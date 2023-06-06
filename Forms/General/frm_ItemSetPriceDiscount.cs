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
    public partial class frm_ItemSetPriceDiscount : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtData = new DataTable();
        private DataTable dtSave;
        private DataSet dsData = new DataSet();
        private DataTable dtBrandDis = new DataTable();
        private DataTable dtUnit;
        private int ItemID = 0;
        private int BrandID = 0;
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

        public void InitialDialogSaleDiscount(int mode)
        {
            frmD_BrandSaleDiscount_Input frmInput;
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

            frmInput = new frmD_BrandSaleDiscount_Input();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
                strMode = " [เพิ่ม]";
            else if (mode == 1)
                strMode = " [แก้ไข]";


            try
            {
                DataTable dtGroup = new DataTable();
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSaleDis;
                if ((view.FocusedRowHandle < 0))
                {
                    if (mode != 0)
                    {
                        return;
                    }
                }
                dr = view.GetFocusedDataRow();
                frmInput.Text = "ส่วนลดขาย" + strMode;
                #region "XXX"
                if (dr != null)
                {
                    if ((mode == 1) || (mode == 2))
                    {
                        if (mode == 1)
                        {
                            frmInput.txtDiscountCode.Text = cls_Library.DBString(dr["DISCOUNT_CODE"]);
                        }
                        else
                        {
                            DataTable dt = (DataTable)gridSaleDis.DataSource;
                            frmInput.txtDiscountCode.Text = "";
                        }
                        frmInput.spinDisC1.EditValue = cls_Library.DBDecimal(dr["DISCOUNT_RATE_STEP1"]);
                        //frmInput.spinDisC2.EditValue = cls_Library.DBDecimal(dr["DISCOUNT_RATE_STEP2"]);
                        //frmInput.spinDisC3.EditValue = cls_Library.DBDecimal(dr["DISCOUNT_RATE_STEP3"]);
                        //frmInput.spinDisC4.EditValue = cls_Library.DBDecimal(dr["DISCOUNT_RATE_STEP4"]);
                        bool sEnable = cls_Library.DBbool(dr["ENABLED_STATUS"]);
                        frmInput.radioStatus.SelectedIndex = sEnable == true ? 0 : 1;
                    }
                    else
                    {
                        DataTable dt = (DataTable)gridSaleDis.DataSource;
                        //frmInput.txtDiscountCode.Text = cls_Data.GetLastCodeDetailMasterAlphabet("D_BRAND_SALE_DISCOUNT_STEPS", BrandID);
                    }
                }
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                dtBrandDis.BeginInit();
                if (Xmode == 0)
                {
                    DataTable dtv = (DataTable)gridSaleDis.DataSource;
                    DataTable dt = dtv.Clone();
                    dt.Rows.Add();
                    dt.Rows[0]["BRAND_ID"] = BrandID;
                    dt.Rows[0]["DISCOUNT_CODE"] = cls_Library.DBString(frmInput.txtDiscountCode.Text);
                    dt.Rows[0]["DISCOUNT_RATE_STEP1"] = cls_Library.DBDecimal(frmInput.spinDisC1.EditValue);
                    //dt.Rows[0]["DISCOUNT_RATE_STEP2"] = cls_Library.DBDecimal(frmInput.spinDisC2.EditValue);
                    //dt.Rows[0]["DISCOUNT_RATE_STEP3"] = cls_Library.DBDecimal(frmInput.spinDisC3.EditValue);
                    //dt.Rows[0]["DISCOUNT_RATE_STEP4"] = cls_Library.DBDecimal(frmInput.spinDisC4.EditValue);
                    dt.Rows[0]["ENABLED_STATUS"] = frmInput.radioStatus.SelectedIndex == 0 ? true : false;
                    dtBrandDis.ImportRow(dt.Rows[0]);
                }
                else
                {
                    view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSaleDis;
                    dr = view.GetFocusedDataRow();
                    dr["BRAND_ID"] = BrandID;
                    dr["DISCOUNT_CODE"] = cls_Library.DBString(frmInput.txtDiscountCode.Text);
                    dr["DISCOUNT_RATE_STEP1"] = cls_Library.DBDecimal(frmInput.spinDisC1.EditValue);
                    //dr["DISCOUNT_RATE_STEP2"] = cls_Library.DBDecimal(frmInput.spinDisC2.EditValue);
                    //dr["DISCOUNT_RATE_STEP3"] = cls_Library.DBDecimal(frmInput.spinDisC3.EditValue);
                    //dr["DISCOUNT_RATE_STEP4"] = cls_Library.DBDecimal(frmInput.spinDisC4.EditValue);
                    dr["ENABLED_STATUS"] = frmInput.radioStatus.SelectedIndex == 0 ? true : false;
                }
                dtBrandDis.EndInit();
                gridSaleDis.DataSource = dtBrandDis;
                gridSaleDis.RefreshDataSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
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
            bool ret = false;
            try
            {
                if (!VerifyData()) return;

                AssignDataFromComponent();
                if (check1.Checked)
                {
                    ret = cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.SetPrice, ItemID, dtSave);
                }
                else
                {
                    ret = cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.SetPriceDisCount, ItemID, dtSave);
                }
                if (ret)
                {
                    if (check2.Checked) ret = cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.SaleDisCount, ItemID, dtBrandDis);
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

                dtBrandDis = dsData.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].Copy();

                gridSaleDis.DataSource = dtBrandDis;
                gridSaleDis.RefreshDataSource();

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

        public frm_ItemSetPriceDiscount(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();
            spinPrice1.GotFocus += SpinPrice1_GotFocus;
            spinPrice2.GotFocus += SpinPrice2_GotFocus;
            gridSaleDis.Enabled = false;
            spinPrice1.Select();
        }

        private void SpinPrice2_GotFocus(object sender, EventArgs e)
        {
            (sender as TextEdit).SelectAll();
        }

        private void SpinPrice1_GotFocus(object sender, EventArgs e)
        {
            (sender as TextEdit).SelectAll();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
                dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.SetPrice, ItemID);
                dsData = cls_Data.GetDataItemEdit2(ItemID);
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


        private void frm_ItemSetPriceDiscount_KeyDown(object sender, KeyEventArgs e)
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

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit item = (CheckEdit)sender;
            if (item.Checked)
            {
                spinPrice1.Enabled = true;
                //spinPrice2.Enabled = true;
                gridSaleDis.Enabled = false;
                btSaleDiscountEdit.Enabled = false;
                check2.Checked = false;
            }
            else
            {
                check2.Checked = true;
                spinPrice1.Enabled = false;
                //spinPrice2.Enabled = false;
                gridSaleDis.Enabled = true;
                btSaleDiscountEdit.Enabled = true;
            }
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit item = (CheckEdit)sender;
            if (item.Checked)
            {
                spinPrice1.Enabled = false;
                //spinPrice2.Enabled = false;
                gridSaleDis.Enabled = true;
                btSaleDiscountEdit.Enabled = true;
                check1.Checked = false;
                spinPrice2.Select();
            }
            else
            {
                check1.Checked = true;
                spinPrice1.Enabled = true;
                //spinPrice2.Enabled = true;
                gridSaleDis.Enabled = false;
                btSaleDiscountEdit.Enabled = false;
            }
        }

        private void btSaleDiscountEdit_Click(object sender, EventArgs e)
        {
            InitialDialogSaleDiscount(1);
        }

        private void sluUnit_EditValueChanged(object sender, EventArgs e)
        {
            if (!sluUnit.IsEditorActive) return;
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            BrandID = Convert.ToInt32(item.EditValue);
            if (BrandID > 0)
            {
                dtBrandDis = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T2, BrandID);
                gridSaleDis.DataSource = dtBrandDis;
                gridSaleDis.RefreshDataSource();
            }
        }

    }
}