using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SmartPart.Forms.Code
{
  public partial class frmD_Cheque_Input : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    int Datatype = 0;

    #endregion
    public frmD_Cheque_Input(int _type)
    {
      // _type 1: customer
      // _type 2: Vendor
      InitializeComponent();
      this.KeyPreview = true;
      Datatype = _type;  
    }

    private void frmD_Cheque_Input_KeyDown(object sender, KeyEventArgs e)
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
      if (txtName.EditValue == null || txtName.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุชื่อเช็ค", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtName.ErrorText = "กรุณาระบุชื่อเช็ค";
        txtName.Focus();
        err = true;
      }
      if (err) return;
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      txtName.Text = "";
      chkUse.Checked = false;
      txtNote.Text = "";
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmD_Cheque_Input_Load(object sender, EventArgs e)
    {
      txtName.Focus();
    }
  }
}