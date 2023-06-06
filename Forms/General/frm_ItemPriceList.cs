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
    public partial class frm_ItemPriceList : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtData = new DataTable();
        private DataTable dtSave;
        private int ItemID = 0;
        #endregion

        #region Function

        private void AssignDataFromComponent()
        {
            //dtSave = dtData.Clone();
            //DataRow row = dtSave.NewRow();

            //row["MAKER_BARCODE_NO"] = txtMarkBarcode.Text.Trim();
            //dtSave.Rows.Add(row);
        }

        private void SaveData()
        {
            try
            {
            if (cls_Library.DBDecimal(spinPrice.EditValue) <= 0)
            {
                XtraMessageBox.Show("กรุณาระบุราคาใหม่", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((datePrice.DateTime == DateTime.MinValue) || (datePrice.DateTime == DateTime.MaxValue))
            {
                XtraMessageBox.Show("กรุณาระบุวันที่ราคาใหม่", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!cls_Library.IsDate(datePrice.DateTime))
            {
                XtraMessageBox.Show("กรุณาระบุวันที่ราคาใหม่", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AssignDataFromComponent();
            if (SavePriceList(ItemID))
            {
                XtraMessageBox.Show("แก้ไขข้อมูลรหัสสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("แก้ไขข้อมูลรหัสสินค้าไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("SaveData: " + ex.Message);
            }
        }

        private bool SavePriceList(int ItemID)
        {
            DataSet _dsdata = new DataSet();
            DataTable dtdata = new DataTable();
            int PriceListID = 0;
            DateTime DT;
            bool ret = false;

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = conn.CreateCommand();
            SqlDataReader rd = null;
            SqlTransaction TransactionControl = null;
            SqlParameter shipperIdParam = null;
            Queue<object> MS_Queue = new Queue<object>();
            string Sql = "";
            int Xid = 0;
            decimal P1, P2, P3;
            DateTime DAT1, DAT2, DAT3;
            DateTime DT1, DT2, DT3;
            bool Uok = false;
            int iN = 0;
            int mode = 0;

            decimal NEW_PRICE = 0;
            DateTime NEW_DATE = DateTime.MinValue;

            cls_Global_DB.ConnectDatabase(ref conn);

            try
            {
                TransactionControl = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                P1 = 0; P2 = 0; P3 = 0;
                DAT1 = DateTime.MinValue; DAT2 = DateTime.MinValue; DAT3 = DateTime.MinValue;
                DT1 = DateTime.MinValue; DT2 = DateTime.MinValue; DT3 = DateTime.MinValue;
                dtdata = cls_Data.GetListPriceListByItemID(ItemID);

                NEW_PRICE = cls_Library.DBDecimal(spinPrice.EditValue);
                NEW_DATE = cls_Library.DBDateTime(datePrice.DateTime);
                mode = 0;
                if (dtdata.Rows.Count > 0)
                {
                    mode = 1;
                    P1 = cls_Library.DBDecimal(dtdata.Rows[0]["PRICE1"]);
                    P2 = cls_Library.DBDecimal(dtdata.Rows[0]["PRICE2"]);
                    P3 = cls_Library.DBDecimal(dtdata.Rows[0]["PRICE3"]);

                    DAT1 = cls_Library.DBDateTime(dtdata.Rows[0]["DATEACTIVE1"]);
                    DAT2 = cls_Library.DBDateTime(dtdata.Rows[0]["DATEACTIVE2"]);
                    DAT3 = cls_Library.DBDateTime(dtdata.Rows[0]["DATEACTIVE3"]);

                    DT1 = cls_Library.DBDateTime(dtdata.Rows[0]["DATE1"]);
                    DT2 = cls_Library.DBDateTime(dtdata.Rows[0]["DATE2"]);
                    DT3 = cls_Library.DBDateTime(dtdata.Rows[0]["DATE3"]);
                }

                Uok = true;

                if ((NEW_PRICE == P1) && (NEW_DATE == DAT1))
                {
                    DT1 = DateTime.Now;
                    Uok = false;
                }
                if ((NEW_PRICE == P2) && (NEW_DATE == DAT2))
                {
                    DT2 = DateTime.Now;
                    Uok = false;
                }
                if ((NEW_PRICE == P3) && (NEW_DATE == DAT3))
                {
                    DT3 = DateTime.Now;
                    Uok = false;
                }

                iN = 0;
                if (Uok)
                {
                    if (P1 <= 0)
                    {
                    iN = 1;
                    P1 = NEW_PRICE;
                    DAT1 = cls_Library.Date_CvDMY(NEW_DATE.Day, NEW_DATE.Month, NEW_DATE.Year, false);
                    DT1 = DateTime.Now;
                    }
                    else
                    {
                    if (P2 <= 0)
                    {
                        iN = 2;
                        P2 = NEW_PRICE;
                        DAT2 = cls_Library.Date_CvDMY(NEW_DATE.Day, NEW_DATE.Month, NEW_DATE.Year, false);
                        DT2 = DateTime.Now;
                    }
                    else
                    {
                        if (P3 <= 0)
                        {
                        iN = 3;
                        P3 = NEW_PRICE;
                        DAT3 = cls_Library.Date_CvDMY(NEW_DATE.Day, NEW_DATE.Month, NEW_DATE.Year, false);
                        DT3 = DateTime.Now;
                        }
                        else
                        {
                        P1 = P2;
                        DAT1 = DAT2;
                        P2 = P3;
                        DAT2 = DAT3;
                        iN = 3;
                        P3 = NEW_PRICE;
                        DAT3 = cls_Library.Date_CvDMY(NEW_DATE.Day, NEW_DATE.Month, NEW_DATE.Year, false);
                        DT3 = DateTime.Now;
                        }
                    }
                    }
                }

                if (mode ==0)
                {
                    Sql = "Insert Into M_PRICELIST WITH (UPDLOCK) (ITEM_ID,UNIT_ID,GENUIN_PART_ID,BRAND_PART_ID,FULL_NAME,MODEL,NEW_PRICE,NEW_DATE,PRICE1,PRICE2,PRICE3,DATEACTIVE1,DATEACTIVE2,DATEACTIVE3,DATE1,DATE2,DATE3,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                            + " VALUES(@ITEM_ID,@UNIT_ID,@GENUIN_PART_ID,@BRAND_PART_ID,@FULL_NAME,@MODEL,@NEW_PRICE,@NEW_DATE,@PRICE1,@PRICE2,@PRICE3,@DATEACTIVE1,@DATEACTIVE2,@DATEACTIVE3,@DATE1,@DATE2,@DATE3,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)"
                            + " SET @ID=SCOPE_IDENTITY()";
                }
                else
                {
                    Sql = "Update M_PRICELIST WITH (UPDLOCK) Set ITEM_ID=@ITEM_ID,UNIT_ID=@UNIT_ID,BRAND_PART_ID=@BRAND_PART_ID,FULL_NAME=@FULL_NAME,MODEL=@MODEL,NEW_PRICE=@NEW_PRICE,NEW_DATE=@NEW_DATE,"
                    + "PRICE1=@PRICE1,PRICE2=@PRICE2,PRICE3=@PRICE3,DATEACTIVE1=@DATEACTIVE1,DATEACTIVE2=@DATEACTIVE2,DATEACTIVE3=@DATEACTIVE3,DATE1=@DATE1,DATE2=@DATE2,DATE3=@DATE3,"
                    + "UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE"
                    + " Where ITEM_ID=@ITEM_ID";
                }
        

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sql;
                cmd.CommandTimeout = 30;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = ItemID;
                cmd.Parameters.Add("@UNIT_ID", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@BRAND_PART_ID", SqlDbType.NVarChar, 50).Value = cls_Data.GetNameFromTBname(ItemID, "ITEMS", "BRAND_PART_ID");
                cmd.Parameters.Add("@GENUIN_PART_ID", SqlDbType.NVarChar, 50).Value = cls_Data.GetNameFromTBname(ItemID, "ITEMS", "GENUIN_PART_ID"); 
                cmd.Parameters.Add("@FULL_NAME", SqlDbType.NVarChar, 100).Value = cls_Data.GetNameFromTBname(ItemID, "ITEMS", "FULL_NAME"); 
                cmd.Parameters.Add("@MODEL", SqlDbType.NVarChar, 50).Value = cls_Data.GetNameFromTBname(ItemID, "ITEMS", "MODEL1"); 
                cmd.Parameters.Add("@NEW_PRICE", SqlDbType.Decimal).Value = NEW_PRICE;
                DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(NEW_DATE).ToShortDateString());
                cmd.Parameters.Add("@NEW_DATE", SqlDbType.DateTime).Value = DT;
                cmd.Parameters.Add("@PRICE1", SqlDbType.Decimal).Value = P1;
                cmd.Parameters.Add("@PRICE2", SqlDbType.Decimal).Value = P2;
                cmd.Parameters.Add("@PRICE3", SqlDbType.Decimal).Value = P3;
                if ((DAT1 == DateTime.MinValue) || (DAT1 == DateTime.MaxValue))
                    cmd.Parameters.Add("@DATEACTIVE1", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DATEACTIVE1", SqlDbType.DateTime).Value = DAT1;
                if ((DAT2 == DateTime.MinValue) || (DAT2 == DateTime.MaxValue))
                    cmd.Parameters.Add("@DATEACTIVE2", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DATEACTIVE2", SqlDbType.DateTime).Value = DAT2;
                if ((DAT3 == DateTime.MinValue) || (DAT3 == DateTime.MaxValue))
                    cmd.Parameters.Add("@DATEACTIVE3", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DATEACTIVE3", SqlDbType.DateTime).Value = DAT3;
                if ((DT1 == DateTime.MinValue) || (DT1 == DateTime.MaxValue))
                    cmd.Parameters.Add("@DATE1", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DATE1", SqlDbType.DateTime).Value = DT1;
                if ((DT2 == DateTime.MinValue) || (DT2 == DateTime.MaxValue))
                    cmd.Parameters.Add("@DATE2", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DATE2", SqlDbType.DateTime).Value = DT2;
                if ((DT3 == DateTime.MinValue) || (DT3 == DateTime.MaxValue))
                    cmd.Parameters.Add("@DATE3", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@DATE3", SqlDbType.DateTime).Value = DT3;

                if (mode == 0)
                {
                    cmd.Parameters.Add("@CREATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                    DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
                    cmd.Parameters.Add("@CREATE_DATE", SqlDbType.DateTime).Value = DT;
                    cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("@DELETED", SqlDbType.Bit).Value = 0;
                    cmd.Parameters.Add("@DELETE_BY", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@DELETE_DATE", SqlDbType.DateTime).Value = DBNull.Value;
                    shipperIdParam = new SqlParameter("@ID", SqlDbType.Int);
                    shipperIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(shipperIdParam);
                }
                if (mode == 1)
                {
                    cmd.Parameters.Add("@PRICELIST_ID", SqlDbType.Int).Value = Xid;
                    cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                    DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
                    cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
                }

                cmd.Transaction = TransactionControl;
                cmd.ExecuteNonQuery();


                TransactionControl.Commit();
                ret = true;
            }
            catch (Exception ex)
            {
                TransactionControl.Rollback();
                XtraMessageBox.Show(ex.Message);
                ret = false;
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
                conn.Dispose();
            }

            return ret;

        }

        private void SetDataToControl()
        {
            //try
            //{
            //    DataRow row = dtData.Rows[0];
            //    txtMarkBarcode.Text = cls_Library.DBString(row["MAKER_BARCODE_NO"]);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("SetDataToControl: " + ex.Message);
            //}
        }

        private void ThreadStart()
        {
            if (!bwItem.IsBusy) bwItem.RunWorkerAsync();
        }
        #endregion

        public frm_ItemPriceList(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dtData = cls_Data.GetListPriceListByItemID(ItemID);
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frm_ItemPriceList_KeyDown(object sender, KeyEventArgs e)
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