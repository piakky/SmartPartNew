using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;
using DevExpress.XtraTabbedMdi;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SmartPart.Class
{
  class cls_Global_class
  {
    public static string GB_UserCode = "";
    public static int GB_Userid = 1;
    public static string USRnameT = "";
    public static string USRnameE = "";
    public static string GB_Password = "";
    public static UInt64 GB_USMs1 = 0;
    public static UInt64 GB_USMs2 = 0;
    public static UInt64 GB_USMs3 = 0;
    public static UInt64 GB_USMs4 = 0;
    public static UInt64 GB_USMs5 = 0;
    public static UInt64 GB_USMs6 = 0;
    public static bool GB_DatabaseOK = false;
    public static bool GB_MAC5OK = false;
    public static bool GB_Userok = false;
    public static string MemoText = "";
    public static DateTime Gdate1;
    public static DateTime Gdate2;
    public static bool GB_ShowAll = false;
    private static string cryptoKey = (string)Dns.GetHostName().ToString();
    private static readonly byte[] IV = new byte[8] { 36, 25, 4, 64, 0, 36, 64, 81 };
    public static DevExpress.XtraTabbedMdi.XtraTabbedMdiManager gb_MdiManager = new XtraTabbedMdiManager();
    public static System.IFormatProvider Iformat = new System.Globalization.CultureInfo("en-US");

    public static void MessageboxErrorOK(string MsgText, string MsgCaption)
    {
      XtraMessageBox.Show(MsgText, MsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static CultureInfo CiT = new CultureInfo("th-TH");
    public static CultureInfo CiE = new CultureInfo("en-US");
    public static DateTime GetDateCulture(DateTime value)
    {
      DateTime obj;
      try
      {
        obj = Convert.ToDateTime(value, CiE);
      }
      catch
      {
        obj = Convert.ToDateTime(DateTime.MinValue, CiE);
      }
      return obj;
    }
    public static bool IsDate(object obj)
    {
      string strDate = "";
      bool ret = false;
      try
      {
        strDate = obj.ToString();
        DateTime dt;
        DateTime.TryParse(strDate, out dt);
        if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
        {
          ret = true;
        }
      }
      catch
      {

      }
      return ret;
    }
    public static bool IsRowDoubleClick(DevExpress.XtraGrid.Views.Grid.GridView view, System.EventArgs e)
    {
      DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi;
      bool Xrow;
      MouseEventArgs Xe = (MouseEventArgs)e;
      hi = view.CalcHitInfo(Xe.Location);
      if ((hi.InRow) || (hi.InRowCell))
      {
        Xrow = true;
      }
      else
      {
        Xrow = false;
      }
      return Xrow;
    }
    public static int NeverNothing(object _param, int defaultvalue)
    {
      int result = 0;
      try
      {
        result = int.Parse(_param.ToString());
      }
      catch (Exception)
      {
        result = defaultvalue;
      }
      return result;
    }
    public static bool ValidateEmailAddress(string email)
    {
      bool OK = false;
      //string pattern  = "^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";
      //string pattern  = "^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";
      string pattern = "";
      OK = System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
      return OK;
    }
    public static ulong BitSum(string Xstr)
    {
      ulong SumVal = 0;
      double j;
      //string ret = "";

      SumVal = 0;
      if (Xstr.Length > 0)
      {
        for (j = 0; j < Xstr.Length; j++)
          SumVal += Convert.ToUInt64(Xstr.Substring((int)j, 1)) * (ulong)(Math.Pow(2, j));
      }
      //ret = SumVal.ToString();
      return SumVal;
    }
    public static string SignificanceDEM(UInt64 Xval, int Xlength)
    {
      string ret = "";
      double XmodVal = 0;
      long Zi, Xremain;
      string[] Xsign = new string[0];

      if (Xlength > 66) Xlength = 66;
      Array.Resize(ref Xsign, 66);
      for (Zi = 65; Zi >= 0; Zi--)
      {
        XmodVal = Math.Pow(2, Zi);
        Xremain = (long)Xval % (long)XmodVal;
        if ((long)Xremain == (long)Xval) Xsign[Zi] = "0";
        else Xsign[Zi] = "1";
        Xval = (UInt64)Xremain;
      }
      for (Zi = 0; Zi < Xlength; Zi++)
        ret += Xsign[Zi];
      return ret;
    }
    public static UInt64 CUInt(object obj)
    {
      UInt64 i;
      try
      {
        if (!UInt64.TryParse(obj.ToString(), out i))
        {
          i = 0;
        }
      }
      catch
      {
        i = 0;
      }
      return i;
    }
    public static string Encrypt(string str)
    {
      if (str == null || str.Length == 0) return string.Empty;
      string result = string.Empty;
      try
      {
        byte[] buffer = Encoding.ASCII.GetBytes(str);
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
        des.IV = IV;
        result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
      }
      catch
      {
        throw;
      }

      return result;
    }
    public static string Decrypt(string str)
    {
      if (str == null || str.Length == 0) return string.Empty;
      string result = string.Empty;
      try
      {
        byte[] buffer = Convert.FromBase64String(str);
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
        des.IV = IV;
        result = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
      }
      catch
      {
        throw;
      }

      return result;
    }
    public static void SetIndicatorWidth(DevExpress.XtraGrid.Views.Grid.GridView View, int RowsCount)
    {
      if ((RowsCount >= 0) || (RowsCount <= 99))
      {
        View.IndicatorWidth = 35;
      }
      else if ((RowsCount >= 0) || (RowsCount <= 999))
      {
        View.IndicatorWidth = 40;
      }
      else if ((RowsCount > 999) || (RowsCount <= 9999))
        View.IndicatorWidth = 50;
      else
      {
        View.IndicatorWidth = 55;
      }
    }
    public static string GetRowSecurityCode(int i)
    {
      string Xcap = "";

      switch (i)
      {
        case 0:
          Xcap = "Customer codes";
          break;
        case 1:
          Xcap = "Instrument name";
          break;
        case 2:
          Xcap = "Spare Part codes";
          break;
        case 3:
          Xcap = "Department codes";
          break;
        case 4:
          Xcap = "Specification codes";
          break;
        case 5:
          Xcap = "Engineer codes ";
          break;
        case 6:
          Xcap = "Recoder codes";
          break;
        case 7:
          Xcap = "Shelf codes";
          break;
      }

      return Xcap;
    }
    public static string GetRowSecurityVoucher(int i)
    {
      string Xcap = "";

      switch (i)
      {
        case 0:
          Xcap = "Budget";
          break;

        //case 0:
        //  Xcap = "Installation";
        //  break;
        //case 1:
        //  Xcap = "Validation";
        //  break;
        //case 2:
        //  Xcap = "PQ";
        //  break;
        //case 3:
        //  Xcap = "Services";
        //  break;
        //case 4:
        //  Xcap = "Visit";
        //  break;
        //case 5:
        //  Xcap = "ASC";
        //  break;
        //case 6:
        //  Xcap = "เสนอราคา ASC";
        //  break;
        //case 7:
        //  Xcap = "เสนอราคา Validation";
        //  break;
        //case 8:
        //  Xcap = "เสนอราคา Spare Part";
        //  break;
        //case 9:
        //  Xcap = "ใบแจ้งเตือนเพื่อสอบเทียบ";
        //  break;
        //case 10:
        //  Xcap = "ใบรับเข้า";
        //  break;
        //case 11:
        //  Xcap = "ใบเบิกออก";
        //  break;
        //case 12:
        //  Xcap = "Change Parts";
        //  break;
      }

      return Xcap;
    }
    public static string GetRowSecuritySystem(int i)
    {
      string Xcap = "";

      switch (i)
      {
        case 0:
          Xcap = "กำหนดรหัสผู้ใช้";
          break;
        case 1:
          Xcap = "กำหนดสิทธิผู้ใช้";
          break;
        case 2:
          Xcap = "เพิ่มรหัสผู้ใช้";
          break;
        case 3:
          Xcap = "แก้ไขรหัสผู้ใช้";
          break;
        case 4:
          Xcap = "ลบรหัสผู้ใช้";
          break;
        case 5:
          Xcap = "เปลี่ยนรหัสผ่านได้";
          break;
      }

      return Xcap;
    }
    public static string GetRowSecurityReport(int i)
    {
      string Xcap = "";

      switch (i)
      {
        case 0:
          Xcap = "รายงานสรุปวัสดุเข้าไซต์";
          break;
        case 1:
          Xcap = "รายงานประมาณการโครงการบ้าน (Estimate) แสดงแบบรายปี";
          break;
        case 2:
          Xcap = "รายงานประมาณการโครงการบ้าน (Estimate) แสดงแบบรายเดือน";
          break;
      }

      return Xcap;
    }
    public static bool GetSecurityOK(int Xtype, UInt64 Xval, int Xno)
    {
      bool isOK = false;
      string Xvalue = "";
      string Xt;

      try
      {
        Xvalue = "";
        switch (Xtype)
        {
          case 1:
            Xvalue = SignificanceDEM(Xval, 2);

            break;
          case 2:
            Xvalue = SignificanceDEM(Xval, 33);
            break;
          case 3:
            Xvalue = SignificanceDEM(Xval, 61);
            break;
          case 4:
            Xvalue = SignificanceDEM(Xval, 21);
            break;
          case 5:
            Xvalue = SignificanceDEM(Xval, 5);
            break;
          case 6:
            Xvalue = SignificanceDEM(Xval, 9);
            break;
        }
        Xt = Xvalue.Substring(Xno, 1);
        if (Xt == "1")
        {
          isOK = true;
        }
        else
        {
          isOK = false;
        }
      }
      catch
      {

      }

      return isOK;

    }

    #region Enum
    //public enum ActionMode
    //{
    //    Add =0, Edit, Copy, Delete
    //}

    public enum ChooseType
    {
      Customer, Item
    }

    public enum TypeCal : int
    { price = 0, quantity, disc, taxamount, taxrate, recalTax, unitprice,perdisc, realprice }

    public enum TypePrice : int
    {
      NOSUMVAT = 0, SUMVAT = 1, NOTVAT =2
    }

    public enum TypeShow : int
    {
      code = 0, name = 1,codename = 2
    }
    #endregion

  }

  class cls_ResizeControl
  {
    private Control mControl;
    private bool mMouseDown = false;
    private EdgeEnum mEdge = EdgeEnum.None;
    private int mWidth = 4;
    private bool mOutlineDrawn = false;

    private enum EdgeEnum
    {
      None,
      Right,
      Left,
      Top,
      Bottom,
      TopLeft
    }

    public cls_ResizeControl(Control conT)
    {
      mControl = conT;
      mControl.MouseDown += new MouseEventHandler(mControl_MouseDown);
      mControl.MouseUp += new MouseEventHandler(mControl_MouseUp);
      mControl.MouseMove += new MouseEventHandler(mControl_MouseMove);
      mControl.MouseLeave += new EventHandler(mControl_MouseLeave);
    }

    private void mControl_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        mMouseDown = true;
      }
    }

    private void mControl_MouseUp(object sender, MouseEventArgs e)
    {
      mMouseDown = false;
    }

    private void mControl_MouseMove(object sender, MouseEventArgs e)
    {
      Control c = new Control();
      Graphics g = c.CreateGraphics();

      c = (Control)sender;
      switch (mEdge)
      {
        case EdgeEnum.TopLeft: g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth * 4, c.Height * 4); mOutlineDrawn = true; break;
        case EdgeEnum.Left: g.FillRectangle(Brushes.Fuchsia, 0, 0, mWidth, c.Height); mOutlineDrawn = true; break;
        case EdgeEnum.Right: g.FillRectangle(Brushes.Fuchsia, c.Width - mWidth, 0, c.Width, c.Height); mOutlineDrawn = true; break;
        case EdgeEnum.Top: g.FillRectangle(Brushes.Fuchsia, 0, 0, c.Width, mWidth); mOutlineDrawn = true; break;
        case EdgeEnum.Bottom: g.FillRectangle(Brushes.Fuchsia, 0, c.Height - mWidth, c.Width, mWidth); mOutlineDrawn = true; break;
        case EdgeEnum.None:
          if (mOutlineDrawn)
          {
            c.Refresh();
            mOutlineDrawn = false;
          }
          break;
      }

      if (mMouseDown & mEdge != EdgeEnum.None)
      {
        c.SuspendLayout();
        switch (mEdge)
        {
          case EdgeEnum.TopLeft: c.SetBounds(c.Left + e.X, c.Top + e.Y, c.Width, c.Height); break;
          case EdgeEnum.Left: c.SetBounds(c.Left + e.X, c.Top, c.Width - e.X, c.Height); break;
          case EdgeEnum.Right: c.SetBounds(c.Left, c.Top, c.Width - (c.Width - e.X), c.Height); break;
          case EdgeEnum.Top: c.SetBounds(c.Left, c.Top + e.Y, c.Width, c.Height - e.Y); break;
          case EdgeEnum.Bottom: c.SetBounds(c.Left, c.Top, c.Width, c.Height - (c.Height - e.Y)); break;
        }
        c.ResumeLayout();
      }
      else
      {
        if (e.X <= (mWidth * 4) & e.Y <= (mWidth * 4))
        {
          c.Cursor = Cursors.NoMove2D;
          mEdge = EdgeEnum.TopLeft;
        }
        else if (e.X <= mWidth)
        {
          c.Cursor = Cursors.NoMoveHoriz;
          mEdge = EdgeEnum.Left;
        }
        else if (e.X > c.Width - (mWidth + 1))
        {
          c.Cursor = Cursors.NoMoveHoriz;
          mEdge = EdgeEnum.Right;
        }
        else if (e.Y <= mWidth)
        {
          c.Cursor = Cursors.NoMoveVert;
          mEdge = EdgeEnum.Top;
        }
        else if (e.Y > c.Height - (mWidth + 1))
        {
          c.Cursor = Cursors.NoMoveVert;
          mEdge = EdgeEnum.Bottom;
        }
        else
        {
          c.Cursor = Cursors.Default;
          mEdge = EdgeEnum.None;
        }
      }
    }

    private void mControl_MouseLeave(object sender, EventArgs e)
    {
      Control c = (Control)sender;
      mEdge = EdgeEnum.None;
      c.Refresh();
    }
  }

  public class Class_Library
  {
    public delegate bool m_Find_DuplicateInstance(string usedid, ref InstanceObject[] param, int count);
    public delegate bool m_Find_FreeInstance(ref int useindex, ref InstanceObject[] param, int count);
    public delegate void m_ClearInstance(int instance, ref InstanceObject[] param);
    //public m_Find_DuplicateInstance Find_DuplicateInstance;

    #region "  Structure declaration  "

    public struct InstanceObject
    {
      public DevExpress.XtraEditors.XtraForm instanceform;
      public string instanceusedid;
      public bool instanceused;
    }

    public struct EndpointStruct
    {
      public string localaddress;
      public string internetaddress;
      public int bufferfactor;
      public DateTime receivetimeout;
      public bool internetstate;
    }

    #endregion

    #region "  Variables declaration  "

    Microsoft.Win32.RegistryKey regkey = null;

    const string regEpname1 = "Local";
    const string regEpname2 = "Internet";
    const string regEpname3 = "BF";
    const string regEpname4 = "RTO";
    const string regEpname5 = "UINT";

    string keypath = @"Software\M9reg\Endpointconfig";

    #endregion

    public Class_Library()
    {
      regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keypath);
    }

    public void ClearInstance(int instance, ref InstanceObject[] param)
    {
      param[instance].instanceform = null;
      param[instance].instanceused = false;
      param[instance].instanceusedid = "";
    }

    public bool Find_DuplicateInstance(string usedid, ref InstanceObject[] param, int count)
    {
      bool xret = false;

      for (int i = 0; i < count; i++)
      {
        if (param[i].instanceusedid == usedid)
        {
          xret = true;
          param[i].instanceform.Focus();
          break;
        }
      }

      return xret;
    }

    public bool Find_FreeInstance(ref int useindex, ref InstanceObject[] param, int count)
    {
      bool xret = true;
      int i = 0;

      do
      {
        if (i >= count)
        {
          xret = false;
          break;
        }
        i++;
      } while (param[i - 1].instanceused);

      useindex = i - 1;

      return xret;
    }

    /// <summary>
    /// Reads path of default browser from registry
    /// </summary>
    /// <returns></returns>
    public static string GetDefaultBrowserPath()
    {

      using (Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command", false)) //htmlfile\shell\open\command
      {
        // get default browser path
        return ((string)registryKey.GetValue(null, null)).Split('"')[1];
      }

    }

    public EndpointStruct LoadAddressSetting()
    {
      EndpointStruct epret = new EndpointStruct();

      byte[] data_local = null;
      byte[] data_internet = null;
      byte[] data_Bfactor = null;
      byte[] data_Rtimeout = null;

      bool chkstate = false;

      data_local = (byte[])regkey.GetValue(regEpname1);
      data_internet = (byte[])regkey.GetValue(regEpname2);
      data_Bfactor = (byte[])regkey.GetValue(regEpname3);
      data_Rtimeout = (byte[])regkey.GetValue(regEpname4);
      chkstate = Convert.ToBoolean(regkey.GetValue(regEpname5));

      if (data_local == null || data_internet == null)
      {
        epret.localaddress = "";
        epret.internetaddress = "";
        epret.bufferfactor = 1;
        epret.receivetimeout = DateTime.Parse(DateTime.Now.ToShortDateString() + " 00:10:00");
      }
      else
      {
        epret.localaddress = System.Text.ASCIIEncoding.ASCII.GetString(data_local);
        epret.internetaddress = System.Text.ASCIIEncoding.ASCII.GetString(data_internet);
        epret.bufferfactor = Convert.ToInt32(System.Text.ASCIIEncoding.ASCII.GetString(data_Bfactor));
        string Xs = System.Text.ASCIIEncoding.ASCII.GetString(data_Rtimeout);
        epret.receivetimeout = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + Xs);
      }
      epret.internetstate = chkstate;

      return epret;
    }

    /// <summary>
    /// Open specific URL by default web browser.
    /// </summary>
    /// <param name="urlpath">Specify URL to be open.</param>

    public void SaveAddressSetting(EndpointStruct epret)
    {
      byte[] data = null;
      int chkstate = 0;

      data = System.Text.ASCIIEncoding.ASCII.GetBytes(epret.localaddress);
      regkey.SetValue(regEpname1, data, Microsoft.Win32.RegistryValueKind.Binary);

      data = System.Text.ASCIIEncoding.ASCII.GetBytes(epret.internetaddress);
      regkey.SetValue(regEpname2, data, Microsoft.Win32.RegistryValueKind.Binary);

      data = System.Text.ASCIIEncoding.ASCII.GetBytes(epret.bufferfactor.ToString());
      regkey.SetValue(regEpname3, data, Microsoft.Win32.RegistryValueKind.Binary);

      data = System.Text.ASCIIEncoding.ASCII.GetBytes(epret.receivetimeout.ToLongTimeString());
      regkey.SetValue(regEpname4, data, Microsoft.Win32.RegistryValueKind.Binary);

      if (epret.internetstate)
        chkstate = 1;
      regkey.SetValue(regEpname5, chkstate, Microsoft.Win32.RegistryValueKind.DWord);
    }

    public string tetext(int number, bool fte)
    {
      /*	number 1-90: System Caption
       *	number 71-90: Credential input data caption
       *	number 91-100: Import/Export Setting Caption
       *	number 101-200: GL Caption	*/

      //--- Varied length variables
      string msg = "";

      switch (number)
      {
        case 1: msg = fte ? "ข้อมูลผู้ใช้งานระบบ" : "User Information";
          break;
        case 2: msg = fte ? "เข้าสู่ระบบ" : "Log on";
          break;
        case 3: msg = fte ? "ระบบฐานข้อมูล" : "Database System";
          break;
        case 4: msg = fte ? "บริษัททำการ" : "Company Database";
          break;
        case 5: msg = fte ? "รายละเอียดบริษัททำการ" : "Company Detail";
          break;
        case 6: msg = fte ? "ข้อกำหนดการเชื่อมต่อบริการ" : "Endpoint Address";
          break;
        case 7: msg = fte ? "ข้อกำหนด E-mail" : "E-mail Setting";
          break;
        case 8: msg = fte ? "ตัวแปรระบบ" : "Default Setup";
          break;
        case 9: msg = fte ? "นำข้อมูลเข้าจากระบบ MAC-5" : "Convert data from MAC-5 system";
          break;
        case 10: msg = fte ? "จบการใช้งานระบบ MacNet" : "End MacNet Solution";
          break;
        case 11: msg = fte ? "กลุ่มและผู้ใช้งาน" : "User and Group";
          break;
        case 12: msg = fte ? "รหัสผู้ใช้งาน" : "User";
          break;
        case 13: msg = fte ? "กลุ่มผู้ใช้งาน" : "Group";
          break;
        case 14: msg = fte ? "ผู้ใช้งานระบบ" : "Credentials";
          break;
        case 15: msg = fte ? "ออกจากระบบ" : "Log off";
          break;
        case 16: msg = fte ? "รูปแบบ" : "Appearance";
          break;
        case 17: msg = fte ? "การใช้งาน" : "Usage";
          break;
        case 18: msg = fte ? "ปิดฟอร์มงานทั้งหมด" : "Close all forms";
          break;
        case 19: msg = fte ? "ผู้ใช้งานและกลุ่มงาน" : "User & Unit";
          break;
        case 20: msg = fte ? "เลือกทั้งหมด" : "Select all";
          break;
        case 21: msg = fte ? "ยกเลิกการเลือกทั้งหมด" : "Deselect all";
          break;
        case 22: msg = fte ? "คืนค่ารูปแบบเริ่มต้น" : "Restore the default layout";
          break;

        // Credential input data
        case 71: msg = fte ? "รหัสผู้ใช้" : "User code";
          break;
        case 72: msg = fte ? "กลุ่มหลัก" : "Group";
          break;
        case 73: msg = fte ? "สมาชิกของ" : "Member Of";
          break;
        case 74: msg = fte ? "ชื่อ (ไทย)" : "Name (TH)";
          break;
        case 75: msg = fte ? "ชื่อ (อังกฤษ)" : "Name (EN)";
          break;
        case 76: msg = fte ? "รหัสผ่าน" : "Password";
          break;
        case 77: msg = fte ? "ยืนยันรหัสผ่าน" : "Confirm password";
          break;
        case 78: msg = fte ? "ระดับ" : "Level";
          break;
        case 79: msg = fte ? "อีเมล์" : "E-mail";
          break;
        case 80: msg = fte ? "รหัสผ่านการอนุมัติ" : "Approval password";
          break;
        case 81: msg = fte ? "ยืนยันรหัสผ่านการอนุมัติ" : "Confirm approval password";
          break;
        case 82: msg = fte ? "รหัส" : "Code";
          break;
        case 83: msg = fte ? "ชื่อกลุ่ม" : "Group name";
          break;
        case 84: msg = fte ? "สมาชิก" : "Member";
          break;
        case 85: msg = fte ? "รหัสกลุ่ม" : "Group code";
          break;
        case 86: msg = fte ? "ชื่อกลุ่ม (ไทย)" : "Group name (TH)";
          break;
        case 87: msg = fte ? "ชื่อกลุ่ม (อังกฤษ)" : "Group name (EN)";
          break;
        case 88: msg = fte ? "สมาชิก" : "Members";
          break;

        // Import/Export Setting
        case 91: msg = fte ? "นำเข้าการตั้งค่า" : "Import Setting";
          break;
        case 92: msg = fte ? "ส่งออกการตั้งค่า" : "Export Setting";
          break;
        case 93: msg = fte ? "รูปแบบไฟล์ไม่ถูกต้อง ยกเลิกงานที่ทำ" : "The file format is invalid. Cancel this job.";
          break;
        case 94: msg = fte ? "ไม่สามารถเขียนข้อมูลได้ ยกเลิกงานที่ทำ" : "Unable to write data. Cancel this job.";
          break;
        case 95: msg = fte ? "ข้อมูลภายในไฟล์มีการเปลี่ยนแปลง ยกเลิกงานที่ทำ" : "Data within the file has changed. Cancel this job.";
          break;

        //"ระบบบัญชีแยกประเภท", "General Ledger"
        case 101: msg = fte ? "ระบบบัญชีแยกประเภท" : "General Ledger";
          break;
        case 102: msg = fte ? "ยอดยกมา" : "Balance Brought Forward";
          break;
        case 103: msg = fte ? "ตัวแปร" + tetext(101, true) : "Balance Brought Forward";
          break;
        case 104: msg = (fte ? "รายการ" : "List ") + tetext(101, fte);
          break;
        case 105: msg = (fte ? "รายการใบสำคัญทั้งหมด" : "List all GL vouchers");
          break;
        case 106: msg = (fte ? "รายการใบสำคัญชั่วคราว" : "List Temporary vouchers");
          break;
        case 107: msg = (fte ? "รายงาน" + tetext(101, fte) : tetext(101, fte) + " Reports");
          break;
        default: msg = "";
          break;
      }

      return msg;
    }

  }

  public class Class_Cryptography
  {
    #region "  Key and vector constant  "

    char vbNullChar = Convert.ToChar(0);

    public static string DESkey = "Sp@dP8Pb";
    public static byte[] DESiv = { 94, 232, 238, 71, 99, 108, 143, 165 };
    public static byte[] TDESkey = { 166, 216, 160, 35, 120, 7, 228, 225, 251, 162, 162, 27, 26, 190, 23, 110, 46, 83, 127, 119, 199, 30, 180, 176 };
    public static byte[] TDESiv = { 216, 94, 249, 141, 226, 29, 155, 92 };
    public static string[] AESkey = new string[366];

    #endregion

    public Class_Cryptography()
    {
      string _key = "";
      for (int i = 0; i < 366; i++)
      {
        switch (i)
        {
          case 0:
            _key = "6cd3ae498eb14c5387d4809dd3b14185";
            break;
          case 1:
            _key = "05e9ecac8cb1417e9804091d99f8a532";
            break;
          case 2:
            _key = "86168f14c932471e9a1c9f3dde48d7ef";
            break;
          case 3:
            _key = "897c1175491b485992d21c8f1378a813";
            break;
          case 4:
            _key = "c89f14251c7944edb73ee43d03a6cb8b";
            break;
          case 5:
            _key = "397aca1bc63b4d54978240fb74db8d09";
            break;
          case 6:
            _key = "794053a080e84617916cd1cae4e2d725";
            break;
          case 7:
            _key = "c3f2b31c094b4e12b629f675373e5030";
            break;
          case 8:
            _key = "181dda21017542f480064f53359c314a";
            break;
          case 9:
            _key = "3ebc03b4f78341e38758b42106965b1a";
            break;
          case 10:
            _key = "98868d5cec3544bbbe764d22398c0eb5";
            break;
          case 11:
            _key = "a3540fd3f9c14942a1695eeaadf2f630";
            break;
          case 12:
            _key = "aa83607706314f8f98374f55691d0f39";
            break;
          case 13:
            _key = "2f15c663c79845b7a4faf0fd24d276bc";
            break;
          case 14:
            _key = "e24c969f89be43cc8ceca864f4f4b59b";
            break;
          case 15:
            _key = "39063f6a7ea9489cbe623e29d58dc5d6";
            break;
          case 16:
            _key = "03a1a597c9eb44dbbfa91e4e4f14bf01";
            break;
          case 17:
            _key = "5d19ef51f57048f1ba7e3e1619baf57b";
            break;
          case 18:
            _key = "ef122f072cba473fb53ecabd4638c3f0";
            break;
          case 19:
            _key = "663473ebd3664ef2bfdbde7457ab70b3";
            break;
          case 20:
            _key = "9f64b6b66d804a6094bcf0dae76966fd";
            break;
          case 21:
            _key = "8fc8cf4d3988448b9d2f575661d24aeb";
            break;
          case 22:
            _key = "6c59579e3e3e45fb8684ca387ff610e9";
            break;
          case 23:
            _key = "6c7cca2232754aa3b604bd16b56606a1";
            break;
          case 24:
            _key = "59838336ac804dbab8bc5fd8f0bc7217";
            break;
          case 25:
            _key = "9489bc6087e74941990c29aebf72b0ef";
            break;
          case 26:
            _key = "195e7e4696ef4d1bb2c83ca10f127a87";
            break;
          case 27:
            _key = "1a7869c156074bd7a4c96ee9320e8cdc";
            break;
          case 28:
            _key = "f2aff1cccbef42f9ab1b403b1e13e5eb";
            break;
          case 29:
            _key = "595b438cf5694ca09ec69c66a16c8a62";
            break;
          case 30:
            _key = "647b8844a9634ebe9445bd04030cef64";
            break;
          case 31:
            _key = "2f6f669a7f864b70aeee95603f811c24";
            break;
          case 32:
            _key = "e0bb317f6ea2400a96c13e04ecb54cb9";
            break;
          case 33:
            _key = "c65d1787c8fb4f65aeb8216ab2003bec";
            break;
          case 34:
            _key = "580395e2374845c2a4cdcbc9705e0d03";
            break;
          case 35:
            _key = "c2f38a93b9ec46fe86a969efd1c88e65";
            break;
          case 36:
            _key = "71d45aa8c151438492575fe7b09c8510";
            break;
          case 37:
            _key = "dc0fc9cbabd54da7b16867a5e49a0714";
            break;
          case 38:
            _key = "31654f9ede7e4d5198705d74c10b2de7";
            break;
          case 39:
            _key = "9cbfa9cb3f414708a9fc3b83e825ebc0";
            break;
          case 40:
            _key = "dd9f26bcc64240eaa0b1bac8d07ef409";
            break;
          case 41:
            _key = "14709eecd52e4e28bdf751085aee5b70";
            break;
          case 42:
            _key = "1e4217b717de43539cb12880c59a0cfc";
            break;
          case 43:
            _key = "e8fd4fb57ce74fe1a12553c6946bbbaf";
            break;
          case 44:
            _key = "c640ba72a1d741ba86e49fa5870bee36";
            break;
          case 45:
            _key = "8758ba9e2aba44c5a1bce2fa6d26b6eb";
            break;
          case 46:
            _key = "462311bac04d47d5aaa7b43ce6897e42";
            break;
          case 47:
            _key = "8b8bc58c37a4434faed53af7f0fdda10";
            break;
          case 48:
            _key = "f61dbff3f8b040498b8213a650a1edc9";
            break;
          case 49:
            _key = "059f2521af4846049de0f646c33aedd6";
            break;
          case 50:
            _key = "c220f8cafc374377a6e8d1951b84d10c";
            break;
          case 51:
            _key = "a6220af9d25b48d0aae857d25c5fcbc1";
            break;
          case 52:
            _key = "c03ba75a784a4757ac7af7b974eb01d7";
            break;
          case 53:
            _key = "a8e6446a4fc445e2851463d769942ec6";
            break;
          case 54:
            _key = "d327b5e3d33845769121b483538d25a4";
            break;
          case 55:
            _key = "a781a6b311e64b55bc0e11d51b8a6bfe";
            break;
          case 56:
            _key = "a19d77485e014dbf95109266beaa2743";
            break;
          case 57:
            _key = "e3d203e141ea44009595b63d5bac9cc3";
            break;
          case 58:
            _key = "4f96af290d3d4a3594de21b061b308e9";
            break;
          case 59:
            _key = "6d826ad5711e48d8bbba9744cbfbaa17";
            break;
          case 60:
            _key = "f1a732c7cd4343e59c9f99e603d62ed4";
            break;
          case 61:
            _key = "f9ae39b02e5d495d8fa8fc11b2515e84";
            break;
          case 62:
            _key = "5e31375420c84b1ea45cf302744cda1b";
            break;
          case 63:
            _key = "6143a6d55ce74231ad437c4b3208509b";
            break;
          case 64:
            _key = "96390736771c45b4a3801bd3317673ed";
            break;
          case 65:
            _key = "35fc1fef28b24f5da8f929de3ac9e581";
            break;
          case 66:
            _key = "cff7ba71b7604fdbab8bdaffb12dcaf2";
            break;
          case 67:
            _key = "6ff80b85814b4198a945837c6814b225";
            break;
          case 68:
            _key = "499240530aa8455ea831724d9beeed3e";
            break;
          case 69:
            _key = "709a1723f41d4911a1dbd7199a9d7d31";
            break;
          case 70:
            _key = "41041f8330814f87b6546c0f9e217135";
            break;
          case 71:
            _key = "39f52f3e0c4e4a5d8a1704712ba5ce55";
            break;
          case 72:
            _key = "518d6f023d754847a2229a0ae057833e";
            break;
          case 73:
            _key = "cc5aee8257d04406a0d604533ae8169f";
            break;
          case 74:
            _key = "798d4b76af11439d94bd9f10c5228a9b";
            break;
          case 75:
            _key = "dc956f4452f046a7ad6fef4a62b6443e";
            break;
          case 76:
            _key = "8779ad4c25db4107b09d4bff0c78842b";
            break;
          case 77:
            _key = "06c3f31da1e24452925212a6adc7eff2";
            break;
          case 78:
            _key = "a91c7572bfa14a4c982e7de8d7ad390e";
            break;
          case 79:
            _key = "929ae2a0477c45e989efee1057375369";
            break;
          case 80:
            _key = "9ffe96f11a234e03b1fcabb5cc322e82";
            break;
          case 81:
            _key = "ab00f0a78fb54a1eb49af90b597435ba";
            break;
          case 82:
            _key = "070c5b9a20f642a2b9a0529369185cb9";
            break;
          case 83:
            _key = "04c0c68c385e496fa8fbf2728b896c82";
            break;
          case 84:
            _key = "d96ca54b64cc47d5a4addec4245af06a";
            break;
          case 85:
            _key = "60a8690c2518453ea7fd0e73d3ed0075";
            break;
          case 86:
            _key = "631cda21126445ba965eed6dff10f382";
            break;
          case 87:
            _key = "1c77aaf74f574caaa3a71a8b9912e3d4";
            break;
          case 88:
            _key = "5418ea304f384530b8229fa470a05a33";
            break;
          case 89:
            _key = "74de23abdb8d49fb827313cf4da7c4ac";
            break;
          case 90:
            _key = "540bfc14425741529db91d40a0af4196";
            break;
          case 91:
            _key = "0caf6d102a294a6dae2530468eb4b569";
            break;
          case 92:
            _key = "3d7e817136de4fe799b57338c48441a9";
            break;
          case 93:
            _key = "cccfd140eb8449c5a871bc77c3f66fa7";
            break;
          case 94:
            _key = "38963cc8827b481bb733c64f4e678fce";
            break;
          case 95:
            _key = "6a5593d69fde498ba2e10b7df73d2603";
            break;
          case 96:
            _key = "41ea55865b9b427e8e2d17c9c040b51b";
            break;
          case 97:
            _key = "6ca12838104043599f8e3a969d85b60d";
            break;
          case 98:
            _key = "8b761aaa9561421c849eb195a3653184";
            break;
          case 99:
            _key = "4e2956601e5c42e8868ed871031036aa";
            break;
          case 100:
            _key = "88853bc845754008afbffa54bcf45299";
            break;
          case 101:
            _key = "2f35e2698e034629b95a26219d1ee8a3";
            break;
          case 102:
            _key = "65a71c0dfc474e6284303c636cfab643";
            break;
          case 103:
            _key = "7183563b2d2c4adb8413fa04f2347012";
            break;
          case 104:
            _key = "ceec55c7c4be422eb87ebad4f1c5fb48";
            break;
          case 105:
            _key = "f609999be191428b917804c800b64604";
            break;
          case 106:
            _key = "ed166dfd9124406480eeadef1d7c1121";
            break;
          case 107:
            _key = "174d0c3cbd0d4cc0b554b9ac2869d5fd";
            break;
          case 108:
            _key = "582c800f4c1f4dab874fed60dd82735d";
            break;
          case 109:
            _key = "1e29deff9ac546d59b0735727b3791d6";
            break;
          case 110:
            _key = "a3416b1b8496424f9c1400ac5c64059b";
            break;
          case 111:
            _key = "eccad3bd909a46e7ab10868b8a3af9b7";
            break;
          case 112:
            _key = "a50d582e59c745ebb5a661cce869be1c";
            break;
          case 113:
            _key = "4de2c97d347841748b8e2882812940da";
            break;
          case 114:
            _key = "ef8c6ed2d528443994b003f76bc3b135";
            break;
          case 115:
            _key = "26c1d61c63614674a821084e1bdf51e9";
            break;
          case 116:
            _key = "4047003623d5453caf225cf40a3b6c37";
            break;
          case 117:
            _key = "4254b10cf2d84896ae522e9aa3139140";
            break;
          case 118:
            _key = "f9957483ccf349cd859408406772179d";
            break;
          case 119:
            _key = "bed8671b8e364369bcee53f95aaea1e4";
            break;
          case 120:
            _key = "cae6ae9c48a2401db5dfd6819f893daf";
            break;
          case 121:
            _key = "66dcb940fae3435fa4f4a1dc91bb8431";
            break;
          case 122:
            _key = "b6b7049b0dcc4b23bbbc33e86c30793f";
            break;
          case 123:
            _key = "1a183520e3e74de4bfdac93beaab8209";
            break;
          case 124:
            _key = "0e3b30a85f9b4684a8bcd386aaec4fbd";
            break;
          case 125:
            _key = "ffff3fc045854705b46f60919ebeeadf";
            break;
          case 126:
            _key = "2c1c2ceb65524d2fb79e611094e17938";
            break;
          case 127:
            _key = "123c0080160a441396161027bfc1c936";
            break;
          case 128:
            _key = "3d96ec617b9c4379a613cdd81bcb7a54";
            break;
          case 129:
            _key = "8c08e88430584f8e9e7ce51c2c2de1b9";
            break;
          case 130:
            _key = "744665b0f4f3492d99c6abf4a3206aeb";
            break;
          case 131:
            _key = "d2120ee40e5447d4a59879acbb5bc7c1";
            break;
          case 132:
            _key = "e676d87d9ecc475881aa2338cb31e8d3";
            break;
          case 133:
            _key = "5a64ae5060774c3b9b811f82c439da24";
            break;
          case 134:
            _key = "e7c8be6a6429485ca5449ddc2a141a57";
            break;
          case 135:
            _key = "fe135868eb17442cabab8a8f3d4ca067";
            break;
          case 136:
            _key = "f5895d0658eb4ea2ba5dd604fbb5cc60";
            break;
          case 137:
            _key = "2dff61cbb5494173a32c12083dfb87bf";
            break;
          case 138:
            _key = "770365c51167470d91c3c03b0d7d18f7";
            break;
          case 139:
            _key = "a3d3c3e587144072ae9b8b0e4c388856";
            break;
          case 140:
            _key = "c37d3dfcc73144a8b8367b1799d84710";
            break;
          case 141:
            _key = "93eaa8184c59476fb6e2c36783f8dd2b";
            break;
          case 142:
            _key = "abe76b84322541b39e1d4055f9751b4e";
            break;
          case 143:
            _key = "55b0f624c0ba4fd3889cc37e701d4d9f";
            break;
          case 144:
            _key = "c1b169e9555c42d69490c76d4028d652";
            break;
          case 145:
            _key = "635a09cd584348919f06528399559c57";
            break;
          case 146:
            _key = "28079c6d1f624670aeaf3fc3f3dc6d0a";
            break;
          case 147:
            _key = "a3275466467a48b29c451f48f11659e2";
            break;
          case 148:
            _key = "924fcdc280334e4db20e48e39093a77a";
            break;
          case 149:
            _key = "d2843eec2a8043a7b240c52e6717e8e1";
            break;
          case 150:
            _key = "c18482c12a3f40a1b0b30bea0f3f872e";
            break;
          case 151:
            _key = "d0f9a0089f014d5d9a5f397f878fff49";
            break;
          case 152:
            _key = "d48b206dc3204adbb3797dcfc4136209";
            break;
          case 153:
            _key = "4328826583aa4b38842b575058808bd0";
            break;
          case 154:
            _key = "a3dd399ccbdb44c188e58431da8d7887";
            break;
          case 155:
            _key = "50958e96b5494f0d914104d799949dba";
            break;
          case 156:
            _key = "49d826e627384e5e8142e6a0bba7c3e0";
            break;
          case 157:
            _key = "0cddf32e7ab841cd90de7380b4fac145";
            break;
          case 158:
            _key = "26caf17774cf434a8f60aca0104107b6";
            break;
          case 159:
            _key = "78ff0fdb818c414387ad48bf148ce2a2";
            break;
          case 160:
            _key = "80b360c8f01446a8981980d12bec6949";
            break;
          case 161:
            _key = "77741368ce3f453da41a34d44111c623";
            break;
          case 162:
            _key = "9bfdf386c4f742e1a5a12c3dcf4bef33";
            break;
          case 163:
            _key = "69a864ba9b62405b8bda75efc200ab8d";
            break;
          case 164:
            _key = "35545dac949242ada0b0788ba79050a8";
            break;
          case 165:
            _key = "1ba26f43ba2d41e2879ba5107ffcbb98";
            break;
          case 166:
            _key = "8d11e840f2714153bbede4c896aae4f5";
            break;
          case 167:
            _key = "c30e0898afa1421381d97d90057e7474";
            break;
          case 168:
            _key = "6837520ed89c4f9ca472ebaeb3d6b025";
            break;
          case 169:
            _key = "1c34c9aff4344a789e53d671897d21c3";
            break;
          case 170:
            _key = "7dc0f9e079e04edea6b3d53489041ff1";
            break;
          case 171:
            _key = "8f6883c5f9164fbaa444ab11bfe46f08";
            break;
          case 172:
            _key = "b6022d9a0db64ea18f480e15d763b118";
            break;
          case 173:
            _key = "46ec55bd2d64431fb4ca398789ad7ff5";
            break;
          case 174:
            _key = "560b28b1b5c244ecb47ac0b0c7a622fa";
            break;
          case 175:
            _key = "e5982b14472a46a8ad01fade47ae21f9";
            break;
          case 176:
            _key = "553aafc61da340358f5cf25346ef32c1";
            break;
          case 177:
            _key = "5434853c8a56456db5c46b422ca6fe10";
            break;
          case 178:
            _key = "bd897992adf442bfa838fc64f494356e";
            break;
          case 179:
            _key = "024926808ee14674b5477f62213f55b9";
            break;
          case 180:
            _key = "053fd7e2c501407286988a58f26de706";
            break;
          case 181:
            _key = "c440e9e89a4b4de993dabd878b940e65";
            break;
          case 182:
            _key = "7a5be60053be4567b77302832c3ee3cf";
            break;
          case 183:
            _key = "fe5f2f93b4964458bd6a55cf509dc58f";
            break;
          case 184:
            _key = "d0b148b075eb4962b35e3dee84b3e6d7";
            break;
          case 185:
            _key = "5ff44cbcc42a4aeb905cf25f65a90ce7";
            break;
          case 186:
            _key = "4b4b26fe593a43d9b44d9473a0929fa4";
            break;
          case 187:
            _key = "8402985378944cd893574bf27af3d25f";
            break;
          case 188:
            _key = "17a76d363702426ca561c0b7619de7eb";
            break;
          case 189:
            _key = "d4217d06b1e6432da16d9b8e61e4c8d3";
            break;
          case 190:
            _key = "f37602a0548843568cffc3f72004a9c7";
            break;
          case 191:
            _key = "9df1422e196e4d7a8cd15c2077c2b6bf";
            break;
          case 192:
            _key = "11ec502b3ed64a76b3783e8acba23b2e";
            break;
          case 193:
            _key = "2fb5d73fe57344c691ae2ceab57e1c47";
            break;
          case 194:
            _key = "5580f3e1139f4c9a91ed2c4021459c27";
            break;
          case 195:
            _key = "05dec8c40477449283d2114004abb241";
            break;
          case 196:
            _key = "d2b55f5bb688495aaa5fc284a0d5b093";
            break;
          case 197:
            _key = "52c11e5943e34d54b25bc0beda23722c";
            break;
          case 198:
            _key = "88fab8b3552e4a51a2fa157c5fd8fad3";
            break;
          case 199:
            _key = "02d9ff5265a44f17b1cba22bcdf43001";
            break;
          case 200:
            _key = "44e293faec7544baaef4c44efee2d890";
            break;
          case 201:
            _key = "7367fa2b00cf4991a2155a040c3780e4";
            break;
          case 202:
            _key = "5c78aa4f9a4541b5a19f9954945e7a07";
            break;
          case 203:
            _key = "eaacbdad715646809e25d8efb292a373";
            break;
          case 204:
            _key = "cadfaf36ea2447389ec01ef743c9cd34";
            break;
          case 205:
            _key = "e715d7ce759148218c95114af82628d9";
            break;
          case 206:
            _key = "ceda6a5393df463bb6cdd67c22ef9438";
            break;
          case 207:
            _key = "5f312468d0ef4e398c610c17506f7e3b";
            break;
          case 208:
            _key = "bd28186f2a0446ae8ae4b38e96a41d56";
            break;
          case 209:
            _key = "d9c37f9688f34e1988292a177e5affde";
            break;
          case 210:
            _key = "8e7c8e7da5214f9a9f2f44bb6edb5891";
            break;
          case 211:
            _key = "4f67f48e5b274f1589a533dde826cdd9";
            break;
          case 212:
            _key = "9900e3e327504b698640cae8d1985fa9";
            break;
          case 213:
            _key = "f9656ee0ef3d4d1ebc1987a0f21a9d3f";
            break;
          case 214:
            _key = "d52321e0643c4413a465f39a02555f52";
            break;
          case 215:
            _key = "857ce88391c141e1809fd367fca161b6";
            break;
          case 216:
            _key = "f92966a1ffa24e1b9a12b7791cc3aa90";
            break;
          case 217:
            _key = "4226a916e58b484990f1bffb928efab8";
            break;
          case 218:
            _key = "3b1b36b566294ec2822614c89c4715c4";
            break;
          case 219:
            _key = "16ac2db124b847e5b7f90d4f90919e44";
            break;
          case 220:
            _key = "249dbeee84be4f3f8747709641df33cf";
            break;
          case 221:
            _key = "8af13671b32545c5a41873e3f287fca6";
            break;
          case 222:
            _key = "3158224232ca4b179d47a5c32861f5df";
            break;
          case 223:
            _key = "c31c9dcbc486482cb3f743569c08ad45";
            break;
          case 224:
            _key = "de127d3b81cc4d4982fe1ae599ab977a";
            break;
          case 225:
            _key = "44e200e6c0714abe9a17109e44ffa937";
            break;
          case 226:
            _key = "6d6e1beddba742bf98408e53a0b0fd0d";
            break;
          case 227:
            _key = "3525e268c7b2420da1f7d378cd9abeaf";
            break;
          case 228:
            _key = "f3564877f9ed42d29284aaff38eac9af";
            break;
          case 229:
            _key = "ae6d333e331247f090b545ac9bdeb723";
            break;
          case 230:
            _key = "4480e94cc71c4f53b4c58388fd4903a4";
            break;
          case 231:
            _key = "381776654faa40a1a4049d094798e605";
            break;
          case 232:
            _key = "996ae28ade184a51b05575184c2af1ca";
            break;
          case 233:
            _key = "baa947cc8c4b470b8765901e1eb5d31f";
            break;
          case 234:
            _key = "0377070b404d40e8a0024b1084b545d6";
            break;
          case 235:
            _key = "a51a447dc29a435d834f37c5fb2bcb6f";
            break;
          case 236:
            _key = "377d3d25063848709f37b1bfcb41cb02";
            break;
          case 237:
            _key = "5489bbe834a447ffbcf81b14ea0b535f";
            break;
          case 238:
            _key = "accf559fc0be460faf61242660484f12";
            break;
          case 239:
            _key = "118501056b5d4e298515ec8a96ec3953";
            break;
          case 240:
            _key = "1e8e71180ae54fa7b392a8f7bca41c26";
            break;
          case 241:
            _key = "5972d605c83548a9b83b87e8256ee342";
            break;
          case 242:
            _key = "5db5fd07b3dd4a9cbe582fb37bca28a3";
            break;
          case 243:
            _key = "0c5b77c21e0747bdaa36e3f63eef1bb0";
            break;
          case 244:
            _key = "d7b76adfa85142aa8e03026325098f79";
            break;
          case 245:
            _key = "d1aa95769f9345ecbaa89f064e429f88";
            break;
          case 246:
            _key = "46c291dd7f6b45beb86033306845b00b";
            break;
          case 247:
            _key = "a5369499553e44748b52dcfff0f60c32";
            break;
          case 248:
            _key = "9081b66868b449f089667af1843b6374";
            break;
          case 249:
            _key = "c6bbe6ac83954e28bed2af72c5c728fb";
            break;
          case 250:
            _key = "eee10094f01e414bbe58ed93a7cae73c";
            break;
          case 251:
            _key = "bc71aa80aabe480ca215eb62871edc6f";
            break;
          case 252:
            _key = "1bc3e1ae14a242eabec6abc99a237346";
            break;
          case 253:
            _key = "b972d6f85f4e4397878e18793dd7f347";
            break;
          case 254:
            _key = "325aa3bf0cae41888448f52b19c0d323";
            break;
          case 255:
            _key = "1c47243c4e984a6ebf1f0e5d41ac4876";
            break;
          case 256:
            _key = "fd29ddd0f4d141e1bf48a321525856de";
            break;
          case 257:
            _key = "380ca0c415774a00b1f35c2f7b70a0c1";
            break;
          case 258:
            _key = "e33807787512496f8399aac35ca00cab";
            break;
          case 259:
            _key = "0e91b545445e4bbfa40533d820c51c46";
            break;
          case 260:
            _key = "39ec73907f124fe4b5648eaf09b66921";
            break;
          case 261:
            _key = "ad166655048e498ab61f6099d905515d";
            break;
          case 262:
            _key = "04df468f98464b67bb780fe41d41befb";
            break;
          case 263:
            _key = "0966831df41d41e1a98e58bc2a936af6";
            break;
          case 264:
            _key = "6f57b021b3a9440dba38538a80d2125e";
            break;
          case 265:
            _key = "dda6b7135b204efea350ae9b19bff164";
            break;
          case 266:
            _key = "79d490cd0fd943d48c3848154bf4078e";
            break;
          case 267:
            _key = "cfea518913e148bbb419beab2d347612";
            break;
          case 268:
            _key = "f534304d46ce4ae193ee2997cb860959";
            break;
          case 269:
            _key = "13d5be3a925a479aad546a7407692beb";
            break;
          case 270:
            _key = "fa71a888a6e6406e8d54d8be429142b1";
            break;
          case 271:
            _key = "c8ff8f6a7637432ea366a03b1fec2353";
            break;
          case 272:
            _key = "0436466188e34da8b432c8b4aa22546b";
            break;
          case 273:
            _key = "18fc73a8c0474c0cb0b20f8677a7d7ef";
            break;
          case 274:
            _key = "2a7875a6fd994c5eaec2375a68be2e6c";
            break;
          case 275:
            _key = "0f6d9e14e9e14fa48102dd80577fc643";
            break;
          case 276:
            _key = "2f43984d854b4624b8149979446fb76f";
            break;
          case 277:
            _key = "530f6fb2a0684577b9700a0b4afde2ec";
            break;
          case 278:
            _key = "017422f0fe0f411895df3dadbfe35f1a";
            break;
          case 279:
            _key = "93a17054cf69443db9a43043bd0f767a";
            break;
          case 280:
            _key = "c1918cf2361e4e7ab8b14ce2e1b2e79f";
            break;
          case 281:
            _key = "bd4b93b0a33e441b8e6733ce45dca5be";
            break;
          case 282:
            _key = "f6942102165e42c0b5ed5a25a60f85e0";
            break;
          case 283:
            _key = "910640e616b347c8aa577092f5ca6785";
            break;
          case 284:
            _key = "a5535c6b8f814ba0acd4da253a0477af";
            break;
          case 285:
            _key = "19a9718f49ff46218c857c12e56fb7ad";
            break;
          case 286:
            _key = "6f1a6b42e74f4360b0afe11707216a8e";
            break;
          case 287:
            _key = "d2e123e2cebc4dc08d664abfbddc3945";
            break;
          case 288:
            _key = "3226eeb222f9425cbd13038c28028704";
            break;
          case 289:
            _key = "302420a414394215a5bfbe0d9dbb073d";
            break;
          case 290:
            _key = "e3a3597450c743769a4b368875aae779";
            break;
          case 291:
            _key = "5cbd2a3ffcb04fb29fc63c050a969596";
            break;
          case 292:
            _key = "e1397c2349c14a41a695d2db3c4eac73";
            break;
          case 293:
            _key = "606edf72a9274659ad248647194c6ad9";
            break;
          case 294:
            _key = "38f52ece7a4a408a9e417d5542f76e02";
            break;
          case 295:
            _key = "332bb31c9f0b4605bab94b108c9a9060";
            break;
          case 296:
            _key = "d58ee7a8628d40778ef513bdf4d5e7db";
            break;
          case 297:
            _key = "1bb9525cf24941d4891e301cc3cef257";
            break;
          case 298:
            _key = "8c40b60961a8407bad2c29b4109e527f";
            break;
          case 299:
            _key = "b21ef5c2b3ed47a29e43149e4ee7983e";
            break;
          case 300:
            _key = "f0f2e9e79ab24a419b3b50430cdc5c1e";
            break;
          case 301:
            _key = "ab0aa493926a4e60b4a988a685567571";
            break;
          case 302:
            _key = "0522a2e226b047fbba53477099005696";
            break;
          case 303:
            _key = "c6a973ad2beb4781bec1b4cbdd04e4de";
            break;
          case 304:
            _key = "a93f47c21803452a9ba2a46aeab55905";
            break;
          case 305:
            _key = "8615c3be45904e76bb18cd2e755147eb";
            break;
          case 306:
            _key = "73bb2c5628a5430bb0105eac98c47a51";
            break;
          case 307:
            _key = "b773035457464bb3bf5306e2090a3515";
            break;
          case 308:
            _key = "d7e1c99e6fa7488c99e437749d1d17f3";
            break;
          case 309:
            _key = "ec490e266f694b8eb28c43bc55fa0837";
            break;
          case 310:
            _key = "f6649b316e804fc098f7a815c03db303";
            break;
          case 311:
            _key = "fce5c27a85d54025b3c5b4385843b88f";
            break;
          case 312:
            _key = "c9b95fe50a5f4e2b8bdeb2b43fa3e70a";
            break;
          case 313:
            _key = "9fa5b70b35e9489eae99cdf9079b23fa";
            break;
          case 314:
            _key = "169af1f1f63b458a99699663629a39ad";
            break;
          case 315:
            _key = "97612cc27f774d4da6de7b4beb32b6ee";
            break;
          case 316:
            _key = "f3f3737064db4c3ab85d3279c6102193";
            break;
          case 317:
            _key = "936c04e283f7498a8fff6bbb5421fff6";
            break;
          case 318:
            _key = "d5ebbbc2cc64469ab3ed1fdee6c5e04e";
            break;
          case 319:
            _key = "b16434f4d918496daa33cde5d7320bd8";
            break;
          case 320:
            _key = "c78fd9f0dbb444ab981c6ea1e2d5b927";
            break;
          case 321:
            _key = "6ded2029c39c425b862e581d0e0ebae4";
            break;
          case 322:
            _key = "8a01a2c1c6b8468982b5fc09f55d5b31";
            break;
          case 323:
            _key = "944fe55843bd42cbaf27711bd3fc1a71";
            break;
          case 324:
            _key = "661e63b72135451aa06be39aef37cc2a";
            break;
          case 325:
            _key = "bd1d7e66b2384efcb68588eb8b1acd76";
            break;
          case 326:
            _key = "0f72c169c91a48f1993011d81a5014e9";
            break;
          case 327:
            _key = "57fcf9b40c4241ea8e228e91beb99ef2";
            break;
          case 328:
            _key = "28db6c9ed95847ef83f7a4fb39758cb0";
            break;
          case 329:
            _key = "fc9dab8f350740a58be0041dbaf52129";
            break;
          case 330:
            _key = "cd43b12dfe3c43418a32c69e74262553";
            break;
          case 331:
            _key = "80d9dbc2b6f84af59382746113041acf";
            break;
          case 332:
            _key = "ba23a4ff067a4c31adae0d575b6e9eec";
            break;
          case 333:
            _key = "118d323b424b4933b0c87d2cd487a197";
            break;
          case 334:
            _key = "f69efc12c31945b9a078e70f7fbc60ef";
            break;
          case 335:
            _key = "37b2a14018c44eca82068ccbc23ff9c8";
            break;
          case 336:
            _key = "060a6bc171dc45299825dc64730adbea";
            break;
          case 337:
            _key = "76e99053a798440284ae633814fb4fe3";
            break;
          case 338:
            _key = "6e33ed5828274f77be30b31306f8d460";
            break;
          case 339:
            _key = "b9c3d93148ae47f6b0eee37d94b32a01";
            break;
          case 340:
            _key = "a07a5a7beb0e44bbb0e0a2ef1717d6e3";
            break;
          case 341:
            _key = "0b5da15d401148febe7f3663d856f27d";
            break;
          case 342:
            _key = "ad1a42934f914af396ae6f3036c4111d";
            break;
          case 343:
            _key = "64de3e70a250459ba8213373c39f76f8";
            break;
          case 344:
            _key = "c90d81cbe75646a8afe2e493f6e70fd8";
            break;
          case 345:
            _key = "167f57d6699f4567b91b92b4573e8720";
            break;
          case 346:
            _key = "105ff607becb486fa8e8de747c2aacd0";
            break;
          case 347:
            _key = "59f89cc34d9f435497905d189cfe0d6a";
            break;
          case 348:
            _key = "00634712ea27493fac66570065dac7e3";
            break;
          case 349:
            _key = "981bab48049c44e7ac47e233b4af5f4f";
            break;
          case 350:
            _key = "3e535d32f2614856a50011b5c97a714a";
            break;
          case 351:
            _key = "2cb9194bea1443b0a23e75f583e8e96d";
            break;
          case 352:
            _key = "ef227a6f6f8242e69acbcd60787ba182";
            break;
          case 353:
            _key = "cff6e05c2faf430b867be5dc6d81a6ee";
            break;
          case 354:
            _key = "097e83f8787046e8964d366694dac819";
            break;
          case 355:
            _key = "a940e536c49a4c8b87d9d0ceb4d4a185";
            break;
          case 356:
            _key = "203c042380b14150b6936c41813ea351";
            break;
          case 357:
            _key = "e24025dc76fe4f0cb5890a185651f8c3";
            break;
          case 358:
            _key = "9258454d254b4aafa195c75d7c667f01";
            break;
          case 359:
            _key = "846321c3e61b4d1bb3200bb96f77ab4d";
            break;
          case 360:
            _key = "99059cb2259048d69807ca391722df53";
            break;
          case 361:
            _key = "be8e8d2e061f4dc18912fce43dd34e19";
            break;
          case 362:
            _key = "9a5e1a23754d4313a7fc2618f397e722";
            break;
          case 363:
            _key = "0238c332f5a442429a495723c1b1da42";
            break;
          case 364:
            _key = "c2271231a8de4e5c98f6e3c7f1ae7b39";
            break;
          case 365:
            _key = "38b41425c13a478f966a3cd6a1c6da41";
            break;
        }
        AESkey[i] = _key;
      }
    }

    #region "  Hash - MD5 Algorithm  "

    public static string Hash_MD5Cryptography(string ClearText)
    {
      if (ClearText.Trim().Length == 0)
      {
        return "";
      }
      return Hash_MD5Cryptography(ClearText, new UnicodeEncoding());
    }

    public static string Hash_MD5Cryptography(string ClearText, Encoding enc)
    {
      MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
      byte[] input = { };
      byte[] output = { };
      StringBuilder CipherText = new StringBuilder(32);

      input = enc.GetBytes(ClearText);
      output = md5.ComputeHash(input);

      foreach (byte b in output)
      {
        CipherText.Append(string.Format("{0:X2}", b));
      }
      return CipherText.ToString();
    }

    #endregion

    #region "  SHA - Secure Hash Algorithm  "

    public string SHA_Cryptography(string ClearText)
    {
      SHA1Managed shaM = new SHA1Managed();
      return Convert.ToBase64String(shaM.ComputeHash(Encoding.ASCII.GetBytes(ClearText)));
    }

    #endregion

    #region "  DES - Data Encryption Standard Algorithm  "

    public string DES_Encryption(string ClearText)
    {
      string Key = DESkey;
      return EncryptText(Key, ClearText);
    }

    public string DES_Encryption(string ClearText, string Key)
    {
      if (string.IsNullOrEmpty(Key)) Key = DESkey;
      if (Key.Length < 8) Key = DESkey;
      if (Key.Length > 8) Key = Key.Substring(0, 8);

      return EncryptText(Key, ClearText);

    }

    public string DES_Decryption(string CipherText)
    {
      string Key = DESkey;
      return DecryptText(Key, CipherText);
    }

    public string DES_Decryption(string CipherText, string Key)
    {
      if (string.IsNullOrEmpty(Key)) Key = DESkey;
      if (Key.Length < 8) Key = DESkey;
      if (Key.Length > 8) Key = Key.Substring(0, 8);

      return DecryptText(Key, CipherText);
    }

    private string EncryptText(string key, string text)
    {
      byte[] IV = DESiv;

      try
      {
        byte[] byKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
        byte[] InputByteArray = System.Text.Encoding.UTF8.GetBytes(text);
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
        cs.Write(InputByteArray, 0, InputByteArray.Length);
        cs.FlushFinalBlock();
        return Convert.ToBase64String(ms.ToArray());
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }

    }

    private string DecryptText(string key, string text)
    {
      byte[] IV = DESiv;
      byte[] inputByteArray = new byte[text.Length];

      try
      {
        byte[] byKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        inputByteArray = Convert.FromBase64String(text);

        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        Encoding encoding = System.Text.Encoding.UTF8;
        return encoding.GetString(ms.ToArray());
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    #endregion

    #region"  3DES - Triple Data Encryption Standard Algorithm  "

    public string TripleDES_Encryption(string ClearText)
    {
      return Convert.ToBase64String(Encrypt(ClearText));
    }

    public string TripleDES_Decryption(string CipherText)
    {
      return Decrypt(Convert.FromBase64String(CipherText));
    }

    private byte[] Encrypt(string strData)
    {
      byte[] data = ASCIIEncoding.ASCII.GetBytes(strData);
      TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
      if (TDESkey == null)
      {
        tdes.GenerateKey();
        tdes.GenerateIV();
        TDESkey = tdes.Key;
        TDESiv = tdes.IV;
      }
      else
      {
        tdes.Key = TDESkey;
        tdes.IV = TDESiv;
      }

      ICryptoTransform encryptor = tdes.CreateEncryptor();
      MemoryStream ms = new MemoryStream();
      CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
      cs.Write(data, 0, data.Length);
      cs.FlushFinalBlock();
      ms.Position = 0;
      byte[] result = new byte[Convert.ToInt32(ms.Length)];
      ms.Read(result, 0, Convert.ToInt32(ms.Length));
      cs.Close();
      return result;
    }

    private string Decrypt(byte[] data)
    {
      TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
      tdes.Key = TDESkey;
      tdes.IV = TDESiv;
      ICryptoTransform decryptor = tdes.CreateDecryptor();
      MemoryStream ms = new MemoryStream();
      CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);
      cs.Write(data, 0, data.Length);
      cs.FlushFinalBlock();
      ms.Position = 0;
      byte[] result = new byte[Convert.ToInt32(ms.Length)];
      ms.Read(result, 0, Convert.ToInt32(ms.Length));
      cs.Close();
      return ASCIIEncoding.ASCII.GetString(result);
    }

    #endregion

    #region "  ASCII Encryption Algorithm  "

    public static string GetEncryptedData(string ClearText)
    {
      byte[] eNC_data = ASCIIEncoding.ASCII.GetBytes(ClearText);
      string eNC_str = Convert.ToBase64String(eNC_data);
      return eNC_str;
    }

    public static string GetDecryptedData(string CipherText)
    {
      byte[] dEC_data = Convert.FromBase64String(CipherText);
      string dEC_Str = ASCIIEncoding.ASCII.GetString(dEC_data);
      return dEC_Str;
    }

    #endregion

    #region "  Rijndael Encryption Algorithm  "

    /// <summary>
    /// ใช้สำหรับการเข้ารหัสตามหลักการของ AES โดยใช้ Rijndael Algorithm
    /// </summary>
    /// <param name="ClearText">ระบุข้อความ (Cleartext) ที่ต้องการจะเข้ารหัส</param>
    /// <param name="EncryptionKey">ระบุค่า Key ที่ต้องการจะใช้ในการเข้ารหัส</param>
    /// <returns>ผลลัพธ์ที่ได้คือข้อความที่ถูกเข้ารหัส (Ciphertext) ตาม Rijndael Algorithm</returns>
    /// <remarks></remarks>
    public static string Rijndael_Encryption(string ClearText, string EncryptionKey)
    {
      byte[] bytValue = { };
      byte[] bytKey = { };
      byte[] bytEncoded = { };
      byte[] bytIV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };
      int intLength = 0;
      MemoryStream objMemoryStream = new MemoryStream();
      CryptoStream objCryptoStream;
      RijndaelManaged objRijndaelManaged;

      ClearText = StripNullCharacter(ClearText);

      bytValue = Encoding.ASCII.GetBytes(ClearText.ToCharArray());

      intLength = EncryptionKey.Length;

      if (intLength >= 32)
        EncryptionKey = EncryptionKey.Substring(0, 32);
      else
      {
        intLength = EncryptionKey.Length;
        EncryptionKey = EncryptionKey.PadRight(32, 'W');
      }


      bytKey = Encoding.ASCII.GetBytes(EncryptionKey.ToCharArray());

      objRijndaelManaged = new RijndaelManaged();

      try
      {
        objCryptoStream = new CryptoStream(objMemoryStream, objRijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write);
        objCryptoStream.Write(bytValue, 0, bytValue.Length);

        objCryptoStream.FlushFinalBlock();

        bytEncoded = objMemoryStream.ToArray();
        objMemoryStream.Close();
        objCryptoStream.Close();
      }
      catch
      {

      }

      return Convert.ToBase64String(bytEncoded);

    }

    /// <summary>
    /// ใช้สำหรับการถอดรหัสตามหลักการของ AES โดยใช้ Rijndael Algorithm
    /// </summary>
    /// <param name="CipherText">ระบุข้อความที่ถูกเข้ารหัส (Ciphertext) ตาม Rijndael Algorithm</param>
    /// <param name="DecryptionKey">ระบุค่า Key ที่ต้องการจะใช้ในการถอดรหัส</param>
    /// <returns>ผลลัพธ์ที่ได้คือข้อความที่ถูกถอดรหัส (Cleartext) ตาม Rijndael Algorithm</returns>
    /// <remarks></remarks>
    public static string Rijndael_Decryption(string CipherText, string DecryptionKey)
    {
      byte[] bytDataToBeDecrypted = { };
      byte[] bytTemp = { };
      byte[] bytIV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };
      RijndaelManaged objRijndaelManaged = new RijndaelManaged();
      MemoryStream objMemoryStream;
      CryptoStream objCryptoStream;
      byte[] bytDecryptionKey = { };

      int intLength = 0;
      string strReturnString = string.Empty;

      bytDataToBeDecrypted = Convert.FromBase64String(CipherText);

      intLength = DecryptionKey.Length;

      if (intLength >= 32)
      {
        DecryptionKey = DecryptionKey.Substring(0, 32);
      }
      else
      {
        intLength = DecryptionKey.Length;
        DecryptionKey = DecryptionKey.PadRight(32, 'W');
      }

      bytDecryptionKey = Encoding.ASCII.GetBytes(DecryptionKey.ToCharArray());

      bytTemp = new byte[bytDataToBeDecrypted.Length];

      objMemoryStream = new MemoryStream(bytDataToBeDecrypted);

      try
      {
        objCryptoStream = new CryptoStream(objMemoryStream, objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), CryptoStreamMode.Read);

        objCryptoStream.Read(bytTemp, 0, bytTemp.Length);

        //objCryptoStream.FlushFinalBlock() '-----You can call FlushFinalBlock once time in sub
        objMemoryStream.Close();
        objCryptoStream.Close();
      }
      catch
      {
      }

      return StripNullCharacter(Encoding.ASCII.GetString(bytTemp));

    }

    public static string StripNullCharacter(string vstrStringWithNulls)
    {
      char vbNullChar = Convert.ToChar(0);
      int intPosition = 1;
      string strStringWithOutNulls = "";

      strStringWithOutNulls = vstrStringWithNulls;

      while (intPosition > 0)
      {
        intPosition = strStringWithOutNulls.IndexOf(vbNullChar, intPosition);
        if (intPosition > 0)
        {
          strStringWithOutNulls = strStringWithOutNulls.Substring(0, intPosition) + strStringWithOutNulls.Substring(intPosition + 1);
        }
        if (intPosition > strStringWithOutNulls.Length)
          break;
      }

      return strStringWithOutNulls;
    }

    #endregion


    public static bool CredentialsVerification(string _clearusername, string _clearpassword)
    {
      //--- Varied length variables ---
      DataTable corresdata = null;

      //corresdata = new DataTable("");
      string hashpassword = "";

      hashpassword = Hash_MD5Cryptography(_clearpassword);

      //--- Fixed length variables ---
      bool AuthenPass = CheckValidPassword(_clearusername, _clearpassword, false);
      bool ret = false;

      if (AuthenPass)
      {
        //corresdata = GeneralSrv.UserMacNetCorrespondingData(Generaldbcfg, _clearusername, 1)

        //if (corresdata.Rows.Count > 0)
        //  //--- User pass authentication
        //  ActiveUser.AuthenPass = True
        //  '--- User ID
        //  If Not Integer.TryParse(corresdata(0)("USRid").ToString(), ActiveUser.ID) Then ActiveUser.ID = 0
        //  '--- User code
        //  Try
        //    ActiveUser.Code = corresdata(0)("USRcode").ToString()
        //  Catch ex As Exception
        //    ActiveUser.Code = ""
        //  End Try
        //  '--- User name thai
        //  Try
        //    ActiveUser.NameTH = corresdata(0)("USRnameT").ToString()
        //  Catch ex As Exception
        //    ActiveUser.NameTH = ""
        //  End Try
        //  '--- User name eng
        //  Try
        //    ActiveUser.NameEN = corresdata(0)("USRnameE").ToString()
        //  Catch ex As Exception
        //    ActiveUser.NameEN = ""
        //  End Try
        //  '--- User password
        //  Try
        //    ActiveUser.Password = corresdata(0)("USRpwd").ToString()
        //  Catch ex As Exception
        //    ActiveUser.Password = ""
        //  End Try
        //  //--- User password approve
        //  Try
        //    ActiveUser.PwdApprove = corresdata(0)("USRpwdApprove").ToString()
        //  Catch ex As Exception
        //    ActiveUser.PwdApprove = ""
        //  End Try
        //  //--- User level
        //  If Not Integer.TryParse(corresdata(0)("USRlevel").ToString(), ActiveUser.Level) Then ActiveUser.Level = 0
        //  //--- User E-mail
        //  Try
        //    ActiveUser.Email = corresdata(0)("USRemail").ToString()
        //  Catch ex As Exception
        //    ActiveUser.Email = ""
        //  End Try



        //else
        //{
        //  //ClearUserInformation();
        //}

        ret = true;
      }
      else
      {
        corresdata = null;
        //ClearUserInformation();
        ret = false;
      }
      return ret;
    }

    public static bool CheckValidPassword(string Username, string Password, bool Approvalmode)
    {
      //--- Varied length variables ---
      string _clearusername = Username;
      string _clearpassword = Password;
      string hashpassword = Hash_MD5Cryptography(_clearpassword);
      string onetimeguid = System.Guid.NewGuid().ToString("N");
      //string[] AESkey = new string[366];

      //--- Except rule
      int _index = DateTime.Now.DayOfYear - 1;
      string _cipherusername = Rijndael_Encryption(_clearusername, AESkey[_index]);
      string _cipheronetime = Rijndael_Encryption(onetimeguid, AESkey[_index]);

      byte[] byteusername = Convert.FromBase64String(_cipherusername);
      byte[] byteonetime = Convert.FromBase64String(_cipheronetime);
      byte[] bytecipher = { };

      string strcipher = "";
      string decryptstrcipher = "";

      try
      {
        bytecipher = CheckValidPasswordThaiMahal(byteusername, byteonetime, 1);
        strcipher = Convert.ToBase64String(bytecipher);
        decryptstrcipher = Rijndael_Decryption(strcipher, onetimeguid);
      }
      catch (Exception ex)
      {
        XtraMessageBox.Show(ex.Message);
        decryptstrcipher = "";
      }

      return hashpassword == decryptstrcipher;
    }

    public static byte[] CheckValidPasswordThaiMahal(byte[] username, byte[] password, int mode)
    {
      //--- mode 0 : Get user data from table A999 use for MacServe3, CRM and BI
      //--- mode 1 : Get user data from table USR use for MacNet

      //--- Varied length variables ---
      SqlConnection conn = new SqlConnection();
      SqlCommand cmd = conn.CreateCommand();
      SqlDataReader rd = null;

      StringBuilder sqlcmd = new StringBuilder();

      string _username = Convert.ToBase64String(username);
      string _password = Convert.ToBase64String(password);

      //--- Except rule
      int _index = DateTime.Now.DayOfYear - 1;
      string decrptusername = Rijndael_Decryption(_username, AESkey[_index]);
      string decrptpassword = Rijndael_Decryption(_password, AESkey[_index]);
      string hashpassword = "121A81915FBED73DEEC0C9A85B2423EC";
      string cipherpassword = "";
      byte[] bytecipher = { };


      cls_Global_DB.ConnectDatabase(ref conn);

      try
      {
        sqlcmd.Clear();
        sqlcmd.Append("SELECT USR.USRcode,USR.USRnameT,USR.USRnameE,USM.USMs1,USM.USMs2,USM.USMs3,USM.USMs4,USM.USMs5,USM.USMs6,USR.USRid,USR.USRpwd FROM USR INNER JOIN USM ON USR.USRid = USM.USR_id WHERE USR.USRcode=@k1 And USR.USRdelete=0");
        cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sqlcmd.ToString();
        cmd.CommandTimeout = 30;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@k1", SqlDbType.VarChar, 50).Value = decrptusername;
        //if (!rd.IsClosed) rd.Close();
        //rd = null;
        rd = cmd.ExecuteReader();
        if (rd.HasRows && rd.Read())
        {
          hashpassword = cls_Library.DBString(rd["USRpwd"]);
          cls_Global_class.GB_Userid = cls_Library.CInt(rd["USRid"]);
          cls_Global_class.USRnameT = cls_Library.DBString(rd["USRnameT"]);
          cls_Global_class.USRnameE = cls_Library.DBString(rd["USRnameE"]);
          cls_Global_class.GB_USMs1 = cls_Global_class.CUInt(rd["USMs1"]);
          cls_Global_class.GB_USMs2 = cls_Global_class.CUInt(rd["USMs2"]);
          cls_Global_class.GB_USMs3 = cls_Global_class.CUInt(rd["USMs3"]);
          cls_Global_class.GB_USMs4 = cls_Global_class.CUInt(rd["USMs4"]);
          cls_Global_class.GB_USMs5 = cls_Global_class.CUInt(rd["USMs5"]);
          cls_Global_class.GB_USMs6 = cls_Global_class.CUInt(rd["USMs6"]);
        }
      }
      catch
      {
        if (!rd.IsClosed) rd.Close();
      }
      finally
      {
        cipherpassword = Rijndael_Encryption(hashpassword, decrptpassword);
        bytecipher = Convert.FromBase64String(cipherpassword);
        if (!rd.IsClosed) rd.Close();
        cls_Global_DB.CloseDB(ref conn);
        conn.Dispose();
      }

      return bytecipher;
    }

    public static bool SaveChangePassword(string Username, string Password, bool Approvalmode)
    {

      //--- Varied length variables ---
      string _clearusername = Username;
      string _clearpassword = Password;
      string hashpassword = Hash_MD5Cryptography(_clearpassword);
      string onetimeguid = System.Guid.NewGuid().ToString("N");

      //--- Except rule
      int _index = DateTime.Now.DayOfYear - 1;
      string _cipherusername = Rijndael_Encryption(_clearusername, AESkey[_index]);
      string _cipherpassword = Rijndael_Encryption(hashpassword, AESkey[_index]);
      _cipherpassword = Rijndael_Encryption(_cipherpassword, onetimeguid);
      string _cipheronetime = Rijndael_Encryption(onetimeguid, AESkey[_index]);

      byte[] byteusername = Convert.FromBase64String(_cipherusername);
      byte[] bytepassword = Convert.FromBase64String(_cipherpassword);
      byte[] byteonetime = Convert.FromBase64String(_cipheronetime);

      //--- Fixed length variables ---
      bool SaveOK = SaveChange_Password(byteusername, bytepassword, byteonetime, Approvalmode, 1);

      return SaveOK;
    }

    public static bool SaveChange_Password(byte[] username, byte[] password, byte[] onetime, bool approvalmode, int mode)
    {
      SqlConnection conn = new SqlConnection();
      SqlCommand cmd = conn.CreateCommand();
      SqlDataReader rd = null;
      SqlTransaction TransactionControl = null;

      StringBuilder sqlcmd = new StringBuilder();

      string _username = Convert.ToBase64String(username);
      string _password = Convert.ToBase64String(password);
      string _onetime = Convert.ToBase64String(onetime);

      int _index = DateTime.Now.DayOfYear - 1;
      string decrptusername = Rijndael_Decryption(_username, AESkey[_index]);
      string decrptonetime = Rijndael_Decryption(_onetime, AESkey[_index]);
      string decrptpassword = Rijndael_Decryption(_password, decrptonetime);
      decrptpassword = Rijndael_Decryption(decrptpassword, AESkey[_index]);

      int _indx = 0;
      //int _changepass = 0;
      int rowaffect = -1;
      bool transactioninstance = false;

      cls_Global_DB.ConnectDatabase(ref conn);

      try
      {
        sqlcmd.Clear();
        sqlcmd.Append("SELECT USRid FROM USR WHERE USRcode=@k1 and USRdelete=0");
        cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sqlcmd.ToString();
        cmd.CommandTimeout = 30;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@k1", SqlDbType.NVarChar, 50).Value = decrptusername;
        rd = cmd.ExecuteReader();
        if (rd.HasRows && rd.Read())
        {
          _indx = cls_Global_class.NeverNothing(rd["USRid"], 0);
        }
        if (!rd.IsClosed) rd.Close();
        transactioninstance = true;
        TransactionControl = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        sqlcmd.Clear();
        sqlcmd.Append("Update USR WITH (UPDLOCK) Set USRpwd=@v1 Where USRid=@k1 and USRdelete=0");
        cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sqlcmd.ToString();
        cmd.CommandTimeout = 30;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@v1", SqlDbType.NVarChar).Value = decrptpassword;
        cmd.Parameters.Add("@k1", SqlDbType.Int).Value = _indx;
        cmd.Transaction = TransactionControl;
        rowaffect = cmd.ExecuteNonQuery();
        TransactionControl.Commit();
      }
      catch
      {
        rowaffect = -1;
        if (transactioninstance)
          TransactionControl.Rollback();
      }
      finally
      {
        if (!rd.IsClosed) rd.Close();
        cls_Global_DB.CloseDB(ref conn);
        conn.Dispose();
      }
      return rowaffect > 0;
    }

    
  }

  public static class NotepadHelper
  {
    [DllImport("user32.dll", EntryPoint = "SetWindowText")]
    private static extern int SetWindowText(IntPtr hWnd, string text);

    [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
    private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("User32.dll", EntryPoint = "SendMessage")]
    private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

    public static void ShowMessage(string message = null, string title = null)
    {
      Process notepad = Process.Start(new ProcessStartInfo("notepad.exe"));
      if (notepad != null)
      {
        notepad.WaitForInputIdle();

        if (!string.IsNullOrEmpty(title))
          SetWindowText(notepad.MainWindowHandle, title);

        if (!string.IsNullOrEmpty(message))
        {
          IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), "Edit", null);
          SendMessage(child, 0x000C, 0, message);
        }
      }
    }
  }
}
