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

namespace SmartPart.Forms.General
{
  public partial class frm_Group_Vers : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private DataSet dsData = new DataSet();
    private DataTable dtSub = new DataTable();
    private DataTable dtItem = new DataTable();
    private byte DataMode = 0;
    private byte DataType = 0;
    private int GroupID = 0;
    private int CurrentGroubID = 0;
    private int CurrentSubID = 0;
    private int Datarowchange = 0;
    private int tmpID = 0;
    private List<DataRow> listSub = new List<DataRow>();
    private List<DataRow> listItem = new List<DataRow>();
    private string tbGroup = string.Empty;
    private string tbSub = string.Empty;
    private string tbItem = string.Empty;
    private int ItemId;

    DataTable[] Itemdata = null;
    int SubCount = 0;
    int Subrow = 1;
    #endregion

    #region Property
    public int ItemID
    {
        set { ItemId = value; }
    }
    #endregion

    #region Function

    private void AddItem()
    {
      Int16 max = 0;
      try
      {
        if (dtItem.Rows.Count > 0)
        {
          max = dtItem.AsEnumerable().Where(row => row.Field<int>("VERSATILE_SUB_ID") == CurrentSubID).Max(row => row.Field<Int16>("LIST_NO"));
        }
        else
        {
          max = 1;
        }
                

        string Fname = cls_Data.GetNameFromTBname(ItemId, "ITEMS", "FULL_NAME");
        string Fcode = cls_Data.GetNameFromTBname(ItemId, "ITEMS", "ITEM_CODE");

        int subid = cls_Data.AddItemInVersatile(CurrentSubID, ItemId, max, Fcode, Fname);
        if (subid <= 0) return;

        DataTable dtv = (DataTable)gridItem.DataSource;
        DataTable dt = dtv.Clone();
        dt.Rows.Add();
        dt.Rows[0]["VERSATILE_SUB_ID"] = CurrentSubID;
        dt.Rows[0]["LIST_NO"] = max;
        dt.Rows[0]["ITEM_ID"] = ItemId;
        dt.Rows[0]["ITEM_CODE"] = Fcode;
        dt.Rows[0]["FULL_NAME"] = Fname;
        dsData.Tables[tbSub].ImportRow(dt.Rows[0]);
        dtItem.ImportRow(dt.Rows[0]);
      }
      catch (Exception ex)
      {
        MessageBox.Show("AddItem: " + ex.Message);
      }
    }

