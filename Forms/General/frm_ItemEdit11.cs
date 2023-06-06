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
using SmartPart.Forms.Code;

namespace SmartPart.Forms.General
{
  public partial class frm_ItemEdit11 : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private DataTable dtData = new DataTable();
    private DataTable dtPOgroup = new DataTable();
    //private DataTable dtSave;
    private int ItemID = 0;
    #endregion

    #region Function

    public void InitialDialogPOGroup(int mode)
    {
      frmD_PogroupInput frmInput;
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

      frmInput = new frmD_PogroupInput();
      frmInput.StartPosition = FormStartPosition.CenterParent;

      if (mode == 0)
        strMode = " [เพิ่ม]";
      else if (mode == 1)
        strMode = " [แก้ไข]";


      try
      {
        DataTable dtUnit = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPO_Group;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != 0)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "กลุ่มสั่งซื้อสินค้า" + strMode;
        #region "XXX"
        frmInput.searchLookUpPOGroup.Properties.DataSource = searchPOGroupsCode.Properties.DataSource;
        frmInput.searchLookUpPOGroup.Properties.PopulateViewColumns();
        frmInput.searchLookUpPOGroup.Properties.ValueMember = "_id";
        frmInput.searchLookUpPOGroup.Properties.DisplayMember = "code";
        frmInput.searchLookUpPOGroup.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpPOGroup.Properties.View.Columns["code"].Caption = "รหัสกลุ่มสั่งซื้อสินค้า";
        frmInput.searchLookUpPOGroup.Properties.View.Columns["name"].Caption = "ชื่อกลุ่มสั่งซื้อสินค้า";
        if (dr != null)
        {
          if ((mode == 1) || (mode == 2))
          {
            if (mode == 1)
            {
              frmInput.searchLookUpPOGroup.EditValue = cls_Library.DBInt(dr["PO_GROUP_ID"]);
              frmInput.TxtPOGroupName.Text = cls_Library.DBString(dr["PO_GROUP_NAME"]); ;
            }
            else
            {
              DataTable dt = (DataTable)gridPO_Group.DataSource;
              frmInput.searchLookUpPOGroup.EditValue = null;
              frmInput.TxtPOGroupName.Text = "";
            }
            try
            {
              //frmInput.MemberOf = dr("USRmember").ToString();
            }
            catch (Exception ex)
            {
              XtraMessageBox.Show(ex.Message);
              //frmInput.MemberOf = "";
            }
            finally
            {
              //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
              //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
            }
          }
          else
          {
            DataTable dt = (DataTable)gridPO_Group.DataSource;
          }
        }

        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dtData.BeginInit();
        if (Xmode == 0)
        {
          DataTable dtv = (DataTable)gridPO_Group.DataSource;
          DataTable dt = dtv.Clone();
          dt.Rows.Add();
          dt.Rows[0]["mode"] = 1;
          dt.Rows[0]["ITEM_ID"] = ItemID;
          dt.Rows[0]["PO_GROUP_ID"] = cls_Library.DBInt(frmInput.searchLookUpPOGroup.EditValue);
          dt.Rows[0]["PO_GROUP_CODE"] = cls_Library.DBString(frmInput.searchLookUpPOGroup.Text.Trim());
          dt.Rows[0]["PO_GROUP_NAME"] = cls_Library.DBString(frmInput.TxtPOGroupName.Text.Trim());
          dtData.ImportRow(dt.Rows[0]);
        }
        else
        {
          view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPO_Group;
          dr = view.GetFocusedDataRow();
          dr["mode"] = 2;
          dr["ITEM_ID"] = ItemID;
          dr["PO_GROUP_ID"] = cls_Library.DBInt(frmInput.searchLookUpPOGroup.EditValue);
          dr["PO_GROUP_CODE"] = cls_Library.DBString(frmInput.searchLookUpPOGroup.Text.Trim());
          dr["PO_GROUP_NAME"] = cls_Library.DBString(frmInput.TxtPOGroupName.Text.Trim());
        }
        dtData.EndInit();
        gridPO_Group.DataSource = dtData;
        gridPO_Group.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }
    private void SaveData()
    {
        try
        {
            if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.T11, ItemID, dtData))
            {
                XtraMessageBox.Show("แก้ไขข้อมูลรหัสสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("แก้ไขข้อมูลรหัสสินค้าไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("SaveData: " + ex.Message);
        }
    }

    private void SetDataToControl()
    {
      searchPOGroupsCode.Properties.DataSource = dtPOgroup;
      searchPOGroupsCode.Properties.PopulateViewColumns();
      searchPOGroupsCode.Properties.View.Columns["_id"].Visible = false;
      searchPOGroupsCode.Properties.View.Columns["code"].Caption = "รหัสกลุ่มสั่งซื้อสินค้า";
      searchPOGroupsCode.Properties.View.Columns["name"].Caption = "ชื่อกลุ่มสั่งซื้อสินค้า";

      searchPOGroupsCode.Properties.ValueMember = "_id";
      searchPOGroupsCode.Properties.DisplayMember = "code";

      cls_Global_DB.GB_DitemPOgroup_count = dtData.Rows.Count;
      gridPO_Group.DataSource = dtData;
      gridPO_Group.RefreshDataSource();


    }

    private void ThreadStart()
    {
        if (!bwItem.IsBusy) bwItem.RunWorkerAsync();
    }
    #endregion

    public frm_ItemEdit11(int Id)
    {
      ItemID = Id;
      InitializeComponent();
      this.KeyPreview = true;
      ThreadStart();
    }

    private void bwItem_DoWork(object sender, DoWorkEventArgs e)
    {
      dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T11, ItemID);
      dtPOgroup = cls_Data.GetDataTable("M_PO_GROUPS");
    }

    private void bwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      SetDataToControl();
    }

    private void btPartAdd_Click(object sender, EventArgs e)
    {
      InitialDialogPOGroup(0);
    }

    private void btPartEdit_Click(object sender, EventArgs e)
    {
      InitialDialogPOGroup(1);
    }

    private void btPartDelete_Click(object sender, EventArgs e)
    {
        DataRow Drow = gvPO_Group.GetFocusedDataRow();
        if (Drow == null) return;
        int irow = gvPO_Group.FocusedRowHandle;
        DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (Result == DialogResult.Yes)
        {
            dtData.AcceptChanges();
            dtData.Rows[irow].Delete();
            Drow.Delete();
            dtData.AcceptChanges();
            gvPO_Group.RefreshData();
            gridPO_Group.RefreshDataSource();
        }
    }

    private void btSave_Click(object sender, EventArgs e)
    {
        SaveData();
            this.DialogResult = DialogResult.OK;
        }

    private void btClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void frm_ItemEdit11_KeyDown(object sender, KeyEventArgs e)
    {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btSave_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
  }
}