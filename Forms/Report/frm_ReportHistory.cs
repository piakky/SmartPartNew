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


namespace Medical
{
 
  public partial class frm_ReportHistory : DevExpress.XtraEditors.XtraForm
  {
    #region ตัวแปร
    BackgroundWorker BGW = new BackgroundWorker();
    BackgroundWorker BGWGetCode = new BackgroundWorker();
    DateTime DefaultCustomDate_From ;
    DateTime DefaultCustomDate_To;
    DataTable dt_type = null;
    RepositoryItemCheckEdit c_V = new RepositoryItemCheckEdit();
    //Con_CompanySelect Comselect=new Con_CompanySelect();
    string[] STKg;
    string[] STOg;
    string[] CREg;
    string Gval = "";
    DataSet DataS, DataC;
    bool ReportRestore = false;
    bool ReportOK = false;
    bool Sameall;
    #endregion

    public frm_ReportHistory()
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
      dt = cls_Data.GetCodeCUS(0, 0, "Cus_id,Cus_Code,Cus_NameT,Cus_NameE");
      DataC.Tables.Add(dt);

      dt = new DataTable();
      dt = cls_Data.GetCodeIns(0, 0, "Ins_id,Ins_Code");
      DataC.Tables.Add(dt);

      dt = new DataTable();
      dt = cls_Data.GetCodeModel(0, 0, "Ins_id,Ins_Model");
      DataC.Tables.Add(dt);

      dt = new DataTable();
      dt = cls_Data.GetCodeSN(0, 0, "Ins_id,Ins_SN");
      DataC.Tables.Add(dt);

      dt = new DataTable("Type");
      dt.Columns.Add("R_Type", typeof(int));
      dt.Columns.Add("Value", typeof(bool));
      dt.Columns.Add("R_Name", typeof(string));
      for (int i = 0; i < 5; i++)
      {
        dt.Rows.Add();
        switch (i)
        {
          case 0:
            dt.Rows[i]["R_Type"] = 201;
            dt.Rows[i]["Value"] = true;
            dt.Rows[i]["R_Name"] = "Installation";
            break;
          case 1:
            dt.Rows[i]["R_Type"] = 202;
            dt.Rows[i]["Value"] = true;
            dt.Rows[i]["R_Name"] = "Validation";
            break;
          case 2:
            dt.Rows[i]["R_Type"] = 203;
            dt.Rows[i]["Value"] = true;
            dt.Rows[i]["R_Name"] = "PQ";
            break;
          case 3:
            dt.Rows[i]["R_Type"] = 204;
            dt.Rows[i]["Value"] = true;
            dt.Rows[i]["R_Name"] = "Services";
            break;
          case 4:
            dt.Rows[i]["R_Type"] = 205;
            dt.Rows[i]["Value"] = true;
            dt.Rows[i]["R_Name"] = "ASC";
            break;
        }
      }
      DataC.Tables.Add(dt);
      //dt = new DataTable();
      //dt = cls_Data.GetCodeCRE();
      //DataC.Tables.Add(dt);
    }

