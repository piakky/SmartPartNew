using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartPart.Class;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SmartPart.Forms.Sale
{
    public partial class frm_PSRecord_Backup : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDelegate();

        #region Variable
        private cls_Struct.StructPS PS = new cls_Struct.StructPS();
        private cls_Struct.ActionMode DataMode;
        private DataSet dsMainData = new DataSet();
        private DataSet dsEdit = new DataSet();
        private int PSID = 0;

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

        private void AddDataSourceToGrid()
        {
            try
            {
                DataTable _dtGrid = new DataTable("PSDETAIL");
                _dtGrid = dsEdit.Tables["PSDETAIL"].Clone();
                dsEdit.Tables["PSDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete))
                .ToList<DataRow>().ForEach(f => _dtGrid.ImportRow(f));

                gridPS.DataSource = _dtGrid;
                gridPS.RefreshDataSource();

                spinListNo.EditValue = _dtGrid.Rows.Count;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
            }
        }

        private void AddItem(int ItemId, string ItemCode)
        {
            List<DataRow> list = new List<DataRow>();
            bool Dadd = false;
            int i;

            try
            {
                DataSet ds = cls_Data.GetListProductById(ItemId);

                list = dsEdit.Tables["PSDETAIL"].AsEnumerable().Where(r => r.Field<string>("ITEM_CODE").Equals(ItemCode)).ToList();
                if (list.Count == 0) Dadd = true;

                if (Dadd)
                {
                    DataRow dr = dsEdit.Tables["PSDETAIL"].NewRow();
                    dr["mode"] = (int)cls_Struct.ActionMode.Add;
                    dr["PSD_PID"] = PSID;
                    dr["LIST_NO"] = AssigNo();
                    dr["ITEM_ID"] = ItemId;
                    dr["ITEM_CODE"] = ItemCode;

                    dr["CONV"] = 1;
                    if (ds.Tables.Contains("M_ITEMS") && ds.Tables["M_ITEMS"].Rows.Count > 0)
                    {
                        DataRow drow = ds.Tables["M_ITEMS"].Rows[0];
                        dr["FULL_NAME"] = cls_Library.DBString(drow["FULL_NAME"]);
                        dr["MODEL1"] = cls_Library.DBString(drow["FULL_NAME"]);
                        dr["BRAND_ID"] = cls_Library.DBInt(drow["BRAND_ID"]);
                        dr["BRAND_CODE"] = "";
                        //dr["BRAND_NAME"] = "";
                        dr["UNIT_ID"] = 0;
                        dr["UNIT_CODE"] = "";
                        //dr["UNIT_NAME"] = "";
                        if (ds.Tables["D_ITEM_UNITS"].Rows.Count > 0)
                        {
                            //List<DataRow> lst = ds.Tables["D_ITEM_UNITS"].AsEnumerable().Where(r => r.Field<Int16>("LIST_NO") == 1).ToList();
                            //if (lst.Count > 0)
                            //{
                            //    dr["UNIT_ID"] = cls_Library.DBInt(lst[0]["UNIT_ID"]);
                            //    dr["CONV"] = cls_Library.DBDouble(lst[0]["MULTIPLY_QTY"]);
                            //}
                            for (i = 0; i < ds.Tables["D_ITEM_UNITS"].Rows.Count; i++)
                            {
                                if (cls_Library.DBInt(ds.Tables["D_ITEM_UNITS"].Rows[i]["SALE_STATUS"]) == 1)
                                {
                                    dr["UNIT_ID"] = cls_Library.DBInt(ds.Tables["D_ITEM_UNITS"].Rows[i]["UNIT_ID"]);
                                    dr["CONV"] = cls_Library.DBDouble(ds.Tables["D_ITEM_UNITS"].Rows[i]["MULTIPLY_QTY"]);
                                    break;
                                }
                            }
                        }
                    }

                    dr["QTY"] = 1;

                    dr["UPRICE"] = cls_Data.GetPriceListByItem(ItemId, cls_Library.DBInt(dr["UNIT_ID"]));
                    dr["DISCA"] = 0;
                    dr["VATL"] = 0;
                    dr["COG"] = cls_Library.DBDecimal(dr["UPRICE"]);
                    dsEdit.Tables["PSDETAIL"].Rows.Add(dr);
                    CalsumTotal();
                }
                else
                {
                    list[0]["QTY"] = cls_Library.DBInt(list[0]["QTY"]) + 1;
                    GetDataRowItemHandle(cls_Global_class.TypeCal.quantity, cls_Library.DBInt(list[0]["LIST_NO"]));
                    Zuprice = cls_Library.DBDecimal(list[0]["UPRICE"]);
                    Zconv = cls_Library.DBDouble(list[0]["CONV"]);
                    ZdiscP = cls_Library.DBString(list[0]["DISCPER"]);
                    Zvat = cls_Library.DBDecimal(list[0]["VATL"]);
                    Qty = cls_Library.DBDouble(list[0]["QTY"]);
                    CalculateValue(cls_Global_class.TypeCal.quantity, cls_Library.DBInt(list[0]["LIST_NO"]));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddItem : " + ex.Message);
            }
            finally
            {
                AddDataSourceToGrid();
            }
        }

        private void AssignDataFromComponent()
        {
            PS.PSH_ID = PSID;
            PS.PSH_NO = txtPSNo.Text.Trim();
            PS.PSH_DATE = cls_Library.CDateTime(datePS.EditValue);
            PS.CUS_ID = cls_Library.CInt(sluCus.EditValue);
            PS.PSH_STATUS = cls_Library.CByte(luStatus.EditValue);
            PS.PRINT_NO = cls_Library.CInt16(spinPrintNo.EditValue);
            PS.LIST_NO = cls_Library.CInt16(spinListNo.EditValue);
            PS.DELETE_NO = cls_Library.CInt16(spinDeleteNo.EditValue);
            PS.SALE_PER = cls_Library.CInt(sluPer.EditValue);
            PS.RES_PER = cls_Library.CInt16(sluResPer.EditValue);
            //PS.PRINT_TYPE = (char)luPrintType.EditValue;  //XXXX
            PS.CASH_AMT = cls_Library.CDecimal(spinCASH.EditValue);
            PS.CARD_AMT = cls_Library.CDecimal(spinCARD.EditValue);
            PS.TRANS_AMT = cls_Library.CDecimal(spinTRANS.EditValue);
            PS.CHEQUE_AMT = cls_Library.CDecimal(spinCHEQUE.EditValue);
            PS.OTHER_AMT = cls_Library.CDecimal(spinOTHER.EditValue);
            PS.SUM_AMT = cls_Library.CDecimal(spinSUM_AMT.EditValue);

            //PS.PER_VAT = cls_Library.CDouble(spinVatePer.EditValue);  //XXXX
            //PS.SUMCOG = cls_Library.CDecimal(spinSumCog.EditValue);
            //PS.VATSUM = cls_Library.CDecimal(spinSumVat.EditValue);
            PS.NETSUM = cls_Library.CDecimal(spinNet.EditValue);
        }

        private void AssignDataList()
        {
            try
            {
                DataTable dtList = new DataTable();
                dtList = dsEdit.Tables["PSDETAIL"].Copy();
                dtList.TableName = "PSDETAIL";

                //DataColumn colMode = new DataColumn("mode", typeof(int));
                DataColumn[] colMode = new DataColumn[5];
                for (int i = 0; i < colMode.Length; i++) colMode[i] = new DataColumn("mode", typeof(int));
                //DataColumn colChange = new DataColumn("Change", typeof(int));

                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        for (int i = 0; i < colMode.Length; i++) colMode[i].DefaultValue = cls_Struct.ActionMode.Default;
                        //colChange.DefaultValue = -1;
                        break;
                    case cls_Struct.ActionMode.Copy:
                        for (int i = 0; i < colMode.Length; i++) colMode[i].DefaultValue = cls_Struct.ActionMode.Add;
                        //colChange.DefaultValue = 1;
                        break;
                }

                dtList.Columns.Add(colMode[0]);
                //dtList.Columns.Add(colChange);

                dsEdit.Tables.Remove("PSDETAIL");
                dsEdit.Tables.Add(dtList);

                //การชำระเงิน
                dsEdit.Tables["MAP_CARD"].Columns.Add(colMode[1]);
                dsEdit.Tables["MAP_TRANSFER_PAY"].Columns.Add(colMode[2]);
                //dsEdit.Tables["MAP_CHEQUE"].Columns.Add(colMode[3]);
                dsEdit.Tables["MAP_OTHER"].Columns.Add(colMode[4]);

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
                List<DataRow> ListNo = dsEdit.Tables["PSDETAIL"].AsEnumerable().ToList();
                if (ListNo.Count() > 0)
                    no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            return no;
        }

        private void AssignRepositoryGrid()
        {
            //repoSearchItem.DataSource = cls_Global_DB.DataInitial.Tables["M_ITEMS"];
            //repoSearchItem.ValueMember = "_id";
            //repoSearchItem.DisplayMember = "code";

            //repoSearchBrand.DataSource = cls_Global_DB.DataInitial.Tables["M_BRANDS"];
            //repoSearchBrand.ValueMember = "_id";
            //repoSearchBrand.DisplayMember = "name";
        }

        private void CalculateValue(cls_Global_class.TypeCal category, int RowHandle)
        {
            try
            {
                DataRow drow = gvPS.GetFocusedDataRow();

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

                //gvPS.SetRowCellValue(RowHandle, 3"QTY"], cls_Library.CDecimal(Zquan / Zconv));               

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
                List<DataRow> listRow = dsEdit.Tables["PSDETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();

                decimal SumCog = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG") ?? 0);

                spinCASH.EditValue = Math.Round(SumCog,2);

                DoCalculationPayment();

                //SumQty = listRow.AsEnumerable().Sum(x => x.Field<double?>("QTY") ?? 0);
                //SumCog = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG") ?? 0);
                //SumVat = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICEVAT") ?? 0);
                //SumNet = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICESUM") ?? 0);

                spinNet.EditValue = Math.Round(SumCog, 2);

                //spinSumQTY.EditValue = SumQty;
                //spinSumPrice.EditValue = SumCog;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("CalsumTotal :" + ex.Message);
            }
        }

        private void CalSumValuePay(cls_Struct.TypePay _type)
        {
            switch (_type)
            {
                case cls_Struct.TypePay.Cash:
                    break;
                case cls_Struct.TypePay.Card:
                    spinCARD.EditValue = dsEdit.Tables["MAP_CARD"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Sum(x => x.Field<decimal?>("AMOUNT") ?? 0);
                    break;
                case cls_Struct.TypePay.Trans:
                    spinTRANS.EditValue = dsEdit.Tables["MAP_TRANSFER_PAY"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Sum(x => x.Field<decimal?>("AMOUNT") ?? 0);
                    break;
                case cls_Struct.TypePay.Cheque:
                    spinCHEQUE.EditValue = dsEdit.Tables["MAP_CHEQUE"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Sum(x => x.Field<decimal?>("AMOUNT") ?? 0);
                    break;
                case cls_Struct.TypePay.Deposit:
                    break;
                case cls_Struct.TypePay.Other:
                    spinOTHER.EditValue = dsEdit.Tables["MAP_OTHER"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Sum(x => x.Field<decimal?>("AMOUNT") ?? 0);
                    break;
            }

            DoCalculationPayment();
        }

        private void DeleteDataDetail()
        {
            int ID = 0, NO = 0;
            int ListId = 0;
            int[] SelectRow = { };
            DataRow[] dr = null;
            DataRow[] ListRow = null;
            try
            {
                if (dsEdit.Tables["PSDETAIL"].Rows.Count > 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPS;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();
                SelectRow = gvPS.GetSelectedRows();
                if (row == null) return;
                if (SelectRow.Length <= 1)
                {
                if (!int.TryParse(gvPS.GetRowCellValue(SelectRow[0], "PSD_ID").ToString(), out ID)) ID = 0; // ดึง Data จาก Rowที่เลือก
                if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                if (ID <= 0)
                {
                    if (!int.TryParse(gvPS.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                    dr = dsEdit.Tables["PSDETAIL"].Select("LIST_NO =" + NO);
                    if (dr.Count() > 0)
                    dsEdit.Tables["PSDETAIL"].Rows.Remove(dr[0]);

                    AddDataSourceToGrid();
                    CalsumTotal();
                    return;
                }
                if (!int.TryParse(gvPS.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                dr = dsEdit.Tables["PSDETAIL"].Select("LIST_NO =" + NO);
                if (dr.Count() > 0)
                {
                    dr[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
                    //Sum Delete Detail
                    spinDeleteNo.EditValue = dsEdit.Tables["PSDETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete) && item.Field<bool>("DELETE_ISCNT") == true).Count();
                }
                }
                else
                {
                if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                for (int i = 0; i < SelectRow.Length; i++)
                {
                    if (!int.TryParse(gvPS.GetRowCellValue(SelectRow[i], "PSD_ID").ToString(), out ID)) ID = 0;
                    if (ID <= 0)
                    {
                    try
                    {
                        if (!int.TryParse(gvPS.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out ListId)) ListId = 0;
                        ListRow = dsEdit.Tables["PSDETAIL"].Select("LIST_NO =" + ListId);
                        dsEdit.Tables["PSDETAIL"].Rows.Remove(ListRow[0]);
                        gvPS.FocusedRowHandle = 0;
                    }
                    catch { }
                    }
                    else
                    {
                    if (!int.TryParse(gvPS.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out NO)) NO = 0;
                    DataRow[] Roww = dsEdit.Tables["PSDETAIL"].Select("LIST_NO =" + NO);
                    if (Roww.Length > 0)
                    {
                        Roww[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
                        //Roww[0]["Change"] = 1;
                    }
                    }
                }

                //Sum Delete Detail
                spinDeleteNo.EditValue = dsEdit.Tables["PSDETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete) && item.Field<bool>("DELETE_ISCNT") == true).Count();
                }
            }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("DeleteDataDetail :" + ex.Message);
            }
            finally
            {
                CalsumTotal();
                AddDataSourceToGrid();
            }
        }

        private void DoCalculationPayment()
        {
            List<DataRow> listRow = dsEdit.Tables["PSDETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();

            decimal SumCog = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG") ?? 0);

            //spinSUM_AMT.EditValue = cls_Library.CDecimal(spinCASH.EditValue) + cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinOTHER.EditValue);
            spinOTHER.EditValue = cls_Library.CDecimal(SumCog) - (cls_Library.CDecimal(spinCASH.EditValue) + cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue));
            spinSUM_AMT.EditValue = cls_Library.CDecimal(spinCASH.EditValue) + cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinOTHER.EditValue);

        }

        private void GetDataRowItemHandle(cls_Global_class.TypeCal category, int RowHandle)
        {
            switch (category)
            {
                case cls_Global_class.TypeCal.price:
                    Zconv = cls_Library.DBDouble(gvPS.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvPS.GetRowCellValue(RowHandle, "QTY"));
                    ZdiscA = cls_Library.DBDecimal(gvPS.GetRowCellValue(RowHandle, "DISCA"));
                    Zvat = cls_Library.DBDecimal(gvPS.GetRowCellValue(RowHandle, "VATL"));
                    //Zuprice = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "UPRICE"));
                    break;
                case cls_Global_class.TypeCal.quantity:
                    Zuprice = cls_Library.DBDecimal(gvPS.GetRowCellValue(RowHandle, "UPRICE"));
                    Zconv = cls_Library.DBDouble(gvPS.GetRowCellValue(RowHandle, "CONV"));
                    ZdiscP = cls_Library.DBString(gvPS.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvPS.GetRowCellValue(RowHandle, "VATL"));
                    break;
                case cls_Global_class.TypeCal.unitprice:
                    Zconv = cls_Library.DBDouble(gvPS.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvPS.GetRowCellValue(RowHandle, "QTY"));
                    ZdiscP = cls_Library.DBString(gvPS.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvPS.GetRowCellValue(RowHandle, "VATL"));
                    break;
                case cls_Global_class.TypeCal.perdisc:
                    Zconv = cls_Library.DBDouble(gvPS.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvPS.GetRowCellValue(RowHandle, "QTY"));
                    Zuprice = cls_Library.DBDecimal(gvPS.GetRowCellValue(RowHandle, "UPRICE"));
                    ZdiscP = cls_Library.DBString(gvPS.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvPS.GetRowCellValue(RowHandle, "VATL"));
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
            //cls_Library.AssignSearchLookUp(sluResPer, "M_PERSONALS", "รหัสผู้รับผิดชอบ", "ชื่อผู้รับผิดชอบ", cls_Global_class.TypeShow.code);
            cls_Library.AssignSearchLookUp(sluPer, "M_USERS", "รหัสพนักงานขาย", "ชื่อพนักงานขาย", cls_Global_class.TypeShow.codename);
            cls_Library.AssignSearchLookUp(sluResPer, "M_USERS", "รหัสผู้รับผิดชอบ", "ชื่อผู้รับผิดชอบ", cls_Global_class.TypeShow.name);

            repoBrand.DataSource = cls_Global_DB.DataInitial.Tables["M_BRANDS"];
            repoBrand.PopulateViewColumns();
            repoBrand.View.Columns["_id"].Visible = false;
            repoBrand.View.Columns["code"].Visible = false;
            repoBrand.View.Columns["name"].Visible = false;
            repoBrand.ValueMember = "_id";
            repoBrand.DisplayMember = "name";

            repoUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
            repoUnit.PopulateViewColumns();
            repoUnit.View.Columns["_id"].Visible = false;
            repoUnit.View.Columns["code"].Visible = false;
            repoUnit.View.Columns["name"].Visible = false;
            repoUnit.ValueMember = "_id";
            repoUnit.DisplayMember = "name";
        }

        private void LoadData()
        {
            dsMainData = cls_Data.GetPSById(PSID);
        }

        private void SaveData()
        {
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return;

                AssignDataFromComponent();
                //AssignList();
                cls_Global_DB.GB_ItemID = 0;
                IsSaveOK = cls_Data.SavePS(DataMode, PS, dsEdit);
                if (IsSaveOK)
                {
                    XtraMessageBox.Show("บันทึกข้อมูลใบรับมัดจำเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //BSID = cls_Global_DB.GB_ItemID;
                    DataMode = cls_Struct.ActionMode.Edit;

                    //if (!_bwLoad.IsBusy)
                    //{
                    //  this.UseWaitCursor = true;
                    //  _bwLoad.RunWorkerAsync();
                    //  this.UseWaitCursor = false;
                    //}
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Application.DoEvents();
                XtraMessageBox.Show("ไม่สามารถบันทึกใบรับมัดจำได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    datePS.ReadOnly = true;
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

                        if (dsEdit.Tables["PSHEADER"].Rows.Count <= 0) return;
                        row = dsEdit.Tables["PSHEADER"].Rows[0];

                        txtPSNo.Text = cls_Library.DBString(row["PSH_NO"]);
                        datePS.EditValue = cls_Library.DBDateTime(row["PSH_DATE"]);
                        sluCus.EditValue = cls_Library.DBInt(row["CUS_ID"]);
                        luStatus.EditValue = cls_Library.DBByte(row["PSH_STATUS"]);
                        sluResPer.EditValue = cls_Library.DBInt(row["RES_PER"]);
                        //luPaymentType.EditValue = cls_Library.DBByte(row["PAYMENT_TYPE"]);
                        spinListNo.EditValue = cls_Library.DBInt16(row["LIST_NO"]);
                        spinPrintNo.EditValue = cls_Library.DBInt16(row["PRINT_NO"]);
                        spinDeleteNo.EditValue = cls_Library.DBInt16(row["DELETE_NO"]);
                        sluPer.EditValue = cls_Library.DBInt(row["SALE_PER"]);
                        spinCASH.EditValue = cls_Library.DBDecimal(row["CASH_AMT"]);
                        spinCARD.EditValue = cls_Library.DBDecimal(row["CARD_AMT"]);
                        spinTRANS.EditValue = cls_Library.DBDecimal(row["TRANS_AMT"]);
                        spinCHEQUE.EditValue = cls_Library.DBDecimal(row["CHEQUE_AMT"]);
                        spinOTHER.EditValue = cls_Library.DBDecimal(row["OTHER_AMT"]);
                        spinSUM_AMT.EditValue = cls_Library.DBDecimal(row["SUM_AMT"]);


                        //luPrintType.EditValue = cls_Library.DBString(row["PRINT_TYPE"]);
                        //spinVatePer.EditValue = cls_Library.DBDouble(row["PER_VAT"]);
                        //spinSumCog.EditValue = cls_Library.DBDecimal(row["SUMCOG"]);
                        //spinSumVat.EditValue = cls_Library.DBDecimal(row["VATSUM"]);
                        //spinSumNet.EditValue = cls_Library.DBDecimal(row["NETSUM"]);
                        spinNet.EditValue = cls_Library.DBDecimal(row["NETSUM"]);

                        CalsumTotal();
                        break;
                    }
                    AddDataSourceToGrid();
                    txtItem2.Focus();
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
                txtPSNo.ReadOnly = true;
                txtPSNo.BackColor = Color.FromArgb(255, 255, 192);
                datePS.EditValue = DateTime.Today;
                luStatus.EditValue = 1;
                sluPer.EditValue = cls_Global_class.GB_Userid;
                //luPaymentType.EditValue = 1;
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

                if (string.IsNullOrEmpty(txtPSNo.Text))
                {
                    ret = false;
                    msg.AppendLine("ไม่มีเลขที่เอกสาร");
                }

                if (!cls_Library.IsDate(datePS.EditValue))
                {
                    ret = false;
                    msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
                }


                if (sluCus.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสลูกค้าไม่ถูกต้อง");
                }

                if (sluResPer.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสผู้รับผิดชอบไม่ถูกต้อง");
                }

                if (!ret)
                {
                    MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return ret;
                }

                if (cls_Library.CDecimal(spinSUM_AMT.EditValue) != cls_Library.CDecimal(spinNet.EditValue))
            {
                ret = false;
                MessageBox.Show("จำนวนเงินและยอดรับชำระต้องเท่ากัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch (Exception)
            {
            }
            return ret;
        }
        #endregion

        public frm_PSRecord_Backup(cls_Struct.ActionMode mode, int id)
        {
            InitializeComponent();
            KeyPreview = true;
            DataMode = mode;
            PSID = id;
            cls_Global_DB.DataInitial = cls_Data.GetDataInitialSale();
            gvPS.GotFocus += GvPS_GotFocus;
            txtItem.GotFocus += TxtItem_GotFocus;
            txtItem.Select();
        }

        private void frm_PSRecord_Load(object sender, EventArgs e)
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

        private void gvPS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void TxtItem_GotFocus(object sender, EventArgs e)
        {
        }

        private void GvPS_GotFocus(object sender, EventArgs e)
        {
            //RowPosition = true;
            DataRow dr = gvPS.GetFocusedDataRow();
            if (dr == null) return;

            string ItemCode = cls_Library.DBString(dr["ITEM_CODE"]);
            int ItemID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemCode, "ITEMS", "ITEM_ID"));

            //CalDisplayInfo(dr, 1, ItemID);
            //CalDisplayInfo(dr, 2, ItemID);
            //CalDisplayInfo(dr, 3, ItemID);
            //CalDisplayInfo(dr, 4, ItemID);

            //txtDecription.Text = ItemCode + "     " + cls_Data.GetNameFromTBname(ItemID, "ITEMS", "FULL_NAME");
            //txtDecription.Visible = true;
        }

        private void spinCASH_EditValueChanged(object sender, EventArgs e)
        {
            if (spinCASH.IsEditorActive)
            {
                DoCalculationPayment();
            }
        }

        private void spinCARD_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinCARD.IsEditorActive)
            //{
            //    DoCalculationPayment();
            //}
        }

        private void spinTRANS_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinTRANS.IsEditorActive)
            //{
            //    DoCalculationPayment();
            //}
        }

        private void spinCHEQUE_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinCASH.IsEditorActive)
            //{
            //    DoCalculationPayment();
            //}
        }

        private void spinOTHER_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinOTHER.IsEditorActive)
            //{
            //    DoCalculationPayment();
            //}
        }

        private void gvPS_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
                XtraMessageBox.Show("gvPS_CellValueChanged : " + ex.Message);
            }
        }

        private void spinCARD_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frm_CardRecord frmCard = new frm_CardRecord(2);
                frmCard.DataTransPay = dsEdit.Tables["MAP_CARD"];
                frmCard.IdData = PSID;
                if (frmCard.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = dsEdit.Tables["MAP_CARD"].Copy();
                    dsEdit.Tables.Remove("MAP_CARD");
                    dsEdit.Tables.Add(frmCard.DataTransPay.Copy());
                    CalSumValuePay(cls_Struct.TypePay.Card);
                }
            }
        }

        private void spinTRANS_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frm_TransferPayRecord frmTrans = new frm_TransferPayRecord(2);
                frmTrans.DataTransPay = dsEdit.Tables["MAP_TRANSFER_PAY"];
                frmTrans.IdData = PSID;
                if (frmTrans.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = dsEdit.Tables["MAP_TRANSFER_PAY"].Copy();
                    dsEdit.Tables.Remove("MAP_TRANSFER_PAY");
                    dsEdit.Tables.Add(frmTrans.DataTransPay.Copy());
                    CalSumValuePay(cls_Struct.TypePay.Trans);
                }
            }
        }

        private void spinOTHER_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frm_OtherRecord frmTrans = new frm_OtherRecord(2);
                frmTrans.DataTransPay = dsEdit.Tables["MAP_OTHER"];
                frmTrans.IdData = PSID;
                if (frmTrans.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = dsEdit.Tables["MAP_OTHER"].Copy();
                    dsEdit.Tables.Remove("MAP_OTHER");
                    dsEdit.Tables.Add(frmTrans.DataTransPay.Copy());
                    CalSumValuePay(cls_Struct.TypePay.Other);
                }
            }
        }

        private void txtItem_EditValueChanged(object sender, EventArgs e)
        {
            if (txtItem2.IsEditorActive)
            {
                if (txtItem2.Text.Length <= 0) return;

                int id = cls_Data.GetItemID(txtItem2.Text.Trim());
                if (id > 0)
                {
                    AddItem(id, txtItem2.Text.Trim());
                    //txtItem.Text = "";
                }
                //SetItemToList();
            }
        }

        private void gvPS_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                if ( info.Column.AbsoluteIndex == 8)
                {
                    view.FocusedRowHandle = info.RowHandle;
                    view.FocusedColumn = info.Column;
                    DXMouseEventArgs.GetMouseArgs(ea).Handled = true;
                    if (ea.Clicks == 2 && ea.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (info.Column.AbsoluteIndex == 8)
                        {
                            DataRow dr = gvPS.GetFocusedDataRow();
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
                        //frm_ChkPassword frmChk = new frm_ChkPassword();
                        //if (frmChk.ShowDialog() == DialogResult.OK)
                        //{
                            view.Columns[info.Column.AbsoluteIndex].OptionsColumn.AllowEdit = true;
                            view.ShowEditor();
                        //}
                    }
                }
            }
        }

        private void gvPS_HiddenEditor(object sender, EventArgs e)
        {
            gvPS.Columns[8].OptionsColumn.AllowEdit = false;
            gvPS.Columns[11].OptionsColumn.AllowEdit = false;
        }

        private void frm_PSRecord_KeyDown(object sender, KeyEventArgs e)
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

        private void txtItem_MouseUp(object sender, MouseEventArgs e)
        {
            txtItem.SelectAll();
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {

            if (txtItem.Text.Length <= 0) return;

            int id = cls_Data.GetItemID(txtItem.Text.Trim());
            if (id > 0)
            {
                AddItem(id, txtItem.Text.Trim());
                txtItem.Text = "";
                TxtItem_GotFocus(sender, e);

            }
        }
    }
}