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
    public partial class frm_POList : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtPO = new DataTable();
        private cls_Struct.GetListPO GetPO;
        #endregion

        #region Function

        public void DeleteData()
        {
            int[] selectRow;
            int _id = 0;
            try
            {
                DataRow row = gvPO.GetFocusedDataRow();
                if (row == null) return;

                selectRow = gvPO.GetSelectedRows();

                if (selectRow.Length <= 1)
                {
                    _id = cls_Library.DBInt(row["POH_ID"]);
                    if (cls_Data.DeletePO(_id)) dtPO.Rows.Remove(row);
                }
                else
                {
                    DataRow[] Rrow;
                    for (int i = 0; i < selectRow.Length; i++)
                    {
                        _id = cls_Library.DBInt(gvPO.GetRowCellValue(selectRow[i], "POH_ID"));
                        if (cls_Data.DeletePO(_id))
                        {
                            Rrow = dtPO.Select("POH_ID = " + _id);
                            dtPO.Rows.Remove(Rrow[0]);
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
            GetPO = new cls_Struct.GetListPO();
            GetPO.Customer = cls_Library.CInt(sluCus.EditValue);
            GetPO.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
            GetPO.DateTo = cls_Library.CDateTime(dateTo.EditValue);
            GetPO.POStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);
            GetPO.Barcode = txtBarcode.Text;

            dtPO = cls_Data.GetListPO(GetPO);
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("GetDataChoose :" + ex.Message);
            }
        }

        private void LoadData()
        {
            GetDataChoose();
            //dtPO = cls_Data.GetListPO();
            //cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            try
            {
                DataRow row = gvPO.GetFocusedDataRow();
                int pid = 0;
                string strMode = "";

                switch (mode)
                {
                    case cls_Struct.ActionMode.Add:
                        strMode = " [เปิดใหม่]";
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["POH_ID"]);
                        strMode = " [แก้ไข]";
                        break;
                    case cls_Struct.ActionMode.Copy:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["POH_ID"]);
                        strMode = " [คัดลอก]";
                        break;
                    case cls_Struct.ActionMode.View:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["POH_ID"]);
                        strMode = " [ดูข้อมูล]";
                        break;
                }

                frm_PORecord frm = new frm_PORecord(mode, pid);
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Text = "ใบสั่งซื้อ -" + strMode;
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

        private void LoadDefaultData()
        {
            try
            {
                cls_Library.AssignSearchLookUp(sluCus, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");

                comboStatus.Properties.Items.Add("ทุกสถานะ");
                comboStatus.Properties.Items.Add("เปิด");
                comboStatus.Properties.Items.Add("ปิด");
                comboStatus.SelectedIndex = 0;

                comboTypedate.SelectedIndex = 0;

                DateTime dCalcDate = DateTime.Now;
                dateFrom.EditValue = new DateTime(dCalcDate.Year, dCalcDate.Month, 1);
                dateTo.EditValue = new DateTime(dCalcDate.Year, dCalcDate.Month, DateTime.DaysInMonth(dCalcDate.Year, dCalcDate.Month));
                //dateFrom.EditValue =  cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
                //dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
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
            DataRow row = gvPO.GetFocusedDataRow();
            int pid = 0;
            if (row == null) return;
            pid = cls_Library.DBInt(row["POH_ID"]);
            //if (DateTime.Today != cls_Library.DBDateTime(row["PO_DATE"]))
            //{
            //  XtraMessageBox.Show("วันที่ใบสั่งซื้อต้องเป็นวันที่ปัจจุบัน");
            //  return;
            //}
            //if (cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.PO) <= 0)
            //{
            //  if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.PO, pid))
            //  {
            //    XtraMessageBox.Show(string.Format("ใบสั่งซื้อเลขที่ {0}  Active แล้ว", row["PO_NO"].ToString()));
            //    if (!bwList.IsBusy)
            //    {
            //        this.UseWaitCursor = true;
            //        bwList.RunWorkerAsync();
            //    }
            //    this.UseWaitCursor = false;
            //    this.Cursor = Cursors.Default;
            //  }                        
            //}
            //else
            //{
            //  XtraMessageBox.Show("มีใบสั่งซื้อวันนี้ Active แล้ว");
            //}

            cls_Data.UpdateUnActiveVoucherByType(1);
            if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.PO, pid))
            {
                XtraMessageBox.Show(string.Format("ใบสั่งซื้อเลขที่ {0}  Active แล้ว", row["PO_NO"].ToString()));
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
            XtraMessageBox.Show("SetActive :" + ex.Message);
            }
        }

        #endregion

        public frm_POList()
        {
            InitializeComponent();
            this.KeyPreview = true;
            cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
            LoadDefaultData();
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
            gridPO.Select();
        }

        private void bwList_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            repoSearchCus.DataSource = cls_Global_DB.DataInitial.Tables["M_VENDORS"];
            repoSearchCus.ValueMember = "_id";
            repoSearchCus.DisplayMember = "code";
            
            gridPO.DataSource = dtPO;
            gridPO.RefreshDataSource();

            //Set focus Active or last row
            List<DataRow> listdata = dtPO.AsEnumerable().Where(r => r.Field<bool>("ACTIVE") == true).ToList<DataRow>();
            if (listdata.Count > 0)
            {
                gvPO.FocusedRowHandle = dtPO.Rows.IndexOf(listdata[0]);
            }
            else
            {
                gvPO.FocusedRowHandle = 0;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
            gridPO.Select();
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

        private void sluCus_EditValueChanged(object sender, EventArgs e)
        {
            if (sluCus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();//GetDataChoose();
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
            if (comboStatus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();//GetDataChoose();
        }

        private void btActive_Click(object sender, EventArgs e)
        {
            SetActive();
        }

        private void btShowItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvPO_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView View = sender as GridView;
                int _id = cls_Library.CInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["POH_ID"]));
                DataRow[] dr = dtPO.Select("POH_ID = " + _id + "And ACTIVE = 1");
                if (dr.Length > 0)
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
        }

        private void frm_POList_KeyDown(object sender, KeyEventArgs e)
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
            case Keys.F9:
                btActive.PerformClick();
                break;
            case Keys.F12:
                btView.PerformClick();
                break;
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
                    dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
                    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
                    break;
                case 1:

                    if (DateTime.Now.Month == 1)
                    {
                        dateFrom.EditValue = cls_Library.Date_CvDMY(1, 12, DateTime.Now.Year - 1, false);
                        dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year - 1, 12), 12, DateTime.Now.Year - 1, false);
                    }
                    else
                    {
                        dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month - 1, DateTime.Now.Year, false);
                        dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1), DateTime.Now.Month-1, DateTime.Now.Year, false);
                    }

                    break;
                case 2:
                    dateFrom.Enabled = true;
                    dateTo.Enabled = true;
                    break;
            }

            if (item.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void panelDock_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}