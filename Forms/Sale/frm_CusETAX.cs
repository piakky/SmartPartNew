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
    public partial class frm_CusETAX : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtMain = new DataTable();
        private cls_Struct.StructCusTaxInv Data = new cls_Struct.StructCusTaxInv();
        private cls_Struct.ActionMode DataMode;
        private int CusId = 0;
        private int AddId = 0;
        private string AddCode = "";
        #endregion

        #region Property
        public int CUSID
        {
            get { return CusId; }
            set { CusId = value; }
        }

        public int AddressID
        {
            get { return AddId; }
            set { AddId = value; }
        }

        public string AddressCode
        {
            get { return AddCode; }
            set { AddCode = value; }
        }
        #endregion

        #region Function
        private void AssignDataFromComponent()
        {
            Data.ADDRESS_ID = AddId;
            Data.ADDRESS_CODE = AddCode;
            Data.CUSTOMER_NAME = txtName.Text;
            Data.CUSTOMER_ID = CusId;
            Data.ADDRESS_1 = txtAddr1.Text;
            Data.ADDRESS_2 = txtAddr2.Text;
            Data.ADDRESS_3 = txtAddr3.Text;
            Data.ADDRESS_4 = txtAddr4.Text;
            Data.TAX_ID = txtTaxId.Text;
            Data.BRANCH = txtBranch.Text;
            Data.TEL = txtTel.Text;
            Data.FAX = txtFax.Text;
            Data.E_MAIL = txtEmail.Text;
            Data.CONTRACT = txtContact.Text;
        }

        private void LoadData()
        {
            //dtMain = cls_Data.GetAddress(AddId, 1);
            //if (dtMain.Rows.Count > 0)
            //{
            //    txtCode.EditValue = cls_Library.DBInt(dtMain.Rows[0][""]);
            //}
        }

        private void LoadDefaultData()
        {
            txtCode.Properties.DataSource = cls_Data.GetDataTable("M_CUSTOMERS");
            txtCode.Properties.PopulateViewColumns();
            txtCode.Properties.View.Columns["_id"].Visible = false;
            txtCode.Properties.View.Columns["code"].Visible = false;
            txtCode.Properties.View.Columns["name"].Visible = false;
            txtCode.Properties.ValueMember = "_id";
            txtCode.Properties.DisplayMember = "name";
        }

        private void SaveData()
        {
            bool IsSaveOK = false;

            try
            {
                AssignDataFromComponent();
                IsSaveOK = cls_Data.SaveCus_TaxInv(DataMode, Data);
                if (IsSaveOK)
                {
                    XtraMessageBox.Show("บันทึกข้อมูลที่อยู่เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Application.DoEvents();
                XtraMessageBox.Show("ไม่สามารถบันทึกที่อยู่ได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (IsSaveOK)
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private bool VerifyData()
        {
            bool ret = true;
            StringBuilder msg = new StringBuilder();
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return false;

                if (txtCode.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสลูกค้าไม่ถูกต้อง");
                }

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    ret = false;
                    msg.AppendLine("ไม่มีชื่อลูกค้า");
                }

                //if (!cls_Library.IsDate(dateRS.EditValue))
                //{
                //    ret = false;
                //    msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
                //}

                if (!ret)
                {
                    MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
            }
            return ret;
        }
        #endregion

        public frm_CusETAX(cls_Struct.ActionMode mode, int id)
        {
            InitializeComponent();
            KeyPreview = true;
            DataMode = mode;
            LoadDefaultData();
            if (mode == cls_Struct.ActionMode.Edit) LoadData();
            AddId = id;
        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            if (VerifyData()) SaveData();
        }

        private void BTcancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frm_CusETAX_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BTsave.PerformClick();
                    break;
                case Keys.Escape:
                    BTcancel.PerformClick();
                    break;
            }
        }

        private void txtCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                CusId = id;
                txtName.Text = cls_Data.GetNameFromTBname(id, "CUSTOMERS", "CUSTOMER_NAME");
                txtAddr1.Text = cls_Data.GetNameFromTBname(id, "CUSTOMERS", "ADDRESS_1");
                txtAddr2.Text = cls_Data.GetNameFromTBname(id, "CUSTOMERS", "ADDRESS_2");
                txtAddr3.Text = cls_Data.GetNameFromTBname(id, "CUSTOMERS", "ADDRESS_3");
                txtAddr4.Text = cls_Data.GetNameFromTBname(id, "CUSTOMERS", "ADDRESS_4");
                txtTaxId.Text = cls_Data.GetNameFromTBname(id, "CUSTOMERS", "TAX_ID");
                txtBranch.Text = "";
                txtTel.Text = cls_Data.GetNameFromTBname(id, "CUSTOMERS", "TEL");
                txtFax.Text = "";
                txtEmail.Text = cls_Data.GetNameFromTBname(id, "CUSTOMERS", "E_MAIL");
                txtContact.Text = "";
            }
        }
    }
}