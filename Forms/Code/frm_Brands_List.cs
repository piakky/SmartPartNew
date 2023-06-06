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
    public partial class frm_Brands_List : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataSet dsBrand = new DataSet();

        #endregion

        #region function

        public void DeleteData()
        {
            int[] selectRow;
            int _id = 0;
            try
            {
                DataRow row = gvBrand.GetFocusedDataRow();
                if (row == null) return;
                
                selectRow = gvBrand.GetSelectedRows();

                if (selectRow.Length <= 1)
                {
                    _id = cls_Library.ConvertToInt(row["BRAND_ID"].ToString());
                    if (cls_Data.DeleteBrand(_id))
                    {
                        dsBrand.Tables["M_BRANDS"].Rows.Remove(row);
                    }                    
                }
                else
                {
                    DataRow[] Rrow;
                    for (int i = 0; i < selectRow.Length; i++)
                    {
                        _id = cls_Library.ConvertToInt(gvBrand.GetRowCellValue(selectRow[i], "BRAND_ID").ToString());
                        if (cls_Data.DeleteProduct(_id))
                        {
                            Rrow = dsBrand.Tables["M_BRANDS"].Select("BRAND_ID = " + _id);
                            dsBrand.Tables["M_BRANDS"].Rows.Remove(Rrow[0]);
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
            dsBrand = cls_Data.GetListBrands();
        }

        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
            DataRow row = gvBrand.GetFocusedDataRow();
            int pid = 0;
            string strMode = "";

            switch (mode)
            {
            //case cls_Global_class.ActionMode.Add:
                //break;
            case cls_Struct.ActionMode.Edit:
            case cls_Struct.ActionMode.Copy:
                if (row == null) return;
                pid = cls_Library.ConvertToInt(row["BRAND_ID"].ToString());
                break;
            }

            
            frm_Brands_Record frm = new frm_Brands_Record(mode, pid);
            //frm.ItemID = pid;
            //frm.InitialDialog(mode);
            frm.ShowInTaskbar = false;
            frm.StartPosition = FormStartPosition.CenterParent;
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

            frm.Text = "ยี่ห้อสินค้า   " + strMode;

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

        public frm_Brands_List()
        {
            InitializeComponent();
            this.KeyPreview = true;
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
            gridBrand.DataSource = dsBrand.Tables["M_BRANDS"];
            gridBrand.RefreshDataSource();
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

        private void frm_Brands_List_KeyDown(object sender, KeyEventArgs e)
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
                    InitialDialogForm(cls_Struct.ActionMode.Delete);
                    break;
            }
        }
    }
}