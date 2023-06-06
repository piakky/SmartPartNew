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
  public partial class frmD_TypeItem_Input : DevExpress.XtraEditors.XtraForm
  {
    public frmD_TypeItem_Input()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void frmD_TypeItem_Input_KeyDown(object sender, KeyEventArgs e)
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

      if ((txtType.EditValue == null) || (txtType.Text == ""))
      {
        XtraMessageBox.Show("กรุณาระบุประเภทสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtType.ErrorText = "กรุณาระบุประเภทสินค้า";
        txtType.Focus();
        err = true;
      }

      if (err) return;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      txtType.Text = "";
      radioVatStatus.SelectedIndex = 0;
      spinCredit.EditValue = 0;
      txtNote.Text = "";
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmD_TypeItem_Input_Load(object sender, EventArgs e)
    {
      txtType.Focus();
    }
  }
}