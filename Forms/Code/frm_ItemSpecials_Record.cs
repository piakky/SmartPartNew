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
  public partial class frm_ItemSpecials_Record : DevExpress.XtraEditors.XtraForm
  {
    #region "  Variables declaration  "

    private BackgroundWorker _bwLoad = null;
    private BackgroundWorker _bwLoadCode = null;

    RepositoryItemTextEdit R_Sub1Code = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Sub1Name = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Sub2Code = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Sub2Name = new RepositoryItemTextEdit();

    RepositoryItemTextEdit R_Item1Code = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Item1Name = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Item1Desc = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Item2Code = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Item2Name = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Item2Desc = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Item3Code = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Item3Name = new RepositoryItemTextEdit();
    RepositoryItemTextEdit R_Item3Desc = new RepositoryItemTextEdit();

    private DataSet dsMainData = new DataSet();
    private DataSet dsEdit = new DataSet();
    DataSet DataS;
    DataTable Subdata = null;
    DataTable[] Itemdata = null;

    cls_Struct.ActionMode DataMode = 0;
    cls_Struct.StructItemSpecials Sitem;
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
          Itemdata[Srow - 1].Rows[itemcount - 1]["SEQUENSE_NO"] = 0;
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEMS_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[Srow - 1]["ITEMS_SUB_ID"]);
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM1_ID"] = 0;
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM1_CODE"] = "";
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM1_NAME"] = "";
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM2_ID"] = 0;
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM2_CODE"] = "";
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM2_NAME"] = "";
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM3_ID"] = 0;
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM3_CODE"] = "";
          Itemdata[Srow - 1].Rows[itemcount - 1]["ITEM3_NAME"] = "";
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
        Subdata.Rows[iCount - 1]["ITEMS_SPECIAL_ID"] = ItemID;
        Subdata.Rows[iCount - 1]["SUB1_ID"] = 0;
        Subdata.Rows[iCount - 1]["SUB1_CODE"] = "";
        Subdata.Rows[iCount - 1]["SUB1_NAME"] = "";
        Subdata.Rows[iCount - 1]["SUB2_ID"] = 0;
        Subdata.Rows[iCount - 1]["SUB2_CODE"] = "";
        Subdata.Rows[iCount - 1]["SUB2_NAME"] = "";
        Subdata.Rows[iCount - 1]["LIST_NO"] = iCount;

        Array.Resize(ref Itemdata, iCount);

        dt = new DataTable("D_ITEMS_SPECIALS_ITEMS");
        dt.Columns.Clear();
        dt.Columns.Add("SEQUENSE_NO", typeof(int));
        dt.Columns.Add("ITEMS_SUB_ID", typeof(int));
        dt.Columns.Add("ITEM1_ID", typeof(int));
        dt.Columns.Add("ITEM1_CODE", typeof(string));
        dt.Columns.Add("ITEM1_NAME", typeof(string));
        dt.Columns.Add("ITEM1_DESCRIPTION", typeof(string));
        dt.Columns.Add("ITEM2_ID", typeof(int));
        dt.Columns.Add("ITEM2_CODE", typeof(string));
        dt.Columns.Add("ITEM2_NAME", typeof(string));
        dt.Columns.Add("ITEM2_DESCRIPTION", typeof(string));
        dt.Columns.Add("ITEM3_ID", typeof(int));
        dt.Columns.Add("ITEM3_CODE", typeof(string));
        dt.Columns.Add("ITEM3_NAME", typeof(string));
        dt.Columns.Add("ITEM3_DESCRIPTION", typeof(string));
        dt.Columns.Add("LIST_NO", typeof(int));

        Itemdata[iCount - 1] = dt.Clone();

        int itemcount = Itemdata[iCount - 1].Rows.Count;
        for (int j = 0; j < 1; j++)
        {
          itemcount++;
          Itemdata[iCount - 1].Rows.Add();
          Itemdata[iCount - 1].Rows[itemcount - 1]["SEQUENSE_NO"] = 0;
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEMS_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[iCount - 1]["ITEMS_SUB_ID"]);
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM1_ID"] = 0;
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM1_CODE"] = "";
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM1_NAME"] = "";
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM2_ID"] = 0;
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM2_CODE"] = "";
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM2_NAME"] = "";
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM3_ID"] = 0;
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM3_CODE"] = "";
          Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM3_NAME"] = "";
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
      Sitem.ITEMS_SPECIAL_ID = ItemID;
      Sitem.ITEMS_SPECIAL_CODE = TxtItemCode.Text.Trim();
      Sitem.ITEMS_SPECIAL_NAME = TxtItemName.Text.Trim();
      Sitem.ITEMS_SPECIAL_DESCRIPTION = "";
      Sitem.ITEMS_SPECIAL_HEADER1 = TxtDesc1.Text.Trim();
      Sitem.ITEMS_SPECIAL_HEADER2 = TxtDesc2.Text.Trim();
      Sitem.ITEMS_SPECIAL_HEADER3 = TxtDesc3.Text.Trim();
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
        
        cls_Global_DB.GB_Ditem_Sub1 = 0;
        cls_Global_DB.GB_Ditem_Item = new int[0];

        cls_Global_DB.GB_Ditem_Sub1 = Subdata.Rows.Count-1;
        SubCount = Subdata.Rows.Count;
        gridSub.DataSource = Subdata;
        gridSub.RefreshDataSource();
        SetCaptionHeader(0);

        int irow = -1;

        for (int i = 0; i < cls_Global_DB.GB_Ditem_Sub1; i++)
        {
          irow++;
          Array.Resize(ref cls_Global_DB.GB_Ditem_Item, irow + 1);
          cls_Global_DB.GB_Ditem_Item[irow] = Itemdata[irow].Rows.Count -1;
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
      cmd.CommandText = "SELECT ITEMS_SPECIAL_ID,ITEMS_SPECIAL_CODE FROM M_ITEMS_SPECIALS WHERE ITEMS_SPECIAL_CODE='" + Xcode + "' And DELETED=0";
      cmd.Connection = conn;
      cmd.CommandTimeout = 30;
      cmd.CommandType = CommandType.Text;
      rd = cmd.ExecuteReader();
      if (rd.HasRows)
      {
        if ((DataMode == cls_Struct.ActionMode.Edit) || (DataMode == cls_Struct.ActionMode.Copy))
        {
          rd.Read();
          id = Convert.ToInt32(rd["ITEMS_SPECIAL_ID"]);
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
            frm.Text = "สินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 2";
            break;
          case 2:
            frm.Text = "สินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1";
            break;
          case 3:
          case 4:
          case 5:
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
                DataRow dr1 = gvSub.GetFocusedDataRow();
                dr1["SUB2_ID"] = cls_Library.DBInt(Xarr);
                dr1["SUB2_CODE"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS_SUB2", "SUB_CODE");
                dr1["SUB2_NAME"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS_SUB2", "SUB_NAME");
                dr1["SUB_DESCRIPTION1"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS_SUB2", "SUB_DESCRIPTION1");
                dr1["SUB_DESCRIPTION2"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS_SUB2", "SUB_DESCRIPTION2");
                dr1["SUB_DESCRIPTION3"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS_SUB2", "SUB_DESCRIPTION3");
                R_Sub2Code.NullText = cls_Library.DBString(dr1["SUB2_CODE"]);
                break;
              case 2:
                DataRow dr2 = gvSub.GetFocusedDataRow();
                dr2["SUB1_ID"] = cls_Library.DBInt(Xarr);
                dr2["SUB1_CODE"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS_SUB1", "SUB_CODE");
                dr2["SUB1_NAME"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS_SPECIALS_SUB1", "SUB_NAME");
                R_Sub1Code.NullText = cls_Library.DBString(dr2["SUB1_CODE"]);
                break;
              case 3:
                DataRow dr3 = bandItem.GetFocusedDataRow();
                dr3["ITEM1_ID"] = cls_Library.DBInt(Xarr);
                dr3["ITEM1_CODE"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS", "ITEM_CODE");
                dr3["ITEM1_NAME"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS", "FULL_NAME");
                R_Item1Code.NullText = cls_Library.DBString(dr3["ITEM1_CODE"]);
                
                break;
              case 4:
                DataRow dr4 = bandItem.GetFocusedDataRow();
                dr4["ITEM2_ID"] = cls_Library.DBInt(Xarr);
                dr4["ITEM2_CODE"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS", "ITEM_CODE");
                dr4["ITEM2_NAME"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS", "FULL_NAME");
                R_Item2Code.NullText = cls_Library.DBString(dr4["ITEM2_CODE"]);
                break;
              case 5:
                DataRow dr5 = bandItem.GetFocusedDataRow();
                dr5["ITEM3_ID"] = cls_Library.DBString(Xarr);
                dr5["ITEM3_CODE"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS", "ITEM_CODE");
                dr5["ITEM3_NAME"] = cls_Data.GetNameFromTBname(cls_Library.DBInt(Xarr), "ITEMS", "FULL_NAME");
                R_Item3Code.NullText = cls_Library.DBString(dr5["ITEM3_CODE"]);
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
      frmD_ItemSpecials_Item frmInput;
      DevExpress.XtraGrid.Views.BandedGrid.BandedGridView view;
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

      frmInput = new frmD_ItemSpecials_Item();
      frmInput.StartPosition = FormStartPosition.CenterParent;

      if (mode == 0)
        strMode = " [เพิ่ม]";
      else if (mode == 1)
        strMode = " [แก้ไข]";


      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)bandItem;
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
        frmInput.searchLookUpProduct1.Properties.DataSource = cls_Global_DB.DataInitialItemSpecial.Tables["M_ITEMS"];
        frmInput.searchLookUpProduct1.Properties.PopulateViewColumns();
        frmInput.searchLookUpProduct1.Properties.ValueMember = "_id";
        frmInput.searchLookUpProduct1.Properties.DisplayMember = "code";
        frmInput.searchLookUpProduct1.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpProduct1.Properties.View.Columns["code"].Caption = "รหัสสินค้า";
        frmInput.searchLookUpProduct1.Properties.View.Columns["name"].Caption = "ชื่อสินค้า";
        frmInput.searchLookUpProduct1.EditValue = null;
        frmInput.searchLookUpProduct2.Properties.DataSource = cls_Global_DB.DataInitialItemSpecial.Tables["M_ITEMS"];
        frmInput.searchLookUpProduct2.Properties.PopulateViewColumns();
        frmInput.searchLookUpProduct2.Properties.ValueMember = "_id";
        frmInput.searchLookUpProduct2.Properties.DisplayMember = "code";
        frmInput.searchLookUpProduct2.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpProduct2.Properties.View.Columns["code"].Caption = "รหัสสินค้า";
        frmInput.searchLookUpProduct2.Properties.View.Columns["name"].Caption = "ชื่อสินค้า";
        frmInput.searchLookUpProduct2.EditValue = null;
        frmInput.searchLookUpProduct3.Properties.DataSource = cls_Global_DB.DataInitialItemSpecial.Tables["M_ITEMS"];
        frmInput.searchLookUpProduct3.Properties.PopulateViewColumns();
        frmInput.searchLookUpProduct3.Properties.ValueMember = "_id";
        frmInput.searchLookUpProduct3.Properties.DisplayMember = "code";
        frmInput.searchLookUpProduct3.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpProduct3.Properties.View.Columns["code"].Caption = "รหัสสินค้า";
        frmInput.searchLookUpProduct3.Properties.View.Columns["name"].Caption = "ชื่อสินค้า";
        frmInput.searchLookUpProduct3.EditValue = null;
        if (dr != null)
        {
          DataTable dt = (DataTable)gridItem.DataSource;
          if ((mode == 1) || (mode == 2))
          {
            frmInput.searchLookUpProduct1.EditValue = null;
            if (cls_Library.DBInt(dr["ITEM1_ID"]) > 0) frmInput.searchLookUpProduct1.EditValue = cls_Library.DBInt(dr["ITEM1_ID"]);
            frmInput.TxtCode1.Text = cls_Library.DBString(dr["ITEM1_CODE"]);
            frmInput.TxtName1.Text = cls_Library.DBString(dr["ITEM1_NAME"]);
            frmInput.TxtDesc1.Text = cls_Library.DBString(dr["ITEM1_DESCRIPTION"]);
            frmInput.searchLookUpProduct2.EditValue = null;
            if (cls_Library.DBInt(dr["ITEM2_ID"]) > 0) frmInput.searchLookUpProduct2.EditValue = cls_Library.DBInt(dr["ITEM2_ID"]);
            frmInput.TxtCode2.Text = cls_Library.DBString(dr["ITEM2_CODE"]);
            frmInput.TxtName2.Text = cls_Library.DBString(dr["ITEM2_NAME"]);
            frmInput.TxtDesc2.Text = cls_Library.DBString(dr["ITEM2_DESCRIPTION"]);
            frmInput.searchLookUpProduct3.EditValue = null;
            if (cls_Library.DBInt(dr["ITEM3_ID"]) > 0) frmInput.searchLookUpProduct3.EditValue = cls_Library.DBInt(dr["ITEM3_ID"]);
            frmInput.TxtCode3.Text = cls_Library.DBString(dr["ITEM3_CODE"]);
            frmInput.TxtName3.Text = cls_Library.DBString(dr["ITEM3_NAME"]);
            frmInput.TxtDesc3.Text = cls_Library.DBString(dr["ITEM3_DESCRIPTION"]);
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
          Itemdata[Subrow - 1].Rows[irow]["ITEMS_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[Subrow - 1]["ITEMS_SUB_ID"]);
          Itemdata[Subrow - 1].Rows[irow]["ITEM1_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct1.EditValue);
          Itemdata[Subrow - 1].Rows[irow]["ITEM1_CODE"] = cls_Library.DBString(frmInput.TxtCode1.Text);
          Itemdata[Subrow - 1].Rows[irow]["ITEM1_NAME"] = cls_Library.DBString(frmInput.TxtName1.Text);
          Itemdata[Subrow - 1].Rows[irow]["ITEM1_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc1.Text);
          Itemdata[Subrow - 1].Rows[irow]["ITEM2_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct2.EditValue);
          Itemdata[Subrow - 1].Rows[irow]["ITEM2_CODE"] = cls_Library.DBString(frmInput.TxtCode2.Text);
          Itemdata[Subrow - 1].Rows[irow]["ITEM2_NAME"] = cls_Library.DBString(frmInput.TxtName2.Text);
          Itemdata[Subrow - 1].Rows[irow]["ITEM2_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc2.Text);
          Itemdata[Subrow - 1].Rows[irow]["ITEM3_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct3.EditValue);
          Itemdata[Subrow - 1].Rows[irow]["ITEM3_CODE"] = cls_Library.DBString(frmInput.TxtCode3.Text);
          Itemdata[Subrow - 1].Rows[irow]["ITEM3_NAME"] = cls_Library.DBString(frmInput.TxtName3.Text);
          Itemdata[Subrow - 1].Rows[irow]["ITEM3_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc3.Text);
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = bandItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
          bandItem.FocusedRowHandle = irow;
        }
        else
        {
          view = (DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)bandItem;
          dr = view.GetFocusedDataRow();
          dr["ITEMS_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[Subrow - 1]["ITEMS_SUB_ID"]);
          dr["ITEM1_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct1.EditValue);
          dr["ITEM1_CODE"] = cls_Library.DBString(frmInput.TxtCode1.Text);
          dr["ITEM1_NAME"] = cls_Library.DBString(frmInput.TxtName1.Text);
          dr["ITEM1_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc1.Text);
          dr["ITEM2_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct2.EditValue);
          dr["ITEM2_CODE"] = cls_Library.DBString(frmInput.TxtCode2.Text);
          dr["ITEM2_NAME"] = cls_Library.DBString(frmInput.TxtName2.Text);
          dr["ITEM2_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc2.Text);
          dr["ITEM3_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct3.EditValue);
          dr["ITEM3_CODE"] = cls_Library.DBString(frmInput.TxtCode3.Text);
          dr["ITEM3_NAME"] = cls_Library.DBString(frmInput.TxtName3.Text);
          dr["ITEM3_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDesc3.Text);
          irow = cls_Library.DBInt(dr["LIST_NO"]);
          if (irow == Itemdata[Subrow - 1].Rows.Count)
          {
            DataTable dtv = (DataTable)gridItem.DataSource;
            DataTable dt = dtv.Clone();
            dt.Rows.Add();
            dt.Rows[0]["LIST_NO"] = bandItem.RowCount + 1;
            Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
            AddDataRowItem(Subrow);
            bandItem.FocusedRowHandle = irow;
          }
        }
        Itemdata[Subrow - 1].EndInit();
        gridItem.DataSource = Itemdata[Subrow - 1];
        gridItem.RefreshDataSource();
        SetCaptionHeader(Subrow - 1);
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
      frmD_ItemSpecials_Sub frmInput;
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

      frmInput = new frmD_ItemSpecials_Sub();
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
        frmInput.searchLookUpSub2.Properties.DataSource = cls_Global_DB.DataInitialItemSpecial.Tables["M_ITEMS_SPECIALS_SUB2"];
        frmInput.searchLookUpSub2.Properties.PopulateViewColumns();
        frmInput.searchLookUpSub2.Properties.ValueMember = "_id";
        frmInput.searchLookUpSub2.Properties.DisplayMember = "code";
        frmInput.searchLookUpSub2.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpSub2.Properties.View.Columns["code"].Caption = "รหัสกลุ่มย่อยระดับที่ 2";
        frmInput.searchLookUpSub2.Properties.View.Columns["name"].Caption = "ชื่อกลุ่มย่อยระดับที่ 2";
        //frmInput.searchLookUpSub2.Properties.View.Columns["description"].Caption = "รายละเอียด";
        frmInput.searchLookUpSub2.EditValue = null;
        frmInput.searchLookUpSub1.Properties.DataSource = cls_Global_DB.DataInitialItemSpecial.Tables["M_ITEMS_SPECIALS_SUB1"];
        
        frmInput.searchLookUpSub1.Properties.PopulateViewColumns();
        frmInput.searchLookUpSub1.Properties.ValueMember = "_id";
        frmInput.searchLookUpSub1.Properties.DisplayMember = "code";
        frmInput.searchLookUpSub1.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpSub1.Properties.View.Columns["code"].Caption = "รหัสกลุ่มย่อยระดับที่ 1";
        frmInput.searchLookUpSub1.Properties.View.Columns["name"].Caption = "ชื่อกลุ่มย่อยระดับที่ 1";
        //frmInput.searchLookUpSub1.Properties.View.Columns["description"].Caption = "รายละเอียด";
        frmInput.searchLookUpSub1.EditValue = null;
        if (dr != null)
        {
          DataTable dt = (DataTable)gridItem.DataSource;
          if ((mode == 1) || (mode == 2))
          {
            frmInput.searchLookUpSub2.Properties.DataSource = cls_Data.GetDataTable("M_ITEMS_SPECIALS_SUB1", 0, cls_Library.DBString(dr["SUB1_CODE"]));
            frmInput.searchLookUpSub2.EditValue = null;
            if (cls_Library.DBInt(dr["SUB2_ID"]) > 0) frmInput.searchLookUpSub2.EditValue = cls_Library.DBInt(dr["SUB2_ID"]);
            frmInput.TxtCodeSub2.Text = cls_Library.DBString(dr["SUB2_CODE"]);
            frmInput.TxtNameSub2.Text = cls_Library.DBString(dr["SUB2_NAME"]);
            frmInput.searchLookUpSub1.Properties.DataSource = cls_Data.GetDataTable("M_ITEMS_SPECIALS_SUB1", 0, TxtItemCode.Text.Trim());
            frmInput.searchLookUpSub1.EditValue = null;
            if (cls_Library.DBInt(dr["SUB1_ID"]) > 0) frmInput.searchLookUpSub1.EditValue = cls_Library.DBInt(dr["SUB1_ID"]);
            frmInput.TxtCodeSub1.Text = cls_Library.DBString(dr["SUB1_CODE"]);
            frmInput.TxtNameSub1.Text = cls_Library.DBString(dr["SUB1_NAME"]);
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
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          irow = (Subdata.Rows.Count) - 1;
          if (irow < 0) irow = 0;
          Subdata.Rows[irow]["ITEMS_SPECIAL_ID"] = ItemID;
          Subdata.Rows[irow]["SUB2_ID"] = cls_Library.DBInt(frmInput.searchLookUpSub2.EditValue);
          Subdata.Rows[irow]["SUB2_CODE"] = cls_Library.DBString(frmInput.TxtCodeSub2.Text);
          Subdata.Rows[irow]["SUB2_NAME"] = cls_Library.DBString(frmInput.TxtNameSub2.Text);
          Subdata.Rows[irow]["SUB1_ID"] = cls_Library.DBInt(frmInput.searchLookUpSub1.EditValue);
          Subdata.Rows[irow]["SUB1_CODE"] = cls_Library.DBString(frmInput.TxtCodeSub1.Text);
          Subdata.Rows[irow]["SUB1_NAME"] = cls_Library.DBString(frmInput.TxtNameSub1.Text);
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
          dr["ITEMS_SPECIAL_ID"] = ItemID;
          dr["SUB2_ID"] = cls_Library.DBInt(frmInput.searchLookUpSub2.EditValue);
          dr["SUB2_CODE"] = cls_Library.DBString(frmInput.TxtCodeSub2.Text);
          dr["SUB2_NAME"] = cls_Library.DBString(frmInput.TxtNameSub2.Text);
          dr["SUB1_ID"] = cls_Library.DBInt(frmInput.searchLookUpSub1.EditValue);
          dr["SUB1_CODE"] = cls_Library.DBString(frmInput.TxtCodeSub1.Text);
          dr["SUB1_NAME"] = cls_Library.DBString(frmInput.TxtNameSub1.Text);
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
        sql = "Select * From M_ITEMS_SPECIALS Where ITEMS_SPECIAL_ID=@ITEMS_SPECIAL_ID and DELETED=0";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.Parameters.Add("@ITEMS_SPECIAL_ID", SqlDbType.Int).Value = ItemID;
        da.SelectCommand.CommandTimeout = 1200;
        dt = new DataTable("M_ITEMS_SPECIALS");
        da.Fill(dt);
        dsMainData.Tables.Add(dt);

        sql = "Select * From D_ITEMS_SPECIALS_SUB Where ITEMS_SPECIAL_ID=@ITEMS_SPECIAL_ID and DELETED=0 order by LIST_NO";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.Parameters.Add("@ITEMS_SPECIAL_ID", SqlDbType.Int).Value = ItemID;
        da.SelectCommand.CommandTimeout = 1200;
        dt = new DataTable("D_ITEMS_SPECIALS_SUB");
        da.Fill(dt);

        Subdata = dt;

        SubCount = -1;
        

        for (int i = 0; i < Subdata.Rows.Count; i++)
        {
          drow = Subdata.Rows[i];
          int ID = cls_Library.DBInt(drow["ITEMS_SUB_ID"]);

          SubCount ++;
          Array.Resize(ref Itemdata, SubCount + 1);

          Itemdata[SubCount] = new DataTable("D_ITEMS_SPECIALS_ITEMS");
          Itemdata[SubCount].Columns.Clear();
          Itemdata[SubCount].Columns.Add("SEQUENSE_NO", typeof(int));
          Itemdata[SubCount].Columns.Add("ITEMS_SUB_ID", typeof(int));
          Itemdata[SubCount].Columns.Add("ITEM1_ID", typeof(int));
          Itemdata[SubCount].Columns.Add("ITEM1_CODE", typeof(string));
          Itemdata[SubCount].Columns.Add("ITEM1_NAME", typeof(string));
          Itemdata[SubCount].Columns.Add("ITEM1_DESCRIPTION", typeof(string));
          Itemdata[SubCount].Columns.Add("ITEM2_ID", typeof(int));
          Itemdata[SubCount].Columns.Add("ITEM2_CODE", typeof(string));
          Itemdata[SubCount].Columns.Add("ITEM2_NAME", typeof(string));
          Itemdata[SubCount].Columns.Add("ITEM2_DESCRIPTION", typeof(string));
          Itemdata[SubCount].Columns.Add("ITEM3_ID", typeof(int));
          Itemdata[SubCount].Columns.Add("ITEM3_CODE", typeof(string));
          Itemdata[SubCount].Columns.Add("ITEM3_NAME", typeof(string));
          Itemdata[SubCount].Columns.Add("ITEM3_DESCRIPTION", typeof(string));
          Itemdata[SubCount].Columns.Add("LIST_NO", typeof(int));

          sql = "Select SEQUENSE_NO, ITEMS_SUB_ID, ITEM1_ID, ITEM1_CODE, ITEM1_NAME, ITEM1_DESCRIPTION, ITEM2_ID, ITEM2_CODE, ITEM2_NAME, ITEM2_DESCRIPTION, ITEM3_ID, ITEM3_CODE, ITEM3_NAME, ITEM3_DESCRIPTION,";
          sql += " LIST_NO From D_ITEMS_SPECIALS_ITEMS Where ITEMS_SUB_ID=@ITEMS_SUB_ID and DELETED=0 order by LIST_NO";
          da = new SqlDataAdapter(sql, cn);
          da.SelectCommand.Parameters.Clear();
          da.SelectCommand.Parameters.Add("@ITEMS_SUB_ID", SqlDbType.Int).Value = ID;
          da.SelectCommand.CommandTimeout = 300;
          da.Fill(Itemdata[SubCount]);
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
        cls_Global_DB.GB_ItemID = 0;
        ret = cls_Data.SaveItemSpecialCode(SaveMode, Sitem,Subdata,Itemdata);
        ItemID = cls_Global_DB.GB_ItemID;
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
          XtraMessageBox.Show("ไม่สามารถบันทึกรหัสกลุ่มสินค้าใช้ด้วยกันได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ret = false;
      }

      return ret;
    }

    private void SetCaptionHeader(int srow)
    {
      TxtDesc1.Text = "";
      TxtDesc2.Text = "";
      TxtDesc3.Text = "";
      gbHeadText1.Caption = "";
      gbHeadText2.Caption = "";
      gbHeadText3.Caption = "";

      if (srow < 0) return;

      TxtDesc1.Text = cls_Library.DBString(Subdata.Rows[srow]["SUB_DESCRIPTION1"]);
      TxtDesc2.Text = cls_Library.DBString(Subdata.Rows[srow]["SUB_DESCRIPTION2"]);
      TxtDesc3.Text = cls_Library.DBString(Subdata.Rows[srow]["SUB_DESCRIPTION3"]);
      gbHeadText1.Caption = cls_Library.DBString(Subdata.Rows[srow]["SUB_DESCRIPTION1"]);
      gbHeadText2.Caption = cls_Library.DBString(Subdata.Rows[srow]["SUB_DESCRIPTION2"]);
      gbHeadText3.Caption = cls_Library.DBString(Subdata.Rows[srow]["SUB_DESCRIPTION3"]);
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
            TxtItemCode.Text = cls_Data.GetLastCodeMaster("ITEMS_SPECIALS", 3);
            break;
          case cls_Struct.ActionMode.Edit:
          case cls_Struct.ActionMode.Copy:
            if (dsEdit.Tables["M_ITEMS_SPECIALS"].Rows.Count <= 0) return;
            row = dsEdit.Tables["M_ITEMS_SPECIALS"].Rows[0];
            TxtItemCode.Text = cls_Library.DBString(row["ITEMS_SPECIAL_CODE"]);
            TxtItemName.Text = cls_Library.DBString(row["ITEMS_SPECIAL_NAME"]);
            TxtDesc1.Text = cls_Library.DBString(row["ITEMS_SPECIAL_HEADER1"]);
            TxtDesc2.Text = cls_Library.DBString(row["ITEMS_SPECIAL_HEADER2"]);
            TxtDesc3.Text = cls_Library.DBString(row["ITEMS_SPECIAL_HEADER3"]);
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
          Subdata.Rows[i]["ITEMS_SPECIAL_ID"] = ItemID;
          //Subdata.Rows[i]["SUB1_ID"] = 0;
          //Subdata.Rows[i]["SUB1_CODE"] = "";
          //Subdata.Rows[i]["SUB1_NAME"] = "";
          //Subdata.Rows[i]["SUB2_ID"] = 0;
          //Subdata.Rows[i]["SUB2_CODE"] = "";
          //Subdata.Rows[i]["SUB2_NAME"] = "";
          Subdata.Rows[i]["LIST_NO"] = i+1;

          int itemcount = Itemdata[i].Rows.Count;
          for (int j = 0; j < 12; j++)
          {
            itemcount++;
            Itemdata[i].Rows.Add();
            Itemdata[i].Rows[itemcount - 1]["SEQUENSE_NO"] = 0;
            Itemdata[i].Rows[itemcount - 1]["ITEMS_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[iCount - 1]["ITEMS_SUB_ID"]);
            Itemdata[i].Rows[itemcount - 1]["ITEM1_ID"] = 0;
            Itemdata[i].Rows[itemcount - 1]["ITEM1_CODE"] = "";
            Itemdata[i].Rows[itemcount - 1]["ITEM1_NAME"] = "";
            Itemdata[i].Rows[itemcount - 1]["ITEM2_ID"] = 0;
            Itemdata[i].Rows[itemcount - 1]["ITEM2_CODE"] = "";
            Itemdata[i].Rows[itemcount - 1]["ITEM2_NAME"] = "";
            Itemdata[i].Rows[itemcount - 1]["ITEM3_ID"] = 0;
            Itemdata[i].Rows[itemcount - 1]["ITEM3_CODE"] = "";
            Itemdata[i].Rows[itemcount - 1]["ITEM3_NAME"] = "";
            Itemdata[i].Rows[itemcount - 1]["LIST_NO"] = itemcount;
          }
        }

        for (int i = 0; i < 12; i++)
        {
          iCount++;
          //SubCount = iCount;
          Subdata.Rows.Add();
          Subdata.Rows[iCount - 1]["ITEMS_SPECIAL_ID"] = ItemID;
          Subdata.Rows[iCount - 1]["SUB1_ID"] = 0;
          Subdata.Rows[iCount - 1]["SUB1_CODE"] = "";
          Subdata.Rows[iCount - 1]["SUB1_NAME"] = "";
          Subdata.Rows[iCount - 1]["SUB2_ID"] = 0;
          Subdata.Rows[iCount - 1]["SUB2_CODE"] = "";
          Subdata.Rows[iCount - 1]["SUB2_NAME"] = "";
          Subdata.Rows[iCount - 1]["LIST_NO"] = iCount;

          Array.Resize(ref Itemdata, iCount);

          dt = new DataTable("D_ITEMS_SPECIALS_ITEMS");
          dt.Columns.Clear();
          dt.Columns.Add("SEQUENSE_NO", typeof(int));
          dt.Columns.Add("ITEMS_SUB_ID", typeof(int));
          dt.Columns.Add("ITEM1_ID", typeof(int));
          dt.Columns.Add("ITEM1_CODE", typeof(string));
          dt.Columns.Add("ITEM1_NAME", typeof(string));
          dt.Columns.Add("ITEM1_DESCRIPTION", typeof(string));
          dt.Columns.Add("ITEM2_ID", typeof(int));
          dt.Columns.Add("ITEM2_CODE", typeof(string));
          dt.Columns.Add("ITEM2_NAME", typeof(string));
          dt.Columns.Add("ITEM2_DESCRIPTION", typeof(string));
          dt.Columns.Add("ITEM3_ID", typeof(int));
          dt.Columns.Add("ITEM3_CODE", typeof(string));
          dt.Columns.Add("ITEM3_NAME", typeof(string));
          dt.Columns.Add("ITEM3_DESCRIPTION", typeof(string));
          dt.Columns.Add("LIST_NO", typeof(int));

          Itemdata[iCount - 1] = dt.Clone();

          int itemcount = Itemdata[iCount - 1].Rows.Count;
          for (int j = 0; j < 12; j++)
          {
            itemcount++;
            Itemdata[iCount - 1].Rows.Add();
            Itemdata[iCount - 1].Rows[itemcount - 1]["SEQUENSE_NO"] = 0;
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEMS_SUB_ID"] = cls_Library.DBInt(Subdata.Rows[iCount - 1]["ITEMS_SUB_ID"]);
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM1_ID"] = 0;
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM1_CODE"] = "";
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM1_NAME"] = "";
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM2_ID"] = 0;
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM2_CODE"] = "";
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM2_NAME"] = "";
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM3_ID"] = 0;
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM3_CODE"] = "";
            Itemdata[iCount - 1].Rows[itemcount - 1]["ITEM3_NAME"] = "";
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
      GridColumn colid1 = cls_Form.AddGridColumn("SUB1_ID", "id", "SUB1_ID", false, 0, 100);
      GridColumn colid2 = cls_Form.AddGridColumn("SUB2_ID", "id", "SUB2_ID", false, 0, 100);
      GridColumn colid = cls_Form.AddGridColumn("LIST_NO", "ลำดับที่", "LIST_NO", true, 0, 50);
      GridColumn colsub2code = cls_Form.AddGridColumn("SUB2_CODE", "รหัสกลุ่มย่อยระดับที่ 2", "SUB2_CODE", true, 1, 100);
      GridColumn colsub2name = cls_Form.AddGridColumn("SUB2_NAME", "ชื่อกลุ่มย่อยระดับที่ 2", "SUB2_NAME", true, 2, 150);
      GridColumn colsub1code = cls_Form.AddGridColumn("SUB1_CODE", "รหัสกลุ่มย่อยระดับที่ 1", "SUB1_CODE", true, 3, 100);
      GridColumn colsub1name = cls_Form.AddGridColumn("SUB1_NAME", "ชื่อกลุ่มย่อยระดับที่ 1", "SUB1_NAME", true, 4, 150);


      gridSub.BeginInit();
      gvSub.BeginInit();
      gvSub.Columns.Clear();
      colid1.Visible = false;
      colid2.Visible = false;

      colid.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colid.AppearanceHeader.Options.UseTextOptions = true;
      colid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colid.AppearanceCell.Options.UseTextOptions = true;
      colid.OptionsColumn.AllowEdit = false;
      colid.DisplayFormat.FormatString = "#,###";
      colid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      colid.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
      colid.SummaryItem.DisplayFormat = "{0:#,###} รายการ";


      colsub2code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colsub2code.AppearanceHeader.Options.UseTextOptions = true;
      colsub2code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      colsub2code.AppearanceCell.Options.UseTextOptions = true;
      colsub2code.OptionsColumn.AllowEdit = true;
      colsub2code.ColumnEdit = R_Sub2Code;
      R_Sub2Code.MaxLength = 3;

      colsub2name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colsub2name.AppearanceHeader.Options.UseTextOptions = true;
      colsub2name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      colsub2name.AppearanceCell.Options.UseTextOptions = true;
      colsub2name.OptionsColumn.AllowEdit = true;
      colsub2name.ColumnEdit = R_Sub2Name;
      R_Sub2Name.MaxLength = 100;

      colsub1code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colsub1code.AppearanceHeader.Options.UseTextOptions = true;
      colsub1code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      colsub1code.AppearanceCell.Options.UseTextOptions = true;
      colsub1code.OptionsColumn.AllowEdit = true;
      colsub1code.ColumnEdit = R_Sub1Code;
      R_Sub1Code.MaxLength = 3;

      colsub1name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colsub1name.AppearanceHeader.Options.UseTextOptions = true;
      colsub1name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      colsub1name.AppearanceCell.Options.UseTextOptions = true;
      colsub1name.OptionsColumn.AllowEdit = true;
      colsub1name.ColumnEdit = R_Sub1Name;
      R_Sub1Name.MaxLength = 100;

      gvSub.Columns.AddRange(new GridColumn[] { colid1, colid2, colid, colsub2code, colsub2name, colsub1code, colsub1name});
      gridSub.RepositoryItems.Add(R_Sub2Code);
      gridSub.RepositoryItems.Add(R_Sub2Name);
      gridSub.RepositoryItems.Add(R_Sub1Code);
      gridSub.RepositoryItems.Add(R_Sub1Name);

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
      bandItem.BeginInit();

      gbHeadText1.Caption = TxtDesc1.Text.Trim();
      gbHeadText2.Caption = TxtDesc2.Text.Trim();
      gbHeadText3.Caption = TxtDesc3.Text.Trim();

      colitemid.OptionsColumn.AllowEdit = false;

      coldesc1.OptionsColumn.AllowEdit = true;
      coldesc1.ColumnEdit = R_Item1Name;
      R_Item1Name.MaxLength = 100;

      coldesc2.OptionsColumn.AllowEdit = true;
      coldesc2.ColumnEdit = R_Item1Desc;
      R_Item1Desc.MaxLength = 100;

      colitem1.OptionsColumn.AllowEdit = true;
      colitem1.ColumnEdit = R_Item1Code;
      R_Item1Code.MaxLength = 8;

      coldesc3.OptionsColumn.AllowEdit = true;
      coldesc3.ColumnEdit = R_Item2Name;
      R_Item2Name.MaxLength = 100;

      coldesc4.OptionsColumn.AllowEdit = true;
      coldesc4.ColumnEdit = R_Item2Desc;
      R_Item2Desc.MaxLength = 100;

      colitem2.OptionsColumn.AllowEdit = true;
      colitem2.ColumnEdit = R_Item2Code;
      R_Item2Code.MaxLength = 8;

      coldesc5.OptionsColumn.AllowEdit = true;
      coldesc5.ColumnEdit = R_Item3Name;
      R_Item3Name.MaxLength = 100;

      coldesc6.OptionsColumn.AllowEdit = true;
      coldesc6.ColumnEdit = R_Item3Desc;
      R_Item3Desc.MaxLength = 100;

      colitem3.OptionsColumn.AllowEdit = true;
      colitem3.ColumnEdit = R_Item3Code;
      R_Item3Code.MaxLength = 8;


      gridItem.RepositoryItems.Add(R_Item1Code);
      gridItem.RepositoryItems.Add(R_Item1Name);
      gridItem.RepositoryItems.Add(R_Item1Desc);
      gridItem.RepositoryItems.Add(R_Item2Code);
      gridItem.RepositoryItems.Add(R_Item2Name);
      gridItem.RepositoryItems.Add(R_Item2Desc);
      gridItem.RepositoryItems.Add(R_Item3Code);
      gridItem.RepositoryItems.Add(R_Item3Name);
      gridItem.RepositoryItems.Add(R_Item3Desc);

      bandItem.OptionsView.ShowGroupPanel = false;
      bandItem.OptionsBehavior.Editable = true;
      bandItem.OptionsSelection.EnableAppearanceFocusedCell = false;
      bandItem.OptionsView.EnableAppearanceEvenRow = false;
      bandItem.OptionsView.EnableAppearanceOddRow = true;
      bandItem.IndicatorWidth = -1;

      //gv.OptionsView.ColumnAutoWidth = false;
      bandItem.OptionsView.RowAutoHeight = true;
      bandItem.OptionsView.ShowAutoFilterRow = false;
      bandItem.OptionsFind.ShowCloseButton = false;
      bandItem.OptionsFind.AlwaysVisible = false;
      bandItem.OptionsView.ShowFooter = true;

      bandItem.EndInit();
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

    public frm_ItemSpecials_Record(cls_Struct.ActionMode mode, int id)
    {
      InitializeComponent();
      DataMode = mode;
      ItemID = id;
      this.KeyPreview = true;
      ThreadStart();
      R_Sub1Code.MouseDown += new MouseEventHandler(R_Sub1Code_MouseDown);
      R_Sub2Code.MouseDown += new MouseEventHandler(R_Sub2Code_MouseDown);
      R_Item1Code.MouseDown += new MouseEventHandler(R_Item1Code_MouseDown);
      R_Item2Code.MouseDown += new MouseEventHandler(R_Item2Code_MouseDown);
      R_Item3Code.MouseDown += new MouseEventHandler(R_Item3Code_MouseDown);
    }

    private void R_Sub1Code_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        string S1code = TxtItemCode.Text.Trim();
        if (DataMode == cls_Struct.ActionMode.Add) S1code = "";
        InitialListCode(2, S1code);
        gvSub.RefreshData();
        gridSub.RefreshDataSource();
        DataRow dr = gvSub.GetFocusedDataRow();
        if (dr == null) return;
        int irow = cls_Library.DBInt(dr["LIST_NO"]);
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
    }

    private void R_Sub2Code_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        DataRow dr = gvSub.GetFocusedDataRow();
        if (dr == null) return;
        string S1code = cls_Library.DBString(dr["SUB1_CODE"]);
        InitialListCode(1, S1code);
        gvSub.RefreshData();
        gridSub.RefreshDataSource();
        dr = gvSub.GetFocusedDataRow();
        int irow = cls_Library.DBInt(dr["LIST_NO"]);
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
        SetCaptionHeader(irow-1);
      }
    }

    private void R_Item1Code_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        InitialListCode(3);
        bandItem.RefreshData();
        gridItem.RefreshDataSource();
        DataRow dr = bandItem.GetFocusedDataRow();
        if (dr == null) return;
        int irow = cls_Library.DBInt(dr["LIST_NO"]);
        if (irow == Itemdata[Subrow - 1].Rows.Count)
        {
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = bandItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
          bandItem.FocusedRowHandle = irow;
        }
      }
    }

    private void R_Item2Code_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        InitialListCode(4);
        bandItem.RefreshData();
        gridItem.RefreshDataSource();
        DataRow dr = bandItem.GetFocusedDataRow();
        if (dr == null) return;
        int irow = cls_Library.DBInt(dr["LIST_NO"]);
        if (irow == Itemdata[Subrow - 1].Rows.Count)
        {
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = bandItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
          bandItem.FocusedRowHandle = irow;
        }
      }
    }

    private void R_Item3Code_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        InitialListCode(5);
        bandItem.RefreshData();
        gridItem.RefreshDataSource();
        DataRow dr = bandItem.GetFocusedDataRow();
        if (dr == null) return;
        int irow = cls_Library.DBInt(dr["LIST_NO"]);
        if (irow == Itemdata[Subrow - 1].Rows.Count)
        {
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = bandItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
          bandItem.FocusedRowHandle = irow;
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
        XtraMessageBox.Show("กรุณาระบุรหัสกลุ่มสินค้าเฉพาะ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
        TxtItemCode.ErrorText = "กรุณาระบุรหัสกลุ่มสินค้าเฉพาะ";
        TxtItemCode.Focus();
        err = true;
      }
      else
      {
        if (CheckCodeExist(TxtItemCode.Text.Trim()))
        {
          XtraMessageBox.Show("มีรหัสกลุ่มสินค้าเฉพาะนี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtItemCode.ErrorText = "มีรหัสกลุ่มสินค้าเฉพาะนี้ในฐานข้อมูลแล้ว";
          TxtItemCode.Focus();
          err = true;
        }

      }

      if (!err)
      {
        if (TxtItemName.EditValue == null || TxtItemName.Text == "")
        {
          XtraMessageBox.Show("กรุณาระบุชื่อกลุ่มสินค้าเฉพาะ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
          TxtItemName.ErrorText = "กรุณาระบุชื่อกลุ่มสินค้าเฉพาะ";
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

      DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสกลุ่มสินค้าเฉพาะ : " + TxtItemCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
      DataRow Drow = bandItem.GetFocusedDataRow();
      if (Drow == null) return;
      int irow = bandItem.FocusedRowHandle;
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        Itemdata[Subrow-1].AcceptChanges();
        Itemdata[Subrow - 1].Rows[irow].Delete();
        Drow.Delete();
        Itemdata[Subrow - 1].AcceptChanges();
        bandItem.RefreshData();
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
      SetCaptionHeader(Subrow - 1);
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
        DataRow erow = bandItem.GetFocusedDataRow();
        if (erow == null) return;
        int iR = cls_Library.DBInt(erow["LIST_NO"]);
        if (iR == bandItem.RowCount)
        {

          //gvSub.FocusedColumn = gvSub.VisibleColumns[0];
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = bandItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
          bandItem.FocusedRowHandle = bandItem.RowCount;
        }

        if (bandItem.FocusedColumn.VisibleIndex == bandItem.VisibleColumns.Count - 1)
        {
          bandItem.FocusedRowHandle++;
          bandItem.FocusedColumn = bandItem.VisibleColumns[1];
        }
        else
        {
          bandItem.FocusedColumn = bandItem.GetVisibleColumn(bandItem.FocusedColumn.VisibleIndex + 1);
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
        if ((e.RowHandle + 1) == bandItem.RowCount)
        {
          DataTable dtv = (DataTable)gridItem.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["LIST_NO"] = bandItem.RowCount + 1;
          Itemdata[Subrow - 1].ImportRow(dt.Rows[0]);
          AddDataRowItem(Subrow);
        }
      }
      
    }

    private void TxtDesc1_EditValueChanged(object sender, EventArgs e)
    {
      gbHeadText1.Caption = TxtDesc1.Text.Trim();
    }

    private void TxtDesc2_EditValueChanged(object sender, EventArgs e)
    {
      gbHeadText2.Caption = TxtDesc2.Text.Trim();
    }

    private void TxtDesc3_EditValueChanged(object sender, EventArgs e)
    {
      gbHeadText3.Caption = TxtDesc3.Text.Trim();
    }
  }
}