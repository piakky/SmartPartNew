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

namespace SmartPart.Forms.Sale
{
    public partial class frm_HistorySO : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        int ItemID = 0;
        cls_Struct.GetHistoryRC GetHis;
        DataTable dtHistory = new DataTable();
        double QtyMark = 0;
        DataRow drows;
        private double Zquan, Zconv;
        #endregion

        #region Property
        public string ItemName
        {
            set { txtItemName.Text = value; }
        }
        #endregion

        #region Function
        private void LoadData()
        {
            try
            {
                GetHis = new cls_Struct.GetHistoryRC();
                GetHis.Customer = cls_Library.CInt(sluCus.EditValue);
                GetHis.DateFrom = cls_Library.CDateTime(dateFrom.EditValue);
                GetHis.DateTo = cls_Library.CDateTime(dateTo.EditValue);
                GetHis.HStatus = cls_Library.DBByte(comboStatus.SelectedIndex + 1);
                GetHis.Selltype = cls_Library.DBByte(comboSellType.SelectedIndex + 1);
                GetHis.ItemId = ItemID;                

                dtHistory = cls_Data.GetHistorySaleData(GetHis, cls_Global_class.GB_ShowAll);

                cls_Global_DB.DataInitial = cls_Data.GetDataInitial();

                if (cls_Global_DB.DataInitial == null)
                {
                    cls_Global_DB.DataInitial = new DataSet();
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_UNITS"));
                }
                else
                {
                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_VENDORS"))
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_VENDORS"));

                    if (!cls_Global_DB.DataInitial.Tables.Contains("M_UNITS"))
                        cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTable("M_UNITS"));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadData: " + ex.Message);
            }
        }

        private void LoadDefaultData()
        {
            try
            {
                comboStatus.Properties.Items.Add("ทุกสถานะ");
                comboStatus.Properties.Items.Add("เปิด");
                comboStatus.Properties.Items.Add("พิมพ์");
                comboStatus.Properties.Items.Add("รับ+POS");
                comboStatus.Properties.Items.Add("ยกเลิก");
                comboStatus.SelectedIndex = 0;

                comboTypedate.SelectedIndex = 0;

                //dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year,false);
                //dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);

                dateFrom.EditValue = cls_Library.GetDateLastYear();
                dateTo.EditValue = cls_Library.GetDateCurrentYear();

                comboSellType.Properties.Items.Add("ทุกประเภทการขาย");
                comboSellType.Properties.Items.Add("ขายสด");
                comboSellType.Properties.Items.Add("ขายเชื่อ");
                comboSellType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadDefaultData: " + ex.Message);
            }
        }

        private void ThreadStart()
        {
            if (!bwList.IsBusy) bwList.RunWorkerAsync();  
        }

        private void ViewData()
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            int ID = 0, RCD_ID = 0;
            try
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvHistory;
                if ((view.FocusedRowHandle < 0)) return;
                DataRow row = view.GetFocusedDataRow();

                RCD_ID = cls_Library.DBInt(row["BSD_ID"]);
                ID = cls_Library.DBInt(row["BSD_PID"]);

                //dsData = cls_Data.GetROById(ID);

