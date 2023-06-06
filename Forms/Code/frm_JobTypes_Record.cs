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
  public partial class frm_JobTypes_Record : DevExpress.XtraEditors.XtraForm
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
      cmd.CommandText = "SELECT JOB_TYPE_ID,JOB_TYPE_CODE FROM M_JOB_TYPES WHERE JOB_TYPE_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((_Mode == cls_Struct.ActionMode.Edit) || (_Mode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["JOB_TYPE_ID"]);
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
      _RowData["JOB_TYPE_CODE"] = TxtJobTypeCode.Text.Trim();
      _RowData["JOB_TYPE_NAME"] = TxtJobTypeName.Text.Trim();
      _RowData["JOB_TYPE_DESCRIPTION"] = TxtJobTypeDesc.Text.Trim();
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
        _getLastdata = SaveJobType(TB, SaveMode);
        _Mode = cls_Struct.ActionMode.Edit;
        ret = true;
      }
      catch (Exception ex)
      {
        Application.DoEvents();
        if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
        {
          TxtJobTypeCode.ErrorText = "";
          TxtJobTypeCode.Focus();
        }
        else
        {
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสงานได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }
    public DataSet SaveJobType(DataTable Tb, int Mode)
    {
      DataSet _dsdata = new DataSet();
      int JobTypeID = 0;
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
            JobTypeCode = cls_Data.GetLastCodeMaster("JOB_TYPES", 2);
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT JOB_TYPE_ID,JOB_TYPE_CODE FROM M_JOB_TYPES WHERE JOB_TYPE_CODE='" + JobTypeCode + "' And DELETED=0";
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
              Sql = "Insert Into M_JOB_TYPES WITH (UPDLOCK) (JOB_TYPE_CODE,JOB_TYPE_NAME,JOB_TYPE_DESCRIPTION,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                  + " VALUES(@JOB_TYPE_CODE,@JOB_TYPE_NAME,@JOB_TYPE_DESCRIPTION,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)"
                  + " SET @ID=SCOPE_IDENTITY()";
            }
            else if (Mode == 1)
            {
              Xid = cls_Library.DBInt(_Codeid);
              Sql = "Update M_JOB_TYPES WITH (UPDLOCK) Set JOB_TYPE_CODE=@JOB_TYPE_CODE,JOB_TYPE_NAME=@JOB_TYPE_NAME,JOB_TYPE_DESCRIPTION=@JOB_TYPE_DESCRIPTION,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE"
                  + " Where JOB_TYPE_ID=@JOB_TYPE_ID";
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@JOB_TYPE_CODE", SqlDbType.NVarChar, 2).Value = row["JOB_TYPE_CODE"];
            cmd.Parameters.Add("@JOB_TYPE_NAME", SqlDbType.NVarChar, 100).Value = row["JOB_TYPE_NAME"];
            cmd.Parameters.Add("@JOB_TYPE_DESCRIPTION", SqlDbType.NVarChar, 100).Value = row["JOB_TYPE_DESCRIPTION"];
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
              cmd.Parameters.Add("@JOB_TYPE_ID", SqlDbType.Int).Value = Xid;
              cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
              DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
              cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
            }
            cmd.Transaction = TransactionControl;
            cmd.ExecuteNonQuery();


            if (Mode == 0)
            {
              JobTypeID = (int)shipperIdParam.Value;
            }
            else if (Mode == 1)
            {
              JobTypeID = Xid;
            }
            TransactionControl.Commit();
          }
        }
        catch (Exception ex)
        {
          TransactionControl.Rollback();
          XtraMessageBox.Show(ex.Message);
          JobTypeID = 0;
        }
        finally
        {
          cls_Global_DB.CloseDB(ref conn);
          conn.Dispose();
          _Codeid = JobTypeID;
        }
        try
        {
          if (JobTypeID != 0)
          {
            int[] uid = { JobTypeID };
            DataTable dt = cls_Data.GetListJobTypesByID(JobTypeID);
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

    public frm_JobTypes_Record(cls_Struct.ActionMode mode)
    {
      InitializeComponent();
      _Mode = mode;

      this.KeyPreview = true;
      TxtJobTypeCode.ReadOnly = true;
      TxtJobTypeCode.BackColor = Color.Yellow;
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

      if (TxtJobTypeCode.EditValue == null || TxtJobTypeCode.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุรหัสงาน", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtJobTypeCode.ErrorText = "กรุณาระบุรหัสงาน";
        TxtJobTypeCode.Focus();
        err = true;
      }
      else
      {
        if (CheckCodeExist(TxtJobTypeCode.Text.Trim()))
        {
          XtraMessageBox.Show("มีรหัสงานนี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtJobTypeCode.ErrorText = "มีรหัสงานนี้ในฐานข้อมูลแล้ว";
          TxtJobTypeCode.Focus();
          err = true;
        }

      }

      if (!err)
      {
        if (TxtJobTypeName.EditValue == null || TxtJobTypeName.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุชื่องาน", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtJobTypeName.ErrorText = "กรุณาระบุชื่องาน";
          TxtJobTypeName.Focus();
          err = true;
        }
      }

      if (err)
      {
        return;
      }

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสงาน : " + TxtJobTypeCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสงานเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
          XtraMessageBox.Show("บันทึกรหัสงานไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
      TxtJobTypeName.Text = "";
      TxtJobTypeDesc.Text = "";
    }

    private void frM_JOB_TYPES_Record_KeyDown(object sender, KeyEventArgs e)
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
  }
}