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
    public partial class frmSearch1 : DevExpress.XtraEditors.XtraForm
    {
        private void ClearValueObject()
        {
            txtPdtCode.Text = "";
            searchCategoriesCode.EditValue = null;
            txtCategoriesName.Text = "";
            txtAbbreviateName.Text = "";
            txtGenuinPart.Text = "";
            txtProducerPart.Text = "";
            txtFullName.Text = "";
            searchBrandCode.EditValue = null;
            txtBrandName.Text = "";
            searchSizesCode.EditValue = null;
            txtSizesName.Text = "";
            txtSizeInner.Text = "";
            txtSizeOutside.Text = "";
            txtSizeThick.Text = "";
            txtModel1.Text = "";
            txtModel2.Text = "";
            txtModel3.Text = "";
            txtLocation.Text = "";
            txtAlternate.Text = "";
            searchTypesCode.EditValue = null;
            txtTypesName.Text = "";
        }
        public frmSearch1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void frmSearch1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case Keys.F3:
                    ClearValueObject();
                    break;
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;

            }
        }

        private void searchCategoriesCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                txtCategoriesName.Text = cls_Data.GetNameFromTBname(id, "CATEGORIES", "CATEGORY_NAME");
            }
        }

        private void searchBrandCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                txtBrandName.Text = cls_Data.GetNameFromTBname(id, "BRANDS", "BRAND_NAME");
            }
        }

        private void searchSizesCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                txtSizesName.Text = cls_Data.GetNameFromTBname(id, "SIZES", "SIZE_NAME");
            }
        }

        private void searchTypesCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                txtTypesName.Text = cls_Data.GetNameFromTBname(id, "TYPES", "TYPE_NAME");
            }
        }

        private void BTsearch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTreset_Click(object sender, EventArgs e)
        {
            ClearValueObject();
        }
    }
}