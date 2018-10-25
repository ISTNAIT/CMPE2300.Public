namespace ICA_8___Intersect
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnDuplicates = new System.Windows.Forms.Button();
            this.btnClips = new System.Windows.Forms.Button();
            this.gbColour = new System.Windows.Forms.GroupBox();
            this.rbSalmon = new System.Windows.Forms.RadioButton();
            this.rbPurple = new System.Windows.Forms.RadioButton();
            this.btnIntersect = new System.Windows.Forms.Button();
            this.btnUnion = new System.Windows.Forms.Button();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.tbTolerance = new System.Windows.Forms.TrackBar();
            this.gbColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDuplicates
            // 
            this.btnDuplicates.Location = new System.Drawing.Point(12, 12);
            this.btnDuplicates.Name = "btnDuplicates";
            this.btnDuplicates.Size = new System.Drawing.Size(202, 23);
            this.btnDuplicates.TabIndex = 0;
            this.btnDuplicates.Text = "Distinct Duplicates!";
            this.btnDuplicates.UseVisualStyleBackColor = true;
            this.btnDuplicates.Click += new System.EventHandler(this.btnDuplicates_Click);
            // 
            // btnClips
            // 
            this.btnClips.Location = new System.Drawing.Point(12, 41);
            this.btnClips.Name = "btnClips";
            this.btnClips.Size = new System.Drawing.Size(202, 23);
            this.btnClips.TabIndex = 1;
            this.btnClips.Text = "Remove Clips!";
            this.btnClips.UseVisualStyleBackColor = true;
            this.btnClips.Click += new System.EventHandler(this.btnClips_Click);
            // 
            // gbColour
            // 
            this.gbColour.Controls.Add(this.rbSalmon);
            this.gbColour.Controls.Add(this.rbPurple);
            this.gbColour.Location = new System.Drawing.Point(12, 70);
            this.gbColour.Name = "gbColour";
            this.gbColour.Size = new System.Drawing.Size(202, 43);
            this.gbColour.TabIndex = 2;
            this.gbColour.TabStop = false;
            this.gbColour.Text = "Ball List Colour";
            // 
            // rbSalmon
            // 
            this.rbSalmon.AutoSize = true;
            this.rbSalmon.ForeColor = System.Drawing.Color.DarkSalmon;
            this.rbSalmon.Location = new System.Drawing.Point(117, 19);
            this.rbSalmon.Name = "rbSalmon";
            this.rbSalmon.Size = new System.Drawing.Size(79, 17);
            this.rbSalmon.TabIndex = 1;
            this.rbSalmon.TabStop = true;
            this.rbSalmon.Text = "Salmon List";
            this.rbSalmon.UseVisualStyleBackColor = true;
            // 
            // rbPurple
            // 
            this.rbPurple.AutoSize = true;
            this.rbPurple.ForeColor = System.Drawing.Color.Purple;
            this.rbPurple.Location = new System.Drawing.Point(6, 19);
            this.rbPurple.Name = "rbPurple";
            this.rbPurple.Size = new System.Drawing.Size(74, 17);
            this.rbPurple.TabIndex = 0;
            this.rbPurple.Text = "Purple List";
            this.rbPurple.UseVisualStyleBackColor = true;
            // 
            // btnIntersect
            // 
            this.btnIntersect.Location = new System.Drawing.Point(12, 148);
            this.btnIntersect.Name = "btnIntersect";
            this.btnIntersect.Size = new System.Drawing.Size(202, 23);
            this.btnIntersect.TabIndex = 4;
            this.btnIntersect.Text = "Show Ball Intersect!";
            this.btnIntersect.UseVisualStyleBackColor = true;
            this.btnIntersect.Click += new System.EventHandler(this.btnIntersect_Click);
            // 
            // btnUnion
            // 
            this.btnUnion.Location = new System.Drawing.Point(12, 119);
            this.btnUnion.Name = "btnUnion";
            this.btnUnion.Size = new System.Drawing.Size(202, 23);
            this.btnUnion.TabIndex = 3;
            this.btnUnion.Text = "Show Ball Union!";
            this.btnUnion.UseVisualStyleBackColor = true;
            this.btnUnion.Click += new System.EventHandler(this.btnUnion_Click);
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 20;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // tbTolerance
            // 
            this.tbTolerance.Location = new System.Drawing.Point(12, 178);
            this.tbTolerance.Name = "tbTolerance";
            this.tbTolerance.Size = new System.Drawing.Size(202, 45);
            this.tbTolerance.TabIndex = 5;
            this.tbTolerance.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbTolerance.Scroll += new System.EventHandler(this.tbTolerance_Scroll);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 216);
            this.Controls.Add(this.tbTolerance);
            this.Controls.Add(this.btnIntersect);
            this.Controls.Add(this.btnUnion);
            this.Controls.Add(this.gbColour);
            this.Controls.Add(this.btnClips);
            this.Controls.Add(this.btnDuplicates);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Intersect";
            this.Load += new System.EventHandler(this.Main_Load);
            this.gbColour.ResumeLayout(false);
            this.gbColour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTolerance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDuplicates;
        private System.Windows.Forms.Button btnClips;
        private System.Windows.Forms.GroupBox gbColour;
        private System.Windows.Forms.RadioButton rbSalmon;
        private System.Windows.Forms.RadioButton rbPurple;
        private System.Windows.Forms.Button btnIntersect;
        private System.Windows.Forms.Button btnUnion;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.TrackBar tbTolerance;
    }
}

