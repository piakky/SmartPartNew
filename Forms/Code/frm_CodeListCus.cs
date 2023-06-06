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
using Medical.Class;
using DevExpress.XtraEditors.Repository;

namespace Medical.Forms.Code
{
  public partial class frm_CodeListCus : DevExpress.XtraEditors.XtraForm
  {
    BackgroundWorker BGW = new BackgroundWorker();
    DataSet _DS;
    RepositoryItemSearchLookUpEdit SlookupDep = new RepositoryItemSearchLookUpEdit();

    public frm_CodeListCus()
    {
      InitializeComponent();
      BGW.WorkerReportsProgress = true;
      BGW.WorkerSupportsCancellation = true;
      BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
      BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
      BGW.RunWorkerAsync();
      SetGrid();
      //gridCodeCus.Visible = true;
    }

    void BGW_DoWork(object sender, DoWorkEventArgs e)
    {
      LoadData();
    }

    void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      gridCodeCus.DataSource = _DS.Tables["CUS"];
      gridCodeCus.RefreshDataSource();
      gridCodeCus.Visible = true;

      SlookupDep.DataSource = _DS.Tables["DEP"];
      SlookupDep.PopulateViewColumns();
      SlookupDep.View.Columns["Dep_NameE"].Caption = "Department name (Eng)";
      SlookupDep.DisplayMember = "Dep_NameE";
      SlookupDep.ValueMember = "Dep_id";
      SlookupDep.NullText = "";

      this.Cursor = Cursors.Default;
    }

