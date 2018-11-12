namespace Demo_9___Dictionary
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fbdDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.lvData = new System.Windows.Forms.ListView();
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDirs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSortExtension = new System.Windows.Forms.Button();
            this.btnRemoveEmpty = new System.Windows.Forms.Button();
            this.btnRemoveHidden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fbdDialog
            // 
            this.fbdDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdDialog.SelectedPath = "C:\\Users\\aja\\Desktop";
            // 
            // btnChooseDirectory
            // 
            this.btnChooseDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChooseDirectory.Location = new System.Drawing.Point(12, 555);
            this.btnChooseDirectory.Name = "btnChooseDirectory";
            this.btnChooseDirectory.Size = new System.Drawing.Size(101, 23);
            this.btnChooseDirectory.TabIndex = 1;
            this.btnChooseDirectory.Text = "Choose Directory";
            this.btnChooseDirectory.UseVisualStyleBackColor = true;
            this.btnChooseDirectory.Click += new System.EventHandler(this.btnChooseDirectory_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(13, 13);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(66, 13);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "Current Path";
            // 
            // lvData
            // 
            this.lvData.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvData.AllowColumnReorder = true;
            this.lvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPath,
            this.chDirs,
            this.chFiles,
            this.chSize});
            this.lvData.HoverSelection = true;
            this.lvData.Location = new System.Drawing.Point(16, 30);
            this.lvData.MultiSelect = false;
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(792, 519);
            this.lvData.TabIndex = 3;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // chPath
            // 
            this.chPath.Text = "Path";
            this.chPath.Width = 571;
            // 
            // chDirs
            // 
            this.chDirs.Text = "Directories";
            this.chDirs.Width = 71;
            // 
            // chFiles
            // 
            this.chFiles.Text = "Files";
            this.chFiles.Width = 70;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            // 
            // btnSortExtension
            // 
            this.btnSortExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSortExtension.Location = new System.Drawing.Point(119, 555);
            this.btnSortExtension.Name = "btnSortExtension";
            this.btnSortExtension.Size = new System.Drawing.Size(101, 23);
            this.btnSortExtension.TabIndex = 4;
            this.btnSortExtension.Text = "Sort";
            this.btnSortExtension.UseVisualStyleBackColor = true;
            this.btnSortExtension.Click += new System.EventHandler(this.btnSortExtension_Click);
            // 
            // btnRemoveEmpty
            // 
            this.btnRemoveEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveEmpty.Location = new System.Drawing.Point(226, 555);
            this.btnRemoveEmpty.Name = "btnRemoveEmpty";
            this.btnRemoveEmpty.Size = new System.Drawing.Size(101, 23);
            this.btnRemoveEmpty.TabIndex = 5;
            this.btnRemoveEmpty.Text = "Remove Empty";
            this.btnRemoveEmpty.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRemoveEmpty.UseVisualStyleBackColor = true;
            this.btnRemoveEmpty.Click += new System.EventHandler(this.btnRemoveEmpty_Click);
            // 
            // btnRemoveHidden
            // 
            this.btnRemoveHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveHidden.Location = new System.Drawing.Point(333, 556);
            this.btnRemoveHidden.Name = "btnRemoveHidden";
            this.btnRemoveHidden.Size = new System.Drawing.Size(101, 23);
            this.btnRemoveHidden.TabIndex = 6;
            this.btnRemoveHidden.Text = "Remove Hidden";
            this.btnRemoveHidden.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRemoveHidden.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveHidden.UseVisualStyleBackColor = true;
            this.btnRemoveHidden.Click += new System.EventHandler(this.btnRemoveHidden_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 590);
            this.Controls.Add(this.btnRemoveHidden);
            this.Controls.Add(this.btnRemoveEmpty);
            this.Controls.Add(this.btnSortExtension);
            this.Controls.Add(this.lvData);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnChooseDirectory);
            this.Name = "frmMain";
            this.Text = "Demo 9 - Dictionary";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdDialog;
        private System.Windows.Forms.Button btnChooseDirectory;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader chPath;
        private System.Windows.Forms.ColumnHeader chDirs;
        private System.Windows.Forms.ColumnHeader chFiles;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.Button btnSortExtension;
        private System.Windows.Forms.Button btnRemoveEmpty;
        private System.Windows.Forms.Button btnRemoveHidden;
    }
}

