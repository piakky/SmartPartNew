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

namespace SmartPart.Forms.Code
{
  public partial class frm_Categories_List : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
      private DataSet dsProduct = new DataSet();

    #endregion

    #region function

    public void DeleteData()
    {
      if (dsProduct.Tables["M_CATEGORIES"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvCategory.GetFocusedDataRow();
      int Id = cls_Library.DBInt(Drow["CATEGORY_ID"]);
      string CGcode = System.Convert.ToString(Drow["CATEGORY_CODE"]);
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรหัสหมวดหมู่สินค้า : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeleteCategory(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("ลบรหัสหมวดหมู่สินค้า :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      dsProduct = cls_Data.GetListCategories();
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      frm_Categories_Record frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      frmInput = new frm_Categories_Record(mode);
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
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvCategory;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != cls_Struct.ActionMode.Add)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "หมวดหมู่สินค้า" + strMode;
        #region "XXX"
        if (dr != null)
        {
          if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
          {
            frmInput.Prop_RowData = dr;
            if (mode == cls_Struct.ActionMode.Edit)
            {
              frmInput.Prop_Codeid = cls_Library.DBInt(dr["CATEGORY_ID"]);
              frmInput.TxtCategoryCode.Text = cls_Library.DBString(dr["CATEGORY_CODE"]);
            }
            else
            {
              frmInput.Prop_Codeid = 0;
              frmInput.TxtCategoryCode.Text = cls_Data.GetLastCodeMaster("CATEGORIES", 3);
            }
            frmInput.TxtCategoryName.Text = cls_Library.DBString(dr["CATEGORY_NAME"]);
            frmInput.TxtCategoryDesc.Text = cls_Library.DBString(dr["CATEGORY_DESCRIPTION"]);
          }
          else
          {
            DataTable dt = (DataTable)gridCategory.DataSource;
            frmInput.Prop_RowData = dt.NewRow();
            frmInput.TxtCategoryCode.Text = cls_Data.GetLastCodeMaster("CATEGORIES", 3);
          }
        }
        else
        {
          DataTable dt = (DataTable)gridCategory.DataSource;
          frmInput.Prop_RowData = dt.NewRow();
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsProduct.Tables["M_CATEGORIES"].BeginInit();

        if (mode == cls_Struct.ActionMode.Add)
        {
          if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["M_CATEGORIES"].Rows.Count == 1))
          {
            dsProduct.Tables["M_CATEGORIES"].ImportRow(frmInput.getLastdata.Tables["M_CATEGORIES"].Rows[0]);
          }
        }
        dsProduct.Tables["M_CATEGORIES"].EndInit();
        gridCategory.DataSource = dsProduct.Tables["M_CATEGORIES"];
        gridCategory.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }
    #endregion

    public frm_Categories_List()
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
      gridCategory.DataSource = dsProduct.Tables["M_CATEGORIES"];
      gridCategory.RefreshDataSource();
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