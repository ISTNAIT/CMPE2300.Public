using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1___Simple_Class
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string species = Person.Species;
            Person p = new Person();
            tbPeople.Text += p;
            tbPeople.Text += "\n";
            p.SetName("J. Random", "User");
            tbPeople.Text += p;
            tbPeople.Text += "\n";
            p = new Person("Bob", "Dobbs", Gender.Indeterminate, 100047);
            tbPeople.Text += p;
            tbPeople.Text += "\r";
        }

        
    }
}
