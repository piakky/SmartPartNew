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
using System.IO;
using DevExpress.XtraEditors.Repository;

namespace SmartPart.Forms.Code
{
    public partial class frm_Product_Record : DevExpress.XtraEditors.XtraForm
    {
        #region Variable

        private cls_Struct.StructPDT PDT = new cls_Struct.StructPDT();
        private BackgroundWorker _bwLoad = null;
        private BackgroundWorker _bwLoadCode = null;
        private DataSet dsMainData = new DataSet();
        private DataSet dsEdit = new DataSet();
        private DataSet _dsresult = new DataSet();
        private int ItemID = 0;
    
        //private cls_Global_class.ActionMode DataMode;
        cls_Struct.ActionMode DataMode;
        private DataRow EditData = null;
        private bool IsSaveOK = false;

        //Alt_Part
        DataTable DTstatus;
        RepositoryItemLookUpEdit rs_status = new RepositoryItemLookUpEdit();
        #endregion

        #region Property

        //public int ItemID
        //{
        //    set { Pid = value; }
        //}
        #endregion

        #region Thread

        private void ThreadStart()
        {
            _bwLoad = new BackgroundWorker();
            _bwLoad.WorkerReportsProgress = true;
            _bwLoad.WorkerSupportsCancellation = true;
            _bwLoad.DoWork += new DoWorkEventHandler(_bwLoad_DoWork);
            _bwLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bwLoad_RunWorkerCompleted);

