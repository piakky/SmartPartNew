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

namespace SmartPart.Forms.Code
{
  public partial class frm_PriceList_List : DevExpress.XtraEditors.XtraForm
  {
    #region Variable
      private DataSet dsProduct = new DataSet();
    private DataTable dtProduct = null;
    #endregion

    #region function

    public void DeleteData()
    {
      if (dsProduct.Tables["M_PRICELIST"].Rows.Count == 0)
      {
        return;
      }
      DataRow Drow = gvPriceList.GetFocusedDataRow();
      int Id = cls_Library.DBInt(Drow["BANK_ID"]);
      string CGcode = System.Convert.ToString(Drow["ABBREVIATE_NAME"]);
      DialogResult Result = XtraMessageBox.Show("ต้องการลบรหัสธนาคาร : " + CGcode + " ใช่หรือไม่?", "ลบข้อมูล", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (Result == DialogResult.Yes)
      {
        bool OK = cls_Data.DeleteBank(Id);

        try
        {
          if (OK)
          {
            MessageBox.Show("ลบรหัสธนาคาร :  " + CGcode + " เรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!bwCode.IsBusy)
            {
              bwCode.RunWorkerAsync();
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

    private void LoadData()
    {
      dsProduct = cls_Data.GetListPriceList();
    }

    public void InitialDialogForm(cls_Struct.ActionMode mode)
    {
      frm_PriceList_Record frmInput;
      DevExpress.XtraGrid.Views.Grid.GridView view;
      DataRow dr = null;
      string strMode = String.Empty;

      frmInput = new frm_PriceList_Record(mode);
      frmInput.StartPosition = FormStartPosition.CenterParent;

      switch (mode)
      {
        case cls_Struct.ActionMode.Add:
          strMode = " [เพิ่ม]";
          break;
        case cls_Struct.ActionMode.Edit:
          strMode = " [แก้ไข]";
          break;
        case cls_Struct.ActionMode.Copy:
          strMode = " [คัดลอก]";
          break;
      }

      try
      {
        #region "Assign Lookup"
        if (dtProduct == null)
        {
          dtProduct = cls_Data.GetDataTable("M_ITEMS_PRICELIST");
        }
        

        frmInput.searchLookUpProduct.Properties.DataSource = dtProduct;
        //sLookUp.Refresh();
        frmInput.searchLookUpProduct.Properties.PopulateViewColumns();
        frmInput.searchLookUpProduct.Properties.View.Columns["_id"].Visible = false;
        frmInput.searchLookUpProduct.Properties.View.Columns["code"].Caption = "รหัสสินค้า";
        frmInput.searchLookUpProduct.Properties.View.Columns["name"].Caption = "ชื่อสินค้า";
        frmInput.searchLookUpProduct.Properties.View.Columns["brandpart"].Caption = "หมายเลขอะไหล่ผู้ผลิต";
        frmInput.searchLookUpProduct.Properties.View.Columns["Genuinpart"].Caption = "หมายเลขอะไหล่แท้";
        frmInput.searchLookUpProduct.Properties.DisplayMember = "code";
        frmInput.searchLookUpProduct.Properties.ValueMember = "_id";

        #endregion
        DataTable dtGroup = new DataTable();
        view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPriceList;
        if ((view.FocusedRowHandle < 0))
        {
          if (mode != cls_Struct.ActionMode.Add)
          {
            
            return;
          }
        }
        dr = view.GetFocusedDataRow();
        frmInput.Text = "Price List" + strMode;
        #region "XXX"
        frmInput.datePrice.DateTime = DateTime.Now;
        if (dr != null)
        {
          if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
          {
            if (mode == cls_Struct.ActionMode.Edit)
            {

              frmInput.searchLookUpProduct.EditValue = cls_Library.DBInt(dr["ITEM_ID"]);
              frmInput.TxtCode.Text = cls_Data.GetNameFromTBname(cls_Library.DBInt(dr["ITEM_ID"]), "ITEMS", "FULL_NAME");
              frmInput.TxtFullname.Text = cls_Library.DBString(dr["FULL_NAME"]);
              frmInput.TxtModel.Text = cls_Library.DBString(dr["Model"]);
              frmInput.txtGenuinPart.Text = cls_Library.DBString(dr["GENUIN_PART_ID"]);
              frmInput.txtProducerPart.Text = cls_Library.DBString(dr["BRAND_PART_ID"]);
              frmInput.spinPrice.EditValue = cls_Library.DBDecimal(dr["NEW_PRICE"]);
              frmInput.datePrice.DateTime = cls_Library.DBDateTime(dr["NEW_DATE"]);
              frmInput.Prop_Price1 = cls_Library.DBDecimal(dr["PRICE1"]);
              frmInput.Prop_Price2 = cls_Library.DBDecimal(dr["PRICE2"]);
              frmInput.Prop_Price3 = cls_Library.DBDecimal(dr["PRICE3"]);
              frmInput.Prop_Date1 = cls_Library.DBDateTime(dr["DATE1"]);
              frmInput.Prop_Date2 = cls_Library.DBDateTime(dr["DATE2"]);
              frmInput.Prop_Date3 = cls_Library.DBDateTime(dr["DATE3"]);
            }
            else
            {
              frmInput.searchLookUpProduct.EditValue = cls_Library.DBInt(dr["ITEM_ID"]);
              //frmInput.TxtCode.Text = cls_Library.DBString(dr["ITEM_CODE"]);
              frmInput.TxtFullname.Text = cls_Library.DBString(dr["FULL_NAME"]);
              frmInput.TxtModel.Text = cls_Library.DBString(dr["Model"]);
              frmInput.txtGenuinPart.Text = cls_Library.DBString(dr["GENUIN_PART_ID"]);
              frmInput.txtProducerPart.Text = cls_Library.DBString(dr["BRAND_PART_ID"]);
              frmInput.spinPrice.EditValue = cls_Library.DBDecimal(dr["NEW_PRICE"]);
              frmInput.datePrice.DateTime = DateTime.Now;
              frmInput.Prop_Price1 = cls_Library.DBDecimal(dr["PRICE1"]);
              frmInput.Prop_Price2 = cls_Library.DBDecimal(dr["PRICE2"]);
              frmInput.Prop_Price3 = cls_Library.DBDecimal(dr["PRICE3"]);
              frmInput.Prop_Date1 = cls_Library.DBDateTime(dr["DATE1"]);
              frmInput.Prop_Date2 = cls_Library.DBDateTime(dr["DATE2"]);
              frmInput.Prop_Date3 = cls_Library.DBDateTime(dr["DATE3"]);
            }
            frmInput.Prop_RowData = dr;
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
              frmInput.Prop_Codeid =  cls_Library.DBInt(dr["PRICELIST_ID"]);
              //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
              //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
            }
          }
          else
          {
            frmInput.Prop_Codeid = 0;
            DataTable dt = (DataTable)gridPriceList.DataSource;
            frmInput.Prop_RowData = dt.NewRow();
            frmInput.searchLookUpProduct.EditValue = null;
            //frmInput.TxtCode.Text = cls_Library.DBString(dr["ITEM_CODE"]);
            frmInput.TxtFullname.Text = "";
            frmInput.TxtModel.Text = "";
            frmInput.txtGenuinPart.Text = "";
            frmInput.txtProducerPart.Text = "";
            frmInput.spinPrice.EditValue = 0;
            frmInput.datePrice.DateTime = DateTime.Now;
            frmInput.Prop_Price1 = 0;
            frmInput.Prop_Price2 = 0;
            frmInput.Prop_Price3 = 0;
            frmInput.Prop_Date1 = DateTime.Now;
            frmInput.Prop_Date2 = DateTime.MinValue;
            frmInput.Prop_Date3 = DateTime.MinValue;
          }
        }
        else
        {
          DataTable dt = (DataTable)gridPriceList.DataSource;
          frmInput.Prop_RowData = dt.NewRow();
        }

        #endregion
        frmInput.MinimizeBox = false;
        frmInput.ShowInTaskbar = false;
        if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
        {
          return;
        }

        dsProduct.Tables["M_PRICELIST"].BeginInit();

        if (mode == cls_Struct.ActionMode.Add)
        {
          if ((frmInput.getLastdata != null) && (frmInput.getLastdata.Tables["M_PRICELIST"].Rows.Count == 1))
          {
            dsProduct.Tables["M_PRICELIST"].ImportRow(frmInput.getLastdata.Tables["M_PRICELIST"].Rows[0]);
          }
        }
        dsProduct.Tables["M_PRICELIST"].EndInit();
        gridPriceList.DataSource = dsProduct.Tables["M_PRICELIST"];
        gridPriceList.RefreshDataSource();
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        Application.DoEvents();
      }
    }
    #endregion

    public frm_PriceList_List()
    {
        InitializeComponent();
        if (!bwCode.IsBusy)
        {
            bwCode.RunWorkerAsync();
        }
    }

    private void bwCode_DoWork(object sender, DoWorkEventArgs e)
    {
        LoadData();
    }

    private void bwCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      gridPriceList.DataSource = dsProduct.Tables["M_PRICELIST"];
      gridPriceList.RefreshDataSource();
    }

    private void frm_Product_List_FormClosing(object sender, FormClosingEventArgs e)
    {
      Class_Library mc = new Class_Library();
      Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
      ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
    }

    private void gvPriceList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
      cls_Form.GridViewCustomDrawRowIndicator(sender, e);
    }
  }
}