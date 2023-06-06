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
    public partial class frm_ItemEdit3 : DevExpress.XtraEditors.XtraForm
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

            row["MINIMUM_QTY"] = cls_Library.CDouble(spinQtymin.EditValue);
            row["MAXIMUM_QTY"] = cls_Library.CDouble(spinQtyMax.EditValue);
            row["MINIMUM_ORDER_QTY"] = cls_Library.CDouble(spinQtyMinOrder.EditValue);
            row["MINIMUM_SALE_QTY"] = cls_Library.CDouble(spinQtyMinSale.EditValue);
            row["QTY"] = cls_Library.CDouble(spCountCar.EditValue);
            dtSave.Rows.Add(row);
        }

        private void SaveData()
        {
            try
            {
                AssignDataFromComponent();
                if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.T3, ItemID, dtSave))
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
                spinQtymin.EditValue = cls_Library.DBDecimal(row["MINIMUM_QTY"]);
                spinQtyMax.EditValue = cls_Library.DBDouble(row["MAXIMUM_QTY"]);
                spinQtyMinOrder.EditValue = cls_Library.DBDouble(row["MINIMUM_ORDER_QTY"]);
                spinQtyMinSale.EditValue = cls_Library.DBDouble(row["MINIMUM_SALE_QTY"]);
                spCountCar.EditValue = cls_Library.DBDouble(row["QTY"]);
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

        public frm_ItemEdit3(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T3, ItemID);
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

        private void frm_ItemEdit3_KeyDown(object sender, KeyEventArgs e)
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