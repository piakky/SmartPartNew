using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraGrid.Columns;
using SmartPart.Class;
using SmartPart.Forms.Code;

namespace SmartPart.Forms
{
  public partial class frm_ListContactCodes : DevExpress.XtraEditors.XtraForm
  {
    #region "  Variables declaration  "

    private DataSet _getLastdata = null;
    private DataRow _RowUser = null;
    private DataTable DTcondata = null;
    private DataTable DTcusdata = null;
    private DataTable DTvendata = null;

    private string MemberOld = String.Empty;
    private string _memberof = String.Empty;

    //--- Fixed length variables
    private int _Mode = 0;
    private int _Codeid = 0;
    private string _Cpath;
    private int PICid = 0;
    private string Gcode;
    bool OK = false;
    int rowarr;
    int Typeid = 0;

    #endregion

    #region "  Properties declaration  "

    public DataSet getLastdata
    {
      get
      {
        return _getLastdata;
      }
      set { _getLastdata = value;}
    }

    public DataRow Prop_RowUser
    {
      get { return _RowUser; }
      set { _RowUser = value; }
    }


    public int Prop_FreightCid
    {
      get { return _Codeid; }
      set { _Codeid = value; }
    }

    public int Prop_Picid
    {
      get { return PICid; }
      set { PICid = value; }
    }

    public string Prop_FreightCPath
    {
      get { return _Cpath; }
      set { _Cpath = value; }
    }

    public int Prop_Arr
    {
      get { return rowarr; }
      set { rowarr = value; }
    }

    public string MemberOf
    {
      set { _memberof = value; }
    }

    public bool PropOK
    {
      set { OK = value; }
    }
    #endregion

    public frm_ListContactCodes()
    {
      InitializeComponent();
      //InitControl();
      this.KeyPreview = true;
      //Gcode = Xcode;
      //CaldateF = cls_Global_class.GetDateCulture(DF);
      //CaldateT = cls_Global_class.GetDateCulture(DT);
      //Typeid = TypeCode;
      LoadData();

      //SetGrid();

      //gridADV.DataSource = DTdata;
      //gridADV.RefreshDataSource();
      //gridADV.Visible = true;
      txtFindContact.Select();
    }

    private void BTok_Click(object sender, EventArgs e)
    {
      //DataRow row = null;
      //row = gvADV.GetFocusedDataRow();
      //if (row == null)
      //{
      //  BTcancel_Click(sender, e);
      //  return;
      //}
      //rowarr = cls_Library.DBInt(row["_id"]);
      this.DialogResult = DialogResult.OK;
    }

    private void LoadData()
    {
      //SqlConnection cn = new SqlConnection();
      //SqlDataAdapter da = null;
      //DataTable dt;
      //string sql = string.Empty;
      //DateTime dateF = DateTime.Now.Date;

      //cls_Global_DB.ConnectDatabase(ref cn);

      //try
      //{
      //  switch (Typeid)
      //  {
      //    case 1:
      //      DTdata = new DataTable("M_ITEMS_SPECIALS_SUB2");
      //      DTdata = cls_Data.GetDataTable("M_ITEMS_SPECIALS_SUB2",0,Gcode);
      //      break;
      //    case 2:
      //      DTdata = new DataTable("M_ITEMS_SPECIALS_SUB1");
      //      DTdata = cls_Data.GetDataTable("M_ITEMS_SPECIALS_SUB1",0,Gcode);
      //      break;
      //    case 3:
      //    case 4:
      //    case 5:
      //      DTdata = new DataTable("M_ITEMS");
      //      DTdata = cls_Data.GetDataTable("M_ITEMS");
      //      break;
      //    case 6:
      //      DTdata = new DataTable("M_ITEMS_SPECIALS");
      //      DTdata = cls_Data.GetDataTable("M_ITEMS_SPECIALS");
      //      break;
      //    case 7:
      //      DTdata = new DataTable("M_ITEMS_SPECIALS_SUB1");
      //      DTdata = cls_Data.GetDataTable("M_ITEMS_SPECIALS_SUB1");
      //      break;
      //    case 8:
      //      DTdata = new DataTable("M_CATEGORIES");
      //      DTdata = cls_Data.GetDataTable("M_CATEGORIES");
      //      break;
      //  }
      //}
      //catch (Exception e)
      //{
      //  this.Focus();
      //}
      //finally
      //{
      //  cls_Global_DB.CloseDB(ref cn);
      //}
    }

