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
using System.Data.SqlClient;

namespace SmartPart.Forms.General
{
    public partial class frm_PJDetailInput : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private bool IsSaveOK = false;

        cls_Struct.ActionMode DataMode;
        DataSet dsEdit = new DataSet();
        DataRow EditData = null;
        int IdNo = 0, ListNo;

        #endregion

        #region Property

        public DataSet SetDatasetEdit
        {
            set { dsEdit = value; }
            get { return dsEdit; }
        }

        public DataRow SetEditData
        {
            set { EditData = value; }
        }

        public int SetListNo
        {
            set { ListNo = value; }
        }

        public int DataID
        {
            set { IdNo = value; }
        }

        #endregion

        #region Function

        private int AssigNo()
        {
            int no = 1;
            List<DataRow> ListNo = new List<DataRow>();
            try
            {
                if (DataMode != cls_Struct.ActionMode.Add)
                {
                    ListNo = dsEdit.Tables["PJOBDETAIL"].AsEnumerable().Where(r => !r.Field<int>("mode").Equals((int)cls_Struct.ActionMode.Delete)).ToList();
                }
                else
                {
                    ListNo = dsEdit.Tables["PJOBDETAIL"].AsEnumerable().ToList();
                }

                if (ListNo.Count() > 0)
                    no = ListNo.Count() + 1;
            }
            catch (Exception ex)
            { MessageBox.Show("AssigNo :" + ex.Message); }
            return no;
        }

        private void ClearData()
        {
            DataMode = cls_Struct.ActionMode.Add;
            //spinListNo.EditValue
            sluItem.EditValue = 0;
            txtFullName.Text = "";
            txtGenuinPartId.Text = "";
            txtBrandPartId.Text = "";
            txtModel1.Text = "";
            sluBrand.EditValue = 0;
            sluLocation.EditValue = 0;
            spinQTY.EditValue = 0;
            sluUnit.EditValue = 0;

            ListNo = AssigNo();
        }