    public void DeleteData()
    {
      if (_DS.Tables["CUS"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvCodeCus.GetFocusedDataRow();
      int Id = System.Convert.ToInt32(Drow["Cus_id"]);
      string Vc = System.Convert.ToString(Drow["Cus_Code"]);
      DialogResult Result = XtraMessageBox.Show("Do you wish to delete " + Vc + " ?", "Delete", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeleteCodeCUS(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("Delete " + Vc + " complete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!BGW.IsBusy)
            {
              BGW.RunWorkerAsync();
            }
            else
            {
              XtraMessageBox.Show("System is running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }
        catch (Exception ex)
        {
          XtraMessageBox.Show(ex.Message);
        }
      }
    }

    public void InitialDialog(int Gmode)
    {
      frm_CodeInputCUS frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      DataRow[] drow = null;
      string strMode = String.Empty;

      int Xmode = 0;
      int mode = Gmode;

      if (mode == 2)
      {
        Xmode = 0;
      }
      else
      {
        Xmode = mode;
      }


      frmInput = new frm_CodeInputCUS(Xmode);
      frmInput.StartPosition = FormStartPosition.CenterParent;
      SetLookUP(frmInput);

      if (mode == 0)
        strMode = " [Insert]";
      else if (mode == 1)
        strMode = " [Edit]";
      else if (mode == 2)
        strMode = " [Copy]";


      try
      {
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvCodeCus;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != 0)
          {
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        //dtGroup = CType(GridGroup.DataSource, DataTable);
        frmInput.Text = "Customer code" + strMode;
        //frmInput.col_lkName.FieldName = "USGname" & IIf(Gte, "T", "E").ToString();
        #region "XXX"
        if (dr != null)
        {
          if ((mode == 1) || (mode == 2))
          {
            //if ((dr["USRlock"] != null) && (Convert.ToBoolean(dr["USRlock"])))
            //{
            //  frmInput.BTok.Visible = false;
            //}
            if (mode == 1)
            {
              frmInput.Prop_CUSid = Convert.ToInt32(dr["Cus_id"]);
              frmInput.Prop_RowUser = dr;
              frmInput.txtCode.Text = Convert.ToString(dr["Cus_Code"]);
            }
            else
            {
              DataTable dt = (DataTable)gridCodeCus.DataSource;
              frmInput.Prop_RowUser = dt.NewRow();
              frmInput.MemberOf = "";
              frmInput.txtCode.Text = "";

            }
            //frmInput.lookUp_Group.EditValue = dr("USRgroupid")					
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
              frmInput.txtNameT.Text = cls_Library.DBString(dr["Cus_NameT"]);
              frmInput.txtNameE.Text = cls_Library.DBString(dr["Cus_NameE"]);
              frmInput.txtAdd1AT.Text = "";
              frmInput.txtAdd2AT.Text = "";
              string Xadd = cls_Library.DBString(dr["Cus_AddressT"]);
              if (Xadd.Length > 0)
              {
                int i = Xadd.IndexOf(System.Environment.NewLine);
                if (i > 0)
                {
                  frmInput.txtAdd1AT.Text = Xadd.Substring(0, i);
                  frmInput.txtAdd2AT.Text = Xadd.Substring(i+2,Xadd.Length - i-2);
                }
              }
              frmInput.txtAdd1AE.Text = "";
              frmInput.txtAdd2AE.Text = "";
              string XaddE = cls_Library.DBString(dr["Cus_AddressE"]);
              if (XaddE.Length > 0)
              {
                int i = XaddE.IndexOf(System.Environment.NewLine);
                if (i > 0)
                {
                  frmInput.txtAdd1AE.Text = XaddE.Substring(0, i);
                  frmInput.txtAdd2AE.Text = XaddE.Substring(i+2, XaddE.Length - i-2);
                }
              }
              frmInput.txtContact1.Text = cls_Library.DBString(dr["Cus_Contact1"]);
              frmInput.txtPosition1.Text = cls_Library.DBString(dr["Cus_Contact1_Pos"]);
              frmInput.LookUpDep1.EditValue =  cls_Library.DBInt(dr["Cus_Contact1_Dep"]);
              frmInput.txtTel1.Text = cls_Library.DBString(dr["Cus_Contact1_Tel"]);
              frmInput.txtEmail1.Text = cls_Library.DBString(dr["Cus_Contact1_Email"]);
              frmInput.txtNote1.Text = cls_Library.DBString(dr["Cus_Contact1_Note"]);
              frmInput.txtContact2.Text = cls_Library.DBString(dr["Cus_Contact2"]);
              frmInput.txtPosition2.Text = cls_Library.DBString(dr["Cus_Contact2_Pos"]);
              frmInput.LookUpDep2.EditValue =  cls_Library.DBInt(dr["Cus_Contact2_Dep"]);
              frmInput.txtTel2.Text = cls_Library.DBString(dr["Cus_Contact2_Tel"]);
              frmInput.txtEmail2.Text = cls_Library.DBString(dr["Cus_Contact2_Email"]);
              frmInput.txtNote2.Text = cls_Library.DBString(dr["Cus_Contact2_Note"]);
            }
          }
          else
          {
            DataTable dt = (DataTable)gridCodeCus.DataSource;
            frmInput.Prop_RowUser = dt.NewRow();
            frmInput.MemberOf = "";
          }
        }
        else
        {
          DataTable dt = (DataTable)gridCodeCus.DataSource;
          frmInput.Prop_RowUser = dt.NewRow();
        }
        #endregion
        //frmInput.lookUp_Group.Properties.DataSource = dtGroup;
        //frmInput.lookUp_Group.Refresh();
        //frmInput.lookUp_Group.Properties.PopulateViewColumns();

        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }


        _DS.Tables["CUS"].BeginInit();
        //DS_Data.Tables["USG"].BeginInit();
        if (Xmode == 0)
        {
          if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["CUS"].Rows.Count == 1))
          {
            //if (mode == 2)
            //{
            //   DataTable _dt;
            //    _dt = frmInput.getLastdata.Tables["CUS"];

            //    if (_dt != null)
            //    {
            //      _DS.Tables["CUS"].BeginInit();
            //      _DS.Tables["CUS"].ImportRow(_dt.Rows[0]);
            //      _DS.Tables["CUS"].EndInit();
            //      gridCodeCus.RefreshDataSource();
            //    }
            //}
            //else
            //{
              _DS.Tables["CUS"].ImportRow(frmInput.getLastdata.Tables["CUS"].Rows[0]);
            //}
            //foreach (DataRow r in frmInput.getLastdata.Tables["USG"].Rows)
            //{
            //  drow = DS_Data.Tables["USG"].Select("USGid=" + Convert.ToString(r["USGid"]));
            //  if (drow.Length == 1)
            //  {
            //    drow[0]["USGmember"] = r["USGmember"];
            //  }
            //}
          }
        }
        else
        {
          //DataRow[] r_USRG = DS_Data.Tables["USR"].Select("USRid=" + Convert.ToString(frmInput.Prop_RowUser["USRid"]));
          //if (r_USRG.Length == 1)
          //{
          //  r_USRG[0].ItemArray = frmInput.getLastdata.Tables["USR"].Rows[0].ItemArray;
          //}
          //if (frmInput.getLastdata.Tables["USG"] !=null) 
          //{
          //  foreach (DataRow r in frmInput.getLastdata.Tables["USG"].Rows)
          //  {
          //    r_USRG = DS_Data.Tables["USG"].Select("USGid=" + Convert.ToString(r["USGid"]));
          //    if (r_USRG.Length == 1)
          //    {
          //      drow[0]["USGmember"] = r["USGmember"];
          //    }
          //  }
          //}
        }
        //DS_Data.Tables("USR").DefaultView.Sort = "USRcode"
        _DS.Tables["CUS"].EndInit();
        gridCodeCus.DataSource = _DS.Tables["CUS"];
        gridCodeCus.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }

    private void LoadData()
    {
      SqlConnection cn = new SqlConnection();
      SqlDataAdapter da = null;
      DataTable dt;
      string sql = string.Empty;
      DateTime dateF = DateTime.Now.Date;

      cls_Global_DB.ConnectDatabase(ref cn);

      try
      {
        _DS = new DataSet();
        _DS.Tables.Clear();

        dt = new DataTable("CUS");
        dt = cls_Data.GetCodeCUS(0,0,"");
        _DS.Tables.Add(dt);

        dt = new DataTable("DEP");
        dt = cls_Data.GetCodeDEP(0, "", "Dep_id,Dep_Code,Dep_NameT,Dep_NameE");
        _DS.Tables.Add(dt);

      }
      catch
      {
      }
      finally
      {
        cls_Global_DB.CloseDB(ref cn);
      }
    }

    public void RefreshData()
    {
      if (!BGW.IsBusy)
      {
        this.UseWaitCursor = true;
        BGW.RunWorkerAsync();
      }
      this.UseWaitCursor = false;
      this.Cursor = Cursors.Default;
    }

    private void SetGrid()
    {
      int i;

      try
      {
        GridColumn Cus_id = cls_Form.AddGridColumn("Cus_id", "id", "Cus_id", false, 0, 100);
        GridColumn Cus_Code = cls_Form.AddGridColumn("Cus_Code", "Customer code", "Cus_Code", true, 1, 100);
        GridColumn Cus_NameT = cls_Form.AddGridColumn("Cus_NameT", "Customer name (Thai)", "Cus_NameT", true, 2, 255);
        GridColumn Cus_NameE = cls_Form.AddGridColumn("Cus_NameE", "Customer name (Eng)", "Cus_NameE", true, 3, 255);
        GridColumn Cus_AddressT = cls_Form.AddGridColumn("Cus_AddressT", "Address (Thai)", "Cus_AddressT", true, 4, 300);
        GridColumn Cus_AddressE = cls_Form.AddGridColumn("Cus_AddressE", "Address (Eng)", "Cus_AddressE", true, 5, 300);
        GridColumn Cus_Contact1 = cls_Form.AddGridColumn("Cus_Contact1", "Contact (1)", "Cus_Contact1", true, 6, 100);
        GridColumn Cus_Contact1_Pos = cls_Form.AddGridColumn("Cus_Contact1_Pos", "Position (1)", "Cus_Contact1_Pos", true, 7, 100);
        GridColumn Cus_Contact1_Dep = cls_Form.AddGridColumn("Cus_Contact1_Dep", "Department (1)", "Cus_Contact1_Dep", true, 8, 100);
        GridColumn Cus_Contact1_Tel = cls_Form.AddGridColumn("Cus_Contact1_Tel", "Tel. (1)", "Cus_Contact1_Tel", true, 9, 100);
        GridColumn Cus_Contact1_Email = cls_Form.AddGridColumn("Cus_Contact1_Email", "Email (1)", "Cus_Contact1_Email", true, 10, 100);
        GridColumn Cus_Contact1_Note = cls_Form.AddGridColumn("Cus_Contact1_Note", "Note (1)", "Cus_Contact1_Note", true, 11, 100);
        GridColumn Cus_Contact2 = cls_Form.AddGridColumn("Cus_Contact2", "Contact (2)", "Cus_Contact2", true, 12, 100);
        GridColumn Cus_Contact2_Pos = cls_Form.AddGridColumn("Cus_Contact2_Pos", "Position (2)", "Cus_Contact2_Pos", true, 13, 100);
        GridColumn Cus_Contact2_Dep = cls_Form.AddGridColumn("Cus_Contact2_Dep", "Department (2)", "Cus_Contact2_Dep", true, 14, 100);
        GridColumn Cus_Contact2_Tel = cls_Form.AddGridColumn("Cus_Contact2_Tel", "Tel. (2)", "Cus_Contact2_Tel", true, 15, 100);
        GridColumn Cus_Contact2_Email = cls_Form.AddGridColumn("Cus_Contact2_Email", "Email (2)", "Cus_Contact2_Email", true, 16, 100);
        GridColumn Cus_Contact2_Note = cls_Form.AddGridColumn("Cus_Contact2_Note", "Note (2)", "Cus_Contact2_Note", true, 17, 100);
        GridColumn Cus_EditUser = cls_Form.AddGridColumn("Cus_EditUser", "Edit by", "Cus_EditUser", true, 18, 100);
        GridColumn Cus_EditDate = cls_Form.AddGridColumn("Cus_EditDate", "Edit date", "Cus_EditDate", true, 19, 100);


        gridCodeCus.BeginInit();
        gvCodeCus.BeginInit();
        gvCodeCus.Columns.Clear();

        Cus_id.Visible = false;
        Cus_EditUser.Visible = false;
        Cus_EditDate.Visible = false;

        Cus_Code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Code.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Code.AppearanceCell.Options.UseTextOptions = true;
        Cus_Code.DisplayFormat.FormatString = "#,##0";
        Cus_Code.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        Cus_Code.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        Cus_Code.SummaryItem.DisplayFormat = "{0:#,##0}" + "   รายการ";

        Cus_NameT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_NameT.AppearanceHeader.Options.UseTextOptions = true;
        Cus_NameT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_NameT.AppearanceCell.Options.UseTextOptions = true;

        Cus_NameE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_NameE.AppearanceHeader.Options.UseTextOptions = true;
        Cus_NameE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_NameE.AppearanceCell.Options.UseTextOptions = true;

        Cus_AddressT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_AddressT.AppearanceHeader.Options.UseTextOptions = true;
        Cus_AddressT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_AddressT.AppearanceCell.Options.UseTextOptions = true;

        Cus_AddressE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_AddressE.AppearanceHeader.Options.UseTextOptions = true;
        Cus_AddressE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_AddressE.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact1.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact1.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact1_Pos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact1_Pos.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact1_Pos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact1_Pos.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact1_Dep.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact1_Dep.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact1_Dep.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact1_Dep.AppearanceCell.Options.UseTextOptions = true;
        Cus_Contact1_Dep.ColumnEdit = SlookupDep;

        Cus_Contact1_Tel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact1_Tel.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact1_Tel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact1_Tel.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact1_Email.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact1_Email.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact1_Email.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact1_Email.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact1_Note.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact1_Note.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact1_Note.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact1_Note.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact2.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact2.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact2_Pos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact2_Pos.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact2_Pos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact2_Pos.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact2_Dep.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact2_Dep.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact2_Dep.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact2_Dep.AppearanceCell.Options.UseTextOptions = true;
        Cus_Contact2_Dep.ColumnEdit = SlookupDep;

        Cus_Contact2_Tel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact2_Tel.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact2_Tel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact2_Tel.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact2_Email.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact2_Email.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact2_Email.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact2_Email.AppearanceCell.Options.UseTextOptions = true;

        Cus_Contact2_Note.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_Contact2_Note.AppearanceHeader.Options.UseTextOptions = true;
        Cus_Contact2_Note.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_Contact2_Note.AppearanceCell.Options.UseTextOptions = true;

        Cus_EditUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_EditUser.AppearanceHeader.Options.UseTextOptions = true;
        Cus_EditUser.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_EditUser.AppearanceCell.Options.UseTextOptions = true;

        Cus_EditDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        Cus_EditDate.AppearanceHeader.Options.UseTextOptions = true;
        Cus_EditDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        Cus_EditDate.AppearanceCell.Options.UseTextOptions = true;

        gvCodeCus.Columns.AddRange(new GridColumn[] { Cus_id, Cus_Code, Cus_NameT, Cus_NameE, Cus_AddressT, Cus_AddressE, Cus_Contact1, Cus_Contact1_Pos, Cus_Contact1_Dep, Cus_Contact1_Tel, Cus_Contact1_Email, Cus_Contact1_Note, Cus_Contact2, Cus_Contact2_Pos, Cus_Contact2_Dep, Cus_Contact2_Tel, Cus_Contact2_Email, Cus_Contact2_Note, Cus_EditUser, Cus_EditDate });
        //gridList.RepositoryItems.Add(R_STK);

        gvCodeCus.OptionsView.ShowGroupPanel = false;
        gvCodeCus.OptionsBehavior.Editable = false;
        gvCodeCus.OptionsSelection.EnableAppearanceFocusedCell = false;
        gvCodeCus.OptionsView.EnableAppearanceEvenRow = false;
        gvCodeCus.OptionsView.EnableAppearanceOddRow = true;
        gvCodeCus.IndicatorWidth = 50;

        //gv.OptionsView.ColumnAutoWidth = false;
        gvCodeCus.OptionsView.RowAutoHeight = true;
        gvCodeCus.OptionsView.ShowAutoFilterRow = false;
        gvCodeCus.OptionsFind.ShowCloseButton = false;
        gvCodeCus.OptionsFind.AlwaysVisible = true;
        gvCodeCus.OptionsView.ShowFooter = true;

        //colDesc.ColumnEdit = R_STK;



        gvCodeCus.EndInit();
        gridCodeCus.EndInit();
      }
      catch (Exception e)
      {
        XtraMessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      //gvCodeCus.OptionsView.ShowViewCaption = true;
      //gridCodeCus.Visible = true;
    }

    private void SetLookUP(frm_CodeInputCUS frmInput)
    {
      frmInput.LookUpDep1.Properties.DataSource = _DS.Tables["DEP"];
      frmInput.LookUpDep1.Properties.PopulateViewColumns();
      frmInput.LookUpDep1.Properties.DisplayMember = "Dep_Code";
      frmInput.LookUpDep1.Properties.ValueMember = "Dep_id";
      frmInput.LookUpDep1.Properties.NullText = "Please specify the Dep code first.";
      frmInput.LookUpDep1.Properties.View.Columns["Dep_id"].Visible = false;
      frmInput.LookUpDep1.Properties.View.Columns["Dep_Code"].Caption = "Department code";
      frmInput.LookUpDep1.Properties.View.Columns["Dep_NameT"].Caption = "Department name (Thai)";
      frmInput.LookUpDep1.Properties.View.Columns["Dep_NameE"].Caption = "Department name (Eng)";

      frmInput.LookUpDep2.Properties.DataSource = _DS.Tables["DEP"];
      frmInput.LookUpDep2.Properties.PopulateViewColumns();
      frmInput.LookUpDep2.Properties.DisplayMember = "Dep_Code";
      frmInput.LookUpDep2.Properties.ValueMember = "Dep_id";
      frmInput.LookUpDep2.Properties.NullText = "Please specify the Dep code first.";
      frmInput.LookUpDep2.Properties.View.Columns["Dep_id"].Visible = false;
      frmInput.LookUpDep2.Properties.View.Columns["Dep_Code"].Caption = "Department code";
      frmInput.LookUpDep2.Properties.View.Columns["Dep_NameT"].Caption = "Department name (Thai)";
      frmInput.LookUpDep2.Properties.View.Columns["Dep_NameE"].Caption = "Department name (Eng)";

      //}
    }



    private void frm_CodeListCus_FormClosing(object sender, FormClosingEventArgs e)
    {
      Class_Library mc = new Class_Library();
      Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
      ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
    }

    private void gvCodeCus_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }

    private void gvCodeCus_DoubleClick(object sender, EventArgs e)
    {
      InitialDialog(1);
    }

  }
}