    private void LoadDataCustomer()
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      DataTable dt;
      string sql = string.Empty;
      DateTime dateF = DateTime.Now.Date;

      if (txtFindCustomer.Text.Length == 0) return;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        sql = "select * from M_CUSTOMERS where CUSTOMER_CODE like '" + txtFindCustomer.Text.Trim() + "%' or CUSTOMER_NAME like '" + txtFindCustomer.Text.Trim() + "%'";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.CommandTimeout = 1200;
        DTcusdata = new DataTable("Customer");
        da.Fill(DTcusdata);

        gridCus.DataSource = DTcusdata;
        gridCus.RefreshDataSource();
        if (DTcusdata.Rows.Count > 0)
        {
          cardCus.Focus();
        }

      }
      catch (Exception e)
      {
        DTcondata = null;
        this.Focus();
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
    }

    private void LoadDataContact()
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      DataTable dt;
      string sql = string.Empty;
      DateTime dateF = DateTime.Now.Date;

      if (txtFindContact.Text.Length == 0) return;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        sql = "select * from M_PERSONALS where PERSONAL_CODE like '" + txtFindContact.Text.Trim() + "%' or PERSONAL_NAME like '" + txtFindContact.Text.Trim() + "%'";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.CommandTimeout = 1200;
        DTcondata = new DataTable("Contact");
        da.Fill(DTcondata);

