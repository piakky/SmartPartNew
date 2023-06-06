using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Medical.Class;
using System.Globalization;

namespace Medical.Forms.Report
{
  public partial class ReportQuotationASC : DevExpress.XtraReports.UI.XtraReport
  {
    public ReportQuotationASC(string Rfno,string Xcontact, int Cus_id, int Ins_id, string model, string SN, DateTime d1, DateTime d2, decimal amount,string Pay,string Standing,DateTime df,DateTime dt)
    {
      InitializeComponent();
      decimal Xvat=0;

      CultureInfo culture = CultureInfo.GetCultureInfo("th-TH");

      xrDate.Text = d1.ToString("D", culture);
      xrRef.Text = "เลขที่  :  " + Rfno;
      xrRef.AutoWidth = true;
      xrCus1.Text = "เรียน  :  " + Xcontact;
      xrCus2.Text = cls_Data.GetTBname(Cus_id, "CUS", "Cus_NameT");
      xrCus3.Text = cls_Data.GetTBname(Cus_id, "CUS", "Cus_Contact1_Tel");
      xrTableIns.Text = "";
      int specid = Convert.ToInt32(cls_Data.GetTBname(Ins_id, "Ins", "Ins_Spec_id"));
      xrTableIns.Text = "  " + cls_Data.GetTBname(specid, "Spec", "Spec_Name");
      xrTableModel.Text = "  " + model;
      xrTableSN.Text = "  " + SN;
      xrTableAmount.Text =amount.ToString("#,##0.00") + " บาท";
      Xvat =(amount * 7)/ 100;
      xrTableVat.Text = Xvat.ToString("#,##0.00") + " บาท";
      xrTableSum.Text = (amount + Xvat).ToString("#,##0.00") + " บาท";
      xrTablePay.Text = "  " + Pay.Replace(Environment.NewLine, Environment.NewLine + "  ");
      xrTableStanding.Text = "  " + Standing;
      xrTableDateOld.Text = "  " + df.ToString("D", culture) + " - " + dt.ToString("D", culture); ;
      //xrTableCertificate.Text = "  " + Certificate;
      //xrTableFree.Text = "  " + Free;
      //xrTableDiscount.Text = "  " + Discount;
      //DateTime Xdate = Convert.ToDateTime(cls_Data.GetTBname(Ins_id, "Ins", "Ins_DateInstall"));
      //CultureInfo culture = CultureInfo.GetCultureInfo("en-GB");
      //xrDetail.Text = "ระยะเวลาให้บริการ : " + df.ToString("D", culture) + " - " + dt.ToString("D", culture);
      //xrLab_InsDate.Text = "วันที่ติดตั้ง : " + Xdate.ToString("D", culture);
      //xrEn1.Text = "3.     วิศวกรผู้รับผิดชอบ 1 : " + cls_Data.GetTBname(En1, "En", "En_NameT");
      //xrEn2.Text = "วิศวกรผู้รับผิดชอบ 2 : " + cls_Data.GetTBname(En2, "En", "En_NameT");
      //xrAmount.Text = "4.     ค่าบริการเป็นจำนวนเงิน " + amount.ToString("#,##0.00") + " บาท (ไม่รวมภาษีมูลค่าเพิ่ม) ";
      //xrLabCusF2.Text = cls_Data.GetTBname(Cus_id, "CUS", "Cus_NameT");
      //xrLabDateF1.Text = df.ToString("D", culture);
      //xrLabDateF2.Text = df.ToString("D", culture);
      //xrFootref.Text = Rfno;
    }

      

  }
}