        private void EditRowData()
        {
            int idx = 0;
            try
            {
                var array1 = EditData.ItemArray;
                foreach (DataRow drRows in dsEdit.Tables["PJOBDETAIL"].Rows)
                {
                    var array2 = drRows.ItemArray;
                    if (array1.SequenceEqual(array2))
                        break;

                    idx++;
                }
                DataRow row = dsEdit.Tables["PJOBDETAIL"].Rows[idx];

                row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                row["BRAND_PART_ID"] = txtBrandPartId.Text;
                row["FULL_NAME"] = txtFullName.Text;
                row["MODEL1"] = txtModel1.Text;
                row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                row["STOCK"] = sluLocation.EditValue.ToString();
                row["QTY"] = cls_Library.DBInt(spinQTY.EditValue);
                row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);

                row["mode"] = DataMode;
                //row["Change"] = 1;

                dsEdit.Tables["PJOBDETAIL"].AcceptChanges();
                EditData.ItemArray = row.ItemArray;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("EditRowData :" + ex.Message);
                IsSaveOK = false;
            }
        }

        public void InitialDialog(cls_Struct.ActionMode mode)
        {
            try
            {
                DataMode = mode;
                if (DataMode == cls_Struct.ActionMode.Copy) DataMode = cls_Struct.ActionMode.Add;
                LoadDefaultData();
                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                        sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = EditData["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                        txtModel1.Text = EditData["MODEL1"].ToString();
                        sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                        sluLocation.EditValue = //EditData["STOCK"].ToString();
                        spinQTY.EditValue = cls_Library.DBInt(EditData["QTY"]);
                        break;
                    case cls_Struct.ActionMode.Edit:
                        if (EditData == null) return;
                        //spinListNo.EditValue = ;      //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXsssss
                        IdNo = cls_Library.DBInt(EditData["JOBD_ID"]);
                        sluItem.EditValue = cls_Library.DBInt(EditData["ITEM_ID"]);
                        SetUnit(cls_Library.CInt(sluItem.EditValue));
                        txtFullName.Text = EditData["FULL_NAME"].ToString();
                        txtGenuinPartId.Text = EditData["GENUIN_PART_ID"].ToString();
                        txtBrandPartId.Text = EditData["BRAND_PART_ID"].ToString();
                        txtModel1.Text = EditData["MODEL1"].ToString();
                        sluBrand.EditValue = cls_Library.DBInt(EditData["BRAND_ID"]).ToString();
                        sluLocation.EditValue = EditData["STOCK"].ToString();
                        spinQTY.EditValue = cls_Library.DBInt(EditData["QTY"]);
                        sluUnit.EditValue = cls_Library.DBInt(EditData["UNIT_ID"]);
                        break;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("InitialDialog :" + ex.Message);
            }
        }

        private void LoadDefaultData()
        {
            try
            {
                cls_Library.AssignSearchLookUp(sluItem, "M_ITEMS", "รหัสสินค้า", "ชื่อสินค้า");
                cls_Library.AssignSearchLookUp(sluBrand, "M_BRANDS", "รหัสยี่ห้อ", "ชื่อยี่ห้อ");
                //cls_Library.AssignSearchLookUp(sluUnit, "M_UNITS", "รหัสหน่วยนับ", "ชื่อหน่วยนับ");                

                SetControl();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("LoadDefaultData :" + ex.Message);
            }
        }

        private void SaveData()
        {
            try
            {
                if (DataMode == cls_Struct.ActionMode.View) return;

                IsSaveOK = true;
                if (DataMode != cls_Struct.ActionMode.Add)
                {
                    EditRowData();
                }
                else
                {
                    DataTable dt = dsEdit.Tables["PJOBDETAIL"].Clone();
                    DataColumn colMode = new DataColumn("mode", typeof(int));
                    dt.Columns.Add(colMode);
                    ListNo = AssigNo();
                    DataRow row = dt.NewRow();
                    row["JOBD_ID"] = -1;
                    row["JOBD_PID"] = IdNo;
                    row["LIST_NO"] = ListNo;
                    row["ITEM_ID"] = cls_Library.DBInt(sluItem.EditValue);
                    row["GENUIN_PART_ID"] = txtGenuinPartId.Text;
                    row["BRAND_PART_ID"] = txtBrandPartId.Text;
                    row["FULL_NAME"] = txtFullName.Text;
                    row["MODEL1"] = txtModel1.Text;
                    row["BRAND_ID"] = cls_Library.DBInt(sluBrand.EditValue);
                    row["STOCK"] = sluLocation.EditValue.ToString();
                    row["QTY"] = cls_Library.DBInt(spinQTY.EditValue);
                    row["UNIT_ID"] = cls_Library.DBInt(sluUnit.EditValue);

                    row["mode"] = DataMode;

                    dt.Rows.Add(row);
                    dsEdit.Tables["PJOBDETAIL"].ImportRow(row);

                    SaveNewDetail(dt);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SaveData :" + ex.Message);
                IsSaveOK = false;
            }
            finally
            {
                if (IsSaveOK) btClose_Click(null, null);
            }
        }

        private void SaveNewDetail(DataTable dt)
        {
            SqlConnection conn = new SqlConnection();
            SqlTransaction tran = null;
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();
            try
            {
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    if (cls_Data.SavePJOBDetail(IdNo, dt, ref conn, ref tran))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            sb.Clear();
                            sb.AppendLine("UPDATE PJOBHEAD WITH (UPDLOCK) SET");
                            sb.AppendLine("LIST_NO = @LIST_NO,");
                            sb.AppendLine("UPDATE_BY = @UPDATE_BY,");
                            sb.AppendLine("UPDATE_DATE = @UPDATE_DATE");
                            sb.AppendLine("WHERE JOB_ID = @JOB_ID");

                            cmd.CommandText = sb.ToString();
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();
                            cmd.Transaction = tran;

                            cmd.Parameters.Add("@LIST_NO", SqlDbType.Int).Value = dsEdit.Tables["PJOBDETAIL"].AsEnumerable().Count();
                            cmd.Parameters.Add("@UPDATE_BY", SqlDbType.Int).Value = cls_Global_class.GB_Userid;
                            cmd.Parameters.Add("@UPDATE_DATE", SqlDbType.DateTime).Value = DateTime.Now;
                            cmd.Parameters.Add("@JOB_ID", SqlDbType.Int).Value = IdNo;

                            cmd.ExecuteNonQuery();
                            tran.Commit();
                            XtraMessageBox.Show("บันทึกรายการ Packing JOB เรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        tran.Rollback();
                        //Remove List
                        DataRow[] dr = dsEdit.Tables["PJOBDETAIL"].Select("LIST_NO =" + ListNo);
                        if (dr.Count() > 0)
                            dsEdit.Tables["PJOBDETAIL"].Rows.Remove(dr[0]);
                    }

                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //Remove List
                DataRow[] dr = dsEdit.Tables["PJOBDETAIL"].Select("LIST_NO =" + ListNo);
                if (dr.Count() > 0)
                    dsEdit.Tables["PJOBDETAIL"].Rows.Remove(dr[0]);
                XtraMessageBox.Show("SaveNewDetail :" + ex.Message);
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn); conn.Dispose();
            }
        }

        private void SetControl()
        {
            try
            {
                sluItem.ReadOnly = true;
                switch (DataMode)
                {
                    case cls_Struct.ActionMode.Add:
                        break;
                    case cls_Struct.ActionMode.Edit:
                    case cls_Struct.ActionMode.View:
                        btSave.Visible = DataMode == cls_Struct.ActionMode.Edit;
                        txtFullName.ReadOnly = true;
                        txtGenuinPartId.ReadOnly = true;
                        txtBrandPartId.ReadOnly = true;
                        txtModel1.ReadOnly = true;
                        sluBrand.ReadOnly = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetControl :" + ex.Message);
            }
        }

        private void SetLocation()
        {
            try
            {
                DataTable dtLocation = cls_Data.GetDataTable("D_ITEM_LOCATIONS", cls_Library.DBInt(sluItem.EditValue));
                sluLocation.Properties.DataSource = dtLocation;
                sluLocation.Properties.PopulateViewColumns();
                sluLocation.Properties.ValueMember = "name";
                sluLocation.Properties.DisplayMember = "name";
                sluLocation.Properties.View.Columns["_id"].Visible = false;
                sluLocation.Properties.View.Columns["name"].Caption = "ชื่อคลังสินค้าา";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetLocation :" + ex.Message);
            }
        }

        private void SetUnit(int ItemId)
        {
            try
            {
                DataTable dtUnit = cls_Data.GetDataTable("D_ITEM_UNITS", ItemId);
                if (dtUnit.Rows.Count > 0)
                {
                    List<DataRow> lst = dtUnit.AsEnumerable().Where(r => r.Field<Int16>("LIST_NO") == 1).ToList();
                    if (lst.Count > 0) sluUnit.EditValue = cls_Library.DBInt(lst[0]["UNIT_ID"]);
                }
                string[] selectedColumns = new[] { "_id", "code", "name" };
                DataTable dt = new DataView(dtUnit).ToTable(false, selectedColumns);
                sluUnit.Properties.DataSource = dt;
                sluUnit.Properties.PopulateViewColumns();
                sluUnit.Properties.View.Columns["_id"].Visible = false;
                sluUnit.Properties.View.Columns["code"].Caption = "รหัสหน่วยนับ";
                sluUnit.Properties.View.Columns["name"].Caption = "ชื่อหน่วยนับ";

                sluUnit.Properties.ValueMember = "_id";
                sluUnit.Properties.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetLocation :" + ex.Message);
            }
        }

        private void SetDetailItem(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = cls_Data.GetDetailItem(id);
                if (dt.Rows.Count > 0)
                {
                    //Set Detail Item
                    DataRow dr = dt.Rows[0];
                    txtFullName.Text = dr["FULL_NAME"].ToString();
                    txtGenuinPartId.Text = dr["GENUIN_PART_ID"].ToString();
                    txtBrandPartId.Text = dr["BRAND_PART_ID"].ToString();
                }
                else
                {
                    //Clear Detail Item
                    txtFullName.Text = "";
                    txtGenuinPartId.Text = "";
                    txtBrandPartId.Text = "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetDetailItem :" + ex.Message);
            }
        }

        private bool VerifyData()
        {
            bool ret = true;
            StringBuilder msg = new StringBuilder();
            try
            {
                if (sluItem.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสสินค้าไม่ถูกต้อง");
                }
                if (sluUnit.EditValue == null)
                {
                    ret = false;
                    msg.AppendLine("รหัสหน่วยนับไม่ถูกต้อง");
                }

                if (!ret)
                {
                    MessageBox.Show("กรุณาใส่ข้อมูลให้ครบถ้วน" + Environment.NewLine + msg, "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("VerifyData :" + ex.Message);
            }
            return ret;
        }

        #endregion

        public frm_PJDetailInput()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (VerifyData()) SaveData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            if (IsSaveOK)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frm_PJDetailInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btClose.PerformClick();
                    break;
            }
        }

        private void sluItem_EditValueChanged(object sender, EventArgs e)
        {
            if (sluItem.IsEditorActive) SetDetailItem(cls_Library.CInt(sluItem.EditValue));
        }
    }
}