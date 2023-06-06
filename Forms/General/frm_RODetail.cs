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

namespace SmartPart.Forms.General
{
    public partial class frm_RODetail : DevExpress.XtraEditors.XtraForm
    {
        //#region Variable
        ////private cls_Struct.StructJOB JOB = new cls_Struct.StructJOB();
        //private BackgroundWorker _bwLoad = null;
        //private int ROID = 0;
        //private cls_Struct.ActionMode DataMode;
        //private DataSet dsMainData = new DataSet();
        //private DataSet dsEdit = new DataSet();
        //#endregion

        //#region Thread
        //private void ThreadStart()
        //{
        //    _bwLoad = new BackgroundWorker();
        //    _bwLoad.WorkerReportsProgress = true;
        //    _bwLoad.WorkerSupportsCancellation = true;
        //    _bwLoad.DoWork += new DoWorkEventHandler(_bwLoad_DoWork);
        //    _bwLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bwLoad_RunWorkerCompleted);

        //    _bwLoad.RunWorkerAsync();
        //}

        //void _bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {
        //        SetDataToControl();
        //    }
        //    catch { }
        //    finally { Cursor = Cursors.Default; }
        //}

        //void _bwLoad_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        dsMainData = cls_Data.GetJOBById(JOBID);
        //    }
        //    catch (Exception ex)
        //    { MessageBox.Show(ex.Message); }
        //}
        //#endregion

        //#region Function
        
        //#endregion

        public frm_RODetail()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }
    }
}