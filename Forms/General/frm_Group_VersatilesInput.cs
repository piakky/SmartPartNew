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
    public partial class frm_Group_VersatilesInput : DevExpress.XtraEditors.XtraForm
    {
        public frm_Group_VersatilesInput()
        {
            InitializeComponent();
        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            if ((txtGroupCode.EditValue == null) || (txtGroupCode.Text == ""))
            {
                XtraMessageBox.Show("กรุณาระบุรหัสกลุ่มย่อย", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGroupCode.ErrorText = "กรุณาระบุรหัสกลุ่มย่อย";
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