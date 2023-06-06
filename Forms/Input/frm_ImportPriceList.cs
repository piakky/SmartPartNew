using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.XtraEditors.Repository;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using SmartPart.Class;
using System.Data.OleDb;

namespace SmartPart.Forms.Input
{
 
  public partial class frm_ImportPriceList : DevExpress.XtraEditors.XtraForm
  {
    #region ตัวแปร


    #endregion

    #region Function
    private DataTable GetListPriceListByBranPartID(string ItemID)
    {
      DataSet dsResult = new DataSet();
      SqlConnection conn = new SqlConnection();
      SqlDataAdapter _dataAdapter = new SqlDataAdapter();
      StringBuilder sb = new StringBuilder();
      try
      {
        if (cls_Global_DB.ConnectDatabase(ref conn))
        {
          sb.AppendLine("Select * From M_PRICELIST Where BRAND_PART_ID=@BRAND_PART_ID And DELETED=0");

          _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
          _dataAdapter.SelectCommand.Parameters.Clear();
          _dataAdapter.SelectCommand.Parameters.Add("@BRAND_PART_ID", SqlDbType.Char,50).Value = ItemID;
          _dataAdapter.Fill(dsResult, "M_PRICELIST");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("GetListPriceListByBranPartID :" + ex.Message);
      }
      finally
      {
        cls_Global_DB.CloseDB(ref conn);
        conn.Dispose();
      }
      return dsResult.Tables["M_PRICELIST"].Copy();
    }

    private DataTable GetListPriceListByGenuinID(string ItemID)
    {
      DataSet dsResult = new DataSet();
      SqlConnection conn = new SqlConnection();
      SqlDataAdapter _dataAdapter = new SqlDataAdapter();
      StringBuilder sb = new StringBuilder();
      try
      {
        if (cls_Global_DB.ConnectDatabase(ref conn))
        {
          sb.AppendLine("Select * From M_PRICELIST Where GENUIN_PART_ID=@GENUIN_PART_ID And DELETED=0");

          _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
          _dataAdapter.SelectCommand.Parameters.Clear();
          _dataAdapter.SelectCommand.Parameters.Add("@GENUIN_PART_ID", SqlDbType.Char, 50).Value = ItemID;
          _dataAdapter.Fill(dsResult, "M_PRICELIST");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("GetListPriceListByGenuinID :" + ex.Message);
      }
      finally
      {
        cls_Global_DB.CloseDB(ref conn);
        conn.Dispose();
      }
      return dsResult.Tables["M_PRICELIST"].Copy();
    }

    #endregion

    private OleDbConnection ConnectAccess(string file = "")
    {
      OleDbConnection conOle;

      string sql = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password=securem5data;", file);

      conOle = new OleDbConnection(sql);

      try
      {
        if (conOle.State == System.Data.ConnectionState.Open) conOle.Close();
        conOle.Open();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "ConnectAccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
      }
      return conOle;
    }


    public frm_ImportPriceList()
    {
      InitializeComponent();
      txtDescription.Text = "";
    }

    private void btnImGetCus_Click(object sender, EventArgs e)
    {
      OpenFileDialog ExcelF = new OpenFileDialog();
      ExcelF.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)|*.xlsx";
      ExcelF.FilterIndex = 2;
      if (ExcelF.ShowDialog() == DialogResult.OK)
      {
        txtImPath.Text = ExcelF.FileName;
      }
    }
    private void BTprocess_Click(object sender, EventArgs e)
    {
      DialogResult Result;
      
      Result = XtraMessageBox.Show("ต้องการปรับราคาใช่หรือไม่?", "ยืนยัน", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        BTnote.Visible = false;
        txtDescription.Text = "";
        ImportUpdatePriceList(txtImPath.Text.Trim());
        //ImportGeneratePartID();
        Result = XtraMessageBox.Show("ปรับราคาเรียบร้อยแล้ว", "Update price list", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Information);
        if (txtDescription.Text.Length > 0) BTnote.Visible = true;
      }
    }

    private void ImportGeneratePartID()
    {
      SqlConnection conn = new SqlConnection();
      SqlCommand comm = new SqlCommand();
      SqlCommand cmd = conn.CreateCommand();
      SqlDataReader rd;
      int Rowcount = 0;
      string sql = "";
      string STKcode;
      double STKquan = 0;
      string VDname;
      int i, j;
      bool ExistOK = false;
      SqlDataAdapter da;


      DataTable dtVoucher = null;
      DataTable dt = null;
      int ITEMid = 0;
      int BrandID = 0;
      string ITEMcode = "";
      string PartNo = "";
      string BranCode = "";
      string sqltex = "";
      int Listno = 0;
      string CateCode = "";
      int CateID = 0;
      StringBuilder sb = new StringBuilder();


      cls_Global_DB.ConnectDatabase(ref conn);

      try
      {
        txtCaption.Text = "Precessing...";
        txtCaption.Refresh();

        sql = "Select * From M_ITEMS order by ITEM_ID";
        da = new SqlDataAdapter(sql, conn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.CommandTimeout = 300;

        dtVoucher = new DataTable("ITEM");
        da.Fill(dtVoucher);
        if (dtVoucher.Rows.Count > 0)
        {
          for (i = 0; i < dtVoucher.Rows.Count; i++)
          {
            ITEMid = 0;
            ITEMcode = cls_Library.DBString(dtVoucher.Rows[i]["ITEM_CODE"]);
            ITEMid = cls_Library.DBInt(dtVoucher.Rows[i]["ITEM_ID"]);
            //PartNo = cls_Library.DBString(dtVoucher.Rows[i]["PARTNO"]);
            //BranCode = cls_Library.DBString(dtVoucher.Rows[i]["BRAND"]);
            CateCode = ITEMcode.Substring(0, 3);
            if (CateCode == "002")
            {
              Application.DoEvents();
            }
            CateID = cls_Library.DBInt(cls_Data.GetNameFromTBname(CateCode, "CATEGORIES", "CATEGORY_ID"));
            BrandID = 0;
            if (ITEMid > 0)
            {
              if (ITEMid > 0)
              {
                //sqltex = string.Format("Update M_ITEMS set CATEGORY_ID =@CATEGORY_ID where ITEM_ID = {0}", ITEMid);
                //cmd = new SqlCommand();
                //cmd.Connection = conn;
                //cmd.CommandText = sqltex;
                //cmd.CommandTimeout = 30;
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Clear();
                //cmd.Parameters.Add("@CATEGORY_ID", SqlDbType.Int).Value = CateID;
                ////cmd.Parameters.Add("@VENDOR_ID", SqlDbType.Int).Value = 2;
                ////cmd.Parameters.Add("@PRIORITY", SqlDbType.SmallInt).Value = 1;
                ////cmd.Parameters.Add("@LIST_NO", SqlDbType.SmallInt).Value = Listno;
                //cmd.ExecuteNonQuery();


                //sqltex = string.Format("Select * From D_ITEM_ALTERNATE_PARTS A Where A.ITEM_ID = {0}", ITEMid);
                //cls_Data.LoadSpecifyData(sqltex, out dt, "D_ITEM_ALTERNATE_PARTS");


                //คลังสินค้า   1
                sqltex = string.Format("Select * From D_ITEM_LOCATIONS A  Where A.ITEM_ID = {0}", ITEMid);
                cls_Data.LoadSpecifyData(sqltex, out dt, "D_ITEM_LOCATIONS");
                if (dt.Rows.Count == 0)
                {
                  sb.Clear();
                  sb.AppendLine("INSERT INTO D_ITEM_LOCATIONS WITH (UPDLOCK) (");
                  sb.AppendLine("ITEM_ID,");
                  sb.AppendLine("LOCATION_NAME,");
                  sb.AppendLine("SERIAL_NO,");
                  sb.AppendLine("QTY,");
                  sb.AppendLine("DEFAULT_LOCATION,");
                  sb.AppendLine("LIST_NO)");
                  sb.AppendLine("VALUES (");
                  sb.AppendLine("@ITEM_ID,");
                  sb.AppendLine("@LOCATION_NAME,");
                  sb.AppendLine("@SERIAL_NO,");
                  sb.AppendLine("@QTY,");
                  sb.AppendLine("@DEFAULT_LOCATION,");
                  sb.AppendLine("@LIST_NO)");

                  cmd = new SqlCommand();
                  cmd.Connection = conn;
                  cmd.CommandText = sb.ToString();
                  cmd.CommandTimeout = 30;
                  cmd.CommandType = CommandType.Text;
                  cmd.Parameters.Clear();
                  cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = ITEMid;
                  cmd.Parameters.Add("@LOCATION_NAME", SqlDbType.VarChar, 20).Value = "MAIN";
                  cmd.Parameters.Add("@SERIAL_NO", SqlDbType.Char, 20).Value = "";
                  cmd.Parameters.Add("@QTY", SqlDbType.Int).Value = 1;
                  cmd.Parameters.Add("@DEFAULT_LOCATION", SqlDbType.Bit).Value = true;
                  cmd.Parameters.Add("@LIST_NO", SqlDbType.SmallInt).Value = 1;
                  cmd.ExecuteNonQuery();
                }


                //หน่วยนับที่ผูกกับสินค้า   2
                sqltex = string.Format("Select * From D_ITEM_UNITS A Where A.ITEM_ID = {0}", ITEMid);
                cls_Data.LoadSpecifyData(sqltex, out dt, "D_ITEM_UNITS");
                if (dt.Rows.Count == 0)
                {
                  sb.Clear();
                  sb.AppendLine("INSERT INTO D_ITEM_UNITS WITH (UPDLOCK) (");
                  sb.AppendLine("ITEM_ID,");
                  sb.AppendLine("UNIT_ID,");
                  sb.AppendLine("DECIMAL_STATUS,");
                  sb.AppendLine("MULTIPLY_QTY,");
                  sb.AppendLine("BUY_STATUS,");
                  sb.AppendLine("SALE_STATUS,");
                  sb.AppendLine("LIST_NO)");
                  sb.AppendLine("VALUES (");
                  sb.AppendLine("@ITEM_ID,");
                  sb.AppendLine("@UNIT_ID,");
                  sb.AppendLine("@DECIMAL_STATUS,");
                  sb.AppendLine("@MULTIPLY_QTY,");
                  sb.AppendLine("@BUY_STATUS,");
                  sb.AppendLine("@SALE_STATUS,");
                  sb.AppendLine("@LIST_NO)");

                  cmd = new SqlCommand();
                  cmd.Connection = conn;
                  cmd.CommandText = sb.ToString();
                  cmd.CommandTimeout = 30;
                  cmd.CommandType = CommandType.Text;
                  cmd.Parameters.Clear();
                  cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = ITEMid;
                  cmd.Parameters.Add("@UNIT_ID", SqlDbType.Int).Value = 1;
                  cmd.Parameters.Add("@DECIMAL_STATUS", SqlDbType.Bit).Value = false;
                  cmd.Parameters.Add("@MULTIPLY_QTY", SqlDbType.Float).Value = 1;
                  cmd.Parameters.Add("@BUY_STATUS", SqlDbType.Bit).Value = true;
                  cmd.Parameters.Add("@SALE_STATUS", SqlDbType.Bit).Value = true;
                  cmd.Parameters.Add("@LIST_NO", SqlDbType.SmallInt).Value = 1;
                  cmd.ExecuteNonQuery();
                }


                //กลุ่มสั่งซื้อสินค้า  4
                sqltex = string.Format("Select * From D_ITEM_PO_GROUPS A  Where A.ITEM_ID = {0}", ITEMid);
                cls_Data.LoadSpecifyData(sqltex, out dt, "D_ITEM_PO_GROUPS");
                if (dt.Rows.Count == 0)
                {
                  sb.Clear();
                  sb.AppendLine("INSERT INTO D_ITEM_PO_GROUPS WITH (UPDLOCK) (");
                  sb.AppendLine("ITEM_ID,");
                  sb.AppendLine("PO_GROUP_ID,");
                  sb.AppendLine("LIST_NO)");
                  sb.AppendLine("VALUES (");
                  sb.AppendLine("@ITEM_ID,");
                  sb.AppendLine("@PO_GROUP_ID,");
                  sb.AppendLine("@LIST_NO)");

                  cmd = new SqlCommand();
                  cmd.Connection = conn;
                  cmd.CommandText = sb.ToString();
                  cmd.CommandTimeout = 30;
                  cmd.CommandType = CommandType.Text;
                  cmd.Parameters.Clear();
                  cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = ITEMid;
                  cmd.Parameters.Add("@PO_GROUP_ID", SqlDbType.Int).Value = 1;
                  cmd.Parameters.Add("@LIST_NO", SqlDbType.SmallInt).Value = 1;
                  cmd.ExecuteNonQuery();
                }

                ////ผู้แทนจำหน่าย    5 
                sqltex = string.Format("Select * From D_ITEM_VENDORS A Where A.ITEM_ID = {0}", ITEMid);
                cls_Data.LoadSpecifyData(sqltex, out dt, "D_ITEM_VENDORS");
                if (dt.Rows.Count == 0)
                {
                  sb.Clear();
                  sb.AppendLine("INSERT INTO D_ITEM_VENDORS WITH (UPDLOCK) (");
                  sb.AppendLine("ITEM_ID,");
                  sb.AppendLine("VENDOR_ID,");
                  sb.AppendLine("PRIORITY,");
                  sb.AppendLine("LIST_NO)");
                  sb.AppendLine("VALUES (");
                  sb.AppendLine("@ITEM_ID,");
                  sb.AppendLine("@VENDOR_ID,");
                  sb.AppendLine("@PRIORITY,");
                  sb.AppendLine("@LIST_NO)");

                  cmd = new SqlCommand();
                  cmd.Connection = conn;
                  cmd.CommandText = sb.ToString();
                  cmd.CommandTimeout = 30;
                  cmd.CommandType = CommandType.Text;
                  cmd.Parameters.Clear();
                  cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = ITEMid;
                  cmd.Parameters.Add("@VENDOR_ID", SqlDbType.Int).Value = 2;
                  cmd.Parameters.Add("@PRIORITY", SqlDbType.SmallInt).Value = 1;
                  cmd.Parameters.Add("@LIST_NO", SqlDbType.SmallInt).Value = 1;
                  cmd.ExecuteNonQuery();
                }


                //เอกสาร
                sqltex = string.Format("Select * From D_ITEM_DOCUMENTS A  Where A.ITEM_ID = {0}", ITEMid);
                cls_Data.LoadSpecifyData(sqltex, out dt, "D_ITEM_DOCUMENTS");
                if (dt.Rows.Count == 0)
                {
                  sb.Clear();
                  sb.AppendLine("INSERT INTO D_ITEM_DOCUMENTS WITH (UPDLOCK) (");
                  sb.AppendLine("ITEM_ID,");
                  sb.AppendLine("DOCUMENT_ID,");
                  sb.AppendLine("LIST_NO)");
                  sb.AppendLine("VALUES (");
                  sb.AppendLine("@ITEM_ID,");
                  sb.AppendLine("@DOCUMENT_ID,");
                  sb.AppendLine("@LIST_NO)");

                  cmd = new SqlCommand();
                  cmd.Connection = conn;
                  cmd.CommandText = sb.ToString();
                  cmd.CommandTimeout = 30;
                  cmd.CommandType = CommandType.Text;
                  cmd.Parameters.Clear();
                  cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = ITEMid;
                  cmd.Parameters.Add("@DOCUMENT_ID", SqlDbType.Int).Value = 1;
                  cmd.Parameters.Add("@LIST_NO", SqlDbType.SmallInt).Value = 1;
                  cmd.ExecuteNonQuery();
                }







                //sb.Clear();
                //sb.AppendLine("INSERT INTO D_ITEM_ALTERNATE_PARTS WITH (UPDLOCK) (");
                //sb.AppendLine("ITEM_ID,");
                //sb.AppendLine("PART_ID,");
                //sb.AppendLine("BRAND_DESCRIPTION,");
                //sb.AppendLine("STATUS,");
                //sb.AppendLine("LIST_NO)");
                //sb.AppendLine("VALUES (");
                //sb.AppendLine("@ITEM_ID,");
                //sb.AppendLine("@PART_ID,");
                //sb.AppendLine("@BRAND_DESCRIPTION,");
                //sb.AppendLine("@STATUS,");
                //sb.AppendLine("@LIST_NO)");

                //cmd = new SqlCommand(sb.ToString(), conn);
                //cmd.CommandText = sb.ToString();
                //cmd.CommandTimeout = 30;
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Clear();
                //cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = ITEMid;
                //cmd.Parameters.Add("@PART_ID", SqlDbType.Char, 20).Value = PartNo;
                //cmd.Parameters.Add("@BRAND_DESCRIPTION", SqlDbType.VarChar, 15).Value = BranCode;
                //cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = 1;
                //cmd.Parameters.Add("@LIST_NO", SqlDbType.SmallInt).Value = Listno;
                //cmd.ExecuteNonQuery();
                //break;
              }
              txtCaption.Text = i.ToString("#,##0") + "/" + dtVoucher.Rows.Count.ToString("#,##0");
              txtCaption.Refresh();
            }
          }
        }

        //Rowcount = rw;

        //if (Rowcount <= 0)
        //{
        //  DialogResult Result = XtraMessageBox.Show("ไม่มีรายการสินค้าในการปรับหน้าไม้?", "ผิดพลาด", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
        //  GC.Collect();
        //  GC.WaitForPendingFinalizers();
        //  xlWorkBook.Close(true, null, null);
        //  xlApp.Quit();

        //  Marshal.ReleaseComObject(xlWorkSheet);
        //  Marshal.ReleaseComObject(xlWorkBook);
        //  Marshal.ReleaseComObject(xlApp);


        //  return;
        //}
        //for (i = 2; i <= range.Rows.Count; i++)
        //{
        //  txtCaption.Text = "Reading..." + i.ToString("#,##0") + "/" + Rowcount.ToString("#,##0");
        //  txtCaption.Refresh();
        //  j = cls_Library.DBInt((range.Cells[i, 1] as Excel.Range).Value2);
        //  STKcode = cls_Library.DBString((range.Cells[i, 2] as Excel.Range).Value2);
        //  STKquan = cls_Library.DBDouble((range.Cells[i, 4] as Excel.Range).Value2);
        //  if ((STKcode.Length > 0) && (STKquan > 0))
        //  {
        //    ExistOK = false;
        //    sql = "Select STKcode from STK where STKcode=@STKcode";
        //    comm = new SqlCommand(sql, conn);
        //    comm.CommandText = sql;
        //    comm.CommandTimeout = 30;
        //    comm.CommandType = CommandType.Text;
        //    comm.Parameters.Clear();
        //    comm.Parameters.AddWithValue("@STKcode", STKcode);
        //    rd = comm.ExecuteReader();
        //    if (rd.HasRows)
        //    {
        //      ExistOK = true;
        //    }
        //    rd.Close();

        //    if (ExistOK)
        //    {
        //      sql = "UPDATE STK WITH (UPDLOCK) Set STKuname2=@STKuname2, STKunit2=@STKunit2, STKqU2=@STKqU2, STKqE2=@STKqE2, STKqN2=@STKqN2 where STKcode=@STKcode";
        //      comm = new SqlCommand(sql, conn);
        //      comm.CommandText = sql;
        //      comm.CommandTimeout = 30;
        //      comm.CommandType = CommandType.Text;
        //      comm.Parameters.Clear();
        //      comm.Parameters.Add("@STKcode", SqlDbType.NVarChar, 25).Value = STKcode;
        //      comm.Parameters.Add("@STKuname2", SqlDbType.NText).Value = "แพ็ค";
        //      comm.Parameters.Add("@STKunit2", SqlDbType.Real).Value = 2;
        //      comm.Parameters.Add("@STKqU2", SqlDbType.Real).Value = STKquan;
        //      comm.Parameters.Add("@STKqE2", SqlDbType.Real).Value = STKquan;
        //      comm.Parameters.Add("@STKqN2", SqlDbType.SmallInt).Value = 1;
        //      comm.ExecuteNonQuery();

        //      txtDescription.Text = "รายการที่ " + j.ToString("#,##0") + "  รหัสสินค้า : " + STKcode + " Update OK" + Environment.NewLine + txtDescription.Text;
        //      txtDescription.Refresh();
        //    }
        //  }

        //}
        //GC.Collect();
        //GC.WaitForPendingFinalizers();
        //xlWorkBook.Close(true, null, null);
        //xlApp.Quit();

        //Marshal.ReleaseComObject(xlWorkSheet);
        //Marshal.ReleaseComObject(xlWorkBook);
        //Marshal.ReleaseComObject(xlApp);

      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      finally
      {
        cls_Global_DB.CloseDB(ref conn);
      }
    }

    private void ImportUpdatePriceList(string Sfile)
    {
      SqlConnection conn = new SqlConnection();
      SqlCommand comm = new SqlCommand();
      SqlCommand cmd = conn.CreateCommand();
      DataTable dt;
      int Rowcount = 0;
      int i;
      bool ExistOK = false;

      string Sql = "";
      decimal P1, P2, P3;
      DateTime DAT1 = DateTime.MinValue, DAT2 = DateTime.MinValue, DAT3 = DateTime.MinValue;

      decimal NEW_PRICE = 0;
      DateTime NEW_DATE = DateTime.MinValue;

      DateTime DT;

      string BRAND_PART_ID = "";
      string GENUIN_PART_ID = "";
      string FULL_NAME = "";
      string BRAND_NAME = "";
      string MODEL = "";
      string Xdate = "";

      int SaveType = 0;       //1 = Brand, 2 = GENUIN

      cls_Global_DB.ConnectDatabase(ref conn);

      try
      {
        txtCaption.Text = "Precessing...";
        txtCaption.Refresh();
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range range;

        int rw = 0;
        int cl = 0;

        xlApp = new Excel.Application();
        xlWorkBook = xlApp.Workbooks.Open(@Sfile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        range = xlWorkSheet.UsedRange;
        rw = range.Rows.Count;
        cl = range.Columns.Count;

        Rowcount = rw;

        if (Rowcount <= 0)
        {
          DialogResult Result = XtraMessageBox.Show("ไม่มีรายการอะไหล่ในการปรับราคา?", "ผิดพลาด", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
          GC.Collect();
          GC.WaitForPendingFinalizers();
          xlWorkBook.Close(true, null, null);
          xlApp.Quit();

          Marshal.ReleaseComObject(xlWorkSheet);
          Marshal.ReleaseComObject(xlWorkBook);
          Marshal.ReleaseComObject(xlApp);
          

          return;
        }
        for (i = 2; i <= range.Rows.Count; i++)
        {
          txtCaption.Text = "Reading..." + i.ToString("#,##0") + "/" + Rowcount.ToString("#,##0");
          txtCaption.Refresh();
          BRAND_PART_ID = cls_Library.DBString((range.Cells[i, 1] as Excel.Range).Value2);
          GENUIN_PART_ID = cls_Library.DBString((range.Cells[i, 2] as Excel.Range).Value2);
          FULL_NAME = cls_Library.DBString((range.Cells[i, 3] as Excel.Range).Value2);
          BRAND_NAME = cls_Library.DBString((range.Cells[i, 4] as Excel.Range).Value2);
          MODEL = cls_Library.DBString((range.Cells[i, 5] as Excel.Range).Value2);
          NEW_PRICE = cls_Library.DBDecimal((range.Cells[i, 6] as Excel.Range).Value2);
          Xdate = cls_Library.DBString((range.Cells[i,7] as Excel.Range).Value);
          if (Xdate.Length > 10) Xdate = Xdate.Substring(0, 10);
          if (cls_Library.IsDate(Xdate)) NEW_DATE = cls_Library.DBDateTime(Xdate);
          if (cls_Library.IsDate(NEW_DATE))
          {
            if (NEW_DATE.Year > 2500) NEW_DATE = cls_Library.Date_CvDMY(NEW_DATE.Day, NEW_DATE.Month, NEW_DATE.Year - 543, false);
          }
          else
          {
            NEW_DATE = DateTime.MinValue;
          }
          P1 = cls_Library.DBDecimal((range.Cells[i, 8] as Excel.Range).Value2);
          Xdate = cls_Library.DBString((range.Cells[i, 9] as Excel.Range).Value);
          if (Xdate.Length > 10) Xdate = Xdate.Substring(0, 10);
          if (cls_Library.IsDate(Xdate)) DAT1 = cls_Library.DBDateTime(Xdate);
          if (cls_Library.IsDate(DAT1))
          {
            if (DAT1.Year > 2500) DAT1 = cls_Library.Date_CvDMY(DAT1.Day, DAT1.Month, DAT1.Year - 543, false);
          }
          else
          {
            DAT1 = DateTime.MinValue;
          }
          P2 = cls_Library.DBDecimal((range.Cells[i, 10] as Excel.Range).Value2);
          Xdate = cls_Library.DBString((range.Cells[i, 11] as Excel.Range).Value);
          if (Xdate.Length > 10) Xdate = Xdate.Substring(0, 10);
          if (cls_Library.IsDate(Xdate)) DAT2 = cls_Library.DBDateTime(Xdate);
          if (cls_Library.IsDate(DAT2))
          {
            if (DAT2.Year > 2500) DAT2 = cls_Library.Date_CvDMY(DAT2.Day, DAT2.Month, DAT2.Year - 543, false);
          }
          else
          {
            DAT2 = DateTime.MinValue;
          }
          P3 = cls_Library.DBDecimal((range.Cells[i, 12] as Excel.Range).Value2);
          Xdate = cls_Library.DBString((range.Cells[i, 13] as Excel.Range).Value);
          if (Xdate.Length > 10) Xdate = Xdate.Substring(0, 10);
          if (cls_Library.IsDate(Xdate)) DAT3 = cls_Library.DBDateTime(Xdate);
          if (cls_Library.IsDate(DAT3))
          {
            if (DAT3.Year > 2500) DAT3 = cls_Library.Date_CvDMY(DAT3.Day, DAT3.Month, DAT3.Year - 543, false);
          }
          else
          {
            DAT3 = DateTime.MinValue;
          }


          ExistOK = false;

          if ((BRAND_PART_ID.Length > 0) || (GENUIN_PART_ID.Length > 0))
          {

            if (BRAND_PART_ID.Length > 0)
            {
              dt = GetListPriceListByBranPartID(BRAND_PART_ID);
              if (dt.Rows.Count > 0)
              {
                SaveType = 1;
                ExistOK = true;
              }
            }


            if (!ExistOK)
            {
              if (GENUIN_PART_ID.Length > 0)
              {
                dt = GetListPriceListByGenuinID(GENUIN_PART_ID);
                if (dt.Rows.Count > 0)
                {
                  SaveType = 2;
                  ExistOK = true;
                }
              }
            }


            if (!ExistOK)
            {
              Sql = "Insert Into M_PRICELIST WITH (UPDLOCK) (BRAND_PART_ID,GENUIN_PART_ID,FULL_NAME,BRAND_NAME,MODEL,NEW_PRICE,NEW_DATE,PRICE1,PRICE2,PRICE3,DATEACTIVE1,DATEACTIVE2,DATEACTIVE3,DATE1,DATE2,DATE3,CREATE_BY,CREATE_DATE,UPDATE_BY,UPDATE_DATE,DELETED,DELETE_BY,DELETE_DATE)"
                      + " VALUES(@BRAND_PART_ID,@GENUIN_PART_ID,@FULL_NAME,@BRAND_NAME,@MODEL,@NEW_PRICE,@NEW_DATE,@PRICE1,@PRICE2,@PRICE3,@DATEACTIVE1,@DATEACTIVE2,@DATEACTIVE3,@DATE1,@DATE2,@DATE3,@CREATE_BY,@CREATE_DATE,@UPDATE_BY,@UPDATE_DATE,@DELETED,@DELETE_BY,@DELETE_DATE)";
            }
            else
            {
              Sql = "Update M_PRICELIST WITH (UPDLOCK) Set FULL_NAME=@FULL_NAME,BRAND_NAME=@BRAND_NAME,MODEL=@MODEL,NEW_PRICE=@NEW_PRICE,NEW_DATE=@NEW_DATE,"
                + "PRICE1=@PRICE1,PRICE2=@PRICE2,PRICE3=@PRICE3,DATEACTIVE1=@DATEACTIVE1,DATEACTIVE2=@DATEACTIVE2,DATEACTIVE3=@DATEACTIVE3,DATE1=@DATE1,DATE2=@DATE2,DATE3=@DATE3,"
                + "UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE";
              if (SaveType == 1)
              {
                Sql += ",GENUIN_PART_ID = @GENUIN_PART_ID";
                Sql += " Where BRAND_PART_ID=@BRAND_PART_ID";
              }
              else
              {
                Sql += ",BRAND_PART_ID = @BRAND_PART_ID";
                Sql += " Where GENUIN_PART_ID=@GENUIN_PART_ID";
              }
              
            }


            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Sql;
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@GENUIN_PART_ID", SqlDbType.NVarChar, 50).Value = GENUIN_PART_ID;
            cmd.Parameters.Add("@BRAND_PART_ID", SqlDbType.NVarChar, 50).Value = BRAND_PART_ID;
            cmd.Parameters.Add("@FULL_NAME", SqlDbType.NVarChar, 100).Value = FULL_NAME;
            cmd.Parameters.Add("@BRAND_NAME", SqlDbType.NVarChar, 50).Value = BRAND_NAME;
            cmd.Parameters.Add("@MODEL", SqlDbType.NVarChar, 50).Value = MODEL;
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

            if ((DAT1 == DateTime.MinValue) || (DAT1 == DateTime.MaxValue))
              cmd.Parameters.Add("@DATE1", SqlDbType.DateTime).Value = DBNull.Value;
            else
              cmd.Parameters.Add("@DATE1", SqlDbType.DateTime).Value = DateTime.Now;
            if ((DAT2 == DateTime.MinValue) || (DAT2 == DateTime.MaxValue))
              cmd.Parameters.Add("@DATE2", SqlDbType.DateTime).Value = DBNull.Value;
            else
              cmd.Parameters.Add("@DATE2", SqlDbType.DateTime).Value = DateTime.Now;
            if ((DAT3 == DateTime.MinValue) || (DAT3 == DateTime.MaxValue))
              cmd.Parameters.Add("@DATE3", SqlDbType.DateTime).Value = DBNull.Value;
            else
              cmd.Parameters.Add("@DATE3", SqlDbType.DateTime).Value = DateTime.Now;

            if (!ExistOK)
            {
              cmd.Parameters.Add("@CREATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
              DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
              cmd.Parameters.Add("@CREATE_DATE", SqlDbType.DateTime).Value = DT;
              cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = 0;
              cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DBNull.Value;
              cmd.Parameters.Add("@DELETED", SqlDbType.Bit).Value = 0;
              cmd.Parameters.Add("@DELETE_BY", SqlDbType.Int).Value = 0;
              cmd.Parameters.Add("@DELETE_DATE", SqlDbType.DateTime).Value = DBNull.Value;              
            }
            if (ExistOK)
            {
              cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
              DT = Convert.ToDateTime(cls_Global_class.GetDateCulture(DateTime.Now).ToShortDateString());
              cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DT;
            }
            cmd.ExecuteNonQuery();
          }

        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        xlWorkBook.Close(true, null, null);
        xlApp.Quit();

        Marshal.ReleaseComObject(xlWorkSheet);
        Marshal.ReleaseComObject(xlWorkBook);
        Marshal.ReleaseComObject(xlApp);

      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      finally
      {
        cls_Global_DB.CloseDB(ref conn);
      }
    }


    private void ImportUpdateSTK(string Sfile)
    {
      SqlConnection conn = new SqlConnection();
      SqlCommand comm = new SqlCommand();
      SqlDataReader rd;
      int Rowcount = 0;
      string sql = "";
      string STKcode;
      double STKquan = 0;
      int i, j;
      bool ExistOK = false;

      cls_Global_DB.ConnectDatabase(ref conn);

      try
      {
        txtCaption.Text = "Precessing...";
        txtCaption.Refresh();
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range range;

        int rw = 0;
        int cl = 0;

        xlApp = new Excel.Application();
        xlWorkBook = xlApp.Workbooks.Open(@Sfile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        range = xlWorkSheet.UsedRange;
        rw = range.Rows.Count;
        cl = range.Columns.Count;

        Rowcount = rw;

        if (Rowcount <= 0)
        {
          DialogResult Result = XtraMessageBox.Show("ไม่มีรายการสินค้าในการปรับหน้าไม้?", "ผิดพลาด", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
          GC.Collect();
          GC.WaitForPendingFinalizers();
          xlWorkBook.Close(true, null, null);
          xlApp.Quit();

          Marshal.ReleaseComObject(xlWorkSheet);
          Marshal.ReleaseComObject(xlWorkBook);
          Marshal.ReleaseComObject(xlApp);


          return;
        }
        for (i = 2; i <= range.Rows.Count; i++)
        {
          txtCaption.Text = "Reading..." + i.ToString("#,##0") + "/" + Rowcount.ToString("#,##0");
          txtCaption.Refresh();
          j = cls_Library.DBInt((range.Cells[i, 1] as Excel.Range).Value2);
          STKcode = cls_Library.DBString((range.Cells[i, 2] as Excel.Range).Value2);
          STKquan = cls_Library.DBDouble((range.Cells[i, 4] as Excel.Range).Value2);
          if ((STKcode.Length > 0) && (STKquan > 0))
          {
            ExistOK = false;
            sql = "Select STKcode from STK where STKcode=@STKcode";
            comm = new SqlCommand(sql, conn);
            comm.CommandText = sql;
            comm.CommandTimeout = 30;
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@STKcode", STKcode);
            rd = comm.ExecuteReader();
            if (rd.HasRows)
            {
              ExistOK = true;
            }
            rd.Close();

            if (ExistOK)
            {
              sql = "UPDATE STK WITH (UPDLOCK) Set STKuname2=@STKuname2, STKunit2=@STKunit2, STKqU2=@STKqU2, STKqE2=@STKqE2, STKqN2=@STKqN2 where STKcode=@STKcode";
              comm = new SqlCommand(sql, conn);
              comm.CommandText = sql;
              comm.CommandTimeout = 30;
              comm.CommandType = CommandType.Text;
              comm.Parameters.Clear();
              comm.Parameters.Add("@STKcode", SqlDbType.NVarChar, 25).Value = STKcode;
              comm.Parameters.Add("@STKuname2", SqlDbType.NText).Value = "แพ็ค";
              comm.Parameters.Add("@STKunit2", SqlDbType.Real).Value = 2;
              comm.Parameters.Add("@STKqU2", SqlDbType.Real).Value = STKquan;
              comm.Parameters.Add("@STKqE2", SqlDbType.Real).Value = STKquan;
              comm.Parameters.Add("@STKqN2", SqlDbType.SmallInt).Value = 1;
              comm.ExecuteNonQuery();

              txtDescription.Text = "รายการที่ " + j.ToString("#,##0") + "  รหัสสินค้า : " + STKcode + " Update OK" + Environment.NewLine + txtDescription.Text;
              txtDescription.Refresh();
            }
          }

        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        xlWorkBook.Close(true, null, null);
        xlApp.Quit();

        Marshal.ReleaseComObject(xlWorkSheet);
        Marshal.ReleaseComObject(xlWorkBook);
        Marshal.ReleaseComObject(xlApp);

      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      finally
      {
        cls_Global_DB.CloseDB(ref conn);
      }
    }

    private void BTnote_Click(object sender, EventArgs e)
    {
      NotepadHelper.ShowMessage(txtDescription.Text, "");
    }

    private void BTexit_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}