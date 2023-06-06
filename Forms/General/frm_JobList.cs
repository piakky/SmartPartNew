using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using SmartPart.Class;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SmartPart.Forms.General
{
  public partial class frm_JobList : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private DataTable dtJob = new DataTable();
    private cls_Struct.GetListJOB GetJOB;
    public int _Jobid;
    public string _Jobcode;
    public DateTime _Jobdate;
    #endregion

    #region "  Properties declaration  "

    public int Jobid
    {
      get
      {
        return _Jobid;
      }
      set { _Jobid = value; }
    }

    public string Jobcode
    {
      get { return _Jobcode; }
      set { _Jobcode = value; }
    }

    public DateTime Jobdate
    {
      get { return _Jobdate; }
      set { _Jobdate = value; }
    }
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
          if (cls_Data.DeleteJOB(_id)) dtJob.Rows.Remove(row);                    
        }
        else
        {
          DataRow[] Rrow;
          for (int i = 0; i < selectRow.Length; i++)
          {
            _id = cls_Library.DBInt(gvJOB.GetRowCellValue(selectRow[i], "JOB_ID"));
            if (cls_Data.DeleteJOB(_id))
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

        dtJob = cls_Data.GetListJOB(GetJOB);
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("GetDataChoose :" + ex.Message);
      }
    }

    private void LoadData()
    {
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

            frm_JobRecord frm = new frm_JobRecord(mode, pid);
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.Text = "JOB -" + strMode;
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
        cls_Library.AssignSearchLookUp(sluOperator, "M_USERS", "รหัสผู้ดำเนินการ", "ชื่อผู้ดำเนินการ",cls_Global_class.TypeShow.codename);

        comboStatus.Properties.Items.Add("แสดงทุกสถานะ");
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

    private void SetActive()
    {
      try
      {
        DataRow row = gvJOB.GetFocusedDataRow();
        int pid = 0;
        if (row == null) return;
        pid = cls_Library.DBInt(row["JOB_ID"]);
        //if (DateTime.Today != cls_Library.DBDateTime(row["JOB_DATE"]))
        //{
        //    XtraMessageBox.Show("วันที่ JOB ต้องเป็นวันที่ปัจจุบัน");
        //    return;
        //}
        //if (cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.JOB) <= 0)
        //{
        //  if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.JOB, pid))
        //  {
        //    XtraMessageBox.Show(string.Format("JOB เลขที่ {0}  Active แล้ว", row["JOB_NO"].ToString()));

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
        //  XtraMessageBox.Show("มี JOB วันนี้ Active แล้ว");
        //}

        cls_Data.UpdateUnActiveVoucherByType(3);
        if (cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.JOB, pid))
        {
          XtraMessageBox.Show(string.Format("JOB เลขที่ {0}  Active แล้ว", row["JOB_NO"].ToString()));

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

    public frm_JobList()
    {

      InitializeComponent();
      this.KeyPreview = true;        
      cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
      LoadDefaultData();
      if (!bwList.IsBusy) bwList.RunWorkerAsync();
      gridJOB.Select();
    }

    private void bwList_DoWork(object sender, DoWorkEventArgs e)
    {
      LoadData();
    }

    private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      repoSearchOperator.DataSource = cls_Global_DB.DataInitial.Tables["M_USERS"];
      repoSearchOperator.ValueMember = "_id";
      repoSearchOperator.DisplayMember = "name";

      repoSearchJobType.DataSource = cls_Global_DB.DataInitial.Tables["M_JOB_TYPES"];
      repoSearchJobType.ValueMember = "_id";
      repoSearchJobType.DisplayMember = "name";
            
      repoComboJobStatus.Items.Add("เปิด");
      repoComboJobStatus.Items.Add("ปิด");
      repoComboJobStatus.Items.Add("ยกเลิก");

      gridJOB.DataSource = dtJob;
      gridJOB.RefreshDataSource();

      //Set focus Active or last row
      List<DataRow> listdata = dtJob.AsEnumerable().Where(r => r.Field<bool>("ACTIVE") == true).ToList<DataRow>();
      if (listdata.Count > 0)
      {
        gvJOB.FocusedRowHandle = dtJob.Rows.IndexOf(listdata[0]);
      }
      else
      {
        gvJOB.FocusedRowHandle = 0;
      }
    }

    private void frm_JobList_FormClosing(object sender, FormClosingEventArgs e)
    {
      Class_Library mc = new Class_Library();
      Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
      ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
    }

    private void gvJOB_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void btDelete_Click(object sender, EventArgs e)
    {
      DeleteData();
    }

    private void btAdd_Click(object sender, EventArgs e)
    {
      InitialDialogForm(cls_Struct.ActionMode.Add);
    }

    private void btEdit_Click(object sender, EventArgs e)
    {
      InitialDialogForm(cls_Struct.ActionMode.Edit);
    }

    private void btView_Click(object sender, EventArgs e)
    {
      InitialDialogForm(cls_Struct.ActionMode.View);
    }

    private void btSearch_Click(object sender, EventArgs e)
    {
      if (!bwList.IsBusy) bwList.RunWorkerAsync();
      gridJOB.Select();
    }

    private void sluOperator_EditValueChanged(object sender, EventArgs e)
    {
        if (sluOperator.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();            
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

    private void btShowItem_Click(object sender, EventArgs e)
    {
      int[] selectRow;
      DataRow row = gvJOB.GetFocusedDataRow();
      if (row == null) return;

      selectRow = gvJOB.GetSelectedRows();

      if (selectRow.Length <= 1)
      {
        _Jobid = cls_Library.DBInt(row["JOB_ID"]);
        _Jobcode = cls_Library.DBString(row["JOB_NO"]);
        _Jobdate = cls_Library.DBDateTime(row["JOB_DATE"]);
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void gvJOB_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
    {
      if (e.RowHandle >= 0)
      {
        GridView View = sender as GridView;
        GridViewInfo viewInfo = View.GetViewInfo() as GridViewInfo;
        int _id = cls_Library.CInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["JOB_ID"]));
        DataRow[] dr = dtJob.Select("JOB_ID = " + _id + "And ACTIVE = 1");
        if (dr.Length > 0)
        {
          e.Appearance.BackColor = Color.Green;
        }
        if (View.GetSelectedRows().Contains(e.RowHandle))
        {
          //e.Appearance.BackColor = Blend(e.Appearance.BackColor, viewInfo.PaintAppearance.FocusedRow.BackColor, 0.5D);
          e.Appearance.BackColor = Color.MediumOrchid;
        }
      }
    }

    private void frm_JobList_KeyDown(object sender, KeyEventArgs e)
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
          dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
          break;
        case 1:
          
          if (DateTime.Now.Month == 1)
          {
            dateFrom.EditValue = cls_Library.Date_CvDMY(1, 12, DateTime.Now.Year-1, false);
            dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year-1, 12), 12, DateTime.Now.Year-1, false);
          }
          else
          {
            dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month - 1, DateTime.Now.Year, false);
            dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month-1), DateTime.Now.Month, DateTime.Now.Year, false);
          }
          
          break;
        case 2:
          dateFrom.Enabled = true;
          dateTo.Enabled = true;
          break;
      }

      if (item.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
    }

    private void frm_JobList_Load(object sender, EventArgs e)
    {

    }
  }
}