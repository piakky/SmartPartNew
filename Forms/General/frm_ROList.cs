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
    public partial class frm_ROList : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtRO = new DataTable();
        private cls_Struct.GetListRO GetRO;
        #endregion

        #region function

        public void DeleteData()
        {
            int[] selectRow;
            int _id = 0;
            try
            {
                DataRow row = gvRO.GetFocusedDataRow();
                if (row == null) return;

                selectRow = gvRO.GetSelectedRows();

                if (selectRow.Length <= 1)
                {
                    _id = cls_Library.DBInt(row["ROH_ID"]);
                    if (cls_Data.DeleteRO(_id)) dtRO.Rows.Remove(row);
                }
                else
                {
                    DataRow[] Rrow;
                    for (int i = 0; i < selectRow.Length; i++)
                    {
                        _id = cls_Library.DBInt(gvRO.GetRowCellValue(selectRow[i], "ROH_ID"));
                        if (cls_Data.DeleteRO(_id))
                        {
                            Rrow = dtRO.Select("ROH_ID = " + _id);
                            dtRO.Rows.Remove(Rrow[0]);
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
            GetRO = new cls_Struct.GetListRO();
            GetRO.Customer = cls_Library.CInt(sluCus.EditValue);
            GetRO.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
            GetRO.DateTo = cls_Library.CDateTime(dateTo.EditValue);
            GetRO.ROStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);
            GetRO.Barcode = txtBarcode.Text;

            dtRO = cls_Data.GetListRO(GetRO);
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("GetDataChoose :" + ex.Message);
            }
        }

        private void LoadData()
        {
            //dtRO = cls_Data.GetListRO();
            GetDataChoose();
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            try
            {
                DataRow row = gvRO.GetFocusedDataRow();
                int pid = 0;
                string strMode = "";

                switch (mode)
                {
                    case cls_Struct.ActionMode.Add:
                        strMode = " [เปิดใหม่]";
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["ROH_ID"]);
                        strMode = " [แก้ไข]";
                        break;
                    case cls_Struct.ActionMode.Copy:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["ROH_ID"]);
                        strMode = " [คัดลอก]";
                        break;
                    case cls_Struct.ActionMode.View:
                        if (row == null) return;
                        pid = cls_Library.DBInt(row["ROH_ID"]);
                        strMode = " [ดูข้อมูล]";
                        break;
                }

                frm_RORecord frm = new frm_RORecord(mode, pid);
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Text = "ส่งคืนสินค้า -" + strMode;
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
            cls_Library.AssignSearchLookUp(sluCus, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");

            comboStatus.Properties.Items.Add("ทุกสถานะ");
            comboStatus.Properties.Items.Add("เปิด");
            comboStatus.Properties.Items.Add("พิมพ์");
            comboStatus.Properties.Items.Add("โอน");
            comboStatus.Properties.Items.Add("ปิด");
            comboStatus.Properties.Items.Add("ยกเลิก");

            comboStatus.SelectedIndex = 0;

            comboTypedate.SelectedIndex = 0;

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

        private void SetClose()
        {
            try
            {
                DataRow row = gvRO.GetFocusedDataRow();
                int pid = 0;
                if (row == null) return;
                pid = cls_Library.DBInt(row["ROH_ID"]);
                if (cls_Library.DBInt(row["RC_STATUS"]) != 2)
                {
                    XtraMessageBox.Show("ใบส่งคืนสินค้าเลขที่ : " + row["RO_NO"].ToString() + "ยังไม่ได้พิมพ์", "พิมพ์", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                //if (cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.RO) <= 0)
                //{
                //  if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.RO, pid))
                //  {
                //    XtraMessageBox.Show(string.Format("ใบส่งคืนสินค้าเลขที่ {0}  Active แล้ว", row["RO_NO"].ToString()));
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
                //  XtraMessageBox.Show("มีใบส่งคืนสินค้าวันนี้ Active แล้ว");
                //}

                DialogResult Result = XtraMessageBox.Show("ต้องการปิดใบส่งคืนสินค้าเลขที่ : " + row["RO_NO"].ToString() + " ใช่หรือไม่?", "ปิด", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    //cls_Data.UpdateUnActiveVoucherByType(4);
                    if (cls_Data.UpdatePrintVoucher(cls_Struct.VoucherType.RO, pid))
                    {
                        XtraMessageBox.Show(string.Format("ปิดใบส่งคืนสินค้าเลขที่ {0}  เรียบร้อยแล้ว", row["RO_NO"].ToString()));
                        if (!bwList.IsBusy)
                        {
                            this.UseWaitCursor = true;
                            bwList.RunWorkerAsync();
                        }
                        this.UseWaitCursor = false;
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetPrint :" + ex.Message);
            }
        }

        private void SetPrint()
        {
            try
            {
                DataRow row = gvRO.GetFocusedDataRow();
                int pid = 0;
                if (row == null) return;
                pid = cls_Library.DBInt(row["ROH_ID"]);
                //if (DateTime.Today != cls_Library.DBDateTime(row["RO_DATE"])) 
                //{
                //    XtraMessageBox.Show("วันที่ใบส่งคืนสินค้าต้องเป็นวันที่ปัจจุบัน");
                //    return;
                //}
                //if (cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.RO) <= 0)
                //{
                //  if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.RO, pid))
                //  {
                //    XtraMessageBox.Show(string.Format("ใบส่งคืนสินค้าเลขที่ {0}  Active แล้ว", row["RO_NO"].ToString()));
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
                //  XtraMessageBox.Show("มีใบส่งคืนสินค้าวันนี้ Active แล้ว");
                //}

                DialogResult Result = XtraMessageBox.Show("ต้องการพิมพ์ใบส่งคืนสินค้าเลขที่ : " + row["RO_NO"].ToString() + " ใช่หรือไม่?", "พิมพ์", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    //cls_Data.UpdateUnActiveVoucherByType(4);
                    if (cls_Data.UpdatePrintVoucher(cls_Struct.VoucherType.RO, pid))
                    {
                        XtraMessageBox.Show(string.Format("พิมพ์ใบส่งคืนสินค้าเลขที่ {0}  เรียบร้อยแล้ว", row["RO_NO"].ToString()));
                        if (!bwList.IsBusy)
                        {
                            this.UseWaitCursor = true;
                            bwList.RunWorkerAsync();
                        }
                        this.UseWaitCursor = false;
                        this.Cursor = Cursors.Default;
                    }
                }          
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetPrint :" + ex.Message);
            }
        }

        private void SetActive()
        {
            try
            {
            DataRow row = gvRO.GetFocusedDataRow();
            int pid = 0;
            if (row == null) return;
            pid = cls_Library.DBInt(row["ROH_ID"]);
            //if (DateTime.Today != cls_Library.DBDateTime(row["RO_DATE"])) 
            //{
            //    XtraMessageBox.Show("วันที่ใบส่งคืนสินค้าต้องเป็นวันที่ปัจจุบัน");
            //    return;
            //}
            //if (cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.RO) <= 0)
            //{
            //  if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.RO, pid))
            //  {
            //    XtraMessageBox.Show(string.Format("ใบส่งคืนสินค้าเลขที่ {0}  Active แล้ว", row["RO_NO"].ToString()));
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
            //  XtraMessageBox.Show("มีใบส่งคืนสินค้าวันนี้ Active แล้ว");
            //}

            cls_Data.UpdateUnActiveVoucherByType(4);
            if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.RO, pid))
            {
                XtraMessageBox.Show(string.Format("ใบส่งคืนสินค้าเลขที่ {0}  Active แล้ว", row["RO_NO"].ToString()));
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

        public frm_ROList()
        {
            InitializeComponent();
            this.KeyPreview = true;
            cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
            LoadDefaultData();
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
            gridRO.Select();
        }

        private void bwList_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            repoSearchCus.DataSource = cls_Global_DB.DataInitial.Tables["M_VENDORS"];
            repoSearchCus.ValueMember = "_id";
            //repoSearchCus.DisplayMember = "name";
            repoSearchCus.DisplayMember = "code";
            gridRO.DataSource = dtRO;
            gridRO.RefreshDataSource();

            //Set focus Active or last row
            List<DataRow> listdata = dtRO.AsEnumerable().Where(r => r.Field<bool>("ACTIVE") == true).ToList<DataRow>();
            if (listdata.Count > 0)
            {
                gvRO.FocusedRowHandle = dtRO.Rows.IndexOf(listdata[0]);
            }
            else
            {
                gvRO.FocusedRowHandle = 0;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!bwList.IsBusy) bwList.RunWorkerAsync();
            gridRO.Select();
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
            DataRow Drow = gvRO.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvRO.FocusedRowHandle;
            string ROno = cls_Library.DBString(Drow["RO_NO"]);
            DialogResult Result = XtraMessageBox.Show("ต้องการลบ RO เลขที่ : " + ROno + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                DeleteData();
            }
                
        }

        private void sluCus_EditValueChanged(object sender, EventArgs e)
        {
            if (sluCus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
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

        private void btActive_Click(object sender, EventArgs e)
        {
            SetActive();
        }

        private void btPrintItem_Click(object sender, EventArgs e)
        {
            SetPrint();
        }

        private void gvRO_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView View = sender as GridView;
                int _id = cls_Library.CInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ROH_ID"]));
                DataRow[] dr = dtRO.Select("ROH_ID = " + _id + "And ACTIVE = 1");
                if (dr.Length > 0)
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
        }

        private void frm_ROList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F6:
                    btEdit.PerformClick();
                    break;
                case Keys.F7:
                    btDelete.PerformClick();
                    break;
                case Keys.F8:
                    btSerch.PerformClick();
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
        }

        private void btClose_Click(object sender, EventArgs e)
        {

        }
    }
}