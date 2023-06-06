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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

namespace SmartPart.Forms.Code
{
  public partial class frm_Versatiles_Record : DevExpress.XtraEditors.XtraForm
  {
    #region "  Variables declaration  "

    private BackgroundWorker _bwLoad = null;
    private BackgroundWorker _bwLoadCode = null;

    RepositoryItemTextEdit R_SubCode = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_SubName = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_ItemCode = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_ItemName = new RepositoryItemTextEdit();

    private DataSet dsMainData = new DataSet();
    private DataSet dsEdit = new DataSet();
    DataSet DataS;
    DataTable Subdata = null;
    DataTable[] Itemdata = null;

    cls_Struct.ActionMode DataMode = 0;
    cls_Struct.StructVersatiles Sitem;
    int ItemID = 0;
    int SubCount = 0;
    int Subrow = 1;
    private int _Codeid = 0;
    private bool IsSaveOK = false;

    #endregion

    #region "  Function  "
    private void AddDataRowItem(int Srow)
    {
      DataTable dt;
      int iCount = Subdata.Rows.Count;

      try
      {

        //dt = new DataTable("D_ITEMS_SPECIALS_ITEMS");
        //dt.Columns.Clear();
        //dt.Columns.Add("SUB_ID", typeof(int));
        //dt.Columns.Add("ITEMS_SUB_ID", typeof(int));
        //dt.Columns.Add("ITEM1_ID", typeof(int));
        //dt.Columns.Add("ITEM1_CODE", typeof(string));
        //dt.Columns.Add("ITEM1_NAME", typeof(string));
        //dt.Columns.Add("ITEM1_DESCRIPTION", typeof(string));
        //dt.Columns.Add("ITEM2_ID", typeof(int));
        //dt.Columns.Add("ITEM2_CODE", typeof(string));
        //dt.Columns.Add("ITEM2_NAME", typeof(string));
        //dt.Columns.Add("ITEM2_DESCRIPTION", typeof(string));
        //dt.Columns.Add("ITEM3_ID", typeof(int));
        //dt.Columns.Add("ITEM3_CODE", typeof(string));
        //dt.Columns.Add("ITEM3_NAME", typeof(string));
        //dt.Columns.Add("ITEM3_DESCRIPTION", typeof(string));
        //dt.Columns.Add("LIST_NO", typeof(int));

        //Itemdata[Srow - 1] = dt.Clone();

        int itemcount = Itemdata[Srow - 1].Rows.Count;
        for (int j = 0; j < 1; j++)
        {
          //itemcount++;
          //Itemdata[Srow - 1].Rows.Add();
          Itemdata[Srow - 1].Rows[itemcount - 1]["VERSATILE_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[Srow - 1]["SUB_ID"]);
          Itemdata[Srow - 1].Rows[itemcount - 1]["SUB_ID"] = 0;
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM_ID"] = 0;
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM_CODE"] = "";
          Itemdata[Srow - 1].Rows[itemcount - 1]["FULL_NAME"] = "";
          Itemdata[Srow - 1].Rows[itemcount - 1]["LIST_NO"] = itemcount;
        }
        SubCount = Subdata.Rows.Count;
      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDefaultDataRow :" + ex.Message);
      }

    }

    private void AddDataRowSUB()
    {
      DataTable dt;
      int iCount = Subdata.Rows.Count;

      try
      {
        
        //iCount++;
        //SubCount = iCount;
        //Subdata.Rows.Add();
        Subdata.Rows[iCount - 1]["VERSATILE_ID"] = ItemID;
        Subdata.Rows[iCount - 1]["SUB_ID"] = 0;
        Subdata.Rows[iCount - 1]["SUB_CODE"] = "";
        Subdata.Rows[iCount - 1]["SUB_NAME"] = "";
        Subdata.Rows[iCount - 1]["LIST_NO"] = iCount;

        Array.Resize(ref Itemdata, iCount);

        dt = new DataTable("M_VERSATILES_ITEM");
        dt.Columns.Clear();
        dt.Columns.Add("SUB_ID", typeof(int));
        dt.Columns.Add("VERSATILE_SUB_ID", typeof(int));
        dt.Columns.Add("ITEM_ID", typeof(int));
        dt.Columns.Add("FULL_NAME", typeof(string));
        dt.Columns.Add("LIST_NO", typeof(int));

        Itemdata[iCount - 1] = dt.Clone();

        int itemcount = Itemdata[iCount - 1].Rows.Count;
        for (int j = 0; j < 1; j++)
        {
          itemcount++;
          Itemdata[iCount - 1].Rows.Add();
          Itemdata[iCount - 1].Rows[itemcount - 1]["VERSATILE_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[iCount - 1]["SUB_ID"]);
          Itemdata[iCount - 1].Rows[itemcount - 1]["SUB_ID"] = 0;
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM_ID"] = 0;
          Itemdata[iCount - 1].Rows[itemcount - 1]["FULL_NAME"] = "";
          Itemdata[iCount - 1].Rows[itemcount - 1]["LIST_NO"] = itemcount;
        }
        SubCount = Subdata.Rows.Count;
      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDefaultDataRow :" + ex.Message);
      }

    }

    private void AssignDataFromComponent()
    {
      Sitem.VERSATILE_ID = ItemID;
      Sitem.VERSATILE_CODE = TxtItemCode.Text.Trim();
      Sitem.VERSATILE_NAME = TxtItemName.Text.Trim();
      Sitem.VERSATILE_DESCRIPTION = "";
      Sitem.CREATE_DATE = DateTime.Now;
      Sitem.CREATE_BY = cls_Global_class.GB_Userid;
      Sitem.UPDATE_DATE = DateTime.Now;
      Sitem.UPDATE_BY = cls_Global_class.GB_Userid;
      Sitem.DELETED = false;
      Sitem.DELETE_BY = cls_Global_class.GB_Userid;
      Sitem.DELETE_DATE = DateTime.Now;
    }

    private void AddDataSourceToGrid()
    {
      try
      {
        
        cls_Global_DB.GB_DitemVersatile_Sub = 0;
        cls_Global_DB.GB_DitemVersatile_Item = new int[0];

        cls_Global_DB.GB_DitemVersatile_Sub = Subdata.Rows.Count-1;
        SubCount = Subdata.Rows.Count;
        gridSub.DataSource = Subdata;
        gridSub.RefreshDataSource();

        int irow = -1;

        for (int i = 0; i < cls_Global_DB.GB_DitemVersatile_Sub; i++)
        {
          irow++;
          Array.Resize(ref cls_Global_DB.GB_DitemVersatile_Item, irow + 1);
          cls_Global_DB.GB_DitemVersatile_Item[irow] = Itemdata[irow].Rows.Count -1;
        }

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
        LoadData();
        //dsMainData = cls_Data.GetListComplementarysById(ItemID);
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
      cmd.CommandText = "SELECT VERSATILE_ID,VERSATILE_CODE FROM M_VERSATILES WHERE VERSATILE_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((DataMode == cls_Struct.ActionMode.Edit) || (DataMode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["VERSATILE_ID"]);
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
      //bool Sok = false;


      //if (TxtItemName.Text.Length > 0) Sok = true;

      //btSubAdd.Enabled = Sok;
      //btSubEdit.Enabled = Sok;
      //btSubDelete.Enabled = Sok;

      //Sok = true;
      //int Sub1 = Subdata.Rows.Count;

      //if (Sub1 == 0) Sok = false;

      //BTitemAdd.Enabled = Sok;
      //BTitemEdit.Enabled = Sok;
      //BTitemDelete.Enabled = Sok;
    }

    private void InitialListCode(int TypeCode,string Xcode = "")
    {
      try
      {
        frm_ListCodes frm;
        frm = new frm_ListCodes(TypeCode,Xcode);
        frm.StartPosition = FormStartPosition.CenterParent;
        switch (TypeCode)
        {
          case 1:
            frm.Text = "รหัสสินค้า";
            break;
        }

        frm.MinimizeBox = false;
        frm.ShowInTaskbar = false;
        if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          int Xarr = frm.Prop_Arr;
          bool ok = false;
          if (Xarr > 0) ok = true;
          if (ok)
          {
            switch (TypeCode)
            {
              case 1:
                DataRow dr1 = gvItem.GetFocusedDataRow();
                dr1["ITEM_ID"] = cls_Library.DBInt(Xarr);
                dr1["ITEM_CODE"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS", "ITEM_CODE");
                dr1["FULL_NAME"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS", "FULL_NAME");
                R_ItemCode.NullText = cls_Library.DBString(dr1["ITEM_CODE"]);
                break;
            }
          }
        }
      }
      catch (Exception e)
      {
        this.Focus();
      }
    }

    public void InitialDialogItem(int mode)
    {
      frmD_ItemVersatiles_Item frmInput;
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

      frmInput = new frmD_ItemVersatiles_Item();
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
        frmInput.searchLookUpProduct.Properties.DataSource = cls_Global_DB.DataInitialVersatile.Tables["M_ITEMS"];
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
            frmInput.searchLookUpProduct.EditValue = null;
            if (cls_Library.DBInt(dr["ITEM_ID"]) > 0) frmInput.searchLookUpProduct.EditValue = cls_Library.DBInt(dr["ITEM_ID"]);
            frmInput.TxtCode.Text = cls_Library.DBString(dr["ITEM_CODE"]);
            frmInput.TxtName.Text = cls_Library.DBString(dr["FULL_NAME"]);
          }
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }
        int irow = 0;
        Itemdata[Subrow - 1].BeginInit();
        if (Xmode == 0)
        {
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          irow = (Itemdata[Subrow - 1].Rows.Count)-1;
          if (irow < 0) irow = 0;
          Itemdata[Subrow - 1].Rows[irow]["VERSATILE_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[Subrow - 1]["SUB_ID"]);
          Itemdata[Subrow - 1].Rows[irow]["ITEM_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          Itemdata[Subrow - 1].Rows[irow]["ITEM_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          Itemdata[Subrow - 1].Rows[irow]["FULL_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = gvItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
          gvItem.FocusedRowHandle = irow;
        }
        else
        {
          view = (DevExpress.XtraGrid.Views.Grid.GridView)gvItem;
          dr = view.GetFocusedDataRow();
          dr["VERSATILE_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[Subrow - 1]["SUB_ID"]);
          dr["ITEM_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
          dr["ITEM_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text);
          dr["FULL_NAME"] = cls_Library.DBString(frmInput.TxtName.Text);
          irow = cls_Library.DBInt(dr["LIST_NO"]);
          if (irow == Itemdata[Subrow - 1].Rows.Count)
          {
            DataTable dtv = (DataTable)gridItem.DataSource;
            DataTable dt = dtv.Clone();
            dt.Rows.Add();
            dt.Rows[0]["LIST_NO"] = gvItem.RowCount + 1;
            Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
            AddDataRowItem(Subrow);
            gvItem.FocusedRowHandle = irow;
          }
        }
        Itemdata[Subrow - 1].EndInit();
        gridItem.DataSource = Itemdata[Subrow - 1];
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

    public void InitialDialogSub(int mode)
    {
      frmD_ItemVersatiles_Sub frmInput;
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

      frmInput = new frmD_ItemVersatiles_Sub();
      frmInput.StartPosition = FormStartPosition.CenterParent;

      if (mode == 0)
        strMode = " [เพิ่ม]";
      else if (mode == 1)
        strMode = " [แก้ไข]";


      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != 0)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "กลุ่มย่อย " + strMode;
        #region "XXX"
        if (dr != null)
        {
          DataTable dt = (DataTable)gridItem.DataSource;
          if ((mode == 1) || (mode == 2))
          {
            frmInput.TxtCodeSub.Text = cls_Library.DBString(dr["SUB_CODE"]);
            frmInput.TxtNameSub.Text = cls_Library.DBString(dr["SUB_NAME"]);
          }
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }
        int irow = 0;
        Subdata.BeginInit();
        if (Xmode == 0)
        {
          DataTable dtv = (DataTable)gridSub.DataSource;
          DataTable dt = dtv.Clone();
          irow = (Subdata.Rows.Count) - 1;
          if (irow < 0) irow = 0;
          Subdata.Rows[irow]["VERSATILE_ID"] = ItemID;
          Subdata.Rows[irow]["SUB_CODE"] = cls_Library.DBString(frmInput.TxtCodeSub.Text);
          Subdata.Rows[irow]["SUB_NAME"] = cls_Library.DBString(frmInput.TxtNameSub.Text);
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = gvSub.RowCount + 1;
          Subdata.ImportRow(dt.Rows[0]);
          AddDataRowSUB();
          gvSub.FocusedRowHandle = irow;
        }
        else
        {
          view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSub;
          dr = view.GetFocusedDataRow();
          dr["VERSATILE_ID"] = ItemID;
          dr["SUB_CODE"] = cls_Library.DBString(frmInput.TxtCodeSub.Text);
          dr["SUB_NAME"] = cls_Library.DBString(frmInput.TxtNameSub.Text);
          irow = cls_Library.DBInt(dr["LIST_NO"]);
          if (irow == Subdata.Rows.Count)
          {
            DataTable dtv = (DataTable)gridSub.DataSource;
            DataTable dt = dtv.Clone();
            dt.Rows.Add();
            dt.Rows[0]["LIST_NO"] = gvSub.RowCount + 1;
            Subdata.ImportRow(dt.Rows[0]);
            AddDataRowSUB();
            gvSub.FocusedRowHandle = irow;
          }
        }
        Subdata.EndInit();
        gridSub.DataSource = Subdata;
        gridSub.RefreshDataSource();
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

    private void LoadData()
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      DataTable dt;
      string sql = string.Empty;
      DataRow drow;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        dsMainData = new DataSet();
        sql = "Select * From M_VERSATILES Where VERSATILE_ID=@VERSATILE_ID and DELETED=0";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.Parameters.Add("@VERSATILE_ID", SqlDbType.Int).Value = ItemID;
        da.SelectCommand.CommandTimeout = 1200;
        dt = new DataTable("M_VERSATILES");
        da.Fill(dt);
        dsMainData.Tables.Add(dt);

        sql = "Select * From M_VERSATILES_SUB Where VERSATILE_ID=@VERSATILE_ID and DELETED=0 order by LIST_NO";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.Parameters.Add("@VERSATILE_ID", SqlDbType.Int).Value = ItemID;
        da.SelectCommand.CommandTimeout = 1200;
        dt = new DataTable("M_VERSATILES_SUB");
        da.Fill(dt);

        Subdata = dt;

        SubCount = -1;
        

        for (int i = 0; i < Subdata.Rows.Count; i++)
        {
          drow = Subdata.Rows[i];
          int ID = cls_Library.DBInt(drow["SUB_ID"]);

          SubCount ++;
          Array.Resize(ref Itemdata, SubCount + 1);

          Itemdata[SubCount] = new DataTable("M_VERSATILES_ITEM");
          Itemdata[SubCount].Columns.Clear();
          Itemdata[SubCount].Columns.Add("SUB_ID", typeof(int));
          Itemdata[SubCount].Columns.Add("VERSATILE_SUB_ID", typeof(int));
          Itemdata[SubCount].Columns.Add("ITEM_ID", typeof(int));
          Itemdata[SubCount].Columns.Add("ITEM_CODE", typeof(string));
          Itemdata[SubCount].Columns.Add("FULL_NAME", typeof(string));
          Itemdata[SubCount].Columns.Add("LIST_NO", typeof(string));
          

          sql = "Select SUB_ID, VERSATILE_SUB_ID, ITEM_ID, ITEM_CODE, FULL_NAME, LIST_NO";
          sql += " From M_VERSATILES_ITEM Where VERSATILE_SUB_ID=@VERSATILE_SUB_ID and DELETED=0 order by LIST_NO";
          da = new SqlDataAdapter(sql, cn);
          da.SelectCommand.Parameters.Clear();
          da.SelectCommand.Parameters.Add("@VERSATILE_SUB_ID", SqlDbType.Int).Value = ID;
          da.SelectCommand.CommandTimeout = 300;
          da.Fill(Itemdata[SubCount]);
        }

        if (Subdata.Rows.Count == 0)
        {
          Array.Resize(ref Itemdata, 1);

          Itemdata[0] = new DataTable("M_VERSATILES_ITEM");
          Itemdata[0].Columns.Clear();
          Itemdata[0].Columns.Add("SUB_ID", typeof(int));
          Itemdata[0].Columns.Add("VERSATILE_SUB_ID", typeof(int));
          Itemdata[0].Columns.Add("ITEM_ID", typeof(int));
          Itemdata[0].Columns.Add("ITEM_CODE", typeof(string));
          Itemdata[0].Columns.Add("FULL_NAME", typeof(string));
          Itemdata[0].Columns.Add("LIST_NO", typeof(string));
        }


      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
    }

    private void ResetNumberOfDataRow()
    {
      int iCount = Subdata.Rows.Count;

      try
      {
        for (int i = 0; i < iCount; i++)
        {
          Subdata.Rows[i]["LIST_NO"] = i+1;

          int itemcount = Itemdata[i].Rows.Count;
          for (int j = 0; j < itemcount; j++)
          {
            Itemdata[i].Rows[j]["LIST_NO"] = j+1;
          }
        }

        SubCount = Subdata.Rows.Count;
      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDefaultDataRow :" + ex.Message);
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
        cls_Global_DB.GB_ItemVersatileID = 0;
        ret = cls_Data.SaveItemVersatileCode(SaveMode, Sitem,Subdata,Itemdata);
        ItemID = cls_Global_DB.GB_ItemVersatileID;
        DataMode = cls_Struct.ActionMode.Edit;
        if (!_bwLoad.IsBusy)
        {
          this.UseWaitCursor = true;
          _bwLoad.RunWorkerAsync();
          this.UseWaitCursor = false;
        }
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
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสกลุ่มสินค้าอเนกประสงค์ได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            TxtItemCode.Text = cls_Data.GetLastCodeMaster("VERSATILES", 5);
            break;
          case cls_Struct.ActionMode.Edit:
          case cls_Struct.ActionMode.Copy:
            if (dsEdit.Tables["M_VERSATILES"].Rows.Count <= 0) return;
            row = dsEdit.Tables["M_VERSATILES"].Rows[0];
            TxtItemCode.Text = cls_Library.DBString(row["VERSATILE_CODE"]);
            TxtItemName.Text = cls_Library.DBString(row["VERSATILE_NAME"]);
            break;
        }
        SetGrid();
        SetDefaultDataRow();
        AddDataSourceToGrid();
        gridSub.DataSource = Subdata;
        gvSub.FocusedRowHandle = 0;
        TxtItemName.Focus();
      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDataToControl :" + ex.Message);
      }
    }

    private void SetDefaultDataRow()
    {
      DataTable dt;
      int iCount = Subdata.Rows.Count;

      try
      {
        for (int i = 0; i < iCount; i++)
        {
          Subdata.Rows[i]["VERSATILE_ID"] = ItemID;
          //Subdata.Rows[i]["SUB1_ID"] = 0;
          //Subdata.Rows[i]["SUB1_CODE"] = "";
          //Subdata.Rows[i]["SUB1_NAME"] = "";
          //Subdata.Rows[i]["SUB2_ID"] = 0;
          //Subdata.Rows[i]["SUB2_CODE"] = "";
          //Subdata.Rows[i]["SUB2_NAME"] = "";
          Subdata.Rows[i]["LIST_NO"] = i+1;

          int itemcount = Itemdata[i].Rows.Count;
          for (int j = 0; j < 1; j++)
          {
            itemcount++;
            Itemdata[i].Rows.Add();
            Itemdata[i].Rows[itemcount - 1]["VERSATILE_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[iCount - 1]["SUB_ID"]);
            Itemdata[i].Rows[itemcount - 1]["SUB_ID"] = 0;
            Itemdata[i].Rows[itemcount - 1]["ITEM_ID"] = 0;
            Itemdata[i].Rows[itemcount - 1]["ITEM_CODE"] = "";
            Itemdata[i].Rows[itemcount - 1]["FULL_NAME"] = "";
            Itemdata[i].Rows[itemcount - 1]["LIST_NO"] = itemcount;
          }
        }

        for (int i = 0; i < 1; i++)
        {
          iCount++;
          //SubCount = iCount;
          Subdata.Rows.Add();
          Subdata.Rows[iCount - 1]["VERSATILE_ID"] = ItemID;
          Subdata.Rows[iCount - 1]["SUB_ID"] = 0;
          Subdata.Rows[iCount - 1]["SUB_CODE"] = "";
          Subdata.Rows[iCount - 1]["SUB_NAME"] = "";
          Subdata.Rows[iCount - 1]["LIST_NO"] = iCount;

          Array.Resize(ref Itemdata, iCount);

          dt = new DataTable("M_VERSATILES_ITEM");
          dt.Columns.Clear();
          dt.Columns.Add("VERSATILE_SUB_ID", typeof(int));
          dt.Columns.Add("SUB_ID", typeof(int));
          dt.Columns.Add("ITEM_ID", typeof(int));
          dt.Columns.Add("ITEM_CODE", typeof(string));
          dt.Columns.Add("FULL_NAME", typeof(string));
          dt.Columns.Add("LIST_NO", typeof(int));

          Itemdata[iCount - 1] = dt.Clone();

          int itemcount = Itemdata[iCount - 1].Rows.Count;
          for (int j = 0; j < 1; j++)
          {
            itemcount++;
            Itemdata[iCount - 1].Rows.Add();
            Itemdata[iCount - 1].Rows[itemcount - 1]["SUB_ID"] = 0;
            Itemdata[iCount - 1].Rows[itemcount - 1]["VERSATILE_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[iCount - 1]["SUB_ID"]);
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM_ID"] = 0;
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM_CODE"] = "";
            Itemdata[iCount - 1].Rows[itemcount - 1]["FULL_NAME"] = "";
            Itemdata[iCount - 1].Rows[itemcount - 1]["LIST_NO"] = itemcount;
          }
        }
        SubCount = Subdata.Rows.Count;
      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDefaultDataRow :" + ex.Message);
      }

    }

    private void SetGrid()
    {
      int i, NO = 0;

      #region gridSUB
      GridColumn colid1 = cls_Form.AddGridColumn("SUB_ID", "id", "SUB_ID", false, 0, 100);
      GridColumn colsubid = cls_Form.AddGridColumn("LIST_NO", "ลำดับที่", "LIST_NO", true, 0, 50);
      GridColumn colsubcode = cls_Form.AddGridColumn("SUB_CODE", "รหัสกลุ่มย่อย", "SUB_CODE", true, 1, 100);
      GridColumn colsubname = cls_Form.AddGridColumn("SUB_NAME", "ชื่อกลุ่มย่อย", "SUB_NAME", true, 2, 200);


      gridSub.BeginInit();
      gvSub.BeginInit();
      gvSub.Columns.Clear();
      colid1.Visible = false;

      colsubid.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colsubid.AppearanceHeader.Options.UseTextOptions = true;
      colsubid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colsubid.AppearanceCell.Options.UseTextOptions = true;
      colsubid.OptionsColumn.AllowEdit = false;
      colsubid.DisplayFormat.FormatString = "#,###";
      colsubid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      colsubid.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
      colsubid.SummaryItem.DisplayFormat = "{0:#,###} รายการ";


      colsubcode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colsubcode.AppearanceHeader.Options.UseTextOptions = true;
      colsubcode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      colsubcode.AppearanceCell.Options.UseTextOptions = true;
      colsubcode.OptionsColumn.AllowEdit = true;
      colsubcode.ColumnEdit = R_SubCode;
      R_SubCode.MaxLength = 5;

      colsubname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colsubname.AppearanceHeader.Options.UseTextOptions = true;
      colsubname.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      colsubname.AppearanceCell.Options.UseTextOptions = true;
      colsubname.OptionsColumn.AllowEdit = true;
      colsubname.ColumnEdit = R_SubName;
      R_SubName.MaxLength = 100;

      gvSub.Columns.AddRange(new GridColumn[] { colid1, colsubid, colsubcode, colsubname});

      gvSub.OptionsView.ShowGroupPanel = false;
      gvSub.OptionsBehavior.Editable = true;
      gvSub.OptionsSelection.EnableAppearanceFocusedCell = false;
      gvSub.OptionsView.EnableAppearanceEvenRow = false;
      gvSub.OptionsView.EnableAppearanceOddRow = true;
      gvSub.IndicatorWidth = -1;

      //gv.OptionsView.ColumnAutoWidth = false;
      gvSub.OptionsView.RowAutoHeight = true;
      gvSub.OptionsView.ShowAutoFilterRow = false;
      gvSub.OptionsFind.ShowCloseButton = false;
      gvSub.OptionsFind.AlwaysVisible = false;
      gvSub.OptionsView.ShowFooter = true;

      //colDesc.ColumnEdit = R_STK;

      gvSub.EndInit();
      gridSub.EndInit();
      #endregion

      #region gridItem
      gridItem.BeginInit();
      gvItem.BeginInit();

      this.colid1.OptionsColumn.AllowEdit = false;

      colitemid.Visible = false;

      colitem.OptionsColumn.AllowEdit = true;
      colitem.ColumnEdit = R_ItemCode;
      R_ItemCode.MaxLength = 8;

      coldesc.OptionsColumn.AllowEdit = true;
      colitem.ColumnEdit = R_ItemName;
      R_ItemCode.MaxLength = 50;

      coldesc.OptionsColumn.AllowEdit = true;


      gridItem.RepositoryItems.Add(R_ItemCode);

      gvItem.OptionsView.ShowGroupPanel = false;
      gvItem.OptionsBehavior.Editable = true;
      gvItem.OptionsSelection.EnableAppearanceFocusedCell = false;
      gvItem.OptionsView.EnableAppearanceEvenRow = false;
      gvItem.OptionsView.EnableAppearanceOddRow = true;
      gvItem.IndicatorWidth = -1;

      //gv.OptionsView.ColumnAutoWidth = false;
      gvItem.OptionsView.RowAutoHeight = true;
      gvItem.OptionsView.ShowAutoFilterRow = false;
      gvItem.OptionsFind.ShowCloseButton = false;
      gvItem.OptionsFind.AlwaysVisible = false;
      gvItem.OptionsView.ShowFooter = true;

      gvItem.EndInit();
      gridItem.EndInit();
      #endregion
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

    public frm_Versatiles_Record(cls_Struct.ActionMode mode, int id)
    {
      InitializeComponent();
      DataMode = mode;
      ItemID = id;
      this.KeyPreview = true;
      ThreadStart();
      R_ItemCode.MouseDown += new MouseEventHandler(R_ItemCode_MouseDown);
    }

    private void R_ItemCode_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        InitialListCode(3);
        gvItem.RefreshData();
        gridItem.RefreshDataSource();
        DataRow dr = gvItem.GetFocusedDataRow();
        if (dr == null) return;
        int irow = cls_Library.DBInt(dr["LIST_NO"]);
        if (irow == Itemdata[Subrow - 1].Rows.Count)
        {
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = gvItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
          gvItem.FocusedRowHandle = irow;
        }
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

      if (TxtItemCode.EditValue == null || TxtItemCode.Text == "")
      {
        XtraMessageBox.Show("กรุณาระบุรหัสกลุ่มสินค้าอเนกประสงค์", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtItemCode.ErrorText = "กรุณาระบุรหัสกลุ่มสินค้าอเนกประสงค์";
        TxtItemCode.Focus();
        err = true;
      }
      else
      {
        if (CheckCodeExist(TxtItemCode.Text.Trim()))
        {
          XtraMessageBox.Show("มีรหัสกลุ่มสินค้าอเนกประสงค์นี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtItemCode.ErrorText = "มีรหัสกลุ่มสินค้าอเนกประสงค์นี้ในฐานข้อมูลแล้ว";
          TxtItemCode.Focus();
          err = true;
        }

      }

      if (!err)
      {
        if (TxtItemName.EditValue == null || TxtItemName.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุชื่อกลุ่มสินค้าอเนกประสงค์", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtItemName.ErrorText = "กรุณาระบุชื่อกลุ่มสินค้าอเนกประสงค์";
          TxtItemName.Focus();
          err = true;
        }
      }

      //if (!err)
      //{
      //  if (Subdata.Rows.Count == 1)
      //  {
      //    XtraMessageBox.Show("กรุณากำหนดกลุ่มย่อย", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //    err = true;
      //  }
      //}

      //if (!err)
      //{
      //  int iCount = Subdata.Rows.Count;

      //  string Scap = "";
      //  bool Sok = true;

        
      //  for (int i = 0; i < (iCount - 1); i++)
      //  {
      //    Sok = true;
      //    if (cls_Library.DBString(Subdata.Rows[i]["SUB1_CODE"]) == "") Sok = false;
      //    if (cls_Library.DBString(Subdata.Rows[i]["SUB1_NAME"]) == "") Sok = false;
      //    if (cls_Library.DBString(Subdata.Rows[i]["SUB2_CODE"]) == "") Sok = false;
      //    if (cls_Library.DBString(Subdata.Rows[i]["SUB2_NAME"]) == "") Sok = false;
      //    if (!Sok)
      //    {
      //      Scap += "กลุ่มย่อยรายการที่ " + (i + 1) + " ยังไม่ได้ระบุข้อมูล " + Environment.NewLine;
      //    }
      //  }

      //  if (Scap.Length > 0)
      //  {
      //    XtraMessageBox.Show(Scap, "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //    err = true;
      //  }

      //}

      //if (!err)
      //{
      //  if (dsEdit.Tables["D_ITEMS_SPECIAL_ITEMS"].Rows.Count ==0)
      //  {
      //    XtraMessageBox.Show("ยังไม่ได้กำหนดรหัสสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //    err = true;
      //  }
      //}

      if (err)
      {
        return;
      }

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสกลุ่มสินค้าอเนกประสงค์ : " + TxtItemCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        if (SaveData())
        {
          XtraMessageBox.Show("บันทึกรหัสกลุ่มสินค้าอเนกประสงค์เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
          XtraMessageBox.Show("บันทึกรหัสกลุ่มสินค้าอเนกประสงค์ไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      
    }

    private void BTreset_Click(object sender, EventArgs e)
    {
      TxtItemName.Text = "";
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

    private void btSubAdd_Click(object sender, EventArgs e)
    {
      InitialDialogSub(0);
    }

    private void btSubEdit_Click(object sender, EventArgs e)
    {
      InitialDialogSub(1);
    }

    private void btSubDelete_Click(object sender, EventArgs e)
    {
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการ " + (Subrow) + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        DataRow Drow = gvSub.GetFocusedDataRow();
        if (Drow == null) return;
        int irow = gvSub.FocusedRowHandle;
        int Count = Subdata.Rows.Count;
        Subdata.AcceptChanges();
        Subdata.Rows[irow].Delete();
        Drow.Delete();
        Subdata.AcceptChanges();
        gvSub.RefreshData();
        gridItem.RefreshDataSource();

        for (int i = irow; i < (Count - 1); i++)
        {
          Itemdata[i] = Itemdata[i + 1].Copy();
        }

        Array.Resize(ref Itemdata, Count - 1);

        ResetNumberOfDataRow();

        irow = gvSub.FocusedRowHandle;

        if (irow >= 0)
        {
          gridItem.DataSource = Itemdata[irow];
          gridItem.RefreshDataSource();
        }
        else
        {
          gridItem.DataSource = null;
          gridItem.RefreshDataSource();
        }

      }
      CheckingObject();
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
        Itemdata[Subrow-1].AcceptChanges();
        Itemdata[Subrow - 1].Rows[irow].Delete();
        Drow.Delete();
        Itemdata[Subrow - 1].AcceptChanges();
        gvItem.RefreshData();
        gridItem.RefreshDataSource();
      }
      ResetNumberOfDataRow();
      CheckingObject();
    }

    private void TxtCompName_EditValueChanged(object sender, EventArgs e)
    {
      CheckingObject();
    }

    private void gvSub_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      Subrow = e.FocusedRowHandle + 1;

      if (SubCount <= 0) return;

      DataRow dr = gvSub.GetFocusedDataRow();
      if (dr == null) return;
      
      if (Subrow > 0)
      {
        if (Itemdata[Subrow -1] != null)
        {
          gridItem.DataSource = Itemdata[Subrow -1];
          gridItem.RefreshDataSource();

        }
      }
    }

    private void gridSub_ProcessGridKey(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        DataRow erow = gvSub.GetFocusedDataRow();
        if (erow == null) return;
        int iR = cls_Library.DBInt(erow["LIST_NO"]);
        if (iR == gvSub.RowCount)
        {
          //gvSub.PostEditor();
          //gvSub.UpdateCurrentRow();
          //gvSub.AddNewRow();
          //DataRow drow = gvSub.GetFocusedDataRow();
          //if (drow != null)
          //{
          //  drow["LIST_NO"] = gvSub.RowCount;
          //}

          //gvSub.FocusedColumn = gvSub.VisibleColumns[0];
          DataTable dtv = (DataTable)gridSub.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = gvSub.RowCount + 1;
          Subdata.ImportRow(dt.Rows[0]);
          AddDataRowSUB();
          gvSub.FocusedRowHandle = gvSub.RowCount;

        }
        
        if (gvSub.FocusedColumn.VisibleIndex == gvSub.VisibleColumns.Count - 1)
        {
          gvSub.FocusedRowHandle++;
          gvSub.FocusedColumn = gvSub.VisibleColumns[1];
        }
        else
        {
          gvSub.FocusedColumn = gvSub.GetVisibleColumn(gvSub.FocusedColumn.VisibleIndex + 1);
        }
      }
    }

    private void gridItem_ProcessGridKey(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        DataRow erow = gvItem.GetFocusedDataRow();
        if (erow == null) return;
        int iR = cls_Library.DBInt(erow["LIST_NO"]);
        if (iR == gvItem.RowCount)
        {

          //gvSub.FocusedColumn = gvSub.VisibleColumns[0];
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = gvItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
          gvItem.FocusedRowHandle = gvItem.RowCount;
        }

        if (gvItem.FocusedColumn.VisibleIndex == gvItem.VisibleColumns.Count - 1)
        {
          gvItem.FocusedRowHandle++;
          gvItem.FocusedColumn = gvItem.VisibleColumns[1];
        }
        else
        {
          gvItem.FocusedColumn = gvItem.GetVisibleColumn(gvItem.FocusedColumn.VisibleIndex + 1);
        }
      }
    }

    private void gvSub_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
      gridSub.RefreshDataSource();
      if (e.Value.ToString().Length > 0)
      {
        if ((e.RowHandle + 1) == gvSub.RowCount)
        {
          DataTable dtv = (DataTable)gridSub.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = gvSub.RowCount + 1;
          Subdata.ImportRow(dt.Rows[0]);
          AddDataRowSUB();
        }
      }
    }

    private void bandItem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
      gridItem.RefreshDataSource();
      if (e.Value.ToString().Length > 0)
      {
        if ((e.RowHandle + 1) == gvItem.RowCount)
        {
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = gvItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
        }
      }
      
    }


  }
}