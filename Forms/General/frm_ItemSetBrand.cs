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
    public partial class frm_ItemSetBrand : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataSet dsData = new DataSet();
        private DataTable dtBrandDis = new DataTable();
        //private DataTable dtData = new DataTable();
        private int ItemID = 0;
        private int BrandID = 0;
        #endregion

        #region Function

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

        private void SaveData()
        {
            try
            {
                if (!VerifyData()) return;
                if (cls_Data.SaveDataItemEdit2(ItemID, BrandID, dtBrandDis))
                {
                    XtraMessageBox.Show("แก้ไขข้อมูลยี่ห้อสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("แก้ไขข้อมูลยี่ห้อไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveData: " + ex.Message);
            }
        }

        private void SetDataToControl(byte type)
        {
            try
            {

                searchBrandCode.Properties.DataSource = dsData.Tables["M_BRANDS"];
                //sLookUp.Refresh();
                searchBrandCode.Properties.PopulateViewColumns();
                searchBrandCode.Properties.View.Columns["_id"].Visible = false;
                searchBrandCode.Properties.View.Columns["code"].Caption = "รหัสยี่ห้อ";
                searchBrandCode.Properties.View.Columns["name"].Caption = "ชื่อยี่ห้อ";

                searchBrandCode.Properties.ValueMember = "_id";
                searchBrandCode.Properties.DisplayMember = "code";                 

                if (type == 1)
                {
                    dtBrandDis = dsData.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].Copy();
                    cls_Global_DB.GB_Dbrand_Salediscount = dtBrandDis.Rows.Count;
                    if (dsData.Tables["M_ITEMS"].Rows.Count > 0)
	                {
                        BrandID= cls_Library.DBInt(dsData.Tables["M_ITEMS"].Rows[0]["BRAND_ID"]);
                        searchBrandCode.EditValue = BrandID;
                        txtBrandName.Text = cls_Library.DBString(dsData.Tables["M_ITEMS"].Rows[0]["BRAND_NAME"]);
	                }     
                }
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
                if (searchBrandCode.EditValue == null || searchBrandCode.Text == "เลือกยี่ห้อสินค้า")
                {
                    XtraMessageBox.Show("กรุณาระบุยี่ห้อสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchBrandCode.ErrorText = "กรุณาระบุยี่ห้อสินค้า";
                    searchBrandCode.Focus();
                    return ret;
                }
                ret = true;
            }
            catch (Exception)
            {
            }
            return ret;
        }
        #endregion

        public frm_ItemSetBrand(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dsData = cls_Data.GetDataItemEdit2(ItemID);
        }

        private void bwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetDataToControl(1);
        }

        private void searchBrandCode_EditValueChanged(object sender, EventArgs e)
        {
            if (!searchBrandCode.IsEditorActive) return;
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            BrandID = Convert.ToInt32(item.EditValue);
            if (BrandID > 0)
            {
                dtBrandDis = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T2, BrandID);
                txtBrandName.Text = cls_Data.GetNameFromTBname(BrandID, "BRANDS", "BRAND_NAME");                    
                SetDataToControl(2);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveData();
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSaleDiscountAdd_Click(object sender, EventArgs e)
        {
            InitialDialogSaleDiscount(0);
        }

        private void btSaleDiscountEdit_Click(object sender, EventArgs e)
        {
            InitialDialogSaleDiscount(1);
        }

        private void btSaleDiscountDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvSaleDis.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvSaleDis.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                dtBrandDis.AcceptChanges();
                dtBrandDis.Rows[irow].Delete();
                Drow.Delete();
                dtBrandDis.AcceptChanges();
                gvSaleDis.RefreshData();
                gridSaleDis.RefreshDataSource();
            }
        }

        private void frm_ItemSetBrand_KeyDown(object sender, KeyEventArgs e)
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