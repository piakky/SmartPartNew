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
    public partial class frm_ItemSetPrice : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtData = new DataTable();
        private DataTable dtSave;
        private DataTable dtUnit;
        private int ItemID = 0;
        #endregion

        #region Function

        private void AssignDataFromComponent()
        {
            dtSave = dtData.Clone();
            DataRow row = dtSave.NewRow();

            row["PRICE1"] = cls_Library.DBDecimal(spinPrice1.EditValue);
            row["PRICE2"] = cls_Library.DBDecimal(spinPrice2.EditValue);
            row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
            dtSave.Rows.Add(row);
        }

        private void LoadDefaultData()
        {
            try
            {
                dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS_SALE", ItemID);
                if (dtUnit.Rows.Count > 0)
                {
                    List<DataRow> lst = dtUnit.AsEnumerable().Where(r => r.Field<Int16>("LIST_NO") == 1).ToList();
                    if (lst.Count > 0)
                    {
                        sluUnit.EditValue = cls_Library.DBInt(lst[0]["UNIT_ID"]);
                    }
                }
                string[] selectedColumns = new[] { "_id", "code", "name", "MULTIPLY_QTY", "codename" };
                DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
                sluUnit.Properties.DataSource = dt;
                sluUnit.Properties.PopulateViewColumns();
                sluUnit.Properties.View.Columns["_id"].Visible = false;
                sluUnit.Properties.View.Columns["codename"].Visible = false;
                sluUnit.Properties.View.Columns["code"].Caption = "รหัสหน่วยนับ";
                sluUnit.Properties.View.Columns["name"].Caption = "ชื่อหน่วยนับ";
                sluUnit.Properties.View.Columns["MULTIPLY_QTY"].Caption = "จำนวนหน่วยย่อย";

                sluUnit.Properties.ValueMember = "_id";
                sluUnit.Properties.DisplayMember = "codename";
                sluUnit.Enabled = true;
                if (dtUnit.Rows.Count == 1)
                {
                    sluUnit.EditValue = cls_Library.DBInt(dtUnit.Rows[0]["UNIT_ID"]);
                    sluUnit.Enabled = false;
                }
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
                if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.SetPrice, ItemID, dtSave))
                {
                    XtraMessageBox.Show("บันทึกราคาขายเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }
                else
                {
                    XtraMessageBox.Show("บันทึกราคาขายไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //DataRow row = dtData.Rows[0];
            
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
            if (sluUnit.EditValue == null)
            {
                ret = false;
                MessageBox.Show("รหัสหน่วยนับไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ret;
            }
            
            try
            {
                if (cls_Library.DBDecimal(spinPrice1.EditValue) <=0) 
                {
                        spinPrice1.EditValue = 0;
                }
                if (cls_Library.DBDecimal(spinPrice2.EditValue) <= 0)
                {
                    spinPrice2.EditValue = 0;
                }
                ret = true;
            }
            catch
            {
            }
            return ret;
        }
        #endregion

        public frm_ItemSetPrice(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();

            spinPrice1.Select();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.SetPrice, ItemID);
        }

        private void bwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            SetDataToControl();
            
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void spinPrice2_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter) btSave.Select();
            }
    }
}