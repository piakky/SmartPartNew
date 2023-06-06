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
  public partial class frmD_Car_Input : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    

    #endregion

    public frmD_Car_Input()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void frmD_Car_Input_KeyDown(object sender, KeyEventArgs e)
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

      if ((txtlicense.EditValue == null) || (txtlicense.Text == ""))
      {
        XtraMessageBox.Show("กรุณาระบุทะเบียนรถ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtlicense.ErrorText = "กรุณาระบุทะเบียนรถ";
        txtlicense.Focus();
        err = true;
      }

      if (err)
      {
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      txtBrand.Text = "";
      txtModel.Text = "";
      txtYear.Text = "";
      txtlicense.Text = "";
      txtNote.Text = "";
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmD_Car_Input_Load(object sender, EventArgs e)
    {
      txtBrand.Focus();
    }
  }
}