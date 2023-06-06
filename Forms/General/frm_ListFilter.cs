using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using SmartPart.Class;
using DevExpress.XtraGrid.Columns;

namespace SmartPart.Forms.General
{
    public partial class frm_ListFilter : DevExpress.XtraEditors.XtraForm
    {
        #region "  Variables declaration  "

        private DataSet _getLastdata = null;
        private DataRow _tmpRowUser = null;
        private DataRow _RowUser = null;
        private DataRow removegroup = null;
        private DataTable DTlist = null;

        private string MemberOld = String.Empty;
        private string _memberof = String.Empty;

        //--- Fixed length variables
        private int _Mode = 0;
        private int _Codeid = 0;
        private string _Cpath;
        bool OK = false;
        int rowarr;
        int Typeid = 0;

        #endregion

        #region "  Properties declaration  "

        public DataSet getLastdata
        {
            get
            {
                return _getLastdata;
            }
            set { _getLastdata = value; }
        }

        public DataRow Prop_RowUser
        {
            get { return _RowUser; }
            set { _RowUser = value; }
        }

        public DataTable PropDTlist
        {
            get { return DTlist; }
            set { DTlist = value; }
        }

        public int Prop_FreightCid
        {
            get { return _Codeid; }
            set { _Codeid = value; }
        }

        public string Prop_FreightCPath
        {
            get { return _Cpath; }
            set { _Cpath = value; }
        }

        public int Prop_Arr
        {
            get { return rowarr; }
            set { rowarr = value; }
        }

        public string MemberOf
        {
            set { _memberof = value; }
        }

        public bool PropOK
        {
            set { OK = value; }
        }
        #endregion

        public frm_ListFilter(int TypeCode)
        {
            InitializeComponent();

            this.KeyPreview = true;

            Typeid = TypeCode;
            LoadData();

            SetGrid();

            gridList.DataSource = DTlist;
            gridList.RefreshDataSource();
            gridList.Visible = true;
        }

        

        private void LoadData()
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = null;
            DataTable dt;
            string sql = string.Empty;
            DateTime dateF = DateTime.Now.Date;

            cls_Global_DB.ConnectDatabase(ref cn);

            try
            {
                switch (Typeid)
                {
                    case 1: //รหัสพนักงาน
                        sql = "Select USER_ID as [V_Id], USER_CODE as [V_Code],'' as [V_Group],USER_NAME as [V_DescT], '' as [V_DescE] from M_USERS Where USER_NAME not like 'admin' order by USER_CODE";
                        break;
                    case 2: //รหัสลูกค้า
                        sql = "Select CUSTOMER_ID as [V_Id],CUSTOMER_CODE as [V_Code],'' as [V_Group],CUSTOMER_NAME as [V_DescT], '' as [V_DescE] from M_CUSTOMERS Where DELETED=0 order by CUSTOMER_CODE";
                        break;
                    //case 3:
                    //    sql = "Select JOBcode as [V_Code],JOBgroup as [V_Group],JOBdescT as [V_DescT], JOBdescE as [V_DescE] from JOB Where JOBhide=0 and JOBlock=0 order by JOBcode";
                    //    break;
                    //case 4:
                    //    sql = "Select distinct JOBgroup as [V_Group] from JOB Where JOBhide=0 and JOBlock=0";
                    //    break;
                }


                da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.Clear();
                //da.SelectCommand.Parameters.Add("@dateForm", SqlDbType.DateTime).Value = System.Convert.ToDateTime(CaldateF);
                //da.SelectCommand.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = System.Convert.ToDateTime(CaldateT);
                ////da.SelectCommand.Parameters.Add("@V_Per_id", SqlDbType.Int).Value = Perid;
                //da.SelectCommand.Parameters.Add("@V_UseAdvance", SqlDbType.Bit).Value = false;
                da.SelectCommand.CommandTimeout = 300;
                DTlist = new DataTable("List");
                da.Fill(DTlist);
            }
            catch (Exception e)
            {
                this.Focus();
            }
            finally
            {
                cls_Global_DB.CloseDB(ref cn);
            }
        }

        private void SetGrid()
        {
            //int i, NO = 0;
            try
            {
                GridColumn V_id = cls_Form.AddGridColumn("V_id", "id", "V_id", false, 0, 100);
                GridColumn V_Code = cls_Form.AddGridColumn("V_Code", "รหัส", "V_Code", true, 1, 80);
                GridColumn V_Group = cls_Form.AddGridColumn("V_Group", "กลุ่ม", "V_Group", true, 2, 60);
                GridColumn V_DescT = cls_Form.AddGridColumn("V_DescT", "คำอธิบายไทย", "V_DescT", true, 3, 160);
                GridColumn V_DescE = cls_Form.AddGridColumn("V_DescE", "คำอธิบายอังกฤษ", "V_DescE", true, 4, 160);


                gridList.BeginInit();
                gvList.BeginInit();
                gvList.Columns.Clear();

                V_id.Visible = false;

                switch (Typeid)
                {
                    case 1:
                    case 2:
                        V_Group.Visible = false;
                        V_DescE.Visible = false;
                        break;
                }

                V_Code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                V_Code.AppearanceHeader.Options.UseTextOptions = true;
                V_Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                V_Code.AppearanceCell.Options.UseTextOptions = true;
                V_Code.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                V_Code.SummaryItem.DisplayFormat = "{0:#,##0}" + "   รายการ";

                V_Group.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                V_Group.AppearanceHeader.Options.UseTextOptions = true;
                V_Group.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                V_Group.AppearanceCell.Options.UseTextOptions = true;

                V_DescT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                V_DescT.AppearanceHeader.Options.UseTextOptions = true;
                V_DescT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                V_DescT.AppearanceCell.Options.UseTextOptions = true;

                V_DescE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                V_DescE.AppearanceHeader.Options.UseTextOptions = true;
                V_DescE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                V_DescE.AppearanceCell.Options.UseTextOptions = true;

                gvList.Columns.AddRange(new GridColumn[] { V_Code, V_Group, V_DescT, V_DescE });

                gvList.OptionsView.ShowGroupPanel = false;
                gvList.OptionsBehavior.Editable = false;
                gvList.OptionsSelection.EnableAppearanceFocusedCell = false;
                gvList.OptionsView.EnableAppearanceEvenRow = false;
                gvList.OptionsView.EnableAppearanceOddRow = true;
                gvList.IndicatorWidth = 30;

                gvList.OptionsView.RowAutoHeight = true;
                gvList.OptionsView.ShowAutoFilterRow = true;
                gvList.OptionsFind.ShowCloseButton = false;
                gvList.OptionsFind.AlwaysVisible = false;
                gvList.OptionsView.ShowFooter = true;

                gvList.EndInit();
                gridList.EndInit();
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //gvCodeCus.OptionsView.ShowViewCaption = true;
            //gridCodeCus.Visible = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            row = gvList.GetFocusedDataRow();
            if (row == null)
            {
                cmdClose_Click(sender, e);
                return;
            }

            if (Typeid == 2)
            {

            }
            switch (Typeid)
            {
                case 1:
                case 2:
                case 3:
                    rowarr = cls_Library.DBInt(row["V_Id"]);
                    break;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void gvList_DoubleClick(object sender, EventArgs e)
        {
            cmdOK.PerformClick();
        }

        private void frm_ListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    cmdClose.PerformClick();
                    break;
            }
        }
    }
}