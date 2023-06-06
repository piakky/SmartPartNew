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
  public partial class frm_ItemEdit5 : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private DataTable dtData = new DataTable();
    //private DataTable dtSave;
    private int ItemID = 0;
    private bool UseSerail = false;
    #endregion

    #region Function

    private void InitialDialogLocation(int mode)
    {
        frmD_LocationInput frmInput;
        DevExpress.XtraGrid.Views.Grid.GridView view;
        DataRow dr = null;
        string strMode = String.Empty;
        try
        {
            int Xmode = 0;
            if (mode == 2)
            {
                Xmode = 0;
            }
            else
            {
                Xmode = mode;
            }

            frmInput = new frmD_LocationInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
                strMode = " [เพิ่ม]";
            else if (mode == 1)
                strMode = " [แก้ไข]";

            DataTable dtGroup = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvLocation;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                    return;
                }
            }

            dr = view.GetFocusedDataRow();
            string Snum = UseSerail ? "  {มีหมายเลขประจำเครื่อง}  " : "  { ไม่มีหมายเลขประจำเครื่อง}  ";
            frmInput.Text = "คลังสินค้า" + Snum + strMode;
            #region "XXX"
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                    if (mode == 1)
                    {
                        frmInput.TxtLocationName.Text = cls_Library.DBString(dr["LOCATION_NAME"]);
                        frmInput.TxtSerialNumber.Text = cls_Library.DBString(dr["SERIAL_NO"]);
                        frmInput.spinQuantity.EditValue = cls_Library.DBInt(dr["QTY"]);
                        frmInput.chkUseMode.EditValue = cls_Library.DBbool(dr["DEFAULT_LOCATION"]); ;
                    }
                    else
                    {
                        DataTable dt = (DataTable)gridLocation.DataSource;
                        frmInput.TxtLocationName.Text = "";
                        frmInput.TxtSerialNumber.Text = "";
                        frmInput.spinQuantity.EditValue = 0;
                        frmInput.chkUseMode.EditValue = 1;
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
                    DataTable dt = (DataTable)gridLocation.DataSource;
                }
            }
            if (!UseSerail)
            {
                frmInput.labelSerialNumber.Visible = false;
                frmInput.TxtSerialNumber.Visible = false;
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
                DataTable dtv = (DataTable)gridLocation.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["LOCATION_NAME"] = cls_Library.DBString(frmInput.TxtLocationName.Text.Trim());
                dt.Rows[0]["SERIAL_NO"] = cls_Library.DBString(frmInput.TxtSerialNumber.Text.Trim());
                dt.Rows[0]["QTY"] = cls_Library.DBInt(frmInput.spinQuantity.EditValue);
                dt.Rows[0]["DEFAULT_LOCATION"] = cls_Library.DBbool(frmInput.chkUseMode.EditValue);
                dtData.ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvLocation;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["LOCATION_NAME"] = cls_Library.DBString(frmInput.TxtLocationName.Text.Trim());
                dr["SERIAL_NO"] = cls_Library.DBString(frmInput.TxtSerialNumber.Text.Trim());
                dr["QTY"] = cls_Library.DBInt(frmInput.spinQuantity.EditValue);
                dr["DEFAULT_LOCATION"] = cls_Library.DBbool(frmInput.chkUseMode.EditValue);
            }
            dtData.EndInit();                
            gridLocation.DataSource = dtData;
            gridLocation.RefreshDataSource();

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
            if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.T5, ItemID, dtData))
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
        cls_Global_DB.GB_DitemLocation_count = dtData.Rows.Count;
        gridLocation.DataSource = dtData;
        gridLocation.RefreshDataSource();
    }

    private void ThreadStart()
    {
        if (!bwItem.IsBusy) bwItem.RunWorkerAsync();
    }
    #endregion

    public frm_ItemEdit5(int Id)
    {
      ItemID = Id;
      InitializeComponent();
      this.KeyPreview = true;
      ThreadStart();
    }

    private void bwItem_DoWork(object sender, DoWorkEventArgs e)
    {
        dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T5, ItemID);
        UseSerail = cls_Library.DBbool(cls_Data.GetNameFromTBname(ItemID, "ITEMS", "SERIAL_NO_STATUS"));
    }

    private void bwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        SetDataToControl();
    }

    private void btLocationAdd_Click(object sender, EventArgs e)
    {
        InitialDialogLocation(0);
    }

    private void btLocationEdit_Click(object sender, EventArgs e)
    {
        InitialDialogLocation(1);
    }

    private void btLocationDelete_Click(object sender, EventArgs e)
    {
        DataRow Drow = gvLocation.GetFocusedDataRow();
        if (Drow == null) return;
        int irow = gvLocation.FocusedRowHandle;
        DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (Result == DialogResult.Yes)
        {
            dtData.AcceptChanges();
            dtData.Rows[irow].Delete();
            Drow.Delete();
            dtData.AcceptChanges();
            gvLocation.RefreshData();
            gridLocation.RefreshDataSource();
        }
    }

    private void btSave_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    private void btClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void frm_ItemEdit5_KeyDown(object sender, KeyEventArgs e)
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