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
    public partial class frmSearch3 : DevExpress.XtraEditors.XtraForm
    {
        private void ClearValueObject()
        {

            searchPOGroupsCode.EditValue = null;
            TxtPOGroupName.Text = "";
            searchVendorsCode.EditValue = null;
            TxtVendorName.Text = "";
            searchBrandCode.EditValue = null;
            txtBrandName.Text = "";
            searchTypesCode.EditValue = null;
            txtTypesName.Text = "";
        }
        public frmSearch3()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void frmSearch3_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
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

        private void BTsearch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTreset_Click(object sender, EventArgs e)
        {
            ClearValueObject();
        }

        private void searchPOGroupsCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                TxtPOGroupName.Text = cls_Data.GetNameFromTBname(id, "PO_GROUPS", "PO_GROUP_NAME");
            }
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

        private void searchBrandCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                txtBrandName.Text = cls_Data.GetNameFromTBname(id, "BRANDS", "BRAND_NAME");
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
    }
}