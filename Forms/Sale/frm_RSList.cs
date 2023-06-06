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
using SmartPart.Forms.General;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace SmartPart.Forms.Sale
{
    public partial class frm_RSList : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtRS = new DataTable();
        private cls_Struct.GetListRS GetRS;

        public frm_RSList()
        {
            InitializeComponent();
            SplashScreenManager.ShowForm(this, typeof(frm_WaitForm), true, true, false);
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(10);
            }
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
                    _id = cls_Library.DBInt(row["RSH_ID"]);
                    if (cls_Data.DeleteRS(_id)) dtRS.Rows.Remove(row);
                }
                else
                {
                    DataRow[] Rrow;
                    for (int i = 0; i < selectRow.Length; i++)
                    {
                        _id = cls_Library.DBInt(gvList.GetRowCellValue(selectRow[i], "RSH_ID"));
                        if (cls_Data.DeletePO(_id))
                        {
                            Rrow = dtRS.Select("RSH_ID = " + _id);
                            dtRS.Rows.Remove(Rrow[0]);
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
                GetRS = new cls_Struct.GetListRS();
                GetRS.Customer = cls_Library.CInt(sluCus.EditValue);
                GetRS.DateType = cls_Library.DBByte(comboTypedate.SelectedIndex);
                GetRS.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
                GetRS.DateTo = cls_Library.CDateTime(dateTo.EditValue);
                GetRS.RSStatus = cls_Library.DBByte(comboStatus.SelectedIndex);
                GetRS.RSno = txtRSNo.Text.Trim();

                dtRS = cls_Data.GetListRS(GetRS);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("GetDataChoose :" + ex.Message);
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
                        strMode = " [เปิดใหม่]";
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["RSH_ID"]);
                        strMode = " [แก้ไข]";
                        break;
                    case cls_Struct.ActionMode.Copy:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["RSH_ID"]);
                        strMode = " [คัดลอก]";
                        break;
                    case cls_Struct.ActionMode.View:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["RSH_ID"]);
                        strMode = " [ดูข้อมูล]";
                        break;
                }

                frm_RSRecord frm = new frm_RSRecord(mode, pid);
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Text = "ใบกำกับภาษีขาย -" + strMode;
                frm.MinimizeBox = false;
                frm.ShowInTaskbar = false;
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    if (!bwList.IsBusy)
                    {
                        this.UseWaitCursor = true;
                        bwList.RunWorkerAsync();
                    }
                    this.UseWaitCursor = false;
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("InitialDialogForm :" + ex.Message);
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
                cls_Library.AssignSearchLookUp(sluCus, "M_CUSTOMERS", "รหัสลูกค้า", "ชื่อลูกค้า");

                comboStatus.Properties.Items.Add("ทุกสถานะ");
                comboStatus.Properties.Items.Add("เปิด");
                comboStatus.Properties.Items.Add("พิมพ์");
                comboStatus.Properties.Items.Add("รับ+POS");
                comboStatus.Properties.Items.Add("ยกเลิก");
                comboStatus.SelectedIndex = 0;

                comboTypedate.SelectedIndex = 0;

                DateTime dCalcDate = DateTime.Now;
                //dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
                if (DateTime.Now.Month == 1)
                {
                    dateFrom.EditValue = cls_Library.Date_CvDMY(1, 12, DateTime.Now.Year - 1, false);
                }
                else
                {
                    dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month - 1, DateTime.Now.Year, false);
                }
                dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
            }
        }

        private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //repoSearchCus.DataSource = cls_Global_DB.DataInitial.Tables["M_VENDORS"];
            //repoSearchCus.ValueMember = "_id";
            //repoSearchCus.DisplayMember = "code";

            gridList.DataSource = dtRS;
            gridList.RefreshDataSource();

            //Set focus Active or last row
            //List<DataRow> listdata = dtRS.AsEnumerable().Where(r => r.Field<bool>("ACTIVE") == true).ToList<DataRow>();
            //if (listdata.Count > 0)
            //{
            //    gvPO.FocusedRowHandle = dtPO.Rows.IndexOf(listdata[0]);
            //}
            //else
            //{
            //    gvPO.FocusedRowHandle = 0;
            //}
            gvList.FocusedRowHandle = 0;
        }

        private void BTexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTdelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void BTadd_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.Add);
        }

        private void BTedit_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.Edit);
        }

        private void btView_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.View);
        }

        private void sluCus_EditValueChanged(object sender, EventArgs e)
        {
            if (sluCus.IsEditorActive)
            {
                if (!bwList.IsBusy) bwList.RunWorkerAsync();
            }
        }

        private void comboTypedate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit item = (ComboBoxEdit)sender;
            dateFrom.Enabled = false;
            dateTo.Enabled = false;
            switch (item.SelectedIndex)
            {
                case 0:
                    //dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
                    if (DateTime.Now.Month == 1)
                    {
                        dateFrom.EditValue = cls_Library.Date_CvDMY(1, 12, DateTime.Now.Year - 1, false);
                    }
                    else
                    {
                        dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month - 1, DateTime.Now.Year, false);
                    }
                    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
                    break;
                case 1:
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
                case 2:
                    //dateFrom.Enabled = true;
                    //dateTo.Enabled = true;
                    break;
            }

            if (item.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (dateFrom.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void dateTo_EditValueChanged(object sender, EventArgs e)
        {
            if (dateTo.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void txtVNo_EditValueChanged(object sender, EventArgs e)
        {
            if (txtRSNo.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void frm_RSList_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void frm_RSList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F5:
                    btAdd.PerformClick();
                    break;
                case Keys.F6:
                    btEdit.PerformClick();
                    break;
                case Keys.F7:
                    btDelete.PerformClick();
                    break;
                case Keys.F8:
                    btSearch.PerformClick();
                    break;
                case Keys.F11:
                    btView.PerformClick();
                    break;
            }
        }
    }
}