        gridContact.DataSource = DTcondata;
        gridContact.RefreshDataSource();
        if (DTcondata.Rows.Count > 0)
        {
          cardContact.Focus();
        }

      }
      catch (Exception e)
      {
        DTcondata = null;
        this.Focus();
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
    }

    private void LoadDataVendor()
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      DataTable dt;
      string sql = string.Empty;
      DateTime dateF = DateTime.Now.Date;

      if (txtFindVendor.Text.Length == 0) return;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        sql = "select * from M_VENDORS where VENDOR_CODE like '" + txtFindVendor.Text.Trim() + "%' or VENDOR_NAME like '" + txtFindVendor.Text.Trim() + "%'";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.CommandTimeout = 1200;
        DTvendata = new DataTable("Vendor");
        da.Fill(DTvendata);

        gridVendor.DataSource = DTvendata;
        gridVendor.RefreshDataSource();

        if (DTvendata.Rows.Count > 0)
        {
          cardVendor.Focus();
        }

      }
      catch (Exception e)
      {
        DTcondata = null;
        this.Focus();
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
    }

    private void SetGrid()
    {
      //int i, NO = 0;
      try
      {
        //string Xcap = "";
        //switch (Typeid)
        //{
        //  case 1:
        //    Xcap = "กลุ่มย่อยระดับที่ 2";
        //    break;
        //  case 2:
        //    Xcap = "กลุ่มย่อยระดับที่ 1";
        //    break;
        //  case 3:
        //  case 4:
        //  case 5:
        //    Xcap = "สินค้า";
        //    break;
        //  case 8:
        //    Xcap = "หมวดหมู่สินค้า";
        //    break;
        //}
        //GridColumn V_id = cls_Form.AddGridColumn("_id", "id", "_id", false, 0, 100);
        //GridColumn V_Code = cls_Form.AddGridColumn("code", "รหัส" + Xcap, "code", true, 1, 100);
        //GridColumn V_Name = cls_Form.AddGridColumn("name", "ชื่อ"+ Xcap, "name", true, 2, 180);
        

        //gridADV.BeginInit();
        //gvADV.BeginInit();
        //gvADV.Columns.Clear();

        //V_id.Visible = false;

        //V_Code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //V_Code.AppearanceHeader.Options.UseTextOptions = true;
        //V_Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        //V_Code.AppearanceCell.Options.UseTextOptions = true;
        //V_Code.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        //V_Code.SummaryItem.DisplayFormat = "{0:#,##0}" + "   รายการ";

        //V_Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //V_Name.AppearanceHeader.Options.UseTextOptions = true;
        //V_Name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        //V_Name.AppearanceCell.Options.UseTextOptions = true;

        //gvADV.Columns.AddRange(new GridColumn[] { V_id, V_Code, V_Name});

        //gvADV.OptionsView.ShowGroupPanel = false;
        //gvADV.OptionsBehavior.Editable = false;
        //gvADV.OptionsSelection.EnableAppearanceFocusedCell = false;
        //gvADV.OptionsView.EnableAppearanceEvenRow = false;
        //gvADV.OptionsView.EnableAppearanceOddRow = true;
        //gvADV.IndicatorWidth = 50;

        //gvADV.OptionsView.RowAutoHeight = true;
        //gvADV.OptionsView.ShowAutoFilterRow = true;
        //gvADV.OptionsFind.ShowCloseButton = false;
        //gvADV.OptionsFind.AlwaysVisible = true;
        //gvADV.OptionsFind.ShowClearButton = false;
        //gvADV.OptionsView.ShowFooter = true;

        //gvADV.EndInit();
        //gridADV.EndInit();
      }
      catch (Exception e)
      {
        XtraMessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      //gvCodeCus.OptionsView.ShowViewCaption = true;
      //gridCodeCus.Visible = true;
    }

    private bool CheckCodeExist(string Xcode)
    {
      bool err = false;
      //string User = "";
      SqlConnection conn = new SqlConnection();
      SqlCommand cmd = conn.CreateCommand();
      SqlDataReader rd = null;
      int id = 0;

      cls_Global_DB.ConnectDatabase(ref conn);

      //User = TbUser.Rows[0]["Cus_Code"].ToString();
      err = false;
      cmd = new SqlCommand();
      cmd.CommandText = "SELECT FreightC_id,FreightC_Code FROM FreightCondition WHERE FreightC_Code='" + Xcode + "' And FreightC_Delete=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if (_Mode == 1)
        {
          rd.Read();
          id = Convert.ToInt32(rd["FreightC_id"]);
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

    byte[] ReadFile(string sPath)
    {
      //Initialize byte array with a null value initially.
      byte[] data = null;

      //Use FileInfo object to get file size.
      FileInfo fInfo = new FileInfo(sPath);
      long numBytes = fInfo.Length;

      //Open FileStream to read file
      FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

      //Use BinaryReader to read file stream into byte array.
      BinaryReader br = new BinaryReader(fStream);

      //When you use BinaryReader, you need to supply number of bytes to read from file.
      //In this case we want to read entire file. So supplying total number of bytes.
      data = br.ReadBytes((int)numBytes);
      return data;
    }

    private void BTcancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

   
    private void gvADV_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvADV_DoubleClick(object sender, EventArgs e)
    {
      BTok_Click(sender,e);
    }

    private void frm_ListCodes_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Escape:
          this.DialogResult = DialogResult.Cancel;
          this.Close();
          break;
      }
    }

    private void txtFindContact_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
      {
        BTfindcontact.PerformClick();
      }
    }

    private void BTfindcontact_Click(object sender, EventArgs e)
    {
      LoadDataContact();
    }

    private void txtFindCustomer_EditValueChanged(object sender, EventArgs e)
    {

    }

    private void txtFindCustomer_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
      {
        BTfindcustomer.PerformClick();
      }
    }

    private void BTfindcustomer_Click(object sender, EventArgs e)
    {
      LoadDataCustomer();
    }

    private void txtFindVendor_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
      {
        BTfindvendor.PerformClick();
      }
    }

    private void BTfindvendor_Click(object sender, EventArgs e)
    {
      LoadDataVendor();
    }

    private void xtraTabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
    {
      if (xtraTabMain.SelectedTabPageIndex == 0)
      {
        txtFindContact.Select();
      }
      if (xtraTabMain.SelectedTabPageIndex == 1)
      {
        txtFindCustomer.Select();
      }
      if (xtraTabMain.SelectedTabPageIndex == 2)
      {
        txtFindVendor.Select();
      }
    }

    private void frm_ListContactCodes_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Escape:
          this.Close();
          break;
        case Keys.F6:
          btEdit.PerformClick();
          break;
        case Keys.F12:
          btView.PerformClick();
          break;
      }
    }

    private void btEdit_Click(object sender, EventArgs e)
    {
      DataRow row;
      int pid = 0;

      switch (xtraTabMain.SelectedTabPageIndex)
      {
        case 0:
          frm_Personals_Record frmInput;
          frmInput = new frm_Personals_Record(cls_Struct.ActionMode.Edit);
          frmInput.StartPosition = FormStartPosition.CenterParent;

          row = cardContact.GetFocusedDataRow();

          if (row == null) return;
          pid = cls_Library.DBInt(row["PERSONAL_ID"].ToString());
          if (pid == 0) return;

          frmInput.Text = "บุคคลทั่วไป   [แก้ไขข้อมูล]";
          frmInput.Prop_Codeid = cls_Library.DBInt(row["PERSONAL_ID"]);
          frmInput.Prop_RowData = row;
          frmInput.TxtPersonalCode.Text = cls_Library.DBString(row["PERSONAL_CODE"]);
          frmInput.TxtPersonalName.Text = cls_Library.DBString(row["PERSONAL_NAME"]);
          frmInput.TxtEPersonalDesc1.Text = cls_Library.DBString(row["PERSONAL_DESCRIPTION1"]);
          frmInput.TxtEPersonalDesc2.Text = cls_Library.DBString(row["PERSONAL_DESCRIPTION2"]);
          frmInput.TxtEPersonalDesc3.Text = cls_Library.DBString(row["PERSONAL_DESCRIPTION3"]);
          frmInput.TxtEPersonalNote.Text = cls_Library.DBString(row["PERSONAL_NOTE"]);
          frmInput.TxtEPersonalEmail.Text = cls_Library.DBString(row["PERSONAL_EMAIL"]);
          if ((cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]) == DateTime.MaxValue))
          {
            frmInput.dateFirstDate.Text = "";
          }
          else
          {
            frmInput.dateFirstDate.DateTime = cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]);
          }
          if ((cls_Library.DBDateTime(row["PERSONAL_LASTDATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["PERSONAL_LASTDATE"]) == DateTime.MaxValue))
          {
            frmInput.dateLastDate.Text = "";
          }
          else
          {
            frmInput.dateLastDate.DateTime = cls_Library.DBDateTime(row["PERSONAL_LASTDATE"]);
          }
          frmInput.TxtEPersonalAddress1.Text = cls_Library.DBString(row["PERSONAL_ADDRESS1"]);
          frmInput.TxtEPersonalAddress2.Text = cls_Library.DBString(row["PERSONAL_ADDRESS2"]);
          frmInput.TxtEPersonalAddress3.Text = cls_Library.DBString(row["PERSONAL_ADDRESS3"]);
          frmInput.TxtEPersonalAddress4.Text = cls_Library.DBString(row["PERSONAL_ADDRESS4"]);
          frmInput.TxtEPersonalPlace.Text = cls_Library.DBString(row["PERSONAL_PLACE"]);
          frmInput.TxtEPersonalTax.Text = cls_Library.DBString(row["PERSONAL_TAX"]);

          frmInput.MinimizeBox = false;
          frmInput.ShowInTaskbar = false;
          break;
        case 1:
          row = cardCus.GetFocusedDataRow();
          if (row == null) return;
          pid = cls_Library.DBInt(row["CUSTOMER_ID"].ToString());
          if (pid == 0) return;

          frm_Vendors_Record frmcus = new frm_Vendors_Record(cls_Struct.ActionMode.Edit, pid);
          frmcus.ShowInTaskbar = false;
          frmcus.StartPosition = FormStartPosition.CenterParent;
          frmcus.Text = "รหัสลูกค้า   [แก้ไขข้อมูล]";
          if (frmcus.ShowDialog() == DialogResult.OK)
          {

          }
          break;
        case 2:
          row = cardVendor.GetFocusedDataRow();
          
          if (row == null) return;
          pid = cls_Library.DBInt(row["VENDOR_ID"].ToString());

          if (pid == 0) return;

          frm_Customers_Record frm = new frm_Customers_Record(cls_Struct.ActionMode.Edit, pid);
          frm.ShowInTaskbar = false;
          frm.StartPosition = FormStartPosition.CenterParent;
          frm.Text = "รหัสพ่อค้า   [แก้ไขข้อมูล]";
          if (frm.ShowDialog() == DialogResult.OK)
          {

          }
          break;
      }

    }

    private void btView_Click(object sender, EventArgs e)
    {
      DataRow row;
      int pid = 0;

      switch (xtraTabMain.SelectedTabPageIndex)
      {
        case 0:
          frm_Personals_Record frmInput;
          frmInput = new frm_Personals_Record(cls_Struct.ActionMode.View);
          frmInput.StartPosition = FormStartPosition.CenterParent;

          row = cardContact.GetFocusedDataRow();

          if (row == null) return;
          pid = cls_Library.DBInt(row["PERSONAL_ID"].ToString());

          frmInput.Text = "บุคคลทั่วไป   [ดูข้อมูล]";
          frmInput.Prop_Codeid = cls_Library.DBInt(row["PERSONAL_ID"]);
          frmInput.Prop_RowData = row;
          frmInput.TxtPersonalCode.Text = cls_Library.DBString(row["PERSONAL_CODE"]);
          frmInput.TxtPersonalName.Text = cls_Library.DBString(row["PERSONAL_NAME"]);
          frmInput.TxtEPersonalDesc1.Text = cls_Library.DBString(row["PERSONAL_DESCRIPTION1"]);
          frmInput.TxtEPersonalDesc2.Text = cls_Library.DBString(row["PERSONAL_DESCRIPTION2"]);
          frmInput.TxtEPersonalDesc3.Text = cls_Library.DBString(row["PERSONAL_DESCRIPTION3"]);
          frmInput.TxtEPersonalNote.Text = cls_Library.DBString(row["PERSONAL_NOTE"]);
          frmInput.TxtEPersonalEmail.Text = cls_Library.DBString(row["PERSONAL_EMAIL"]);
          if ((cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]) == DateTime.MaxValue))
          {
            frmInput.dateFirstDate.Text = "";
          }
          else
          {
            frmInput.dateFirstDate.DateTime = cls_Library.DBDateTime(row["PERSONAL_FIRSTDATE"]);
          }
          if ((cls_Library.DBDateTime(row["PERSONAL_LASTDATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["PERSONAL_LASTDATE"]) == DateTime.MaxValue))
          {
            frmInput.dateLastDate.Text = "";
          }
          else
          {
            frmInput.dateLastDate.DateTime = cls_Library.DBDateTime(row["PERSONAL_LASTDATE"]);
          }
          frmInput.TxtEPersonalAddress1.Text = cls_Library.DBString(row["PERSONAL_ADDRESS1"]);
          frmInput.TxtEPersonalAddress2.Text = cls_Library.DBString(row["PERSONAL_ADDRESS2"]);
          frmInput.TxtEPersonalAddress3.Text = cls_Library.DBString(row["PERSONAL_ADDRESS3"]);
          frmInput.TxtEPersonalAddress4.Text = cls_Library.DBString(row["PERSONAL_ADDRESS4"]);
          frmInput.TxtEPersonalPlace.Text = cls_Library.DBString(row["PERSONAL_PLACE"]);
          frmInput.TxtEPersonalTax.Text = cls_Library.DBString(row["PERSONAL_TAX"]);

          frmInput.MinimizeBox = false;
          frmInput.ShowInTaskbar = false;
          break;
        case 1:
          row = cardCus.GetFocusedDataRow();
          if (row == null) return;
          pid = cls_Library.DBInt(row["CUSTOMER_ID"].ToString());

          frm_Vendors_Record frmcus = new frm_Vendors_Record(cls_Struct.ActionMode.View, pid);
          frmcus.ShowInTaskbar = false;
          frmcus.StartPosition = FormStartPosition.CenterParent;
          frmcus.Text = "รหัสลูกค้า   [ดูข้อมูล]";
          if (frmcus.ShowDialog() == DialogResult.OK)
          {

          }
          break;
        case 2:
          row = cardVendor.GetFocusedDataRow();

          if (row == null) return;
          pid = cls_Library.DBInt(row["VENDOR_ID"].ToString());

          frm_Customers_Record frm = new frm_Customers_Record(cls_Struct.ActionMode.View, pid);
          frm.ShowInTaskbar = false;
          frm.StartPosition = FormStartPosition.CenterParent;
          frm.Text = "รหัสพ่อค้า   [ดูข้อมูล]";
          if (frm.ShowDialog() == DialogResult.OK)
          {

          }
          break;
      }
    }
  }
}