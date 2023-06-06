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
  public partial class frm_PORecord : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
    private cls_Struct.StructPO PO = new cls_Struct.StructPO();
    private BackgroundWorker _bwLoad = null;
    private int POID = 0;
    private cls_Struct.ActionMode DataMode;
    private DataSet dsMainData = new DataSet();
    private DataSet dsEdit = new DataSet();
    //private DataSet dsSave = new DataSet();
    private bool IsSaveOK = false;

    double SumQty = 0;
    decimal SumCog = 0, SumVat = 0, SumNet = 0;
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
            dsMainData = cls_Data.GetPOById(POID);
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
            DataTable _dtGrid = new DataTable("PODETAIL");
            _dtGrid = dsEdit.Tables["PODETAIL"].Clone();
            dsEdit.Tables["PODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete))
            .ToList<DataRow>().ForEach(f => _dtGrid.ImportRow(f));

            gridPO.DataSource = _dtGrid;
            gridPO.RefreshDataSource();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
        }
    }

    private void AssignDataFromComponent()
    {
      PO.POH_ID = POID;
      PO.PO_NO = txtPONo.Text.Trim();
      PO.PO_DATE = cls_Library.DBDateTime(datePO.EditValue);
      PO.CUS_ID = cls_Library.DBInt(sluCus.EditValue);
      PO.BILLER = cls_Library.DBInt(sluBiller.EditValue);
      PO.PRINT_NO = cls_Library.CByte(spinPrint.EditValue);
      PO.LIST_NO = dsEdit.Tables["PODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).Count();
      PO.PO_TYPE = cls_Library.CByte(radioPOtype.SelectedIndex);
      PO.METHOD_ORDER = cls_Library.DBInt(sluOrder.EditValue);
      PO.METHOD_TRANS = cls_Library.DBInt(sluTrans.EditValue);
      PO.DUETYPE = cls_Library.CByte(radioDueType.SelectedIndex);
      if (PO.DUETYPE == 0)
      {
        PO.DUEDATE = PO.PO_DATE;
      }
      else
      {
        if (cls_Library.IsDate(dateDue.EditValue))
        {
          PO.DUEDATE = cls_Library.DBDateTime(dateDue.EditValue);
        }
        else
        {
          PO.DUEDATE = PO.PO_DATE;
        }
      }
      
      PO.PO_STATUS = cls_Library.CByte(radioPOstatus.SelectedIndex + 1);
      PO.BARCODE = txtBarcode.Text.Trim();
      PO.SUMCOG = SumCog;
      PO.VATSUM = SumVat;
      PO.DISCLST = 0; //ใบนี้ไม่มีส่วนลด แต่เพิ่มฟิลด์ไว้แล้ว
      PO.NETSUM = SumNet;
    }

    private void AssignDataList()
    {
        try
        {
            DataTable dtList = new DataTable();
            dtList = dsEdit.Tables["PODETAIL"].Copy();
            dtList.TableName = "PODETAIL";

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

            dsEdit.Tables.Remove("PODETAIL");
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
    //        if (dsSave.Tables.Contains("PODETAIL")) dsSave.Tables.Remove("PODETAIL");
    //        DataTable dt = dsEdit.Tables["PODETAIL"].Clone();
    //        dt.TableName = "PODETAIL";
    //        List<DataRow> listDetail = dsEdit.Tables["PODETAIL"].AsEnumerable().Where(r => r.Field<int>("mode") > -1 && r.Field<int>("Change") == 1).ToList();
    //        if (listDetail.Count > 0)
    //        {
    //            dt = listDetail.CopyToDataTable();
    //            dt.TableName = "PODETAIL";
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
            List<DataRow> ListNo = dsEdit.Tables["PODETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
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
            repoVatStatus.Items.Add("Vat นอก"); //XXXX
            repoVatStatus.Items.Add("Vat ใน");
            repoVatStatus.Items.Add("ไม่มี Vat");

            repoSearchBrand.DataSource = cls_Global_DB.DataInitial.Tables["M_BRANDS"];
            repoSearchBrand.ValueMember = "_id";
            repoSearchBrand.DisplayMember = "name";

            repoSearchUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
            repoSearchUnit.ValueMember = "_id";
            repoSearchUnit.DisplayMember = "name";

            repoSearchItem.DataSource = cls_Global_DB.DataInitial.Tables["M_ITEMS"];
            repoSearchItem.ValueMember = "_id";
            repoSearchItem.DisplayMember = "code";

            repoSearchSpecials.DataSource = cls_Global_DB.DataInitial.Tables["M_SPECIALS"];
            repoSearchSpecials.ValueMember = "_id";
            repoSearchSpecials.DisplayMember = "name";

        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("AssignRepositoryGrid :" + ex.Message);
        }
    }

    private void DeleteDataDetail()
    {
        int ID = 0, NO =0;
        int ListId = 0;
        int[] SelectRow = { };
        DataRow[] dr = null;
        DataRow[] ListRow = null;
        try
        {
            if (dsEdit.Tables["PODETAIL"].Rows.Count > 0)
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPO;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();
                SelectRow = gvPO.GetSelectedRows();
                if (row == null) return;
                if (SelectRow.Length <= 1)
                {
                    if (!int.TryParse(gvPO.GetRowCellValue(SelectRow[0], "POD_ID").ToString(), out ID)) ID = 0; // ดึง Data จาก Rowที่เลือก
                    if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                    if (ID <= 0)
                    {
                        if (!int.TryParse(gvPO.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                        dr = dsEdit.Tables["PODETAIL"].Select("LIST_NO =" + NO);
                        if (dr.Count() > 0)
                            dsEdit.Tables["PODETAIL"].Rows.Remove(dr[0]);

                        AddDataSourceToGrid();
                        CalsumTotal();
                        return;
                    }
                    if (!int.TryParse(gvPO.GetRowCellValue(SelectRow[0], "LIST_NO").ToString(), out NO)) NO = 0;
                    dr = dsEdit.Tables["PODETAIL"].Select("LIST_NO =" + NO);
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
                        if (!int.TryParse(gvPO.GetRowCellValue(SelectRow[i], "POD_ID").ToString(), out ID)) ID = 0;
                        if (ID <= 0)
                        {
                            try
                            {
                                if (!int.TryParse(gvPO.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out ListId)) ListId = 0;
                                ListRow = dsEdit.Tables["PODETAIL"].Select("LIST_NO =" + ListId);
                                dsEdit.Tables["PODETAIL"].Rows.Remove(ListRow[0]);
                                gvPO.FocusedRowHandle = 0;
                            }
                            catch { }
                        }
                        else
                        {
                            if (!int.TryParse(gvPO.GetRowCellValue(SelectRow[i], "LIST_NO").ToString(), out NO)) NO = 0;
                            DataRow[] Roww = dsEdit.Tables["PODETAIL"].Select("LIST_NO =" + NO);
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
            CalsumTotal();
            AddDataSourceToGrid();
        }
    }

    private void CalsumTotal()
    {            
        try
        {
            List<DataRow> listRow = dsEdit.Tables["PODETAIL"].AsEnumerable().Where(item => !item.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
            SumQty = listRow.AsEnumerable().Sum(x => x.Field<double?>("QTY") ?? 0);
            SumCog = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("COG") ?? 0);
            SumVat = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICEVAT") ?? 0);
            SumNet = listRow.AsEnumerable().Sum(x => x.Field<decimal?>("PRICESUM") ?? 0);

            spinSumQTY.EditValue = SumQty;
            spinSumPrice.EditValue = SumCog;
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("CalsumTotal :" + ex.Message);
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
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPO;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != cls_Struct.ActionMode.Add) return;
        }
        dr = view.GetFocusedDataRow();

        frm_PODetailInput frmInput = new frm_PODetailInput();
        frmInput.Text = "แก้ไขสินค้า";
        frmInput.SetEditData = dr;
        frmInput.SetDatasetEdit = dsEdit;
        frmInput.SetListNo = AssigNo();
        frmInput.InitialDialog(mode);

        if (frmInput.ShowDialog() == DialogResult.OK)
        {
          dsEdit = frmInput.SetDatasetEdit;
          CalsumTotal();
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
            cls_Library.AssignSearchLookUp(sluCus, "M_VENDORS", "รหัสพ่อค้า", "ชื่อพ่อค้า");
            cls_Library.AssignSearchLookUp(sluBiller, "M_USERS", "รหัสผู้เปิดบิล", "ชื่อผู้เปิดบิล", cls_Global_class.TypeShow.codename);
                
            if (!cls_Global_DB.DataInitial.Tables.Contains("M_CONTACTS"))                
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_CONTACTS"));

            if (!cls_Global_DB.DataInitial.Tables.Contains("M_TRANSPORTS"))
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_TRANSPORTS"));

            cls_Library.AssignSearchLookUp(sluOrder, "M_CONTACTS", "รหัสวิธีการสั่งซื้อ", "ชื่อวิธีการสั่งซื้อ", cls_Global_class.TypeShow.name);
            cls_Library.AssignSearchLookUp(sluTrans, "M_TRANSPORTS", "รหัสวิธีการจัดส่ง", "ชื่อวิธีการจัดส่ง", cls_Global_class.TypeShow.name);                
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
        IsSaveOK = cls_Data.SavePO(DataMode, PO, dsEdit);
        if (IsSaveOK)
        {
          XtraMessageBox.Show("บันทึกข้อมูลใบสั่งซื้อเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
          POID = cls_Global_DB.GB_ItemID;
          DataMode = cls_Struct.ActionMode.Edit;
          //PIPI
          cls_Data.UpdateUnActiveVoucherByType(1);
          cls_Data.UpdateActiveVoucher(cls_Struct.VoucherType.PO, POID);
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
        XtraMessageBox.Show("ไม่สามารถบันทึกใบสั่งซื้อได้" + Environment.NewLine + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    radioPOstatus.SelectedIndex = 0;
                    radioDueType.SelectedIndex = 0;
                    break;
                case cls_Struct.ActionMode.Edit:
                case cls_Struct.ActionMode.View:
                    btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
                    datePO.ReadOnly = true;
                    sluBiller.ReadOnly = true;
                    sluCus.ReadOnly = true; 
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

                    if (dsEdit.Tables["POHEADER"].Rows.Count <= 0) return;
                    row = dsEdit.Tables["POHEADER"].Rows[0];

                    if (cls_Library.DBbool(row["ACTIVE"]))
                    {
                        datePO.ReadOnly = true;
                        datePO.BackColor = Color.FromArgb(255, 255, 192);
                    }

                    radioPOtype.SelectedIndex = cls_Library.DBByte(row["PO_TYPE"]);
                    sluCus.EditValue = cls_Library.DBInt(row["CUS_ID"]);
                    sluOrder.EditValue = cls_Library.DBInt(row["METHOD_ORDER"]);
                    sluTrans.EditValue = cls_Library.DBInt(row["METHOD_TRANS"]);
                    radioDueType.SelectedIndex = cls_Library.DBByte(row["DUETYPE"]);
                    dateDue.EditValue = cls_Library.DBDateTime(row["DUEDATE"]);
                    txtPONo.Text = row["PO_NO"].ToString();
                    datePO.EditValue = cls_Library.DBDateTime(row["PO_DATE"]);
                    sluBiller.EditValue = cls_Library.DBInt(row["BILLER"]);
                    spinPrint.EditValue = cls_Library.DBByte(row["PRINT_NO"]);
                    radioPOstatus.SelectedIndex = cls_Library.DBByte(row["PO_STATUS"]) - 1;
                    txtBarcode.Text = row["BARCODE"].ToString();

                    CalsumTotal();
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
            txtPONo.ReadOnly = true;
            txtPONo.BackColor = Color.FromArgb(255, 255, 192);
            datePO.EditValue = DateTime.Today;
            radioPOstatus.SelectedIndex = 0;
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

        if (string.IsNullOrEmpty(txtPONo.Text))
        {
            ret = false;
            msg.AppendLine("ไม่มีเลขที่เอกสาร");
        }
        if (radioDueType.SelectedIndex == 1)
        {
          if (!cls_Library.IsDate(datePO.EditValue))
          {
            ret = false;
            msg.AppendLine("วันที่เอกสารไม่ถูกต้อง");
          }
        }
        
        if (sluCus.EditValue == null)
        {
            ret = false;
            msg.AppendLine("ข้อมูลพ่อค้าไม่ถูกต้อง");
        }
                
        if (sluBiller.EditValue == null)
        {
            ret = false;
            msg.AppendLine("ข้อมูลผู้เปิดบิลไม่ถูกต้อง");
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

    public frm_PORecord(cls_Struct.ActionMode mode, int id)
    {
        InitializeComponent();
        KeyPreview = true;
        DataMode = mode;
        POID = id;
        InitialDialog();
        txtPONo.Focus();

    }

    private void btItemEdit_Click(object sender, EventArgs e)
    {
        InitialDialogFrom(cls_Struct.ActionMode.Edit);
    }

    private void btItemDelete_Click(object sender, EventArgs e)
    {
        DeleteDataDetail();
    }

    private void btSave_Click(object sender, EventArgs e)
    {
      if(VerifyData())
      {
        SaveData();
        this.DialogResult = DialogResult.OK;
      }
        
    }

    private void frm_PORecord_Load(object sender, EventArgs e)
    {
        AssignRepositoryGrid();
        SetControl();
    }

    private void frm_PORecord_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F2:
          btSave.PerformClick();
          break;
        case Keys.F7:
          btItemEdit.PerformClick();
          break;
        case Keys.F8:
          btItemDelete.PerformClick();
          break;
        case Keys.Escape:
          btClose.PerformClick();
          break;
      }
    }

    private void radioDueType_SelectedIndexChanged(object sender, EventArgs e)
    {
        dateDue.Visible = radioDueType.SelectedIndex == 1;
    }

    private void btClose_Click(object sender, EventArgs e)
    {
        if (IsSaveOK)
            DialogResult = DialogResult.OK;
        else
            DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void gvPO_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        try
        {
            if (e.IsGetData)
            {
                switch (e.Column.FieldName)
                {
                    case "col_quan":
                        if (!Double.TryParse(gvPO.GetListSourceRowCellValue(e.ListSourceRowIndex, "QTY").ToString(), out Zquan)) Zquan = 0;
                        if (!Double.TryParse(gvPO.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;
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