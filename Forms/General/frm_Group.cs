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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;

namespace SmartPart.Forms.General
{
    public partial class frm_Group : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        private DataSet dsData = new DataSet();
        private DataTable dtItem = new DataTable();
        private byte DataMode = 0;
        private byte DataType = 0;
        private int GroupId = 0;
        private int CurrentGroubID = 0;
        private int tmpID = 0;
        private List<DataRow> listItem = new List<DataRow>();
        private string tbGroup = string.Empty;
        private string tbSub = string.Empty;
        private int ItemId;
        private string ItemCode = string.Empty;
        #endregion

        #region Property
        public int ItemID
        {
            set { ItemId = value; }
        }

        public int GroupID
        {
            set { GroupId = value; }
        }

        public string ProductCode
        {
            get { return ItemCode; }
        }
        #endregion

        #region Function

        private void AddItem()
        {
            Int16 max = 0;
            try
            {
                if (dtItem.Rows.Count > 0)
                {
                    //ตรวจสอบ ItemId ซ้ำ
                    int _count = dtItem.AsEnumerable().Where(r => r.Field<int>("ITEM_ID") == ItemId).ToList().Count;
                    if (_count > 0) return;

                    max = dtItem.AsEnumerable().Where(row => row.Field<int>("GROUP_ID") == CurrentGroubID).Max(row => row.Field<Int16>("LIST_NO"));
                }
                

                string Fname = cls_Data.GetNameFromTBname(ItemId, "ITEMS", "FULL_NAME");

                int subid = cls_Data.AddItemInGroup(DataType, CurrentGroubID, ItemId, max, Fname);
                if (subid <= 0) return;

                DataTable dtv = (DataTable)gridSub.DataSource;
                DataTable dt = dtv.Clone();
                dt.Rows.Add();
                dt.Rows[0]["SUBID"] = subid;
                dt.Rows[0]["GROUP_ID"] = CurrentGroubID;
                dt.Rows[0]["LIST_NO"] = max;
                dt.Rows[0]["ITEM_ID"] = ItemId;
                dt.Rows[0]["FULL_NAME"] = Fname;
                dsData.Tables[tbSub].ImportRow(dt.Rows[0]);
                dtItem.ImportRow(dt.Rows[0]);
                if (dtItem.Rows.Count > 0)
                {
                    List<DataRow> ListHave = dtItem.AsEnumerable().Where(r => r.Field<int>("ITEM_ID") == ItemId).ToList();
                    if (ListHave.Count > 0)
                    {
                        gvSub.FocusedRowHandle = dtItem.Rows.IndexOf(ListHave[0]);
                        btAddItem.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AddItem: " + ex.Message);
            }
        }

        private DataSet GetGroupData(byte type, byte mode, out int GroupId)
        {
            DataSet dsResult = new DataSet();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();

            GroupId = 0;
            try
            {

                dsResult = new DataSet();
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {

                    switch (type)
                    {
                        case 1://ใช้แทนกัน
                            sb.Clear();
                            switch (mode)
                            {
                                case 1:
                                    sb.AppendLine("Select * From GROUPREPLACE");
                                    break;
                                case 2:
                                    //sb.AppendFormat("Select Top 1 * From GROUPREPLACE Order by GROUP_ID desc");
                                    sb.AppendFormat("Select Top 1 * From GROUPREPLACE Where GROUP_ACTIVE=1");
                                    break;
                                case 3:
                                    sb.AppendFormat("Select * From GROUPREPLACE Where GROUP_ID = {0}", GroupId);
                                    break;
                            }

                            _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                            _dataAdapter.SelectCommand.Parameters.Clear();
                            _dataAdapter.Fill(dsResult, "GROUPREPLACE");

                            if (dsResult.Tables["GROUPREPLACE"].Rows.Count == 0)
                            {
                                sb.Clear();
                                switch (mode)
                                {
                                    case 1:
                                        sb.AppendLine("Select * From GROUPREPLACE");
                                        break;
                                    case 2:
                                        sb.AppendFormat("Select Top 1 * From GROUPREPLACE Order by GROUP_ID desc");
                                        break;
                                    case 3:
                                        sb.AppendFormat("Select * From GROUPREPLACE Where GROUP_ID = {0}", GroupId);
                                        break;
                                }

                                _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                                _dataAdapter.SelectCommand.Parameters.Clear();
                                _dataAdapter.Fill(dsResult, "GROUPREPLACE");

                                if (dsResult.Tables["GROUPREPLACE"].Rows.Count > 0)
                                {
                                    GroupId = cls_Library.DBInt(dsResult.Tables["GROUPREPLACE"].Rows[dsResult.Tables["GROUPREPLACE"].Rows.Count - 1]["GROUP_ID"]);
                                    UpdateUnActive(1);
                                    UpdateActive(1, GroupId);
                                }
                            }

                            //Sub
                            sb.Clear();
                            switch (mode)
                            {
                                case 1:
                                    if (dsResult.Tables["GROUPREPLACE"].Rows.Count > 0)
                                    {
                                        GroupId = cls_Library.DBInt(dsResult.Tables["GROUPREPLACE"].Rows[dsResult.Tables["GROUPREPLACE"].Rows.Count - 1]["GROUP_ID"]);
                                    }
                                    sb.AppendLine("Select * From GROUPSUBREPLACE Order by GROUP_ID, LIST_NO");
                                    break;
                                case 2:
                                    if (dsResult.Tables["GROUPREPLACE"].Rows.Count > 0)
                                    {
                                        GroupId = cls_Library.DBInt(dsResult.Tables["GROUPREPLACE"].Rows[0]["GROUP_ID"]);
                                    }
                                    sb.AppendFormat("Select * From GROUPSUBREPLACE Where GROUP_ID = {0} Order by LIST_NO", GroupId);
                                    break;
                                case 3:
                                    sb.AppendFormat("Select * From GROUPSUBREPLACE Where GROUP_ID = {0} Order by LIST_NO", GroupId);
                                    break;
                            }

                            _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                            _dataAdapter.SelectCommand.Parameters.Clear();
                            _dataAdapter.Fill(dsResult, "GROUPSUBREPLACE");
                            break;
                        case 2://ใช้ร่วมกัน
                            sb.Clear();
                            switch (mode)
                            {
                                case 1:
                                    sb.AppendLine("Select * From GROUPJOIN");
                                    break;
                                case 2:
                                    //sb.AppendFormat("Select Top 1 * From GROUPJOIN Order by GROUP_ID desc");
                                    sb.AppendFormat("Select Top 1 * From GROUPJOIN Where GROUP_ACTIVE=1");
                                    break;
                                case 3:
                                    sb.AppendFormat("Select * From GROUPJOIN Where GROUP_ID = {0}", GroupId);
                                    break;
                            }



                            _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                            _dataAdapter.SelectCommand.Parameters.Clear();
                            _dataAdapter.Fill(dsResult, "GROUPJOIN");

                            if (dsResult.Tables["GROUPJOIN"].Rows.Count == 0)
                            {
                                sb.Clear();
                                switch (mode)
                                {
                                    case 1:
                                        sb.AppendLine("Select * From GROUPJOIN");
                                        break;
                                    case 2:
                                        sb.AppendFormat("Select Top 1 * From GROUPJOIN Order by GROUP_ID desc");
                                        break;
                                    case 3:
                                        sb.AppendFormat("Select * From GROUPJOIN Where GROUP_ID = {0}", GroupId);
                                        break;
                                }



                                _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                                _dataAdapter.SelectCommand.Parameters.Clear();
                                _dataAdapter.Fill(dsResult, "GROUPJOIN");
                                if (dsResult.Tables["GROUPJOIN"].Rows.Count > 0)
                                {
                                    GroupId = cls_Library.DBInt(dsResult.Tables["GROUPJOIN"].Rows[dsResult.Tables["GROUPJOIN"].Rows.Count - 1]["GROUP_ID"]);
                                    UpdateUnActive(2);
                                    UpdateActive(2, GroupId);
                                }
                            }

                            //Sub
                            sb.Clear();
                            switch (mode)
                            {
                                case 1:
                                    if (dsResult.Tables["GROUPJOIN"].Rows.Count > 0)
                                    {
                                        GroupId = cls_Library.DBInt(dsResult.Tables["GROUPJOIN"].Rows[dsResult.Tables["GROUPJOIN"].Rows.Count - 1]["GROUP_ID"]);
                                    }
                                    sb.AppendLine("Select * From GROUPSUBJOIN Order by GROUP_ID, LIST_NO");
                                    break;
                                case 2:
                                    if (dsResult.Tables["GROUPJOIN"].Rows.Count > 0)
                                    {
                                        GroupId = cls_Library.DBInt(dsResult.Tables["GROUPJOIN"].Rows[0]["GROUP_ID"]);
                                    }
                                    sb.AppendFormat("Select * From GROUPSUBJOIN Where GROUP_ID = {0} Order by LIST_NO", GroupId);
                                    break;
                                case 3:
                                    sb.AppendFormat("Select * From GROUPSUBJOIN Where GROUP_ID = {0} Order by LIST_NO", GroupId);
                                    break;
                            }

                            _dataAdapter.SelectCommand = new SqlCommand(sb.ToString(), conn);
                            _dataAdapter.SelectCommand.Parameters.Clear();
                            _dataAdapter.Fill(dsResult, "GROUPSUBJOIN");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetGroupData: " + ex.Message);
                dsResult = new DataSet();
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn);
                conn.Dispose();
            }
            return dsResult;
        }

        private void InitialDialogGroup(byte mode)
        {
            frm_GroupInput frmInput;
            //DevExpress.XtraGrid.Views.Grid.GridView view;
            DataRow dr = null;
            string strMode = String.Empty;
            try
            {
                byte Xmode = 0;
                if (mode == 2)
                {
                    Xmode = 0;
                }
                else
                {
                    Xmode = mode;
                }

                frmInput = new frm_GroupInput();
                frmInput.StartPosition = FormStartPosition.CenterParent;

                if (mode == 0)
                    strMode = " [เพิ่ม]";
                else if (mode == 1)
                    strMode = " [แก้ไข]";

                //dr = gvGroup.GetFocusedDataRow();
                //if (dr == null) return;
                int irow = gvGroup.FocusedRowHandle;
                //view = (DevExpress.XtraGrid.Views.Grid.GridView)gvGroup;
                if ((irow < 0))
                {
                    if (mode != 0)
                    {
                        return;
                    }
                }
                //dr = view.GetFocusedDataRow();
                frmInput.Text = "กลุ่มสินค้า" + strMode;
                #region "XXX"
                if (dr != null)
                {
                    if ((mode == 1) || (mode == 2))
                    {
                        if (mode == 1)
                        {
                            frmInput.txtGroupCode.Text = cls_Library.DBString(dr["GROUP_CODE"]);
                            frmInput.txtDesc.Text = cls_Library.DBString(dr["DESCRIPTION"]);
                        }
                        else
                        {
                            frmInput.txtGroupCode.Text = "";
                            frmInput.txtDesc.Text = "";
                        }
                    }
                    else
                    {
                        frmInput.txtGroupCode.Text = "";
                        frmInput.txtDesc.Text = "";
                    }
                }
                #endregion
                frmInput.MinimizeBox = false;
                frmInput.ShowInTaskbar = false;
                frmInput.txtGroupCode.Select();
                if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                if (cls_Data.SaveDataGroup(DataType, Xmode, frmInput.txtGroupCode.Text, frmInput.txtDesc.Text, ref CurrentGroubID))
                {
                    dsData.Tables[tbGroup].BeginInit();
                    if (Xmode == 0)
                    {
                        DataTable dtv = (DataTable)gridGroup.DataSource;
                        DataTable dt = dtv.Clone();
                        dt.Rows.Add();
                        dt.Rows[0]["GROUP_ID"] = CurrentGroubID;
                        dt.Rows[0]["GROUP_CODE"] = cls_Library.DBString(frmInput.txtGroupCode.Text.Trim());
                        dt.Rows[0]["DESCRIPTION"] = cls_Library.DBString(frmInput.txtDesc.Text.Trim());
                        dsData.Tables[tbGroup].ImportRow(dt.Rows[0]);
                        gvGroup.FocusedRowHandle = dsData.Tables[tbGroup].Rows.Count -1;

                        if (DataType == 1)
                            cls_Global_DB.GB_GroupReplace = CurrentGroubID;
                        else
                            cls_Global_DB.GB_GroupJoin = CurrentGroubID;

                        GroupId = CurrentGroubID;
                    }
                    else
                    {
                        //view = (DevExpress.XtraGrid.Views.Grid.GridView)gvGroup;
                        dr = gvGroup.GetFocusedDataRow();
                        dr["GROUP_ID"] = CurrentGroubID;
                        dr["GROUP_CODE"] = cls_Library.DBString(frmInput.txtGroupCode.Text.Trim());
                        dr["DESCRIPTION"] = cls_Library.DBString(frmInput.txtDesc.Text.Trim());                        
                    }
                    dsData.Tables[tbGroup].EndInit();
                    gridGroup.DataSource = dsData.Tables[tbGroup];
                    gridGroup.RefreshDataSource();   
                }
                UpdateUnActive(DataType);
                UpdateActive(DataType, CurrentGroubID);
                ThreadStart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("InitialDialogGroup: " + ex.Message);
            }
        }

        private void SetActive()
        {
            try
            {
                DataRow row = gvGroup.GetFocusedDataRow();
                int GID = 0;
                if (row == null) return;
                GID = cls_Library.DBInt(row["GROUP_ID"]);
                string Gcode = cls_Library.DBString(row["GROUP_CODE"]); 

                int mode = 0;
                if (DataType == 1)
                {
                    mode = 1;
                }
                else
                {
                    mode = 2;
                }

                //cls_Data.UpdateUnActiveVoucherByType(mode);

                UpdateUnActive(mode);

                if (UpdateActive(mode,GID))
                {
                    XtraMessageBox.Show(string.Format("กลุ่ม {0}  Active แล้ว", Gcode));
                    ThreadStart();
                    this.UseWaitCursor = false;
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("SetActive :" + ex.Message);
            }
        }

        private void SetDataFocus(DataRow row)
        {
            try
            {
                if (row == null)
                {
                    CurrentGroubID = 0;
                }
                else
                    CurrentGroubID = cls_Library.DBInt(row["GROUP_ID"]);

                listItem = dsData.Tables[tbSub].AsEnumerable().Where(r => r.Field<int>("GROUP_ID") == CurrentGroubID).ToList();
                if (listItem.Count > 0)
                {
                    dtItem = listItem.CopyToDataTable();
                    btDeleteGroup.Enabled = false;
                }
                else
                {
                    dtItem = dsData.Tables[tbSub].Clone();
                    btDeleteGroup.Enabled = true;
                }

                btAddItem.Enabled = true;
                gridSub.DataSource = dtItem;
                gridSub.RefreshDataSource();
                if (dtItem.Rows.Count > 0)
                {
                    List<DataRow> ListHave = dtItem.AsEnumerable().Where(r => r.Field<int>("ITEM_ID") == ItemId).ToList();
                    if (ListHave.Count > 0)
                    {
                        gvSub.FocusedRowHandle = dtItem.Rows.IndexOf(ListHave[0]);
                        btAddItem.Enabled = false;
                    }    
                    else
                    {
                        btAddItem.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("SetDataFocus: " + ex.Message);
            }
        }

        private void SetDataToControl()
        {
            try
            {
                gridGroup.DataSource = dsData.Tables[tbGroup];
                gridGroup.RefreshDataSource();
                
                listItem = dsData.Tables[tbGroup].AsEnumerable().Where(r => r.Field<int>("GROUP_ID") == GroupId).ToList();
                if (listItem.Count > 0)
                {
                    gvGroup.FocusedRowHandle = dsData.Tables[tbGroup].Rows.IndexOf(listItem[0]);
                    //dtItem = listItem.CopyToDataTable();
                }
                else
                {
                    gvGroup.FocusedRowHandle = 0;
                    //dtItem = dsData.Tables[tbSub].Clone();
                }
                DataRow dr = gvGroup.GetFocusedDataRow();
                SetDataFocus(dr);

            }
            catch (Exception ex)
            {
                MessageBox.Show("SetDataToControl: " + ex.Message);
            }
        }

        private void ThreadStart()
        {
            if (!bwLoad.IsBusy) bwLoad.RunWorkerAsync();
        }

        public static bool UpdateActive(int Type, int GID)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction tran = null;
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();
            bool ret = false;
            try
            {
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    sb.Clear();
                    switch (Type)
                    {
                        case 1:
                            sb.AppendLine("UPDATE GROUPREPLACE WITH (UPDLOCK) SET GROUP_ACTIVE = 1 WHERE GROUP_ID = @GROUP_ID");
                            break;
                        case 2:
                            sb.AppendLine("UPDATE GROUPJOIN WITH (UPDLOCK) SET GROUP_ACTIVE = 1 WHERE GROUP_ID = @GROUP_ID");
                            break;
                    }

                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sb.ToString();
                    cmd.CommandTimeout = 30;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Transaction = tran;

                    cmd.Parameters.Add("@GROUP_ID", SqlDbType.Int).Value = GID;
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                ret = false;
                tran.Rollback();
                XtraMessageBox.Show("UpdateActive :" + ex.Message);
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn); conn.Dispose();
            }
            return ret;
        }

        public static void UpdateUnActive(int Type)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = conn.CreateCommand();
            SqlTransaction tran = null;
            SqlDataAdapter _dataAdapter = new SqlDataAdapter();
            StringBuilder sb = new StringBuilder();

            try
            {
                if (cls_Global_DB.ConnectDatabase(ref conn))
                {
                    tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    switch (Type)
                    {
                        case 1:
                            sb.Clear();
                            sb.AppendLine("UPDATE GROUPREPLACE WITH (UPDLOCK) SET GROUP_ACTIVE = 0 WHERE GROUP_ACTIVE=1");
                            cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = sb.ToString();
                            cmd.CommandTimeout = 30;
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();
                            cmd.Transaction = tran;
                            cmd.ExecuteNonQuery();
                            break;
                        case 2:
                            sb.Clear();
                            sb.AppendLine("UPDATE GROUPJOIN WITH (UPDLOCK) SET GROUP_ACTIVE = 0 WHERE GROUP_ACTIVE=1");
                            cmd = new SqlCommand();
                            cmd.Connection = conn;
                            cmd.CommandText = sb.ToString();
                            cmd.CommandTimeout = 30;
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();
                            cmd.Transaction = tran;
                            cmd.ExecuteNonQuery();
                            break;
                    }

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                XtraMessageBox.Show("UpdateUnActiveVoucherByType :" + ex.Message);
            }
            finally
            {
                cls_Global_DB.CloseDB(ref conn); conn.Dispose();
            }
        }

        #endregion

        public frm_Group(byte type, byte mode)
        {
            InitializeComponent();
            DataType = type;    //1: ใช้แทนกัน, 2: ใช้ร่วมกัน
            DataMode = mode;    //1: All Group, 2: By Id      
            GroupID = 0;
            DataMode = 2;

            //switch (DataType)
            //{
            //    case 1:
            //        GroupId = cls_Global_DB.GB_GroupReplace;
            //        if (cls_Global_DB.GB_GroupReplace > 0)
            //        {
            //            DataMode = 2;                     
            //        }
            //        break;
            //    case 2:
            //        GroupId = cls_Global_DB.GB_GroupJoin;
            //        if (cls_Global_DB.GB_GroupJoin > 0)
            //        {
            //            DataMode = 2;
            //        }
            //        break;
            //}

            this.KeyPreview = true;

            this.Text = type == 2 ? "สินค้าใช้ด้วยกัน" : "สินค้าใช้แทนกัน";
            tbGroup = DataType == 1 ? "GROUPREPLACE" : "GROUPJOIN";
            tbSub = DataType == 1 ? "GROUPSUBREPLACE" : "GROUPSUBJOIN";

            //gvGroup.Appearance.SelectedRow.BackColor = Color.Yellow;
            //gvGroup.Appearance.FocusedRow.BackColor = Color.Green;

            //gvSub.Appearance.SelectedRow.BackColor = Color.Yellow;
            //gvSub.Appearance.FocusedRow.BackColor = Color.Green;
            ThreadStart();
        }

        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            //chkShow.Enabled = false;
            dsData = GetGroupData(DataType, DataMode,out GroupId);
        }

        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //chkShow.Enabled = true;
            SetDataToControl();
        }

        private void gvGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gvGroup.GetFocusedDataRow();
            SetDataFocus(dr);
        }

        private void frm_GroupJoin_Load(object sender, EventArgs e)
        {
            if (cls_Global_DB.DataInitial == null)
            {
                cls_Global_DB.DataInitial = new DataSet();
                cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTableSP("M_ITEMS"));
            }
            else
            {
                if (!cls_Global_DB.DataInitial.Tables.Contains("M_ITEMS"))
                    cls_Global_DB.DataInitial.Tables.Add(cls_Data.GetDataTableSP("M_ITEMS"));
            }

            repoSearchItem.DataSource = cls_Global_DB.DataInitial.Tables["M_ITEMS"];
            repoSearchItem.ValueMember = "_id";
            repoSearchItem.DisplayMember = "code";

            chkShow.Checked = DataMode == 1;
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkShow.IsEditorActive) return;            
            if (chkShow.Checked) DataMode = 1; else DataMode = 2;
            ThreadStart();
        }

        private void btAddGroup_Click(object sender, EventArgs e)
        {
            InitialDialogGroup(0);
        }

        private void btEditGroup_Click(object sender, EventArgs e)
        {
            InitialDialogGroup(1);
        }

        private void btDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow Drow = gvGroup.GetFocusedDataRow();
                if (Drow == null) return;
                int irow = gvGroup.FocusedRowHandle;
                DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    CurrentGroubID = cls_Library.DBInt(Drow["GROUP_ID"]);
                    if (cls_Data.DeleteGroup(DataType, CurrentGroubID))
                    {
                        dsData.Tables[tbGroup].AcceptChanges();
                        dsData.Tables[tbGroup].Rows[irow].Delete();
                        Drow.Delete();
                        dsData.Tables[tbGroup].AcceptChanges();

                        if (dsData.Tables[tbGroup].Rows.Count > 0)
                        {
                            GroupId = cls_Library.DBInt(dsData.Tables[tbGroup].Rows[dsData.Tables[tbGroup].Rows.Count - 1]["GROUP_ID"]);
                        }
                        
                        gvGroup.RefreshData();
                        gridGroup.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btDeleteGroup_Click: " + ex.Message);
            }
        }

        private void btView_Click(object sender, EventArgs e)
        {
            DataRow row = gvSub.GetFocusedDataRow();
            if (row == null) return;
            ItemCode = cls_Data.GetNameFromTBname(cls_Library.DBInt(row["ITEM_ID"]), "ITEMS", "ITEM_CODE");
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void btDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow Drow = gvSub.GetFocusedDataRow();
                if (Drow == null) return;
                int irow = gvSub.FocusedRowHandle;
                DialogResult Result = XtraMessageBox.Show("ต้องการลบรายการที่ " + (irow + 1).ToString("#,##0") + " ใช่หรือไม่?", "ลบ", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    tmpID = cls_Library.DBInt(Drow["SUBID"]);
                    if (cls_Data.DeleteItemInGroup(DataType, tmpID))
                    {
                        dsData.Tables[tbSub].AcceptChanges();
                        dsData.Tables[tbSub].Rows[irow].Delete();
                        Drow.Delete();
                        dsData.Tables[tbSub].AcceptChanges();
                        dtItem.Rows[irow].Delete();
                        dtItem.AcceptChanges();
                        gvGroup.RefreshData();
                        gridGroup.RefreshDataSource();
                    }   
                    if (dtItem.Rows.Count == 0) btAddItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("btDeleteItem_Click: " + ex.Message);
            }
        }

        private void frm_Group_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.Escape:
                this.Close();
                break;
            }
        }

        private void gvSub_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gvSub.GetFocusedDataRow();
            //btAddItem.Enabled = true;
            if (dr == null) return;
            int _id = cls_Library.DBInt(dr["ITEM_ID"]);
            //if (_id == ItemId) btAddItem.Enabled = false;
            //btDeleteItem.Enabled = _id == ItemId;
        }

        private void gvGroup_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView View = sender as GridView;
                //int _id = cls_Library.CInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["GROUP_ID"]));
                bool ACok = cls_Library.DBbool(View.GetRowCellValue(e.RowHandle, View.Columns["GROUP_ACTIVE"]));
                if (ACok)
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
        }

        private void gvSub_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView View = sender as GridView;
                int _id = cls_Library.DBInt(dtItem.Rows[e.RowHandle]["ITEM_ID"]); //cls_Library.CInt(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ITEM_ID"]));
                if (_id == ItemId)
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }

        }

        private void btActive_Click(object sender, EventArgs e)
        {
            SetActive();
        }
    }
}