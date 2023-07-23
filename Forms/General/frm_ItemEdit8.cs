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
    public partial class frm_ItemEdit8 : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtData = new DataTable();
        private DataTable dtSotkOH = new DataTable();
        private DataTable dtSave;
        private int ItemID = 0;
        #endregion

        #region Function

        private void AssignDataFromComponent()
        {
          //In 1: Out 2
            dtSave = dtSotkOH.Clone();
            DataRow row = dtSave.NewRow();
            try
            {
              row["ITEM_ID"] = ItemID;
              row["DOCNO"] = "";
              row["INOUT"] = cls_Library.CDouble(spinQtyCurrent.EditValue) > cls_Library.CDouble(spinQtyNew.EditValue) ? 2 : 1;
              row["QTY"] = cls_Library.CDouble(spinQtyNew.EditValue);
              row["QTY_ORIGINAL"] = cls_Library.CDouble(spinQtyCurrent.EditValue);
              dtSave.Rows.Add(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show("AssignDataFromComponent: " + ex.Message);
            }
        }

        private void SaveData()
        {
            try
            {
                AssignDataFromComponent();
                if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.T8, ItemID, dtSave))
                {
                    XtraMessageBox.Show("แก้ไขจำนวนสินค้าในคลังเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("แก้ไขจำนวนสินค้าในคลังไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //แก้ไข 2022-05-05
                //if (dtData.Rows.Count <= 0) return;

                //DataRow row = dtData.Rows[0];
                //spinQtyCurrent.EditValue = cls_Library.DBDecimal(row["CURRENT_QTY"]);
                //ตรวจสอบ stock on hand
                double GetOnh = cls_Data.GetBalanceStockOnhand(ItemID);
                spinQtyCurrent.EditValue = GetOnh;
                spinQtyNew.EditValue = 0;
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

        public frm_ItemEdit8(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            spinQtyNew.Focus();
            ThreadStart();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            //แก้ไข 2022-05-05
            //dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T8, ItemID);
            dtSotkOH = cls_Data.GetListStockOnHandByItemID(0, 2);
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

        private void frm_ItemEdit8_KeyDown(object sender, KeyEventArgs e)
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