using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using SmartPart.Class;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SmartPart.Forms.Sale
{
    public partial class frm_BSRecord : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDelegate();

        #region Variable
        private DevExpress.XtraGrid.StyleFormatCondition styleDef = new DevExpress.XtraGrid.StyleFormatCondition();
        private RepositoryItemSearchLookUpEdit[] Runit = new RepositoryItemSearchLookUpEdit[0];
        private cls_Struct.StructBS BS = new cls_Struct.StructBS();
        private DataSet dsMainData = new DataSet();
        private DataSet dsEdit = new DataSet();
        DataTable dtUnit = new DataTable();
        private cls_Struct.ActionMode DataMode;
        private int IdPer = 0;
        private int IdCus = 0;
        private int BSID = 0;
        private bool IsSaveOK = false;
        private bool IsCash = false;


        double Qty = 0;
        double Zconv = 1;
        double Zquan = 0.00;
        decimal Zuprice = 0;
        decimal Zcog = 0;
        decimal Znet = 0;
        //decimal ZsumVat = 0;
        //decimal ZnosumVat = 0;
        string ZdiscP = "";
        decimal ZdiscA = 0;
        decimal Zvat = 0;
        float ZvatP = 7;

        bool RowPosition = false;
        bool ShowDelete = false;

        #endregion

        #region Properties
        public int CUS_ID
        {
            set { IdCus = value; }
        }

        public int PER_ID
        {
            set { IdPer = value; }
        }
        #endregion

        #region Function

        private void AddDataSourceToGrid()
        {
            try
            {
                styleDef.Appearance.BackColor = Color.Red;
                styleDef.Appearance.Options.UseBackColor = true;
                styleDef.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
                //styleDef.Expression = "mode = 4";
                styleDef.Expression = "DELETE_ISCNT = True";
                styleDef.ApplyToRow = true;
                gvBS.FormatConditions.Add(styleDef);

                gridBS.DataSource = dsEdit.Tables["BSDETAIL"];
                gridBS.RefreshDataSource();
                gvBS.ActiveFilter.Clear();
                if (ShowDelete)
                {
                    gvBS.ActiveFilter.NonColumnFilter = "DELETE_ISCNT = False or DELETE_ISCNT = True";
                }
                else
                {
                    gvBS.ActiveFilter.NonColumnFilter = "DELETE_ISCNT = False";
                }
                

                spinListNo.EditValue = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Count();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
            }
        }

        private void AddItem(int ItemId, string ItemCode)
        {
            List<DataRow> list = new List<DataRow>();
            bool Dadd = false;
            int i;

            try
            {
                DataSet ds = cls_Data.GetListProductById(ItemId);

                list = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(r => r.Field<string>("ITEM_CODE").Equals(ItemCode)).ToList();
                //2023-06-01
                if (list.Count == 0)
                {
                    Dadd = true;
                }
                else
                {
                    if (cls_Library.DBbool(list[0]["DELETE_ISCNT"])) Dadd = true;
                }

                if (Dadd)
                {
                    DataRow dr = dsEdit.Tables["BSDETAIL"].NewRow();
                    dr["mode"] = (int)cls_Struct.ActionMode.Add;
                    dr["BSD_PID"] = BSID;
                    dr["LIST_NO"] = AssigNo();
                    dr["ITEM_ID"] = ItemId;
                    dr["ITEM_CODE"] = ItemCode;

                    dr["CONV"] = 1;
                    if (ds.Tables.Contains("M_ITEMS") && ds.Tables["M_ITEMS"].Rows.Count > 0)
                    {
                        DataRow drow = ds.Tables["M_ITEMS"].Rows[0];
                        dr["FULL_NAME"] = cls_Library.DBString(drow["FULL_NAME"]);
                        dr["MODEL1"] = cls_Library.DBString(drow["MODEL1"]);
                        dr["BRAND_ID"] = cls_Library.DBInt(drow["BRAND_ID"]);
                        dr["BRAND_CODE"] = "";
                        //dr["BRAND_NAME"] = "";
                        dr["UNIT_ID"] = 0;
                        dr["UNIT_CODE"] = "";
                        //dr["UNIT_NAME"] = "";
                        if (ds.Tables["D_ITEM_UNITS"].Rows.Count > 0)
                        {
                            //List<DataRow> lst = ds.Tables["D_ITEM_UNITS"].AsEnumerable().Where(r => r.Field<Int16>("LIST_NO") == 1).ToList();
                            //if (lst.Count > 0)
                            //{
                            //    dr["UNIT_ID"] = cls_Library.DBInt(lst[0]["UNIT_ID"]);
                            //    dr["CONV"] = cls_Library.DBDouble(lst[0]["MULTIPLY_QTY"]);
                            //}
                            for (i=0;i< ds.Tables["D_ITEM_UNITS"].Rows.Count;i++)
                            {
                                if (cls_Library.DBInt(ds.Tables["D_ITEM_UNITS"].Rows[i]["SALE_STATUS"]) == 1)
                                {
                                    dr["UNIT_ID"] = cls_Library.DBInt(ds.Tables["D_ITEM_UNITS"].Rows[i]["UNIT_ID"]);
                                    dr["CONV"] = cls_Library.DBDouble(ds.Tables["D_ITEM_UNITS"].Rows[i]["MULTIPLY_QTY"]);
                                    break;
                                }
                            }                            
                        }
                        else
                        {
                            dr["UNIT_ID"] = 1;
                            dr["CONV"] = 1;
                        }
                    }

                    dr["QTY"] = 1;
                    dr["VATtype"] = 1;
                    dr["UPRICE"] = cls_Data.GetPriceListByItem(ItemId, cls_Library.DBInt(dr["UNIT_ID"]));
                    dr["DISCA"] = 0;
                    dr["VATL"] = 0;
                    //Get Price
                    dr["COG"] = cls_Library.DBDecimal(dr["UPRICE"]);
                    dr["NET"] = cls_Library.DBDecimal(dr["UPRICE"]);
                    dr["DELETE_ISCNT"] = false; 
                    dsEdit.Tables["BSDETAIL"].Rows.Add(dr);
                    CalsumTotal();
                }
                else
                {
                    list[0]["QTY"] = cls_Library.DBInt(list[0]["QTY"]) + 1;
                    GetDataRowItemHandle(cls_Global_class.TypeCal.quantity, cls_Library.DBInt(list[0]["LIST_NO"]));
                    Zuprice = cls_Library.DBDecimal(list[0]["UPRICE"]);
                    Zconv = cls_Library.DBDouble(list[0]["CONV"]);
                    ZdiscP = cls_Library.DBString(list[0]["DISCPER"]);
                    Zvat = cls_Library.DBDecimal(list[0]["VATL"]);
                    Qty = cls_Library.DBDouble(list[0]["QTY"]);
                    CalculateValue(cls_Global_class.TypeCal.quantity, cls_Library.DBInt(list[0]["LIST_NO"]));
                }
                AutoSaveData();
                    
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddItem : " + ex.Message);
            }
            finally
            {
                AddDataSourceToGrid();
                //txtItem.Text = "";
            }
        }

        private void AssignDataFromComponent()
        {
            BS.BSH_ID = BSID;

            if (DataMode == cls_Struct.ActionMode.Add)
            {
                string Xs = "IC";
                //IA ขายสด
                //IC ขายเชื่อ
                if (IsCash) Xs = "IA";
                BS.BSH_NO = Xs;//string.Concat(Xs, DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString("00"));
            }
            //else
            //    BS.BSH_NO = txtBSNo.Text.Trim();


            BS.BSH_DATE = cls_Library.CDateTime(dateBS.EditValue);
            BS.CUS_ID = cls_Library.CInt(sluCus.EditValue);
            BS.BSH_STATUS = cls_Library.CByte(luStatus.EditValue);
            BS.PRINT_NO = cls_Library.CInt16(spinPrintNo.EditValue);
            BS.LIST_NO = cls_Library.CInt16(spinListNo.EditValue);
            BS.DELETE_NO = cls_Library.CInt16(spinDeleteNo.EditValue);
            BS.SALE_PER = IdPer;
            BS.RES_PER = cls_Library.CInt16(sluResPer.EditValue);
            BS.PRINT_TYPE = luPrintType.EditValue.ToString();
            BS.CASHIER = Environment.MachineName;
            //BS.PAYMENT_TYPE = cls_Library.CByte(luPaymentType.EditValue);
            BS.IS_ETAX = chkEtax.Checked;
            BS.IS_CASH = IsCash;    //ดูจาก Master Customer
            BS.CASH_AMT = cls_Library.CDecimal(spinCASH.EditValue);
            BS.CARD_AMT = cls_Library.CDecimal(spinCARD.EditValue);
            BS.TRANS_AMT = cls_Library.CDecimal(spinTRANS.EditValue);
            BS.CHEQUE_AMT = cls_Library.CDecimal(spinCHEQUE.EditValue);
            BS.DEPOSIT_AMT = cls_Library.CDecimal(spinDEPOSIT.EditValue);
            BS.OTHER_AMT = cls_Library.CDecimal(spinOTHER.EditValue);
            BS.SUM_AMT = cls_Library.CDecimal(spinSUM_AMT.EditValue);
            BS.PER_VAT = cls_Library.CDouble(spinVatePer.EditValue);
            BS.SUMCOG = cls_Library.CDecimal(spinSumCog.EditValue);
            BS.VATSUM = cls_Library.CDecimal(spinSumVat.EditValue);
            BS.NETSUM = cls_Library.CDecimal(spinNet.EditValue);
        }

        private void AssignDataList()
        {
            try
            {
                DataTable dtList = new DataTable();
                dtList = dsEdit.Tables["BSDETAIL"].Copy();
                dtList.TableName = "BSDETAIL";

                DataColumn colMode1 = new DataColumn("mode", typeof(int));
                DataColumn[] colMode = new DataColumn[6];

                for (int i = 0; i < colMode.Length; i++) colMode[i] = new DataColumn("mode", typeof(int));

                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        //colMode.DefaultValue = cls_Struct.ActionMode.Default;
                        for (int i = 0; i < colMode.Length; i++) colMode[i].DefaultValue = cls_Struct.ActionMode.Default;
                        break;
                    case cls_Struct.ActionMode.Copy:
                        for (int i = 0; i < colMode.Length; i++) colMode[i].DefaultValue = cls_Struct.ActionMode.Add;
                        //colChange.DefaultValue = 1;
                        break;
                }

                dtList.Columns.Add(colMode[0]);
                //dtList.Columns.Add(colChange);

                dsEdit.Tables.Remove("BSDETAIL");
                dsEdit.Tables.Add(dtList);

                //การชำระเงิน

                dsEdit.Tables["MAP_CARD"].Columns.Add(colMode[1]);
                dsEdit.Tables["MAP_TRANSFER_PAY"].Columns.Add(colMode[2]);
                dsEdit.Tables["MAP_CHEQUE"].Columns.Add(colMode[3]);
                dsEdit.Tables["MAP_BSPS"].Columns.Add(colMode[4]);
                dsEdit.Tables["MAP_OTHER"].Columns.Add(colMode[5]);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AssignDataList :" + ex.Message);
            }
        }

        private int AssigNo()
        {
            int no = 1;
            try
            {
                List<DataRow> ListNo = dsEdit.Tables["BSDETAIL"].AsEnumerable().ToList(); //dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                if (ListNo.Count() > 0)
                    no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            return no;
        }

        private void AssignRepositoryGrid()
        {
            //repoSearchItem.DataSource = cls_Global_DB.DataInitial.Tables["M_ITEMS"];
            //repoSearchItem.ValueMember = "_id";
            //repoSearchItem.DisplayMember = "code";

            //repoSearchBrand.DataSource = cls_Global_DB.DataInitial.Tables["M_BRANDS"];
            //repoSearchBrand.ValueMember = "_id";
            //repoSearchBrand.DisplayMember = "name";
        }

        private void AutoSaveData()
        {
            try
            {
                AssignDataFromComponent();
                cls_Global_DB.GB_ItemID = 0;
                cls_Global_DB.GB_BSH_ID = 0;
                IsSaveOK = cls_Data.SaveBS(DataMode, BS, dsEdit);
                if (IsSaveOK)
                {
                    DataMode = cls_Struct.ActionMode.Edit;
                    BSID = cls_Global_DB.GB_BSH_ID;
                    LoadData();
                    cls_Global_DB.GB_DitemBS_count = dsEdit.Tables["BSDETAIL"].Rows.Count;
                }
            }
            catch (Exception ex)
            {
                Application.DoEvents();
                XtraMessageBox.Show("ไม่สามารถบันทึกบิลขายได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsSaveOK = false;
            }
        }

        private void CalculateValue(cls_Global_class.TypeCal category, int RowHandle)
        {
            try
            {
                DataRow drow = gvBS.GetFocusedDataRow();

                Zquan = cls_Library.CDouble(Qty) * Zconv;

                switch (category)
                {
                    case cls_Global_class.TypeCal.price:
                        if (Zquan > 0)
                        {
                            //Zvat = (Znet / 107) * cls_Library.CDecimal(ZvatP);
                            Zvat = 0;
                            Zcog = Znet - Zvat + ZdiscA;
                            ZdiscP = ((ZdiscA * 100) / Zcog).ToString("#,##0.##");                            
                            Zuprice = (Zcog * (decimal)Zconv) / cls_Library.CDecimal(Zquan);
                            drow["UPRICE"] = Zuprice;
                            drow["DISCPER"] = "";
                            if (cls_Library.CDouble(ZdiscP) > 0)
                            {
                                drow["DISCPER"] = ZdiscP;
                            }
                            drow["DISCA"] = ZdiscA;
                            drow["VATL"] = Zvat;
                        }
                        break;
                    case cls_Global_class.TypeCal.quantity:
                        if (Zconv == 0) Zconv = 1;            
                        Zcog = (Zuprice * (decimal)Zquan) / (decimal)Zconv;

                        ZdiscA = cls_Library.CalFix_TXTdisc(ZdiscP, Zcog);
                        Zvat = 0;
                        //if (chkEtax.Checked) Zvat = (Zcog - ZdiscA) * 7 / 100;
                        Znet = Zcog - ZdiscA + Zvat;
                        drow["DISCA"] = ZdiscA;
                        drow["VATL"] = Zvat;
                        drow["COG"] = Znet;
                        drow["NET"] = Znet;
                        break;
                    case cls_Global_class.TypeCal.disc:
                        //ZdiscA = cls_Library.CDecimal(spinDiscount1.EditValue) + cls_Library.CDecimal(spinDiscount2.EditValue) + cls_Library.CDecimal(spinDiscount3.EditValue);
                        break;
                    case cls_Global_class.TypeCal.unitprice:
                        if (Zconv == 0) Zconv = 1;  
                        Zcog = (Zuprice * cls_Library.CDecimal(Zquan)) / (decimal)Zconv;
                        ZdiscA = cls_Library.CalFix_TXTdisc(ZdiscP, Zcog);
                        Zvat = 0;
                        //if (chkEtax.Checked) Zvat = (Zcog - ZdiscA) * 7 / 100;
                        Znet = Zcog - ZdiscA + Zvat;
                        drow["DISCA"] = ZdiscA;
                        drow["VATL"] = Zvat;
                        drow["COG"] = Znet;
                        drow["NET"] = Znet;
                        break;
                    case cls_Global_class.TypeCal.perdisc:
                        if (Zconv == 0) Zconv = 1;
                        Zcog = (Zuprice * cls_Library.CDecimal(Zquan)) / (decimal)Zconv;
                        ZdiscA = cls_Library.CalFix_TXTdisc(ZdiscP, Zcog);
                        Zvat = 0;
                        //if (chkEtax.Checked) Zvat = (Zcog - ZdiscA) * 7 / 100;
                        Znet = Zcog - ZdiscA + Zvat;
                        drow["DISCA"] = ZdiscA;
                        drow["VATL"] = Zvat;
                        drow["COG"] = Znet;
                        drow["NET"] = Znet;
                        break;
                }

                //Zuprice = Zquan == 0 ? 0 : (Zcog * (decimal)Zconv) / Convert.ToDecimal(Zquan);        

                //gvBS.SetRowCellValue(RowHandle, 3"QTY"], cls_Library.CDecimal(Zquan / Zconv));               

                CalsumTotal();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("CalculateValue : " + category + ":" + ex.Message);
            }
        }

        private void CalDisplayInfo(DataRow dr, int iType,int ItemID)
        {
            DataTable dt;
            double GetOnh = 0;
            DateTime RCdate;
            string Scap = "";
            string Scap1 = "";
            string Scap2 = "";
            string Cuscode = "";
            string UnitName = "";
            int Factor = 0;
            int SALE_CODE = 0;
            bool isNET = false;
            decimal Discount = 0;
            int VatType = 0;
            string VatTypeName = "";
            double QTY = 0;
            decimal COG = 0, Price = 0, NetPrice = 0;
            decimal VAT = 0;
            int BrandID = 0;


            if (ItemID == 0) return;

            switch (iType)
            {
                case 1:
                    Scap1 = "NEW";
                    isNET = true;
                    //Scap = "NET" + "     " + "" + Environment.NewLine;
                    dt = cls_Data.GetLastRCDataDT(ItemID);
                    if (dt.Rows.Count > 0)
                    {
                        RCdate = cls_Library.DBDateTime(dt.Rows[0]["T_DATE"]);
                        Cuscode = cls_Library.DBString(dt.Rows[0]["T_CODE"]);
                        VatType = cls_Library.DBInt(dt.Rows[0]["VATTYPE"]);
                        Discount = cls_Library.DBDecimal(dt.Rows[0]["T_DISCOUNT"]);
                        QTY = cls_Library.DBDouble(dt.Rows[0]["T_QTY"]);
                        COG = cls_Library.DBDecimal(dt.Rows[0]["T_COG"]);
                        VAT = cls_Library.DBDecimal(dt.Rows[0]["T_VAT"]);
                        Price = cls_Library.DBDecimal(dt.Rows[0]["T_NET"]);

                        if (VatType == 0) VatTypeName = "ไม่มี VAT";
                        if (VatType == 1) VatTypeName = "VAT นอก";
                        if (VatType == 2) VatTypeName = "VAT ใน";


                        if (Discount > 0) isNET = false;
                        
                        if (isNET)
                        {
                            Scap1 = "NET";
                            Scap1 = Scap1.PadRight(60 - Scap1.Length) + VatTypeName;
                            Scap1 = Scap1 + Environment.NewLine + Environment.NewLine;

                        }
                        else
                        {
                            Scap1 = Discount.ToString("#,##0.00") + "%";
                            Scap1 = Scap1.PadRight(60 - Scap1.Length) + COG.ToString("#,##0.00") + Environment.NewLine + Environment.NewLine;
                        }
                        int iYear = RCdate.Year;
                        if (iYear < 2450) iYear = iYear + 543;
                        iYear = iYear - 2500;
                        NetPrice = 0;
                        switch (VatType)
                        {
                            case 1:
                                if (QTY > 0) NetPrice = Price + (VAT / cls_Library.DBDecimal(QTY));
                                break;
                            case 2:
                                NetPrice = Price;
                                break;
                            case 3:
                                NetPrice = Price;
                                break;
                        }
                        Scap2 = RCdate.Month.ToString("00") + "/" + iYear.ToString("00") + "-" + Cuscode;
                        Scap2 = Scap2.PadRight(69 - Scap2.Length)  + NetPrice.ToString("#,##0.00");
                        Scap = Scap1 + Scap2;
                    }
                    else
                    {
                        Scap = Scap1 + Scap2;
                    }
                    Textmemo1.Text = Scap;
                    break;
                case 2:
                    Scap = "NEW";
                    Scap = Scap.PadRight(57) + "0.00" + Environment.NewLine + Environment.NewLine;
                    dt = cls_Data.GetPriceListByItem(ItemID, 0,1);
                    BrandID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemID, "ITEMS", "BRAND_ID"));
                    if (dt.Rows.Count > 0)
                    {                    
                        cls_Data.GetBrandBuyDiscountByID(ref Discount, ref VatType, BrandID);
                        RCdate = cls_Library.DBDateTime(dt.Rows[0]["NEW_DATE"]);
                        Price = cls_Library.DBDecimal(dt.Rows[0]["NEW_PRICE"]);
                        if (Discount > 0)
                        {
                            if (Discount > 100) Discount = 100;
                            NetPrice = Price - Math.Round((Price * Discount) / 100, 2);
                        }
                        switch (VatType)
                        {
                            case 1:
                                NetPrice = NetPrice + Math.Round((NetPrice * 7)/100,2);
                                break;
                        }
                        int iYear = RCdate.Year;
                        if (iYear < 2450) iYear = iYear + 543;
                        iYear = iYear - 2500;
                        Scap = "NEW";
                        Scap = Scap.PadRight(57) + Price.ToString("#,##0.00") + Environment.NewLine + Environment.NewLine;
                        Scap1 = RCdate.Month.ToString("00") + "/" + iYear.ToString("00");
                        Scap = Scap + Scap1.PadRight(60 - Scap1.Length) + NetPrice.ToString("#,##0.00");                       
                    }
                    Textmemo2.Text = Scap;
                    break;
                case 3:
                    GetOnh = cls_Data.GetBalanceStockOnhand(ItemID);
                    UnitName = cls_Data.GetNameFromTBname(cls_Library.DBInt(dr["UNIT_ID"]), "UNITS", "UNIT_NAME");
                    Factor = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemID,cls_Library.DBInt(dr["UNIT_ID"]), "D_ITEM_UNITS", "MULTIPLY_QTY"));
                    if (Factor ==1)
                    {
                        Scap = "Ond" + "                              " + GetOnh.ToString("#,##0") + "     " + UnitName + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        Scap = "Ond" + "                              " + GetOnh.ToString("#,##0") + "     " + UnitName + "/" + Factor.ToString("#,##0") + Environment.NewLine + Environment.NewLine;
                    }
                    Textmemo3.Text = Scap;
                    break;
                case 4:
                    //Scap = "สุทธิ";
                    //Scap = Scap.PadRight(57) + "0.00" + Environment.NewLine + Environment.NewLine;
                    //isNET = true;
                    //BrandID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemID, "ITEMS", "BRAND_ID"));
                    //SALE_CODE = cls_Library.DBInt(cls_Data.GetNameFromTBname(BrandID, "BRANDS", "SALE_CODE"));
                    //VatType = cls_Library.DBInt(cls_Data.GetNameFromTBname(BrandID, "BRANDS", "CURRENT_VAT_STATUS"));
                    //if (SALE_CODE == 2) isNET = false;
                    //if (isNET)
                    //{
                    //    dt = cls_Data.GetPriceListByItem(ItemID, cls_Library.DBInt(dr["UNIT_ID"]), 2);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        Scap = "สุทธิ";
                    //        Scap = Scap.PadRight(57) + cls_Library.DBDecimal(dt.Rows[0]["PRICE1"]).ToString("#,##0.00") + Environment.NewLine + Environment.NewLine;
                    //        RCdate = cls_Library.DBDateTime(dt.Rows[0]["DATENET"]);
                    //        int iYear = RCdate.Year;
                    //        if (iYear < 2450) iYear = iYear + 543;
                    //        iYear = iYear - 2500;
                    //        Scap1 = RCdate.Month.ToString("00") + "/" + iYear.ToString("00");
                    //        Scap = Scap + Scap1.PadRight(60 - Scap1.Length) + cls_Library.DBDecimal(dt.Rows[0]["PRICE2"]).ToString("#,##0.00");
                    //    }
                    //}
                    //else
                    //{
                    //    Scap1 = "0.0%";
                    //    Scap = Scap1.PadRight(60 - Scap1.Length) + "0.00" + Environment.NewLine + Environment.NewLine;
                    //    dt = cls_Data.GetPriceListByItem(ItemID, 0, 1);
                    //    Price = 0;
                    //    RCdate = DateTime.MinValue;
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        RCdate = cls_Library.DBDateTime(dt.Rows[0]["NEW_DATE"]);
                    //        Price = cls_Library.DBDecimal(dt.Rows[0]["NEW_PRICE"]);
                    //    }
                    //    dt = cls_Data.GetLastRCDataDT(ItemID);
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        Discount = cls_Library.DBDecimal(dt.Rows[0]["T_DISCOUNT"]);
                    //        if (Discount > 0)
                    //        {
                    //            if (cls_Library.DBDateTime(dt.Rows[0]["T_DATE"]) > RCdate)
                    //            {
                    //                Price = cls_Library.DBDecimal(dt.Rows[0]["T_COG"]);
                    //                RCdate = cls_Library.DBDateTime(dt.Rows[0]["T_DATE"]);
                    //            }
                    //        }
                    //    }
                    //    if (Price > 0)
                    //    {
                    //        cls_Data.GetBrandBuyDiscountByID(ref Discount, ref VatType, BrandID);
                    //        if (Discount > 100) Discount = 100;
                    //        NetPrice = Price - Math.Round((Price * Discount) / 100, 2);
                    //    }
                    //    switch (VatType)
                    //    {
                    //        case 1:
                    //            VAT = (NetPrice * (decimal)0.07);
                    //            NetPrice = NetPrice + VAT;
                    //            break;
                    //    }
                    //    if (RCdate != DateTime.MinValue)
                    //    {
                    //        Scap = Discount.ToString("#,##0.00") + "%" + "                          " + "" + Environment.NewLine + Environment.NewLine;
                    //        int iYear = RCdate.Year;
                    //        if (iYear < 2450) iYear = iYear + 543;
                    //        iYear = iYear - 2500;
                    //        Scap1 = RCdate.Month.ToString("00") + "/" + iYear.ToString("00");
                    //        Scap = Scap + Scap1.PadRight(60 - Scap1.Length) + NetPrice.ToString("#,##0.00");
                    //    }
                    //}

                    Scap = "";
                    dt = cls_Data.GetPriceListByItem(ItemID, cls_Library.DBInt(dr["UNIT_ID"]), 2);
                    if (dt.Rows.Count > 0)
                    {
                        if (cls_Library.DBInt(dt.Rows[0]["PRICETYPE"]) == 1)
                        {
                            Scap = "สุทธิ";
                            RCdate = cls_Library.DBDateTime(dt.Rows[0]["DATENET"]);
                        }
                        else
                        {
                            Scap = "ส่วนลด";
                            RCdate = cls_Library.DBDateTime(dt.Rows[0]["DATEDISC"]);
                        }
                        Price = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["PRICE1"]),2);
                        UnitName = cls_Data.GetNameFromTBname(cls_Library.DBInt(dr["UNIT_ID"]), "UNITS", "UNIT_NAME");
                        BrandID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemID, "ITEMS", "BRAND_ID"));
                        VatType = cls_Library.DBInt(cls_Data.GetNameFromTBname(BrandID, "BRANDS", "CURRENT_VAT_STATUS"));
                        if ((cls_Library.DBInt(dt.Rows[0]["PRICETYPE"]) == 2) && (VatType == 1)) Price = Math.Round(Price + (Price * cls_Library.DBDecimal(0.07)), 2);

                        Scap = Scap.PadRight(37) + UnitName + Environment.NewLine + Environment.NewLine;
                        int iYear = RCdate.Year;
                        if (iYear < 2450) iYear = iYear + 543;
                        iYear = iYear - 2500;
                        Scap1 = RCdate.Month.ToString("00") + "/" + iYear.ToString("00");
                        Scap = Scap + Scap1.PadRight(40 - Scap1.Length) + Price;
                    }


                    Textmemo4.Text = Scap;
                    break;
                default:
                    Textmemo1.Text = "";
                    Textmemo2.Text = "";
                    Textmemo3.Text = "";
                    Textmemo4.Text = "";
                    break;
            }
        }

        private void CalsumTotal()
        {
            try
            {
                List<DataRow> listRow = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(item => !item.Field<bool>("DELETE_ISCNT").Equals(true)).ToList();
                //SumQty = listRow.AsEnumerable().Sum(x => x.Field<double?>("QTY") ?? 0);
                decimal SumCog = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG") ?? 0);
                //SumVat = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICEVAT") ?? 0);
                //SumNet = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICESUM") ?? 0);

                spinSumCog.EditValue = SumCog;

                //if (cls_Library.DBDecimal(spinCASH.EditValue) == 0)
                //{
                //    spinCASH.EditValue = spinSumCog.EditValue;
                //}

                



                spinSumVat.EditValue = (cls_Library.DBDecimal(spinVatePer.EditValue) * SumCog) / 100;
                spinSumNet.EditValue = cls_Library.DBDecimal(spinSumCog.EditValue) + cls_Library.DBDecimal(spinSumVat.EditValue);
                spinNet.EditValue = spinSumNet.EditValue;

                //spinCASH.EditValue = spinSumCog.EditValue;
                spinCASH.EditValue = spinSumNet.EditValue;

                DoCalculationPayment();

                //หา
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("CalsumTotal :" + ex.Message);
            }
        }

        private void CalSumValuePay(cls_Struct.TypePay _type)
        {
            switch (_type)
            {
                case cls_Struct.TypePay.Cash:
                    break;
                case cls_Struct.TypePay.Card:
                    spinCARD.EditValue = dsEdit.Tables["MAP_CARD"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Sum(x => x.Field<decimal?>("AMOUNT") ?? 0);
                    
                    break;
                case cls_Struct.TypePay.Trans:
                    spinTRANS.EditValue = dsEdit.Tables["MAP_TRANSFER_PAY"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Sum(x => x.Field<decimal?>("AMOUNT") ?? 0);
                    break;
                case cls_Struct.TypePay.Cheque:
                    spinCHEQUE.EditValue = dsEdit.Tables["MAP_CHEQUE"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Sum(x => x.Field<decimal?>("AMOUNT") ?? 0);
                    break;
                case cls_Struct.TypePay.Deposit:                    
                    break;
                case cls_Struct.TypePay.Other:
                    spinOTHER.EditValue = dsEdit.Tables["MAP_OTHER"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Sum(x => x.Field<decimal?>("AMOUNT") ?? 0);
                    break;
            }
            spinCASH.EditValue = cls_Library.CDecimal(spinSumNet.EditValue) - (cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinDEPOSIT.EditValue));

            DoCalculationPayment();
        }

        private void CalVATbyRow()
        {
            //int ID = 0, NO = 0;
            //int ListId = 0;
            int[] SelectRow = { };
            //DataRow[] dr = null;
            //DataRow[] ListRow = null;

            try
            {
                if (dsEdit.Tables["BSDETAIL"].Rows.Count > 0)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvBS;
                    if ((view.FocusedRowHandle < 0)) return;
                    DataRow row = view.GetFocusedDataRow();
                    SelectRow = gvBS.GetSelectedRows();
                    if (row == null) return;

                    //DataRow dr = gvBS.GetFocusedDataRow();
                    //if (dr == null) return;

                    //int i = 0;

                    //for (i=0; i < dsEdit.Tables["BSDETAIL"].Rows.Count;i++)
                    //{
                    //    dr = dsEdit.Tables["BSDETAIL"].Rows[i];
                    //row["COG"] = cls_Library.CDecimal(row["UPRICE"]) * cls_Library.CDecimal(row["QTY"]);
                    decimal VATL = 0;
                    decimal UPRICE = 0;
                    double Quan = cls_Library.CDouble(row["QTY"]);

                    //VATL = (cls_Library.CDecimal(row["COG"]) / 107) * cls_Library.CDecimal(ZvatP);
                    VATL = (cls_Library.CDecimal(row["NET"]) / 107) * cls_Library.CDecimal(ZvatP);

                    UPRICE = 0;
                    if (Quan > 0)
                    {
                        UPRICE = (cls_Library.CDecimal(row["NET"]) - (VATL + cls_Library.CDecimal(row["DISCA"]))) / cls_Library.CDecimal(Quan);
                    }
                    row["VATL"] = Math.Round(VATL,2);
                    row["UPRICE"] = Math.Round(UPRICE,2);
                    row["COG"] = Math.Round(UPRICE * cls_Library.CDecimal(Quan),2);
                    row["VATtype"] = 2;
                    CalsumTotal();
                    //decimal SumCog = cls_Library.CDecimal(spinSumCog.EditValue);

                    //spinSumVat.EditValue = Math.Round((SumCog / 107) * 7,2);
                    //spinSumNet.EditValue = Math.Round(SumCog,2);
                    //spinSumCog.EditValue = cls_Library.CDecimal(spinSumNet.EditValue) - cls_Library.CDecimal(spinSumVat.EditValue);
                    //spinCASH.EditValue = spinSumCog.EditValue;
                    //spinNet.EditValue = spinSumNet.EditValue;
                    DoCalculationPayment();
                    //}

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("DeleteDataDetail :" + ex.Message);
            }
            finally
            {
                CalsumTotal();
                gridBS.RefreshDataSource();
                //AddDataSourceToGrid();
            }
        }

        private void DeleteDataDetail()
        {
            int ID = 0, NO = 0;
            int ListId = 0;
            int[] SelectRow = { };
            DataRow[] dr = null;
            DataRow[] ListRow = null;
            try
            {
                if (dsEdit.Tables["BSDETAIL"].Rows.Count > 0)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvBS;
                    if ((view.FocusedRowHandle < 0)) return;
                    DataRow row = view.GetFocusedDataRow();
                    SelectRow = gvBS.GetSelectedRows();
                    if (row == null) return;
                    if (SelectRow.Length <= 1)
                    {
                        if (!int.TryParse(gvBS.GetRowCellValue(SelectRow[0], "BSD_ID").ToString(), out ID)) ID = 0; // ดึง Data จาก Rowที่เลือก
                        if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                        if (ID <= 0)
                        {
                            if (!int.TryParse(gvBS.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                            dr = dsEdit.Tables["BSDETAIL"].Select("LIST_NO =" + NO);
                            if (dr.Count() > 0)
                            dsEdit.Tables["BSDETAIL"].Rows.Remove(dr[0]);

                            AddDataSourceToGrid();
                            CalsumTotal();
                            return;
                        }
                        if (!int.TryParse(gvBS.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                        dr = dsEdit.Tables["BSDETAIL"].Select("LIST_NO =" + NO);
                        if (dr.Count() > 0)
                        {
                            dr[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
                            dr[0]["DELETE_ISCNT"] = true;
                            dr[0].AcceptChanges();
                            //Sum Delete Detail
                            //spinDeleteNo.EditValue = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(item => item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete) && item.Field<bool>("DELETE_ISCNT") == true).Count();
                            spinDeleteNo.EditValue = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(item => item.Field<bool>("DELETE_ISCNT") == true).Count();
                        }
                    }
                    else
                    {
                        if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                        for (int i = 0; i < SelectRow.Length; i++)
                        {
                            if (!int.TryParse(gvBS.GetRowCellValue(SelectRow[i], "BSD_ID").ToString(), out ID)) ID = 0;
                            if (ID <= 0)
                            {
                                try
                                {
                                    if (!int.TryParse(gvBS.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out ListId)) ListId = 0;
                                    ListRow = dsEdit.Tables["BSDETAIL"].Select("LIST_NO =" + ListId);
                                    dsEdit.Tables["BSDETAIL"].Rows.Remove(ListRow[0]);
                                    gvBS.FocusedRowHandle = 0;
                                }
                                catch { }
                                }
                            else
                            {
                                if (!int.TryParse(gvBS.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out NO)) NO = 0;
                                DataRow[] Roww = dsEdit.Tables["BSDETAIL"].Select("LIST_NO =" + NO);
                                if (Roww.Length > 0)
                                {
                                    Roww[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
                                    dr[0]["DELETE_ISCNT"] = true;
                                    dr[0].AcceptChanges();
                                    //Roww[0]["Change"] = 1;
                                }
                            }
                        }

                        //Sum Delete Detail
                        //spinDeleteNo.EditValue = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete) && item.Field<bool>("DELETE_ISCNT") == true).Count();
                        spinDeleteNo.EditValue = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(item => item.Field<bool>("DELETE_ISCNT") == true).Count();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("DeleteDataDetail :" + ex.Message);
            }
            finally
            {
                CalsumTotal();
                gvBS.ActiveFilter.Clear();
                gvBS.ActiveFilter.NonColumnFilter = "DELETE_ISCNT = False";
                gridBS.RefreshDataSource();
                //AddDataSourceToGrid();
                
                AutoSaveData();
            }
        }

        private void DoCalculationPayment()
        {
            //spinSUM_AMT.EditValue = cls_Library.CDecimal(spinCASH.EditValue) + cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinDEPOSIT.EditValue) + cls_Library.CDecimal(spinOTHER.EditValue);
            //spinOTHER.EditValue = cls_Library.CDecimal(spinSumNet.EditValue) - (cls_Library.CDecimal(spinCASH.EditValue) + cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinDEPOSIT.EditValue));
            //spinSUM_AMT.EditValue = cls_Library.CDecimal(spinCASH.EditValue) + cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinDEPOSIT.EditValue) + cls_Library.CDecimal(spinOTHER.EditValue);

            //spinOTHER.EditValue = cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinDEPOSIT.EditValue);
            spinCASH.EditValue = cls_Library.CDecimal(spinSumNet.EditValue) - ( cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinDEPOSIT.EditValue)  + cls_Library.CDecimal(spinOTHER.EditValue));
            spinSUM_AMT.EditValue =  (cls_Library.CDecimal(spinCASH.EditValue) + cls_Library.CDecimal(spinCARD.EditValue) + cls_Library.CDecimal(spinTRANS.EditValue) + cls_Library.CDecimal(spinCHEQUE.EditValue) + cls_Library.CDecimal(spinDEPOSIT.EditValue) + cls_Library.CDecimal(spinOTHER.EditValue));
        }

        private void EditQuantity()
        {
            int ID = 0, NO = 0;
            int ListId = 0;
            int[] SelectRow = { };
            DataRow[] dr = null;
            DataRow[] ListRow = null;
            try
            {             
                if (dsEdit.Tables["BSDETAIL"].Rows.Count > 0)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvBS;
                    if ((view.FocusedRowHandle < 0)) return;
                    DataRow row = view.GetFocusedDataRow();

                    frm_AddQuantity frmInput;
                    frmInput = new frm_AddQuantity();
                    frmInput.StartPosition = FormStartPosition.CenterParent;

                    frmInput.Text = "ระบุจำนวนขาย";
                    #region "Assign Lookup"
                    #endregion
                    frmInput.MinimizeBox = false;
                    frmInput.ShowInTaskbar = false;
                    if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    row["QTY"] = frmInput.Qquantity;
                    Qty = frmInput.Qquantity;
                    GetDataRowItemHandle(cls_Global_class.TypeCal.quantity, view.FocusedRowHandle);
                    CalculateValue(cls_Global_class.TypeCal.quantity, view.FocusedRowHandle);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("DeleteDataDetail :" + ex.Message);
            }
            finally
            {
                CalsumTotal();
                gridBS.RefreshDataSource();
                //AddDataSourceToGrid();
            }
        }

        private void EditPrice()
        {
            int ID = 0, NO = 0;
            int ListId = 0;
            int[] SelectRow = { };
            DataRow[] dr = null;
            DataRow[] ListRow = null;
            try
            {                
                if (dsEdit.Tables["BSDETAIL"].Rows.Count > 0)
                {

                    DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvBS;
                    if ((view.FocusedRowHandle < 0)) return;
                    DataRow row = view.GetFocusedDataRow();

                    frm_AddPrice frmInput;
                    frmInput = new frm_AddPrice();
                    frmInput.StartPosition = FormStartPosition.CenterParent;

                    frmInput.Text = "ระบุราคา";
                    #region "Assign Lookup"
                    #endregion
                    frmInput.MinimizeBox = false;
                    frmInput.ShowInTaskbar = false;
                    if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    row["UPRICE"] = frmInput.Qprice;
                    Zuprice = frmInput.Qprice;
                    Qty = cls_Library.DBDouble(gvBS.GetRowCellValue(view.FocusedRowHandle, "QTY"));
                    GetDataRowItemHandle(cls_Global_class.TypeCal.unitprice, view.FocusedRowHandle);
                    CalculateValue(cls_Global_class.TypeCal.unitprice, view.FocusedRowHandle);
                    //CalculateValue(cls_Global_class.TypeCal.price, view.FocusedRowHandle);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("DeleteDataDetail :" + ex.Message);
            }
            finally
            {
                CalsumTotal();
                gridBS.RefreshDataSource();
                //AddDataSourceToGrid();
            }
        }

        private void GetDataRowItemHandle(cls_Global_class.TypeCal category, int RowHandle)
        {
            switch (category)
            {
                case cls_Global_class.TypeCal.price:
                    Zconv = cls_Library.DBDouble(gvBS.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvBS.GetRowCellValue(RowHandle, "QTY"));
                    ZdiscA = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "DISCA"));
                    Zvat = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "VATL"));
                    //Zuprice = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "UPRICE"));
                    break;
                case cls_Global_class.TypeCal.quantity:
                    Zuprice = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "UPRICE"));
                    Zconv = cls_Library.DBDouble(gvBS.GetRowCellValue(RowHandle, "CONV"));
                    ZdiscP = cls_Library.DBString(gvBS.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "VATL"));
                    break;
                case cls_Global_class.TypeCal.unitprice:
                    Zconv = cls_Library.DBDouble(gvBS.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvBS.GetRowCellValue(RowHandle, "QTY"));
                    ZdiscP = cls_Library.DBString(gvBS.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "VATL"));
                    break;
                case cls_Global_class.TypeCal.perdisc:
                    Zconv = cls_Library.DBDouble(gvBS.GetRowCellValue(RowHandle, "CONV"));
                    Qty = cls_Library.DBDouble(gvBS.GetRowCellValue(RowHandle, "QTY"));
                    Zuprice = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "UPRICE"));
                    ZdiscP = cls_Library.DBString(gvBS.GetRowCellValue(RowHandle, "DISCPER"));
                    Zvat = cls_Library.DBDecimal(gvBS.GetRowCellValue(RowHandle, "VATL"));
                    break;
            }           
        }

        private void GetDetailCustomer()
        {
            //ขายสด ขายเชื่อ
            //รูปแบบการพิมพ์
        }

        private void GetHistorySaleItem()
        {
            DataRow dr = gvBS.GetFocusedDataRow();
            if (dr == null) return;
            frm_HistorySale frmHis = new frm_HistorySale(cls_Library.CInt(sluCus.EditValue), cls_Library.DBInt(dr["ITEM_ID"]));
            frmHis.ShowDialog();      
        }

        private void GroupItem()
        {
            DataRow dr;
            List<DataRow> listItem;
            try
            {
                DataTable dt = dsEdit.Tables["BSDETAIL"].Copy();
                DataTable dtGroup = dsEdit.Tables["BSDETAIL"].Clone();

                List<int> GroupItem = dt.AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Select(r => r.Field<int>("ITEM_ID")).Distinct().ToList();

                //List<string> ListItemG = dt.AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Select(s => s.Field<string>("ITEM_CODE")).ToList();
                foreach (int item in GroupItem)
                {
                    dtGroup = dsEdit.Tables["BSDETAIL"].Clone();

                    listItem = dt.AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete) && r.Field<int>("ITEM_ID") == item).ToList();

                    dr = dtGroup.NewRow();

                    dr["mode"] = (int)cls_Struct.ActionMode.Add;
                    dr["BSD_PID"] = BSID;
                    dr["LIST_NO"] = AssigNo(); //ZOZO
                    dr["ITEM_ID"] = item;
                    dr["ITEM_CODE"] = listItem[0]["ITEM_CODE"].ToString();
                    dr["FULL_NAME"] = listItem[0]["FULL_NAME"].ToString();
                    dr["MODEL1"] = listItem[0]["MODEL1"].ToString();
                    dr["BRAND_ID"] = cls_Library.DBInt(listItem[0]["BRAND_ID"]);
                    dr["BRAND_CODE"] = "";
                    dr["UNIT_ID"] = cls_Library.DBInt(listItem[0]["UNIT_ID"]);
                    dr["CONV"] = cls_Library.DBDouble(listItem[0]["CONV"]);
                    dr["QTY"] = listItem.AsEnumerable().Sum(x => x.Field<double?>("QTY") ?? 0);

                    dr["UPRICE"] = cls_Library.DBDouble(listItem[0]["UPRICE"]);
                    dr["COG"] = listItem.AsEnumerable().Sum(x => x.Field<double?>("COG") ?? 0);
                    dr["NET"] = listItem.AsEnumerable().Sum(x => x.Field<double?>("NET") ?? 0);

                    dtGroup.Rows.Add(dr);
                    //ลบ item เดิม
                    //ลบจริง
                    //ลบติด flag
                    listItem = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(r => r.Field<int>("ITEM_ID") == item).ToList();
                    //ZOZO
                    


                    //เพิ่ม item ที่รวมแล้ว
                    dsEdit.Tables["BSDETAIL"].ImportRow(dtGroup.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("GroupItem : " + ex.Message);
            }
            finally
            {
                AddDataSourceToGrid();
            }
        }

        private void InitializeControl()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable _dt = new DataTable();
            DataRow dr = null;

            try
            {
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("id", typeof(int));

                #region สถานะ
                _dt = dt.Clone();
                _dt.TableName = "DocStatus";
                //Open = 1, Print = 2, Receive = 3, POS = 4, ReceiveAndPOS = 5,  Cancel = 99
                for (int i = 1; i <= 4; i++)
                {
                    dr = _dt.NewRow();
                    switch (i)
                    {
                    case 1:
                        dr["Name"] = "เปิด";
                        dr["id"] = i;
                        break;
                    case 2:
                        dr["Name"] = "พิมพ์";
                        dr["id"] = i;
                        break;
                    case 3:
                        dr["Name"] = "รับ+POS";
                        dr["id"] = 5;
                        break;
                    case 4:
                        dr["Name"] = "ยกเลิก";
                        dr["id"] = 99;
                        break;
                    }
                    _dt.Rows.Add(dr);
                }
                ds.Tables.Add(_dt);

                luStatus.Properties.ValueMember = "id";
                luStatus.Properties.DisplayMember = "Name";
                luStatus.Properties.DataSource = ds.Tables["DocStatus"];
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 300);
                luStatus.Properties.Columns.Add(col);
                luStatus.Properties.DropDownRows = 4;
                luStatus.EditValue = 1;

                #endregion

                #region ประเภทการพิมพ์
                dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("id", typeof(string));
                _dt = dt.Clone();
                _dt.TableName = "PrintType";
                for (int i = 1; i <= 3; i++)
                {
                    dr = _dt.NewRow();
                    switch (i)
                    {
                    case 1:
                        dr["Name"] = "ก";
                        dr["id"] = "ก";
                        break;
                    case 2:
                        dr["Name"] = "ข";
                        dr["id"] = "ข";
                        break;
                    case 3:
                        dr["Name"] = "ค";
                        dr["id"] = "ค";
                        break;
                    }
                    _dt.Rows.Add(dr);
                }
                ds.Tables.Add(_dt);

                luPrintType.Properties.ValueMember = "id";
                luPrintType.Properties.DisplayMember = "Name";
                luPrintType.Properties.DataSource = ds.Tables["PrintType"];
                col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "", 100);
                luPrintType.Properties.Columns.Add(col);
                luPrintType.Properties.DropDownRows = 3;
                luPrintType.EditValue = "ก";

                #endregion

                cls_Library.AssignSearchLookUp(sluCus, "M_CUSTOMERS", "รหัสลูกค้า", "ชื่อลูกค้า", cls_Global_class.TypeShow.codename);
                //cls_Library.AssignSearchLookUp(sluPer, "M_PERSONALS", "รหัสพนักงานขาย", "ชื่อพนักงานขาย", cls_Global_class.TypeShow.code);
                //cls_Library.AssignSearchLookUp(sluResPer, "M_PERSONALS", "รหัสผู้รับผิดชอบ", "ชื่อผู้รับผิดชอบ", cls_Global_class.TypeShow.code);

                cls_Library.AssignSearchLookUp(sluPer, "M_USERS", "รหัสพนักงานขาย", "ชื่อพนักงานขาย", cls_Global_class.TypeShow.codename);
                cls_Library.AssignSearchLookUp(sluResPer, "M_USERS", "รหัสผู้รับผิดชอบ", "ชื่อผู้รับผิดชอบ", cls_Global_class.TypeShow.codename);

                repoBrand.DataSource = cls_Global_DB.DataInitial.Tables["M_BRANDS"];
                repoBrand.PopulateViewColumns();
                repoBrand.View.Columns["_id"].Visible = false;
                repoBrand.View.Columns["code"].Visible = false;
                repoBrand.View.Columns["name"].Visible = false;
                repoBrand.ValueMember = "_id";
                repoBrand.DisplayMember = "name";

                repoUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
                repoUnit.PopulateViewColumns();
                repoUnit.View.Columns["_id"].Visible = false;
                repoUnit.View.Columns["code"].Visible = false;
                repoUnit.View.Columns["name"].Visible = false;
                repoUnit.ValueMember = "_id";
                repoUnit.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("InitializeControl :" + ex.Message);
            }
        }

        private void LoadData()
        {
            dsMainData = cls_Data.GetBSById(BSID);
        }

        private void SaveData()
        {
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return;

                AssignDataFromComponent();
                //AssignList();
                cls_Global_DB.GB_ItemID = 0;
                
                IsSaveOK = cls_Data.SaveBS(DataMode, BS, dsEdit);
                if (IsSaveOK)
                {
                    XtraMessageBox.Show("บันทึกข้อมูลบิลขายเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //BSID = cls_Global_DB.GB_ItemID;
                    DataMode = cls_Struct.ActionMode.Edit;
                    
                    LoadData();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Application.DoEvents();
                XtraMessageBox.Show("ไม่สามารถบันทึกบิลขายได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsSaveOK = false;
            }
        }

        private void SetControl()
        {
            try
            {
                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                    //radioPOstatus.SelectedIndex = 0;
                    //radioDueType.SelectedIndex = 0;
                    break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                    btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
                    dateBS.ReadOnly = true;
                    //sluBiller.ReadOnly = true;
                    sluCus.ReadOnly = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetControl :" + ex.Message);
            }
        }

        private void SetDataToControl()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetDelegate(SetDataToControl));
            }
            else
            {
                DataRow row;
                try
                {
                    dsEdit = dsMainData.Copy();
                    AssignDataList();
                    switch (DataMode)
                    {
                        case cls_Struct.ActionMode.Add:
                            SetDefaultData();
                            sluCus.EditValue = IdCus;
                            break;
                        case cls_Struct.ActionMode.Edit:
                        case cls_Struct.ActionMode.Copy:
                        case cls_Struct.ActionMode.View:

                            if (dsEdit.Tables["BSHEADER"].Rows.Count <= 0) return;
                            row = dsEdit.Tables["BSHEADER"].Rows[0];

                            txtBSNo.Text = cls_Library.DBString(row["BSH_NO"]);
                            dateBS.EditValue = cls_Library.DBDateTime(row["BSH_DATE"]);
                            IdCus = cls_Library.DBInt(row["CUS_ID"]);
                            sluCus.EditValue = IdCus;
                            luStatus.EditValue = cls_Library.DBByte(row["BSH_STATUS"]);
                            sluResPer.EditValue = cls_Library.DBInt(row["RES_PER"]);
                            //luPaymentType.EditValue = cls_Library.DBByte(row["PAYMENT_TYPE"]);
                            spinListNo.EditValue = cls_Library.DBInt16(row["LIST_NO"]);
                            spinPrintNo.EditValue = cls_Library.DBInt16(row["PRINT_NO"]);
                            spinDeleteNo.EditValue = cls_Library.DBInt16(row["DELETE_NO"]);
                            if (DataMode != cls_Struct.ActionMode.Add) IdPer = cls_Library.DBInt(row["SALE_PER"]);
                            sluPer.EditValue = IdPer;                            
                            luPrintType.EditValue = cls_Library.DBString(row["PRINT_TYPE"]);
                            chkEtax.Checked = cls_Library.DBbool(row["IS_ETAX"]);
                            IsCash = cls_Library.DBbool(row["IS_CASH"]);
                            spinCASH.EditValue = cls_Library.DBDecimal(row["CASH_AMT"]);
                            spinCARD.EditValue = cls_Library.DBDecimal(row["CARD_AMT"]);
                            spinTRANS.EditValue = cls_Library.DBDecimal(row["TRANS_AMT"]);
                            spinCHEQUE.EditValue = cls_Library.DBDecimal(row["CHEQUE_AMT"]);
                            spinDEPOSIT.EditValue = cls_Library.DBDecimal(row["DEPOSIT_AMT"]);
                            spinOTHER.EditValue = cls_Library.DBDecimal(row["OTHER_AMT"]);
                            spinSUM_AMT.EditValue = cls_Library.DBDecimal(row["SUM_AMT"]);
                            spinVatePer.EditValue = cls_Library.DBDouble(row["PER_VAT"]);
                            spinSumCog.EditValue = cls_Library.DBDecimal(row["SUMCOG"]);
                            spinSumNet.EditValue = cls_Library.DBDecimal(row["VATSUM"]);
                            spinSumNet.EditValue = cls_Library.DBDecimal(row["NETSUM"]);
                            spinNet.EditValue = cls_Library.DBDecimal(row["NETSUM"]);

                            CalsumTotal();
                            break;
                    }
                    AddDataSourceToGrid();
                    //PIAK
                    switch (DataMode)
                    {
                        case cls_Struct.ActionMode.Add:
                        case cls_Struct.ActionMode.Copy:
                            AutoSaveData();
                            break;
                    }

                    cls_Global_DB.GB_DitemBS_count = dsEdit.Tables["BSDETAIL"].Rows.Count;

                    txtItem2.Focus();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("SetDataToControl :" + ex.Message);
                }
            }
        }

        private void SetDefaultData()
        {
            //XXX
            try
            {
                txtBSNo.ReadOnly = true;
                txtBSNo.BackColor = Color.FromArgb(255, 255, 192);
                dateBS.EditValue = DateTime.Today;
                luStatus.EditValue = 1;
                //luPaymentType.EditValue = 1;
                sluPer.EditValue = IdPer;
                sluResPer.EditValue = IdPer;
                sluCus.EditValue = IdCus;
                luPrintType.EditValue = "ก";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetDefaultData :" + ex.Message);
            }
        }

        private void SetItemToList()
        {
            try
            {
                List<DataRow> ListCheck = dsEdit.Tables["BSDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete) && r.Field<string>("ITEM_CODE") == txtItem2.Text.Trim()).ToList();
                int ItemH = ListCheck.Count;
                if (ItemH > 0)  //มีอยู่ใน List แล้ว
                {
                    //XXXXXXXXXXXXXXXXX
                }
                else
                {
                    //เพิ่มรายการ Detail
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetItemToList : " + ex.Message);
            }
        }

        private void SetUnit(int ItemId)
        {
            try
            {
                DataRow drow = gvBS.GetFocusedDataRow();
                dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId);
                if (dtUnit.Rows.Count > 0)
                {
                    List<DataRow> lst = dtUnit.AsEnumerable().Where(r => r.Field<Int16>("LIST_NO") == 1).ToList();
                    if (lst.Count > 0)
                    {
                        drow["UNIT_ID"] = cls_Library.DBInt(lst[0]["UNIT_ID"]);
                        drow["UNIT_CODE"] = cls_Library.DBDouble(lst[0]["MULTIPLY_QTY"]);
                    }
                }
                string[] selectedColumns = new[] { "_id", "code", "name", "MULTIPLY_QTY", "codename" };
                DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
                repoUnit.DataSource = dt;
                repoUnit.PopulateViewColumns();
                repoUnit.View.Columns["_id"].Visible = false;
                repoUnit.View.Columns["codename"].Visible = false;
                repoUnit.View.Columns["code"].Caption = "รหัสหน่วยนับ";
                repoUnit.View.Columns["name"].Caption = "ชื่อหน่วยนับ";
                repoUnit.View.Columns["MULTIPLY_QTY"].Caption = "จำนวนหน่วยย่อย";

                repoUnit.ValueMember = "_id";
                repoUnit.DisplayMember = "codename";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetLocation :" + ex.Message);
            }
        }

        private void SetRowposition(bool sR)
        {
            if (sR)
            {
                BTeditStock.Visible = false;
                BThistory.Visible = true;
                BTprice.Visible = true;
                BTquantity.Visible = true;
                BTdiscount.Visible = true;
                BTdelete.Visible = true;
                BTvatlist.Visible = true;
                BTvatall.Visible = true;
            }
            else
            {
                BTeditStock.Visible = true;
                BThistory.Visible = false;
                BTprice.Visible = false;
                BTquantity.Visible = false;
                BTdiscount.Visible = false;
                BTdelete.Visible = false;
                BTvatlist.Visible = false;
                BTvatall.Visible = false;
            }
        }

        private bool VerifyData()
        {
            bool ret = true;
            StringBuilder msg = new StringBuilder();
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return false;

                if (string.IsNullOrEmpty(txtBSNo.Text))
                {
                    ret = false;
                    msg.AppendLine("ไม่มีเลขที่เอกสาร");
                }

                if (!cls_Library.IsDate(dateBS.EditValue))
                {
                    ret = false;
                    msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
                }


                if (sluCus.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสลูกค้าไม่ถูกต้อง");
                }

                if (sluResPer.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสผู้รับผิดชอบไม่ถูกต้อง");
                }

                if (!ret)
                {
                    MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ret;
                }

                if (cls_Library.CDecimal(spinSumNet.EditValue) != cls_Library.CDecimal(spinSUM_AMT.EditValue))
                {
                    ret = false;
                    MessageBox.Show("จำนวนเงินและยอดรับชำระต้องเท่ากัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ret;
        }

        #endregion

        public frm_BSRecord(cls_Struct.ActionMode mode, int id,int Cusid = 0, int Saleid = 0,bool ISCash = false)
        {
            InitializeComponent();
            KeyPreview = true;
            DataMode = mode;
            BSID = id;
            IdCus = Cusid;
            IdPer = Saleid;
            IsCash = ISCash;
            //XXXXXXXXXXXXXXXXXX
            //panelMemo.Visible = false;
            cls_Global_DB.DataInitial = cls_Data.GetDataInitialSale();
            RowPosition = false;
            ShowDelete = false;
            SetRowposition(RowPosition);
            //SetUnit();
            gvBS.GotFocus += GvBS_GotFocus;
            txtItem.GotFocus += TxtItem_GotFocus;
            txtItem.Select();
        }

        private void TxtItem_GotFocus(object sender, EventArgs e)
        {
            RowPosition = false;
            SetRowposition(RowPosition);
            txtItem.Select();
            txtDecription.Visible = false;
        }

        private void GvBS_GotFocus(object sender, EventArgs e)
        {
            RowPosition = true;
            DataRow dr = gvBS.GetFocusedDataRow();
            if (dr == null) return;

            string ItemCode = cls_Library.DBString(dr["ITEM_CODE"]);
            int ItemID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemCode, "ITEMS", "ITEM_ID"));

            //CalDisplayInfo(dr, 1, ItemID);
            //CalDisplayInfo(dr, 2, ItemID);
            //CalDisplayInfo(dr, 3, ItemID);
            //CalDisplayInfo(dr, 4, ItemID);

            txtDecription.Text = ItemCode + "     " + cls_Data.GetNameFromTBname(ItemID, "ITEMS", "FULL_NAME");
            txtDecription.Visible = true;
        }

        private void frm_BSRecord_Load(object sender, EventArgs e)
        {
            InitializeControl();
            SetControl();
            Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
            {
                this.Invoke(new SetDelegate(SetDataToControl));
            });
            sluCus.EditValue = IdCus;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (VerifyData()) SaveData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sluCus_EditValueChanged(object sender, EventArgs e)
        {
            //DataRow[] dr = cls_Global_DB.DataInitial.Tables["M_CUSTOMERS"].Select("_id = " + sluBrand.EditValue);
            //if (dr.Length == 0)
            //  return;
            //txtBrandName.Text = dr[0]["name"].ToString();
            //Branddesc = dr[0]["description"].ToString();
        }

        private void gvBS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }        

        private void spinCASH_EditValueChanged(object sender, EventArgs e)
        {
            if (spinCASH.IsEditorActive)
            {
                DoCalculationPayment();
            }
        }

        private void spinCARD_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinCARD.IsEditorActive)
            //{
            //    DoCalculationPayment();

            //    //ถ้าเคยมียอดเงินแล้วลบออก ต้องไปใส่ Delete ใบตาราง MAP ด้วย
            //    //

            //    //ZOZO
            //}
        }

        private void spinTRANS_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinTRANS.IsEditorActive)
            //{
            //    DoCalculationPayment();
            //}
        }

        private void spinCHEQUE_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinCHEQUE.IsEditorActive)
            //{
            //    DoCalculationPayment();
            //}
        }

        private void spinDEPOSIT_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinDEPOSIT.IsEditorActive)
            //{
            //    DoCalculationPayment();
            //}
        }

        private void spinOTHER_EditValueChanged(object sender, EventArgs e)
        {
            //if (spinOTHER.IsEditorActive)
            //{
            //    DoCalculationPayment();
            //}
        }

        private void txtItem_EditValueChanged(object sender, EventArgs e)
        {
            //if (txtItem.IsEditorActive)
            //{
            //    if (txtItem.Text.Length <= 0) return;

            //    int id = cls_Data.GetItemID(txtItem.Text.Trim());
            //    if (id > 0)
            //    {
            //        AddItem(id, txtItem.Text.Trim());
            //        txtItem.Text = "";

            //    }
            //    //SetItemToList();
            //}
        }

        private void gvBS_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
                switch (e.Column.Name)
                {
                case "col1":  //รหัสสินค้า

                break;
                case "col2":  //ชื่อสินค้า
                break;
                case "col3":  //ยี่ห้อ
                break;
                case "col4":  //รุ่น
                break;
                case "col5":  //หน่วบนับ
                    GetDataRowItemHandle(cls_Global_class.TypeCal.perdisc, e.RowHandle);
                    CalculateValue(cls_Global_class.TypeCal.quantity, e.RowHandle);
                break;
                case "col6":  //จำนวน
                    Qty = cls_Library.DBDouble(e.Value);
                    GetDataRowItemHandle(cls_Global_class.TypeCal.quantity, e.RowHandle);
                    CalculateValue(cls_Global_class.TypeCal.quantity, e.RowHandle);
                    break;
                case "col7":  //ราคาต่อหน่วย
                    Zuprice = cls_Library.DBDecimal(e.Value);
                    GetDataRowItemHandle(cls_Global_class.TypeCal.unitprice, e.RowHandle);
                    CalculateValue(cls_Global_class.TypeCal.unitprice, e.RowHandle);
                    break;
                case "col8":  //รวมเงิน
                    Znet  = cls_Library.DBDecimal(e.Value);
                    GetDataRowItemHandle(cls_Global_class.TypeCal.price, e.RowHandle);
                    CalculateValue(cls_Global_class.TypeCal.price, e.RowHandle);
                    break;
                case "col9":    //อัตราส่วนลด
                    ZdiscP = cls_Library.DBString(e.Value);
                    GetDataRowItemHandle(cls_Global_class.TypeCal.perdisc, e.RowHandle);
                    CalculateValue(cls_Global_class.TypeCal.perdisc, e.RowHandle);
                    break;
                case "col11":   //ภาษีในรายการ
                    break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("gvBS_CellValueChanged : " + ex.Message);
            }
        }

        private void spinVatePer_EditValueChanged(object sender, EventArgs e)
        {
            if (spinVatePer.IsEditorActive)
            {
                spinSumVat.EditValue = (cls_Library.DBDecimal(spinVatePer.EditValue) * cls_Library.DBDecimal(spinSumCog.EditValue)) / 100;
                spinSumNet.EditValue = cls_Library.DBDecimal(spinSumCog.EditValue) + cls_Library.DBDecimal(spinSumVat.EditValue);
                spinNet.EditValue = spinSumNet.EditValue;
                CalsumTotal();
            }
        }

        private void btItemDelete_Click(object sender, EventArgs e)
        {
            frm_ChkPassword frmChk = new frm_ChkPassword();
            if (frmChk.ShowDialog() == DialogResult.OK)
            {
                DeleteDataDetail();
            }
            
        }

        private void spinCARD_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frm_CardRecord frmCard = new frm_CardRecord(1);
                frmCard.DataTransPay = dsEdit.Tables["MAP_CARD"];
                frmCard.IdData = BSID;
                if (frmCard.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = dsEdit.Tables["MAP_CARD"].Copy();
                    dsEdit.Tables.Remove("MAP_CARD");
                    dsEdit.Tables.Add(frmCard.DataTransPay.Copy());
                    CalSumValuePay(cls_Struct.TypePay.Card);
                }
            }
        }

        private void spinTRANS_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frm_TransferPayRecord frmTrans = new frm_TransferPayRecord(1);
                frmTrans.DataTransPay = dsEdit.Tables["MAP_TRANSFER_PAY"];
                frmTrans.IdData = BSID;
                if (frmTrans.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = dsEdit.Tables["MAP_TRANSFER_PAY"].Copy();
                    dsEdit.Tables.Remove("MAP_TRANSFER_PAY");
                    dsEdit.Tables.Add(frmTrans.DataTransPay.Copy());
                    CalSumValuePay(cls_Struct.TypePay.Trans);
                }
            }
        }

        private void spinDEPOSIT_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frm_Choose_PS frm = new frm_Choose_PS(IdCus);
                frm.DataMap = dsEdit.Tables["MAP_BSPS"];
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    //XXXXXXXXXXXXXXX
                    // กรณีมีของเดิมอยู่แล้ว แล้วดึงใหม่จะจัดการกับของเดิมยังไง

                    if (dsEdit.Tables.Contains("MAP_BSPS"))
                    {
                        dsEdit.Tables.Remove("MAP_BSPS");
                    }
                    DataTable dt = frm.DataMap;
                    dt.TableName = "MAP_BSPS";
                    spinDEPOSIT.EditValue = frm.Total;
                    dsEdit.Tables.Add(dt);

                    CalsumTotal();
                }
            }
        }

        private void spinOTHER_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frm_OtherRecord frmTrans = new frm_OtherRecord(1);
                frmTrans.DataTransPay = dsEdit.Tables["MAP_OTHER"];
                frmTrans.IdData = BSID;
                if (frmTrans.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = dsEdit.Tables["MAP_OTHER"].Copy();
                    dsEdit.Tables.Remove("MAP_OTHER");
                    dsEdit.Tables.Add(frmTrans.DataTransPay.Copy());
                    CalSumValuePay(cls_Struct.TypePay.Other);
                }
            }
        }

        private void frm_BSRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("ต้องการปิดหน้าจอการขายใช่หรือไม่?","ยืนยัน",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            Class_Library mc = new Class_Library();
            Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
            ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
            cls_Global_DB.GB_GroupReplace = 0;
            cls_Global_DB.GB_GroupJoin = 0;
            //Force garbage collection.
            GC.Collect();

            // Wait for all finalizers to complete before continuing.
            GC.WaitForPendingFinalizers();
        }

        private void gvBS_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.F2:
            //        btSave.PerformClick();
            //        break;
            //    case Keys.F12:
            //        GetHistorySaleItem();
            //        break;
            //    case Keys.Escape:
            //        btClose.PerformClick();
            //        break;
            //}
        }

        private void frm_BSRecord_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (RowPosition)
                    {
                        RowPosition = false;
                        SetRowposition(RowPosition);
                        txtItem.Select();
                        txtDecription.Visible = false;
                    }
                    else
                    {
                        this.Close();
                    }
                    
                    break;
                case Keys.F1:
                    BThistory.PerformClick();
                    break;
                case Keys.F2:
                    btSave.PerformClick();
                    break;
                //txtItem.Text = "";
                case Keys.F3:
                    //RowPosition = !RowPosition;
                    //if (RowPosition)
                    //{
                    //    gridBS.Select();
                    //    txtDecription.Visible = true;
                    //}
                    //else
                    //{
                    //    txtItem.Select();
                    //    txtDecription.Visible = false;
                    //}
                    BTeditStock.PerformClick();
                    break;
                case Keys.F4:
                    if (!RowPosition) return;
                    BTprice.PerformClick();
                    break;
                case Keys.F8:
                    if (!RowPosition) return;
                    BTdelete.PerformClick();
                    break;
                case Keys.F9:
                    if (!RowPosition) return;
                    BTquantity.PerformClick();
                    break;
                case Keys.F11:
                    if (!RowPosition) return;
                    BTvatlist.PerformClick();
                    break;

                case Keys.F12:
                    if (!RowPosition) return;
                    BTvatall.PerformClick();
                    break;
            }         
        }

        private void gvBS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDecription.Text = "";
            RowPosition = true;
            DataRow dr = gvBS.GetFocusedDataRow();
            if (dr == null) return;

            string ItemCode = cls_Library.DBString(dr["ITEM_CODE"]);
            int ItemID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemCode, "ITEMS", "ITEM_ID"));

            CalDisplayInfo(dr,1, ItemID);
            CalDisplayInfo(dr,2, ItemID);
            CalDisplayInfo(dr,3, ItemID);
            CalDisplayInfo(dr,4, ItemID);

            //DataTable dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemID);
            //if (dtUnit.Rows.Count > 0)
            //{
            //    List<DataRow> lst = dtUnit.AsEnumerable().Where(r => r.Field<Int16>("LIST_NO") == 1).ToList();
            //    if (lst.Count > 0)
            //    {
            //        //dr["UNIT_ID"] = cls_Library.DBInt(lst[0]["UNIT_ID"]);
            //        Zconv = cls_Library.DBDouble(lst[0]["MULTIPLY_QTY"]);
            //    }
            //}
            //string[] selectedColumns = new[] { "_id", "code", "name", "MULTIPLY_QTY", "codename" };
            //DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
            //repoUnit.DataSource = dt;
            //repoUnit.PopulateViewColumns();
            //repoUnit.View.Columns["_id"].Visible = false;
            //repoUnit.View.Columns["codename"].Visible = false;
            //repoUnit.View.Columns["code"].Caption = "รหัสหน่วยนับ";
            //repoUnit.View.Columns["name"].Caption = "ชื่อหน่วยนับ";
            //repoUnit.View.Columns["MULTIPLY_QTY"].Caption = "จำนวนหน่วยย่อย";

            //repoUnit.ValueMember = "_id";
            ////sluUnit.Properties.DisplayMember = "name";
            //repoUnit.DisplayMember = "codename";

            txtDecription.Text = ItemCode + "     " + cls_Data.GetNameFromTBname(ItemID, "ITEMS", "FULL_NAME");
        }

        private void gvBS_DoubleClick(object sender, EventArgs e)
        {
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //if (info.InRow || info.InRowCell)
            //{
            //    if (info.Column.AbsoluteIndex == 8 || info.Column.AbsoluteIndex == 11)
            //    {
            //        view.FocusedRowHandle = info.RowHandle;
            //        view.FocusedColumn = info.Column;
            //        DXMouseEventArgs.GetMouseArgs(ea).Handled = true;
            //        if (ea.Clicks == 2 && ea.Button == System.Windows.Forms.MouseButtons.Left)
            //        {
            //            if (info.Column.AbsoluteIndex == 8)
            //            {
            //                DataRow dr = gvBS.GetFocusedDataRow();
            //                if (dr == null) return;
            //                int IdBrand = cls_Library.DBInt(dr["BRAND_ID"]);
            //                DataTable dtBrand;
            //                cls_Data.LoadSpecifyData(string.Format("Select SALE_CODE From M_BRANDS Where BRAND_ID = {0}", IdBrand), out dtBrand, "M_BRANDS");
            //                if (dtBrand.Rows.Count > 0)
            //                {
            //                    if (cls_Library.DBByte(dtBrand.Rows[0]["SALE_CODE"]) != 2)
            //                    {
            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    return;
            //                }
            //            }
            //            frm_ChkPassword frmChk = new frm_ChkPassword();
            //            if (frmChk.ShowDialog() == DialogResult.OK)
            //            {
            //                view.Columns[info.Column.AbsoluteIndex].OptionsColumn.AllowEdit = true;
            //                view.ShowEditor();
            //            }
            //        }
            //    }
            //}
        }

        private void gvBS_HiddenEditor(object sender, EventArgs e)
        {
            //gvBS.Columns[8].OptionsColumn.AllowEdit = false;
            //gvBS.Columns[11].OptionsColumn.AllowEdit = false;
        }

        private void BTvat_Click(object sender, EventArgs e)
        {
            //DataRow dr = gvBS.GetFocusedDataRow();
            //if (dr == null) return;

            //int i = 0;

            //for (i=0; i < dsEdit.Tables["BSDETAIL"].Rows.Count;i++)
            //{
            //    dr = dsEdit.Tables["BSDETAIL"].Rows[i];
            //    dr["VATL"] = (cls_Library.CDecimal(dr["COG"]) / 107) * cls_Library.CDecimal(ZvatP);
            //    dr["UPRICE"] = cls_Library.CDecimal(dr["COG"]) - (cls_Library.CDecimal(dr["VATL"]) + cls_Library.CDecimal(dr["DISCA"]));
            //}
        }

        private void BThistory_Click(object sender, EventArgs e)
        {
            if (!RowPosition) return;
            GetHistorySaleItem();
        }

        private void BTdelete_Click(object sender, EventArgs e)
        {
            if (!RowPosition) return;
            if (cls_Library.DBInt(spinPrintNo.EditValue) > 0)
            {
                frm_ChkPassword frmChk = new frm_ChkPassword();
                if (frmChk.ShowDialog() == DialogResult.OK)
                {
                    DeleteDataDetail();
                }
            }
            else
            {
                DeleteDataDetail();
            }
            
            AutoSaveData();
        }

        private void BTprice_Click(object sender, EventArgs e)
        {
            if (!RowPosition) return;
            if (DataMode == cls_Struct.ActionMode.Edit)
            {
                frm_ChkPassword frmChk = new frm_ChkPassword();
                if (frmChk.ShowDialog() == DialogResult.OK)
                {
                    EditPrice();
                }
            }
            else
            {
                EditPrice();
            }
            AutoSaveData();
        }

        private void BTquantity_Click(object sender, EventArgs e)
        {
            if (!RowPosition) return;
            if (DataMode == cls_Struct.ActionMode.Edit)
            {
                frm_ChkPassword frmChk = new frm_ChkPassword();
                if (frmChk.ShowDialog() == DialogResult.OK)
                {
                    EditQuantity();
                }
            }
            else
            {
                EditQuantity();
            }
            AutoSaveData();
        }

        private void BTdiscount_Click(object sender, EventArgs e)
        {
            if (!RowPosition) return;
            DataRow row = gvBS.GetFocusedDataRow();
            if (row == null) return;
            string ItemCode = cls_Library.DBString(row["ITEM_CODE"]);
            int ItemID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemCode, "ITEMS", "ITEM_ID"));
            int SALE_CODE = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemID, "BRANDS", "SALE_CODE"));
            if (SALE_CODE == 1)
            {
                XtraMessageBox.Show("สินค้าตั้งราคาเป็นแบบสุทธิ ไม่สามารถใช้ส่วนลดได้", "กำหนดส่วนลด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            if (DataMode == cls_Struct.ActionMode.Edit)
            {
                frm_ChkPassword frmChk = new frm_ChkPassword();
                if (frmChk.ShowDialog() == DialogResult.OK)
                {
                    EditQuantity();
                }
            }
            else
            {
                EditQuantity();
            }
            AutoSaveData();
        }

        private void txtItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (Char)Keys.Enter)
            //{
            //    if (txtItem.Text.Length <= 0) return;

            //    int id = cls_Data.GetItemID(txtItem.Text.Trim());
            //    if (id > 0)
            //    {
            //        AddItem(id, txtItem.Text.Trim());
            //        //txtItem.Text = "";
            //    }
            //}
                
        }

        private void txtItem_Leave(object sender, EventArgs e)
        {
            //if (txtItem.Text == "") return;
            //int id = cls_Data.GetItemID(txtItem.Text.Trim());
            //if (id > 0)
            //{
            //    AddItem(id, txtItem.Text.Trim());
            //    txtItem.Text = "";
            //}
        }

        private void BTvatall_Click(object sender, EventArgs e)
        {
            decimal VATL = 0;
            decimal UPRICE = 0;
            double Quan = 0;
            if (!chkEtax.Checked) return;
            frm_ChkPassword frmChk = new frm_ChkPassword();
            if (frmChk.ShowDialog() == DialogResult.OK)
            {
                if (XtraMessageBox.Show("ต้องการถอด Vat ทั้งใบใช่หรือไม่?", "ลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                DataRow dr = gvBS.GetFocusedDataRow();
                if (dr == null) return;

                int i = 0;

                for (i = 0; i < dsEdit.Tables["BSDETAIL"].Rows.Count; i++)
                {
                    dr = dsEdit.Tables["BSDETAIL"].Rows[i];
                    //dr["COG"] = cls_Library.CDecimal(dr["UPRICE"]) * cls_Library.CDecimal(dr["QTY"]);
                    VATL = 0;
                    UPRICE = 0;
                    Quan = cls_Library.CDouble(dr["QTY"]);

                    //VATL = (cls_Library.CDecimal(dr["COG"]) / 107) * cls_Library.CDecimal(ZvatP);
                    VATL = (cls_Library.CDecimal(dr["NET"]) / 107) * cls_Library.CDecimal(ZvatP);

                    UPRICE = 0;
                    if (Quan > 0)
                    {
                        UPRICE = (cls_Library.CDecimal(dr["NET"]) - (VATL + cls_Library.CDecimal(dr["DISCA"]))) / cls_Library.CDecimal(Quan);
                    }
                    dr["VATL"] = VATL;
                    dr["VATtype"] = 2;
                    dr["UPRICE"] = UPRICE;
                    dr["COG"] = Math.Round(UPRICE * cls_Library.CDecimal(Quan), 2);
                }

                CalsumTotal();
                //decimal SumCog = cls_Library.CDecimal(spinSumCog.EditValue);

                //spinSumVat.EditValue = Math.Round((SumCog / 107) * 7,2);
                //spinSumNet.EditValue = Math.Round(SumCog,2);
                //spinSumCog.EditValue = cls_Library.CDecimal(spinSumNet.EditValue) - cls_Library.CDecimal(spinSumVat.EditValue);
                //spinCASH.EditValue = spinSumCog.EditValue;
                //spinNet.EditValue = spinSumNet.EditValue;
                DoCalculationPayment();
                AutoSaveData();
            }
            

        }

        private void BTvatlist_Click(object sender, EventArgs e)
        {
            if (chkEtax.Checked == false) return;
            if (!RowPosition) return;
            if (DataMode == cls_Struct.ActionMode.Edit)
            {
                frm_ChkPassword frmChk = new frm_ChkPassword();
                if (frmChk.ShowDialog() == DialogResult.OK)
                {
                    CalVATbyRow();
                }
            }
            else
            {
                CalVATbyRow();
            }
            AutoSaveData();
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            if (txtItem.Text.Length <= 0) return;

            int id = cls_Data.GetItemID(txtItem.Text.Trim());
            if (id > 0)
            {
                AddItem(id, txtItem.Text.Trim());
                txtItem.Text = "";
                RowPosition = false;
                TxtItem_GotFocus(sender, e);
            }
                //SetItemToList();
        }

        private void txtItem_MouseUp(object sender, MouseEventArgs e)
        {
            RowPosition = false;
            txtItem.SelectAll();
        }

        private void chkEtax_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit item = (CheckEdit)sender;
            if (item.Checked)
            {
                if ( cls_Library.DBDouble(spinVatePer.EditValue) == 0)
                {
                    spinVatePer.EditValue = 7;
                    CalsumTotal();
                }
            }
        }

        private void BTeditStock_Click(object sender, EventArgs e)
        {
            if (dsEdit.Tables["BSDETAIL"].Rows.Count <= 0) return;
            RowPosition = true;
            SetRowposition(RowPosition);
            gridBS.Select();
            txtDecription.Visible = true;
        }

        private void spinCHEQUE_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frm_ChequeRecord frmCheque = new frm_ChequeRecord(1);
                frmCheque.DataCheque = dsEdit.Tables["MAP_CHEQUE"];
                frmCheque.IdData = BSID;
                if (frmCheque.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = dsEdit.Tables["MAP_CHEQUE"].Copy();
                    dsEdit.Tables.Remove("MAP_CHEQUE");
                    dsEdit.Tables.Add(frmCheque.DataCheque.Copy());
                    CalSumValuePay(cls_Struct.TypePay.Cheque);
                }
            }
        }

        private void BTshowDelete_Click(object sender, EventArgs e)
        {
            ShowDelete = !ShowDelete;


            gridBS.RefreshDataSource();
            gvBS.ActiveFilter.Clear();
            if (ShowDelete)
            {
                BTshowDelete.Appearance.BackColor = Color.Red;
                gvBS.ActiveFilter.NonColumnFilter = "DELETE_ISCNT = False or DELETE_ISCNT = True";
            }
            else
            {
                BTshowDelete.Appearance.BackColor = Color.FromArgb(255, 192, 128);
                gvBS.ActiveFilter.NonColumnFilter = "DELETE_ISCNT = False";
            }
        }
    }
}