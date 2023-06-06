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
  public partial class frm_HistorySQ : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    int ItemID = 0;
    cls_Struct.GetHistorySQ GetHis;
    DataTable dtHistory = new DataTable();
    DataTable dtUnit = new DataTable();
    DataRow drows;
    private double Zquan, Zconv;
    #endregion

    #region Property
    public string ItemName
    {
        set { txtItemName.Text = value; }
    }
    #endregion

    #region Function
    private void LoadData()
    {
      try
      {
        GetHis = new cls_Struct.GetHistorySQ();
        GetHis.Customer = cls_Library.CInt(sluCus.EditValue);
        GetHis.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
        GetHis.DateTo = cls_Library.CDateTime(dateTo.EditValue);
        GetHis.HStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);                
        GetHis.ItemId = ItemID;

        dtHistory = cls_Data.GetHistorySQData(GetHis, cls_Global_class.GB_ShowAll);

        cls_Global_DB.DataInitial = cls_Data.GetDataInitial();

        if (cls_Global_DB.DataInitial == null)
        {
          cls_Global_DB.DataInitial = new DataSet();
          cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));
          cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_UNITS"));
        }
        else
        {
          if (!cls_Global_DB.DataInitial.Tables.Contains("M_VENDORS"))
              cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));

          if (!cls_Global_DB.DataInitial.Tables.Contains("M_UNITS"))
              cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_UNITS"));
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show("LoadData: " + ex.Message);
      }
    }

    private void LoadDefaultData()
    {
      try
      {
        comboStatus.Properties.Items.Add("ทุกสถานะ");
        comboStatus.Properties.Items.Add("เปิด");
        comboStatus.Properties.Items.Add("ปิด");
        comboStatus.Properties.Items.Add("ยกเลิก");
        comboStatus.SelectedIndex = 0;
        comboTypedate.SelectedIndex = 0;

        //dateFrom.EditValue = DateTime.Today;
        //dateTo.EditValue = DateTime.Today;
        dateFrom.EditValue = cls_Library.GetDateLastYear();
        dateTo.EditValue = cls_Library.GetDateCurrentYear();

      }
      catch (Exception ex)
      {
        MessageBox.Show("LoadDefaultData: " + ex.Message);
      }
    }

    private void ThreadStart()
    {
      if (!bwList.IsBusy) bwList.RunWorkerAsync();
    }

    private void ViewData()
    {
        DevExpress.XtraGrid.Views.Grid.GridView view;
        int ID = 0, SQD_ID = 0;
        try
        {
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvHistory;
            if ((view.FocusedRowHandle < 0)) return;
            DataRow row = view.GetFocusedDataRow();

            SQD_ID = cls_Library.DBInt(row["SQD_ID"]);
            ID = cls_Library.DBInt(row["SQD_PID"]);

            //dsData = cls_Data.GetROById(ID);

            frm_SQRecord frm = new frm_SQRecord(cls_Struct.ActionMode.View, ID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = "Supplier Quatation - [ดูข้อมูล]";
            frm.MinimizeBox = false;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show("ViewData:" + ex.Message);
        }
    }
    #endregion

    public frm_HistorySQ(int Id)
    {
      cls_Global_class.GB_ShowAll = false;
      InitializeComponent();
      this.KeyPreview = true;
      ItemID = Id;
      this.Text = "SQ History";
      LoadDefaultData();
      dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", 0);
      ThreadStart(); 
    }

    private void btSearch_Click(object sender, EventArgs e)
    {
      ThreadStart();
    }

    private void bwList_DoWork(object sender, DoWorkEventArgs e)
    {
      LoadData();
    }

    private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      cls_Library.AssignSearchLookUp(sluCus, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");
      repoSearchCus.DataSource = cls_Global_DB.DataInitial.Tables["M_VENDORS"];
      repoSearchCus.ValueMember = "_id";
      repoSearchCus.DisplayMember = "code";
      //repoSearchCus.DisplayMember = "name";

      //repoSearchUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
      //repoSearchUnit.ValueMember = "_id";
      ////repoSearchUnit.DisplayMember = "code";
      //repoSearchUnit.DisplayMember = "name";
      string[] selectedColumns = new[] { "_id", "code", "name", "MULTIPLY_QTY", "codename" };
      DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
      //repoSearchUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
      repoSearchUnit.DataSource = dt;
      repoSearchUnit.ValueMember = "_id";
      repoSearchUnit.DisplayMember = "codename";

      gridHistory.DataSource = dtHistory;
      gridHistory.RefreshDataSource();

      gridHistory.Focus();
    }

    private void frm_frm_HistorySQ_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Escape:
                this.Close();
                break;
            case Keys.F11:
                btView.PerformClick();
                break;
        }
    }

    private void btView_Click(object sender, EventArgs e)
    {
        ViewData();
    }

    private void comboTypedate_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBoxEdit item = (ComboBoxEdit)sender;
      dateFrom.Enabled = false;
      dateTo.Enabled = false;
      cls_Global_class.GB_ShowAll = false;
      switch (item.SelectedIndex)
      {
        case 0:
          //dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
          //dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
          dateFrom.EditValue = cls_Library.GetDateLastYear();
          dateTo.EditValue = cls_Library.GetDateCurrentYear();
          break;
        case 1:

          //if (DateTime.Now.Month == 1)
          //{
          //    dateFrom.EditValue = cls_Library.Date_CvDMY(1, 12, DateTime.Now.Year - 1, false);
          //    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year - 1, 12), 12, DateTime.Now.Year - 1, false);
          //}
          //else
          //{
          //    dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month - 1, DateTime.Now.Year, false);
          //    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1), DateTime.Now.Month-1, DateTime.Now.Year, false);
          //}
          cls_Global_class.GB_ShowAll = true;
          break;
        case 2:
          dateFrom.Enabled = true;
          dateTo.Enabled = true;
          break;
      }

      if (item.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
    }

    private void gvHistory_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        try
        {
            if (e.IsGetData)
            {
                switch (e.Column.FieldName)
                {
                    case "col_quan":
                        if (!Double.TryParse(gvHistory.GetListSourceRowCellValue(e.ListSourceRowIndex, "QTY").ToString(), out Zquan)) Zquan = 0;
                        if (!Double.TryParse(gvHistory.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;
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