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
  public partial class frm_SQList : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private DataTable dtSQ = new DataTable();
    private cls_Struct.GetListSQ GetSQ;
    #endregion

    #region Function
    public void DeleteData()
    {
        int[] selectRow;
        int _id = 0;
        try
        {
            DataRow row = gvSQ.GetFocusedDataRow();
            if (row == null) return;

            selectRow = gvSQ.GetSelectedRows();

            if (selectRow.Length <= 1)
            {
                _id = cls_Library.DBInt(row["SQH_ID"]);
                if (cls_Data.DeleteSQ(_id)) dtSQ.Rows.Remove(row);
            }
            else
            {
                DataRow[] Rrow;
                for (int i = 0; i < selectRow.Length; i++)
                {
                    _id = cls_Library.DBInt(gvSQ.GetRowCellValue(selectRow[i], "SQH_ID"));
                    if (cls_Data.DeleteSQ(_id))
                    {
                        Rrow = dtSQ.Select("SQH_ID = " + _id);
                        dtSQ.Rows.Remove(Rrow[0]);
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
            GetSQ = new cls_Struct.GetListSQ();
            GetSQ.Operator = cls_Library.CInt(sluCus.EditValue);
            GetSQ.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
            GetSQ.DateTo = cls_Library.CDateTime(dateTo.EditValue);
            GetSQ.SQStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);                
            GetSQ.Barcode = txtBarcode.Text;

            dtSQ = cls_Data.GetListSQ(GetSQ);
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

            comboStatus.Properties.Items.Add("เปิด");
            comboStatus.Properties.Items.Add("ปิด");
            comboStatus.Properties.Items.Add("ยกเลิก");
            comboStatus.SelectedIndex = 0;
            comboTypedate.SelectedIndex = 0;

            DateTime dCalcDate = DateTime.Now;
            dateFrom.EditValue = new DateTime(dCalcDate.Year, dCalcDate.Month, 1);
            dateTo.EditValue = new DateTime(dCalcDate.Year, dCalcDate.Month, DateTime.DaysInMonth(dCalcDate.Year, dCalcDate.Month));
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
            DataRow row = gvSQ.GetFocusedDataRow();
            int pid = 0;
            string strMode = "";

            switch (mode)
            {
                case cls_Struct.ActionMode.Add:
                    strMode = " [เปิดใหม่]";
                    break;
                case cls_Struct.ActionMode.Edit:
                    if (row == null) return;
                    pid = cls_Library.DBInt(row["SQH_ID"]);
                    strMode = " [แก้ไข]";
                    break;
                case cls_Struct.ActionMode.Copy:
                    if (row == null) return;
                    pid = cls_Library.DBInt(row["SQH_ID"]);
                    strMode = " [คัดลอก]";
                    break;
                case cls_Struct.ActionMode.View:
                    if (row == null) return;
                    pid = cls_Library.DBInt(row["SQH_ID"]);
                    strMode = " [ดูข้อมูล]";
                    break;
            }

            frm_SQRecord frm = new frm_SQRecord(mode, pid);
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.Text = "Supplier Quatation -" + strMode;
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
        }
    }

    private void SetActive()
    {
      try
      {
        DataRow row = gvSQ.GetFocusedDataRow();
        int pid = 0;
        if (row == null) return;
        pid = cls_Library.DBInt(row["SQH_ID"]);
        //if (DateTime.Today != cls_Library.DBDateTime(row["SQ_DATE"]))
        //{
        //    XtraMessageBox.Show("วันที่ Supplier Quatation ต้องเป็นวันที่ปัจจุบัน");
        //    return;
        //}

        //if (cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.SQ) <= 0)
        //{
        //  if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.SQ, pid))
        //  {
        //    XtraMessageBox.Show(string.Format("Supplier Quatation เลขที่ {0}  Active แล้ว", row["SQ_NO"].ToString()));
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
        //  XtraMessageBox.Show("มี Supplier Quatation วันนี้ Active แล้ว");
        //}

        cls_Data.UpdateUnActiveVoucherByType(5);
        if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.SQ, pid))
        {
          XtraMessageBox.Show(string.Format("Supplier Quatation เลขที่ {0}  Active แล้ว", row["SQ_NO"].ToString()));
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

    public frm_SQList()
    {
      InitializeComponent();
      this.KeyPreview = true;
      cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
      LoadDefaultData();
      if (!bwList.IsBusy) bwList.RunWorkerAsync();
      gridSQ.Select();
    }

    private void bwList_DoWork(object sender, DoWorkEventArgs e)
    {
        LoadData();
    }

    private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        repoSearchCUs.DataSource = cls_Global_DB.DataInitial.Tables["M_VENDORS"];
        repoSearchCUs.ValueMember = "_id";
        //repoSearchCUs.DisplayMember = "name";
        repoSearchCUs.DisplayMember = "code";

        gridSQ.DataSource = dtSQ;
        gridSQ.RefreshDataSource();

        //Set focus Active or last row
        List<DataRow> listdata = dtSQ.AsEnumerable().Where(r => r.Field<bool>("ACTIVE") == true).ToList<DataRow>();
        if (listdata.Count > 0)
        {
            gvSQ.FocusedRowHandle = dtSQ.Rows.IndexOf(listdata[0]);
        }
        else
        {
            gvSQ.FocusedRowHandle = 0;
        }
    }

    private void btSearch_Click(object sender, EventArgs e)
    {
      if (!bwList.IsBusy) bwList.RunWorkerAsync();
      gridSQ.Select();
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

    private void sluCus_EditValueChanged(object sender, EventArgs e)
    {
        if (sluCus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
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

    private void gvSQ_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
    {
        if (e.RowHandle >= 0)
        {
            GridView View = sender as GridView;
            int _id = cls_Library.CInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["SQH_ID"]));
            DataRow[] dr = dtSQ.Select("SQH_ID = " + _id + "And ACTIVE = 1");
            if (dr.Length > 0)
            {
                e.Appearance.BackColor = Color.Green;
            }
        }
    }

    private void frm_SQList_KeyDown(object sender, KeyEventArgs e)
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