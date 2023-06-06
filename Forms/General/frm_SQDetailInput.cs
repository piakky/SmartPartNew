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
    public partial class frm_SQDetailInput : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private bool IsSaveOK = false;

        cls_Struct.ActionMode DataMode;
        DataSet dsEdit = new DataSet();
        DataRow EditData = null;
        DataTable dtUnit = new DataTable();
        int IdNo = 0, ListNo;

        decimal Zcog_D = 0;
        double Zquan = 0.00;
        double Zconv = 1;
        decimal Zuprice_D = 0;
        decimal ZdiscA = 0;
        decimal Znet = 0;
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
                    ListNo = dsEdit.Tables["SQDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                }
                else
                {
                    ListNo = dsEdit.Tables["SQDETAIL"].AsEnumerable().ToList();
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
            txtBrand.Text = "";
            sluUnit.EditValue = 0;
            spinQTY.EditValue = 0;
            spinNetDiscount.EditValue = 0;

            txtDiscount.Text = "";
            spinPriceD.EditValue = 0;
            txtNoteD.Text = "";

            ListNo = AssigNo();

            Zconv = 0;
            Zconv = 1;
            Zcog_D = 0;
            //ZnosumVat_D = 0;
            Zuprice_D = 0;
            ZdiscA = 0;
            Znet = 0;
            //ZsumVat_D = 0;
            //Zcog_R = 0;
            //ZnosumVat_R = 0;
            //Zuprice_R = 0;
            //ZsumVat_R = 0;
        }

        private void CalculateValue(cls_Global_class.TypeCal category)
        {
            string Sdics = "";

            try
            {
                Sdics = txtDiscount.Text.Trim();
                Zquan = cls_Library.CDouble(spinQTY.EditValue) * Zconv;
                if (Zquan == 0) Zquan = 1;

                switch (category)
                {
                    case cls_Global_class.TypeCal.price:
                        if (Zquan > 0)
                        {
                            Zuprice_D = (Zcog_D * (decimal)Zconv) / cls_Library.CDecimal(Zquan);
                            //Zuprice_R = (Zcog_R * Zconv) / cls_Library.CDecimal(Zquan);
                        }
                        break;
                    case cls_Global_class.TypeCal.quantity:
                        Zcog_D = (Zuprice_D * (decimal)Zquan) / (decimal)Zconv;
                        //Zcog_R = (Zuprice_R * (decimal)Zquan) / Zconv;
                        break;
                    case cls_Global_class.TypeCal.disc:

                        //ZdiscA = cls_Library.CDecimal(spinDiscount1.EditValue) + cls_Library.CDecimal(spinDiscount2.EditValue) + cls_Library.CDecimal(spinDiscount3.EditValue);
                        //////ZdiscA = cls_Library.CalFix_TXTdisc(txtDiscount.Text.Trim(), cls_Library.CDecimal(spinPriceD.EditValue));
                        //////spinNetDiscount.EditValue = Math.Round(ZdiscA, 2);
                        //////txtDiscount.Text = Sdics;
                        if (cls_Library.CDecimal(txtDiscount.EditValue) > 100)
                        {
                            txtDiscount.Text = "100";
                        }
                        break;
                    case cls_Global_class.TypeCal.perdisc:

                        if (cls_Library.CDecimal(spinNetDiscount.EditValue) > cls_Library.CDecimal(spinPriceD.EditValue))
                        {
                            spinNetDiscount.EditValue = cls_Library.CDecimal(spinPriceD.EditValue);
                        }

                        if (cls_Library.CDecimal(spinPriceD.EditValue) == 0)
                        {
                            txtDiscount.Text = "0";
                        }
                        
                        //////else
                        //////{
                        //////    txtDiscount.Text = ((cls_Library.CDecimal(spinNetDiscount.EditValue) * 100) / cls_Library.CDecimal(spinPriceD.EditValue)).ToString("#,##0.##");
                        //////}
                        break;
                    case cls_Global_class.TypeCal.unitprice:
                        Zcog_D = (Zuprice_D * cls_Library.CDecimal(Zquan)) / (decimal)Zconv;
                        //Zcog_R = (Zuprice_R * cls_Library.CDecimal(Zquan)) / Zconv;
                        //////ZdiscA = cls_Library.CalFix_TXTdisc(txtDiscount.Text.Trim(), cls_Library.CDecimal(spinPriceD.EditValue));
                        //////spinNetDiscount.EditValue = Math.Round(ZdiscA, 2);
                        //////txtDiscount.Text = Sdics;
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
            foreach (DataRow drRows in dsEdit.Tables["SQDETAIL"].Rows)
            {
                var array2 = drRows.ItemArray;
                if (array1.SequenceEqual(array2))
                    break;
                idx++;
            }
            DataRow row = dsEdit.Tables["SQDETAIL"].Rows[idx];

            row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
            row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
            row["BRAND_PART_ID"] = txtBrandPartId.Text;
            row["FULL_NAME"] = txtFullName.Text;
            row["MODEL1"] = txtModel1.Text;
            //row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
            row["BRAND_ID"] = 0;
            row["BRAND_PRINT"] = txtBrand.Text.Trim();
            row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
            if (cls_Library.DBDouble(spinQTY.EditValue) == 0) Zquan = 0;
            row["QTY"] = Zquan;//cls_Library.DBInt(spinQTY.EditValue);
            row["CONV"] = Zconv;
            row["DISCOUNT"] = cls_Library.DBString(txtDiscount.Text);
            row["DISCOUNT1"] = cls_Library.DBDecimal(spinNetDiscount.EditValue);
            row["DISCOUNT2"] = 0;
            row["DISCOUNT3"] = 0;

            row["BUYPRICE"] = cls_Library.DBDecimal(spinPriceD.EditValue);
            row["COG"] = Zcog_D;
            //row["VAT_DOC"] = ZsumVat_D;
            //row["NET_DOC"] = cls_Library.DBDecimal(spinNetD.EditValue);
            row["NETPRICE"] = Znet;
            row["NOTED"] = txtNoteD.Text;

            row["mode"] = DataMode;
            //row["Change"] = 1;

            dsEdit.Tables["SQDETAIL"].AcceptChanges();
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

                        DataRow dr = dsEdit.Tables["SQHEADER"].Rows[0];
                        //Defalut Data
                        txtSQNo.Text = dr["SQ_NO"].ToString();
                        dateSQ.EditValue = cls_Library.DBDateTime(dr["SQ_DATE"]);
                        txtCus.Text = dr["VENDOR_CODE"].ToString();
                        txtNoteH.Text = dr["NOTE"].ToString();

                        sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = EditData["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                        txtModel1.Text = EditData["MODEL1"].ToString();
                        //sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                        txtBrand.Text = EditData["BRAND_PRINT"].ToString();
                        Zquan = cls_Library.DBInt(EditData["QTY"]);
                        if (Zconv == 0) Zconv = 1;
                        spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
                        txtDiscount.Text = "";
                        spinNetDiscount.EditValue = 0;
                        //spinDiscount1.EditValue = 0;
                        //spinDiscount2.EditValue = 0;
                        //spinDiscount3.EditValue = 0;

                        spinPriceD.EditValue = 0;
                        //spinNetD.EditValue = 0;
                        //spinPriceR.EditValue = 0;
                        //spinNetR.EditValue = 0;

                        //XXXXXXXXXXXXXXXXXXXXXXXXX
                        //ZnosumVat_D = 0;
                        //ZsumVat_D = 0;
                        Zuprice_D = cls_Library.CDecimal(spinPriceD.EditValue);
                        Zcog_D = 0;
                        ZdiscA = 0;

                        Znet = 0;
                        //Zvat = 7;
                        //ZnosumVat_R = 0;
                        //ZsumVat_R = 0;
                        //Zuprice_R = cls_Library.CDecimal(spinPriceR.EditValue);
                        //Zcog_R = 0;

                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (EditData == null) return;
                        IdNo = cls_Library.DBInt(EditData["SQD_ID"]);
                        sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = EditData["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                        txtModel1.Text = EditData["MODEL1"].ToString();
                        //sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                        txtBrand.Text = EditData["BRAND_NAME"].ToString();
                        sluUnit.EditValue = cls_Library.DBInt(EditData["UNIT_ID"]);
                        Zquan = cls_Library.DBInt(EditData["QTY"]);
                        Zconv = cls_Library.DBDouble(EditData["CONV"]);
                        spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
            
                        //spinDiscount1.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT1"]);
                        //spinDiscount2.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT2"]);
                        //spinDiscount3.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT3"]);

                        spinPriceD.EditValue = cls_Library.DBDecimal(EditData["BUYPRICE"]);
                        spinNetDiscount.EditValue = cls_Library.DBDecimal(EditData["DISCOUNT1"]);
                        txtDiscount.Text = cls_Library.DBString(EditData["DISCOUNT"]);
                        //spinNetD.EditValue = cls_Library.DBDecimal(EditData["NET_DOC"]);

                        txtNoteD.Text = cls_Library.DBString(EditData["NOTED"]);

                        Zcog_D = cls_Library.DBDecimal(EditData["COG"]);
                        ZdiscA = cls_Library.CalFix_TXTdisc(txtDiscount.Text.Trim(), cls_Library.CDecimal(spinPriceD.EditValue)); ;
                        Znet = cls_Library.DBDecimal(EditData["NETPRICE"]);
                        //ZsumVat_D = cls_Library.DBDecimal(EditData["VAT_DOC"]);
                        //Zvat = 7;
                        //ZnosumVat_D = cls_Library.DBDecimal(EditData["NOSUMVAT_DOC"]);
                        Zuprice_D = cls_Library.CDecimal(spinPriceD.EditValue);
                        //spinPriceR.EditValue = cls_Library.DBDecimal(EditData["PRICE_REAL"]);
                        //Zcog_R = cls_Library.DBDecimal(EditData["COG_REAL"]);
                        //ZsumVat_R = cls_Library.DBDecimal(EditData["VAT_REAL"]);
                        //ZnosumVat_R = cls_Library.DBDecimal(EditData["NOSUMVAT_REAL"]);
                        //Zuprice_R = cls_Library.CDecimal(spinPriceR.EditValue);
                        //spinNetR.EditValue = cls_Library.DBDecimal(EditData["NET_REAL"]);

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

                cls_Library.AssignSearchLookUp(sluItem, "M_ITEMS", "รหัสสินค้า", "ชื่อสินค้า");
                //cls_Library.AssignSearchLookUp(sluBrand, "M_BRANDS", "รหัสยี่ห้อ", "ชื่อยี่ห้อ", cls_Global_class.TypeShow.codename);
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
                Zuprice_D = Zquan == 0 ? 0 : (Zcog_D * (decimal)Zconv) / Convert.ToDecimal(Zquan);                

                //ZnosumVat_D = (cls_Global_class.TypePrice)comboVatStatus.SelectedIndex == cls_Global_class.TypePrice.SUMVAT ? (Zcog_D - ZdiscA) - ZsumVat_D : Zcog_D - ZdiscA;                

                if (!(Zquan == 1 && cls_Library.DBDouble(spinQTY.EditValue) == 0))
                {
                    spinQTY.Value = cls_Library.CDecimal(Zquan / Zconv);
                }
                
                spinPriceD.Value = cls_Library.CDecimal(Zuprice_D);
                Znet = Zcog_D - ZdiscA;



                //if (Zcog_D - ZdiscA <= 0)
                //{
                //    ZsumVat_D = 0; //Zvat = 0;
                //}
                //else
                //{
                //    if ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex == cls_Global_class.TypePrice.NOTVAT)
                //    {
                //        ZsumVat_D = 0;//Zvat = 0; 
                //    }
                //    else
                //    {
                //        if (ZsumVat_D > 0 && Zvat == 0)
                //            if (ZnosumVat_D > 0) Zvat = (float)cls_Library.CalCulateTax((cls_Global_class.TypePrice)5, cls_Global_class.TypeCal.taxrate, 0, ZnosumVat_D, ZsumVat_D);

                //        ZsumVat_D = cls_Library.CalCulateTax((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex, cls_Global_class.TypeCal.recalTax, cls_Library.CDecimal(Zvat), (Zcog_D - ZdiscA), ZsumVat_D);
                //    }
                //}               


                //switch ((cls_Global_class.TypePrice)comboVatStatus.SelectedIndex)
                //{
                //    case cls_Global_class.TypePrice.NOSUMVAT:
                //        spinNetD.Value = Zcog_D - ZdiscA + ZsumVat_D;
                //        spinNetR.Value = Zcog_R - ZdiscA + ZsumVat_R;
                //        break;
                //    case cls_Global_class.TypePrice.SUMVAT:
                //    case cls_Global_class.TypePrice.NOTVAT:
                //        spinNetD.Value = Zcog_D - ZdiscA;
                //        spinNetR.Value = Zcog_R - ZdiscA;
                //        break;
                //}
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
                DataTable dt = dsEdit.Tables["SQDETAIL"].Clone();
                DataColumn colMode = new DataColumn("mode", typeof(int));
                dt.Columns.Add(colMode);
                ListNo = AssigNo();
                DataRow row = dt.NewRow();
                row["SQD_ID"] = -1;
                row["SQD_PID"] = IdNo;
                row["LIST_NO"] = ListNo;
                row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                row["GENUIN_PART_ID"] = txtGenuinPartId.Text.Trim();
                row["BRAND_PART_ID"] = txtBrandPartId.Text.Trim();
                row["FULL_NAME"] = txtFullName.Text;
                row["MODEL1"] = txtModel1.Text;
                row["BRAND_ID"] = 0;
                row["BRAND_NAME"] = cls_Library.DBString(txtBrand.Text);
                row["BRAND_PRINT"] = cls_Library.DBString(txtBrand.Text);
                row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);
                if (Zquan == 1 && cls_Library.DBDouble(spinQTY.EditValue) == 0) Zquan = 0;                    
                row["QTY"] = Zquan;
                row["CONV"] = Zconv;
                row["DISCOUNT"] = cls_Library.DBString(txtDiscount.Text);
                row["DISCOUNT1"] = cls_Library.DBDecimal(spinNetDiscount.EditValue);
                //row["DISCOUNT1"] = cls_Library.DBDecimal(spinDiscount1.EditValue);
                //row["DISCOUNT2"] = cls_Library.DBDecimal(spinDiscount2.EditValue);
                //row["DISCOUNT3"] = cls_Library.DBDecimal(spinDiscount3.EditValue);

                row["BUYPRICE"] = cls_Library.DBDecimal(spinPriceD.EditValue);
                row["COG"] = Zcog_D;
                //row["VAT_DOC"] = ZsumVat_D;
                //row["NOSUMVAT_DOC"] = ZnosumVat_D;
                row["NETPRICE"] = Zcog_D;
                row["NOTED"] = txtNoteD.Text;
                row["mode"] = DataMode;

                dt.Rows.Add(row);
                dsEdit.Tables["SQDETAIL"].ImportRow(row);

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

                if (cls_Data.SaveSQDetail(IdNo, dt, ref conn, ref tran))
                {
                    //decimal sumD = 0, sumVatD = 0, sumNetD = 0;
                    //decimal sumR = 0, sumVatR = 0, sumNetR = 0;
                    //decimal sumDisA = 0;
                    ////Update
                    //sumD = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("COG_DOC") ?? 0);
                    //sumVatD = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("VAT_DOC") ?? 0);
                    //sumNetD = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("NET_DOC") ?? 0);
                    //sumR = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("COG_REAL") ?? 0);
                    //sumVatR = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("VAT_REAL") ?? 0);
                    //sumNetR = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("NET_REAL") ?? 0);
                    //sumDisA = dsEdit.Tables["RCDETAIL"].AsEnumerable().Sum(x => x.Field<decimal?>("DISCA") ?? 0);

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        sb.Clear();
                        sb.AppendLine("UPDATE SQHEADER WITH (UPDLOCK) SET");
                        sb.AppendLine("LIST_NO = @LIST_NO,");
                        //sb.AppendLine("DISCLST = @DISCLST,");
                        //sb.AppendLine("SUM_DOC = @SUM_DOC,");
                        //sb.AppendLine("VAT_DOC = @VAT_DOC,");
                        //sb.AppendLine("NET_DOC = @NET_DOC,");
                        //sb.AppendLine("SUM_REAL = @SUM_REAL,");
                        //sb.AppendLine("VAT_REAL = @VAT_REAL,");
                        //sb.AppendLine("NET_REAL = @NET_REAL,");
                        sb.AppendLine("UPDATE_BY = @UPDATE_BY,");
                        sb.AppendLine("UPDATE_DATE = @UPDATE_DATE");
                        sb.AppendLine("WHERE SQH_ID = @SQH_ID");

                        cmd.CommandText = sb.ToString();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Transaction = tran;

                        cmd.Parameters.Add("@LIST_NO", SqlDbType.Int).Value = dsEdit.Tables["SQDETAIL"].AsEnumerable().Count();
                        //cmd.Parameters.Add("@DISCLST", SqlDbType.Decimal).Value = sumDisA;
                        //cmd.Parameters.Add("@SUM_DOC", SqlDbType.Decimal).Value = sumD;
                        //cmd.Parameters.Add("@VAT_DOC", SqlDbType.Decimal).Value = sumVatD;
                        //cmd.Parameters.Add("@NET_DOC", SqlDbType.Decimal).Value = sumNetD;
                        //cmd.Parameters.Add("@SUM_REAL", SqlDbType.Decimal).Value = sumR;
                        //cmd.Parameters.Add("@VAT_REAL", SqlDbType.Decimal).Value = sumVatR;
                        //cmd.Parameters.Add("@NET_REAL", SqlDbType.Decimal).Value = sumNetR;
                        cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                        cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@SQH_ID", SqlDbType.Int).Value = IdNo;

                        cmd.ExecuteNonQuery();

                        tran.Commit();

                        cls_Data.UpdateLastTransfer(cls_Struct.VoucherType.SQ, dt);
                        XtraMessageBox.Show("บันทึกรายการ Supplier Quatation เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                tran.Rollback();
                //Remove List
                DataRow[] dr = dsEdit.Tables["SQDETAIL"].Select("LIST_NO =" + ListNo);
                if (dr.Count() > 0)
                    dsEdit.Tables["SQDETAIL"].Rows.Remove(dr[0]);
                }

            }
            }
            catch (Exception ex)
            {
            tran.Rollback();
            //Remove List
            DataRow[] dr = dsEdit.Tables["SQDETAIL"].Select("LIST_NO =" + ListNo);
            if (dr.Count() > 0)
                dsEdit.Tables["SQDETAIL"].Rows.Remove(dr[0]);
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
                        txtBrand.ReadOnly = true;
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
                txtBrand.Text = dr["BRAND_PRINT"].ToString();
            }
            else
            {
                //Clear Detail Item
                txtFullName.Text = "";
                txtGenuinPartId.Text = "";
                txtBrandPartId.Text = "";
                txtBrand.Text = "";
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
                if ((spinQTY.EditValue == null) || (cls_Library.DBDouble(spinQTY.EditValue)<= 0))
                {
                    ret = false;
                    msg.AppendLine("ปริมาณสินค้าไม่ถูกต้อง");
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

        public frm_SQDetailInput()
        {
            InitializeComponent();
            KeyPreview = true;
            txtBrand.Select();
        }

        private void frm_SQDetailInput_Load(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (VerifyData())
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
                    Zquan = 1;
                }

                if ((Zquan / (double)Zconv) != cls_Library.CDouble(spinQTY.Value))
                {
                    if (Zquan == 1 && cls_Library.CDouble(spinQTY.Value) == 0) return;
                    
                    Zquan = cls_Library.CDouble(spinQTY.Value) * (double)Zconv;
                    if (Zquan == 0) Zquan = 1;                    

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

        private void spinDiscount1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frm_SQDetailInput_KeyDown(object sender, KeyEventArgs e)
        {
        switch (e.KeyCode)
        {
        case Keys.Escape:
            this.Close();
            break;
        case Keys.F2:
            btSave.PerformClick();
            break;
        }
        }

        private void spinNetDiscount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateValue(cls_Global_class.TypeCal.perdisc);
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateValue(cls_Global_class.TypeCal.disc);
        }

        private void spinPriceD_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Zuprice_D != cls_Library.CDecimal(spinPriceD.Value))
                {
                Zuprice_D = cls_Library.CDecimal(spinPriceD.Value);
                if (cls_Library.CDecimal(spinPriceD.Value) < 0) Zuprice_D = 0;
                CalculateValue(cls_Global_class.TypeCal.unitprice);
                }
            }
            catch
            {
            }
        }
    }
}