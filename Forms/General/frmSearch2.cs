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

namespace SmartPart.Forms.General
{
  public partial class frmSearch2 : DevExpress.XtraEditors.XtraForm
  {
    private void ClearValueObject()
    {
      searchVendorsCode.EditValue = null;
      TxtVendorName.Text = "";
    }
    public frmSearch2()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void frmSearch2_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F6:
          BTsearch.PerformClick();
          break;
        case Keys.F3:
          ClearValueObject();
          break;
        case Keys.Escape:
          this.DialogResult = DialogResult.Cancel;
          this.Close();
          break;

      }
    }

    private void BTsearch_Click(object sender, EventArgs e)
    {
      if ((cls_Library.DBInt(searchVendorsCode.EditValue) == 0) || (searchVendorsCode.Text == "เลือกรหัสพ่อค้า"))
      {
        MessageBox.Show("กรุณาเลือกรหัสพ่อค้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        searchVendorsCode.ErrorText = "กรุณาเลือกรหัสพ่อค้า";
        searchVendorsCode.Select();
        return;
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
        ClearValueObject();
    }

    private void searchVendorsCode_EditValueChanged(object sender, EventArgs e)
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