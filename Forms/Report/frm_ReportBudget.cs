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
using Medical.Class;
using DevExpress.XtraEditors.Repository;
using Medical.Forms.General;
using Medical.Forms.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using Microsoft.VisualBasic;
using DevExpress.XtraGrid;
using DevExpress.Export;

namespace Medical
{
 
  public partial class frm_ReportBudget : DevExpress.XtraEditors.XtraForm
  {
    #region ตัวแปร
    BackgroundWorker BGW = new BackgroundWorker();
    BackgroundWorker BGWGetCode = new BackgroundWorker();
    DateTime DefaultCustomDate_From ;
    DateTime DefaultCustomDate_To;
    DataTable dt_type = null;
    DateTime CaldateF;
    DateTime CaldateT;
    RepositoryItemCheckEdit c_V = new RepositoryItemCheckEdit();
    private DevExpress.XtraGrid.StyleFormatCondition styleDef = new DevExpress.XtraGrid.StyleFormatCondition();
    private DevExpress.XtraGrid.StyleFormatCondition styleDef2 = new DevExpress.XtraGrid.StyleFormatCondition();
    private DevExpress.XtraGrid.StyleFormatCondition styleDef3 = new DevExpress.XtraGrid.StyleFormatCondition();
    //Con_CompanySelect Comselect=new Con_CompanySelect();
    string[] STKg;
    string[] STOg;
    string[] CREg;
    string[] TmonthName;
    string[] EmonthName;
    string Gval = "";
    DataSet DataS, DataC;
    bool ReportRestore = false;
    bool ReportOK = false;
    bool Sameall;
    int Nomonth = 0;
    #endregion

    public frm_ReportBudget()
    {
      InitializeComponent();
      BGW.WorkerReportsProgress = true;
      BGW.WorkerSupportsCancellation = true;
      BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
      BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
      BGWGetCode.WorkerReportsProgress = true;
      BGWGetCode.WorkerSupportsCancellation = true;
      BGWGetCode.DoWork += new DoWorkEventHandler(BGWGetCode_DoWork);
      BGWGetCode.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGWGetCode_RunWorkerCompleted);
      BGWGetCode.RunWorkerAsync();
      //Comselect = new Con_CompanySelect();
      SetDefaultdate();
      SetObject();
    }

    private void BGWGetCode_DoWork(object sender, DoWorkEventArgs e)
    {
      DataTable dt;
      DataC = new DataSet();

      dt = new DataTable();
      dt = GetCodeJOB();
      DataC.Tables.Add(dt);

      dt = new DataTable();
      dt = GetCodeJOBGroup();
      DataC.Tables.Add(dt);


      //dt = new DataTable();
      //dt = cls_Data.GetCodePart(0, 0, "Part_id,Part_Code,Part_NameT,Part_NameE");
      //DataC.Tables.Add(dt);

      //dt = new DataTable();
      //dt = cls_Data.GetCodeCUS(0, 0, "Cus_id,Cus_Code,Cus_NameT,Cus_NameE");
      //DataC.Tables.Add(dt);

      //dt = new DataTable();
      //dt = cls_Data.GetCodeIns(0, 0, "Ins_id,Ins_Code");
      //DataC.Tables.Add(dt);

      //dt = new DataTable();
      //dt = cls_Data.GetCodeModel(0, 0, "Ins_id,Ins_Model");
      //DataC.Tables.Add(dt);

      //dt = new DataTable();
      //dt = cls_Data.GetCodeSN(0, 0, "Ins_id,Ins_SN");
      //DataC.Tables.Add(dt);

      //dt = new DataTable("Type");
      //dt.Columns.Add("R_Type", typeof(int));
      //dt.Columns.Add("Value", typeof(bool));
      //dt.Columns.Add("R_Name", typeof(string));
      //for (int i = 0; i < 5; i++)
      //{
      //  dt.Rows.Add();
      //  switch (i)
      //  {
      //    case 0:
      //      dt.Rows[i]["R_Type"] = 201;
      //      dt.Rows[i]["Value"] = true;
      //      dt.Rows[i]["R_Name"] = "Installation";
      //      break;
      //    case 1:
      //      dt.Rows[i]["R_Type"] = 202;
      //      dt.Rows[i]["Value"] = true;
      //      dt.Rows[i]["R_Name"] = "Validation";
      //      break;
      //    case 2:
      //      dt.Rows[i]["R_Type"] = 203;
      //      dt.Rows[i]["Value"] = true;
      //      dt.Rows[i]["R_Name"] = "PQ";
      //      break;
      //    case 3:
      //      dt.Rows[i]["R_Type"] = 204;
      //      dt.Rows[i]["Value"] = true;
      //      dt.Rows[i]["R_Name"] = "Services";
      //      break;
      //    case 4:
      //      dt.Rows[i]["R_Type"] = 205;
      //      dt.Rows[i]["Value"] = true;
      //      dt.Rows[i]["R_Name"] = "ASC";
      //      break;
      //  }
      //}
      //DataC.Tables.Add(dt);
    }