                frm_BSRecord frm = new frm_BSRecord(cls_Struct.ActionMode.View, ID);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Text = "ขายสินค้า - [ดูข้อมูล]";
                frm.MinimizeBox = false;
                frm.ShowInTaskbar = false;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ViewData:" + ex.Message);
            }
        }

        #endregion

        public frm_HistorySO(int Id)
        {
            cls_Global_class.GB_ShowAll = false;
            InitializeComponent();
            this.KeyPreview = true;
            ItemID = Id;
            this.Text = "Sale History";
            LoadDefaultData();
            ThreadStart();      
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            ThreadStart();
        }

        private void bwList_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void bwList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cls_Library.AssignSearchLookUp(sluCus, "M_CUSTOMERS", "รหัสลูกค้า", "ชื่อลูกค้า");
            repoSearchCus.DataSource = cls_Global_DB.DataInitial.Tables["M_CUSTOMERS"];
            repoSearchCus.ValueMember = "_id";
            repoSearchCus.DisplayMember = "code";
            //แก้ครั้งที่ 2
            //repoSearchCus.DisplayMember = "name";

            repoSearchUnit.DataSource = cls_Global_DB.DataInitial.Tables["M_UNITS"];
            repoSearchUnit.ValueMember = "_id";
            repoSearchUnit.DisplayMember = "name";

            gridHistory.DataSource = dtHistory;
            gridHistory.RefreshDataSource();

            gridHistory.Focus();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            ViewData();
        }

        private void gvHistory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {            
        }

        private void frm_HistoryRC_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.Escape:
                this.Close();
                break;
            case Keys.F11:
                btView.PerformClick();
                break;
            }
        }

        private void comboTypedate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit item = (ComboBoxEdit)sender;
            dateFrom.Enabled = false;
            dateTo.Enabled = false;
            cls_Global_class.GB_ShowAll = false;
            switch (item.SelectedIndex)
            {
            case 0:
                //dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month, DateTime.Now.Year, false);
                //dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), DateTime.Now.Month, DateTime.Now.Year, false);
                dateFrom.EditValue = cls_Library.GetDateLastYear();
                dateTo.EditValue = cls_Library.GetDateCurrentYear();
                break;
            case 1:

                //if (DateTime.Now.Month == 1)
                //{
                //    dateFrom.EditValue = cls_Library.Date_CvDMY(1, 12, DateTime.Now.Year - 1, false);
                //    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year - 1, 12), 12, DateTime.Now.Year - 1, false);
                //}
                //else
                //{
                //    dateFrom.EditValue = cls_Library.Date_CvDMY(1, DateTime.Now.Month - 1, DateTime.Now.Year, false);
                //    dateTo.EditValue = cls_Library.Date_CvDMY(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1), DateTime.Now.Month-1, DateTime.Now.Year, false);
                //}
                cls_Global_class.GB_ShowAll = true;
                break;
            case 2:
                dateFrom.Enabled = true;
                dateTo.Enabled = true;
                break;
            }

            if (item.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void comboSellType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSellType.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync();
        }

        private void sluCus_EditValueChanged(object sender, EventArgs e)
        {
            if (sluCus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.IsEditorActive) if (!bwList.IsBusy) bwList.RunWorkerAsync(); //GetDataChoose();
        }

        private void gvHistory_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.IsGetData)
                {
                    switch (e.Column.FieldName)
                    {
                        //case "colQty":
                        //    if (!Double.TryParse(gvHistory.GetListSourceRowCellValue(e.ListSourceRowIndex, "QTY").ToString(), out Zquan)) Zquan = 0;
                        //    if (!Double.TryParse(gvHistory.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;
                        //    e.Value = cls_Library.CDecimal(Zquan / Zconv);
                        //    break;
                        //case "colQtyMark":
                        //    if (!Double.TryParse(gvHistory.GetListSourceRowCellValue(e.ListSourceRowIndex, "QTY_MARK").ToString(), out Zquan)) Zquan = 0;
                        //    if (!Double.TryParse(gvHistory.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;
                        //    e.Value = cls_Library.CDecimal(Zquan / Zconv);
                        //    break;
                        //case "colQtyReturn":
                        //    if (!Double.TryParse(gvHistory.GetListSourceRowCellValue(e.ListSourceRowIndex, "QTY_RETURN").ToString(), out Zquan)) Zquan = 0;
                        //    if (!Double.TryParse(gvHistory.GetListSourceRowCellValue(e.ListSourceRowIndex, "CONV").ToString(), out Zconv)) Zconv = 1;
                        //    e.Value = cls_Library.CDecimal(Zquan / Zconv);
                        //    break;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}