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
  public partial class frmD_ItemSetInput : DevExpress.XtraEditors.XtraForm
  {
    public frmD_ItemSetInput()
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

      if (cls_Library.DBInt(spinOrder.EditValue) < 1)
      {
        XtraMessageBox.Show("กรุณาระบุลำดับสมาชิก", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        spinOrder.ErrorText = "กรุณาระบุลำดับสมาชิก";
        spinOrder.Focus();
        err = true;
      }

      if (!err)
      {
        if ((searchLookUpProduct.EditValue == null) || (searchLookUpProduct.Text == "เลือกรหัสสินค้า"))
        {
          XtraMessageBox.Show("กรุณาระบุรหัสสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          searchLookUpProduct.ErrorText = "กรุณาระบุรหัสสินค้า";
          searchLookUpProduct.Focus();
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

    private void btReset_Click(object sender, EventArgs e)
    {
      searchLookUpProduct.EditValue = null;
      searchLookUpBrand.EditValue = null;
      TxtFullname.Text = "";
      TxtModel1.Text = "";
      txtGenuinPart.Text = "";
      txtProducerPart.Text = "";
      TxtBrand.Text = "";
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
        TxtFullname.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "FULL_NAME");
        TxtModel1.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "MODEL1");
        txtGenuinPart.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "GENUIN_PART_ID");
        txtProducerPart.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "BRAND_PART_ID");
        searchLookUpBrand.EditValue = cls_Library.DBInt(cls_Data.GetNameFromTBname(id, "ITEMS", "BRAND_ID"));
        TxtBrand.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchLookUpBrand.EditValue), "BRANDS", "BRAND_NAME");
      }
    }
  }
}