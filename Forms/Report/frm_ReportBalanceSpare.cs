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


namespace Medical
{
 
  public partial class frm_ReportBalanceSpare : DevExpress.XtraEditors.XtraForm
  {
    #region ตัวแปร
    BackgroundWorker BGW = new BackgroundWorker();
    BackgroundWorker BGWGetCode = new BackgroundWorker();
    DateTime DefaultCustomDate_From ;
    DateTime DefaultCustomDate_To;
    DataTable dt_type = null;
    RepositoryItemCheckEdit c_V = new RepositoryItemCheckEdit();
    private DevExpress.XtraGrid.StyleFormatCondition styleDef = new DevExpress.XtraGrid.StyleFormatCondition();
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

    public frm_ReportBalanceSpare()
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
      dt = cls_Data.GetCodePart(0, 0, "Part_id,Part_Code,Part_NameT,Part_NameE");
      DataC.Tables.Add(dt);

      //dt = new DataTable();
      //dt = cls_Data.GetCodeIns(0, 0, "Ins_id,Ins_Code");
      //DataC.Tables.Add(dt);

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
      slookupSpare.Properties.DataSource = DataC.Tables["Part"];
      //slookupIns.Properties.DataSource = DataC.Tables["Ins"];
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
      Grid.DataSource = DataS.Tables["Part"];
      gvList.RefreshData();
      Grid.RefreshDataSource();
      groupControl1.Enabled = true;
      groupControl4.Enabled = true;
      Grid.Visible=true;
      if (DataS.Tables["Part"].Rows.Count > 0) ReportOK = true;
      this.UseWaitCursor = false;
    }

