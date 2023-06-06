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

namespace SmartPart.Forms.General
{
  public partial class frm_JobRecord : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private cls_Struct.StructJOB JOB = new cls_Struct.StructJOB();
    private BackgroundWorker _bwLoad = null;
    private int JOBID = 0;
    private cls_Struct.ActionMode DataMode;
    private DataSet dsMainData = new DataSet();
    private DataSet dsEdit = new DataSet();
    //private DataSet dsSave = new DataSet();
    private bool IsSaveOK = false;
    private double Zquan, Zconv;

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
          dsMainData = cls_Data.GetJOBById(JOBID);
      }
      catch (Exception ex)
      { MessageBox.Show(ex.Message); }
    }

    #endregion

    #region function

    private void AddDataSourceToGrid()
    {
        try
        {
            DataTable _dtGrid = new DataTable("JOBDETAIL");
            _dtGrid = dsEdit.Tables["JOBDETAIL"].Clone();
            dsEdit.Tables["JOBDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete))
            .ToList<DataRow>().ForEach(f => _dtGrid.ImportRow(f));

            gridDetail.DataSource = _dtGrid;
            gridDetail.RefreshDataSource();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
        }
    }

    private void AssignDataFromComponent()
    {
      JOB.JOB_ID = JOBID;
      JOB.JOB_NO = txtJobNo.Text.Trim();
      JOB.JOB_DATE = cls_Library.CDateTime(dateJOB.EditValue);
      JOB.JOB_TYPE = cls_Library.CInt(sluType.EditValue);
      JOB.JOB_OPEN = txtOpen.Text.Trim();
      JOB.JOB_OPERATOR = cls_Library.CInt(sluOperator.EditValue);
      JOB.JOB_STATUS = cls_Library.CByte(cmbStatus.SelectedIndex + 1);
      JOB.PRINT_NO = cls_Library.CByte(spinPrint.EditValue);
      JOB.LIST_NO = dsEdit.Tables["JOBDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Count();
      JOB.BARCODE = txtBarcode.Text.Trim();
    }

    private void AssignDataList()
    {
        try
        {
            DataTable dtList = new DataTable();
            dtList = dsEdit.Tables["JOBDETAIL"].Copy();
            dtList.TableName = "JOBDETAIL";

            DataColumn colMode = new DataColumn("mode", typeof(int));
            //DataColumn colChange = new DataColumn("Change", typeof(int));

            switch (DataMode)
            {
                case cls_Struct.ActionMode.Add:
                case cls_Struct.ActionMode.Edit:
                case cls_Struct.ActionMode.View:
                    colMode.DefaultValue = cls_Struct.ActionMode.Default;
                    //colChange.DefaultValue = -1;                    
                    break;
                case cls_Struct.ActionMode.Copy:
                    colMode.DefaultValue = cls_Struct.ActionMode.Add;
                    //colChange.DefaultValue = 1;
                    break;
            }

            dtList.Columns.Add(colMode);
            //dtList.Columns.Add(colChange);

            dsEdit.Tables.Remove("JOBDETAIL");
            dsEdit.Tables.Add(dtList);

        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("AssignDataList :" + ex.Message);
        }
    }

    //private void AssignList()
    //{
    //    try
    //    {
    //        if (dsSave.Tables.Contains("JOBDETAIL")) dsSave.Tables.Remove("JOBDETAIL");
    //        DataTable dt = dsEdit.Tables["JOBDETAIL"].Clone();
    //        dt.TableName = "JOBDETAIL";
    //        List<DataRow> listDetail = dsEdit.Tables["JOBDETAIL"].AsEnumerable().Where(r => r.Field<int>("mode") > -1 && r.Field<int>("Change") == 1).ToList();
    //        if (listDetail.Count > 0)
    //        {
    //            dt = listDetail.CopyToDataTable();
    //            dt.TableName = "JOBDETAIL";
    //        }
    //        dsSave.Tables.Add(dt);
    //    }
    //    catch (Exception ex)
    //    {
    //        XtraMessageBox.Show("AssignList :" + ex.Message);
    //    }
    //}

    private int AssigNo()
    {
      int no = 1;
      try
      {
        List<DataRow> ListNo = dsEdit.Tables["JOBDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
        if (ListNo.Count() > 0)
            no = ListNo.Count() + 1;
      }
      catch (Exception ex)
      { MessageBox.Show(ex.Message); }
      return no;
    }

    private void AssignRepositoryGrid()
    {
      try
      {
        repoSearchBrand.DataSource = cls_Global_DB.DataInitial.Tables["M_BRANDS"];
        repoSearchBrand.ValueMember = "_id";
        repoSearchBrand.DisplayMember = "name";

        repoSearchUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
        repoSearchUnit.ValueMember = "_id";
        repoSearchUnit.DisplayMember = "name";

        repoSearchItem.DataSource = cls_Global_DB.DataInitial.Tables["M_ITEMS"];
        repoSearchItem.ValueMember = "_id";
        repoSearchItem.DisplayMember = "code";

      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("AssignRepositoryGrid :" + ex.Message);
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
        if (dsEdit.Tables["JOBDETAIL"].Rows.Count > 0)
        {
          DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvDetail;
          if ((view.FocusedRowHandle < 0)) return;
          DataRow row = view.GetFocusedDataRow();
          SelectRow = gvDetail.GetSelectedRows();
          if (row == null) return;
          if (SelectRow.Length <= 1)
          {
            if (!int.TryParse(gvDetail.GetRowCellValue(SelectRow[0], "JOBD_ID").ToString(), out ID)) ID = 0; // ดึง Data จาก Rowที่เลือก
            if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            if (ID <= 0)
            {
              if (!int.TryParse(gvDetail.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
              dr = dsEdit.Tables["JOBDETAIL"].Select("LIST_NO =" + NO);
              if (dr.Count() > 0)
                  dsEdit.Tables["JOBDETAIL"].Rows.Remove(dr[0]);

              AddDataSourceToGrid();                            
              return;
            }
            if (!int.TryParse(gvDetail.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
            dr = dsEdit.Tables["JOBDETAIL"].Select("LIST_NO =" + NO);
            if (dr.Count() > 0)
            {
              dr[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
              //dr[0]["Change"] = 1;
            }
          }
          else
          {
            if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            for (int i = 0; i < SelectRow.Length; i++)
            {
              if (!int.TryParse(gvDetail.GetRowCellValue(SelectRow[i], "JOBD_ID").ToString(), out ID)) ID = 0;
              if (ID <= 0)
              {
                try
                {
                  if (!int.TryParse(gvDetail.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out ListId)) ListId = 0;
                  ListRow = dsEdit.Tables["JOBDETAIL"].Select("LIST_NO =" + ListId);
                  dsEdit.Tables["JOBDETAIL"].Rows.Remove(ListRow[0]);
                  gvDetail.FocusedRowHandle = 0;
                }
                catch { }
              }
              else
              {
                if (!int.TryParse(gvDetail.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out NO)) NO = 0;
                DataRow[] Roww = dsEdit.Tables["JOBDETAIL"].Select("LIST_NO =" + NO);
                if (Roww.Length > 0)
                {
                  Roww[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
                  //Roww[0]["Change"] = 1;
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("DeleteDataDetail :" + ex.Message);
      }
      finally
      {
        AddDataSourceToGrid();
      }
    }

    private void InitialDialog()
    {
      ThreadStart();
      LoadDefaultData();
    }

    private void InitialDialogFrom(cls_Struct.ActionMode mode)
    {
      DevExpress.XtraGrid.Views.Grid.GridView view;
      int ID = 0;
      DataRow dr;
      try
      {
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvDetail;
        if ((view.FocusedRowHandle < 0))
        {
            if (mode != cls_Struct.ActionMode.Add) return;
        }
        dr = view.GetFocusedDataRow();

        frm_JOBDetailInput frmInput = new frm_JOBDetailInput();
        frmInput.Text = "แก้ไขสินค้า";
        frmInput.SetEditData = dr;
        frmInput.SetDatasetEdit = dsEdit;
        frmInput.SetListNo = AssigNo();
        frmInput.InitialDialog(mode);

        if (frmInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          dsEdit = frmInput.SetDatasetEdit;
          AddDataSourceToGrid();
        }
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("InitialDialogFrom :" + ex.Message);
      }
    }

    private void LoadDefaultData()
    {
        try
        {
          cmbStatus.Properties.Items.Add("เปิด");
          cmbStatus.Properties.Items.Add("ปิด");
          cmbStatus.Properties.Items.Add("ยกเลิก");

          cmbStatus.SelectedIndex = 0;

          cls_Library.AssignSearchLookUp(sluType, "M_JOB_TYPES", "รหัสประเภท JOB", "ชื่อประเภท JOB", cls_Global_class.TypeShow.codename);
          cls_Library.AssignSearchLookUp(sluOperator, "M_USERS", "รหัสผู้ดำเนินการ", "ชื่อผู้ดำเนินการ",cls_Global_class.TypeShow.codename);
          cls_Library.AssignSearchLookUp(sluUseEdit, "M_USERS", "รหัสผู้ปรับปรุงข้อมูล", "ชื่อผู้ปรับปรุงข้อมูล", cls_Global_class.TypeShow.name);              
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
        }
    }

    private void SaveData()
    {
      try 
	    {
        if (DataMode == cls_Struct.ActionMode.View) return;

        AssignDataFromComponent();
        //AssignList();
        cls_Global_DB.GB_ItemID = 0;
        IsSaveOK = cls_Data.SaveJOB(DataMode, JOB, dsEdit);

        if (IsSaveOK)
        {
          XtraMessageBox.Show("บันทึกข้อมูล JOB เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
          JOBID = cls_Global_DB.GB_ItemID;
          DataMode = cls_Struct.ActionMode.Edit;
          //PIPI
          cls_Data.UpdateUnActiveVoucherByType(3);
          cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.JOB, JOBID);
          if (!_bwLoad.IsBusy)
          {
            this.UseWaitCursor = true;
            _bwLoad.RunWorkerAsync();
            this.UseWaitCursor = false;
          }   
        }
	    }
	    catch (Exception ex)
	    {
        Application.DoEvents();      
        XtraMessageBox.Show("ไม่สามารถบันทึก JOB ได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            break;
          case cls_Struct.ActionMode.Edit:
          case cls_Struct.ActionMode.View:
            btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
            dateJOB.ReadOnly = true;
            txtOpen.ReadOnly = true;
            sluOperator.ReadOnly = true;
            cmbStatus.ReadOnly = true;
            sluType.ReadOnly = true;
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
      DataRow row;
      try
      {
        dsEdit = dsMainData.Copy();
        AssignDataList();
        switch (DataMode)
        {
          case cls_Struct.ActionMode.Add:
            SetDefaultData();
            break;
          case cls_Struct.ActionMode.Edit:
          case cls_Struct.ActionMode.Copy:
          case cls_Struct.ActionMode.View:

            if (dsEdit.Tables["JOBHEAD"].Rows.Count <= 0) return;
            row = dsEdit.Tables["JOBHEAD"].Rows[0];

            if (cls_Library.DBbool(row["ACTIVE"]))
            {
                dateJOB.ReadOnly = true;
                dateJOB.BackColor = Color.FromArgb(255, 255, 192);
            }

            txtJobNo.Text = row["JOB_NO"].ToString();
            dateJOB.EditValue = cls_Library.DBDateTime(row["JOB_DATE"]);
            sluType.EditValue = cls_Library.DBInt(row["JOB_TYPE"]);
            txtOpen.Text = row["JOB_OPEN"].ToString();
            sluOperator.EditValue = cls_Library.DBInt16(row["JOB_OPERATOR"]);
            //XXXXXXXXXXXXXX
            //txtOperatorName.Text
            cmbStatus.SelectedIndex = cls_Library.DBByte(row["JOB_STATUS"]) -1;
            spinPrint.EditValue = cls_Library.DBInt16(row["PRINT_NO"]);

            //dateEdit
            sluUseEdit.EditValue = cls_Library.DBInt(row["UPDATE_BY"]);
            txtBarcode.Text = row["BARCODE"].ToString();
            break;
        }

        AddDataSourceToGrid();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show("SetDataToControl :" +ex.Message);
      }
    }

    private void SetDefaultData()
    {
      try
      {
        txtJobNo.ReadOnly = true;
        txtJobNo.BackColor = Color.FromArgb(255, 255, 192);
        dateJOB.DateTime = DateTime.Today;
        if (cls_Global_DB.DataInitial.Tables["M_JOB_TYPES"] != null)
        {
          if (cls_Global_DB.DataInitial.Tables["M_JOB_TYPES"].Rows.Count > 0)
          {
            sluType.EditValue = cls_Library.DBInt(cls_Global_DB.DataInitial.Tables["M_JOB_TYPES"].Rows[0]["_id"]);
          }
        }
        txtOpen.Text = cls_Global_class.USRnameT;
        dateEdit.EditValue = DateTime.Today;
        sluOperator.EditValue = cls_Global_class.GB_Userid;
        sluUseEdit.EditValue = cls_Global_class.GB_Userid;
        txtOpen.Text = cls_Data.GetNameFromTBname(cls_Global_class.GB_Userid, "USER", "USER_NAME");
      }
      catch (Exception ex)
      {
          XtraMessageBox.Show("SetDefaultData :" + ex.Message);
      }
    }

    private bool VerifyData()
    {
        bool ret = true;
        StringBuilder msg = new StringBuilder();
        try
        {
            if (DataMode == cls_Struct.ActionMode.View) return false;

            if (string.IsNullOrEmpty(txtJobNo.Text))
            {
                ret = false;
                msg.AppendLine("ไม่มีเลขที่เอกสาร");
            }

            if (dateJOB.EditValue == null)
            {
                ret = false;
                msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
            }
            if (sluOperator.EditValue == null)
            {
                ret = false;
                msg.AppendLine("รหัสผู้ดำเนินการไม่ถูกต้อง");
            }

            if (!ret)
            {
                MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception)
        {
        }
        return ret;
    }

    #endregion

    public frm_JobRecord(cls_Struct.ActionMode mode, int id)
    {
      InitializeComponent();
            this.KeyPreview = true;
      KeyPreview = true;
      DataMode = mode;
      JOBID = id;
      InitialDialog();
      txtJobNo.Focus();
    }

    private void btEdit_Click(object sender, EventArgs e)
    {
        InitialDialogFrom(cls_Struct.ActionMode.Edit);
    }

    private void btDelete_Click(object sender, EventArgs e)
    {
        DeleteDataDetail();
    }

    private void btChangeStatus_Click(object sender, EventArgs e)
    {
        //XXX
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      if (VerifyData())
      {
        SaveData();
        DialogResult = DialogResult.OK;
      } 
    }

    private void frm_JobRecord_Load(object sender, EventArgs e)
    {
        AssignRepositoryGrid();
        SetControl();
    }

    private void btClose_Click(object sender, EventArgs e)
    {
        if (IsSaveOK)
            DialogResult = DialogResult.OK;
        else
            DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void frm_JobRecord_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F2:
          btSave.PerformClick();
          break;
        case Keys.F7:
          btEdit.PerformClick();
          break;
        case Keys.F8:
          btDelete.PerformClick();
          break;
        case Keys.Escape:
          btClose.PerformClick();
          break;
      }
    }

    private void gvDetail_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        try
        {
            if (e.IsGetData)
            {
                switch (e.Column.FieldName)
                {
                    case "col_quan":
                        if (!Double.TryParse(gvDetail.GetListSourceRowCellValue(e.ListSourceRowIndex, "QTY").ToString(), out Zquan)) Zquan = 0;
                        if (!Double.TryParse(gvDetail.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;
                        e.Value = cls_Library.CDecimal(Zquan / Zconv);
                        break;
                }
            }
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message); }
    }
  }
}