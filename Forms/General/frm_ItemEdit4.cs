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
    public partial class frm_ItemEdit4 : DevExpress.XtraEditors.XtraForm
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

            row["CATEGORY_ID"] = cls_Library.CInt(searchCategoriesCode.EditValue);
            row["TYPE_ID"] = cls_Library.CInt(searchTypesCode.EditValue);
            dtSave.Rows.Add(row);
        }

        private void LoadDefaultData()
        {
            try
            {
                cls_Library.AssignSearchLookUp(searchCategoriesCode, "M_CATEGORIES", "รหัสหมวดหมู่", "ชื่อหมวดหมู่");
                cls_Library.AssignSearchLookUp(searchTypesCode, "M_TYPES", "รหัสประเภทสินค้า", "ชื่อประเภทสินค้า");
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
                if (!VerifyData()) return;

                AssignDataFromComponent();
                if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.T4, ItemID, dtSave))
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
                searchCategoriesCode.EditValue = cls_Library.DBInt(row["CATEGORY_ID"]);
                searchTypesCode.EditValue = cls_Library.DBInt(row["TYPE_ID"]);
                txtCategoriesName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchCategoriesCode.EditValue), "CATEGORIES", "CATEGORY_NAME");
                txtTypesName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchTypesCode.EditValue), "TYPES", "TYPE_NAME");
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
                if (searchCategoriesCode.EditValue == null || searchCategoriesCode.Text == "เลือกหมวดหมู่สินค้า")
                {
                    XtraMessageBox.Show("กรุณาระบุหมวดหมู่สินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchCategoriesCode.ErrorText = "กรุณาระบุหมวดหมู่สินค้า";
                    searchCategoriesCode.Focus();
                    return ret;
                }
                if (searchTypesCode.EditValue == null || searchTypesCode.Text == "เลือกประเภทสินค้า")
                {
                    XtraMessageBox.Show("กรุณาระบุประเภทสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchTypesCode.ErrorText = "กรุณาระบุประเภทสินค้า";
                    searchTypesCode.Focus();
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

        public frm_ItemEdit4(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T4, ItemID);
            if (cls_Global_DB.DataInitial == null)
            {
                cls_Global_DB.DataInitial = new DataSet();
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_CATEGORIES"));                
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_TYPES"));
            }
            else
            {
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_CATEGORIES"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_CATEGORIES"));

                if (!cls_Global_DB.DataInitial.Tables.Contains("M_TYPES"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_TYPES"));
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

        private void searchCategoriesCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                txtCategoriesName.Text = cls_Data.GetNameFromTBname(id, "CATEGORIES", "CATEGORY_NAME");
            }
        }

        private void searchTypesCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
                txtTypesName.Text = cls_Data.GetNameFromTBname(id, "TYPES", "TYPE_NAME");
            }
        }

        private void frm_ItemEdit4_KeyDown(object sender, KeyEventArgs e)
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