    private void InitialData()
    {
      //cls_CST_CP.CSTgetBal("FG001", "MAIN", DateTime.Now);

      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      string sql = string.Empty;
      //DateTime CaldateF;
      //DateTime CaldateT;
      DataTable dt = null;
      DataTable dtVoucher = null;
      //DataTable dtHead = null;
      DataTable dtList = null;
      int i, NO = 0, j;

      int R_Shelf = 0,R_Spareid=0;
      //string R_ShelfNo = "", R_PartNo = "", R_SN = "", R_Dep, R_Cus, R_Rec, R_Note;
      //DateTime R_Date;
      DateTime dateF = DateTime.Now.Date;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        //CaldateF = cls_Global_class.GetDateCulture(txtDateStart.DateTime);
        //CaldateT = cls_Global_class.GetDateCulture(txtDateEnd.DateTime);
        DataS = new DataSet();
        //dtHead = new DataTable("Head");


        //dtHead.Columns.Clear();
        //dtHead.Columns.Add("R_Cus_id", typeof(int));
        //dtHead.Columns.Add("R_CusName", typeof(string));



        dtList = new DataTable("Part");
        //dtList = dtHead.Copy();
        dtList.Columns.Clear();
        dtList.Columns.Add("R_ShelfNo", typeof(string));
        dtList.Columns.Add("R_PartNo", typeof(string));
        dtList.Columns.Add("R_PartCode", typeof(string));
        //dtList.Columns.Add("R_InsName", typeof(string));
        dtList.Columns.Add("R_Partname", typeof(string));
        dtList.Columns.Add("R_MCName", typeof(string));
        dtList.Columns.Add("R_MCModel", typeof(string));
        dtList.Columns.Add("R_Version", typeof(string));
        dtList.Columns.Add("R_Min", typeof(double));
        dtList.Columns.Add("R_Balanace", typeof(double));
        dtList.Columns.Add("R_Remark", typeof(string));


        dt = new DataTable("Part");

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
        sql = "SELECT  Part_id, Part_No, Part_Code, Part_NameT, Part_NameE, Part_Spec_id, Part_Spec_Model, Part_Version, Part_Shelf, Part_Minimum, Part_Remark FROM SparePart";
        sql += " Where (Part_Delete =0) ";
        if (slookupSpare.Visible)
        {
          sql += " and Part_id=@Part_id";
          R_Spareid = Convert.ToInt32(slookupSpare.EditValue);
        }
        sql += " Order by Part_Code,Part_NameT";
        da = new SqlDataAdapter(sql, cn);
        
        //da.SelectCommand.Parameters.Add("@BFmonth", SqlDbType.Int).Value = BFmonth;
        //da.SelectCommand.Parameters.Add("@BFyear", SqlDbType.Int).Value = BFyear;
        //da.SelectCommand.Parameters.Add("@dateForm", SqlDbType.DateTime).Value = System.Convert.ToDateTime(CaldateF);
        //da.SelectCommand.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = System.Convert.ToDateTime(CaldateT);
        if (slookupSpare.Visible)
        {
          da.SelectCommand.Parameters.Clear();
          da.SelectCommand.Parameters.Add("@Part_id", SqlDbType.Int).Value = R_Spareid;
        }
        da.SelectCommand.CommandTimeout = 1200;
        dtVoucher = new DataTable("Part");
        da.Fill(dtVoucher);
        for (i = 0; i < dtVoucher.Rows.Count; i++)
        {
          //R_Ins = cls_Library.DBInt(dtVoucher.Rows[i]["V_Ins_id"]);

          //CPPunit = cls_Library.DBString(dtVoucher.Rows[i]["STKuname"]);
          //CPPquan = cls_Library.DBDouble(dtVoucher.Rows[i]["CPPstkREQ"]);
          //CPPreceive = cls_Library.DBDouble(dtVoucher.Rows[i]["CPPstkCUT1"]);
          //CPPsumREQ = cls_Library.DBDecimal(dtVoucher.Rows[i]["CPPsumREQ"]);

          //CPPorder=CPPquan/32500;
          //CPPreceive = CPPreceive / 32500;
          //CPPbetween = GetQuanfromQuotation(cls_Library.DBString(dtVoucher.Rows[i]["CPPcusID"]),CPPstk, System.Convert.ToDateTime(CaldateF),System.Convert.ToDateTime(CaldateT));


          dt.Rows.Add();
          //dt.Rows[i]["R_Ins"] = R_Ins;
          R_Spareid = cls_Library.DBInt(dtVoucher.Rows[i]["Part_id"]);
          R_Shelf = cls_Library.DBInt(dtVoucher.Rows[i]["Part_Shelf"]);
          dt.Rows[i]["R_ShelfNo"] = cls_Data.GetTBname(R_Shelf, "Shelf", "Shelf_Code");
          //dt.Rows[i]["R_Cus"] =cls_Library.DBInt(dtVoucher.Rows[i]["Ins_Cus_id"]);
          dt.Rows[i]["R_PartNo"] = cls_Library.DBString(dtVoucher.Rows[i]["Part_No"]);
          dt.Rows[i]["R_PartCode"] = cls_Library.DBString(dtVoucher.Rows[i]["Part_Code"]);
          dt.Rows[i]["R_Partname"] = cls_Library.DBString(dtVoucher.Rows[i]["Part_NameE"]);
          dt.Rows[i]["R_MCName"] = cls_Data.GetTBname(cls_Library.DBInt(dtVoucher.Rows[i]["Part_Spec_id"]), "Spec", "Spec_Name");
          dt.Rows[i]["R_MCModel"] = cls_Library.DBString(dtVoucher.Rows[i]["Part_Spec_Model"]);
          dt.Rows[i]["R_Version"] = cls_Library.DBString(dtVoucher.Rows[i]["Part_Version"]);
          dt.Rows[i]["R_Min"] = cls_Library.DBInt(dtVoucher.Rows[i]["Part_Minimum"]);
          dt.Rows[i]["R_Balanace"] =cls_Data.GetBalancePart(R_Spareid);
          dt.Rows[i]["R_Remark"] = cls_Library.DBString(dtVoucher.Rows[i]["Part_Remark"]);

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
        //foreach (DataRow r in dt.Rows)
        //{
        //  //object Debit = 0;
        //  //object Credit = 0;
        //  DataRow[] dr = dtHead.Select("R_Cus_id =" + System.Convert.ToInt32(r[0]) + "");

        //  if (dr.Length <= 0)
        //  {
        //    //Debit = tbMzbf.Compute("sum(ZBFsumDr)", "ACCid =" + Convert.ToInt32(r["ACCid"]) + " AND OCMDid = " + Convert.ToInt32(r["OCMDid"]));
        //    //Credit = tbMzbf.Compute("sum(ZBFsumCr)", "ACCid =" + Convert.ToInt32(r["ACCid"]) + " AND OCMDid = " + Convert.ToInt32(r["OCMDid"]));
        //    DataRow _row = dtHead.NewRow();
        //    _row["R_Cus_id"] = r["R_Cus_id"];
        //    _row["R_CusName"] =cls_Data.GetTBname(cls_Library.DBInt(r["R_Cus_id"]), "CUS", "Cus_NameE");
        //    //_row["ZBFsumCr"] = Credit;
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


        DataS.Tables.Add(dt);
        //DataS.Tables.Add(dtHead);

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
      //slookupIns.Properties.PopulateViewColumns();
      //slookupIns.Properties.ValueMember = "Ins_id";
      //slookupIns.Properties.DisplayMember = "Ins_Code";
      //slookupIns.Properties.View.Columns["Ins_id"].Visible=false;
      //slookupIns.Properties.View.Columns["Ins_Code"].Caption = "Instrument code";

      //slookupModel.Properties.PopulateViewColumns();
      //slookupModel.Properties.ValueMember = "STOcode";
      //slookupModel.Properties.DisplayMember = "STOcode";
      //slookupModel.Properties.View.Columns["STOcode"].Caption = "รหัสสโตร์";
      //slookupModel.Properties.View.Columns["STOgroup"].Caption = "กลุ่มสโตร์";
      //slookupModel.Properties.View.Columns["STOdescT"].Caption = "ชื่อไทย";
      //slookupModel.Properties.View.Columns["STOdescE"].Caption = "ชื่ออังกฤษ";

      slookupSpare.Properties.PopulateViewColumns();
      slookupSpare.Properties.ValueMember = "Part_id";
      slookupSpare.Properties.DisplayMember = "Part_NameE";
      slookupSpare.Properties.View.Columns["Part_id"].Visible = false;
      slookupSpare.Properties.View.Columns["Part_NameT"].Caption = "Spare part name (Thai)";
      slookupSpare.Properties.View.Columns["Part_NameE"].Caption = "Spare part name (Eng)";
      slookupSpare.Refresh();
    }

    private void SetGrid()
    {
      int i, NO = 0;

      //--- กำหนดค่าของ Heading 
      gvHead.Columns.Clear();
      gvList.Columns.Clear();

      GridColumn h_colCusid = cls_Form.AddGridColumn("R_Cus_id", "รหัสเครื่อง", "R_Cus_id", true, 0, 100);
      GridColumn h_colCusName = cls_Form.AddGridColumn("R_CusName", "บริษัท", "R_CusName", true, 1, 200);
      //GridColumn h_colModel = cls_Form.AddGridColumn("R_Model", "รุ่น", "R_Model", true,1 , 300);
      //GridColumn h_colSN = cls_Form.AddGridColumn("R_SN", "หมายเลข", "R_SN", true, 2, 100);
      //GridColumn h_colDep = cls_Form.AddGridColumn("R_Dep", "แผนก", "R_Dep", true, 3, 100);
      //GridColumn h_colCus = cls_Form.AddGridColumn("R_Cus", "บริษัท", "R_Cus", true, 4, 100);
      //GridColumn h_colREC = cls_Form.AddGridColumn("R_Rec", "คนให้บริการ", "R_Rec", true, 5, 100);
      //GridColumn h_colNote = cls_Form.AddGridColumn("R_Note", "Note", "R_Note", true, 6, 100);
      
      //GridColumn h_coltoday = cls_Form_CP.AddGridColumn("CPPtoday", "การปล่อยรถ วันนี้", "CPPtoday", true, 9, 100);
      //GridColumn h_colplan = cls_Form_CP.AddGridColumn("CPPplan", "Plan", "CPPplan", true, 10, 100);

      GridColumn colShelfNo = cls_Form.AddGridColumn("R_ShelfNo", "Shelf no.", "R_ShelfNo", true, 0, 100);
      GridColumn colPartNo = cls_Form.AddGridColumn("R_PartNo", "Part No", "R_PartNo", true, 0, 100);
      GridColumn colPartCode = cls_Form.AddGridColumn("R_PartCode", "Part Code", "R_PartCode", true, 1, 100);
      GridColumn colPartname = cls_Form.AddGridColumn("R_Partname", "Part name ", "R_Partname", true, 2, 100);
      GridColumn colMCName = cls_Form.AddGridColumn("R_MCName", "M/C Name", "R_MCName", true, 3, 100);
      GridColumn colMCModel = cls_Form.AddGridColumn("R_MCModel", "M/C Model", "R_MCModel", true, 4, 100);
      GridColumn colVersion = cls_Form.AddGridColumn("R_Version", "Version", "R_Version", true, 5, 100);
      GridColumn colMin = cls_Form.AddGridColumn("R_Min", "Min", "R_Min", true, 6, 100);
      GridColumn colBalanace = cls_Form.AddGridColumn("R_Balanace", "Balanace", "R_Balanace", true,7, 100);
      GridColumn colRemark = cls_Form.AddGridColumn("R_Remark", "Remark", "R_Remark", true, 8, 100);
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
      h_colCusid.Visible = false;
      //colIns.Visible = false;

      gvHead.OptionsView.ShowGroupPanel = false;
      gvHead.Columns.Clear();
      //gvHead.Columns.AddRange(new GridColumn[] { h_colCusid, h_colCusName});
      gvHead.Columns.AddRange(new GridColumn[] { colShelfNo, colPartNo, colPartCode, colPartname, colMCName, colMCModel, colVersion, colMin, colBalanace, colRemark });

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
      gvList.OptionsView.ShowGroupPanel = false;
      gvList.OptionsBehavior.Editable = false;
      gvList.OptionsSelection.EnableAppearanceFocusedCell = false;
      gvList.OptionsView.EnableAppearanceEvenRow = false;
      gvList.OptionsView.EnableAppearanceOddRow = true;
      gvList.IndicatorWidth = 50;

      //gv.OptionsView.ColumnAutoWidth = false;
      gvHead.OptionsView.RowAutoHeight = true;
      gvHead.OptionsView.ShowAutoFilterRow = true;
      //foreach (GridColumn col in gvList.Columns)
      //{
      //  //col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
      //  col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
      //  col.OptionsFilter.AllowFilter = false;
      //}

      styleDef.Appearance.BackColor = Color.Red;
      styleDef.Appearance.BackColor2 = Color.Red;
      styleDef.Appearance.Options.UseBackColor = true;
      styleDef.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
      //styleDef.Value1 = 0;
      //styleDef.Value2 = colBalanace;
      //styleDef.Column = colBalanace;
      styleDef.Expression = "[R_Min] > [R_Balanace]";
      styleDef.ApplyToRow = true;
      gvHead.FormatConditions.Add(styleDef);

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

    private void SetObject()
    {
      comboCus.SelectedIndex = 0;
      //comboIns.SelectedIndex = 0;
      //comboModel.SelectedIndex = 0;
      //comboSN.SelectedIndex = 0;
      //txtIns.Visible = false;
      //txtModel.Visible = false;
      txtCspare.Visible = false;
      //txtSN.Visible = false;
      //slookupIns.Visible = false;
      //slookupModel.Visible = false;
      slookupSpare.Visible = false;
      //slookupSN.Visible = false;
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

      //lkDateOpt.Properties.DataSource = DTdateOpt;
      //lkDateOpt.Properties.DisplayMember = "Text";
      //lkDateOpt.Properties.ValueMember = "Id";
      //lkDateOpt.Properties.NullText = "กรุณาเลือกช่วงเวลา";
      //txtDateStart.Enabled = false;
      //txtDateEnd.Enabled = false;
      //lkDateOpt.EditValue = 5;
      //groupControl3.Controls.Add(Comselect);
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
      //if (System.Convert.ToInt32(lkDateOpt.EditValue) < 1)
      //{
      //  XtraMessageBox.Show("คุณยังไม่ได้ระบุช่วงเวลา", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //  return;
      //}
      //if (txtModel.Visible)
      //{
      //  if (txtModel.EditValue == null || txtModel.EditValue.ToString().Length == 0)
      //  {
      //    XtraMessageBox.Show("คุณยังไม่ได้ระบุกลุ่มรหัสสโตร์", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //    return;
      //  }
      //}
      if (slookupSpare.Visible)
      {
        if (slookupSpare.EditValue == null)
        {
          XtraMessageBox.Show("คุณยังไม่ได้ระบุรหัส spare part", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }
      }

      //if (slookupIns.Visible)
      //{
      //  if (slookupIns.EditValue == null)
      //  {
      //    XtraMessageBox.Show("คุณยังไม่ได้ระบุเครื่อง", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //    return;
      //  }
      //}

      //if (slookupModel.Visible)
      //{
      //  if (slookupModel.EditValue == null)
      //  {
      //    XtraMessageBox.Show("คุณยังไม่ได้ระบุรุ่น", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //    return;
      //  }
      //}

      //if (slookupSN.Visible)
      //{
      //  if (slookupSN.EditValue == null)
      //  {
      //    XtraMessageBox.Show("คุณยังไม่ได้ระบุหมายเลข", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //    return;
      //  }
      //}

      //Sameall = true;
      //Nchk = true;
      //string Xval = "";
      //for (int i = 0; i < 4; i++)
      //{
      //  Xchk = Convert.ToBoolean(DataC.Tables["Type"].Rows[i]["Value"]);
      //  if (!Xchk) Sameall = false;
      //  if (Xchk)
      //  {
      //    Nchk = false;
      //    if (Xval.Length == 0)
      //    {
      //      Xval = "20" + Convert.ToString(i + 1);
      //    }
      //    else
      //    {
      //      Xval += ",20" + Convert.ToString(i + 1);
      //    }
      //  }
      //}

      //Gval = Xval;

      //if (Nchk)
      //{
      //  XtraMessageBox.Show("กรุณาเลือกประเภทเอกสารอย่างน้อย 1 ประเภท", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //  return;
      //}
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
        //XSTKg = txtIns.Text;
        //XSTOg = txtModel.Text;
        XCRE = txtCspare.Text;
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
      DateTime dateFrom ;

      dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      DefaultCustomDate_From = dateFrom;
      DefaultCustomDate_To = DateTime.Now;
    }

    private void comboCus_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtCspare.Visible = false;
      slookupSpare.Visible = false;
      switch (comboCus.SelectedIndex)
      {
        //case 1:
        //  txtCcus.Visible = true;
        //  txtCcus.Width = 150;
        //  txtCcus.Focus();
        //  break;
        case 1:
          slookupSpare.Visible = true;
          slookupSpare.Width = 150;
          slookupSpare.Properties.NullText = "กรุณาระบุรหัส spare";
          slookupSpare.Location = new Point(txtCspare.Left, txtCspare.Top);
          break;
      }
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
           
  }
}