            _bwLoad.RunWorkerAsync();
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
                //LoadDefaultData();
                dsMainData = cls_Data.GetListProductById(ItemID);
                DTstatus = new DataTable("Status");
                DTstatus.Columns.Add("Status", typeof(int));
                DTstatus.Columns.Add("Status_Name", typeof(string));
                for (int i = 0; i < 4; i++)
                {
                    DTstatus.Rows.Add();
                    switch (i)
                    {
                    case 0:
                        DTstatus.Rows[i]["Status"] = 1;
                        DTstatus.Rows[i]["Status_Name"] = "ไม่กำหนด";
                        break;
                    case 1:
                        DTstatus.Rows[i]["Status"] = 2;
                        DTstatus.Rows[i]["Status_Name"] = "เปลี่ยนเบอร์ใหม่";
                        break;
                    case 2:
                        DTstatus.Rows[i]["Status"] = 3;
                        DTstatus.Rows[i]["Status_Name"] = "พอใช้แทนกันได้";
                        break;
                    case 3:
                        DTstatus.Rows[i]["Status"] = 4;
                        DTstatus.Rows[i]["Status_Name"] = "ใช้แทนเบอร์เก่าได้";
                        break;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        #endregion

        #region function
        private void AddDataInitialofDetail()
        {
            //หน่วยนับ
            DataTable dtv = dsEdit.Tables["D_ITEM_UNITS"].Copy();
            DataTable dt = dtv.Clone();
            dt.Rows.Add();
            dt.Rows[0]["mode"] = 1;
            dt.Rows[0]["ITEM_ID"] = ItemID;
            dt.Rows[0]["UNIT_ID"] = 1;
            dt.Rows[0]["UNIT_CODE"] = "001";
            dt.Rows[0]["UNIT_NAME"] = "ชิ้น";
            dt.Rows[0]["MULTIPLY_QTY"] = 1;
            dt.Rows[0]["DECIMAL_STATUS"] = 0;
            dt.Rows[0]["BUY_STATUS"] = true;
            dt.Rows[0]["SALE_STATUS"] = true;
            dsEdit.Tables["D_ITEM_UNITS"].ImportRow(dt.Rows[0]);

            //กลุ่มสั่งสินค้า

            dtv = dsEdit.Tables["D_ITEM_PO_GROUPS"].Copy();
            dt = dtv.Clone();
            dt.Rows.Add();
            dt.Rows[0]["mode"] = 1;
            dt.Rows[0]["ITEM_ID"] = ItemID;
            dt.Rows[0]["PO_GROUP_ID"] = 1;
            dt.Rows[0]["PO_GROUP_CODE"] = "001";
            dt.Rows[0]["PO_GROUP_NAME"] = "สินค้าทั่วไป";
            dt.Rows[0]["LIST_NO"] = 1;
            dsEdit.Tables["D_ITEM_PO_GROUPS"].ImportRow(dt.Rows[0]);
        }

        private void AddDataSourceToGrid(byte gType)
        {
            try
            {
            switch (gType)
            {
                case 1://คลังสินค้า
                cls_Global_DB.GB_DitemLocation_count = dsEdit.Tables["D_ITEM_LOCATIONS"].Rows.Count;
                gridLocation.DataSource = dsEdit.Tables["D_ITEM_LOCATIONS"];
                gridLocation.RefreshDataSource();
                break;
                case 2://หน่วยนับ
                cls_Global_DB.GB_DitemUnit_count = dsEdit.Tables["D_ITEM_UNITS"].Rows.Count;
                gridUnit.DataSource = dsEdit.Tables["D_ITEM_UNITS"];
                gridUnit.RefreshDataSource();
                break;
                case 3://อะไหล่
                cls_Global_DB.GB_DitemPart_count = dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"].Rows.Count;
                gridAlternate.DataSource = dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"];
                gridAlternate.RefreshDataSource();
                break;
                case 4://กลุ่มสั่งสินค้า
                cls_Global_DB.GB_DitemPOgroup_count = dsEdit.Tables["D_ITEM_PO_GROUPS"].Rows.Count;
                if ((DataMode == cls_Struct.ActionMode.Add) || (DataMode == cls_Struct.ActionMode.Copy)) AddDataInitialofDetail();
                gridPO_Group.DataSource = dsEdit.Tables["D_ITEM_PO_GROUPS"];
                gridPO_Group.RefreshDataSource();
                break;
                case 5://ผู้แทนจำหน่าย
                cls_Global_DB.GB_DitemVendor_count = dsEdit.Tables["D_ITEM_VENDORS"].Rows.Count;
                gridVendors.DataSource = dsEdit.Tables["D_ITEM_VENDORS"];
                gridVendors.RefreshDataSource();
                break;
                case 6://สมาชิก
                cls_Global_DB.GB_DitemSet_count = dsEdit.Tables["D_ITEM_SETS"].Rows.Count;
                gridItemSet.DataSource = dsEdit.Tables["D_ITEM_SETS"];
                gridItemSet.RefreshDataSource();
                break;
                case 7://ส่วนประกอบ
                cls_Global_DB.GB_DitemComponent_count = dsEdit.Tables["D_ITEM_COMPONENTS"].Rows.Count;
                gridComponent.DataSource = dsEdit.Tables["D_ITEM_COMPONENTS"];
                gridComponent.RefreshDataSource();
                break;
                case 8://รูปภาพ
                cls_Global_DB.GB_DitemPicture_count = dsEdit.Tables["D_ITEM_PICTURES"].Rows.Count;
                gridPicture.DataSource = dsEdit.Tables["D_ITEM_PICTURES"];
                gridPicture.RefreshDataSource();
                break;
                case 9://เอกสาร
                cls_Global_DB.GB_DitemDocument_count = dsEdit.Tables["D_ITEM_DOCUMENTS"].Rows.Count;
                gridDoc.DataSource = dsEdit.Tables["D_ITEM_DOCUMENTS"];
                gridDoc.RefreshDataSource();
                break;
            }
            }
            catch (Exception ex)
            {
            MessageBox.Show("AddDataSourceToGrid :" + ex.Message);
            }
        }

        private void AssignDataFromComponent()
        {
            PDT.ITEM_ID = ItemID;
            PDT.ITEM_CODE = txtPdtCode.Text.Trim();
            PDT.MAKER_BARCODE_NO = txtMarkBarcode.Text.Trim();
            PDT.SET_STATUS = chkIsSet.Checked;
            PDT.COMPONENT_STATUS = chkComponent.Checked;
            PDT.CATEGORY_ID = cls_Library.DBInt(searchCategoriesCode.EditValue);
            PDT.TYPE_ID = cls_Library.DBInt(searchTypesCode.EditValue);
            PDT.BRAND_ID = cls_Library.DBInt(searchBrandCode.EditValue);
            PDT.PROMOTION_ID = 0;
            PDT.GENUIN_PART_ID = txtGenuinPart.Text.Trim();
            PDT.BRAND_PART_ID = txtProducerPart.Text.Trim();
            PDT.PO_NAME ="";
            PDT.PO_BRAND ="";
            PDT.PO_MODEL ="";
            PDT.ABBREVIATE_NAME = txtAbbreviateName.Text.Trim();
            PDT.FULL_NAME = txtFullName.Text.Trim();
            PDT.MODEL1 = txtModel1.Text.Trim();
            PDT.MODEL2 = txtModel2.Text.Trim();
            PDT.MODEL3 = txtModel3.Text.Trim();
            PDT.FULL_NAME_PRINT = txtFullPrint.Text.Trim();
            PDT.MODEL_PRINT = txtModelPrint.Text.Trim();
            PDT.BRAND_PRINT = txtBrandPrint.Text.Trim();
            PDT.QTY = cls_Library.DBInt(spCountCar.EditValue);
            PDT.PO_GROUP_ID = 0;
            PDT.LAST_BUY_CODE = "M";
            PDT.CURRENT_SALE_CODE = "M";
            PDT.CURRENT_QTY = 0;
            PDT.CURRENT_QTY_VAT = 0;
            PDT.CURRENT_VAT_STATUS = "N";
            PDT.TAX_INVOICE_VAT_STATUS = "N";
            PDT.SETUP_PRICE_DATE = cls_Library.DBDateTime(DBNull.Value);
            PDT.ENABLED_PRICE_STATUS = "N";
            PDT.ENABLED_PRICE_STATUS_DATE = cls_Library.DBDateTime(DBNull.Value);
            PDT.SERIAL_NO_STATUS = false;
            PDT.MINIMUM_QTY = cls_Library.DBInt(spinQtyMinOrder.EditValue);
            PDT.MAXIMUM_QTY = cls_Library.DBInt(spinQtyMax.EditValue);
            PDT.COUNTING_DATE = DateTime.Now;
            PDT.MINIMUM_DATE = cls_Library.DBDateTime(DBNull.Value);
            PDT.MINIMUM_ORDER_QTY = cls_Library.DBInt(spinQtymin.EditValue);
            PDT.MINIMUM_SALE_QTY = cls_Library.DBInt(spinQtyMinSale.EditValue);
            PDT.INVOICE_PRICE = 0;
            PDT.INVOICE_DATE = cls_Library.DBDateTime(DBNull.Value);
            PDT.DEFECT_QTY = cls_Library.DBInt(spinQtyDefect.EditValue);
            PDT.RESERVE_QTY = cls_Library.DBInt(spinQtyReserve.EditValue);
            PDT.SIZE_ID = cls_Library.DBInt(searchSizesCode.EditValue);
            PDT.SIZE_INNER = txtSizeInner.Text.Trim();
            PDT.SIZE_OUTSIDE = txtSizeOutside.Text.Trim();
            PDT.SIZE_THICK = txtSizeThick.Text.Trim();
            PDT.REMARK = txtRemark.Text.Trim();
            PDT.ACTIVE_STOCK = false;
            PDT.CUSTOMER_DISCOUNT_STATUS = false;
            PDT.DISPLAY_SEQUENSE_NO = cls_Library.DBInt(spinNoShow.EditValue);
            PDT.DISPLAY_HIDING_STATUS = chkNoIsHide.Checked;
            PDT.CREATED_DATE = DateTime.Now;
            PDT.CREATED_BY = cls_Global_class.GB_Userid;
            PDT.UPDATED_DATE = DateTime.Now;
            PDT.UPDATED_BY = cls_Global_class.GB_Userid;
            PDT.DELETED = false;
            PDT.DELETE_BY= cls_Global_class.GB_Userid;
            PDT.DELETE_DATE = DateTime.Now;
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
            cmd.CommandText = "SELECT ITEM_ID,ITEM_CODE FROM M_ITEMS WHERE ITEM_CODE='" + Xcode + "' And DELETED=0";
            cmd.Connection = conn;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
            if ((DataMode == cls_Struct.ActionMode.Edit) || (DataMode == cls_Struct.ActionMode.Copy))
            {
                rd.Read();
                id = Convert.ToInt32(rd["ITEM_ID"]);
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

        private void InitialDialog()
        {
            ThreadStart();
            LoadDefaultData();
                //switch (DataMode)
                //{
                //    case cls_Global_class.ActionMode.Add:
                //        SetDefaultData();
                //        break;
                //    //case cls_Global_class.ActionMode.Edit:                    
                //    //case cls_Global_class.ActionMode.Copy:
                //    //    ThreadStart();
                //    //    break;
                //}
            
        }

        public void InitialDialogAlternate(int mode)
        {
            frmD_AlternateInput frmInput;
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

            frmInput = new frmD_AlternateInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtGroup = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvAlternate;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            dr = view.GetFocusedDataRow();
            frmInput.Text = "หมายเลขอะไหล่" + strMode;
            #region "XXX"
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    frmInput.TxtAlternatePart.Text = cls_Library.DBString(dr["PART_ID"]);
                    frmInput.TxtAlternateBrand.Text = cls_Library.DBString(dr["BRAND_DESCRIPTION"]);
                    frmInput.radioAlternateStatus.SelectedIndex = cls_Library.DBInt(dr["STATUS"]) - 1;
                }
                else
                {
                    DataTable dt = (DataTable)gridAlternate.DataSource;
                    frmInput.TxtAlternatePart.Text = "";
                    frmInput.TxtAlternateBrand.Text = "";
                    frmInput.radioAlternateStatus.SelectedIndex = 0;
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridAlternate.DataSource;
                }
            }
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridAlternate.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["PART_ID"] = cls_Library.DBString(frmInput.TxtAlternatePart.Text.Trim());
                dt.Rows[0]["BRAND_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtAlternateBrand.Text.Trim());
                dt.Rows[0]["STATUS"] = (frmInput.radioAlternateStatus.SelectedIndex) + 1;
                dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvAlternate;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["PART_ID"] = cls_Library.DBString(frmInput.TxtAlternatePart.Text.Trim());
                dr["BRAND_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtAlternateBrand.Text.Trim());
                dr["STATUS"] = (frmInput.radioAlternateStatus.SelectedIndex) + 1;
            }
            dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"].EndInit();
            gridAlternate.DataSource = dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"];
            gridAlternate.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogComponent(int mode)
        {
            frmD_ComponentInput frmInput;
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

            frmInput = new frmD_ComponentInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtGroup = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvComponent;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            dr = view.GetFocusedDataRow();
            frmInput.Text = "ส่วนประกอบ" + strMode;
            #region "XXX"
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    frmInput.TxtComponentCode.Text = cls_Library.DBString(dr["COMPONENT_CODE"]);
                    frmInput.TxtComponentName.Text = cls_Library.DBString(dr["COMPONENT_NAME"]);
                    frmInput.spinQuantity.EditValue = cls_Library.DBInt(dr["QTY"]);
                }
                else
                {
                    DataTable dt = (DataTable)gridComponent.DataSource;
                    frmInput.TxtComponentCode.Text = "";
                    frmInput.TxtComponentName.Text = "";
                    frmInput.spinQuantity.EditValue = 1;
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridComponent.DataSource;
                }
            }
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsEdit.Tables["D_ITEM_COMPONENTS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridComponent.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["COMPONENT_CODE"] = cls_Library.DBString(frmInput.TxtComponentCode.Text.Trim());
                dt.Rows[0]["COMPONENT_NAME"] = cls_Library.DBString(frmInput.TxtComponentName.Text.Trim());
                dt.Rows[0]["QTY"] = cls_Library.DBInt(frmInput.spinQuantity.EditValue);
                dsEdit.Tables["D_ITEM_COMPONENTS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvComponent;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["COMPONENT_CODE"] = cls_Library.DBString(frmInput.TxtComponentCode.Text.Trim());
                dr["COMPONENT_NAME"] = cls_Library.DBString(frmInput.TxtComponentName.Text.Trim());
                dr["QTY"] = cls_Library.DBInt(frmInput.spinQuantity.EditValue);
            }
            dsEdit.Tables["D_ITEM_COMPONENTS"].EndInit();
            chkComponent.Checked = dsEdit.Tables["D_ITEM_COMPONENTS"].Rows.Count > 0 ? true : false;
            gridComponent.DataSource = dsEdit.Tables["D_ITEM_COMPONENTS"];
            gridComponent.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogDocument(int mode)
        {
            frmD_DocumentInput frmInput;
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

            frmInput = new frmD_DocumentInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtGroup = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvDoc;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            dr = view.GetFocusedDataRow();
            frmInput.Text = "เอกสาร" + strMode;
            #region "XXX"
            frmInput.searchLookUpDocument.Properties.DataSource = searchDocsCode.Properties.DataSource;
            frmInput.searchLookUpDocument.Properties.PopulateViewColumns();
            frmInput.searchLookUpDocument.Properties.ValueMember = "_id";
            frmInput.searchLookUpDocument.Properties.DisplayMember = "code";
            frmInput.searchLookUpDocument.Properties.View.Columns["_id"].Visible = false;
            frmInput.searchLookUpDocument.Properties.View.Columns["code"].Caption = "รหัสเอกสาร";
            frmInput.searchLookUpDocument.Properties.View.Columns["name"].Caption = "ชื่อเอกสาร";
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    frmInput.searchLookUpDocument.EditValue = cls_Library.DBInt(dr["DOCUMENT_ID"]);
                    frmInput.TxtDocName.Text = cls_Library.DBString(dr["DOCUMENT_NAME"]);
                    frmInput.TxtDescription.Text = cls_Library.DBString(dr["DOCUMENT_DESCRIPTION"]);
                    frmInput.TxtAddress.Text = cls_Library.DBString(dr["DOCUMENT_ADDRESS"]);
                }
                else
                {
                    DataTable dt = (DataTable)gridDoc.DataSource;
                    frmInput.searchLookUpDocument.EditValue = null;
                    frmInput.TxtDocName.Text = "";
                    frmInput.TxtDescription.Text = "";
                    frmInput.TxtAddress.Text = "";
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridDoc.DataSource;
                }
            }
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsEdit.Tables["D_ITEM_DOCUMENTS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridDoc.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["ITEM_ID"] = ItemID;
                dt.Rows[0]["DOCUMENT_ID"] = cls_Library.DBInt(frmInput.searchLookUpDocument.EditValue);
                dt.Rows[0]["DOCUMENT_CODE"] = cls_Library.DBString(frmInput.searchLookUpDocument.Text.Trim());
                dt.Rows[0]["DOCUMENT_NAME"] = cls_Library.DBString(frmInput.TxtDocName.Text.Trim());
                dt.Rows[0]["DOCUMENT_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDescription.Text.Trim());
                dt.Rows[0]["DOCUMENT_ADDRESS"] = cls_Library.DBString(frmInput.TxtAddress.Text.Trim());
                dsEdit.Tables["D_ITEM_DOCUMENTS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvDoc;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["DOCUMENT_ID"] = cls_Library.DBInt(frmInput.searchLookUpDocument.EditValue);
                dr["DOCUMENT_CODE"] = cls_Library.DBString(frmInput.searchLookUpDocument.Text.Trim());
                dr["DOCUMENT_NAME"] = cls_Library.DBString(frmInput.TxtDocName.Text.Trim());
                dr["DOCUMENT_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtDescription.Text.Trim());
                dr["DOCUMENT_ADDRESS"] = cls_Library.DBString(frmInput.TxtAddress.Text.Trim());
            }
            dsEdit.Tables["D_ITEM_DOCUMENTS"].EndInit();
            gridDoc.DataSource = dsEdit.Tables["D_ITEM_DOCUMENTS"];
            gridDoc.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogLocation(int mode)
        {
            frmD_LocationInput frmInput;
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

            frmInput = new frmD_LocationInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtGroup = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvLocation;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            dr = view.GetFocusedDataRow();
            string Snum = cls_Library.DBbool(chkUseSerial.EditValue) ? "  {มีหมายเลขประจำเครื่อง}  " : "  { ไม่มีหมายเลขประจำเครื่อง}  ";
            frmInput.Text = "คลังสินค้า" + Snum + strMode;
            #region "XXX"
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    frmInput.TxtLocationName.Text = cls_Library.DBString(dr["LOCATION_NAME"]);
                    frmInput.TxtSerialNumber.Text = cls_Library.DBString(dr["SERIAL_NO"]);
                    frmInput.spinQuantity.EditValue = cls_Library.DBInt(dr["QTY"]);
                    frmInput.chkUseMode.EditValue = cls_Library.DBbool(dr["DEFAULT_LOCATION"]); ;
                }
                else
                {
                    DataTable dt = (DataTable)gridLocation.DataSource;
                    frmInput.TxtLocationName.Text = "";
                    frmInput.TxtSerialNumber.Text = "";
                    frmInput.spinQuantity.EditValue = 0;
                    frmInput.chkUseMode.EditValue = 1;
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridLocation.DataSource;
                }
            }
            if (!cls_Library.DBbool(chkUseSerial.EditValue))
            {
                frmInput.labelSerialNumber.Visible = false;
                frmInput.TxtSerialNumber.Visible = false;
            }
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsEdit.Tables["D_ITEM_LOCATIONS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridLocation.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["LOCATION_NAME"] = cls_Library.DBString(frmInput.TxtLocationName.Text.Trim());
                dt.Rows[0]["SERIAL_NO"] = cls_Library.DBString(frmInput.TxtSerialNumber.Text.Trim());
                dt.Rows[0]["QTY"] = cls_Library.DBInt(frmInput.spinQuantity.EditValue);
                dt.Rows[0]["DEFAULT_LOCATION"] = cls_Library.DBbool(frmInput.chkUseMode.EditValue);
                dsEdit.Tables["D_ITEM_LOCATIONS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvLocation;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["LOCATION_NAME"] = cls_Library.DBString(frmInput.TxtLocationName.Text.Trim());
                dr["SERIAL_NO"] = cls_Library.DBString(frmInput.TxtSerialNumber.Text.Trim());
                dr["QTY"] = cls_Library.DBInt(frmInput.spinQuantity.EditValue);
                dr["DEFAULT_LOCATION"] = cls_Library.DBbool(frmInput.chkUseMode.EditValue);
            }
            dsEdit.Tables["D_ITEM_LOCATIONS"].EndInit();
            gridLocation.DataSource = dsEdit.Tables["D_ITEM_LOCATIONS"];
            gridLocation.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogPicture(int mode)
        {
            frmD_PicturesInput frmInput;
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

            frmInput = new frmD_PicturesInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtGroup = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPicture;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            dr = view.GetFocusedDataRow();
            frmInput.Text = "รูปภาพ" + strMode;
            #region "XXX"
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    string strBasePath = Application.StartupPath + "\\Photos";
                    if (!Directory.Exists(strBasePath))
                    {
                    Directory.CreateDirectory(strBasePath);
                    }
                    var picbyte = (Byte[])(dr["PICTURE_IMAGE"]);
                    //var stream = new MemoryStream(picbyte);
                    MemoryStream MemoryStreamData = new MemoryStream(picbyte);
                    Image image = System.Drawing.Image.FromStream(MemoryStreamData);
                    image.Save(strBasePath + "\\" + cls_Library.DBString(dr["PICTURE_FILE_NAME"]));
                    frmInput.pictureDisplay.Image = image;
                    frmInput.Txtfilename.Text = cls_Library.DBString(dr["PICTURE_FILE_NAME"]);
                    frmInput.TxtfilePath.Text = strBasePath + "\\" + cls_Library.DBString(dr["PICTURE_FILE_NAME"]);
                }
                else
                {
                    DataTable dt = (DataTable)gridPicture.DataSource;
                    frmInput.pictureDisplay.Image = null;
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridPicture.DataSource;
                }
            }
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            Class_ImageResize img = new Class_ImageResize();
            dsEdit.Tables["D_ITEM_PICTURES"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridPicture.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["PICTURE_FILE_NAME"] = cls_Library.DBString(frmInput.Txtfilename.Text.Trim());
                dt.Rows[0]["PICTURE_IMAGE"] = img.imageToByteArray(frmInput.pictureDisplay.Image);
                dsEdit.Tables["D_ITEM_PICTURES"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPicture;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["PICTURE_FILE_NAME"] = cls_Library.DBString(frmInput.Txtfilename.Text.Trim());
                dr["PICTURE_IMAGE"] = img.imageToByteArray(frmInput.pictureDisplay.Image);
            }
            dsEdit.Tables["D_ITEM_PICTURES"].EndInit();
            gridPicture.DataSource = dsEdit.Tables["D_ITEM_PICTURES"];
            gridPicture.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogPOGroup(int mode)
        {
            frmD_PogroupInput frmInput;
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

            frmInput = new frmD_PogroupInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtUnit = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPO_Group;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            dr = view.GetFocusedDataRow();
            frmInput.Text = "กลุ่มสั่งซื้อสินค้า" + strMode;
            #region "XXX"
            frmInput.searchLookUpPOGroup.Properties.DataSource = searchPOGroupsCode.Properties.DataSource;
            frmInput.searchLookUpPOGroup.Properties.PopulateViewColumns();
            frmInput.searchLookUpPOGroup.Properties.ValueMember = "_id";
            frmInput.searchLookUpPOGroup.Properties.DisplayMember = "code";
            frmInput.searchLookUpPOGroup.Properties.View.Columns["_id"].Visible = false;
            frmInput.searchLookUpPOGroup.Properties.View.Columns["code"].Caption = "รหัสกลุ่มสั่งซื้อสินค้า";
            frmInput.searchLookUpPOGroup.Properties.View.Columns["name"].Caption = "ชื่อกลุ่มสั่งซื้อสินค้า";
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    frmInput.searchLookUpPOGroup.EditValue = cls_Library.DBInt(dr["PO_GROUP_ID"]);
                    frmInput.TxtPOGroupName.Text = cls_Library.DBString(dr["PO_GROUP_NAME"]); ;
                }
                else
                {
                    DataTable dt = (DataTable)gridPO_Group.DataSource;
                    frmInput.searchLookUpPOGroup.EditValue = null;
                    frmInput.TxtPOGroupName.Text = "";
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridPO_Group.DataSource;
                }
            }

            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsEdit.Tables["D_ITEM_PO_GROUPS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridPO_Group.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["ITEM_ID"] = ItemID;
                dt.Rows[0]["PO_GROUP_ID"] = cls_Library.DBInt(frmInput.searchLookUpPOGroup.EditValue);
                dt.Rows[0]["PO_GROUP_CODE"] = cls_Library.DBString(frmInput.searchLookUpPOGroup.Text.Trim());
                dt.Rows[0]["PO_GROUP_NAME"] = cls_Library.DBString(frmInput.TxtPOGroupName.Text.Trim());
                dsEdit.Tables["D_ITEM_PO_GROUPS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPO_Group;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["ITEM_ID"] = ItemID;
                dr["PO_GROUP_ID"] = cls_Library.DBInt(frmInput.searchLookUpPOGroup.EditValue);
                dr["PO_GROUP_CODE"] = cls_Library.DBString(frmInput.searchLookUpPOGroup.Text.Trim());
                dr["PO_GROUP_NAME"] = cls_Library.DBString(frmInput.TxtPOGroupName.Text.Trim());
            }
            dsEdit.Tables["D_ITEM_PO_GROUPS"].EndInit();
            gridPO_Group.DataSource = dsEdit.Tables["D_ITEM_PO_GROUPS"];
            gridPO_Group.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogProductSet(int mode)
        {
            frmD_ItemSetInput frmInput;
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

            frmInput = new frmD_ItemSetInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtUnit = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvItemSet;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            int irow = dsEdit.Tables["D_ITEM_SETS"].Rows.Count;
            dr = view.GetFocusedDataRow();
            frmInput.Text = "สมาชิก" + strMode;
            #region "XXX"
            frmInput.searchLookUpProduct.Properties.DataSource = searchMainProductCode.Properties.DataSource;
            frmInput.searchLookUpProduct.Properties.PopulateViewColumns();
            frmInput.searchLookUpProduct.Properties.ValueMember = "_id";
            frmInput.searchLookUpProduct.Properties.DisplayMember = "code";
            frmInput.searchLookUpProduct.Properties.View.Columns["_id"].Visible = false;
            frmInput.searchLookUpProduct.Properties.View.Columns["code"].Caption = "รหัสสินค้า";
            frmInput.searchLookUpProduct.Properties.View.Columns["name"].Caption = "ชื่อสินค้า";
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    frmInput.spinOrder.EditValue = cls_Library.DBInt(dr["SET_ORDER"]);
                    frmInput.searchLookUpProduct.EditValue = cls_Library.DBInt(dr["SET_ITEM_ID"]);
                    frmInput.TxtCode.Text = cls_Library.DBString(dr["ITEM_CODE"]);
                    frmInput.searchLookUpBrand.EditValue = cls_Library.DBInt(dr["BRAND_ID"]);
                    frmInput.TxtFullname.Text = cls_Library.DBString(dr["FULL_NAME"]);
                    frmInput.TxtModel1.Text = cls_Library.DBString(dr["Model1"]);
                    frmInput.txtGenuinPart.Text = cls_Library.DBString(dr["GENUIN_PART_ID"]);
                    frmInput.txtProducerPart.Text = cls_Library.DBString(dr["BRAND_PART_ID"]);
                    frmInput.TxtBrand.Text = cls_Library.DBString(dr["BRAND_NAME"]);
                    frmInput.spinQuantity.EditValue = cls_Library.DBInt(dr["QTY"]);
                }
                else
                {
                    DataTable dt = (DataTable)gridItemSet.DataSource;
                    frmInput.spinOrder.EditValue = irow + 1;
                    frmInput.searchLookUpProduct.EditValue = null;
                    frmInput.searchLookUpBrand.EditValue = null;
                    frmInput.TxtCode.Text = "";
                    frmInput.TxtFullname.Text = "";
                    frmInput.TxtModel1.Text = "";
                    frmInput.txtGenuinPart.Text = "";
                    frmInput.txtProducerPart.Text = "";
                    frmInput.TxtBrand.Text = "";
                    frmInput.spinQuantity.EditValue = 1;
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridItemSet.DataSource;
                frmInput.spinOrder.EditValue = irow + 1;
                }
            }

            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

        

            dsEdit.Tables["D_ITEM_SETS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridItemSet.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["ITEM_ID"] = ItemID;
                dt.Rows[0]["ITEM_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text.Trim());
                dt.Rows[0]["SET_ORDER"] = cls_Library.DBInt(frmInput.spinOrder.EditValue);
                dt.Rows[0]["SET_ITEM_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
                dt.Rows[0]["BRAND_ID"] = cls_Library.DBInt(frmInput.searchLookUpBrand.EditValue);
                dt.Rows[0]["FULL_NAME"] = cls_Library.DBString(frmInput.TxtFullname.Text.Trim());
                dt.Rows[0]["Model1"] = cls_Library.DBString(frmInput.TxtModel1.Text.Trim());
                dt.Rows[0]["GENUIN_PART_ID"] = cls_Library.DBString(frmInput.txtGenuinPart.Text.Trim());
                dt.Rows[0]["BRAND_PART_ID"] = cls_Library.DBString(frmInput.txtProducerPart.Text.Trim());
                dt.Rows[0]["BRAND_NAME"] = cls_Library.DBString(frmInput.TxtBrand.Text.Trim());
                dt.Rows[0]["QTY"] = cls_Library.DBInt(frmInput.spinQuantity.EditValue);
                dsEdit.Tables["D_ITEM_SETS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvItemSet;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["ITEM_ID"] = ItemID;
                dr["ITEM_CODE"] = cls_Library.DBString(frmInput.TxtCode.Text.Trim());
                dr["SET_ORDER"] = cls_Library.DBInt(frmInput.spinOrder.EditValue);
                dr["SET_ITEM_ID"] = cls_Library.DBInt(frmInput.searchLookUpProduct.EditValue);
                dr["BRAND_ID"] = cls_Library.DBInt(frmInput.searchLookUpBrand.EditValue);
                dr["FULL_NAME"] = cls_Library.DBString(frmInput.TxtFullname.Text.Trim());
                dr["Model1"] = cls_Library.DBString(frmInput.TxtModel1.Text.Trim());
                dr["GENUIN_PART_ID"] = cls_Library.DBString(frmInput.txtGenuinPart.Text.Trim());
                dr["BRAND_PART_ID"] = cls_Library.DBString(frmInput.txtProducerPart.Text.Trim());
                dr["BRAND_NAME"] = cls_Library.DBString(frmInput.TxtBrand.Text.Trim());
                dr["QTY"] = cls_Library.DBInt(frmInput.spinQuantity.EditValue);
            }
            dsEdit.Tables["D_ITEM_SETS"].EndInit();
            chkIsSet.Checked = dsEdit.Tables["D_ITEM_SETS"].Rows.Count > 0 ? true : false;
            gridLocation.DataSource = dsEdit.Tables["D_ITEM_SETS"];
            gridLocation.RefreshDataSource();

            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogUnit(int mode)
        {
            frmD_UnitInput frmInput;
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

            frmInput = new frmD_UnitInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtUnit = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvUnit;
            int irow = 0;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            else
            {
                irow = view.FocusedRowHandle + 1;
            }
        
            dr = view.GetFocusedDataRow();
            frmInput.Text = "หน่วยนับ" + strMode;
            #region "XXX"
            frmInput.searchLookUpUnit.Properties.DataSource = searchUnitsCode.Properties.DataSource;
            frmInput.searchLookUpUnit.Properties.PopulateViewColumns();
            frmInput.searchLookUpUnit.Properties.ValueMember = "_id";
            frmInput.searchLookUpUnit.Properties.DisplayMember = "code";
            frmInput.searchLookUpUnit.Properties.View.Columns["_id"].Visible = false;
            frmInput.searchLookUpUnit.Properties.View.Columns["code"].Caption = "รหัสหน่วยนับสินค้า";
            frmInput.searchLookUpUnit.Properties.View.Columns["name"].Caption = "ชื่อหน่วยนับสินค้า";
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    frmInput.searchLookUpUnit.EditValue = cls_Library.DBInt(dr["UNIT_ID"]);
                    frmInput.TxtUnitName.Text = cls_Library.DBString(dr["UNIT_NAME"]); ;
                    frmInput.spinQuantity.EditValue = cls_Library.DBDouble(dr["MULTIPLY_QTY"]);
                    frmInput.checkDigit.Checked = cls_Library.DBbool(dr["DECIMAL_STATUS"]);
                    frmInput.checkBuy.Checked = cls_Library.DBbool(dr["BUY_STATUS"]);
                    frmInput.checkSale.Checked = cls_Library.DBbool(dr["SALE_STATUS"]);
                }
                else
                {
                    DataTable dt = (DataTable)gridUnit.DataSource;
                    frmInput.searchLookUpUnit.EditValue = null;
                    frmInput.TxtUnitName.Text = "";
                    frmInput.spinQuantity.EditValue = 0;
                    frmInput.checkDigit.Checked = false;
                    frmInput.checkBuy.Checked = false;
                    frmInput.checkSale.Checked = false;
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridUnit.DataSource;
                }
            }

            frmInput.dtUit = dsEdit.Tables["D_ITEM_UNITS"].Copy();
            frmInput.iRow = irow;
            frmInput.Mode = Xmode;

            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsEdit.Tables["D_ITEM_UNITS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridUnit.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["ITEM_ID"] = ItemID;
                dt.Rows[0]["UNIT_ID"] = cls_Library.DBInt(frmInput.searchLookUpUnit.EditValue);
                dt.Rows[0]["UNIT_CODE"] = cls_Library.DBString(frmInput.searchLookUpUnit.Text.Trim());
                dt.Rows[0]["UNIT_NAME"] = cls_Library.DBString(frmInput.TxtUnitName.Text.Trim());
                dt.Rows[0]["MULTIPLY_QTY"] = cls_Library.DBDouble(frmInput.spinQuantity.EditValue);
                dt.Rows[0]["DECIMAL_STATUS"] = cls_Library.DBbool(frmInput.checkDigit.Checked);
                dt.Rows[0]["BUY_STATUS"] = cls_Library.DBbool(frmInput.checkBuy.Checked);
                dt.Rows[0]["SALE_STATUS"] = cls_Library.DBbool(frmInput.checkSale.Checked);
                dsEdit.Tables["D_ITEM_UNITS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvUnit;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["ITEM_ID"] = ItemID;
                dr["UNIT_ID"] = cls_Library.DBInt(frmInput.searchLookUpUnit.EditValue);
                dr["UNIT_CODE"] = cls_Library.DBString(frmInput.searchLookUpUnit.Text.Trim());
                dr["UNIT_NAME"] = cls_Library.DBString(frmInput.TxtUnitName.Text.Trim());
                dr["MULTIPLY_QTY"] = cls_Library.DBDouble(frmInput.spinQuantity.EditValue);
                dr["DECIMAL_STATUS"] = cls_Library.DBbool(frmInput.checkDigit.Checked);
                dr["BUY_STATUS"] = cls_Library.DBbool(frmInput.checkBuy.Checked);
                dr["SALE_STATUS"] = cls_Library.DBbool(frmInput.checkSale.Checked);
            }
            dsEdit.Tables["D_ITEM_UNITS"].EndInit();
            gridLocation.DataSource = dsEdit.Tables["D_ITEM_UNITS"];
            gridLocation.RefreshDataSource();
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
            }
        }

        public void InitialDialogVendor(int mode)
        {
            frmD_VendorsInput frmInput;
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

            frmInput = new frmD_VendorsInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
            strMode = " [เพิ่ม]";
            else if (mode == 1)
            strMode = " [แก้ไข]";


            try
            {
            DataTable dtvendor = new DataTable();
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvVendors;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != 0)
                {
                return;
                }
            }
            dr = view.GetFocusedDataRow();
            frmInput.Text = "ผู้แทนจำหน่าย" + strMode;
            #region "XXX"
            frmInput.searchLookUpVendor.Properties.DataSource = searchVendorsCode.Properties.DataSource;
            frmInput.searchLookUpVendor.Properties.PopulateViewColumns();
            frmInput.searchLookUpVendor.Properties.ValueMember = "_id";
            frmInput.searchLookUpVendor.Properties.DisplayMember = "code";
            frmInput.searchLookUpVendor.Properties.View.Columns["_id"].Visible = false;
            frmInput.searchLookUpVendor.Properties.View.Columns["code"].Caption = "รหัสเจ้าหนี้";
            frmInput.searchLookUpVendor.Properties.View.Columns["name"].Caption = "ชื่อเจ้าหนี้";
            if (dr != null)
            {
                if ((mode == 1) || (mode == 2))
                {
                if (mode == 1)
                {
                    frmInput.searchLookUpVendor.EditValue = cls_Library.DBInt(dr["VENDOR_ID"]);
                    frmInput.TxtVendorName.Text = cls_Library.DBString(dr["VENDOR_NAME"]); ;
                    frmInput.spinPiority.EditValue = cls_Library.DBInt(dr["PRIORITY"]);
                }
                else
                {
                    DataTable dt = (DataTable)gridUnit.DataSource;
                    frmInput.searchLookUpVendor.EditValue = null;
                    frmInput.TxtVendorName.Text = "";
                    frmInput.spinPiority.EditValue = 1;
                }
                try
                {
                    //frmInput.MemberOf = dr("USRmember").ToString();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                    //frmInput.MemberOf = "";
                }
                finally
                {
                    //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                    //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                }
                }
                else
                {
                DataTable dt = (DataTable)gridUnit.DataSource;
                }
            }

            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            dsEdit.Tables["D_ITEM_VENDORS"].BeginInit();
            if (Xmode == 0)
            {
                DataTable dtv = (DataTable)gridVendors.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["mode"] = 1;
                dt.Rows[0]["ITEM_ID"] = ItemID;
                dt.Rows[0]["VENDOR_ID"] = cls_Library.DBInt(frmInput.searchLookUpVendor.EditValue);
                dt.Rows[0]["VENDOR_CODE"] = cls_Library.DBString(frmInput.searchLookUpVendor.Text.Trim());
                dt.Rows[0]["VENDOR_NAME"] = cls_Library.DBString(frmInput.TxtVendorName.Text.Trim());
                dt.Rows[0]["PRIORITY"] = cls_Library.DBInt(frmInput.spinPiority.EditValue);
                dsEdit.Tables["D_ITEM_VENDORS"].ImportRow(dt.Rows[0]);
            }
            else
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvVendors;
                dr = view.GetFocusedDataRow();
                dr["mode"] = 2;
                dr["ITEM_ID"] = ItemID;
                dr["VENDOR_ID"] = cls_Library.DBInt(frmInput.searchLookUpVendor.EditValue);
                dr["VENDOR_CODE"] = cls_Library.DBString(frmInput.searchLookUpVendor.Text.Trim());
                dr["VENDOR_NAME"] = cls_Library.DBString(frmInput.TxtVendorName.Text.Trim());
                dr["PRIORITY"] = cls_Library.DBInt(frmInput.spinPiority.EditValue);
            }
            dsEdit.Tables["D_ITEM_VENDORS"].EndInit();
            gridLocation.DataSource = dsEdit.Tables["D_ITEM_VENDORS"];
            gridLocation.RefreshDataSource();
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

                if (cls_Global_DB.DataInitial == null)
                {
                    cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
                }
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_CATEGORIES"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_CATEGORIES"));
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_BRANDS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_BRANDS"));
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_TYPES"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_TYPES"));
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_UNITS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_UNITS"));
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_VENDORS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_ITEMS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_ITEMS"));
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_DOCUMENTS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_DOCUMENTS"));
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_PO_GROUPS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_PO_GROUPS"));
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_SIZES"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_SIZES"));



