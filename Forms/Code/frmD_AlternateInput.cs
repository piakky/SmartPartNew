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
  public partial class frmD_AlternateInput : DevExpress.XtraEditors.XtraForm
  {
    public frmD_AlternateInput()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      TxtAlternatePart.Text = "";
      TxtAlternateBrand.Text = "";
      radioAlternateStatus.SelectedIndex = 0;
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      bool err = false;

      if ((TxtAlternatePart.EditValue == null) || (TxtAlternatePart.Text == ""))
      {
        XtraMessageBox.Show("กรุณาระบุหมายเลขอะไหล่", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtAlternatePart.ErrorText = "กรุณาระบุหมายเลขอะไหล่";
        TxtAlternatePart.Focus();
        err = true;
      }
      else
      {

        //if (CheckCodeExist(txtAcc.Text.Trim()))
        //{
        //  txtAcc.ErrorText = "Cannot insert duplicate key";
        //  txtAcc.Focus();
        //  err = true;
        //}

      }

      //if (!err)
      //{
      //  if ((TxtAlternateBrand.EditValue == null) || (TxtAlternateBrand.Text == ""))
      //  {
      //    XtraMessageBox.Show("กรุณาระบุยี่ห้อ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //    TxtAlternateBrand.ErrorText = "กรุณาระบุยี่ห้อ";
      //    TxtAlternateBrand.Focus();
      //    err = true;
      //  }
      //}


      if (err)
      {
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void frmD_AlternateInput_KeyDown(object sender, KeyEventArgs e)
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