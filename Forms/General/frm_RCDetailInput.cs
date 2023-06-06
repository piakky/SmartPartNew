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
    public partial class frm_RCDetailInput : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private bool IsSaveOK = false;

        cls_Struct.ActionMode DataMode;
        DataSet dsEdit = new DataSet();
        DataRow EditData = null;
        int IdNo = 0, ListNo;
        DataTable dtUnit = new DataTable();

        double Zconv = 1;
        double Zquan = 0.00;
        decimal Zuprice_D = 0, Zuprice_R = 0;
        decimal Zcog_D = 0, Zcog_R = 0;
        decimal ZsumVat_D = 0, ZsumVat_R = 0;
        decimal ZnosumVat_D = 0, ZnosumVat_R = 0;
        decimal ZdiscA = 0;
        float Zvat = 0;
        int ReturnId = 0;

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
                ListNo = dsEdit.Tables["RCDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
            }
            else
            {
                ListNo = dsEdit.Tables["RCDETAIL"].AsEnumerable().ToList();
            }
                
            if (ListNo.Count() > 0)
                no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
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
            txtBrandImp.Text = "";
            sluBrand.EditValue = 0;
            sluUnit.EditValue = 0;
            spinBarcode.EditValue = 0;
            spinQTY.EditValue = 0;
            spinSetDiscount.EditValue = 0;

            spinSetPrice.EditValue = 0;
            spinNetPrice.EditValue = 0;
            spinTotalPriceR.EditValue = 0;
            spinNetPriceR.EditValue = 0;
            spinTotalPriceR.EditValue = 0;
            ReturnId = 0;

            ListNo = AssigNo();

            Zconv = 1;
            Zcog_D = 0;
            ZnosumVat_D = 0;
            Zuprice_D = 0;
            ZdiscA = 0;
            ZsumVat_D = 0;
            Zcog_R = 0;
            ZnosumVat_R = 0;
            Zuprice_R = 0;
            ZsumVat_R = 0;
        }

        private void CalculateValue(cls_Global_class.TypeCal category)
        {
            string Sdics = "";
            decimal Sprice = cls_Library.CDecimal(spinSetPrice.EditValue);
            double Squan = cls_Library.CDouble(spinQTY.EditValue);

            try
            {
                Sdics = txtDiscount.Text.Trim();
                if (cls_Library.DBDouble(Sdics) > 100) Sdics = "100";
                Zquan = Squan * Zconv;
                //xx
                switch (category)
                {
                    case cls_Global_class.TypeCal.price:
                        //if (Zquan > 0)
                        //{
                        //  Zuprice_D = (Zcog_D * Zconv) / cls_Library.CDecimal(Zquan);
                        //  Zuprice_R = (Zcog_R * Zconv) / cls_Library.CDecimal(Zquan);
                        //}
                        spinSetDiscount.EditValue = cls_Library.CalFix_TXTdisc(txtDiscount.Text.Trim(), cls_Library.CDecimal(spinSetPrice.EditValue)) * cls_Library.CDecimal(Squan);
                        txtDiscount.Text = Sdics;
                        break;
                    case cls_Global_class.TypeCal.quantity:
                        spinSetDiscount.EditValue = cls_Library.CalFix_TXTdisc(txtDiscount.Text.Trim(), cls_Library.CDecimal(spinSetPrice.EditValue)) * cls_Library.CDecimal(Squan);
                        break;
                    case cls_Global_class.TypeCal.disc:
                        spinSetDiscount.EditValue = cls_Library.CalFix_TXTdisc(txtDiscount.Text.Trim(), cls_Library.CDecimal(spinSetPrice.EditValue)) * cls_Library.CDecimal(Squan);
                        txtDiscount.Text = Sdics;
                        break;
                    case cls_Global_class.TypeCal.perdisc:
            
                        if (cls_Library.CDecimal(spinSetDiscount.EditValue) > (Sprice * cls_Library.CDecimal(Squan)))
                        {
                            spinSetDiscount.EditValue = (Sprice * cls_Library.CDecimal(Squan));
                        }
                        if ((Sprice * cls_Library.CDecimal(Squan)) == 0)
                        {
                            txtDiscount.Text = "0";
                        }
                        else
                        {
                            txtDiscount.Text = ((cls_Library.CDecimal(spinSetDiscount.EditValue) * 100) / (Sprice * cls_Library.CDecimal(Squan))).ToString("#,##0.##");
                        }                       
                        break;
                        //case cls_Global_class.TypeCal.unitprice:
                        //  Zcog_D = (Zuprice_D * cls_Library.CDecimal(Zquan)) / Zconv;
                        //  Zcog_R = (Zuprice_R * cls_Library.CDecimal(Zquan)) / Zconv;
                        //  break;
                }

                //ราคารวมตามเอกสาร
                if (cls_Library.DBDecimal(spinSetPrice.EditValue) > 0)
                {
                    spinTotalPrice.EditValue = (cls_Library.DBDecimal(spinSetPrice.EditValue) * cls_Library.CDecimal(Squan)) - cls_Library.DBDecimal(spinSetDiscount.EditValue);
                    if (cls_Library.CDecimal(Squan) > 0)
                    {
                        spinNetPriceR.EditValue = cls_Library.DBDecimal(spinTotalPrice.EditValue)/ cls_Library.CDecimal(Squan);
                    }
                    else
                    {
                        spinNetPriceR.EditValue = cls_Library.DBDecimal(spinTotalPrice.EditValue);
                    }
                }
                else
                {
                    spinTotalPrice.EditValue = cls_Library.DBDecimal(spinNetPrice.EditValue) * cls_Library.CDecimal(Squan);
                    spinNetPriceR.EditValue = cls_Library.DBDecimal(spinNetPrice.EditValue);
                }
                //spinTotalPrice.EditValue = cls_Library.DBDecimal(spinTotalPrice.EditValue) ;
                spinTotalPriceR.EditValue = cls_Library.DBDecimal(spinNetPriceR.EditValue) * cls_Library.CDecimal(Squan);

                RecalChangeValue();
                //RecalChangeValue();
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
            foreach (DataRow drRows in dsEdit.Tables["RCDETAIL"].Rows)
            {
                var array2 = drRows.ItemArray;
                if (array1.SequenceEqual(array2))
                    break;
                idx++;
            }
            DataRow row = dsEdit.Tables["RCDETAIL"].Rows[idx];

            row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
            row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
            row["BRAND_PART_ID"] = txtBrandPartId.Text;
            row["FULL_NAME"] = txtFullName.Text;
            row["MODEL1"] = txtModel1.Text;
            row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
            row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
            row["QTY"] = Zquan;//cls_Library.DBInt(spinQTY.EditValue);
            row["CONV"] = Zconv;
            row["BARCODE_NO"] = cls_Library.DBInt(spinBarcode.EditValue);

            //row["DISCOUNT"] = cls_Library.DBString(txtDiscount.Text);
            //row["DISCOUNT1"] = cls_Library.DBDecimal(spinSetDiscount.EditValue);
            ////row["DISCOUNT2"] = cls_Library.DBDecimal(spinSetDiscount.EditValue);
            ////row["DISCOUNT3"] = cls_Library.DBDecimal(spinSetDiscount2.EditValue);

            //row["PRICE_DOC"] = cls_Library.DBDecimal(spinSetPrice.EditValue);
            //row["COG_DOC"] = Zcog_D;
            //row["VAT_DOC"] = ZsumVat_D;
            //row["NET_DOC"] = cls_Library.DBDecimal(spinNetPrice.EditValue);
            //row["NOSUMVAT_DOC"] = ZnosumVat_D;
            //row["PRICE_REAL"] = cls_Library.DBDecimal(spinNetPriceR.EditValue);
            //row["COG_REAL"] = Zcog_R;
            //row["VAT_REAL"] = ZsumVat_R;
            //row["NET_REAL"] = cls_Library.DBDecimal(spinTotalPriceR.EditValue);
            //row["NOSUMVAT_REAL"] = ZnosumVat_R;
            //row["VAT_STATUS"] = comboVatStatus.SelectedIndex + 1;
            //row["RETURN_REASON"] = ReturnId;
            row["PRICE_DOC"] = cls_Library.DBDecimal(spinSetPrice.EditValue);
            row["DISCOUNT"] = cls_Library.DBString(txtDiscount.Text);
            row["DISCOUNT1"] = cls_Library.DBDecimal(spinSetDiscount.EditValue);
            row["NET_DOC"] = cls_Library.DBDecimal(spinNetPrice.EditValue);     //ราคาสุทธิ/หน่วย ตามเอกสาร
            row["COG_DOC"] = cls_Library.DBDecimal(spinTotalPrice.EditValue);   //ยอดรวม
            row["VAT_DOC"] = cls_Library.DBDecimal(spinVatNetD.EditValue);
            row["NOSUMVAT_DOC"] = 0;
            //switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
            //{
            //    case cls_Global_class.TypePrice.SUMVAT:
            //    row["COG_DOC"] = Math.Round(cls_Library.DBDecimal(spinTotalPrice.EditValue) - cls_Library.DBDecimal(spinVatNetD.EditValue), 2);
            //    break;
            //    case cls_Global_class.TypePrice.NOSUMVAT:
            //    row["COG_DOC"] = Math.Round(cls_Library.DBDecimal(spinTotalPrice.EditValue) + cls_Library.DBDecimal(spinVatNetD.EditValue), 2);
            //    break;
            //    case cls_Global_class.TypePrice.NOTVAT:
            //    row["COG_DOC"] = Math.Round(cls_Library.DBDecimal(spinTotalPrice.EditValue), 2);
            //    break;
            //}

            row["PRICE_REAL"] = cls_Library.DBDecimal(spinNetPriceR.EditValue);
            row["NET_REAL"] = cls_Library.DBDecimal(spinNetPriceR.EditValue);
            row["COG_REAL"] = cls_Library.DBDecimal(spinTotalPriceR.EditValue);
            row["VAT_REAL"] = cls_Library.DBDecimal(spinVatNetR.EditValue);
            row["NOSUMVAT_REAL"] = 0;
            //switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
            //{
            //    case cls_Global_class.TypePrice.SUMVAT:
            //    row["COG_REAL"] = Math.Round(cls_Library.DBDecimal(spinTotalPriceR.EditValue) - cls_Library.DBDecimal(spinVatNetR.EditValue), 2);
            //    break;
            //    case cls_Global_class.TypePrice.NOSUMVAT:
            //    row["COG_REAL"] = Math.Round(cls_Library.DBDecimal(spinTotalPriceR.EditValue) + cls_Library.DBDecimal(spinVatNetR.EditValue), 2);
            //    break;
            //    case cls_Global_class.TypePrice.NOTVAT:
            //    row["COG_REAL"] = Math.Round(cls_Library.DBDecimal(spinTotalPriceR.EditValue), 2);
            //    break;
            //}
            row["RETURN_REASON"] = 0;
            row["VAT_STATUS"] = comboVatStatus.SelectedIndex + 1;
            row["BRANDIMP"] = txtBrandImp.Text;

            row["mode"] = DataMode;
            //row["Change"] = 1;

            dsEdit.Tables["RCDETAIL"].AcceptChanges();
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

                DataRow dr = dsEdit.Tables["RCHEADER"].Rows[0];
                //Defalut Data
                txtInvNo.Text = dr["INV_NO"].ToString();
                dateInvNo.EditValue = cls_Library.DBDateTime(dr["INV_DATE"]);                        
                comboSelltype.SelectedIndex = cls_Library.DBInt16(dr["SELL_TYPE"]) - 1;
                txtCus.Text = dr["VENDOR_CODE"].ToString();
                txtCategory.Text =  dr["CATEGORY_NAME"].ToString();
                txtCredit.Text = cls_Library.DBInt(dr["CREDIT_TERM"]).ToString();
                comboVatStatus.SelectedIndex = cls_Library.DBInt16(dr["VAT_STATUS"]) - 1;

                sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                SetUnit(cls_Library.CInt(sluItem.EditValue));
                txtFullName.Text = EditData["FULL_NAME"].ToString();
                txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                txtModel1.Text = EditData["MODEL1"].ToString();
                sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                txtBrandImp.Text = "";
                spinQTY.EditValue = cls_Library.DBInt(EditData["QTY"]);
                spinBarcode.EditValue = 0;
                //spinDiscount1.EditValue = 0;
                spinSetDiscount.EditValue = 0;
                //spinSetDiscount2.EditValue = 0;

                spinSetPrice.EditValue = 0;
                spinNetPrice.EditValue = 0;
                spinNetPriceR.EditValue = 0;
                spinTotalPriceR.EditValue = 0;

                ReturnId = 0;

                //XXXXXXXXXXXXXXXXXXXXXXXXXx
                Zquan = cls_Library.CDouble(spinQTY.EditValue);
                Zconv = 1;
                ZnosumVat_D = 0;
                ZsumVat_D = 0;
                Zuprice_D = cls_Library.CDecimal(spinSetPrice.EditValue);
                Zcog_D = 0;
                Zvat = 7;
                ZnosumVat_R = 0;
                ZsumVat_R = 0;
                Zuprice_R = cls_Library.CDecimal(spinNetPriceR.EditValue);
                Zcog_R = 0;
                ZdiscA = 0;

                break;
                case cls_Struct.ActionMode.Edit:
                if (EditData == null) return;                        
                IdNo = cls_Library.DBInt(EditData["RCD_ID"]);
                sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                SetUnit(cls_Library.CInt(sluItem.EditValue));
                txtFullName.Text = EditData["FULL_NAME"].ToString();
                txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                txtModel1.Text = EditData["MODEL1"].ToString();
                sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                sluUnit.EditValue = cls_Library.DBInt(EditData["UNIT_ID"]);
                Zquan = cls_Library.DBInt(EditData["QTY"]);
                Zconv = cls_Library.DBDouble(EditData["CONV"]);
                if (Zconv == 0) Zconv = 1;
                spinQTY.EditValue = cls_Library.CDecimal(Zquan / Zconv);

                spinBarcode.EditValue = cls_Library.DBInt(EditData["BARCODE_NO"]);
                comboVatStatus.SelectedIndex = cls_Library.DBInt16(EditData["VAT_STATUS"]) - 1;
                txtBrandImp.Text = EditData["BRANDIMP"].ToString();

            
                //spinSetDiscount2.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT3"]);

                spinSetPrice.EditValue = cls_Library.DBDecimal(EditData["PRICE_DOC"]);
                txtDiscount.Text = cls_Library.DBString(EditData["DISCOUNT"]);
                spinSetDiscount.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT1"]);
                spinNetPrice.EditValue = cls_Library.DBDecimal(EditData["NET_DOC"]);
                spinTotalPrice.EditValue = cls_Library.DBDecimal(EditData["COG_DOC"]);
                spinVatNetD.EditValue = cls_Library.DBDecimal(EditData["VAT_DOC"]);
                spinNetPriceR.EditValue = cls_Library.DBDecimal(EditData["NET_REAL"]);
                spinTotalPriceR.EditValue = cls_Library.DBDecimal(EditData["COG_REAL"]);
                spinVatNetR.EditValue = cls_Library.DBDecimal(EditData["VAT_REAL"]);

                ReturnId = cls_Library.DBInt(EditData["RETURN_REASON"]);

                //Zquan = cls_Library.CDouble(spinQTY.EditValue);
                //Zconv = 1;
                Zvat = 7;


                switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
                {
                    case cls_Global_class.TypePrice.SUMVAT:
                    spinTotalPrice.EditValue = Math.Round(cls_Library.DBDecimal(EditData["COG_DOC"]) + cls_Library.DBDecimal(EditData["VAT_DOC"]), 2);
                    break;
                    case cls_Global_class.TypePrice.NOSUMVAT:
                    case cls_Global_class.TypePrice.NOTVAT:
                    spinTotalPrice.EditValue = Math.Round(cls_Library.DBDecimal(EditData["COG_DOC"]), 2);
                    break;
                }

                switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
                {
                    case cls_Global_class.TypePrice.SUMVAT:
                    spinTotalPriceR.EditValue = Math.Round(cls_Library.DBDecimal(EditData["COG_REAL"]) + cls_Library.DBDecimal(EditData["VAT_REAL"]), 2);
                    break;
                    case cls_Global_class.TypePrice.NOSUMVAT:
                    case cls_Global_class.TypePrice.NOTVAT:
                    spinTotalPriceR.EditValue = Math.Round(cls_Library.DBDecimal(EditData["COG_REAL"]), 2);
                    break;
                }

                //Zcog_D = cls_Library.DBDecimal(EditData["COG_DOC"]);
                //ZsumVat_D = cls_Library.DBDecimal(EditData["VAT_DOC"]);
                //Zvat = 7;
                //ZnosumVat_D = cls_Library.DBDecimal(EditData["NOSUMVAT_DOC"]);
                //Zuprice_D = cls_Library.CDecimal(spinPriceSet.EditValue);
                //spinPriceR.EditValue = cls_Library.DBDecimal(EditData["PRICE_REAL"]);
                //Zcog_R = cls_Library.DBDecimal(EditData["COG_REAL"]);
                //ZsumVat_R = cls_Library.DBDecimal(EditData["VAT_REAL"]);
                //ZnosumVat_R = cls_Library.DBDecimal(EditData["NOSUMVAT_REAL"]);
                //Zuprice_R = cls_Library.CDecimal(spinPriceR.EditValue);
                //spinNetR.EditValue = cls_Library.DBDecimal(EditData["NET_REAL"]);



                //ZdiscA = cls_Library.CDecimal(spinDiscount1.EditValue) + cls_Library.CDecimal(spinSetDiscount.EditValue) + cls_Library.CDecimal(spinSetDiscount2.EditValue);
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
            comboSelltype.Properties.Items.Add("ปกติ");
            comboSelltype.Properties.Items.Add("เบิกห้าง");
            comboSelltype.Properties.Items.Add("ชดเชย");
            comboSelltype.Properties.Items.Add("Back Order");
            comboSelltype.Properties.Items.Add("สินค้าตัวอย่าง");

            comboVatStatus.Properties.Items.Add("Vat นอก");
            comboVatStatus.Properties.Items.Add("Vat ใน");
            comboVatStatus.Properties.Items.Add("ไม่มี Vat");

            cls_Library.AssignSearchLookUp(sluItem, "M_ITEMS", "รหัสสินค้า", "ชื่อสินค้า");
            cls_Library.AssignSearchLookUp(sluBrand, "M_BRANDS", "รหัสยี่ห้อ", "ชื่อยี่ห้อ",cls_Global_class.TypeShow.codename);                
            //cls_Library.AssignSearchLookUp(sluUnit, "M_UNITS", "รหัสหน่วยนับ", "ชื่อหน่วยนับ");

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
            //Zuprice_D = Zquan == 0 ? 0 : (Zcog_D * Zconv) / Convert.ToDecimal(Zquan);
            //Zuprice_R = Zquan == 0 ? 0 : (Zcog_R * Zconv) / Convert.ToDecimal(Zquan);

            //ZnosumVat_D = (cls_Global_class.TypePrice)comboVatStatus.SelectedIndex == cls_Global_class.TypePrice.SUMVAT ? (Zcog_D - ZdiscA) - ZsumVat_D : Zcog_D - ZdiscA;
            //ZnosumVat_R = (cls_Global_class.TypePrice)comboVatStatus.SelectedIndex == cls_Global_class.TypePrice.SUMVAT ? (Zcog_R - ZdiscA) - ZsumVat_R : Zcog_R - ZdiscA;

            //if (Zconv > 0) spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
            //spinSetPrice.Value = cls_Library.CDecimal(Zuprice_D);
            //spinPriceR.Value = cls_Library.CDecimal(Zuprice_R);

            //if (Zcog_D - ZdiscA <= 0)
            //{
            //    ZsumVat_D = 0; //Zvat = 0;
            //}
            //else
            //{
            //  if ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex == cls_Global_class.TypePrice.NOTVAT)
            //  {
            //      ZsumVat_D = 0;//Zvat = 0; 
            //  }
            //  else
            //  {
            //    if (ZsumVat_D > 0 && Zvat == 0)
            //        if (ZnosumVat_D > 0) Zvat = (float)cls_Library.CalCulateTax((cls_Global_class.TypePrice)5, cls_Global_class.TypeCal.taxrate, 0, ZnosumVat_D, ZsumVat_D);

            //    ZsumVat_D = cls_Library.CalCulateTax((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex, cls_Global_class.TypeCal.recalTax, cls_Library.CDecimal(Zvat), (Zcog_D - ZdiscA), ZsumVat_D);
            //  }
            //}

            //if (Zcog_R - ZdiscA <= 0)
            //{
            //  ZsumVat_R = 0; //Zvat = 0;
            //}
            //else
            //{
            //  if ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex == cls_Global_class.TypePrice.NOTVAT)
            //  {
            //    ZsumVat_R = 0;//Zvat = 0; 
            //  }
            //  else
            //  {
            //    if (ZsumVat_R > 0 && Zvat == 0)
            //        if (ZnosumVat_R > 0) Zvat = (float)cls_Library.CalCulateTax((cls_Global_class.TypePrice)5, cls_Global_class.TypeCal.taxrate, 0, ZnosumVat_R, ZsumVat_R);

            //    ZsumVat_R = cls_Library.CalCulateTax((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex, cls_Global_class.TypeCal.recalTax, cls_Library.CDecimal(Zvat), (Zcog_R - ZdiscA), ZsumVat_R);
            //  }
            //}


            //switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
            //{
            //  case cls_Global_class.TypePrice.NOSUMVAT:
            //    spinNetPrice.Value = Zcog_D - ZdiscA + ZsumVat_D;
            //    spinNetR.Value = Zcog_R - ZdiscA + ZsumVat_R;
            //    break;
            //  case cls_Global_class.TypePrice.SUMVAT:
            //  case cls_Global_class.TypePrice.NOTVAT:
            //    spinNetPrice.Value = Zcog_D - ZdiscA;
            //    spinNetR.Value = Zcog_R - ZdiscA;
            //    break;
            //}

            switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
            {
                case cls_Global_class.TypePrice.SUMVAT:
                ZsumVat_D = 0;
                if (cls_Library.DBDecimal(spinTotalPrice.EditValue) > 0) ZsumVat_D = Math.Round((cls_Library.DBDecimal(spinTotalPrice.EditValue) * 7)/(107),2);
                spinVatNetD.EditValue = ZsumVat_D;
                ZsumVat_R = 0;
                if (cls_Library.DBDecimal(spinTotalPriceR.EditValue) > 0) ZsumVat_R = Math.Round((cls_Library.DBDecimal(spinTotalPriceR.EditValue) * 7) / (107), 2);
                spinVatNetR.EditValue = ZsumVat_R;
                break;
                case cls_Global_class.TypePrice.NOSUMVAT:
                ZsumVat_D = 0;
                ZsumVat_D = Math.Round((cls_Library.DBDecimal(spinTotalPrice.EditValue) * 7) / 100 , 2);
                spinVatNetD.EditValue = ZsumVat_D;
                ZsumVat_R = 0;
                ZsumVat_R = Math.Round((cls_Library.DBDecimal(spinTotalPriceR.EditValue) * 7) / 100, 2);
                spinVatNetR.EditValue = ZsumVat_R;
                break;
                case cls_Global_class.TypePrice.NOTVAT:
                spinVatNetD.EditValue = 0;
                spinVatNetR.EditValue = 0;
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
                    DataTable dt = dsEdit.Tables["RCDETAIL"].Clone();
                    DataColumn colMode = new DataColumn("mode", typeof(int));
                    dt.Columns.Add(colMode);
                    ListNo = AssigNo();
                    DataRow row = dt.NewRow();
                    row["RCD_ID"] = -1;
                    row["RCD_PID"] = IdNo;
                    row["LIST_NO"] = ListNo;
                    row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                    row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                    row["BRAND_PART_ID"] = txtBrandPartId.Text;
                    row["FULL_NAME"] = txtFullName.Text;
                    row["MODEL1"] = txtModel1.Text;
                    row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                    row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
                    row["QTY"] = Zquan; //cls_Library.DBInt(spinQTY.EditValue);
                    row["CONV"] = Zconv;
                    row["BARCODE_NO"] = cls_Library.DBInt(spinBarcode.EditValue);

                    //PIAK       
                    //row["DISCOUNT2"] = cls_Library.DBDecimal(spinSetDiscount.EditValue);
                    //row["DISCOUNT3"] = cls_Library.DBDecimal(spinSetDiscount2.EditValue);

                    row["PRICE_DOC"] = cls_Library.DBDecimal(spinSetPrice.EditValue);
                    row["DISCOUNT"] = cls_Library.DBString(txtDiscount.Text);
                    row["DISCOUNT1"] = cls_Library.DBDecimal(spinSetDiscount.EditValue);//ราคาตั้ง/หน่วย ตามเอกสาร
                    row["NET_DOC"] = cls_Library.DBDecimal(spinNetPrice.EditValue);     //ราคาสุทธิ/หน่วย ตามเอกสาร
                    row["COG_DOC"] = cls_Library.DBDecimal(spinTotalPrice.EditValue);   //ยอดรวม
                    row["VAT_DOC"] = cls_Library.DBDecimal(spinVatNetD.EditValue);
                    row["NOSUMVAT_DOC"] = 0;
                    //switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
                    //{
                    //    case cls_Global_class.TypePrice.SUMVAT:        
                    //        row["COG_DOC"] = Math.Round(cls_Library.DBDecimal(spinTotalPrice.EditValue) - cls_Library.DBDecimal(spinVatNetD.EditValue), 2);
                    //        break;
                    //    case cls_Global_class.TypePrice.NOSUMVAT:
                    //        row["COG_DOC"] = Math.Round(cls_Library.DBDecimal(spinTotalPrice.EditValue) + cls_Library.DBDecimal(spinVatNetD.EditValue), 2);
                    //        break;
                    //    case cls_Global_class.TypePrice.NOTVAT:
                    //        row["COG_DOC"] = Math.Round(cls_Library.DBDecimal(spinTotalPrice.EditValue), 2);
                    //        break;
                    //}
                    row["COG_DOC"] = Math.Round(cls_Library.DBDecimal(spinTotalPrice.EditValue), 2);

                    row["PRICE_REAL"] = cls_Library.DBDecimal(spinNetPriceR.EditValue);
                    row["NET_REAL"] = cls_Library.DBDecimal(spinNetPriceR.EditValue);  //ราคาสุทธิ/หน่วย ตามจริง
                    row["COG_REAL"] = cls_Library.DBDecimal(spinTotalPriceR.EditValue);
                    row["VAT_REAL"] = cls_Library.DBDecimal(spinVatNetR.EditValue);
                    row["NOSUMVAT_REAL"] = 0;
                    //switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
                    //{
                    //    case cls_Global_class.TypePrice.SUMVAT:
                    //        row["COG_REAL"] = Math.Round(cls_Library.DBDecimal(spinTotalPriceR.EditValue) - cls_Library.DBDecimal(spinVatNetR.EditValue), 2);
                    //        break;
                    //    case cls_Global_class.TypePrice.NOSUMVAT:
                    //        row["COG_REAL"] = Math.Round(cls_Library.DBDecimal(spinTotalPriceR.EditValue) + cls_Library.DBDecimal(spinVatNetR.EditValue), 2);
                    //        break;
                    //    case cls_Global_class.TypePrice.NOTVAT:
                    //        row["COG_REAL"] = Math.Round(cls_Library.DBDecimal(spinTotalPriceR.EditValue), 2);
                    //        break;
                    //}     
                    row["COG_REAL"] = Math.Round(cls_Library.DBDecimal(spinTotalPriceR.EditValue), 2);
                    row["RETURN_REASON"] = 0;
                    row["VAT_STATUS"] = comboVatStatus.SelectedIndex + 1;
                    row["BRANDIMP"] = txtBrandImp.Text;
                    row["mode"] = DataMode;

                    dt.Rows.Add(row);
                    dsEdit.Tables["RCDETAIL"].ImportRow(row);
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

                    if (cls_Data.SaveRCDetail(IdNo, dt, ref conn, ref tran))
                    {
                        decimal sumD = 0, sumVatD = 0, sumNetD = 0;
                        decimal sumR = 0, sumVatR = 0, sumNetR = 0;
                        decimal sumDisA = 0;
                        //Update
                        sumD = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("COG_DOC") ?? 0);
                        sumVatD = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("VAT_DOC") ?? 0);
                        //sumNetD = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("NET_DOC") ?? 0);
                        sumNetD = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("COG_DOC") ?? 0);
                        sumR = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("COG_REAL") ?? 0);
                        sumVatR = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("VAT_REAL") ?? 0);
                        //sumNetR = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("NET_REAL") ?? 0);
                        sumNetR = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("COG_REAL") ?? 0);
                        //sumDisA = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("DISCA") ?? 0);

                        switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
                        {
                            case cls_Global_class.TypePrice.SUMVAT:
                            sumNetD = Math.Round(sumD + sumVatD, 2);
                            sumNetR = Math.Round(sumR + sumVatR, 2);
                            break;
                            case cls_Global_class.TypePrice.NOSUMVAT:
                            sumNetD = Math.Round(sumNetD, 2);
                            sumNetR = Math.Round(sumNetR, 2);
                            break;
                            case cls_Global_class.TypePrice.NOTVAT:
                            sumNetD = Math.Round(sumNetD, 2);
                            sumNetR = Math.Round(sumNetR, 2);
                            break;
                        }



                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            sb.Clear();
                            sb.AppendLine("UPDATE RCHEADER WITH (UPDLOCK) SET");
                            sb.AppendLine("LIST_NO = @LIST_NO,");
                            sb.AppendLine("DISCLST = @DISCLST,");
                            sb.AppendLine("SUM_DOC = @SUM_DOC,");
                            sb.AppendLine("VAT_DOC = @VAT_DOC,");
                            sb.AppendLine("NET_DOC = @NET_DOC,");
                            sb.AppendLine("SUM_REAL = @SUM_REAL,");
                            sb.AppendLine("VAT_REAL = @VAT_REAL,");
                            sb.AppendLine("NET_REAL = @NET_REAL,");
                            sb.AppendLine("UPDATE_BY = @UPDATE_BY,");
                            sb.AppendLine("UPDATE_DATE = @UPDATE_DATE");
                            sb.AppendLine("WHERE RCH_ID = @RCH_ID");

                            cmd.CommandText = sb.ToString();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();
                            cmd.Transaction = tran;

                            cmd.Parameters.Add("@LIST_NO", SqlDbType.Int).Value = dsEdit.Tables["RCDETAIL"].AsEnumerable().Count();
                            cmd.Parameters.Add("@DISCLST", SqlDbType.Decimal).Value = sumDisA;
                            cmd.Parameters.Add("@SUM_DOC", SqlDbType.Decimal).Value = sumD;
                            cmd.Parameters.Add("@VAT_DOC", SqlDbType.Decimal).Value = sumVatD;
                            cmd.Parameters.Add("@NET_DOC", SqlDbType.Decimal).Value = sumNetD;
                            cmd.Parameters.Add("@SUM_REAL", SqlDbType.Decimal).Value = sumR;
                            cmd.Parameters.Add("@VAT_REAL", SqlDbType.Decimal).Value = sumVatR;
                            cmd.Parameters.Add("@NET_REAL", SqlDbType.Decimal).Value = sumNetR;
                            cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                            cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.Parameters.Add("@RCH_ID", SqlDbType.Int).Value = IdNo;

                            cmd.ExecuteNonQuery();

                            tran.Commit();

                            cls_Data.UpdateLastTransfer(cls_Struct.VoucherType.RC, dt);

                            XtraMessageBox.Show("บันทึกรายการใบรับสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        tran.Rollback();
                        //Remove List
                        DataRow[] dr = dsEdit.Tables["RCDETAIL"].Select("LIST_NO =" + ListNo);
                        if (dr.Count() > 0)
                            dsEdit.Tables["RCDETAIL"].Rows.Remove(dr[0]);
                    }
                }
            }
            catch (Exception ex)
            {
            tran.Rollback();
            //Remove List
            DataRow[] dr = dsEdit.Tables["RCDETAIL"].Select("LIST_NO =" + ListNo);
            if (dr.Count() > 0)
                dsEdit.Tables["RCDETAIL"].Rows.Remove(dr[0]);
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
                break;
                case cls_Struct.ActionMode.Edit:
                case cls_Struct.ActionMode.View:
                btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
                txtFullName.ReadOnly = true;
                txtGenuinPartId.ReadOnly = true;
                txtBrandPartId.ReadOnly = true;
                txtModel1.ReadOnly = true;
                sluBrand.ReadOnly = true;
                spinBarcode.ReadOnly = true;
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
                //2022-06-06
                //dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId,"",false,2);
                dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId, "", false);

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
                XtraMessageBox.Show("SetUnit :" + ex.Message);
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
            if ((spinQTY.EditValue == null) || (cls_Library.DBDouble(spinQTY.EditValue) <= 0))
            {
                ret = false;
                msg.AppendLine("ปริมาณสินค้าไม่ถูกต้อง");
            }

                if ((cls_Library.DBDecimal(spinSetPrice.EditValue) > 0) &&  (cls_Library.DBDecimal(spinNetPrice.EditValue) > 0))
            {
                ret = false;
                msg.AppendLine("ไม่สามารถระบุราคาตั้ง/หน่วยกับราคาสุทธิ/หน่วย พร้อมกันได้");
            }

                if (cls_Library.DBDecimal(spinSetPrice.EditValue) > 0)
            {
                if (cls_Library.DBDecimal(spinSetDiscount.EditValue) ==0)
                {
                ret = false;
                msg.AppendLine("ไม่ได้ระบุส่วนลด");
                }
            }

            if (cls_Library.DBDecimal(spinSetDiscount.EditValue) > 0)
            {
                if (cls_Library.DBDecimal(spinSetPrice.EditValue) == 0)
                {
                ret = false;
                msg.AppendLine("ไม่ได้ระบุราคาตั้ง/หน่วย ตามเอกสาร");
                }
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

        public frm_RCDetailInput()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(VerifyData())
            {
                SaveData();
                this.DialogResult = DialogResult.OK;
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
                else
                {
                    spinBarcode.Value = spinQTY.Value;
                }

                //if ((Zquan / Zconv) != cls_Library.CDouble(spinQTY.Value))
                //{
                    Zquan = cls_Library.CDouble(spinQTY.Value) * Zconv;
                    CalculateValue(cls_Global_class.TypeCal.quantity);
                //}
                }
            catch { }
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {    
            CalculateValue(cls_Global_class.TypeCal.disc);
        }

        private void spinSetDiscount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateValue(cls_Global_class.TypeCal.perdisc);
        }

        private void spinNetPrice_EditValueChanged(object sender, EventArgs e)
        {
            if (cls_Library.DBDecimal(spinNetPrice.EditValue) > 0)
            {
            spinSetPrice.EditValue = 0;
            txtDiscount.Text = "";
            spinSetDiscount.EditValue = 0;
            CalculateValue(cls_Global_class.TypeCal.realprice);
            }
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

        private void spinSetPrice_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
            //if (Zuprice_D != cls_Library.CDecimal(spinPriceD.Value))
            //{
            //  Zuprice_D = cls_Library.CDecimal(spinPriceD.Value);
            //  if (cls_Library.CDecimal(spinPriceD.Value) < 0) Zuprice_D = 0;
            //  if (spinPriceD.IsEditorActive) CalculateValue(cls_Global_class.TypeCal.unitprice);
            //}
            //if (spinSetPrice.IsEditorActive)
            //{
                if (cls_Library.DBDecimal(spinSetPrice.EditValue) > 0)
                {
                spinNetPrice.EditValue = 0;
                spinTotalPrice.EditValue = 0;
                }
                CalculateValue(cls_Global_class.TypeCal.price);
            //}
            }
            catch { }
        }

        private void spinPriceR_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (Zuprice_R != cls_Library.CDecimal(spinPriceR.Value))
                //{
                //  Zuprice_R = cls_Library.CDecimal(spinPriceR.Value);
                //  if (cls_Library.CDecimal(spinPriceR.Value) < 0) Zuprice_R = 0;
                //  if (spinPriceR.IsEditorActive) CalculateValue(cls_Global_class.TypeCal.unitprice);
                //}
                //if (spinPriceR.IsEditorActive)
                //{


                //if (cls_Library.DBDecimal(spinPriceR.EditValue) > 0)
                //{
                //  spinSetPrice.EditValue = 0;
                //  txtDiscount.Text = "";
                //  spinNetPriceiscount.EditValue = 0;
                //  spinNetPrice.EditValue = 0;
                //  spinNetPrice.EditValue = 0;
                //  CalculateValue(cls_Global_class.TypeCal.realprice);
                //}
                spinTotalPriceR.EditValue = cls_Library.DBDecimal(spinNetPriceR.EditValue) * cls_Library.CDecimal(spinQTY.EditValue);
                RecalChangeValue();
                //}
            }
            catch { }
        }

        private void frm_RCDetailInput_KeyDown(object sender, KeyEventArgs e)
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