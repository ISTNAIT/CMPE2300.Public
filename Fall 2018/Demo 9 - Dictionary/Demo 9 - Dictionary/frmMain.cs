using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Demo_9___Dictionary
{
    public partial class frmMain : Form
    {
        public String DirectoryPath { get; set; }
        public DirData DirectoryData { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DirectoryPath = 
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            DirectoryData = new DirData(DirectoryPath);
        }

        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdDialog.ShowDialog();
            switch(dr)
            {
                case DialogResult.OK:
                    DirectoryPath = fbdDialog.SelectedPath;
                    DirectoryData = new DirData(DirectoryPath);
                    break;
                default:
                    //Do nothing
                    break;
            }

        }

    }
}
