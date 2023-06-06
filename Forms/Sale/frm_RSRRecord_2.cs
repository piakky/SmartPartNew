using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartPart.Class;
using System.Threading.Tasks;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SmartPart.Forms.Sale
{
    public partial class frm_RSRRecord_2 : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDelegate();

        #region Variable
        private cls_Struct.StructRSR RSR = new cls_Struct.StructRSR();
        private cls_Struct.ActionMode DataMode;
        private DataSet dsMainData = new DataSet();
        private DataSet dsEdit = new DataSet();
        private DataSet DataTS = new DataSet();
        private DataTable dtAddress = new DataTable();
        private int RSRID = 0;

        private bool IsSaveOK = false;

        double Qty = 0;
        double Zconv = 1;
        double Zquan = 0.00;
        decimal Zuprice = 0;
        decimal Zcog = 0;
        decimal Znet = 0;
        //decimal ZsumVat = 0;
        //decimal ZnosumVat = 0;
        string ZdiscP = "";
        decimal ZdiscA = 0;
        decimal Zvat = 0;
        float ZvatP = 7;
        #endregion

        #region Function

        private void AddItem(ref DataTable dt, DataRow drow, string TsNo, DateTime _date)
        {
            DataRow dr;

            dr = dt.NewRow();
            dr["mode"] = (int)cls_Struct.ActionMode.Add;
            dr["RSRD_PID"] = RSRID;
            dr["LIST_NO"] = AssigNo();
            dr["TSH_ID"] = cls_Library.DBInt(drow["TSH_ID"]);
            dr["TSD_ID"] = cls_Library.DBInt(drow["TSD_ID"]);
            dr["ITEM_ID"] = cls_Library.DBInt(drow["ITEM_ID"]);
            dr["FULL_NAME"] = cls_Library.DBString(drow["FULL_NAME"]);
            dr["MODEL1"] = cls_Library.DBString(drow["MODEL1"]);
            dr["BRAND_ID"] = cls_Library.DBInt(drow["BRAND_ID"]);
            dr["QTY"] = cls_Library.DBDouble(drow["QTY"]);
            dr["CONV"] = cls_Library.DBDouble(drow["CONV"]);
            dr["UPRICE"] = cls_Library.DBDouble(drow["UPRICE"]);
            dr["COG"] = cls_Library.DBDouble(drow["COG"]);
            dr["DISCPER"] = cls_Library.DBString(drow["DISCPER"]);
            dr["DISCA"] = cls_Library.DBDouble(drow["DISCA"]);
            dr["VATL"] = cls_Library.DBDouble(drow["VATL"]);

            //show in grid
            dr["TSH_NO"] = TsNo;
            dr["TSH_DATE"] = _date;

            dt.Rows.Add(dr);
        }

        private void AddDataSourceToGrid()
        {
            try
            {
                DataTable _dtGrid = new DataTable("RSRDETAIL");
                _dtGrid = dsEdit.Tables["RSRDETAIL"].Clone();
                dsEdit.Tables["RSRDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete))
                .ToList<DataRow>().ForEach(f => _dtGrid.ImportRow(f));

                gridRSR.DataSource = _dtGrid;
                gridRSR.RefreshDataSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
            }
        }

        private void AssignDataFromComponent()
        {
            RSR.RSRH_ID = RSRID;
            RSR.RSRH_NO = txtRSRNo.Text.Trim();
            RSR.RSRH_DATE = cls_Library.CDateTime(dateRSR.EditValue);
            //RRS.BSH_ID = cls_Library.CInt()
            RSR.CUS_ID = cls_Library.CInt(sluCus.EditValue);
            RSR.RSRH_ADDRESS = cls_Library.CInt(sluAddress.EditValue);
            RSR.RSRH_STATUS = cls_Library.CByte(luStatus.EditValue);
            RSR.PRINT_NO = cls_Library.CInt16(spinPrintNo.EditValue);
            RSR.LIST_NO = cls_Library.CInt16(spinListNo.EditValue);
            RSR.DELETE_NO = cls_Library.CInt16(spinDeleteNo.EditValue);
            RSR.SALE_PER = cls_Library.CInt(sluPer.EditValue);
            RSR.PER_VAT = cls_Library.CDouble(spinVatePer.EditValue);
            RSR.SUMCOG = cls_Library.CDecimal(spinSumCog.EditValue);
            RSR.VATSUM = cls_Library.CDecimal(spinSumVat.EditValue);
            RSR.NETSUM = cls_Library.CDecimal(spinNet.EditValue);

            //RSR.TBSH_NO = beBSNO.EditValue.ToString();
        }

        private void AssignDataList()
        {
            try
            {
                DataTable dtList = new DataTable();
                dtList = dsEdit.Tables["RSRDETAIL"].Copy();
                dtList.TableName = "RSRDETAIL";

                DataColumn colMode = new DataColumn("mode", typeof(int));

                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        colMode.DefaultValue = cls_Struct.ActionMode.Default;
                        //colChange.DefaultValue = -1;
                        break;
                    case cls_Struct.ActionMode.Copy:
                        colMode.DefaultValue = cls_Struct.ActionMode.Add;
                        //colChange.DefaultValue = 1;
                        break;
                }

                dtList.Columns.Add(colMode);

                dsEdit.Tables.Remove("RSRDETAIL");
                dsEdit.Tables.Add(dtList);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AssignDataList :" + ex.Message);
            }
        }

        private int AssigNo()
        {
            int no = 1;
            try
            {
                List<DataRow> ListNo = dsEdit.Tables["RSRDETAIL"].AsEnumerable().ToList();
                if (ListNo.Count() > 0)
                    no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            return no;
        }

        private void CalculateValue(cls_Global_class.TypeCal category, int RowHandle)
        {
            try
            {
                DataRow drow = gvRSR.GetFocusedDataRow();

                Zquan = cls_Library.CDouble(Qty) * Zconv;

                switch (category)
                {
                    case cls_Global_class.TypeCal.price:
                        if (Zquan > 0)
                        {
                            Zvat = (Znet / 107) * cls_Library.CDecimal(ZvatP);
                            Zcog = Znet - Zvat + ZdiscA;
                            ZdiscP = ((ZdiscA * 100) / Zcog).ToString("#,##0.##");
                            Zuprice = (Zcog * (decimal)Zconv) / cls_Library.CDecimal(Zquan);
                            drow["UPRICE"] = Zuprice;
                            drow["DISCPER"] = "";
                            if (cls_Library.CDouble(ZdiscP) > 0)
                            {
                                drow["DISCPER"] = ZdiscP;
                            }
                            drow["DISCA"] = ZdiscA;
                            drow["VATL"] = Zvat;
                        }
                        break;
                    case cls_Global_class.TypeCal.quantity:
                        if (Zconv == 0) Zconv = 1;
                        Zcog = (Zuprice * (decimal)Zquan) / (decimal)Zconv;

                        ZdiscA = cls_Library.CalFix_TXTdisc(ZdiscP, Zcog);
                        Zvat = (Zcog - ZdiscA) * 7 / 100;
                        Znet = Zcog - ZdiscA + Zvat;
                        drow["DISCA"] = ZdiscA;
                        drow["VATL"] = Zvat;
                        drow["COG"] = Znet;
                        break;
                    case cls_Global_class.TypeCal.disc:
                        //ZdiscA = cls_Library.CDecimal(spinDiscount1.EditValue) + cls_Library.CDecimal(spinDiscount2.EditValue) + cls_Library.CDecimal(spinDiscount3.EditValue);
                        break;
                    case cls_Global_class.TypeCal.unitprice:
                        if (Zconv == 0) Zconv = 1;
                        Zcog = (Zuprice * cls_Library.CDecimal(Zquan)) / (decimal)Zconv;
                        ZdiscA = cls_Library.CalFix_TXTdisc(ZdiscP, Zcog);
                        Zvat = (Zcog - ZdiscA) * 7 / 100;
                        Znet = Zcog - ZdiscA + Zvat;
                        drow["DISCA"] = ZdiscA;
                        drow["VATL"] = Zvat;
                        drow["COG"] = Znet;
                        break;
                    case cls_Global_class.TypeCal.perdisc:
                        if (Zconv == 0) Zconv = 1;
                        Zcog = (Zuprice * cls_Library.CDecimal(Zquan)) / (decimal)Zconv;
                        ZdiscA = cls_Library.CalFix_TXTdisc(ZdiscP, Zcog);
                        Zvat = (Zcog - ZdiscA) * 7 / 100;
                        Znet = Zcog - ZdiscA + Zvat;
                        drow["DISCA"] = ZdiscA;
                        drow["VATL"] = Zvat;
                        drow["COG"] = Znet;
                        break;
                }

                //Zuprice = Zquan == 0 ? 0 : (Zcog * (decimal)Zconv) / Convert.ToDecimal(Zquan);        

                //gvBS.SetRowCellValue(RowHandle, 3"QTY"], cls_Library.CDecimal(Zquan / Zconv));               

                CalsumTotal();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("CalculateValue : " + category + ":" + ex.Message);
            }
        }

        private void CalsumTotal()
        {
            try
            {
                List<DataRow> listRow = dsEdit.Tables["RSRDETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                //SumQty = listRow.AsEnumerable().Sum(x => x.Field<double?>("QTY") ?? 0);
                decimal SumCog = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG") ?? 0);
                //SumVat = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICEVAT") ?? 0);
                //SumNet = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICESUM") ?? 0);

                spinSumCog.EditValue = SumCog;

                //if (cls_Library.DBDecimal(spinCASH.EditValue) == 0)
                //{
                //    spinCASH.EditValue = spinSumCog.EditValue;
                //}

               

                spinSumVat.EditValue = (cls_Library.DBDecimal(spinVatePer.EditValue) * SumCog) / 100;
                spinSumNet.EditValue = cls_Library.DBDecimal(spinSumCog.EditValue) + cls_Library.DBDecimal(spinSumVat.EditValue);
                spinNet.EditValue = spinSumNet.EditValue;

                //หา
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("CalsumTotal :" + ex.Message);
            }
        }

        private void GetAddress(int cusid)
        {
            dtAddress = cls_Data.GetAddress(cusid);

            sluAddress.Properties.DataSource = dtAddress;
            sluAddress.Properties.PopulateViewColumns();
            sluAddress.Properties.View.Columns["ADDRESS_ID"].Visible = false;
            sluAddress.Properties.ValueMember = "ADDRESS_ID";
            sluAddress.Properties.DisplayMember = "ADDRESS_CODE";
        }

        private void GetDataRowItemHandle(cls_Global_class.TypeCal category, int RowHandle)
        {
            switch (category)
            {
                case cls_Global_class.TypeCal.price:
                    Zconv = cls_Library.DBDouble(gvRSR.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvRSR.GetRowCellValue(RowHandle, "QTY"));
                    ZdiscA = cls_Library.DBDecimal(gvRSR.GetRowCellValue(RowHandle, "DISCA"));
                    Zvat = cls_Library.DBDecimal(gvRSR.GetRowCellValue(RowHandle, "VATL"));
                    //Zuprice = cls_Library.DBDecimal(gvRSR.GetRowCellValue(RowHandle, "UPRICE"));
                    break;
                case cls_Global_class.TypeCal.quantity:
                    Zuprice = cls_Library.DBDecimal(gvRSR.GetRowCellValue(RowHandle, "UPRICE"));
                    Zconv = cls_Library.DBDouble(gvRSR.GetRowCellValue(RowHandle, "CONV"));
                    ZdiscP = cls_Library.DBString(gvRSR.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvRSR.GetRowCellValue(RowHandle, "VATL"));
                    break;
                case cls_Global_class.TypeCal.unitprice:
                    Zconv = cls_Library.DBDouble(gvRSR.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvRSR.GetRowCellValue(RowHandle, "QTY"));
                    ZdiscP = cls_Library.DBString(gvRSR.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvRSR.GetRowCellValue(RowHandle, "VATL"));
                    break;
                case cls_Global_class.TypeCal.perdisc:
                    Zconv = cls_Library.DBDouble(gvRSR.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvRSR.GetRowCellValue(RowHandle, "QTY"));
                    Zuprice = cls_Library.DBDecimal(gvRSR.GetRowCellValue(RowHandle, "UPRICE"));
                    ZdiscP = cls_Library.DBString(gvRSR.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvRSR.GetRowCellValue(RowHandle, "VATL"));
                    break;
            }
        }

        private void InitializeControl()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable _dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("id", typeof(int));

            _dt = dt.Clone();
            _dt.TableName = "DocStatus";
            //Open = 1, Print = 2, Receive = 3, POS = 4, ReceiveAndPOS = 5,  Cancel = 99
            for (int i = 1; i <= 6; i++)
            {
                dr = _dt.NewRow();
                switch (i)
                {
                    case 1:
                        dr["Name"] = "เปิด";
                        dr["id"] = i;
                        break;
                    case 2:
                        dr["Name"] = "พิมพ์";
                        dr["id"] = i;
                        break;
                    case 3:
                        dr["Name"] = "รับ+POS";
                        dr["id"] = 5;
                        break;
                    case 4:
                        dr["Name"] = "ยกเลิก";
                        dr["id"] = 99;
                        break;
                }
                _dt.Rows.Add(dr);
            }
            ds.Tables.Add(_dt);


            _dt = dt.Clone();
            _dt.TableName = "TypePayment";
            for (int i = 1; i <= 6; i++)
            {
                dr = _dt.NewRow();
                switch (i)
                {
                    case 1:
                        dr["Name"] = "เงินสด";
                        dr["id"] = i;
                        break;
                    case 2:
                        dr["Name"] = "บัตรต่างๆ";
                        dr["id"] = i;
                        break;
                    case 3:
                        dr["Name"] = "เงินโอน";
                        dr["id"] = i;
                        break;
                    case 4:
                        dr["Name"] = "เช็ค";
                        dr["id"] = i;
                        break;
                    case 5:
                        dr["Name"] = "หักมัดจำ";
                        dr["id"] = i;
                        break;
                    case 6:
                        dr["Name"] = "อื่นๆ";
                        dr["id"] = i;
                        break;
                }
                _dt.Rows.Add(dr);
            }
            ds.Tables.Add(_dt);

            cls_Library.AssignSearchLookUp(sluCus, "M_CUSTOMERS", "รหัสลูกค้า", "ชื่อลูกค้า", cls_Global_class.TypeShow.codename);
        }

        private void LoadData()
        {
            dsMainData = cls_Data.GetRSRById(RSRID);
        }

        private void SaveData()
        {
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return;

                AssignDataFromComponent();
                //AssignList();
                cls_Global_DB.GB_ItemID = 0;
                IsSaveOK = cls_Data.SaveRSR(DataMode, RSR, dsEdit);
                if (IsSaveOK)
                {
                    XtraMessageBox.Show("บันทึกข้อมูลใบกำกับภาษีรับคืนเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //BSID = cls_Global_DB.GB_ItemID;
                    DataMode = cls_Struct.ActionMode.Edit;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Application.DoEvents();
                XtraMessageBox.Show("ไม่สามารถบันทึกใบกำกับภาษีรับคืนได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsSaveOK = false;
            }
        }

        private void SetControl()
        {
            try
            {
                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                        //radioPOstatus.SelectedIndex = 0;
                        //radioDueType.SelectedIndex = 0;
                        break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
                        dateRSR.ReadOnly = true;
                        //sluBiller.ReadOnly = true;
                        sluCus.ReadOnly = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetControl :" + ex.Message);
            }
        }

        private void SetDataTS()
        {
            DataTable dt;
            DateTime dateTS;
            string TSno = string.Empty;


            if (DataTS.Tables.Contains("TSHEADER"))
            {
                DataRow row = DataTS.Tables["TSHEADER"].Rows[0];

                RSR.TSH_ID = cls_Library.DBInt(row["TSH_ID"]);
                TSno = cls_Library.DBString(row["TSH_NO"]);
                dateTS = cls_Library.DBDateTime(row["TSH_DATE"]);
                if (cls_Library.CInt(sluCus.EditValue) <= 0)
                {
                    sluCus.EditValue = cls_Library.DBInt(row["CUS_ID"]);
                    GetAddress(cls_Library.CInt(sluCus.EditValue));
                }
                //Detail
                dt = dsEdit.Tables["RSRDETAIL"].Copy();
                dt.TableName = "RSRDETAIL";
                if (dt.Rows.Count > 0)
                {
                    List<int> listData = dt.AsEnumerable().Where(r => r.Field<int>("TSH_ID") == RSR.TSH_ID).Select(s => s.Field<int>("TSD_ID")).ToList();
                    if (listData.Count > 0)
                    {
                        DataRow dr;
                        int listId = 0;
                        int cnt = 0;
                        for (int i = 0; i < DataTS.Tables["TSDETAIL"].Rows.Count; i++)
                        {
                            dr = DataTS.Tables["TSDETAIL"].Rows[i];

                            listId = cls_Library.DBInt(dr["TSD_ID"]);
                            if (!listData.Contains(listId))
                            {
                                cnt++;
                                AddItem(ref dt, dr, TSno, dateTS);
                            }
                        }

                        if (cnt > 0)
                        {
                            if (dsEdit.Tables.Contains("RSRDETAIL")) dsEdit.Tables.Remove("RSRDETAIL");
                            dsEdit.Tables.Add(dt);
                        }
                    }
                    else
                    {
                        DataTS.Tables["TSDETAIL"].AsEnumerable().ToList().ForEach(f => AddItem(ref dt, f, TSno, dateTS));
                        if (dsEdit.Tables.Contains("RSRDETAIL")) dsEdit.Tables.Remove("RSRDETAIL");
                        dsEdit.Tables.Add(dt);
                    }
                }
                else
                {
                    DataTS.Tables["TSDETAIL"].AsEnumerable().ToList().ForEach(f => AddItem(ref dt, f, TSno, dateTS));
                    if (dsEdit.Tables.Contains("RSRDETAIL")) dsEdit.Tables.Remove("RSRDETAIL");
                    dsEdit.Tables.Add(dt);
                }
                AssignDataList();
                AddDataSourceToGrid();
                CalsumTotal();
            }
        }

        private void SetDataToControl()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetDelegate(SetDataToControl));
            }
            else
            {
                DataRow row;
                try
                {
                    dsEdit = dsMainData.Copy();
                    AssignDataList();
                    switch (DataMode)
                    {
                        case cls_Struct.ActionMode.Add:
                            SetDefaultData();
                            break;
                        case cls_Struct.ActionMode.Edit:
                        case cls_Struct.ActionMode.Copy:
                        case cls_Struct.ActionMode.View:

                            if (dsEdit.Tables["RSRHEADER"].Rows.Count <= 0) return;
                            row = dsEdit.Tables["RSRHEADER"].Rows[0];

                            txtRSRNo.Text = cls_Library.DBString(row["RSRH_NO"]);
                            dateRSR.EditValue = cls_Library.DBDateTime(row["RSRH_DATE"]);
                            sluCus.EditValue = cls_Library.DBInt(row["CUS_ID"]);
                            sluAddress.EditValue = cls_Library.DBInt(row["RSRH_ADDRESS"]);
                            luStatus.EditValue = cls_Library.DBByte(row["RSRH_STATUS"]);
                            spinListNo.EditValue = cls_Library.DBInt16(row["LIST_NO"]);
                            spinPrintNo.EditValue = cls_Library.DBInt16(row["PRINT_NO"]);
                            spinDeleteNo.EditValue = cls_Library.DBInt16(row["DELETE_NO"]);
                            sluPer.EditValue = cls_Library.DBInt(row["SALE_PER"]);
                            spinVatePer.EditValue = cls_Library.DBDouble(row["PER_VAT"]);
                            spinSumCog.EditValue = cls_Library.DBDecimal(row["SUMCOG"]);
                            spinSumVat.EditValue = cls_Library.DBDecimal(row["VATSUM"]);
                            spinSumNet.EditValue = cls_Library.DBDecimal(row["NETSUM"]);
                            spinNet.EditValue = cls_Library.DBDecimal(row["NETSUM"]);

                            //beBSNO.Text = cls_Library.DBString(row["BSH_NO"]);
                            //dateBS.EditValue = cls_Library.DBDateTime(row["BSH_DATE"]);

                            //CalsumTotal();
                            break;
                    }
                    AddDataSourceToGrid();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("SetDataToControl :" + ex.Message);
                }
            }
        }

        private void SetDefaultData()
        {
            //XXX
            try
            {
                txtRSRNo.ReadOnly = true;
                txtRSRNo.BackColor = Color.FromArgb(255, 255, 192);
                dateRSR.EditValue = DateTime.Today;
                luStatus.EditValue = 1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetDefaultData :" + ex.Message);
            }
        }

        private bool VerifyData()
        {
            bool ret = true;
            StringBuilder msg = new StringBuilder();
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return false;

                if (string.IsNullOrEmpty(txtRSRNo.Text))
                {
                    ret = false;
                    msg.AppendLine("ไม่มีเลขที่เอกสาร");
                }

                if (!cls_Library.IsDate(dateRSR.EditValue))
                {
                    ret = false;
                    msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
                }


                if (sluCus.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสลูกค้าไม่ถูกต้อง");
                }

                if (!ret)
                {
                    MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
            }
            return ret;
        }

        #endregion

        public frm_RSRRecord_2(cls_Struct.ActionMode mode, int id)
        {
            InitializeComponent();
            KeyPreview = true;
            DataMode = mode;
            RSRID = id;
            //XXXXXXXXXXXXXXXXXX
            cls_Global_DB.DataInitial = cls_Data.GetDataInitialSale();
        }

        private void frm_RSRRecord_Load(object sender, EventArgs e)
        {
            InitializeControl();
            SetControl();
            Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
            {
                this.Invoke(new SetDelegate(SetDataToControl));
            });
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                SaveData();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sluAddress_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                frm_AddressEtaxList frm = new frm_AddressEtaxList(cls_Library.CInt(sluAddress.EditValue));
                frm.ShowDialog();
                GetAddress(cls_Library.CInt(sluAddress.EditValue));
            }
        }

        private void gvRSR_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void gvRSR_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                if (info.Column.AbsoluteIndex == 8 || info.Column.AbsoluteIndex == 11)
                {
                    view.FocusedRowHandle = info.RowHandle;
                    view.FocusedColumn = info.Column;
                    DXMouseEventArgs.GetMouseArgs(ea).Handled = true;
                    if (ea.Clicks == 2 && ea.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (info.Column.AbsoluteIndex == 8)
                        {
                            DataRow dr = gvRSR.GetFocusedDataRow();
                            if (dr == null) return;
                            int IdBrand = cls_Library.DBInt(dr["BRAND_ID"]);
                            DataTable dtBrand;
                            cls_Data.LoadSpecifyData(string.Format("Select SALE_CODE From M_BRANDS Where BRAND_ID = {0}", IdBrand), out dtBrand, "M_BRANDS");
                            if (dtBrand.Rows.Count > 0)
                            {
                                if (cls_Library.DBByte(dtBrand.Rows[0]["SALE_CODE"]) != 2)
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        frm_ChkPassword frmChk = new frm_ChkPassword();
                        if (frmChk.ShowDialog() == DialogResult.OK)
                        {
                            view.Columns[info.Column.AbsoluteIndex].OptionsColumn.AllowEdit = true;
                            view.ShowEditor();
                        }
                    }
                }
            }
        }

        private void gvRSR_HiddenEditor(object sender, EventArgs e)
        {
            gvRSR.Columns[8].OptionsColumn.AllowEdit = false;
            gvRSR.Columns[11].OptionsColumn.AllowEdit = false;
        }

        private void gvRSR_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
                switch (e.Column.Name)
                {
                    case "col1":  //รหัสสินค้า

                        break;
                    case "col2":  //ชื่อสินค้า
                        break;
                    case "col3":  //ยี่ห้อ
                        break;
                    case "col4":  //รุ่น
                        break;
                    case "col5":  //หน่วบนับ
                        GetDataRowItemHandle(cls_Global_class.TypeCal.perdisc, e.RowHandle);
                        CalculateValue(cls_Global_class.TypeCal.quantity, e.RowHandle);
                        break;
                    case "col6":  //จำนวน
                        Qty = cls_Library.DBDouble(e.Value);
                        GetDataRowItemHandle(cls_Global_class.TypeCal.quantity, e.RowHandle);
                        CalculateValue(cls_Global_class.TypeCal.quantity, e.RowHandle);
                        break;
                    case "col7":  //ราคาต่อหน่วย
                        Zuprice = cls_Library.DBDecimal(e.Value);
                        GetDataRowItemHandle(cls_Global_class.TypeCal.unitprice, e.RowHandle);
                        CalculateValue(cls_Global_class.TypeCal.unitprice, e.RowHandle);
                        break;
                    case "col8":  //รวมเงิน
                        Znet = cls_Library.DBDecimal(e.Value);
                        GetDataRowItemHandle(cls_Global_class.TypeCal.price, e.RowHandle);
                        CalculateValue(cls_Global_class.TypeCal.price, e.RowHandle);
                        break;
                    case "col9":    //อัตราส่วนลด
                        ZdiscP = cls_Library.DBString(e.Value);
                        GetDataRowItemHandle(cls_Global_class.TypeCal.perdisc, e.RowHandle);
                        CalculateValue(cls_Global_class.TypeCal.perdisc, e.RowHandle);
                        break;
                    case "col11":   //ภาษีในรายการ
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("gvRSR_CellValueChanged : " + ex.Message);
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            frm_ChooseTSRSR frm = new frm_ChooseTSRSR();
            frm.CUS_ID = cls_Library.CInt(sluCus.EditValue);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataTS = frm.DataChoose;
                SetDataTS();
            }
        }

        private void frm_RSRRecord_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btSave.PerformClick();
                    break;
                case Keys.Escape:
                    btClose.PerformClick();
                    break;
            }
        }
    }
}