namespace BounceBall
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.UI_Tim_Main = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_Tim_Main
            // 
            this.UI_Tim_Main.Enabled = true;
            this.UI_Tim_Main.Interval = 20;
            this.UI_Tim_Main.Tick += new System.EventHandler(this.UI_Tim_Main_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 170);
            this.Name = "Form1";
            this.Text = "Bounce Ball";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UI_Tim_Main;
    }
}

