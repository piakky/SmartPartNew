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
  public partial class frm_SQRecord : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private cls_Struct.StructSQ SQ = new cls_Struct.StructSQ();
    private BackgroundWorker _bwLoad = null;
    private int SQID = 0;
    private cls_Struct.ActionMode DataMode;
    private DataSet dsMainData = new DataSet();
    private DataSet dsEdit = new DataSet();
    DataTable dtUnit = new DataTable();
    //private DataSet dsSave = new DataSet();
    private bool IsSaveOK = false;
    private double Zquan, Zconv;
    #endregion

    #region Thread
        
    #endregion

    #region Function

    private void AddDataSourceToGrid()
    {
        try
        {
            DataTable _dtGrid = new DataTable("SQDETAIL");
            _dtGrid = dsEdit.Tables["SQDETAIL"].Clone();
            dsEdit.Tables["SQDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete))
            .ToList<DataRow>().ForEach(f => _dtGrid.ImportRow(f));

            gridSQ.DataSource = _dtGrid;
            gridSQ.RefreshDataSource();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
        }
    }

    private void AssignDataFromComponent()
    {
        SQ.SQH_ID = SQID;
        SQ.SQ_NO = txtSQNo.Text.Trim();
        SQ.SQ_DATE = cls_Library.CDateTime(dateSQ.EditValue);
        SQ.SQ_STATUS = cls_Library.CByte(comboSQStatus.SelectedIndex + 1);
        SQ.CUS_ID = cls_Library.CInt(sluCus.EditValue);
        SQ.VAT_STATUS = cls_Library.CByte(comboVatStatus.SelectedIndex + 1);
        SQ.LIST_NO = dsEdit.Tables["SQDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Count();
        SQ.NOTE = txtNote.Text.Trim();
        SQ.BARCODE = txtBarcode.Text.Trim();
    }

    private void AssignDataList()
    {
        try
        {
            DataTable dtList = new DataTable();
            dtList = dsEdit.Tables["SQDETAIL"].Copy();
            dtList.TableName = "SQDETAIL";

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

            dsEdit.Tables.Remove("SQDETAIL");
            dsEdit.Tables.Add(dtList);

        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("AssignDataList :" + ex.Message);
        }
    }

    private int AssigNo()
    {
        int no = 1;
        try
        {
            List<DataRow> ListNo = dsEdit.Tables["SQDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
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

        //repoSearchUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
        //repoSearchUnit.ValueMember = "_id";
        //repoSearchUnit.DisplayMember = "name";
        string[] selectedColumns = new[] { "_id", "code", "name", "MULTIPLY_QTY", "codename" };
        DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
        //repoSearchUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
        repoSearchUnit.DataSource = dt;
        repoSearchUnit.ValueMember = "_id";
        repoSearchUnit.DisplayMember = "codename";

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
            if (dsEdit.Tables["SQDETAIL"].Rows.Count > 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSQ;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();
                SelectRow = gvSQ.GetSelectedRows();
                if (row == null) return;
                if (SelectRow.Length <= 1)
                {
                    if (!int.TryParse(gvSQ.GetRowCellValue(SelectRow[0], "SQD_ID").ToString(), out ID)) ID = 0; // ดึง Data จาก Rowที่เลือก
                    if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                    if (ID <= 0)
                    {
                        if (!int.TryParse(gvSQ.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                        dr = dsEdit.Tables["SQDETAIL"].Select("LIST_NO =" + NO);
                        if (dr.Count() > 0)
                            dsEdit.Tables["SQDETAIL"].Rows.Remove(dr[0]);

                        AddDataSourceToGrid();
                        return;
                    }
                    if (!int.TryParse(gvSQ.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                    dr = dsEdit.Tables["SQDETAIL"].Select("LIST_NO =" + NO);
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
                        if (!int.TryParse(gvSQ.GetRowCellValue(SelectRow[i], "SQD_ID").ToString(), out ID)) ID = 0;
                        if (ID <= 0)
                        {
                            try
                            {
                                if (!int.TryParse(gvSQ.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out ListId)) ListId = 0;
                                ListRow = dsEdit.Tables["SQDETAIL"].Select("LIST_NO =" + ListId);
                                dsEdit.Tables["SQDETAIL"].Rows.Remove(ListRow[0]);
                                gvSQ.FocusedRowHandle = 0;
                            }
                            catch { }
                        }
                        else
                        {
                            if (!int.TryParse(gvSQ.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out NO)) NO = 0;
                            DataRow[] Roww = dsEdit.Tables["SQDETAIL"].Select("LIST_NO =" + NO);
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
            //CalsumTotal();
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
            view = (DevExpress.XtraGrid.Views.Grid.GridView)gvSQ;
            if ((view.FocusedRowHandle < 0))
            {
                if (mode != cls_Struct.ActionMode.Add) return;
            }
            dr = view.GetFocusedDataRow();

            frm_SQDetailInput frmInput = new frm_SQDetailInput();
            frmInput.Text = "แก้ไขสินค้า";
            frmInput.SetEditData = dr;
            frmInput.SetDatasetEdit = dsEdit;
            frmInput.SetListNo = AssigNo();
            frmInput.InitialDialog(mode);
            frmInput.txtSQNo.Text = txtSQNo.Text;
            frmInput.dateSQ.EditValue = dateSQ.EditValue;
            frmInput.txtNoteH.Text = txtNote.Text;
            frmInput.txtCus.Text = sluCus.SelectedText;

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
            comboSQStatus.Properties.Items.Add("เปิด");
            comboSQStatus.Properties.Items.Add("ปิด");
            comboSQStatus.Properties.Items.Add("ยกเลิก");

            comboSQStatus.SelectedIndex = 0;

            comboVatStatus.Properties.Items.Add("Vat นอก");
            comboVatStatus.Properties.Items.Add("Vat ใน");
            comboVatStatus.Properties.Items.Add("ไม่มี Vat");
            comboVatStatus.SelectedIndex = 0;

            cls_Library.AssignSearchLookUp(sluCus, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");                
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
            IsSaveOK = cls_Data.SaveSQ(DataMode, SQ, dsEdit);
            if (IsSaveOK)
            {
                XtraMessageBox.Show("บันทึกข้อมูล Supplier Quatation เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQID = cls_Global_DB.GB_ItemID;
                DataMode = cls_Struct.ActionMode.Edit;
                //PIPI
                cls_Data.UpdateUnActiveVoucherByType(5);
                cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.SQ, SQID);
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
            XtraMessageBox.Show("ไม่สามารถบันทึก Supplier Quatation ได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dateSQ.ReadOnly = true;
                    sluCus.ReadOnly = true;
                    comboVatStatus.ReadOnly = true;
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

                  if (dsEdit.Tables["SQHEADER"].Rows.Count <= 0) return;
                  row = dsEdit.Tables["SQHEADER"].Rows[0];

                  if (cls_Library.DBbool(row["ACTIVE"]))
                  {
                      dateSQ.ReadOnly = true;
                      dateSQ.BackColor = Color.FromArgb(255, 255, 192);
                  }

                  txtSQNo.Text = row["SQ_NO"].ToString();
                  dateSQ.EditValue = cls_Library.DBDateTime(row["SQ_DATE"]);                                                
                  sluCus.EditValue = cls_Library.DBInt(row["CUS_ID"]);                        
                  comboVatStatus.SelectedIndex = cls_Library.DBByte(row["VAT_STATUS"]) - 1;
                  comboSQStatus.SelectedIndex = cls_Library.DBByte(row["SQ_STATUS"]) - 1;
                  txtNote.Text = row["NOTE"].ToString();
                  txtBarcode.Text = row["BARCODE"].ToString();
                  break;
          }
          AddDataSourceToGrid();
      }
      catch (Exception ex)
      {
          XtraMessageBox.Show("SetDataToControl :" + ex.Message);
      }
    }

    private void SetDefaultData()
    {
        //XXX
        try
        {
            txtSQNo.ReadOnly = true;
            txtSQNo.BackColor = Color.FromArgb(255, 255, 192);
            dateSQ.EditValue = DateTime.Today;                
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

            if (string.IsNullOrEmpty(txtSQNo.Text))
            {
                ret = false;
                msg.AppendLine("ไม่มีเลขที่เอกสาร");
            }

            if (dateSQ.EditValue == null)
            {
                ret = false;
                msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
            }
            if (sluCus.EditValue == null)
            {
                ret = false;
                msg.AppendLine("ข้อมูลพ่อค้าไม่ถูกต้อง");
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
        
        dsMainData = cls_Data.GetSQById(SQID);
      }
      catch (Exception ex)
      { MessageBox.Show(ex.Message); }
    }
    #endregion

    public frm_SQRecord(cls_Struct.ActionMode mode, int id)
    {
      InitializeComponent();
      KeyPreview = true;
      DataMode = mode;
      SQID = id;
      InitialDialog();
      txtSQNo.Focus();
    }

    private void frm_SQRecord_Load(object sender, EventArgs e)
    {
      dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", 0);
      AssignRepositoryGrid();
      SetControl();
    }

    private void frm_SQRecord_KeyDown(object sender, KeyEventArgs e)
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

    private void btEdit_Click(object sender, EventArgs e)
    {
        InitialDialogFrom(cls_Struct.ActionMode.Edit);
    }

    private void btDelete_Click(object sender, EventArgs e)
    {
        DeleteDataDetail();
    }

    private void btSave_Click(object sender, EventArgs e)
    {
        if (VerifyData())
        {
            SaveData();
            DialogResult = DialogResult.OK;
        }
    }

    private void btClose_Click(object sender, EventArgs e)
    {
        if (IsSaveOK)
            DialogResult = DialogResult.OK;
        else
            DialogResult = DialogResult.Cancel;
    }

    private void gvSQ_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        try
        {
            if (e.IsGetData)
            {
                switch (e.Column.FieldName)
                {
                    case "col_quan":
                        if (!Double.TryParse(gvSQ.GetListSourceRowCellValue(e.ListSourceRowIndex, "QTY").ToString(), out Zquan)) Zquan = 0;
                        if (!Double.TryParse(gvSQ.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;                            
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