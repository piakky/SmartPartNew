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
  public partial class frmD_Address_Input : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    int Datatype = 0;

    #endregion

    public frmD_Address_Input(int _type)
    {
      // _type 1: customer
      // _type 2: Vendor
      InitializeComponent();
      this.KeyPreview = true;
      Datatype = _type;
    }

    private void frmD_Address_Input_KeyDown(object sender, KeyEventArgs e)
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

      if ((txtAddr1.EditValue == null) || (txtAddr1.Text == ""))
      {
        XtraMessageBox.Show("กรุณาระบุที่อยู่", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtAddr1.ErrorText = "กรุณาระบุที่อยู่";
        txtAddr1.Focus();
        err = true;
      }

      if (err) return;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      txtLocation.Text = "";
      txtAddr1.Text = "";
      txtAddr2.Text = "";
      txtAddr3.Text = "";
      txtAddr4.Text = "";
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}