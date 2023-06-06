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
  public partial class frmD_ComponentInput : DevExpress.XtraEditors.XtraForm
  {
    public frmD_ComponentInput()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      TxtComponentCode.Text = "";
      TxtComponentName.Text = "";
      spinQuantity.EditValue = 1;
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      bool err = false;

      if ((TxtComponentCode.EditValue == null) || (TxtComponentCode.Text == ""))
      {
        XtraMessageBox.Show("กรุณาระบุรหัสส่วนประกอบ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtComponentCode.ErrorText = "กรุณาระบุรหัสส่วนประกอบ";
        TxtComponentCode.Focus();
        err = true;
      }

      if (!err)
      {
        if ((TxtComponentName.EditValue == null) || (TxtComponentName.Text == ""))
        {
          XtraMessageBox.Show("กรุณาระบุชื่อส่วนประกอบ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtComponentName.ErrorText = "กรุณาระบุชื่อส่วนประกอบ";
          TxtComponentName.Focus();
          err = true;
        }
      }

      if (!err)
      {
        if (cls_Library.DBInt(spinQuantity.EditValue) < 1)
        {
          XtraMessageBox.Show("กรุณาระบุจำนวน", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          spinQuantity.ErrorText = "กรุณาระบุจำนวน";
          spinQuantity.Focus();
          err = true;
        }
      }


      if (err)
      {
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void frmD_ComponentInput_KeyDown(object sender, KeyEventArgs e)
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