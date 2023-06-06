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
  public partial class frmD_VendorsInput : DevExpress.XtraEditors.XtraForm
  {
    public frmD_VendorsInput()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }


    private void btSave_Click(object sender, EventArgs e)
    {
      bool err = false;

      if ((searchLookUpVendor.EditValue == null) || (searchLookUpVendor.Text == "เลือกรหัสเจ้าหนี้"))
      {
        XtraMessageBox.Show("กรุณาระบุรหัสเจ้าหนี้", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        searchLookUpVendor.ErrorText = "กรุณาระบุรหัสเจ้าหนี้";
        searchLookUpVendor.Focus();
        err = true;
      }
      else
      {
        if (cls_Library.DBInt(spinPiority.EditValue) < 1)
        {
          XtraMessageBox.Show("กรุณาระบุลำดับความสำคัญ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          spinPiority.ErrorText = "กรุณาระบุลำดับความสำคัญ";
          spinPiority.Focus();
          err = true;
        }
      }

      if (err)
      {
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void frmD_VendorsInput_KeyDown(object sender, KeyEventArgs e)
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

    private void btReset_Click(object sender, EventArgs e)
    {
      searchLookUpVendor.EditValue = null;
      TxtVendorName.Text = "";
      spinPiority.EditValue = 1;
    }

    private void searchLookUpVendor_EditValueChanged(object sender, EventArgs e)
    {
        SearchLookUpEdit item = (SearchLookUpEdit)sender;
        int id = Convert.ToInt32(item.EditValue);
        if (id > 0)
        {
            TxtVendorName.Text = cls_Data.GetNameFromTBname(id, "VENDORS", "VENDOR_NAME");
        }
    }
    }
}