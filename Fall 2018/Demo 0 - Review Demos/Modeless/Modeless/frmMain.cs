using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modeless
{
    public partial class frmMain : Form
    {
        private frmEditText fET = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Ignore != MessageBox.Show("Cancel What?", "Cancel?", MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Exclamation))
                MessageBox.Show("Get Bent");
        }

        private void cbShowDial_CheckedChanged(object sender, EventArgs e)
        {
            if (fET == null) fET = new frmEditText();
            {
                fET.callbackDialogClosing = this.CallBackDialogClosed;
                fET.callbackStringChanged = this.CallBackTextChanged;
            }
            
            if (cbShowDial.Checked) fET.Show();
            else fET.Hide();
        }

        //Callback to change the text
        public void CallBackTextChanged(string str)
        {
            lblText.Text = str;
        }

        //Callback for the edit box closing
        public void CallBackDialogClosed()
        {
            cbShowDial.Checked = false;
        }
    }
}
