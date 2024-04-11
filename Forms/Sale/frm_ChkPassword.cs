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

namespace SmartPart.Forms.Sale
{
    public partial class frm_ChkPassword : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChkPassword()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                if (!string.IsNullOrEmpty(cls_Data.CheckCodeUser(txtPassword.Text.Trim())))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("รหัสผ่านไม่ถูกต้อง");
                }
            }
        }

        private void frm_ChkPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

            }
        }
    }
}