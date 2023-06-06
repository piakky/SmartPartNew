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
    public partial class frm_ChooseBSRS : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDisplayDelegate();

        #region Variable
        private DataTable dtData = new DataTable();
        private DataSet dsReturn = new DataSet();
        //private string BSHno = string.Empty;
        private int BSHid = 0;
        private int CUSid = 0;
        #endregion

        #region Properties
        public DataSet DataChoose
        {
            get { return dsReturn; }
        }

        public int CUS_ID
        {
            get;
            set;
        } = 0;


        //public int IDBSH
        //{
        //    get { return BSHid; }
        //}

        //public string BSH_NO
        //{
        //    get { return BSHno; }
        //}
         #endregion

        #region Function
        private void LoadData()
        {
            dtData = cls_Data.GetListBSToETAX(CUSid);
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

        public frm_ChooseBSRS()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void frm_ChooseBSRS_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
            {
            this.Invoke(new SetDisplayDelegate(SetDataToControl));
            });
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selectedRowHandles = gvBS.GetSelectedRows();
                if (selectedRowHandles.Count() <= 0) return;                

                DataRow dr = gvBS.GetDataRow(selectedRowHandles[0]);
                BSHid = cls_Library.DBInt(dr["BSH_ID"]);
                //BSHno = cls_Library.DBString(dr["BSH_NO"]);
                dsReturn = cls_Data.GetBSById(BSHid);
        
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

        private void gvBS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void frm_ChooseBSRS_KeyDown(object sender, KeyEventArgs e)
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