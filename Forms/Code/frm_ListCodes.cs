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
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Controls;

namespace SmartPart.Forms
{
  public partial class frm_ListCodes : DevExpress.XtraEditors.XtraForm
  {
    #region "  Variables declaration  "

    private DataSet _getLastdata = null;
    private DataRow _RowUser = null;
    private DataTable DTdata = null;

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

    public DataTable PropDTdata
    {
      get { return DTdata; }
      set { DTdata = value; }
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

    public frm_ListCodes(int TypeCode,string Xcode = "")
    {
      InitializeComponent();
      //InitControl();
      this.KeyPreview = true;
      Gcode = Xcode;
      //CaldateF = cls_Global_class.GetDateCulture(DF);
      //CaldateT = cls_Global_class.GetDateCulture(DT);
      Typeid = TypeCode;
      LoadData();

      SetGrid();

      gridADV.DataSource = DTdata;
      gridADV.RefreshDataSource();
      gridADV.Visible = true;
    }

    private void BTok_Click(object sender, EventArgs e)
    {
      DataRow row = null;
      row = gvADV.GetFocusedDataRow();
      if (row == null)
      {
        BTcancel_Click(sender, e);
        return;
      }
      rowarr = cls_Library.DBInt(row["_id"]);
      this.DialogResult = DialogResult.OK;
    }

    private void LoadData()
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      DataTable dt;
      string sql = string.Empty;
      DateTime dateF = DateTime.Now.Date;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        switch (Typeid)
        {
          case 1:
            DTdata = new DataTable("M_ITEMS_SPECIALS_SUB2");
            DTdata = cls_Data.GetDataTable("M_ITEMS_SPECIALS_SUB2",0,Gcode);
            break;
          case 2:
            DTdata = new DataTable("M_ITEMS_SPECIALS_SUB1");
            DTdata = cls_Data.GetDataTable("M_ITEMS_SPECIALS_SUB1",0,Gcode);
            break;
          case 3:
          case 4:
          case 5:
            DTdata = new DataTable("M_ITEMS");
            DTdata = cls_Data.GetDataTable("M_ITEMS");
            break;
          case 6:
            DTdata = new DataTable("M_ITEMS_SPECIALS");
            DTdata = cls_Data.GetDataTable("M_ITEMS_SPECIALS");
            break;
          case 7:
            DTdata = new DataTable("M_ITEMS_SPECIALS_SUB1");
            DTdata = cls_Data.GetDataTable("M_ITEMS_SPECIALS_SUB1");
            break;
          case 8:
            DTdata = new DataTable("M_CATEGORIES");
            DTdata = cls_Data.GetDataTable("M_CATEGORIES");
            break;
        }
      }
      catch (Exception e)
      {
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
        string Xcap = "";
        switch (Typeid)
        {
          case 1:
            Xcap = "กลุ่มย่อยระดับที่ 2";
            break;
          case 2:
            Xcap = "กลุ่มย่อยระดับที่ 1";
            break;
          case 3:
          case 4:
          case 5:
            Xcap = "สินค้า";
            break;
          case 8:
            Xcap = "หมวดหมู่สินค้า";
            break;
        }
        GridColumn V_id = cls_Form.AddGridColumn("_id", "id", "_id", false, 0, 100);
        GridColumn V_Code = cls_Form.AddGridColumn("code", "รหัส" + Xcap, "code", true, 1, 100);
        GridColumn V_Name = cls_Form.AddGridColumn("name", "ชื่อ"+ Xcap, "name", true, 2, 180);
        

        gridADV.BeginInit();
        gvADV.BeginInit();
        gvADV.Columns.Clear();

        V_id.Visible = false;

        V_Code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        V_Code.AppearanceHeader.Options.UseTextOptions = true;
        V_Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        V_Code.AppearanceCell.Options.UseTextOptions = true;
        V_Code.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        V_Code.SummaryItem.DisplayFormat = "{0:#,##0}" + "   รายการ";

        V_Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        V_Name.AppearanceHeader.Options.UseTextOptions = true;
        V_Name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        V_Name.AppearanceCell.Options.UseTextOptions = true;

        gvADV.Columns.AddRange(new GridColumn[] { V_id, V_Code, V_Name});

        gvADV.OptionsView.ShowGroupPanel = false;
        gvADV.OptionsBehavior.Editable = false;
        gvADV.OptionsSelection.EnableAppearanceFocusedCell = false;
        gvADV.OptionsView.EnableAppearanceEvenRow = false;
        gvADV.OptionsView.EnableAppearanceOddRow = true;
        gvADV.IndicatorWidth = 50;

        gvADV.OptionsView.RowAutoHeight = true;
        gvADV.OptionsView.ShowAutoFilterRow = true;
        gvADV.OptionsFind.ShowCloseButton = false;
        gvADV.OptionsFind.AlwaysVisible = true;
        gvADV.OptionsFind.ShowClearButton = false;
        gvADV.OptionsView.ShowFooter = true;

        gvADV.EndInit();
        gridADV.EndInit();
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

    private void gvADV_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == Convert.ToChar(Keys.Enter))
      {
        BTok.PerformClick();
      }
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

    private void frm_ListCodes_Shown(object sender, EventArgs e)
    {
      PropertyInfo property = typeof(GridView).GetProperty("FindPanel", BindingFlags.Instance | BindingFlags.NonPublic);

      FindControl findPanel = property.GetValue(gvADV, new object[0]) as FindControl;
      findPanel.Focus();

    }
  }
}