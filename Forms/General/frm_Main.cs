using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;

using Microsoft.Win32;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using SmartPart.Class;
using SmartPart.Forms.Code;
using SmartPart.Forms.General;
using SmartPart.Forms.Input;
using SmartPart.Forms.Sale;

namespace SmartPart
{
    public partial class frm_Main : RibbonForm
    {
        private bool conOK = false;
        private bool conNovatOK = false;
        private bool flag = false;
        private string SelectPage = string.Empty;
        frm_SPWenter frm_SPW;

        #region " Function "
        public void InitialDialogForm(cls_Struct.ActionMode mode)
        {
        try
        {
            int pid = 0;
            string strMode = "";

            switch (mode)
            {
                case cls_Struct.ActionMode.Add:
                    strMode = " [เปิดใหม่]";
                    break;
            }

            frm_BSRecord frm = new frm_BSRecord(mode, pid, cls_Sales.Sale_Cus, cls_Sales.Sale_User);
            frm.StartPosition = FormStartPosition.CenterParent;

            frm.Text = "ขายสินค้า -" + strMode;
            frm.MinimizeBox = false;
            frm.ShowInTaskbar = false;
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.UseWaitCursor = false;
                this.Cursor = Cursors.Default;
            }
            this.Select();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show("InitialDialogForm :" + ex.Message);
        }
        }

        public void InitialDialogFormfilter()
        {
        FilterBS frmInput;
        frmInput = new FilterBS();
        frmInput.StartPosition = FormStartPosition.CenterParent;

        try
        {
            frmInput.Text = "Condition";
            #region "Assign Lookup"
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            cls_Sales.FilterOption = frmInput.MainCondition;                                

        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
        }
        }

