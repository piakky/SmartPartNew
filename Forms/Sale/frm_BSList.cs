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
using SmartPart.Class;
using DevExpress.XtraSplashScreen;
using System.Threading;
using SmartPart.Forms.General;

namespace SmartPart.Forms.Sale
{
    public partial class frm_BSList : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtBS = new DataTable();
        cls_Struct.GetListBS GetBS = new cls_Struct.GetListBS();
        bool LoadBegin = false;
        bool datachange = false;

        #region " Function "
        public void DeleteData()
        {
            int[] selectRow;
            int _id = 0;
            try
            {
                DataRow row = gvList.GetFocusedDataRow();
                if (row == null) return;

                selectRow = gvList.GetSelectedRows();

                if (selectRow.Length <= 1)
                {
                    _id = cls_Library.DBInt(row["BSH_ID"]);

                    //Check Data Can Delete
                    if (!cls_Data.CheckDataCanDel(1, _id))
                    {
                        if (cls_Data.DeleteBS(_id)) dtBS.Rows.Remove(row);
                    }
                    else
                    {
                        XtraMessageBox.Show(string.Format("บิลขาย : {0} มีการเชื่อมโยง ไม่สามารถลบได้", cls_Library.DBString(row["BSH_NO"])));
                    }
                }
                else
                {
                    DataRow[] Rrow;
                    for (int i = 0; i < selectRow.Length; i++)
                    {
                        _id = cls_Library.DBInt(gvList.GetRowCellValue(selectRow[i], "BSH_ID"));
                        Rrow = dtBS.Select("BSH_ID = " + _id);
                        if (!cls_Data.CheckDataCanDel(1, _id))
                        {
                            if (cls_Data.DeleteBS(_id))
                            {
                                //Rrow = dtBS.Select("BSH_ID = " + _id);
                                dtBS.Rows.Remove(Rrow[0]);
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(string.Format("บิลขาย : {0} มีการเชื่อมโยง ไม่สามารถลบได้", cls_Library.DBString(Rrow[0]["BSH_NO"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DeleteData : " + ex.Message);
            }
        }

        private void GetDataChoose()
        {
            try
            {
                //GetPO = new cls_Struct.GetListPO();
                //GetPO.Customer = cls_Library.CInt(sluCus.EditValue);
                //GetPO.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
                //GetPO.DateTo = cls_Library.CDateTime(dateTo.EditValue);
                //GetPO.POStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);
                //GetPO.Barcode = txtBarcode.Text;

                if (LoadBegin)
                {
                    dtBS = cls_Data.GetListBSOption();
                }
                else
                {
                    GetBS = new cls_Struct.GetListBS();
                    GetBS.Customer = cls_Library.CInt(sluCus.EditValue);
                    GetBS.Personal = cls_Library.CInt(sluPer.EditValue);
                    GetBS.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
                    GetBS.DateTo = cls_Library.CDateTime(dateTo.EditValue);
                    GetBS.BSstatus = cls_Library.DBInt(comboStatus.SelectedIndex);
                    GetBS.DateType = cls_Library.DBInt(comboTypedate.SelectedIndex);
                    dtBS = cls_Data.GetListBS(GetBS);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("GetDataChoose :" + ex.Message);
            }
        }

        public void InitialDialogFormOpenBill()
        {
            frm_OpenBill frmInput;
            frmInput = new frm_OpenBill();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "ขายสินค้า";
                #region "Assign Lookup"
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                int CUSid = frmInput.CUS_ID;
                int PERid = frmInput.PER_ID;

                cls_Sales.Sale_ISCASH = false;
                cls_Sales.Sale_Cus = CUSid;
                cls_Sales.Sale_User = PERid;


                //if (cls_Sales.FilterOption == 0) return;
                this.Cursor = Cursors.WaitCursor;

                InitialDialogForm(cls_Struct.ActionMode.Add);

                this.Cursor = Cursors.Default;

                //Class_Library mc = new Class_Library();
                //Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
                //Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

                //if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
                //{
                //    return;
                //}
                //if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
                //{
                //    this.Cursor = Cursors.WaitCursor;

                //    cls_Form.GB_Instance[i].instanceused = true;
                //    cls_Form.GB_Instance[i].instanceusedid = tag;
                //    cls_Form.GB_Instance[i].instanceform = new frm_BSRecord(0, 0);
                //    cls_Form.GB_Instance[i].instanceform.Text = "ขายสินค้า";
                //    cls_Form.GB_Instance[i].instanceform.Tag = tag;
                //    cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                //    cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                //    cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                //    cls_Form.GB_Instance[i].instanceform.Show();
                //    this.Cursor = Cursors.Default;
                //}

                //frm_BSRecord frm = new frm_BSRecord(0, 0);
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.WindowState = FormWindowState.Maximized;

                //frm.Text = "ขายสินค้า -" + strMode;
                //frm.MinimizeBox = false;
                //frm.ShowInTaskbar = false;
                //if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                //{
                //    if (!bwList.IsBusy)
                //    {
                //        this.UseWaitCursor = true;
                //        bwList.RunWorkerAsync();
                //    }
                //    this.UseWaitCursor = false;
                //    this.Cursor = Cursors.Default;
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            try
            {
                DataRow row = gvList.GetFocusedDataRow();
                int pid = 0;
                string strMode = "";

                switch (mode)
                {
                    case cls_Struct.ActionMode.Add:
                        strMode = " [เปิดใหม่][Auto Save]";
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["BSH_ID"]);
                        strMode = " [แก้ไข][Auto Save]";
                        break;
                    case cls_Struct.ActionMode.Copy:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["BSH_ID"]);
                        strMode = " [คัดลอก][Auto Save]";
                        break;
                    case cls_Struct.ActionMode.View:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["BSH_ID"]);
                        strMode = " [ดูข้อมูล][Auto Save]";
                        break;
                }

                frm_BSRecord frm = new frm_BSRecord(mode, pid, cls_Sales.Sale_Cus, cls_Sales.Sale_User);
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Text = "ขายสินค้า -" + strMode;
                frm.MinimizeBox = false;
                frm.ShowInTaskbar = false;
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    
                }
                if (!bwList.IsBusy)
                {
                    this.UseWaitCursor = true;
                    bwList.RunWorkerAsync();
                }
                this.UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                gridList.Select();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("InitialDialogForm :" + ex.Message);
            }
        }

        public void InitialDialogFormfilter()
        {
            FilterBS frmInput;
            frmInput = new FilterBS();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "Condition";
                #region "Assign Lookup"
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                cls_Sales.FilterOption = frmInput.MainCondition;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        private void LoadData()
        {
            GetDataChoose();
            //dtPO = cls_Data.GetListPO();
            //cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
        }

        private void LoadDefaultData()
        {
            try
            {
                cls_Library.AssignSearchLookUp(sluCus, "M_CUSTOMERS", "รหัสลูกค้า", "ชื่อลูกค้า",cls_Global_class.TypeShow.name);
                cls_Library.AssignSearchLookUp(sluPer, "M_USERS", "รหัสพนักงาน", "ชื่อพนักงาน", cls_Global_class.TypeShow.name);

                datachange = false;

                comboStatus.Properties.Items.Clear();
                comboStatus.Properties.Items.Add("ทุกสถานะ");
                comboStatus.Properties.Items.Add("เปิด");
                comboStatus.Properties.Items.Add("พิมพ์");
                comboStatus.Properties.Items.Add("ปิด");
                comboStatus.Properties.Items.Add("POST");
                comboStatus.Properties.Items.Add("ยกเลิก");
                comboStatus.Properties.Items.Add("บิลที่มีรายการลบ");
                comboStatus.SelectedIndex = 0;


                comboTypedate.SelectedIndex = 1;

                dateFrom.EditValue = cls_Library.Date_CvDMY(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, false);
                dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, false);

                switch (cls_Sales.FilterOption)
                {
                    case 7:
                    case 8:
                        comboTypedate.SelectedIndex = 0;
                        dateFrom.Enabled = false;
                        dateTo.Enabled = false;
                        break;
                }

                datachange = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
            }
        }
        #endregion

        public frm_BSList()
        {
            InitializeComponent();
            SplashScreenManager.ShowForm(this, typeof(frm_WaitForm), true, true, false);
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(10);
            }
            LoadBegin = true;
            this.KeyPreview = true;
            cls_Global_DB.DataInitial = cls_Data.GetDataInitialSale();
            LoadDefaultData();
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
            SplashScreenManager.CloseForm();
            gridList.Select();
        }

        private void bwList_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }
      
        private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //repoSearchCus.DataSource = cls_Global_DB.DataInitial.Tables["M_VENDORS"];
            //repoSearchCus.ValueMember = "_id";
            //repoSearchCus.DisplayMember = "code";
            
            gridList.DataSource = dtBS;
            gridList.RefreshDataSource();

            //Set focus Active or last row
            //List<DataRow> listdata = dtBS.AsEnumerable().Where(r => r.Field<bool>("ACTIVE") == true).ToList<DataRow>();
            //if (listdata.Count > 0)
            //{
            //    gvPO.FocusedRowHandle = dtPO.Rows.IndexOf(listdata[0]);
            //}
            //else
            //{
            //    gvPO.FocusedRowHandle = 0;
            //}
            gvList.FocusedRowHandle = 0;
            LoadBegin = false;
        }

        private void BTexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTdelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void BTadd_Click(object sender, EventArgs e)
        {
            InitialDialogFormOpenBill();         
        }

        private void BTedit_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.Edit);
        }

