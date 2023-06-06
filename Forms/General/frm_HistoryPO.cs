﻿using System;
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
  public partial class frm_HistoryPO : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    int ItemID = 0;
    cls_Struct.GetHistoryPO GetHis;
    DataTable dtHistory = new DataTable();
    DataTable dtUnit = new DataTable();
    private double Zquan, Zconv;
    #endregion

    #region Property
    public string ItemName
    { 
        set { txtItemName.Text = value; } 
    }
    #endregion

    #region Function
    private int AssigNo(DataSet dsData)
    {
        int no = 1;
        try
        {
            no = dsData.Tables["PODETAIL"].Rows.Count + 1;
        }
        catch (Exception ex)
        { MessageBox.Show("AssigNo :" + ex.Message); }
        return no;
    }

    private void LoadData()
    {
      try
      {
        GetHis = new cls_Struct.GetHistoryPO();
        GetHis.Customer = cls_Library.CInt(sluCus.EditValue);
        GetHis.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
        GetHis.DateTo = cls_Library.CDateTime(dateTo.EditValue);
        GetHis.HStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);
        GetHis.ItemId = ItemID;

        dtHistory = cls_Data.GetHistoryPOData(GetHis,cls_Global_class.GB_ShowAll);
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
          MessageBox.Show("LoadData :" + ex.Message);
      }
    }

    private void LoadDefaultData()
    {
      try
      {                
        comboStatus.Properties.Items.Add("เปิด");
        comboStatus.Properties.Items.Add("ปิด");
        //dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
        //dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
        dateFrom.EditValue = cls_Library.GetDateLastYear();
        dateTo.EditValue = cls_Library.GetDateCurrentYear();
        comboStatus.SelectedIndex = 0;
        comboTypedate.SelectedIndex = 0;
      }
      catch (Exception ex)
      {
        MessageBox.Show("LoadDefaultData :" + ex.Message);
      }
    }

    private void ThreadStart()
    {
        if (!bwList.IsBusy) bwList.RunWorkerAsync();
    }

    private void ViewData()
    {
        DevExpress.XtraGrid.Views.Grid.GridView view;
        int ID = 0, POD_ID = 0;
        try
        {
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvHistory;
            if ((view.FocusedRowHandle < 0)) return;
            DataRow row = view.GetFocusedDataRow();

            POD_ID = cls_Library.DBInt(row["POD_ID"]);
            ID = cls_Library.DBInt(row["POD_PID"]);

            frm_PORecord frm = new frm_PORecord(cls_Struct.ActionMode.View, ID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Text = "ส่งคืนสินค้า - [ดูข้อมูล]";
            frm.MinimizeBox = false;
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show("ViewData : " + ex.Message);
        }
    }
    #endregion

    public frm_HistoryPO(int Id)
    {
      InitializeComponent();
      ItemID = Id;
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

    private void frm_HistoryPO_KeyDown(object sender, KeyEventArgs e)
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
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}