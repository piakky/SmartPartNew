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
  public partial class frmD_ItemSpecials_Sub : DevExpress.XtraEditors.XtraForm
  {
    public frmD_ItemSpecials_Sub()
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


      if ((searchLookUpSub2.EditValue == null) || (searchLookUpSub2.Text == "เลือกรหัสกลุ่มย่อยระดับที่ 2"))
      {
        XtraMessageBox.Show("กรุณาระบุรหัสกลุ่มย่อยระดับที่ 2", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        searchLookUpSub2.ErrorText = "กรุณาระบุรหัสกลุ่มย่อยระดับที่ 2";
        searchLookUpSub2.Focus();
        err = true;
      }

      if (!err)
      {
        if ((searchLookUpSub1.EditValue == null) || (searchLookUpSub1.Text == "เลือกรหัสกลุ่มย่อยระดับที่ 1"))
        {
          XtraMessageBox.Show("กรุณาระบุรหัสกลุ่มย่อยระดับที่ 1", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          searchLookUpSub1.ErrorText = "กรุณาระบุรหัสกลุ่มย่อยระดับที่ 1";
          searchLookUpSub1.Focus();
          err = false;
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

    private void searchLookUpSub2_EditValueChanged(object sender, EventArgs e)
    {
      SearchLookUpEdit item = (SearchLookUpEdit)sender;
      int id = Convert.ToInt32(item.EditValue);
      if (id > 0)
      {
        TxtCodeSub2.Text = cls_Data.GetNameFromTBname(id, "ITEMS_SPECIALS_SUB2", "SUB_CODE");
        TxtNameSub2.Text = cls_Data.GetNameFromTBname(id, "ITEMS_SPECIALS_SUB2", "SUB_NAME");
      }
    }

    private void searchLookUpSub1_EditValueChanged(object sender, EventArgs e)
    {
      SearchLookUpEdit item = (SearchLookUpEdit)sender;
      int id = Convert.ToInt32(item.EditValue);
      if (id > 0)
      {
        TxtCodeSub1.Text = cls_Data.GetNameFromTBname(id, "ITEMS_SPECIALS_SUB1", "SUB_CODE");
        TxtNameSub1.Text = cls_Data.GetNameFromTBname(id, "ITEMS_SPECIALS_SUB1", "SUB_NAME");
      }
    }

  }
}