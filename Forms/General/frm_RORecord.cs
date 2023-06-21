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
    public partial class frm_RORecord : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private cls_Struct.StructRO RO = new cls_Struct.StructRO();
        private BackgroundWorker _bwLoad = null;
        private int ROID = 0;
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
                dsMainData = cls_Data.GetROById(ROID);
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
                DataTable _dtGrid = new DataTable("RODETAIL");
                _dtGrid = dsEdit.Tables["RODETAIL"].Clone();
                dsEdit.Tables["RODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete))
                .ToList<DataRow>().ForEach(f => _dtGrid.ImportRow(f));

                gridRO.DataSource = _dtGrid;
                gridRO.RefreshDataSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
            }
        }

        private void AssignDataFromComponent()
        {
            RO.ROH_ID = ROID;
            RO.RO_NO = txtRONo.Text;
            RO.RO_DATE = cls_Library.CDateTime(dateRO.EditValue);
            RO.CUS_ID = cls_Library.CInt(sluCus.EditValue);
            RO.VAT_STATUS = cls_Library.CByte(comboVatStatus.SelectedIndex + 1);
            RO.RO_STATUS = cls_Library.CByte(comboROStatus.SelectedIndex + 1);
            RO.PRINT_NO = cls_Library.CByte(spinPrint.EditValue);
            RO.LIST_NO = dsEdit.Tables["RODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Count();
            RO.SUM_DOC = cls_Library.CDecimal(spinSumDoc.EditValue);
            RO.DISCLST_DOC = cls_Library.CDecimal(spinDiscLST.EditValue);
            RO.VAT_DOC = cls_Library.CDecimal(spinVatDoc.EditValue);
            RO.NET_DOC = cls_Library.CDecimal(spinNetDoc.EditValue);
            RO.BARCODE = txtBarcode.Text.Trim();
        }

        private void AssignDataList()
        {
            try
            {
                DataTable dtList = new DataTable();
                dtList = dsEdit.Tables["RODETAIL"].Copy();
                dtList.TableName = "RODETAIL";

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

                dsEdit.Tables.Remove("RODETAIL");
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
        //        if (dsSave.Tables.Contains("RODETAIL")) dsSave.Tables.Remove("RODETAIL");
        //        DataTable dt = dsEdit.Tables["RODETAIL"].Clone();
        //        dt.TableName = "RODETAIL";
        //        List<DataRow> listDetail = dsEdit.Tables["RODETAIL"].AsEnumerable().Where(r => r.Field<int>("mode") > -1 && r.Field<int>("Change") == 1).ToList();
        //        if (listDetail.Count > 0)
        //        {
        //            dt = listDetail.CopyToDataTable();
        //            dt.TableName = "RODETAIL";
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
                List<DataRow> ListNo = dsEdit.Tables["RODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
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

                if (!cls_Global_DB.DataInitial.Tables.Contains("M_RETURN_REASONS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_RETURN_REASONS"));
                repoSearchReason.DataSource = cls_Global_DB.DataInitial.Tables["M_RETURN_REASONS"];
                repoSearchReason.ValueMember = "_id";
                repoSearchReason.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AssignRepositoryGrid :" + ex.Message);
            }
        }

        private void CalsumTotal()
        {
            decimal SumDoc = 0, SumDisc = 0, SumVaT = 0, SumNet = 0;
            try
            {
                List<DataRow> listRow = dsEdit.Tables["RODETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                SumDoc = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG") ?? 0);
                SumDisc = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("DISCA") ?? 0);
                SumVaT = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICEVAT") ?? 0);
                SumNet = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("NET_DOC") ?? 0);

                spinSumDoc.EditValue = Math.Round(SumDoc,2);
                spinDiscLST.EditValue = SumDisc;
                spinVatDoc.EditValue = Math.Round(SumVaT,2);
                    //spinNetDoc.EditValue = SumNet;
                    spinNetDoc.EditValue = Math.Round(SumDoc + SumVaT, 2);
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
                if (dsEdit.Tables["RODETAIL"].Rows.Count > 0)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvRO;
                    if ((view.FocusedRowHandle < 0)) return;
                    DataRow row = view.GetFocusedDataRow();
                    SelectRow = gvRO.GetSelectedRows();
                    if (row == null) return;
                    if (SelectRow.Length <= 1)
                    {
                        if (!int.TryParse(gvRO.GetRowCellValue(SelectRow[0], "ROD_ID").ToString(), out ID)) ID = 0; // ดึง Data จาก Rowที่เลือก
                        if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                        if (ID <= 0)
                        {
                            if (!int.TryParse(gvRO.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                            dr = dsEdit.Tables["RODETAIL"].Select("LIST_NO =" + NO);
                            if (dr.Count() > 0)
                                dsEdit.Tables["RODETAIL"].Rows.Remove(dr[0]);

                            AddDataSourceToGrid();
                            return;
                        }
                        if (!int.TryParse(gvRO.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                        dr = dsEdit.Tables["RODETAIL"].Select("LIST_NO =" + NO);
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
                            if (!int.TryParse(gvRO.GetRowCellValue(SelectRow[i], "ROD_ID").ToString(), out ID)) ID = 0;
                            if (ID <= 0)
                            {
                                try
                                {
                                    if (!int.TryParse(gvRO.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out ListId)) ListId = 0;
                                    ListRow = dsEdit.Tables["RODETAIL"].Select("LIST_NO =" + ListId);
                                    dsEdit.Tables["RODETAIL"].Rows.Remove(ListRow[0]);
                                    gvRO.FocusedRowHandle = 0;
                                }
                                catch { }
                            }
                            else
                            {
                                if (!int.TryParse(gvRO.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out NO)) NO = 0;
                                DataRow[] Roww = dsEdit.Tables["RODETAIL"].Select("LIST_NO =" + NO);
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
            DataRow dr;
            try
            {
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvRO;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != cls_Struct.ActionMode.Add) return;
            }
            dr = view.GetFocusedDataRow();

            frm_RODetailInput frmInput = new frm_RODetailInput();
            frmInput.Text = "แก้ไขสินค้า";
            frmInput.SetEditData = dr;
            frmInput.SetDatasetEdit = dsEdit;
            frmInput.SetListNo = AssigNo();
            frmInput.InitialDialog(mode);
            frmInput.txtRONo.Text = txtRONo.Text;
            frmInput.dateRO.EditValue = dateRO.EditValue;
            frmInput.sluCus.Text = sluCus.SelectedText;
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
                comboVatStatus.Properties.Items.Add("Vat นอก");
                comboVatStatus.Properties.Items.Add("Vat ใน");
                comboVatStatus.Properties.Items.Add("ไม่มี Vat");

                comboROStatus.Properties.Items.Add("เปิด");
                comboROStatus.Properties.Items.Add("พิมพ์");
                comboROStatus.Properties.Items.Add("โอน");
                comboROStatus.Properties.Items.Add("ปิด");
                comboROStatus.Properties.Items.Add("ส่งคืน/ยกเลิก");

                comboROStatus.SelectedIndex = 0;

                cls_Library.AssignSearchLookUp(sluCus, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");
                if (DataMode == cls_Struct.ActionMode.View) btSave.Visible = false;
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
                IsSaveOK = cls_Data.SaveRO(DataMode, RO, dsEdit);
                if (IsSaveOK)
                {
                    XtraMessageBox.Show("บันทึกข้อมูลใบส่งคืนสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ROID = cls_Global_DB.GB_ItemID;
                    DataMode = cls_Struct.ActionMode.Edit;
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
                XtraMessageBox.Show("ไม่สามารถบันทึกส่งคืนสินค้าได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsSaveOK = false;
            }
        }

        private void SetControl()
        {
            try
            {
                if (DataMode != cls_Struct.ActionMode.Add)
                {
                    dateRO.ReadOnly = true;
                    sluCus.ReadOnly = true;                    
                    comboROStatus.ReadOnly = true;
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

                comboVatStatus.ReadOnly = dsEdit.Tables["RODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Count() > 0;

                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                        SetDefaultData();
                        break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.Copy:
                    case cls_Struct.ActionMode.View:
                        if (dsEdit.Tables["ROHEADER"].Rows.Count <= 0) return;
                        row = dsEdit.Tables["ROHEADER"].Rows[0];

                        if (cls_Library.DBbool(row["ACTIVE"]))
                        {
                            dateRO.ReadOnly = true;
                            dateRO.BackColor = Color.FromArgb(255, 255, 192);
                        }

                        txtRONo.Text = row["RO_NO"].ToString();
                        dateRO.EditValue = cls_Library.DBDateTime(row["RO_DATE"]);
                        txtBarcode.Text = row["BARCODE"].ToString();
                        sluCus.EditValue = cls_Library.DBInt(row["CUS_ID"]);
                        comboVatStatus.SelectedIndex = cls_Library.DBByte(row["VAT_STATUS"]) - 1;
                        comboROStatus.SelectedIndex = cls_Library.DBByte(row["RO_STATUS"]) - 1;
                        spinPrint.EditValue = cls_Library.DBInt16(row["PRINT_NO"]);

                        spinSumDoc.EditValue = cls_Library.DBDecimal(row["SUM_DOC"]);
                        spinVatDoc.EditValue = cls_Library.DBDecimal(row["VAT_DOC"]);
                        spinNetDoc.EditValue = cls_Library.DBDecimal(row["NET_DOC"]);
                        spinDiscLST.EditValue = cls_Library.DBDecimal(row["DISCLST_DOC"]);
                            spinNetDoc.EditValue =Math.Round((cls_Library.DBDecimal(row["SUM_DOC"]) + cls_Library.DBDecimal(row["VAT_DOC"])),2);
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
                txtRONo.ReadOnly = true;
                txtRONo.BackColor = Color.FromArgb(255, 255, 192);
                dateRO.EditValue = DateTime.Today;
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

                if (string.IsNullOrEmpty(txtRONo.Text))
                {
                    ret = false;
                    msg.AppendLine("ไม่มีเลขที่เอกสาร");
                }

                if (dateRO.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
                }
                if (sluCus.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("ข้อมูลพ่อค้าไม่ถูกต้อง");
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

        public frm_RORecord(cls_Struct.ActionMode mode, int id)
        {
            InitializeComponent();
            KeyPreview = true;
            DataMode = mode;
            ROID = id;
            InitialDialog();
            txtRONo.Focus();
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
            if(VerifyData()) SaveData();
        }

        private void frm_RORecord_Load(object sender, EventArgs e)
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

        private void frm_RORecord_KeyDown(object sender, KeyEventArgs e)
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

        private void gvRO_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.IsGetData)
                {
                    switch (e.Column.FieldName)
                    {
                        case "colReturnQty":
                            if (!Double.TryParse(gvRO.GetListSourceRowCellValue(e.ListSourceRowIndex, "MARK_NO").ToString(), out Zquan)) Zquan = 0; //XXXXXXXXXXXXXXX
                            if (!Double.TryParse(gvRO.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;
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