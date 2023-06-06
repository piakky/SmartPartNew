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
  public partial class frm_ItemSpecials_Sub2_List : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
      private DataSet dsProduct = new DataSet();

    #endregion

    #region function

    public void DeleteData()
    {
      if (dsProduct.Tables["M_ITEMS_SPECIALS_SUB2"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvSub1.GetFocusedDataRow();
      int Id = cls_Library.DBInt(Drow["SUB_ID"]);
      string CGcode = System.Convert.ToString(Drow["SUB_CODE"]);
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 2  : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeleteItemSpecialSub2(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("ลบรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 2  :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      dsProduct = cls_Data.GetListItemSpecialsSub2();
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      frm_ItemSpecials_Sub2_Record frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      frmInput = new frm_ItemSpecials_Sub2_Record(mode);
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
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub1;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != cls_Struct.ActionMode.Add)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "รหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 2 " + strMode;
        #region "XXX"
        if (dr != null)
        {
          if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
          {
            frmInput.Prop_RowData = dr;
            if (mode == cls_Struct.ActionMode.Edit)
            {
              frmInput.Prop_Codeid = cls_Library.DBInt(dr["SUB_ID"]);
              frmInput.TxtItemCode.Text = cls_Library.DBString(dr["SUB_CODE"]);
            }
            else
            {
              frmInput.Prop_Codeid = 0;
              frmInput.TxtItemCode.Text = cls_Data.GetLastCodeMaster("ITEMS_SPECIALS_SUB2", 4);
            }
            frmInput.TxtItemName.Text = cls_Library.DBString(dr["SUB_NAME"]);
            frmInput.TxtItemDesc1.Text = cls_Library.DBString(dr["SUB_DESCRIPTION1"]);
            frmInput.TxtItemDesc2.Text = cls_Library.DBString(dr["SUB_DESCRIPTION2"]);
            frmInput.TxtItemDesc3.Text = cls_Library.DBString(dr["SUB_DESCRIPTION3"]);
            frmInput.TxtSub1ID.Text = cls_Library.DBString(dr["SUB1_ID"]);
            frmInput.TxtSub1Code.Text = cls_Library.DBString(dr["SUB1_CODE"]);
            frmInput.TxtSub1Name.Text = cls_Library.DBString(dr["SUB1_NAME"]);
          }
          else
          {
            DataTable dt = (DataTable)gridSub1.DataSource;
            frmInput.Prop_RowData = dt.NewRow();
            frmInput.TxtItemCode.Text = cls_Data.GetLastCodeMaster("ITEMS_SPECIALS_SUB2", 4);
          }
        }
        else
        {
          DataTable dt = (DataTable)gridSub1.DataSource;
          frmInput.Prop_RowData = dt.NewRow();
          frmInput.TxtItemCode.Text = cls_Data.GetLastCodeMaster("ITEMS_SPECIALS_SUB2", 4);
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsProduct.Tables["M_ITEMS_SPECIALS_SUB2"].BeginInit();

        if (mode == cls_Struct.ActionMode.Add)
        {
          if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["M_ITEMS_SPECIALS_SUB2"].Rows.Count == 1))
          {
            dsProduct.Tables["M_ITEMS_SPECIALS_SUB2"].ImportRow(frmInput.getLastdata.Tables["M_ITEMS_SPECIALS_SUB2"].Rows[0]);
          }
        }
        dsProduct.Tables["M_ITEMS_SPECIALS_SUB2"].EndInit();
        gridSub1.DataSource = dsProduct.Tables["M_ITEMS_SPECIALS_SUB2"];
        gridSub1.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }
    #endregion

    public frm_ItemSpecials_Sub2_List()
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
      gridSub1.DataSource = dsProduct.Tables["M_ITEMS_SPECIALS_SUB2"];
      gridSub1.RefreshDataSource();
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