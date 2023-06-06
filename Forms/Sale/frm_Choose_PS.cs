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
    public partial class frm_Choose_PS : DevExpress.XtraEditors.XtraForm
    {
        private delegate void SetDisplayDelegate();

        #region Variable
        private DataTable dtData = new DataTable();
        private DataTable dtMAP = new DataTable();
        private decimal TotalVal;
        private DataTable dtReturn;
        private int CUSID = 0;
        private int BSID = 0;
        #endregion

        #region Properties

        public int BS_ID
        {
            set { BSID = value; }
        }

        public decimal Total
        {
            get { return TotalVal; }
        }

        public DataTable DataMap
        {
            set { dtMAP = value; }
            get { return dtReturn; }
        }
        #endregion

        #region Function

        private void CalDeposit()
        {
            try
            {
                int[] selectedRowHandles = gvPS.GetSelectedRows();
                if (selectedRowHandles.Count() <= 0) return;

                DataTable dt = dtMAP.Clone();
                DataRow dr, row;
                TotalVal = 0;
                decimal DEPOSIT_AMT = 0;
                decimal Balance = 0;
                bool ret = true;
                StringBuilder msg = new StringBuilder();

                for (int i = 0; i < selectedRowHandles.Length; i++)
                {
                    dr = gvPS.GetDataRow(selectedRowHandles[i]);
                    DEPOSIT_AMT = cls_Library.DBDecimal(dr["SUMCUT"]);
                    Balance = cls_Library.DBDecimal(dr["AMOUNT"]);
                    if (Balance <= 0)
                    {
                        ret = false;
                        msg.AppendLine("ใบมัดจำเลขที่ " + cls_Library.DBString(dr["PSH_NO"])  + "ไม่ได้ระบุยอดเงินที่ต้องการตัด");
                    }



                    if (Balance > DEPOSIT_AMT)
                    {
                        ret = false;
                        msg.AppendLine("ใบมัดจำเลขที่ " + cls_Library.DBString(dr["PSH_NO"]) + "ยอดที่ต้องการตัดมากกว่ายอดมัดจำคงค้าง");
                    }


                    if (ret)
                    {
                        TotalVal += cls_Library.DBDecimal(dr["AMOUNT"]);
                        row = dt.NewRow();
                        row["BSH_ID"] = BSID;
                        row["PSH_ID"] = cls_Library.DBInt(dr["PSH_ID"]);
                        row["AMOUNT"] = cls_Library.DBDecimal(dr["AMOUNT"]);
                        dt.Rows.Add(row);
                    }
                }
                if (!ret)
                {
                    MessageBox.Show("มีข้อผิดพลาดในการตัดยอดมัดจำ" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dtReturn = dt.Copy();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("CalDeposit : " + ex.Message);
            }
        }

        private void LoadData()
        {
            dtData = cls_Data.GetListPSToBS(CUSID);
        }

        private void SetDataToControl()
        {
            if (this.InvokeRequired)
            {
            this.BeginInvoke(new SetDisplayDelegate(SetDataToControl));
            }
            else
            {
            gridPS.DataSource = dtData;
            gridPS.RefreshDataSource();
            }
        }
        #endregion

        public frm_Choose_PS(int ID)
        {
            InitializeComponent();
                KeyPreview = true;
            CUSID = ID;
        }

        private void frm_Choose_PS_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => LoadData()).ContinueWith((pt) =>
            {
            this.Invoke(new SetDisplayDelegate(SetDataToControl));
            });
        }

        private void gvPS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            CalDeposit();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frm_Choose_PS_KeyDown(object sender, KeyEventArgs e)
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