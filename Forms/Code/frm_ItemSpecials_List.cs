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
  public partial class frm_ItemSpecials_List : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
      private DataSet dsProduct = new DataSet();

    #endregion

    #region function

    public void DeleteData()
    {
      if (dsProduct.Tables["M_ITEMS_SPECIALS"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvItem.GetFocusedDataRow();
      int Id = cls_Library.DBInt(Drow["ITEMS_SPECIAL_ID"]);
      string CGcode = System.Convert.ToString(Drow["ITEMS_SPECIAL_CODE"]);
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรหัสกลุ่มสินค้าเฉพาะ : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeleteItemSpecial(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("ลบรหัสกลุ่มสินค้าเฉพาะ :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      dsProduct = cls_Data.GetListItemSpecials();
      cls_Global_DB.DataInitialItemSpecial = cls_Data.GetDataInitialItemSpecial();
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      DataRow row = gvItem.GetFocusedDataRow();
      int pid = 0;
      string strMode = "";

      switch (mode)
      {
        //case cls_Global_class.ActionMode.Add:
        //break;
        case cls_Struct.ActionMode.Edit:
        case cls_Struct.ActionMode.Copy:
          if (row == null) return;
          pid = cls_Library.ConvertToInt(row["ITEMS_SPECIAL_ID"].ToString());
          break;
      }


      frm_ItemSpecials_Record frm = new frm_ItemSpecials_Record(mode, pid);
      //frm.ItemID = pid;
      //frm.InitialDialog(mode);
      frm.ShowInTaskbar = false;
      frm.StartPosition = FormStartPosition.CenterParent;
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

      frm.Text = "รหัสกลุ่มสินค้าเฉพาะ  " + strMode;

      if (frm.ShowDialog() == DialogResult.OK)
      {
        if (!bwCode.IsBusy)
        {
          this.UseWaitCursor = true;
          bwCode.RunWorkerAsync();
        }
        this.UseWaitCursor = false;
        this.Cursor = Cursors.Default;
      }
    }
    #endregion

    public frm_ItemSpecials_List()
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
      gridItem.DataSource = dsProduct.Tables["M_ITEMS_SPECIALS"];
      gridItem.RefreshDataSource();
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