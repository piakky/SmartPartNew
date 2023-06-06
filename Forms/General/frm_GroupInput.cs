using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SmartPart.Forms.General
{
    public partial class frm_GroupInput : DevExpress.XtraEditors.XtraForm
    {
        public frm_GroupInput()
        {
            InitializeComponent();
        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            if ((txtGroupCode.EditValue == null) || (txtGroupCode.Text == ""))
            {
                XtraMessageBox.Show("กรุณาระบุชื่อกลุ่มสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGroupCode.ErrorText = "กรุณาระบุชื่อกลุ่มสินค้า";
                txtGroupCode.Focus();
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BTcancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}