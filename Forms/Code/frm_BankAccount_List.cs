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
  public partial class frm_BankAccount_List : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private DataSet dsProduct = new DataSet();
    private DataTable dtBank = null;

    #endregion

    #region function

    public void DeleteData()
    {
      if (dsProduct.Tables["M_BANKS_ACCOUNTS"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvBank.GetFocusedDataRow();
      int Id = cls_Library.DBInt(Drow["BANKS_ACCOUNT_ID"]);
      string CGcode = System.Convert.ToString(Drow["BANKS_ACCOUNT_CODE"]);
      DialogResult Result = XtraMessageBox.Show("ต้องการลบเลขที่บัญชีเงินฝากธนาคาร : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeleteBankAccount(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("ลบเลขที่บัญชีเงินฝากธนาคาร :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
      dsProduct = cls_Data.GetListBankAccounts();
      dtBank = cls_Data.GetDataTable("M_BANKS");
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      frm_BankAccount_Record frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      frmInput = new frm_BankAccount_Record(mode);
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
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvBank;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != cls_Struct.ActionMode.Add)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "บัญชีเงินฝากธนาคาร" + strMode;
        #region "XXX"
        frmInput.sluBank.Properties.DataSource = dtBank;
        frmInput.sluBank.Refresh();
        frmInput.sluBank.Properties.PopulateViewColumns();
        frmInput.sluBank.Properties.View.Columns["_id"].Visible = false;
        frmInput.sluBank.Properties.View.Columns["code"].Caption = "ชื่อย่อธนาคาร";
        frmInput.sluBank.Properties.View.Columns["name"].Caption = "ชื่อธนาคาร";
        frmInput.sluBank.Properties.ValueMember = "_id";
        frmInput.sluBank.Properties.DisplayMember = "code";
        frmInput.sluBank.EditValue = null;
        if (dr != null)
        {
          if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
          {
            if (mode == cls_Struct.ActionMode.Edit)
            {
              frmInput.Prop_Codeid = cls_Library.DBInt(dr["BANKS_ACCOUNT_ID"]);
              frmInput.Prop_BankCode = cls_Library.DBString(dr["BANKS_ACCOUNT_CODE"]);
            }
            else
            {
              frmInput.Prop_Codeid = 0;
            }
            frmInput.Prop_RowData = dr;
            if (cls_Library.DBInt(dr["BANK_ID"]) > 0) frmInput.sluBank.EditValue = cls_Library.DBInt(dr["BANK_ID"]);
            frmInput.TxtBankName.Text = cls_Library.DBString(dr["FULL_NAME"]);
            frmInput.TxtBankBranch.Text = cls_Library.DBString(dr["BANKS_ACCOUNT_BRANCH"]);
            frmInput.TxtBankAccCode.Text = cls_Library.DBString(dr["BANKS_ACCOUNT_CODE"]);
            frmInput.TxtBankAccName.Text = cls_Library.DBString(dr["BANKS_ACCOUNT_NAME"]);
            frmInput.TxtBankNote.Text = cls_Library.DBString(dr["BANKS_ACCOUNT_NOTE"]);
            frmInput.radioType.SelectedIndex = cls_Library.DBInt(dr["BANKS_ACCOUNT_TYPE"]) - 1;
            if (frmInput.radioType.SelectedIndex < 0) frmInput.radioType.SelectedIndex = 0;
          }
          else
          {
            DataTable dt = (DataTable)gridBank.DataSource;
            frmInput.Prop_RowData = dt.NewRow();
          }
        }
        else
        {
          DataTable dt = (DataTable)gridBank.DataSource;
          frmInput.Prop_RowData = dt.NewRow();
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsProduct.Tables["M_BANKS_ACCOUNTS"].BeginInit();

        if (mode == cls_Struct.ActionMode.Add)
        {
          if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["M_BANKS_ACCOUNTS"].Rows.Count == 1))
          {
            dsProduct.Tables["M_BANKS_ACCOUNTS"].ImportRow(frmInput.getLastdata.Tables["M_BANKS_ACCOUNTS"].Rows[0]);
          }
        }
        dsProduct.Tables["M_BANKS_ACCOUNTS"].EndInit();
        gridBank.DataSource = dsProduct.Tables["M_BANKS_ACCOUNTS"];
        gridBank.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }
    #endregion

    public frm_BankAccount_List()
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
      gridBank.DataSource = dsProduct.Tables["M_BANKS_ACCOUNTS"];
      gridBank.RefreshDataSource();
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