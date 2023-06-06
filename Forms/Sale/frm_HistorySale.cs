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
    public partial class frm_HistorySale : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDelegate();

        #region Varialbe
        private DataTable dtHis = new DataTable();
        private int CusID, ItemID;
        #endregion

        #region function
        private void LoadData()
        {
            dtHis = cls_Data.GetItemSaleHistory(CusID, ItemID);
        }

        private void SetDataToControl()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SetDelegate(SetDataToControl));
            }
            else
            {
                gridHis.DataSource = dtHis;
                gridHis.RefreshDataSource();
            }
        }
        #endregion

        private void frm_HistorySale_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                       
            }
        }

        public frm_HistorySale(int cusid, int itemid)
        {
            InitializeComponent();
            KeyPreview = true;

            CusID = cusid;
            ItemID = itemid;

            Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
            {
                this.Invoke(new SetDelegate(SetDataToControl));
            });
        }
    }
}