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

namespace SmartPart.Forms.General
{
    public partial class frm_RCRecord : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private cls_Struct.StructRC RC = new cls_Struct.StructRC();
        private BackgroundWorker _bwLoad = null;
        private int RCID = 0;
        private cls_Struct.ActionMode DataMode;
        private DataSet dsMainData = new DataSet();
        private DataSet dsEdit = new DataSet();
        //private DataSet dsSave = new DataSet();
        private bool IsSaveOK = false;
        private double Zquan, Zconv;
        #endregion

        #region Thread
        private void ThreadStart()
        {
            _bwLoad = new BackgroundWorker();
            _bwLoad.WorkerReportsProgress = true;
            _bwLoad.WorkerSupportsCancellation = true;
            _bwLoad.DoWork += new DoWorkEventHandler(_bwLoad_DoWork);
            _bwLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bwLoad_RunWorkerCompleted);

            _bwLoad.RunWorkerAsync();
        }

        void _bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                SetDataToControl();
            }
            catch { }
            finally { Cursor = Cursors.Default; }
        }

        void _bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dsMainData = cls_Data.GetRCById(RCID);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region Function

        private void AddDataSourceToGrid()
        {
            try
            {
                DataTable _dtGrid = new DataTable("RCDETAIL");
                _dtGrid = dsEdit.Tables["RCDETAIL"].Clone();
                dsEdit.Tables["RCDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete))
                .ToList<DataRow>().ForEach(f => _dtGrid.ImportRow(f));

                gridRC.DataSource = _dtGrid;
                gridRC.RefreshDataSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
            }
        }

        private void AssignDataFromComponent()
        {
            RC.RCH_ID = RCID;
            RC.RC_NO = txtRCNo.Text.Trim();
            RC.RC_DATE = cls_Library.CDateTime(dateRC.EditValue);
            RC.RC_STATUS = cls_Library.CByte(comboRCStatus.SelectedIndex + 1);
            RC.INV_NO = txtInvNo.Text.Trim();
            RC.INV_DATE = cls_Library.CDateTime(dateInv.EditValue);
            RC.SELL_TYPE = cls_Library.CByte(comboSelltype.SelectedIndex + 1);
            RC.CUS_ID = cls_Library.CInt(sluCus.EditValue);
            RC.CATEGORY_ID = cls_Library.CInt(sluItemType.EditValue);
            RC.CREDIT_TERM = cls_Library.CInt(spinCredit.Text);
            RC.VAT_STATUS = cls_Library.CByte(comboVatStatus.SelectedIndex + 1);
            RC.LIST_NO = dsEdit.Tables["RCDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Count();
            RC.DISCLST = cls_Library.CDecimal(spinDiscLST.EditValue);
            RC.SUM_DOC = cls_Library.CDecimal(spinSumDoc.EditValue);
            RC.VAT_DOC = cls_Library.CDecimal(spinVatDoc.EditValue);
            RC.NET_DOC = cls_Library.CDecimal(spinNetDoc.EditValue);
            RC.SUM_REAL = cls_Library.CDecimal(spinSumReal.EditValue);
            RC.VAT_REAL = cls_Library.CDecimal(spinVatReal.EditValue);
            RC.NET_REAL = cls_Library.CDecimal(spinNetReal.EditValue);
            RC.BARCODE = txtBarcode.Text.Trim();
        }

        private void AssignDataList()
        {
            try
            {
                DataTable dtList = new DataTable();
                dtList = dsEdit.Tables["RCDETAIL"].Copy();
                dtList.TableName = "RCDETAIL";

                DataColumn colMode = new DataColumn("mode", typeof(int));
                //DataColumn colChange = new DataColumn("Change", typeof(int));

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
                //dtList.Columns.Add(colChange);

                dsEdit.Tables.Remove("RCDETAIL");
                dsEdit.Tables.Add(dtList);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AssignDataList :" + ex.Message);
            }
        }

        //private void AssignList()
        //{
        //    try
        //    {
        //        if (dsSave.Tables.Contains("RCDETAIL")) dsSave.Tables.Remove("RCDETAIL");
        //        DataTable dt = dsEdit.Tables["RCDETAIL"].Clone();
        //        dt.TableName = "RCDETAIL";
        //        List<DataRow> listDetail = dsEdit.Tables["RCDETAIL"].AsEnumerable().Where(r => r.Field<int>("mode") > -1 && r.Field<int>("Change") == 1).ToList();
        //        if (listDetail.Count > 0)
        //        {
        //            dt = listDetail.CopyToDataTable();
        //            dt.TableName = "RCDETAIL";
        //        }
        //        dsSave.Tables.Add(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show("AssignList :" + ex.Message);
        //    }
        //}

        private int AssigNo()
        {
            int no = 1;
            try
            {
                List<DataRow> ListNo = dsEdit.Tables["RCDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                if (ListNo.Count() > 0)
                    no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            return no;
        }

        private void AssignRepositoryGrid()
        {
            try
            {

                repoSearchBrand.DataSource = cls_Global_DB.DataInitial.Tables["M_BRANDS"];
                repoSearchBrand.ValueMember = "_id";
                repoSearchBrand.DisplayMember = "name";

                repoSearchUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
                repoSearchUnit.ValueMember = "_id";
                repoSearchUnit.DisplayMember = "name";

                repoSearchItem.DataSource = cls_Global_DB.DataInitial.Tables["M_ITEMS"];
                repoSearchItem.ValueMember = "_id";
                repoSearchItem.DisplayMember = "code";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AssignRepositoryGrid :" + ex.Message);
            }
        }

        private void CalsumTotal()
        {
            decimal sumD = 0, sumVatD = 0, sumNetD = 0;
            decimal sumR = 0, sumVatR = 0, sumNetR = 0;
            decimal SumDisc = 0;
            try
            {
            List<DataRow> listRow = dsEdit.Tables["RCDETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
            sumD = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG_DOC") ?? 0);
            sumVatD = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("VAT_DOC") ?? 0);
            sumNetD = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG_DOC") ?? 0);
            sumR = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG_REAL") ?? 0);
            sumVatR = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("VAT_REAL") ?? 0);
            sumNetR = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG_REAL") ?? 0);

                if (cls_Library.DBDouble(listRow[0]["QTY"]) > 0) listRow[0]["NET_DOC_AC"] = Math.Round(cls_Library.DBDecimal(listRow[0]["COG_DOC"]) / cls_Library.DBDecimal(listRow[0]["QTY"]),2);

            switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
            {
                case cls_Global_class.TypePrice.SUMVAT:
                sumNetD = Math.Round(sumD + sumVatD, 2);
                sumNetR = Math.Round(sumR + sumVatR, 2);
                break;
                case cls_Global_class.TypePrice.NOSUMVAT:
                sumNetD = Math.Round(sumNetD, 2);
                sumNetR = Math.Round(sumNetR, 2);
                break;
                case cls_Global_class.TypePrice.NOTVAT:
                sumNetD = Math.Round(sumNetD, 2);
                sumNetR = Math.Round(sumNetR, 2);
                break;
            }

            spinDiscLST.EditValue = SumDisc;

            spinSumDoc.EditValue = sumD;
            spinVatDoc.EditValue = sumVatD;
            spinNetDoc.EditValue = sumNetD + sumVatD;

            spinSumReal.EditValue = sumR;
            spinVatReal.EditValue = sumVatR;
            spinNetReal.EditValue = sumNetR + sumVatR;
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("CalsumTotal :" + ex.Message);
            }
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
                if (dsEdit.Tables["RCDETAIL"].Rows.Count > 0)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvRC;
                    if ((view.FocusedRowHandle < 0)) return;
                    DataRow row = view.GetFocusedDataRow();
                    SelectRow = gvRC.GetSelectedRows();
                    if (row == null) return;
                    if (SelectRow.Length <= 1)
                    {
                        if (!int.TryParse(gvRC.GetRowCellValue(SelectRow[0], "RCD_ID").ToString(), out ID)) ID = 0; // ดึง Data จาก Rowที่เลือก
                        if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                        if (ID <= 0)
                        {
                            if (!int.TryParse(gvRC.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                            dr = dsEdit.Tables["RCDETAIL"].Select("LIST_NO =" + NO);
                            if (dr.Count() > 0)
                                dsEdit.Tables["RCDETAIL"].Rows.Remove(dr[0]);

                            AddDataSourceToGrid();
                            return;
                        }
                        if (!int.TryParse(gvRC.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                        dr = dsEdit.Tables["RCDETAIL"].Select("LIST_NO =" + NO);
                        if (dr.Count() > 0)
                        {
                            dr[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
                            //dr[0]["Change"] = 1;
                        }
                    }
                    else
                    {
                        if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                        for (int i = 0; i < SelectRow.Length; i++)
                        {
                            if (!int.TryParse(gvRC.GetRowCellValue(SelectRow[i], "RCD_ID").ToString(), out ID)) ID = 0;
                            if (ID <= 0)
                            {
                                try
                                {
                                    if (!int.TryParse(gvRC.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out ListId)) ListId = 0;
                                    ListRow = dsEdit.Tables["RCDETAIL"].Select("LIST_NO =" + ListId);
                                    dsEdit.Tables["RCDETAIL"].Rows.Remove(ListRow[0]);
                                    gvRC.FocusedRowHandle = 0;
                                }
                                catch { }
                            }
                            else
                            {
                                if (!int.TryParse(gvRC.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out NO)) NO = 0;
                                DataRow[] Roww = dsEdit.Tables["RCDETAIL"].Select("LIST_NO =" + NO);
                                if (Roww.Length > 0)
                                {
                                    Roww[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
                                    //Roww[0]["Change"] = 1;
                                }
                            }
                        }
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

        private void InitialDialog()
        {
            ThreadStart();
            LoadDefaultData();
        }

        private void InitialDialogFrom(cls_Struct.ActionMode mode)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            DataRow dr;
            try
            {
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvRC;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != cls_Struct.ActionMode.Add) return;
            }
            dr = view.GetFocusedDataRow();

            frm_RCDetailInput frmInput = new frm_RCDetailInput();
            frmInput.Text = "แก้ไขสินค้า";
            frmInput.SetEditData = dr;
            frmInput.SetDatasetEdit = dsEdit;
            frmInput.SetListNo = AssigNo();
            frmInput.InitialDialog(mode);
            frmInput.txtInvNo.Text = txtInvNo.Text;
            frmInput.dateInvNo.EditValue = dateInv.EditValue;
            frmInput.comboVatStatus.SelectedIndex = comboSelltype.SelectedIndex;
            frmInput.txtCus.Text = sluCus.SelectedText;
            frmInput.txtCategory.Text = sluItemType.SelectedText;
            frmInput.txtCredit.Text = spinCredit.EditValue.ToString();
            frmInput.comboVatStatus.SelectedIndex = comboVatStatus.SelectedIndex;

            if (frmInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dsEdit = frmInput.SetDatasetEdit;
                CalsumTotal();
                AddDataSourceToGrid();
            }
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("InitialDialogFrom :" + ex.Message);
            }
        }

        private void LoadDefaultData()
        {
            try
            {
            comboRCStatus.Properties.Items.Add("เปิด");
            comboRCStatus.Properties.Items.Add("ปิด");
            comboRCStatus.Properties.Items.Add("ยกเลิก");

            comboRCStatus.SelectedIndex = 0;

            comboSelltype.Properties.Items.Add("ปกติ");
            comboSelltype.Properties.Items.Add("เบิกห้าง");
            comboSelltype.Properties.Items.Add("ชดเชย");
            comboSelltype.Properties.Items.Add("Back Order");
            comboSelltype.Properties.Items.Add("สินค้าตัวอย่าง");

            comboVatStatus.Properties.Items.Add("Vat นอก");
            comboVatStatus.Properties.Items.Add("Vat ใน");
            comboVatStatus.Properties.Items.Add("ไม่มี Vat");

            cls_Library.AssignSearchLookUp(sluCus, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");
            //cls_Library.AssignSearchLookUp(sluItemType, "M_CATEGORIES", "รหัสประเภทสินค้า", "ชื่อประเภทสินค้า");
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
            }
        }

        private void SaveData()
        {
            try
            {
            if (DataMode == cls_Struct.ActionMode.View) return;
            AssignDataFromComponent();
            //AssignList();
            cls_Global_DB.GB_ItemID = 0;
            IsSaveOK = cls_Data.SaveRC(DataMode, RC, dsEdit);
            if (IsSaveOK)
            {
                XtraMessageBox.Show("บันทึกข้อมูลใบรับสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RCID = cls_Global_DB.GB_ItemID;
                DataMode = cls_Struct.ActionMode.Edit;
                //PIPI
                cls_Data.UpdateUnActiveVoucherByType(2);
                cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.RC, RCID);
                if (!_bwLoad.IsBusy)
                {
                this.UseWaitCursor = true;
                _bwLoad.RunWorkerAsync();
                this.UseWaitCursor = false;
                }
            }            
            }
            catch (Exception ex)
            {
            Application.DoEvents();      
            XtraMessageBox.Show("ไม่สามารถบันทึกใบรับสินค้าได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
                        dateRC.ReadOnly = true;
                        sluCus.ReadOnly = true;
                        sluItemType.ReadOnly = true;
                        spinCredit.ReadOnly = true;
                        comboVatStatus.ReadOnly = true;
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

                if (dsEdit.Tables["RCHEADER"].Rows.Count <= 0) return;
                row = dsEdit.Tables["RCHEADER"].Rows[0];

                if (cls_Library.DBbool(row["ACTIVE"]))
                {
                    dateRC.ReadOnly = true;
                    dateRC.BackColor = Color.FromArgb(255, 255, 192);
                }

                txtRCNo.Text = row["RC_NO"].ToString();
                dateRC.EditValue = cls_Library.DBDateTime(row["RC_DATE"]);
                txtInvNo.Text = row["INV_NO"].ToString();
                dateInv.EditValue = cls_Library.DBDateTime(row["INV_DATE"]);
                comboSelltype.SelectedIndex = cls_Library.DBByte(row["SELL_TYPE"]) - 1;
                sluCus.EditValue = cls_Library.DBInt(row["CUS_ID"]);
                sluItemType.EditValue = cls_Library.DBInt(row["CATEGORY_ID"]);

                if (!cls_Global_DB.DataInitial.Tables.Contains("D_VENDOR_CREDIT_TERMS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("D_VENDOR_CREDIT_TERMS", cls_Library.DBInt(row["CUS_ID"])));
                else
                {
                    cls_Global_DB.DataInitial.Tables.Remove("D_VENDOR_CREDIT_TERMS");
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("D_VENDOR_CREDIT_TERMS", cls_Library.DBInt(row["CUS_ID"])));
                }
                cls_Library.AssignSearchLookUp(sluItemType, "D_VENDOR_CREDIT_TERMS", "รหัสประเภทสินค้า", "ชื่อประเภทสินค้า");
                sluItemType.Properties.View.Columns["VAT_STATUS"].Caption = "สถานะ VAT";
                sluItemType.Properties.View.Columns["CREDIT_TERM"].Caption = "เครดิตเทอม";
                if (cls_Global_DB.DataInitial.Tables["D_VENDOR_CREDIT_TERMS"].Rows.Count > 0)
                {
                    sluItemType.EditValue = cls_Library.DBInt(row["CATEGORY_ID"]); ;
                }
                spinCredit.EditValue = cls_Library.DBInt(row["CREDIT_TERM"]);
                comboVatStatus.SelectedIndex = cls_Library.DBByte(row["VAT_STATUS"]) - 1;
                spinSumDoc.EditValue = cls_Library.DBDecimal(row["SUM_DOC"]);
                spinVatDoc.EditValue = cls_Library.DBDecimal(row["VAT_DOC"]);
                spinNetDoc.EditValue = cls_Library.DBDecimal(row["NET_DOC"]) + cls_Library.DBDecimal(row["VAT_DOC"]);
                spinSumReal.EditValue = cls_Library.DBDecimal(row["SUM_REAL"]);
                spinVatReal.EditValue = cls_Library.DBDecimal(row["VAT_REAL"]);
                spinNetReal.EditValue = cls_Library.DBDecimal(row["NET_REAL"]) + cls_Library.DBDecimal(row["VAT_REAL"]);
                txtBarcode.Text = row["BARCODE"].ToString();
                break;
            }
            AddDataSourceToGrid();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("SetDataToControl :" + ex.Message);
            }
        }

        private void SetDefaultData()
        {
            //XXX
            try
            {
                txtRCNo.ReadOnly = true;
                txtRCNo.BackColor = Color.FromArgb(255, 255, 192);
                dateRC.EditValue = DateTime.Today;
                comboSelltype.SelectedIndex = 0;
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

            if (string.IsNullOrEmpty(txtRCNo.Text))
            {
                ret = false;
                msg.AppendLine("ไม่มีเลขที่เอกสาร");
            }

            if (dateRC.EditValue == null)
            {
                ret = false;
                msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
            }
            if (dateInv.EditValue == null)
            {
                ret = false;
                msg.AppendLine("วันที่ Invoice ตามเอกสารไม่ถูกต้อง");
            }
            if (sluCus.EditValue == null)
            {
                ret = false;
                msg.AppendLine("ข้อมูลพ่อค้าไม่ถูกต้อง");
            }
            if ((sluItemType.EditValue == null) || (sluItemType.Text == "เลือกประเภทสินค้า"))
            {
                ret = false;
                msg.AppendLine("ประเภทสินค้าไม่ถูกต้อง");
            }
            if ((comboVatStatus.EditValue == null) || (comboVatStatus.Text == ""))
            {
                ret = false;
                msg.AppendLine("สถานะ Vat ไม่ถูกต้อง");
            }

        

            if (!ret)
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }
            catch (Exception)
            {
            }
            return ret;
        }
        #endregion

        public frm_RCRecord(cls_Struct.ActionMode mode, int id)
        {
            InitializeComponent();
            KeyPreview = true;
            DataMode = mode;
            RCID = id;
            InitialDialog();
            txtRCNo.Focus();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            InitialDialogFrom(cls_Struct.ActionMode.Edit);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DeleteDataDetail();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
            SaveData();
            DialogResult = DialogResult.OK;
            }
        }

        private void frm_RCRecord_Load(object sender, EventArgs e)
        {
            AssignRepositoryGrid();
            SetControl();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (IsSaveOK)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void frm_RCRecord_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.F2:
                btSave.PerformClick();
                break;
            case Keys.F7:
                btEdit.PerformClick();
                break;
            case Keys.F8:
                btDelete.PerformClick();
                break;
            case Keys.Escape:
                btClose.PerformClick();
                break;
            }
        }

        private void sluCus_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
            if (!sluCus.IsEditorActive) return;
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);

            if (!cls_Global_DB.DataInitial.Tables.Contains("D_VENDOR_CREDIT_TERMS"))
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("D_VENDOR_CREDIT_TERMS", id));
            else
            {
                cls_Global_DB.DataInitial.Tables.Remove("D_VENDOR_CREDIT_TERMS");
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("D_VENDOR_CREDIT_TERMS", id));
            }
            cls_Library.AssignSearchLookUp(sluItemType, "D_VENDOR_CREDIT_TERMS", "รหัสประเภทสินค้า", "ชื่อประเภทสินค้า");
            sluItemType.Properties.View.Columns["VAT_STATUS"].Caption = "สถานะ VAT";
            sluItemType.Properties.View.Columns["CREDIT_TERM"].Caption = "เครดิตเทอม";
            if (cls_Global_DB.DataInitial.Tables["D_VENDOR_CREDIT_TERMS"].Rows.Count > 0)
            {
                sluItemType.EditValue = cls_Library.DBInt(cls_Global_DB.DataInitial.Tables["D_VENDOR_CREDIT_TERMS"].Rows[0]["_id"]);
                spinCredit.EditValue = cls_Library.DBInt(cls_Global_DB.DataInitial.Tables["D_VENDOR_CREDIT_TERMS"].Rows[0]["CREDIT_TERM"]); 
                switch (cls_Library.DBString(cls_Global_DB.DataInitial.Tables["D_VENDOR_CREDIT_TERMS"].Rows[0]["VAT_STATUS"]))
                {
                case "VAT นอก":
                    comboVatStatus.SelectedIndex = 0;
                    break;
                case "VAT ใน":
                    comboVatStatus.SelectedIndex = 1;
                    break;
                case "ไม่มี VAT":
                    comboVatStatus.SelectedIndex = 2;
                    break;
                }
            }
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message);
            }
        
        }

        private void sluItemType_EditValueChanged(object sender, EventArgs e)
        {
            if (!sluItemType.IsEditorActive) return;
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
            List<DataRow> _list = cls_Global_DB.DataInitial.Tables["D_VENDOR_CREDIT_TERMS"].AsEnumerable().Where(r => r.Field<int>("_id") == id).ToList();
            if (_list.Count > 0)
            {
                spinCredit.EditValue = cls_Library.DBInt(_list[0]["CREDIT_TERM"]);
                //comboVatStatus.SelectedIndex = cls_Library.DBByte(_list[0]["VAT_STATUS"]) - 1;
                if (cls_Library.DBString(_list[0]["VAT_STATUS"]) == "VAT นอก")
                comboVatStatus.SelectedIndex =0;
                if (cls_Library.DBString(_list[0]["VAT_STATUS"]) == "VAT ใน")
                comboVatStatus.SelectedIndex = 1;
                if (cls_Library.DBString(_list[0]["VAT_STATUS"]) == "ไม่มี VAT")
                comboVatStatus.SelectedIndex = 2;
            }
            }
        }

        private void gvRC_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.IsGetData)
                {
                    switch (e.Column.FieldName)
                    {
                        case "col_quan":
                            if (!Double.TryParse(gvRC.GetListSourceRowCellValue(e.ListSourceRowIndex, "QTY").ToString(), out Zquan)) Zquan = 0;
                            if (!Double.TryParse(gvRC.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;
                            e.Value = cls_Library.CDecimal(Zquan / Zconv);
                            break;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}