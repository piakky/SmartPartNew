using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartPart.Class;

namespace SmartPart.Forms.Sale
{
    public partial class frm_ChooseBSTS : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDisplayDelegate();

        #region Variable
        private DataTable dtData = new DataTable();
        private DataSet dsReturn = new DataSet();
        private int CUSID = 0;
        #endregion

        #region Properties
        public DataSet DataChoose
        {
            get { return dsReturn; }
        }
        #endregion

        #region Function

        //private async void CallMethod()
        //{
        //    //Task task1 = new Task(LoadData);
        //    //task1.Start();
        //    //await Task.Run(() =>
        //    //{
        //    //    cnt = CountCharactor();
        //    //});
        //    //SetDataToControl();
        //}

        private void InitializeControl()
        {
            repoBrand.DataSource = cls_Global_DB.DataInitial.Tables["M_BRANDS"];
            repoBrand.PopulateViewColumns();
            repoBrand.View.Columns["_id"].Visible = false;
            repoBrand.View.Columns["code"].Visible = false;
            repoBrand.View.Columns["name"].Visible = false;
            repoBrand.ValueMember = "_id";
            repoBrand.DisplayMember = "name";
        }

        private void LoadData()
        {
            dtData = cls_Data.GetListBSToTS(CUSID);
        }

        private void SetDataToControl()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetDisplayDelegate(SetDataToControl));
            }
            else
            {
                gridBS.DataSource = dtData;
                gridBS.RefreshDataSource();
            }
        }
        #endregion

        public frm_ChooseBSTS(int ID)
        {
            InitializeComponent();
            KeyPreview = true;
            CUSID = ID;
        }

        private void frm_ChooseBSTS_Load(object sender, EventArgs e)
        {
            InitializeControl();
            Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
            {
                this.Invoke(new SetDisplayDelegate(SetDataToControl));
            });
        }

        private void gvBS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selectedRowHandles = gvBS_H.GetSelectedRows();
                if (selectedRowHandles.Count() <= 0) return;
                

                DataRow dr = gvBS_H.GetDataRow(selectedRowHandles[0]);
                dsReturn = cls_Data.GetBSforTS(cls_Library.DBInt(dr["BSH_ID"]));                
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("cmdOK_Click: " + ex.Message);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gvBS_L_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gvBS_L.GetFocusedDataRow();
            if (dr == null) return;

            string ItemCode = cls_Library.DBString(dr["ITEM_CODE"]);
            int ItemID = cls_Library.DBInt(cls_Data.GetNameFromTBname(ItemCode, "ITEMS", "ITEM_ID"));
            DataTable dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemID);
            if (dtUnit.Rows.Count > 0)
            {
                List<DataRow> lst = dtUnit.AsEnumerable().Where(r => r.Field<Int16>("LIST_NO") == 1).ToList();
                if (lst.Count > 0)
                {
                    //Zconv = cls_Library.DBDouble(lst[0]["MULTIPLY_QTY"]);
                }
            }
            string[] selectedColumns = new[] { "_id", "code", "name", "MULTIPLY_QTY", "codename" };
            DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
            repoUnit.DataSource = dt;
            repoUnit.PopulateViewColumns();
            repoUnit.View.Columns["_id"].Visible = false;
            repoUnit.View.Columns["codename"].Visible = false;
            repoUnit.View.Columns["code"].Caption = "รหัสหน่วยนับ";
            repoUnit.View.Columns["name"].Caption = "ชื่อหน่วยนับ";
            repoUnit.View.Columns["MULTIPLY_QTY"].Caption = "จำนวนหน่วยย่อย";

            repoUnit.ValueMember = "_id";
            //sluUnit.Properties.DisplayMember = "name";
            repoUnit.DisplayMember = "codename";
        }

        private void frm_ChooseBSTS_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    cmdOK.PerformClick();
                    break;
                case Keys.Escape:
                    cmdClose.PerformClick();
                    break;
            }
        }
    }
}