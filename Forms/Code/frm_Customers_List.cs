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
  public partial class frm_Customers_List : DevExpress.XtraEditors.XtraForm
  {

    #region Variable
    private DataSet dsCustomer = new DataSet();
    #endregion

    #region user define function

    public void DeleteData()
    {
      int[] selectRow;
      int _id = 0;
      try
      {
        DataRow row = gvCustomers.GetFocusedDataRow();
        if (row == null) return;

        if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;

        selectRow = gvCustomers.GetSelectedRows();

        if (selectRow.Length <= 1)
        {
          _id = cls_Library.DBInt(row["CUSTOMER_ID"].ToString());
          if (cls_Data.DeleteCustomer(_id))
          {
            dsCustomer.Tables["M_CUSTOMERS"].Rows.Remove(row);
          }
        }
        else
        {
          DataRow[] Rrow;
          for (int i = 0; i < selectRow.Length; i++)
          {
            _id = cls_Library.DBInt(gvCustomers.GetRowCellValue(selectRow[i], "CUSTOMER_ID").ToString());
            if (cls_Data.DeleteCustomer(_id))
            {
              Rrow = dsCustomer.Tables["M_CUSTOMERS"].Select("CUSTOMER_ID = " + _id);
              dsCustomer.Tables["M_CUSTOMERS"].Rows.Remove(Rrow[0]);
            }
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("DeleteData : " + ex.Message);
      }
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      DataRow row = gvCustomers.GetFocusedDataRow();
      int pid = 0;
      string strMode = "";

      switch (mode)
      {
        case cls_Struct.ActionMode.Add:
          pid = 0;
          break;
        case cls_Struct.ActionMode.Edit:
        case cls_Struct.ActionMode.Copy:
          if (row == null) return;
          pid = cls_Library.DBInt(row["CUSTOMER_ID"].ToString());
          break;
      }


      frm_Customers_Record frm = new frm_Customers_Record(mode, pid);
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

      frm.Text = "รหัสลูกค้า   " + strMode;

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

    private void LoadData()
    {
      dsCustomer = cls_Data.GetListCustomer();
      cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
    }

    #endregion

    public frm_Customers_List()
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
      gridCustomers.DataSource = dsCustomer.Tables["M_CUSTOMERS"];
      gridCustomers.RefreshDataSource();
    }

    private void frm_Customers_List_FormClosing(object sender, FormClosingEventArgs e)
    {
      Class_Library mc = new Class_Library();
      Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
      ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
    }

    private void gvCustomers_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }
  }
}