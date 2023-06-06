using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SmartPart.Class;

namespace SmartPart.Forms.General
{
  public partial class frm_SPWenter : DevExpress.XtraEditors.XtraForm
  {

    Class_Cryptography Cryp = new Class_Cryptography();
    public frm_SPWenter()
    {
      InitializeComponent();

      this.KeyPreview = true;
      SetObjectProperties();
    }
    private void SetObjectProperties()
  {
    txtUsername.Properties.CharacterCasing = CharacterCasing.Upper;
	}

    private void txtUsername_EditValueChanged(object sender, EventArgs e)
  {
    SetText(sender);
  }

    private void SetText(Object sender)
  {
	  //--- Varied length variables ---
	  TextEdit _sender  = (TextEdit)sender;

	  //--- Fixed length variables ---
	  bool secondcondition  = false;

	  try
    {
		  secondcondition = _sender.EditValue.ToString().Length == 0;
    }
	  catch ( Exception ex)
    {
		  secondcondition = true;
	  }

	  _sender.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
	  if ((_sender.EditValue == null) || (secondcondition))
    {
		  _sender.EditValue = null;
		  _sender.Properties.PasswordChar = Convert.ToChar(0);
		  _sender.ForeColor = Color.Gray;
    }
	  else
    {
		  _sender.ForeColor = Color.Black;
	  } 
  }

	  private void SetTextAppearance(Object sender)
  {
		//--- Varied length variables ---
		TextEdit _sender   = (TextEdit)sender;

		//--- Fixed length variables ---
    bool secondcondition = false;

		try
    {
			secondcondition = _sender.EditValue.ToString().Length == 0;
    }
		catch (Exception ex)
    {
			secondcondition = true;
		}

		if ((_sender.EditValue == null) || (secondcondition))
    {
			_sender.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
			_sender.EditValue = null;
			_sender.Properties.PasswordChar = Convert.ToChar(0);
			_sender.ForeColor = Color.Gray;
    }
		else
    {
			_sender.Font = new System.Drawing.Font("Wingdings", 8, FontStyle.Regular);
			_sender.ForeColor = Color.Black;
			_sender.Properties.PasswordChar = Convert.ToChar("l");
		}
	}

    private void txtPassword_EditValueChanged(object sender, EventArgs e)
  {
    SetTextAppearance(sender);
  }

    private void txtUsername_KeyDown(object sender, KeyEventArgs e)
  {
    if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Down)) txtPassword.Focus();
  }

    private void txtPassword_KeyDown(object sender, KeyEventArgs e)
  {
    switch (e.KeyCode)
    {
       case Keys.Up : 
          txtUsername.Focus();
          break;
       case Keys.Down:
          btOK.Focus();
          break;
        case Keys.Enter :
          btOK_Click(sender,e);
          break;
    }
  }

    private void btCancel_Click(object sender, EventArgs e)
  {
    //this.DialogResult = DialogResult.Cancel;
    //this.Close();
    Environment.Exit(0);
  }

    private void btOK_Click(object sender, EventArgs e)
  {
    if (CheckValidPassword())
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
      cls_Global_class.GB_UserCode = txtUsername.Text;
      cls_Global_class.GB_Password = txtPassword.Text;

      string Xc = "11111";
      ulong Xsum = cls_Global_class.BitSum(Xc);

      

    }
  }

    private bool CheckValidPassword() 
  {
	  //--- Varied length variables ---
	  string _clearusername  = "";
	  string _clearpassword  = "";

	  //--- Fix length variables ---
	  bool _ret = false;

	  _clearusername = txtUsername.Text;
	  _clearpassword = txtPassword.Text;

	  try
    {
		  _ret =Class_Cryptography.CredentialsVerification(_clearusername, _clearpassword);
    }
	  catch (Exception ex)
    {
      XtraMessageBox.Show(ex.Message);
      _ret = false;
	  }
	  return _ret;
  }

    private void frm_SPWenter_Load(object sender, EventArgs e)
    {

    }

    private void frm_SPWenter_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
      {
        Environment.Exit(0);
      }
    }

    private void frm_SPWenter_FormClosing(object sender, FormClosingEventArgs e)
    {

    }
  }
}