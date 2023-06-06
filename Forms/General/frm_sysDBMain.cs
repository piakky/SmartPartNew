using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using Microsoft.Win32;
using SmartPart.Class;

namespace SmartPart
{
  public partial class frm_sysDBMain : DevExpress.XtraEditors.XtraForm
  {
    public frm_sysDBMain()
    {
      InitializeComponent();
      txtServer.Text = cls_Global_DB.GB_ServerName;
      //txtDBname.Text = cls_Global_DB.GB_ServerDBname;
      txtUser.Text = cls_Global_DB.GB_ServerUser;
      txtPass.Text = cls_Global_DB.GB_ServerPass;
    }

    private void btok_Click(object sender, EventArgs e)
    {
      string sn = cls_Global_DB.GB_ServerName;
      string sdb = cls_Global_DB.GB_ServerDBname;
      string su = cls_Global_DB.GB_ServerUser;
      string sp = cls_Global_DB.GB_ServerPass;

      cls_Global_DB.GB_ServerName = txtServer.Text;
      cls_Global_DB.GB_ServerUser = txtUser.Text;
      cls_Global_DB.GB_ServerPass = txtPass.Text;
      cls_Global_DB.GB_ServerDBname = "SmartPart2";
      RegistryKey Key = Registry.CurrentUser.CreateSubKey("Software\\SMARTPART2");

      SqlConnection cn = new SqlConnection();
      if (!cls_Global_DB.ConnectDatabase(ref cn))
      {
        cls_Global_DB.GB_ServerName = sn;
        cls_Global_DB.GB_ServerDBname = sdb;
        cls_Global_DB.GB_ServerUser = su;
        cls_Global_DB.GB_ServerPass = sp;
        XtraMessageBox.Show("ไม่สามารถเชื่อมฐานข้อมูลได้", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        Key.SetValue("ServerName", ASCIIEncoding.ASCII.GetBytes(cls_Global_class.Encrypt(cls_Global_DB.GB_ServerName)), RegistryValueKind.Binary);
        Key.SetValue("ServerDBname", ASCIIEncoding.ASCII.GetBytes(cls_Global_class.Encrypt(cls_Global_DB.GB_ServerDBname)), RegistryValueKind.Binary);
        Key.SetValue("ServerUser", ASCIIEncoding.ASCII.GetBytes(cls_Global_class.Encrypt(cls_Global_DB.GB_ServerUser)), RegistryValueKind.Binary);
        Key.SetValue("ServerPass", ASCIIEncoding.ASCII.GetBytes(cls_Global_class.Encrypt(cls_Global_DB.GB_ServerPass)), RegistryValueKind.Binary);
        cls_Global_class.GB_DatabaseOK = true;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      cls_Global_DB.CloseDB(ref cn);
    }

    private void btno_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void frm_sysDBMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      //if (this.DialogResult ==DialogResult.Cancel)
      //{
      //  Environment.Exit(0);
      //}
    }

    private void frm_sysDBMain_Load(object sender, EventArgs e)
    {

    }

    
  }
}