                cls_Library.AssignSearchLookUp(searchCategoriesCode, "M_CATEGORIES", "รหัสหมวดหมู่", "ชื่อหมวดหมู่");
                cls_Library.AssignSearchLookUp(searchBrandCode, "M_BRANDS", "รหัสยี่ห้อสินค้า", "ชื่อยี่ห้อสินค้า");
                cls_Library.AssignSearchLookUp(searchTypesCode, "M_TYPES", "รหัสประเภทสินค้า", "ชื่อประเภทสินค้า");
                cls_Library.AssignSearchLookUp(searchUnitsCode, "M_UNITS", "รหัสหน่วยนับสินค้า", "ชื่อหน่วยนับสินค้า");
                cls_Library.AssignSearchLookUp(searchVendorsCode, "M_VENDORS", "รหัสเจ้าหนี้", "ชื่อเจ้าหนี้");
                cls_Library.AssignSearchLookUp(searchMainProductCode, "M_ITEMS", "รหัสสินค้า", "ชื่อสินค้า");
                cls_Library.AssignSearchLookUp(searchDocsCode, "M_DOCUMENTS", "รหัสเอกสาร", "ชื่อเอกสาร");
                cls_Library.AssignSearchLookUp(searchPOGroupsCode, "M_PO_GROUPS", "รหัสกลุ่มสั่งซื้อสินค้า", "ชื่อกลุ่มสั่งซื้อสินค้า");
                cls_Library.AssignSearchLookUp(searchSizesCode, "M_SIZES", "รหัสประเภทสินค้า+ขนาด", "ชื่อประเภทสินค้า+ขนาด");



            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadDefaultData :" + ex.Message);
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
            ret = cls_Data.SaveProductCode(SaveMode, PDT,dsEdit);
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
                txtPdtCode.ErrorText = "";
                txtPdtCode.Focus();
            }
            else
            {
                XtraMessageBox.Show("ไม่สามารถบันทึกรหัสสินค้าได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    SetDefaultData();
                    break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.Copy:
                    if (dsEdit.Tables["M_ITEMS"].Rows.Count <= 0) return;
                    row = dsEdit.Tables["M_ITEMS"].Rows[0];
                    txtPdtCode.Text = row["ITEM_CODE"].ToString();
                    chkIsSet.Checked = cls_Library.DBbool(row["SET_STATUS"]);
                    chkComponent.Checked = cls_Library.DBbool(row["COMPONENT_STATUS"]);
                    searchCategoriesCode.EditValue = cls_Library.DBInt(row["CATEGORY_ID"]);
                    txtCategoriesName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchCategoriesCode.EditValue), "CATEGORIES", "CATEGORY_NAME");
                    searchTypesCode.EditValue = cls_Library.DBInt(row["TYPE_ID"]);
                    txtTypesName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchTypesCode.EditValue), "TYPES", "TYPE_NAME");
                    txtAbbreviateName.Text = cls_Library.DBString(row["ABBREVIATE_NAME"]);
                    txtFullName.Text = cls_Library.DBString(row["FULL_NAME"]);
                    txtModel1.Text = cls_Library.DBString(row["MODEL1"]);
                    txtModel2.Text = cls_Library.DBString(row["MODEL2"]);
                    txtModel3.Text = cls_Library.DBString(row["MODEL3"]);
                    txtFullPrint.Text = cls_Library.DBString(row["FULL_NAME_PRINT"]);
                    txtModelPrint.Text = cls_Library.DBString(row["MODEL_PRINT"]);
                    txtBrandPrint.Text = cls_Library.DBString(row["BRAND_PRINT"]);
                    spCountCar.EditValue = cls_Library.DBDouble(row["QTY"]);
                    searchBrandCode.EditValue = cls_Library.DBInt(row["BRAND_ID"]);
                    txtBrandName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchBrandCode.EditValue), "BRANDS", "BRAND_NAME");
                    txtGenuinPart.Text = cls_Library.DBString(row["GENUIN_PART_ID"]);
                    txtProducerPart.Text = cls_Library.DBString(row["BRAND_PART_ID"]);
                    //txtFullPrint.Text = "";
                    //txtModelName.Text = "";
                    //txtBrandPart.Text = "";

                    spinQtyCurrent.EditValue = cls_Library.DBDouble(row["CURRENT_QTY"]);
                    if ((cls_Library.DBDateTime(row["COUNTING_DATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["COUNTING_DATE"]) == DateTime.MaxValue))
                    {
                        dateCount.Text = "";
                    }
                    else
                    {
                        dateCount.DateTime = cls_Library.DBDateTime(row["COUNTING_DATE"]);
                    }
                    spinQtymin.EditValue = cls_Library.DBDouble(row["MINIMUM_QTY"]);
                    if ((cls_Library.DBDateTime(row["MINIMUM_DATE"]) == DateTime.MinValue) || (cls_Library.DBDateTime(row["MINIMUM_DATE"]) == DateTime.MaxValue))
                    {
                        dateMove.Text = "";
                    }
                    else
                    {
                        dateMove.DateTime = cls_Library.DBDateTime(row["MINIMUM_DATE"]);
                    }
                    spinQtyMax.EditValue = cls_Library.DBDouble(row["MAXIMUM_QTY"]);
                    spinQtyDefect.EditValue = cls_Library.DBDouble(row["DEFECT_QTY"]);
                    spinQtyMinOrder.EditValue = cls_Library.DBDouble(row["MINIMUM_ORDER_QTY"]);
                    spinQtyReserve.EditValue = cls_Library.DBDouble(row["RESERVE_QTY"]);
                    spinQtyMinSale.EditValue = cls_Library.DBDouble(row["MINIMUM_SALE_QTY"]);
                    chkUseSerial.EditValue = cls_Library.DBbool(row["SERIAL_NO_STATUS"]);
                    searchSizesCode.EditValue = cls_Library.DBInt(row["SIZE_ID"]);
                    txtSizesName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchSizesCode.EditValue), "SIZES", "SIZE_NAME");
                    if (cls_Library.DBInt(searchSizesCode.EditValue) == 0) searchSizesCode.EditValue = null;
                    txtSizeInner.Text  = cls_Library.DBString(row["SIZE_INNER"]);
                    txtSizeOutside.Text =  cls_Library.DBString(row["SIZE_OUTSIDE"]);
                    txtSizeThick.Text = cls_Library.DBString(row["SIZE_THICK"]);
                    txtMarkBarcode.Text = row["MAKER_BARCODE_NO"].ToString();
                    txtRemark.Text = cls_Library.DBString(row["REMARK"]); 
                    break;
                }
                SetGrid();
            }
            catch (Exception ex)
            {
            MessageBox.Show("SetDataToControl :" + ex.Message);
            }
        }

        private void SetDefaultData()
        {
            try
            {
            searchTypesCode.EditValue = 1;
            txtTypesName.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(searchTypesCode.EditValue), "TYPES", "TYPE_NAME");
            searchCategoriesCode.EditValue = cls_Library.DBInt(cls_Data.GetNameFromTBname("001", "CATEGORIES", "CATEGORY_ID"));
            txtCategoriesName.Text = cls_Data.GetNameFromTBname("001", "CATEGORIES", "CATEGORY_NAME");
            searchSizesCode.EditValue = cls_Library.DBInt(cls_Data.GetNameFromTBname("001", "CATEGORIES", "CATEGORY_ID"));
            txtSizesName.Text = cls_Data.GetNameFromTBname("001", "SIZES", "SIZE_NAME");
            //txtPdtCode.Text = "";
            //chkIsSet.Checked = false;
            //chkComponent.Checked = false;
            //searchCategoriesCode.EditValue = 0;
            //txtCategoriesName.Text = "";
            //txtAbbreviateName.Text = "";
            //txtFullName.Text = "";
            //searchBrandCode.EditValue = 0;
            //txtBrandName.Text = "";
            //txtGenuinPart.Text = "";
            //txtProducerPart.Text = "";
            //txtFullPrint.Text = "";
            //txtModelName.Text = "";
            //txtBrandPart.Text = "";

            ////จำนวนสินค้าในคลัง
            //spinQtyCurrent.EditValue = 0;
            //dateCount.EditValue = DateTime.Now;
            //spinQtymin.EditValue = 0;
            //dateMove.EditValue = DateTime.Now;
            //spinQtyMax.EditValue = 0;
            //spinQtyDefect.EditValue = 0;
            //spinQtyMinOrder.EditValue = 0;
            //spinQtyReserve.EditValue = 0;
            //spinQtyMinSale.EditValue = 0;
            //chkUseSerial.EditValue = 0;


            ////ขนาด/หน่ววนับ
            //txtTypeName.Text = "";
            //txtSizeInner.Text = "";
            //txtSizeOutside.Text = "";
            //txtSizeThick.Text = "";

            ////หมายเลขอะไหล่ทดแทน
            //txtMarkBarcode.Text = "";


            }
            catch (Exception ex)
            {
            MessageBox.Show("SetDefaultData : " + ex.Message);
            }
        }

        private void SetGrid()
        {
            cls_Global_DB.GB_DitemLocation_count = 0;
            cls_Global_DB.GB_DitemUnit_count = 0;
            cls_Global_DB.GB_DitemPart_count = 0;
            cls_Global_DB.GB_DitemPOgroup_count = 0;
            cls_Global_DB.GB_DitemVendor_count = 0;
            cls_Global_DB.GB_DitemSet_count = 0;
            cls_Global_DB.GB_DitemComponent_count = 0;
            cls_Global_DB.GB_DitemPicture_count = 0;
            cls_Global_DB.GB_DitemDocument_count = 0;

            for (byte i = 1; i <= 9; i++)
            AddDataSourceToGrid(i);

            //คลังสินค้า   1
            colL_id.FieldName = "SEQUENSE_NO";
            colL_code.FieldName = "LOCATION_NAME";
            colL_type.FieldName = "";       //XXX
            colL_qty.FieldName = "QTY";

            //หน่วยนับ
            colU_id.FieldName = "SEQUENSE_NO";
            colU_code.FieldName = "UNIT_CODE";
            colU_name.FieldName = "UNIT_NAME";
            colU_qty.FieldName = "MULTIPLY_QTY";
            colU_buy.FieldName = "BUY_STATUS";
            colU_sell.FieldName = "SALE_STATUS";

            //อะไหล่
            colA_id.FieldName = "SEQUENSE_NO";
            colA_code.FieldName = "PART_ID";
            colA_band.FieldName = "BRAND_DESCRIPTION";
            colA_status.FieldName = "STATUS";
            colA_status.ColumnEdit = rs_status;

            rs_status.DataSource = DTstatus;
            rs_status.PopulateColumns();
            rs_status.Columns["Status"].Caption = "สถานะ";
            rs_status.Columns["Status_Name"].Caption = "สถานะ";
            rs_status.ValueMember = "Status";
            rs_status.DisplayMember = "Status_Name";

            //กลุ่มสั่งสินค้า
            colP_id.FieldName = "PO_GROUP_ID";
            colP_code.FieldName = "PO_GROUP_CODE";
            colP_name.FieldName = "";   //XXX


            //ผู้แทนจำหน่าย
            colV_id.FieldName = "SEQUENSE_NO";
            colV_code.FieldName = "VENDOR_CODE";
            colV_name.FieldName = "VENDOR_NAME";
            colV_priority.FieldName = "PRIORITY";

            //ประเภทสินค้าหลัก

            //สมาชิก
            colS_id.FieldName = "SEQUENSE_NO";
            colS_code.FieldName = "ITEM_CODE";
            colS_brand.FieldName = "BRAND_CODE";
            colS_model1.FieldName = "MODEL1";
            colS_nameF.FieldName = "FULL_NAME";
            colS_qty.FieldName = "QTY";

            //ส่วนประกอบ
            colC_id.FieldName = "COMPONENT_ID";
            colC_code.FieldName = "COMPONENT_ID";
            colC_name.FieldName = "COMPONENT_NAME";
            colC_qty.FieldName = "QTY";

            //เอกสาร
            colD_id.FieldName = "SEQUENSE_NO";
            colD_code.FieldName = "DOCUMENT_CODE";
            colD_name.FieldName = "DOCUMENT_NAME";
            colD_type.FieldName = "DOCUMENT_DESCRIPTION";
            colD_location.FieldName = "DOCUMENT_ADDRESS";

        }

        #endregion

        public frm_Product_Record(cls_Struct.ActionMode mode, int id)
        {
            InitializeComponent();
            this.KeyPreview = true;
            DataMode = mode;
            ItemID = id;
            InitialDialog();
            txtPdtCode.Focus();
        }

        private void frm_Product_Record_Load(object sender, EventArgs e)
        {
            //ThreadStart();
        }

        private void btLocationAdd_Click(object sender, EventArgs e)
        {
            InitialDialogLocation(0);
        }

        private void btUnitAdd_Click(object sender, EventArgs e)
        {
            InitialDialogUnit(0);
        }

        private void btPartAdd_Click(object sender, EventArgs e)
        {
            InitialDialogAlternate(0);
        }

        private void btOrderAdd_Click(object sender, EventArgs e)
        {
            InitialDialogPOGroup(0);
        }

        private void btVendorAdd_Click(object sender, EventArgs e)
        {
            InitialDialogVendor(0);
        }

        private void btT6Add_Click(object sender, EventArgs e)
        {
            //frmD_TypePdtInput frm = new frmD_TypePdtInput();
            //frm.ShowDialog();
        }

        private void btSetAdd_Click(object sender, EventArgs e)
        {
            InitialDialogProductSet(0);
        }

        private void btCompAdd_Click(object sender, EventArgs e)
        {
            InitialDialogComponent(0);
        }


        private void searchPdtType_MouseDown(object sender, MouseEventArgs e)
        {
            //frm_CategoriesC_List frm = new frm_CategoriesC_List();
            //frm.ShowDialog();
        }

        private void BTcancel_Click(object sender, EventArgs e)
        {
            if (IsSaveOK)
                this.DialogResult = DialogResult.OK;
            else
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void searchCategoriesCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
            txtCategoriesName.Text = cls_Data.GetNameFromTBname(id, "CATEGORIES", "CATEGORY_NAME");
            }
        }

        private void searchTypesCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
            txtTypesName.Text = cls_Data.GetNameFromTBname(id, "TYPES", "TYPE_NAME");
            }
        }

        private void btLocationEdit_Click(object sender, EventArgs e)
        {
            InitialDialogLocation(1);
        }

        private void btLocationDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvLocation.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvLocation.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_LOCATIONS"].AcceptChanges();
            dsEdit.Tables["D_ITEM_LOCATIONS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_LOCATIONS"].AcceptChanges();
            gvLocation.RefreshData();
            gridLocation.RefreshDataSource();
            }
        }

        private void gvLocation_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void btUnitDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvUnit.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvUnit.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_UNITS"].AcceptChanges();
            dsEdit.Tables["D_ITEM_UNITS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_UNITS"].AcceptChanges();
            gvUnit.RefreshData();
            gridUnit.RefreshDataSource();
            }
        }

        private void btUnitEdit_Click(object sender, EventArgs e)
        {
            InitialDialogUnit(1);
        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            bool err = false;

            if (txtPdtCode.EditValue == null || txtPdtCode.Text == "")
            {
                XtraMessageBox.Show("กรุณาระบุรหัสสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPdtCode.ErrorText = "กรุณาระบุรหัสสินค้า";
                txtPdtCode.Focus();
                err = true;
            }
            else
            {
                if (CheckCodeExist(txtPdtCode.Text.Trim()))
                {
                    XtraMessageBox.Show("มีรหัสสินค้านี้ในฐานข้อมูลแล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPdtCode.ErrorText = "มีรหัสสินค้านี้ในฐานข้อมูลแล้ว";
                    txtPdtCode.Focus();
                    err = true;
                }

            }

            if (!err)
            {
                if (searchCategoriesCode.EditValue == null || searchCategoriesCode.Text == "เลือกหมวดหมู่สินค้า")
                {
                    XtraMessageBox.Show("กรุณาระบุหมวดหมู่สินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchCategoriesCode.ErrorText = "กรุณาระบุหมวดหมู่สินค้า";
                    searchCategoriesCode.Focus();
                    err = true;
                }
            }

            if (!err)
            {
                if (searchTypesCode.EditValue == null || searchTypesCode.Text == "เลือกประเภทสินค้า")
                {
                    XtraMessageBox.Show("กรุณาระบุประเภทสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchTypesCode.ErrorText = "กรุณาระบุประเภทสินค้า";
                    searchTypesCode.Focus();
                    err = true;
                }
            }

            if (!err)
            {
                if (searchBrandCode.EditValue == null || searchBrandCode.Text == "เลือกยี่ห้อสินค้า")
                {
                    XtraMessageBox.Show("กรุณาระบุยี่ห้อสินค้า", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchBrandCode.ErrorText = "กรุณาระบุยี่ห้อสินค้า";
                    searchBrandCode.Focus();
                    err = true;
                }
            }

            if (!err)
            {
                if (searchSizesCode.EditValue == null || searchSizesCode.Text == "เลือกประเภทสินค้า+ขนาด")
                {
                    XtraMessageBox.Show("กรุณาระบุประเภทสินค้า+ขนาด", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    searchSizesCode.ErrorText = "กรุณาระบุประเภทสินค้า+ขนาด";
                    searchSizesCode.Focus();
                    err = true;
                }
            }

            //ตรวจสอบหน่วยนับ

            #region  "  หน่วยนับ  "
            //ตรวจสอบเงื่อนไข
            string Xcode = "";
            double Xquan = 0;
            bool Xbuy = false;
            bool Xsale = false;
            bool UnitOK = false;

            //if ((DataMode == cls_Struct.ActionMode.Add) || (DataMode == cls_Struct.ActionMode.Copy))
            //{
            ////ตรวจสอบรหัส
            //for (int i = 0; i < dsEdit.Tables["D_ITEM_UNITS"].Rows.Count; i++)
            //{
            //    Xcode = cls_Library.DBString(dsEdit.Tables["D_ITEM_UNITS"].Rows[i]["UNIT_NAME"]);
            //    if (Xcode.ToUpper() == TxtUnitName.Text.ToUpper())
            //    {
            //        XtraMessageBox.Show("หน่วยนับสินค้าซ้ำกับที่กำหนดไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        err = true;
            //        return;
            //    }
            //}     

                var duplicates = dsEdit.Tables["D_ITEM_UNITS"].AsEnumerable().GroupBy(r => r[10]).Where(gr => gr.Count() > 1).ToList();
                if (duplicates.Any())
                {
                    XtraMessageBox.Show("หน่วยนับสินค้าซ้ำ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    err = true;
                    return;
                }

                ////ตรวจสอบจำนวน
                //for (int i = 0; i < _dtUit.Rows.Count; i++)
                //{
                //    Xquan = cls_Library.DBDouble(_dtUit.Rows[i]["MULTIPLY_QTY"]);
                //    if (Xquan == cls_Library.DBInt(spinQuantity.EditValue))
                //    {
                //        XtraMessageBox.Show("จำนวนหน่วยซ้ำกับที่กำหนดไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        err = true;
                //        return;
                //    }
                //}

                duplicates = dsEdit.Tables["D_ITEM_UNITS"].AsEnumerable().GroupBy(r => r[5]).Where(gr => gr.Count() > 1).ToList();
                if (duplicates.Any())
                {
                    XtraMessageBox.Show("จำนวนหน่วยซ้ำ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    err = true;
                    return;
                }

                ////หน่วยซื้อ
                //if (checkBuy.Checked == true)
                //{
                //    for (int i = 0; i < _dtUit.Rows.Count; i++)
                //    {
                //        Xbuy = cls_Library.DBbool(_dtUit.Rows[i]["BUY_STATUS"]);
                //        if (Xbuy)
                //        {
                //            XtraMessageBox.Show("มีการกำหนดหน่วยซื้อไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            err = true;
                //            return;
                //        }
                //    }
                //}

                duplicates = dsEdit.Tables["D_ITEM_UNITS"].AsEnumerable().GroupBy(r => r[6]).Where(gr => gr.Count() > 1).ToList();
                if (duplicates.Any())
                {
                    XtraMessageBox.Show("หน่วยซื้อซ้ำ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    err = true;
                    return;
                }



                ////หน่วยขาย
                //if (checkSale.Checked == true)
                //{
                //    for (int i = 0; i < _dtUit.Rows.Count; i++)
                //    {
                //        Xsale = cls_Library.DBbool(_dtUit.Rows[i]["SALE_STATUS"]);
                //        if (Xsale)
                //        {
                //            XtraMessageBox.Show("มีการกำหนดหน่วยขายไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            err = true;
                //            return;
                //        }
                //    }
                //}

                duplicates = dsEdit.Tables["D_ITEM_UNITS"].AsEnumerable().GroupBy(r => r[7]).Where(gr => gr.Count() > 1).ToList();
                if (duplicates.Any())
                {
                    XtraMessageBox.Show("หน่วยขายซ้ำ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    err = true;
                    return;
                }
            //}
            //else
            //{
            //    var duplicates = dsEdit.Tables["D_ITEM_UNITS"].AsEnumerable().GroupBy(r => r[10]).Where(gr => gr.Count() > 1).ToList();
            //    if (duplicates.Any())
            //    {
            //        XtraMessageBox.Show("หน่วยนับสินค้าซ้ำกับที่กำหนดไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        err = true;
            //        return;
            //    }

            //    //ตรวจสอบจำนวน
            //    //for (int i = 0; i < _dtUit.Rows.Count; i++)
            //    //{
            //    //    Xquan = cls_Library.DBDouble(_dtUit.Rows[i]["MULTIPLY_QTY"]);
            //    //    if ((Xquan == cls_Library.DBInt(spinQuantity.EditValue)) && (i + 1 != _iRow))
            //    //    {
            //    //        XtraMessageBox.Show("จำนวนหน่วยซ้ำกับที่กำหนดไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //        err = true;
            //    //        return;
            //    //    }
            //    //}

            //    ////หน่วยซื้อ
            //    //if (checkBuy.Checked == true)
            //    //{
            //    //    for (int i = 0; i < _dtUit.Rows.Count; i++)
            //    //    {
            //    //        Xbuy = cls_Library.DBbool(_dtUit.Rows[i]["BUY_STATUS"]);
            //    //        if ((Xbuy) && (i + 1 != _iRow))
            //    //        {
            //    //            XtraMessageBox.Show("มีการกำหนดหน่วยซื้อไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //            err = true;
            //    //            return;
            //    //        }
            //    //    }
            //    //}

            //    ////หน่วยขาย
            //    //if (checkSale.Checked == true)
            //    //{
            //    //    for (int i = 0; i < _dtUit.Rows.Count; i++)
            //    //    {
            //    //        Xsale = cls_Library.DBbool(_dtUit.Rows[i]["SALE_STATUS"]);
            //    //        if ((Xsale) && (i + 1 != _iRow))
            //    //        {
            //    //            XtraMessageBox.Show("มีการกำหนดหน่วยขายไว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //            err = true;
            //    //            return;
            //    //        }
            //    //    }
            //    //}
            //}

            //ตรวจสอบหน่วยซื้อ/ขาย
            bool xSale = false;
            bool xBuy = false;

            bool SB = false;

            //หน่วยซื้อ
            for (int i = 0; i < dsEdit.Tables["D_ITEM_UNITS"].Rows.Count; i++)
            {
                xBuy = cls_Library.DBbool(dsEdit.Tables["D_ITEM_UNITS"].Rows[i]["BUY_STATUS"]);
                if (xBuy)
                {
                    SB = true;
                }
            }
            if (!SB)
            {
                XtraMessageBox.Show("ไม่มีการกำหนดหน่วยซื้อ", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = true;
                return;
            }

            //หน่วยขาย
            SB = false;
            for (int i = 0; i < dsEdit.Tables["D_ITEM_UNITS"].Rows.Count; i++)
            {
                xSale = cls_Library.DBbool(dsEdit.Tables["D_ITEM_UNITS"].Rows[i]["SALE_STATUS"]);
                if (xSale) 
                {
                    SB = true;
                }
            }
            if (!SB)
            {
                XtraMessageBox.Show("ไม่มีการกำหนดหน่วยขาย", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = true;
                return;
            }

            //ตรวจสอบจำนวนหน่อยย่อย
            UnitOK = false;
            for (int i = 0; i < dsEdit.Tables["D_ITEM_UNITS"].Rows.Count; i++)
            {
                Xquan = cls_Library.DBDouble(dsEdit.Tables["D_ITEM_UNITS"].Rows[i]["MULTIPLY_QTY"]);
                if (Xquan == 1)
                {
                    UnitOK = true;
                }
            }
            if (!UnitOK)
            {
                XtraMessageBox.Show("ไม่มีการกำหนดหน่วยย่อยเท่ากับ 1", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = true;
                return;
            }

            #endregion

            if (err)
            {
                return;
            }

            DialogResult Result = XtraMessageBox.Show("ต้องการบันทึกรหัสสินค้า : " + txtPdtCode.Text.Trim() + " ใช่หรือไม่?", "บันทึก", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                if (SaveData())
                {
                    if (cls_Global_DB.DataInitial.Tables.Contains("M_ITEMS"))
                    {
                        cls_Global_DB.DataInitial.Tables.Remove("M_ITEMS");
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_ITEMS"));
                    }
                    XtraMessageBox.Show("บันทึกรหัสสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    XtraMessageBox.Show("บันทึกรหัสสินค้าไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void frm_Product_Record_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.F2:
                BTsave_Click(sender, e);
                break;
            case Keys.Escape:
                BTcancel_Click(sender, e);
                break;
            }
        }

        private void searchBrandCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
            txtBrandName.Text = cls_Data.GetNameFromTBname(id, "BRANDS", "BRAND_NAME");
            }
        }

        private void gvUnit_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void gvAlternate_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void btPartDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvAlternate.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvAlternate.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"].AcceptChanges();
            dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_ALTERNATE_PARTS"].AcceptChanges();
            gvAlternate.RefreshData();
            gridAlternate.RefreshDataSource();
            }
        }

        private void btPartEdit_Click(object sender, EventArgs e)
        {
            InitialDialogAlternate(1);
        }

        private void btVendorEdit_Click(object sender, EventArgs e)
        {
            InitialDialogVendor(1);
        }

        private void btVendorDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvVendors.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvVendors.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_VENDORS"].AcceptChanges();
            dsEdit.Tables["D_ITEM_VENDORS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_VENDORS"].AcceptChanges();
            gvVendors.RefreshData();
            gridVendors.RefreshDataSource();
            }
        }

        private void btOrderDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvPO_Group.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvPO_Group.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_PO_GROUPS"].AcceptChanges();
            dsEdit.Tables["D_ITEM_PO_GROUPS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_PO_GROUPS"].AcceptChanges();
            gvPO_Group.RefreshData();
            gridPO_Group.RefreshDataSource();
            }
        }

        private void gvPO_Group_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void gvVendors_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void gvItemSet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void btOrderEdit_Click(object sender, EventArgs e)
        {
            InitialDialogPOGroup(1);
        }

        private void btSetDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvItemSet.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvItemSet.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_SETS"].AcceptChanges();
            dsEdit.Tables["D_ITEM_SETS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_SETS"].AcceptChanges();
            gvItemSet.RefreshData();
            gridItemSet.RefreshDataSource();
            }
            chkIsSet.Checked = dsEdit.Tables["D_ITEM_SETS"].Rows.Count > 0 ? true : false;
        }

        private void btSetEdit_Click(object sender, EventArgs e)
        {
            InitialDialogProductSet(1);
        }

        private void btCompEdit_Click(object sender, EventArgs e)
        {
            InitialDialogComponent(1);
        }

        private void btCompDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvComponent.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvComponent.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_COMPONENTS"].AcceptChanges();
            dsEdit.Tables["D_ITEM_COMPONENTS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_COMPONENTS"].AcceptChanges();
            gvComponent.RefreshData();
            gridComponent.RefreshDataSource();
            }
            chkComponent.Checked = dsEdit.Tables["D_ITEM_COMPONENTS"].Rows.Count > 0 ? true : false;
        }

        private void btDocDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvDoc.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvDoc.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_DOCUMENTS"].AcceptChanges();
            dsEdit.Tables["D_ITEM_DOCUMENTS"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_DOCUMENTS"].AcceptChanges();
            gvDoc.RefreshData();
            gridDoc.RefreshDataSource();
            }
        }

        private void btDocAdd_Click(object sender, EventArgs e)
        {
            InitialDialogDocument(0);
        }

        private void btDocEdit_Click(object sender, EventArgs e)
        {
            InitialDialogDocument(1);
        }

        private void gvComponent_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void gvPicture_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void btPictureAdd_Click(object sender, EventArgs e)
        {
            InitialDialogPicture(0);
        }

        private void btPictureEdit_Click(object sender, EventArgs e)
        {
            InitialDialogPicture(1);
        }

        private void btPictureDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvPicture.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvPicture.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
            dsEdit.Tables["D_ITEM_PICTURES"].AcceptChanges();
            dsEdit.Tables["D_ITEM_PICTURES"].Rows[irow].Delete();
            Drow.Delete();
            dsEdit.Tables["D_ITEM_PICTURES"].AcceptChanges();
            gvPicture.RefreshData();
            gridPicture.RefreshDataSource();
            pictureDisplay.Image = null;
            }
        }

        private void gvPicture_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow Drow = gvPicture.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvPicture.FocusedRowHandle;
            pictureDisplay.Image = null;
            var picbyte = (Byte[])(Drow["PICTURE_IMAGE"]);
            var stream = new MemoryStream(picbyte);
            pictureDisplay.Image = Image.FromStream(stream);
        }

        private void gvDoc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void searchSizesCode_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit item = (SearchLookUpEdit)sender;
            int id = Convert.ToInt32(item.EditValue);
            if (id > 0)
            {
            txtSizesName.Text = cls_Data.GetNameFromTBname(id, "SIZES", "SIZE_NAME");
            }
        }
    }
}