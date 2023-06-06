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
  public partial class frm_BankAccount_Record : DevExpress.XtraEditors.XtraForm
  {
    #region "  Variables declaration  "

    private DataSet _getLastdata = null;
    private DataRow _RowData = null;

    cls_Struct.ActionMode _Mode = 0;
    private int _Codeid = 0;
    private string _BankCode = "";
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

    public string Prop_BankCode
    {
      get { return _BankCode; }
      set { _BankCode = value; }
    }
    #endregion

    #region "  Function  "
    private bool CheckCodeExist(int Xbank,string Xcode)
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
      cmd.CommandText = "SELECT BANKS_ACCOUNT_ID FROM M_BANKS_ACCOUNTS WHERE BANK_ID=" + Xbank + " and BANKS_ACCOUNT_CODE ='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((_Mode == cls_Struct.ActionMode.Edit) || (_Mode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["BANKS_ACCOUNT_ID"]);
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
      _RowData["BANK_ID"] = cls_Library.DBInt(sluBank.EditValue);
      _RowData["ABBREVIATE_NAME"] = sluBank.Text.Trim();
      _RowData["FULL_NAME"] = TxtBankName.Text.Trim();
      _RowData["BANKS_ACCOUNT_BRANCH"] = TxtBankBranch.Text.Trim();
      _RowData["BANKS_ACCOUNT_CODE"] = TxtBankAccCode.Text.Trim();
      _RowData["BANKS_ACCOUNT_NAME"] = TxtBankAccName.Text.Trim();
      _RowData["BANKS_ACCOUNT_TYPE"] = radioType.SelectedIndex + 1;
      _RowData["BANKS_ACCOUNT_NOTE"] = TxtBankNote.Text.Trim();
    }
    private bool SaveData()
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
        _getLastdata = SaveBankAccount(TB, SaveMode);
        _Mode = cls_Struct.ActionMode.Edit;
        ret = true;
      }
      catch (Exception ex)
      {
        Application.DoEvents();
        if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
        {
          TxtBankAccCode.ErrorText = "";
          TxtBankAccCode.Focus();
        }
        else
        {
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสธนาคารได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }
    public DataSet SaveBankAccount(DataTable Tb, int Mode)
    {
      DataSet _dsdata = new DataSet();
      int BankID = 0;
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
        string BankCode = "";
        int Xid = 0;

        cls_Global_DB.ConnectDatabase(ref conn);

        try
        {
          if (Mode == 0)
          {
            BankCode = cls_Library.DBString(Tb.Rows[0]["ABBREVIATE_NAME"]);
            BankID = cls_Library.DBInt(Tb.Rows[0]["BANK_ID"]);
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT BANKS_ACCOUNT_ID FROM M_BANKS_ACCOUNTS WHERE BANK_ID=" + BankID + " and BANKS_ACCOUNT_CODE ='" + BankCode + "' And DELETED=0";
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
          BankID = 0;
          foreach (DataRow row in Tb.Rows)
          {
            TransactionControl = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            if (Mode == 0)
            {
              Sql = "Insert Into M_BANKS_ACCOUNTS WITH (UPDLOCK) (BANK_ID,ABBREVIATE_NAME,FULL_NAME,BANKS_ACCOUNT_BRANCH,BANKS_ACCOUNT_CODE,BANKS_ACCOUNT_NAME,BANKS_ACCOUNT_TYPE,BANKS_ACCOUNT_NOTE,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                  + " VALUES(@BANK_ID,@ABBREVIATE_NAME,@FULL_NAME,@BANKS_ACCOUNT_BRANCH,@BANKS_ACCOUNT_CODE,@BANKS_ACCOUNT_NAME,@BANKS_ACCOUNT_TYPE,@BANKS_ACCOUNT_NOTE,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)"
                  + " SET @ID=SCOPE_IDENTITY()";
            }
            else if (Mode == 1)
            {
              Xid = cls_Library.DBInt(row["BANKS_ACCOUNT_ID"]);
              Sql = "Update M_BANKS_ACCOUNTS WITH (UPDLOCK) Set BANK_ID=@BANK_ID,ABBREVIATE_NAME=@ABBREVIATE_NAME,FULL_NAME=@FULL_NAME,BANKS_ACCOUNT_BRANCH=@BANKS_ACCOUNT_BRANCH,BANKS_ACCOUNT_CODE=@BANKS_ACCOUNT_CODE,BANKS_ACCOUNT_NAME=@BANKS_ACCOUNT_NAME,"
                  + "BANKS_ACCOUNT_TYPE=@BANKS_ACCOUNT_TYPE,BANKS_ACCOUNT_NOTE=@BANKS_ACCOUNT_NOTE,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE"
                  + " Where BANKS_ACCOUNT_ID=@BANKS_ACCOUNT_ID";
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BANK_ID", SqlDbType.Int).Value = row["BANK_ID"];
            cmd.Parameters.Add("@ABBREVIATE_NAME", SqlDbType.NVarChar, 4).Value = row["ABBREVIATE_NAME"];
            cmd.Parameters.Add("@FULL_NAME", SqlDbType.NVarChar, 50).Value = row["FULL_NAME"];
            cmd.Parameters.Add("@BANKS_ACCOUNT_BRANCH", SqlDbType.NVarChar, 50).Value = row["BANKS_ACCOUNT_BRANCH"];
            cmd.Parameters.Add("@BANKS_ACCOUNT_CODE", SqlDbType.NVarChar, 50).Value = row["BANKS_ACCOUNT_CODE"];
            cmd.Parameters.Add("@BANKS_ACCOUNT_NAME", SqlDbType.NVarChar, 50).Value = row["BANKS_ACCOUNT_NAME"];
            cmd.Parameters.Add("@BANKS_ACCOUNT_TYPE", SqlDbType.TinyInt).Value = row["BANKS_ACCOUNT_TYPE"];
            cmd.Parameters.Add("@BANKS_ACCOUNT_NOTE", SqlDbType.NVarChar, 50).Value = row["BANKS_ACCOUNT_NOTE"];
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
              cmd.Parameters.Add("@BANKS_ACCOUNT_ID", SqlDbType.Int).Value = Xid;
              cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
              DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
              cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
            }
            cmd.Transaction = TransactionControl;
            cmd.ExecuteNonQuery();


            if (Mode == 0)
            {
              BankID = (int)shipperIdParam.Value;
            }
            else if (Mode == 1)
            {
              BankID = Xid;
            }
            TransactionControl.Commit();
          }
        }
        catch (Exception ex)
        {
          TransactionControl.Rollback();
          XtraMessageBox.Show(ex.Message);
          BankID = 0;
        }
        finally
        {
          cls_Global_DB.CloseDB(ref conn);
          conn.Dispose();
          _Codeid = BankID;
          _BankCode = TxtBankAccCode.Text.Trim();
        }
        try
        {
          //_BankCode = TxtBankAccCode.Text.Trim();
          if (BankID != 0)
          {
            int[] uid = { BankID };
            DataTable dt = cls_Data.GetListBanksAccountByID(BankID);
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

    public frm_BankAccount_Record(cls_Struct.ActionMode mode)
    {
      InitializeComponent();
      _Mode = mode;

      this.KeyPreview = true;
      if (mode == cls_Struct.ActionMode.Edit)
      {
        TxtBankAccCode.ReadOnly = true;
        TxtBankAccCode.BackColor = Color.Yellow;
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
      bool err = false;

      if ((sluBank.EditValue == null) || (sluBank.Text == "เลือกรหัสธนาคาร"))
      {
        XtraMessageBox.Show("กรุณาระบุรหัสธนาคาร", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        sluBank.ErrorText = "กรุณาระบุรหัสธนาคาร";
        sluBank.Focus();
        err = true;
      }

      if (!err)
      {
        if (TxtBankAccCode.EditValue == null || TxtBankAccCode.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุเลขที่บัญชี", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtBankAccCode.ErrorText = "กรุณาระบุเลขที่บัญชี";
          TxtBankAccCode.Focus();
          err = true;
        }
        else
        {
          if (CheckCodeExist(cls_Library.DBInt(sluBank.EditValue), TxtBankAccCode.Text.Trim()))
          {
            XtraMessageBox.Show("มีเลขที่บัญชี " + TxtBankAccCode.Text.Trim() + " ธนาคาร " + sluBank.Text + " นี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TxtBankAccCode.ErrorText = "มีเลขที่บัญชี " + TxtBankAccCode.Text.Trim() + " ธนาคาร " + sluBank.Text + " นี้ในฐานข้อมูลแล้ว";
            TxtBankAccCode.Focus();
            err = true;
          }

        }
      }
      

      if (err)
      {
        return;
      }

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสบัญชีเงินฝากธนาคาร : " + TxtBankAccCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสบัญชีเงินฝากธนาคารเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
          IsSaveOK = true;
          if (((SimpleButton)sender).Tag.ToString() == "1")
          {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
          }
        }
        else
        {
          IsSaveOK = false;
          XtraMessageBox.Show("บันทึกบัญชีเงินฝากธนาคารไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
      TxtBankAccCode.Text = "";
      TxtBankName.Text = "";
    }

    private void frm_Models_Record_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F2:
          BTsave_Click(sender, e);
          break;
        case Keys.F3:
          BTreset_Click(sender, e);
          break;
        case Keys.Escape:
          BTcancel_Click(sender, e);
          break;
      }
    }

    private void sluBank_EditValueChanged(object sender, EventArgs e)
    {
      SearchLookUpEdit item = (SearchLookUpEdit)sender;
      int id = Convert.ToInt32(item.EditValue);
      if (id > 0)
      {
        TxtBankName.Text = cls_Data.GetNameFromTBname(id, "BANKS", "FULL_NAME");
      }
    }
  }
}