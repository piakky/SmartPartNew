using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using SmartPart.Class;

namespace SmartPart.Forms.Sale
{
    public partial class frm_ChooseTSRSR : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDisplayDelegate();

        #region Variable
        private DataTable dtData = new DataTable();
        private DataSet dsReturn = new DataSet();
        //private string BSHno = string.Empty;
        private int TSHid = 0;
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

        #endregion

        #region Function
        private void LoadData()
        {
            dtData = cls_Data.GetListTSToRSR(CUSid);
        }

        private void SetDataToControl()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetDisplayDelegate(SetDataToControl));
            }
            else
            {
                gridTS.DataSource = dtData;
                gridTS.RefreshDataSource();
            }
        }

        #endregion

        public frm_ChooseTSRSR()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void gvTS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void frm_ChooseTSRSR_Load(object sender, EventArgs e)
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
                int[] selectedRowHandles = gvTS.GetSelectedRows();
                if (selectedRowHandles.Count() <= 0) return;

                DataRow dr = gvTS.GetDataRow(selectedRowHandles[0]);
                TSHid = cls_Library.DBInt(dr["TSH_ID"]);
                //BSHno = cls_Library.DBString(dr["BSH_NO"]);
                dsReturn = cls_Data.GetTSById(TSHid);

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

        private void frm_ChooseTSRSR_KeyDown(object sender, KeyEventArgs e)
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