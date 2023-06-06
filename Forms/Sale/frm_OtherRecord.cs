﻿using System;
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
    public partial class frm_OtherRecord : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtData = new DataTable();
        private DataTable dtEdit = new DataTable();
        private byte Vtype = 0;
        private int IdPay = 0;
        #endregion

        #region Property
        public DataTable DataTransPay
        {
            set { dtData = value; }
            get { return dtEdit; }
        }

        public int IdData
        {
            set { IdPay = value; }
        }
        #endregion

        #region Fucntion
        private void AddDataSourceToGrid()
        {
            try
            {
                DataTable _dtGrid = new DataTable();
                _dtGrid = dtEdit.Clone();
                dtEdit.AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete))
                .ToList<DataRow>().ForEach(f => _dtGrid.ImportRow(f));
                gridPay.DataSource = _dtGrid; //xx เฉพาะที่ mode != .delete
                gridPay.RefreshDataSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("AddDataSourceToGrid :" + ex.Message);
            }
        }

        private int AssigNo()
        {
            int no = 1;
            List<DataRow> ListNo = new List<DataRow>();
            try
            {
                ListNo = dtEdit.AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();

                if (ListNo.Count() > 0) no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show("AssigNo :" + ex.Message); }
            return no;
        }

        private void DeleteDataPay()
        {
            int ID = 0;
            int[] SelectRow = { };
            DataRow[] dr = null;
            try
            {
                if (dtEdit.Rows.Count > 0)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPay;
                    if ((view.FocusedRowHandle < 0)) return;
                    DataRow row = view.GetFocusedDataRow();
                    if (row == null) return;
                    SelectRow = gvPay.GetSelectedRows();
                    if (SelectRow.Length <= 1)
                    {
                        if (!int.TryParse(gvPay.GetRowCellValue(SelectRow[0], "SEQUENSE_NO").ToString(), out ID)) ID = 0; // ดึง Data จาก Rowที่เลือก
                        if (XtraMessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                        if (ID <= 0)
                        {
                            int idx = GetRowIndex();
                            row = dtEdit.Rows[idx];
                            dtEdit.Rows.Remove(row);

                            //AddDataSourceToGrid();
                            return;
                        }
                        dr = dtEdit.Select("SEQUENSE_NO" + ID);
                        if (dr.Count() > 0)
                        {
                            dr[0]["mode"] = (int)cls_Struct.ActionMode.Delete;
                            //AddDataSourceToGrid();
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
                AddDataSourceToGrid();
            }
        }

        private int GetRowIndex()
        {
            int idx = 0;

            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPay;
            if ((view.FocusedRowHandle < 0)) return 0;
            DataRow row = view.GetFocusedDataRow();

            var array1 = row.ItemArray;
            foreach (DataRow drRows in dtEdit.Rows)
            {
                var array2 = drRows.ItemArray;
                if (array1.SequenceEqual(array2))
                    break;

                idx++;
            }

            return idx;
        }

        private void InitializeControl()
        {
            dtEdit = dtData.Copy();
        }

        public void InitialDialogFrom(cls_Struct.ActionMode mode)
        {
            frm_PayInput frmInput;
            DevExpress.XtraGrid.Views.Grid.GridView view;
            DataRow dr = null;
            string strMode = String.Empty;

            frmInput = new frm_PayInput(cls_Struct.TypePay.Trans);
            frmInput.StartPosition = FormStartPosition.CenterParent;
            frmInput.layoutCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            if (mode == cls_Struct.ActionMode.Add)
                strMode = " [เพิ่ม]";
            else if (mode == cls_Struct.ActionMode.Edit)
                strMode = " [แก้ไข]";

            try
            {
                DataTable dtGroup = new DataTable();
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPay;
                if ((view.FocusedRowHandle < 0))
                {
                    if (mode != cls_Struct.ActionMode.Add) return;
                }
                dr = view.GetFocusedDataRow();

                frmInput.Text = "อื่นๆ " + strMode;

                #region "XXX"
                //frmInput.sluCode.Properties.DataSource = dtRepo;
                //frmInput.sluCode.Properties.PopulateViewColumns();
                //frmInput.sluCode.Properties.ValueMember = "_id";
                //frmInput.sluCode.Properties.DisplayMember = "code";
                //frmInput.sluCode.Properties.View.Columns["_id"].Visible = false;
                //frmInput.sluCode.Properties.View.Columns["code"].Caption = "รหัสบัญชีธนาคาร";
                //frmInput.sluCode.Properties.View.Columns["name"].Caption = "ชื่อบัญชีธนาคาร";
                //frmInput.sluCode.EditValue = null;
                if (dr != null)
                {
                    DataTable dt = (DataTable)gridPay.DataSource;
                    if ((mode == cls_Struct.ActionMode.Edit) || (mode == cls_Struct.ActionMode.Copy))
                    {
                        //frmInput.sluCode.EditValue = null;
                        //if (cls_Library.DBInt(dr["BANKS_ACCOUNT_ID"]) > 0) frmInput.sluCode.EditValue = cls_Library.DBInt(dr["BANKS_ACCOUNT_ID"]);
                        frmInput.txtName.Text = cls_Library.DBString(dr["DESCRIPTION"]);
                        frmInput.spinAmount.EditValue = cls_Library.DBDouble(dr["AMOUNT"]);
                    }
                }
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == DialogResult.Cancel) return;
                int irow = 0;
                dtEdit.BeginInit();
                if (mode == cls_Struct.ActionMode.Add)
                {
                    irow = AssigNo() - 2;

                    if (irow < 0) irow = 0;
                    DataRow row = dtEdit.NewRow();

                    row["SEQUENSE_NO"] = 0;
                    row["VOUCHER_TYPE"] = Vtype;
                    row["VOUCHER_ID"] = IdPay;
                    row["LIST_NO"] = AssigNo();
                    row["DESCRIPTION"] = frmInput.txtName.Text;
                    row["AMOUNT"] = cls_Library.CDouble(frmInput.spinAmount.EditValue);
                    row["mode"] = cls_Struct.ActionMode.Add;
                    dtEdit.Rows.Add(row);
                    gvPay.FocusedRowHandle = irow;
                }
                else
                {
                    view = (DevExpress.XtraGrid.Views.Grid.GridView)gvPay;
                    dr = view.GetFocusedDataRow();

                    int idx = GetRowIndex();
                    DataRow row = dtEdit.Rows[idx];
                    row["DESCRIPTION"] = frmInput.txtName.Text;
                    row["AMOUNT"] = cls_Library.CDouble(frmInput.spinAmount.EditValue);
                }
                dtEdit.EndInit();
                AddDataSourceToGrid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
            finally
            {
                //CheckingObject();
            }
        }

        #endregion

        public frm_OtherRecord(byte vtype)
        {
            InitializeComponent();
            KeyPreview = true;
            Vtype = vtype;
        }

        private void frm_InputOther_Load(object sender, EventArgs e)
        {
            InitializeControl();
            AddDataSourceToGrid();
        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BTcancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BTitemAdd_Click(object sender, EventArgs e)
        {
            InitialDialogFrom(cls_Struct.ActionMode.Add);
        }

        private void BTitemEdit_Click(object sender, EventArgs e)
        {
            InitialDialogFrom(cls_Struct.ActionMode.Edit);
        }

        private void BTitemDelete_Click(object sender, EventArgs e)
        {
            DeleteDataPay();
        }

        private void gvPay_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            cls_Form.GridViewCustomDrawRowIndicator(sender, e);
        }

        private void frm_OtherRecord_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    BTsave.PerformClick();
                    break;
                case Keys.Escape:
                    BTcancel.PerformClick();
                    break;
            }
        }
    }
}