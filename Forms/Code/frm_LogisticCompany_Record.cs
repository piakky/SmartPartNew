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
  public partial class frm_LogisticCompany_Record : DevExpress.XtraEditors.XtraForm
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
      cmd.CommandText = "SELECT LOGISTIC_ID,LOGISTIC_CODE FROM M_LOGISTIC_COMPANIES WHERE LOGISTIC_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((_Mode == cls_Struct.ActionMode.Edit) || (_Mode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["LOGISTIC_ID"]);
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
      _RowData["LOGISTIC_CODE"] = TxtLogisticCode.Text.Trim();
      _RowData["LOGISTIC_NAME"] = TxtLogisticName.Text.Trim();
      _RowData["LOGISTIC_DESCRIPTION"] = TxtLogisticDesc.Text.Trim();
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
        _getLastdata = SaveLogistic(TB, SaveMode);
        _Mode = cls_Struct.ActionMode.Edit;
        ret = true;
      }
      catch (Exception ex)
      {
        Application.DoEvents();
        if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
        {
          TxtLogisticCode.ErrorText = "";
          TxtLogisticCode.Focus();
        }
        else
        {
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสบริษัทขนส่งสินค้าได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }
    public DataSet SaveLogistic(DataTable Tb, int Mode)
    {
      DataSet _dsdata = new DataSet();
      int LogisticID = 0;
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
        string LogisticCode = "";
        int Xid = 0;

        cls_Global_DB.ConnectDatabase(ref conn);

        try
        {
          if (Mode == 0)
          {
            LogisticCode = cls_Data.GetLastCodeMaster("LOGISTIC", 2);
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT LOGISTIC_ID,LOGISTIC_CODE FROM M_LOGISTIC_COMPANIES WHERE LOGISTIC_CODE='" + LogisticCode + "' And DELETED=0";
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
              Sql = "Insert Into M_LOGISTIC_COMPANIES WITH (UPDLOCK) (LOGISTIC_CODE,LOGISTIC_NAME,LOGISTIC_DESCRIPTION,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                  + " VALUES(@LOGISTIC_CODE,@LOGISTIC_NAME,@LOGISTIC_DESCRIPTION,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)"
                  + " SET @ID=SCOPE_IDENTITY()";
            }
            else if (Mode == 1)
            {
              Xid = cls_Library.DBInt(_Codeid);
              Sql = "Update M_LOGISTIC_COMPANIES WITH (UPDLOCK) Set LOGISTIC_CODE=@LOGISTIC_CODE,LOGISTIC_NAME=@LOGISTIC_NAME,LOGISTIC_DESCRIPTION=@LOGISTIC_DESCRIPTION,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE"
                  + " Where LOGISTIC_ID=@LOGISTIC_ID";
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@LOGISTIC_CODE", SqlDbType.NVarChar, 2).Value = row["LOGISTIC_CODE"];
            cmd.Parameters.Add("@LOGISTIC_NAME", SqlDbType.NVarChar, 100).Value = row["LOGISTIC_NAME"];
            cmd.Parameters.Add("@LOGISTIC_DESCRIPTION", SqlDbType.NVarChar, 200).Value = row["LOGISTIC_DESCRIPTION"];
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
              cmd.Parameters.Add("@LOGISTIC_ID", SqlDbType.Int).Value = Xid;
              cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
              DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
              cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
            }
            cmd.Transaction = TransactionControl;
            cmd.ExecuteNonQuery();


            if (Mode == 0)
            {
              LogisticID = (int)shipperIdParam.Value;
            }
            else if (Mode == 1)
            {
              LogisticID = Xid;
            }
            TransactionControl.Commit();
          }
        }
        catch (Exception ex)
        {
          TransactionControl.Rollback();
          XtraMessageBox.Show(ex.Message);
          LogisticID = 0;
        }
        finally
        {
          cls_Global_DB.CloseDB(ref conn);
          conn.Dispose();
          _Codeid = LogisticID;
        }
        try
        {
          if (LogisticID != 0)
          {
            int[] uid = { LogisticID };
            DataTable dt = cls_Data.GetListLogisticCompanyByID(LogisticID);
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

    public frm_LogisticCompany_Record(cls_Struct.ActionMode mode)
    {
      InitializeComponent();
      _Mode = mode;

      this.KeyPreview = true;
      TxtLogisticCode.ReadOnly = true;
      TxtLogisticCode.BackColor = Color.Yellow;
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

      if (TxtLogisticCode.EditValue == null || TxtLogisticCode.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุรหัสบริษัทขนส่งสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtLogisticCode.ErrorText = "กรุณาระบุรหัสบริษัทขนส่งสินค้า";
        TxtLogisticCode.Focus();
        err = true;
      }
      else
      {
        if (CheckCodeExist(TxtLogisticCode.Text.Trim()))
        {
          XtraMessageBox.Show("มีรหัสบริษัทขนส่งสินค้านี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtLogisticCode.ErrorText = "มีรหัสบริษัทขนส่งสินค้านี้ในฐานข้อมูลแล้ว";
          TxtLogisticCode.Focus();
          err = true;
        }

      }

      if (!err)
      {
        if (TxtLogisticName.EditValue == null || TxtLogisticName.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุชื่อบริษัทขนส่งสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtLogisticName.ErrorText = "กรุณาระบุชื่อบริษัทขนส่งสินค้า";
          TxtLogisticName.Focus();
          err = true;
        }
      }

      if (err)
      {
        return;
      }

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสบริษัทขนส่งสินค้า : " + TxtLogisticCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสบริษัทขนส่งสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
          XtraMessageBox.Show("บันทึกรหัสบริษัทขนส่งสินค้าไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
      TxtLogisticName.Text = "";
      TxtLogisticDesc.Text = "";
    }

    private void frm_Categories_Record_KeyDown(object sender, KeyEventArgs e)
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