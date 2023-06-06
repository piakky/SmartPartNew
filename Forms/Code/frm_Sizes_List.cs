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
  public partial class frm_Sizes_List : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
      private DataSet dsProduct = new DataSet();

    #endregion

    #region function

    public void DeleteData()
    {
      if (dsProduct.Tables["M_SIZES"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvSize.GetFocusedDataRow();
      int Id = cls_Library.DBInt(Drow["SIZE_ID"]);
      string CGcode = System.Convert.ToString(Drow["SIZE_CODE"]);
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรหัสประเภทสินค้า + ขนาด : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeleteSize(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("ลบรหัสประเภทสินค้า + ขนาด :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      dsProduct = cls_Data.GetListSizes();
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      frm_Sizes_Record frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      frmInput = new frm_Sizes_Record(mode);
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
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSize;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != cls_Struct.ActionMode.Add)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "ประเภทสินค้า + ขนาด" + strMode;
        #region "XXX"
        if (dr != null)
        {
          if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
          {
            frmInput.Prop_RowData = dr;
            if (mode == cls_Struct.ActionMode.Edit)
            {
              frmInput.Prop_Codeid = cls_Library.DBInt(dr["SIZE_ID"]);
              frmInput.TxtSizeCode.Text = cls_Library.DBString(dr["SIZE_CODE"]);
            }
            else
            {
              frmInput.Prop_Codeid = 0;
              frmInput.TxtSizeCode.Text = cls_Library.DBString(dr["SIZE_CODE"]);
            }
            frmInput.TxtSizeName.Text = cls_Library.DBString(dr["SIZE_NAME"]);
            frmInput.TxtSizeDesc.Text = cls_Library.DBString(dr["SIZE_DESCRIPTION"]);
          }
          else
          {
            DataTable dt = (DataTable)gridSize.DataSource;
            frmInput.Prop_RowData = dt.NewRow();
            frmInput.TxtSizeCode.Text = "";
          }
        }
        else
        {
          DataTable dt = (DataTable)gridSize.DataSource;
          frmInput.Prop_RowData = dt.NewRow();
          frmInput.TxtSizeCode.Text = "";
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsProduct.Tables["M_SIZES"].BeginInit();

        if (mode == cls_Struct.ActionMode.Add)
        {
          if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["M_SIZES"].Rows.Count == 1))
          {
            dsProduct.Tables["M_SIZES"].ImportRow(frmInput.getLastdata.Tables["M_SIZES"].Rows[0]);
          }
        }
        dsProduct.Tables["M_SIZES"].EndInit();
        gridSize.DataSource = dsProduct.Tables["M_SIZES"];
        gridSize.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }
    #endregion

    public frm_Sizes_List()
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
      gridSize.DataSource = dsProduct.Tables["M_SIZES"];
      gridSize.RefreshDataSource();
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