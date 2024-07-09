namespace VideoLooper
{
    partial class frmOutputFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutputFormat));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnOK2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnNewProfile = new System.Windows.Forms.Button();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkCopyMetadata = new System.Windows.Forms.CheckBox();
            this.chkDeinterlace = new System.Windows.Forms.CheckBox();
            this.chkTwoPass = new System.Windows.Forms.CheckBox();
            this.cmbVideoAspectRatio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVideoSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVideoFrameRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVideoBitrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkMute = new System.Windows.Forms.CheckBox();
            this.chkNormalize = new System.Windows.Forms.CheckBox();
            this.cmbVolume = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAudioChannels = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSampleRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAudioBitrate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtFFMpeg2ndPass = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFFMpeg1stPass = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFFMpegAddParameters = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lvProfile = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCategory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFillInputValues = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDeleteProfile
            // 
            resources.ApplyResources(this.btnDeleteProfile, "btnDeleteProfile");
            this.btnDeleteProfile.Image = global::VideoLooper.Properties.Resources.delete;
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // btnCancel2
            // 
            resources.ApplyResources(this.btnCancel2, "btnCancel2");
            this.btnCancel2.Image = global::VideoLooper.Properties.Resources.exit;
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK2
            // 
            resources.ApplyResources(this.btnOK2, "btnOK2");
            this.btnOK2.Image = global::VideoLooper.Properties.Resources.check;
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.UseVisualStyleBackColor = true;
            this.btnOK2.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Name = "label12";
            // 
            // btnNewProfile
            // 
            resources.ApplyResources(this.btnNewProfile, "btnNewProfile");
            this.btnNewProfile.Image = global::VideoLooper.Properties.Resources.document_new;
            this.btnNewProfile.Name = "btnNewProfile";
            this.btnNewProfile.UseVisualStyleBackColor = true;
            this.btnNewProfile.Click += new System.EventHandler(this.btnNewProfile_Click);
            // 
            // btnEditProfile
            // 
            resources.ApplyResources(this.btnEditProfile, "btnEditProfile");
            this.btnEditProfile.Image = global::VideoLooper.Properties.Resources.edit;
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.UseVisualStyleBackColor = true;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkCopyMetadata);
            this.tabPage1.Controls.Add(this.chkDeinterlace);
            this.tabPage1.Controls.Add(this.chkTwoPass);
            this.tabPage1.Controls.Add(this.cmbVideoAspectRatio);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbVideoSize);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmbVideoFrameRate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbVideoBitrate);
            this.tabPage1.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkCopyMetadata
            // 
            resources.ApplyResources(this.chkCopyMetadata, "chkCopyMetadata");
            this.chkCopyMetadata.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkCopyMetadata.Name = "chkCopyMetadata";
            this.chkCopyMetadata.UseVisualStyleBackColor = true;
            // 
            // chkDeinterlace
            // 
            resources.ApplyResources(this.chkDeinterlace, "chkDeinterlace");
            this.chkDeinterlace.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkDeinterlace.Name = "chkDeinterlace";
            this.chkDeinterlace.UseVisualStyleBackColor = true;
            // 
            // chkTwoPass
            // 
            resources.ApplyResources(this.chkTwoPass, "chkTwoPass");
            this.chkTwoPass.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkTwoPass.Name = "chkTwoPass";
            this.chkTwoPass.UseVisualStyleBackColor = true;
            // 
            // cmbVideoAspectRatio
            // 
            this.cmbVideoAspectRatio.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVideoAspectRatio, "cmbVideoAspectRatio");
            this.cmbVideoAspectRatio.Name = "cmbVideoAspectRatio";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // cmbVideoSize
            // 
            this.cmbVideoSize.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVideoSize, "cmbVideoSize");
            this.cmbVideoSize.Name = "cmbVideoSize";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // cmbVideoFrameRate
            // 
            this.cmbVideoFrameRate.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVideoFrameRate, "cmbVideoFrameRate");
            this.cmbVideoFrameRate.Name = "cmbVideoFrameRate";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // cmbVideoBitrate
            // 
            this.cmbVideoBitrate.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVideoBitrate, "cmbVideoBitrate");
            this.cmbVideoBitrate.Name = "cmbVideoBitrate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkMute);
            this.tabPage2.Controls.Add(this.chkNormalize);
            this.tabPage2.Controls.Add(this.cmbVolume);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cmbAudioChannels);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cmbSampleRate);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cmbAudioBitrate);
            this.tabPage2.Controls.Add(this.label5);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkMute
            // 
            resources.ApplyResources(this.chkMute, "chkMute");
            this.chkMute.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkMute.Name = "chkMute";
            this.chkMute.UseVisualStyleBackColor = true;
            // 
            // chkNormalize
            // 
            resources.ApplyResources(this.chkNormalize, "chkNormalize");
            this.chkNormalize.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkNormalize.Name = "chkNormalize";
            this.chkNormalize.UseVisualStyleBackColor = true;
            // 
            // cmbVolume
            // 
            this.cmbVolume.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVolume, "cmbVolume");
            this.cmbVolume.Name = "cmbVolume";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Name = "label8";
            // 
            // cmbAudioChannels
            // 
            this.cmbAudioChannels.FormattingEnabled = true;
            resources.ApplyResources(this.cmbAudioChannels, "cmbAudioChannels");
            this.cmbAudioChannels.Name = "cmbAudioChannels";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Name = "label7";
            // 
            // cmbSampleRate
            // 
            this.cmbSampleRate.FormattingEnabled = true;
            resources.ApplyResources(this.cmbSampleRate, "cmbSampleRate");
            this.cmbSampleRate.Name = "cmbSampleRate";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Name = "label6";
            // 
            // cmbAudioBitrate
            // 
            this.cmbAudioBitrate.FormattingEnabled = true;
            resources.ApplyResources(this.cmbAudioBitrate, "cmbAudioBitrate");
            this.cmbAudioBitrate.Name = "cmbAudioBitrate";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtFFMpeg2ndPass);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.txtFFMpeg1stPass);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.txtFFMpegAddParameters);
            this.tabPage3.Controls.Add(this.label9);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtFFMpeg2ndPass
            // 
            resources.ApplyResources(this.txtFFMpeg2ndPass, "txtFFMpeg2ndPass");
            this.txtFFMpeg2ndPass.Name = "txtFFMpeg2ndPass";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Name = "label11";
            // 
            // txtFFMpeg1stPass
            // 
            resources.ApplyResources(this.txtFFMpeg1stPass, "txtFFMpeg1stPass");
            this.txtFFMpeg1stPass.Name = "txtFFMpeg1stPass";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Name = "label10";
            // 
            // txtFFMpegAddParameters
            // 
            resources.ApplyResources(this.txtFFMpegAddParameters, "txtFFMpegAddParameters");
            this.txtFFMpegAddParameters.Name = "txtFFMpegAddParameters";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Name = "label9";
            // 
            // lvProfile
            // 
            resources.ApplyResources(this.lvProfile, "lvProfile");
            this.lvProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvProfile.FullRowSelect = true;
            this.lvProfile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvProfile.HideSelection = false;
            this.lvProfile.MultiSelect = false;
            this.lvProfile.Name = "lvProfile";
            this.lvProfile.ShowGroups = false;
            this.lvProfile.UseCompatibleStateImageBehavior = false;
            this.lvProfile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // lvCategory
            // 
            resources.ApplyResources(this.lvCategory, "lvCategory");
            this.lvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvCategory.FullRowSelect = true;
            this.lvCategory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCategory.HideSelection = false;
            this.lvCategory.MultiSelect = false;
            this.lvCategory.Name = "lvCategory";
            this.lvCategory.ShowGroups = false;
            this.lvCategory.UseCompatibleStateImageBehavior = false;
            this.lvCategory.View = System.Windows.Forms.View.Details;
            this.lvCategory.SelectedIndexChanged += new System.EventHandler(this.lvCategory_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Image = global::VideoLooper.Properties.Resources.brush2;
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFillInputValues
            // 
            resources.ApplyResources(this.btnFillInputValues, "btnFillInputValues");
            this.btnFillInputValues.Name = "btnFillInputValues";
            this.btnFillInputValues.UseVisualStyleBackColor = true;
            this.btnFillInputValues.Click += new System.EventHandler(this.btnFillInputValues_Click);
            // 
            // frmOutputFormat
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnFillInputValues);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDeleteProfile);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.btnOK2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnNewProfile);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lvProfile);
            this.Controls.Add(this.lvCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmOutputFormat";
            this.Load += new System.EventHandler(this.frmOutputFormat_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCategory;
        private System.Windows.Forms.ListView lvProfile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmbVideoAspectRatio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVideoSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVideoFrameRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVideoBitrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbVolume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbAudioChannels;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSampleRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAudioBitrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox txtFFMpeg2ndPass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox txtFFMpeg1stPass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtFFMpegAddParameters;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.Button btnNewProfile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button btnOK2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox chkDeinterlace;
        private System.Windows.Forms.CheckBox chkTwoPass;
        private System.Windows.Forms.CheckBox chkNormalize;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.CheckBox chkMute;
        private System.Windows.Forms.CheckBox chkCopyMetadata;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFillInputValues;
    }
}
