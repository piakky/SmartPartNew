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
  public partial class frmD_ItemVersatiles_Sub : DevExpress.XtraEditors.XtraForm
  {
    public frmD_ItemVersatiles_Sub()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void panelControl1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void btSave_Click(object sender, EventArgs e)
    {
      bool err = false;


      if ((TxtCodeSub.EditValue == null) || (TxtCodeSub.Text == ""))
      {
        XtraMessageBox.Show("กรุณาระบุรหัสกลุ่มย่อย", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtCodeSub.ErrorText = "กรุณาระบุรหัสกลุ่มย่อย";
        TxtCodeSub.Focus();
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

    }

    private void frmD_ItemSetInput_KeyDown(object sender, KeyEventArgs e)
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

  }
}