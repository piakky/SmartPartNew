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
  public partial class frmD_BrandDiscount_Input : DevExpress.XtraEditors.XtraForm
  {
    private string Branddesc= "";

    public string BrandDesc
    {
      get { return Branddesc; }
    }

    public frmD_BrandDiscount_Input()
    {
      InitializeComponent();
      this.KeyPreview = true;
    }

    private void frmD_BrandDiscount_Input_KeyDown(object sender, KeyEventArgs e)
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

      if ((sluBrand.EditValue == null) || (sluBrand.Text == "เลือกยี่ห้อสินค้า"))
      {
        XtraMessageBox.Show("กรุณาระบุยี่ห้อสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        sluBrand.ErrorText = "กรุณาระบุยี่ห้อสินค้า";
        sluBrand.Focus();
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
      sluBrand.EditValue = null;
      txtBrandName.Text = "";
      spinDisC1.EditValue = 0;
      spinDisC2.EditValue = 0;
      spinDisC3.EditValue = 0;
      spinDisC4.EditValue = 0;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void sluBrand_EditValueChanged(object sender, EventArgs e)
    {
      DataRow[] dr = cls_Global_DB.DataInitial.Tables["M_BRANDS"].Select("_id = " + sluBrand.EditValue);
      if (dr.Length == 0)
        return;
      txtBrandName.Text = dr[0]["name"].ToString();
      Branddesc = dr[0]["description"].ToString();
    }

    private void frmD_BrandDiscount_Input_Load(object sender, EventArgs e)
    {
      sluBrand.Focus();
    }
  }
}