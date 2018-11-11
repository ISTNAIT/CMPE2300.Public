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
            this.lbData = new System.Windows.Forms.ListBox();
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fbdDialog
            // 
            this.fbdDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdDialog.SelectedPath = System.Environment.SpecialFolder.UserProfile.ToString();
            // 
            // lbData
            // 
            this.lbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbData.FormattingEnabled = true;
            this.lbData.Location = new System.Drawing.Point(12, 12);
            this.lbData.MultiColumn = true;
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(796, 537);
            this.lbData.TabIndex = 0;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 590);
            this.Controls.Add(this.btnChooseDirectory);
            this.Controls.Add(this.lbData);
            this.Name = "frmMain";
            this.Text = "Demo 9 - Dictionary";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdDialog;
        private System.Windows.Forms.ListBox lbData;
        private System.Windows.Forms.Button btnChooseDirectory;
    }
}

