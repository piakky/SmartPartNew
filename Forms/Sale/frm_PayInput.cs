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
    public partial class frm_PayInput : DevExpress.XtraEditors.XtraForm
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

        #endregion

        public frm_PayInput(cls_Struct.TypePay paytype)
        {
            InitializeComponent();
            KeyPreview = true;
            PayType = paytype;
        }

        private void frm_PayInput_Load(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void sluCode_EditValueChanged(object sender, EventArgs e)
        {
            DataRow[] rowck = dtRepo.Select("_id = " + sluCode.EditValue);
            if (rowck.Length == 0)
                return;

            txtName.Text = rowck[0]["name"].ToString();
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
    }
}