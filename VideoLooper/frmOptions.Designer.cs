namespace VideoLooper
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInsertN = new System.Windows.Forms.Button();
            this.btnInsertDocFilename = new System.Windows.Forms.Button();
            this.btnInsertDate = new System.Windows.Forms.Button();
            this.btnInsertDateTime = new System.Windows.Forms.Button();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.niceLine1 = new VideoLooper.NiceLine();
            this.label2 = new System.Windows.Forms.Label();
            this.rdPNG = new System.Windows.Forms.RadioButton();
            this.rdJPG = new System.Windows.Forms.RadioButton();
            this.rdGIF = new System.Windows.Forms.RadioButton();
            this.rdBMP = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.nudJpegQuality = new System.Windows.Forms.NumericUpDown();
            this.tbJpegQuality = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.nudJpegQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbJpegQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilename
            // 
            resources.ApplyResources(this.txtFilename, "txtFilename");
            this.txtFilename.Name = "txtFilename";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Image = global::VideoLooper.Properties.Resources.check;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Image = global::VideoLooper.Properties.Resources.exit;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInsertN
            // 
            resources.ApplyResources(this.btnInsertN, "btnInsertN");
            this.btnInsertN.Name = "btnInsertN";
            this.btnInsertN.UseVisualStyleBackColor = true;
            this.btnInsertN.Click += new System.EventHandler(this.btnInsertN_Click);
            // 
            // btnInsertDocFilename
            // 
            resources.ApplyResources(this.btnInsertDocFilename, "btnInsertDocFilename");
            this.btnInsertDocFilename.Name = "btnInsertDocFilename";
            this.btnInsertDocFilename.UseVisualStyleBackColor = true;
            this.btnInsertDocFilename.Click += new System.EventHandler(this.btnInsertDocFilename_Click);
            // 
            // btnInsertDate
            // 
            resources.ApplyResources(this.btnInsertDate, "btnInsertDate");
            this.btnInsertDate.Name = "btnInsertDate";
            this.btnInsertDate.UseVisualStyleBackColor = true;
            this.btnInsertDate.Click += new System.EventHandler(this.btnInsertDate_Click);
            // 
            // btnInsertDateTime
            // 
            resources.ApplyResources(this.btnInsertDateTime, "btnInsertDateTime");
            this.btnInsertDateTime.Name = "btnInsertDateTime";
            this.btnInsertDateTime.UseVisualStyleBackColor = true;
            this.btnInsertDateTime.Click += new System.EventHandler(this.btnInsertDateTime_Click);
            // 
            // chkOverwrite
            // 
            resources.ApplyResources(this.chkOverwrite, "chkOverwrite");
            this.chkOverwrite.BackColor = System.Drawing.Color.Transparent;
            this.chkOverwrite.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.UseVisualStyleBackColor = false;
            // 
            // niceLine1
            // 
            this.niceLine1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.niceLine1, "niceLine1");
            this.niceLine1.Name = "niceLine1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // rdPNG
            // 
            resources.ApplyResources(this.rdPNG, "rdPNG");
            this.rdPNG.BackColor = System.Drawing.Color.Transparent;
            this.rdPNG.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdPNG.Name = "rdPNG";
            this.rdPNG.TabStop = true;
            this.rdPNG.UseVisualStyleBackColor = false;
            // 
            // rdJPG
            // 
            resources.ApplyResources(this.rdJPG, "rdJPG");
            this.rdJPG.BackColor = System.Drawing.Color.Transparent;
            this.rdJPG.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdJPG.Name = "rdJPG";
            this.rdJPG.TabStop = true;
            this.rdJPG.UseVisualStyleBackColor = false;
            // 
            // rdGIF
            // 
            resources.ApplyResources(this.rdGIF, "rdGIF");
            this.rdGIF.BackColor = System.Drawing.Color.Transparent;
            this.rdGIF.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdGIF.Name = "rdGIF";
            this.rdGIF.TabStop = true;
            this.rdGIF.UseVisualStyleBackColor = false;
            // 
            // rdBMP
            // 
            resources.ApplyResources(this.rdBMP, "rdBMP");
            this.rdBMP.BackColor = System.Drawing.Color.Transparent;
            this.rdBMP.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdBMP.Name = "rdBMP";
            this.rdBMP.TabStop = true;
            this.rdBMP.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // nudJpegQuality
            // 
            resources.ApplyResources(this.nudJpegQuality, "nudJpegQuality");
            this.nudJpegQuality.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudJpegQuality.Name = "nudJpegQuality";
            this.nudJpegQuality.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudJpegQuality.ValueChanged += new System.EventHandler(this.nudJpegQuality_ValueChanged);
            // 
            // tbJpegQuality
            // 
            resources.ApplyResources(this.tbJpegQuality, "tbJpegQuality");
            this.tbJpegQuality.Maximum = 100;
            this.tbJpegQuality.Minimum = 1;
            this.tbJpegQuality.Name = "tbJpegQuality";
            this.tbJpegQuality.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbJpegQuality.Value = 1;
            this.tbJpegQuality.ValueChanged += new System.EventHandler(this.tbJpegQuality_ValueChanged);
            // 
            // frmOptions
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tbJpegQuality);
            this.Controls.Add(this.nudJpegQuality);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdBMP);
            this.Controls.Add(this.rdGIF);
            this.Controls.Add(this.rdJPG);
            this.Controls.Add(this.rdPNG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.niceLine1);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.btnInsertDateTime);
            this.Controls.Add(this.btnInsertDate);
            this.Controls.Add(this.btnInsertDocFilename);
            this.Controls.Add(this.btnInsertN);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.Load += new System.EventHandler(this.frmOutputFilenamePattern_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudJpegQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbJpegQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInsertN;
        private System.Windows.Forms.Button btnInsertDocFilename;
        private System.Windows.Forms.Button btnInsertDate;
        private System.Windows.Forms.Button btnInsertDateTime;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private NiceLine niceLine1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdPNG;
        private System.Windows.Forms.RadioButton rdJPG;
        private System.Windows.Forms.RadioButton rdGIF;
        private System.Windows.Forms.RadioButton rdBMP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudJpegQuality;
        private System.Windows.Forms.TrackBar tbJpegQuality;
    }
}
