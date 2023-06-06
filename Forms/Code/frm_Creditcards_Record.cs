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
using System.Data.SqlClient;

namespace SmartPart.Forms.Code
{
    public partial class frm_Creditcards_Record : DevExpress.XtraEditors.XtraForm
    {
        #region "  Variables declaration  "

        private DataSet _getLastdata = null;
        private DataRow _RowData = null;

        cls_Struct.ActionMode _Mode = 0;
        private int _Codeid = 0;
        private bool IsSaveOK = false;

        #endregion

        #region "  Properties declaration  "

        public DataSet getLastdata
        {
            get
            {
            return _getLastdata;
            }
            set { _getLastdata = value; }
        }

        public DataRow Prop_RowData
        {
            get { return _RowData; }
            set { _RowData = value; }
        }

        public int Prop_Codeid
        {
            get { return _Codeid; }
            set { _Codeid = value; }
        }
        #endregion

        #region "  Function  "
        private bool CheckCodeExist(string Xcode)
        {
            bool err = false;
            //string User = "";
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = conn.CreateCommand();
            SqlDataReader rd = null;
            int id = 0;

            cls_Global_DB.ConnectDatabase(ref conn);

            err = false;
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT CREDITCARD_ID,CREDITCARD_CODE FROM M_CREDITCARDS WHERE CREDITCARD_CODE='" + Xcode + "' And DELETED=0";
            cmd.Connection = conn;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
            if ((_Mode == cls_Struct.ActionMode.Edit) || (_Mode == cls_Struct.ActionMode.Copy))
            {
                rd.Read();
                id = Convert.ToInt32(rd["CREDITCARD_ID"]);
                if (id != _Codeid)
                {
                err = true;
                }
            }
            else
            {
                err = true;
            }
            }

            if (!rd.IsClosed) rd.Close();

            return err;

        }
        private void AssignDataFromComponent()
        {
            _RowData["BANK_ID"] = cls_Library.DBInt(searchLookUpCreditBank.EditValue);
            _RowData["ABBREVIATE_NAME"] = cls_Library.DBString(searchLookUpCreditBank.Text.Trim());
            _RowData["FULL_NAME"] = TxtBankName.Text.Trim();
            _RowData["CREDITCARD_CODE"] = TxtCreditCode.Text.Trim();
            _RowData["CREDITCARD_DESCRIPTION"] = TxtCreditDesc.Text.Trim();
        }