    private void BGWGetCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      slookupCus.Properties.DataSource = DataC.Tables["CUS"];
      slookupIns.Properties.DataSource = DataC.Tables["Ins"];
      slookupModel.Properties.DataSource = DataC.Tables["Model"];
      slookupSN.Properties.DataSource = DataC.Tables["SN"];
      gridType.DataSource = DataC.Tables["Type"];
      SetGridType();
      //slookupCRE.Properties.DataSource = DataC.Tables["CRE"];
      SetslookUP();
    }

    private void BGW_DoWork(object sender, DoWorkEventArgs e)
    {
      InitialData();
    }

    private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      barBottom.Visible = false;
      Grid.DataSource = DataS.Tables["Head"];
      gvList.RefreshData();
      Grid.RefreshDataSource();
      groupControl1.Enabled = true;
      groupControl2.Enabled = true;
      groupControl4.Enabled = true;
      Grid.Visible=true;
      if (DataS.Tables["Head"].Rows.Count > 0) ReportOK = true;
      this.UseWaitCursor = false;
    }

    private void InitialData()
    {
      //cls_CST_CP.CSTgetBal("FG001", "MAIN", DateTime.Now);

      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;
      DateTime CaldateF;
      DateTime CaldateT;
      DataTable dt = null;
      DataTable dtVoucher = null;
      DataTable dtHead = null;
      DataTable dtList = null;
      int i;

      int R_Ins = 0,R_Cus_id=0;
      string R_Model="", R_SN="";
      DateTime dateF = DateTime.Now.Date;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        CaldateF = cls_Global_class.GetDateCulture(txtDateStart.DateTime);
        CaldateT = cls_Global_class.GetDateCulture(txtDateEnd.DateTime);
        DataS = new DataSet();
        dtHead = new DataTable("Head");


        dtHead.Columns.Clear();
        dtHead.Columns.Add("R_Ins", typeof(int));
        dtHead.Columns.Add("R_InsName", typeof(string));
        dtHead.Columns.Add("R_Model", typeof(string));
        dtHead.Columns.Add("R_SN", typeof(string));
        dtHead.Columns.Add("R_Dep", typeof(string));
        dtHead.Columns.Add("R_Cus", typeof(string));
        dtHead.Columns.Add("R_Rec", typeof(string));
        dtHead.Columns.Add("R_Note", typeof(string));

        dtList = new DataTable("List");
        //dtList = dtHead.Copy();
        dtList.Columns.Clear();
        dtList.Columns.Add("R_Ins", typeof(int));
        dtList.Columns.Add("R_InsName", typeof(string));
        dtList.Columns.Add("R_Pur", typeof(string));
        dtList.Columns.Add("R_Date", typeof(DateTime));
        dtList.Columns.Add("R_Status", typeof(string));
        dtList.Columns.Add("R_Charge", typeof(string));
        dtList.Columns.Add("R_Warrantee", typeof(string));
        dtList.Columns.Add("R_Model", typeof(string));
        dtList.Columns.Add("R_SN", typeof(string));
        dtList.Columns.Add("R_Dep", typeof(string));
        dtList.Columns.Add("R_Cus", typeof(string));
        dtList.Columns.Add("R_Rec", typeof(string));
        dtList.Columns.Add("R_Note", typeof(string));
        

        dt = new DataTable("List");

        dt = dtList.Copy();
        //dt.Columns.Add("CSTstk", typeof(string));
        //dt.Columns.Add("CSTunit", typeof(string));
        //dt.Columns.Add("CSTgroup", typeof(string));
        //if (txtSTO.Visible)
        //{
        //  NO = STOg.Length;
        //  CSTquan = new double[NO];
        //  for (i = 0; i < NO; i++)
        //  {
        //    dt.Columns.Add("CSTsto" + STOg[i], typeof(double));
        //  }
        //}
        //dt.Columns.Add("CSTstototal", typeof(double));

        //sql = "SELECT DISTINCT CST.CSTstk, CST.CSTstk AS CSTuname, STK_1.STKgroup FROM CST INNER JOIN STK AS STK_1 ON STK_1.STKcode = CST.CSTstk";
        //sql = "Select * From CPP Where CPPcut=-1 and CPPclearALL=0 and CPSdelvDate=@CPSdelvDate and (CPPdateID Between @dateForm AND @dateTo) ";
        sql = "Select * From Voucher ";
        sql += "Where (V_Delete =0) ";
        if (cls_Library.DBInt(lkDateOpt.EditValue) < 6)
        {
          sql += " and (V_date Between @dateForm AND @dateTo)  ";
        }
        //if (!Sameall && Gval.Length > 0)
        //{
          sql += " and V_Type in (" + Gval + ")";
        //}
        if (slookupCus.Visible)
        {
          sql += " and V_Cus_id=@V_Cus_id";
          R_Cus_id =Convert.ToInt32(slookupCus.EditValue);
        }
        if (slookupIns.Visible)
        {
          sql += " and V_Ins_id=@V_Ins_id";
          R_Ins = Convert.ToInt32(slookupIns.EditValue);
        }
        if (slookupModel.Visible)
        {
          sql += " and V_Model=@V_Model";
          R_Model = Convert.ToString(slookupModel.EditValue);
        }
        if (slookupSN.Visible)
        {
          sql += " and V_SN=@V_SN";
          R_SN = Convert.ToString(slookupSN.EditValue);
        }
        sql += " Order by V_date,V_nos";
        da = new SqlDataAdapter(sql, cn);
        da.SelectCommand.Parameters.Clear();
        //da.SelectCommand.Parameters.Add("@BFmonth", SqlDbType.Int).Value = BFmonth;
        //da.SelectCommand.Parameters.Add("@BFyear", SqlDbType.Int).Value = BFyear;
        if (cls_Library.DBInt(lkDateOpt.EditValue) < 6)
        {
          da.SelectCommand.Parameters.Add("@dateForm", SqlDbType.DateTime).Value = System.Convert.ToDateTime(CaldateF);
          da.SelectCommand.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = System.Convert.ToDateTime(CaldateT);
        }
        if (slookupCus.Visible)
        {
          da.SelectCommand.Parameters.Add("@V_Cus_id", SqlDbType.Int).Value = R_Cus_id;
        }
        if (slookupIns.Visible)
        {
          da.SelectCommand.Parameters.Add("@V_Ins_id", SqlDbType.Int).Value = R_Ins;
        }
        if (slookupModel.Visible)
        {
          da.SelectCommand.Parameters.Add("@V_Model", SqlDbType.NVarChar, 255).Value = R_Model;
        }
        if (slookupSN.Visible)
        {
          da.SelectCommand.Parameters.Add("@V_SN", SqlDbType.NVarChar, 255).Value = R_SN;
        }
        da.SelectCommand.CommandTimeout = 1200;
        dtVoucher = new DataTable("Voucher");
        da.Fill(dtVoucher);
        for (i = 0; i < dtVoucher.Rows.Count; i++)
        {
          R_Ins = cls_Library.DBInt(dtVoucher.Rows[i]["V_Ins_id"]);

          //CPPunit = cls_Library.DBString(dtVoucher.Rows[i]["STKuname"]);
          //CPPquan = cls_Library.DBDouble(dtVoucher.Rows[i]["CPPstkREQ"]);
          //CPPreceive = cls_Library.DBDouble(dtVoucher.Rows[i]["CPPstkCUT1"]);
          //CPPsumREQ = cls_Library.DBDecimal(dtVoucher.Rows[i]["CPPsumREQ"]);

          //CPPorder=CPPquan/32500;
          //CPPreceive = CPPreceive / 32500;
          //CPPbetween = GetQuanfromQuotation(cls_Library.DBString(dtVoucher.Rows[i]["CPPcusID"]),CPPstk, System.Convert.ToDateTime(CaldateF),System.Convert.ToDateTime(CaldateT));


          dt.Rows.Add();
          dt.Rows[i]["R_Ins"] = R_Ins;
          dt.Rows[i]["R_InsName"] = cls_Data.GetTBname(R_Ins,"Ins","Ins_Code");
          int type=cls_Library.DBInt(dtVoucher.Rows[i]["V_Type"]);
          switch (type)
          {
            case 201:
              dt.Rows[i]["R_Pur"] = "Installation";
              break;
            case 202:
              dt.Rows[i]["R_Pur"] = "Validation";
              break;
            case 203:
              dt.Rows[i]["R_Pur"] = "PQ";
              break;
            case 204:
              dt.Rows[i]["R_Pur"] = "Services";
              break;
            case 205:
              dt.Rows[i]["R_Pur"] = "ASC";
              break;
          }
          dt.Rows[i]["R_Model"] = cls_Library.DBString(dtVoucher.Rows[i]["V_Model"]);
          dt.Rows[i]["R_SN"] = cls_Library.DBString(dtVoucher.Rows[i]["V_SN"]);
          dt.Rows[i]["R_Dep"] = cls_Data.GetTBname(cls_Library.DBInt(dtVoucher.Rows[i]["V_Dep_id"]), "DEP", "Dep_NameE");
          dt.Rows[i]["R_Cus"] = cls_Data.GetTBname(cls_Library.DBInt(dtVoucher.Rows[i]["V_Cus_id"]), "CUS", "Cus_NameE");
          dt.Rows[i]["R_Rec"] = cls_Data.GetTBname(cls_Library.DBInt(dtVoucher.Rows[i]["V_Rec_id"]), "Record", "Cus_NameE");
          dt.Rows[i]["R_Note"] = cls_Library.DBString(dtVoucher.Rows[i]["V_Note"]);
          dt.Rows[i]["R_Date"] = cls_Library.DBDateTime(dtVoucher.Rows[i]["V_Date"]);
          int Istatus = cls_Library.DBInt(dtVoucher.Rows[i]["V_Complete"]);
          dt.Rows[i]["R_Status"] = "Complete";
          if (Istatus == 0) dt.Rows[i]["R_Status"] = "Incomplete";
          int ICharge = cls_Library.DBInt(dtVoucher.Rows[i]["V_Charge"]);
          dt.Rows[i]["R_Charge"] = "Charge";
          if (ICharge == 0) dt.Rows[i]["R_Charge"] = "No charge";
          int Iwarranty = cls_Library.DBInt(dtVoucher.Rows[i]["V_Warranty"]);
          dt.Rows[i]["R_Warrantee"] = "Under warrantee";
          if (Iwarranty == 0) dt.Rows[i]["R_Warrantee"] = "Service Contact";

          //if (txtSTO.Visible)
          //{
          //  CSTquantotal = 0;
          //  for (j = 0; j < NO; j++)
          //  {
          //    quan = cls_CST_CP.CSTgetBal(CPPstk, STOg[j], dateF);
          //    dt.Rows[i]["CSTsto" + STOg[j]] = quan;
          //    CSTquantotal += quan;
          //  }
          //  dt.Rows[i]["CSTstototal"] = CSTquantotal;
          //}
          //else
          //{
          //  dt.Rows[i]["CSTstototal"] = cls_CST_CP.CSTgetBal(CPPstk, "", dateF);
          //}
        }

        //dtList = dt.Clone();

        dtList = new DataTable("List");
        //dtList = dtHead.Copy();
        //dtList.Columns.Clear();
        //dtList.Columns.Add("R_Ins", typeof(int));
        ////dtList.Columns.Add("R_InsName", typeof(string));
        //dtList.Columns.Add("วัตถุประสงค์", typeof(string));
        //dtList.Columns.Add("วันที่", typeof(DateTime));
        //dtList.Columns.Add("สถานะ", typeof(string));
        //dtList.Columns.Add("การ Charge", typeof(string));
        //dtList.Columns.Add("การ Warrantee", typeof(string));
        //dtList.Columns.Add("R_Model", typeof(string));
        //dtList.Columns.Add("R_SN", typeof(string));
        //dtList.Columns.Add("R_Dep", typeof(string));
        //dtList.Columns.Add("R_Cus", typeof(string));
        //dtList.Columns.Add("คนให้บริการ", typeof(string));
        //dtList.Columns.Add("Note", typeof(string));

        dtList.Columns.Clear();
        dtList.Columns.Add("R_Ins", typeof(int));
        dtList.Columns.Add("R_Pur", typeof(string));
        dtList.Columns.Add("R_Date", typeof(DateTime));
        dtList.Columns.Add("R_Status", typeof(string));
        dtList.Columns.Add("R_Charge", typeof(string));
        dtList.Columns.Add("R_Warrantee", typeof(string));

        foreach (DataRow r in dt.Rows)
        {
          DataRow Xrow = dtList.NewRow();
          Xrow[0] = r["R_Ins"];
          Xrow[1] = r["R_Pur"];
          Xrow[2] = r["R_Date"];
          Xrow[3] = r["R_Status"];
          Xrow[4] = r["R_Charge"];
          Xrow[5] = r["R_Warrantee"];
          //Xrow[6] = r["R_Rec"];
          //Xrow[7] = r["R_Note"];
          dtList.Rows.Add(Xrow);
          //object Debit = 0;
          //object Credit = 0;
          DataRow[] dr = dtHead.Select("R_Ins =" + System.Convert.ToInt32(r[0]) + "");

          if (dr.Length <= 0)
          {
            //Debit = tbMzbf.Compute("sum(ZBFsumDr)", "ACCid =" + Convert.ToInt32(r["ACCid"]) + " AND OCMDid = " + Convert.ToInt32(r["OCMDid"]));
            //Credit = tbMzbf.Compute("sum(ZBFsumCr)", "ACCid =" + Convert.ToInt32(r["ACCid"]) + " AND OCMDid = " + Convert.ToInt32(r["OCMDid"]));
            DataRow _row = dtHead.NewRow();
            _row["R_Ins"] = r["R_Ins"];
            _row["R_InsName"] = r["R_InsName"];
            _row["R_Model"] = r["R_Model"];
            _row["R_SN"] = r["R_SN"];
            _row["R_Dep"] = r["R_Dep"];
            _row["R_Cus"] = r["R_Cus"];
            _row["R_Rec"] = r["R_Rec"];
            _row["R_Note"] = r["R_Note"];
            //_row["ZBFsumCr"] = Credit;
            dtHead.Rows.Add(_row);
          }
        }
        if (!(DataS.Tables["Head"] == null))
        {
          if (DataS.Relations.Count > 0) DataS.Relations.Clear();
          DataS.Tables.Clear();
          //DataS.Tables.Remove("Head");
        }
        //if (!(DataS.Tables["List"] == null))
        //{
        //  if (DataS.Relations.Count > 0) DataS.Relations.Clear();
        //  DataS.Tables.Remove("List");
        //}


        DataS.Tables.Add(dtList);
        DataS.Tables.Add(dtHead);

        if (!(DataS.Tables["Head"] == null) && (DataS.Tables["Head"].Rows.Count > 0) && (DataS.Tables["List"].Rows.Count > 0))
        {
          //_DS.Tables("List").Columns.Add("Balance", GetType(Decimal))
          if (DataS.Relations.Count <= 0)
          {
            DataS.Relations.Clear();
            DataS.Relations.Add("Relation", DataS.Tables["Head"].Columns["R_Ins"], DataS.Tables["List"].Columns["R_Ins"]);
          }
          //List = _DS.Tables("List").Copy()
        }


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
      catch
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
      slookupIns.Properties.PopulateViewColumns();
      slookupIns.Properties.ValueMember = "Ins_id";
      slookupIns.Properties.DisplayMember = "Ins_Code";
      slookupIns.Properties.View.Columns["Ins_id"].Visible=false;
      slookupIns.Properties.View.Columns["Ins_Code"].Caption = "Instrument code";

      slookupModel.Properties.PopulateViewColumns();
      slookupModel.Properties.ValueMember = "Ins_Model";
      slookupModel.Properties.DisplayMember = "Ins_Model";
      slookupModel.Properties.View.Columns["Ins_id"].Visible = false;
      slookupModel.Properties.View.Columns["Ins_Model"].Caption = "Instrument Model";

      slookupSN.Properties.PopulateViewColumns();
      slookupSN.Properties.ValueMember = "Ins_SN";
      slookupSN.Properties.DisplayMember = "Ins_SN";
      slookupSN.Properties.View.Columns["Ins_id"].Visible = false;
      slookupSN.Properties.View.Columns["Ins_SN"].Caption = "Instrument S/N";

      
      slookupCus.Properties.PopulateViewColumns();
      slookupCus.Properties.ValueMember = "Cus_id";
      slookupCus.Properties.DisplayMember = "Cus_Code";
      slookupCus.Properties.View.Columns["Cus_id"].Visible=false;
      slookupCus.Properties.View.Columns["Cus_NameT"].Caption = "Customer name (Thai)";
      slookupCus.Properties.View.Columns["Cus_NameE"].Caption = "Customer name (Eng)";
    }

    private void SetGrid()
    {
      int i, NO = 0;

      //--- กำหนดค่าของ Heading 
      gvHead.Columns.Clear();
      gvList.Columns.Clear();

      GridColumn h_colIns = cls_Form.AddGridColumn("R_Ins", "รหัสเครื่อง", "R_Ins", true, 0, 100);
      GridColumn h_colInsName = cls_Form.AddGridColumn("R_InsName", "เครื่อง", "R_InsName", true, 0, 300);
      GridColumn h_colModel = cls_Form.AddGridColumn("R_Model", "รุ่น", "R_Model", true,1 , 100);
      GridColumn h_colSN = cls_Form.AddGridColumn("R_SN", "หมายเลข", "R_SN", true, 2, 100);
      GridColumn h_colDep = cls_Form.AddGridColumn("R_Dep", "แผนก", "R_Dep", true, 3, 200);
      GridColumn h_colCus = cls_Form.AddGridColumn("R_Cus", "บริษัท", "R_Cus", true, 4, 300);
      GridColumn h_colREC = cls_Form.AddGridColumn("R_Rec", "คนให้บริการ", "R_Rec", true, 5, 100);
      GridColumn h_colNote = cls_Form.AddGridColumn("R_Note", "Note", "R_Note", true, 6, 300);


      h_colInsName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      h_colInsName.AppearanceHeader.Options.UseTextOptions = true;
      h_colInsName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      h_colInsName.AppearanceCell.Options.UseTextOptions = true;
      h_colInsName.DisplayFormat.FormatString = "#,##0";
      h_colInsName.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      h_colInsName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
      h_colInsName.SummaryItem.DisplayFormat = "{0:#,##0}" + "   รายการ";
      //GridColumn h_coltoday = cls_Form_CP.AddGridColumn("CPPtoday", "การปล่อยรถ วันนี้", "CPPtoday", true, 9, 100);
      //GridColumn h_colplan = cls_Form_CP.AddGridColumn("CPPplan", "Plan", "CPPplan", true, 10, 100);

      GridColumn colIns = cls_Form.AddGridColumn("R_Ins", "Ins", "R_Ins", true, 0, 100);
      //GridColumn colInsName = cls_Form.AddGridColumn("R_InsName", "ใบสั่งซื้อ", "R_InsName", true, 0, 100);
      GridColumn colPur = cls_Form.AddGridColumn("R_Pur", "วัตถประสงค์", "R_Pur", true, 0, 100);
      GridColumn colDate = cls_Form.AddGridColumn("R_Date", "วันที่", "R_Date", true, 1, 100);
      GridColumn colStatus = cls_Form.AddGridColumn("R_Status", "สถานะ", "R_Status", true, 2, 100);
      GridColumn colCharge = cls_Form.AddGridColumn("R_Charge", "การ Charge", "R_Charge", true, 3, 100);
      GridColumn colWarrantee = cls_Form.AddGridColumn("R_Warrantee", "การ Warrantee", "R_Warrantee", true, 4, 100);
      //GridColumn colRec = cls_Form.AddGridColumn("R_Rec", "คนให้บริการ", "R_Rec", true, 5, 100);
      //GridColumn colNote = cls_Form.AddGridColumn("R_Note", "ค้างรับ", "R_Note", true, 6, 100);
      //GridColumn coltoday = cls_Form_CP.AddGridColumn("CPPtoday", "การปล่อยรถ วันนี้", "CPPtoday", true, 9, 100);
      //GridColumn colplan = cls_Form_CP.AddGridColumn("CPPplan", "Plan", "CPPplan", true, 10, 100);
      GridColumn[] colSTO = new GridColumn[NO];

      //if (txtSTO.Visible)
      //{
      //  NO = STOg.Length;
      //  Array.Resize(ref colSTO, NO);
      //  for (i = 0; i < NO; i++)
      //  {
      //    colSTO[i] = cls_Form_CP.AddGridColumn("CSTsto" + STOg[i], STOg[i], "CSTsto" + STOg[i], true, 3 + i, 100);
      //  }
      //}
      //GridColumn colSTOtotal = cls_Form_CP.AddGridColumn("CSTstototal", "รวมสโตร์", "CSTstototal", true, 3 + NO, 100);

      //Grid.BeginInit();
      gvHead.BeginInit();
      gvList.BeginInit();
      h_colIns.Visible = false;
      colIns.Visible = false;

      gvHead.OptionsView.ShowGroupPanel = false;
      gvHead.Columns.Clear();
      gvHead.Columns.AddRange(new GridColumn[] { h_colIns, h_colInsName, h_colModel, h_colSN, h_colDep, h_colCus, h_colREC, h_colNote});
      gvList.Columns.AddRange(new GridColumn[] { colIns, colPur, colDate, colStatus, colCharge, colWarrantee});

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

      gvList.OptionsView.ShowFooter = true;
      gvList.OptionsView.ColumnAutoWidth=true;
      gvList.OptionsView.ShowGroupPanel = false;
      gvList.OptionsBehavior.Editable = false;
      gvList.OptionsSelection.EnableAppearanceFocusedCell = false;
      gvList.OptionsView.EnableAppearanceEvenRow = true;
      gvList.OptionsView.EnableAppearanceOddRow = false;
      gvList.IndicatorWidth = 50;

      //gv.OptionsView.ColumnAutoWidth = false;
      gvHead.OptionsView.RowAutoHeight = true;
      gvHead.OptionsView.ShowAutoFilterRow = true;
      foreach (GridColumn col in gvList.Columns)
      {
        //col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        col.OptionsFilter.AllowFilter = false;
      }
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
      gvList.EndInit();
      //Grid.EndInit();
    }

    private void SetGridType()
    {
      int i, NO = 0;

      //--- กำหนดค่าของ Heading 
      gvType.Columns.Clear();

      GridColumn h_colID = cls_Form.AddGridColumn("R_Type", "id", "R_Type", true, 0, 50);
      GridColumn h_colV = cls_Form.AddGridColumn("R_Value", "", "Value", true, 1, 50);
      GridColumn h_colVname = cls_Form.AddGridColumn("R_Name", "ประเภท", "R_Name", true, 2, 170);

      gvType.BeginInit();

      gvType.OptionsView.ShowGroupPanel = false;
      gvType.Columns.Clear();
      h_colID.Visible = false;
      h_colV.ColumnEdit = c_V;

      h_colV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      h_colV.AppearanceHeader.Options.UseTextOptions = true;
      h_colV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      h_colV.AppearanceCell.Options.UseTextOptions = true;
      h_colV.OptionsColumn.AllowEdit = true;

      h_colVname.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      h_colVname.AppearanceHeader.Options.UseTextOptions = true;
      h_colVname.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      h_colVname.AppearanceCell.Options.UseTextOptions = true;
      h_colVname.OptionsColumn.AllowEdit = false;

      gvType.Columns.AddRange(new GridColumn[] { h_colID, h_colV, h_colVname });
      gvType.OptionsView.ShowFooter = true;
      gvType.OptionsSelection.EnableAppearanceFocusedCell = false;
      gvType.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
      gvType.OptionsSelection.MultiSelect = true;
      gvType.OptionsView.ColumnAutoWidth = false;
      //gvType.OptionsBehavior.Editable = false;
      gvType.OptionsView.EnableAppearanceEvenRow = true;
      gvType.OptionsView.EnableAppearanceOddRow = false;
      gvType.IndicatorWidth = 10;

      gvType.OptionsView.RowAutoHeight = true;
      gvType.OptionsView.ShowAutoFilterRow = false;

      gvType.OptionsView.RowAutoHeight = true;
      foreach (GridColumn col in gvType.Columns)
      {
        //col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        col.OptionsFilter.AllowFilter = false;
      }
      gvType.EndInit();
    }

    private void SetObject()
    {
      comboCus.SelectedIndex = 0;
      comboIns.SelectedIndex = 0;
      comboModel.SelectedIndex = 0;
      comboSN.SelectedIndex = 0;
      txtIns.Visible = false;
      txtModel.Visible = false;
      txtCcus.Visible = false;
      txtSN.Visible = false;
      slookupIns.Visible = false;
      slookupModel.Visible = false;
      slookupCus.Visible = false;
      slookupSN.Visible = false;
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

      r = DTdateOpt.NewRow();
      r[0] = 6;
      r[1] = "ไม่ระบุ";
      DTdateOpt.Rows.Add(r);

      lkDateOpt.Properties.DataSource = DTdateOpt;
      lkDateOpt.Properties.DisplayMember = "Text";
      lkDateOpt.Properties.ValueMember = "Id";
      lkDateOpt.Properties.NullText = "กรุณาเลือกช่วงเวลา";
      txtDateStart.Enabled = false;
      txtDateEnd.Enabled = false;
      lkDateOpt.EditValue = 5;

      //groupControl3.Controls.Add(Comselect);
    }

    private void comboIns_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtIns.Visible = false;
      slookupIns.Visible = false;
      switch (comboIns.SelectedIndex)
      {
        //case 1:
        //  txtIns.Visible = true;
        //  txtIns.Width = 150;
        //  txtIns.Focus();
        //  break;
        case 1:
          slookupIns.Visible = true;
          slookupIns.Width = 150;
          slookupIns.Properties.NullText = "กรุณาระบุเครื่อง";
          slookupIns.Location = new Point(txtIns.Left, txtIns.Top);
          break;
      }
    }

    private void comboModel_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtModel.Visible = false;
      slookupModel.Visible = false;
      switch (comboModel.SelectedIndex)
      {
        //case 1:
        //  txtModel.Visible = true;
        //  txtModel.Width = 150;
        //  txtModel.Focus();
        //  break;
        case 1:
          slookupModel.Visible = true;
          slookupModel.Width = 150;
          slookupModel.Properties.NullText = "กรุณาระบุรุ่น";
          slookupModel.Location = new Point(txtModel.Left, txtModel.Top);
          break;
      }
    }

    private void BTreport_Click(object sender, EventArgs e)
    {
      string XSTKg = string.Empty;
      string XSTOg = string.Empty;
      string XCRE = string.Empty;
      bool Xchk = false;
      bool Nchk = false;

      //cls_DB_CP.GB_DBnameMac5 =System.Convert.ToString(Comselect.Com_Select.EditValue);
      //if (cls_DB_CP.GB_DBnameMac5 == null || cls_DB_CP.GB_DBnameMac5 == string.Empty)
      //{
      //  XtraMessageBox.Show("คุณยังไม่ได้เลือกบริษัททำการ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //  return;
      //}
      if (System.Convert.ToInt32(lkDateOpt.EditValue) < 1)
      {
        XtraMessageBox.Show("คุณยังไม่ได้ระบุช่วงเวลา", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      //if (txtModel.Visible)
      //{
      //  if (txtModel.EditValue == null || txtModel.EditValue.ToString().Length == 0)
      //  {
      //    XtraMessageBox.Show("คุณยังไม่ได้ระบุกลุ่มรหัสสโตร์", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //    return;
      //  }
      //}
      if (slookupCus.Visible)
      {
        if (slookupCus.EditValue == null)
        {
          XtraMessageBox.Show("คุณยังไม่ได้ระบุรหัสลูกค้า", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
      }

      if (slookupIns.Visible)
      {
        if (slookupIns.EditValue == null)
        {
          XtraMessageBox.Show("คุณยังไม่ได้ระบุเครื่อง", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
      }

      if (slookupModel.Visible)
      {
        if (slookupModel.EditValue == null)
        {
          XtraMessageBox.Show("คุณยังไม่ได้ระบุรุ่น", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
      }

      if (slookupSN.Visible)
      {
        if (slookupSN.EditValue == null)
        {
          XtraMessageBox.Show("คุณยังไม่ได้ระบุหมายเลข", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
      }

      Sameall = true;
      Nchk = true;
      string Xval = "";
      for (int i = 0; i < 5; i++)
      {
        Xchk = Convert.ToBoolean(DataC.Tables["Type"].Rows[i]["Value"]);
        if (!Xchk) Sameall = false;
        if (Xchk)
        {
          Nchk = false;
          if (Xval.Length == 0)
          {
            Xval = "20" + Convert.ToString(i + 1);
          }
          else
          {
            Xval += ",20" + Convert.ToString(i + 1);
          }
        }
      }

      Gval = Xval;

      if (Nchk)
      {
        XtraMessageBox.Show("กรุณาเลือกประเภทเอกสารอย่างน้อย 1 ประเภท", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      //if (txtIns.Visible)
      //{
      //  if (txtIns.EditValue == null || txtIns.EditValue.ToString().Length == 0)
      //  {
      //    XtraMessageBox.Show("คุณยังไม่ได้ระบุกลุ่มรหัสสินค้า", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //    return;
      //  }
      //}
      

      //เจ้าหนี้
      //if (txtCcus.Visible)
      //{
      //  if (txtCcus.EditValue == null || txtCcus.EditValue.ToString().Length == 0)
      //  {
      //    XtraMessageBox.Show("คุณยังไม่ได้ระบุกลุ่มรหัสเจ้าหนี้", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //    return;
      //  }
      //}
      
      if (!BGW.IsBusy)
      {
        XSTKg = txtIns.Text;
        XSTOg = txtModel.Text;
        XCRE = txtCcus.Text;
        STKg = XSTKg.Split(',');
        STOg = XSTOg.Split(',');
        groupControl1.Enabled = false;
        groupControl2.Enabled = false;
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

   private void lkDateOpt_EditValueChanged(object sender, EventArgs e)
    {
      DateTime dateFrom;
      DateTime dateTo ;
      int day = 0;
      int month  = 0;
      int year  = 0;
      int type  = 0;
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
        if (type==5)
        {
          txtDateStart.Enabled =true;
          txtDateEnd.Enabled = true;
        }
        else
        {
          txtDateStart.Enabled = false;
          txtDateEnd.Enabled = false;
        }

        switch ( System.Convert.ToInt32(lkDateOpt.EditValue))
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
          case  3:
              day = 1;
              month =DateTime.Now.Month == 1 ?  12: DateTime.Now.Month - 1;
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
              year = DateTime.Now.Year-1;
              dateFrom = new DateTime(year, month, day);
              day = 31;
              month = 12;
              year = DateTime.Now.Year-1;
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

        txtDateStart.DateTime =dateFrom;
        txtDateEnd.DateTime = dateTo;
        }
      catch(Exception ex) 
       {
         MessageBox.Show(ex.Message);
       }
    }

   
    public void SetDefaultdate()
    {
      DateTime dateFrom ;

      dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      DefaultCustomDate_From = dateFrom;
      DefaultCustomDate_To = new DateTime(DateTime.Now.Year, 12, 31);
    }

    private void comboCus_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtCcus.Visible = false;
      slookupCus.Visible = false;
      switch (comboCus.SelectedIndex)
      {
        //case 1:
        //  txtCcus.Visible = true;
        //  txtCcus.Width = 150;
        //  txtCcus.Focus();
        //  break;
        case 1:
          slookupCus.Visible = true;
          slookupCus.Width = 150;
          slookupCus.Properties.NullText = "กรุณาระบุรหัสลูกค้า";
          slookupCus.Location = new Point(txtCcus.Left, txtCcus.Top);
          break;
      }
    }

    private void txtDateStart_EditValueChanged(object sender, EventArgs e)
    {
      txtDateEnd.Properties.MinValue = System.Convert.ToDateTime(txtDateStart.EditValue);
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
      bool isOK = false;
      isOK = cls_Global_class.GetSecurityOK(4, cls_Global_class.GB_USMs4, 10);

      if ((!isOK) && (cls_Global_class.GB_UserCode != "ADMIN"))
      {
        frm_NoAccess frno;
        frno = new frm_NoAccess();
        frno.ShowDialog();
        return;
      }
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("Excle 2003", "Excle Files|*.xls", this.Text);
      if (Filename == string.Empty) return;
      //Grid.ExportToXlsx(Filename);
      bool printDetails = gvHead.OptionsPrint.PrintDetails;
      bool expandAllDetails = gvHead.OptionsPrint.ExpandAllDetails;
      bool expandAllGroups = gvHead.OptionsPrint.ExpandAllGroups;


      gvHead.OptionsPrint.ExpandAllDetails = true;
      gvHead.OptionsPrint.ExpandAllGroups = true;
      gvHead.OptionsPrint.PrintDetails = true;

      foreach (GridView gv in Grid.Views)
      {
        gv.OptionsPrint.AutoWidth = true;
        gv.OptionsView.RowAutoHeight = true;
        gv.OptionsView.ColumnAutoWidth = true;
        foreach (GridColumn gc in gv.Columns)
        gc.ColumnEdit = new RepositoryItemMemoEdit();
      }

      gvHead.ExportToXls(Filename);

      gvHead.OptionsPrint.PrintDetails = printDetails;
      gvHead.OptionsPrint.ExpandAllDetails = expandAllDetails;
      gvHead.OptionsPrint.ExpandAllGroups = expandAllGroups;
      cls_Form.OpenFile(Filename);
    }

    private void exportExcle_Click_1(object sender, EventArgs e)
    {
      if (!ReportOK) return;
      string Filename = cls_Form.ShowsaveDialogFile("Excle 2007-2010", "Excle Files|*.xls", this.Text);
      if (Filename == string.Empty) return;
      //Grid.ExportToXlsx(Filename);
      bool printDetails = gvHead.OptionsPrint.PrintDetails;
      bool expandAllDetails = gvHead.OptionsPrint.ExpandAllDetails;
      bool expandAllGroups = gvHead.OptionsPrint.ExpandAllGroups;


      gvHead.OptionsPrint.ExpandAllDetails = true;
      gvHead.OptionsPrint.ExpandAllGroups = true;
      gvHead.OptionsPrint.PrintDetails = true;

      foreach (GridView gv in Grid.Views)
      {
        gv.OptionsPrint.AutoWidth = true;
        gv.OptionsView.RowAutoHeight = true;
        gv.OptionsView.ColumnAutoWidth = true;
        foreach (GridColumn gc in gv.Columns)
          gc.ColumnEdit = new RepositoryItemMemoEdit();
      }

      gvHead.ExportToXls(Filename);

      gvHead.OptionsPrint.PrintDetails = printDetails;
      gvHead.OptionsPrint.ExpandAllDetails = expandAllDetails;
      gvHead.OptionsPrint.ExpandAllGroups = expandAllGroups;
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

    private void comboSN_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtSN.Visible = false;
      slookupSN.Visible = false;
      switch (comboSN.SelectedIndex)
      {
        //case 1:
        //  txtSN.Visible = true;
        //  txtSN.Width = 150;
        //  txtSN.Focus();
        //  break;
        case 1:
          slookupSN.Visible = true;
          slookupSN.Width = 150;
          slookupSN.Properties.NullText = "กรุณาระบุหมายเลข";
          slookupSN.Location = new Point(txtSN.Left, txtSN.Top);
          break;
      }
    }

    private void gvHead_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
    {
      GridView masterView = sender as GridView;
      GridView detailView = masterView.GetDetailView(e.RowHandle, 0) as GridView;
      masterView.BeginUpdate();
      for (int i = 0; i < detailView.DataRowCount; i++)
        detailView.SetMasterRowExpanded(i, true);
      masterView.EndUpdate();
    }
    
  }
}