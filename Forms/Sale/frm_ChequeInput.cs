using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartPart.Class;

namespace SmartPart.Forms.Sale
{
    public partial class frm_ChequeInput : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private cls_Struct.TypePay PayType;
        private DataTable dtRepo = new DataTable();
        #endregion

        #region Property
        public DataTable dtSlu
        {
            set { dtRepo = value; }
        }
        #endregion

        #region Function
        private bool VerifyData()
        {
            bool ret = true;
            StringBuilder msg = new StringBuilder();
            try
            {
                if (sluCode.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสธนาคารไม่ถูกต้อง");
                }

                if (string.IsNullOrEmpty(txtChequeNo.Text))
                {
                    ret = false;
                    msg.AppendLine("ไม่มีเลขที่เช็ค");
                }

                if (!cls_Library.IsDate(txtDateCheque.EditValue))
                {
                    ret = false;
                    msg.AppendLine("วันที่เช็คไม่ถูกต้อง");
                }


                if (string.IsNullOrEmpty(txtName.Text))
                {
                    ret = false;
                    msg.AppendLine("ไม่มีชื่อหน้าเช็ค");
                }

                if (!ret)
                {
                    MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ret;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ret;
        }
        #endregion

        public frm_ChequeInput(cls_Struct.TypePay paytype)
        {
            InitializeComponent();
            KeyPreview = true;
            PayType = paytype;
            sluCode.Select();
        }

        private void frm_PayInput_Load(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                DialogResult = DialogResult.OK;
            }
           
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void sluCode_EditValueChanged(object sender, EventArgs e)
        {
            //DataRow[] rowck = dtRepo.Select("_id = " + sluCode.EditValue);
            //if (rowck.Length == 0)
            //    return;

            //txtName.Text = rowck[0]["name"].ToString();
            txtChequeNo.Select();
        }

        private void frm_PayInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btSave.PerformClick();
                    break;
                case Keys.Escape:
                    btClose.PerformClick();
                    break;
            }
        }

        private void spinAmount_MouseUp(object sender, MouseEventArgs e)
        {
            SpinEdit item = (SpinEdit)sender;
            item.SelectAll();
        }

        private void spinAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btSave.Select();
        }
    }
}