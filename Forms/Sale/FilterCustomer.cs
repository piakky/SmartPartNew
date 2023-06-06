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
using SmartPart.Forms.General;

namespace SmartPart.Forms.Sale
{
    public partial class FilterCustomer : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDisplayDelegate();

        #region Variable
        private DataTable dtCus = new DataTable();
        private DataTable dtPer = new DataTable();
        private int IdCus = 0;
        private int IdPer = 0;
        bool UserOK = false;

        #endregion

        #region Properties
        public int CUS_ID
        {
            get { return IdCus; }
            set { IdCus = value; }
        }

        public int PER_ID
        {
            get { return IdPer; }
        }
        #endregion

        #region Function
        private void InitialListCode()
        {
            try
            {
                frm_ListFilter frm = new frm_ListFilter(2);
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Text = "รหัสลูกค้า";

                frm.MinimizeBox = false;
                frm.ShowInTaskbar = false;
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    int Xarr = frm.Prop_Arr;
                    bool ok = false;
                    if (Xarr > 0) ok = true;
                    if (ok)
                    {
                        txtCustomer.Text = cls_Data.GetNameFromTBname(Xarr, "CUSTOMERS", "CUSTOMER_CODE");
                        txtCustomerName.Text = cls_Data.GetNameFromTBname(Xarr, "CUSTOMERS", "CUSTOMER_NAME");
                        cls_Sales.Sale_Cus = Xarr;
                    }
                }
            }
            catch (Exception)
            {
                this.Focus();
            }
        }

        private void LoadData()
        {
            //dtCus = cls_Data.GetDataTable("M_CUSTOMERS");
            //dtPer = cls_Data.GetDataTable("M_PERSONALS");
        }

        #endregion

        public FilterCustomer()
        {
            InitializeComponent();
            KeyPreview = true;
            txtCustomer.Select();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //IdCus = cls_Library.CInt(sluCus.EditValue);
            //IdPer = cls_Library.CInt(sluPer.EditValue);

            if (txtCustomer.Text.Length == 0)
            {
                XtraMessageBox.Show("ยังไมได้ระบุรหัสลูกค้า", "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void sluCus_EditValueChanged(object sender, EventArgs e)
        {
            //if (!sluCus.IsEditorActive) return;
            //SearchLookUpEdit lookUp = sender as SearchLookUpEdit;
            //DataRowView dataRow = lookUp.GetSelectedDataRow() as DataRowView;
            //if (dataRow != null)
            //{
            //  txtNameCus.Text = cls_Library.DBString(dataRow["Name"]);
            //}
            IdCus = cls_Library.DBInt(cls_Data.GetNameFromTBname(txtCustomer.Text.Trim(), "CUSTOMERS", "CUSTOMER_CODE"));
            txtCustomerName.Text = cls_Data.GetNameFromTBname(IdCus, "CUSTOMERS", "CUSTOMER_NAME");
            cls_Sales.Sale_Cus = IdCus;

        }

        private void BTbrowse_Click(object sender, EventArgs e)
        {
            InitialListCode();
        }

        private void txtUserCode_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) InitialListCode();

        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmdOK.Select();
            }
        }

        private void FilterCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    cmdOK.PerformClick();
                    break;
                case Keys.Escape:
                    cmdClose.PerformClick();
                    break;
            }
        }
    }
}