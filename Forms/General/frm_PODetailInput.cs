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

namespace SmartPart.Forms.General
{
    public partial class frm_PODetailInput : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private bool IsSaveOK = false;

        cls_Struct.ActionMode DataMode;
        DataSet dsEdit = new DataSet();
        DataRow EditData = null;
        DataTable dtUnit = new DataTable();
        int IdNo = 0, ListNo;

        double Zconv = 1;
        double Zquan = 0.00;
        decimal Zuprice = 0;
        decimal Zcog = 0;
        decimal ZsumVat = 0;
        decimal ZnosumVat = 0;
        decimal ZdiscA = 0;
        float Zvat = 0;
        #endregion

        #region Property

        public DataSet SetDatasetEdit
        {
            set { dsEdit = value; }
            get { return dsEdit; }
        }

        public DataRow SetEditData
        {
            set { EditData = value; }
        }

        public int SetListNo
        {
            set { ListNo = value; }
        }

        public int DataID
        {
            set { IdNo = value; }
        }

        #endregion

        #region Function

        private int AssigNo()
        {
            int no = 1;
            List<DataRow> ListNo = new List<DataRow>();
            try
            {
                if (DataMode != cls_Struct.ActionMode.Add)
                {
                    ListNo = dsEdit.Tables["PODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                }
                else
                {
                    ListNo = dsEdit.Tables["PODETAIL"].AsEnumerable().ToList();
                }
                
                if (ListNo.Count() > 0)
                    no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show("AssigNo :" + ex.Message); }
            return no;
        }

        private void ClearData()
        {            
            DataMode = cls_Struct.ActionMode.Add;
            //spinListNo.EditValue
            sluItem.EditValue = 0;
            txtFullName.Text = "";
            txtGenuinPartId.Text = "";
            txtBrandPartId.Text = "";
            txtModel1.Text = "";
            sluBrand.EditValue = 0;
            spinQtyLocation.EditValue = 0;
            spinQTY.EditValue = 0;
            spinMinQty.EditValue = 0;
            sluUnit.EditValue = 0;
            spinBuyPrice.EditValue = 0;
            comboVatStatus.SelectedIndex = 0;
            sluSpecialOrder.EditValue = 0;
            txtNote.Text = "";
            ListNo = AssigNo();
            txtBrandPrint.Text = "";

            Zquan = 0;
            Zconv = 1;
            Zcog = 0;
            ZnosumVat = 0;
            Zuprice = 0;
            ZdiscA = 0;
            ZsumVat = 0;
        }

        private void CalculateValue(cls_Global_class.TypeCal category)
        {
            try
            {
                Zquan = cls_Library.CDouble(spinQTY.EditValue) * Zconv;

                switch (category)
                {
                    case cls_Global_class.TypeCal.price:
                        if (Zquan > 0)
                        {
                            Zuprice = (Zcog * (decimal)Zconv) / cls_Library.CDecimal(Zquan);
                        }
                        break;
                    case cls_Global_class.TypeCal.quantity:
                        Zcog = (Zuprice * (decimal)Zquan) / (decimal)Zconv;
                        break;
                    case cls_Global_class.TypeCal.unitprice:
                        Zcog = (Zuprice * cls_Library.CDecimal(Zquan)) / (decimal)Zconv;
                        break;
                }
                RecalChangeValue();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("CalculateValue : " + category + ":" + ex.Message);
            }
        }

        private void EditRowData()
        {
            int idx = 0;
            try
            {
                var array1 = EditData.ItemArray;
                foreach (DataRow drRows in dsEdit.Tables["PODETAIL"].Rows)
                {
                    var array2 = drRows.ItemArray;
                    if (array1.SequenceEqual(array2))
                    break;

                    idx++;
                }
                DataRow row = dsEdit.Tables["PODETAIL"].Rows[idx];

                row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                row["BRAND_PART_ID"] = txtBrandPartId.Text;
                row["FULL_NAME"] = txtFullName.Text;
                row["MODEL1"] = txtModel1.Text;
                row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                row["LOCATION_QTY"] = cls_Library.DBDecimal(spinQtyLocation.EditValue);
                row["QTY"] = Zquan; //cls_Library.DBInt(spinQTY.EditValue);
                row["CONV"] = Zconv;
                row["MINIMUM_QTY"] = cls_Library.DBDecimal(spinMinQty.EditValue);
                row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
                row["BUY_PRICE"] = cls_Library.DBDecimal(spinBuyPrice.EditValue);
                row["COG"] = Zcog;
                row["PRICEVAT"] = ZsumVat;
                row["PRICESUM"] = cls_Library.CDecimal(spinNet.EditValue);
                row["NOSUMVAT"] = ZnosumVat;
                row["VAT_STATUS"] = comboVatStatus.SelectedIndex + 1;
                row["SPECIAL_ORDER"] = cls_Library.DBInt(sluSpecialOrder.EditValue);
                row["NOTE"] = txtNote.Text;
                row["BRAND_PRINT"] = txtBrandPrint.Text;

                row["mode"] = DataMode;

                dsEdit.Tables["PODETAIL"].AcceptChanges();
                EditData.ItemArray = row.ItemArray;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("EditRowData :" + ex.Message);
                IsSaveOK = false;
            }
        }

        public void InitialDialog(cls_Struct.ActionMode mode)
        {
            try
            {
                DataMode = mode;
                if (DataMode == cls_Struct.ActionMode.Copy) DataMode = cls_Struct.ActionMode.Add;
                LoadDefaultData();
                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                        sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = EditData["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                        //txtBrand.Text = dsEdit.Tables["PODETAIL"].Rows[0]["BRAND_NAME"].ToString();
                        txtModel1.Text = EditData["MODEL1"].ToString();
                        sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                        txtBrand.Text = sluBrand.Text;
                        spinQtyLocation.EditValue = 0;// cls_Library.DBDecimal(EditData["LOCATION_QTY"]);
                        Zquan = cls_Library.DBInt(EditData["QTY"]);
                        if (Zconv == 0) Zconv = 1;
                        spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
                        spinMinQty.EditValue = cls_Library.DBDecimal(EditData["MINIMUM_QTY"]);                        
                        spinBuyPrice.EditValue = 0;// cls_Library.DBDecimal(EditData["BUY_PRICE"]);
                        txtBrandPrint.Text = EditData["BRAND_PRINT"].ToString();

                        //XXXXXXXXXXXXXXXXXX
                        spinNet.EditValue = 0;
                        ZnosumVat = 0;
                        ZsumVat = 0;
                        Zuprice = cls_Library.CDecimal(spinBuyPrice.EditValue);
                        Zcog = 0;
                        Zvat = 7;
                        int DefVAT = cls_Library.DBInt(cls_Data.GetNameFromTBname(cls_Library.DBInt(EditData["BRAND_ID"]), "BRANDS", "CURRENT_VAT_STATUS"));

                        //comboVatStatus.SelectedIndex = 1;   //Default vat ใน
                        comboVatStatus.SelectedIndex = DefVAT - 1;   //Default vat ใน
                        sluSpecialOrder.EditValue = 0;
                        txtNote.Text = "";// EditData["NOTE"].ToString();
                        break;
                    case cls_Struct.ActionMode.View:
                    case cls_Struct.ActionMode.Edit:
                        if (EditData == null) return;                        
                        IdNo = cls_Library.DBInt(EditData["POD_ID"]);
                        sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = EditData["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                        txtBrand.Text = dsEdit.Tables["PODETAIL"].Rows[0]["BRAND_NAME"].ToString();
                        txtModel1.Text = EditData["MODEL1"].ToString();
                        sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                        spinQtyLocation.EditValue = cls_Library.DBDecimal(EditData["LOCATION_QTY"]);
                        Zquan = cls_Library.DBInt(EditData["QTY"]);
                        Zconv = cls_Library.DBDouble(EditData["CONV"]);
                        if (Zconv == 0) Zconv = 1;
                        spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
                        spinMinQty.EditValue = cls_Library.DBDecimal(EditData["MINIMUM_QTY"]);
                        sluUnit.EditValue = cls_Library.DBInt(EditData["UNIT_ID"]);
                        spinBuyPrice.EditValue = cls_Library.DBDecimal(EditData["BUY_PRICE"]);
                        txtBrandPrint.Text = EditData["BRAND_PRINT"].ToString();

                        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        Zcog = cls_Library.DBDecimal(EditData["COG"]);
                        ZsumVat = cls_Library.DBDecimal(EditData["PRICEVAT"]);
                        Zvat = 7;
                        ZnosumVat = cls_Library.DBDecimal(EditData["NOSUMVAT"]);
                        Zuprice = cls_Library.CDecimal(spinBuyPrice.EditValue);
                        spinNet.EditValue = cls_Library.DBDecimal(EditData["PRICESUM"]);

                        comboVatStatus.SelectedIndex = cls_Library.DBByte(EditData["VAT_STATUS"]) - 1;
                        sluSpecialOrder.EditValue = cls_Library.DBInt(EditData["SPECIAL_ORDER"]);
                        txtNote.Text = EditData["NOTE"].ToString();
                        break;
                }

                spinQTY.Select();
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("InitialDialog :" + ex.Message);
            }            
        }

        private void LoadDefaultData()
        {
            try
            {
                comboVatStatus.Properties.Items.Add("Vat นอก");
                comboVatStatus.Properties.Items.Add("Vat ใน");
                comboVatStatus.Properties.Items.Add("ไม่มี Vat");

                cls_Library.AssignSearchLookUp(sluItem, "M_ITEMS", "รหัสสินค้า", "ชื่อสินค้า");
                cls_Library.AssignSearchLookUp(sluBrand, "M_BRANDS", "รหัสยี่ห้อ", "ชื่อยี่ห้อ", cls_Global_class.TypeShow.codename);
                //cls_Library.AssignSearchLookUp(sluUnit, "M_UNITS", "รหัสหน่วยนับ", "ชื่อหน่วยนับ");
                cls_Library.AssignSearchLookUp(sluSpecialOrder, "M_SPECIALS", "รหัสคำสั่งพิเศษ", "ชื่อคำสั่งพิเศษ", cls_Global_class.TypeShow.name);
                SetControl();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
            }
        }

        private void RecalChangeValue()
        {
            try
            {
                Zuprice = Zquan == 0 ? 0 : (Zcog * (decimal)Zconv) / Convert.ToDecimal(Zquan);
                ZnosumVat = (cls_Global_class.TypePrice)comboVatStatus.SelectedIndex == cls_Global_class.TypePrice.SUMVAT ? (Zcog - ZdiscA) - ZsumVat : Zcog - ZdiscA;

                spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
                spinBuyPrice.Value = cls_Library.CDecimal(Zuprice);

                if (Zcog - ZdiscA <= 0)
                {
                    ZsumVat = 0; //Zvat = 0;
                }
                else
                {
                    if ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex == cls_Global_class.TypePrice.NOTVAT)
                    {
                        ZsumVat = 0;//Zvat = 0; 
                    }
                    else
                    {
                        if (ZsumVat > 0 && Zvat == 0)
                            if (ZnosumVat > 0) Zvat = (float)cls_Library.CalCulateTax((cls_Global_class.TypePrice)5, cls_Global_class.TypeCal.taxrate, 0, ZnosumVat, ZsumVat);

                        ZsumVat = cls_Library.CalCulateTax((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex, cls_Global_class.TypeCal.recalTax, cls_Library.CDecimal(Zvat), (Zcog - ZdiscA), ZsumVat);                        
                    }
                }
                switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
                {
                    case cls_Global_class.TypePrice.NOSUMVAT:
                        spinNet.Value = Zcog - ZdiscA + ZsumVat;
                        break;
                    case cls_Global_class.TypePrice.SUMVAT:
                    case cls_Global_class.TypePrice.NOTVAT:
                        spinNet.Value = Zcog - ZdiscA;
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("RecalChangeValue: " + ex.Message);
            }
        }

        private void SaveData()
        {
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return;

                IsSaveOK = true;
                if (DataMode != cls_Struct.ActionMode.Add)
                {
                    EditRowData();
                }
                else
                {
                    DataTable dt = dsEdit.Tables["PODETAIL"].Clone();
                    DataColumn colMode = new DataColumn("mode", typeof(int));
                    dt.Columns.Add(colMode);
                    ListNo = AssigNo();
                    DataRow row = dt.NewRow();
                    row["POD_ID"] = -1;
                    row["POD_PID"] = IdNo;
                    row["LIST_NO"] = ListNo;
                    row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                    row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                    row["BRAND_PART_ID"] = txtBrandPartId.Text;
                    row["FULL_NAME"] = txtFullName.Text;
                    row["MODEL1"] = txtModel1.Text;
                    row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                    row["LOCATION_QTY"] = cls_Library.DBDecimal(spinQtyLocation.EditValue);
                    row["QTY"] = Zquan;
                    row["CONV"] = Zconv;
                    row["MINIMUM_QTY"] = cls_Library.DBDecimal(spinMinQty.EditValue);
                    row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
                    row["BUY_PRICE"] = cls_Library.DBDecimal(spinBuyPrice.EditValue);
                    row["COG"] = Zcog;
                    row["PRICEVAT"] = ZsumVat;
                    row["PRICESUM"] = cls_Library.CDecimal(spinNet.EditValue);
                    row["NOSUMVAT"] = ZnosumVat;

                    row["VAT_STATUS"] = comboVatStatus.SelectedIndex + 1;
                    row["SPECIAL_ORDER"] = cls_Library.DBInt(sluSpecialOrder.EditValue);
                    row["NOTE"] = txtNote.Text;
                    row["BRAND_PRINT"] = txtBrandPrint.Text.Trim();

                    row["mode"] = DataMode;

                    dt.Rows.Add(row);
                    dsEdit.Tables["PODETAIL"].ImportRow(row);

                    SaveNewDetail(dt);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SaveData :" + ex.Message);
                IsSaveOK = false;
            }
            finally
            {
                if (IsSaveOK) btClose_Click(null, null);
            }
        }

        private void SaveNewDetail(DataTable dt)
        {
            SqlConnection conn = new SqlConnection();
            SqlTransaction tran = null;
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();
            try
            {
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    if (cls_Data.SavePODetail(IdNo, dt, ref conn, ref tran))
                    {                        
                        decimal SumCog = dsEdit.Tables["PODETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("COG") ?? 0);
                        decimal SumVat = dsEdit.Tables["PODETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("PRICEVAT") ?? 0);
                        decimal SumNet = dsEdit.Tables["PODETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("PRICESUM") ?? 0);

                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            sb.Clear();
                            sb.AppendLine("UPDATE POHEADER WITH (UPDLOCK) SET");
                            sb.AppendLine("LIST_NO = @LIST_NO,");
                            sb.AppendLine("SUMCOG = @SUMCOG,");
                            sb.AppendLine("VATSUM = @VATSUM,");
                            sb.AppendLine("DISCLST = @DISCLST,");
                            sb.AppendLine("NETSUM = @NETSUM,");
                            sb.AppendLine("UPDATE_BY = @UPDATE_BY,");
                            sb.AppendLine("UPDATE_DATE = @UPDATE_DATE");
                            sb.AppendLine("WHERE POH_ID = @POH_ID");
                            
                            cmd.CommandText = sb.ToString();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();
                            cmd.Transaction = tran;

                            cmd.Parameters.Add("@LIST_NO", SqlDbType.Int).Value = dsEdit.Tables["PODETAIL"].AsEnumerable().Count();
                            cmd.Parameters.Add("@SUMCOG", SqlDbType.Decimal).Value = SumCog;
                            cmd.Parameters.Add("@VATSUM", SqlDbType.Decimal).Value = SumVat;
                            cmd.Parameters.Add("@DISCLST", SqlDbType.Decimal).Value = 0;
                            cmd.Parameters.Add("@NETSUM", SqlDbType.Decimal).Value = SumNet;
                            cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                            cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.Parameters.Add("@POH_ID", SqlDbType.Int).Value = IdNo;

                            cmd.ExecuteNonQuery();
                            tran.Commit();

                            cls_Data.UpdateLastTransfer(cls_Struct.VoucherType.PO, dt);
                            XtraMessageBox.Show("บันทึกรายการใบสั่งซื้อเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                        
                    }
                    else
                    {
                        tran.Rollback();
                        //Remove List
                        DataRow[] dr = dsEdit.Tables["PODETAIL"].Select("LIST_NO =" + ListNo);
                        if (dr.Count() > 0)
                            dsEdit.Tables["PODETAIL"].Rows.Remove(dr[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //Remove List
                DataRow[] dr = dsEdit.Tables["PODETAIL"].Select("LIST_NO =" + ListNo);
                if (dr.Count() > 0)
                    dsEdit.Tables["PODETAIL"].Rows.Remove(dr[0]);
                XtraMessageBox.Show("SaveNewDetail :" + ex.Message);
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn); conn.Dispose();
            }
        }

        private void SetControl()
        {
            try
            {
            sluItem.ReadOnly = true;
            switch (DataMode)
            {
                case cls_Struct.ActionMode.Add:
                txtFullName.ReadOnly = true;
                txtModel1.ReadOnly = true;
                sluBrand.ReadOnly = true;
                //sluUnit.ReadOnly = true;
                //comboVatStatus.ReadOnly = true;
                //sluSpecialOrder.ReadOnly = true;
                //txtNote.ReadOnly = true;
                break;
                case cls_Struct.ActionMode.Edit:
                case cls_Struct.ActionMode.View:
                btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;                        
                txtGenuinPartId.ReadOnly = true;
                txtBrandPartId.ReadOnly = true;      
                break;
            }
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("SetControl :" + ex.Message);
            }
        }

        private void SetDetailItem(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = cls_Data.GetDetailItem(id);
                if (dt.Rows.Count > 0)
                {
                    //Set Detail Item
                    DataRow dr = dt.Rows[0];
                    txtFullName.Text = dr["FULL_NAME"].ToString();
                    txtGenuinPartId.Text = dr["GENUIN_PART_ID"].ToString();
                    txtBrandPartId.Text = dr["BRAND_PART_ID"].ToString();
                    txtBrandPrint.Text = dr["BRAND_PRINT"].ToString();
                }
                else
                {
                    //Clear Detail Item
                    txtFullName.Text = "";
                    txtGenuinPartId.Text = "";
                    txtBrandPartId.Text = "";
                    txtBrandPrint.Text = "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetDetailItem :" + ex.Message);
            }
        }

        private void SetUnit(int ItemId)
        {
            try
            {
                //dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId);
                //2022-06-06
                dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId, "", false);

                string[] selectedColumns = new[] { "_id", "code", "name", "MULTIPLY_QTY","codename" };
                DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
                sluUnit.Properties.DataSource = dt;
                sluUnit.Properties.PopulateViewColumns();
                sluUnit.Properties.View.Columns["_id"].Visible = false;
                sluUnit.Properties.View.Columns["codename"].Visible = false;
                sluUnit.Properties.View.Columns["code"].Caption = "รหัสหน่วยนับ";
                sluUnit.Properties.View.Columns["name"].Caption = "ชื่อหน่วยนับ";
                sluUnit.Properties.View.Columns["MULTIPLY_QTY"].Caption = "จำนวนหน่วยย่อย";

                sluUnit.Properties.ValueMember = "_id";
                //sluUnit.Properties.DisplayMember = "name";
                sluUnit.Properties.DisplayMember = "codename";

                //Default BUY_STATUS 2022-09-19
                if (dtUnit.Rows.Count > 0)
                {
                    List<DataRow> lst = dtUnit.AsEnumerable().Where(r => r.Field<Boolean>("BUY_STATUS") == true).ToList();
                    if (lst.Count > 0)
                    {
                        sluUnit.EditValue = cls_Library.DBInt(lst[0]["UNIT_ID"]);
                        Zconv = cls_Library.DBDouble(lst[0]["MULTIPLY_QTY"]);
                    }
                    //sluUnit.EditValue = cls_Library.DBInt(dtUnit.Rows[0]["UNIT_ID"]);
                    //Zconv = cls_Library.DBDouble(dtUnit.Rows[0]["MULTIPLY_QTY"]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetLocation :" + ex.Message);
            }
        }

        private bool VerifyData()
        {
            bool ret = true;
            StringBuilder msg = new StringBuilder();
            try
            {
                if (sluItem.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสสินค้าไม่ถูกต้อง");
                }
                if ((spinQTY.EditValue == null) || (cls_Library.DBDouble(spinQTY.EditValue) <= 0))
                {
                    ret = false;
                    msg.AppendLine("ปริมาณสินค้าไม่ถูกต้อง");
                }
                

                if (sluUnit.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสหน่วยนับไม่ถูกต้อง");
                }

                if ((comboVatStatus.EditValue == null) || (comboVatStatus.Text == ""))
                {
                    ret = false;
                    msg.AppendLine("สถานะ VAT ไม่ถูกต้อง");
                }
                

                if (!ret)
                {
                    MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("VerifyData :" + ex.Message);
            }
            return ret;
        }


        #endregion

        public frm_PODetailInput()
        {
            InitializeComponent();
            this.KeyPreview = true;
            spinQTY.Select();
        }

        private void frm_PODetailInput_Load(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                SaveData();
                DialogResult = DialogResult.OK;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (IsSaveOK)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void sluItem_EditValueChanged(object sender, EventArgs e)
        {
            if (sluItem.IsEditorActive) SetDetailItem(cls_Library.CInt(sluItem.EditValue));
        }

        private void spinQTY_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
            if (spinQTY.Value <= 0)
            {
                spinQTY.Value = 0;
            }

            if ((Zquan / Zconv) != cls_Library.CDouble(spinQTY.Value))
            {
                Zquan = cls_Library.CDouble(spinQTY.Value) * Zconv;
                if (spinQTY.IsEditorActive) CalculateValue(cls_Global_class.TypeCal.quantity);
            }
            }
            catch { }
        }

        private void sluUnit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit _sender = (SearchLookUpEdit)sender;

                if (_sender.EditValue != null)
                {
                    DataRow[] xrow = dtUnit.Select("UNIT_ID = " + _sender.EditValue + "");
                    if (xrow.Length > 0)
                        Zconv = cls_Library.DBDouble(xrow[0]["MULTIPLY_QTY"]);
                    else
                        Zconv = 1;
                }
                if (sluUnit.IsEditorActive) CalculateValue(cls_Global_class.TypeCal.quantity);
            }
            catch (Exception)
            {
                Zconv = 1;
            }        
        }

        private void spinBuyPrice_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Zuprice != cls_Library.CDecimal(spinBuyPrice.Value))
                {
                    Zuprice = cls_Library.CDecimal(spinBuyPrice.Value);
                    if (cls_Library.CDecimal(spinBuyPrice.Value) < 0) Zuprice = 0;
                    //if (spinBuyPrice.IsEditorActive)
                    CalculateValue(cls_Global_class.TypeCal.unitprice);
                }
            }
            catch { }
        }

        private void frm_PODetailInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.F2:
                btSave.PerformClick();
                break;
            case Keys.Escape:
                btClose.PerformClick();
                break;
            }
        }

        private void comboVatStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboVatStatus.IsEditorActive) RecalChangeValue();            
        }
    }
}