        public void InitialDialogFormOpenBill()
        {
        frm_OpenBill frmInput;
        frmInput = new frm_OpenBill();
        frmInput.StartPosition = FormStartPosition.CenterParent;

        try
        {
            frmInput.Text = "ขายสินค้า";
            #region "Assign Lookup"
            #endregion
            frmInput.MinimizeBox = false;
            frmInput.ShowInTaskbar = false;
            if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            int CUSid = frmInput.CUS_ID;
            int PERid = frmInput.PER_ID;

            cls_Sales.Sale_ISCASH = false;
            cls_Sales.Sale_Cus = CUSid;
            cls_Sales.Sale_User = PERid;


            //if (cls_Sales.FilterOption == 0) return;
            this.Cursor = Cursors.WaitCursor;

            InitialDialogForm(cls_Struct.ActionMode.Add);

            this.Cursor = Cursors.Default;


            //Class_Library mc = new Class_Library();
            //Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
            //Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

            //if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
            //{
            //    return;
            //}
            //if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    cls_Form.GB_Instance[i].instanceused = true;
            //    cls_Form.GB_Instance[i].instanceusedid = tag;
            //    cls_Form.GB_Instance[i].instanceform = new frm_BSRecord(cls_Struct.ActionMode.Add,0, CUSid, PERid);
                    
            //    cls_Form.GB_Instance[i].instanceform.Text = "ขายสินค้า";
            //    cls_Form.GB_Instance[i].instanceform.Tag = tag;
            //    cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
            //    cls_Form.GB_Instance[i].instanceform.MdiParent = this;
            //    cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //    cls_Form.GB_Instance[i].instanceform.Show();
            //    this.Cursor = Cursors.Default;
            //}
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message);
            Application.DoEvents();
        }
        }

        #endregion

        public frm_Main()
        {
            InitializeComponent();
            SelectSkin();

            this.Text = "Smart Parts";
            conOK = false;
            conNovatOK = false;
            showconnect();
        
            SelectPage = Properties.Settings.Default.SelectPage.ToString();
            switch (SelectPage)
            {
                case "ribSystem": ribbon.SelectedPage = ribTask; break;
            }
       
            //dockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;

            conOK = true;

            cls_Global_class.GB_Userid = 1;


            //ZOZO ---1
            //if (conOK)
            //{

            //  frm_SPW = new frm_SPWenter();
            //  if (frm_SPW.ShowDialog() == DialogResult.OK)
            //  {
            //    cls_Global_class.GB_Userok = true;
            //    flag = true;
            //    this.Text = this.Text + "  [" + cls_Global_class.USRnameE + "]";
            //  }
            //  else
            //  {
            //    cls_Global_class.GB_Userok = false;
            //    cls_Global_class.GB_Userid = 0;
            //    cls_Global_class.GB_USMs1 = 0;
            //    cls_Global_class.GB_USMs2 = 0;
            //    cls_Global_class.GB_USMs3 = 0;
            //    cls_Global_class.GB_USMs4 = 0;
            //    cls_Global_class.GB_USMs5 = 0;
            //    cls_Global_class.GB_USMs6 = 0;
            //    flag = false;
            //  }
            //  MainMenuVisibleEnable(cls_Global_class.GB_Userok);
            //}
            //ZOZO---2

        }

        private void barListing_ItemClick(object sender, ItemClickEventArgs e)
        {
        string etag = "0";
        //int book  = 0;
        string NameVoucher = "";

        try
        {
        etag = System.Convert.ToString(e.Item.Tag); //ประเภทใบสำคัญ
        NameVoucher =  System.Convert.ToString(e.Item.Caption);
        }
        catch (Exception ex)
        {
        etag = "0";
        }

        string tag = System.Convert.ToString(e.Item.Tag);
        int Stype = System.Convert.ToInt32(tag);
        int i = -1;

        bool isOK = false;

        switch (Stype)
        {
        case 201:
        //isOK = cls_General_PI.GetSecurityOK(2, cls_General_PI.GB_USMs2, 1);
        break;
        case 202:
        //isOK = cls_General_PI.GetSecurityOK(2, cls_General_PI.GB_USMs2, 6);
        break;
        case 203:
        //isOK = cls_General_PI.GetSecurityOK(2, cls_General_PI.GB_USMs2, 11);
        break;
        case 204:
        //isOK = cls_General_PI.GetSecurityOK(2, cls_General_PI.GB_USMs2, 16);
        break;
        case 205:
        break;
        case 206:
        break;
        case 207:
        break;
        case 301:
        break;
        case 302:
        break;
        case 401:
        break;
        case 402:
        break;
        case 403:
        break;
        case 404:
        break;
        }

        //if ((!isOK) && (cls_General_PI.GB_UserCode != "ADMIN"))
        //{
        //  frm_NoAccess frm;
        //  frm = new frm_NoAccess();
        //  frm.ShowDialog();
        //  return;
        //}

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        //Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);

        //if (Find_DuplicateInstance(tag, ref cls_General_PI.GB_Instance, 50))
        //{
        //  return;
        //}

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;

        switch (Stype)
        {
        case 201:
        //isOK = cls_General_PI.GetSecurityOK(2, cls_General_PI.GB_USMs2, 1);
            
        break;
        case 202:
        //isOK = cls_General_PI.GetSecurityOK(2, cls_General_PI.GB_USMs2, 6);
        break;
        case 203:
        //isOK = cls_General_PI.GetSecurityOK(2, cls_General_PI.GB_USMs2, 11);
        break;
        case 204:
        //isOK = cls_General_PI.GetSecurityOK(2, cls_General_PI.GB_USMs2, 16);
        break;
        case 205:
        break;
        case 206:
        break;
        case 207:
        break;
        case 301:
        break;
        case 302:
        break;
        case 401:
        break;
        case 402:
        break;
        case 403:
        break;
        case 404:
        break;
        }
        //if (Stype == 207)
        //{
        //  cls_Form.GB_Instance[i].instanceform = new frm_ListProblem(Stype);
        //}
        //else
        //{
        //  cls_Form.GB_Instance[i].instanceform = new frm_ListVoucher(Stype);
        //}
        //*******************  รายการใบสำคัญทั้งหมด หรือ ใบสำคัญชั่วคราวจะมีค่าเป็น 0  ********************************
        cls_Form.GB_Instance[i].instanceform.Text = NameVoucher;
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
    
        private void viewSkin_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
        Properties.Settings.Default.SkinSetting = e.Item.Caption.ToString();
        Properties.Settings.Default.Save();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

        }  

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        DialogResult dlr = XtraMessageBox.Show("Quit System ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (dlr == DialogResult.Yes)
        {
        e.Cancel = false;
        }
        else
        {
        e.Cancel = true;
        }
        }

        protected void MainMenuVisibleEnable(bool isOK)
        {
        int i;

        }

        private void MdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
        TabFormPageChangeRoutine();
        }

        private void SelectSkin()
        {
        ribbon.ForceInitialize();
        GalleryDropDown skins = new GalleryDropDown();
        skins.Ribbon = ribbon;
        DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGalleryDropDown(skins);
        //barSkin.DropDownControl = skins;
        SkinHelper.InitSkinGallery(viewSkin, true);
        UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.SkinSetting.ToString());
        skins.GalleryItemClick += new GalleryItemClickEventHandler(this.viewSkin_GalleryItemClick);
        }

        private void showconnect()
        {
        SqlConnection cn = new SqlConnection();

        try
        {
        RegistryKey Key = Registry.CurrentUser.CreateSubKey("Software\\SMARTPART2");
        int i = Key.ValueCount;
        if (i == 0)
        {
        Key.SetValue("ServerName", ASCIIEncoding.ASCII.GetBytes(""), RegistryValueKind.Binary);
        Key.SetValue("ServerDBname", ASCIIEncoding.ASCII.GetBytes(""), RegistryValueKind.Binary);
        Key.SetValue("ServerUser", ASCIIEncoding.ASCII.GetBytes(""), RegistryValueKind.Binary);
        Key.SetValue("ServerPass", ASCIIEncoding.ASCII.GetBytes(""), RegistryValueKind.Binary);
        }

        object sn = Key.GetValue("ServerName");
        object sdb = Key.GetValue("ServerDBname");
        object su = Key.GetValue("ServerUser");
        object sp = Key.GetValue("ServerPass");

        string Regsn = cls_Global_class.Decrypt(ASCIIEncoding.ASCII.GetString((byte[])sn).ToString());
        string Regsdb = cls_Global_class.Decrypt(ASCIIEncoding.ASCII.GetString((byte[])sdb).ToString());
        string Regsu = cls_Global_class.Decrypt(ASCIIEncoding.ASCII.GetString((byte[])su).ToString());
        string Regsp = cls_Global_class.Decrypt(ASCIIEncoding.ASCII.GetString((byte[])sp).ToString());

        cls_Global_DB.GB_ServerDBname = "";
        cls_Global_class.GB_DatabaseOK = false;
        cls_Global_DB.GB_ServerName = Regsn;
        cls_Global_DB.GB_ServerUser = Regsu;
        cls_Global_DB.GB_ServerPass = Regsp;
        cls_Global_DB.GB_ServerDBname = Regsdb;
        if (Regsn.Length > 0)
        {
        cn = new SqlConnection();
        if (cls_Global_DB.ConnectDatabase(ref cn))
        {
        cls_Global_DB.GB_ReportOK = true;
        }
        }

        frm_sysDBMain frm_DB;
        if (Regsn.Length == 0 || Regsu.Length == 0 || Regsp.Length == 0)
        {
        frm_DB = new frm_sysDBMain();
        if (frm_DB.ShowDialog() == DialogResult.OK)
        {
        conOK = true;
        }
        else
        {
        conOK = false;
        }
        }
        else
        {
        cn = new SqlConnection();
        if (!cls_Global_DB.ConnectDatabase(ref cn))
        {
        frm_DB = new frm_sysDBMain();
        if (frm_DB.ShowDialog() == DialogResult.OK)
        {
            conOK = true;
        }
        else
        {
            conOK = false;
        }
        }
        else
        {
        conOK = true;
        cls_Global_class.GB_DatabaseOK = true;
        }
        }

        if (conOK)
        {
        cls_Global_DB.GB_MOD();
        }

        }
        catch
        {
        conOK = false;
        }
        }

        private void TabFormPageChangeRoutine()
        {
            string formtag = "";
            DevExpress.XtraEditors.XtraForm instanceform = (DevExpress.XtraEditors.XtraForm)this.ActiveMdiChild;
            try
            {
                ribbonPageGroupActions.Visible = false;
                ribbonPageGroupPrint.Visible = false;
                ribbonPageGroupView.Visible = false;
                ribbonPageGroupPriceList.Visible = false;
                //ribbon.Minimized = false;
                //dockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                if (instanceform == null)
                return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            return;
            }

            try
            {
                formtag = Convert.ToString(instanceform.Tag);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                formtag = "";
            }

            ribbon.Minimized = false;
            switch (formtag)
            {
                case "1001":  //Categories
                case "1002":  //Types
                case "1003":  //Types
                case "1004":  //Types
                case "1006":  //Models
                case "1007":  //PO Groups
                case "1008":  //Transport
                case "1009":  //Buying
                case "1010":  //Logistic Company
                case "1011":  //Package Type
                case "1012":  //Bank
                case "1013":  //Bank
                case "1014":  //Document
                case "1015":  //Job Type
                case "1016":  //Special
                case "1017":  //Employee
                case "1018":  //Pesonal
                case "1019":  //Contact
                case "1020":  //Credit Card
                case "1021":  //Size
                case "1022":  //Versatile
                case "1023":  //Bank Account
                case "1024":  //Bank Account
                case "2001":  //Customer
                case "3001":  //Vendor
                ribbonPageGroupActions.Visible = true;
                ribbonPageGroupPrint.Visible = true;
                ribbonPageGroupView.Visible = true;
                break;
                case "1025":  //Price List
                ribbonPageGroupActions.Visible = true;
                ribbonPageGroupPrint.Visible = true;
                ribbonPageGroupView.Visible = true;
                ribbonPageGroupPriceList.Visible = true;
                break;
                case "4001":  //Product
                ribbonPageGroupActions.Visible = true;
                ribbonPageGroupPrint.Visible = true;
                ribbonPageGroupView.Visible = true;
                break;
                case "5001":  //Complementary
                case "5002":  //Complementary Sub1
                case "5003":  //Complementary Sub2
                case "5004":  //Complementary Sub3
                ribbonPageGroupActions.Visible = true;
                ribbonPageGroupPrint.Visible = true;
                ribbonPageGroupView.Visible = true;
                break;
                case "6001":  //Substitute
                case "6002":  //Substitute Sub1
                case "6003":  //Substitute Sub2
                ribbonPageGroupActions.Visible = true;
                ribbonPageGroupPrint.Visible = true;
                ribbonPageGroupView.Visible = true;
                break;
                case "9001":
                ribbon.Minimized = true;
                dockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                break;
            }
        }

        private void ribbon_SelectedPageChanging(object sender, RibbonPageChangingEventArgs e)
        {
        Properties.Settings.Default.SelectPage = e.Page.Name.ToString();
        Properties.Settings.Default.Save();
        }

        private void bt_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
        string _tag = "";

        try
        {
        }
        catch (Exception)
        {
            
        throw;
        }
        }

        private void MdiManager_SelectedPageChanged_1(object sender, EventArgs e)
        {
        TabFormPageChangeRoutine();
        }

        private void barButtonItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
        this.Close();
        }

        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
        try
        {
        XtraForm frm = (XtraForm)this.ActiveMdiChild;
        switch (frm.Tag.ToString())
        {
        case "1001":  //Category
        frm_Categories_List instantCategory = (frm_Categories_List)frm;
        instantCategory.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1002":  //Type
        frm_Types_List instantType = (frm_Types_List)frm;
        instantType.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1003":  //Brand
        frm_Brands_List instantBrand = (frm_Brands_List)frm;
        instantBrand.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1004":  //Unit
        frm_Units_List instantUnit = (frm_Units_List)frm;
        instantUnit.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1006":  //Model
        frm_Models_List instantModel = (frm_Models_List)frm;
        instantModel.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1007":  //PO Groups
        frm_POGroups_List instantPOs = (frm_POGroups_List)frm;
        instantPOs.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1008":  //Transport
        frm_Transports_List instantTrans = (frm_Transports_List)frm;
        instantTrans.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1009":  //Buying
        frm_Buying_List instantBuying = (frm_Buying_List)frm;
        instantBuying.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1010":  //Logistic Company
        frm_LogisticCompany_List instantLogis = (frm_LogisticCompany_List)frm;
        instantLogis.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1011":  //Package Type
        frm_PackageTypes_List instantPackageType = (frm_PackageTypes_List)frm;
        instantPackageType.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1012":  //Package Type
        frm_ReturnReason_List instantReturn = (frm_ReturnReason_List)frm;
        instantReturn.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1013":  //Bank
        frm_Banks_List instantBank = (frm_Banks_List)frm;
        instantBank.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1014":  //Document
        frm_Documents_List instantDoc = (frm_Documents_List)frm;
        instantDoc.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1015":  //Job Type
        frm_JobTypes_List instantJob = (frm_JobTypes_List)frm;
        instantJob.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1016":  //Special
        frm_SpecialPOs_List instantSpecial = (frm_SpecialPOs_List)frm;
        instantSpecial.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1017":  //Employee
        frm_Employees_List instantEmployee = (frm_Employees_List)frm;
        instantEmployee.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1018":  //Personal
        frm_Personals_List instantPersonal = (frm_Personals_List)frm;
        instantPersonal.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1019":  //Contact
        frm_Contacts_List instantContact = (frm_Contacts_List)frm;
        instantContact.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1020":  //Creditcard
        frm_Creditcards_List instantCreditcard = (frm_Creditcards_List)frm;
        instantCreditcard.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1021":  //Size
        frm_Sizes_List instantSize = (frm_Sizes_List)frm;
        instantSize.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1022":  //Versatile
        frm_Versatiles_List instantVersatile = (frm_Versatiles_List)frm;
        instantVersatile.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1023":  //Bank Account
        frm_BankAccount_List instantBankAccount = (frm_BankAccount_List)frm;
        instantBankAccount.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "1024":  //Price List
        frm_PriceList_List instantPriceList = (frm_PriceList_List)frm;
        instantPriceList.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "2001":  //Customer
        frm_Customers_List instantCus = (frm_Customers_List)frm;
        instantCus.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "3001":  //Vendor
        frm_Vendors_List instantVen = (frm_Vendors_List)frm;
        instantVen.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "4001":  //Product
        frm_Product_List instantProduc = (frm_Product_List)frm;
        instantProduc.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "5001":  //Item Special
        frm_ItemSpecials_List instantItemSpecial = (frm_ItemSpecials_List)frm;
        instantItemSpecial.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "5002":  //Item Special Sub1
        frm_ItemSpecials_Sub1_List instantItemSpecialSub1 = (frm_ItemSpecials_Sub1_List)frm;
        instantItemSpecialSub1.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "5003":  //Item Special Sub2
        frm_ItemSpecials_Sub2_List instantItemSpecialSub2 = (frm_ItemSpecials_Sub2_List)frm;
        instantItemSpecialSub2.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "6001":  //Substitute
        frm_Substitutes_List instantSubstitute = (frm_Substitutes_List)frm;
        instantSubstitute.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "6002":  //Substitute Sub1
        frm_Substitutes_Sub1_List instantSubstituteSub1 = (frm_Substitutes_Sub1_List)frm;
        instantSubstituteSub1.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        case "6003":  //Substitute Sub2
        frm_Substitutes_Sub2_List instantSubstituteSub2 = (frm_Substitutes_Sub2_List)frm;
        instantSubstituteSub2.InitialDialogForm(cls_Struct.ActionMode.Add);
        break;
        }
        }
        catch (Exception ex)
        {
        MessageBox.Show(ex.Message);
        }
        }

        private void barButtonItemEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
        try
        {
        XtraForm frm = (XtraForm)this.ActiveMdiChild;
        switch (frm.Tag.ToString())
        {
        case "1001":  //Category
        frm_Categories_List instantCategory = (frm_Categories_List)frm;
        instantCategory.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1002":  //Type
        frm_Types_List instantType = (frm_Types_List)frm;
        instantType.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1003":  //Brand
        frm_Brands_List instantBrand = (frm_Brands_List)frm;
        instantBrand.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1004":  //Unit
        frm_Units_List instantUnit = (frm_Units_List)frm;
        instantUnit.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1006":  //Model
        frm_Models_List instantModel = (frm_Models_List)frm;
        instantModel.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1007":  //PO Groups
        frm_POGroups_List instantPOs = (frm_POGroups_List)frm;
        instantPOs.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1008":  //Transport
        frm_Transports_List instantTrans = (frm_Transports_List)frm;
        instantTrans.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1009":  //Buying
        frm_Buying_List instantBuying = (frm_Buying_List)frm;
        instantBuying.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1010":  //Logistic Company
        frm_LogisticCompany_List instantLogis = (frm_LogisticCompany_List)frm;
        instantLogis.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1011":  //Package Type
        frm_PackageTypes_List instantPackageType = (frm_PackageTypes_List)frm;
        instantPackageType.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1012":  //Package Type
        frm_ReturnReason_List instantReturn = (frm_ReturnReason_List)frm;
        instantReturn.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1013":  //Bank
        frm_Banks_List instantBank = (frm_Banks_List)frm;
        instantBank.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1014":  //Document
        frm_Documents_List instantDoc = (frm_Documents_List)frm;
        instantDoc.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1015":  //Job Type
        frm_JobTypes_List instantJob = (frm_JobTypes_List)frm;
        instantJob.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1016":  //Special
        frm_SpecialPOs_List instantSpecial = (frm_SpecialPOs_List)frm;
        instantSpecial.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1017":  //Employee
        frm_Employees_List instantEmployee = (frm_Employees_List)frm;
        instantEmployee.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1018":  //Personal
        frm_Personals_List instantPersonal = (frm_Personals_List)frm;
        instantPersonal.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1019":  //Contact
        frm_Contacts_List instantContact = (frm_Contacts_List)frm;
        instantContact.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1020":  //Creditcard
        frm_Creditcards_List instantCreditcard = (frm_Creditcards_List)frm;
        instantCreditcard.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1021":  //Size
        frm_Sizes_List instantSize = (frm_Sizes_List)frm;
        instantSize.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1022":  //Versatile
        frm_Versatiles_List instantVersatile = (frm_Versatiles_List)frm;
        instantVersatile.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1023":  //Bank Account
        frm_BankAccount_List instantBankAccount = (frm_BankAccount_List)frm;
        instantBankAccount.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "1024":  //Price List
        frm_PriceList_List instantPriceList = (frm_PriceList_List)frm;
        instantPriceList.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "2001":  //Customer
        frm_Customers_List instantCus = (frm_Customers_List)frm;
        instantCus.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "3001":  //Vendor
        frm_Vendors_List instantVen = (frm_Vendors_List)frm;
        instantVen.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "4001":  //Product
        frm_Product_List instantProduc = (frm_Product_List)frm;
        instantProduc.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "5001":  //Item Special
        frm_ItemSpecials_List instantItemSpecial = (frm_ItemSpecials_List)frm;
        instantItemSpecial.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "5002":  //Item Special Sub1
        frm_ItemSpecials_Sub1_List instantItemSpecialSub1 = (frm_ItemSpecials_Sub1_List)frm;
        instantItemSpecialSub1.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "5003":  //Item Special Sub2
        frm_ItemSpecials_Sub2_List instantItemSpecialSub2 = (frm_ItemSpecials_Sub2_List)frm;
        instantItemSpecialSub2.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "6001":  //Substitute
        frm_Substitutes_List instantSubstitute = (frm_Substitutes_List)frm;
        instantSubstitute.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "6002":  //Substitute Sub1
        frm_Substitutes_Sub1_List instantSubstituteSub1 = (frm_Substitutes_Sub1_List)frm;
        instantSubstituteSub1.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        case "6003":  //Substitute Sub2
        frm_Substitutes_Sub2_List instantSubstituteSub2 = (frm_Substitutes_Sub2_List)frm;
        instantSubstituteSub2.InitialDialogForm(cls_Struct.ActionMode.Edit);
        break;
        }
        }
        catch (Exception ex)
        {
        MessageBox.Show(ex.Message);
        }
        }
        private void navBarItemProduct_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "4001";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Product_List();
        cls_Form.GB_Instance[i].instanceform.Text = "รหัสสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void navBarItemCategories_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1001";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Categories_List();
        cls_Form.GB_Instance[i].instanceform.Text = "หมวดหมู่สินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
        try
        {
        XtraForm frm = (XtraForm)this.ActiveMdiChild;
        switch (frm.Tag.ToString())
        {
        case "1001":  //Category
        frm_Categories_List instantCategory = (frm_Categories_List)frm;
        instantCategory.DeleteData();
        break;
        case "1002":  //Type
        frm_Types_List instantType = (frm_Types_List)frm;
        instantType.DeleteData();
        break;
        case "1003":  //Brand
        frm_Brands_List instantBrand = (frm_Brands_List)frm;
        instantBrand.DeleteData();
        break;
        case "1004":  //Unit
        frm_Units_List instantUnit = (frm_Units_List)frm;
        instantUnit.DeleteData();
        break;
        case "1006":  //Model
        frm_Models_List instantModel = (frm_Models_List)frm;
        instantModel.DeleteData();
        break;
        case "1007":  //PO Groups
        frm_POGroups_List instantPOs = (frm_POGroups_List)frm;
        instantPOs.DeleteData();
        break;
        case "1008":  //Transport
        frm_Transports_List instantTrans = (frm_Transports_List)frm;
        instantTrans.DeleteData();
        break;
        case "1009":  //Buying
        frm_Buying_List instantBuying = (frm_Buying_List)frm;
        instantBuying.DeleteData();
        break;
        case "1010":  //Logistic Company
        frm_LogisticCompany_List instantLogis = (frm_LogisticCompany_List)frm;
        instantLogis.DeleteData();
        break;
        case "1011":  //Package Type
        frm_PackageTypes_List instantPackageType = (frm_PackageTypes_List)frm;
        instantPackageType.DeleteData();
        break;
        case "1012":  //Return Reason
        frm_ReturnReason_List instantReturn = (frm_ReturnReason_List)frm;
        instantReturn.DeleteData();
        break;
        case "1013":  //Bank
        frm_Banks_List instantBank = (frm_Banks_List)frm;
        instantBank.DeleteData();
        break;
        case "1014":  //Document
        frm_Documents_List instantDoc = (frm_Documents_List)frm;
        instantDoc.DeleteData();
        break;
        case "1015":  //Job Type
        frm_JobTypes_List instantJob = (frm_JobTypes_List)frm;
        instantJob.DeleteData();
        break;
        case "1016":  //Special
        frm_SpecialPOs_List instantSpecial = (frm_SpecialPOs_List)frm;
        instantSpecial.DeleteData();
        break;
        case "1017":  //Employee
        frm_Employees_List instantEmployee = (frm_Employees_List)frm;
        instantEmployee.DeleteData();
        break;
        case "1018":  //Personal
        frm_Personals_List instantPersonal = (frm_Personals_List)frm;
        instantPersonal.DeleteData();
        break;
        case "1019":  //Contact
        frm_Contacts_List instantContact = (frm_Contacts_List)frm;
        instantContact.DeleteData();
        break;
        case "1020":  //Creditcard
        frm_Creditcards_List instantCreditcard = (frm_Creditcards_List)frm;
        instantCreditcard.DeleteData();
        break;
        case "1021":  //Size
        frm_Sizes_List instantSize = (frm_Sizes_List)frm;
        instantSize.DeleteData();
        break;
        case "1022":  //Versatile
        frm_Versatiles_List instantVersatile = (frm_Versatiles_List)frm;
        instantVersatile.DeleteData();
        break;
        case "1023":  //Bank Account
        frm_BankAccount_List instantBankAccount = (frm_BankAccount_List)frm;
        instantBankAccount.DeleteData();
        break;
        case "1024":  //Price List
        frm_PriceList_List instantPriceLis = (frm_PriceList_List)frm;
        instantPriceLis.DeleteData();
        break;
        case "2001":  //Customer
        frm_Customers_List instantCus = (frm_Customers_List)frm;
        instantCus.DeleteData();
        break;
        case "3001":  //Vendor
        frm_Vendors_List instantVen = (frm_Vendors_List)frm;
        instantVen.DeleteData();
        break;
        case "4001":  //Product
        frm_Product_List instantProduc = (frm_Product_List)frm;
        instantProduc.DeleteData();
        break;
        case "5001":  //Item Special
        frm_ItemSpecials_List instantItemSpecial = (frm_ItemSpecials_List)frm;
        instantItemSpecial.DeleteData();
        break;
        case "5002":  //Item Special Sub1
        frm_ItemSpecials_Sub1_List instantItemSpecialSub1 = (frm_ItemSpecials_Sub1_List)frm;
        instantItemSpecialSub1.DeleteData();
        break;
        case "5003":  //Item Special Sub2
        frm_ItemSpecials_Sub2_List instantItemSpecialSub2 = (frm_ItemSpecials_Sub2_List)frm;
        instantItemSpecialSub2.DeleteData();
        break;
        case "6001":  //Substitute
        frm_Substitutes_List instantSubstitute = (frm_Substitutes_List)frm;
        instantSubstitute.DeleteData();
        break;
        case "6002":  //Substitute Sub1
        frm_Substitutes_Sub1_List instantSubstituteSub1 = (frm_Substitutes_Sub1_List)frm;
        instantSubstituteSub1.DeleteData();
        break;
        case "6003":  //Substitute Sub2
        frm_Substitutes_Sub2_List instantSubstituteSub2 = (frm_Substitutes_Sub2_List)frm;
        instantSubstituteSub2.DeleteData();
        break;
        }
        }
        catch (Exception ex)
        {
        MessageBox.Show(ex.Message);
        }
        }
        private void navBarItemProductType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1002";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Types_List();
        cls_Form.GB_Instance[i].instanceform.Text = "ประเภทสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void navBarItemUnit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1004";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Units_List();
        cls_Form.GB_Instance[i].instanceform.Text = "หน่วยนับสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void barButtonItemView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void navBarItemModel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1006";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Models_List();
        cls_Form.GB_Instance[i].instanceform.Text = "รุ่นสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void navBarItemProductPO_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1007";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_POGroups_List();
        cls_Form.GB_Instance[i].instanceform.Text = "กลุ่มสั่งซื้อสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void navBarItemDelivery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1008";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Transports_List();
        cls_Form.GB_Instance[i].instanceform.Text = "การจัดส่งสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void navBarItemPOType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1009";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Buying_List();
        cls_Form.GB_Instance[i].instanceform.Text = "ประเภทการซื้อสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void navBarItemProductCompany_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1010";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_LogisticCompany_List();
        cls_Form.GB_Instance[i].instanceform.Text = "บริษัทขนส่งสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void navBarItemDocument_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1014";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Documents_List();
        cls_Form.GB_Instance[i].instanceform.Text = "เอกสาร";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }
        private void navBarItemBank_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1013";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Banks_List();
        cls_Form.GB_Instance[i].instanceform.Text = "ธนาคาร";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemCusomer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "2001";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }
        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Customers_List();
        cls_Form.GB_Instance[i].instanceform.Text = "รหัสลูกค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemVendors_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "3001";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }
        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Vendors_List();
        cls_Form.GB_Instance[i].instanceform.Text = "รหัสพ่อค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemJobType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1015";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_JobTypes_List();
        cls_Form.GB_Instance[i].instanceform.Text = "ประเภทงาน";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSpecials_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1016";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_SpecialPOs_List();
        cls_Form.GB_Instance[i].instanceform.Text = "คำสั่งพิเศษ (P/O)";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemEmployee_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1017";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Employees_List();
        cls_Form.GB_Instance[i].instanceform.Text = "พนักงาน";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemPersonal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1018";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Personals_List();
        cls_Form.GB_Instance[i].instanceform.Text = "บุคคลทั่วไป";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemPacking_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1011";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_PackageTypes_List();
        cls_Form.GB_Instance[i].instanceform.Text = "ชนิดบรรจุสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemReturns_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1012";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_ReturnReason_List();
        cls_Form.GB_Instance[i].instanceform.Text = "เหตุผลการคืนสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemContact_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1019";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Contacts_List();
        cls_Form.GB_Instance[i].instanceform.Text = "วิธีการติดต่อ";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemCreditCard_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1020";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Creditcards_List();
        cls_Form.GB_Instance[i].instanceform.Text = "บัตรเครดิต";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemBrand_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1003";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Brands_List();
        cls_Form.GB_Instance[i].instanceform.Text = "ยี่ห้อสินค้า";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSpecial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "5001";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_ItemSpecials_List();
        cls_Form.GB_Instance[i].instanceform.Text = "กลุ่มสินค้าเฉพาะ";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSpecialSub1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "5002";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_ItemSpecials_Sub1_List();
        cls_Form.GB_Instance[i].instanceform.Text = "สินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 1";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSpecialSub2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "5003";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_ItemSpecials_Sub2_List();
        cls_Form.GB_Instance[i].instanceform.Text = "สินค้าเฉพาะกลุ่ม กลุ่มย่อยระดับที่ 2";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSub3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "5004";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Complementarys_Sub3_List();
        cls_Form.GB_Instance[i].instanceform.Text = "กลุ่มสินค้าเฉพาะใช้ด้วยกัน 3 ";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSize_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1021";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Sizes_List();
        cls_Form.GB_Instance[i].instanceform.Text = "ประเภทสินค้า + ขนาด";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSubS1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "6002";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Substitutes_Sub1_List();
        cls_Form.GB_Instance[i].instanceform.Text = "กลุ่มสินค้าเฉพาะใช้แทนกัน 1 ";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSubs2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "6003";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Substitutes_Sub2_List();
        cls_Form.GB_Instance[i].instanceform.Text = "กลุ่มสินค้าเฉพาะใช้แทนกัน 2 ";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSub_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "6001";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Substitutes_List();
        cls_Form.GB_Instance[i].instanceform.Text = "กลุ่มสินค้าเฉพาะใช้แทนกัน";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemVersatile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1022";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_Versatiles_List();
        cls_Form.GB_Instance[i].instanceform.Text = "กลุ่มสินค้าอเนกประสงค์";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemBankAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1023";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_BankAccount_List();
        cls_Form.GB_Instance[i].instanceform.Text = "บัญชีเงินฝากธนาคาร";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemSearch_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string tag = "9001";
            int i = -1;

            Class_Library mc = new Class_Library();
            Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
            Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

            if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
            {
                return;
            }
            if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
            {
                this.Cursor = Cursors.WaitCursor;

                cls_Form.GB_Instance[i].instanceused = true;
                cls_Form.GB_Instance[i].instanceusedid = tag;
                cls_Form.GB_Instance[i].instanceform = new frmInput2();
                cls_Form.GB_Instance[i].instanceform.Text = "การค้นหา";
                cls_Form.GB_Instance[i].instanceform.Tag = tag;
                cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                cls_Form.GB_Instance[i].instanceform.Show();
                this.Cursor = Cursors.Default;
            }
        }

        private void navBarItemPriceList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "1025";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);
        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }

        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_PriceList_List();
        cls_Form.GB_Instance[i].instanceform.Text = "Price List";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void barButtonItemImportPriceList_ItemClick(object sender, ItemClickEventArgs e)
        {
        frm_ImportPriceList frm_import;
        frm_import = new frm_ImportPriceList();
        //frm_import.MdiParent = this;
        //frm_import.WindowState = FormWindowState.Maximized;
        frm_import.StartPosition = FormStartPosition.CenterParent;
        frm_import.ShowInTaskbar = false;
        frm_import.ShowDialog();
        }

        private void navBarItemSales_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "9002";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
            cls_Form.FocusForm(MdiManager, "รายการขายสินค้า");
            return;               
        }
        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
            cls_Sales.FilterOption = 0;
            InitialDialogFormfilter();
            if (cls_Sales.FilterOption == 0) return;
            this.Cursor = Cursors.WaitCursor;

            switch (cls_Sales.FilterOption)
            {
                case 1:
                    InitialDialogFormOpenBill();
                    break;
                case 2:
                case 3:
                case 4:
                    FilterStaff frmInput;
                    frmInput = new FilterStaff();
                    frmInput.StartPosition = FormStartPosition.CenterParent;

                    frmInput.Text = "ระบุพนักงาน";
                    #region "Assign Lookup"
                    #endregion
                    frmInput.MinimizeBox = false;
                    frmInput.ShowInTaskbar = false;
                    if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }



                    cls_Form.GB_Instance[i].instanceused = true;
                    cls_Form.GB_Instance[i].instanceusedid = tag;
                    cls_Form.GB_Instance[i].instanceform = new frm_BSList();
                    cls_Form.GB_Instance[i].instanceform.Text = "รายการขายสินค้า";
                    cls_Form.GB_Instance[i].instanceform.Tag = tag;
                    cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                    cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                    cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    cls_Form.GB_Instance[i].instanceform.Show();
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    cls_Form.GB_Instance[i].instanceused = true;
                    cls_Form.GB_Instance[i].instanceusedid = tag;
                    cls_Form.GB_Instance[i].instanceform = new frm_BSList();
                    cls_Form.GB_Instance[i].instanceform.Text = "รายการขายสินค้า";
                    cls_Form.GB_Instance[i].instanceform.Tag = tag;
                    cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                    cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                    cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    cls_Form.GB_Instance[i].instanceform.Show();
                    break;
                case 11:
                case 12:
                    FilterCashier frmInpuCashiert;
                    frmInpuCashiert = new FilterCashier();
                    frmInpuCashiert.StartPosition = FormStartPosition.CenterParent;

                    frmInpuCashiert.Text = "ระบุพนักงานขาย";
                    #region "Assign Lookup"
                    #endregion
                    frmInpuCashiert.MinimizeBox = false;
                    frmInpuCashiert.ShowInTaskbar = false;
                    if (frmInpuCashiert.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }



                    cls_Form.GB_Instance[i].instanceused = true;
                    cls_Form.GB_Instance[i].instanceusedid = tag;
                    cls_Form.GB_Instance[i].instanceform = new frm_BSList();
                    cls_Form.GB_Instance[i].instanceform.Text = "รายการขายสินค้า";
                    cls_Form.GB_Instance[i].instanceform.Tag = tag;
                    cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                    cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                    cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    cls_Form.GB_Instance[i].instanceform.Show();
                    break;
                case 13:
                case 14:
                    FilterCustomer frmInpuCustomer;
                    frmInpuCustomer = new FilterCustomer();
                    frmInpuCustomer.StartPosition = FormStartPosition.CenterParent;

                    frmInpuCustomer.Text = "ระบุลูกค้า";
                    #region "Assign Lookup"
                    #endregion
                    frmInpuCustomer.MinimizeBox = false;
                    frmInpuCustomer.ShowInTaskbar = false;
                    if (frmInpuCustomer.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.Cursor = Cursors.Default;
                        return;
                    }



                    cls_Form.GB_Instance[i].instanceused = true;
                    cls_Form.GB_Instance[i].instanceusedid = tag;
                    cls_Form.GB_Instance[i].instanceform = new frm_BSList();
                    cls_Form.GB_Instance[i].instanceform.Text = "รายการขายสินค้า";
                    cls_Form.GB_Instance[i].instanceform.Tag = tag;
                    cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                    cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                    cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    cls_Form.GB_Instance[i].instanceform.Show();
                    break;
                default:
                    cls_Form.GB_Instance[i].instanceused = true;
                    cls_Form.GB_Instance[i].instanceusedid = tag;
                    cls_Form.GB_Instance[i].instanceform = new frm_BSList();
                    cls_Form.GB_Instance[i].instanceform.Text = "รายการขายสินค้า";
                    cls_Form.GB_Instance[i].instanceform.Tag = tag;
                    cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                    cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                    cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    cls_Form.GB_Instance[i].instanceform.Show();
                    break;
            }

                
            this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemPO_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "9005";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }
        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_PSList();
        cls_Form.GB_Instance[i].instanceform.Text = "ใบมัดจำ";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemReturn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "9006";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
        return;
        }
        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
        this.Cursor = Cursors.WaitCursor;

        cls_Form.GB_Instance[i].instanceused = true;
        cls_Form.GB_Instance[i].instanceusedid = tag;
        cls_Form.GB_Instance[i].instanceform = new frm_TSList();
        cls_Form.GB_Instance[i].instanceform.Text = "ใบรับคืน";
        cls_Form.GB_Instance[i].instanceform.Tag = tag;
        cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
        cls_Form.GB_Instance[i].instanceform.MdiParent = this;
        cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        cls_Form.GB_Instance[i].instanceform.Show();
        this.Cursor = Cursors.Default;
        }
        }

        private void navBarItemINV_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "9007";
        int i = -1;

            Class_Library mc = new Class_Library();
            Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
            Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

            if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
            {
                return;
            }
            if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
            {
                this.Cursor = Cursors.WaitCursor;

                cls_Form.GB_Instance[i].instanceused = true;
                cls_Form.GB_Instance[i].instanceusedid = tag;
                cls_Form.GB_Instance[i].instanceform = new frm_RSList();
                cls_Form.GB_Instance[i].instanceform.Text = "ใบกำกับภาษีขาย";
                cls_Form.GB_Instance[i].instanceform.Tag = tag;
                cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
                cls_Form.GB_Instance[i].instanceform.MdiParent = this;
                cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                cls_Form.GB_Instance[i].instanceform.Show();
                this.Cursor = Cursors.Default;
            }
        }

        private void navBarItemCN_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        string tag = "9008";
        int i = -1;

        Class_Library mc = new Class_Library();
        Class_Library.m_Find_DuplicateInstance Find_DuplicateInstance = new Class_Library.m_Find_DuplicateInstance(mc.Find_DuplicateInstance);
        Class_Library.m_Find_FreeInstance Find_FreeInstance = new Class_Library.m_Find_FreeInstance(mc.Find_FreeInstance);

        if (Find_DuplicateInstance(tag, ref cls_Form.GB_Instance, 50))
        {
            return;
        }
        if (Find_FreeInstance(ref i, ref cls_Form.GB_Instance, 50))
        {
            this.Cursor = Cursors.WaitCursor;

            cls_Form.GB_Instance[i].instanceused = true;
            cls_Form.GB_Instance[i].instanceusedid = tag;
            cls_Form.GB_Instance[i].instanceform = new frm_RSRList();
            cls_Form.GB_Instance[i].instanceform.Text = "ใบกำกับภาษีรับคืน";
            cls_Form.GB_Instance[i].instanceform.Tag = tag;
            cls_Form.GB_Instance[i].instanceform.AccessibleDescription = System.Convert.ToString(i);
            cls_Form.GB_Instance[i].instanceform.MdiParent = this;
            cls_Form.GB_Instance[i].instanceform.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            cls_Form.GB_Instance[i].instanceform.Show();
            this.Cursor = Cursors.Default;
        }
        }

    }
}