    private void InitialDialogSub(byte mode)
    {
      frm_Group_VersatilesInput frmInput;
      //DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;
      try
      {
        byte Xmode = 0;
        if (mode == 2)
        {
            Xmode = 0;
        }
        else
        {
            Xmode = mode;
        }

        frmInput = new frm_Group_VersatilesInput();
        frmInput.StartPosition = FormStartPosition.CenterParent;

        if (mode == 0)
            strMode = " [เพิ่ม]";
        else if (mode == 1)
            strMode = " [แก้ไข]";

        //dr = gvGroup.GetFocusedDataRow();
        //if (dr == null) return;
        int irow = gvSub.FocusedRowHandle;
        //view = (DevExpress.XtraGrid.Views.Grid.GridView)gvGroup;
        if ((irow < 0))
        {
          if (mode != 0)
          {
              return;
          }
        }
        //dr = view.GetFocusedDataRow();
        frmInput.Text = "กลุ่มสินค้า" + strMode;
        #region "XXX"
        if (dr != null)
        {
          if ((mode == 1) || (mode == 2))
          {
            if (mode == 1)
            {
                frmInput.txtGroupCode.Text = cls_Library.DBString(dr["SUB_CODE"]);
                frmInput.txtDesc.Text = cls_Library.DBString(dr["SUB_NAME"]);
            }
            else
            {
                frmInput.txtGroupCode.Text = "";
                frmInput.txtDesc.Text = "";
            }
          }
          else
          {
            frmInput.txtGroupCode.Text = "";
            frmInput.txtDesc.Text = "";
          }
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }
        DataTable dtr = (DataTable)gridSub.DataSource;
        if (cls_Data.SaveDataSubGroupVersatile(Xmode, CurrentGroubID, frmInput.txtGroupCode.Text, frmInput.txtDesc.Text, dtr.Rows.Count, ref CurrentSubID))
        {
          dsData.Tables[tbGroup].BeginInit();
          if (Xmode == 0)
          {
            DataTable dtv = (DataTable)gridSub.DataSource;
            DataTable dt = dtv.Clone();
            dt.Rows.Add();
            dt.Rows[0]["VERSATILE_ID"] = CurrentGroubID;
            dt.Rows[0]["SUB_ID"] = CurrentSubID;
            dt.Rows[0]["SUB_CODE"] = cls_Library.DBString(frmInput.txtGroupCode.Text.Trim());
            dt.Rows[0]["SUB_NAME"] = cls_Library.DBString(frmInput.txtDesc.Text.Trim());
            dt.Rows[0]["LIST_NO"] = gvSub.RowCount + 1;
            dsData.Tables[tbGroup].ImportRow(dt.Rows[0]);
            gvGroup.FocusedRowHandle = dsData.Tables[tbGroup].Rows.Count -1;
          }
          else
          {
            //view = (DevExpress.XtraGrid.Views.Grid.GridView)gvGroup;
            dr = gvSub.GetFocusedDataRow();
            dr["VERSATILE_ID"] = CurrentGroubID;
            dr["SUB_ID"] = CurrentSubID;
            dr["SUB_CODE"] = cls_Library.DBString(frmInput.txtGroupCode.Text.Trim());
            dr["SUB_NAME"] = cls_Library.DBString(frmInput.txtDesc.Text.Trim());                        
          }
          dsData.Tables[tbGroup].EndInit();
          gridGroup.DataSource = dsData.Tables[tbGroup];
          gridGroup.RefreshDataSource();   
        }       
      }
      catch (Exception ex)
      {
        MessageBox.Show("InitialDialogSub: " + ex.Message);
      }
    }

    private void LoadData()
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;
      DataRow drow;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        dsData = new DataSet();
        dsData = cls_Data.GetGroupVersatileData(DataMode, GroupID);
        if (dsData.Tables["M_VERSATILES_SUB"].Rows.Count > 0)
        {
          SubCount = -1;
          for (int i = 0; i < dsData.Tables["M_VERSATILES_SUB"].Rows.Count; i++)
          {
            drow = dsData.Tables["M_VERSATILES_SUB"].Rows[i];
            int ID = cls_Library.DBInt(drow["SUB_ID"]);

            SubCount++;
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

    private void SetDataFocusItem(DataRow row,int iRow)
    {
      try
      {
        if (row == null)
        {
          CurrentSubID = 0;
        }
        else
          CurrentSubID = cls_Library.DBInt(row["SUB_ID"]);




        //listItem = Itemdata[iRow].AsEnumerable().Where(r => r.Field<int>("VERSATILE_SUB_ID") == CurrentSubID).ToList();
        //if (listItem.Count > 0)
        //{
        //  dtItem = listItem.CopyToDataTable();
        //}
        //else
        //{
        //  dtItem = Itemdata[iRow].Clone();
        //}

        dtItem = cls_Data.GetListVersatilesItemByID(CurrentSubID);

        gridItem.DataSource = dtItem;
        gridItem.RefreshDataSource();

      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDataFocusItem: " + ex.Message);
      }
    }

    private void SetDataFocusSub(DataRow row)
    {
      try
      {                
        if (row == null)
        {
            CurrentGroubID = 0;
        }
        else
            CurrentGroubID = cls_Library.DBInt(row["VERSATILE_ID"]);


        listSub = dsData.Tables[tbSub].AsEnumerable().Where(r => r.Field<int>("VERSATILE_ID") == CurrentGroubID).ToList();
        if (listSub.Count > 0)
        {
          dtSub = listSub.CopyToDataTable();
        }
        else
        {
          dtSub = dsData.Tables[tbSub].Clone();
        }

        gridSub.DataSource = dtSub;
        gridSub.RefreshDataSource();

        Datarowchange++;


        DataRow dr = gvSub.GetFocusedDataRow();
        Subrow = cls_Library.DBInt(dr["LIST_NO"]) - 1;
        SetDataFocusItem(dr, Subrow);

      }
      catch (Exception ex)
      {
        MessageBox.Show("SetDataFocus: " + ex.Message);
      }
    }

    private void SetDataToControl()
    {
        try
        {
            gridGroup.DataSource = dsData.Tables["M_VERSATILES"];
            gridGroup.RefreshDataSource();

        }
        catch (Exception ex)
        {
            MessageBox.Show("SetDataToControl: " + ex.Message);
        }
    }

    private void ThreadStart()
    {
        if (!bwLoad.IsBusy) bwLoad.RunWorkerAsync();
    }

    #endregion

    public frm_Group_Vers(byte mode, int Groupid =0)
    {
      InitializeComponent();
      DataMode = mode;    //1: All Group, 2: By Id
      GroupID = Groupid;
      Datarowchange = 0;
      this.KeyPreview = true;

      this.Text = "สินค้าอเนกประสงค์";
      tbSub = "M_VERSATILES_SUB";
      tbItem = "M_VERSATILES_ITEM";
      ThreadStart();
    }

    private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
    {
      LoadData();
    }

    private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        //chkShow.Enabled = true;
        SetDataToControl();
    }

    private void gvGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      DataRow dr = gvGroup.GetFocusedDataRow();
      SetDataFocusSub(dr);
    }

