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
using System.Threading.Tasks;

namespace SmartPart.Forms.Sale
{
    public partial class frm_AddressEtaxList : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDelegate();

        #region Variable
        private DataTable dtMain = new DataTable();
        private int CusId = 0;
        int AddressID = 0;
        #endregion

        #region Property
        public int SetAddressID
        {
            set { AddressID = value; }
            get { return AddressID; }
        }
        #endregion

        #region Function
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        private void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            try
            {
                DataRow row = gvAddr.GetFocusedDataRow();
                int pid = 0;
                string strMode = "";

                switch (mode)
                {
                    case cls_Struct.ActionMode.Add:
                        strMode = " [เปิดใหม่]";
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (row == null) return;
                        strMode = " [แก้ไข]";
                        pid = cls_Library.DBInt(row["CUSTOMER_ID"]);
                        break;
                }

                frm_CusETAX frmAddr = new frm_CusETAX(mode, pid);
                frmAddr.StartPosition = FormStartPosition.CenterParent;

                frmAddr.Text = "ที่อยู่" + strMode;
                switch (mode)
                {
                    case cls_Struct.ActionMode.Add:
                        frmAddr.CUSID = 0;
                        frmAddr.AddressID = 0;
                        frmAddr.AddressCode = cls_Data.GetLastCodeMaster("M_CUS_TAXINV", 5);
                        frmAddr.txtCode.EditValue = null;
                        frmAddr.txtCode.ReadOnly = false;
                        frmAddr.txtCode.BackColor = Color.White;
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (row == null) return;
                        strMode = " [แก้ไข]";
                        pid = cls_Library.DBInt(row["CUSTOMER_ID"]);
                        frmAddr.CUSID = cls_Library.DBInt(row["CUSTOMER_ID"]);
                        frmAddr.AddressID = cls_Library.DBInt(row["ADDRESS_ID"]);
                        frmAddr.AddressCode = cls_Library.DBString(row["ADDRESS_CODE"]);
                        frmAddr.txtCode.EditValue = cls_Library.DBInt(row["CUSTOMER_ID"]);
                        frmAddr.txtCode.ReadOnly = true;
                        frmAddr.txtCode.BackColor = Color.FromArgb(255, 255, 192);
                        frmAddr.txtName.Text = cls_Library.DBString(row["CUSTOMER_NAME"]);
                        frmAddr.txtAddr1.Text = cls_Library.DBString(row["ADDRESS_1"]);
                        frmAddr.txtAddr2.Text = cls_Library.DBString(row["ADDRESS_2"]);
                        frmAddr.txtAddr3.Text = cls_Library.DBString(row["ADDRESS_3"]);
                        frmAddr.txtAddr4.Text = cls_Library.DBString(row["ADDRESS_4"]);
                        frmAddr.txtTaxId.Text = cls_Library.DBString(row["TAX_ID"]);
                        frmAddr.txtBranch.Text = cls_Library.DBString(row["BRANCH"]);
                        frmAddr.txtTel.Text = cls_Library.DBString(row["TEL"]);
                        frmAddr.txtFax.Text = cls_Library.DBString(row["FAX"]);
                        frmAddr.txtEmail.Text = cls_Library.DBString(row["E_MAIL"]);
                        frmAddr.txtContact.Text = cls_Library.DBString(row["CONTRACT"]);
                        break;
                }
                frmAddr.MinimizeBox = false;
                frmAddr.ShowInTaskbar = false;
                if (frmAddr.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
                    {
                        this.Invoke(new SetDelegate(SetDataToControl));
                    });
                    this.UseWaitCursor = false;
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("InitialDialogForm :" + ex.Message);
            }
        }

        private void LoadData()
        {
            dtMain = cls_Data.GetAddress(CusId, 1);
        }

        private void SetDataToControl()
        {
            gridAddr.DataSource = dtMain;
            gridAddr.RefreshDataSource();
        }
        #endregion

        public frm_AddressEtaxList(int Id)
        {
            InitializeComponent();
            KeyPreview = true;
            CusId = Id;
        }

        private void frm_AddressEtaxList_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
            {
                this.Invoke(new SetDelegate(SetDataToControl));
            });
            gvAddr.Focus();
        }

        private void gvAddr_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.Add);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            InitialDialogForm(cls_Struct.ActionMode.Edit);
        }

        private void frm_AddressEtaxList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    btAdd.PerformClick();
                    break;
                case Keys.F6:
                    btEdit.PerformClick();
                    break;
                case Keys.F8:
                    btSearch.PerformClick();
                    break;
                case Keys.F9:
                    btActive.PerformClick();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void btActive_Click(object sender, EventArgs e)
        {
            DataRow row = gvAddr.GetFocusedDataRow();
            if (row == null) return;
            AddressID = cls_Library.DBInt(row["ADDRESS_ID"]);
            this.DialogResult = DialogResult.OK;
        }

        private void gvAddr_DoubleClick(object sender, EventArgs e)
        {
            btActive.PerformClick();
        }
    }
}