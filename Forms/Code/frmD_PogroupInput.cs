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
  public partial class frmD_PogroupInput : DevExpress.XtraEditors.XtraForm
  {
    public frmD_PogroupInput()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void frmD_PogroupInput_KeyDown(object sender, KeyEventArgs e)
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

      if ((searchLookUpPOGroup.EditValue == null) || (searchLookUpPOGroup.Text == "เลือกกลุ่มสั่งซื้อสินค้า"))
      {
        XtraMessageBox.Show("กรุณาระบุรหัสกลุ่มสั่งซื้อสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        searchLookUpPOGroup.ErrorText = "กรุณาระบุรหัสกลุ่มสั่งซื้อสินค้า";
        searchLookUpPOGroup.Focus();
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
      searchLookUpPOGroup.EditValue = null;
      TxtPOGroupName.Text = "";
    }

    private void searchLookUpPOGroup_EditValueChanged(object sender, EventArgs e)
    {
      SearchLookUpEdit item = (SearchLookUpEdit)sender;
      int id = Convert.ToInt32(item.EditValue);
      if (id > 0)
      {
        TxtPOGroupName.Text = cls_Data.GetNameFromTBname(id, "PO_GROUPS", "PO_GROUP_NAME");
      }
    }
  }
}