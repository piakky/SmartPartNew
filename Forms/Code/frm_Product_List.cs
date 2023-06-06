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
using DevExpress.XtraSplashScreen;
using SmartPart.Forms.General;
using System.Threading;

namespace SmartPart.Forms.Code
{
    public partial class frm_Product_List : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataSet dsProduct = new DataSet();

        #endregion

        #region function

        public void DeleteData()
        {
            int[] selectRow;
            int _id = 0;
            try
            {
                DataRow row = gvPDT.GetFocusedDataRow();
                if (row == null) return;
                
                selectRow = gvPDT.GetSelectedRows();

                if (selectRow.Length <= 1)
                {
                    _id = cls_Library.ConvertToInt(row["ITEM_ID"].ToString());
                    if (cls_Data.DeleteProduct(_id))
                    {
                        dsProduct.Tables["M_ITEMS"].Rows.Remove(row);
                    }                    
                }
                else
                {
                    DataRow[] Rrow;
                    for (int i = 0; i < selectRow.Length; i++)
                    {
                        _id = cls_Library.ConvertToInt(gvPDT.GetRowCellValue(selectRow[i], "ITEM_ID").ToString());
                        if (cls_Data.DeleteProduct(_id))
                        {
                            Rrow = dsProduct.Tables["M_ITEMS"].Select("ITEM_ID = " + _id);
                            dsProduct.Tables["M_ITEMS"].Rows.Remove(Rrow[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DeleteData : " + ex.Message);
            }
        }

        private void LoadData()
        {
            dsProduct = cls_Data.GetListProduct();
            //cls_Global_DB.DataInitial.Clear();
            cls_Global_DB.DataInitial = cls_Data.GetDataInitial();
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            DataRow row = gvPDT.GetFocusedDataRow();
            int pid = 0;
            string strMode = "";

            switch (mode)
            {
            //case cls_Global_class.ActionMode.Add:
                //break;
            case cls_Struct.ActionMode.Edit:
            case cls_Struct.ActionMode.Copy:
                if (row == null) return;
                pid = cls_Library.ConvertToInt(row["ITEM_ID"].ToString());
                break;
            }

            
            frm_Product_Record frm = new frm_Product_Record(mode, pid);
            //frm.ItemID = pid;
            //frm.InitialDialog(mode);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Width = 1379;
            frm.Height = 850;
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

            frm.Text = "รหัสสินค้า   " + strMode;

            if (frm.ShowDialog() == DialogResult.OK)
            {
            if (!bwCode.IsBusy)
            {
                this.UseWaitCursor = true;
                bwCode.RunWorkerAsync();
            }
            this.UseWaitCursor = false;
            this.Cursor = Cursors.Default;
            }
        }
        #endregion

        public frm_Product_List()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SplashScreenManager.ShowForm(this, typeof(frm_WaitForm), true, true, false);
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(10);
            }
            if (!bwCode.IsBusy)
            {
                bwCode.RunWorkerAsync();
            }
                SplashScreenManager.CloseForm();
            }

        private void bwCode_DoWork(object sender, DoWorkEventArgs e)
        {
            
            LoadData();
            
            }

        private void bwCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            gridPd.DataSource = dsProduct.Tables["M_ITEMS"];
            gridPd.RefreshDataSource();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //InitialDialogForm(cls_Global_class.ActionMode.Edit);
        }

        private void frm_Product_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class_Library mc = new Class_Library();
            Class_Library.m_ClearInstance ClearInstance = new Class_Library.m_ClearInstance(mc.ClearInstance);
            ClearInstance(System.Convert.ToInt32(this.AccessibleDescription), ref cls_Form.GB_Instance);
        }

        private void gvPDT_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void frm_Product_List_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    InitialDialogForm(cls_Struct.ActionMode.Add);
                    break;
                case Keys.F6:
                    InitialDialogForm(cls_Struct.ActionMode.Edit);
                    break;
                case Keys.F7:
                    //InitialDialogForm(cls_Struct.ActionMode.Delete);
                    DeleteData();
                    break;
            }
        }
    }
}