        private void SaveData(int Btype)
        {
            bool err = false;

            if (searchLookUpCreditBank.EditValue == null || searchLookUpCreditBank.Text == "เลือกรหัสธนาคาร")
            {
                XtraMessageBox.Show("กรุณาระบุรหัสธนาคาร", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchLookUpCreditBank.ErrorText = "กรุณาระบุรหัสธนาคาร";
                searchLookUpCreditBank.Focus();
                err = true;
            }
            else
            {
                if (CheckCodeExist(TxtCreditCode.Text.Trim()))
                {
                    XtraMessageBox.Show("มีรหัสบัตรเครดิตนี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtCreditCode.ErrorText = "มีรหัสบัตรเครดิตนี้ในฐานข้อมูลแล้ว";
                    TxtCreditCode.Focus();
                    err = true;
                }

            }

            if (!err)
            {
                if (TxtCreditCode.EditValue == null || TxtCreditCode.Text == "")
                {
                    XtraMessageBox.Show("กรุณาระบุหมายเลขบัตรเครดิต", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtCreditCode.ErrorText = "กรุณาระบุหมายเลขบัตรเครดิต";
                    TxtCreditCode.Focus();
                    err = true;
                }
            }

            if (err)
            {
                return;
            }

            DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสบัตรเครดิต : " + TxtCreditCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                if (SaveDataOK())
                {
                    XtraMessageBox.Show("บันทึกรหัสบัตรเครดิตเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsSaveOK = true;
                    if (Btype == 1)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    IsSaveOK = false;
                    XtraMessageBox.Show("บันทึกรหัสบัตรเครดิตไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private bool SaveDataOK()
        {
            DataTable TB = new DataTable();
            DataTable tbGRP = new DataTable();
            DataRow drow = null;
            string Pass = String.Empty;
            int SaveMode = 0;
            bool ret = false;

            try
            {
            drow = null;

            if ((_Mode == cls_Struct.ActionMode.Add) || (_Mode == cls_Struct.ActionMode.Copy))
            {
                SaveMode = 0;
            }
            else 
            {
                SaveMode = 1;
            }
            AssignDataFromComponent();
            TB = _RowData.Table.Clone();
            DataRow newRow = TB.NewRow();
            newRow.ItemArray = _RowData.ItemArray;
            TB.Rows.Add(newRow);

            //--- Save ข้อมูลลงฐานข้อมูล 
            _getLastdata = SaveCreditcard(TB, SaveMode);
            _Mode = cls_Struct.ActionMode.Edit;
            ret = true;
            }
            catch (Exception ex)
            {
            Application.DoEvents();
            if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
            {
                TxtCreditCode.ErrorText = "";
                TxtCreditCode.Focus();
            }
            else
            {
                XtraMessageBox.Show("ไม่สามารถบันทึกรหัสบัตรเครดิตได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ret = false;
            }

            return ret;
        }
        public DataSet SaveCreditcard(DataTable Tb, int Mode)
        {
            DataSet _dsdata = new DataSet();
            int CreditcardID = 0;
            DateTime DT;

            if (Tb.Rows.Count > 0)
            {

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = conn.CreateCommand();
            SqlDataReader rd = null;
            SqlTransaction TransactionControl = null;
            SqlParameter shipperIdParam = null;
            Queue<object> MS_Queue = new Queue<object>();
            string Sql = "";
            string CreditcardCode = "";
            int Xid = 0;

            cls_Global_DB.ConnectDatabase(ref conn);

            try
            {
                if (Mode == 0)
                {
                CreditcardCode = Tb.Rows[0]["CREDITCARD_CODE"].ToString();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT CREDITCARD_ID,CREDITCARD_CODE FROM M_CREDITCARDS WHERE CREDITCARD_CODE='" + CreditcardCode + "' And DELETED=0";
                cmd.Connection = conn;
                cmd.CommandTimeout = 30;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    return (_dsdata = null);
                }

                if (!rd.IsClosed) rd.Close();
                }
                foreach (DataRow row in Tb.Rows)
                {
                TransactionControl = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                if (Mode == 0)
                {
                    Sql = "Insert Into M_CREDITCARDS WITH (UPDLOCK) (BANK_ID,CREDITCARD_CODE,CREDITCARD_DESCRIPTION,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                        + " VALUES(@BANK_ID,@CREDITCARD_CODE,@CREDITCARD_DESCRIPTION,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)"
                        + " SET @ID=SCOPE_IDENTITY()";
                }
                else if (Mode == 1)
                {
                    Xid = cls_Library.DBInt(_Codeid);
                    Sql = "Update M_CREDITCARDS WITH (UPDLOCK) Set BANK_ID=@BANK_ID,CREDITCARD_CODE=@CREDITCARD_CODE,CREDITCARD_DESCRIPTION=@CREDITCARD_DESCRIPTION,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE"
                        + " Where CREDITCARD_ID=@CREDITCARD_ID";
                }
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sql;
                cmd.CommandTimeout = 30;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@BANK_ID", SqlDbType.Int).Value = row["BANK_ID"];
                cmd.Parameters.Add("@CREDITCARD_CODE", SqlDbType.NVarChar, 20).Value = row["CREDITCARD_CODE"];
                cmd.Parameters.Add("@CREDITCARD_DESCRIPTION", SqlDbType.NVarChar, 200).Value = row["CREDITCARD_DESCRIPTION"];
                if (Mode == 0)
                {
                    cmd.Parameters.Add("@CREATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                    DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
                    cmd.Parameters.Add("@CREATE_DATE", SqlDbType.DateTime).Value = DT;
                    cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@DELETED", SqlDbType.Bit).Value = 0;
                    cmd.Parameters.Add("@DELETE_BY", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@DELETE_DATE", SqlDbType.DateTime).Value = DBNull.Value;
                    shipperIdParam = new SqlParameter("@ID", SqlDbType.Int);
                    shipperIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(shipperIdParam);
                }
                if (Mode == 1)
                {
                    cmd.Parameters.Add("@CREDITCARD_ID", SqlDbType.Int).Value = Xid;
                    cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                    DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
                    cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
                }
                cmd.Transaction = TransactionControl;
                cmd.ExecuteNonQuery();


                if (Mode == 0)
                {
                    CreditcardID = (int)shipperIdParam.Value;
                }
                else if (Mode == 1)
                {
                    CreditcardID = Xid;
                }
                TransactionControl.Commit();
                }
            }
            catch (Exception ex)
            {
                TransactionControl.Rollback();
                XtraMessageBox.Show(ex.Message);
                CreditcardID = 0;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
                conn.Dispose();
                _Codeid = CreditcardID;
            }
            try
            {
                if (CreditcardID != 0)
                {
                int[] uid = { CreditcardID };
                DataTable dt = cls_Data.GetListCreditcardsByID(CreditcardID);
                _dsdata.Clear();
                _dsdata.Tables.Add(dt);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            }
            return _dsdata;
        }

        #endregion

        public frm_Creditcards_Record(cls_Struct.ActionMode mode)
        {
            InitializeComponent();
            _Mode = mode;

            this.KeyPreview = true;
            if (mode == cls_Struct.ActionMode.Edit)
            {
            TxtCreditCode.ReadOnly = true;
            TxtCreditCode.BackColor = Color.Yellow;
            }
        }

        private void BTcancel_Click(object sender, EventArgs e)
        {
            if (IsSaveOK)
            DialogResult = DialogResult.OK;
            else
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            SaveData(2);
      
        }

        private void BTreset_Click(object sender, EventArgs e)
        {
            searchLookUpCreditBank.EditValue = null;
            TxtBankName.Text = "";
            TxtCreditCode.Text = "";
            TxtCreditDesc.Text = "";
        }

        private void frM_CREDITCARDS_Record_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BTsave_Click(sender, e);
                    break;
                case Keys.F3:
                    BTsaveclose_Click(sender, e);
                    break;
                case Keys.F4:
                    BTreset_Click(sender, e);
                    break;
                case Keys.Escape:
                BTcancel_Click(sender, e);
                break;
            }
        }

        private void searchLookUpCreditBank_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
            TxtBankName.Text = cls_Data.GetNameFromTBname(id, "BANKS", "FULL_NAME");
            }
        }

        private void BTsaveclose_Click(object sender, EventArgs e)
        {
            SaveData(1);
        }
    }
}