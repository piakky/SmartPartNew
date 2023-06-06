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
  public partial class frm_ItemSpecials_Sub1_Record : DevExpress.XtraEditors.XtraForm
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
      cmd.CommandText = "SELECT SUB_ID,SUB_CODE FROM M_ITEMS_SPECIALS_SUB1 WHERE SUB_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((_Mode == cls_Struct.ActionMode.Edit) || (_Mode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["SUB_ID"]);
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
      _RowData["SUB_CODE"] = TxtItemCode.Text.Trim();
      _RowData["SUB_NAME"] = TxtItemName.Text.Trim();
      _RowData["SUB_DESCRIPTION"] = TxtItemDesc.Text.Trim();
      _RowData["ITEMS_SPECIAL_ID"] = cls_Library.DBInt(TxtItemSpecialID.Text.Trim());
      _RowData["ITEMS_SPECIAL_CODE"] = TxtItemSpecialCode.Text.Trim();
      _RowData["ITEMS_SPECIAL_NAME"] = TxtItemSpecialName.Text.Trim();
    }
    private void InitialListCode(int TypeCode)
    {
      try
      {
        frm_ListCodes frm;
        frm = new frm_ListCodes(TypeCode);
        frm.StartPosition = FormStartPosition.CenterParent;
        frm.Text = "รหัสสินค้าเฉพาะกลุ่ม";

        frm.MinimizeBox = false;
        frm.ShowInTaskbar = false;
        if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          int Xarr = frm.Prop_Arr;
          bool ok = false;
          if (Xarr > 0) ok = true;
          if (ok)
          {
            TxtItemSpecialID.Text = cls_Library.DBString(Xarr);
            TxtItemSpecialCode.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS", "ITEMS_SPECIAL_CODE");
            TxtItemSpecialName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS", "ITEMS_SPECIAL_NAME");
          }
        }
      }
      catch (Exception e)
      {
        this.Focus();
      }
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
        _getLastdata = SaveItemSpecialSub1(TB, SaveMode);
        _Mode = cls_Struct.ActionMode.Edit;
        ret = true;
      }
      catch (Exception ex)
      {
        Application.DoEvents();
        if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
        {
          TxtItemCode.ErrorText = "";
          TxtItemCode.Focus();
        }
        else
        {
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1ได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }
    public DataSet SaveItemSpecialSub1(DataTable Tb, int Mode)
    {
      DataSet _dsdata = new DataSet();
      int SubID = 0;
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
        string SubCode = "";
        int Xid = 0;

        cls_Global_DB.ConnectDatabase(ref conn);

        try
        {
          if (Mode == 0)
          {
            SubCode = cls_Data.GetLastCodeMaster("ITEMS_SPECIALS_SUB1", 3);
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT SUB_ID,SUB_CODE FROM M_ITEMS_SPECIALS_SUB1 WHERE SUB_CODE='" + SubCode + "' And DELETED=0";
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
              Sql = "Insert Into M_ITEMS_SPECIALS_SUB1 WITH (UPDLOCK) (SUB_CODE,SUB_NAME,SUB_DESCRIPTION,ITEMS_SPECIAL_ID,ITEMS_SPECIAL_CODE,ITEMS_SPECIAL_NAME,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                  + " VALUES(@SUB_CODE,@SUB_NAME,@SUB_DESCRIPTION,@ITEMS_SPECIAL_ID,@ITEMS_SPECIAL_CODE,@ITEMS_SPECIAL_NAME,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)"
                  + " SET @ID=SCOPE_IDENTITY()";
            }
            else if (Mode == 1)
            {
              Xid = cls_Library.DBInt(_Codeid);
              Sql = "Update M_ITEMS_SPECIALS_SUB1 WITH (UPDLOCK) Set SUB_CODE=@SUB_CODE,SUB_NAME=@SUB_NAME,SUB_DESCRIPTION=@SUB_DESCRIPTION,ITEMS_SPECIAL_ID=@ITEMS_SPECIAL_ID,ITEMS_SPECIAL_CODE=@ITEMS_SPECIAL_CODE,ITEMS_SPECIAL_NAME=@ITEMS_SPECIAL_NAME,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE"
                  + " Where SUB_ID=@SUB_ID";
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@SUB_CODE", SqlDbType.NVarChar, 3).Value = row["SUB_CODE"];
            cmd.Parameters.Add("@SUB_NAME", SqlDbType.NVarChar, 100).Value = row["SUB_NAME"];
            cmd.Parameters.Add("@SUB_DESCRIPTION", SqlDbType.NVarChar, 200).Value = row["SUB_DESCRIPTION"];
            cmd.Parameters.Add("@ITEMS_SPECIAL_ID", SqlDbType.Int).Value = row["ITEMS_SPECIAL_ID"];
            cmd.Parameters.Add("@ITEMS_SPECIAL_CODE", SqlDbType.NVarChar, 3).Value = row["ITEMS_SPECIAL_CODE"];
            cmd.Parameters.Add("@ITEMS_SPECIAL_NAME", SqlDbType.NVarChar, 100).Value = row["ITEMS_SPECIAL_NAME"];
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
              cmd.Parameters.Add("@SUB_ID", SqlDbType.Int).Value = Xid;
              cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
              DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
              cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
            }
            cmd.Transaction = TransactionControl;
            cmd.ExecuteNonQuery();


            if (Mode == 0)
            {
              SubID = (int)shipperIdParam.Value;
            }
            else if (Mode == 1)
            {
              SubID = Xid;
            }
            TransactionControl.Commit();
          }
        }
        catch (Exception ex)
        {
          TransactionControl.Rollback();
          XtraMessageBox.Show(ex.Message);
          SubID = 0;
        }
        finally
        {
          cls_Global_DB.CloseDB(ref conn);
          conn.Dispose();
          _Codeid = SubID;
        }
        try
        {
          if (SubID != 0)
          {
            int[] uid = { SubID };
            DataTable dt = cls_Data.GetListItemSpecialsSub1ByID(SubID);
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

    public frm_ItemSpecials_Sub1_Record(cls_Struct.ActionMode mode)
    {
      InitializeComponent();
      _Mode = mode;

      this.KeyPreview = true;
      TxtItemCode.ReadOnly = true;
      TxtItemCode.BackColor = Color.Yellow;
      TxtItemSpecialCode.ReadOnly = true;
      TxtItemSpecialCode.BackColor = Color.Yellow;
      TxtItemSpecialName.ReadOnly = true;
      TxtItemSpecialName.BackColor = Color.Yellow;
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

      if (TxtItemCode.EditValue == null || TxtItemCode.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtItemCode.ErrorText = "กรุณาระบุรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1";
        TxtItemCode.Focus();
        err = true;
      }
      else
      {
        if (CheckCodeExist(TxtItemCode.Text.Trim()))
        {
          XtraMessageBox.Show("มีรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1 นี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtItemCode.ErrorText = "มีรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1 นี้ในฐานข้อมูลแล้ว";
          TxtItemCode.Focus();
          err = true;
        }

      }

      if (!err)
      {
        if (TxtItemName.EditValue == null || TxtItemName.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุชื่อกลุ่มสินค้าหลัก", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtItemName.ErrorText = "กรุณาระบุชื่อกลุ่มสินค้าหลัก";
          TxtItemName.Focus();
          err = true;
        }
      }

      if (err)
      {
        return;
      }

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1 : " + TxtItemCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1 เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
          XtraMessageBox.Show("บันทึกรหัสสินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1 ไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
      TxtItemName.Text = "";
      TxtItemDesc.Text = "";
    }

    private void frm_ItemSpecials_Sub1_Record_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F1:
          BTlist_Click(sender, e);
          break;
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

    private void BTlist_Click(object sender, EventArgs e)
    {
      InitialListCode(6);
    }
  }
}