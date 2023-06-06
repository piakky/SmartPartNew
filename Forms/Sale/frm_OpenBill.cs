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
    public partial class frm_OpenBill : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDisplayDelegate();

        #region Variable
        private DataTable dtCus = new DataTable();
        private DataTable dtPer = new DataTable();
        private int IdCus = 0;
        private int IdPer = 0;
        private string CusCode = "";
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

        public string CUS_CODE
        {
            get { return CusCode; }
            set { CusCode = value; }
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
                        sluCus.Text = cls_Data.GetNameFromTBname(Xarr, "CUSTOMERS", "CUSTOMER_CODE");
                        txtNameCus.Text = cls_Data.GetNameFromTBname(Xarr, "CUSTOMERS", "CUSTOMER_NAME");
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

        private void SetDataToControl()
        {
            //sluCus.Properties.DataSource = dtCus;
            //sluCus.Properties.PopulateViewColumns();
            //sluCus.Properties.View.Columns["_id"].Visible = false;
            //sluCus.Properties.View.Columns["code"].Caption = "รหัสลูกค้า";
            //sluCus.Properties.View.Columns["name"].Caption = "ชื่อลูกค้า";

            //sluCus.Properties.ValueMember = "_id";
            //sluCus.Properties.DisplayMember = "code";
            //sluCus.Properties.View.Columns["codename"].Visible = false;

            //sluPer.Properties.DataSource = dtPer;
            //sluPer.Properties.PopulateViewColumns();
            //sluPer.Properties.View.Columns["_id"].Visible = false;
            //sluPer.Properties.View.Columns["code"].Caption = "รหัสพนักงานขาย";
            //sluPer.Properties.View.Columns["name"].Caption = "ชื่อพนักงานขาย";

            //sluPer.Properties.ValueMember = "_id";
            //sluPer.Properties.DisplayMember = "code";
        }
        #endregion

        public frm_OpenBill()
        {
            InitializeComponent();
            this.KeyPreview = true;
            sluCus.Select();
        }

        private void frm_OpenBill_Load(object sender, EventArgs e)
        {
            //Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
            //{
            //  this.Invoke(new SetDisplayDelegate(SetDataToControl));
            //});
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //IdCus = cls_Library.CInt(sluCus.EditValue);
            //IdPer = cls_Library.CInt(sluPer.EditValue);

            if (txtNamePer.Text.Length > 0)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            
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
            IdCus = cls_Library.DBInt(cls_Data.GetNameFromTBname(sluCus.Text.Trim(), "CUSTOMERS", "CUSTOMER_ID"));
            CusCode = cls_Library.DBString(cls_Data.GetNameFromTBname(sluCus.Text.Trim(), "CUSTOMERS", "CUSTOMER_CODE"));
            txtNameCus.Text = cls_Data.GetNameFromTBname(IdCus, "CUSTOMERS", "CUSTOMER_NAME");

            

        }

        private void sluPer_EditValueChanged(object sender, EventArgs e)
        {
            if (!sluPer.IsEditorActive) return;
            SearchLookUpEdit lookUp = sender as SearchLookUpEdit;
            DataRowView dataRow = lookUp.GetSelectedDataRow() as DataRowView;
            if (dataRow != null)
            {
                txtNamePer.Text = cls_Library.DBString(dataRow["Name"]);
            }
        }

        private void BTbrowse_Click(object sender, EventArgs e)
        {
            InitialListCode();
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            txtNamePer.Text = "";
            sluPer.Text = cls_Data.CheckCodeUser(txtPassword.Text.Trim());
            IdPer = cls_Library.DBInt(cls_Data.GetNameFromTBname(sluPer.Text, "USER", "USER_ID"));
            txtNamePer.Text = cls_Data.GetNameFromTBname(IdPer, "USER", "USER_NAME"); 
        }

        private void sluCus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                txtPassword.Select();
            }
        }

        private void frm_OpenBill_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    cmdClose.PerformClick();
                    break;
            }
        }
    }
}