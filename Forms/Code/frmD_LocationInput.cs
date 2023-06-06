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
  public partial class frmD_LocationInput : DevExpress.XtraEditors.XtraForm
  {
    public frmD_LocationInput()
    {
      InitializeComponent();
      //if (Convert.ToInt32(chkUseMode.EditValue) == 0)
      //{
      //  labelSerialNumber.Visible = false;
      //  TxtSerialNumber.Visible = false;
      //}
      this.KeyPreview = true;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      bool err = false;

      if ((TxtLocationName.EditValue == null) || (TxtLocationName.Text ==""))
      {
        XtraMessageBox.Show("กรุณาระบุชื่อคลังสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtLocationName.ErrorText = "กรุณาระบุชื่อคลังสินค้า";
        TxtLocationName.Focus();
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

      if (!err)
      {
        if (TxtSerialNumber.Visible == true)
        {
          if ((TxtSerialNumber.EditValue == null) || (TxtSerialNumber.Text == ""))
          {
            XtraMessageBox.Show("กรุณาระบุหมายเลขประจำเครื่อง", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TxtSerialNumber.ErrorText = "กรุณาระบุหมายเลขประจำเครื่อง";
            TxtSerialNumber.Focus();
            err = true;
          }
        }
      }


      if (err)
      {
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
      TxtLocationName.Text = "";
      spinQuantity.EditValue = 0;
      chkUseMode.EditValue = true;
      TxtSerialNumber.Text = "";
    }

    private void frmD_LocationInput_KeyDown(object sender, KeyEventArgs e)
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