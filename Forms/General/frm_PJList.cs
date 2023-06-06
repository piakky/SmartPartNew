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
using DevExpress.XtraGrid.Views.Grid;

namespace SmartPart.Forms.General
{
    public partial class frm_PJList : DevExpress.XtraEditors.XtraForm
    {

        #region Variable
        private DataTable dtJob = new DataTable();
        private cls_Struct.GetListJOB GetJOB;
        #endregion

        #region Function

        public void DeleteData()
        {
            int[] selectRow;
            int _id = 0;
            try
            {
                DataRow row = gvJOB.GetFocusedDataRow();
                if (row == null) return;

                selectRow = gvJOB.GetSelectedRows();

                if (selectRow.Length <= 1)
                {
                    _id = cls_Library.DBInt(row["JOB_ID"]);
                    if (cls_Data.DeletePJOB(_id)) dtJob.Rows.Remove(row);
                }
                else
                {
                    DataRow[] Rrow;
                    for (int i = 0; i < selectRow.Length; i++)
                    {
                        _id = cls_Library.DBInt(gvJOB.GetRowCellValue(selectRow[i], "JOB_ID"));
                        if (cls_Data.DeletePJOB(_id))
                        {
                            Rrow = dtJob.Select("JOB_ID = " + _id);
                            dtJob.Rows.Remove(Rrow[0]);
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
                GetJOB = new cls_Struct.GetListJOB();
                GetJOB.Operator = cls_Library.CInt(sluOperator.EditValue);
                GetJOB.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
                GetJOB.DateTo = cls_Library.CDateTime(dateTo.EditValue);
                GetJOB.JobStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);
                GetJOB.Barcode = txtBarcode.Text;

                dtJob = cls_Data.GetListPJOB(GetJOB);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("GetDataChoose :" + ex.Message);
            }
        }

        private void LoadData()
        {
            cls_Data.CheckClearJOB();
            //dtJob = cls_Data.GetListJOB();
            GetDataChoose();
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            try
            {
                DataRow row = gvJOB.GetFocusedDataRow();
                int pid = 0;
                string strMode = "";

                switch (mode)
                {
                    case cls_Struct.ActionMode.Add:
                        strMode = " [เปิดใหม่]";
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["JOB_ID"]);
                        strMode = " [แก้ไข]";
                        break;
                    case cls_Struct.ActionMode.Copy:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["JOB_ID"]);
                        strMode = " [คัดลอก]";
                        break;
                    case cls_Struct.ActionMode.View:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["JOB_ID"]);
                        strMode = " [ดูข้อมูล]";
                        break;
                }

                frm_PJRecord frm = new frm_PJRecord(mode, pid);
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Text = "Packing JOB -" + strMode;
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
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadDefaultData()
        {
            try
            {
                cls_Library.AssignSearchLookUp(sluOperator, "M_USERS", "รหัสผู้ดำเนินการ", "ชื่อผู้ดำเนินการ");

                comboStatus.Properties.Items.Add("เปิด");
                comboStatus.Properties.Items.Add("ปิด");
                comboStatus.Properties.Items.Add("ยกเลิก");

                comboStatus.SelectedIndex = 0;

                dateFrom.EditValue = DateTime.Today;
                dateTo.EditValue = DateTime.Today;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
            }
        }

        private void SetActive()
        {
            try
            {
                DataRow row = gvJOB.GetFocusedDataRow();
                int pid = 0;
                if (row == null) return;
                pid = cls_Library.DBInt(row["JOB_ID"]);
                if (DateTime.Today != cls_Library.DBDateTime(row["JOB_DATE"]))
                {
                    XtraMessageBox.Show("วันที่ JOB ต้องเป็นวันที่ปัจจุบัน");
                    return;
                }
                if (cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.PJOB) <= 0)
                {
                    if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.PJOB, pid))
                    {
                        XtraMessageBox.Show(string.Format("Packing JOB เลขที่ {0}  Active แล้ว", row["JOB_NO"].ToString()));

                        if (!bwList.IsBusy)
                        {
                            this.UseWaitCursor = true;
                            bwList.RunWorkerAsync();
                        }
                        this.UseWaitCursor = false;
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    XtraMessageBox.Show("มี Packing JOB วันนี้ Active แล้ว");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetActive :" + ex.Message);
            }
        }

        #endregion

        public frm_PJList()
        {
            InitializeComponent();
            this.KeyPreview = true;
            cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
            LoadDefaultData();
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void frmPJList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class_Library mc = new Class_Library();
            Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
            ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
        }

        private void frmPJList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void bwList_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            repoSearchOperator.DataSource = cls_Global_DB.DataInitial.Tables["M_USERS"];
            repoSearchOperator.ValueMember = "_id";
            repoSearchOperator.DisplayMember = "code";

            repoSearchJobType.DataSource = cls_Global_DB.DataInitial.Tables["M_JOB_TYPES"];
            repoSearchJobType.ValueMember = "_id";
            repoSearchJobType.DisplayMember = "code";

            repoComboJobStatus.Items.Add("เปิด");
            repoComboJobStatus.Items.Add("ปิด");
            repoComboJobStatus.Items.Add("ยกเลิก");

            gridJOB.DataSource = dtJob;
            gridJOB.RefreshDataSource();
        }

        private void gvJOB_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void gvJOB_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView View = sender as GridView;
                int _id = cls_Library.CInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["JOB_ID"]));
                DataRow[] dr = dtJob.Select("JOB_ID = " + _id + "And ACTIVE = 1");
                if (dr.Length > 0)
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
        }

        private void btView_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.View);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.Add);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.Edit);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void btActive_Click(object sender, EventArgs e)
        {
            SetActive();
        }

        private void btShowItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sluOperator_EditValueChanged(object sender, EventArgs e)
        {
            if (sluOperator.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (dateFrom.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
        }

        private void dateTo_EditValueChanged(object sender, EventArgs e)
        {
            if (dateTo.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
        }

        private void btSerch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}