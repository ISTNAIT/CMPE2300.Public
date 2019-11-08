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
using aja; //Extension methods

namespace Demo_9___Dictionary
{
    public partial class frmMain : Form
    {
        private string directoryPath = "";
        public String DirectoryPath
        {
            get => directoryPath;
            set
            {
                lvData.Items.Clear();
                lvData.Enabled = false;
                btnChooseDirectory.Enabled = false;
                lblPath.Text = "Depending on the directory, this may take a very long time. Get coffee.";
                Application.DoEvents();
                directoryPath = value;
                DirectoryDict = new Dictionary<DirectoryInfo, DirData>();
                RecurseDirectory(DirectoryPath);
                lvData.Enabled = true;
                lblPath.Text = DirectoryPath.ToString();
                Application.DoEvents();
                Populate();
                btnChooseDirectory.Enabled = true;
            }
        }

        public Dictionary<DirectoryInfo, DirData> DirectoryDict { get; private set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            DirectoryPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            fbdDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            fbdDialog.SelectedPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Desktop);
            DialogResult dr = fbdDialog.ShowDialog();
            
            switch(dr)
            {
                case DialogResult.OK:
                    DirectoryPath = fbdDialog.SelectedPath;
                    break;
                default:
                    //Do nothing
                    break;
            }
        }

        private void RecurseDirectory(string directory)
        {
            //Create a dictionary of the passed directory and all of its children
            //(recursive).  A bit contrived so that we can play with some things.

            //First, add the current directory
            DirectoryDict.Add(new DirectoryInfo(directory), new DirData(directory));

            //Now grab all my child directories and recursively call this method 
            //using some fun syntax
            try
            { //Don't bounce off of permissions issues
                List<string> subdirs = System.IO.Directory.EnumerateDirectories(directory).Distinct().ToList();
                subdirs.ForEach(s => RecurseDirectory(s));
            }
            catch (UnauthorizedAccessException) { return;  } //Not allowed to descend any further.

            //Obfuscated one liner version of the above! (Probably bad practice, but fun!)
            //System.IO.Directory.EnumerateDirectories(directory).Distinct().ToList()
                //.ForEach(s => RecurseDirectory(s));
        }

        //Display the current contents of the dictionary to the listview
        private void Populate()
        {  
            //FIXME: Currently hacked to only take 2000 items.
            //ListView not optimized for very large sets (need some kind of cursor/dataview).
            lvData.Items.Clear();
            //Use my groovy extension method (see AJAExtension.cs) to simplify this
            foreach (KeyValuePair<DirectoryInfo, DirData> kvp in DirectoryDict.Take(2000))
                lvData.Items.Add(kvp.LVIFromKVP());
            Application.DoEvents();
        }

        private void btnSortExtension_Click(object sender, EventArgs e)
        {
            DirectoryDict = DirectoryDict.OrderByDescending(kvp=>kvp.Value.StorageSize).ThenBy(kvp=>kvp.Key.FullName)
                .ToDictionary(kvp => kvp.Key, kvp=> kvp.Value);
            Populate();
        }

        private void btnRemoveEmpty_Click(object sender, EventArgs e)
        {
            DirectoryDict = DirectoryDict
                .Where(kvp => kvp.Value.StorageSize > 0)
                .ToDictionary(kvp=>kvp.Key, kvp=>kvp.Value);
            Populate();
        }

        private void btnRemoveHidden_Click(object sender, EventArgs e)
        {
            DirectoryDict = DirectoryDict
                .Where(kvp => ((kvp.Key.Attributes & FileAttributes.Hidden)==0 //Winderz visible
                && (kvp.Key.Name.Length > 0 && kvp.Key.Name[0] != '.'))) //Unix visible
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Populate();
        }

       
    }
}
