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
    public partial class frm_ItemEdit10 : DevExpress.XtraEditors.XtraForm
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

            row["ABBREVIATE_NAME"] = txtAbbreviateName.Text.Trim();
            row["FULL_NAME"] = txtFullName.Text.Trim();
            row["MODEL1"] = txtModel1.Text.Trim();
            row["MODEL2"] = txtModel2.Text.Trim();
            row["MODEL3"] = txtModel3.Text.Trim();
            row["GENUIN_PART_ID"] = txtGenuinPart.Text.Trim();
            row["BRAND_PART_ID"] = txtProducerPart.Text.Trim();
            row["FULL_NAME_PRINT"] = txtFullPrint.Text.Trim();
            row["MODEL_PRINT"] = txtModelPrint.Text.Trim();
            row["BRAND_PRINT"] = txtBrandPrint.Text.Trim();
            dtSave.Rows.Add(row);
        }

        private void SaveData()
        {
            try
            {
                AssignDataFromComponent();
                if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.T10, ItemID, dtSave))
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
                DataRow row = dtData.Rows[0];
                txtAbbreviateName.Text = cls_Library.DBString(row["ABBREVIATE_NAME"]);
                txtFullName.Text = cls_Library.DBString(row["FULL_NAME"]);
                txtModel1.Text = cls_Library.DBString(row["MODEL1"]);
                txtModel2.Text = cls_Library.DBString(row["MODEL2"]);
                txtModel3.Text = cls_Library.DBString(row["MODEL3"]);
                txtGenuinPart.Text = cls_Library.DBString(row["GENUIN_PART_ID"]);
                txtProducerPart.Text = cls_Library.DBString(row["BRAND_PART_ID"]);
                txtFullPrint.Text = cls_Library.DBString(row["FULL_NAME_PRINT"]);
                txtModelPrint.Text = cls_Library.DBString(row["MODEL_PRINT"]);
                txtBrandPrint.Text = cls_Library.DBString(row["BRAND_PRINT"]);
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
        #endregion

        public frm_ItemEdit10(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T10, ItemID);
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

        private void frm_ItemEdit10_KeyDown(object sender, KeyEventArgs e)
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

        private void frm_ItemEdit10_Load(object sender, EventArgs e)
        {

        }
    }
}