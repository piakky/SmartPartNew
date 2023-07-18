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
    public partial class frm_RODetailInput : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private bool IsSaveOK = false;
        cls_Struct.ActionMode DataMode;
        DataSet dsEdit = new DataSet();
        DataSet dsRO = new DataSet();
        DataTable dtUnit = new DataTable();
        DataRow EditData = null;
        int RCD_ID = 0, IdNo = 0, ListNo;

        double Zconv = 1;
        double Zquan = 0.00;
        decimal Zuprice = 0;
        decimal Zcog = 0;
        decimal ZsumVat = 0;
        decimal ZnosumVat = 0;
        decimal ZdiscA = 0;
        float Zvat = 0;


        //Mark
        byte VatStatus;
        int Cus_Id;
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
                if (DataMode != cls_Struct.ActionMode.Add && DataMode != cls_Struct.ActionMode.Other)
                {
                    ListNo = dsEdit.Tables["RODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                }
                else
                {
                    ListNo = dsEdit.Tables["RODETAIL"].AsEnumerable().ToList();
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
            sluItem.EditValue = 0;
            txtFullName.Text = "";
            txtGenuinPartId.Text = "";
            txtBrandPartId.Text = "";
            txtModel1.Text = "";
            sluBrand.EditValue = 0;
            sluUnit.EditValue = 0;
            spinMarkNo.EditValue = 0;
            spinQtyRe.EditValue = 0;
            spinPriceD.EditValue = 0;            
            spinNetD.EditValue = 0;
            sluReason.EditValue = 0;
            spinDiscount1.EditValue =0;
            spinDiscount2.EditValue = 0;
            spinDiscount3.EditValue = 0;

            txtInvNo.Text = "";
            dateInvNo.EditValue = null;
            comboSelltype.SelectedIndex = 0;
            sluCategory.EditValue = 0;
            spinCredit.EditValue = 0;
            txtReason.Text = "";

            ListNo = AssigNo();
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
                Zquan = cls_Library.CDouble(spinMarkNo.EditValue) * Zconv;

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
                    case cls_Global_class.TypeCal.disc:
                        ZdiscA = cls_Library.CDecimal(spinDiscount1.EditValue) + cls_Library.CDecimal(spinDiscount2.EditValue) + cls_Library.CDecimal(spinDiscount3.EditValue);
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
                foreach (DataRow drRows in dsEdit.Tables["RODETAIL"].Rows)
                {
                    var array2 = drRows.ItemArray;
                    if (array1.SequenceEqual(array2))
                        break;

                    idx++;
                }
                DataRow row = dsEdit.Tables["RODETAIL"].Rows[idx];

                row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                row["BRAND_PART_ID"] = txtBrandPartId.Text;
                row["FULL_NAME"] = txtFullName.Text;
                row["MODEL1"] = txtModel1.Text;
                row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
                row["MARK_NO"] = Zquan;// cls_Library.CDouble(spinMarkNo.EditValue);
                row["CONV"] = Zconv;
                row["RETURN_QTY"] = cls_Library.CDouble(spinQtyRe.EditValue);
                row["PRICE_DOC"] = cls_Library.DBDecimal(spinPriceD.EditValue);                
                //XXXXXXXXXX
                row["COG"] = Zcog;
                row["PRICEVAT"] = ZsumVat;
                row["NOSUMVAT"] = ZnosumVat;
                row["NET_DOC"] = cls_Library.DBDecimal(spinNetD.EditValue);
                row["RETURN_REASON"] = cls_Library.CInt(sluReason.EditValue);
                row["DISCOUNT1"] = cls_Library.DBDecimal(spinDiscount1.EditValue);
                row["DISCOUNT2"] = cls_Library.DBDecimal(spinDiscount2.EditValue);
                row["DISCOUNT3"] = cls_Library.DBDecimal(spinDiscount3.EditValue);                              

                row["INV_NO"] = txtInvNo.Text;
                row["INV_DATE"] = cls_Library.DBDateTime(dateInvNo.EditValue);
                row["SELL_TYPE"] = cls_Library.CByte(comboSelltype.SelectedIndex + 1);
                row["CATEGORY_ID"] = cls_Library.DBInt(sluCategory.EditValue);
                row["CREDIT_TERM"] = cls_Library.DBInt(spinCredit.EditValue);
                row["REASON"] = txtReason.Text;

                row["mode"] = DataMode;
                //row["Change"] = 1;

                dsEdit.Tables["RODETAIL"].AcceptChanges();
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
            DataRow dr;
            try
            {
                DataMode = mode;
                if (DataMode == cls_Struct.ActionMode.Copy) DataMode = cls_Struct.ActionMode.Add;
                LoadDefaultData();
                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                        //Default value
                        dr = dsEdit.Tables["ROHEADER"].Rows[0];

                        txtRONo.Text = dr["RO_NO"].ToString();
                        dateRO.EditValue = cls_Library.DBDateTime(dr["RO_DATE"]);
                        sluCus.Text = dr["VENDOR_CODE"].ToString();
                        comboVatStatus.SelectedIndex = cls_Library.DBByte(dr["VAT_STATUS"]) - 1;

                        sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = EditData["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                        txtModel1.Text = EditData["MODEL1"].ToString();
                        sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();                        
                        spinMarkNo.EditValue = 0;
                        spinQtyRe.EditValue = 0; //ไม่ได้ใช้
                        spinPriceD.EditValue = 0;
                       
                        sluReason.EditValue = cls_Library.DBInt(EditData["RETURN_REASON"]);
                        spinDiscount1.EditValue = 0;
                        spinDiscount2.EditValue = 0;
                        spinDiscount3.EditValue = 0;
                        txtReason.Text = "";

                        //XXXXXXXXXXXXXXXXXXXXXXXXXx
                        Zquan = 0;
                        Zconv = 1;
                        ZnosumVat = 0;
                        ZsumVat = 0;
                        Zuprice = cls_Library.CDecimal(spinPriceD.EditValue);
                        Zcog = 0;
                        Zvat = 7;
                        ZdiscA = 0;

                        txtInvNo.Text = "";
                        dateInvNo.EditValue = DateTime.Now;
                        comboSelltype.SelectedIndex = 0;                        
                        sluCategory.EditValue = cls_Library.DBInt(EditData["CATEGORY_ID"]);
                        spinCredit.EditValue = 0;

                        break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        if (EditData == null) return;

                        IdNo = cls_Library.DBInt(EditData["ROD_ID"]);
                        sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = EditData["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                        txtModel1.Text = EditData["MODEL1"].ToString();
                        sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                        sluUnit.EditValue = cls_Library.DBInt(EditData["UNIT_ID"]);
                        Zquan = cls_Library.DBDouble(EditData["MARK_NO"]);
                        Zconv = cls_Library.DBDouble(EditData["CONV"]);
                        spinMarkNo.Value = cls_Library.CDecimal(Zquan / Zconv);
                        spinQtyRe.EditValue = cls_Library.DBDecimal(EditData["RETURN_QTY"]);  //ไม่ได้ใช้
                        spinPriceD.EditValue = cls_Library.DBDecimal(EditData["PRICE_DOC"]);
                        spinNetD.EditValue = cls_Library.DBDecimal(EditData["NET_DOC"]);
                        sluReason.EditValue = cls_Library.DBInt(EditData["RETURN_REASON"]);
                        spinDiscount1.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT1"]);
                        spinDiscount2.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT2"]);
                        spinDiscount3.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT3"]);
                        
                        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        Zcog = cls_Library.DBDecimal(EditData["COG"]);
                        ZsumVat = cls_Library.DBDecimal(EditData["PRICEVAT"]);
                        Zvat = 7;
                        ZnosumVat = cls_Library.DBDecimal(EditData["NOSUMVAT"]);
                        Zuprice = cls_Library.CDecimal(spinPriceD.EditValue);
                        ZdiscA = cls_Library.CDecimal(spinDiscount1.EditValue) + cls_Library.CDecimal(spinDiscount2.EditValue) + cls_Library.CDecimal(spinDiscount3.EditValue);

                        txtInvNo.Text = EditData["INV_NO"].ToString();
                        dateInvNo.EditValue = cls_Library.DBDateTime(EditData["INV_DATE"]);
                        comboSelltype.SelectedIndex = cls_Library.DBByte(EditData["SELL_TYPE"]) - 1;                        
                        sluCategory.EditValue = cls_Library.DBInt(EditData["CATEGORY_ID"]);
                        spinCredit.EditValue = cls_Library.DBInt(EditData["CREDIT_TERM"]);
                        txtReason.Text = EditData["REASON"].ToString();

                        break;
                    //Mark
                    case cls_Struct.ActionMode.Other:
                        if (EditData == null) return;
                        dr = dsEdit.Tables["RCHEADER"].Rows[0];
                        //RCD_ID = cls_Library.DBInt(dsEdit.Tables["RCDETAIL"].Rows[0]["RCD_ID"]);
                        List<DataRow> _list = dsEdit.Tables["RCDETAIL"].AsEnumerable().Where(r => r.Field<int>("RCD_ID") == IdNo).ToList();

                        Cus_Id = cls_Library.DBInt(dr["CUS_ID"]);
                        VatStatus =  cls_Library.DBByte( cls_Library.DBByte(dr["VAT_STATUS"]) - 1);

                        sluCus.Text = dr["VENDOR_CODE"].ToString();
                        comboVatStatus.SelectedIndex = cls_Library.DBByte(dr["VAT_STATUS"]) -1;
                        sluReason.EditValue = cls_Library.DBInt(_list[0]["RETURN_REASON"]);

                        IdNo = cls_Library.DBInt(_list[0]["RCD_ID"]);
                        sluItem.EditValue = cls_Library.DBInt(_list[0]["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = _list[0]["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = _list[0]["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = _list[0]["BRAND_PART_ID"].ToString();
                        txtModel1.Text = _list[0]["MODEL1"].ToString();
                        sluBrand.EditValue = cls_Library.DBInt(_list[0]["BRAND_ID"]).ToString();
                        sluUnit.EditValue = cls_Library.DBInt(_list[0]["UNIT_ID"]);

                        Zquan = cls_Library.DBInt(_list[0]["QTY_MARK"]);
                        Zconv = cls_Library.DBDouble(_list[0]["CONV"]);
                        if (Zconv <= 0) Zconv = 1;

                        if (Zquan <= 0)
                        {
                            spinMarkNo.Properties.MinValue = 0;
                            spinMarkNo.Properties.MaxValue = 0;
                        }
                        else
                        {
                            spinMarkNo.Properties.MinValue = cls_Library.CDecimal(1 / Zconv); //1;
                            //spinMarkNo.Properties.MaxValue = cls_Library.CDecimal(Zquan / Zconv); //cls_Library.DBInt(_list[0]["QTY_MARK"]);
                            //spinMarkNo.Properties.MaxValue = cls_Library.DBInt(_list[0]["QTY_MARK"]) - cls_Library.DBInt(_list[0]["QTY_RETURN"]);
                            spinMarkNo.Properties.MaxValue = cls_Library.DBInt(_list[0]["QTY"]) - cls_Library.DBInt(_list[0]["QTY_RETURN"]);
                        }
                        //spinMarkNo.EditValue = cls_Library.CDecimal(Zquan / Zconv);
                        //spinMarkNo.EditValue = cls_Library.DBInt(_list[0]["QTY_MARK"]) - cls_Library.DBInt(_list[0]["QTY_RETURN"]);
                        spinMarkNo.EditValue = cls_Library.DBInt(_list[0]["QTY"]) - cls_Library.DBInt(_list[0]["QTY_RETURN"]);

                        //spinQtyRe.EditValue = cls_Library.DBDecimal(_list[0]["RETURN_QTY"]);
                        //spinPriceD.EditValue = cls_Library.DBDecimal(_list[0]["PRICE_DOC"]);
                        //spinNetD.EditValue = cls_Library.DBDecimal(_list[0]["NET_DOC"]);
                        spinPriceD.EditValue = cls_Library.DBDecimal(_list[0]["PRICE_REAL"]);
                        spinNetD.EditValue = cls_Library.DBDecimal(_list[0]["NET_REAL"]);
                        sluReason.EditValue = cls_Library.DBInt(_list[0]["RETURN_REASON"]);
                        spinDiscount1.EditValue = cls_Library.DBDecimal(_list[0]["DISCOUNT1"]);
                        spinDiscount2.EditValue = cls_Library.DBDecimal(_list[0]["DISCOUNT2"]);
                        spinDiscount3.EditValue = cls_Library.DBDecimal(_list[0]["DISCOUNT3"]);

                        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        //Zcog = cls_Library.DBDecimal(_list[0]["COG_DOC"]);
                        //ZsumVat = cls_Library.DBDecimal(_list[0]["VAT_DOC"]);
                        Zcog = cls_Library.DBDecimal(_list[0]["COG_REAL"]);
                        ZsumVat = cls_Library.DBDecimal(_list[0]["VAT_REAL"]);
                        Zvat = 7;
                        ZnosumVat = cls_Library.DBDecimal(_list[0]["NOSUMVAT_DOC"]);
                        Zuprice = cls_Library.CDecimal(spinPriceD.EditValue);
                        ZdiscA = cls_Library.CDecimal(spinDiscount1.EditValue) + cls_Library.CDecimal(spinDiscount2.EditValue) + cls_Library.CDecimal(spinDiscount3.EditValue);

                        txtInvNo.Text = dr["INV_NO"].ToString();
                        dateInvNo.EditValue = cls_Library.DBDateTime(dr["INV_DATE"]);
                        comboSelltype.SelectedIndex = cls_Library.DBByte(dr["SELL_TYPE"]) - 1;
                        sluCategory.EditValue = cls_Library.DBInt(dr["CATEGORY_ID"]);
                        spinCredit.EditValue = cls_Library.DBInt(dr["CREDIT_TERM"]);
                        txtReason.Text = "";

                    break;
                }

                spinMarkNo.Select();

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
            comboSelltype.Properties.Items.Clear();
            comboSelltype.Properties.Items.Add("ปกติ");
            comboSelltype.Properties.Items.Add("เบิกห้าง");
            comboSelltype.Properties.Items.Add("ชดเชย");
            comboSelltype.Properties.Items.Add("Back Order");
            comboSelltype.Properties.Items.Add("สินค้าตัวอย่าง");

            comboVatStatus.Properties.Items.Clear();
            comboVatStatus.Properties.Items.Add("Vat นอก");
            comboVatStatus.Properties.Items.Add("Vat ใน");
            comboVatStatus.Properties.Items.Add("ไม่มี Vat");

            if (cls_Global_DB.DataInitial == null)
            {
                cls_Global_DB.DataInitial = new DataSet();
            }
            if (!cls_Global_DB.DataInitial.Tables.Contains("M_ITEMS"))
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_ITEMS"));
            cls_Library.AssignSearchLookUp(sluItem, "M_ITEMS", "รหัสสินค้า", "ชื่อสินค้า");

            if (!cls_Global_DB.DataInitial.Tables.Contains("M_BRANDS"))
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_BRANDS"));
            cls_Library.AssignSearchLookUp(sluBrand, "M_BRANDS", "รหัสยี่ห้อ", "ชื่อยี่ห้อ", cls_Global_class.TypeShow.codename);                
            //cls_Library.AssignSearchLookUp(sluUnit, "M_UNITS", "รหัสหน่วยนับ", "ชื่อหน่วยนับ");
            if (!cls_Global_DB.DataInitial.Tables.Contains("M_CATEGORIES"))
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_CATEGORIES"));
            cls_Library.AssignSearchLookUp(sluCategory, "M_CATEGORIES", "รหัสประเภทสินค้า", "ชื่อประเภทสินค้า", cls_Global_class.TypeShow.name);
            if (!cls_Global_DB.DataInitial.Tables.Contains("M_RETURN_REASONS"))
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_RETURN_REASONS"));
            cls_Library.AssignSearchLookUp(sluReason, "M_RETURN_REASONS", "รหัสเหตุผลการคืน", "เหตุผลการคืน", cls_Global_class.TypeShow.name);

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

                spinMarkNo.Value = cls_Library.CDecimal(Zquan / Zconv);
                spinPriceD.Value = cls_Library.CDecimal(Zuprice);

                if (Zcog- ZdiscA <= 0)
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

                        //decimal Zu = Convert.ToDecimal((Convert.ToDouble(Zvat) + 0.02) * 0.01 * Convert.ToDouble(Zcog - ZdiscA));
                        //decimal Zl = Convert.ToDecimal((Convert.ToDouble(Zvat) - 0.02) * 0.01 * Convert.ToDouble(Zcog - ZdiscA));
                        //if ((ZsumVat < Zl) || (ZsumVat > Zu))
                        //{
                            ZsumVat = cls_Library.CalCulateTax((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex, cls_Global_class.TypeCal.recalTax, cls_Library.CDecimal(Zvat), (Zcog - ZdiscA), ZsumVat);
                        //}
                    }
                }
                switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
                {
                    case cls_Global_class.TypePrice.NOSUMVAT:
                        spinNetD.Value = Zcog - ZdiscA + ZsumVat;
                        break;
                    case cls_Global_class.TypePrice.SUMVAT:
                    case cls_Global_class.TypePrice.NOTVAT:
                        spinNetD.Value = Zcog - ZdiscA;
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
                    if (DataMode == cls_Struct.ActionMode.Other)
                        SaveMarkData();
                    else
                        EditRowData();
                }
                else
                {
                    //DataTable dt = dsEdit.Tables["RODETAIL"].Clone();
                    //DataColumn colMode = new DataColumn("mode", typeof(int));
                    //dt.Columns.Add(colMode);

                    //ListNo = AssigNo();
                    //DataRow row = dt.NewRow();
                    //row["ROD_ID"] = -1;
                    //row["ROD_PID"] = IdNo;
                    //row["LIST_NO"] = ListNo;
                    //row["ITEM_ID"] = cls_Library.CInt(sluItem.EditValue);
                    //row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                    //row["BRAND_PART_ID"] = txtBrandPartId.Text;
                    //row["FULL_NAME"] = txtFullName.Text;
                    //row["MODEL1"] = txtModel1.Text;
                    //row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                    //row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
                    //row["MARK_NO"] = cls_Library.DBInt(spinMarkNo.EditValue);
                    //row["RETURN_QTY"] = cls_Library.DBDecimal(spinQtyRe.EditValue);
                    //row["PRICE_DOC"] = cls_Library.DBDecimal(spinPriceD.EditValue);
                    //row["COG"] = Zcog;
                    ////PRICEVAT //XXXX
                    //row["PRICEVAT"] = ZsumVat;
                    //row["NOSUMVAT"] = ZnosumVat;
                    //row["NET_DOC"] = cls_Library.DBDecimal(spinNetD.EditValue);
                    //row["RETURN_REASON"] = cls_Library.CInt(sluReason.EditValue);
                    //row["DISCOUNT1"] = cls_Library.DBDecimal(spinDiscount1.EditValue);
                    //row["DISCOUNT2"] = cls_Library.DBDecimal(spinDiscount2.EditValue);
                    //row["DISCOUNT3"] = cls_Library.DBDecimal(spinDiscount3.EditValue);

                    //row["INV_NO"] = txtInvNo.Text;
                    //row["INV_DATE"] = cls_Library.DBDateTime(dateInvNo.EditValue);
                    //row["SELL_TYPE"] = cls_Library.CByte(comboSelltype.SelectedIndex + 1);
                    //row["CATEGORY_ID"] = cls_Library.DBInt(sluCategory.EditValue);
                    //row["CREDIT_TERM"] = cls_Library.DBInt(spinCredit.EditValue);

                    //row["mode"] = DataMode;

                    //dt.Rows.Add(row);
                    //dsEdit.Tables["RODETAIL"].ImportRow(row);

                    //SaveNewDetail(dt);
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

        private void SaveNewDetail(DataTable dt, int pid)
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

                    if (cls_Data.SaveRODetail(pid, dt, ref conn, ref tran))
                    {
                        //Update
                        decimal SumDoc = dsEdit.Tables["RODETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("PRICE_DOC") ?? 0);
                        decimal SumDisc = dsEdit.Tables["RODETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("DISCA") ?? 0);
                        decimal SumVaT = dsEdit.Tables["RODETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("PRICEVAT") ?? 0);
                        decimal SumNet = dsEdit.Tables["RODETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("NET_DOC") ?? 0);

                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            sb.Clear();
                            sb.AppendLine("UPDATE ROHEADER WITH (UPDLOCK) SET");
                            sb.AppendLine("LIST_NO = @LIST_NO,");
                            sb.AppendLine("SUM_DOC = @SUM_DOC,");
                            sb.AppendLine("DISCLST_DOC = @DISCLST_DOC,");
                            sb.AppendLine("VAT_DOC = @VAT_DOC,");
                            sb.AppendLine("NET_DOC = @NET_DOC,");
                            sb.AppendLine("UPDATE_BY = @UPDATE_BY,");
                            sb.AppendLine("UPDATE_DATE = @UPDATE_DATE");
                            sb.AppendLine(" WHERE ROH_ID = @ROH_ID");

                            cmd.CommandText = sb.ToString();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();
                            cmd.Transaction = tran;

                            cmd.Parameters.Add("@LIST_NO", SqlDbType.Int).Value = dsEdit.Tables["RODETAIL"].AsEnumerable().Count();
                            cmd.Parameters.Add("@SUM_DOC", SqlDbType.Decimal).Value = SumDoc;
                            cmd.Parameters.Add("@DISCLST_DOC", SqlDbType.Decimal).Value = SumDisc;
                            cmd.Parameters.Add("@VAT_DOC", SqlDbType.Decimal).Value = SumVaT;
                            cmd.Parameters.Add("@NET_DOC", SqlDbType.Decimal).Value = SumNet;
                            cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                            cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.Parameters.Add("@ROH_ID", SqlDbType.Int).Value = pid;
                            cmd.ExecuteNonQuery();
                            tran.Commit();
                            cls_Data.UpdateRCQtyMark(IdNo, cls_Library.CDouble(spinMarkNo.EditValue));//cls_Library.CDouble(spinMarkNo.EditValue));
                            cls_Data.UpdateLastTransfer(cls_Struct.VoucherType.RO, dt);
                            XtraMessageBox.Show("บันทึกรายการใบส่งคืนสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);                                                        
                        }
                    }
                    else
                    {
                        tran.Rollback();
                        //Remove List
                        DataRow[] dr = dsEdit.Tables["RODETAIL"].Select("LIST_NO =" + ListNo);
                        if (dr.Count() > 0)
                            dsEdit.Tables["RODETAIL"].Rows.Remove(dr[0]);
                    }

                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //Remove List
                DataRow[] dr = dsEdit.Tables["RODETAIL"].Select("LIST_NO =" + ListNo);
                if (dr.Count() > 0)
                    dsEdit.Tables["RODETAIL"].Rows.Remove(dr[0]);
                
                XtraMessageBox.Show("SaveNewDetail :" + ex.Message);
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn); conn.Dispose();
            }
        }

        private void SaveMarkData()
        {
            DataTable dt = new DataTable();
            int ROH_ID = 0;
            try
            {
                if (cls_Data.CheckSaveSameRO(Cus_Id, cls_Library.CByte(VatStatus + 1), IdNo, out ROH_ID))
                {                    
                    if (ROH_ID > 0) //เพิ่มรายการ
                    {
                        dsEdit = cls_Data.GetROById(ROH_ID);
                        dt = dsEdit.Tables["RODETAIL"].Clone();
                        DataColumn colMode = new DataColumn("mode", typeof(int));
                        dt.Columns.Add(colMode);
                        ListNo = AssigNo();
                        DataRow row = dt.NewRow();
                        row["ROD_ID"] = -1;
                        row["ROD_PID"] = ROH_ID;
                        row["LIST_NO"] = ListNo;
                        row["ITEM_ID"] = cls_Library.CInt(sluItem.EditValue);
                        row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                        row["BRAND_PART_ID"] = txtBrandPartId.Text;
                        row["FULL_NAME"] = txtFullName.Text;
                        row["MODEL1"] = txtModel1.Text;
                        row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                        row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
                        row["MARK_NO"] = cls_Library.CDouble(spinMarkNo.EditValue);
                        row["CONV"] = Zconv;
                        row["RETURN_QTY"] = cls_Library.DBDecimal(spinQtyRe.EditValue);
                        row["PRICE_DOC"] = cls_Library.DBDecimal(spinPriceD.EditValue);
                        row["COG"] = Zcog;
                        //PRICEVAT //XXXX
                        row["PRICEVAT"] = ZsumVat;
                        row["NOSUMVAT"] = ZnosumVat;
                        row["NET_DOC"] = cls_Library.DBDecimal(spinNetD.EditValue);
                        row["RETURN_REASON"] = cls_Library.CInt(sluReason.EditValue);
                        row["DISCOUNT1"] = cls_Library.DBDecimal(spinDiscount1.EditValue);
                        row["DISCOUNT2"] = cls_Library.DBDecimal(spinDiscount2.EditValue);
                        row["DISCOUNT3"] = cls_Library.DBDecimal(spinDiscount3.EditValue);

                        row["INV_NO"] = txtInvNo.Text;
                        row["INV_DATE"] = cls_Library.DBDateTime(dateInvNo.EditValue);
                        row["SELL_TYPE"] = cls_Library.CByte(comboSelltype.SelectedIndex + 1);
                        row["CATEGORY_ID"] = cls_Library.DBInt(sluCategory.EditValue);
                        row["CREDIT_TERM"] = cls_Library.DBInt(spinCredit.EditValue);
                        row["REASON"] = txtReason.Text;

                        row["mode"] = cls_Struct.ActionMode.Add;

                        dt.Rows.Add(row);
                        dsEdit.Tables["RODETAIL"].ImportRow(row);

                        SaveNewDetail(dt, ROH_ID);
                    }
                    else
                    {
                        
                        //เพิ่ม RO ใบใหม่
                        //Header

                        cls_Struct.StructRO RO = new cls_Struct.StructRO();
                        RO.ROH_ID = -1;
                        RO.RO_NO = "";
                        RO.RO_DATE = DateTime.Today;
                        RO.CUS_ID = Cus_Id;
                        RO.VAT_STATUS = cls_Library.CByte(VatStatus + 1);
                        RO.RO_STATUS = 1;
                        RO.PRINT_NO = 0;
                        RO.LIST_NO = 1;
                        RO.SUM_DOC = 0;
                        RO.DISCLST_DOC = 0;
                        RO.VAT_DOC = 0;
                        RO.NET_DOC = 0;
                        RO.BARCODE = "";

                        //Detail

                        DataSet dsRO = cls_Data.GetROById(0);
                        dt = dsRO.Tables["RODETAIL"].Clone();
                        DataColumn colMode = new DataColumn("mode", typeof(int));
                        dt.Columns.Add(colMode);
                        DataRow row = dt.NewRow();
                        row["ROD_ID"] = -1;
                        row["ROD_PID"] = ROH_ID;
                        row["LIST_NO"] = 1;
                        row["RCD_ID"] = IdNo;
                        row["ITEM_ID"] = cls_Library.CInt(sluItem.EditValue);
                        row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                        row["BRAND_PART_ID"] = txtBrandPartId.Text;
                        row["FULL_NAME"] = txtFullName.Text;
                        row["MODEL1"] = txtModel1.Text;
                        row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                        row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
                        row["MARK_NO"] = cls_Library.CDouble(spinMarkNo.EditValue);
                        row["CONV"] = Zconv;
                        row["RETURN_QTY"] = cls_Library.DBDecimal(spinQtyRe.EditValue);
                        row["PRICE_DOC"] = cls_Library.DBDecimal(spinPriceD.EditValue);
                        row["COG"] = Zcog;
                        //PRICEVAT //XXXX
                        row["PRICEVAT"] = ZsumVat;
                        row["NOSUMVAT"] = ZnosumVat;
                        row["NET_DOC"] = cls_Library.DBDecimal(spinNetD.EditValue);
                        row["RETURN_REASON"] = cls_Library.CInt(sluReason.EditValue);
                        row["DISCOUNT1"] = cls_Library.DBDecimal(spinDiscount1.EditValue);
                        row["DISCOUNT2"] = cls_Library.DBDecimal(spinDiscount2.EditValue);
                        row["DISCOUNT3"] = cls_Library.DBDecimal(spinDiscount3.EditValue);

                        row["INV_NO"] = txtInvNo.Text;
                        row["INV_DATE"] = cls_Library.DBDateTime(dateInvNo.EditValue);
                        row["SELL_TYPE"] = cls_Library.CByte(comboSelltype.SelectedIndex + 1);
                        row["CATEGORY_ID"] = cls_Library.DBInt(sluCategory.EditValue);
                        row["CREDIT_TERM"] = cls_Library.DBInt(spinCredit.EditValue);
                        row["REASON"] = txtReason.Text;

                        row["VAT_STATUS"] = RO.VAT_STATUS;

                        row["mode"] = cls_Struct.ActionMode.Add;

                        dt.Rows.Add(row);
                        dsRO = new DataSet();
                        dsRO.Tables.Add(dt);

                        if (cls_Data.SaveRO( cls_Struct.ActionMode.Add, RO, dsRO))
                        {
                            if(cls_Data.UpdateRCQtyMark(IdNo, cls_Library.CDouble(spinMarkNo.EditValue)))// cls_Library.CDouble(spinMarkNo.EditValue)))
                                XtraMessageBox.Show("บันทึกใบส่งคืนสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveMarkData: " + ex.Message);
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
                        break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
                        txtFullName.ReadOnly = true;
                        txtGenuinPartId.ReadOnly = true;
                        txtBrandPartId.ReadOnly = true;
                        txtModel1.ReadOnly = true;
                        sluBrand.ReadOnly = true;
                        txtInvNo.ReadOnly = true;
                        dateInvNo.ReadOnly = true;
                        comboSelltype.ReadOnly = true;
                        sluCategory.ReadOnly = true;
                        spinCredit.ReadOnly = true;
                        break;
                    case cls_Struct.ActionMode.Other:
                        sluItem.ReadOnly = true;
                        txtFullName.ReadOnly = true;
                        txtGenuinPartId.ReadOnly = true;
                        txtBrandPartId.ReadOnly = true;
                        txtModel1.ReadOnly = true;
                        sluBrand.ReadOnly = true;
                        sluUnit.ReadOnly = true;

                        spinPriceD.ReadOnly = true;
                        spinNetD.ReadOnly = true;
                        spinDiscount1.ReadOnly = true;
                        spinDiscount2.ReadOnly = true;
                        spinDiscount3.ReadOnly = true;
                        sluReason.ReadOnly = true;

                        txtInvNo.ReadOnly = true;
                        dateInvNo.ReadOnly = true;
                        comboSelltype.ReadOnly = true;
                        sluCategory.ReadOnly = true;
                        spinCredit.ReadOnly = true;
                        txtReason.ReadOnly = false;
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
            }
            else
            {
                //Clear Detail Item
                txtFullName.Text = "";
                txtGenuinPartId.Text = "";
                txtBrandPartId.Text = "";
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
                dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId);
                if (dtUnit.Rows.Count > 0)
                {
                    List<DataRow> lst = dtUnit.AsEnumerable().Where(r => r.Field<Int16>("LIST_NO") == 1).ToList();
                    if (lst.Count > 0)
                    {
                    sluUnit.EditValue = cls_Library.DBInt(lst[0]["UNIT_ID"]);
                    Zconv = cls_Library.DBDouble(lst[0]["MULTIPLY_QTY"]);
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
                if (sluUnit.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสหน่วยนับไม่ถูกต้อง");
                }
                if ((spinMarkNo.EditValue == null) || (cls_Library.DBDouble(spinMarkNo.EditValue) == 0))
                {
                    ret = false;
                    msg.AppendLine("ไม่มีจำนวนสินค้า mark คืน");
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

        public frm_RODetailInput()
        {
            InitializeComponent();
            KeyPreview = true;
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

        private void spinMarkNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (spinMarkNo.Value <= 0)
                {
                    spinMarkNo.Value =0;
                }

                if ((Zquan/ Zconv) != cls_Library.CDouble(spinMarkNo.Value))
                {
                    Zquan = cls_Library.CDouble(spinMarkNo.Value) * Zconv;
                    if (spinMarkNo.IsEditorActive) CalculateValue(cls_Global_class.TypeCal.quantity);
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

        private void spinPriceD_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Zuprice != cls_Library.CDecimal(spinPriceD.Value))
                {
                    Zuprice = cls_Library.CDecimal(spinPriceD.Value);
                    if (cls_Library.CDecimal(spinPriceD.Value) < 0) Zuprice = 0;
                    if (spinPriceD.IsEditorActive) CalculateValue(cls_Global_class.TypeCal.unitprice);
                }
            }
            catch { }
        }

        private void spinDiscount1_EditValueChanged(object sender, EventArgs e)
        {
            SpinEdit spin = (SpinEdit)sender;
            if (spin.IsEditorActive) CalculateValue(cls_Global_class.TypeCal.disc);
        }

        private void spinMarkNo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue == null || string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                return;
            }

            decimal _val = Convert.ToDecimal(e.NewValue);
            e.Cancel = ((_val > spinMarkNo.Properties.MaxValue) || (_val < spinMarkNo.Properties.MinValue));
        }

        private void frm_RODetailInput_KeyDown(object sender, KeyEventArgs e)
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
    }
}