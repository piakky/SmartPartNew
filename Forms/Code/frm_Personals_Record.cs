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
  public partial class frm_Personals_Record : DevExpress.XtraEditors.XtraForm
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
      cmd.CommandText = "SELECT PERSONAL_ID,PERSONAL_CODE FROM M_PERSONALS WHERE PERSONAL_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((_Mode == cls_Struct.ActionMode.Edit) || (_Mode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["PERSONAL_ID"]);
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
      _RowData["PERSONAL_CODE"] = TxtPersonalCode.Text.Trim();
      _RowData["PERSONAL_NAME"] = TxtPersonalName.Text.Trim();
      _RowData["PERSONAL_DESCRIPTION1"] = TxtEPersonalDesc1.Text.Trim();
      _RowData["PERSONAL_DESCRIPTION2"] = TxtEPersonalDesc2.Text.Trim();
      _RowData["PERSONAL_DESCRIPTION3"] = TxtEPersonalDesc3.Text.Trim();
      _RowData["PERSONAL_NOTE"] = TxtEPersonalNote.Text.Trim();
      _RowData["PERSONAL_EMAIL"] = TxtEPersonalEmail.Text.Trim();
      _RowData["PERSONAL_FIRSTDATE"] = cls_Library.DBDateTime(dateFirstDate.EditValue);
      _RowData["PERSONAL_LASTDATE"] = cls_Library.DBDateTime(dateLastDate.EditValue);
      _RowData["PERSONAL_ADDRESS1"] = TxtEPersonalAddress1.Text.Trim();
      _RowData["PERSONAL_ADDRESS2"] = TxtEPersonalAddress2.Text.Trim();
      _RowData["PERSONAL_ADDRESS3"] = TxtEPersonalAddress3.Text.Trim();
      _RowData["PERSONAL_ADDRESS4"] = TxtEPersonalAddress4.Text.Trim();
      _RowData["PERSONAL_PLACE"] = TxtEPersonalPlace.Text.Trim();
      _RowData["PERSONAL_TAX"] = TxtEPersonalTax.Text.Trim();
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
        _getLastdata = SavePersonal(TB, SaveMode);
        _Mode = cls_Struct.ActionMode.Edit;
        ret = true;
      }
      catch (Exception ex)
      {
        Application.DoEvents();
        if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
        {
          TxtPersonalCode.ErrorText = "";
          TxtPersonalCode.Focus();
        }
        else
        {
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสผู้ติดต่อได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }
    public DataSet SavePersonal(DataTable Tb, int Mode)
    {
      DataSet _dsdata = new DataSet();
      int PersonalID = 0;
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
        string JobTypeCode = "";
        int Xid = 0;

        cls_Global_DB.ConnectDatabase(ref conn);

        try
        {
          if (Mode == 0)
          {
            JobTypeCode = Tb.Rows[0]["PERSONAL_CODE"].ToString();
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT PERSONAL_ID,PERSONAL_CODE FROM M_PERSONALS WHERE PERSONAL_CODE='" + JobTypeCode + "' And DELETED=0";
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
              Sql = "Insert Into M_PERSONALS WITH (UPDLOCK) (PERSONAL_CODE,PERSONAL_NAME,PERSONAL_DESCRIPTION1,PERSONAL_DESCRIPTION2,PERSONAL_DESCRIPTION3,"
                  + "PERSONAL_NOTE,PERSONAL_EMAIL,PERSONAL_FIRSTDATE,PERSONAL_LASTDATE,PERSONAL_ADDRESS1,PERSONAL_ADDRESS2,PERSONAL_ADDRESS3,PERSONAL_ADDRESS4,"
                  + "PERSONAL_PLACE,PERSONAL_TAX,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                  + " VALUES(@PERSONAL_CODE,@PERSONAL_NAME,@PERSONAL_DESCRIPTION1,@PERSONAL_DESCRIPTION2,@PERSONAL_DESCRIPTION3,"
                  + "@PERSONAL_NOTE,@PERSONAL_EMAIL,@PERSONAL_FIRSTDATE,@PERSONAL_LASTDATE,@PERSONAL_ADDRESS1,@PERSONAL_ADDRESS2,@PERSONAL_ADDRESS3,@PERSONAL_ADDRESS4,"
                  + "@PERSONAL_PLACE,@PERSONAL_TAX,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)"
                  + " SET @ID=SCOPE_IDENTITY()";
            }
            else if (Mode == 1)
            {
              Xid = cls_Library.DBInt(_Codeid);
              Sql = "Update M_PERSONALS WITH (UPDLOCK) Set PERSONAL_CODE=@PERSONAL_CODE,PERSONAL_NAME=@PERSONAL_NAME,PERSONAL_DESCRIPTION1=@PERSONAL_DESCRIPTION1,"
                  + "PERSONAL_DESCRIPTION2=@PERSONAL_DESCRIPTION2,PERSONAL_DESCRIPTION3=@PERSONAL_DESCRIPTION3,PERSONAL_NOTE=@PERSONAL_NOTE,PERSONAL_EMAIL=@PERSONAL_EMAIL,"
                  + "PERSONAL_FIRSTDATE=@PERSONAL_FIRSTDATE,PERSONAL_LASTDATE=@PERSONAL_LASTDATE,PERSONAL_ADDRESS1=@PERSONAL_ADDRESS1,PERSONAL_ADDRESS2=@PERSONAL_ADDRESS2,"
                  + "PERSONAL_ADDRESS3=@PERSONAL_ADDRESS3,PERSONAL_ADDRESS4=@PERSONAL_ADDRESS4,PERSONAL_PLACE=@PERSONAL_PLACE,PERSONAL_TAX=@PERSONAL_TAX,"
                  + "UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE"
                  + " Where PERSONAL_ID=@PERSONAL_ID";
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@PERSONAL_CODE", SqlDbType.VarChar, 4).Value = row["PERSONAL_CODE"];
            cmd.Parameters.Add("@PERSONAL_NAME", SqlDbType.NVarChar, 100).Value = row["PERSONAL_NAME"];
            cmd.Parameters.Add("@PERSONAL_DESCRIPTION1", SqlDbType.NVarChar, 200).Value = row["PERSONAL_DESCRIPTION1"];
            cmd.Parameters.Add("@PERSONAL_DESCRIPTION2", SqlDbType.NVarChar, 200).Value = row["PERSONAL_DESCRIPTION2"];
            cmd.Parameters.Add("@PERSONAL_DESCRIPTION3", SqlDbType.NVarChar, 200).Value = row["PERSONAL_DESCRIPTION3"];
            cmd.Parameters.Add("@PERSONAL_NOTE", SqlDbType.NVarChar, 200).Value = row["PERSONAL_NOTE"];
            cmd.Parameters.Add("@PERSONAL_EMAIL", SqlDbType.NVarChar, 100).Value = row["PERSONAL_EMAIL"];
            if ((cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]) == DateTime.MaxValue))
            {
              cmd.Parameters.Add("@PERSONAL_FIRSTDATE", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
              cmd.Parameters.Add("@PERSONAL_FIRSTDATE", SqlDbType.DateTime).Value = cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]);
            }
            if ((cls_Library.DBDateTime(row["PERSONAL_LASTDATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["PERSONAL_LASTDATE"]) == DateTime.MaxValue))
            {
              cmd.Parameters.Add("@PERSONAL_LASTDATE", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
              cmd.Parameters.Add("@PERSONAL_LASTDATE", SqlDbType.DateTime).Value = cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]);
            }
            cmd.Parameters.Add("@PERSONAL_ADDRESS1", SqlDbType.NVarChar, 200).Value = row["PERSONAL_ADDRESS1"];
            cmd.Parameters.Add("@PERSONAL_ADDRESS2", SqlDbType.NVarChar, 200).Value = row["PERSONAL_ADDRESS2"];
            cmd.Parameters.Add("@PERSONAL_ADDRESS3", SqlDbType.NVarChar, 200).Value = row["PERSONAL_ADDRESS3"];
            cmd.Parameters.Add("@PERSONAL_ADDRESS4", SqlDbType.NVarChar, 200).Value = row["PERSONAL_ADDRESS4"];
            cmd.Parameters.Add("@PERSONAL_PLACE", SqlDbType.NVarChar, 100).Value = row["PERSONAL_PLACE"];
            cmd.Parameters.Add("@PERSONAL_TAX", SqlDbType.VarChar, 13).Value = row["PERSONAL_TAX"];
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
              cmd.Parameters.Add("@PERSONAL_ID", SqlDbType.Int).Value = Xid;
              cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
              DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
              cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
            }
            cmd.Transaction = TransactionControl;
            cmd.ExecuteNonQuery();


            if (Mode == 0)
            {
              PersonalID = (int)shipperIdParam.Value;
            }
            else if (Mode == 1)
            {
              PersonalID = Xid;
            }
            TransactionControl.Commit();
          }
        }
        catch (Exception ex)
        {
          TransactionControl.Rollback();
          XtraMessageBox.Show(ex.Message);
          PersonalID = 0;
        }
        finally
        {
          cls_Global_DB.CloseDB(ref conn);
          conn.Dispose();
          _Codeid = PersonalID;
        }
        try
        {
          if (PersonalID != 0)
          {
            int[] uid = { PersonalID };
            DataTable dt = cls_Data.GetListPersonalsByID(PersonalID);
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

    public frm_Personals_Record(cls_Struct.ActionMode mode)
    {
      InitializeComponent();
      _Mode = mode;

      this.KeyPreview = true;
      if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.View))
      {
        TxtPersonalCode.ReadOnly = true;
        TxtPersonalCode.BackColor = Color.Yellow;
      }
      if (mode == cls_Struct.ActionMode.View)
      {
        BTsave.Visible = false;
        BTsaveclose.Visible = false;
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

      if (TxtPersonalCode.EditValue == null || TxtPersonalCode.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุรหัสผู้ติดต่อ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtPersonalCode.ErrorText = "กรุณาระบุรหัสผู้ติดต่อ";
        TxtPersonalCode.Focus();
        err = true;
      }
      else
      {
        if (CheckCodeExist(TxtPersonalCode.Text.Trim()))
        {
          XtraMessageBox.Show("มีรหัสผู้ติดต่อนี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtPersonalCode.ErrorText = "มีรหัสผู้ติดต่อนี้ในฐานข้อมูลแล้ว";
          TxtPersonalCode.Focus();
          err = true;
        }

      }

      if (!err)
      {
        if (TxtPersonalName.EditValue == null || TxtPersonalName.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุชื่อผู้ติดต่อ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtPersonalName.ErrorText = "กรุณาระบุชื่อผู้ติดต่อ";
          TxtPersonalName.Focus();
          err = true;
        }
      }

      if (err)
      {
        return;
      }

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสผู้ติดต่อ : " + TxtPersonalCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสผู้ติดต่อเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
          XtraMessageBox.Show("บันทึกรหัสผู้ติดต่อไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
      TxtPersonalCode.Text = "";
      TxtPersonalName.Text = "";
      TxtEPersonalDesc1.Text = "";
    }

    private void frM_PERSONALS_Record_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F2:
          if (_Mode == cls_Struct.ActionMode.View) return;
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
  }
}