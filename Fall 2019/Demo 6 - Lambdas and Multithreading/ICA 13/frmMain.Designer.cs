namespace ThreadyBalls
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbSize = new System.Windows.Forms.TrackBar();
            this.lblBallSize = new System.Windows.Forms.Label();
            this.lblThreads = new System.Windows.Forms.Label();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.lblNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(20, 20);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(20, 98);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 35);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbSize
            // 
            this.tbSize.LargeChange = 20;
            this.tbSize.Location = new System.Drawing.Point(177, 20);
            this.tbSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSize.Maximum = 100;
            this.tbSize.Minimum = 10;
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(402, 69);
            this.tbSize.SmallChange = 10;
            this.tbSize.TabIndex = 2;
            this.tbSize.Value = 10;
            // 
            // lblBallSize
            // 
            this.lblBallSize.AutoSize = true;
            this.lblBallSize.Location = new System.Drawing.Point(351, 69);
            this.lblBallSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBallSize.Name = "lblBallSize";
            this.lblBallSize.Size = new System.Drawing.Size(70, 20);
            this.lblBallSize.TabIndex = 3;
            this.lblBallSize.Text = "Ball Size";
            // 
            // lblThreads
            // 
            this.lblThreads.AutoSize = true;
            this.lblThreads.Location = new System.Drawing.Point(192, 109);
            this.lblThreads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(84, 20);
            this.lblThreads.TabIndex = 4;
            this.lblThreads.Text = "Threads: 0";
            // 
            // tmrTimer
            // 
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // lblNote
            // 
            this.lblNote.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblNote.Location = new System.Drawing.Point(122, 138);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(457, 49);
            this.lblNote.TabIndex = 5;
            this.lblNote.Text = "This is a version of review demo \"ThreadyBalls\" that replaces the delegate infras" +
    "tructue with lambdas.\r\n";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 196);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblThreads);
            this.Controls.Add(this.lblBallSize);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "ThreadyBalls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TrackBar tbSize;
        private System.Windows.Forms.Label lblBallSize;
        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.Label lblNote;
    }
}