    private void frm_GroupJoin_Load(object sender, EventArgs e)
    {
        if (cls_Global_DB.DataInitial == null)
        {
            cls_Global_DB.DataInitial = new DataSet();
            cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_ITEMS"));
        }
        else
        {
            if (!cls_Global_DB.DataInitial.Tables.Contains("M_ITEMS"))
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_ITEMS"));
        }

        repoSearchItem.DataSource = cls_Global_DB.DataInitial.Tables["M_ITEMS"];
        repoSearchItem.ValueMember = "_id";
        repoSearchItem.DisplayMember = "code";

        chkShow.Checked = DataMode == 1;
    }

    private void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        if (!chkShow.IsEditorActive) return;            
        if (chkShow.Checked) DataMode = 1; else DataMode = 2;
        ThreadStart();
    }

    private void btAddGroup_Click(object sender, EventArgs e)
    {
      InitialDialogSub(0);
    }

    private void btEditGroup_Click(object sender, EventArgs e)
    {
      InitialDialogSub(1);
    }

    private void btDeleteGroup_Click(object sender, EventArgs e)
    {
        try
        {
            DataRow Drow = gvGroup.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvGroup.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                CurrentGroubID = cls_Library.DBInt(Drow["GROUP_ID"]);
                if (cls_Data.DeleteGroup(DataType, CurrentGroubID))
                {
                    dsData.Tables[tbGroup].AcceptChanges();
                    dsData.Tables[tbGroup].Rows[irow].Delete();
                    Drow.Delete();
                    dsData.Tables[tbGroup].AcceptChanges();
                    gvGroup.RefreshData();
                    gridGroup.RefreshDataSource();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("btDeleteGroup_Click: " + ex.Message);
        }
    }

    private void btView_Click(object sender, EventArgs e)
    {

    }

    private void btAddItem_Click(object sender, EventArgs e)
    {
      AddItem();
    }

    private void btDeleteItem_Click(object sender, EventArgs e)
    {
        try
        {
            DataRow Drow = gvItem.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvItem.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                tmpID = cls_Library.DBInt(Drow["SUBID"]);
                if (cls_Data.DeleteItemInGroup(DataType, tmpID))
                {
                    dsData.Tables[tbSub].AcceptChanges();
                    dsData.Tables[tbSub].Rows[irow].Delete();
                    Drow.Delete();
                    dsData.Tables[tbSub].AcceptChanges();
                    gvGroup.RefreshData();
                    gridGroup.RefreshDataSource();
                }                
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("btDeleteItem_Click: " + ex.Message);
        }
    }

    private void gvSub_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      Subrow = e.FocusedRowHandle;

      if (Subrow < 0) return;

      DataRow dr = gvSub.GetFocusedDataRow();
      SetDataFocusItem(dr,Subrow);
    }

  }
}