        private void frm_BSList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class_Library mc = new Class_Library();
            Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
            ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
            cls_Global_DB.GB_GroupReplace = 0;
            cls_Global_DB.GB_GroupJoin = 0;
            //Force garbage collection.
            GC.Collect();

            // Wait for all finalizers to complete before continuing.
            GC.WaitForPendingFinalizers();
        }

        private void gvList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtCusName.Text = "";
            txtAmount.Text = "";
            txtDate.Text = "";

            DataRow dr = gvList.GetFocusedDataRow();
            if (dr == null) return;

            DataTable dt = (DataTable)gridList.DataSource;

            txtCusName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(dr["CUS_ID"]), "CUSTOMERS", "CUSTOMER_NAME");
            txtAmount.Text = cls_Library.CDecimal(dt.Compute("Sum(NETSUM)", string.Empty)).ToString("#,##0.00");
            int dd = cls_Library.DBDateTime(dr["BSH_DATE"]).Day;
            int mm = cls_Library.DBDateTime(dr["BSH_DATE"]).Month;
            int yy = cls_Library.DBDateTime(dr["BSH_DATE"]).Year;

            if (yy < 2500) yy = yy + 543;

            yy = yy - 2500;

            txtDate.Text = dd.ToString("00") + "/" + mm.ToString("00") + "/" + yy.ToString("00");
        }

        private void BTpost_Click(object sender, EventArgs e)
        {

        }

        private void frm_BSList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F1:
                    LoadBegin = true;
                    cls_Sales.FilterOption = 0;
                    InitialDialogFormfilter();
                    if (cls_Sales.FilterOption == 0) return;
                    this.Cursor = Cursors.WaitCursor;

                    switch (cls_Sales.FilterOption)
                    {
                        case 1:
                            InitialDialogFormOpenBill();
                            break;
                        case 2:
                        case 3:
                        case 4:
                            FilterStaff frmInput;
                            frmInput = new FilterStaff();
                            frmInput.StartPosition = FormStartPosition.CenterParent;

                            frmInput.Text = "ระบุพนักงาน";
                            #region "Assign Lookup"
                            #endregion
                            frmInput.MinimizeBox = false;
                            frmInput.ShowInTaskbar = false;
                            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                            {
                                this.Cursor = Cursors.Default;
                                return;
                            }



                            if (!bwList.IsBusy) bwList.RunWorkerAsync();
                            gridList.Select();

                            break;
                        default:
                            datachange = false;
                            switch (cls_Sales.FilterOption)
                            {
                                case 7:
                                case 8:
                                    comboTypedate.SelectedIndex = 0;
                                    dateFrom.Enabled = false;
                                    dateTo.Enabled = false;
                                    break;
                            }
                            datachange = true;
                            if (!bwList.IsBusy) bwList.RunWorkerAsync();
                            gridList.Select();
                            break;
                    }
                    break;
                case Keys.F5:
                    BTadd.PerformClick();
                    break;
                case Keys.F6:
                    BTedit.PerformClick();
                    break;
                case Keys.F7:
                    BTdelete.PerformClick();
                    break;
                case Keys.F8:
                    //btSearch.PerformClick();
                    break;
                case Keys.F9:
                    //btActive.PerformClick();
                    break;
            }
        }

        private void comboTypedate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!datachange) return;
            ComboBoxEdit item = (ComboBoxEdit)sender;
            dateFrom.Enabled = false;
            dateTo.Enabled = false;
            switch (item.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    dateFrom.EditValue = cls_Library.Date_CvDMY(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, false);
                    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, false);
                    break;
                case 2:
                    dateFrom.EditValue = cls_Library.Date_CvDMY(DateTime.Now.Day-1, DateTime.Now.Month, DateTime.Now.Year, false);
                    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.Now.Day-1, DateTime.Now.Month, DateTime.Now.Year, false);
                    break;
                case 3:
                    dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
                    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
                    break;
                case 4:
                    dateFrom.EditValue = cls_Library.Date_CvDMY(1, 1, DateTime.Now.Year, false);
                    dateTo.EditValue = cls_Library.Date_CvDMY(31, 12, DateTime.Now.Year, false);
                    break;
                case 5:
                    dateFrom.Enabled = true;
                    dateTo.Enabled = true;
                    //if (DateTime.Now.Month == 1)
                    //{
                    //    dateFrom.EditValue = cls_Library.Date_CvDMY(1, 12, DateTime.Now.Year - 1, false);
                    //    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year - 1, 12), 12, DateTime.Now.Year - 1, false);
                    //}
                    //else
                    //{
                    //    dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month - 1, DateTime.Now.Year, false);
                    //    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1), DateTime.Now.Month - 1, DateTime.Now.Year, false);
                    //}
                    break;
            }

            if (item.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void sluCus_EditValueChanged(object sender, EventArgs e)
        {
            if (sluCus.IsEditorActive)
            {
                if (!bwList.IsBusy) bwList.RunWorkerAsync();
            }
        }

        private void sluPer_EditValueChanged(object sender, EventArgs e)
        {
            if (sluPer.IsEditorActive)
            {
                if (!bwList.IsBusy) bwList.RunWorkerAsync();
            }
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (dateFrom.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void dateTo_EditValueChanged(object sender, EventArgs e)
        {
            if (dateTo.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void comboStatus_EditValueChanged(object sender, EventArgs e)
        {
            if (!datachange) return;
            if (comboStatus.IsEditorActive)
            {
                if (!bwList.IsBusy) bwList.RunWorkerAsync();
            }
        }

        private void BTprint_Click(object sender, EventArgs e)
        {

        }
    }
}