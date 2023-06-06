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
    public partial class frm_RCList : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtRC = new DataTable();
        private cls_Struct.GetListRC GetRC;
        #endregion

        #region Function

        public void DeleteData()
        {
            int[] selectRow;
            int _id = 0;
            try
            {
                DataRow row = gvRC.GetFocusedDataRow();
                if (row == null) return;

                selectRow = gvRC.GetSelectedRows();

                if (selectRow.Length <= 1)
                {
                    _id = cls_Library.DBInt(row["RCH_ID"]);
                    if (cls_Data.DeleteRC(_id)) dtRC.Rows.Remove(row);
                }
                else
                {
                    DataRow[] Rrow;
                    for (int i = 0; i < selectRow.Length; i++)
                    {
                        _id = cls_Library.DBInt(gvRC.GetRowCellValue(selectRow[i], "RCH_ID"));
                        if (cls_Data.DeleteRC(_id))
                        {
                            Rrow = dtRC.Select("RCH_ID = " + _id);
                            dtRC.Rows.Remove(Rrow[0]);
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
                GetRC = new cls_Struct.GetListRC();
                if (sluCus.EditValue == null)
                {
                    GetRC.Operator = 0;
                }
                else
                {
                    GetRC.Operator = cls_Library.DBInt(sluCus.EditValue);
                }
                if (dateFrom.EditValue == null)
                {
                    GetRC.DateFrom = cls_Library.Date_CvDMY(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, false);
                }
                else
                {
                    GetRC.DateFrom = cls_Library.DBDateTime(dateFrom.EditValue);
                }
                if (dateTo.EditValue == null)
                {
                    GetRC.DateTo = cls_Library.Date_CvDMY(cls_Library.DayssinMonth(DateTime.Now.Month, DateTime.Now.Year), DateTime.Now.Month, DateTime.Now.Year, false);
                }
                else
                {
                    GetRC.DateTo = cls_Library.DBDateTime(dateTo.EditValue);
                }
                if (comboStatus.SelectedIndex < 0)
                {
                    GetRC.RCStatus = 1;
                }
                else
                {
                    GetRC.RCStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);
                }
                if (comboSellType.SelectedIndex < 0)
                {
                    GetRC.Selltype = 1;
                }
                else
                {
                    GetRC.Selltype = cls_Library.DBByte(comboSellType.SelectedIndex + 1);
                }            
                GetRC.Barcode = txtBarcode.Text;

                dtRC = cls_Data.GetListRC(GetRC);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("GetDataChoose :" + ex.Message);
            }
        }

        private void LoadData()
        {
            GetDataChoose();            
        }

        private void LoadDefaultData()
        {
            try
            {
            cls_Library.AssignSearchLookUp(sluCus, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");

            comboStatus.Properties.Items.Add("ทุกสถานะ");
            comboStatus.Properties.Items.Add("เปิด");
            comboStatus.Properties.Items.Add("ปิด");
            comboStatus.Properties.Items.Add("ยกเลิก");
            comboStatus.SelectedIndex = 0;

            comboTypedate.SelectedIndex = 0;

            comboSellType.Properties.Items.Add("ทุกประเภทการซื้อ");
            comboSellType.Properties.Items.Add("ปกติ");
            comboSellType.Properties.Items.Add("เบิกห้าง");
            comboSellType.Properties.Items.Add("ชดเชย");
            comboSellType.Properties.Items.Add("Back Order");
            comboSellType.Properties.Items.Add("สินค้าตัวอย่าง");
            comboSellType.SelectedIndex = 0;


            DateTime dCalcDate = DateTime.Now;
            //dateFrom.EditValue = new DateTime(dCalcDate.Year, dCalcDate.Month, 1);
            //dateTo.EditValue = new DateTime(dCalcDate.Year, dCalcDate.Month, DateTime.DaysInMonth(dCalcDate.Year, dCalcDate.Month));
            dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
            dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
            }
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            try
            {
                DataRow row = gvRC.GetFocusedDataRow();
                int pid = 0;
                string strMode = "";

                switch (mode)
                {
                    case cls_Struct.ActionMode.Add:
                        strMode = " [เปิดใหม่]";
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["RCH_ID"]);
                        strMode = " [แก้ไข]";
                        break;
                    case cls_Struct.ActionMode.Copy:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["RCH_ID"]);
                        strMode = " [คัดลอก]";
                        break;
                    case cls_Struct.ActionMode.View:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["RCH_ID"]);
                        strMode = " [ดูข้อมูล]";
                        break;
                }

                frm_RCRecord frm = new frm_RCRecord(mode, pid);
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Text = "ใบรับสินค้า -" + strMode;
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

        private void SetActive()
        {
            try
            {
            DataRow row = gvRC.GetFocusedDataRow();
            int pid = 0;
            if (row == null) return;
            pid = cls_Library.DBInt(row["RCH_ID"]);
            //if (DateTime.Today != cls_Library.DBDateTime(row["RC_DATE"]))
            //{
            //    XtraMessageBox.Show("วันที่ใบรับสินค้าต้องเป็นวันที่ปัจจุบัน");
            //    return;
            //}
            //if (cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.RC) <= 0)
            //{
            //  if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.RC, pid))
            //  {
            //    XtraMessageBox.Show(string.Format("ใบรับสินค้าเลขที่ {0}  Active แล้ว", row["RC_NO"].ToString()));
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
            //  XtraMessageBox.Show("มีใบรับสินค้าวันนี้ Active แล้ว");
            //}

            cls_Data.UpdateUnActiveVoucherByType(2);
            if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.RC, pid))
            {
                XtraMessageBox.Show(string.Format("ใบรับสินค้าเลขที่ {0}  Active แล้ว", row["RC_NO"].ToString()));
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

        public frm_RCList()
        {
            InitializeComponent();
            this.KeyPreview = true;
            cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
            LoadDefaultData();
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
            gridRC.Select();
        }

        private void bwList_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            repoSearchCUs.DataSource = cls_Global_DB.DataInitial.Tables["M_VENDORS"];
            repoSearchCUs.ValueMember = "_id";
            repoSearchCUs.DisplayMember = "code";

            gridRC.DataSource = dtRC;
            gridRC.RefreshDataSource();

            //Set focus Active or last row
            List<DataRow> listdata = dtRC.AsEnumerable().Where(r => r.Field<bool>("ACTIVE") == true).ToList<DataRow>();
            if (listdata.Count > 0)
            {
                gvRC.FocusedRowHandle = dtRC.Rows.IndexOf(listdata[0]);
            }
            else
            {
                gvRC.FocusedRowHandle = 0;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
            gridRC.Select();
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
            if (sluCus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
        }

        private void dateFrom_EditValueChanged(object sender, EventArgs e)
        {
                //if (dateFrom.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
                if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
            }

        private void dateTo_EditValueChanged(object sender, EventArgs e)
        {
            //if (dateTo.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
                if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
            }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
        }

        private void comboSellType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSellType.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
        }

        private void btActive_Click(object sender, EventArgs e)
        {
            SetActive();
        }

        private void btShowItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvRC_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView View = sender as GridView;
                int _id = cls_Library.CInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["RCH_ID"]));
                DataRow[] dr = dtRC.Select("RCH_ID = " + _id + "And ACTIVE = 1");
                if (dr.Length > 0)
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
        }

        private void frm_RCList_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.F11:
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
    }
}