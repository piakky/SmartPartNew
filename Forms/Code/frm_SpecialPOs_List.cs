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

namespace SmartPart.Forms.Code
{
  public partial class frm_SpecialPOs_List : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
      private DataSet dsProduct = new DataSet();

    #endregion

    #region function

    public void DeleteData()
    {
      if (dsProduct.Tables["M_SPECIALS"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvSpecial.GetFocusedDataRow();
      int Id = cls_Library.DBInt(Drow["SPECIAL_ID"]);
      string CGcode = System.Convert.ToString(Drow["SPECIAL_CODE"]);
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรหัสคำสั่งพิเศษ : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeleteSpecial(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("ลบรหัสคำสั่งพิเศษ :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!bwCode.IsBusy)
            {
              bwCode.RunWorkerAsync();
            }
            else
            {
              XtraMessageBox.Show("System is running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }
        catch (Exception ex)
        {
          XtraMessageBox.Show(ex.Message);
        }
      }
    }

    private void LoadData()
    {
      dsProduct = cls_Data.GetListSpecials();
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      frm_SpecialPOs_Record frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      frmInput = new frm_SpecialPOs_Record(mode);
      frmInput.StartPosition = FormStartPosition.CenterParent;

      switch (mode)
      {
        case cls_Struct.ActionMode.Add:
          strMode = " [เพิ่ม]";
          break;
        case cls_Struct.ActionMode.Edit:
          strMode = " [แก้ไข]";
          break;
        case cls_Struct.ActionMode.Copy:
          strMode = " [คัดลอก]";
          break;
      }

      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSpecial;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != cls_Struct.ActionMode.Add)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "คำสั่งพิเศษ (P/O)" + strMode;
        #region "XXX"
        if (dr != null)
        {
          if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
          {
            if (mode == cls_Struct.ActionMode.Edit)
            {
              frmInput.Prop_Codeid = cls_Library.DBInt(dr["SPECIAL_ID"]);          
            }
            else
            {
              frmInput.Prop_Codeid = 0;
            }
            frmInput.Prop_RowData = dr;
            frmInput.TxtSpecialCode.Text = cls_Library.DBString(dr["SPECIAL_CODE"]);
            frmInput.TxtSpecialName.Text = cls_Library.DBString(dr["SPECIAL_NAME"]);
            frmInput.TxtSpecialDesc.Text = cls_Library.DBString(dr["SPECIAL_DESCRIPTION"]);
          }
          else
          {
            DataTable dt = (DataTable)gridSpecial.DataSource;
            frmInput.Prop_RowData = dt.NewRow();
          }
        }
        else
        {
          DataTable dt = (DataTable)gridSpecial.DataSource;
          frmInput.Prop_RowData = dt.NewRow();
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsProduct.Tables["M_SPECIALS"].BeginInit();

        if (mode == cls_Struct.ActionMode.Add)
        {
          if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["M_SPECIALS"].Rows.Count == 1))
          {
            dsProduct.Tables["M_SPECIALS"].ImportRow(frmInput.getLastdata.Tables["M_SPECIALS"].Rows[0]);
          }
        }
        dsProduct.Tables["M_SPECIALS"].EndInit();
        gridSpecial.DataSource = dsProduct.Tables["M_SPECIALS"];
        gridSpecial.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }
    #endregion

    public frm_SpecialPOs_List()
    {
        InitializeComponent();
        if (!bwCode.IsBusy)
        {
            bwCode.RunWorkerAsync();
        }
    }

    private void bwCode_DoWork(object sender, DoWorkEventArgs e)
    {
        LoadData();
    }

    private void bwCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      gridSpecial.DataSource = dsProduct.Tables["M_SPECIALS"];
      gridSpecial.RefreshDataSource();
    }

    private void frm_Product_List_FormClosing(object sender, FormClosingEventArgs e)
    {
      Class_Library mc = new Class_Library();
      Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
      ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
    }

    private void gvPDT_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }
  }
}