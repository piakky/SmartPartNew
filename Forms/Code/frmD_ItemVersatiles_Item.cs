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
  public partial class frmD_ItemVersatiles_Item : DevExpress.XtraEditors.XtraForm
  {
    public frmD_ItemVersatiles_Item()
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
      bool err = true;


      if ((searchLookUpProduct.EditValue != null) || (searchLookUpProduct.Text != "เลือกรหัสสินค้า"))
      {
        err = false;
      }

      if (err)
      {
        XtraMessageBox.Show("กรุณาระบุรหัสสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        searchLookUpProduct.Focus();
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

    private void searchLookUpProduct_EditValueChanged(object sender, EventArgs e)
    {
      SearchLookUpEdit item = (SearchLookUpEdit)sender;
      int id = Convert.ToInt32(item.EditValue);
      if (id > 0)
      {
        TxtCode.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "ITEM_CODE");
        TxtName.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "FULL_NAME");
      }
    }

  }
}