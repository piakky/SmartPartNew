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
  public partial class frmD_Bank_Input : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    int Datatype = 0;
    private DataTable dtBranch = new DataTable();
    #endregion

    private void SetBranch()
    {
      try
      {
        //dtBranch = cls_Data.GetDataTable("D_BANK_BRANCHS", cls_Library.DBInt(sluBank.EditValue));
        //sluBranch.Properties.DataSource = dtBranch;
        //sluBranch.Properties.PopulateViewColumns();
        //sluBranch.Properties.ValueMember = "_id";
        //sluBranch.Properties.DisplayMember = "code";
        //sluBranch.Properties.View.Columns["_id"].Visible = false;
        //sluBranch.Properties.View.Columns["code"].Caption = "รหัสสาขา";
        //sluBranch.Properties.View.Columns["name"].Caption = "ชื่อสาขา";
      }
      catch (Exception)
      {
      }
    }

    public frmD_Bank_Input(int _type)
    {
      // _type 1: customer
      // _type 2: Vendor
      InitializeComponent();
      this.KeyPreview = true;
      Datatype = _type;
    }

    private void frmD_Bank_Input_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F2:
          btSave_Click(sender, e);
          break;
        case Keys.F3:
          btReset_Click(sender, e);
          break;
        case Keys.Escape:
          btClose_Click(sender, e);
          break;
      }
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      bool err = false;

      if ((sluBank.EditValue == null) || (cls_Library.DBInt(sluBank.EditValue) == 0) || (sluBank.Text == "เลือกรหัสธนาคาร"))
      {
        XtraMessageBox.Show("กรุณาระบุรหัสธนาคาร", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        sluBank.ErrorText = "กรุณาระบุรหัสธนาคาร";
        sluBank.Focus();
        err = true;
      }

      if (err) return;
      

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      sluBank.EditValue = null;
      txtBankName.Text = "";
      txtBranchName.Text = "";
      txtAccountNo.Text = "";
      txtAccountName.Text = "";
      txtNote.Text = "";
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void sluBank_EditValueChanged(object sender, EventArgs e)
    {
      SetBranch();
      DataRow[] dr = cls_Global_DB.DataInitial.Tables["M_BANKS"].Select("_id = " + sluBank.EditValue);
      if (dr.Length == 0)
        return;
      txtBankName.Text = dr[0]["name"].ToString();      
    }

    private void frmD_Bank_Input_Load(object sender, EventArgs e)
    {
      sluBank.Focus();
    }
  }
}