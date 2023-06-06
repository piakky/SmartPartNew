using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartPart
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      DevExpress.UserSkins.OfficeSkins.Register();
      DevExpress.UserSkins.BonusSkins.Register();
      DevExpress.Skins.SkinManager.EnableFormSkins();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Main());
        }
  }
}
