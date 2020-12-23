namespace IMDbLinkDecoder
{
    partial class Form1
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
            this.bStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lSeparator = new System.Windows.Forms.Label();
            this.tbSeparator = new System.Windows.Forms.TextBox();
            this.cbInputLink = new System.Windows.Forms.CheckBox();
            this.cbTMDb = new System.Windows.Forms.CheckBox();
            this.cbDate = new System.Windows.Forms.CheckBox();
            this.cbTitle = new System.Windows.Forms.CheckBox();
            this.cbCounter = new System.Windows.Forms.CheckBox();
            this.lProgress = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbIn = new System.Windows.Forms.TextBox();
            this.tbOut = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 12);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.Start_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lSeparator);
            this.panel1.Controls.Add(this.tbSeparator);
            this.panel1.Controls.Add(this.cbInputLink);
            this.panel1.Controls.Add(this.cbTMDb);
            this.panel1.Controls.Add(this.cbDate);
            this.panel1.Controls.Add(this.cbTitle);
            this.panel1.Controls.Add(this.cbCounter);
            this.panel1.Controls.Add(this.lProgress);
            this.panel1.Controls.Add(this.bStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 1;
            // 
            // lSeparator
            // 
            this.lSeparator.AutoSize = true;
            this.lSeparator.Location = new System.Drawing.Point(435, 17);
            this.lSeparator.Name = "lSeparator";
            this.lSeparator.Size = new System.Drawing.Size(56, 13);
            this.lSeparator.TabIndex = 8;
            this.lSeparator.Text = "Separator:";
            // 
            // tbSeparator
            // 
            this.tbSeparator.Location = new System.Drawing.Point(497, 14);
            this.tbSeparator.Name = "tbSeparator";
            this.tbSeparator.Size = new System.Drawing.Size(100, 20);
            this.tbSeparator.TabIndex = 7;
            this.tbSeparator.Text = " ";
            // 
            // cbInputLink
            // 
            this.cbInputLink.AutoSize = true;
            this.cbInputLink.Checked = true;
            this.cbInputLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInputLink.Location = new System.Drawing.Point(360, 16);
            this.cbInputLink.Name = "cbInputLink";
            this.cbInputLink.Size = new System.Drawing.Size(69, 17);
            this.cbInputLink.TabIndex = 6;
            this.cbInputLink.Text = "Input link";
            this.cbInputLink.UseVisualStyleBackColor = true;
            // 
            // cbTMDb
            // 
            this.cbTMDb.AutoSize = true;
            this.cbTMDb.Checked = true;
            this.cbTMDb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTMDb.Location = new System.Drawing.Point(269, 16);
            this.cbTMDb.Name = "cbTMDb";
            this.cbTMDb.Size = new System.Drawing.Size(85, 17);
            this.cbTMDb.TabIndex = 5;
            this.cbTMDb.Text = "TMDb rating";
            this.cbTMDb.UseVisualStyleBackColor = true;
            // 
            // cbDate
            // 
            this.cbDate.AutoSize = true;
            this.cbDate.Checked = true;
            this.cbDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDate.Location = new System.Drawing.Point(214, 16);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(49, 17);
            this.cbDate.TabIndex = 4;
            this.cbDate.Text = "Date";
            this.cbDate.UseVisualStyleBackColor = true;
            // 
            // cbTitle
            // 
            this.cbTitle.AutoSize = true;
            this.cbTitle.Checked = true;
            this.cbTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTitle.Location = new System.Drawing.Point(162, 16);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(46, 17);
            this.cbTitle.TabIndex = 3;
            this.cbTitle.Text = "Title";
            this.cbTitle.UseVisualStyleBackColor = true;
            // 
            // cbCounter
            // 
            this.cbCounter.AutoSize = true;
            this.cbCounter.Checked = true;
            this.cbCounter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCounter.Location = new System.Drawing.Point(93, 15);
            this.cbCounter.Name = "cbCounter";
            this.cbCounter.Size = new System.Drawing.Size(63, 17);
            this.cbCounter.TabIndex = 2;
            this.cbCounter.Text = "Counter";
            this.cbCounter.UseVisualStyleBackColor = true;
            // 
            // lProgress
            // 
            this.lProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lProgress.AutoSize = true;
            this.lProgress.Location = new System.Drawing.Point(680, 17);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(48, 13);
            this.lProgress.TabIndex = 1;
            this.lProgress.Text = "Progress";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbIn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbOut);
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 2;
            // 
            // tbIn
            // 
            this.tbIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIn.Location = new System.Drawing.Point(0, 0);
            this.tbIn.Multiline = true;
            this.tbIn.Name = "tbIn";
            this.tbIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbIn.Size = new System.Drawing.Size(266, 404);
            this.tbIn.TabIndex = 0;
            // 
            // tbOut
            // 
            this.tbOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOut.Location = new System.Drawing.Point(0, 0);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ReadOnly = true;
            this.tbOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOut.Size = new System.Drawing.Size(530, 404);
            this.tbOut.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "IMDb Link Decoder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbIn;
        private System.Windows.Forms.TextBox tbOut;
        private System.Windows.Forms.Label lProgress;
        private System.Windows.Forms.CheckBox cbInputLink;
        private System.Windows.Forms.CheckBox cbTMDb;
        private System.Windows.Forms.CheckBox cbDate;
        private System.Windows.Forms.CheckBox cbTitle;
        private System.Windows.Forms.CheckBox cbCounter;
        private System.Windows.Forms.TextBox tbSeparator;
        private System.Windows.Forms.Label lSeparator;
    }
}

