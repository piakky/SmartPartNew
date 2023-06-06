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
using SmartPart.Forms.Code;

namespace SmartPart.Forms.General
{
    public partial class frm_ItemEdit7 : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataTable dtData = new DataTable();
        DataTable DTstatus;
        //private DataTable dtSave;
        private int ItemID = 0;
        #endregion

        #region Function

        public void InitialDialogAlternate(int mode)
        {
            frmD_AlternateInput frmInput;
            DevExpress.XtraGrid.Views.Grid.GridView view;
            DataRow dr = null;
            string strMode = String.Empty;

            int Xmode = 0;
            if (mode == 2)
            {
                Xmode = 0;
            }
            else
            {
                Xmode = mode;
            }

            frmInput = new frmD_AlternateInput();
            frmInput.StartPosition = FormStartPosition.CenterParent;

            if (mode == 0)
                strMode = " [เพิ่ม]";
            else if (mode == 1)
                strMode = " [แก้ไข]";


            try
            {
                DataTable dtGroup = new DataTable();
                view = (DevExpress.XtraGrid.Views.Grid.GridView)gvAlternate;
                if ((view.FocusedRowHandle < 0))
                {
                    if (mode != 0)
                    {
                        return;
                    }
                }
                dr = view.GetFocusedDataRow();
                frmInput.Text = "หมายเลขอะไหล่" + strMode;
                #region "XXX"
                if (dr != null)
                {
                    if ((mode == 1) || (mode == 2))
                    {
                        if (mode == 1)
                        {
                            frmInput.TxtAlternatePart.Text = cls_Library.DBString(dr["PART_ID"]);
                            frmInput.TxtAlternateBrand.Text = cls_Library.DBString(dr["BRAND_DESCRIPTION"]);
                            frmInput.radioAlternateStatus.SelectedIndex = cls_Library.DBInt(dr["STATUS"]) - 1;
                        }
                        else
                        {
                            DataTable dt = (DataTable)gridAlternate.DataSource;
                            frmInput.TxtAlternatePart.Text = "";
                            frmInput.TxtAlternateBrand.Text = "";
                            frmInput.radioAlternateStatus.SelectedIndex = 0;
                        }
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
                            //frmInput.txtNameT.Text = cls_Library.DBString(dr["Dep_NameT"]);
                            //frmInput.txtNameE.Text = cls_Library.DBString(dr["Dep_NameE"]);
                        }
                    }
                    else
                    {
                        DataTable dt = (DataTable)gridAlternate.DataSource;
                    }
                }
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                dtData.BeginInit();
                if (Xmode == 0)
                {
                    DataTable dtv = (DataTable)gridAlternate.DataSource;
                    DataTable dt = dtv.Clone();
                    dt.Rows.Add();
                    dt.Rows[0]["mode"] = 1;
                    dt.Rows[0]["PART_ID"] = cls_Library.DBString(frmInput.TxtAlternatePart.Text.Trim());
                    dt.Rows[0]["BRAND_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtAlternateBrand.Text.Trim());
                    dt.Rows[0]["STATUS"] = (frmInput.radioAlternateStatus.SelectedIndex) + 1;
                    dtData.ImportRow(dt.Rows[0]);
                }
                else
                {
                    view = (DevExpress.XtraGrid.Views.Grid.GridView)gvAlternate;
                    dr = view.GetFocusedDataRow();
                    dr["mode"] = 2;
                    dr["PART_ID"] = cls_Library.DBString(frmInput.TxtAlternatePart.Text.Trim());
                    dr["BRAND_DESCRIPTION"] = cls_Library.DBString(frmInput.TxtAlternateBrand.Text.Trim());
                    dr["STATUS"] = (frmInput.radioAlternateStatus.SelectedIndex) + 1;
                }
                dtData.EndInit();                
                gridAlternate.DataSource = dtData;
                gridAlternate.RefreshDataSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        private void SaveData()
        {
            try
            {
                if (cls_Data.SaveProductEdit(cls_Struct.TypeEditItem.T7, ItemID, dtData))
                {
                    XtraMessageBox.Show("แก้ไขข้อมูลรหัสสินค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("แก้ไขข้อมูลรหัสสินค้าไม่สำเร็จ กรุณาบันทึกใหม่", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SaveData: " + ex.Message);
            }
        }

        private void SetDataToControl()
        {
            cls_Global_DB.GB_DitemPart_count = dtData.Rows.Count;
            gridAlternate.DataSource = dtData;
            gridAlternate.RefreshDataSource();

            r_status.DataSource = DTstatus;
            r_status.PopulateColumns();
            r_status.Columns["Status"].Caption = "สถานะ";
            r_status.Columns["Status_Name"].Caption = "สถานะ";
            r_status.ValueMember = "Status";
            r_status.DisplayMember = "Status_Name";
        }

        private void ThreadStart()
        {
            if (!bwItem.IsBusy) bwItem.RunWorkerAsync();
        }
        #endregion

        public frm_ItemEdit7(int Id)
        {
            ItemID = Id;
            InitializeComponent();
            this.KeyPreview = true;
            ThreadStart();
        }

        private void bwItem_DoWork(object sender, DoWorkEventArgs e)
        {
            dtData = cls_Data.GetDataItemByType(cls_Struct.TypeEditItem.T7, ItemID);
            DTstatus = new DataTable("Status");
            DTstatus.Columns.Add("Status", typeof(int));
            DTstatus.Columns.Add("Status_Name", typeof(string));
            for (int i = 0; i < 4; i++)
            {
                DTstatus.Rows.Add();
                switch (i)
                {
                    case 0:
                    DTstatus.Rows[i]["Status"] = 1;
                    DTstatus.Rows[i]["Status_Name"] = "ไม่กำหนด";
                    break;
                    case 1:
                    DTstatus.Rows[i]["Status"] = 2;
                    DTstatus.Rows[i]["Status_Name"] = "เปลี่ยนเบอร์ใหม่";
                    break;
                    case 2:
                    DTstatus.Rows[i]["Status"] = 3;
                    DTstatus.Rows[i]["Status_Name"] = "พอใช้แทนกันได้";
                    break;
                    case 3:
                    DTstatus.Rows[i]["Status"] = 4;
                    DTstatus.Rows[i]["Status_Name"] = "ใช้แทนเบอร์เก่าได้";
                    break;
                }
            }
        }

        private void bwItem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetDataToControl();
        }

        private void btPartAdd_Click(object sender, EventArgs e)
        {
            InitialDialogAlternate(0);
        }

        private void btPartEdit_Click(object sender, EventArgs e)
        {
            InitialDialogAlternate(1);
        }

        private void btPartDelete_Click(object sender, EventArgs e)
        {
            DataRow Drow = gvAlternate.GetFocusedDataRow();
            if (Drow == null) return;
            int irow = gvAlternate.FocusedRowHandle;
            DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                dtData.AcceptChanges();
                dtData.Rows[irow].Delete();
                Drow.Delete();
                dtData.AcceptChanges();
                gvAlternate.RefreshData();
                gridAlternate.RefreshDataSource();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveData();
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void frm_ItemEdit7_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btSave_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void frm_ItemEdit7_InputLanguageChanging(object sender, InputLanguageChangingEventArgs e)
        {

        }
    }
}