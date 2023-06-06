using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using SmartPart.Class;

namespace SmartPart.Forms.Code
{
    public partial class frm_Creditcards_List : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        RepositoryItemGridLookUpEdit SlookupBank = new RepositoryItemGridLookUpEdit();
        private DataSet dsProduct = new DataSet();
        private DataTable dtBank = null;

        #endregion

        #region function

        public void DeleteData()
        {
            if (dsProduct.Tables["M_CREDITCARDS"].Rows.Count == 0)
            {
            return;
            }
            DataRow Drow = gvCredit.GetFocusedDataRow();
            int Id = cls_Library.DBInt(Drow["CREDITCARD_ID"]);
            string CGcode = System.Convert.ToString(Drow["CREDITCARD_CODE"]);
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรหัสบัตรเครดิต : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                bool OK = cls_Data.DeleteCreditcard(Id);

                try
                {
                    if (OK)
                    {
                        MessageBox.Show("ลบรหัสบัตรเครดิต :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!bwCode.IsBusy)
                        {
                            bwCode.RunWorkerAsync();
                        }
                        else
                        {
                            XtraMessageBox.Show("System is running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadData()
        {
            dsProduct = cls_Data.GetListCreditcards();
            dtBank = cls_Data.GetListBanksForLookUp();
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            frm_Creditcards_Record frmInput;
            DevExpress.XtraGrid.Views.Grid.GridView view;
            DataRow dr = null;
            string strMode = String.Empty;

            frmInput = new frm_Creditcards_Record(mode);
            frmInput.StartPosition = FormStartPosition.CenterParent;

            switch (mode)
            {
            case cls_Struct.ActionMode.Add:
                strMode = " [เพิ่ม]";
                break;
            case cls_Struct.ActionMode.Edit:
                strMode = " [แก้ไข]";
                break;
            case cls_Struct.ActionMode.Copy:
                strMode = " [คัดลอก]";
                break;
            }

            try
            {
            DataTable dtGroup = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvCredit;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != cls_Struct.ActionMode.Add)
                {
                return;
                }
            }
            dr = view.GetFocusedDataRow();
            frmInput.Text = "บัตรเครดิต" + strMode;
            #region "XXX"
            frmInput.searchLookUpCreditBank.Properties.DataSource = dtBank;
            frmInput.searchLookUpCreditBank.Properties.PopulateViewColumns();
            frmInput.searchLookUpCreditBank.Properties.ValueMember = "_id";
            frmInput.searchLookUpCreditBank.Properties.DisplayMember = "code";
            frmInput.searchLookUpCreditBank.Properties.View.Columns["_id"].Visible = false;
            frmInput.searchLookUpCreditBank.Properties.View.Columns["code"].Caption = "ชื่อย่อธนาคาร";
            frmInput.searchLookUpCreditBank.Properties.View.Columns["name"].Caption = "ชื่อเต็มธนาคาร";
            if (dr != null)
            {
                if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
                {
                if (mode == cls_Struct.ActionMode.Edit)
                {
                    frmInput.Prop_Codeid = cls_Library.DBInt(dr["CREDITCARD_ID"]);          
                }
                else
                {
                    frmInput.Prop_Codeid = 0;
                }
                frmInput.Prop_RowData = dr;
                frmInput.searchLookUpCreditBank.EditValue = cls_Library.DBInt(dr["BANK_ID"]);
                if (cls_Library.DBInt(dr["BANK_ID"]) > 0)
                {
                    frmInput.TxtBankName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(dr["BANK_ID"]), "BANKS", "FULL_NAME");
                }
                frmInput.TxtCreditCode.Text = cls_Library.DBString(dr["CREDITCARD_CODE"]);
                frmInput.TxtCreditDesc.Text = cls_Library.DBString(dr["CREDITCARD_DESCRIPTION"]);
                }
                else
                {
                DataTable dt = (DataTable)gridCredit.DataSource;
                frmInput.Prop_RowData = dt.NewRow();
                }
            }
            else
            {
                DataTable dt = (DataTable)gridCredit.DataSource;
                frmInput.Prop_RowData = dt.NewRow();
            }
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsProduct.Tables["M_CREDITCARDS"].BeginInit();

            if (mode == cls_Struct.ActionMode.Add)
            {
                if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["M_CREDITCARDS"].Rows.Count == 1))
                {
                dsProduct.Tables["M_CREDITCARDS"].ImportRow(frmInput.getLastdata.Tables["M_CREDITCARDS"].Rows[0]);
                }
            }
            dsProduct.Tables["M_CREDITCARDS"].EndInit();
            gridCredit.DataSource = dsProduct.Tables["M_CREDITCARDS"];
            gridCredit.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }
        #endregion

        public frm_Creditcards_List()
        {
            InitializeComponent();
            this.KeyPreview = true;
            if (!bwCode.IsBusy)
            {
                bwCode.RunWorkerAsync();
            }
        }

        private void bwCode_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void bwCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridCredit.DataSource = dsProduct.Tables["M_CREDITCARDS"];
            gridCredit.RefreshDataSource();

            //SlookupBank.DataSource = dtBank; ;
            //SlookupBank.PopulateViewColumns();
            //SlookupBank.View.Columns["_id"].Visible = false;
            //SlookupBank.View.Columns["code"].Caption = "ชื่อย่อธนาคาร";
            //SlookupBank.View.Columns["name"].Caption = "ชื่อเต็มธนาคาร";

            //SlookupBank.ValueMember = "_id";
            //SlookupBank.DisplayMember = "code";
        }

        private void frm_Product_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class_Library mc = new Class_Library();
            Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
            ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
        }

        private void gvPDT_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void frm_Creditcards_List_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    InitialDialogForm(cls_Struct.ActionMode.Add);
                    break;
                case Keys.F6:
                    InitialDialogForm(cls_Struct.ActionMode.Edit);
                    break;
                case Keys.F7:
                    //InitialDialogForm(cls_Struct.ActionMode.Delete);
                    DeleteData();
                    break;
            }
        }
    }
}