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
    public delegate void delVoidString(string s);
    public delegate void delVoidVoid();
    public partial class frmEditText : Form
    {
        //delegate properties
        public delVoidString callbackStringChanged;
        public delVoidVoid callbackDialogClosing;
        
        public frmEditText()
        {
            InitializeComponent();
        }

        //Trap closing event
        private void frmEditText_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Let the other form know so it can uncheck the text box
            callbackDialogClosing();
            //Don't actually close...
            e.Cancel = true;
            //Just hide
            this.Visible = false;
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            //Tell our parent form that the text is new
            callbackStringChanged(tbText.Text);
        }
    }
}
