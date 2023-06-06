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
  public partial class frm_Complementarys_Record : DevExpress.XtraEditors.XtraForm
  {
    #region "  Variables declaration  "

    private BackgroundWorker _bwLoad = null;
    private BackgroundWorker _bwLoadCode = null;
    private DataSet dsMainData = new DataSet();
    private DataSet dsEdit = new DataSet();

    cls_Struct.ActionMode DataMode = 0;
    cls_Struct.StructComplementarys SComp;
    int ItemID = 0;
    private int _Codeid = 0;
    private bool IsSaveOK = false;

    #endregion

    #region "  Function  "
    private void AssignDataFromComponent()
    {
      SComp.COMPLEMENTARY_ID = ItemID;
      SComp.COMPLEMENTARY_CODE = TxtCompCode.Text.Trim();
      SComp.COMPLEMENTARY_NAME = TxtCompName.Text.Trim();
      SComp.COMPLEMENTARY_DESCRIPTION = TxtCompDesc.Text.Trim();
      SComp.CREATE_DATE = DateTime.Now;
      SComp.CREATE_BY = cls_Global_class.GB_Userid;
      SComp.UPDATE_DATE = DateTime.Now;
      SComp.UPDATE_BY = cls_Global_class.GB_Userid;
      SComp.DELETED = false;
      SComp.DELETE_BY = cls_Global_class.GB_Userid;
      SComp.DELETE_DATE = DateTime.Now;
    }

    private void AddDataSourceToGrid()
    {
      try
      {
        cls_Global_DB.GB_Dcomp_Sub1 = 0;
        cls_Global_DB.GB_Dcomp_Sub2 = 0;
        cls_Global_DB.GB_Dcomp_Sub3 = 0;
        cls_Global_DB.GB_Dcomp_Item = 0;

        cls_Global_DB.GB_Dcomp_Sub1 = dsEdit.Tables["D_COMPLEMENTARY_SUB1"].Rows.Count;
        gridSub1.DataSource = dsEdit.Tables["D_COMPLEMENTARY_SUB1"];
        gridSub1.RefreshDataSource();

        cls_Global_DB.GB_Dcomp_Sub2 = dsEdit.Tables["D_COMPLEMENTARY_SUB2"].Rows.Count;
        gridSub2.DataSource = dsEdit.Tables["D_COMPLEMENTARY_SUB2"];
        gridSub2.RefreshDataSource();

        cls_Global_DB.GB_Dcomp_Sub3 = dsEdit.Tables["D_COMPLEMENTARY_SUB3"].Rows.Count;
        gridSub3.DataSource = dsEdit.Tables["D_COMPLEMENTARY_SUB3"];
        gridSub3.RefreshDataSource();

        cls_Global_DB.GB_Dcomp_Item = dsEdit.Tables["D_COMPLEMENTARY_ITEMS"].Rows.Count;
        gridItem.DataSource = dsEdit.Tables["D_COMPLEMENTARY_ITEMS"];
        gridItem.RefreshDataSource();
      }
      catch (Exception ex)
      {
        MessageBox.Show("AddDataSourceToGrid :" + ex.Message);
      }
    }

    void _bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try
      {
        SetDataToControl();
        CheckingObject();
      }
      catch { }
      finally { Cursor = Cursors.Default; }
    }

    void _bwLoad_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        dsMainData = cls_Data.GetListComplementarysById(ItemID);
      }
      catch (Exception ex)
      { MessageBox.Show(ex.Message); }
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

      err = false;
      cmd = new SqlCommand();
      cmd.CommandText = "SELECT COMPLEMENTARY_ID,COMPLEMENTARY_CODE FROM M_COMPLEMENTARIES WHERE COMPLEMENTARY_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((DataMode == cls_Struct.ActionMode.Edit) || (DataMode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["COMPLEMENTARY_ID"]);
          if (id != ItemID)
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

    private void CheckingObject()
    {
      bool Sok = false;


      if (TxtCompName.Text.Length > 0) Sok = true;

      btSub1Add.Enabled = Sok;
      btSub1Edit.Enabled = Sok;
      btSub1Delete.Enabled = Sok;
      btSub2Add.Enabled = Sok;
      btSub2Edit.Enabled = Sok;
      btSub2Delete.Enabled = Sok;
      btSub3Add.Enabled = Sok;
      btSub3Edit.Enabled = Sok;
      btSub3Delete.Enabled = Sok;

      Sok = true;
      int Sub1 = dsEdit.Tables["D_COMPLEMENTARY_SUB1"].Rows.Count;
      int Sub2 = dsEdit.Tables["D_COMPLEMENTARY_SUB2"].Rows.Count;
      int Sub3 = dsEdit.Tables["D_COMPLEMENTARY_SUB3"].Rows.Count;

      if (Sub1 == 0) Sok = false;
      if (Sub2 == 0) Sok = false;
      if (Sub3 == 0) Sok = false;

      BTitemAdd.Enabled = Sok;
      BTitemEdit.Enabled = Sok;
      BTitemDelete.Enabled = Sok;
    }

    public void InitialDialogItem(int mode)
    {
      frmD_Complementary_Item frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      int Xmode = 0;
      if (mode == 2)
      {
        Xmode = 0;
      }
      else
      {
        Xmode = mode;
      }

      frmInput = new frmD_Complementary_Item();
      frmInput.StartPosition = FormStartPosition.CenterParent;

      if (mode == 0)
        strMode = " [เพิ่ม]";
      else if (mode == 1)
        strMode = " [แก้ไข]";


      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvItem;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != 0)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "รหัสสินค้า " + strMode;
        #region "XXX"
        frmInput.searchLookUpProduct.Properties.DataSource = cls_Global_DB.DataInitialComp.Tables["M_ITEMS"];
        frmInput.searchLookUpProduct.Properties.PopulateViewColumns();
        frmInput.searchLookUpProduct.Properties.ValueMember = "_id";
        frmInput.searchLookUpProduct.Properties.DisplayMember = "code";
        frmInput.searchLookUpProduct.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpProduct.Properties.View.Columns["code"].Caption = "รหัสสินค้า";
        frmInput.searchLookUpProduct.Properties.View.Columns["name"].Caption = "ชื่อสินค้า";
        frmInput.searchLookUpProduct.EditValue = null;
        if (dr != null)
        {
          DataTable dt = (DataTable)gridItem.DataSource;
          if ((mode == 1) || (mode == 2))
          {
            frmInput.searchLookUpProduct.EditValue = cls_Library.DBInt(dr["ITEM_ID"]);
            frmInput.TxtCode.Text = cls_Library.DBString(dr["ITEM_CODE"]);
            frmInput.TxtName.Text = cls_Library.DBString(dr["ITEM_NAME"]);
            frmInput.TxtDesc.Text = cls_Library.DBString(dr["ITEM_DESCRIPTION"]);
          }
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsEdit.Tables["D_COMPLEMENTARY_ITEMS"].BeginInit();
        if (Xmode == 0)
        {
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["COMPLEMENTARY_ID"] = ItemID;
          dt.Rows[0]["ITEM_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dt.Rows[0]["ITEM_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dt.Rows[0]["ITEM_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dt.Rows[0]["ITEM_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc.Text);
          dsEdit.Tables["D_COMPLEMENTARY_ITEMS"].ImportRow(dt.Rows[0]);
        }
        else
        {
          view = (DevExpress.XtraGrid.Views.Grid.GridView)gvItem;
          dr = view.GetFocusedDataRow();
          dr["COMPLEMENTARY_ID"] = ItemID;
          dr["ITEM_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dr["ITEM_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dr["ITEM_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dr["ITEM_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc.Text);
        }
        dsEdit.Tables["D_COMPLEMENTARY_ITEMS"].EndInit();
        gridItem.DataSource = dsEdit.Tables["D_COMPLEMENTARY_ITEMS"];
        gridItem.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
      finally
      {
        CheckingObject();
      }
    }

    public void InitialDialogSub1(int mode)
    {
      frmD_Complementary_Sub1 frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      int Xmode = 0;
      if (mode == 2)
      {
        Xmode = 0;
      }
      else
      {
        Xmode = mode;
      }

      frmInput = new frmD_Complementary_Sub1();
      frmInput.StartPosition = FormStartPosition.CenterParent;

      if (mode == 0)
        strMode = " [เพิ่ม]";
      else if (mode == 1)
        strMode = " [แก้ไข]";


      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub1;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != 0)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 1 " + strMode;
        #region "XXX"
        frmInput.searchLookUpProduct.Properties.DataSource = cls_Global_DB.DataInitialComp.Tables["M_COMPLEMENTARIES_SUB1"];
        frmInput.searchLookUpProduct.Properties.PopulateViewColumns();
        frmInput.searchLookUpProduct.Properties.ValueMember = "_id";
        frmInput.searchLookUpProduct.Properties.DisplayMember = "code";
        frmInput.searchLookUpProduct.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpProduct.Properties.View.Columns["code"].Caption = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 1";
        frmInput.searchLookUpProduct.Properties.View.Columns["name"].Caption = "ชื่อกลุ่มสินค้าหลัก";
        frmInput.searchLookUpProduct.Properties.View.Columns["description"].Caption = "รายละเอียด";
        if (dr != null)
        {
          DataTable dt = (DataTable)gridSub1.DataSource;
          if ((mode == 1) || (mode == 2))
          {
            frmInput.searchLookUpProduct.EditValue = cls_Library.DBInt(dr["SUB_ID"]);
            frmInput.TxtCode.Text = cls_Library.DBString(dr["SUB_CODE"]);
            frmInput.TxtName.Text = cls_Library.DBString(dr["SUB_NAME"]);
            frmInput.TxtDesc.Text = cls_Library.DBString(dr["SUB_DESCRIPTION"]);
          }
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsEdit.Tables["D_COMPLEMENTARY_SUB1"].BeginInit();
        if (Xmode == 0)
        {
          DataTable dtv = (DataTable)gridSub1.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["COMPLEMENTARY_ID"] = ItemID;
          dt.Rows[0]["SUB_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dt.Rows[0]["SUB_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dt.Rows[0]["SUB_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dt.Rows[0]["SUB_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc.Text);
          dsEdit.Tables["D_COMPLEMENTARY_SUB1"].ImportRow(dt.Rows[0]);
        }
        else
        {
          view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub1;
          dr = view.GetFocusedDataRow();
          dr["COMPLEMENTARY_ID"] = ItemID;
          dr["SUB_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dr["SUB_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dr["SUB_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dr["SUB_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc.Text);
        }
        dsEdit.Tables["D_COMPLEMENTARY_SUB1"].EndInit();
        gridSub1.DataSource = dsEdit.Tables["D_COMPLEMENTARY_SUB1"];
        gridSub1.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
      finally
      {
        CheckingObject();
      }
    }

    public void InitialDialogSub2(int mode)
    {
      frmD_Complementary_Sub2 frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      int Xmode = 0;
      if (mode == 2)
      {
        Xmode = 0;
      }
      else
      {
        Xmode = mode;
      }

      frmInput = new frmD_Complementary_Sub2();
      frmInput.StartPosition = FormStartPosition.CenterParent;

      if (mode == 0)
        strMode = " [เพิ่ม]";
      else if (mode == 1)
        strMode = " [แก้ไข]";


      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub2;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != 0)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 2 " + strMode;
        #region "XXX"
        frmInput.searchLookUpProduct.Properties.DataSource = cls_Global_DB.DataInitialComp.Tables["M_COMPLEMENTARIES_SUB2"];
        frmInput.searchLookUpProduct.Properties.PopulateViewColumns();
        frmInput.searchLookUpProduct.Properties.ValueMember = "_id";
        frmInput.searchLookUpProduct.Properties.DisplayMember = "code";
        frmInput.searchLookUpProduct.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpProduct.Properties.View.Columns["code"].Caption = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 2";
        frmInput.searchLookUpProduct.Properties.View.Columns["name"].Caption = "ยี่ห้อสินค้า";
        frmInput.searchLookUpProduct.Properties.View.Columns["description"].Caption = "รายละเอียด";
        if (dr != null)
        {
          DataTable dt = (DataTable)gridSub2.DataSource;
          if ((mode == 1) || (mode == 2))
          {
            frmInput.searchLookUpProduct.EditValue = cls_Library.DBInt(dr["SUB_ID"]);
            frmInput.TxtCode.Text = cls_Library.DBString(dr["SUB_CODE"]);
            frmInput.TxtName.Text = cls_Library.DBString(dr["SUB_NAME"]);
            frmInput.TxtDesc.Text = cls_Library.DBString(dr["SUB_DESCRIPTION"]);
          }
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsEdit.Tables["D_COMPLEMENTARY_SUB2"].BeginInit();
        if (Xmode == 0)
        {
          DataTable dtv = (DataTable)gridSub2.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["COMPLEMENTARY_ID"] = ItemID;
          dt.Rows[0]["SUB_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dt.Rows[0]["SUB_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dt.Rows[0]["SUB_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dt.Rows[0]["SUB_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc.Text);
          dsEdit.Tables["D_COMPLEMENTARY_SUB2"].ImportRow(dt.Rows[0]);
        }
        else
        {
          view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub2;
          dr = view.GetFocusedDataRow();
          dr["COMPLEMENTARY_ID"] = ItemID;
          dr["SUB_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dr["SUB_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dr["SUB_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dr["SUB_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc.Text);
        }
        dsEdit.Tables["D_COMPLEMENTARY_SUB2"].EndInit();
        gridSub2.DataSource = dsEdit.Tables["D_COMPLEMENTARY_SUB2"];
        gridSub2.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
      finally
      {
        CheckingObject();
      }
    }

    public void InitialDialogSub3(int mode)
    {
      frmD_Complementary_Sub3 frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      int Xmode = 0;
      if (mode == 2)
      {
        Xmode = 0;
      }
      else
      {
        Xmode = mode;
      }

      frmInput = new frmD_Complementary_Sub3();
      frmInput.StartPosition = FormStartPosition.CenterParent;

      if (mode == 0)
        strMode = " [เพิ่ม]";
      else if (mode == 1)
        strMode = " [แก้ไข]";


      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub3;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != 0)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 3 " + strMode;
        #region "XXX"
        frmInput.searchLookUpProduct.Properties.DataSource = cls_Global_DB.DataInitialComp.Tables["M_COMPLEMENTARIES_SUB3"];
        frmInput.searchLookUpProduct.Properties.PopulateViewColumns();
        frmInput.searchLookUpProduct.Properties.ValueMember = "_id";
        frmInput.searchLookUpProduct.Properties.DisplayMember = "code";
        frmInput.searchLookUpProduct.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpProduct.Properties.View.Columns["code"].Caption = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 3";
        frmInput.searchLookUpProduct.Properties.View.Columns["name"].Caption = "ขนาด/รุ่น";
        frmInput.searchLookUpProduct.Properties.View.Columns["description"].Caption = "รายละเอียด";
        if (dr != null)
        {
          DataTable dt = (DataTable)gridSub3.DataSource;
          if ((mode == 1) || (mode == 2))
          {
            frmInput.searchLookUpProduct.EditValue = cls_Library.DBInt(dr["SUB_ID"]);
            frmInput.TxtCode.Text = cls_Library.DBString(dr["SUB_CODE"]);
            frmInput.TxtName.Text = cls_Library.DBString(dr["SUB_NAME"]);
            frmInput.TxtDesc.Text = cls_Library.DBString(dr["SUB_DESCRIPTION"]);
          }
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsEdit.Tables["D_COMPLEMENTARY_SUB3"].BeginInit();
        if (Xmode == 0)
        {
          DataTable dtv = (DataTable)gridSub3.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["COMPLEMENTARY_ID"] = ItemID;
          dt.Rows[0]["SUB_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dt.Rows[0]["SUB_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dt.Rows[0]["SUB_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dt.Rows[0]["SUB_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc.Text);
          dsEdit.Tables["D_COMPLEMENTARY_SUB3"].ImportRow(dt.Rows[0]);
        }
        else
        {
          view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub3;
          dr = view.GetFocusedDataRow();
          dr["COMPLEMENTARY_ID"] = ItemID;
          dr["SUB_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dr["SUB_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dr["SUB_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dr["SUB_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc.Text);
        }
        dsEdit.Tables["D_COMPLEMENTARY_SUB3"].EndInit();
        gridSub3.DataSource = dsEdit.Tables["D_COMPLEMENTARY_SUB3"];
        gridSub3.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
      finally
      {
        CheckingObject();
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

        if ((DataMode == cls_Struct.ActionMode.Add) || (DataMode == cls_Struct.ActionMode.Copy))
        {
          SaveMode = 1;
        }
        else
        {
          SaveMode = 2;
        }
        AssignDataFromComponent();

        //--- Save ข้อมูลลงฐานข้อมูล 
        ret = cls_Data.SaveComplementaryCode(SaveMode, SComp, dsEdit);

      }
      catch (Exception ex)
      {
        Application.DoEvents();
        if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
        {
          TxtCompCode.ErrorText = "";
          TxtCompCode.Focus();
        }
        else
        {
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสกลุ่มสินค้าใช้ด้วยกันได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }

    private void SetDataToControl()
    {
      DataRow row = null;
      try
      {
        dsEdit = dsMainData.Copy();

        switch (DataMode)
        {
          case cls_Struct.ActionMode.Add:
            TxtCompCode.Text = cls_Data.GetLastCodeMaster("COMPLEMENTARIES", 3);
            break;
          case cls_Struct.ActionMode.Edit:
          case cls_Struct.ActionMode.Copy:
            if (dsEdit.Tables["M_COMPLEMENTARIES"].Rows.Count <= 0) return;
            row = dsEdit.Tables["M_COMPLEMENTARIES"].Rows[0];
            TxtCompCode.Text = cls_Library.DBString(row["COMPLEMENTARY_CODE"]);
            TxtCompName.Text = cls_Library.DBString(row["COMPLEMENTARY_NAME"]);
            TxtCompDesc.Text = cls_Library.DBString(row["COMPLEMENTARY_DESCRIPTION"]);
            break;
        }
        AddDataSourceToGrid();
      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDataToControl :" + ex.Message);
      }
    }

    private void ThreadStart()
    {
      _bwLoad = new BackgroundWorker();
      _bwLoad.WorkerReportsProgress = true;
      _bwLoad.WorkerSupportsCancellation = true;
      _bwLoad.DoWork += new DoWorkEventHandler(_bwLoad_DoWork);
      _bwLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bwLoad_RunWorkerCompleted);

      _bwLoad.RunWorkerAsync();
    }
    #endregion

    public frm_Complementarys_Record(cls_Struct.ActionMode mode, int id)
    {
      InitializeComponent();
      DataMode = mode;
      ItemID = id;
      this.KeyPreview = true;
      ThreadStart();
      
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

      if (TxtCompCode.EditValue == null || TxtCompCode.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุรหัสกลุ่มสินค้าเฉพาะ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtCompCode.ErrorText = "กรุณาระบุรหัสกลุ่มสินค้าเฉพาะ";
        TxtCompCode.Focus();
        err = true;
      }
      else
      {
        if (CheckCodeExist(TxtCompCode.Text.Trim()))
        {
          XtraMessageBox.Show("มีรหัสกลุ่มสินค้าเฉพาะนี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtCompCode.ErrorText = "มีรหัสกลุ่มสินค้าเฉพาะนี้ในฐานข้อมูลแล้ว";
          TxtCompCode.Focus();
          err = true;
        }

      }

      if (!err)
      {
        int Sub1 = dsEdit.Tables["D_COMPLEMENTARY_SUB1"].Rows.Count;
        int Sub2 = dsEdit.Tables["D_COMPLEMENTARY_SUB2"].Rows.Count;
        int Sub3 = dsEdit.Tables["D_COMPLEMENTARY_SUB3"].Rows.Count;

        if (Sub1 == 0)
        {
          XtraMessageBox.Show("ยังไม่ได้กำหนดรหัสกลุ่มสินค้าเฉพาะใช้ด้วยกัน 1", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          err = true;
        }

        if (!err)
        {
          if (Sub2 == 0)
          {
            XtraMessageBox.Show("ยังไม่ได้กำหนดรหัสกลุ่มสินค้าเฉพาะใช้ด้วยกัน 2", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            err = true;
          }
        }
        
        if (!err)
        {
          if (Sub3 == 0)
          {
            XtraMessageBox.Show("ยังไม่ได้กำหนดรหัสกลุ่มสินค้าเฉพาะใช้ด้วยกัน 3", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            err = true;
          }
        }
        
      }

      if (!err)
      {
        if (dsEdit.Tables["D_COMPLEMENTARY_ITEMS"].Rows.Count ==0)
        {
          XtraMessageBox.Show("ยังไม่ได้กำหนดรหัสสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          err = true;
        }
      }

      if (err)
      {
        return;
      }

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสกลุ่มสินค้าเฉพาะ : " + TxtCompCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสกลุ่มสินค้าเฉพาะเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
          IsSaveOK = true;
          if (((SimpleButton)sender).Tag == "1")
          {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
          }          
        }
        else
        {
          IsSaveOK = false;
          XtraMessageBox.Show("บันทึกรหัสกลุ่มสินค้าเฉพาะไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
      TxtCompName.Text = "";
      TxtCompDesc.Text = "";
    }

    private void frm_Types_Record_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F2:
          BTsave_Click(sender, e);
          break;
        case Keys.F3:
          if (DataMode == cls_Struct.ActionMode.Edit)
          {
            return;
          }
          BTreset_Click(sender, e);
          break;
        case Keys.Escape:
          BTcancel_Click(sender, e);
          break;
      }
    }

    private void btSub1Add_Click(object sender, EventArgs e)
    {
      InitialDialogSub1(0);
    }

    private void btSub1Edit_Click(object sender, EventArgs e)
    {
      InitialDialogSub1(1);
    }

    private void btSub1Delete_Click(object sender, EventArgs e)
    {
      DataRow Drow = gvSub1.GetFocusedDataRow();
      if (Drow == null) return;
      int irow = gvSub1.FocusedRowHandle;
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        dsEdit.Tables["D_COMPLEMENTARY_SUB1"].AcceptChanges();
        dsEdit.Tables["D_COMPLEMENTARY_SUB1"].Rows[irow].Delete();
        Drow.Delete();
        dsEdit.Tables["D_COMPLEMENTARY_SUB1"].AcceptChanges();
        gvSub1.RefreshData();
        gridSub1.RefreshDataSource();
      }
      CheckingObject();
    }

    private void btSub2Add_Click(object sender, EventArgs e)
    {
      InitialDialogSub2(0);
    }

    private void btSub2Edit_Click(object sender, EventArgs e)
    {
      InitialDialogSub2(1);
    }

    private void btSub2Delete_Click(object sender, EventArgs e)
    {
      DataRow Drow = gvSub2.GetFocusedDataRow();
      if (Drow == null) return;
      int irow = gvSub2.FocusedRowHandle;
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        dsEdit.Tables["D_COMPLEMENTARY_SUB2"].AcceptChanges();
        dsEdit.Tables["D_COMPLEMENTARY_SUB2"].Rows[irow].Delete();
        Drow.Delete();
        dsEdit.Tables["D_COMPLEMENTARY_SUB2"].AcceptChanges();
        gvSub2.RefreshData();
        gridSub2.RefreshDataSource();
      }
      CheckingObject();
    }

    private void btSub3Delete_Click(object sender, EventArgs e)
    {
      DataRow Drow = gvSub3.GetFocusedDataRow();
      if (Drow == null) return;
      int irow = gvSub3.FocusedRowHandle;
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        dsEdit.Tables["D_COMPLEMENTARY_SUB3"].AcceptChanges();
        dsEdit.Tables["D_COMPLEMENTARY_SUB3"].Rows[irow].Delete();
        Drow.Delete();
        dsEdit.Tables["D_COMPLEMENTARY_SUB3"].AcceptChanges();
        gvSub3.RefreshData();
        gridSub3.RefreshDataSource();
      }
      CheckingObject();
    }

    private void btSub3Add_Click(object sender, EventArgs e)
    {
      InitialDialogSub3(0);
    }

    private void btSub3Edit_Click(object sender, EventArgs e)
    {
      InitialDialogSub3(1);
    }

    private void BTitemAdd_Click(object sender, EventArgs e)
    {
      InitialDialogItem(0);
    }

    private void BTitemEdit_Click(object sender, EventArgs e)
    {
      InitialDialogItem(1);
    }

    private void BTitemDelete_Click(object sender, EventArgs e)
    {
      DataRow Drow = gvItem.GetFocusedDataRow();
      if (Drow == null) return;
      int irow = gvItem.FocusedRowHandle;
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        dsEdit.Tables["D_COMPLEMENTARY_ITEMS"].AcceptChanges();
        dsEdit.Tables["D_COMPLEMENTARY_ITEMS"].Rows[irow].Delete();
        Drow.Delete();
        dsEdit.Tables["D_COMPLEMENTARY_ITEMS"].AcceptChanges();
        gvItem.RefreshData();
        gridItem.RefreshDataSource();
      }
      CheckingObject();
    }

    private void TxtCompName_EditValueChanged(object sender, EventArgs e)
    {
      CheckingObject();
    }
  }
}