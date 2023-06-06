using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SmartPart.Class
{
    class cls_Global_DB
    {
        public static string GB_ServerName = string.Empty;
        public static string GB_ServerDBname = string.Empty;
        public static string GB_ServerUser = string.Empty;
        public static string GB_ServerPass = string.Empty;
        public static bool GB_ReportOK = false;
        public static int GB_SQLtimeOUT = 100;
        public static string CapTH = string.Empty;
        public static string CapEN = string.Empty;


        //For recorcd in detail of product
        public static int GB_DitemLocation_count = 0;
        public static int GB_DitemUnit_count = 0;
        public static int GB_DitemPart_count = 0;
        public static int GB_DitemPOgroup_count = 0;
        public static int GB_DitemVendor_count = 0;
        public static int GB_DitemSet_count = 0;
        public static int GB_DitemComponent_count = 0;
        public static int GB_DitemPicture_count = 0;
        public static int GB_DitemDocument_count = 0;

        //For record in detail of brand
        public static int GB_Dbrand_Salediscount = 0;
        public static int GB_Dbrand_Buydiscount = 0;

        //For record in detail of complementary
        public static int GB_Dcomp_Sub1 = 0;
        public static int GB_Dcomp_Sub2 = 0;
        public static int GB_Dcomp_Sub3 = 0;
        public static int GB_Dcomp_Item = 0;

        //For record in detail of Substitute
        public static int GB_Dsubs_Sub1 = 0;
        public static int GB_Dsubs_Sub2 = 0;
        public static int GB_Dsubs_Item = 0;

        //For record in detail of Item Special
        public static int GB_Ditem_Sub1 = 0;
        public static int[] GB_Ditem_Item = new int[0];
        public static int GB_ItemID = 0;

        //For record in detail of Item Versatile
        public static int GB_DitemVersatile_Sub = 0;
        public static int[] GB_DitemVersatile_Item = new int[0];
        public static int GB_ItemVersatileID = 0;

        //For record in detail of BSrecord
        public static int GB_BSH_ID = 0;
        public static int GB_DitemBS_count = 0;

        //ZONE
        public static DataSet DataInitial = null;
        public static int GB_GroupReplace = 0;
        public static int GB_GroupJoin = 0;
        public static int GB_GroupVersatile = 0;

        //PIAK
        public static DataSet DataInitialComp = null;
        public static DataSet DataInitialSubstitute = null;
        public static DataSet DataInitialItemSpecial = null;
        public static DataSet DataInitialVersatile = null;

        //PIAK
        public static int GB_Condition = 0;



    public static void ConnectDB_Master(ref SqlConnection OpenDB, string DBname)
    {
        CloseDB(ref OpenDB);
        try
        {
        OpenDB = new SqlConnection(GetSQLConStr(GB_ServerName, GB_ServerUser, GB_ServerPass, DBname));
        
        OpenDB.Open();
        }
        catch (SqlException Ex)
        {
        cls_Global_class.MessageboxErrorOK("ConnectDB" + Environment.NewLine + Ex.Message.ToString(), "แจ้งทราบ");
        }
    }

    public static bool ConnectDatabase(ref SqlConnection OpenDB)
    {
        bool OK = false;
        CloseDB(ref OpenDB);
        try
        {
        OpenDB = new SqlConnection(GetSQLConStr(GB_ServerName, GB_ServerUser, GB_ServerPass, GB_ServerDBname));
        OpenDB.Open();
        OK = true;
        }
        catch (SqlException Ex)
        {
        OK = false;
        cls_Global_class.MessageboxErrorOK("ConnectDB" + Environment.NewLine + Ex.Message.ToString(), "แจ้งทราบ");
        }
        return OK;
    }

    public static string Get_DataName(string DBname)
    {

        SqlConnection cn = new SqlConnection();
        SqlDataAdapter da = null;
        String Sql = String.Empty;
        DataTable dt = null;
        string Xname = String.Empty;

        ConnectDB_Master(ref cn, DBname);
        Xname = "";
        try
        {
        Sql = "Select OCMnameT from OCM";
        da = new SqlDataAdapter(Sql, cn);
        dt = new DataTable("Com");
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Xname = cls_Library.DBString(dt.Rows[0]["OCMnameT"]);
        }
        }
        catch
        {
        }
        finally
        {
        CloseDB(ref cn);
        }
        return Xname;
    }

    public static string GetSQLConStr(string ServerName, string ServerUser, string ServerPass, string DBName)
    {
        string Xs = "Data Source=" + ServerName + ";Initial Catalog=" + DBName + ";User Id=" + ServerUser + ";Password=" + ServerPass + ";";
        return Xs;
    }

    public static void CloseDB(ref SqlConnection ColseDB)
    {
        if (ColseDB.State == ConnectionState.Open)
        {
        ColseDB.Close();
        ColseDB.Dispose();
        }
    }

    public static void GB_MOD()
    {
        DataTable dt = new DataTable("Voucher");
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = null;
        int i = 0;
        string sql = string.Empty;
        string stk = string.Empty;
        bool OK = false;
        string Coln = string.Empty;
        //double Quan = 0;

        ConnectDatabase(ref cn);

        try
        {

        #region " Remark Code"

        ////Check V_Contact
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_Contact")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_Contact] nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update [Voucher] set [V_Contact]='' Where [V_Contact] is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}
        ////Check V_DateProve
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_DateProve")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_DateProve][datetime]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_AnualDate3
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_AnualDate3")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_AnualDate3][datetime]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Voucher WITH (UPDLOCK) Set V_AnualDate3=V_AnualDate2 Where V_Type=205 and V_AnualDate3 is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_AnualDate4
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_AnualDate4")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_AnualDate4][datetime]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Voucher WITH (UPDLOCK) Set V_AnualDate4=V_AnualDate2 Where V_Type=205 and V_AnualDate4 is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_NextVal
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_NextVal")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_NextVal][datetime]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Voucher WITH (UPDLOCK) Set V_NextVal=V_AnualDate2 Where V_NextVal is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_TimeVal
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_TimeVal")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_TimeVal][smallint]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Voucher WITH (UPDLOCK) Set V_TimeVal=0 Where V_TimeVal is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_Time
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_Time")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_Time][smallint]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Voucher WITH (UPDLOCK) Set V_Time=0 Where V_Time is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_Position
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_Position")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_Position]nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Voucher WITH (UPDLOCK) Set V_Position='' Where V_Position is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_SumQuantity
        //sql = "SELECT Top 1 * from H_Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_SumQuantity")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [H_Voucher] add [V_SumQuantity][real]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update H_Voucher WITH (UPDLOCK) Set V_SumQuantity=0 Where V_SumQuantity is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_DueDate
        //sql = "SELECT Top 1 * from H_Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_DueDate")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [H_Voucher] add [V_DueDate]nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update H_Voucher WITH (UPDLOCK) Set V_DueDate='' Where V_DueDate is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_Insurance
        //sql = "SELECT Top 1 * from H_Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_Insurance")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [H_Voucher] add [V_Insurance]nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update H_Voucher WITH (UPDLOCK) Set V_Insurance='' Where V_Insurance is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check En_Email
        //sql = "SELECT Top 1 * from Engineer";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "En_Email")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Engineer] add [En_Email]nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Engineer WITH (UPDLOCK) Set En_Email='' Where En_Email is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}


        ////Check V_WaitPO
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = false;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_WaitPO")
        //  {
        //    OK = true;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "Update Voucher WITH (UPDLOCK) Set V_WaitPO=@V_WaitPO Where V_WaitPO is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.Parameters.Add("@V_WaitPO", SqlDbType.Bit).Value = false;
        //  cmd.ExecuteNonQuery();
        //}

        ////Check V_WaitQuo
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = false;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_WaitQuo")
        //  {
        //    OK = true;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "Update Voucher WITH (UPDLOCK) Set V_WaitQuo=@V_WaitQuo Where V_WaitQuo is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.Parameters.Add("@V_WaitQuo", SqlDbType.Bit).Value = false;
        //  cmd.ExecuteNonQuery();
        //}

        

        ////Check V_Approve
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = false;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_Approve")
        //  {
        //    OK = true;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "Update Voucher WITH (UPDLOCK) Set V_Approve=@V_Approve Where V_Approve is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.Parameters.Add("@V_Approve", SqlDbType.Bit).Value = false;
        //  cmd.ExecuteNonQuery();
        //}

        ////Check GoodsReceived_connect
        //sql = "SELECT Top 1 * from GoodsReceived_Header";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "GoodsReceived_connect")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [GoodsReceived_Header] add [GoodsReceived_connect]nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update GoodsReceived_Header WITH (UPDLOCK) Set GoodsReceived_connect='Server 1' Where GoodsReceived_connect is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check GoodsIssued_connect
        //sql = "SELECT Top 1 * from GoodsIssued_Header";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "GoodsIssued_connect")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [GoodsIssued_Header] add [GoodsIssued_connect]nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update GoodsIssued_Header WITH (UPDLOCK) Set GoodsIssued_connect='Server 1' Where GoodsIssued_connect is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check GoodsReceived_desc
        //sql = "SELECT Top 1 * from GoodsReceived_Header";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "GoodsReceived_desc")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [GoodsReceived_Header] add [GoodsReceived_desc]nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update GoodsReceived_Header WITH (UPDLOCK) Set GoodsReceived_desc='' Where GoodsReceived_desc is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check GoodsReceived_vnos2
        //sql = "SELECT Top 1 * from GoodsReceived_Header";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "GoodsReceived_vnos2")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [GoodsReceived_Header] add [GoodsReceived_vnos2]nvarchar(15)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update GoodsReceived_Header WITH (UPDLOCK) Set GoodsReceived_vnos2='' Where GoodsReceived_vnos2 is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check GoodsReceived_Detail
        //sql = "SELECT Top 1 * from GoodsReceived_Detail";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "GoodsReceived_Detail_vnos2")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [GoodsReceived_Detail] add [GoodsReceived_Detail_vnos2]nvarchar(15)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update GoodsReceived_Detail WITH (UPDLOCK) Set GoodsReceived_Detail_vnos2='' Where GoodsReceived_Detail_vnos2 is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}


        ////Check Debtor
        //sql = "SELECT Top 1 * from Debtor";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "DEBserver")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Debtor] add [DEBserver]nvarchar(50)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Debtor WITH (UPDLOCK) Set DEBserver='1' Where DEBserver is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}


        ////Check GoodsIssued_Detail_balance
        //sql = "SELECT Top 1 * from GoodsIssued_Detail";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "GoodsIssued_Detail_balance")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [GoodsIssued_Detail] add [GoodsIssued_Detail_balance][float]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update GoodsIssued_Detail WITH (UPDLOCK) Set GoodsIssued_Detail_balance=0 Where GoodsIssued_Detail_balance is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        ////Check GoodsIssued_Detail_balance
        //sql = "SELECT Top 1 * from GoodsIssued_Detail";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "GoodsIssued_Detail_remain")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [GoodsIssued_Detail] add [GoodsIssued_Detail_remain][float]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update GoodsIssued_Detail WITH (UPDLOCK) Set GoodsIssued_Detail_remain=0 Where GoodsIssued_Detail_remain is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}


        ////Check BF
        //sql = "SELECT Top 1 * from StockBF";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "StockBF_stkname")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [StockBF] add [StockBF_stkname]nvarchar(1000)";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update StockBF WITH (UPDLOCK) Set StockBF_stkname='' Where StockBF_stkname is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        //StoreShift_vType
        //sql = "SELECT Top 1 * from StoreShift_Header";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "StoreShift_vType")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [StoreShift_Header] add [StoreShift_vType][tinyint]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update StoreShift_Header WITH (UPDLOCK) Set StoreShift_vType=0 Where StoreShift_vType is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        //Check USMs6
        //sql = "SELECT Top 1 * from USM";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "USMs6")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [USM] add [USMs6][Bigint]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update USM WITH (UPDLOCK) Set USMs6=0 Where USMs6 is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        //Update V_CreateUser of Voucher,H_Voucher
        //sql = "Update Voucher WITH (UPDLOCK) Set V_CreateUser=1 Where V_CreateUser=0 or V_CreateUser is null";
        //cmd = new SqlCommand(sql, cn);
        //cmd.ExecuteNonQuery();

        //sql = "Update H_Voucher WITH (UPDLOCK) Set V_CreateUser=1 Where V_CreateUser=0 or V_CreateUser is null";
        //cmd = new SqlCommand(sql, cn);
        //cmd.ExecuteNonQuery();

        //Check V_SVfree
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_SVfree")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_SVfree][smallint]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Voucher WITH (UPDLOCK) Set V_SVfree=0 Where V_SVfree is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}

        //Check V_SVamount
        //sql = "SELECT Top 1 * from Voucher";
        //da = new SqlDataAdapter(sql, cn);
        //da.Fill(dt);
        //OK = true;
        //foreach (DataColumn Col in dt.Columns)
        //{
        //  Coln = Col.ColumnName.ToString();
        //  if (Coln == "V_SVamount")
        //  {
        //    OK = false;
        //    break;
        //  }
        //}
        //if (OK)
        //{
        //  sql = "alter table [Voucher] add [V_SVamount][money]";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();

        //  sql = "Update Voucher WITH (UPDLOCK) Set V_SVamount=0 Where V_SVamount is null";
        //  cmd = new SqlCommand(sql, cn);
        //  cmd.ExecuteNonQuery();
        //}
        #endregion

        }
        catch (Exception e)
        {

        }
        finally
        {
        CloseDB(ref cn);
        }

    }
    }


}
