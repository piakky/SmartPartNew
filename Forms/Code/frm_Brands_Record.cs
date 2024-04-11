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
using System.Data.SqlClient;

namespace SmartPart.Forms.Code
{
    public partial class frm_Brands_Record : DevExpress.XtraEditors.XtraForm
    {
        #region "  Variables declaration  "

        private BackgroundWorker _bwLoad = null;
        private BackgroundWorker _bwLoadCode = null;
        private DataSet dsMainData = new DataSet();
        private DataSet dsEdit = new DataSet();

        cls_Struct.ActionMode DataMode = 0;
        cls_Struct.StructBrands SBrands;
        int ItemID = 0;
        private int _Codeid = 0;
        private bool IsSaveOK = false;

        #endregion

        #region "  Function  "
        private void AssignDataFromComponent()
        {
            SBrands.BRAND_ID = ItemID;
            SBrands.BRAND_CODE = TxtBrandCode.Text.Trim();
            SBrands.BRAND_NAME = TxtBrandName.Text.Trim();
            SBrands.DESCRIPTION = TxtBrandDesc.Text.Trim();
            SBrands.ADDITION_DESCRIPTION = TxtBrandDesc.Text.Trim();
            SBrands.SETUP_PRICE_DATE = cls_Library.DBDateTime(datePriceDate.DateTime);
            SBrands.TAX_INVOICE_VAT_STATUS = radioReceiveVAT.SelectedIndex + 1;
            SBrands.CURRENT_VAT_STATUS = radioVatStatus.SelectedIndex + 1;
            SBrands.SALE_CODE = radioSetPrice.SelectedIndex + 1;
            SBrands.PRINT_TYPE = radioPrintType.SelectedIndex + 1;
            SBrands.CREATE_DATE = DateTime.Now;
            SBrands.CREATE_BY = cls_Global_class.GB_Userid;
            SBrands.UPDATE_DATE = DateTime.Now;
            SBrands.UPDATE_BY = cls_Global_class.GB_Userid;
            SBrands.DELETED = false;
            SBrands.DELETE_BY = cls_Global_class.GB_Userid;
            SBrands.DELETE_DATE = DateTime.Now;
        }

        private void AddDataSourceToGrid()
        {
            try
            {
            cls_Global_DB.GB_Dbrand_Salediscount = 0;
            cls_Global_DB.GB_Dbrand_Buydiscount = 0;

            cls_Global_DB.GB_Dbrand_Salediscount = dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].Rows.Count;
            gridSaleDis.DataSource = dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"];
            gridSaleDis.RefreshDataSource();

            cls_Global_DB.GB_Dbrand_Buydiscount = dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"].Rows.Count;
            gridBuyDis.DataSource = dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"];
            gridBuyDis.RefreshDataSource();

            gridCusDis.DataSource = dsEdit.Tables["D_DISCOUNT_RATE"];
            gridCusDis.RefreshDataSource();
            }
            catch (Exception ex)
            {
            MessageBox.Show("AddDataSourceToGrid :" + ex.Message);
            }
        }

