using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Medical.Class;
using System.Globalization;

namespace Medical.Forms.Report
{
  public partial class ReportAlertValidation : DevExpress.XtraReports.UI.XtraReport
  {
    public ReportAlertValidation(string Rfno, string Xcontact, int Cus_id, int Ins_id, int Dep_id , string model, string SN, DateTime d1, DateTime d2, decimal amount, string Standing, string Notes)
    {
      InitializeComponent();

      CultureInfo culture = CultureInfo.GetCultureInfo("th-TH");
      xrDate.Text = d1.ToString("D", culture);
      //xrRef.Text = "เลขที่  :  " + Rfno;
      //xrRef.AutoWidth = true;
      xrTableASC.Text = "  " + Standing;
      xrCus1.Text = "เรียน  :  " + Xcontact;
      //xrCus2.Text = cls_Data.GetTBname(Dep_id, "DEP", "Dep_NameT");
      xrCus2.Text = cls_Data.GetTBname(Cus_id, "CUS", "Cus_NameT");
      xrCus3.Visible = false;
      xrTableIns.Text = "";
      int specid = Convert.ToInt32(cls_Data.GetTBname(Ins_id, "Ins", "Ins_Spec_id"));
      xrTableIns.Text = "  " + cls_Data.GetTBname(specid, "Spec", "Spec_Name");
      xrTableModel.Text = "  " + model;
      xrTableSN.Text = "  " + SN;
      xrTableInsDate.Text = "  " + Convert.ToDateTime(cls_Data.GetTBname(Ins_id, "Ins", "Ins_DateInstall")).ToString("D", culture);
      xrTableDateVal.Text = "  " + d2.ToString("D", culture);
      xrTableNote.Text = "  " + Notes;
    }
  }
}
