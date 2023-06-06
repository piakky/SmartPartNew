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
  public partial class frm_PriceList_Record : DevExpress.XtraEditors.XtraForm
  {
    #region "  Variables declaration  "

    private DataSet _getLastdata = null;
    private DataRow _RowData = null;

    cls_Struct.ActionMode _Mode = 0;
    private int _Codeid = 0;
    private DateTime _Date1 = DateTime.MinValue;
    private DateTime _Date2 = DateTime.MinValue;
    private DateTime _Date3 = DateTime.MinValue;
    private decimal _Price1 = 0;
    private decimal _Price2 = 0;
    private decimal _Price3 = 0;
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

    public decimal Prop_Price1
    {
      get { return _Price1; }
      set { _Price1 = value; }
    }

    public decimal Prop_Price2
    {
      get { return _Price2; }
      set { _Price2 = value; }
    }

    public decimal Prop_Price3
    {
      get { return _Price3; }
      set { _Price3 = value; }
    }

    public DateTime Prop_Date1
    {
      get { return _Date1; }
      set { _Date1 = value; }
    }

    public DateTime Prop_Date2
    {
      get { return _Date2; }
      set { _Date2 = value; }
    }

    public DateTime Prop_Date3
    {
      get { return _Date3; }
      set { _Date3 = value; }
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
      cmd.CommandText = "SELECT PRICELIST_ID,BRAND_PART_ID FROM M_PRICELIST WHERE BRAND_PART_ID='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((_Mode == cls_Struct.ActionMode.Edit) || (_Mode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["PRICELIST_ID"]);
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
      _RowData["ITEM_ID"] = searchLookUpProduct.EditValue;
      _RowData["BRAND_PART_ID"] = txtProducerPart.Text.Trim();
      _RowData["GENUIN_PART_ID"] = txtGenuinPart.Text.Trim();
      _RowData["FULL_NAME"] = TxtFullname.Text.Trim();
      _RowData["MODEL"] = TxtModel.Text.Trim();
      _RowData["NEW_PRICE"] = cls_Library.DBDecimal(spinPrice.EditValue);
      _RowData["NEW_DATE"] = datePrice.DateTime;
      if (_Mode == cls_Struct.ActionMode.Add)
      {
        _Price1 = cls_Library.DBDecimal(spinPrice.EditValue);
        _Date1 = datePrice.DateTime;
        _Price2 = 0;
        _Date2 = DateTime.MinValue;
        _Price3 = 0;
        _Date3 = DateTime.MinValue;
      }
      if (_Mode == cls_Struct.ActionMode.Edit)
      {
        bool _pass = true;
        if (_Date2 != DateTime.MinValue)
        {
          _Price1 = _Price2;
          _Date1 = _Date2;
          _pass = true;
        }
        else
        {
          _pass = false;
          _Price2 = cls_Library.DBDecimal(spinPrice.EditValue);
          _Date2 = datePrice.DateTime;
        }
        if (_Date3 != DateTime.MinValue)
        {
          _Price2 = _Price3;
          _Date2 = _Date3;
          _Price3 = cls_Library.DBDecimal(spinPrice.EditValue);
          _Date3 = datePrice.DateTime;
        }
        else
        {
          if (_pass)
          {
            _Price3 = cls_Library.DBDecimal(spinPrice.EditValue);
            _Date3 = datePrice.DateTime;
          }
        }
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
        _getLastdata = SavePriceList(TB, SaveMode);
        _Mode = cls_Struct.ActionMode.Edit;
        ret = true;
      }
      catch (Exception ex)
      {
        Application.DoEvents();
        if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
        {
          txtProducerPart.ErrorText = "";
          txtProducerPart.Focus();
        }
        else
        {
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสหมวดหมู่สินค้าได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }
    public DataSet SavePriceList(DataTable Tb, int Mode)
    {
      DataSet _dsdata = new DataSet();
      int PriceListID = 0;
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
        //string CategoryCode = "";
        int Xid = 0;

        cls_Global_DB.ConnectDatabase(ref conn);

        try
        {
          //if (Mode == 0)
          //{
          //  CategoryCode = cls_Data.GetLastCodeMaster("CATEGORIES", 3);
          //  cmd = new SqlCommand();
          //  cmd.CommandText = "SELECT CATEGORY_ID,CATEGORY_CODE FROM M_CATEGORIES WHERE CATEGORY_CODE='" + CategoryCode + "' And DELETED=0";
          //  cmd.Connection = conn;
          //  cmd.CommandTimeout = 30;
          //  cmd.CommandType = CommandType.Text;
          //  rd = cmd.ExecuteReader();
          //  if (rd.HasRows)
          //  {
          //    return (_dsdata = null);
          //  }

          //  if (!rd.IsClosed) rd.Close();
          //}
          foreach (DataRow row in Tb.Rows)
          {
            TransactionControl = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            if (Mode == 0)
            {
              Sql = "Insert Into M_PRICELIST WITH (UPDLOCK) (ITEM_ID,GENUIN_PART_ID,BRAND_PART_ID,FULL_NAME,MODEL,NEW_PRICE,NEW_DATE,PRICE1,PRICE2,PRICE3,DATE1,DATE2,DATE3,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                  + " VALUES(@ITEM_ID,@GENUIN_PART_ID,@BRAND_PART_ID,@FULL_NAME,@MODEL,@NEW_PRICE,@NEW_DATE,@PRICE1,@PRICE2,@PRICE3,@DATE1,@DATE2,@DATE3,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)"
                  + " SET @ID=SCOPE_IDENTITY()";
            }
            else if (Mode == 1)
            {
              Xid = cls_Library.DBInt(_Codeid);
              Sql = "Update M_PRICELIST WITH (UPDLOCK) Set ITEM_ID=@ITEM_ID,BRAND_PART_ID=@BRAND_PART_ID,FULL_NAME=@FULL_NAME,MODEL=@MODEL,NEW_PRICE=@NEW_PRICE,NEW_DATE=@NEW_DATE,"
                  + "PRICE1=@PRICE1,PRICE2=@PRICE2,PRICE3=@PRICE3,DATE1=@DATE1,DATE2=@DATE2,DATE3=@DATE3,"
                  + "UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE"
                  + " Where PRICELIST_ID=@PRICELIST_ID and GENUIN_PART_ID=@GENUIN_PART_ID";
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = row["ITEM_ID"];
            cmd.Parameters.Add("@BRAND_PART_ID", SqlDbType.NVarChar, 50).Value = row["BRAND_PART_ID"];
            cmd.Parameters.Add("@GENUIN_PART_ID", SqlDbType.NVarChar, 50).Value = row["GENUIN_PART_ID"];
            cmd.Parameters.Add("@FULL_NAME", SqlDbType.NVarChar, 100).Value = row["FULL_NAME"];
            cmd.Parameters.Add("@MODEL", SqlDbType.NVarChar, 50).Value = row["MODEL"];
            cmd.Parameters.Add("@NEW_PRICE", SqlDbType.Decimal).Value = row["NEW_PRICE"];
            DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(cls_Library.DBDateTime(row["NEW_DATE"])).ToShortDateString());
            cmd.Parameters.Add("@NEW_DATE", SqlDbType.DateTime).Value = DT;
            cmd.Parameters.Add("@PRICE1", SqlDbType.Decimal).Value = _Price1;
            cmd.Parameters.Add("@PRICE2", SqlDbType.Decimal).Value = _Price2;
            cmd.Parameters.Add("@PRICE3", SqlDbType.Decimal).Value = _Price3;
            if ((_Date1 == DateTime.MinValue) || (_Date1 == DateTime.MaxValue))
              cmd.Parameters.Add("@DATE1", SqlDbType.DateTime).Value = DBNull.Value;
            else
              cmd.Parameters.Add("@DATE1", SqlDbType.DateTime).Value = _Date1;
            if ((_Date2 == DateTime.MinValue) || (_Date2 == DateTime.MaxValue))
              cmd.Parameters.Add("@DATE2", SqlDbType.DateTime).Value = DBNull.Value;
            else
              cmd.Parameters.Add("@DATE2", SqlDbType.DateTime).Value = _Date2;
            if ((_Date3 == DateTime.MinValue) || (_Date3 == DateTime.MaxValue))
              cmd.Parameters.Add("@DATE3", SqlDbType.DateTime).Value = DBNull.Value;
            else
              cmd.Parameters.Add("@DATE3", SqlDbType.DateTime).Value = _Date3;
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
              cmd.Parameters.Add("@PRICELIST_ID", SqlDbType.Int).Value = Xid;
              cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
              DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
              cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
            }
            cmd.Transaction = TransactionControl;
            cmd.ExecuteNonQuery();


            if (Mode == 0)
            {
              PriceListID = (int)shipperIdParam.Value;
            }
            else if (Mode == 1)
            {
              PriceListID = Xid;
            }
            TransactionControl.Commit();
          }
        }
        catch (Exception ex)
        {
          TransactionControl.Rollback();
          XtraMessageBox.Show(ex.Message);
          PriceListID = 0;
        }
        finally
        {
          cls_Global_DB.CloseDB(ref conn);
          conn.Dispose();
          _Codeid = PriceListID;
        }
        try
        {
          if (PriceListID != 0)
          {
            int[] uid = { PriceListID };
            DataTable dt = cls_Data.GetListPriceListByID(PriceListID);
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

    public frm_PriceList_Record(cls_Struct.ActionMode mode)
    {
      InitializeComponent();
      _Mode = mode;

      this.KeyPreview = true;
      //txtProducerPart.ReadOnly = true;
      //txtProducerPart.BackColor = Color.Yellow;
      if (_Mode == cls_Struct.ActionMode.Edit)
      {
        txtProducerPart.ReadOnly = true;
        txtProducerPart.BackColor = Color.Yellow;
        txtGenuinPart.ReadOnly = true;
        txtGenuinPart.BackColor = Color.Yellow;
        searchLookUpProduct.ReadOnly = true;
        searchLookUpProduct.BackColor = Color.Yellow;
        TxtFullname.ReadOnly = true;
        TxtFullname.BackColor = Color.Yellow;
        TxtModel.ReadOnly = true;
        TxtModel.BackColor = Color.Yellow;
        datePrice.ReadOnly = true;
        datePrice.BackColor = Color.Yellow;
        spinPrice.Select();
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

      if (txtGenuinPart.EditValue == null || txtGenuinPart.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุหมายเลขอะไหล่ร้าน", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtGenuinPart.ErrorText = "กรุณาระบุหมายเลขอะไหล่ร้าน";
        txtGenuinPart.Focus();
        err = true;
      }
      else
      {
        if (CheckCodeExist(txtGenuinPart.Text.Trim()))
        {
          XtraMessageBox.Show("มีหมายเลขอะไหล่นี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          txtProducerPart.ErrorText = "มีหมายเลขอะไหล่นี้ในฐานข้อมูลแล้ว";
          txtProducerPart.Focus();
          err = true;
        }

      }

      if (!err)
      {
        if (spinPrice.EditValue == null || cls_Library.DBDecimal(spinPrice.EditValue) < 0)
        {
          XtraMessageBox.Show("กรุณาระบุราคา", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          spinPrice.ErrorText = "กรุณาระบุราคา";
          spinPrice.Focus();
          err = true;
        }
      }

      if (err)
      {
        return;
      }

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึก Price list หมายเลขอะไหล่ : " + txtGenuinPart.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึก Price list เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
          XtraMessageBox.Show("บันทึก Price list ไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
      searchLookUpProduct.EditValue = null;
      TxtCode.Text = "";
      TxtFullname.Text = "";
      TxtModel.Text = "";
      txtGenuinPart.Text = "";
      txtProducerPart.Text = "";
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

    private void searchLookUpProduct_EditValueChanged(object sender, EventArgs e)
    {
      SearchLookUpEdit item = (SearchLookUpEdit)sender;
      int id = Convert.ToInt32(item.EditValue);
      if (id > 0)
      {
        TxtCode.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "ITEM_CODE");
        TxtFullname.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "FULL_NAME");
        TxtModel.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "MODEL1");
        txtGenuinPart.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "GENUIN_PART_ID");
        txtProducerPart.Text = cls_Data.GetNameFromTBname(id, "ITEMS", "BRAND_PART_ID");
      }
    }
  }
}