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
  public partial class frmD_DocumentInput : DevExpress.XtraEditors.XtraForm
  {
    public frmD_DocumentInput()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void frmD_DocumentInput_KeyDown(object sender, KeyEventArgs e)
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

      if ((searchLookUpDocument.EditValue == null) || (searchLookUpDocument.Text == "เลือกรหัสเอกสาร"))
      {
        XtraMessageBox.Show("กรุณาระบุรหัสเอกสาร", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        searchLookUpDocument.ErrorText = "กรุณาระบุรหัสเอกสาร";
        searchLookUpDocument.Focus();
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
      searchLookUpDocument.EditValue = null;
      TxtDocName.Text = "";
      TxtDescription.Text = "";
      TxtAddress.Text = "";
    }
  }
}