using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using Microsoft.Win32;
//using Microsoft.Office.Interop;
//using Microsoft.Office.Interop.Outlook;
using Microsoft.VisualBasic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace SmartPart.Class
{
    class cls_Library
    {
        public static string[] EmonthName;
        public static string[] TmonthName;

        public static bool Date_ValidIDMY(int Dx, int Mx, int Yx)
        {
            bool functionReturnValue = false;
            //Xdate is in English Year ONLY
            if ((Mx < 1) | (Mx > 12))
            goto VDinvalidIDMY;
            if ((Dx < 1) | (Dx > DayssinMonth(Mx, Yx)))
            goto VDinvalidIDMY;
            functionReturnValue = true;
            return functionReturnValue;
        VDinvalidIDMY:
            functionReturnValue = false;
            return functionReturnValue;
        }

        public static DateTime Date_CvDMY(int dd, int mm, int yy, bool Tdisp)
        {
            //Get And Check And Assign to Public Function the Input Date String
            //Data must be integer of Date,Month,Year
            int Yx;

            Yx = yy;
            if (Tdisp)
            {
            Yx = Yx - 543;
            }

            if (Date_ValidIDMY(dd, mm, Yx))
            {
            return DateAndTime.DateSerial(Yx, mm, dd);
            }
            else
            {
            return DateTime.MinValue;
            }
        }

        public static object Date_CvDMYHNS(int dd, int mm, int yy, int hh, int nn, int ss, bool Tdisp)
        {
            //Get And Check And Assign to Public Function the Input Date TIstring
            //Data must be integer of Date,Month,Year
            string Xm = string.Empty;
            string Xh = string.Empty;
            string Xn = string.Empty;
            string Xs = string.Empty;
            string Datestr = string.Empty;
            int Yx = 0;
            object Xdate = DBNull.Value;
            //string dt = string.Empty;

            EmonthName = new string[13];
            EmonthName[1] = "January";
            EmonthName[2] = "February";
            EmonthName[3] = "March";
            EmonthName[4] = "April";
            EmonthName[5] = "May";
            EmonthName[6] = "June";
            EmonthName[7] = "July";
            EmonthName[8] = "August";
            EmonthName[9] = "September";
            EmonthName[10] = "October";
            EmonthName[11] = "November";
            EmonthName[12] = "December";
            Yx = yy;
            if (Tdisp) Yx = Yx - 543;
            if (Date_ValidIDMY(dd, mm, Yx))
            {
            //dt = dd.ToString() + " " + EmonthName[mm] + " " + Yx.ToString();
            if ((hh > 23) || (hh < 0)) hh = 0;
            if ((nn > 59) || (nn < 0)) nn = 0;
            if ((ss > 59) || (ss < 0)) ss = 0;

            Xh = dd.ToString();
            Xn = mm.ToString();
            Xs = yy.ToString();

            if (Xh.Length < 2) { Xh = "0" + Xh.ToString(); }
            if (Xn.Length < 2) { Xn = "0" + Xn.ToString(); }
            if (Xs.Length < 4) { Xs = (2000 + Xs).ToString(); }



            Datestr = Xn + "/" + Xh + "/" + Xs;

            Xh = hh.ToString();
            Xn = nn.ToString();
            Xs = ss.ToString();

            if (Xh.Length < 2) { Xh = "0" + Xh.ToString(); }
            if (Xn.Length < 2) { Xn = "0" + Xn.ToString(); }
            if (Xs.Length < 2) { Xs = "0" + Xs.ToString(); }

            Xdate = DateAndTime.DateSerial(yy, mm, dd);

            Xm = Xh + ":" + Xn + ":" + Xs;
            Xdate = Convert.ToDateTime(Datestr + " " + Xm).ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US"));
            return Xdate;
            }
            else
            {
            return DBNull.Value;
            }
        }

        public static bool Date_ValidS10TE(string Xdate, bool TdisX)
        {
            //Verify that Xdate is a valid date in Thai/Eng
            string Xs;
            int Xv;

            if (TdisX)  //if Thai Display then Covert Year first
            {
            if (Xdate.Length != 10) return false;
            Xs = Right(Xdate, 4);
            Xv = Convert.ToInt16(Xs);
            if ((Xv < 2450) || (Xv > 2600)) return false;
            Xv = Xv - 543;
            Xs = Left(Xdate, 6) + Convert.ToString(Xv);
            return Date_ValidS10(Xs);
            //Xdate = Xs only check for validity, not changing status
            }
            else
            {
            return Date_ValidS10(Xdate);
            }

        }

        public static bool Date_ValidS10(string Xdate)
        {
            //Xdate is in English Year ONLY : Length of String must be 10
            string Sx;
            int id, im, iy; //', FullYear%

            //Xdate = Xdate;
            if (Xdate.Length != 10) return false;


            if ((Xdate.Substring(2, 1) != "/") || (Xdate.Substring(5, 1) != "/")) return false;
            Sx = Xdate.Substring(0, 1);
            if (InStr("0123456789", Sx) == 0) return false;
            Sx = Xdate.Substring(1, 1);
            if (InStr("0123456789", Sx) == 0) return false;
            Sx = Xdate.Substring(3, 1);
            if (InStr("0123456789", Sx) == 0) return false;
            Sx = Xdate.Substring(4, 1);
            if (InStr("0123456789", Sx) == 0) return false;
            Sx = Xdate.Substring(6, 1);
            if (InStr("0123456789", Sx) == 0) return false;
            Sx = Xdate.Substring(7, 1);
            if (InStr("0123456789", Sx) == 0) return false;
            Sx = Left(Xdate, 2);
            id = Convert.ToInt16(Sx);
            if ((id < 1) || (id > 31)) return false;
            Sx = Xdate.Substring(3, 2);
            im = Convert.ToInt16(Sx);
            if ((im < 1) || (im > 12)) return false;
            Sx = Right(Xdate, 4);
            iy = Convert.ToInt16(Sx);
            if ((iy < 1900) || (iy > 2050)) return false;
            if (id > DayssinMonth(im, iy)) return false;
            return true;
        }

        public static int DayssinMonth(int Mx, int Yx)
        {
            //Day ss is to avoid conflict with CScalendar Property
            //Xdate is in English Year ONLY, yx must be in full Year
            int[] MDarray = new int[13];
            if (Mx == 0 || Yx == 0)
            {
            return 0;
            }
            else
            {
            MDarray[1] = 31;
            MDarray[2] = 28;
            MDarray[3] = 31;
            MDarray[4] = 30;
            MDarray[5] = 31;
            MDarray[6] = 30;
            MDarray[7] = 31;
            MDarray[8] = 31;
            MDarray[9] = 30;
            MDarray[10] = 31;
            MDarray[11] = 30;
            MDarray[12] = 31;
            if (Yx % 4 == 0) MDarray[2] = 29;
            return MDarray[Mx];
            }
        }

        public static int InStr(string str1, string str2)
        {
            string StrTemp;
            int index = 0;
            if (str1.Length > 0)
            {
            while (str1.Length > 0)
            {
                StrTemp = str1.Substring(0, 1);
                str1 = str1.Remove(0, 1);
                index += 1;
                if (StrTemp.IndexOf(str2) > -1) return index;
            }
            }
            return 0;
        }

        public static bool IsDate(Object obj)
        {

            if (obj == null)
            {
                return false;
            }
            string strDate = obj.ToString();
            
            try
            {
                if (cls_Library.DBDateTime(strDate) == DateTime.MinValue)
                {
                    return false;
                }
                if (cls_Library.DBDateTime(strDate) == DateTime.MaxValue)
                {
                    return false;
                }
                DateTime dt = DateTime.Parse(strDate);
                if ((dt.Day < 1 && dt.Day > 31))
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static string Date_TE10E10(string Xdate, bool Tdisp)
        {
            //Input is Valid S10 in Thai/Eng
            //Return is English Only Format$
            int iy;

            if (!Date_ValidS10TE(Xdate, Tdisp))
            return "00/00/0000";
            if (Tdisp)
            {
            iy = Convert.ToInt16(Right(Xdate, 4)) - 543;
            return Left(Xdate, 6) + Convert.ToInt16(iy);
            }
            else
            {
            return Xdate;
            }
        }

        public static byte DBByte(object obj)
        {
            byte i;
            try
            {
                i = obj == DBNull.Value ? (byte)0 : Convert.ToByte(obj);
            }
            catch
            {
                i = 0;
            }
            return i;
        }

        public static decimal DBDecimal(object obj)
        {
            decimal dec;

            try
            {
            dec = obj == DBNull.Value ? 0 : Convert.ToDecimal(obj);
            }
            catch
            {
            dec = 0;
            }

            return dec;
        }

        public static Int16 DBInt16(object obj)
        {
            Int16 i;

            try
            {
            i = obj == DBNull.Value ? (Int16)0 : Convert.ToInt16(obj);
            }
            catch
            {
            i = 0;
            }

            return i;
        }

        public static int DBInt(object obj)
        {
            int i;

            try
            {
            i = obj == DBNull.Value ? 0 : Convert.ToInt32(obj);
            }
            catch
            {
            i = 0;
            }

            return i;
        }

        public static ulong DBUInt64(object obj)
        {
            ulong i;

            try
            {
            i = obj == DBNull.Value ? 0 : Convert.ToUInt64(obj);
            }
            catch
            {
            i = 0;
            }

            return i;
        }

        public static string DBString(object obj)
        {
            string str;

            str = obj == DBNull.Value ? "" : Convert.ToString(obj);

            return str;
        }

        public static DateTime DBDateTime(object obj)
        {
            DateTime dt;

            dt = obj == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(obj);

            return dt;
        }

        public static double DBDouble(object obj)
        {
            double db;

            try
            {
            db = obj == DBNull.Value ? 0 : Convert.ToDouble(obj);
            }
            catch
            {
            db = 0;
            }

            return db;
        }

        public static bool DBbool(object obj)
        {
            bool ok;

            ok = obj == DBNull.Value ? false : Convert.ToBoolean(obj);

            return ok;
        }

        public static byte CByte(object obj)
        {
            byte i;
            try
            {
            if (!byte.TryParse(obj.ToString(), out i))
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

        public static int CInt(object obj)
        {
            int i;
            try
            {
            if (!int.TryParse(obj.ToString(), out i))
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

        public static Int16 CInt16(object obj)
        {
            Int16 i;
            try
            {
            if (!Int16.TryParse(obj.ToString(), out i))
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

        public static double CDouble(object obj)
        {
            double db;
            try
            {
            if (!double.TryParse(obj.ToString(), out db))
            {
                db = 0;
            }
            }
            catch
            {
            db = 0;
            }
            return db;
        }

        public static decimal CDecimal(object obj)
        {
            decimal dec;
            try
            {
            if (!decimal.TryParse(obj.ToString(), out dec))
            {
                dec = 0;
            }
            }
            catch
            {
            dec = 0;
            }
            return dec;
        }

        public static DateTime CDateTime(object obj)
        {
            DateTime dateT;
            if (!DateTime.TryParse(obj.ToString(), out dateT))
            {
            dateT = DateTime.MinValue;
            }
            return dateT;
        }

        public static DateTime GetMIdate(object obj)
        {
            DateTime date;
            string dd = string.Empty;
            string mm = string.Empty;
            string yyyy = string.Empty;

            dd = obj.ToString().Substring(6, 2);
            mm = obj.ToString().Substring(4, 2);
            yyyy = obj.ToString().Substring(0, 4);

            try
            {
            date = Convert.ToDateTime(dd + "/" + mm + "/" + yyyy);
            }
            catch
            {
            date = DateTime.MinValue;
            }

            return date;
        }

        public static DateTime GetDateLastYear()
        {
            DateTime dt = cls_Library.Date_CvDMY(1, 1, DateTime.Now.Year - 1, false);

            return dt;
        }

        public static DateTime GetDateCurrentYear()
        {
            DateTime dt = cls_Library.Date_CvDMY(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, false);

            return dt;
        }

        public static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            if (param.Length > 0)
            return param.Substring(0, length);
            else
            return ""; //return the result of the operation


        }

        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            if (param.Length > 0)
            return param.Substring(param.Length - length, length);
            else
            return "";//return the result of the operation


        }

        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable

            string result = "";

            if (param.Length <= length)
            length = param.Length;
            result = param.Substring(startIndex, length);


            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }

        public static bool ValidateEmailAddress(string email)
        {
            bool OK = false;
            //string pattern  = "^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[a-zA-Z]{2,9})$";
            string pattern = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\\w]*[0-9a-zA-Z])*\\.)+[a-zA-Z]{2,9})$";
            //string pattern = "";
            OK = System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
            return OK;
        }

        public static void SendMail(string MailTo,string mailSubject,string mailBody, string mailAttach  = "")
        {
            //Application mailProg = new Application();
            //MailItem mailMsg ;
            //Attachments myAttachments;
            //string[] AttFile= new string[0];
            //int i, AttNo=0;
            ////bool mailAttOk=false;

            try
            {
            //   mailAttOk = false;
            //   AttNo = 0;
            //   //if (mailAttach.Length > 0)
            //   //{
            //   //  Erase XYZarray
            //   //  XYZassignArray(mailAttach, ";")
            //   //  If XYZnoA > 0 Then
            //   //    mailAttOk = True
            //   //    AttNo = CInt(XYZnoA)
            //   //    AttFile = CType(XYZarray.Clone, String())
            //   //  End If
            //   //}
            //   //mailMsg = Microsoft.Office.Interop.Outlook.MailItem();
            //   mailMsg = mailProg.CreateItem(OlItemType.olMailItem);
            //   mailMsg.To = MailTo;
            //   mailMsg.Subject = mailSubject;
            //   mailMsg.Body = mailBody;
            //     //If mailAttOk Then
            //     //  myAttachments = .Attachments
            //     //  For i = 1 To AttNo
            //     //    If System.IO.File.Exists(ZSnull(AttFile(i))) Then myAttachments.Add(ZSnull(AttFile(i)))
            //     //  Next i
            //     //End If
            //   //mailMsg.
            //   mailMsg.Send();
            //   mailAttOk = false;
            //   AttNo = 0;
            }
            catch (System.Exception ex)
            {
            }
        }

        public static void sendEmail(string MailTo,string mailSubject,string mailBody, string mailAttach  = "") 
        {

            try
            {
                MailMessage Mail =new MailMessage();

            //Mail.To.Add(New MailAddress("pongsiri_n@hotmail.com"))
            //Mail.To.Add(New MailAddress("burin_@hotmail.com"))
            Mail.To.Add(new MailAddress(MailTo));

            //Mail.CC.Add(New MailAddress("CC1@email.com"))
            //Mail.CC.Add(New MailAddress("CC2@email.com"))

            //Mail.Bcc.Add(New MailAddress("BCC1@email.com"))
            //Mail.Bcc.Add(New MailAddress("BCC2@email.com"))

            Mail.From = new MailAddress("big_tmat@hotmail.com");
            Mail.Subject = mailSubject;
            Mail.Body = mailBody;
            //Mail.IsBodyHtml = true;

            //Dim Smtp As New SmtpClient("smtp.email.com")
            //Smtp.Send(Mail)

            //ชื่อ SMTP server ใช้ IP แทนก็ได้นะครับ
            //กรณีที่ SMTP server มีการตรวจสอบสิทธิ์ ก็ให้เพิ่มโค้ดในส่วน SmtpClient เป็น

            SmtpClient Smtp = new SmtpClient("mail.doublepine.co.th");
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.Credentials = new NetworkCredential("pi.k@doublepine.co.th", "Ron@ldinho82");
            Smtp.Send(Mail);
            }
            catch (System.Exception ex)
            {
            }
        }

        public static string SequenceStr(string Xval)
        {
            int i, j, ch, NoS;
            string Xsequnce="";
            string[] Xarr=new string[0];

            Xsequnce = "";
            if (Xval.Length == 0) return
            Xsequnce = Xval;
            //ReDim Xarr(1)
            NoS = Xval.Length;
            Array.Resize(ref Xarr, NoS);
            //ReDim Xarr(NoS)
            for (i = 0 ; i < NoS;i++)
            {
                Xarr[i] = Xval.Substring(i, 1);
            }
  
            j = 1;
            for (i = NoS-1; i >=0 ; i=i-1)
            {
            ch =Convert.ToInt32(Xarr[i]);
            ch = ch + j;
            switch (ch)
            {
                case 91:
                Xarr[i] =Convert.ToString((char)65);
                j = 1;
                break;
                case 207:
                Xarr[i] =Convert.ToString((char)161);
                j = 1;
                break;
                case 58:
                Xarr[i] =Convert.ToString((char)48); 
                j = 1;
                break;
                case 256:
                i = 0;
                break;
                default:
                Xarr[i] = Convert.ToString(ch);
                i = 0;
                break;
            }
            }

            Xsequnce = "";
            for (i = 0;i < NoS ; i++)
            {
                Xsequnce = Xsequnce + Xarr[i];
            }
            return Xsequnce;
        }

        public static double Disc_CalText(string Xs)
        {
            string Xk=string.Empty;
            int i=0;
            double Vx, Tval, Tn;
            string[] XYZarray={};

            try
            {
            Vx = 0;
            Tval = 0;
            Tn = 0;
            Xk = Xs.Trim();
            XYZarray = Xk.Split('/');
            if (XYZarray.Length > 0)
            {
                Tn = 100;
                Tval = 0;
                for (i = 0; i < XYZarray.Length; i++)
                {
                Vx = Convert.ToDouble(XYZarray[i]);
                if ((Vx != 0) && (Math.Abs(Vx) != 100))
                {
                    Tval = Tval + (Tn * Vx / 100);
                    Tn = 100 - Tval;
                }
                }
                Vx = 100 - Tn;
            }
            }
            catch 
            {
            Vx=0;
            }
            return Vx;
        }

        public static decimal CalFix_TXTdisc(string Xdisc,decimal Tn)
        {
            decimal Tval;
      
            Tval =Convert.ToDecimal(Disc_CalText(Xdisc)) * Tn / 100;

            return Tval;
        }
    
        public string Disc_VerifyText(string Xs)
        {
            string Xk= string.Empty;
            int i;
            double Vx;
            string[] XYZarray = { };
        
            Xk = "0";
            Xk = Xs.Trim();
            XYZarray = Xk.Split('/');
            if (XYZarray.Length > 0)
            {
                Xk = "";
                for (i = 0; i < XYZarray.Length; i++)
                {
                Vx = Convert.ToDouble(XYZarray[i]);
                if (Math.Abs(Vx) < 100)
                {
                    if (Xk.Length == 0)
                    {
                    Xk = Vx.ToString().Trim();
                    }
                    else
                    {
                    Xk = Xk + "/" + Vx.ToString().Trim();
                    }
                }
                }
            }
            return Xk;
        }

        #region Zone
        public static void BestFitColumns(DevExpress.XtraGrid.Views.Grid.GridView gvGrid)
        {
            try
            {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvGrid.Columns)
            {
                col.BestFit();
                col.OptionsColumn.ShowInCustomizationForm = col.Visible;
            }
            }
            catch (System.Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        public static void AssignSearchLookUp(SearchLookUpEdit sLookUp, string tbName, string txtCode, string txtName, cls_Global_class.TypeShow showtype = cls_Global_class.TypeShow.code)
        {
            try
            {
                sLookUp.Properties.DataSource = cls_Global_DB.DataInitial.Tables[tbName];
                //sLookUp.Refresh();
                sLookUp.Properties.PopulateViewColumns();
                sLookUp.Properties.View.Columns["_id"].Visible = false;
                sLookUp.Properties.View.Columns["code"].Caption = txtCode;
                sLookUp.Properties.View.Columns["name"].Caption = txtName;

                sLookUp.Properties.ValueMember = "_id";
                switch (showtype)
                {
                    case cls_Global_class.TypeShow.code:
                        sLookUp.Properties.DisplayMember = "code";
                        break;
                    case cls_Global_class.TypeShow.name:
                        sLookUp.Properties.DisplayMember = "name";
                        break;
                    case cls_Global_class.TypeShow.codename:
                        sLookUp.Properties.DisplayMember = "codename";                      
                        break;
                    default:
                        sLookUp.Properties.DisplayMember = "code";
                        break;
                }
                if (sLookUp.Properties.View.Columns.Contains(sLookUp.Properties.View.Columns["codename"]))
                {
                    sLookUp.Properties.View.Columns["codename"].Visible = false;
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public static decimal CalCulateTax(cls_Global_class.TypePrice TypePrice, cls_Global_class.TypeCal TypeCal, decimal TaxRate, decimal balance, decimal Taxamount)
        {
            decimal ret = 0;
            try
            {
            switch (TypeCal)
            {
                case cls_Global_class.TypeCal.taxamount:
                switch (TypePrice)
                {
                    case cls_Global_class.TypePrice.NOSUMVAT:
                    if ((Taxamount < Convert.ToDecimal((Convert.ToDouble(TaxRate) - 0.1) * Convert.ToDouble((balance) / 100))) || (Taxamount > Convert.ToDecimal((Convert.ToDouble(TaxRate) + 0.1) * Convert.ToDouble((balance) / 100)))) Taxamount = (balance * Convert.ToDecimal(TaxRate)) / 100;
                    break;
                    case cls_Global_class.TypePrice.SUMVAT:
                    Taxamount = (balance * TaxRate) / (100 + TaxRate);
                    break;
                    case cls_Global_class.TypePrice.NOTVAT:
                    Taxamount = 0;
                    break;
                    default:
                    break;
                }
                ret = Taxamount;
                break;
                case cls_Global_class.TypeCal.taxrate:
                TaxRate = ((Taxamount * 100) / balance);
                ret = TaxRate;
                break;
                case cls_Global_class.TypeCal.recalTax:
                switch (TypePrice)
                {
                    case cls_Global_class.TypePrice.NOSUMVAT:
                    Taxamount = (TaxRate * balance) / 100;
                    break;
                    case cls_Global_class.TypePrice.SUMVAT:
                    Taxamount = (balance * TaxRate) / (100 + TaxRate);
                    break;
                }
                ret = Taxamount;
                break;
            }
            }
            catch { }
            return ret;
        }

        public static string GetAutotNumber(cls_Struct.VoucherType type, string Xs = "")
        {
            string runNo = "";
            string Hno = "";
            string result = "";
            SqlConnection conn = new SqlConnection();
            StringBuilder sb = new StringBuilder();
            DateTime _date = DateTime.Today;
            bool DocOK = false;
            try
            {
            if (cls_Global_DB.ConnectDatabase(ref conn))
            {
                switch (type)
                {
                case cls_Struct.VoucherType.PO:
                    Hno = "PO" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(PO_NO,8) AS DocNo From POHEADER Order By RIGHT(PO_NO,8) DESC");
                    break;
                case cls_Struct.VoucherType.RC:
                    Hno = "RC" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(RC_NO,8) AS DocNo From RCHEADER Order By RIGHT(RC_NO,8) DESC");
                    break;
                case cls_Struct.VoucherType.JOB:
                    Hno = "JOB" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(JOB_NO,8) AS DocNo From JOBHEAD Order By RIGHT(JOB_NO,8) DESC");
                    break;
                case cls_Struct.VoucherType.RO:
                    Hno = "RO" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(RO_NO,8) AS DocNo From ROHEADER Order By RIGHT(RO_NO,8) DESC");
                    break;
                    //ZOZO23----1
                case cls_Struct.VoucherType.SQ:
                    Hno = "SQ" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(SQ_NO,8) AS DocNo From SQHEADER Order By RIGHT(SQ_NO,8) DESC");
                    break;
                    //ZOZO23----2
                case cls_Struct.VoucherType.BS:
                    //แยกขายสดขายเชือ
                    Hno = Xs + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(BSH_NO,8) AS DocNo From BSHEADER Order By RIGHT(BSH_NO,8) DESC");
                    break;
                case cls_Struct.VoucherType.RS:
                    //Hno = "AI" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(RSH_NO,8) AS DocNo From ETAXHEADER Order By RIGHT(RSH_NO,8) DESC");
                    break;
                case cls_Struct.VoucherType.PS:
                    Hno = "DP" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(PSH_NO,8) AS DocNo From PSHEADER Order By RIGHT(PSH_NO,8) DESC");
                    break;
                case cls_Struct.VoucherType.TS:
                    Hno = "IW" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(TSH_NO,8) AS DocNo From TSHEADER Order By RIGHT(TSH_NO,8) DESC");
                    break;

                case cls_Struct.VoucherType.RSR:
                    Hno = "IW" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                    sb.AppendLine("Select TOP 1 RIGHT(RSRH_NO,8) AS DocNo From RSRHEADER Order By RIGHT(RSRH_NO,8) DESC");
                    break;
                }

                using (SqlCommand cmd = conn.CreateCommand())
                {
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Clear();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    runNo = reader["DocNo"].ToString();
                    if (runNo.Length != 8 || !IsNumeric(runNo))
                    {
                    runNo = "00000000";
                    }
                }
                else
                {
                    runNo = "00000000";
                }
                reader.Close();
                while (!DocOK)
                {
                    runNo = (int.Parse(runNo) + 1).ToString().PadLeft(8, '0');
                    result = string.Concat(Hno, runNo);

                    sb.Clear();
                    switch (type)
                    {
                    case cls_Struct.VoucherType.PO:
                        sb.AppendLine("Select PO_NO From POHEADER Where PO_NO = @No");
                        break;
                    case cls_Struct.VoucherType.RC:
                        sb.AppendLine("Select RC_NO From RCHEADER Where RC_NO = @No");
                        break;
                    case cls_Struct.VoucherType.JOB:
                        sb.AppendLine("Select JOB_NO From JOBHEAD Where JOB_NO = @No");
                        break;
                    case cls_Struct.VoucherType.RO:
                        sb.AppendLine("Select RO_NO From ROHEADER Where RO_NO = @No");
                        break;
                    case cls_Struct.VoucherType.SQ:
                        sb.AppendLine("Select SQ_NO From SQHEADER Where SQ_NO = @No");
                        break;
                    case cls_Struct.VoucherType.BS:
                        //แยกขายสดขายเชือ
                        sb.AppendLine("Select BSH_NO From BSHEADER Where BSH_NO = @No");                  
                        break;
                    case cls_Struct.VoucherType.RS:
                        sb.AppendLine("Select RSH_NO From ETAXHEADER Where RSH_NO = @No");
                        break;
                    case cls_Struct.VoucherType.PS:
                        sb.AppendLine("Select PSH_NO From PSHEADER Where PSH_NO = @No");
                        break;
                    case cls_Struct.VoucherType.TS:
                        sb.AppendLine("Select TSH_NO From TSHEADER Where TSH_NO = @No");
                        break;
                    case cls_Struct.VoucherType.RSR:
                        sb.AppendLine("Select RSRH_NO From RSRHEADER Where RSRH_NO = @No");
                        break;
                    }
                    cmd.CommandText = sb.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@No", SqlDbType.VarChar, 20).Value = result;
                    reader = cmd.ExecuteReader();
                    DocOK = !reader.HasRows;
                    reader.Close();
                }
                }
            }
            }
            catch (Exception ex)
            {
            XtraMessageBox.Show("GetAutotNumber :" + ex.Message);
            }
            finally
            {
            cls_Global_DB.CloseDB(ref conn); conn.Dispose();
            }
            return result;
        }

        #region function Convert
        public static int ConvertToInt(string _value)
        {
            int result = 0;
            if (int.TryParse(_value, out result))
                return result;

            return result;
        }
            #endregion
        #endregion
    }
}