    private void BGWGetCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      //slookupSpare.Properties.DataSource = DataC.Tables["Part"];
      slookupJob.Properties.DataSource = DataC.Tables["JOB"];
      //slookupIns.Properties.DataSource = DataC.Tables["Ins"];
      //slookupModel.Properties.DataSource = DataC.Tables["Model"];
      slookupJobG.Properties.DataSource = DataC.Tables["JOBGROUP"];
      //slookupSN.Properties.DataSource = DataC.Tables["SN"];
      //gridType.DataSource = DataC.Tables["Type"];
      //SetGridType();
      SetslookUP();
    }

    private void BGW_DoWork(object sender, DoWorkEventArgs e)
    {
      if (Mopt1.Checked == true)
      {
        InitialData1();
      }
      else
      {
        InitialData2();
      }

    }

    private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      barBottom.Visible = false;
      Grid.DataSource = DataS.Tables["Head"];
      gvHead.RefreshData();
      Grid.RefreshDataSource();
      groupControl1.Enabled = true;
      groupControl4.Enabled = true;
      Grid.Visible=true;
      if (DataS.Tables["Head"].Rows.Count > 0) ReportOK = true;
      this.UseWaitCursor = false;
    }

    private static DataTable GetCodeJOB()
    {
      DataTable dt = new DataTable("JOB");
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;

      cls_Global_DB.ConnectDatabaseMAC5(ref cn);

      try
      {
        sql = "SELECT JOBcode,JOBgroup,JOBdescT,JOBdescE FROM JOB WHERE JOBhide=0 AND JOBlock=0";
        da = new SqlDataAdapter(sql, cn);
        da.Fill(dt);
      }
      catch
      {
        dt = null;
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
      return dt;
    }

    private static DataTable GetCodeJOBGroup()
    {
      DataTable dt = new DataTable("JOBGROUP");
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;

      cls_Global_DB.ConnectDatabaseMAC5(ref cn);

      try
      {
        sql = "SELECT distinct JOBgroup FROM JOB WHERE JOBhide=0 AND JOBlock=0";
        da = new SqlDataAdapter(sql, cn);
        da.Fill(dt);
      }
      catch
      {
        dt = null;
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
      return dt;
    }

    private static string GetCodeJOBGroupOK(string JOBcode)
    {
      //string User = "";
      SqlConnection conn = new SqlConnection();
      SqlCommand cmd = conn.CreateCommand();
      SqlDataReader rd = null;
      string Xjob = "";

      cls_Global_DB.ConnectDatabase(ref conn);
      try
      {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT JOBgroup FROM JOB WHERE JOBcode=@JOBcode";
        cmd.Connection = conn;
        cmd.CommandTimeout = 30;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@JOBcode", SqlDbType.NVarChar, 15).Value = JOBcode;
        rd = cmd.ExecuteReader();
        if (rd.HasRows)
        {
          rd.Read();
          Xjob = cls_Library.DBString(rd["JOBgroup"]);
        }
      }
      catch
      {
        Xjob = "";
      }
      finally
      {
        if (!rd.IsClosed) rd.Close();
        cls_Global_DB.CloseDB(ref conn);
      }
      return Xjob;
    }

    private static string GetJobName(string JOBcode)
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;
      string xs = string.Empty;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        sql = "SELECT JOBdescT FROM JOB WHERE JOBcode=@JOBcode";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.Parameters.Add("@JOBcode", SqlDbType.NVarChar, 15).Value = JOBcode;
        xs = cls_Library.DBString(da.SelectCommand.ExecuteScalar());
      }
      catch
      {
        xs = "";
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
      return xs;
    }

    private static string GetCusName(string CREcode)
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;
      string xs = string.Empty;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        sql = "SELECT CREnameT FROM CRE WHERE CREcode=@CREcode";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.Parameters.Add("@CREcode", SqlDbType.NVarChar, 15).Value = CREcode;
        xs = cls_Library.DBString(da.SelectCommand.ExecuteScalar());
      }
      catch
      {
        xs = "";
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
      return xs;
    }
    private static string GetComName()
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;
      string xs = string.Empty;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        sql = "SELECT OCMnameT FROM OCM";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        //da.SelectCommand.Parameters.Add("@JOBcode", SqlDbType.NVarChar, 15).Value = JOBcode;
        xs = cls_Library.DBString(da.SelectCommand.ExecuteScalar());
      }
      catch
      {
        xs = "";
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
      return xs;
    }

    private void InitialData1()
    {
      //cls_CST_CP.CSTgetBal("FG001", "MAIN", DateTime.Now);

      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      SqlDataAdapter da1 = null;
      string sql = string.Empty;
      
      DateTime dateT;
      DataTable dt = null;
      DataTable dtVoucher = null;
      DataTable dtVoucher1 = null;
      DataTable dtHead = null;
      DataTable dtJob = null;
      //DataTable dtJobMonth = null;
      //DataTable dtJobMonthCus = null;
      int i,  j;
      int vf = 0, vt = 0;
      string Job1, Job2;
      string Xdate;
      string JOBgroup="";
      bool CalOK = false;

      DateTime dateF = DateTime.Now.Date;

      int day = 0;
      int month = 0;
      int year = 0;
      DateTime DateStart;

      //หาผลรวม

      cls_Global_DB.ConnectDatabaseMAC5(ref cn);

      try
      {
        CaldateF = cls_Global_class.GetDateCulture(txtDateStart.DateTime);
        CaldateT = cls_Global_class.GetDateCulture(txtDateEnd.DateTime);



        //หาจำนวนคอลัมน์

        string[] colMonth = new string[Nomonth];
        decimal[] colMonthValue = new decimal[Nomonth];

        CaldateF = cls_Global_class.GetDateCulture(txtDateStart.DateTime);
        CaldateT = cls_Global_class.GetDateCulture(txtDateEnd.DateTime);
        JOBgroup = "";

        //day = 1;
        day = CaldateF.Day;
        month = CaldateF.Month;
        year = CaldateF.Year;
        CaldateF = new DateTime(year, month, day);

        month = CaldateT.Month + 1;
        //month = CaldateT.Month;
        year = CaldateT.Year;
        //day = DateTime.DaysInMonth(year, month);
        day = CaldateT.Day;
        if (month == 13)
        {
          month = 1;
          year += 1;
        }
        if (month == 2)
        {
          day = 28;
          if (year % 4 == 0) day = 29;
        }
        if (day == 31)
        {
          int Xday = DateTime.DaysInMonth(year, month);
          if (day != Xday) day = Xday;
        }

        CaldateT = new DateTime(year, month, day);

        var dateSpan = DateTimeSpan.CompareDates(CaldateF, CaldateT);

        Nomonth = dateSpan.Years * 12;
        Nomonth += 1;

        Nomonth = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Month, CaldateF, CaldateT, FirstDayOfWeek.Sunday));
        //NO = STOg.Length;

        DateStart = CaldateF.AddMonths(-1);
        CaldateT = CaldateT.AddMonths(-1);
        day = DateTime.DaysInMonth(CaldateT.Year, CaldateT.Month);
        CaldateT = new DateTime(CaldateT.Year, CaldateT.Month, day);

        Array.Resize(ref colMonth, Nomonth);
        Array.Resize(ref colMonthValue, Nomonth);

        for (i = 0; i < Nomonth; i++)
        {
          DateStart = DateStart.AddMonths(1);
          string Xm = DateStart.Month.ToString("00");
          string Xy = DateStart.Year.ToString("0000");
          string Xname = DateStart.Month.ToString("00") + "/" + DateStart.Year.ToString("0000");
          colMonth[i] = "R_" + Xm + Xy;
          colMonthValue[i] = 0;
        }

        Nomonth += 1;
        Array.Resize(ref colMonth, Nomonth);
        Array.Resize(ref colMonthValue, Nomonth);
        colMonth[i] = "R_DateSum";
        colMonthValue[i] = 0;


        DataS = new DataSet();
        dtHead = new DataTable("Head");

        dtHead.Columns.Clear();
        dtHead.Columns.Clear();
        dtHead.Columns.Add("R_Date", typeof(string));
        dtHead.Columns.Add("R_Vnos", typeof(string));
        dtHead.Columns.Add("R_Desc", typeof(string));
        dtHead.Columns.Add("R_Quan", typeof(decimal));
        dtHead.Columns.Add("R_Uname", typeof(string));
        dtHead.Columns.Add("R_Unitprice", typeof(string));
        dtHead.Columns.Add("R_Cog", typeof(decimal));
        dtHead.Columns.Add("R_Sum", typeof(decimal));
        dtHead.Columns.Add("R_Cus", typeof(string));
        dtHead.Columns.Add("R_Job", typeof(string));
        dtHead.Columns.Add("R_CusMonth", typeof(string));
        dtHead.Columns.Add("R_Type", typeof(int));
        for (i = 0; i < Nomonth; i++)
        {
          dtHead.Columns.Add(colMonth[i], typeof(decimal));
        }

        dt = new DataTable("Head");
        dt = dtHead.Copy();


        sql = "Select MIH.*,MIL.* From MIH INNER JOIN MIL ON MIH.MIHday = MIL.MILday AND MIH.MIHmonth = MIL.MILmonth AND MIH.MIHyear = MIL.MILyear AND MIH.MIHType = MIL.MILtype And MIH.MIHvnos = MIL.MILvnos And MIH.MIHcus = MIL.MILcus";
        sql += " Where ";


        if (Vopt1.Checked == true)
        {
          sql += " MIL.MILtype='PP' and ";
        }
        else
        {
          sql += " (MIL.MILtype='DP' or MIL.MILtype='CP') and ";
        }

        if (cls_Library.DBInt(lkDateOpt.EditValue) < 6)
        {
          //sql += " and (H_Voucher.V_date Between @dateForm AND @dateTo)  ";

          vf = (CaldateF.Year * 10000) + (CaldateF.Month * 100) + CaldateF.Day;
          vt = (CaldateT.Year * 10000) + (CaldateT.Month * 100) + CaldateT.Day;
          sql += " (((MILyear*10000)+(MILmonth*100)+(MILday)>=@CaldateF) and ((MILyear*10000)+(MILmonth*100)+(MILday)<=@CaldateT))";
        }

        if (slookupJob.Visible)
        {
          sql += " and MIL.MILjob=@MILjob";
        }

        sql += " Order By MILjob,MILyear,MILmonth,MILday,MILcus,MILvnos";

        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();

        //da.SelectCommand.Parameters.Add("@BFmonth", SqlDbType.Int).Value = BFmonth;
        //da.SelectCommand.Parameters.Add("@BFyear", SqlDbType.Int).Value = BFyear;
        //da.SelectCommand.Parameters.Add("@dateForm", SqlDbType.DateTime).Value = System.Convert.ToDateTime(CaldateF);
        //da.SelectCommand.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = System.Convert.ToDateTime(CaldateT);
        if (cls_Library.DBInt(lkDateOpt.EditValue) < 6)
        {
          da.SelectCommand.Parameters.Add("@CaldateF", SqlDbType.Int).Value = vf;
          da.SelectCommand.Parameters.Add("@CaldateT", SqlDbType.Int).Value = vt;
        }
        if (slookupJob.Visible)
        {
          da.SelectCommand.Parameters.Add("@MILjob", SqlDbType.NVarChar, 15).Value = slookupJob.EditValue;
        }

        da.SelectCommand.CommandTimeout = 1200;
        dtVoucher = new DataTable("Head");
        da.Fill(dtVoucher);

        for (i = 0; i < dtVoucher.Rows.Count; i++)
        {
          CalOK = true;
          if (slookupJobG.Visible)
          {
            JOBgroup = GetCodeJOBGroupOK(cls_Library.DBString(dtVoucher.Rows[i]["MILjob"]));
            if (slookupJobG.Text.ToUpper() != JOBgroup.ToUpper())
            {
              CalOK = false;
            }
          }
          if (CalOK==true)
          {
            DataRow Xrow1 = dt.NewRow();
            //dt.Rows.Add();
            dateT = cls_Library.Date_CvDMY(cls_Library.DBInt(dtVoucher.Rows[i]["MILday"]), cls_Library.DBInt(dtVoucher.Rows[i]["MILmonth"]), cls_Library.DBInt(dtVoucher.Rows[i]["MILyear"]), false);
            Xdate = "R_" + dateT.Month.ToString("00") + dateT.Year.ToString("0000");
            Xrow1["R_Cus"] = cls_Library.DBString(dtVoucher.Rows[i]["MILcus"]);
            Xrow1["R_Job"] = cls_Library.DBString(dtVoucher.Rows[i]["MILjob"]);
            Xrow1["R_Date"] = cls_Library.CDateTime(dateT).ToShortDateString();
            Xrow1["R_CusMonth"] = dateT.Month.ToString("00") + "/" + dateT.Year.ToString("0000");
            Xrow1["R_Vnos"] = cls_Library.DBString(dtVoucher.Rows[i]["MILvnos"]);
            Xrow1["R_Desc"] = cls_Library.DBString(dtVoucher.Rows[i]["MILdesc"]);
            Xrow1["R_Quan"] = cls_Library.DBDouble(dtVoucher.Rows[i]["MILquan"]);
            Xrow1["R_Uname"] = cls_Library.DBString(dtVoucher.Rows[i]["MILuname"]);
            Xrow1["R_Cog"] = cls_Library.DBDecimal(dtVoucher.Rows[i]["MILcog"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MILdiscA"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MILadisc"]);
            Xrow1["R_Unitprice"] = (cls_Library.DBDouble(dtVoucher.Rows[i]["MILcog"]) * cls_Library.DBDouble(dtVoucher.Rows[i]["MILconv"])) / cls_Library.DBDouble(dtVoucher.Rows[i]["MILquan"]);
           //หาค่า Vat
            decimal DvatA=0,Dxv=0;
            if (cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHvatInList"])==-1)
            {
              DvatA = cls_Library.DBDecimal(dtVoucher.Rows[i]["MILvat"]);
            }
            else
            {
              //Vat @ end, so have to make some cals here !
              DvatA = decimal.Round(cls_Library.DBDecimal(dtVoucher.Rows[i]["MILcog"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MILdiscA"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MILadisc"]), 2, MidpointRounding.AwayFromZero);
              Dxv = cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHcog"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHdiscLST"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHdiscHF1"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHdiscHF2"]);
              if ((Dxv != 0) && (DvatA > 0))
              {
                DvatA = decimal.Round(DvatA * (cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHvatSUM"]) / Dxv), 2, MidpointRounding.AwayFromZero);
              }
              else
              {
                DvatA =0;
              }
            }
            Xrow1["R_Sum"] = cls_Library.DBDecimal(Xrow1["R_Cog"]) + DvatA;
            for (j = 0; j < Nomonth; j++)
            {
              if (Xdate.ToUpper() == colMonth[j].ToUpper())
              {
                //Xrow1[colMonth[j]] = cls_Library.DBDecimal(Xrow1[colMonth[j]]) + cls_Library.DBDecimal(dtVoucher.Rows[i]["MILsum"]) + DvatA;
                Xrow1[colMonth[j]] = cls_Library.DBDecimal(Xrow1[colMonth[j]]) + cls_Library.DBDecimal(Xrow1["R_Sum"]); 
                break; 
              }
            }
            dt.Rows.Add(Xrow1);
            if (cls_Library.DBString(dtVoucher.Rows[i]["MILvnos"])=="INV-1001003")
            {
              Application.DoEvents();
            }
            if (Vopt2.Checked == true)
            {
              dateT = cls_Library.Date_CvDMY(cls_Library.DBInt(dtVoucher.Rows[i]["MILday"]), cls_Library.DBInt(dtVoucher.Rows[i]["MILmonth"]), cls_Library.DBInt(dtVoucher.Rows[i]["MILyear"]), false);
              sql = "Select MIH.*,MIL.* From MIH INNER JOIN MIL ON MIH.MIHday = MIL.MILday AND MIH.MIHmonth = MIL.MILmonth AND MIH.MIHyear = MIL.MILyear AND MIH.MIHType = MIL.MILtype And MIH.MIHvnos = MIL.MILvnos And MIH.MIHcus = MIL.MILcus";
              sql += " Where (MIL.MILtype='AP' or MIL.MILtype='BP') and MILcus=@MILcus and MILlinkVCtype='DP' and MILlinkVCdate=@MILlinkVCdate and MILlinkVCno=@MILlinkVCno and MILlinkVCid=@MILlinkVCid";
              da1 = new SqlDataAdapter(sql, cn);
              da1.SelectCommand.Parameters.Clear();
              da1.SelectCommand.Parameters.Add("@MILcus", SqlDbType.NVarChar, 15).Value = cls_Library.DBString(dtVoucher.Rows[i]["MILcus"]);
              da1.SelectCommand.Parameters.Add("@MILlinkVCdate", SqlDbType.DateTime).Value = dateT;
              da1.SelectCommand.Parameters.Add("@MILlinkVCno", SqlDbType.NVarChar, 15).Value = cls_Library.DBString(dtVoucher.Rows[i]["MILvnos"]);
              da1.SelectCommand.Parameters.Add("@MILlinkVCid", SqlDbType.Int).Value = cls_Library.DBInt(dtVoucher.Rows[i]["MILlinkVCid"]);
              da1.SelectCommand.CommandTimeout = 1200;
              dtVoucher1 = new DataTable("Head");
              da1.Fill(dtVoucher1);
              for (j = 0; j < dtVoucher1.Rows.Count; j++)
              {
                DataRow Xrow2 = dt.NewRow();
                //dt.Rows.Add();
                dateT = cls_Library.Date_CvDMY(cls_Library.DBInt(dtVoucher1.Rows[j]["MILday"]), cls_Library.DBInt(dtVoucher1.Rows[j]["MILmonth"]), cls_Library.DBInt(dtVoucher1.Rows[j]["MILyear"]), false);
                Xdate = "R_" + dateT.Month.ToString("00") + dateT.Year.ToString("0000");
                Xrow2["R_Cus"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILcus"]);
                Xrow2["R_Job"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILjob"]);
                Xrow2["R_Date"] = cls_Library.CDateTime(dateT).ToShortDateString();
                Xrow2["R_CusMonth"] = dateT.Month.ToString("00") + "/" + dateT.Year.ToString("0000");
                if (Xrow2["R_Date"].ToString().Length == 0)
                {
                  Application.DoEvents();
                }
                Xrow2["R_Vnos"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILvnos"]);
                Xrow2["R_Desc"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILdesc"]);
                Xrow2["R_Quan"] = -Math.Abs(cls_Library.DBDouble(dtVoucher1.Rows[j]["MILquan"]));
                Xrow2["R_Uname"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILuname"]);
                Xrow2["R_Cog"] = -Math.Abs(cls_Library.DBDouble(dtVoucher1.Rows[j]["MILcog"]) - cls_Library.DBDouble(dtVoucher1.Rows[j]["MILdiscA"]) - cls_Library.DBDouble(dtVoucher1.Rows[j]["MILadisc"]));
                Xrow2["R_Unitprice"] = -Math.Abs((cls_Library.DBDouble(dtVoucher1.Rows[j]["MILcog"]) * cls_Library.DBDouble(dtVoucher1.Rows[j]["MILconv"])) / cls_Library.DBDouble(dtVoucher1.Rows[j]["MILquan"]));
                //หาค่า Vat
                decimal DvatA1 = 0, Dxv1 = 0;
                if (cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHvatInList"]) == -1)
                {
                  DvatA1 = cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILvat"]);
                }
                else
                {
                  //Vat @ end, so have to make some cals here !
                  DvatA1 = decimal.Round(cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILcog"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILdiscA"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILadisc"]), 2, MidpointRounding.AwayFromZero);
                  Dxv1 = cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHcog"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHdiscLST"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHdiscHF1"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHdiscHF2"]);
                  if ((Dxv1 != 0) && (DvatA1 > 0))
                  {
                    DvatA1 = decimal.Round(DvatA1 * (cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHvatSUM"]) / Dxv1), 2, MidpointRounding.AwayFromZero);
                  }
                  else
                  {
                    DvatA1 = 0;
                  }
                }
                Xrow2["R_Sum"] = -Math.Abs(cls_Library.DBDecimal(Xrow2["R_Cog"]) + DvatA1);
                for (int k = 0; k < Nomonth; k++)
                {
                  if (Xdate.ToUpper() == colMonth[k].ToUpper())
                  {
                    Xrow2[colMonth[k]] = cls_Library.DBDecimal(Xrow2[colMonth[k]]) + -Math.Abs(cls_Library.DBDecimal(Xrow2["R_Sum"]));
                    break;
                  }
                }
                dt.Rows.Add(Xrow2);
              }
            }
          }
        }
        dtHead = dt.Clone();

        dtJob = dt.Clone();
        //dtJobMonth = dt.Clone();
        //dtJobMonthCus = dt.Clone();

        foreach (DataRow r in dt.Rows)
        {
          //งาน
          DataRow[] dr1 = dtJob.Select("R_Job ='" + cls_Library.DBString(r["R_Job"]) + "'");
          if (dr1.Length <= 0)
          {
            DataRow _row = dtJob.NewRow();
            _row["R_Job"] = cls_Library.DBString(r["R_Job"]);
            for (j = 0; j < Nomonth; j++)
            {
              _row[colMonth[j]] = 0;
            }
            dtJob.Rows.Add(_row);
          }
        }

        foreach (DataRow r1 in dtJob.Rows)
        {
          Job1 = cls_Library.DBString(r1["R_Job"]).ToUpper();
          DataRow _row2 = dtHead.NewRow();
          _row2["R_Job"] = GetJobName(Job1); 
          foreach (DataRow r2 in dt.Rows)
          {
            Job2 = cls_Library.DBString(r2["R_Job"]).ToUpper();
            if (Job1 == Job2)
            {
              
              for (j = 0; j < Nomonth; j++)
              {
                if (colMonth[j].ToString().ToUpper()!="R_DATESUM")
                {
                _row2[colMonth[j]] =  cls_Library.DBDecimal(_row2[colMonth[j]]) + cls_Library.DBDecimal(r2[colMonth[j]]);
                _row2["R_DateSum"] = cls_Library.DBDecimal(_row2["R_DateSum"]) + cls_Library.DBDecimal(r2[colMonth[j]]);
                }
              }
            }
          }
          dtHead.Rows.Add(_row2);
        }


        //if (dtHead.Rows.Count > 0)
        //{
        //  DataRow _row2 = dtHead.NewRow();
        //  _row2["R_Job"] = "รวมทั้งหมด";
        //  for (j = 0; j < Nomonth; j++)
        //  {
        //    //decimal Sum= cls_Library.DBDecimal(dtHead.Compute("sum(" + colMonth[j] + ")", ""));
        //    decimal Sum = 0;
        //    foreach (DataRow r3 in dtHead.Rows)
        //    {
        //      Sum = Sum + cls_Library.DBDecimal(r3[colMonth[j]]);
        //    }

        //    _row2[colMonth[j]] = Sum;
        //  }
        //  dtHead.Rows.Add(_row2);
        //}

          


        //TotalCusMonth = 0;
        //TotalMonth = 0;
        //i = 0;
        //j = 0;
        //foreach (DataRow r in dt.Rows)
        //{
        //  DataRow[] dr = dtHead.Select("R_Job ='" + cls_Library.DBString(r["R_Job"]) + "' and R_Cus='" + cls_Library.DBString(r["R_Cus"]) + "' and R_CusMonth='" + cls_Library.DBString(r["R_CusMonth"]) + "'");
        //  i += 1;
        //  if (dr.Length <= 0)
        //  {
        //    DataRow _row = dtHead.NewRow();
        //    _row["R_Date"] = cls_Library.DBString(r["R_Job"]);
        //    _row["R_Type"] = 1;
        //    dtHead.Rows.Add(_row);

        //    _row["R_Date"] = TmonthName[cls_Library.DBDateTime(r["R_Date"]).Month] + " - " + cls_Library.DBDateTime(r["R_Date"]).ToString("0000");
        //    _row["R_Type"] = 2;
        //    dtHead.Rows.Add(_row);

        //    _row["R_Date"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Cus"]); 
        //    _row["R_Type"] = 3;
        //    dtHead.Rows.Add(_row);

        //    _row["R_Date"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Cus"]);
        //    _row["R_Job"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Job"]);
        //    _row["R_Date"] = cls_Library.DBDateTime(dtVoucher.Rows[i]["R_Date"]);
        //    _row["R_CusMonth"] = cls_Library.DBString(dtVoucher.Rows[i]["R_CusMonth"]);
        //    _row["R_Vnos"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Vnos"]);
        //    _row["R_Desc"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Desc"]);
        //    _row["R_Quan"] = cls_Library.DBDouble(dtVoucher.Rows[i]["R_Quan"]);
        //    _row["R_Uname"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Uname"]);
        //    _row["R_Unitprice"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Unitprice"]);
        //    _row["R_Cog"] = cls_Library.DBDouble(dtVoucher.Rows[i]["R_Cog"]);
        //    _row["R_Sum"] = cls_Library.DBDecimal(dtVoucher.Rows[i]["R_Sum"]);
        //    _row["R_Type"] = 4;
        //    dtHead.Rows.Add(_row);
        //  }
        //}


        //if (!(DataS.Tables["Head"] == null))
        //{
        //  if (DataS.Relations.Count > 0) DataS.Relations.Clear();
        //  DataS.Tables.Clear();
        //  //DataS.Tables.Remove("Head");
        //}
        //if (!(DataS.Tables["List"] == null))
        //{
        //  if (DataS.Relations.Count > 0) DataS.Relations.Clear();
        //  DataS.Tables.Remove("List");
        //}


        //DataS.Tables.Add(dt);
        DataS.Tables.Add(dtHead);

        //if (!(DataS.Tables["Head"] == null) && (DataS.Tables["Head"].Rows.Count > 0) && (DataS.Tables["List"].Rows.Count > 0))
        //{
        //  //_DS.Tables("List").Columns.Add("Balance", GetType(Decimal))
        //  if (DataS.Relations.Count <= 0)
        //  {
        //    DataS.Relations.Clear();
        //    DataS.Relations.Add("Relation", DataS.Tables["Head"].Columns["R_Cus_id"], DataS.Tables["List"].Columns["R_Cus_id"]);
        //  }
        //  //List = _DS.Tables("List").Copy()
        //}


        //sql = "SELECT DISTINCT CSTstk,CSTsto FROM CST";
        //dt = new DataTable("GetSTK");
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //  sql = "SELECT CSTstk,(SELECT STKuname1 FROM STK WHERE (STKcode = @STKcode)) AS CSTuname";
        //  sql += ",(SELECT STKgroup FROM STK AS STK_1  WHERE (STKcode = @STKcode)) AS CSTgroup,CSTsto FROM CST";
        //  sql += " WHERE CSTstk = @CSTstk AND CSTsto = @CSTsto";
        //  dtVoucher = new DataTable("CST");
        //  da = new SqlDataAdapter(sql, cn);
        //  da.SelectCommand.Parameters.Add("@STKcode", SqlDbType.NVarChar, 25).Value = cls_Library_CP.DBString(dt.Rows[i]["CSTstk"]);
        //  da.SelectCommand.Parameters.Add("@CSTstk", SqlDbType.NVarChar, 25).Value = cls_Library_CP.DBString(dt.Rows[i]["CSTstk"]);
        //  da.SelectCommand.Parameters.Add("@CSTsto", SqlDbType.NVarChar, 15).Value = cls_Library_CP.DBString(dt.Rows[i]["CSTsto"]);
        //  da.Fill(dtVoucher);
        //  if (i == 0)
        //  {
        //    DataS.Tables.Add(dtVoucher);
        //  }
        //  else
        //  {
        //    DataS.Tables["CST"].ImportRow(dtVoucher.Rows[0]);
        //  }
        //}
      }
      catch (Exception e)
      {
        this.Cursor = Cursors.Default;
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
    }

    private void InitialData2()
    {
      //cls_CST_CP.CSTgetBal("FG001", "MAIN", DateTime.Now);

      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      SqlDataAdapter da1 = null;
      string sql = string.Empty;
      //DateTime CaldateF;
      //DateTime CaldateT;
      DateTime dateT;
      DataTable dt = null;
      DataTable dtVoucher = null;
      DataTable dtVoucher1 = null;
      DataTable dtHead = null;
      DataTable dtJob = null;
      DataTable dtJobMonth = null;
      DataTable dtJobMonthCus = null;
      int i, j;
      int vf=0,vt=0;
      string Job1, Job2, Job3, Job4;
      string Cusmonth1, Cusmonth2, Cusmonth3;
      string Xcus, Pcus;
      string JOBgroup = "";
      bool CalOK = false;

      DateTime dateF = DateTime.Now.Date;

      decimal TotalJob = 0, TotalNetJob = 0;
      decimal TotalCusMonth = 0, TotalNetCusMonth = 0;
      decimal TotalMonth = 0, TotalNetMonth = 0;

      //หาผลรวม

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        CaldateF = cls_Global_class.GetDateCulture(txtDateStart.DateTime);
        CaldateT = cls_Global_class.GetDateCulture(txtDateEnd.DateTime);
        JOBgroup = "";
        DataS = new DataSet();
        dtHead = new DataTable("Head");

        dtHead.Columns.Clear();
        dtHead.Columns.Clear();
        dtHead.Columns.Add("R_Date", typeof(string));
        dtHead.Columns.Add("R_Vnos", typeof(string));
        dtHead.Columns.Add("R_Desc", typeof(string));
        dtHead.Columns.Add("R_Quan", typeof(string));
        dtHead.Columns.Add("R_Uname", typeof(string));
        dtHead.Columns.Add("R_Unitprice", typeof(string));
        dtHead.Columns.Add("R_Cog", typeof(decimal));
        dtHead.Columns.Add("R_Sum", typeof(decimal));
        dtHead.Columns.Add("R_Cus", typeof(string));
        dtHead.Columns.Add("R_Job", typeof(string));
        dtHead.Columns.Add("R_CusMonth", typeof(string));
        dtHead.Columns.Add("R_Type", typeof(int));

        dt = new DataTable("Head");
        dt = dtHead.Copy();

        sql = "Select MIH.*,MIL.* From MIH INNER JOIN MIL ON MIH.MIHday = MIL.MILday AND MIH.MIHmonth = MIL.MILmonth AND MIH.MIHyear = MIL.MILyear AND MIH.MIHType = MIL.MILtype And MIH.MIHvnos = MIL.MILvnos And MIH.MIHcus = MIL.MILcus";
        sql += " Where ";

        if (Vopt1.Checked == true)
        {
          sql += " MIL.MILtype='PP' and ";
        }
        else
        {
          sql += " (MIL.MILtype='DP' or MIL.MILtype='CP') and ";
        }

        if (cls_Library.DBInt(lkDateOpt.EditValue) < 6)
        {
          vf =  (CaldateF.Year * 10000) + (CaldateF.Month * 100) + CaldateF.Day;
          vt = (CaldateT.Year * 10000) + (CaldateT.Month * 100) + CaldateT.Day;
          sql += " (((MIL.MILyear*10000)+(MIL.MILmonth*100)+(MIL.MILday)>=@CaldateF) and ((MIL.MILyear*10000)+(MIL.MILmonth*100)+(MIL.MILday)<=@CaldateT))";
        }
        
        if (slookupJob.Visible)
        {
          sql += " and MIL.MILjob=@MILjob";
        }

        sql += " Order By MIL.MILjob,MIL.MILyear,MIL.MILmonth,MIL.MILday,MIL.MILcus,MIL.MILvnos";

        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        if (cls_Library.DBInt(lkDateOpt.EditValue) < 6)
        {
          da.SelectCommand.Parameters.Add("@CaldateF", SqlDbType.Int).Value = vf;
          da.SelectCommand.Parameters.Add("@CaldateT", SqlDbType.Int).Value = vt;
        }
        if (slookupJob.Visible)
        {
          da.SelectCommand.Parameters.Add("@MILjob", SqlDbType.NVarChar, 15).Value = slookupJob.EditValue;
        }
        
        da.SelectCommand.CommandTimeout = 1200;
        dtVoucher = new DataTable("Head");
        da.Fill(dtVoucher);
        for (i = 0; i < dtVoucher.Rows.Count; i++)
        {
          CalOK = true;
          if (slookupJobG.Visible)
          {
            JOBgroup = GetCodeJOBGroupOK(cls_Library.DBString(dtVoucher.Rows[i]["MILjob"]));
            if (slookupJobG.Text.ToUpper() != JOBgroup.ToUpper())
            {
              CalOK = false;
            }
          }
          if (CalOK == true)
          {
            DataRow Xrow1 = dt.NewRow();
            dateT = cls_Library.Date_CvDMY(cls_Library.DBInt(dtVoucher.Rows[i]["MILday"]), cls_Library.DBInt(dtVoucher.Rows[i]["MILmonth"]), cls_Library.DBInt(dtVoucher.Rows[i]["MILyear"]), false);
            Xrow1["R_Cus"] = cls_Library.DBString(dtVoucher.Rows[i]["MILcus"]);
            Xrow1["R_Job"] = cls_Library.DBString(dtVoucher.Rows[i]["MILjob"]);
            Xrow1["R_Date"] = cls_Library.CDateTime(dateT).ToShortDateString();
            if (Xrow1["R_Date"].ToString().Length == 0)
            {
              Application.DoEvents();
            }
            Xrow1["R_CusMonth"] = dateT.Month.ToString("00") + "/" + dateT.Year.ToString("0000");
            Xrow1["R_Vnos"] = cls_Library.DBString(dtVoucher.Rows[i]["MILvnos"]);
            Xrow1["R_Desc"] = cls_Library.DBString(dtVoucher.Rows[i]["MILdesc"]);
            Xrow1["R_Quan"] = cls_Library.DBDouble(dtVoucher.Rows[i]["MILquan"]);
            Xrow1["R_Uname"] = cls_Library.DBString(dtVoucher.Rows[i]["MILuname"]);
            Xrow1["R_Cog"] = cls_Library.DBDouble(dtVoucher.Rows[i]["MILcog"]) - cls_Library.DBDouble(dtVoucher.Rows[i]["MILdiscA"]) - cls_Library.DBDouble(dtVoucher.Rows[i]["MILadisc"]);
            Xrow1["R_Unitprice"] = (cls_Library.DBDouble(dtVoucher.Rows[i]["MILcog"]) * cls_Library.DBDouble(dtVoucher.Rows[i]["MILconv"])) / cls_Library.DBDouble(dtVoucher.Rows[i]["MILquan"]);
            //หาค่า Vat
            decimal DvatA = 0, Dxv = 0;
            if (cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHvatInList"]) == -1)
            {
              DvatA = cls_Library.DBDecimal(dtVoucher.Rows[i]["MILvat"]);
            }
            else
            {
              //Vat @ end, so have to make some cals here !
              DvatA = decimal.Round(cls_Library.DBDecimal(dtVoucher.Rows[i]["MILcog"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MILdiscA"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MILadisc"]), 2, MidpointRounding.AwayFromZero);
              Dxv = cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHcog"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHdiscLST"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHdiscHF1"]) - cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHdiscHF2"]);
              if ((Dxv != 0) && (DvatA > 0))
              {
                DvatA = decimal.Round(DvatA * (cls_Library.DBDecimal(dtVoucher.Rows[i]["MIHvatSUM"]) / Dxv), 2, MidpointRounding.AwayFromZero);
              }
              else
              {
                DvatA = 0;
              }
            }
            Xrow1["R_Sum"] = cls_Library.DBDecimal(Xrow1["R_Cog"]) + DvatA;
            dt.Rows.Add(Xrow1);
            if (cls_Library.DBString(dtVoucher.Rows[i]["MILvnos"]) == "INV-1001003")
            {
              Application.DoEvents();
            }
            if (Vopt2.Checked == true)
            {
              dateT = cls_Library.Date_CvDMY(cls_Library.DBInt(dtVoucher.Rows[i]["MILday"]), cls_Library.DBInt(dtVoucher.Rows[i]["MILmonth"]), cls_Library.DBInt(dtVoucher.Rows[i]["MILyear"]), false);
              sql = "Select MIH.*,MIL.* From MIH INNER JOIN MIL ON MIH.MIHday = MIL.MILday AND MIH.MIHmonth = MIL.MILmonth AND MIH.MIHyear = MIL.MILyear AND MIH.MIHType = MIL.MILtype And MIH.MIHvnos = MIL.MILvnos And MIH.MIHcus = MIL.MILcus";
              sql += " Where (MIL.MILtype='AP' or MIL.MILtype='BP') and MILcus=@MILcus and MILlinkVCtype='DP' and MILlinkVCdate=@MILlinkVCdate and MILlinkVCno=@MILlinkVCno and MILlinkVCid=@MILlinkVCid";
              da1 = new SqlDataAdapter(sql, cn);
              da1.SelectCommand.Parameters.Clear();
              da1.SelectCommand.Parameters.Add("@MILcus", SqlDbType.NVarChar, 15).Value = cls_Library.DBString(dtVoucher.Rows[i]["MILcus"]);
              da1.SelectCommand.Parameters.Add("@MILlinkVCdate", SqlDbType.DateTime).Value = dateT;
              da1.SelectCommand.Parameters.Add("@MILlinkVCno", SqlDbType.NVarChar, 15).Value = cls_Library.DBString(dtVoucher.Rows[i]["MILvnos"]);
              da1.SelectCommand.Parameters.Add("@MILlinkVCid", SqlDbType.Int).Value = cls_Library.DBInt(dtVoucher.Rows[i]["MILlinkVCid"]);
              da1.SelectCommand.CommandTimeout = 1200;
              dtVoucher1 = new DataTable("Head");
              da1.Fill(dtVoucher1);
              for (j = 0; j < dtVoucher1.Rows.Count; j++)
              {
                DataRow Xrow2 = dt.NewRow();
                //dt.Rows.Add();
                dateT = cls_Library.Date_CvDMY(cls_Library.DBInt(dtVoucher1.Rows[j]["MILday"]), cls_Library.DBInt(dtVoucher1.Rows[j]["MILmonth"]), cls_Library.DBInt(dtVoucher1.Rows[j]["MILyear"]), false);
                Xrow2["R_Cus"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILcus"]);
                Xrow2["R_Job"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILjob"]);
                Xrow2["R_Date"] = cls_Library.CDateTime(dateT).ToShortDateString();
                Xrow2["R_CusMonth"] = dateT.Month.ToString("00") + "/" + dateT.Year.ToString("0000");
                Xrow2["R_Vnos"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILvnos"]);
                Xrow2["R_Desc"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILdesc"]);
                Xrow2["R_Quan"] = -Math.Abs(cls_Library.DBDouble(dtVoucher1.Rows[j]["MILquan"]));
                Xrow2["R_Uname"] = cls_Library.DBString(dtVoucher1.Rows[j]["MILuname"]);
                Xrow2["R_Cog"] = -Math.Abs(cls_Library.DBDouble(dtVoucher1.Rows[j]["MILcog"]) - cls_Library.DBDouble(dtVoucher1.Rows[j]["MILdiscA"]) - cls_Library.DBDouble(dtVoucher1.Rows[j]["MILadisc"]));
                Xrow2["R_Unitprice"] = -Math.Abs((cls_Library.DBDouble(dtVoucher1.Rows[j]["MILcog"]) * cls_Library.DBDouble(dtVoucher1.Rows[j]["MILconv"])) / cls_Library.DBDouble(dtVoucher1.Rows[j]["MILquan"]));
                //หาค่า Vat
                decimal DvatA1 = 0, Dxv1 = 0;
                if (cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHvatInList"]) == -1)
                {
                  DvatA1 = cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILvat"]);
                }
                else
                {
                  //Vat @ end, so have to make some cals here !
                  DvatA1 = decimal.Round(cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILcog"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILdiscA"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILadisc"]), 2, MidpointRounding.AwayFromZero);
                  Dxv1 = cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHcog"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHdiscLST"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHdiscHF1"]) - cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHdiscHF2"]);
                  if ((Dxv1 != 0) && (DvatA1 > 0))
                  {
                    DvatA1 = decimal.Round(DvatA1 * (cls_Library.DBDecimal(dtVoucher1.Rows[j]["MIHvatSUM"]) / Dxv1), 2, MidpointRounding.AwayFromZero);
                  }
                  else
                  {
                    DvatA1 = 0;
                  }
                }
                //Xrow2["R_Sum"] = -Math.Abs(cls_Library.DBDecimal(dtVoucher1.Rows[j]["MILsum"]) + DvatA1);
                if (cls_Library.DBString(dtVoucher1.Rows[j]["MILvnos"]) == "BP")
                {
                  Xrow2["R_Sum"] = -Math.Abs(Math.Abs(cls_Library.DBDecimal(Xrow2["R_Cog"])) + Math.Abs(DvatA1));
                }
                else
                {
                  Xrow2["R_Sum"] = -Math.Abs(Math.Abs(cls_Library.DBDecimal(Xrow2["R_Cog"])) + Math.Abs(DvatA1));
                }
                dt.Rows.Add(Xrow2);
              }
            }
          }
        }
        dtHead = dt.Clone();

        dtJob = dt.Clone();
        dtJobMonth = dt.Clone();
        dtJobMonthCus = dt.Clone();

        foreach (DataRow r in dt.Rows)
        {
          //งาน
          DataRow[] dr1 = dtJob.Select("R_Job ='" + cls_Library.DBString(r["R_Job"]) + "'");
          if (dr1.Length <= 0)
          {
            DataRow _row = dtJob.NewRow();
            _row["R_Job"] = cls_Library.DBString(r["R_Job"]);
            dtJob.Rows.Add(_row);
          }
          //งาน-เดือน-ปี
          DataRow[] dr2 = dtJobMonth.Select("R_Job ='" + cls_Library.DBString(r["R_Job"]) + "' and R_CusMonth='" + cls_Library.DBString(r["R_CusMonth"]) + "'");
          if (dr2.Length <= 0)
          {
            DataRow _row = dtJobMonth.NewRow();
            _row["R_Job"] = cls_Library.DBString(r["R_Job"]);
            _row["R_CusMonth"] = cls_Library.DBString(r["R_CusMonth"]);
            _row["R_Date"] = cls_Library.DBString(r["R_Date"]);
            if (cls_Library.DBString(r["R_Date"]).ToString().Length == 0)
            {
              Application.DoEvents();
            }
            dtJobMonth.Rows.Add(_row);
          }
          //งาน-เดือน-ปี-เจ้าหนี้
          DataRow[] dr3 = dtJobMonthCus.Select("R_Job ='" + cls_Library.DBString(r["R_Job"]) + "' and R_CusMonth='" + cls_Library.DBString(r["R_CusMonth"]) + "' and R_Cus='" + cls_Library.DBString(r["R_Cus"]) + "'");
          if (dr3.Length <= 0)
          {
            DataRow _row = dtJobMonthCus.NewRow();
            _row["R_Job"] = cls_Library.DBString(r["R_Job"]);
            _row["R_CusMonth"] = cls_Library.DBString(r["R_CusMonth"]);
            _row["R_Cus"] = cls_Library.DBString(r["R_Cus"]);
            _row["R_Date"] = cls_Library.DBString(r["R_Date"]);
            dtJobMonthCus.Rows.Add(_row);
          }
        }

        foreach (DataRow r1 in dtJob.Rows)
        {
          //ระดับ 1 งาน
          DataRow _row1 = dtHead.NewRow();
          _row1["R_Date"] = GetJobName(cls_Library.DBString(r1["R_Job"]));
          _row1["R_Type"] = 1;
          dtHead.Rows.Add(_row1);
          Job1 = cls_Library.DBString(r1["R_Job"]).ToUpper();
          TotalJob = 0;
          TotalNetJob = 0;
          foreach (DataRow r2 in dtJobMonth.Rows)
          {
            Job2 = cls_Library.DBString(r2["R_Job"]).ToUpper();
            Cusmonth1 = cls_Library.DBString(r2["R_CusMonth"]).ToUpper();
            if (Job1 == Job2)
            {
              //ระดับ 2 งาน-เดือน/ปี
              DataRow _row2 = dtHead.NewRow();
              _row2["R_Date"] = TmonthName[cls_Library.DBDateTime(r2["R_Date"]).Month] + " - " + cls_Library.DBDateTime(r2["R_Date"]).Year.ToString("0000");
              _row2["R_Type"] = 2;
              dtHead.Rows.Add(_row2);

              Xcus = "";
              Pcus = "";
              TotalMonth = 0;
              TotalNetMonth = 0;
              foreach (DataRow r3 in dtJobMonthCus.Rows)
              {
                Cusmonth2 = cls_Library.DBString(r3["R_CusMonth"]).ToUpper();
                Job3 = cls_Library.DBString(r3["R_Job"]).ToUpper();
                if (Job2 == Job3 && Cusmonth1 == Cusmonth2)
                {
                  j = 0;
                  
                  Xcus = cls_Library.DBString(r3["R_Cus"]).ToUpper();
                  //ระดับ 3 งาน-เดือน/ปี-เจ้าหนี้
                  DataRow _row3 = dtHead.NewRow();

                  _row3["R_Date"] =GetCusName(Xcus);
                  _row3["R_Type"] = 3;
                  dtHead.Rows.Add(_row3);

                  TotalCusMonth = 0;
                  TotalNetCusMonth = 0;
                  foreach (DataRow r4 in dt.Rows)
                  {
                    Pcus = cls_Library.DBString(r4["R_Cus"]).ToUpper();
                    Job4 = cls_Library.DBString(r4["R_Job"]).ToUpper();
                    Cusmonth3 = cls_Library.DBString(r4["R_CusMonth"]).ToUpper();
                    if (Job3 == Job4 && Cusmonth2 == Cusmonth3 && Xcus==Pcus)
                    {
                      j += 1;
                      DataRow _row4 = dtHead.NewRow();
                      //_row4["R_Date"] = cls_Library.DBString(r4["R_Cus"]);
                      _row4["R_Job"] = cls_Library.DBString(r4["R_Job"]);
                      _row4["R_Date"] = cls_Library.DBDateTime(r4["R_Date"]).ToShortDateString();
                      _row4["R_CusMonth"] = cls_Library.DBString(r4["R_CusMonth"]);
                      _row4["R_Vnos"] = cls_Library.DBString(r4["R_Vnos"]);
                      _row4["R_Desc"] = cls_Library.DBString(r4["R_Desc"]);
                      _row4["R_Quan"] = cls_Library.DBDouble(r4["R_Quan"]).ToString("#,##0.00") + "  " + cls_Library.DBString(r4["R_Uname"]);
                      _row4["R_Uname"] = cls_Library.DBString(r4["R_Uname"]);
                      _row4["R_Unitprice"] = cls_Library.DBDouble(r4["R_Unitprice"]).ToString("#,##0.00");
                      _row4["R_Cog"] = cls_Library.DBDecimal(r4["R_Cog"]);
                      _row4["R_Sum"] = cls_Library.DBDecimal(r4["R_Sum"]);
                      _row4["R_Type"] = 4;
                      dtHead.Rows.Add(_row4);

                      //เก็บค่าสะสม
                      TotalJob += cls_Library.DBDecimal(r4["R_Cog"]); ;
                      TotalNetJob += cls_Library.DBDecimal(r4["R_Sum"]); 
                      TotalMonth += cls_Library.DBDecimal(r4["R_Cog"]);
                      TotalNetMonth += cls_Library.DBDecimal(r4["R_Sum"]);  
                      TotalCusMonth += cls_Library.DBDecimal(r4["R_Cog"]); 
                      TotalNetCusMonth += cls_Library.DBDecimal(r4["R_Sum"]); 
                    }
                    
                  }
                  //รวม Cus-Month
                  DataRow _row5 = dtHead.NewRow();
                  _row5["R_Unitprice"] = "";
                  _row5["R_Cog"] = TotalCusMonth;
                  _row5["R_Sum"] = TotalNetCusMonth;
                  dtHead.Rows.Add(_row5);
                }
              }
              //รวม Month
              DataRow _row6 = dtHead.NewRow();
              _row6["R_Unitprice"] = TmonthName[cls_Library.DBDateTime(r2["R_Date"]).Month] + " - " + cls_Library.DBDateTime(r2["R_Date"]).Year.ToString("0000");
              _row6["R_Cog"] = TotalMonth;
              _row6["R_Sum"] = TotalNetMonth;
              dtHead.Rows.Add(_row6);
            }
          }
          //รวมงาน
          DataRow _row7 = dtHead.NewRow();
          _row7["R_Unitprice"] = "รวมทั้งหมด";
          _row7["R_Cog"] = TotalJob;
          _row7["R_Sum"] = TotalNetJob;
          dtHead.Rows.Add(_row7);
        }


        //TotalCusMonth = 0;
        //TotalMonth = 0;
        //i = 0;
        //j = 0;
        //foreach (DataRow r in dt.Rows)
        //{
        //  DataRow[] dr = dtHead.Select("R_Job ='" + cls_Library.DBString(r["R_Job"]) + "' and R_Cus='" + cls_Library.DBString(r["R_Cus"]) + "' and R_CusMonth='" + cls_Library.DBString(r["R_CusMonth"]) + "'");
        //  i += 1;
        //  if (dr.Length <= 0)
        //  {
        //    DataRow _row = dtHead.NewRow();
        //    _row["R_Date"] = cls_Library.DBString(r["R_Job"]);
        //    _row["R_Type"] = 1;
        //    dtHead.Rows.Add(_row);

        //    _row["R_Date"] = TmonthName[cls_Library.DBDateTime(r["R_Date"]).Month] + " - " + cls_Library.DBDateTime(r["R_Date"]).ToString("0000");
        //    _row["R_Type"] = 2;
        //    dtHead.Rows.Add(_row);

        //    _row["R_Date"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Cus"]); 
        //    _row["R_Type"] = 3;
        //    dtHead.Rows.Add(_row);

        //    _row["R_Date"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Cus"]);
        //    _row["R_Job"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Job"]);
        //    _row["R_Date"] = cls_Library.DBDateTime(dtVoucher.Rows[i]["R_Date"]);
        //    _row["R_CusMonth"] = cls_Library.DBString(dtVoucher.Rows[i]["R_CusMonth"]);
        //    _row["R_Vnos"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Vnos"]);
        //    _row["R_Desc"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Desc"]);
        //    _row["R_Quan"] = cls_Library.DBDouble(dtVoucher.Rows[i]["R_Quan"]);
        //    _row["R_Uname"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Uname"]);
        //    _row["R_Unitprice"] = cls_Library.DBString(dtVoucher.Rows[i]["R_Unitprice"]);
        //    _row["R_Cog"] = cls_Library.DBDouble(dtVoucher.Rows[i]["R_Cog"]);
        //    _row["R_Sum"] = cls_Library.DBDecimal(dtVoucher.Rows[i]["R_Sum"]);
        //    _row["R_Type"] = 4;
        //    dtHead.Rows.Add(_row);
        //  }
        //}


        //if (!(DataS.Tables["Head"] == null))
        //{
        //  if (DataS.Relations.Count > 0) DataS.Relations.Clear();
        //  DataS.Tables.Clear();
        //  //DataS.Tables.Remove("Head");
        //}
        //if (!(DataS.Tables["List"] == null))
        //{
        //  if (DataS.Relations.Count > 0) DataS.Relations.Clear();
        //  DataS.Tables.Remove("List");
        //}


        //DataS.Tables.Add(dt);
        DataS.Tables.Add(dtHead);

        //if (!(DataS.Tables["Head"] == null) && (DataS.Tables["Head"].Rows.Count > 0) && (DataS.Tables["List"].Rows.Count > 0))
        //{
        //  //_DS.Tables("List").Columns.Add("Balance", GetType(Decimal))
        //  if (DataS.Relations.Count <= 0)
        //  {
        //    DataS.Relations.Clear();
        //    DataS.Relations.Add("Relation", DataS.Tables["Head"].Columns["R_Cus_id"], DataS.Tables["List"].Columns["R_Cus_id"]);
        //  }
        //  //List = _DS.Tables("List").Copy()
        //}


        //sql = "SELECT DISTINCT CSTstk,CSTsto FROM CST";
        //dt = new DataTable("GetSTK");
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //  sql = "SELECT CSTstk,(SELECT STKuname1 FROM STK WHERE (STKcode = @STKcode)) AS CSTuname";
        //  sql += ",(SELECT STKgroup FROM STK AS STK_1  WHERE (STKcode = @STKcode)) AS CSTgroup,CSTsto FROM CST";
        //  sql += " WHERE CSTstk = @CSTstk AND CSTsto = @CSTsto";
        //  dtVoucher = new DataTable("CST");
        //  da = new SqlDataAdapter(sql, cn);
        //  da.SelectCommand.Parameters.Add("@STKcode", SqlDbType.NVarChar, 25).Value = cls_Library_CP.DBString(Xrow1["CSTstk"]);
        //  da.SelectCommand.Parameters.Add("@CSTstk", SqlDbType.NVarChar, 25).Value = cls_Library_CP.DBString(Xrow1["CSTstk"]);
        //  da.SelectCommand.Parameters.Add("@CSTsto", SqlDbType.NVarChar, 15).Value = cls_Library_CP.DBString(Xrow1["CSTsto"]);
        //  da.Fill(dtVoucher);
        //  if (i == 0)
        //  {
        //    DataS.Tables.Add(dtVoucher);
        //  }
        //  else
        //  {
        //    DataS.Tables["CST"].ImportRow(dtVoucher.Rows[0]);
        //  }
        //}
      }
      catch (Exception e)
      {
        this.Cursor = Cursors.Default;
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
    }

    private void SetslookUP()
    {
      slookupJob.Properties.PopulateViewColumns();
      slookupJob.Properties.ValueMember = "JOBcode";
      slookupJob.Properties.DisplayMember = "JOBcode";
      //slookupCus.Properties.View.Columns["Cus_id"].Visible = false;
      slookupJob.Properties.View.Columns["JOBcode"].Caption = "รหัสงาน";
      slookupJob.Properties.View.Columns["JOBdescT"].Caption = "ชื่องาน (ไทย)";
      slookupJob.Properties.View.Columns["JOBdescE"].Caption = "ชื่องาน (อังกฤษ)";

      slookupJobG.Properties.PopulateViewColumns();
      slookupJobG.Properties.ValueMember = "JOBgroup";
      slookupJobG.Properties.DisplayMember = "JOBgroup";
      //slookupCus.Properties.View.Columns["Cus_id"].Visible = false;
      slookupJobG.Properties.View.Columns["JOBgroup"].Caption = "กลุ่มงาน";
      //slookupJob.Properties.View.Columns["JOBdescT"].Caption = "ชื่องาน (ไทย)";
      //slookupJob.Properties.View.Columns["JOBdescE"].Caption = "ชื่องาน (อังกฤษ)";
    }

    private void SetGrid()
    {
      int i;
      int day = 0;
      int month = 0;
      int year = 0;
      DateTime CaldateF;
      DateTime CaldateT;
      DateTime DateStart;

      //--- กำหนดค่าของ Heading 
      gvHead.Columns.Clear();

      #region "ตัวเลือก 1"
      if (Mopt1.Checked == true)
      {
        GridColumn colCus = cls_Form.AddGridColumn("R_Cus_id", "บริษัท", "R_Cus_id", true, 0, 100);
        //GridColumn colDate = cls_Form.AddGridColumn("R_Date", "วันที่", "R_Date", true, 0, 100);
        string Xcom = GetComName();
        GridColumn colCusName = cls_Form.AddGridColumn("R_Job", Xcom, "R_Job", true, 1, 300);
        GridColumn[] colMonth = new GridColumn[Nomonth];

        colCusName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colCusName.AppearanceHeader.Options.UseTextOptions = true;
        colCusName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        colCusName.AppearanceCell.Options.UseTextOptions = true;
        colCusName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        colCusName.SummaryItem.DisplayFormat = "{0:#,##0} " + " รายการ";

        CaldateF = cls_Global_class.GetDateCulture(txtDateStart.DateTime);
        CaldateT = cls_Global_class.GetDateCulture(txtDateEnd.DateTime);

        
        day = 1;
        month = CaldateF.Month;
        year = CaldateF.Year;
        CaldateF = new DateTime(year, month, day);

        month = CaldateT.Month + 1;
        year = CaldateT.Year;
        if (month == 13)
        {
          month = 1;
          year += 1;
        }
        day = DateTime.DaysInMonth(year, month);
        CaldateT = new DateTime(year, month, day);

        var dateSpan = DateTimeSpan.CompareDates(CaldateF, CaldateT);

        Nomonth = dateSpan.Years * 12;
        Nomonth += 1;
        Nomonth =Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Month, CaldateF, CaldateT, FirstDayOfWeek.Sunday));
        //NO = STOg.Length;

        DateStart = CaldateF.AddMonths(-1);

        Array.Resize(ref colMonth, Nomonth);
        for (i = 0; i < Nomonth; i++)
        {
          DateStart = DateStart.AddMonths(1);
          string Xm = DateStart.Month.ToString("00");
          string Xy = DateStart.Year.ToString("0000");
          string Xname = DateStart.Month.ToString("00") + "/" + DateStart.Year.ToString("0000");
          colMonth[i] = cls_Form.AddGridColumn("R_" + Xm + Xy, Xname, "R_" + Xm + Xy, true, 1 + i, 100);
          colMonth[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          colMonth[i].AppearanceHeader.Options.UseTextOptions = true;
          colMonth[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
          colMonth[i].AppearanceCell.Options.UseTextOptions = true;
          colMonth[i].DisplayFormat.FormatString = "#,##0.00";
          colMonth[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          colMonth[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
          colMonth[i].SummaryItem.DisplayFormat = "{0:#,##0.00}";
        }

        GridColumn colSummary = cls_Form.AddGridColumn("R_DateSum", "ต้นทุนรวม", "R_DateSum", true, 1 + Nomonth + 1, 100);

        colSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colSummary.AppearanceHeader.Options.UseTextOptions = true;
        colSummary.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        colSummary.AppearanceCell.Options.UseTextOptions = true;
        colSummary.DisplayFormat.FormatString = "#,##0.00";
        colSummary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        colSummary.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        colSummary.SummaryItem.DisplayFormat = "{0:#,##0.00}";

        //colSum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //colSum.AppearanceHeader.Options.UseTextOptions = true;
        //colSum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        //colSum.AppearanceCell.Options.UseTextOptions = true;
        //colSum.DisplayFormat.FormatString = "#,##0.00";
        //colSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        //colSum.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        //colSum.SummaryItem.DisplayFormat = "{0:#,##0.00}";

        //Grid.BeginInit();
        gvHead.BeginInit();
        //gvList.BeginInit();
        //h_colCusid.Visible = false;
        //colIns.Visible = false;
        colCus.Visible = false;
        //colPartCode.Visible = false;

        gvHead.OptionsView.ShowGroupPanel = false;
        gvHead.Columns.Clear();
        gvHead.Columns.AddRange(new GridColumn[] { colCus, colCusName });
        //gvList.Columns.AddRange(new GridColumn[] { colCus, colDate, colMCName, colMCModel, colPartCode, colSN, colPartname, colQuan, colSum });


        for (i = 0; i < Nomonth; i++)
        {
          gvHead.Columns.Add(colMonth[i]);
        }

        gvHead.Columns.Add(colSummary);

        gvHead.OptionsView.ShowFooter = true;
        gvHead.OptionsSelection.EnableAppearanceFocusedCell = false;
        gvHead.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
        gvHead.OptionsSelection.MultiSelect = true;
        gvHead.OptionsView.ColumnAutoWidth = false;

        gvHead.OptionsBehavior.Editable = false;
        gvHead.OptionsSelection.EnableAppearanceFocusedCell = false;
        gvHead.OptionsView.EnableAppearanceEvenRow = true;
        gvHead.OptionsView.EnableAppearanceOddRow = false;
        gvHead.IndicatorWidth = 50;

        //gv.OptionsView.ColumnAutoWidth = false;
        gvHead.OptionsView.RowAutoHeight = true;
        gvHead.OptionsView.ShowAutoFilterRow = true;

        //gvList.OptionsView.ShowFooter = true;
        //gvList.OptionsView.ShowGroupPanel = false;
        //gvList.OptionsBehavior.Editable = false;
        //gvList.OptionsSelection.EnableAppearanceFocusedCell = false;
        //gvList.OptionsView.EnableAppearanceEvenRow = false;
        //gvList.OptionsView.EnableAppearanceOddRow = true;
        //gvList.IndicatorWidth = 50;

        //gv.OptionsView.ColumnAutoWidth = false;
        gvHead.OptionsView.RowAutoHeight = true;
        gvHead.OptionsView.ShowAutoFilterRow = true;
        //foreach (GridColumn col in gvList.Columns)
        //{
        //  //col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        //  col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        //  col.OptionsFilter.AllowFilter = false;
        //}
      }
      #endregion
      else
      #region "ตัวเลือก 2"
      {
        GridColumn colDate = cls_Form.AddGridColumn("R_Date", "วันที่ใบสำคัญ", "R_Date", true, 0, 300);  //จะเก็บ หรัสงานและรหัสเจ้าหนี้ด้วย
        GridColumn colVnos = cls_Form.AddGridColumn("R_Vnos", "เลขที่ใบสำคัญ", "R_Vnos", true, 1, 100);
        GridColumn colDesc = cls_Form.AddGridColumn("R_Desc", "รายละเอียดรายการสินค้า", "R_Desc", true, 2, 250);
        GridColumn colQuan = cls_Form.AddGridColumn("R_Quan", "ปริมาณสินค้า", "R_Quan", true, 3, 80);
        GridColumn colUname = cls_Form.AddGridColumn("R_Uname", "ชื่อหน่วยนับ", "R_Uname", true, 4, 100);
        GridColumn colUnitprice = cls_Form.AddGridColumn("R_Unitprice", "ราคาต่อหน่วย", "R_Unitprice", true, 5, 100);
        GridColumn colCog = cls_Form.AddGridColumn("R_Cog", "ราคาสินค้า", "R_Cog", true, 6, 80);
        GridColumn colSum = cls_Form.AddGridColumn("R_Sum", "ราคาสินค้ารวมภาษี", "R_Sum", true, 7, 100);
        GridColumn colCus = cls_Form.AddGridColumn("R_Cus", "รหัสเจ้าหนี้", "R_Cus", true, 8, 100);
        GridColumn colJob = cls_Form.AddGridColumn("R_Job", "รหัสงาน", "R_Job", true, 9, 100);
        GridColumn colCusMonth = cls_Form.AddGridColumn("R_CusMonth", "เดือนปี", "R_CusMonth", true, 10, 100);
        GridColumn colType = cls_Form.AddGridColumn("R_Type", "Type", "R_Type", true, 11, 100);

        //Grid.BeginInit();
        gvHead.BeginInit();
        //h_colCusid.Visible = false;
        //colIns.Visible = false;
        //colCus.Visible = false;
        //colPartCode.Visible = false;

        colUname.Visible = false;
        colCus.Visible = false;
        colJob.Visible = false;
        colType.Visible = false;

        colDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colDate.AppearanceHeader.Options.UseTextOptions = true;
        colDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        colDate.AppearanceCell.Options.UseTextOptions = true;
        colDate.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        colDate.SummaryItem.DisplayFormat = "{0:#,##0} " + " รายการ";

        colVnos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colVnos.AppearanceHeader.Options.UseTextOptions = true;
        colVnos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colVnos.AppearanceCell.Options.UseTextOptions = true;

        colDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colDesc.AppearanceHeader.Options.UseTextOptions = true;
        colDesc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        colDesc.AppearanceCell.Options.UseTextOptions = true;

        colQuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colQuan.AppearanceHeader.Options.UseTextOptions = true;
        colQuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        colQuan.AppearanceCell.Options.UseTextOptions = true;
        colQuan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        colQuan.DisplayFormat.FormatString = "#,##0.00";
        //colQuan.SummaryItem.DisplayFormat = "{0:#,##0.00}";

        colUnitprice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colUnitprice.AppearanceHeader.Options.UseTextOptions = true;
        colUnitprice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        colUnitprice.AppearanceCell.Options.UseTextOptions = true;
        colUnitprice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        colUnitprice.DisplayFormat.FormatString = "#,##0.00";
        //colUnitprice.SummaryItem.DisplayFormat = "{0:#,##0.00}";

        colCog.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colCog.AppearanceHeader.Options.UseTextOptions = true;
        colCog.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        colCog.AppearanceCell.Options.UseTextOptions = true;
        colCog.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        colCog.DisplayFormat.FormatString = "#,##0.00";
        //colCog.SummaryItem.DisplayFormat = "{0:#,##0.00}";

        colSum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        colSum.AppearanceHeader.Options.UseTextOptions = true;
        colSum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        colSum.AppearanceCell.Options.UseTextOptions = true;
        colSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        colSum.DisplayFormat.FormatString = "#,##0.00";
        //colSum.SummaryItem.DisplayFormat = "{0:#,##0.00}";

        gvHead.OptionsView.ShowGroupPanel = false;
        gvHead.Columns.Clear();
        //gvHead.Columns.AddRange(new GridColumn[] { colDate, colVnos, colDesc, colQuan, colUname, colUnitprice, colCog, colSum, colCus, colJob, colType });
        gvHead.Columns.AddRange(new GridColumn[] { colDate, colVnos, colDesc, colQuan, colUnitprice, colCog, colSum, colType });

        gvHead.OptionsView.ShowFooter = true;
        gvHead.OptionsSelection.EnableAppearanceFocusedCell = false;
        gvHead.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
        gvHead.OptionsSelection.MultiSelect = true;
        gvHead.OptionsView.ColumnAutoWidth = false;


        gvHead.OptionsBehavior.Editable = false;
        gvHead.OptionsSelection.EnableAppearanceFocusedCell = false;
        gvHead.OptionsView.EnableAppearanceEvenRow = true;
        gvHead.OptionsView.EnableAppearanceOddRow = false;
        gvHead.IndicatorWidth = 50;

        //gv.OptionsView.ColumnAutoWidth = false;
        gvHead.OptionsView.RowAutoHeight = true;
        gvHead.OptionsView.ShowAutoFilterRow = true;

        //gv.OptionsView.ColumnAutoWidth = false;
        gvHead.OptionsView.RowAutoHeight = true;
        gvHead.OptionsView.ShowAutoFilterRow = true;

        

        


        //styleDef.Appearance.ForeColor = Color.Blue;
        styleDef.Appearance.BackColor = Color.LightYellow;
        styleDef.Appearance.BackColor2 = Color.LightYellow;
        styleDef.Appearance.Options.UseBackColor = true;
        styleDef.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
        //styleDef.Value1 = 0;
        //styleDef.Value2 = colBalanace;
        styleDef.Column = colDate;
        styleDef.Expression = "[R_Type] = 1";
        //styleDef.ApplyToRow = true;
        gvHead.FormatConditions.Add(styleDef);


        styleDef2.Appearance.BackColor = Color.LightSalmon;
        styleDef2.Appearance.BackColor2 = Color.LightSalmon;
        styleDef2.Appearance.Options.UseBackColor = true;
        styleDef2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
        //styleDef.Value1 = 0;
        //styleDef.Value2 = colBalanace;
        styleDef2.Column = colDate;
        styleDef2.Expression = "[R_Type] = 2";
        //styleDef2.ApplyToRow = true;
        gvHead.FormatConditions.Add(styleDef2);

        styleDef3.Appearance.BackColor = Color.LightBlue;
        styleDef3.Appearance.BackColor2 = Color.LightBlue;
        styleDef3.Appearance.Options.UseBackColor = true;
        styleDef3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
        //styleDef.Value1 = 0;
        //styleDef.Value2 = colBalanace;
        styleDef3.Column = colDate;
        styleDef3.Expression = "[R_Type] = 3";
        //styleDef2.ApplyToRow = true;
        gvHead.FormatConditions.Add(styleDef3);


        //styleDef2.Appearance.BackColor = Color.BlueViolet;
        //styleDef2.Appearance.BackColor2 = Color.BlueViolet;
        //styleDef2.Appearance.Options.UseBackColor = true;
        //styleDef2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
        ////styleDef.Value1 = 0;
        ////styleDef.Value2 = colBalanace;
        ////styleDef.Column = colBalanace;
        //styleDef2.Expression = "[R_Type] = 5";
        //styleDef2.ApplyToRow = true;
        //gvHead.FormatConditions.Add(styleDef2);

        //foreach (GridColumn col in gvList.Columns)
        //{
        //  //col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        //  col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        //  col.OptionsFilter.AllowFilter = false;
        //}
      }
      #endregion

      //styleDef.Appearance.BackColor = Color.Red;
      //styleDef.Appearance.BackColor2 = Color.Red;
      //styleDef.Appearance.Options.UseBackColor = true;
      //styleDef.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
      ////styleDef.Value1 = 0;
      ////styleDef.Value2 = colBalanace;
      ////styleDef.Column = colBalanace;
      //styleDef.Expression = "[R_Min] > [R_Balanace]";
      //styleDef.ApplyToRow = true;
      //gvHead.FormatConditions.Add(styleDef);

      //h_colquan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //h_colquan.DisplayFormat.FormatString = "n5";
      //h_colcost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //h_colcost.DisplayFormat.FormatString = "n5";
      //h_colorder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //h_colorder.DisplayFormat.FormatString = "n5";
      //h_colreceive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //h_colreceive.DisplayFormat.FormatString = "n5";
      //h_colbetween.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //h_colbetween.DisplayFormat.FormatString = "n5";
      //h_colaccrued.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //h_colaccrued.DisplayFormat.FormatString = "n5";

      //colquan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //colquan.DisplayFormat.FormatString = "n5";
      //colcost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //colcost.DisplayFormat.FormatString = "n5";
      //colorder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //colorder.DisplayFormat.FormatString = "n5";
      //colreceive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //colreceive.DisplayFormat.FormatString = "n5";
      //colbetween.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //colbetween.DisplayFormat.FormatString = "n5";
      //colaccrued.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      //colaccrued.DisplayFormat.FormatString = "n5";
      //colstk.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
      //colstk.SummaryItem.DisplayFormat = "{0:#,##0} " + " รหัส";
      //colquan.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
      //colquan.SummaryItem.DisplayFormat = "{0:#,##0.00000}";
      //colcost.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
      //colcost.SummaryItem.DisplayFormat = "{0:#,##0.00000}";
      //colorder.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
      //colorder.SummaryItem.DisplayFormat = "{0:#,##0.00000}";
      //colreceive.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
      //colreceive.SummaryItem.DisplayFormat = "{0:#,##0.00000}";
      //colbetween.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
      //colbetween.SummaryItem.DisplayFormat = "{0:#,##0.00000}";
      //colaccrued.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
      //colaccrued.SummaryItem.DisplayFormat = "{0:#,##0.00000}";
      //if (txtSTO.Visible)
      //{
      //  for (i = 0; i < NO; i++)
      //  {
      //    gv.Columns.Add(colSTO[i]);
      //  }
      //}
      //gv.Columns.Add(colSTOtotal);

      gvHead.EndInit();
      //Grid.EndInit();
    }

    private void SetObject()
    {
      //comParts.SelectedIndex = 0;
      //comboCus.SelectedIndex = 0;
      //comboIns.SelectedIndex = 0;
      //comboModel.SelectedIndex = 0;
      //comboSN.SelectedIndex = 0;
      //comParts.SelectedIndex = 0;
      //txtIns.Visible = false;
      //txtModel.Visible = false;
      //txtCcus.Visible = false;
      //txtSN.Visible = false;
      //txtCspare.Visible = false;
      //slookupIns.Visible = false;
      //slookupModel.Visible = false;
      //slookupCus.Visible = false;
      //slookupSN.Visible = false;
      //slookupSpare.Visible = false;
      //comboCus.Enabled = false;
      //comboSTK.Enabled = false;
      Grid.Visible = false;
      barBottom.Visible = false;
      InitialDataLookUp();

    }

    private double GetQuanfromQuotation(string cus,string stock,DateTime CaldateF,DateTime CaldateT)
    {
      DataTable dt = new DataTable("QUO");
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;
      double Quan = 0;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        sql = "SELECT sum(MILquan) as MILquan FROM WHERE MILcus=@MILcus and  STKhide=0 AND STKlock=0";
        sql = "SELECT SUM(MIL.MILquan) AS MILquan FROM MIH INNER JOIN"
            + "MIL ON MIH.MIHday = MIL.MILday AND MIH.MIHmonth = MIL.MILmonth AND MIH.MIHyear = MIL.MILyear AND"
            + "MIH.MIHtype = MIL.MILtype AND MIH.MIHvnos = MIL.MILvnos AND MIH.MIHcus = MIL.MILcus"
            + " WHERE MIL.MILstk =@MILstk AND MIH.MIHcus=@MIHcus";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        da.SelectCommand.Parameters.Add("@MILstk", SqlDbType.DateTime).Value = stock;
        da.SelectCommand.Parameters.Add("@MIHcus", SqlDbType.DateTime).Value = cus;
        da.SelectCommand.CommandTimeout = 1200;
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
          Quan = cls_Library.DBDouble(dt.Rows[0]["MILquan"]);
        }
      }
      catch
      {
        Quan=0;
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
      return Quan;
    }

    private void InitialDataLookUp()
    {
      DataTable DTdateOpt=new DataTable();
      DTdateOpt.Columns.Add("Id",typeof(int));
      DTdateOpt.Columns.Add("Text", typeof(String));
      DataRow r =null;

      r = DTdateOpt.NewRow();
      r[0] = 1;
      r[1] = "แสดงเฉพาะข้อมูลเดือนนี้";
      DTdateOpt.Rows.Add(r);

      r = DTdateOpt.NewRow();
      r[0] = 2;
      r[1] = "แสดงเฉพาะข้อมูลปีนี้";
      DTdateOpt.Rows.Add(r);

      r = DTdateOpt.NewRow();
      r[0] = 3;
      r[1] = "แสดงเฉพาะข้อมูลเดือนที่ผ่านมา";
      DTdateOpt.Rows.Add(r);

      r = DTdateOpt.NewRow();
      r[0] = 4;
      r[1] = "แสดงเฉพาะข้อมูลปีที่ผ่านมา";
      DTdateOpt.Rows.Add(r);

      r = DTdateOpt.NewRow();
      r[0] = 5;
      r[1] = "ระบุจากถึงวันที่ที่ต้องการ";
      DTdateOpt.Rows.Add(r);

      lkDateOpt.Properties.DataSource = DTdateOpt;
      lkDateOpt.Properties.DisplayMember = "Text";
      lkDateOpt.Properties.ValueMember = "Id";
      lkDateOpt.Properties.NullText = "กรุณาเลือกช่วงเวลา";
      txtDateStart.Enabled = false;
      txtDateEnd.Enabled = false;
      lkDateOpt.EditValue = 5;
    }

    
    private void BTreport_Click(object sender, EventArgs e)
    {
      string XSTKg = string.Empty;
      string XSTOg = string.Empty;
      string XCRE = string.Empty;

      if (System.Convert.ToInt32(lkDateOpt.EditValue) < 1)
      {
        XtraMessageBox.Show("คุณยังไม่ได้ระบุช่วงเวลา", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }


      if (slookupJob.Visible)
      {
        if (slookupJob.EditValue == null)
        {
          XtraMessageBox.Show("คุณยังไม่ได้ระบุรหัสงาน", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
      }

      if (slookupJobG.Visible)
      {
        if (slookupJobG.EditValue == null)
        {
          XtraMessageBox.Show("คุณยังไม่ได้ระบุกลุ่มงาน", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
      }

      CaldateF = cls_Global_class.GetDateCulture(txtDateStart.DateTime);
      CaldateT = cls_Global_class.GetDateCulture(txtDateEnd.DateTime);

      int day = 0;
      int month = 0;
      int year = 0;

      day = 1;
      month = CaldateF.Month;
      year = CaldateF.Year;
      CaldateF = new DateTime(year, month, day);

      month = CaldateT.Month + 1;
      year = CaldateT.Year;
      if (month == 13)
      {
        month = 1;
        year += 1;
      }
      day = DateTime.DaysInMonth(year, month);
      CaldateT = new DateTime(year, month, day);

      Nomonth = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Month, CaldateF, CaldateT, FirstDayOfWeek.Sunday));
      if (Nomonth < 0)
      {
        XtraMessageBox.Show("ระบุวันที่ไม่ถูกต้อง", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      if (!BGW.IsBusy)
      {
        //XSTKg = txtIns.Text;
        //XSTOg = txtModel.Text;
        //XCRE = txtCspare.Text;
        //STKg = XSTKg.Split(',');
        //STOg = XSTOg.Split(',');
        groupControl1.Enabled = false;
        //groupControl3.Enabled = false;
        groupControl4.Enabled = false;
        this.UseWaitCursor = true;
        SetGrid();
        Grid.Visible = true;
        barBottom.Visible = true;
        ReportRestore = false;
        BGW.RunWorkerAsync();
      }
      else
      {
        XtraMessageBox.Show("ระบบกำลังทำงาน", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

   
    public void SetDefaultdate()
    {
      DateTime dateFrom;

      dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      DefaultCustomDate_From = dateFrom;
      DefaultCustomDate_To = DateTime.Now;

      //Month name, Thai/Eng
      Array.Resize(ref TmonthName, 13);
      Array.Resize(ref EmonthName, 13);

      TmonthName[0] = "";
      TmonthName[1] = "มกราคม";
      TmonthName[2] = "กุมภาพันธ์";
      TmonthName[3] = "มีนาคม";
      TmonthName[4] = "เมษายน";
      TmonthName[5] = "พฤษภาคม";
      TmonthName[6] = "มิถุนายน";
      TmonthName[7] = "กรกฎาคม";
      TmonthName[8] = "สิงหาคม";
      TmonthName[9] = "กันยายน";
      TmonthName[10] = "ตุลาคม";
      TmonthName[11] = "พฤศจิกายน";
      TmonthName[12] = "ธันวาคม";
      EmonthName[0] = "";
      EmonthName[1] = "January";
      EmonthName[2] = "February";
      EmonthName[3] = "March";
      EmonthName[4] = "April";
      EmonthName[5] = "May";
      EmonthName[6] = "June";
      EmonthName[7] = "July";
      EmonthName[8] = "August";
      EmonthName[9] = "September";
      EmonthName[10] = "October";
      EmonthName[11] = "November";
      EmonthName[12] = "December";
    }

    
        
    private void ConExpandAll_Click(object sender, EventArgs e)
    {
      GridView View = (GridView)(Grid.FocusedView);
      ExpandAllRows(View);
    }

    public void ExpandAllRows(GridView View )
    {
    View.BeginUpdate();
    try
    {
      int dataRowCount  = View.DataRowCount;
      int rHandle;
      for (rHandle = 0 ;rHandle <= dataRowCount - 1;rHandle++)
      {
        View.SetMasterRowExpanded(rHandle, true);
      }
    } 
    finally
    {
      View.EndUpdate();
    }
    }

    private void ConCollapseAll_Click(object sender, EventArgs e)
    {
      gvHead.CollapseAllDetails();
    }

    private void exportExcle_Click(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("Excle", "Excle Files|*.xlsx", this.Text);
      if (Filename == string.Empty) return;
      Grid.ExportToXlsx(Filename);
      cls_Form.OpenFile(Filename);
    }

    private void exportPDF_Click(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("PDF", "PDF Files|*.pdf", this.Text);
      if (Filename == string.Empty) return;
      Grid.ExportToPdf(Filename);
      cls_Form.OpenFile(Filename);
    }

    private void exportText_Click(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("Text", "Text Files|*.txt", this.Text);
      if (Filename == string.Empty) return;
      Grid.ExportToText(Filename);
      cls_Form.OpenFile(Filename);
    }

    private void ExportData_Click(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("XML", "XML Files|*.xml", this.Text);
      if (Filename == string.Empty)
      {
        return;
      }
      else
      {
        DataS.WriteXml(Filename);
      }
    }

    private void exportExcleold_Click(object sender, EventArgs e)
    {
      //bool isOK = false;
      //isOK = cls_Global_class.GetSecurityOK(6, cls_Global_class.GB_USMs6, 6);

      //if ((!isOK) && (cls_Global_class.GB_UserCode != "ADMIN"))
      //{
      //  frm_NoAccess frno;
      //  frno = new frm_NoAccess();
      //  frno.ShowDialog();
      //  return;
      //}

      if (!ReportOK) return;

      //ExportToExcel(DataS.Tables["Head"], Grid);

      string Filename = cls_Form.ShowsaveDialogFile("Excle 2007-2010", "Excle Files|*.xlsx", this.Text);
      if (Filename == string.Empty) return;
      //Grid.ExportToXlsx(Filename);
      bool printDetails = gvHead.OptionsPrint.PrintDetails;
      bool expandAllDetails = gvHead.OptionsPrint.ExpandAllDetails;
      bool expandAllGroups = gvHead.OptionsPrint.ExpandAllGroups;


      gvHead.OptionsPrint.ExpandAllDetails = true;
      gvHead.OptionsPrint.ExpandAllGroups = true;
      gvHead.OptionsPrint.PrintDetails = true;
      //gvHead.OptionsPrint.UsePrintStyles = true;

      foreach (GridView gv in Grid.Views)
      {
        gv.OptionsPrint.AutoWidth = false;
        gv.OptionsView.RowAutoHeight = false;
        gv.OptionsView.ColumnAutoWidth = false;

        RepositoryItemMemoEdit rmemo = new RepositoryItemMemoEdit();
        foreach (GridColumn gc in gv.Columns)
        {
          gc.ColumnEdit = rmemo;
          gc.BestFit();
          gc.OptionsColumn.FixedWidth = true;
          rmemo.WordWrap = false;
        }

      }

      DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.DataAware;
      XlsxExportOptions opts = new XlsxExportOptions();
      //opts.ExportType = ExportType.WYSIWYG;
      opts.TextExportMode = TextExportMode.Text;
      opts.SheetName = this.Text;

       //.ExportToXlsx(

      gvHead.ExportToXlsx(Filename, opts);

      //Grid.ExportToXlsx(Filename, opts);

      gvHead.OptionsPrint.PrintDetails = printDetails;
      gvHead.OptionsPrint.ExpandAllDetails = expandAllDetails;
      gvHead.OptionsPrint.ExpandAllGroups = expandAllGroups;
      cls_Form.OpenFile(Filename);
    }

    private void exportExcle_Click_1(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("Excle 2007-2010", "Excle Files|*.xlsx", this.Text);
      if (Filename == string.Empty) return;
      Grid.ExportToXlsx(Filename);
      cls_Form.OpenFile(Filename);
    }

    private void exportText_Click_1(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("Text", "Text Files|*.txt", this.Text);
      if (Filename == string.Empty) return;
      Grid.ExportToText(Filename);
      cls_Form.OpenFile(Filename);
    }

    private void exportPDF_Click_1(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("PDF", "PDF Files|*.pdf", this.Text);
      if (Filename == string.Empty) return;
      Grid.ExportToPdf(Filename);
      cls_Form.OpenFile(Filename);
    }

    private void ImportData_Click(object sender, EventArgs e)
    {
      ReportRestore = true;
      ReportOK = false;
      if (DataS.Tables["Head"] != null) ReportOK = true;
      string Filename = cls_Form.ShowopenDialogFile("XML", "XML Files|*.xml");
      string gridset = string.Empty;
      string gridxml = string.Empty;
      if (Filename == string.Empty) return;
      DataS = new DataSet();
      DataS.ReadXml(Filename);
      if (!Grid.Visible) Grid.Visible = true;
      gridset = Filename.Replace(".xml", "Temp.txml");
      gridxml = gridset.Replace(".txml", ".xml");
      if (!File.Exists(gridset)) return;
      File.Copy(gridset, gridxml, true);
      if (!File.Exists(gridxml)) return;
      SetGrid();
      gvHead.RestoreLayoutFromXml(gridxml);
      File.Delete(gridxml);
      Grid.DataSource = DataS.Tables["Head"];
      Grid.RefreshDataSource();
      if (DataS.Tables["Head"] != null) ReportOK = true;
    }

    private void ExportData_Click_1(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("XML", "XML Files|*.xml", this.Text);
      string gridset = string.Empty;
      if (Filename == string.Empty) return;
      //Filename = Filename.Replace(".xml", DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + ".xml");
      DataS.WriteXml(Filename);
      gridset = Filename.Replace(".xml", "Temp.txml");
      if (File.Exists(gridset)) File.Delete(gridset);
      gvHead.SaveLayoutToXml(gridset);
    }

    public static void ExportToExcel(DataTable dt, GridControl gc)
    {
      if (dt.Rows.Count == 0)
      {
        XtraMessageBox.Show("Not Data", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      SaveFileDialog sf = new SaveFileDialog();
      sf.Filter = "Excel 2000-2003 Files | *.xls|Excel 2007-2013 Files | *.xlsx";
      if (sf.ShowDialog() == DialogResult.OK)
      {
        if (sf.FilterIndex == 1)
        {
          gc.ExportToXls(sf.FileName);
        }
        else if (sf.FilterIndex == 2)
        {
          gc.ExportToXlsx(sf.FileName);
        }
        cls_Form.OpenFile(sf.FileName);
      }
    }

    private void gvHead_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
      if (!ReportRestore) return;
      if (e.Column.VisibleIndex > 3)
      {
        e.DisplayText = cls_Library.CDouble(e.Value).ToString("#,###.##");
        e.Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        DevExpress.XtraGrid.StyleFormatCondition Gc = new DevExpress.XtraGrid.StyleFormatCondition();

      }
    }

    private void gvHead_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvList_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }
    
    private void comboCus_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtJob.Visible = false;
      slookupJob.Visible = false;
      slookupJobG.Visible = false;
      switch (comboJob.SelectedIndex)
      {
        case 1:
          //txtJob.Visible = true;
          //txtJob.Width = 150;
          //txtJob.Focus();
          //break;
          slookupJobG.Visible = true;
          slookupJobG.Width = 150;
          slookupJobG.Properties.NullText = "กรุณาระบุกลุ่มงาน";
          slookupJobG.Location = new Point(txtJob.Left, txtJob.Top);
          break;
        case 2:
          slookupJob.Visible = true;
          slookupJob.Width = 150;
          slookupJob.Properties.NullText = "กรุณาระบุรหัสงาน";
          slookupJob.Location = new Point(txtJob.Left, txtJob.Top);
          break;
      }
    }

        
    private void lkDateOpt_EditValueChanged(object sender, EventArgs e)
    {
      DateTime dateFrom;
      DateTime dateTo;
      int day = 0;
      int month = 0;
      int year = 0;
      int type = 0;
      //type 1  เรียกรายงานเฉพาะข้อมูลเดือนนี้
      //type 2  เรียกรายงานเฉพาะข้อมูลปีบัญชีนี้
      //type 3  เรียกรายงานเฉพาะข้อมูลเดือนที่ผ่านมา
      //type 4  Mode 4 = เรียกรายงานเฉพาะข้อมูลปีบัญชีที่ผ่านมา
      //type 5  Mode 5 = เรียกรายงานโดยระบุวันที่ จาก-ถึง เอง

      try
      {
        dateFrom = DateTime.Now;
        dateTo = DateTime.Now;
        type = System.Convert.ToInt32(lkDateOpt.EditValue);
        if (type == 5)
        {
          txtDateStart.Enabled = true;
          txtDateEnd.Enabled = true;
        }
        else
        {
          txtDateStart.Enabled = false;
          txtDateEnd.Enabled = false;
        }

        switch (System.Convert.ToInt32(lkDateOpt.EditValue))
        {
          case 1:
            day = 1;
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            dateFrom = new DateTime(year, month, day);
            dateTo = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            break;
          case 2:
            day = 1;
            month = 1;
            year = DateTime.Now.Year;
            dateFrom = new DateTime(year, month, day);
            day = 31;
            month = 12;
            year = DateTime.Now.Year;
            dateTo = new DateTime(year, month, day);
            break;
          case 3:
            day = 1;
            month = DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1;
            year = DateTime.Now.Year;
            dateFrom = new DateTime(year, month, day);
            dateTo = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            break;
          case 4:
            //year = DateTime.Now.Year-1;
            //if (DateTime.Now.Month == 1)
            //{
            //  month=12;
            //  year--;
            //}
            //else
            //{
            //  month = DateTime.Now.Month -1;
            //}

            //day = DateTime.DaysInMonth(year, month);
            //dateFrom = new DateTime(year, month, day);
            //dateTo = new DateTime(year, month, day);
            day = 1;
            month = 1;
            year = DateTime.Now.Year - 1;
            dateFrom = new DateTime(year, month, day);
            day = 31;
            month = 12;
            year = DateTime.Now.Year - 1;
            dateTo = new DateTime(year, month, day);
            break;
          case 5:
            dateFrom = DefaultCustomDate_From;
            dateTo = DefaultCustomDate_To;
            break;
          case 6:
            txtDateStart.Enabled = false;
            txtDateEnd.Enabled = false;
            break;
        }

        txtDateStart.DateTime = dateFrom;
        txtDateEnd.DateTime = dateTo;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void reportCondition_Click(object sender, EventArgs e)
    {

    }


    public struct DateTimeSpan
    {
      private readonly int years;
      private readonly int months;
      private readonly int days;
      private readonly int hours;
      private readonly int minutes;
      private readonly int seconds;
      private readonly int milliseconds;

      public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
      {
        this.years = years;
        this.months = months;
        this.days = days;
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
        this.milliseconds = milliseconds;
      }

      public int Years { get { return years; } }
      public int Months { get { return months; } }
      public int Days { get { return days; } }
      public int Hours { get { return hours; } }
      public int Minutes { get { return minutes; } }
      public int Seconds { get { return seconds; } }
      public int Milliseconds { get { return milliseconds; } }

      enum Phase { Years, Months, Days, Done }

      public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
      {
        if (date2 < date1)
        {
          var sub = date1;
          date1 = date2;
          date2 = sub;
        }

        DateTime current = date1;
        int years = 0;
        int months = 0;
        int days = 0;

        Phase phase = Phase.Years;
        DateTimeSpan span = new DateTimeSpan();

        while (phase != Phase.Done)
        {
          switch (phase)
          {
            case Phase.Years:
              if (current.AddYears(years + 1) > date2)
              {
                phase = Phase.Months;
                current = current.AddYears(years);
              }
              else
              {
                years++;
              }
              break;
            case Phase.Months:
              if (current.AddMonths(months + 1) > date2)
              {
                phase = Phase.Days;
                current = current.AddMonths(months);
              }
              else
              {
                months++;
              }
              break;
            case Phase.Days:
              if (current.AddDays(days + 1) > date2)
              {
                current = current.AddDays(days);
                var timespan = date2 - current;
                span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                phase = Phase.Done;
              }
              else
              {
                days++;
              }
              break;
          }
        }

        return span;
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      if (Mopt2.Checked == true && ReportOK==true)
      {
        ReportAllSite report1 = new ReportAllSite(CaldateF, CaldateT, DataS.Tables["Head"]);
        report1.PrintingSystem.ContinuousPageNumbering = true;

        report1.ShowPreview();
      }
    }

    private void Mopt1_CheckedChanged(object sender, EventArgs e)
    {

    }
    
           
  }
}