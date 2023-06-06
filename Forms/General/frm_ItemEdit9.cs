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

namespace SmartPart.Forms.General
{
  public partial class frm_ItemEdit9 : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private DataTable dtData = new DataTable();
    private DataTable dtSave;
    private int ItemID = 0;
    #endregion

    #region Function

    private void AssignDataFromComponent()
    {
        dtSave = dtData.Clone();
        DataRow row = dtSave.NewRow();
        row["SIZE_ID"] = cls_Library.DBInt(searchSizesCode.EditValue);
        row["SIZE_INNER"] = txtSizeInner.Text.Trim();
        row["SIZE_OUTSIDE"] = txtSizeOutside.Text.Trim();
        row["SIZE_THICK"] = txtSizeThick.Text.Trim();
        dtSave.Rows.Add(row);
    }

    private void LoadDefaultData()
    {
        try
        {
            cls_Library.AssignSearchLookUp(searchSizesCode, "M_SIZES", "รหัสประเภทสินค้า+ขนาด", "ชื่อประเภทสินค้า+ขนาด");
        }
        catch (Exception ex)
        {
            MessageBox.Show("LoadDefaultData :" + ex.Message);
        }
    }

    private void SaveData()
    {
        try
        {
            AssignDataFromComponent();
            if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.T9, ItemID, dtSave))
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
        try
        {
            LoadDefaultData();

            DataRow row = dtData.Rows[0];
            searchSizesCode.EditValue = cls_Library.DBInt(row["SIZE_ID"]);
            txtSizesName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchSizesCode.EditValue), "SIZES", "SIZE_NAME");
            if (cls_Library.DBInt(searchSizesCode.EditValue) == 0) searchSizesCode.EditValue = null;
            txtSizeInner.Text = cls_Library.DBString(row["SIZE_INNER"]);
            txtSizeOutside.Text = cls_Library.DBString(row["SIZE_OUTSIDE"]);
            txtSizeThick.Text = cls_Library.DBString(row["SIZE_THICK"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show("SetDataToControl: " + ex.Message);
        }
    }

    private void ThreadStart()
    {
        if (!bwItem.IsBusy) bwItem.RunWorkerAsync();
    }

    private bool VerifyData()
    {
        bool ret = false;

        try
        {
            if (searchSizesCode.EditValue == null || searchSizesCode.Text == "เลือกประเภทสินค้า+ขนาด")
            {
                XtraMessageBox.Show("กรุณาระบุประเภทสินค้า+ขนาด", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchSizesCode.ErrorText = "กรุณาระบุประเภทสินค้า+ขนาด";
                searchSizesCode.Focus();
                return ret;
            }
            ret = true;
        }
        catch
        {
        }
        return ret;
    }
    #endregion

    public frm_ItemEdit9(int Id)
    {
      ItemID = Id;
      InitializeComponent();
      this.KeyPreview = true;
      ThreadStart();
    }

    private void bwItem_DoWork(object sender, DoWorkEventArgs e)
    {
        dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T9, ItemID);
        if (cls_Global_DB.DataInitial == null)
        {
            cls_Global_DB.DataInitial = new DataSet();
            cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_SIZES"));
        }
        else
        {
            if (!cls_Global_DB.DataInitial.Tables.Contains("M_SIZES"))
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_SIZES"));
        }
    }

    private void bwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        SetDataToControl();
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

    private void searchSizesCode_EditValueChanged(object sender, EventArgs e)
    {
        SearchLookUpEdit item = (SearchLookUpEdit)sender;
        int id = Convert.ToInt32(item.EditValue);
        if (id > 0)
        {
            txtSizesName.Text = cls_Data.GetNameFromTBname(id, "SIZES", "SIZE_NAME");
        }
    }

    private void frm_ItemEdit9_KeyDown(object sender, KeyEventArgs e)
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