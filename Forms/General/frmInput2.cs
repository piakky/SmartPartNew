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
using System.IO;
using System.Data.SqlClient;
using DevExpress.Utils;
using System.Diagnostics;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using SmartPart.Forms.Code;
using SmartPart.Forms.Sale;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace SmartPart.Forms.General
{
    public partial class frmInput2 : DevExpress.XtraEditors.XtraForm
    {
        #region Variable

        DataSet dsData = new DataSet();
        DataTable dtShow = new DataTable();
        DataTable dtShow_Tmp = new DataTable();
        DataTable dtVG = new DataTable();
        Size sizeText;

        bool FocusRowchangeOK = false;

        //Main Search
        int MainSearch = 0;
        int SubSearch = 0;
        string ProductSearch = "";
        string CategorySearch = "";
        string ActiveGroupReplace = "";
        string ActiveGroupJoin = "";
        bool ProcessStartOK = false;
        int RowNumberID = 0;
        int MinRowNumberID = 0;
        int MaxRowNumberID = 0;
        int ItemID = 0;

        int SortType = 0;

        //ตัวแปร search แบบที่ 1
        string PdtCode;
        //int Categoriesid, Brandid, Sizesid, Typesid;
        string CategoriesCode,CategoriesName;
        string AbbreviateName;
        string GenuinPart, ProducerPart, FullName, BrandCode, BrandName, SizesCode, SizesName, SizeInner, SizeOutside, SizeThick, Model1, Model2, Model3, LocationName, Alternate, TypesCode, TypesName;
        int SortOrderNum;

        //ตัวแปร search แบบที่ 3
        int POGroupid, Vendorsid;
        string POGroupCode, POGroupName, VendorsCode, VendorName;
        int CountType;

        //ตัวแปร สินค้าใช้ด้วยกัน สินค้าใช้แทนกัน สินค้าอเนกประสงค์
        DataTable dtJoin, dtReplace, dtVersatile;
        bool SelectJoin = false;
        bool SelectReplace = false;
        bool SelectVersatile = false;

        //ตัวแปร Undo
        int uNCoumt = 0;
        // #1
        string[] u_comboItemSearch, u_comboSort, u_txtProduct, u_txtCategory, u_txtBarcode;
        int[] u_sluCustomer;
        // #2
        string[] u_txtDocNo, u_txtDocData, u_txtCode, u_txtOut, u_txtIn, u_txtThick, u_txtStock, u_txtBrand;
        // #3
        DateTime[] u_dateDoc,u_datePrice, u_dateStock, u_dateMoveStock;
        // #4
        int[] u_spinListNo, u_spinCostAvg, u_spinCostOneYear, u_spinCostbfLast, u_spinCostLast, u_spinNewPrice, u_spinCostAfVat, u_spinPriceAfVat;
        int[] u_spinH, u_spinL, u_spinUse, u_spinSell, u_spinBuy, u_spinNumStock, u_spinNumwait;
        bool[] u_chkSearch, u_chkSet, u_chkComponent, u_chkBarcode;
        // #5
        DataTable[] u_cvItem, u_vGridItem, u_dtJoin, u_dtReplace, u_dtVersatile;

        //Job
        int JOBid;
        string JOBcode;
        DateTime JOBdate;

        //For Search Type
        int searchType = 0;
        #endregion

        #region Use define function
        private void AddDetailVoucher(cls_Struct.VoucherType type)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            DataSet dsData = new DataSet();
            try
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();


                ID = cls_Data.CheckActiveVoucher(type);
                if (ID > 0)
                {
                    switch (type)
                    {
                        case cls_Struct.VoucherType.PO:
                            dsData = cls_Data.GetPOById(ID);
                            frm_PODetailInput frmPO = new frm_PODetailInput();
                            frmPO.Text = "เพิ่มรายการสินค้า";
                            frmPO.SetEditData = row;
                            frmPO.DataID = ID;
                            frmPO.SetDatasetEdit = dsData;
                            frmPO.SetListNo = AssigNo(type, dsData);
                            frmPO.InitialDialog(cls_Struct.ActionMode.Add);
                            frmPO.ShowDialog();
                            break;
                        case cls_Struct.VoucherType.RC:
                            dsData = cls_Data.GetRCById(ID);
                            frm_RCDetailInput frmRC = new frm_RCDetailInput();
                            frmRC.Text = "เพิ่มรายการสินค้า";
                            frmRC.SetEditData = row;
                            frmRC.DataID = ID;
                            frmRC.SetDatasetEdit = dsData;
                            frmRC.SetListNo = AssigNo(type, dsData);
                            frmRC.InitialDialog(cls_Struct.ActionMode.Add);
                            //frmRC.txtInvNo.Text = txtInvNo.Text;
                            //frmRC.dateInvNo.EditValue = dateInv.EditValue;
                            //frmRC.txtSellType.Text = comboSelltype.SelectedText;
                            //frmRC.txtCus.Text = sluCus.SelectedText;
                            //frmRC.txtCategory.Text = sluItemType.SelectedText;
                            //frmRC.txtCredit.Text = spinCredit.EditValue.ToString();
                            //frmRC.comboVatStatus.SelectedText = comboVatStatus.SelectedText;
                            if (frmRC.ShowDialog() == DialogResult.OK)
                            {
                                SetUpdateDataFocus(1);
                                SetUpdateDataFocus(2);
                                SetUpdateDataFocus(3);
                                SetUpdateDataFocus(4);
                                SetUpdateDataFocus(5);
                                SetUpdateDataFocus(6);
                                SetUpdateDataFocus(7);
                                UpdateItemData();
                                //SetDataFocus();
                            }
                            break;
                        case cls_Struct.VoucherType.JOB:
                            dsData = cls_Data.GetJOBById(ID);
                            frm_JOBDetailInput frmJOB = new frm_JOBDetailInput();
                            frmJOB.Text = "เพิ่มรายการสินค้า";
                            frmJOB.SetEditData = row;
                            frmJOB.SetDatasetEdit = dsData;
                            frmJOB.DataID = ID;
                            frmJOB.SetListNo = AssigNo(type, dsData);
                            frmJOB.InitialDialog(cls_Struct.ActionMode.Add);
                            frmJOB.ShowDialog();
                            break;
                        case cls_Struct.VoucherType.RO:
                            dsData = cls_Data.GetROById(ID);
                            frm_RODetailInput frmRO = new frm_RODetailInput();
                            frmRO.Text = "เพิ่มรายการสินค้า";
                            frmRO.SetEditData = row;
                            frmRO.DataID = ID;
                            frmRO.SetDatasetEdit = dsData;
                            frmRO.SetListNo = AssigNo(type, dsData);
                            frmRO.InitialDialog(cls_Struct.ActionMode.Add);
                            //frmRO.txtRONo.Text = txtRONo.Text;
                            //frmRO.dateRO.EditValue = dateRO.EditValue;
                            //frmRO.sluCus.Text = sluCus.SelectedText;
                            //frmRO.comboVatStatus.Text = comboVatStatus.SelectedText;
                            frmRO.ShowDialog();
                            break;
                    }
                }
                else
                {
                    switch (type)
                    {
                    case cls_Struct.VoucherType.PO:
                        XtraMessageBox.Show("ไม่มีใบสำคัญ (PO) ที่ Active", "Set Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case cls_Struct.VoucherType.RC:
                        XtraMessageBox.Show("ไม่มีใบสำคัญ (RC) ที่ Active", "Set Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case cls_Struct.VoucherType.JOB:
                        XtraMessageBox.Show("ไม่มีใบสำคัญ (JOB) ที่ Active", "Set Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case cls_Struct.VoucherType.RO:
                        XtraMessageBox.Show("ไม่มีใบสำคัญ (RO) ที่ Active", "Set Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
        
            }
            catch (Exception ex)
            {
            //XXXX
            }
        }

        private int AssigNo(cls_Struct.VoucherType type, DataSet dsData)
        {
            int no = 1;
            try
            {
            switch (type)
            {
                case cls_Struct.VoucherType.PO:
                no = dsData.Tables["PODETAIL"].Rows.Count + 1;
                break;
                case cls_Struct.VoucherType.RC:
                no = dsData.Tables["RCDETAIL"].Rows.Count + 1;
                break;
                case cls_Struct.VoucherType.JOB:
                no = dsData.Tables["JOBDETAIL"].Rows.Count + 1;
                break;
                case cls_Struct.VoucherType.RO:
                no = dsData.Tables["RODETAIL"].Rows.Count + 1;
                break;
                case cls_Struct.VoucherType.SQ:
                no = dsData.Tables["SQDETAIL"].Rows.Count + 1;
                break;
            }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            return no;
        }

        private void AssignArraUndo(int nCount)
        {
            try
            {
            Array.Resize(ref u_comboItemSearch, nCount); Array.Resize(ref u_comboSort, nCount); Array.Resize(ref u_txtProduct, nCount); Array.Resize(ref u_txtCategory, nCount); Array.Resize(ref u_sluCustomer, nCount); Array.Resize(ref u_txtBarcode, nCount);
            // #2
            Array.Resize(ref u_txtDocNo, nCount); Array.Resize(ref u_txtDocData, nCount); Array.Resize(ref u_txtCode, nCount); Array.Resize(ref u_txtOut, nCount); Array.Resize(ref u_txtIn, nCount); Array.Resize(ref u_txtThick, nCount); Array.Resize(ref u_txtStock, nCount); Array.Resize(ref u_txtBrand, nCount);
            // #3
            Array.Resize(ref u_dateDoc, nCount); Array.Resize(ref u_datePrice, nCount); Array.Resize(ref u_dateStock, nCount); Array.Resize(ref u_dateMoveStock, nCount);
            // #4
            Array.Resize(ref u_spinListNo, nCount); Array.Resize(ref u_spinCostAvg, nCount); Array.Resize(ref u_spinCostOneYear, nCount); Array.Resize(ref u_spinCostbfLast, nCount); Array.Resize(ref u_spinCostLast, nCount); Array.Resize(ref u_spinNewPrice, nCount); Array.Resize(ref u_spinCostAfVat, nCount); Array.Resize(ref u_spinPriceAfVat, nCount);
            Array.Resize(ref u_spinH, nCount); Array.Resize(ref u_spinL, nCount); Array.Resize(ref u_spinUse, nCount); Array.Resize(ref u_spinSell, nCount); Array.Resize(ref u_spinBuy, nCount); Array.Resize(ref u_spinNumStock, nCount); Array.Resize(ref u_spinNumwait, nCount);
            Array.Resize(ref u_chkSearch, nCount); Array.Resize(ref u_chkSet, nCount); Array.Resize(ref u_chkComponent, nCount); Array.Resize(ref u_chkBarcode, nCount);
            // #5
            Array.Resize(ref u_cvItem, nCount); Array.Resize(ref u_vGridItem, nCount); Array.Resize(ref u_dtJoin, nCount); Array.Resize(ref u_dtReplace, nCount); Array.Resize(ref u_dtVersatile, nCount);
            }
            catch (Exception ex)
            {

            }
        }

        private void AssignValueToArraUndo(int nCount)
        {
            try
            {
            u_comboItemSearch[nCount - 1] = comboItemSearch.Text.Trim();
            u_comboSort[nCount - 1] = comboSort.Text.Trim();
            u_txtProduct[nCount - 1] = txtProduct.Text.Trim();
            u_txtCategory[nCount - 1] = txtCategory.Text.Trim(); u_sluCustomer[nCount - 1] = cls_Library.DBInt(sluCustomer.EditValue); u_txtBarcode[nCount - 1] = txtBarcode.Text.Trim();
            // #2
            u_txtDocNo[nCount - 1] = txtDocNo.Text.Trim(); u_txtDocData[nCount - 1] = txtDocData.Text.Trim(); u_txtCode[nCount - 1] = txtCode.Text.Trim(); u_txtOut[nCount - 1] = txtOut.Text.Trim(); u_txtIn[nCount - 1] = txtIn.Text.Trim(); u_txtThick[nCount - 1] = txtThick.Text.Trim(); u_txtStock[nCount - 1] = txtStock.Text.Trim(); u_txtBrand[nCount - 1] = txtBrand.Text.Trim();
            // #3
            u_dateDoc[nCount - 1] = dateDoc.DateTime; u_datePrice[nCount - 1] = datePrice.DateTime; u_dateStock[nCount - 1] = dateStock.DateTime; u_dateMoveStock[nCount - 1] = dateMoveStock.DateTime;
            // #4
            u_spinListNo[nCount - 1] = cls_Library.DBInt(spinListNo.EditValue); u_spinCostAvg[nCount - 1] = cls_Library.DBInt(spinCostAvg.EditValue); u_spinCostOneYear[nCount - 1] = cls_Library.DBInt(spinCostOneYear.EditValue); u_spinCostbfLast[nCount - 1] = cls_Library.DBInt(spinCostbfLast.EditValue); u_spinCostLast[nCount - 1] = cls_Library.DBInt(spinCostLast.EditValue); u_spinNewPrice[nCount - 1] = cls_Library.DBInt(spinNewPrice.EditValue); u_spinCostAfVat[nCount - 1] = cls_Library.DBInt(spinCostAfVat.EditValue); u_spinPriceAfVat[nCount - 1] = cls_Library.DBInt(spinPriceAfVat.EditValue);
            u_spinH[nCount - 1] = cls_Library.DBInt(spinH.EditValue); u_spinL[nCount - 1] = cls_Library.DBInt(spinL.EditValue); u_spinUse[nCount - 1] = cls_Library.DBInt(spinUse.EditValue); u_spinSell[nCount - 1] = cls_Library.DBInt(spinSell.EditValue); u_spinBuy[nCount - 1] = cls_Library.DBInt(spinBuy.EditValue); u_spinNumStock[nCount - 1] = cls_Library.DBInt(spinNumStock.EditValue); u_spinNumwait[nCount - 1] = cls_Library.DBInt(spinNumwait.EditValue);
            u_chkSearch[nCount - 1] = cls_Library.DBbool(chkSearch.EditValue); u_chkSet[nCount - 1] = cls_Library.DBbool(chkSet.EditValue); u_chkComponent[nCount - 1] = cls_Library.DBbool(chkComponent.EditValue); u_chkBarcode[nCount - 1] = cls_Library.DBbool(chkBarcode.EditValue);
            // #5
            u_cvItem[nCount - 1] = (DataTable)gridItem.DataSource; u_vGridItem[nCount - 1] = (DataTable)vGridItem.DataSource; u_dtJoin[nCount - 1] = dtJoin.Copy(); u_dtReplace[nCount - 1] = dtReplace.Copy(); u_dtVersatile[nCount - 1] = dtVersatile.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AssignArraUndoToValue(int nCount)
        {
            try
            {
            // #1
            comboItemSearch.Text = u_comboItemSearch[nCount - 1];
            comboSort.Text = u_comboSort[nCount - 1];
            txtProduct.Text = u_txtProduct[nCount - 1];
            txtCategory.Text = u_txtCategory[nCount - 1]; sluCustomer.EditValue = u_sluCustomer[nCount - 1]; txtBarcode.Text = u_txtBarcode[nCount - 1];
            // #2
            txtDocNo.Text = u_txtDocNo[nCount - 1]; txtDocData.Text = u_txtDocData[nCount - 1]; txtCode.Text = u_txtCode[nCount - 1]; txtOut.Text = u_txtOut[nCount - 1];
            txtIn.Text = u_txtIn[nCount - 1]; txtThick.Text = u_txtThick[nCount - 1]; txtStock.Text = u_txtStock[nCount - 1]; txtBrand.Text = u_txtBrand[nCount - 1];
            // #3
            dateDoc.Text = "";
            if (cls_Library.IsDate(u_dateDoc[nCount - 1])) dateDoc.DateTime = u_dateDoc[nCount - 1];
            datePrice.Text = "";
            if (cls_Library.IsDate(u_datePrice[nCount - 1])) datePrice.DateTime = u_datePrice[nCount - 1];
            dateStock.Text = "";
            if (cls_Library.IsDate(u_dateStock[nCount - 1])) dateStock.DateTime = u_dateStock[nCount - 1];
            dateMoveStock.Text = "";
            if (cls_Library.IsDate(u_dateMoveStock[nCount - 1])) dateMoveStock.DateTime = u_dateMoveStock[nCount - 1];
            // #4
            spinListNo.EditValue = u_spinListNo[nCount - 1]; spinCostAvg.EditValue = u_spinCostAvg[nCount - 1]; spinCostOneYear.EditValue = u_spinCostOneYear[nCount - 1]; spinCostbfLast.EditValue = u_spinCostbfLast[nCount - 1];
            spinCostLast.EditValue = u_spinCostLast[nCount - 1]; spinNewPrice.EditValue = u_spinNewPrice[nCount - 1]; spinCostAfVat.EditValue = u_spinCostAfVat[nCount - 1]; spinPriceAfVat.EditValue = u_spinPriceAfVat[nCount - 1];
            spinH.EditValue = u_spinH[nCount - 1]; spinL.EditValue = u_spinL[nCount - 1]; spinUse.EditValue = u_spinUse[nCount - 1]; spinSell.EditValue = u_spinSell[nCount - 1]; spinBuy.EditValue = u_spinBuy[nCount - 1];
            spinNumStock.EditValue = u_spinNumStock[nCount - 1]; spinNumwait.EditValue = u_spinNumwait[nCount - 1];
            chkSearch.EditValue = cls_Library.DBbool(u_chkSearch[nCount - 1]); chkSet.EditValue = cls_Library.DBbool(u_chkSet[nCount - 1]); chkComponent.EditValue = cls_Library.DBbool(u_chkComponent[nCount - 1]); chkBarcode.EditValue = cls_Library.DBbool(u_chkBarcode[nCount - 1]);
            // #5
            dtShow = u_cvItem[nCount - 1].Copy();
            gridItem.DataSource = dtShow;
            gridItem.RefreshDataSource();
            gridItem.Refresh();
            cvItem.RefreshData();
            dtVG = u_vGridItem[nCount - 1].Copy();
            vGridItem.DataSource = dtVG;
            vGridItem.RefreshDataSource();
            dtJoin = u_dtJoin[nCount - 1].Copy();
            gridJoin.DataSource = dtJoin;
            gridJoin.RefreshDataSource();
            dtReplace = u_dtReplace[nCount - 1].Copy();
            gridReplace.DataSource = dtReplace;
            gridReplace.RefreshDataSource();
            dtVersatile = u_dtVersatile[nCount - 1].Copy();
            gridVersatile.DataSource = dtVersatile;
            gridVersatile.RefreshDataSource();
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message);
            }
        }

        private void ClearControl()
        {
            try
            {
                dockPanel2.Text = "รายการที่";
                vGridItem.DataSource = null;
                txtDocNo.Text = "";
                dateDoc.Text = "";
                spinListNo.Text = "";
                txtDocData.Text = "";
                spinCostAvg.Text = "";
                spinCostOneYear.Text = "";
                spinCostbfLast.Text = "";
                spinCostLast.Text = "";
                spinNewPrice.Text = "";
                datePrice.Text = "";
                spinCostAfVat.Text = "";
                spinPriceAfVat.Text = "";
                listDiscount.Items.Clear();

                spinH.Text = "";
                spinL.Text = "";
                spinUse.Text = "";
                spinSell.Text = "";
                spinBuy.Text = "";
                txtCode.Text = "";
                txtOut.Text = "";
                txtIn.Text = "";
                txtThick.Text = "";
                spinNumStock.Text = "";
                spinNumwait.Text = "";
                txtStock.Text = "";
                dateStock.Text = "";
                dateMoveStock.Text = "";
                txtBrand.Text = "";
                chkSearch.EditValue = false;
                chkSet.EditValue = false;
                chkComponent.EditValue = false;
                chkBarcode.EditValue = false;
                //picItem.Image = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("ClearControl: " + ex.Message);
            }
        }

        private void GetDataChoose(cls_Global_class.ChooseType type, string ItemCode = "")
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            string sqltext;           
            try
            {
                searchType = 0;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    #region Select Case 
                    switch (type)
                    {
                        case cls_Global_class.ChooseType.Customer:
                            txtBarcode.Text = "";
                            break;
                        case cls_Global_class.ChooseType.Item:
                            sluCustomer.EditValue = "";
                            //string val = txtBarcode.Text;
                            ProductSearch = txtProduct.Text.Trim();
                            if (!string.IsNullOrEmpty(ItemCode))
                            {
                                ProductSearch = ItemCode;
                            }
                            txtProduct.Text = "";

                            dt = new DataTable("M_ITEMS");
                    
                            sqltext = "";

                                //if (SortType > 0)
                                //{
                                //    switch (SortType)
                                //    {
                                //        case 1:
                                //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY CATEGORY_CODE,ABBREVIATE_NAME,MODEL1) as RNnew  FROM Vw_ItemSearch";
                                //            if (CategorySearch.Length > 0)
                                //                sqltext += string.Format(" where CATEGORY_CODE = '{0}'", CategorySearch);
                                //            break;
                                //        case 2:
                                //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY CATEGORY_CODE,FULL_NAME,MODEL1) as RNnew  FROM Vw_ItemSearch";
                                //            if (CategorySearch.Length > 0)
                                //                sqltext += string.Format(" where CATEGORY_CODE = '{0}'", CategorySearch);
                                //            break;
                                //        case 3:
                                //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY ITEM_CODE) as RNnew  FROM Vw_ItemSearch";
                                //        break;
                                //        case 4:
                                //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY GENUIN_PART_ID) as RNnew  FROM Vw_ItemSearch";
                                //            break;
                                //        case 5:
                                //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY BRAND_PART_ID) as RNnew  FROM Vw_ItemSearch";
                                //            break;
                                //        case 6:
                                //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_OUTSIDE) as RNnew  FROM Vw_ItemSearch";
                                //            break;
                                //        case 7:
                                //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_THICK) as RNnew  FROM Vw_ItemSearch";
                                //            break;
                                //        case 8:
                                //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_INNER) as RNnew  FROM Vw_ItemSearch";
                                //            break;
                                //    }
                                //}

                                #region " เก็บไว้ก่อน "
                                //sqltext = "SELECT * FROM Vw_AllItemsRN";
                                //sqltext += " Where len(ITEM_CODE) > 0 ";
                                //if (ProductSearch.Length > 0)
                                //{
                                //  switch (SortType)
                                //  {
                                //    case 1:
                                //      sqltext += string.Format(" and ABBREVIATE_NAME Like '{0}%'", ProductSearch);
                                //      if (CategorySearch.Length > 0)
                                //        sqltext += string.Format(" and CATEGORY_CODE = '{0}'", CategorySearch);
                                //      break;
                                //    case 2:
                                //      sqltext += string.Format(" and FULL_NAME Like '{0}%'", ProductSearch);
                                //      if (CategorySearch.Length > 0)
                                //        sqltext += string.Format(" and CATEGORY_CODE = '{0}'", CategorySearch);
                                //      break;
                                //    case 3:
                                //      sqltext += string.Format(" and ITEM_CODE Like '{0}%'", ProductSearch);
                                //      break;
                                //    case 4:
                                //      sqltext += string.Format(" and GENUIN_PART_ID Like '{0}%'", ProductSearch);
                                //      break;
                                //    case 5:
                                //      sqltext += string.Format(" and BRAND_PART_ID Like '{0}%'", ProductSearch);
                                //      break;
                                //    //case 6:
                                //    //  sqltext += string.Format(" and SIZE_OUTSIDE Like '{0}%'", ProductSearch);
                                //    //  break;
                                //    //case 7:
                                //    //  sqltext += string.Format(" and SIZE_THICK Like '{0}%'", ProductSearch);
                                //    //  break;
                                //    //case 8:
                                //    //  sqltext += string.Format(" and SIZE_INNER Like '{0}%'", ProductSearch);
                                //    //  break;
                                //    case 6:
                                //      sqltext += string.Format(" and SIZE_CODE Like '{0}%'", ProductSearch);
                                //      break;
                                //    case 7:
                                //      sqltext += string.Format(" and SIZE_CODE Like '{0}%'", ProductSearch);
                                //      break;
                                //    case 8:
                                //      sqltext += string.Format(" and SIZE_CODE Like '{0}%'", ProductSearch);
                                //      break;
                                //  }
                                //}
                                #endregion



                                //if (SortType > 0)
                                //{
                                //    switch (SortType)
                                //    {
                                //        case 1:
                                //        sqltext += " order by CATEGORY_CODE,ABBREVIATE_NAME,MODEL1";
                                //        break;
                                //        case 2:
                                //        sqltext += " order by CATEGORY_CODE,FULL_NAME,MODEL1";
                                //        break;
                                //        case 3:
                                //        sqltext += " order by ITEM_CODE";
                                //        break;
                                //        case 4:
                                //        sqltext += " order by GENUIN_PART_ID";
                                //        break;
                                //        case 5:
                                //        sqltext += " order by BRAND_PART_ID";
                                //        break;
                                //        case 6:
                                //        sqltext += " order by SIZE_CODE,SIZE_OUTSIDE";
                                //        break;
                                //        case 7:
                                //        sqltext += " order by SIZE_CODE,SIZE_THICK";
                                //        break;
                                //        case 8:
                                //        sqltext += " order by SIZE_CODE,SIZE_INNER";
                                //        break;
                                //    }
                                //}

                            sqltext = "SP_M_ItemSearch";

                            command.Connection = conn;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "SP_M_ItemSearch";

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@pType", SortType);
                            command.Parameters.AddWithValue("@CategorySearch", CategorySearch);

                            dtShow = new DataTable();
                            _dataAdapter = new SqlDataAdapter(command);
                            _dataAdapter.Fill(dtShow);

                            //_dataAdapter.SelectCommand = new SqlCommand(sqltext, conn);
                            //_dataAdapter.SelectCommand.Parameters.Clear();
                            //_dataAdapter.SelectCommand.CommandTimeout = 300;


                            //    dtShow = new DataTable();
                            //_dataAdapter.Fill(dtShow);





                            RowNumberID = 0;
                        //dtShow = dt.Copy();
                        if (dtShow.Rows.Count > 0)
                        {
                            if (ProductSearch.Length > 0)
                            {
                                ItemID = 0;
                                dtShow_Tmp = dtShow.Clone();
                                DataRow[] drw = new DataRow[0];
                                switch (SortType)
                                {
                                case 1:
                                    drw = dtShow.Select("ABBREVIATE_NAME Like '" + ProductSearch + "%'");
                                    break;
                                case 2:
                                    drw = dtShow.Select("FULL_NAME Like '" + ProductSearch + "%'");
                                    break;
                                case 3:
                                    drw = dtShow.Select("ITEM_CODE Like '" + ProductSearch + "%'");
                                    break;
                                case 4:
                                    drw = dtShow.Select("GENUIN_PART_ID Like '" + ProductSearch + "%'");
                                    break;
                                case 5:
                                    drw = dtShow.Select("BRAND_PART_ID Like '" + ProductSearch + "%'");
                                    break;
                                //case 6:
                                //  sqltext += string.Format(" and SIZE_OUTSIDE Like '{0}%'", ProductSearch);
                                //  break;
                                //case 7:
                                //  sqltext += string.Format(" and SIZE_THICK Like '{0}%'", ProductSearch);
                                //  break;
                                //case 8:
                                //  sqltext += string.Format(" and SIZE_INNER Like '{0}%'", ProductSearch);
                                //  break;
                                case 6:
                                case 7:
                                case 8:
                                    drw = dtShow.Select("SIZE_CODE Like '" + ProductSearch + "%'");
                                    break;
                                }
                                if (drw.Length > 0)
                                {
                                    ItemID = cls_Library.DBInt(drw[0]["ITEM_ID"]);
                                }
                                DataRow[] dr = new DataRow[0];
                                if (ItemID > 0)
                                {
                                    //dtShow_Tmp = dtShow.Copy();
                                    dr = dtShow.Select("ITEM_ID =" + ItemID + "");
                                    if (dr.Length > 0)
                                    {
                                        RowNumberID = cls_Library.DBInt(dr[0]["RNnew"]);
                                        MinRowNumberID = RowNumberID - 50;
                                        MaxRowNumberID = RowNumberID + 50;
                                    }
                                    dr = dtShow.Select("RNnew >=" + MinRowNumberID + " and RNnew <=" + MaxRowNumberID + "");
                                    if (dr.Length > 0) dtShow = dr.CopyToDataTable();
                                    //gridItem.DataSource = dtShow;
                                    //gridItem.RefreshDataSource();

                                }
                                else
                                {
                                    dtShow = dtShow_Tmp.Clone();
                                }
                            }
                            else
                            {
                                if (ItemID > 0)
                                {
                                //dtShow_Tmp = dtShow.Copy();
                                DataRow[] dr = dtShow.Select("ITEM_ID =" + ItemID + "");
                                if (dr.Length > 0)
                                {
                                    RowNumberID = cls_Library.DBInt(dr[0]["RNnew"]);
                                    MinRowNumberID = RowNumberID - 50;
                                    MaxRowNumberID = RowNumberID + 50;
                                }
                                dr = dtShow.Select("RNnew >=" + MinRowNumberID + " and RNnew <=" + MaxRowNumberID + "");
                                if (dr.Length > 0) dtShow = dr.CopyToDataTable();
                                //gridItem.DataSource = dtShow;
                                //gridItem.RefreshDataSource();

                                }
                            }
                
                            spinListNo.Text = dtShow.Rows.Count.ToString("#,##0");
                            spinListNo.Properties.EditMask = @"#,####,###";
                            spinListNo.Properties.DisplayFormat.FormatString = @"#,####,###";
                        }
                        //for (int i = 0; i < dtShow.Rows.Count; i++)
                        //{
                        //    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                        //}
                        //Setgrid();
                        //}
                        //else
                        //{
                        //    dt = null;
                        //    dtShow = null;
                        //    ClearControl();
                        //}
                        RowNumberID = -1;
                        if (dtShow.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtShow.Rows.Count; i++)
                            {
                                RowNumberID++;
                                if (ItemID == cls_Library.DBInt(dtShow.Rows[i]["ITEM_ID"]))
                                {
                                break;
                                }
                            }
                        }
              
                        if (RowNumberID < 0) RowNumberID = 0;

                        //Grid                            
                        gridItem.DataSource = dtShow;
                        gridItem.RefreshDataSource();
                        cvItem.RefreshData();
              
                        cvItem.FocusedRowHandle = RowNumberID;
                        eLabelRecord.Text = "";
                        if (dtShow.Rows.Count > 0) eLabelRecord.Text = "Record : " + (RowNumberID + 1).ToString("#,##0") + "/" + dtShow.Rows.Count.ToString("#,##0");
                        FocusRowchangeOK = false;
                        if (gridItem.Visible)
                        {
                            FocusRowchangeOK = true;
                            SetDataFocus();
                            FocusRowchangeOK = false;
                        }
                        //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                        //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                        if (dtShow.Rows.Count > 0)
                        {
                            uNCoumt++;
                            AssignArraUndo(uNCoumt);
                            AssignValueToArraUndo(uNCoumt);
                        }
                        gridItem.Select();
                        break;
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            //throw;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void GetDataChooseForSortOrder(cls_Global_class.ChooseType type, string ItemCode = "")
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            string sqltext;
            try
            {
                searchType = 0;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    #region Select Case 
                    switch (type)
                    {
                        case cls_Global_class.ChooseType.Customer:
                            txtBarcode.Text = "";
                            break;
                        case cls_Global_class.ChooseType.Item:
                            sluCustomer.EditValue = "";
                            //string val = txtBarcode.Text;
                            ProductSearch = txtProduct.Text.Trim();
                            if (!string.IsNullOrEmpty(ItemCode))
                            {
                                ProductSearch = ItemCode;
                            }
                            txtProduct.Text = "";
                            //if (!string.IsNullOrEmpty(ProductSearch))
                            //{
                            dt = new DataTable("M_ITEMS");
                            //xx = join
                            //sqltext = "SELECT A.ITEM_CODE + CHAR(10) + CHAR(10) + ISNULL(A.ABBREVIATE_NAME, '   ') + CHAR(10) + CHAR(10) + ISNULL(B.BRAND_NAME, '') AS Group1,"
                            //        + "ISNULL(A.GENUIN_PART_ID, '   ') + CHAR(10) + CHAR(10) + ISNULL(A.BRAND_PART_ID,'') + CHAR(10) + CHAR(10) + ISNULL(A.FULL_NAME, '') AS Group2,"
                            //        + "ISNULL(A.MODEL1, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL2, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL3, '') AS Group3,"
                            //        + "ISNULL(A.MODEL1, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL2, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL3, '') AS Group4,"
                            //        + "ISNULL(I.VENDOR_NAME, '') + CHAR(10) + CHAR(10) + CONVERT(nvarchar,CONVERT(date,ISNULL(B.SETUP_PRICE_DATE,''))) + char(10) + char(10) +  + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                            //        + "A.ITEM_ID, A.ITEM_CODE, A.MAKER_BARCODE_NO, A.SET_STATUS, A.COMPONENT_STATUS, A.BRAND_ID,"
                            //        + "A.*, B.BRAND_CODE, B.BRAND_ID AS Expr1, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE, I.VENDOR_NAME, J.PART_ID,"
                            //        + "0 as RCD_ID, 0 as RCD_PID"
                            //        + " FROM M_VENDORS I INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID AND G.LIST_NO = 1 RIGHT OUTER JOIN"
                            //        + " M_ITEMS A LEFT OUTER JOIN"
                            //        + " M_BRANDS AS B ON A.BRAND_ID = B.BRAND_ID LEFT OUTER JOIN"
                            //        + " M_CATEGORIES AS C ON C.CATEGORY_ID = A.CATEGORY_ID LEFT OUTER JOIN"
                            //        + " M_TYPES AS D ON D.TYPE_ID = A.TYPE_ID LEFT OUTER JOIN"
                            //        + " M_SIZES AS E ON E.SIZE_ID = A.SIZE_ID LEFT OUTER JOIN"
                            //        + " D_ITEM_PO_GROUPS AS F ON F.ITEM_ID = A.ITEM_ID AND F.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " M_PO_GROUPS AS H ON H.PO_GROUP_ID = F.PO_GROUP_ID ON G.ITEM_ID = A.ITEM_ID AND G.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " D_ITEM_ALTERNATE_PARTS AS J ON J.ITEM_ID = A.ITEM_ID AND J.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " D_ITEM_PICTURES AS Z ON Z.ITEM_ID = A.ITEM_ID AND Z.LIST_NO = 1";

                            //sqltext = "Select A.ITEM_CODE + char(10) + char(10) + ISNULL(A.ABBREVIATE_NAME,'') + char(10) + char(10) + ISNULL(B.BRAND_CODE,'') as Group1,"
                            //        + "ISNULL(A.GENUIN_PART_ID,'') + char(10) + char(10) + ISNULL(A.BRAND_PART_ID,'') + char(10) + char(10) + ISNULL(A.FULL_NAME,'') as Group2,"
                            //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group3,"
                            //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group4,"
                            //        //+ "ISNULL(G.BRAND_CODE,'') + char(10) + char(10) + CONVERT(datetime,ISNULL(B.SETUP_PRICE_DATE,''),103) + char(10) + char(10) + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                            //        + " A.*, B.BRAND_CODE as Group1, B.BRAND_ID, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE "
                            //        + " From M_VENDORS I  INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID And G.LIST_NO = 1 RIGHT OUTER JOIN"
                            //        + " M_ITEMS A LEFT OUTER JOIN"
                            //        + " M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                            //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                            //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                            //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                            //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                            //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                       
                            //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                            //sqltext = "Select A.*, B.BRAND_ID, B.BRAND_CODE, C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE From M_ITEMS A"
                            //        + " LEFT JOIN M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                            //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                            //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                            //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size

                            //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                            //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                        
                            //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ


                            ////////sqltext = "";
                            ////////if (SortType > 0)
                            ////////{
                            ////////switch (SortType)
                            ////////{
                            ////////    case 1:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY CATEGORY_CODE,ABBREVIATE_NAME,MODEL1) as RNnew  FROM Vw_ItemSearch";
                            ////////    break;
                            ////////    case 2:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY CATEGORY_CODE,FULL_NAME,MODEL1) as RNnew  FROM Vw_ItemSearch";
                            ////////    break;
                            ////////    case 3:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY ITEM_CODE) as RNnew  FROM Vw_ItemSearch";
                            ////////    break;
                            ////////    case 4:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY GENUIN_PART_ID) as RNnew  FROM Vw_ItemSearch";
                            ////////    break;
                            ////////    case 5:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY BRAND_PART_ID) as RNnew  FROM Vw_ItemSearch";
                            ////////    break;
                            ////////    case 6:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_OUTSIDE) as RNnew  FROM Vw_ItemSearch";
                            ////////    break;
                            ////////    case 7:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_THICK) as RNnew  FROM Vw_ItemSearch";
                            ////////    break;
                            ////////    case 8:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_INNER) as RNnew  FROM Vw_ItemSearch";
                            ////////    break;
                            ////////}
                            ////////}

                            //////////sqltext = "SELECT * FROM Vw_AllItemsRN";
                            ////////sqltext += " Where len(ITEM_CODE) > 0 ";
                            ////////if (ProductSearch.Length > 0)
                            ////////{
                            ////////    switch (SortType)
                            ////////    {
                            ////////        case 1:
                            ////////        sqltext += string.Format(" and ABBREVIATE_NAME Like '{0}%'", ProductSearch);
                            ////////        if (CategorySearch.Length > 0)
                            ////////            sqltext += string.Format(" and CATEGORY_CODE = '{0}'", CategorySearch);
                            ////////        break;
                            ////////        case 2:
                            ////////        sqltext += string.Format(" and FULL_NAME Like '{0}%'", ProductSearch);
                            ////////        if (CategorySearch.Length > 0)
                            ////////            sqltext += string.Format(" and CATEGORY_CODE = '{0}'", CategorySearch);
                            ////////        break;
                            ////////        case 3:
                            ////////        sqltext += string.Format(" and ITEM_CODE Like '{0}%'", ProductSearch);
                            ////////        break;
                            ////////        case 4:
                            ////////        sqltext += string.Format(" and GENUIN_PART_ID Like '{0}%'", ProductSearch);
                            ////////        break;
                            ////////        case 5:
                            ////////        sqltext += string.Format(" and BRAND_PART_ID Like '{0}%'", ProductSearch);
                            ////////        break;
                            ////////        //case 6:
                            ////////        //  sqltext += string.Format(" and SIZE_OUTSIDE Like '{0}%'", ProductSearch);
                            ////////        //  break;
                            ////////        //case 7:
                            ////////        //  sqltext += string.Format(" and SIZE_THICK Like '{0}%'", ProductSearch);
                            ////////        //  break;
                            ////////        //case 8:
                            ////////        //  sqltext += string.Format(" and SIZE_INNER Like '{0}%'", ProductSearch);
                            ////////        //  break;
                            ////////        case 6:
                            ////////        sqltext += string.Format(" and SIZE_CODE Like '{0}%'", ProductSearch);
                            ////////        break;
                            ////////        case 7:
                            ////////        sqltext += string.Format(" and SIZE_CODE Like '{0}%'", ProductSearch);
                            ////////        break;
                            ////////        case 8:
                            ////////        sqltext += string.Format(" and SIZE_CODE Like '{0}%'", ProductSearch);
                            ////////        break;
                            ////////    }
                            ////////}

                            ////////if (SortType > 0)
                            ////////{
                            ////////    switch (SortType)
                            ////////    {
                            ////////        case 1:
                            ////////        sqltext += " order by CATEGORY_CODE,ABBREVIATE_NAME,MODEL1";
                            ////////        break;
                            ////////        case 2:
                            ////////        sqltext += " order by CATEGORY_CODE,FULL_NAME,MODEL1";
                            ////////        break;
                            ////////        case 3:
                            ////////        sqltext += " order by ITEM_CODE";
                            ////////        break;
                            ////////        case 4:
                            ////////        sqltext += " order by GENUIN_PART_ID";
                            ////////        break;
                            ////////        case 5:
                            ////////        sqltext += " order by BRAND_PART_ID";
                            ////////        break;
                            ////////        case 6:
                            ////////        sqltext += " order by SIZE_CODE,SIZE_OUTSIDE";
                            ////////        break;
                            ////////        case 7:
                            ////////        sqltext += " order by SIZE_CODE,SIZE_THICK";
                            ////////        break;
                            ////////        case 8:
                            ////////        sqltext += " order by SIZE_CODE,SIZE_INNER";
                            ////////        break;
                            ////////    }
                            ////////}

                            ////////_dataAdapter.SelectCommand = new SqlCommand(sqltext, conn);
                            ////////_dataAdapter.SelectCommand.Parameters.Clear();
                            ////////_dataAdapter.SelectCommand.CommandTimeout = 300;
                            sqltext = "SP_M_itemsearch_Order";
                            command.Connection = conn;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "SP_M_itemsearch_Order";

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@pType", SortType);
                            command.Parameters.AddWithValue("@ItemSearch", ProductSearch);
                            command.Parameters.AddWithValue("@CategorySearch", CategorySearch);
                            //command.Parameters.Add(new SqlParameter("@pType", SqlDbType.Int,SortType));
                            //command.Parameters.Add(new SqlParameter("@CategorySearch", SqlDbType.Char,3, CategorySearch));


                            dtShow = new DataTable();
                            _dataAdapter = new SqlDataAdapter(command);
                            _dataAdapter.Fill(dtShow);
                            RowNumberID = 0;
                            //dtShow = dt.Copy();
                            if (dtShow.Rows.Count > 0)
                            {

                            if (ItemID > 0)
                            {
                                dtShow_Tmp = dtShow.Copy();
                                DataRow[] dr = dtShow.Select("ITEM_ID =" + ItemID + "");
                                if (dr.Length > 0)
                                {
                                RowNumberID = cls_Library.DBInt(dr[0]["RNnew"]);
                                MinRowNumberID = RowNumberID - 50;
                                MaxRowNumberID = RowNumberID + 50;
                                }
                                dr = dtShow.Select("RNnew >=" + MinRowNumberID + " and RNnew <=" + MaxRowNumberID + "");
                                if (dr.Length > 0) dtShow = dr.CopyToDataTable();
                                //gridItem.DataSource = dtShow;
                                //gridItem.RefreshDataSource();

                            }
                            spinListNo.Text = dt.Rows.Count.ToString("#,##0");
                            spinListNo.Properties.EditMask = @"#,####,###";
                            spinListNo.Properties.DisplayFormat.FormatString = @"#,####,###";
                    }
                    //for (int i = 0; i < dtShow.Rows.Count; i++)
                    //{
                    //    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                    //}
                    //Setgrid();
                    //}
                    //else
                    //{
                    //    dt = null;
                    //    dtShow = null;
                    //    ClearControl();
                    //}
                    RowNumberID = -1;
                    for (int i = 0; i < dtShow.Rows.Count; i++)
                    {
                    RowNumberID++;
                    if (ItemID == cls_Library.DBInt(dtShow.Rows[i]["ITEM_ID"]))
                    {
                        break;
                    }
                    }
                    if (RowNumberID < 0) RowNumberID = 0;

                    //Grid                            
                    gridItem.DataSource = dtShow;
                    gridItem.RefreshDataSource();
                    cvItem.RefreshData();

                    cvItem.FocusedRowHandle = RowNumberID;
                    if (dtShow.Rows.Count > 0) eLabelRecord.Text = "Record : " + (RowNumberID + 1).ToString("#,##0") + "/" + dtShow.Rows.Count.ToString("#,##0");
                    FocusRowchangeOK = false;
                    if (gridItem.Visible)
                    {
                        FocusRowchangeOK = true;
                        SetDataFocus();
                        FocusRowchangeOK = false;
                    }
                    //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                    //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                    if (dtShow.Rows.Count > 0)
                    {
                        uNCoumt++;
                        AssignArraUndo(uNCoumt);
                        AssignValueToArraUndo(uNCoumt);
                    }
                    gridItem.Select();
                    break;
                }
                #endregion
            }
            }
            catch (Exception e)
            {
            MessageBox.Show(e.Message);
            throw;
            }
            finally
            {
            cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void GetDataChooseForStart(cls_Global_class.ChooseType type)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            string sqltext = "";
            try
            {
                searchType = 0;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    #region Select Case 
                    switch (type)
                    {
                    case cls_Global_class.ChooseType.Customer:
                        break;
                    case cls_Global_class.ChooseType.Item:
                        ProductSearch = "";
                        dt = new DataTable("M_ITEMS");

                                //sqltext = "";
                                //sqltext = "SELECT ROW_NUMBER() OVER(ORDER BY CATEGORY_CODE,ABBREVIATE_NAME,MODEL1) as RNnew,* from Vw_ItemSearch";
                                //sqltext += " Where len(ITEM_CODE) > 0 ";
                                //sqltext += string.Format(" and CATEGORY_CODE = '{0}'", "002");
                                //sqltext += " order by CATEGORY_CODE,ABBREVIATE_NAME,MODEL1";

                                //_dataAdapter.SelectCommand = new SqlCommand(sqltext, conn);
                                //_dataAdapter.SelectCommand.Parameters.Clear();
                                //_dataAdapter.Fill(dtShow);

                                sqltext = "SP_M_itemsearch";
                                command.Connection = conn;
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandText = "SP_M_itemsearch";

                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@pType", SortType);
                                command.Parameters.AddWithValue("@CategorySearch", CategorySearch);
                                //command.Parameters.Add(new SqlParameter("@pType", SqlDbType.Int,SortType));
                                //command.Parameters.Add(new SqlParameter("@CategorySearch", SqlDbType.Char,3, CategorySearch));

                                dtShow = new DataTable();
                                _dataAdapter = new SqlDataAdapter(command);
                                _dataAdapter.Fill(dtShow);


                                if (dtShow.Rows.Count > 0)
                                {
                                    //DataRow[] dr = dtShow.Select("RNnew >=" + 1 + " and RNnew <=" + 100 + "");
                                    //if (dr.Length > 0) dtShow = dr.CopyToDataTable();
                                }
                                //dtShow = dt.Copy();
                                //if (dt.Rows.Count > 0) spinListNo.Text = dt.Rows.Count.ToString("#,##0");
                                ////for (int i = 0; i < dtShow.Rows.Count; i++)
                                ////{
                                ////    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                                ////}
                                ////Setgrid();
                                ////}
                                ////else
                                ////{
                                ////    dt = null;
                                ////    dtShow = null;
                                ////    ClearControl();
                                ////}
                                ////Grid                            
                                //gridItem.DataSource = dtShow;
                                //gridItem.RefreshDataSource();
                                //cvItem.RefreshData();
                                //gridItem.Select();
                                //FocusRowchangeOK = false;
                                //if (gridItem.Visible)
                                //{
                                //    FocusRowchangeOK = true;
                                //    DataRow row = cvItem.GetFocusedDataRow();
                                //    SetDataFocus(row);
                                //    FocusRowchangeOK = false;
                                //}
                                //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                                //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                                break;
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void BTsub4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (MainSearch == 1)
                {
                    LinkMenu(cls_Struct.MenuItem.hRO);
                }
            }
        }

        private void GetDataChooseFromSearch1(cls_Global_class.ChooseType type)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            string sqltext;
            try
            {
                searchType = 1;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    switch (type)
                    {
                        case cls_Global_class.ChooseType.Customer:
                            txtBarcode.Text = "";
                            break;
                        case cls_Global_class.ChooseType.Item:
                            sluCustomer.EditValue = "";
                            //string val = txtBarcode.Text;
                            //if (!string.IsNullOrEmpty(val))
                            //{
                            dt = new DataTable("M_ITEMS");
                            //xx = join
                            //sqltext = "SELECT A.ITEM_CODE + CHAR(10) + CHAR(10) + ISNULL(A.ABBREVIATE_NAME, '   ') + CHAR(10) + CHAR(10) + ISNULL(B.BRAND_NAME, '') AS Group1,"
                            //        + "ISNULL(A.GENUIN_PART_ID, '   ') + CHAR(10) + CHAR(10) + ISNULL(A.BRAND_PART_ID,'') + CHAR(10) + CHAR(10) + ISNULL(A.FULL_NAME, '') AS Group2,"
                            //        + "ISNULL(A.MODEL1, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL2, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL3, '') AS Group3,"
                            //        + "ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_DOC) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.DISCOUNT1) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_REAL) AS nvarchar), '') AS Group4,"
                            //        + "ISNULL(I.VENDOR_CODE, '') + CHAR(10) + CHAR(10) + CONVERT(nvarchar,CONVERT(date,ISNULL(B.SETUP_PRICE_DATE,''))) + char(10) + char(10) +  + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,'' as Group6,'' as Group7,"
                            //        + "A.ITEM_ID, A.ITEM_CODE, A.MAKER_BARCODE_NO, A.SET_STATUS, A.COMPONENT_STATUS, A.BRAND_ID,"
                            //        + "A.*, B.BRAND_CODE, B.BRAND_ID AS Expr1, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE, I.VENDOR_NAME,"
                            //        + "0 as RCD_ID, 0 as RCD_PID,'' AS Marktrans, '' AS Quotrans, '' AS POtrans"
                            //        + " FROM M_VENDORS I INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID AND G.LIST_NO = 1 RIGHT OUTER JOIN"
                            //        + " M_ITEMS A LEFT OUTER JOIN"
                            //        + " M_BRANDS AS B ON A.BRAND_ID = B.BRAND_ID LEFT OUTER JOIN"
                            //        + " M_CATEGORIES AS C ON C.CATEGORY_ID = A.CATEGORY_ID LEFT OUTER JOIN"
                            //        + " M_TYPES AS D ON D.TYPE_ID = A.TYPE_ID LEFT OUTER JOIN"
                            //        + " M_SIZES AS E ON E.SIZE_ID = A.SIZE_ID LEFT OUTER JOIN"
                            //        + " D_ITEM_PO_GROUPS AS F ON F.ITEM_ID = A.ITEM_ID AND F.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " M_PO_GROUPS AS H ON H.PO_GROUP_ID = F.PO_GROUP_ID ON G.ITEM_ID = A.ITEM_ID AND G.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " D_ITEM_LOCATIONS AS J ON J.ITEM_ID = A.ITEM_ID AND J.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " D_ITEM_ALTERNATE_PARTS AS K ON K.ITEM_ID = A.ITEM_ID AND K.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " D_ITEM_PICTURES AS Z ON Z.ITEM_ID = A.ITEM_ID AND Z.LIST_NO = 1";


                            //sqltext = "Select A.ITEM_CODE + char(10) + char(10) + ISNULL(A.ABBREVIATE_NAME,'') + char(10) + char(10) + ISNULL(B.BRAND_CODE,'') as Group1,"
                            //        + "ISNULL(A.GENUIN_PART_ID,'') + char(10) + char(10) + ISNULL(A.BRAND_PART_ID,'') + char(10) + char(10) + ISNULL(A.FULL_NAME,'') as Group2,"
                            //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group3,"
                            //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group4,"
                            //        //+ "ISNULL(G.BRAND_CODE,'') + char(10) + char(10) + CONVERT(datetime,ISNULL(B.SETUP_PRICE_DATE,''),103) + char(10) + char(10) + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                            //        + " A.*, B.BRAND_CODE as Group1, B.BRAND_ID, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE "
                            //        + " From M_VENDORS I  INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID And G.LIST_NO = 1 RIGHT OUTER JOIN"
                            //        + " M_ITEMS A LEFT OUTER JOIN"
                            //        + " M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                            //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                            //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                            //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                            //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                            //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                       
                            //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                            //sqltext = "Select A.*, B.BRAND_ID, B.BRAND_CODE, C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE From M_ITEMS A"
                            //        + " LEFT JOIN M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                            //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                            //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                            //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                            //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                            //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                        
                            //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ

                            // PIAK Edit By 09/01/2022
                            ////////sqltext = "";
                            ////////switch (SortOrderNum + 1)
                            ////////{
                            ////////case 1:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(order by CATEGORY_CODE,ABBREVIATE_NAME,MODEL1) as RNnew  FROM Vw_ItemSearch1";
                            ////////    break;
                            ////////case 2:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(order by GENUIN_PART_ID) as RNnew  FROM Vw_ItemSearch1";
                            ////////    break;
                            ////////case 3:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(order by BRAND_PART_ID) as RNnew  FROM Vw_ItemSearch1";
                            ////////    break;
                            ////////case 4:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(order by SIZE_OUTSIDE) as RNnew  FROM Vw_ItemSearch1";
                            ////////    break;
                            ////////case 5:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(order by SIZE_INNER) as RNnew  FROM Vw_ItemSearch1";
                            ////////    break;
                            ////////case 6:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(order by SIZE_THICK) as RNnew  FROM Vw_ItemSearch1";
                            ////////    break;
                            ////////case 7:
                            ////////    sqltext = "SELECT *, ROW_NUMBER() OVER(order by LOCATION_NAME) as RNnew  FROM Vw_ItemSearch1";
                            ////////    break;
                            ////////default:
                            ////////    sqltext = "SELECT *FROM Vw_ItemSearch1";
                            ////////    break;

                            ////////}
                            ////////sqltext += " Where len(ITEM_CODE) > 0 ";
                            ////////if (PdtCode.Length > 0)
                            ////////    sqltext += string.Format(" and ITEM_CODE Like '{0}%'", PdtCode);
                            ////////if (CategoriesCode.Length > 0)
                            ////////    sqltext += string.Format(" and CATEGORY_CODE Like '{0}%'", CategoriesCode);
                            ////////if (AbbreviateName.Length > 0)
                            ////////    sqltext += string.Format(" and ABBREVIATE_NAME Like '{0}%'", AbbreviateName);
                            ////////if (GenuinPart.Length > 0)
                            ////////    sqltext += string.Format(" and GENUIN_PART_ID Like '{0}%'", GenuinPart);
                            ////////if (ProducerPart.Length > 0)
                            ////////    sqltext += string.Format(" and BRAND_PART_ID Like '{0}%'", ProducerPart);
                            ////////if (FullName.Length > 0)
                            ////////    sqltext += string.Format(" and FULL_NAME Like '{0}%'", FullName);
                            ////////if (BrandCode.Length > 0)
                            ////////    sqltext += string.Format(" and BRAND_CODE Like '{0}%'", BrandCode);
                            ////////if (SizesCode.Length > 0)
                            ////////    sqltext += string.Format(" and SIZE_CODE Like '{0}%'", SizesCode);
                            ////////if (SizeInner.Length > 0)
                            ////////    sqltext += string.Format(" and SIZE_INNER Like '{0}%'", SizeInner);
                            ////////if (SizeOutside.Length > 0)
                            ////////    sqltext += string.Format(" and SIZE_OUTSIDE Like '{0}%'", SizeOutside);
                            ////////if (SizeThick.Length > 0)
                            ////////    sqltext += string.Format(" and SIZE_THICK Like '{0}%'", SizeThick);
                            ////////if (Model1.Length > 0)
                            ////////    sqltext += string.Format(" and MODEL1 Like '{0}%'", Model1);
                            ////////if (Model2.Length > 0)
                            ////////    sqltext += string.Format(" and MODEL2 Like '{0}%'", Model2);
                            ////////if (Model3.Length > 0)
                            ////////    sqltext += string.Format(" and MODEL3 Like '{0}%'", Model3);
                            ////////if (LocationName.Length > 0)
                            ////////    sqltext += string.Format(" and LOCATION_NAME Like '{0}%'", LocationName);
                            ////////if (Alternate.Length > 0)
                            ////////    sqltext += string.Format(" and PART_ID Like '{0}%'", Alternate);
                            ////////if (TypesCode.Length > 0)
                            ////////    sqltext += string.Format(" and TYPE_CODE Like '{0}%'", TypesCode);

                            ////////switch (SortOrderNum + 1)
                            ////////{
                            ////////    case 1:
                            ////////        sqltext += " order by CATEGORY_CODE,ABBREVIATE_NAME,MODEL1";
                            ////////        break;
                            ////////    case 2:
                            ////////        sqltext += " order by GENUIN_PART_ID";
                            ////////        break;
                            ////////    case 3:
                            ////////        sqltext += " order by BRAND_PART_ID";
                            ////////        break;
                            ////////    case 4:
                            ////////        sqltext += " order by SIZE_OUTSIDE";
                            ////////        break;
                            ////////    case 5:
                            ////////        sqltext += " order by SIZE_INNER";
                            ////////        break;
                            ////////    case 6:
                            ////////        sqltext += " order by SIZE_THICK";
                            ////////        break;
                            ////////    case 7:
                            ////////        sqltext += " order by LOCATION_NAME";
                            ////////        break;
                            ////////    //case 8:
                            ////////    //    sqltext += " order by SIZE_INNER";
                            ////////        //break;
                            ////////}

                            ////////_dataAdapter.SelectCommand = new SqlCommand(sqltext, conn);
                            ////////_dataAdapter.SelectCommand.Parameters.Clear();

                            sqltext = "SP_M_ItemSearch_Search1";
                            command.Connection = conn;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "SP_M_ItemSearch_Search1";

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@SORT_ORDER", SortOrderNum + 1);
                            command.Parameters.AddWithValue("@pType", SortOrderNum + 1);                           
                            command.Parameters.AddWithValue("@CATEGORY_CODE", CategoriesCode);
                            command.Parameters.AddWithValue("@ITEM_CODE", PdtCode);
                            command.Parameters.AddWithValue("@ABBREVIATE_NAME", AbbreviateName);
                            command.Parameters.AddWithValue("@GENUIN_PART_ID", GenuinPart);
                            command.Parameters.AddWithValue("@BRAND_PART_ID", ProducerPart);
                            command.Parameters.AddWithValue("@FULL_NAME", FullName);
                            command.Parameters.AddWithValue("@BRAND_CODE", BrandCode);
                            command.Parameters.AddWithValue("@SIZE_CODE", SizesCode);
                            command.Parameters.AddWithValue("@SIZE_INNER", SizeInner);
                            command.Parameters.AddWithValue("@SIZE_OUTSIDE", SizeOutside);
                            command.Parameters.AddWithValue("@SIZE_THICK", SizeThick);
                            command.Parameters.AddWithValue("@MODEL1", Model1);
                            command.Parameters.AddWithValue("@MODEL2", Model2);
                            command.Parameters.AddWithValue("@MODEL3", Model3);
                            command.Parameters.AddWithValue("@LOCATION_NAME", LocationName);
                            command.Parameters.AddWithValue("@PART_ID", Alternate);
                            command.Parameters.AddWithValue("@TYPE_CODE", TypesCode);

                            dtShow = new DataTable();
                            _dataAdapter = new SqlDataAdapter(command);
                            _dataAdapter.Fill(dtShow);
                            //dtShow = dt.Copy();
                                //for (int i = 0; i < dtShow.Rows.Count; i++)
                                //{
                                //    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                                //}
                                //Setgrid();
                            //}
                            //else
                            //{
                            //    dt = null;
                            //    dtShow = null;
                            //    ClearControl();
                            //}
                            //Grid                            
                            gridItem.DataSource = dtShow;
                            gridItem.RefreshDataSource();
                            if (dtShow.Rows.Count > 0)
                            {
                                spinListNo.Text = dtShow.Rows.Count.ToString("#,##0");
                                spinListNo.Properties.EditMask = @"#,####,###";
                                spinListNo.Properties.DisplayFormat.FormatString = @"#,####,###";
                            }
                            cvItem.RefreshData();
                            gridItem.Select();
                            FocusRowchangeOK = false;
                            if (gridItem.Visible)
                            {
                                FocusRowchangeOK = true;
                                SetDataFocus();
                                FocusRowchangeOK = false;
                            }
                            //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                            //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                            if (dt.Rows.Count > 0)
                            {
                            uNCoumt++;
                            AssignArraUndo(uNCoumt);
                            AssignValueToArraUndo(uNCoumt);
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void GetDataChooseFromSearch2(cls_Global_class.ChooseType type)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            string sqltext;
            try
            {
                searchType = 2;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    switch (type)
                    {
                        case cls_Global_class.ChooseType.Customer:
                            txtBarcode.Text = "";
                            break;
                        case cls_Global_class.ChooseType.Item:
                            sluCustomer.EditValue = "";
                            //string val = txtBarcode.Text;
                            //if (!string.IsNullOrEmpty(val))
                            //{
                            dt = new DataTable("M_ITEMS");

                            //xx = join
                            //sqltext = "SELECT A.ITEM_CODE + CHAR(10) + CHAR(10) + ISNULL(A.ABBREVIATE_NAME, '   ') + CHAR(10) + CHAR(10) + ISNULL(B.BRAND_NAME, '') AS Group1,"
                            //        + "ISNULL(A.GENUIN_PART_ID, '   ') + CHAR(10) + CHAR(10) + ISNULL(A.BRAND_PART_ID,'') + CHAR(10) + CHAR(10) + ISNULL(A.FULL_NAME, '') AS Group2,"
                            //        + "ISNULL(A.MODEL1, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL2, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL3, '') AS Group3,"
                            //        + "ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_DOC) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.DISCOUNT1) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_REAL) AS nvarchar), '') AS Group4,"
                            //        + "ISNULL(I.VENDOR_CODE, '') + CHAR(10) + CHAR(10) + CONVERT(nvarchar,CONVERT(date,ISNULL(B.SETUP_PRICE_DATE,''))) + char(10) + char(10) +  + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,'' as Group6,'' as Group7,"
                            //        + "A.ITEM_ID, A.ITEM_CODE, A.MAKER_BARCODE_NO, A.SET_STATUS, A.COMPONENT_STATUS, A.BRAND_ID,"
                            //        + "A.*, B.BRAND_CODE, B.BRAND_ID AS Expr1, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE, I.VENDOR_NAME,"
                            //        + "R.RCD_ID, R.RCD_PID,'' AS Marktrans, '' AS Quotrans, '' AS POtrans"
                            //        + " FROM M_VENDORS I INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID AND G.LIST_NO = 1 RIGHT OUTER JOIN"
                            //        + " M_ITEMS AS A INNER JOIN"
                            //        + " RCDETAIL R ON A.ITEM_ID = R.ITEM_ID INNER JOIN"
                            //        + " RCHEADER  S ON R.RCD_PID = S.RCH_ID LEFT OUTER JOIN"
                            //        + " M_BRANDS AS B ON A.BRAND_ID = B.BRAND_ID LEFT OUTER JOIN"
                            //        + " M_CATEGORIES AS C ON C.CATEGORY_ID = A.CATEGORY_ID LEFT OUTER JOIN"
                            //        + " M_TYPES AS D ON D.TYPE_ID = A.TYPE_ID LEFT OUTER JOIN"
                            //        + " M_SIZES AS E ON E.SIZE_ID = A.SIZE_ID LEFT OUTER JOIN"
                            //        + " D_ITEM_PO_GROUPS AS F ON F.ITEM_ID = A.ITEM_ID AND F.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " M_PO_GROUPS AS H ON H.PO_GROUP_ID = F.PO_GROUP_ID ON G.ITEM_ID = A.ITEM_ID AND G.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " D_ITEM_LOCATIONS AS J ON J.ITEM_ID = A.ITEM_ID AND J.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " D_ITEM_ALTERNATE_PARTS AS K ON K.ITEM_ID = A.ITEM_ID AND K.LIST_NO = 1 LEFT OUTER JOIN"
                            //        + " D_ITEM_PICTURES AS Z ON Z.ITEM_ID = A.ITEM_ID AND Z.LIST_NO = 1";


                            //sqltext = "Select A.ITEM_CODE + char(10) + char(10) + ISNULL(A.ABBREVIATE_NAME,'') + char(10) + char(10) + ISNULL(B.BRAND_CODE,'') as Group1,"
                            //        + "ISNULL(A.GENUIN_PART_ID,'') + char(10) + char(10) + ISNULL(A.BRAND_PART_ID,'') + char(10) + char(10) + ISNULL(A.FULL_NAME,'') as Group2,"
                            //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group3,"
                            //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group4,"
                            //        //+ "ISNULL(G.BRAND_CODE,'') + char(10) + char(10) + CONVERT(datetime,ISNULL(B.SETUP_PRICE_DATE,''),103) + char(10) + char(10) + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                            //        + " A.*, B.BRAND_CODE as Group1, B.BRAND_ID, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE "
                            //        + " From M_VENDORS I  INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID And G.LIST_NO = 1 RIGHT OUTER JOIN"
                            //        + " M_ITEMS A LEFT OUTER JOIN"
                            //        + " M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                            //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                            //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                            //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                            //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                            //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                       
                            //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                            //sqltext = "Select A.*, B.BRAND_ID, B.BRAND_CODE, C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE From M_ITEMS A"
                            //        + " LEFT JOIN M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                            //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                            //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                            //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                            //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                            //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                        
                            //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ

                            //sqltext = "SELECT *,ROW_NUMBER() over(ORDER BY item_code) as RNnew FROM Vw_AllItemsRCSumQTY";
                            //        sqltext = "SELECT *,ROW_NUMBER() over(ORDER BY item_code) as RNnew FROM Vw_AllItemRemark";
                            //        sqltext += " Where len(ITEM_CODE) > 0 and (QTY_MARK > 0) ";
                            //if (VendorsCode.Length > 0)
                            //sqltext += string.Format(" and CUS_ID ={0}", Vendorsid);

                            //switch (SortOrderNum + 1)
                            //{
                            //    case 1:
                            //        sqltext += " order by C.CATEGORY_CODE,A.ABBREVIATE_NAME,A.MODEL1,A.MODEL2,A.MODEL3";
                            //        break;
                            //    case 2:
                            //        sqltext += " order by A.GENUIN_PART_ID";
                            //        break;
                            //    case 3:
                            //        sqltext += " order by A.BRAND_PART_ID";
                            //        break;
                            //    case 4:
                            //        sqltext += " order by C.CATEGORY_CODE,A.FULL_NAME,A.MODEL1,A.MODEL2,A.MODEL3";
                            //        break;
                            //    case 5:
                            //        sqltext += " order by B.BRAND_CODE";
                            //        break;
                            //    case 6:
                            //        sqltext += " order by E.SIZE_CODEE";
                            //        break;
                            //    case 7:
                            //        sqltext += " order by A.SIZE_INNER";
                            //        break;
                            //    case 8:
                            //        sqltext += " order by A.SIZE_THICK";
                            //        break;
                            //    case 9:
                            //        sqltext += " order by A.SIZE_INNER";
                            //        break;
                            //    case 10:
                            //        sqltext += " order by A.MODEL1";
                            //        break;
                            //    case 11:
                            //        sqltext += " order by A.MODEL2";
                            //        break;
                            //    case 12:
                            //        sqltext += " order by A.MODEL3";
                            //        break;
                            //    case 13:
                            //        sqltext += " order by J.LOCATION_NAME";
                            //        break;
                            //    case 14:
                            //        sqltext += " order by D.TYPE_CODE";
                            //        break;
                            //}
                            sqltext = "SP_M_ItemSearch_Search2";
                            command.Connection = conn;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "SP_M_ItemSearch_Search2";

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@SORT_ORDER", 1);
                            command.Parameters.AddWithValue("@pType", 1);
                            command.Parameters.AddWithValue("@CUS_ID", Vendorsid);
                           
                            dtShow = new DataTable();
                            _dataAdapter = new SqlDataAdapter(command);
                            _dataAdapter.Fill(dtShow);
                            //dtShow = dt.Copy();
                            //for (int i = 0; i < dtShow.Rows.Count; i++)
                            //{
                            //    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                            //}
                            //Setgrid();
                            //}
                            //else
                            //{
                            //    dt = null;
                            //    dtShow = null;
                            //    ClearControl();
                            ////}
                            //Grid                            
                            gridItem.DataSource = dtShow;
                            gridItem.RefreshDataSource();
                            if (dtShow.Rows.Count > 0)
                            {
                                spinListNo.Text = dtShow.Rows.Count.ToString("#,##0");
                                spinListNo.Properties.EditMask = @"#,####,###";
                                spinListNo.Properties.DisplayFormat.FormatString = @"#,####,###";
                            }
                            cvItem.RefreshData();
                            gridItem.Select();
                            FocusRowchangeOK = false;
                            SetDataFocus();
                            //PIAK 2022/02/04
                            //if (gridItem.Visible)
                            //{
                            //    FocusRowchangeOK = true;
                            //    SetDataFocus();
                            //    FocusRowchangeOK = false;
                            //}
                            //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                            //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                            if (dt.Rows.Count > 0)
                            {
                                uNCoumt++;
                                AssignArraUndo(uNCoumt);
                                AssignValueToArraUndo(uNCoumt);
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void GetDataChooseFromSearch3(cls_Global_class.ChooseType type)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable();
            string sqltext;
            try
            {
                searchType = 3;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    switch (type)
                    {
                        case cls_Global_class.ChooseType.Customer:
                            txtBarcode.Text = "";

                            break;
                        case cls_Global_class.ChooseType.Item:
                            sluCustomer.EditValue = "";
                            //string val = txtBarcode.Text;
                            //if (!string.IsNullOrEmpty(val))
                            //{
                            dt = new DataTable("M_ITEMS");

                            //sqltext = "SELECT * FROM Vw_AllItemsRCSumQTY";
                            //sqltext += " Where len(ITEM_CODE) > 0 ";
                            //if (POGroupCode.Length > 0)
                            //    sqltext += string.Format(" and PO_GROUP_CODE Like '{0}%'", POGroupCode);
                            //if (VendorsCode.Length > 0)
                            //    sqltext += string.Format(" and VENDOR_CODE Like '{0}%'", VendorsCode);
                            //if (BrandCode.Length > 0)
                            //    sqltext += string.Format(" and BRAND_CODE Like '{0}%'", BrandCode);
                            //if (TypesCode.Length > 0)
                            //    sqltext += string.Format(" and TYPE_CODE Like '{0}%'", TypesCode);
                            //if (CountType == 0)
                            //{
                            //    sqltext += " and ((sumQTY < MINIMUM_QTY) or UNDER_STOCK =1) order by UNDER_STOCK_DATE desc";               
                            //}

                            sqltext = "SP_M_ItemSearch_Search3";
                            command.Connection = conn;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "SP_M_ItemSearch_Search3";

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@SORT_ORDER", 1);
                            command.Parameters.AddWithValue("@pType", 1);
                            command.Parameters.AddWithValue("@PO_GROUP_CODE", POGroupCode);
                            command.Parameters.AddWithValue("@VENDOR_CODE", VendorsCode);
                            command.Parameters.AddWithValue("@BRAND_CODE", BrandCode);
                            command.Parameters.AddWithValue("@TYPE_CODE", TypesCode);
                            command.Parameters.AddWithValue("@CountType", CountType);

                            dtShow = new DataTable();
                            _dataAdapter = new SqlDataAdapter(command);
                            _dataAdapter.Fill(dtShow);
                            //dtShow = dt.Copy();
                            if (dtShow.Rows.Count > 0)
                            {
                                spinListNo.Text = dtShow.Rows.Count.ToString("#,##0");
                                spinListNo.Properties.EditMask = @"#,####,###";
                                spinListNo.Properties.DisplayFormat.FormatString = @"#,####,###";
                            }
                            //for (int i = 0; i < dtShow.Rows.Count; i++)
                            //{
                            //    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                            //}
                            //Setgrid();
                            //}
                            //else
                            //{
                            //    dt = null;
                            //    dtShow = null;
                            //    ClearControl();
                            //}
                            //Grid                            
                            gridItem.DataSource = dtShow;
                            gridItem.RefreshDataSource();
                            cvItem.RefreshData();
                            gridItem.Select();
                            FocusRowchangeOK = false;
                            if (gridItem.Visible)
                            {
                                FocusRowchangeOK = true;
                                SetDataFocus();
                                FocusRowchangeOK = false;
                            }
                            //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                            //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                            if (dt.Rows.Count > 0)
                            {
                                uNCoumt++;
                                AssignArraUndo(uNCoumt);
                                AssignValueToArraUndo(uNCoumt);
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void GetDataChooseGroupJoin(int Groupid)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                searchType = 0;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    sluCustomer.EditValue = "";
                    //string val = txtBarcode.Text;
                    ProductSearch = txtProduct.Text.Trim();
                    txtProduct.Text = "";
                    //if (!string.IsNullOrEmpty(ProductSearch))
                    //{
                    dt = new DataTable("M_ITEMS");

                    //sqltext = "SELECT A.ITEM_CODE + CHAR(10) + CHAR(10) + ISNULL(A.ABBREVIATE_NAME, '   ') + CHAR(10) + CHAR(10) + ISNULL(B.BRAND_NAME, '') AS Group1,"
                    //    + "ISNULL(A.GENUIN_PART_ID, '   ') + CHAR(10) + CHAR(10) + ISNULL(A.BRAND_PART_ID,'') + CHAR(10) + CHAR(10) + ISNULL(A.FULL_NAME, '') AS Group2,"
                    //    + "ISNULL(A.MODEL1, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL2, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL3, '') AS Group3,"
                    //    + "ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_DOC) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.DISCOUNT1) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_REAL) AS nvarchar), '') AS Group4,"
                    //    + "ISNULL(I.VENDOR_CODE, '') + CHAR(10) + CHAR(10) + CONVERT(nvarchar,CONVERT(date,ISNULL(B.SETUP_PRICE_DATE,''))) + char(10) + char(10) +  + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                    //    + "A.ITEM_ID, A.ITEM_CODE, A.MAKER_BARCODE_NO, A.SET_STATUS, A.COMPONENT_STATUS, A.BRAND_ID,"
                    //    + "A.*, B.BRAND_CODE, B.BRAND_ID AS Expr1, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE, I.VENDOR_NAME, J.PART_ID, R.GROUP_CODE,'' AS Marktrans, '' AS Quotrans, '' AS POtrans"
                    //    + " FROM M_VENDORS I INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID AND G.LIST_NO = 1 RIGHT OUTER JOIN"
                    //    + " M_ITEMS A INNER JOIN"
                    //    + " GROUPJOIN R INNER JOIN GROUPSUBJOIN S ON R.GROUP_ID = S.GROUP_ID ON A.ITEM_ID = S.ITEM_ID LEFT OUTER JOIN"
                    //    + " M_BRANDS AS B ON A.BRAND_ID = B.BRAND_ID LEFT OUTER JOIN"
                    //    + " M_CATEGORIES AS C ON C.CATEGORY_ID = A.CATEGORY_ID LEFT OUTER JOIN"
                    //    + " M_TYPES AS D ON D.TYPE_ID = A.TYPE_ID LEFT OUTER JOIN"
                    //    + " M_SIZES AS E ON E.SIZE_ID = A.SIZE_ID LEFT OUTER JOIN"
                    //    + " D_ITEM_PO_GROUPS AS F ON F.ITEM_ID = A.ITEM_ID AND F.LIST_NO = 1 LEFT OUTER JOIN"
                    //    + " M_PO_GROUPS AS H ON H.PO_GROUP_ID = F.PO_GROUP_ID ON G.ITEM_ID = A.ITEM_ID AND G.LIST_NO = 1 LEFT OUTER JOIN"
                    //    + " D_ITEM_ALTERNATE_PARTS AS J ON J.ITEM_ID = A.ITEM_ID AND J.LIST_NO = 1 LEFT OUTER JOIN"
                    //    + " D_ITEM_PICTURES AS Z ON Z.ITEM_ID = A.ITEM_ID AND Z.LIST_NO = 1";

                    //sqltext = "Select A.ITEM_CODE + char(10) + char(10) + ISNULL(A.ABBREVIATE_NAME,'') + char(10) + char(10) + ISNULL(B.BRAND_CODE,'') as Group1,"
                    //        + "ISNULL(A.GENUIN_PART_ID,'') + char(10) + char(10) + ISNULL(A.BRAND_PART_ID,'') + char(10) + char(10) + ISNULL(A.FULL_NAME,'') as Group2,"
                    //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group3,"
                    //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group4,"
                    //        //+ "ISNULL(G.BRAND_CODE,'') + char(10) + char(10) + CONVERT(datetime,ISNULL(B.SETUP_PRICE_DATE,''),103) + char(10) + char(10) + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                    //        + " A.*, B.BRAND_CODE as Group1, B.BRAND_ID, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE "
                    //        + " From M_VENDORS I  INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID And G.LIST_NO = 1 RIGHT OUTER JOIN"
                    //        + " M_ITEMS A LEFT OUTER JOIN"
                    //        + " M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                    //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                    //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                    //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                    //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                    //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                       
                    //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                    //sqltext = "Select A.*, B.BRAND_ID, B.BRAND_CODE, C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE From M_ITEMS A"
                    //        + " LEFT JOIN M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                    //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                    //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                    //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                    //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                    //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                        
                    //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                    //sqltext += " Where len(A.ITEM_CODE) > 0 ";
                    //sqltext += string.Format(" and R.GROUP_ID ={0}", Groupid);

                    //if (SortType > 0)
                    //{
                    //    switch (SortType)
                    //    {
                    //        case 1:
                    //        sqltext += " order by C.CATEGORY_CODE,A.ABBREVIATE_NAME,A.MODEL1";
                    //        break;
                    //        case 2:
                    //        sqltext += " order by C.CATEGORY_CODE,A.FULL_NAME,A.MODEL1";
                    //        break;
                    //        case 3:
                    //        sqltext += " order by A.ITEM_CODE";
                    //        break;
                    //        case 4:
                    //        sqltext += " order by A.GENUIN_PART_ID";
                    //        break;
                    //        case 5:
                    //        sqltext += " order by A.BRAND_PART_ID";
                    //        break;
                    //        case 6:
                    //        sqltext += " order by A.SIZE_OUTSIDE";
                    //        break;
                    //        case 7:
                    //        sqltext += " order by A.SIZE_THICK";
                    //        break;
                    //        case 8:
                    //        sqltext += " order by A.SIZE_INNER";
                    //        break;
                    //    }
                    //}

                    //_dataAdapter.SelectCommand = new SqlCommand(sqltext, conn);
                    //_dataAdapter.SelectCommand.Parameters.Clear();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_M_ItemSearchGroupJoin";

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@pType", SortType);
                    command.Parameters.AddWithValue("@GroupID", Groupid);

                    dtShow = new DataTable();
                    _dataAdapter = new SqlDataAdapter(command);
                    _dataAdapter.Fill(dtShow);

                    //_dataAdapter.Fill(dt);
                    //dtShow = dt.Copy();
                    if (dtShow.Rows.Count > 0) spinListNo.Text = dtShow.Rows.Count.ToString("#,##0");
                    //for (int i = 0; i < dtShow.Rows.Count; i++)
                    //{
                    //    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                    //}
                    //Setgrid();
                    //}
                    //else
                    //{
                    //    dt = null;
                    //    dtShow = null;
                    //    ClearControl();
                    //}
                    //Grid                            
                    gridItem.DataSource = dtShow;
                    gridItem.RefreshDataSource();
                    cvItem.RefreshData();
                    gridItem.Select();
                    FocusRowchangeOK = false;
                    if (gridItem.Visible)
                    {
                        FocusRowchangeOK = true;
                        SetDataFocus();
                        FocusRowchangeOK = false;
                    }
                    //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                    //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                }
            }
            catch (Exception e)
            {
            MessageBox.Show(e.Message);
            throw;
            }
            finally
            {
            cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void GetDataChooseGroupReplace(int Groupid)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                searchType = 0;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    sluCustomer.EditValue = "";
                    //string val = txtBarcode.Text;
                    ProductSearch = txtProduct.Text.Trim();
                    txtProduct.Text = "";
                    //if (!string.IsNullOrEmpty(ProductSearch))
                    //{
                    dt = new DataTable("M_ITEMS");

                    //sqltext = "SELECT A.ITEM_CODE + CHAR(10) + CHAR(10) + ISNULL(A.ABBREVIATE_NAME, '   ') + CHAR(10) + CHAR(10) + ISNULL(B.BRAND_NAME, '') AS Group1,"
                    //        + "ISNULL(A.GENUIN_PART_ID, '   ') + CHAR(10) + CHAR(10) + ISNULL(A.BRAND_PART_ID,'') + CHAR(10) + CHAR(10) + ISNULL(A.FULL_NAME, '') AS Group2,"
                    //        + "ISNULL(A.MODEL1, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL2, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL3, '') AS Group3,"
                    //        + "ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_DOC) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.DISCOUNT1) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_REAL) AS nvarchar), '') AS Group4,"
                    //        + "ISNULL(I.VENDOR_CODE, '') + CHAR(10) + CHAR(10) + CONVERT(nvarchar,CONVERT(date,ISNULL(B.SETUP_PRICE_DATE,''))) + char(10) + char(10) +  + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                    //        + "A.ITEM_ID, A.ITEM_CODE, A.MAKER_BARCODE_NO, A.SET_STATUS, A.COMPONENT_STATUS, A.BRAND_ID,"
                    //        + "A.*, B.BRAND_CODE, B.BRAND_ID AS Expr1, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE, I.VENDOR_NAME, J.PART_ID, R.GROUP_CODE,'' AS Marktrans, '' AS Quotrans, '' AS POtrans"
                    //        + " FROM M_VENDORS I INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID AND G.LIST_NO = 1 RIGHT OUTER JOIN"
                    //        + " M_ITEMS A INNER JOIN"
                    //        + " GROUPREPLACE R INNER JOIN GROUPSUBREPLACE S ON R.GROUP_ID = S.GROUP_ID ON A.ITEM_ID = S.ITEM_ID LEFT OUTER JOIN"
                    //        + " M_BRANDS AS B ON A.BRAND_ID = B.BRAND_ID LEFT OUTER JOIN"
                    //        + " M_CATEGORIES AS C ON C.CATEGORY_ID = A.CATEGORY_ID LEFT OUTER JOIN"
                    //        + " M_TYPES AS D ON D.TYPE_ID = A.TYPE_ID LEFT OUTER JOIN"
                    //        + " M_SIZES AS E ON E.SIZE_ID = A.SIZE_ID LEFT OUTER JOIN"
                    //        + " D_ITEM_PO_GROUPS AS F ON F.ITEM_ID = A.ITEM_ID AND F.LIST_NO = 1 LEFT OUTER JOIN"
                    //        + " M_PO_GROUPS AS H ON H.PO_GROUP_ID = F.PO_GROUP_ID ON G.ITEM_ID = A.ITEM_ID AND G.LIST_NO = 1 LEFT OUTER JOIN"
                    //        + " D_ITEM_ALTERNATE_PARTS AS J ON J.ITEM_ID = A.ITEM_ID AND J.LIST_NO = 1 LEFT OUTER JOIN"
                    //        + " D_ITEM_PICTURES AS Z ON Z.ITEM_ID = A.ITEM_ID AND Z.LIST_NO = 1";

                    //sqltext = "Select A.ITEM_CODE + char(10) + char(10) + ISNULL(A.ABBREVIATE_NAME,'') + char(10) + char(10) + ISNULL(B.BRAND_CODE,'') as Group1,"
                    //        + "ISNULL(A.GENUIN_PART_ID,'') + char(10) + char(10) + ISNULL(A.BRAND_PART_ID,'') + char(10) + char(10) + ISNULL(A.FULL_NAME,'') as Group2,"
                    //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group3,"
                    //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group4,"
                    //        //+ "ISNULL(G.BRAND_CODE,'') + char(10) + char(10) + CONVERT(datetime,ISNULL(B.SETUP_PRICE_DATE,''),103) + char(10) + char(10) + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                    //        + " A.*, B.BRAND_CODE as Group1, B.BRAND_ID, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE "
                    //        + " From M_VENDORS I  INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID And G.LIST_NO = 1 RIGHT OUTER JOIN"
                    //        + " M_ITEMS A LEFT OUTER JOIN"
                    //        + " M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                    //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                    //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                    //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                    //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                    //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                       
                    //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                    //sqltext = "Select A.*, B.BRAND_ID, B.BRAND_CODE, C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE From M_ITEMS A"
                    //        + " LEFT JOIN M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                    //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                    //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                    //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                    //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                    //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                        
                    //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                    //sqltext += " Where len(A.ITEM_CODE) > 0 ";
                    //sqltext += string.Format(" and R.GROUP_ID ={0}", Groupid);

                    //if (SortType > 0)
                    //{
                    //    switch (SortType)
                    //    {
                    //        case 1:
                    //        sqltext += " order by C.CATEGORY_CODE,A.ABBREVIATE_NAME,A.MODEL1";
                    //        break;
                    //        case 2:
                    //        sqltext += " order by C.CATEGORY_CODE,A.FULL_NAME,A.MODEL1";
                    //        break;
                    //        case 3:
                    //        sqltext += " order by A.ITEM_CODE";
                    //        break;
                    //        case 4:
                    //        sqltext += " order by A.GENUIN_PART_ID";
                    //        break;
                    //        case 5:
                    //        sqltext += " order by A.BRAND_PART_ID";
                    //        break;
                    //        case 6:
                    //        sqltext += " order by A.SIZE_OUTSIDE";
                    //        break;
                    //        case 7:
                    //        sqltext += " order by A.SIZE_THICK";
                    //        break;
                    //        case 8:
                    //        sqltext += " order by A.SIZE_INNER";
                    //        break;
                    //    }
                    //}

                    //_dataAdapter.SelectCommand = new SqlCommand(sqltext, conn);
                    //_dataAdapter.SelectCommand.Parameters.Clear();

                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_M_ItemSearchGroupReplace";

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@pType", SortType);
                    command.Parameters.AddWithValue("@GroupID", Groupid);

                    dtShow = new DataTable();
                    _dataAdapter = new SqlDataAdapter(command);
                    _dataAdapter.Fill(dtShow);

                    //_dataAdapter.Fill(dt);
                    //dtShow = dt.Copy();
                    if (dtShow.Rows.Count > 0) spinListNo.Text = dtShow.Rows.Count.ToString("#,##0");
                    //for (int i = 0; i < dtShow.Rows.Count; i++)
                    //{
                    //    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                    //}
                    //Setgrid();
                    //}
                    //else
                    //{
                    //    dt = null;
                    //    dtShow = null;
                    //    ClearControl();
                    //}
                    //Grid                            
                    gridItem.DataSource = dtShow;
                    gridItem.RefreshDataSource();
                    cvItem.RefreshData();
                    gridItem.Select();
                    FocusRowchangeOK = false;
                    if (gridItem.Visible)
                    {
                        FocusRowchangeOK = true;
                        SetDataFocus();
                        FocusRowchangeOK = false;
                    }
                    //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                    //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                }
            }
            catch (Exception e)
            {
            MessageBox.Show(e.Message);
            throw;
            }
            finally
            {
            cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void GetDataChooseGroupVersatile(int Groupid)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                searchType = 0;
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    sluCustomer.EditValue = "";
                    //string val = txtBarcode.Text;
                    ProductSearch = txtProduct.Text.Trim();
                    txtProduct.Text = "";
                    //if (!string.IsNullOrEmpty(ProductSearch))
                    //{
                    dt = new DataTable("M_ITEMS");
                        //xx = join
                        //sqltext = "SELECT A.ITEM_CODE + CHAR(10) + CHAR(10) + ISNULL(A.ABBREVIATE_NAME, '   ') + CHAR(10) + CHAR(10) + ISNULL(B.BRAND_NAME, '') AS Group1,"
                        //        + "ISNULL(A.GENUIN_PART_ID, '   ') + CHAR(10) + CHAR(10) + ISNULL(A.BRAND_PART_ID,'') + CHAR(10) + CHAR(10) + ISNULL(A.FULL_NAME, '') AS Group2,"
                        //        + "ISNULL(A.MODEL1, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL2, '') + CHAR(10) + CHAR(10) + ISNULL(A.MODEL3, '') AS Group3,"
                        //        + "ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_DOC) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.DISCOUNT1) AS nvarchar), '') + CHAR(10) + CHAR(10) + ISNULL(CAST(CONVERT(decimal(18, 2), R.PRICE_REAL) AS nvarchar), '') AS Group4,"
                        //        + "ISNULL(I.VENDOR_CODE, '') + CHAR(10) + CHAR(10) + CONVERT(nvarchar,CONVERT(date,ISNULL(B.SETUP_PRICE_DATE,''))) + char(10) + char(10) +  + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                        //        + "A.ITEM_ID, A.ITEM_CODE, A.MAKER_BARCODE_NO, A.SET_STATUS, A.COMPONENT_STATUS, A.BRAND_ID,"
                        //        + "A.*, B.BRAND_CODE, B.BRAND_ID AS Expr1, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE, I.VENDOR_NAME, J.PART_ID, R.SUB_CODE,'' AS Marktrans, '' AS Quotrans, '' AS POtrans"
                        //        + " FROM M_VENDORS I INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID AND G.LIST_NO = 1 RIGHT OUTER JOIN"
                        //        + " M_ITEMS A INNER JOIN"
                        //        + " M_VERSATILES_SUB R INNER JOIN M_VERSATILES_ITEM S ON R.SUB_ID = S.VERSATILE_SUB_ID ON A.ITEM_ID = S.ITEM_ID LEFT OUTER JOIN"
                        //        + " M_BRANDS AS B ON A.BRAND_ID = B.BRAND_ID LEFT OUTER JOIN"
                        //        + " M_CATEGORIES AS C ON C.CATEGORY_ID = A.CATEGORY_ID LEFT OUTER JOIN"
                        //        + " M_TYPES AS D ON D.TYPE_ID = A.TYPE_ID LEFT OUTER JOIN"
                        //        + " M_SIZES AS E ON E.SIZE_ID = A.SIZE_ID LEFT OUTER JOIN"
                        //        + " D_ITEM_PO_GROUPS AS F ON F.ITEM_ID = A.ITEM_ID AND F.LIST_NO = 1 LEFT OUTER JOIN"
                        //        + " M_PO_GROUPS AS H ON H.PO_GROUP_ID = F.PO_GROUP_ID ON G.ITEM_ID = A.ITEM_ID AND G.LIST_NO = 1 LEFT OUTER JOIN"
                        //        + " D_ITEM_ALTERNATE_PARTS AS J ON J.ITEM_ID = A.ITEM_ID AND J.LIST_NO = 1 LEFT OUTER JOIN"
                        //        + " D_ITEM_PICTURES AS Z ON Z.ITEM_ID = A.ITEM_ID AND Z.LIST_NO = 1";

                        //sqltext = "Select A.ITEM_CODE + char(10) + char(10) + ISNULL(A.ABBREVIATE_NAME,'') + char(10) + char(10) + ISNULL(B.BRAND_CODE,'') as Group1,"
                        //        + "ISNULL(A.GENUIN_PART_ID,'') + char(10) + char(10) + ISNULL(A.BRAND_PART_ID,'') + char(10) + char(10) + ISNULL(A.FULL_NAME,'') as Group2,"
                        //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group3,"
                        //        + "ISNULL(A.MODEL1,'') + char(10) + char(10) + ISNULL(A.MODEL2,'') + char(10) + char(10) + ISNULL(A.MODEL3,'') as Group4,"
                        //        //+ "ISNULL(G.BRAND_CODE,'') + char(10) + char(10) + CONVERT(datetime,ISNULL(B.SETUP_PRICE_DATE,''),103) + char(10) + char(10) + CASE WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 1 THEN 'VAT นอก' WHEN ISNULL(B.CURRENT_VAT_STATUS,1) = 2 THEN 'VAT ใน' ELSE 'ไม่มี VAT' END as Group5,"
                        //        + " A.*, B.BRAND_CODE as Group1, B.BRAND_ID, B.BRAND_CODE,C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE "
                        //        + " From M_VENDORS I  INNER JOIN D_ITEM_VENDORS G ON I.VENDOR_ID = G.VENDOR_ID And G.LIST_NO = 1 RIGHT OUTER JOIN"
                        //        + " M_ITEMS A LEFT OUTER JOIN"
                        //        + " M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                        //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                        //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                        //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                        //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                        //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                       
                        //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                        //sqltext = "Select A.*, B.BRAND_ID, B.BRAND_CODE, C.CATEGORY_CODE, C.CATEGORY_NAME, D.TYPE_CODE, D.TYPE_NAME, E.SIZE_CODE, H.PO_GROUP_CODE, H.PO_GROUP_NAME, Z.PICTURE_IMAGE From M_ITEMS A"
                        //        + " LEFT JOIN M_BRANDS B ON A.BRAND_ID = B.BRAND_ID"    //ยี่ห้อ
                        //        + " LEFT JOIN M_CATEGORIES C ON C.CATEGORY_ID = A.CATEGORY_ID"     //หมวดหมู่
                        //        + " LEFT JOIN M_TYPES D ON D.TYPE_ID = A.TYPE_ID"     //ประเภท
                        //        + " LEFT JOIN M_SIZES E ON E.SIZE_ID = A.SIZE_ID"       //Size
                        //        + " LEFT JOIN D_ITEM_PO_GROUPS F ON F.ITEM_ID = A.ITEM_ID And F.LIST_NO = 1"      //กลุ่มสั่งซื้อ
                        //        + " LEFT JOIN M_PO_GROUPS H ON H.PO_GROUP_ID = F.PO_GROUP_ID"                                        
                        //        + " LEFT JOIN D_ITEM_PICTURES Z ON Z.ITEM_ID = A.ITEM_ID And Z.LIST_NO = 1";   //รูปภาพ
                        //sqltext += " Where len(A.ITEM_CODE) > 0 ";
                        //sqltext += string.Format(" and R.SUB_ID ={0}", Groupid);

                        //if (SortType > 0)
                        //{
                        //switch (SortType)
                        //{
                        //    case 1:
                        //    sqltext += " order by C.CATEGORY_CODE,A.ABBREVIATE_NAME,A.MODEL1";
                        //    break;
                        //    case 2:
                        //    sqltext += " order by C.CATEGORY_CODE,A.FULL_NAME,A.MODEL1";
                        //    break;
                        //    case 3:
                        //    sqltext += " order by A.ITEM_CODE";
                        //    break;
                        //    case 4:
                        //    sqltext += " order by A.GENUIN_PART_ID";
                        //    break;
                        //    case 5:
                        //    sqltext += " order by A.BRAND_PART_ID";
                        //    break;
                        //    case 6:
                        //    sqltext += " order by A.SIZE_OUTSIDE";
                        //    break;
                        //    case 7:
                        //    sqltext += " order by A.SIZE_THICK";
                        //    break;
                        //    case 8:
                        //    sqltext += " order by A.SIZE_INNER";
                        //    break;
                        //}
                        //}

                        //_dataAdapter.SelectCommand = new SqlCommand(sqltext, conn);
                        //_dataAdapter.SelectCommand.Parameters.Clear();
                        //_dataAdapter.Fill(dt);
                        command.Connection = conn;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "SP_M_ItemSearchVERSATILES";

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@pType", SortType);
                        command.Parameters.AddWithValue("@GroupID", Groupid);

                        dtShow = new DataTable();
                        _dataAdapter = new SqlDataAdapter(command);
                        _dataAdapter.Fill(dtShow);

                        //dtShow = dt.Copy();
                    if (dtShow.Rows.Count > 0) spinListNo.Text = dtShow.Rows.Count.ToString("#,##0");
                    //for (int i = 0; i < dtShow.Rows.Count; i++)
                    //{
                    //    dtShow.Rows[i]["Group1"] = cls_Library.DBString(dtShow.Rows[i]["ITEM_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]) + Environment.NewLine + cls_Library.DBString(dtShow.Rows[i]["BRAND_CODE"]);
                    //}
                    //Setgrid();
                    //}
                    //else
                    //{
                    //    dt = null;
                    //    dtShow = null;
                    //    ClearControl();
                    //}
                    //Grid                            
                    gridItem.DataSource = dtShow;
                    gridItem.RefreshDataSource();
                    cvItem.RefreshData();
                    gridItem.Select();
                    FocusRowchangeOK = false;
                    if (gridItem.Visible)
                    {
                    FocusRowchangeOK = true;
                    SetDataFocus();
                    FocusRowchangeOK = false;
                    }
                    //XXXX กรณีมีข้อมูลอยู่ แล้วได้ข้อมูลชุดใหม่ ต้องทำให้เข้า RowChange
                    //if (dtShow.Rows.Count > 0) cvItem_FocusedRowChanged(cvItem, null);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
            }
        }

        private void GetDisCount(int BrandID)
        {
            DataTable dt = new DataTable();
            try
            {
                listDiscount.Items.Clear();
                //cls_Data.LoadSpecifyData("Select DISCOUNT_RATE, VAT_STATUS, LIST_NO From D_BRAND_REFERENCE_DISCOUNTS Where BRAND_ID = " + BrandID + " And ACTIVE_STATUS = 1 Order By LIST_NO", out dt, "D_BRAND_REFERENCE_DISCOUNTS");
                cls_Data.LoadSpecifyData("Select DISCOUNT_RATE, VAT_STATUS, LIST_NO From D_BRAND_REFERENCE_DISCOUNTS Where BRAND_ID = " + BrandID + " Order By LIST_NO", out dt, "D_BRAND_REFERENCE_DISCOUNTS");
                if (dt.Rows.Count > 0)
                {
                    int ItemKey;
                    foreach (DataRow dr in dt.Rows)
                    {
                        listDiscount.Items.Add(cls_Library.DBInt(dr["DISCOUNT_RATE"]).ToString());
                        ItemKey = listDiscount.Items.Count - 1;
                        listDiscount.Items[ItemKey].SubItems.Add(GetVatStatus(cls_Library.DBByte(dr["VAT_STATUS"])));
                        if (cls_Library.DBDecimal(spinNewPrice.EditValue) > 0)
                        {
                            ItemKey = listDiscount.Items.Count - 1;                         
                            decimal Oprice = cls_Library.DBDecimal(spinNewPrice.EditValue);
                            decimal NewPrice = 0;
                            NewPrice = Oprice - ((Oprice * cls_Library.DBInt(dr["DISCOUNT_RATE"])) / 100);
                            if (cls_Library.DBByte(dr["VAT_STATUS"]) == 1)
                            {
                                NewPrice = NewPrice + Math.Round(((NewPrice * 7) / 100), 2);
                            }
                            listDiscount.Items[ItemKey].SubItems.Add(NewPrice.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("GetDisCount: " + ex.Message);
            }
        }

        //private void cvItem_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        //{
        //    int Id = 0;
        //    try
        //    {

        //            if (dtShow.Rows.Count <= 0) return;
        //            GridView view = sender as GridView;
        //            int iRow = e.ListSourceRowIndex;
        //            int Itemid = 0;
        //            switch (e.Column.Name)
        //            {
        //                case "colGroup6":
        //                    Itemid = cls_Library.DBInt(view.GetListSourceRowCellValue(iRow, "ITEM_ID"));
        //                    DataTable dt = cls_Data.GetPriceListByItem(ItemID, 0, 2);
        //                    string Scap = "";
        //                    if (dt.Rows.Count > 0)
        //                    {
        //                        int UnitID = cls_Library.DBInt(dt.Rows[0]["UNIT_ID"]);
        //                        string Suname = cls_Data.GetNameFromTBname(UnitID, "UNITS", "UNIT_NAME");
        //                        Scap = Suname + Environment.NewLine + Environment.NewLine;
        //                        Scap = Scap + cls_Library.DBDateTime(dt.Rows[0]["DATENET"]).ToShortDateString() + Environment.NewLine + Environment.NewLine ;
        //                        Scap = Scap + cls_Library.DBDecimal(dt.Rows[0]["PRICE1"]).ToString("#,##0.00");
        //                        e.Value = Scap;
        //                    }
        //                    break;
        //                //case "rowType":
        //                //    string Typecode = cls_Library.DBString(dtVG.Rows[0]["TYPE_CODE"]);
        //                //    string Typename = cls_Library.DBString(dtVG.Rows[0]["TYPE_NAME"]);
        //                //    e.Value = string.Concat(Typecode, " ", Typename);
        //                //    break;
        //                ////case "rowCusPO":
        //                ////  e.Value = cls_Library.DBString(dtVG.Rows[0]["VENDOR_NAME"]); 
        //                ////  break;
        //                //case "rowGroupPO":
        //                //    Id = cls_Library.DBInt(cls_Data.GetNameFromTBname(cls_Library.DBInt(dtVG.Rows[0]["ITEM_ID"]), "ITEM_PO_GROUPS", "PO_GROUP_ID"));
        //                //    string POcode = cls_Data.GetNameFromTBname(Id, "PO_GROUPS", "PO_GROUP_CODE");
        //                //    string POname = cls_Data.GetNameFromTBname(Id, "PO_GROUPS", "PO_GROUP_NAME");
        //                //    e.Value = string.Concat(POcode, " ", POname);
        //                //    break;
        //                //case "rowPart":
        //                //    e.Value = cls_Data.GetNameFromTBname(cls_Library.DBInt(dtVG.Rows[0]["ITEM_ID"]), "ITEM_ALTERNATE_PARTS", "PART_ID", true);
        //                //    break;
        //            }

        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message);
        //    }
        //}

        private DataTable GetGroupItemData(byte type, int ItemID = 0)
        {
            DataTable dtResult = null;
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();
            try
            {
            if (cls_Global_DB.ConnectDatabase(ref conn))
            {
                switch (type)
                {
                case 1://ใช้แทนกัน
                    sb.AppendFormat("SELECT GROUPREPLACE.GROUP_ID, GROUPREPLACE.GROUP_CODE FROM  GROUPREPLACE INNER JOIN GROUPSUBREPLACE ON GROUPREPLACE.GROUP_ID = GROUPSUBREPLACE.GROUP_ID where GROUPSUBREPLACE.ITEM_ID = {0}", ItemID);
                    sb.AppendLine(" order by GROUPSUBREPLACE.LIST_NO");
                    _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                    _dataAdapter.SelectCommand.Parameters.Clear();
                    dtResult = new DataTable("GROUPREPLACE");
                    _dataAdapter.Fill(dtResult);

                    break;
                case 2://ใช้ร่วมกัน
                    sb.AppendFormat("SELECT GROUPJOIN.GROUP_ID, GROUPJOIN.GROUP_CODE FROM  GROUPJOIN  INNER JOIN GROUPSUBJOIN  ON GROUPJOIN.GROUP_ID = GROUPSUBJOIN.GROUP_ID where GROUPSUBJOIN.ITEM_ID = {0}", ItemID);
                    sb.AppendLine(" order by GROUPSUBJOIN.LIST_NO");
                    _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                    _dataAdapter.SelectCommand.Parameters.Clear();
                    dtResult = new DataTable("GROUPJOIN");
                    _dataAdapter.Fill(dtResult);
                    break;
                }
            }
            }
            catch (Exception ex)
            {
            MessageBox.Show("GetGroupItemData: " + ex.Message);
            dtResult = null;
            }
            finally
            {
            cls_Global_DB.CloseDB(ref conn);
            conn.Dispose();
            }
            return dtResult;
        }

        private void gvJoin_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (!SelectJoin) return;
            //////////gvJoinSetDataRow();
            
            //////////gridJoin.Select();
            //////////gvJoin.Focus();
        }

        private DataTable GetGroupVersatileData(int ItemID = 0)
        {
            DataTable dtResult = null;
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();
            try
            {
            if (cls_Global_DB.ConnectDatabase(ref conn))
            {
                sb.AppendFormat("SELECT M_VERSATILES_SUB.SUB_ID, M_VERSATILES_SUB.SUB_CODE, M_VERSATILES_SUB.SUB_NAME FROM  M_VERSATILES_SUB INNER JOIN M_VERSATILES_ITEM ON M_VERSATILES_SUB.SUB_ID = M_VERSATILES_ITEM.VERSATILE_SUB_ID where M_VERSATILES_ITEM.ITEM_ID = {0}", ItemID);
                sb.AppendLine(" order by M_VERSATILES_SUB.LIST_NO");
                _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                _dataAdapter.SelectCommand.Parameters.Clear();
                dtResult = new DataTable("M_VERSATILES_SUB");
                _dataAdapter.Fill(dtResult);

            }
            }
            catch (Exception ex)
            {
            MessageBox.Show("GetGroupVersatileData: " + ex.Message);
            dtResult = null;
            }
            finally
            {
            cls_Global_DB.CloseDB(ref conn);
            conn.Dispose();
            }
            return dtResult;
        }

        private DataTable GetItemByID(int ItemID=0)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable("M_ITEMS");
            string sqltext = "";
            try
            {
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {

                    dt = new DataTable("M_ITEMS");
                    //sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY ITEM_ID) as RNnew FROM Vw_ItemSearch";

                    //if (SortType > 0)
                    //{
                    //    switch (SortType)
                    //    {
                    //        case 1:
                    //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY CATEGORY_CODE,ABBREVIATE_NAME,MODEL1) as RNnew  FROM Vw_ItemSearch";
                    //            break;
                    //        case 2:
                    //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY CATEGORY_CODE,FULL_NAME,MODEL1) as RNnew  FROM Vw_ItemSearch";
                    //            break;
                    //        case 3:
                    //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY ITEM_CODE) as RNnew  FROM Vw_ItemSearch";
                    //            break;
                    //        case 4:
                    //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY GENUIN_PART_ID) as RNnew  FROM Vw_ItemSearch";
                    //            break;
                    //        case 5:
                    //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY BRAND_PART_ID) as RNnew  FROM Vw_ItemSearch";
                    //            break;
                    //        case 6:
                    //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_OUTSIDE) as RNnew  FROM Vw_ItemSearch";
                    //            break;
                    //        case 7:
                    //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_THICK) as RNnew  FROM Vw_ItemSearch";
                    //            break;
                    //        case 8:
                    //            sqltext = "SELECT *, ROW_NUMBER() OVER(ORDER BY SIZE_CODE,SIZE_INNER) as RNnew  FROM Vw_ItemSearch";
                    //            break;
                    //    }
                    //}

                    //sqltext += " Where len(ITEM_CODE) > 0 ";        

                    //if ((SortType ==1) || (SortType == 2))
                    //{
                    //    if (CategorySearch.Length > 0)
                    //        sqltext += string.Format(" and CATEGORY_CODE = '{0}'", CategorySearch);
                    //}



                    //sqltext += string.Format(" and ITEM_ID ={0}", ItemID);

                    //if(SortType > 0)
                    //{
                    //    switch (SortType)
                    //    {
                    //        case 1:
                    //            sqltext += " order by CATEGORY_CODE,ABBREVIATE_NAME,MODEL1";
                    //            break;
                    //        case 2:
                    //            sqltext += " order by CATEGORY_CODE,FULL_NAME,MODEL1";
                    //            break;
                    //        case 3:
                    //            sqltext += " order by ITEM_CODE";
                    //            break;
                    //        case 4:
                    //            sqltext += " order by GENUIN_PART_ID";
                    //            break;
                    //        case 5:
                    //            sqltext += " order by BRAND_PART_ID";
                    //            break;
                    //        case 6:
                    //            sqltext += " order by SIZE_CODE,SIZE_OUTSIDE";
                    //            break;
                    //        case 7:
                    //            sqltext += " order by SIZE_CODE,SIZE_THICK";
                    //            break;
                    //        case 8:
                    //            sqltext += " order by SIZE_CODE,SIZE_INNER";
                    //            break;
                    //    }
                    //}

                    //_dataAdapter.SelectCommand = new SqlCommand(sqltext, conn);
                    //_dataAdapter.SelectCommand.Parameters.Clear();
                    //_dataAdapter.SelectCommand.CommandTimeout = 300;
                    //_dataAdapter.Fill(dt);

                    string iTemCode = cls_Data.GetNameFromTBname(ItemID, "ITEMS", "ITEM_CODE", false);

                    sqltext = "SP_M_ItemSearch_Search1";
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_M_ItemSearch_Search1";

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SORT_ORDER", SortType);
                    command.Parameters.AddWithValue("@ITEM_CODE", iTemCode);
                    
                    dt = new DataTable();
                    _dataAdapter = new SqlDataAdapter(command);
                    _dataAdapter.Fill(dt);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            //throw;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
            }
            return dt;
        }

        private DataTable GetItemROByID(int ItemID = 0)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataTable dt = new DataTable("M_ITEMS");
            string sqltext = "";
            try
            {
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {

                    dt = new DataTable("M_ITEMS");
                    

                    string iTemCode = cls_Data.GetNameFromTBname(ItemID, "ITEMS", "ITEM_CODE", false);

                    sqltext = "SP_M_ItemSearch_Search2";
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SP_M_ItemSearch_Search2";

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SORT_ORDER", 1);
                    command.Parameters.AddWithValue("@pType", 1);
                    command.Parameters.AddWithValue("@CUS_ID", Vendorsid);

                    dt = new DataTable();
                    _dataAdapter = new SqlDataAdapter(command);
                    _dataAdapter.Fill(dt);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //throw;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
            }
            return dt;
        }
        private void gvReplace_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (!SelectReplace) return;
            //////////gvReplaceSetDataRow();

            //////////gridReplace.Select();
            //////////gvReplace.Focus();
        }

        private string GetVatStatus(byte Vstatus)
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

        private void gvJoinSetDataRow()
        {
            //if (e.KeyChar == (Char)Keys.Enter)
            //{
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvJoin;
            if (view.FocusedRowHandle < 0) return;
            int RowHandle = view.FocusedRowHandle;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["GROUP_ID"]);
            if (ID == 0) return;
            this.Cursor = Cursors.WaitCursor;
            GetDataChooseGroupJoin(ID);
            this.Cursor = Cursors.Default;
            if (dtJoin.Rows.Count > 0)
            {
                uNCoumt++;
                AssignArraUndo(uNCoumt);
                AssignValueToArraUndo(uNCoumt);
            }
            SetDataFocus();
            gvJoin.FocusedRowHandle = RowHandle;

            //gvJoin.Focus();
            //}
        }

        private void gvJoinOpenGroup()
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
            if ((view.FocusedRowHandle < 0)) return;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["ITEM_ID"]);
            frm_Group frmGroup = new frm_Group(2, 1);
            frmGroup.ItemID = ID;
            cls_Global_DB.GB_GroupJoin = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvJoin;
            if (view.FocusedRowHandle >= 0)
            {
                row = view.GetFocusedDataRow();
                cls_Global_DB.GB_GroupJoin = cls_Library.DBInt(row["GROUP_ID"]);
            }
            frmGroup.GroupID = cls_Global_DB.GB_GroupJoin;


            if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(frmGroup.ProductCode))
                {
                    GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
                }
            }
        }

        private void gvReplaceOpenGroup()
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
            if ((view.FocusedRowHandle < 0)) return;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["ITEM_ID"]);
            frm_Group frmGroup = new frm_Group(1, 1);
            frmGroup.ItemID = ID;
            cls_Global_DB.GB_GroupReplace = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvReplace;
            if (view.FocusedRowHandle >= 0)
            {
                row = view.GetFocusedDataRow();
                cls_Global_DB.GB_GroupReplace = cls_Library.DBInt(row["GROUP_ID"]);
            }
            frmGroup.GroupID = cls_Global_DB.GB_GroupReplace;


            if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(frmGroup.ProductCode))
                {
                    GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
                }
            }
        }

        private void gvVersatile_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //////////if (!SelectVersatile) return;
            //////////gvVersatileSetDataRow();

            //////////gridVersatile.Select();
            //////////gvVersatile.Focus();
        }

        private void cvItem_MouseUp(object sender, MouseEventArgs e)
        {
            Application.DoEvents();
        }

        private void gvReplace_DoubleClick(object sender, EventArgs e)
        {
            gvReplaceSetDataRow();

            gridReplace.Select();
            gvReplace.Focus();
        }

        private void gvVersatile_DoubleClick(object sender, EventArgs e)
        {
            //////////if (!SelectVersatile) return;
            gvVersatileSetDataRow();

            gridVersatile.Select();
            gvVersatile.Focus();
        }

        private void gvJoin_GotFocus(object sender, EventArgs e)
        {
            //////////if (SelectJoin) return;
            //////////gvJoinSetDataRow();
            SelectJoin = true;


            //DevExpress.XtraGrid.Views.Grid.GridView view;
            //int ID = 0;
            //view = (DevExpress.XtraGrid.Views.Grid.GridView)gvJoin;
            //if (view.FocusedRowHandle < 0) return;
            //DataRow row = view.GetFocusedDataRow();
            //ID = cls_Library.DBInt(row["GROUP_ID"]);
            //if (ID == 0) return;
            //GetDataChooseGroupJoin(ID);
            //if (dtJoin.Rows.Count > 0)
            //{
            //    uNCoumt++;
            //    AssignArraUndo(uNCoumt);
            //    AssignValueToArraUndo(uNCoumt);
            //}
        }

        private void gvReplace_GotFocus(object sender, EventArgs e)
        {
            //////////if (SelectReplace) return;
            //////////gvReplaceSetDataRow();
            SelectReplace = true;



            //DevExpress.XtraGrid.Views.Grid.GridView view;
            //int ID = 0;
            //view = (DevExpress.XtraGrid.Views.Grid.GridView)gvReplace;
            //if (view.FocusedRowHandle < 0) return;
            //DataRow row = view.GetFocusedDataRow();
            //ID = cls_Library.DBInt(row["GROUP_ID"]);
            //if (ID == 0) return;
            //GetDataChooseGroupReplace(ID);
            //if (dtReplace.Rows.Count > 0)
            //{
            //    uNCoumt++;
            //    AssignArraUndo(uNCoumt);
            //    AssignValueToArraUndo(uNCoumt);
            //}
        }

        private void gvReplaceSetDataRow()
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvReplace;
            if (view.FocusedRowHandle < 0) return;
            int RowHandle = view.FocusedRowHandle;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["GROUP_ID"]);
            if (ID == 0) return;
            this.Cursor = Cursors.WaitCursor;
            GetDataChooseGroupReplace(ID);
            this.Cursor = Cursors.Default;
            if (dtReplace.Rows.Count > 0)
            {
                uNCoumt++;
                AssignArraUndo(uNCoumt);
                AssignValueToArraUndo(uNCoumt);
            }
            SetDataFocus();
            gvReplace.FocusedRowHandle = RowHandle;
        }

        private void cvItem_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            //Application.DoEvents();
        }

        private void cvItem_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            //Application.DoEvents();
        }

        private void cvItem_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Application.DoEvents();
        }

        private void cvItem_LostFocus(object sender, EventArgs e)
        {
            //Application.DoEvents();
        }

        private void cvItem_GotFocus(object sender, EventArgs e)
        {
            //Application.DoEvents();
        }

        private void cvItem_RowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            //Application.DoEvents();
        }

        private void gvVersatileSetDataRow()
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvVersatile;
            if (view.FocusedRowHandle < 0) return;
            int RowHandle = view.FocusedRowHandle;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["SUB_ID"]);
            if (ID == 0) return;
            this.Cursor = Cursors.WaitCursor;
            GetDataChooseGroupVersatile(ID);
            this.Cursor = Cursors.Default;
            if (dtReplace.Rows.Count > 0)
            {
                uNCoumt++;
                AssignArraUndo(uNCoumt);
                AssignValueToArraUndo(uNCoumt);
            }
            SetDataFocus();
            gvVersatile.FocusedRowHandle = RowHandle;
        }

        private void InitialDialog()
        {
            if (!bwData.IsBusy)
                bwData.RunWorkerAsync();           
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            try
            {
                int pid = 0;
                string strMode = "";

                switch (mode)
                {
                    case cls_Struct.ActionMode.Add:
                        strMode = " [เปิดใหม่]";
                        break;
                }

                frm_BSRecord frm = new frm_BSRecord(mode, pid, cls_Sales.Sale_Cus, cls_Sales.Sale_User);
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.Text = "ขายสินค้า -" + strMode;
                frm.MinimizeBox = false;
                frm.ShowInTaskbar = false;
                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.UseWaitCursor = false;
                    this.Cursor = Cursors.Default;
                }
                gridItem.Select();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("InitialDialogForm :" + ex.Message);
            }
        }

        public void InitialDialogFormfilter()
        {
            FilterBS frmInput;
            frmInput = new FilterBS();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "Condition";
                #region "Assign Lookup"
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                cls_Sales.FilterOption = frmInput.MainCondition;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        public void InitialDialogFormSearch1()
        {
            frmSearch1 frmInput;
            frmInput = new frmSearch1();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "ค้นหาแบบที่ 1";
                #region "Assign Lookup"

                if (cls_Global_DB.DataInitial == null)
                {
                    cls_Global_DB.DataInitial = new DataSet();
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_CATEGORIES"));
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_BRANDS"));
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_SIZES"));
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_TYPES"));
                }
                else
                {
                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_CATEGORIES"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_CATEGORIES"));

                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_BRANDS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_BRANDS"));

                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_SIZES"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_SIZES"));

                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_TYPES"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_TYPES"));
                }


                cls_Library.AssignSearchLookUp(frmInput.searchCategoriesCode, "M_CATEGORIES", "รหัสหมวดหมู่", "ชื่อหมวดหมู่");
                cls_Library.AssignSearchLookUp(frmInput.searchBrandCode, "M_BRANDS", "รหัสยี่ห้อสินค้า", "ชื่อยี่ห้อสินค้า");
                cls_Library.AssignSearchLookUp(frmInput.searchSizesCode, "M_SIZES", "รหัสประเภทสินค้า+ขนาด", "ชื่อประเภทสินค้า+ขนาด");
                cls_Library.AssignSearchLookUp(frmInput.searchTypesCode, "M_TYPES", "รหัสประเภทสินค้า", "ชื่อประเภทสินค้า");

                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                PdtCode = frmInput.txtPdtCode.Text.Trim();
                CategoriesCode = frmInput.searchCategoriesCode.Text.Trim();
                CategoriesName = frmInput.txtCategoriesName.Text.Trim();
                AbbreviateName = frmInput.txtAbbreviateName.Text.Trim();
                GenuinPart = frmInput.txtGenuinPart.Text.Trim();
                ProducerPart = frmInput.txtProducerPart.Text.Trim();
                FullName = frmInput.txtFullName.Text.Trim();
                BrandCode = frmInput.searchBrandCode.Text.Trim();
                BrandName = frmInput.txtBrandName.Text.Trim();
                SizesCode = frmInput.searchSizesCode.Text.Trim();
                SizesName = frmInput.txtSizesName.Text.Trim();
                SizeInner = frmInput.txtSizeInner.Text.Trim();
                SizeOutside = frmInput.txtSizeOutside.Text.Trim();
                SizeThick = frmInput.txtSizeThick.Text.Trim();
                Model1 = frmInput.txtModel1.Text.Trim();
                Model2 = frmInput.txtModel2.Text.Trim();
                Model3 = frmInput.txtModel3.Text.Trim();
                LocationName = frmInput.txtLocation.Text.Trim();
                Alternate = frmInput.txtAlternate.Text.Trim();
                TypesCode = frmInput.searchTypesCode.Text.Trim();
                TypesName = frmInput.txtTypesName.Text.Trim();
                SortOrderNum = frmInput.comboSortOrder.SelectedIndex;

                CategorySearch = CategoriesCode;
                txtCategory.Text = cls_Data.GetNameFromTBname(CategorySearch, "CATEGORIES", "CATEGORY_CODE") + " ---- " + cls_Data.GetNameFromTBname(CategorySearch, "CATEGORIES", "CATEGORY_NAME");

                this.Cursor = Cursors.WaitCursor;
                GetDataChooseFromSearch1(cls_Global_class.ChooseType.Item);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogFormSearch2()
        {
            frmSearch2 frmInput;
            frmInput = new frmSearch2();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "ค้นหาแบบที่ 2";
                #region "Assign Lookup"

                if (cls_Global_DB.DataInitial == null)
                {
                    cls_Global_DB.DataInitial = new DataSet();
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));
                }
                else
                {
                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_VENDORS"))
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));

                }

                cls_Library.AssignSearchLookUp(frmInput.searchVendorsCode, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");

                frmInput.searchVendorsCode.Select();

                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                Vendorsid = cls_Library.DBInt(frmInput.searchVendorsCode.EditValue);
                VendorsCode = frmInput.searchVendorsCode.Text.Trim();
                VendorName = frmInput.TxtVendorName.Text.Trim();

                this.Cursor = Cursors.WaitCursor;
                GetDataChooseFromSearch2(cls_Global_class.ChooseType.Item);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        public void InitialDialogFormSortOrder()
        {
            ShortcutSortOrder frmInput;
            frmInput = new ShortcutSortOrder();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "Sort Order";
                #region "Assign Lookup"
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                SortType = frmInput.MainSearch;
                if (SortType < 1) SortType = 1;
                if (SortType > 8) SortType = 1;
                comboSort.SelectedIndex = SortType - 1;
                this.Cursor = Cursors.WaitCursor;
                GetDataChooseForSortOrder(cls_Global_class.ChooseType.Item);
                this.Cursor = Cursors.Default;
                txtProduct.Select();

            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogFormSearch3()
        {
            frmSearch3 frmInput;
            frmInput = new frmSearch3();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "ค้นหาแบบที่ 3";
                #region "Assign Lookup"

                if (cls_Global_DB.DataInitial == null)
                {
                    cls_Global_DB.DataInitial = new DataSet();
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_PO_GROUPS"));
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_BRANDS"));
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_TYPES"));
                }
                else
                {
                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_PO_GROUPS"))
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_PO_GROUPS"));

                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_VENDORS"))
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));

                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_BRANDS"))
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_BRANDS"));

                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_TYPES"))
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_TYPES"));
                }



                cls_Library.AssignSearchLookUp(frmInput.searchPOGroupsCode, "M_PO_GROUPS", "รหัสกลุ่มสั่งซื้อสินค้า", "ชื่อกลุ่มสั่งซื้อสินค้า");
                cls_Library.AssignSearchLookUp(frmInput.searchVendorsCode, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");
                cls_Library.AssignSearchLookUp(frmInput.searchBrandCode, "M_BRANDS", "รหัสยี่ห้อสินค้า", "ชื่อยี่ห้อสินค้า");
                cls_Library.AssignSearchLookUp(frmInput.searchTypesCode, "M_TYPES", "รหัสประเภทสินค้า", "ชื่อประเภทสินค้า");

                frmInput.searchPOGroupsCode.Select();

                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                POGroupCode = frmInput.searchPOGroupsCode.Text.Trim();
                POGroupName = frmInput.TxtPOGroupName.Text.Trim();
                VendorsCode = frmInput.searchVendorsCode.Text.Trim();
                VendorName = frmInput.TxtVendorName.Text.Trim();
                BrandCode = frmInput.searchBrandCode.Text.Trim();
                BrandName = frmInput.txtBrandName.Text.Trim();
                TypesCode = frmInput.searchTypesCode.Text.Trim();
                TypesName = frmInput.txtTypesName.Text.Trim();
                CountType = frmInput.radioGroupType.SelectedIndex;

                this.Cursor = Cursors.WaitCursor;
                GetDataChooseFromSearch3(cls_Global_class.ChooseType.Item);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        private void InitialListCode(int TypeCode, string Xcode = "")
        {
            try
            {
            frm_ListCodes frm;
            frm = new frm_ListCodes(TypeCode, Xcode);
            frm.StartPosition = FormStartPosition.CenterParent;
            switch (TypeCode)
            {
                case 8:
                frm.Text = "หมวดหมู่สินค้า";
                break;
            }

            frm.MinimizeBox = false;
            frm.ShowInTaskbar = false;
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                int id = frm.Prop_Arr;
                bool ok = false;
                if (id > 0) ok = true;
                if (ok)
                {
                if (id > 0)
                {
                    CategorySearch = cls_Data.GetNameFromTBname(id, "CATEGORIES", "CATEGORY_CODE").ToUpper();
                    txtCategory.Text = CategorySearch + " ---- " + cls_Data.GetNameFromTBname(id, "CATEGORIES", "CATEGORY_NAME");
                }
                }
            }
            }
            catch (Exception e)
            {
            this.Focus();
            }
        }

        private void InitialListContactCode()
        {
            try
            {
            frm_ListContactCodes frm;
            frm = new frm_ListContactCodes();
            frm.StartPosition = FormStartPosition.CenterParent;
        

            frm.MinimizeBox = false;
            frm.ShowInTaskbar = false;
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {

            }
            }
            catch (Exception e)
            {
            this.Focus();
            }
        }

        public void InitialDialogMainSearch()
        {
            ShortcutMenu frmInput;
            frmInput = new ShortcutMenu();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "Main menu";
                #region "Assign Lookup"

                frmInput.BTmenu1.Select();
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                MainSearch = frmInput.MainSearch;
                SubSearch = MainSearch;
                SetSubMenu();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        public void InitialDialogFormOpenBill()
        {
            frm_OpenBill frmInput;
            frmInput = new frm_OpenBill();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            try
            {
                frmInput.Text = "ขายสินค้า";
                #region "Assign Lookup"
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                int CUSid = frmInput.CUS_ID;
                int PERid = frmInput.PER_ID;

                cls_Sales.Sale_ISCASH = false;
                cls_Sales.Sale_Cus = CUSid;
                cls_Sales.Sale_User = PERid;


                this.Cursor = Cursors.WaitCursor;

                InitialDialogForm(cls_Struct.ActionMode.Add);

                this.Cursor = Cursors.Default;

                //Class_Library mc = new Class_Library();
                //Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
                //Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

                //if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
                //{
                //    return;
                //}
                //if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
                //{
                //    this.Cursor = Cursors.WaitCursor;

                //    cls_Form.GB_Instance[i].instanceused = true;
                //    cls_Form.GB_Instance[i].instanceusedid = tag;
                //    cls_Form.GB_Instance[i].instanceform = new frm_BSRecord(0, 0);
                //    cls_Form.GB_Instance[i].instanceform.Text = "ขายสินค้า";
                //    cls_Form.GB_Instance[i].instanceform.Tag = tag;
                //    cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                //    cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                //    cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                //    cls_Form.GB_Instance[i].instanceform.Show();
                //    this.Cursor = Cursors.Default;
                //}

                //frm_BSRecord frm = new frm_BSRecord(0, 0);
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.WindowState = FormWindowState.Maximized;

                //frm.Text = "ขายสินค้า -" + strMode;
                //frm.MinimizeBox = false;
                //frm.ShowInTaskbar = false;
                //if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                //{
                //    if (!bwList.IsBusy)
                //    {
                //        this.UseWaitCursor = true;
                //        bwList.RunWorkerAsync();
                //    }
                //    this.UseWaitCursor = false;
                //    this.Cursor = Cursors.Default;
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        private void LinkEditItem(cls_Struct.TypeEditItem type)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            try
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();
                ID = cls_Library.DBInt(row["ITEM_ID"]);

                switch (type)
                {
                    case cls_Struct.TypeEditItem.T1:
                        break;
                    case cls_Struct.TypeEditItem.T2:        //Brand
                        frm_ItemSetBrand frmItem2 = new frm_ItemSetBrand(ID);
                        if (frmItem2.ShowDialog() == DialogResult.OK)
                        {
                            SetUpdateDataFocus(1);
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T3:        //ต่ำสุด/สูงสุด
                        frm_ItemEdit3 frmItem3 = new frm_ItemEdit3(ID);
                        if (frmItem3.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T4:
                        frm_ItemEdit4 frmItem4 = new frm_ItemEdit4(ID);
                        if (frmItem4.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T5:
                        frm_ItemEdit5 frmItem5 = new frm_ItemEdit5(ID);
                        if (frmItem5.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T6:
                        frm_ItemEdit6 frmItem6 = new frm_ItemEdit6(ID);
                        if (frmItem6.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T7:
                        frm_ItemEdit7 frmItem7 = new frm_ItemEdit7(ID);
                        if (frmItem7.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T8:
                        frm_ItemEdit8 frmItem8 = new frm_ItemEdit8(ID);
                        frmItem8.spinQtyNew.Focus();
                        if (frmItem8.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T9:
                        frm_ItemEdit9 frmItem9 = new frm_ItemEdit9(ID);
                        if (frmItem9.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T10:
                        frm_ItemEdit10 frmItem10 = new frm_ItemEdit10(ID);
                        if (frmItem10.ShowDialog() == DialogResult.OK)
                        {
                            SetUpdateDataFocus(2);
                            SetUpdateDataFocus(3);
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T11:
                        frm_ItemEdit11 frmItem11 = new frm_ItemEdit11(ID);
                        if (frmItem11.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }
                        break;
                    case cls_Struct.TypeEditItem.T14:
                        frm_Product_Record frm = new frm_Product_Record(cls_Struct.ActionMode.Edit, ID);
                        //frm.ItemID = pid;
                        //frm.InitialDialog(mode);
                        frm.ShowInTaskbar = false;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.Width = 1379;
                        frm.Height = 850;
                        frm.Text = "รหัสสินค้า [แก้ไข]";
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                        }   
                        break;
                    case cls_Struct.TypeEditItem.SetPrice:
                        //DataSet dsData = cls_Data.GetDataItemEdit2(ItemID);                       
                        //if (dsData.Tables["D_BRAND_SALE_DISCOUNT_STEPS"].Rows.Count > 0)
                        //{
                        //    frm_ItemSetPriceDiscount frmItemSetPriceDiscount = new frm_ItemSetPriceDiscount(ID);
                        //    frmItemSetPriceDiscount.ShowDialog();
                        //}
                        //else
                        //{
                        //    frm_ItemSetPrice frmItemSetPrice = new frm_ItemSetPrice(ID);
                        //    frmItemSetPrice.ShowDialog();
                        //}
                        int BrandID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ID, "ITEMS", "BRAND_ID"));
                        int SALE_CODE = cls_Library.DBInt(cls_Data.GetNameFromTBname(BrandID, "BRANDS", "SALE_CODE"));
                        if (SALE_CODE == 1)
                        {
                            frm_ItemSetPrice frmItemSetPrice = new frm_ItemSetPrice(ID);
                            if (frmItemSetPrice.ShowDialog() == DialogResult.OK)
                            {
                                row["Group6"] = cls_Data.GetSetPriceByItem(ID);
                            }
                        }
                        else
                        {
                            frm_ItemSetPriceDiscount frmItemSetPriceDiscount = new frm_ItemSetPriceDiscount(ID);
                            if (frmItemSetPriceDiscount.ShowDialog() == DialogResult.OK)
                            {
                                //row["Group6"] = cls_Data.GetSetPriceByItem(ID);
                                SetUpdateDataFocus(6);
                                UpdateItemData();
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void LinkMenu(cls_Struct.MenuItem type)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            DataSet dsVoucher = new DataSet();
            try
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();
                switch (type)
                {
                    case cls_Struct.MenuItem.PO:
                        ID = cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.PO);
                        if (ID <= 0)
                        {
                            MessageBox.Show("ไม่มีใบสั่งซื้อที่สถานะ Active" + Environment.NewLine, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dsVoucher = cls_Data.GetPOById(ID);
                        frm_PODetailInput frmPO = new frm_PODetailInput();
                        frmPO.SetEditData = row;
                        frmPO.DataID = ID;
                        frmPO.SetDatasetEdit = dsVoucher;
                        frmPO.SetListNo = AssigNo(cls_Struct.VoucherType.PO, dsVoucher);
                        frmPO.InitialDialog(cls_Struct.ActionMode.Add);
                        frmPO.Text = "รายละเอียด PO ของสินค้า [เพิ่ม]";
                            frmPO.spinQTY.Select();
                        if (frmPO.ShowDialog() == DialogResult.OK)
                        {
                            //UpdateItemData();
                            SetUpdateDataFocus(1);
                            SetUpdateDataFocus(2);
                            SetUpdateDataFocus(3);
                            SetUpdateDataFocus(4);
                            SetUpdateDataFocus(5);
                            SetUpdateDataFocus(6);
                            SetUpdateDataFocus(7);
                            UpdateItemData();
                            //SetDataFocus();
                        }
                        break;
                    case cls_Struct.MenuItem.RC:
                    ID = cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.RC);
                    if (ID <= 0)
                    {
                        MessageBox.Show("ไม่มีใบ RC ที่สถานะ Active" + Environment.NewLine, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dsVoucher = cls_Data.GetRCById(ID);
                    frm_RCDetailInput frmRC = new frm_RCDetailInput();
                    frmRC.SetEditData = row;
                    frmRC.DataID = ID;
                    frmRC.SetDatasetEdit = dsVoucher;
                    frmRC.SetListNo = AssigNo(cls_Struct.VoucherType.RC, dsVoucher);
                    frmRC.InitialDialog(cls_Struct.ActionMode.Add);
                    frmRC.Text = "รายละเอียด RC ของสินค้า [เพิ่ม]";
                    if (frmRC.ShowDialog() == DialogResult.OK)
                    {
                            SetUpdateDataFocus(1);
                            SetUpdateDataFocus(2);
                            SetUpdateDataFocus(3);
                            SetUpdateDataFocus(4);
                            SetUpdateDataFocus(5);
                            SetUpdateDataFocus(6);
                            SetUpdateDataFocus(7);
                            UpdateItemData();
                            //SetDataFocus();
                    }
                    break;
                    case cls_Struct.MenuItem.JOB:
                        ID = cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.JOB);
                        if (ID <= 0)
                        {
                            MessageBox.Show("ไม่มีใบ JOB ที่สถานะ Active" + Environment.NewLine, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dsVoucher = cls_Data.GetJOBById(ID);
                        frm_JOBDetailInput frmJOB = new frm_JOBDetailInput();
                        frmJOB.SetEditData = row;
                        frmJOB.SetDatasetEdit = dsVoucher;
                        frmJOB.DataID = ID;
                        frmJOB.SetListNo = AssigNo(cls_Struct.VoucherType.JOB, dsVoucher);
                        frmJOB.InitialDialog(cls_Struct.ActionMode.Add);
                            frmJOB.Text = "รายละเอียด Job ของสินค้า [เพิ่ม]";
                            frmJOB.ShowDialog();
                        break;
                    case cls_Struct.MenuItem.RO:
                        //ID = cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.RO);
                        //if (ID <= 0) return;
                        //dsVoucher = cls_Data.GetROById(ID);
                        //frm_RODetailInput frmRO = new frm_RODetailInput();
                        //frmRO.SetEditData = row;
                        //frmRO.DataID = ID;
                        //frmRO.SetDatasetEdit = dsVoucher;
                        //frmRO.SetListNo = AssigNo(cls_Struct.VoucherType.RO, dsVoucher);
                        //frmRO.InitialDialog(cls_Struct.ActionMode.Add);
                        //frmRO.ShowDialog();

                        //ID = cls_Library.DBInt(row["ITEM_ID"]);  //Header
                        //dsVoucher = cls_Data.GetRCRemarkById(ID);
                        //if (dsVoucher.Tables["RCDETAIL"].Rows.Count <=0)
                        //{
                        //    MessageBox.Show("ไม่มีสินค้าที่ Mark" + Environment.NewLine, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}

                        ID = cls_Library.DBInt(row["RCD_PID"]);  //Header
                        if (ID <= 0)
                        {
                            MessageBox.Show("ไม่มีสินค้าที่ Mark" + Environment.NewLine, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dsVoucher = cls_Data.GetRCById(ID);
                        frm_RODetailInput frmRO = new frm_RODetailInput();
                        frmRO.SetEditData = row;
                        frmRO.DataID = cls_Library.DBInt(row["RCD_ID"]);  //Detail
                        frmRO.SetDatasetEdit = dsVoucher;
                        frmRO.SetListNo = 0;
                        frmRO.Text = "สินค้าสำหรับบันทึกการส่งออก [เพิ่ม]";
                        frmRO.InitialDialog(cls_Struct.ActionMode.Other);
                        if (frmRO.ShowDialog() == DialogResult.OK)
                        {
                            //SetDataFocus();
                            //SetUpdateDataFocus(1);
                            //SetUpdateDataFocus(2);
                            //SetUpdateDataFocus(3);
                            //SetUpdateDataFocus(4);
                            //SetUpdateDataFocus(5);
                            //SetUpdateDataFocus(6);
                            //SetUpdateDataFocus(7);
                            UpdateItemDataRO();
                        }
                        break;
                    case cls_Struct.MenuItem.PJOB:
                        ID = cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.PJOB);
                        ID = cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.JOB);
                        if (ID <= 0)
                        {
                            MessageBox.Show("ไม่มีใบ Packing JOB ที่สถานะ Active" + Environment.NewLine, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dsVoucher = cls_Data.GetPJOBById(ID);
                        frm_PJDetailInput frmPJOB = new frm_PJDetailInput();
                        frmPJOB.SetEditData = row;
                        frmPJOB.SetDatasetEdit = dsVoucher;
                        frmPJOB.DataID = ID;
                        frmPJOB.SetListNo = AssigNo(cls_Struct.VoucherType.PJOB, dsVoucher);
                        frmPJOB.InitialDialog(cls_Struct.ActionMode.Add);
                        frmPJOB.ShowDialog();
                        break;
                    case cls_Struct.MenuItem.hPO:
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_HistoryPO frmHisPO = new frm_HistoryPO(ID);
                        frmHisPO.ItemName = cls_Library.DBString(row["ITEM_CODE"]);
                        frmHisPO.ShowDialog();
                        break;
                        case cls_Struct.MenuItem.hRC:
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_HistoryRC frmHisRC = new frm_HistoryRC(ID);
                        frmHisRC.ItemName = cls_Library.DBString(row["ITEM_CODE"]);
                        frmHisRC.ShowDialog();
                        break;
                    case cls_Struct.MenuItem.hJOB:
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_HistoryJOB frmHisjJob = new frm_HistoryJOB(ID);
                        frmHisjJob.ItemName = cls_Library.DBString(row["ITEM_CODE"]);
                        frmHisjJob.ShowDialog();
                        break;
                    case cls_Struct.MenuItem.hRO:
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_HistoryRO frmHisRO = new frm_HistoryRO(ID);
                        frmHisRO.ItemName = cls_Library.DBString(row["ITEM_CODE"]);
                        frmHisRO.ShowDialog();
                        break;
                    case cls_Struct.MenuItem.hSO:
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_HistorySO frmHisSO = new frm_HistorySO(ID);
                        frmHisSO.ItemName = cls_Library.DBString(row["ITEM_CODE"]);
                        frmHisSO.ShowDialog();
                        break;

                    case cls_Struct.MenuItem.SQ:
                        ID = cls_Data.CheckActiveVoucher(cls_Struct.VoucherType.SQ);
                        if (ID <= 0)
                        {
                            MessageBox.Show("ไม่มีใบ SQ ที่สถานะ Active" + Environment.NewLine, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dsVoucher = cls_Data.GetSQById(ID);
                        frm_SQDetailInput frmSQ = new frm_SQDetailInput();
                        frmSQ.SetEditData = row;
                        frmSQ.DataID = ID;
                        frmSQ.SetDatasetEdit = dsVoucher;
                        frmSQ.SetListNo = AssigNo(cls_Struct.VoucherType.SQ, dsVoucher);
                        frmSQ.InitialDialog(cls_Struct.ActionMode.Add);
                        frmSQ.Text = "รายละเอียด SQ ของสินค้า [เพิ่ม]";
                        frmSQ.txtBrand.Select();
                        if (frmSQ.ShowDialog() == DialogResult.OK)
                        {
                            UpdateItemData();
                            //SetDataFocus();
                        }
                        break;
                    case cls_Struct.MenuItem.hSQ:
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_HistorySQ frmHisSQ = new frm_HistorySQ(ID);
                        frmHisSQ.ItemName = cls_Library.DBString(row["ITEM_CODE"]);
                        frmHisSQ.ShowDialog();
                        break;
                    case cls_Struct.MenuItem.hSOH:
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_HistoryStock frmHisSOH = new frm_HistoryStock(ID);
                        frmHisSOH.ItemName = cls_Library.DBString(row["ITEM_CODE"]);
                        frmHisSOH.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            MessageBox.Show("LinkMenu type: " + type + " :" + ex.Message);
            }
        }

        private void LoadData()
        {            
            dsData = cls_Data.GetDataInitial();     //XXXXXXXXXXXXXX
        }

        private void SetControl()
        {
            dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            //cls_Library.AssignSearchLookUp(sluCustomer, "M_CUSTOMERS", "รหัสลูกค้า", "ชื่อลูกค้า");

            //comboItemSearch.Properties.Items.Add("สินค้า Mark          F2");
            comboItemSearch.Properties.Items.Add("สินค้า แบบที่ 1    F2");
            comboItemSearch.Properties.Items.Add("สินค้า แบบที่ 2    F3");
            comboItemSearch.Properties.Items.Add("สินค้า แบบที่ 3    F4");
            //comboItemSearch.Properties.Items.Add("สินค้า แบบที่4        F8");

            SortType = 0;

            comboSort.Properties.Items.Add("ชื่อย่อ");
            comboSort.Properties.Items.Add("ชื่อเต็ม");
            comboSort.Properties.Items.Add("รหัสสินค้า");
            comboSort.Properties.Items.Add("หมายเลขอะไหล่แท้");
            comboSort.Properties.Items.Add("หมายเลขอะไหล่ผู้ผลิต");
            comboSort.Properties.Items.Add("ประเภทขนาดสินค้า + ด้านนอก");
            comboSort.Properties.Items.Add("ประเภทขนาดสินค้า + สูง");
            comboSort.Properties.Items.Add("ประเภทขนาดสินค้า + ด้านใน");

            comboSort.SelectedIndex = 0;


            sluCustomer.Properties.DataSource = dsData.Tables["M_CUSTOMERS"];
            sluCustomer.Refresh();
            sluCustomer.Properties.PopulateViewColumns();
            sluCustomer.Properties.View.Columns["_id"].Visible = false;
            sluCustomer.Properties.View.Columns["code"].Caption = "รหัสลูกค้า";
            sluCustomer.Properties.View.Columns["name"].Caption = "ชื่อลูกค้า";

            sluCustomer.Properties.ValueMember = "_id";
            sluCustomer.Properties.DisplayMember = "code";            
        }

        private void SetDataFocus()
        {
            DataRow row = cvItem.GetFocusedDataRow();
            
            if (row == null)
            {
                return;
            }
            else
            {
                //2023-03-26
                dtVG = dtShow.Clone();
                //dtVG.ImportRow(row);
                vGridItem.DataSource = dtVG;
                vGridItem.RefreshDataSource();
            }
            //return;
            string strBasePath = Application.StartupPath + "\\Photos";
            try
            {
                FocusRowchangeOK = false;
                if (row == null)
                {
                    ClearControl();
                    return;
                }

                cvItem.BeginInit();
               
                //dtVG = dtShow.Clone();
                //dtVG.ImportRow(row);
                //vGridItem.DataSource = dtVG;
                //vGridItem.RefreshDataSource();

                spinH.EditValue = cls_Library.DBDecimal(row["MAXIMUM_QTY"]);
                spinL.EditValue = cls_Library.DBDecimal(row["MINIMUM_QTY"]);
                spinUse.EditValue = cls_Library.DBInt(row["QTY"]);
                spinSell.EditValue = cls_Library.DBDecimal(row["MINIMUM_SALE_QTY"]);
                spinBuy.EditValue = cls_Library.DBDecimal(row["MINIMUM_ORDER_QTY"]);
                txtCode.Text = cls_Library.DBString(row["SIZE_CODE"]) + " " + row["SIZE_NAME"].ToString();
                txtOut.Text = row["SIZE_OUTSIDE"].ToString();
                txtIn.Text = row["SIZE_INNER"].ToString();
                txtThick.Text = row["SIZE_THICK"].ToString();

                spinNumwait.EditValue = cls_Library.DBDouble(row["DEFECT_QTY"]);

                //Piak 2022-12-25
                //if (searchType ==2)
                //{
                //    row["Marktrans"] = cls_Library.DBDecimal(row["QTY_MARK"]) - cls_Library.DBDecimal(row["QTY_RETURN"]);
                //}
                //else
                //{
                //    row["Marktrans"] = cls_Data.GetMarkTransData(cls_Library.DBInt(row["ITEM_ID"]));
                //}
                row["Marktrans"] = cls_Library.DBDecimal(row["QTY_MARK"]) - cls_Library.DBDecimal(row["QTY_RETURN"]);
                row["Quotrans"] = cls_Data.GetLastSQData(cls_Library.DBInt(row["ITEM_ID"]));
                row["POtrans"] = cls_Data.GetLastPOData(cls_Library.DBInt(row["ITEM_ID"]));
                dtVG = dtShow.Clone();
                dtVG.ImportRow(row);
                vGridItem.DataSource = dtVG;
                vGridItem.RefreshDataSource();
                //ตรวจสอบ stock on hand
                double GetOnh = cls_Data.GetBalanceStockOnhand(cls_Library.DBInt(row["ITEM_ID"]));
                if (GetOnh > cls_Library.DBDouble(row["MINIMUM_QTY"])) row["POtrans"] = "";

                //PIAK
                //spinNumStock.EditValue = cls_Data.GetSumRCquantity(cls_Library.DBInt(row["ITEM_ID"]));
                spinNumStock.EditValue = Math.Round(GetOnh, 0);
                spinNumwait.EditValue = cls_Data.GetSumRCreturnquantity(cls_Library.DBInt(row["ITEM_ID"]));
                spinNumStockVat.EditValue = cls_Data.GetSumRCquantity(cls_Library.DBInt(row["ITEM_ID"]), true);
                DateTime Sdate = cls_Data.GetDateLastRCData(cls_Library.DBInt(row["ITEM_ID"]));
                if (cls_Library.IsDate(Sdate))
                {
                    if ((Sdate == DateTime.MaxValue) || (Sdate == DateTime.MinValue))
                    {
                        dateMoveStock.Text = "";
                    }
                    else
                    {
                        dateMoveStock.Text = Sdate.ToShortDateString();
                    }
                }

                DataTable dt;

                txtStock.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEM_LOCATIONS", "LOCATION_NAME");
                //txtStock.Text = row["LOCATION_NAME"].ToString();



                if ((cls_Library.DBDateTime(row["COUNTING_DATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["COUNTING_DATE"]) == DateTime.MaxValue))
                    dateStock.Text = "";
                else
                    dateStock.DateTime = cls_Library.DBDateTime(row["COUNTING_DATE"]);
                if ((cls_Library.DBDateTime(row["MINIMUM_DATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["MINIMUM_DATE"]) == DateTime.MaxValue))
                    dateMoveStock.Text = "";
                else
                    dateMoveStock.DateTime = cls_Library.DBDateTime(row["MINIMUM_DATE"]);

                txtBrand.Text = row["BRAND_CODE"].ToString() + " " + row["BRAND_NAME"].ToString();   //Join
                chkSearch.EditValue = cls_Library.DBbool(row["DISPLAY_HIDING_STATUS"]);
                chkSet.EditValue = cls_Library.DBbool(row["SET_STATUS"]);
                chkComponent.EditValue = cls_Library.DBbool(row["COMPONENT_STATUS"]);
                chkBarcode.EditValue = cls_Library.DBbool(row["BARCODE_STATUS"]);       //XXX เพิ่มฟิลด์ BARCODE_STATUS

                


                ////Image
                pictureDisplay.Image = null;
                object PICTURE_IMAGE = null;
                PICTURE_IMAGE = cls_Data.GetByteFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEM_PICTURES", "PICTURE_IMAGE");
                if (PICTURE_IMAGE != null)
                {
                    var picbyte = (Byte[])(PICTURE_IMAGE);
                    var stream = new MemoryStream(picbyte);
                    pictureDisplay.Image = Image.FromStream(stream);
                }

                //เอกสาร
                txtDocNo.Text = cls_Library.DBString(row["INV_NO"]);
                dateDoc.Text = "";

                if (cls_Library.IsDate(cls_Library.DBString(row["INV_DATE"])))
                {
                    dateDoc.DateTime = cls_Library.DBDateTime(row["INV_DATE"]);
                }

                txtDocData.Text = "";
                if (cls_Library.DBInt(row["VAT_STATUS"]) > 0)
                {
                    txtDocData.Text = " DO " + GetVatStatus(cls_Library.DBByte(row["VAT_STATUS"])) ;
                }


                //ราคาต้นทุนซื้อหลังสุด,ราคาต้นทุนเฉลี่ย
                spinCostLast.EditValue = 0;
                spinCostbfLast.EditValue = 0;
                spinCostAvg.EditValue = 0;
                spinCostAfVat.EditValue = 0;

                //PIAK
                dt = cls_Data.GetCostLastRCData(cls_Library.DBInt(row["ITEM_ID"]));
                if (dt.Rows.Count > 0)
                {
                    spinCostLast.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["CostLast"]), 2);
                    spinCostbfLast.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["CostBFLast"]), 2);
                    spinCostAvg.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["CostAverage"]), 2);
                    spinCostAfVat.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["CostLastNovat"]), 2);
                }

                //ราคาต่ำสุดในรอบปี
                spinCostOneYear.EditValue = Math.Round(cls_Data.GetCostMinRCData(cls_Library.DBInt(row["ITEM_ID"])), 2);

                //ราคาตั้งใหม่
                spinNewPrice.EditValue = 0;
                datePrice.Text = "";
                dt = cls_Data.GetListPriceListByItemID(cls_Library.DBInt(row["ITEM_ID"]));
                if (dt.Rows.Count > 0)
                {
                    spinNewPrice.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["NEW_PRICE"]), 2);
                    datePrice.DateTime = cls_Library.DBDateTime(dt.Rows[0]["NEW_DATE"]);
                }

                //หาส่วนลด
                GetDisCount(cls_Library.DBInt(row["BRAND_ID"]));

                //if (string.IsNullOrEmpty(row["PICTURE_IMAGE"].ToString()))
                //{
                //    picItem.Image = null;
                //}
                //else
                //{
                //    var picbyte = (Byte[])(row["PICTURE_IMAGE"]);
                //    MemoryStream MemoryStreamData = new MemoryStream(picbyte);
                //    Image image = System.Drawing.Image.FromStream(MemoryStreamData);
                //    image.Save(strBasePath + "\\" + cls_Library.DBString(row["PICTURE_IMAGE"]));
                //    picItem.Image = image;
                //}



                //สินค้าใช้ด้วยกัน
                if (!SelectJoin)
                {
                    dtJoin = GetGroupItemData(2, cls_Library.DBInt(row["ITEM_ID"]));
                    gridJoin.DataSource = dtJoin;
                    gridJoin.RefreshDataSource();
                    //////gvJoin.OptionsSelection.EnableAppearanceFocusedCell = false;
                    //////gvJoin.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                }

                if (!SelectReplace)
                {
                    //สินค้าใช้แทนกัน
                    dtReplace = GetGroupItemData(1, cls_Library.DBInt(row["ITEM_ID"]));
                    gridReplace.DataSource = dtReplace;
                    gridReplace.RefreshDataSource();
                    //////gvReplace.OptionsSelection.EnableAppearanceFocusedCell = false;
                    //////gvReplace.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                }


                if (!SelectVersatile)
                {
                    //สินค้าอเนอกประสงค์
                    dtVersatile = GetGroupVersatileData(cls_Library.DBInt(row["ITEM_ID"]));
                    gridVersatile.DataSource = dtVersatile;
                    gridVersatile.RefreshDataSource();
                    //////gvVersatile.OptionsSelection.EnableAppearanceFocusedCell = false;
                    //////gvVersatile.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                }

                cvItem.EndInit();


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SetDataFocus(DataRow row)
        {
            //DataRow row = cvItem.GetFocusedDataRow();
            if (row == null)
            {
                return;
            }
            else
            {
                //2023-03-26
                dtVG = dtShow.Clone();
                //dtVG.ImportRow(row);
                vGridItem.DataSource = dtVG;
                vGridItem.RefreshDataSource();
            }
            //return;
            string strBasePath = Application.StartupPath + "\\Photos";
            try
            {
                FocusRowchangeOK = false;
                if (row == null)
                {
                    ClearControl();
                    return;
                }

                cvItem.BeginInit();

                //dtVG = dtShow.Clone();
                //dtVG.ImportRow(row);
                //vGridItem.DataSource = dtVG;
                //vGridItem.RefreshDataSource();

                spinH.EditValue = cls_Library.DBDecimal(row["MAXIMUM_QTY"]);
                spinL.EditValue = cls_Library.DBDecimal(row["MINIMUM_QTY"]);
                spinUse.EditValue = cls_Library.DBInt(row["QTY"]);
                spinSell.EditValue = cls_Library.DBDecimal(row["MINIMUM_SALE_QTY"]);
                spinBuy.EditValue = cls_Library.DBDecimal(row["MINIMUM_ORDER_QTY"]);
                txtCode.Text = cls_Library.DBString(row["SIZE_CODE"]) + " " + row["SIZE_NAME"].ToString();
                txtOut.Text = row["SIZE_OUTSIDE"].ToString();
                txtIn.Text = row["SIZE_INNER"].ToString();
                txtThick.Text = row["SIZE_THICK"].ToString();

                spinNumwait.EditValue = cls_Library.DBDouble(row["DEFECT_QTY"]);

                //Piak 2022-12-25
                //if (searchType == 2)
                //{
                //    row["Marktrans"] = cls_Library.DBDecimal(row["QTY_MARK"]) - cls_Library.DBDecimal(row["QTY_RETURN"]);
                //}
                //else
                //{
                //    row["Marktrans"] = cls_Data.GetMarkTransData(cls_Library.DBInt(row["ITEM_ID"]));
                //} 
                row["Marktrans"] = cls_Library.DBDecimal(row["QTY_MARK"]) - cls_Library.DBDecimal(row["QTY_RETURN"]);
                row["Quotrans"] = cls_Data.GetLastSQData(cls_Library.DBInt(row["ITEM_ID"]));
                row["POtrans"] = cls_Data.GetLastPOData(cls_Library.DBInt(row["ITEM_ID"]));
                dtVG = dtShow.Clone();
                dtVG.ImportRow(row);
                vGridItem.DataSource = dtVG;
                vGridItem.RefreshDataSource();
                //ตรวจสอบ stock on hand
                double GetOnh = cls_Data.GetBalanceStockOnhand(cls_Library.DBInt(row["ITEM_ID"]));
                if (GetOnh > cls_Library.DBDouble(row["MINIMUM_QTY"])) row["POtrans"] = "";

                //PIAK
                //spinNumStock.EditValue = cls_Data.GetSumRCquantity(cls_Library.DBInt(row["ITEM_ID"]));
                spinNumStock.EditValue = Math.Round(GetOnh,0);
                spinNumwait.EditValue = cls_Data.GetSumRCreturnquantity(cls_Library.DBInt(row["ITEM_ID"]));
                spinNumStockVat.EditValue = cls_Data.GetSumRCquantity(cls_Library.DBInt(row["ITEM_ID"]), true);
                DateTime Sdate = cls_Data.GetDateLastRCData(cls_Library.DBInt(row["ITEM_ID"]));
                if (cls_Library.IsDate(Sdate))
                {
                    if ((Sdate == DateTime.MaxValue) || (Sdate == DateTime.MinValue))
                    {
                        dateMoveStock.Text = "";
                    }
                    else
                    {
                        dateMoveStock.Text = Sdate.ToShortDateString();
                    }
                }

                DataTable dt;

                txtStock.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEM_LOCATIONS", "LOCATION_NAME");
                //txtStock.Text = row["LOCATION_NAME"].ToString();



                if ((cls_Library.DBDateTime(row["COUNTING_DATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["COUNTING_DATE"]) == DateTime.MaxValue))
                    dateStock.Text = "";
                else
                    dateStock.DateTime = cls_Library.DBDateTime(row["COUNTING_DATE"]);
                if ((cls_Library.DBDateTime(row["MINIMUM_DATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["MINIMUM_DATE"]) == DateTime.MaxValue))
                    dateMoveStock.Text = "";
                else
                    dateMoveStock.DateTime = cls_Library.DBDateTime(row["MINIMUM_DATE"]);

                txtBrand.Text = row["BRAND_CODE"].ToString() + " " + row["BRAND_NAME"].ToString();   //Join
                chkSearch.EditValue = cls_Library.DBbool(row["DISPLAY_HIDING_STATUS"]);
                chkSet.EditValue = cls_Library.DBbool(row["SET_STATUS"]);
                chkComponent.EditValue = cls_Library.DBbool(row["COMPONENT_STATUS"]);
                chkBarcode.EditValue = cls_Library.DBbool(row["BARCODE_STATUS"]);       //XXX เพิ่มฟิลด์ BARCODE_STATUS

                //หาส่วนลด
                GetDisCount(cls_Library.DBInt(row["BRAND_ID"]));


                ////Image
                pictureDisplay.Image = null;
                object PICTURE_IMAGE = null;
                PICTURE_IMAGE = cls_Data.GetByteFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEM_PICTURES", "PICTURE_IMAGE");
                if (PICTURE_IMAGE != null)
                {
                    var picbyte = (Byte[])(PICTURE_IMAGE);
                    var stream = new MemoryStream(picbyte);
                    pictureDisplay.Image = Image.FromStream(stream);
                }

                //เอกสาร
                txtDocNo.Text = cls_Library.DBString(row["INV_NO"]);
                dateDoc.Text = "";

                if (cls_Library.IsDate(cls_Library.DBString(row["INV_DATE"])))
                {
                    dateDoc.DateTime = cls_Library.DBDateTime(row["INV_DATE"]);
                }

                txtDocData.Text = "";
                if (cls_Library.DBInt(row["VAT_STATUS"]) > 0)
                {
                    txtDocData.Text = " DO " + GetVatStatus(cls_Library.DBByte(row["VAT_STATUS"]));
                }


                //ราคาต้นทุนซื้อหลังสุด,ราคาต้นทุนเฉลี่ย
                spinCostLast.EditValue = 0;
                spinCostbfLast.EditValue = 0;
                spinCostAvg.EditValue = 0;
                spinCostAfVat.EditValue = 0;

                //PIAK
                //////dt = cls_Data.GetCostLastRCData(cls_Library.DBInt(row["ITEM_ID"]));
                //////if (dt.Rows.Count > 0)
                //////{
                //////    spinCostLast.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["CostLast"]), 2);
                //////    spinCostbfLast.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["CostBFLast"]), 2);
                //////    spinCostAvg.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["CostAverage"]), 2);
                //////    spinCostAfVat.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["CostLastNovat"]), 2);
                //////}

                //ราคาต่ำสุดในรอบปี
                spinCostOneYear.EditValue = Math.Round(cls_Data.GetCostMinRCData(cls_Library.DBInt(row["ITEM_ID"])), 2);

                //ราคาตั้งใหม่
                spinNewPrice.EditValue = 0;
                datePrice.Text = "";
                dt = cls_Data.GetListPriceListByItemID(cls_Library.DBInt(row["ITEM_ID"]));
                if (dt.Rows.Count > 0)
                {
                    spinNewPrice.EditValue = Math.Round(cls_Library.DBDecimal(dt.Rows[0]["NEW_PRICE"]), 2);
                    datePrice.DateTime = cls_Library.DBDateTime(dt.Rows[0]["NEW_DATE"]);
                }

                //if (string.IsNullOrEmpty(row["PICTURE_IMAGE"].ToString()))
                //{
                //    picItem.Image = null;
                //}
                //else
                //{
                //    var picbyte = (Byte[])(row["PICTURE_IMAGE"]);
                //    MemoryStream MemoryStreamData = new MemoryStream(picbyte);
                //    Image image = System.Drawing.Image.FromStream(MemoryStreamData);
                //    image.Save(strBasePath + "\\" + cls_Library.DBString(row["PICTURE_IMAGE"]));
                //    picItem.Image = image;
                //}



                //สินค้าใช้ด้วยกัน
                if (!SelectJoin)
                {
                    dtJoin = GetGroupItemData(2, cls_Library.DBInt(row["ITEM_ID"]));
                    gridJoin.DataSource = dtJoin;
                    gridJoin.RefreshDataSource();
                    //////gvJoin.OptionsSelection.EnableAppearanceFocusedCell = false;
                    //////gvJoin.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                }

                if (!SelectReplace)
                {
                    //สินค้าใช้แทนกัน
                    dtReplace = GetGroupItemData(1, cls_Library.DBInt(row["ITEM_ID"]));
                    gridReplace.DataSource = dtReplace;
                    gridReplace.RefreshDataSource();
                    //////gvReplace.OptionsSelection.EnableAppearanceFocusedCell = false;
                    //////gvReplace.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                }


                if (!SelectVersatile)
                {
                    //สินค้าอเนอกประสงค์
                    dtVersatile = GetGroupVersatileData(cls_Library.DBInt(row["ITEM_ID"]));
                    gridVersatile.DataSource = dtVersatile;
                    gridVersatile.RefreshDataSource();
                    //////gvVersatile.OptionsSelection.EnableAppearanceFocusedCell = false;
                    //////gvVersatile.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                }

                cvItem.EndInit();


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Setgrid()
        {
            //cvItem.OptionsView.RowAutoHeight = true;
            //MemoEdit1.AutoHeight = true;
            //MemoEdit1.WordWrap = true;

        }

        private void SetSubMenu()
        {
            layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            switch (MainSearch)
            {
            case 0:
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                gridItem.Select();
                break;
            case 1:
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                BTsub1.Text = "(F2) PO";
                BTsub2.Text = "(F3) Quotation พ่อค้า";
                BTsub3.Text = "(F5) RC";
                BTsub4.Text = "(F6) Out Ward";
                BTsub5.Text = "(F7) JOB";
                //BTsub6.Text = "(F8) Packing JOB";
                BTsub7.Text = "(F9) ขาย";
                BTsub8.Text = "(F11) Quotation ลูกค้า";
                BTsub9.Text = "(F12) In Ward";

                BTsub1.Select();
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                break;
        
            case 2:
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                BTsub1.Text = "(F2) ราคาขาย";
                BTsub2.Text = "(F3) ยี่ห้อสินค้า";
                BTsub3.Text = "(F5) ปริมาณต่ำสุด/สูงสุด";
                BTsub4.Text = "(F6) กลุ่มสั่งซื้อ";
                BTsub5.Text = "(F7) ชื่อย่อ/ชื่อเต็ม";
                BTsub6.Text = "(F8) Price list";
                BTsub7.Text = "(F9) รหัสสินค้าเต็มรูป";
                BTsub8.Text = "";
                BTsub9.Text = "";

                BTsub1.Select();
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                break;
            case 3:
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                BTsub1.Text = "(F2) หมวดหมู่สินค้า";
                BTsub2.Text = "(F3) คลังสินค้า";
                BTsub3.Text = "(F5) Barcode ผู้ผลิต";
                BTsub4.Text = "(F6) เลขอะไหล่ทดแทน";
                BTsub5.Text = "(F7) Stock on hand";
                BTsub6.Text = "(F8) ประเภทขนาด";
                BTsub7.Text = "(F9) Under stock";
                BTsub8.Text = "(F11) พิมพ์ barcode";
                BTsub9.Text = "";

                BTsub1.Select();
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                break;
            case 4:
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;


                BTsub1.Text = "(F2) สินค้าใช้ด้วยกัน";
                BTsub2.Text = "(F3) สินค้าใช้แทนกัน";
                BTsub3.Text = "(F5) สินค้าเอนกประสงค์";
                BTsub4.Text = "";
                BTsub5.Text = "";
                BTsub6.Text = "";
                BTsub7.Text = "";
                BTsub8.Text = "";
                BTsub9.Text = "";

                BTsub1.Select();
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                break;
            }
            
        }

        private void SetUpdateDataFocus(int sGroup)
        {
            DataRow row = cvItem.GetFocusedDataRow();
            if (row == null) return;
            //return;
            string sData = "";
            int vatType = 0;
            string sVatType = "";
            string NL = Environment.NewLine;
            try
            {
                FocusRowchangeOK = false;
                if (row == null) return;

                cvItem.BeginInit();

                vatType = 0;

                switch (sGroup)
                {
                    case 1:
                        vatType = cls_Library.DBInt(cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "BRAND_ID"));
                        sData = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "ITEM_CODE")  + NL + NL + cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "ABBREVIATE_NAME") + NL + NL + cls_Data.GetNameFromTBname(vatType, "BRANDS", "BRAND_NAME");
                        row["Group1"] = sData;
                        break;
                    case 2:                      
                        sData = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "GENUIN_PART_ID")  + NL + NL + cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "BRAND_PART_ID") + NL + NL + cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "FULL_NAME");
                        row["Group2"] = sData;
                        break;
                    case 3:
                        sData = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "MODEL1") + NL + NL + cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "MODEL2") + NL + NL + cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "MODEL3");
                        row["Group3"] = sData;
                        break;
                    case 4:
                        sData = cls_Library.DBDecimal(cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "VW_RCAll", "PriceSet")).ToString("#,###,##0") + NL + NL + cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "VW_RCAll", "PriceDiscount") + NL + NL + cls_Library.DBDecimal(cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "VW_RCAll", "PriceNet")).ToString("#,###,##0");
                        row["Group4"] = sData;
                        break;
                    case 5:
                        vatType = cls_Library.DBInt(cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "T_LASTRECRC", "VATTYPE"));
                        switch (vatType)
                        {
                            case 0:
                                sVatType = "";
                                break;
                            case 1:
                                sVatType = "VAT ใน";
                                break;
                            case 2:
                                sVatType = "VAT นอก";
                                break;
                            default:
                                sVatType = "ไม่มี VAT";
                                break;
                        }
                        string LastPO = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "T_LASTRECPO", "T_DATE");
                        string DateLastPO = "";
                        if (cls_Library.IsDate(LastPO))
                        {
                            DateLastPO = cls_Library.DBDateTime(LastPO).ToShortDateString();
                        }
                        sData = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "T_LASTRECPO", "T_CODE") + NL + NL + DateLastPO + NL + NL + sVatType;
                        row["Group5"] = sData;
                        break;
                    case 6:
                        sData = cls_Data.GetSetPriceByItem(cls_Library.DBInt(row["ITEM_ID"]));
                        //sData = cls_Library.DBString(row["MODEL1"]) + NL + NL + cls_Library.DBString(row["MODEL2"]) + NL + NL + cls_Library.DBString(row["MODEL3"]);
                        //DataTable dt = cls_Data.GetPriceListByItem(ItemID, cls_Library.DBInt(row["UNIT_ID"]), 2);
                        //DateTime DATENET = DateTime.MinValue;
                        //string sDATENET = "";
                        //string UnitName = "";
                        //decimal Price1 = 0;
                        //decimal Price2 = 0; 
                        //string sPrice1 = "";
                        //string sPrice2 = "";
                        //if (dt.Rows.Count > 0)
                        //{
                        //    Price1 = cls_Library.DBDecimal(dt.Rows[0]["PRICE1"]);
                        //    Price2 = cls_Library.DBDecimal(dt.Rows[0]["PRICE2"]);
                        //    DATENET = cls_Library.DBDateTime(dt.Rows[0]["DATENET"]);
                        //    UnitName = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["UNIT_ID"]), "UNITS", "UNIT_NAME");
                        //    int BrandID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemID, "ITEMS", "BRAND_ID"));
                        //    vatType = cls_Library.DBInt(cls_Data.GetNameFromTBname(BrandID, "BRANDS", "CURRENT_VAT_STATUS"));                          
                        //}
                        //if (cls_Library.IsDate(DATENET))
                        //{
                        //    sDATENET = DATENET.ToShortDateString();
                        //}
                        //if (vatType == 1) Price1 = Math.Round(Price1 + (Price1 * cls_Library.DBDecimal(0.07)), 2);
                        //if (vatType == 1) Price2 = Math.Round(Price2 + (Price2 * cls_Library.DBDecimal(0.07)), 2);
                        //if (Price1 > 0) sPrice1 = Price1.ToString("#,##0.00");
                        //if (Price2 > 0) sPrice2 = Price2.ToString("#,##0.00");
                        //sData = UnitName + NL + NL + DATENET + NL + NL + sPrice1 + "    " + sPrice2;
                        row["Group6"] = sData;
                        break;
                    case 7:
                        //sData = cls_Library.DBString(row["MODEL1"]) + NL + NL + cls_Library.DBString(row["MODEL2"]) + NL + NL + cls_Library.DBString(row["MODEL3"]);
                        //row["Group7"] = sData;
                        break;
                }
                cvItem.EndInit();


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void UpdateItemData()
        {
            DataRow dr = cvItem.GetFocusedDataRow();
            int iRow = cvItem.FocusedRowHandle;
            if (iRow <= 0)
            {
                //2023-03-26
                //dtVG = dtShow.Clone();
                //vGridItem.DataSource = dtVG;
                //vGridItem.RefreshDataSource();
                //gridItem.DataSource = dtShow;
                //gridItem.RefreshDataSource();
                //return;
            }
            if (dr == null) return;
            DataTable dt = GetItemByID(cls_Library.DBInt(dr["ITEM_ID"]));
            Int64 Rnew = cls_Library.DBInt(dr["RNnew"]);
            dr = dt.Rows[0];

            
            //dr.ItemArray = dt.Rows[0].ItemArray;
            dr["RNnew"] = Rnew;
            dtShow.Rows[iRow].ItemArray = dr.ItemArray;
            cvItem.UpdateCurrentRow();
            dr = cvItem.GetFocusedDataRow();
            if (dr == null) return;
            SetDataFocus(dr);
            gridItem.RefreshDataSource();
        }

        private void UpdateItemDataRO()
        {
            DataRow dr = cvItem.GetFocusedDataRow();
            int iRow = cvItem.FocusedRowHandle;
            if (iRow < 0)
            {
                //2023-03-26
                dtVG = dtShow.Clone();
                vGridItem.DataSource = dtVG;
                vGridItem.RefreshDataSource();
                gridItem.DataSource = dtShow;
                gridItem.RefreshDataSource();
                return;
            }
            if (dr == null) return;
            DataTable dt = GetItemROByID(cls_Library.DBInt(dr["ITEM_ID"]));
            if (dt.Rows.Count <= 0)
            {
                //2023-05-12
                dtVG = dt.Clone();
                vGridItem.DataSource = dtVG;
                vGridItem.RefreshDataSource();
                gridItem.DataSource = dt;
                gridItem.RefreshDataSource();
                return;
            }
            Int64 Rnew = cls_Library.DBInt(dr["RNnew"]);
            dr = dt.Rows[0];


            //dr.ItemArray = dt.Rows[0].ItemArray;
            dr["RNnew"] = Rnew;
            dtShow.Rows[iRow].ItemArray = dr.ItemArray;
            cvItem.UpdateCurrentRow();
            dr = cvItem.GetFocusedDataRow();
            if (dr == null) return;
            SetDataFocus(dr);
            gridItem.RefreshDataSource();
        }
        #endregion

        public frmInput2()
        {
            InitializeComponent();
            this.KeyPreview = true;
            ProcessStartOK = true;

            SplashScreenManager.ShowForm(this, typeof(frm_WaitForm), true, true, false);
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(10);
            }

            SortOrderNum = 0;
            SortType = 1;
            CategorySearch = "002";
            cls_Data.UpdateUnActiveVoucher();

            dtJoin = new DataTable();
            dtReplace = new DataTable();
            dtVersatile = new DataTable();

            InitialDialog();

            cvItem.OptionsBehavior.AllowPixelScrolling = DefaultBoolean.True;
            cvItem.OptionsView.RowAutoHeight = false;
            cvItem.OptionsView.ShowPreview = false;
            cvItem.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            cvItem.CustomDrawCell += CvItem_CustomDrawCell;
            cvItem.CalcRowHeight += CvItem_CalcRowHeight;

            dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            SplashScreenManager.CloseForm();
            //ProductSearch = "";
            //SortType = 1;
            //GetDataChoose(cls_Global_class.ChooseType.Item);
            //gridItem.Select();
            SelectJoin = false;
            SelectReplace = false;
            SelectVersatile = false;

            gvVersatile.GotFocus += GvVersatile_GotFocus;

            gvJoin.LostFocus += GvJoin_LostFocus;
            gvReplace.LostFocus += GvReplace_LostFocus;
            gvVersatile.LostFocus += GvVersatile_LostFocus;

            //FocusRowchangeOK = false;
            //if (gridItem.Visible)
            //{
                FocusRowchangeOK = true;
                SetDataFocus();
                FocusRowchangeOK = false;
            //}

        }

        private void GvVersatile_LostFocus(object sender, EventArgs e)
        {
            SelectVersatile = false;
        }

        private void GvVersatile_GotFocus(object sender, EventArgs e)
        {
            SelectVersatile = true;
        }

        private void GvReplace_LostFocus(object sender, EventArgs e)
        {
            SelectReplace = false;
        }

        private void GvJoin_LostFocus(object sender, EventArgs e)
        {
            SelectJoin = false;
        }

        private void comboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortType = comboSort.SelectedIndex + 1;
            if (SortType < 1) SortType = 1;
            if (SortType > 8) SortType = 1;
            if (ProcessStartOK) return;
            //GetDataChoose(cls_Global_class.ChooseType.Item);
        }

        private void groupJoint_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
            if ((view.FocusedRowHandle < 0)) return;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["ITEM_ID"]);
            frm_Group frmGroup = new frm_Group(2, 1);
            frmGroup.ItemID = ID;
            if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(frmGroup.ProductCode))
                {
                    GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
                }
            }
        }

        private void groupReplace_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
            if ((view.FocusedRowHandle < 0)) return;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["ITEM_ID"]);
            frm_Group frmGroup = new frm_Group(1, 1);
            frmGroup.ItemID = ID;
            if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            if (!string.IsNullOrEmpty(frmGroup.ProductCode))
            {
                GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
            }
            }
        }

        private void gvJoin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (Char)Keys.Enter)
            //{
            //DevExpress.XtraGrid.Views.Grid.GridView view;
            //int ID = 0;
            //view = (DevExpress.XtraGrid.Views.Grid.GridView)gvJoin;
            //if (view.FocusedRowHandle < 0) return;
            //DataRow row = view.GetFocusedDataRow();
            //ID = cls_Library.DBInt(row["GROUP_ID"]);
            //if (ID == 0) return;
            //GetDataChooseGroupJoin(ID);
            //if (dtJoin.Rows.Count > 0)
            //{
            //    uNCoumt++;
            //    AssignArraUndo(uNCoumt);
            //    AssignValueToArraUndo(uNCoumt);
            //}

            //gvJoin.Focus();
            //}

        }

        private void gvReplace_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (Char)Keys.Enter)
            //{
            //DevExpress.XtraGrid.Views.Grid.GridView view;
            //int ID = 0;
            //view = (DevExpress.XtraGrid.Views.Grid.GridView)gvReplace;
            //if (view.FocusedRowHandle < 0) return;
            //DataRow row = view.GetFocusedDataRow();
            //ID = cls_Library.DBInt(row["GROUP_ID"]);
            //if (ID == 0) return;
            //GetDataChooseGroupReplace(ID);
            //if (dtReplace.Rows.Count > 0)
            //{
            //    uNCoumt++;
            //    AssignArraUndo(uNCoumt);
            //    AssignValueToArraUndo(uNCoumt);
            //}

            //}

        }

        private void groupUtility_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
            if ((view.FocusedRowHandle < 0)) return;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["ITEM_ID"]);
            frm_Group_Vers frmGroup = new frm_Group_Vers(1, 1);
            frmGroup.ItemID = ID;
            frmGroup.ShowDialog();
        }

        private void gvVersatile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0;
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvVersatile;
            if (view.FocusedRowHandle < 0) return;
            DataRow row = view.GetFocusedDataRow();
            ID = cls_Library.DBInt(row["SUB_ID"]);
            if (ID == 0) return;
            GetDataChooseGroupVersatile(ID);
            if (dtVersatile.Rows.Count > 0)
            {
                uNCoumt++;
                AssignArraUndo(uNCoumt);
                AssignValueToArraUndo(uNCoumt);
            }
        
            }
        }

        private void gvJoin_DoubleClick(object sender, EventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView view;
            //int ID = 0;
            //view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
            //if ((view.FocusedRowHandle < 0)) return;
            //DataRow row = view.GetFocusedDataRow();
            //ID = cls_Library.DBInt(row["ITEM_ID"]);
            //frm_Group frmGroup = new frm_Group(2, 1);
            //frmGroup.ItemID = ID;     
            //if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //if (!string.IsNullOrEmpty(frmGroup.ProductCode))
            //{
            //    GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
            //}
            //}

            gvJoinSetDataRow();

            gridJoin.Select();
            gvJoin.Focus();
        }

        private void BTsub1_Click(object sender, EventArgs e)
        {
            //F2
            switch (MainSearch)
            {
                case 1:
                    frm_POList frmPO = new frm_POList();
                    frmPO.WindowState = FormWindowState.Maximized;
                    frmPO.ShowDialog();
                    break;
                case 2:
                        LinkEditItem(cls_Struct.TypeEditItem.SetPrice);
                        break;
                case 3:
                    LinkEditItem(cls_Struct.TypeEditItem.T4);
                    break;
                case 4:
                    DevExpress.XtraGrid.Views.Grid.GridView view;
                    int ID = 0;
                    view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                    if ((view.FocusedRowHandle < 0)) return;
                    DataRow row = view.GetFocusedDataRow();
                    ID = cls_Library.DBInt(row["ITEM_ID"]);
                    frm_Group frmGroup = new frm_Group(2, 1);
                    frmGroup.ItemID = ID;
                    if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                    if (!string.IsNullOrEmpty(frmGroup.ProductCode))
                    {
                        GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
                    }
                    }
                    break;
            }
            gridItem.Select();
        }

        private void BTsub2_Click(object sender, EventArgs e)
        {
            //F3
            switch (MainSearch)
            {
            case 1:
                frm_SQList frmSQ = new frm_SQList();
                frmSQ.WindowState = FormWindowState.Maximized;
                frmSQ.ShowDialog();
                break;
            case 2: //ยี่ห้อสินค้า
                LinkEditItem(cls_Struct.TypeEditItem.T2);
                break;
            case 3:
                LinkEditItem(cls_Struct.TypeEditItem.T5);
                break;
            case 4:
                DevExpress.XtraGrid.Views.Grid.GridView view;
                int ID = 0;
                view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();
                ID = cls_Library.DBInt(row["ITEM_ID"]);
                frm_Group frmGroup = new frm_Group(1, 1);
                frmGroup.ItemID = ID;
                if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                if (!string.IsNullOrEmpty(frmGroup.ProductCode))
                {
                    GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
                }
                }
                break;
            }
            gridItem.Select();
        }

        private void BTsub3_Click(object sender, EventArgs e)
        {
            //F5
            switch (MainSearch)
            {
            case 1:
                frm_RCList frmRC = new frm_RCList();
                frmRC.WindowState = FormWindowState.Maximized;
                frmRC.ShowDialog();
                break;
            case 2:
                LinkEditItem(cls_Struct.TypeEditItem.T3);
                break;
            case 3:
                LinkEditItem(cls_Struct.TypeEditItem.T6);
                break;
            case 4:
                DevExpress.XtraGrid.Views.Grid.GridView view;
                int ID = 0;
                view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();
                ID = cls_Library.DBInt(row["ITEM_ID"]);
                //frm_Group_Vers frmGroup = new frm_Group_Vers(1, 1);
                //frmGroup.ItemID = ID;
                //frmGroup.ShowDialog();
                break;
            }

            gridItem.Select();
        }

        private void BTsub4_Click(object sender, EventArgs e)
        {
            //F6
            switch (MainSearch)
            {
            case 1:
                frm_ROList frmRO = new frm_ROList();
                frmRO.WindowState = FormWindowState.Maximized;
                frmRO.ShowDialog();
                break;
            case 2:
                LinkEditItem(cls_Struct.TypeEditItem.T11);
                break;
            case 3:
                LinkEditItem(cls_Struct.TypeEditItem.T7);
                break;
            }
            gridItem.Select();
        }

        private void BTsub5_Click(object sender, EventArgs e)
        {
            //F7
            switch (MainSearch)
            {
            case 1:
                frm_JobList frmJOB = new frm_JobList();
                frmJOB.WindowState = FormWindowState.Maximized;
                frmJOB.Text = "Job list";
                if (frmJOB.ShowDialog() == DialogResult.OK)
                {
                JOBid = frmJOB.Jobid;
                JOBcode = frmJOB.Jobcode;
                JOBdate = frmJOB.Jobdate;
                }
                break;
            case 2:
                LinkEditItem(cls_Struct.TypeEditItem.T10);
                break;
            case 3:
                LinkEditItem(cls_Struct.TypeEditItem.T8);
                break;
            }
            gridItem.Select();
        }

        private void BTsub6_Click(object sender, EventArgs e)
        {
            //F8
            switch (MainSearch)
            {
            case 1:
                //frm_PJList frmJOB = new frm_PJList();
                //frmJOB.WindowState = FormWindowState.Maximized;
                //frmJOB.ShowDialog();
                break;
            case 2:
                DevExpress.XtraGrid.Views.Grid.GridView view;
                int ID = 0;
                view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();
                ID = cls_Library.DBInt(row["ITEM_ID"]);
                frm_ItemPriceList frmItem = new frm_ItemPriceList(ID);
                if (frmItem.ShowDialog() == DialogResult.OK)
                {
                        UpdateItemData();
                    //SetDataFocus();
                }
                break;
            case 3:
                LinkEditItem(cls_Struct.TypeEditItem.T9);
                break;
            }
            gridItem.Select();
        }

        private void BTsub7_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            DataRow row;
            int ID = 0;
            //F9
            switch (MainSearch)
            {
                case 1:
                    InitialDialogFormOpenBill();
                    break;
                case 2:
                    view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                    if ((view.FocusedRowHandle < 0)) return;
                    row = view.GetFocusedDataRow();
                    ID = cls_Library.DBInt(row["ITEM_ID"]);
                    frm_Product_Record frm = new frm_Product_Record(cls_Struct.ActionMode.Edit, ID);
                    //frm.ItemID = pid;
                    //frm.InitialDialog(mode);
                    frm.ShowInTaskbar = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.Width = 1379;
                    frm.Height = 850;
                    frm.Text = "รหัสสินค้า " + " [แก้ไข]";
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SetUpdateDataFocus(1);
                        SetUpdateDataFocus(2);
                        SetUpdateDataFocus(3);
                        SetUpdateDataFocus(4);
                        SetUpdateDataFocus(5);
                        SetUpdateDataFocus(6);
                        SetUpdateDataFocus(7);
                        UpdateItemData();
                    }
                    //DataRow dr = cvItem.GetFocusedDataRow();
                    //if (dr == null) return;
                    //DataTable dt = GetItemByID(cls_Library.DBInt(dr["ITEM_ID"]));
                    //Int64 Rnew = cls_Library.DBInt(dr["RNnew"]);
                    //dr = dt.Rows[0];
                    ////dr.ItemArray = dt.Rows[0].ItemArray;
                    //dr["RNnew"] = Rnew;
                    //SetDataFocus();
                    //gridItem.RefreshDataSource();
                    break;
                case 3:
                    view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                    if ((view.FocusedRowHandle < 0)) return;
                    row = view.GetFocusedDataRow();
                    bool UnderStock = false;
                    UnderStock = cls_Library.DBbool(row["UNDER_STOCK"]);
                    if (!UnderStock)
                    {
                    DialogResult Result = XtraMessageBox.Show("Update under stock?", "Under Stock", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Result == DialogResult.Yes)
                    {
                        cls_Data.UpdateItemUnderStock(cls_Library.DBInt(row["ITEM_ID"]), true);
                        row["UNDER_STOCK"] = true;
                        cvItem.UpdateCurrentRow();
                    }
                    }
                    else
                    {
                    DialogResult Result = XtraMessageBox.Show("Cancel under stock?", "Under Stock", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Result == DialogResult.Yes)
                    {
                        cls_Data.UpdateItemUnderStock(cls_Library.DBInt(row["ITEM_ID"]), false);
                        row["UNDER_STOCK"] = false;
                        cvItem.UpdateCurrentRow();
                    }
                    }
                    break;
            }
            gridItem.Select();
        }

        private void CvItem_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            //GridView gridView = sender as GridView;

            //if (e.RowHandle < 0) return;

            //try
            //{
            //  Image chatFakeImage = new Bitmap(1, 1);
            //  Graphics chatGraphics = Graphics.FromImage(chatFakeImage);
            //  GraphicsCache graphicsCache = new GraphicsCache(chatGraphics);

            //  AppearanceObject appearance = new AppearanceObject();
            //  appearance.TextOptions.HAlignment = HorzAlignment.Near;
            //  appearance.TextOptions.VAlignment = VertAlignment.Top;
            //  appearance.TextOptions.WordWrap = WordWrap.Wrap;

            //  SizeF sizeF = graphicsCache.CalcTextSize(dtShow.Rows[e.RowHandle]["Group1"] as string,
            //                                              appearance.Font,
            //                                              appearance.GetStringFormat(),
            //                                              200);

            //  sizeText = new Size((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height));

            //  e.RowHeight = sizeText.Height + 10;
            //  e.RowHeight = 115;
            //}
            //catch (Exception exception)
            //{
            //  Debug.WriteLine("CvItem_CalcRowHeight exception : " + exception.ToString());
            //}
        }

        private void CvItem_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //bool OK = false;
            //string eFname;
            //try
            //{
            //  OK = false;

            //  if (e.Column.FieldName == "Group1")
            //    OK = true;
            //  if (e.Column.FieldName == "Group2")
            //    OK = true;
            //  if (e.Column.FieldName == "Group3")
            //    OK = true;
            //  if (e.Column.FieldName == "Group4")
            //    OK = true;
            //  if (e.Column.FieldName == "Group5")
            //    OK = true;
            //  if (e.Column.FieldName == "Group6")
            //    OK = true;
            //  if (e.Column.FieldName == "Group7")
            //    OK = true;


            //  if (!OK)
            //  {
            //    e.Handled = false;
            //    return;
            //  }

            //  eFname = e.Column.FieldName;

            //  e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            //  e.Appearance.TextOptions.VAlignment = VertAlignment.Top;
            //  e.Appearance.TextOptions.WordWrap = WordWrap.Wrap;

            //  Rectangle bound = e.Bounds;
            //  bound.Width = sizeText.Width;
            //  if (e.Column.FieldName == "Group7")
            //  {
            //    bound.Width = 30;
            //  }
            //  bound.Height = sizeText.Height;

            //  e.Cache.DrawString(dtShow.Rows[e.RowHandle][eFname] as string,
            //                              e.Appearance.Font,
            //                              new SolidBrush(Color.Black),
            //                              new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height),
            //                              e.Appearance.GetStringFormat());

            //  // e.Cache.FillRectangle(Brushes.Red, new Rectangle(e.Bounds.X, e.Bounds.Y, 40,40));
            //  e.Handled = true;
            //}
            //catch (Exception exception)
            //{
            //  Debug.WriteLine("CvItem_CustomDrawCell exception : " + exception.ToString());
            //}
            //return;
        }

        private void bwData_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
            ProductSearch = "";
            SortType = 1;
            //PIAK 20221225
            searchType = 0;
            //PIAK 20201021
            GetDataChooseForStart(cls_Global_class.ChooseType.Item);
        }

        private void bwData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetControl();
            gridItem.DataSource = dtShow;
            cvItem.Columns["Group7"].Width = 60;
            gridItem.RefreshDataSource();
            if (dtShow.Rows.Count > 0)
            {
                spinListNo.Text = dtShow.Rows.Count.ToString("#,##0");
                spinListNo.Properties.EditMask = @"#,####,###";
                spinListNo.Properties.DisplayFormat.FormatString = @"#,####,###";
            }
            cvItem.RefreshData();
            txtCategory.Text = cls_Data.GetNameFromTBname(CategorySearch, "CATEGORIES", "CATEGORY_CODE") + " ---- " + cls_Data.GetNameFromTBname(CategorySearch, "CATEGORIES", "CATEGORY_NAME");
            uNCoumt = 1;
            AssignArraUndo(uNCoumt);
            AssignValueToArraUndo(uNCoumt);
            ProcessStartOK = false;
            gridItem.Select();

            //PIAK 20220131
            //PIAK_20220908
            SetDataFocus();
        }

        private void cvItem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //FocusRowchangeOK = true;
            if (FocusRowchangeOK) return;
            //PIAK 20201021
            SetDataFocus();

            int i = e.FocusedRowHandle + 1;
            eLabelRecord.Text = "";
            if (dtShow.Rows.Count > 0)
            {
                eLabelRecord.Text = "Record : " + i.ToString("#,##0") + "/" + dtShow.Rows.Count.ToString("#,##0");
                //ItemID
                DataRow dr = cvItem.GetFocusedDataRow();
                if (dr == null)
                {
                    return;
                }
                ItemID = cls_Library.DBInt(dr["ITEM_ID"]);
            }
        }

        private void vGridItem_CustomUnboundData(object sender, DevExpress.XtraVerticalGrid.Events.CustomDataEventArgs e)
        {
            int Id = 0;
            try
            {
            if (e.IsGetData)
            {
                if (dtVG.Rows.Count <= 0) return;                    
                switch (e.Row.Name)
                {
                case "rowCategory":
                    e.Value = string.Concat(dtVG.Rows[0]["CATEGORY_CODE"], " ", dtVG.Rows[0]["CATEGORY_NAME"]);
                    break;
                case "rowType":
                    string Typecode = cls_Library.DBString(dtVG.Rows[0]["TYPE_CODE"]); 
                    string Typename = cls_Library.DBString(dtVG.Rows[0]["TYPE_NAME"]); 
                    e.Value = string.Concat(Typecode, " ", Typename);
                    break;
                //case "rowCusPO":
                //  e.Value = cls_Library.DBString(dtVG.Rows[0]["VENDOR_NAME"]); 
                //  break;
                case "rowGroupPO":
                    Id = cls_Library.DBInt(cls_Data.GetNameFromTBname(cls_Library.DBInt(dtVG.Rows[0]["ITEM_ID"]), "ITEM_PO_GROUPS", "PO_GROUP_ID"));
                    string POcode = cls_Data.GetNameFromTBname(Id, "PO_GROUPS", "PO_GROUP_CODE");
                    string POname = cls_Data.GetNameFromTBname(Id, "PO_GROUPS", "PO_GROUP_NAME");
                    e.Value = string.Concat(POcode, " ", POname);
                    break;
                case "rowPart":
                    e.Value = cls_Data.GetNameFromTBname(cls_Library.DBInt(dtVG.Rows[0]["ITEM_ID"]), "ITEM_ALTERNATE_PARTS", "PART_ID",true);
                    break;
                }
            }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "")
                return;
            GetDataChoose(cls_Global_class.ChooseType.Item);            
        }

        private void frmInput2_KeyDown(object sender, KeyEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            DataRow row;
            int ID = 0;
            int Fmode;

            switch (e.KeyCode)
            {
                #region " F1 "
                case Keys.F1:
                    switch (MainSearch)
                    {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        MainSearch++;
                        SetSubMenu();
                        //InitialDialogMainSearch();
                        break;
                    case 4:
                        MainSearch = 0;
                        SetSubMenu();
                        break;
                    }
                    break;
                #endregion
                #region " F2 "
                case Keys.F2:
                    switch (MainSearch)
                    {
                        case 0:
                            Fmode = 1;
                            if (e.Shift)
                            {
                                Fmode = 2;
                            }
                            if (e.Control)
                            {
                                Fmode = 3;
                            }
                            switch (Fmode)
                            {
                                case 1:
                                    InitialDialogFormSearch1();
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    if (SelectJoin)
                                    {
                                        gvJoinOpenGroup();
                                        gridJoin.Select();
                                        gvJoin.Focus();
                                        SelectJoin = true;
                                    }
                                    if (SelectReplace)
                                    {
                                        gvReplaceOpenGroup();
                                        gridReplace.Select();
                                        gvReplace.Focus();
                                        SelectReplace = true;
                                    }
                                    break;
                            }
                            
                            break;
                    case 1:
                        Fmode = 1;
                        if (e.Shift)
                        {
                            Fmode = 2;
                        }
                        if (e.Control)
                        {
                            Fmode = 3;
                        }
                        switch (Fmode)
                        {
                        case 1:
                            frm_POList frmPO = new frm_POList();
                            frmPO.WindowState = FormWindowState.Maximized;
                            frmPO.ShowDialog();
                            break;
                        case 2:
                            LinkMenu(cls_Struct.MenuItem.PO);
                            break;
                        case 3:
                            LinkMenu(cls_Struct.MenuItem.hPO);
                            break;
                        }
                        gridItem.Select();
                        break;
                    case 2:
                        LinkEditItem(cls_Struct.TypeEditItem.SetPrice);
                        break;
                    case 3:
                        LinkEditItem(cls_Struct.TypeEditItem.T4);
                        gridItem.Select();
                        break;
                    case 4:
                        view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                        if ((view.FocusedRowHandle < 0)) return;
                        row = view.GetFocusedDataRow();
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_Group frmGroup = new frm_Group(2, 1);
                        frmGroup.ItemID = ID;
                        if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                        if (!string.IsNullOrEmpty(frmGroup.ProductCode))
                        {
                            GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
                        }
                        }
                        break;
                    }
                    break;
                #endregion
                #region " F3 "
                case Keys.F3:
                    switch (MainSearch)
                    {
                    case 0:
                            //Fmode = 1;
                            //if (e.Shift)
                            //{
                            //    Fmode = 2;
                            //}
                            //if (e.Control)
                            //{
                            //    Fmode = 3;
                            //}
                            //switch (Fmode)
                            //{
                            //    case 1:
                            //        InitialDialogFormSearch2();
                            //        break;
                            //    case 2:
                            //        break;
                            //    case 3:
                            //        if (SelectReplace) gvReplaceOpenGroup();
                            //        break;
                            //}
                            //gridReplace.Select();
                            //gvReplace.Focus();
                            //SelectReplace = true;

                            InitialDialogFormSearch2();
                            break;
                            
                    case 1:
                        Fmode = 1;
                        if (e.Shift)
                        {
                        Fmode = 2;
                        }
                        if (e.Control)
                        {
                        Fmode = 3;
                        }
                        switch (Fmode)
                        {
                            case 1:
                                frm_SQList frmSQ = new frm_SQList();
                                frmSQ.WindowState = FormWindowState.Maximized;
                                frmSQ.ShowDialog();
                                break;
                            case 2:
                                LinkMenu(cls_Struct.MenuItem.SQ);
                                break;
                            case 3:
                                LinkMenu(cls_Struct.MenuItem.hSQ);
                                break;
                        }
                        gridItem.Select();
                        break;
                    case 2:
                        LinkEditItem(cls_Struct.TypeEditItem.T2);
                        gridItem.Select();
                        break;
                    case 3:
                        LinkEditItem(cls_Struct.TypeEditItem.T5);
                        gridItem.Select();
                        break;
                    case 4:
                        view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                        if ((view.FocusedRowHandle < 0)) return;
                        row = view.GetFocusedDataRow();
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_Group frmGroup = new frm_Group(1, 1);
                        frmGroup.ItemID = ID;
                        if (frmGroup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                        if (!string.IsNullOrEmpty(frmGroup.ProductCode))
                        {
                            GetDataChoose(cls_Global_class.ChooseType.Item, frmGroup.ProductCode);
                        }
                        }
                        break;
                    }
                    break;
                #endregion
                #region " F4 "
                case Keys.F4:
                    switch (MainSearch)
                    {
                    case 0:
                        InitialDialogFormSearch3();
                        break;
                    //case 1:
                    //  Fmode = 1;
                    //  if (e.Shift)
                    //  {
                    //    Fmode = 2;
                    //  }
                    //  if (e.Control)
                    //  {
                    //    Fmode = 3;
                    //  }
                    //  switch (Fmode)
                    //  {
                    //    case 1:
                    //      frm_RCList frmRC = new frm_RCList();
                    //      frmRC.WindowState = FormWindowState.Maximized;
                    //      frmRC.ShowDialog();
                    //      break;
                    //    case 2:
                    //      LinkMenu(cls_Struct.MenuItem.RC);
                    //      break;
                    //    case 3:
                    //      LinkMenu(cls_Struct.MenuItem.hRC);
                    //      break;
                    //  }

                    //  break;
                    //case 2:
                    //  LinkEditItem(cls_Struct.TypeEditItem.T6);
                    //  break;
                    }
                    break;
                #endregion
                #region " F5 "
                case Keys.F5:
                    switch (MainSearch)
                    {
                    case 0:
                        txtProduct.Select();
                        break;
                    case 1:
                        Fmode = 1;
                        if (e.Shift)
                        {
                        Fmode = 2;
                        }
                        if (e.Control)
                        {
                        Fmode = 3;
                        }
                        switch (Fmode)
                        {
                        case 1:
                            frm_RCList frmRC = new frm_RCList();
                            frmRC.WindowState = FormWindowState.Maximized;
                            frmRC.ShowDialog();
                            break;
                        case 2:
                            LinkMenu(cls_Struct.MenuItem.RC);
                            break;
                        case 3:
                            LinkMenu(cls_Struct.MenuItem.hRC);
                            break;
                        }
                        gridItem.Select();
                        break;
                    case 2:
                        LinkEditItem(cls_Struct.TypeEditItem.T3);
                        gridItem.Select();
                        break;
                    case 3:
                        LinkEditItem(cls_Struct.TypeEditItem.T6);
                        gridItem.Select();
                        break;
                    case 4:
                        view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                        if ((view.FocusedRowHandle < 0)) return;
                        row = view.GetFocusedDataRow();
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        //frm_Group_Vers frmGroup = new frm_Group_Vers(1, 1);
                        //frmGroup.ItemID = ID;
                        //frmGroup.ShowDialog();
                        break;
                    }
                    break;
                #endregion
                #region " F6 "
                case Keys.F6:
                    switch (MainSearch)
                    {
                    case 0:
                        InitialListCode(8, "");
                        break;
                    case 1:
                        Fmode = 1;
                        if (e.Shift)
                        {
                        Fmode = 2;
                        }
                        if (e.Control)
                        {
                        Fmode = 3;
                        }
                        switch (Fmode)
                        {
                        case 1:
                            frm_ROList frmRO = new frm_ROList();
                            frmRO.WindowState = FormWindowState.Maximized;
                            frmRO.ShowDialog();
                            break;
                        case 2:
                            LinkMenu(cls_Struct.MenuItem.RO);
                            break;
                        case 3:
                            LinkMenu(cls_Struct.MenuItem.hRO);
                            break;
                        }
                        gridItem.Select();
                        break;
                    case 2:
                        LinkEditItem(cls_Struct.TypeEditItem.T11);
                        gridItem.Select();
                        break;
                    case 3:
                        LinkEditItem(cls_Struct.TypeEditItem.T7);
                        gridItem.Select();
                        break;
                    }
                    break;
                #endregion
                #region " F7 "
                case Keys.F7:
                    switch (MainSearch)
                    {
                        case 0:
                            InitialDialogFormSortOrder();
                            break;
                        case 1:
                            Fmode = 1;
                            if (e.Shift)
                            {
                                Fmode = 2;
                            }
                            if (e.Control)
                            {
                                Fmode = 3;
                            }
                            switch (Fmode)
                            {
                                case 1:
                                    frm_JobList frmJOB = new frm_JobList();
                                    frmJOB.WindowState = FormWindowState.Maximized;
                                    frmJOB.Text = "Job list";
                                    if (frmJOB.ShowDialog() == DialogResult.OK)
                                    {
                                    JOBid = frmJOB.Jobid;
                                    JOBcode = frmJOB.Jobcode;
                                    JOBdate = frmJOB.Jobdate;
                                    }
                                    break;
                                case 2:
                                    LinkMenu(cls_Struct.MenuItem.JOB);
                                    break;
                                case 3:
                                    LinkMenu(cls_Struct.MenuItem.hJOB);
                                    break;
                            }
                            gridItem.Select();
                            break;
                        case 2:
                            LinkEditItem(cls_Struct.TypeEditItem.T10);
                            gridItem.Select();
                            break;
                        case 3:
                            Fmode = 1;
                            if (e.Shift)
                            {
                            Fmode = 2;
                            }
                            if (e.Control)
                            {
                            Fmode = 3;
                            }
                            switch (Fmode)
                            {
                            case 1:
                                LinkEditItem(cls_Struct.TypeEditItem.T8);
                                break;
                            case 2:
                  
                                break;
                            case 3:
                                LinkMenu(cls_Struct.MenuItem.hSOH);
                                break;
                            }
                            break;
                    }
                    break;
                #endregion
                #region " F8 "
                case Keys.F8:
                    switch (MainSearch)
                    {
                        case 0:
                            SelectJoin = true;
                            SelectReplace = false;
                            gridJoin.Select();
                            gvJoin.Focus();
                            gvJoinSetDataRow();
                            gridJoin.Select();
                            gvJoin.Focus();
                            break;
                        case 1:
                            Fmode = 1;
                            if (e.Shift)
                            {
                            Fmode = 2;
                            }
                            if (e.Control)
                            {
                            Fmode = 3;
                            }
                            switch (Fmode)
                            {
                            case 1:
                                //frm_PJList frmJOB = new frm_PJList();
                                //frmJOB.WindowState = FormWindowState.Maximized;
                                //frmJOB.ShowDialog();
                                break;
                            case 2:
                                LinkMenu(cls_Struct.MenuItem.PJOB);
                                break;
                            case 3:
                                break;
                            }
                            break;
                        case 2:
                            DataRow _row;
                            Fmode = 1;
                            if (e.Control)
                            {
                                Fmode = 3;
                            }
                            switch (Fmode)
	                        {
                            case 1:
                                ID = 0;
                                view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                                if ((view.FocusedRowHandle < 0)) return;
                                _row = view.GetFocusedDataRow();
                                ID = cls_Library.DBInt(_row["ITEM_ID"]);
                                frm_ItemPriceList frmItem = new frm_ItemPriceList(ID);
                                if (frmItem.ShowDialog() == DialogResult.OK)
                                {
                                        UpdateItemData();
                                        //SetDataFocus();
                                }
                                break;
                            case 3:
                                ID = 0;
                                view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                                if ((view.FocusedRowHandle < 0)) return;
                                _row = view.GetFocusedDataRow();
                                ID = cls_Library.DBInt(_row["ITEM_ID"]);
                                frm_HistoryPriceList frmHprice = new frm_HistoryPriceList(ID);
                                frmHprice.ItemName = cls_Library.DBString(_row["ITEM_CODE"]);
                                frmHprice.Text = "History [Price List]";
                                frmHprice.ShowDialog();
                                break;
	                        }
                            gridItem.Select();
                            break;
                        case 3:
                            LinkEditItem(cls_Struct.TypeEditItem.T9);
                            gridItem.Select();
                            break;
                    }
                    break;
                #endregion
                #region " F9 "
                case Keys.F9:
                    switch (MainSearch)
                    {
                        case 0:
                            SelectReplace  = true;
                            SelectJoin = false;
                            gridReplace.Select();
                            gvReplace.Focus();
                            gvReplaceSetDataRow();
                            gridReplace.Select();
                            gvReplace.Focus();
                            break;
                        case 1:
                            Fmode = 1;
                            if (e.Shift)
                            {
                                Fmode = 2;
                            }
                            if (e.Control)
                            {
                                Fmode = 3;
                            }
                            switch (Fmode)
                            {
                                case 1:
                                    cls_Sales.FilterOption = 0;
                                    InitialDialogFormfilter();
                                    if (cls_Sales.FilterOption == 0) return;
                                    this.Cursor = Cursors.WaitCursor;
                                    switch (cls_Sales.FilterOption)
                                    {
                                        case 1:
                                            InitialDialogFormOpenBill();
                                            break;
                                        case 2:
                                        case 3:
                                        case 4:
                                            FilterStaff frmInput;
                                            frmInput = new FilterStaff();
                                            frmInput.StartPosition = FormStartPosition.CenterParent;

                                            frmInput.Text = "ระบุพนักงาน";
                                            #region "Assign Lookup"
                                            #endregion
                                            frmInput.MinimizeBox = false;
                                            frmInput.ShowInTaskbar = false;
                                            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                                            {
                                                this.Cursor = Cursors.Default;
                                                return;
                                            }
                                            frm_BSList frmBS = new frm_BSList();
                                            frmBS.WindowState = FormWindowState.Maximized;
                                            frmBS.Text = "รายการขายสินค้า";
                                            if (frmBS.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                            break;
                                        case 5:
                                        case 6:
                                        case 7:
                                        case 8:
                                        case 9:
                                        case 10:
                                            frm_BSList frmBS1 = new frm_BSList();
                                            frmBS1.WindowState = FormWindowState.Maximized;
                                            frmBS1.Text = "รายการขายสินค้า";
                                            if (frmBS1.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                            break;
                                        case 11:
                                        case 12:
                                            FilterCashier frmInpuCashiert;
                                            frmInpuCashiert = new FilterCashier();
                                            frmInpuCashiert.StartPosition = FormStartPosition.CenterParent;

                                            frmInpuCashiert.Text = "ระบุพนักงานขาย";
                                            #region "Assign Lookup"
                                            #endregion
                                            frmInpuCashiert.MinimizeBox = false;
                                            frmInpuCashiert.ShowInTaskbar = false;
                                            if (frmInpuCashiert.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                                            {
                                                this.Cursor = Cursors.Default;
                                                return;
                                            }



                                            frm_BSList frmBS2 = new frm_BSList();
                                            frmBS2.WindowState = FormWindowState.Maximized;
                                            frmBS2.Text = "รายการขายสินค้า";
                                            if (frmBS2.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                            break;
                                        case 13:
                                        case 14:
                                            FilterCustomer frmInpuCustomer;
                                            frmInpuCustomer = new FilterCustomer();
                                            frmInpuCustomer.StartPosition = FormStartPosition.CenterParent;

                                            frmInpuCustomer.Text = "ระบุลูกค้า";
                                            #region "Assign Lookup"
                                            #endregion
                                            frmInpuCustomer.MinimizeBox = false;
                                            frmInpuCustomer.ShowInTaskbar = false;
                                            if (frmInpuCustomer.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                                            {
                                                this.Cursor = Cursors.Default;
                                                return;
                                            }
                                            frm_BSList frmBS3 = new frm_BSList();
                                            frmBS3.WindowState = FormWindowState.Maximized;
                                            frmBS3.Text = "รายการขายสินค้า";
                                            if (frmBS3.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                            break;
                                        default:
                                            frm_BSList frmBS4 = new frm_BSList();
                                            frmBS4.WindowState = FormWindowState.Maximized;
                                            frmBS4.Text = "รายการขายสินค้า";
                                            if (frmBS4.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                            break;
                                    }                                
                                break;
                            case 2:
                                //InitialDialogFormOpenBill();
                                break;
                            case 3:
                                LinkMenu(cls_Struct.MenuItem.hSO);
                                break;
                        }                           
                        break;
                    case 2:         
                        view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                        if ((view.FocusedRowHandle < 0)) return;
                        row = view.GetFocusedDataRow();
                        ID = cls_Library.DBInt(row["ITEM_ID"]);
                        frm_Product_Record frm = new frm_Product_Record(cls_Struct.ActionMode.Edit, ID);
                        //frm.ItemID = pid;
                        //frm.InitialDialog(mode);
                        frm.ShowInTaskbar = false;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.Width = 1379;
                        frm.Height = 850;
                        frm.Text = "รหัสสินค้า " + " [แก้ไข]";
                        
                        if (frm.ShowDialog() == DialogResult.Cancel)
                        {
                            SetDataFocus();
                            gridItem.Select();
                            return;
                        }

                            SetUpdateDataFocus(1);
                            SetUpdateDataFocus(2);
                            SetUpdateDataFocus(3);
                            SetUpdateDataFocus(4);
                            SetUpdateDataFocus(5);
                            SetUpdateDataFocus(6);
                            SetUpdateDataFocus(7);
                            UpdateItemData();
                            //DataRow dr = cvItem.GetFocusedDataRow();
                            //if (dr == null) return;
                            //DataTable dt = GetItemByID(cls_Library.DBInt(dr["ITEM_ID"]));
                            //int Rnew = cls_Library.DBInt(dr["RNnew"]);
                            //dr.ItemArray = dt.Rows[0].ItemArray;
                            //dr["RNnew"] = Rnew;
                            //SetDataFocus();
                            //gridItem.Select();
                            break;
                    case 3:              
              
                        view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                        if ((view.FocusedRowHandle < 0)) return;
                        row = view.GetFocusedDataRow();
                        bool UnderStock = false;
                        UnderStock = cls_Library.DBbool(row["UNDER_STOCK"]);
                        if (!UnderStock)
                        {
                        DialogResult Result = XtraMessageBox.Show("Update under stock?", "Under Stock", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Result == DialogResult.Yes)
                        {
                            cls_Data.UpdateItemUnderStock(cls_Library.DBInt(row["ITEM_ID"]), true);
                            row["UNDER_STOCK"] = true;
                            cvItem.UpdateCurrentRow();
                        }
                        }
                        else
                        {
                        DialogResult Result = XtraMessageBox.Show("Cancel under stock?", "Under Stock", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Result == DialogResult.Yes)
                        {
                            cls_Data.UpdateItemUnderStock(cls_Library.DBInt(row["ITEM_ID"]), false);
                            row["UNDER_STOCK"] = false;
                            cvItem.UpdateCurrentRow();
                        }
                        }
                        gridItem.Select();
                        break;
                    }
                    break;
                #endregion
                #region " F11 "
                case Keys.F11:
                    switch (MainSearch)
                    {
                        case 0:
                            gridVersatile.Select();
                            gvVersatile.Focus();
                            gvVersatileSetDataRow();
                            gridVersatile.Select();
                            gvVersatile.Focus();
                            break;
                        case 1:
                            Fmode = 1;
                            if (e.Shift)
                            {
                                Fmode = 2;
                            }
                            if (e.Control)
                            {
                                Fmode = 3;
                            }
                            break;
                        case 2:
                            view = (DevExpress.XtraGrid.Views.Grid.GridView)cvItem;
                            if ((view.FocusedRowHandle < 0)) return;
                            row = view.GetFocusedDataRow();
                            ID = cls_Library.DBInt(row["ITEM_ID"]);
                            frm_Product_Record frm = new frm_Product_Record(cls_Struct.ActionMode.Edit, ID);
                            //frm.ItemID = pid;
                            //frm.InitialDialog(mode);
                            frm.ShowInTaskbar = false;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.Width = 1379;
                            frm.Height = 850;
                            frm.Text = "รหัสสินค้า " + " [แก้ไข]";
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                UpdateItemData();
                                //SetDataFocus();
                            }
                            break;
                    }
                    break;
                #endregion
                #region " F12 "
                case Keys.F12:
                    switch (MainSearch)
                    {
                        case 0:
                            InitialListContactCode();
                            break;
                    }
                    break;
                #endregion
                case Keys.Home:
                    MainSearch = 0;
                    SetSubMenu();
                    break;
                case Keys.Escape:
                    uNCoumt--;
                    if (uNCoumt <= 0) uNCoumt = 0;
                    if (uNCoumt <= 0) return;
                    AssignArraUndoToValue(uNCoumt);
                    AssignArraUndo(uNCoumt);
                    break;
            }


        }

        private void sluCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (sluCustomer.IsEditorActive)
            {
                GetDataChoose(cls_Global_class.ChooseType.Customer);
            }            
        }

        private void frmInput2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class_Library mc = new Class_Library();
            Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
            ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
            cls_Global_DB.GB_GroupReplace = 0;
            cls_Global_DB.GB_GroupJoin = 0;
            cls_Global_DB.GB_GroupVersatile = 0;
            //Force garbage collection.
            GC.Collect();

            // Wait for all finalizers to complete before continuing.
            GC.WaitForPendingFinalizers();
        }

        private void cvItem_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            //cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtBarcode.Text == "")
                {
                    SortType++;
                    if (SortType > 8) SortType = 0;
                    comboSort.SelectedIndex = SortType - 1;
                    txtBarcode.Select();
                }              
            }
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtProduct.Text == "")
                {
                    //SortType = comboSort.SelectedIndex + 1;
                    //if (SortType < 1) SortType = 1;
                    //if (SortType > 8) SortType = 1;
                    //comboSort.SelectedIndex = SortType - 1;
                    //GetDataChoose(cls_Global_class.ChooseType.Item);
                    txtProduct.Select();
                }
                else
                {
                    SelectJoin = false;
                    SelectReplace = false;
                    SelectVersatile = false;
                    GetDataChoose(cls_Global_class.ChooseType.Item);
                }
                txtProduct.Select();
                if (dtShow.Rows.Count > 0) cvItem.Focus();
            }
        }

        private void txtProduct_Leave(object sender, EventArgs e)
        {
            if (txtProduct.Text == "")
            return;
            SelectJoin = false;
            SelectReplace = false;
            SelectVersatile = false;
            GetDataChoose(cls_Global_class.ChooseType.Item);
            if (dtShow.Rows.Count > 0) cvItem.Focus();
        }

        private void frmInput2_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}