        void _bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
            SetDataToControl();
            }
            catch { }
            finally { Cursor = Cursors.Default; }
        }

        void _bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dsMainData = cls_Data.GetListBrandsById(ItemID);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private bool CheckCodeExist(string Xcode)
        {
            bool err = false;
            //string User = "";
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = conn.CreateCommand();
            SqlDataReader rd = null;
            int id = 0;

            cls_Global_DB.ConnectDatabase(ref conn);

            err = false;
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT BRAND_ID,BRAND_CODE FROM M_BRANDS WHERE BRAND_CODE='" + Xcode + "' And DELETED=0";
            cmd.Connection = conn;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
            if ((DataMode == cls_Struct.ActionMode.Edit) || (DataMode == cls_Struct.ActionMode.Copy))
            {
                rd.Read();
                id = Convert.ToInt32(rd["BRAND_ID"]);
                if (id != ItemID)
                {
                err = true;
                }
            }
            else
            {
                err = true;
            }
            }

            if (!rd.IsClosed) rd.Close();

            return err;

        }

        private string GetVatStatus(int Vstatus)
        {
            string Xstr = "";
            switch (Vstatus)
            {
                case 1: Xstr = "Vat นอก"; break;
                case 2: Xstr = "Vat ใน"; break;
                case 3: Xstr = "ไม่มี Vat"; break;
            }
            return Xstr;
        }

        public void InitialDialogBuyDiscount(int mode)
    {
        frmD_BrandBuyDiscount_Input frmInput;
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

        frmInput = new frmD_BrandBuyDiscount_Input();
        frmInput.StartPosition = FormStartPosition.CenterParent;

        if (mode == 0)
        strMode = " [เพิ่ม]";
        else if (mode == 1)
        strMode = " [แก้ไข]";


        try
        {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvBuyDis;
        if ((view.FocusedRowHandle < 0))
        {
            if (mode != 0)
            {
            return;
            }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "ส่วนลดซื้อ" + strMode;
        #region "XXX"
        if (dr != null)
        {
            if ((mode == 1) || (mode == 2))
            {
            if (mode == 1)
            {
                frmInput.spinDisCount.EditValue = cls_Library.DBDecimal(dr["DISCOUNT_RATE"]);
            }
            else
            {
                DataTable dt = (DataTable)gridBuyDis.DataSource;
                frmInput.spinDisCount.EditValue = 0;
            }
            frmInput.radioVatStatus.SelectedIndex = cls_Library.DBInt(dr["VAT_STATUS"]) -1;
            bool sEnable = cls_Library.DBbool(dr["ACTIVE_STATUS"]);
            frmInput.radioStatus.SelectedIndex = sEnable == true ? 0 : 1;
            }
            else
            {
            DataTable dt = (DataTable)gridBuyDis.DataSource;
            }
        }
        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
            return;
        }

        dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"].BeginInit();
        if (Xmode == 0)
        {
            DataTable dtv = (DataTable)gridBuyDis.DataSource;
            DataTable dt = dtv.Clone();
            dt.Rows.Add();
            dt.Rows[0]["BRAND_ID"] = ItemID;
            dt.Rows[0]["DISCOUNT_RATE"] = cls_Library.DBInt(frmInput.spinDisCount.EditValue);
            dt.Rows[0]["VAT_STATUS"] = cls_Library.DBInt(frmInput.radioVatStatus.SelectedIndex) + 1;
                    dt.Rows[0]["_VAT_STATUS"] = GetVatStatus(cls_Library.DBInt(frmInput.radioVatStatus.SelectedIndex) + 1);
            dt.Rows[0]["ACTIVE_STATUS"] = cls_Library.DBInt(frmInput.radioStatus.SelectedIndex) == 0 ? true : false;
            dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"].ImportRow(dt.Rows[0]);
        }
        else
        {
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvBuyDis;
            dr = view.GetFocusedDataRow();
            dr["BRAND_ID"] = ItemID;
            dr["DISCOUNT_RATE"] = cls_Library.DBInt(frmInput.spinDisCount.EditValue);
            dr["VAT_STATUS"] = cls_Library.DBInt(frmInput.radioVatStatus.SelectedIndex) + 1;
                    dr["_VAT_STATUS"] = GetVatStatus(cls_Library.DBInt(frmInput.radioVatStatus.SelectedIndex) + 1);
                    dr["ACTIVE_STATUS"] = cls_Library.DBInt(frmInput.radioStatus.SelectedIndex) == 0 ? true : false;
        }
        dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"].EndInit();
        gridBuyDis.DataSource = dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"];
        gridBuyDis.RefreshDataSource();
        }
        catch (Exception ex)
        {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
        }
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
                //frmInput.txtDiscountCode.Text = cls_Data.GetLastCodeDetailMasterAlphabet("D_BRAND_SALE_DISCOUNT_STEPS", ItemID);
                }
            }
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridSaleDis.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["BRAND_ID"] = ItemID;
                dt.Rows[0]["DISCOUNT_CODE"] = cls_Library.DBString(frmInput.txtDiscountCode.Text);
                dt.Rows[0]["DISCOUNT_RATE_STEP1"] = cls_Library.DBDecimal(frmInput.spinDisC1.EditValue);
                //dt.Rows[0]["DISCOUNT_RATE_STEP2"] = cls_Library.DBDecimal(frmInput.spinDisC2.EditValue);
                //dt.Rows[0]["DISCOUNT_RATE_STEP3"] = cls_Library.DBDecimal(frmInput.spinDisC3.EditValue);
                //dt.Rows[0]["DISCOUNT_RATE_STEP4"] = cls_Library.DBDecimal(frmInput.spinDisC4.EditValue);
                dt.Rows[0]["ENABLED_STATUS"] = frmInput.radioStatus.SelectedIndex == 0 ? true : false;
                dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSaleDis;
                dr = view.GetFocusedDataRow();
                dr["BRAND_ID"] = ItemID;
                dr["DISCOUNT_CODE"] = cls_Library.DBString(frmInput.txtDiscountCode.Text);
                dr["DISCOUNT_RATE_STEP1"] = cls_Library.DBDecimal(frmInput.spinDisC1.EditValue);
                //dr["DISCOUNT_RATE_STEP2"] = cls_Library.DBDecimal(frmInput.spinDisC2.EditValue);
                //dr["DISCOUNT_RATE_STEP3"] = cls_Library.DBDecimal(frmInput.spinDisC3.EditValue);
                //dr["DISCOUNT_RATE_STEP4"] = cls_Library.DBDecimal(frmInput.spinDisC4.EditValue);
                dr["ENABLED_STATUS"] = frmInput.radioStatus.SelectedIndex == 0 ? true : false;
            }
            dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].EndInit();
            gridSaleDis.DataSource = dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"];
            gridSaleDis.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        private bool SaveData()
        {
            DataTable TB = new DataTable();
            DataTable tbGRP = new DataTable();
            DataRow drow = null;
            string Pass = String.Empty;
            int SaveMode = 0;
            bool ret = false;

            try
            {
            drow = null;

            if ((DataMode == cls_Struct.ActionMode.Add) || (DataMode == cls_Struct.ActionMode.Copy))
            {
                SaveMode = 1;
            }
            else
            {
                SaveMode = 2;
            }
            AssignDataFromComponent();

            //--- Save ข้อมูลลงฐานข้อมูล 
            cls_Global_DB.GB_ItemID = 0;
            ret = cls_Data.SaveBrandCode(SaveMode, SBrands, dsEdit);
            ItemID = cls_Global_DB.GB_ItemID;
            DataMode = cls_Struct.ActionMode.Edit;
            if (!_bwLoad.IsBusy)
            {
                this.UseWaitCursor = true;
                _bwLoad.RunWorkerAsync();
                this.UseWaitCursor = false;
            }

            }
            catch (Exception ex)
            {
            Application.DoEvents();
            if (ex.Message.IndexOf("Cannot insert duplicate key") > -1)
            {
                TxtBrandCode.ErrorText = "";
                TxtBrandCode.Focus();
            }
            else
            {
                XtraMessageBox.Show("ไม่สามารถบันทึกรหัสยี่ห้อสินค้าได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ret = false;
            }

            return ret;
        }

        private void SetDataToControl()
        {
            DataRow row = null;
            try
            {
                dsEdit = dsMainData.Copy();

                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                    TxtBrandCode.Text = cls_Data.GetLastCodeMaster("BRANDS", 4);
                    break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.Copy:
                    if (dsEdit.Tables["M_BRANDS"].Rows.Count <= 0) return;
                    row = dsEdit.Tables["M_BRANDS"].Rows[0];
                    TxtBrandCode.Text = cls_Library.DBString(row["BRAND_CODE"]);
                    TxtBrandName.Text = cls_Library.DBString(row["BRAND_NAME"]);
                    TxtBrandDesc.Text = cls_Library.DBString(row["DESCRIPTION"]);
                    TxtBrandAddDesc.Text = cls_Library.DBString(row["ADDITION_DESCRIPTION"]);
                    if ((cls_Library.DBDateTime(row["SETUP_PRICE_DATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["SETUP_PRICE_DATE"]) == DateTime.MaxValue))
                    {
                        datePriceDate.Text = "";
                    }
                    else
                    {
                        datePriceDate.DateTime = cls_Library.DBDateTime(row["SETUP_PRICE_DATE"]);
                    }

                    radioReceiveVAT.SelectedIndex = cls_Library.DBInt(row["TAX_INVOICE_VAT_STATUS"]) - 1;
                    radioVatStatus.SelectedIndex = cls_Library.DBInt(row["CURRENT_VAT_STATUS"]) - 1;
                    radioSetPrice.SelectedIndex = cls_Library.DBInt(row["SALE_CODE"]) - 1;
                    radioPrintType.SelectedIndex = cls_Library.DBInt(row["PRINT_TYPE"]) - 1;
                    break;
                }
                AddDataSourceToGrid();
                if (cls_Data.CheckUseBrandByItem(ItemID))
                {
                    radioSetPrice.Enabled = false;
                }
                else
                {
                    radioSetPrice.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetDataToControl :" + ex.Message);
            }
        }

        private void ThreadStart()
        {
            _bwLoad = new BackgroundWorker();
            _bwLoad.WorkerReportsProgress = true;
            _bwLoad.WorkerSupportsCancellation = true;
            _bwLoad.DoWork += new DoWorkEventHandler(_bwLoad_DoWork);
            _bwLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bwLoad_RunWorkerCompleted);

            _bwLoad.RunWorkerAsync();
        }
        #endregion

        public frm_Brands_Record(cls_Struct.ActionMode mode, int id)
        {
            InitializeComponent();
            DataMode = mode;
            ItemID = id;
            this.KeyPreview = true;
            TxtBrandCode.ReadOnly = true;
            TxtBrandCode.BackColor = Color.Yellow;
            ThreadStart();
            TxtBrandCode.Focus();
        }

        private void BTcancel_Click(object sender, EventArgs e)
        {
            if (IsSaveOK)
            DialogResult = DialogResult.OK;
            else
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            bool err = false;

            if (TxtBrandCode.EditValue == null || TxtBrandCode.Text == "")
            {
                XtraMessageBox.Show("กรุณาระบุรหัสยี่ห้อสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBrandCode.ErrorText = "กรุณาระบุรหัสยี่ห้อสินค้า";
                TxtBrandCode.Focus();
                err = true;
            }
            else
            {
                if (CheckCodeExist(TxtBrandCode.Text.Trim()))
                {
                    XtraMessageBox.Show("มีรหัสยี่ห้อสินค้านี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtBrandCode.ErrorText = "มีรหัสยี่ห้อสินค้านี้ในฐานข้อมูลแล้ว";
                    TxtBrandCode.Focus();
                    err = true;
                }
            }

            if (!err)
            {
                if (TxtBrandName.EditValue == null || TxtBrandName.Text == "")
                {
                    XtraMessageBox.Show("กรุณาระบุชื่อยี่ห้อสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtBrandName.ErrorText = "กรุณาระบุชื่อยี่ห้อสินค้า";
                    TxtBrandName.Focus();
                    err = true;
                }
            }

            DataTable dt = dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"];

            int iCount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool OK = false;
                OK = cls_Library.DBbool(dt.Rows[i]["ACTIVE_STATUS"]);
                if (OK) iCount++;
            }
            if (iCount > 1)
            {
                XtraMessageBox.Show("เลือกใช้แสดงต้นทุนได้เพียง 1 เท่านั้น", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = true;
                return;
            }

            if (err)
            {
                return;
            }

            DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสยี่ห้อสินค้า : " + TxtBrandCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                if (SaveData())
                {
                    if (cls_Global_DB.DataInitial.Tables.Contains("M_BRANDS"))
                    {
                        cls_Global_DB.DataInitial.Tables.Remove("M_BRANDS");
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_BRANDS"));
                    }
                    XtraMessageBox.Show("บันทึกรหัสยี่ห้อสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsSaveOK = true;
                    if (((SimpleButton)sender).Tag.ToString() == "1")
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();  
                    }
                }
                else
                {
                    IsSaveOK = false;
                    XtraMessageBox.Show("บันทึกรหัสยี่ห้อสินค้าไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
      
        }

        private void BTreset_Click(object sender, EventArgs e)
        {
            TxtBrandName.Text = "";
            TxtBrandDesc.Text = "";
        }

        private void frm_Brands_Record_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.F2:
                BTsave_Click(sender, e);
                break;
            case Keys.F3:
                BTreset_Click(sender, e);
                break;
            case Keys.Escape:
                BTcancel_Click(sender, e);
                break;
            }
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
                dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].AcceptChanges();
                dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].Rows[irow].Delete();
                Drow.Delete();
                dsEdit.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].AcceptChanges();
                gvSaleDis.RefreshData();
                gridSaleDis.RefreshDataSource();
            }
        }

        private void btBuyDiscountDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvBuyDis.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvBuyDis.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"].AcceptChanges();
            dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_BRAND_REFERENCE_DISCOUNTS"].AcceptChanges();
            gvBuyDis.RefreshData();
            gridBuyDis.RefreshDataSource();
            }
        }

        private void btBuyDiscountAdd_Click(object sender, EventArgs e)
        {
            InitialDialogBuyDiscount(0);
        }

        private void btBuyDiscountEdit_Click(object sender, EventArgs e)
        {
            InitialDialogBuyDiscount(1);
        }
    }
}