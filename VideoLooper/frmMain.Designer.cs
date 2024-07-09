namespace VideoLooper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbOutputDir = new System.Windows.Forms.ComboBox();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.cmsFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFullFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbExecute = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.whenFinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.useFFMPEG64bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useFFMPEG32bitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyEXIFInformationFromSourceVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepCreationDateFromSourceVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepLastModificationDateFromSourceVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showMessageOnSuccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languages2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadSoftwareToolStripMenuItem = new com.softpcapps.download_software.DownloadSoftwareToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pleaseDonateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiHelpFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwareYoutubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbVideoFile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVideoVolume = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBackgroundFile = new System.Windows.Forms.ComboBox();
            this.cmbBackgroundVolume = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowseVideoFile = new System.Windows.Forms.Button();
            this.btnBrowseBackgroundFile = new System.Windows.Forms.Button();
            this.chkMute = new System.Windows.Forms.CheckBox();
            this.tudDuration = new VideoLooper.TimeUpDownControl();
            this.rdTimeDuration = new System.Windows.Forms.RadioButton();
            this.rdLoopFitBackgroundDuration = new System.Windows.Forms.RadioButton();
            this.rdLoopNumberOfTimes = new System.Windows.Forms.RadioButton();
            this.nudLoopNumberOfTimes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilenamePattern = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.cmsFiles.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoopNumberOfTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 40000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 30000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbOutputDir);
            this.groupBox1.Controls.Add(this.btnChangeFolder);
            this.groupBox1.Controls.Add(this.btnOpenFolder);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cmbOutputDir
            // 
            resources.ApplyResources(this.cmbOutputDir, "cmbOutputDir");
            this.cmbOutputDir.FormattingEnabled = true;
            this.cmbOutputDir.Name = "cmbOutputDir";
            this.cmbOutputDir.SelectedIndexChanged += new System.EventHandler(this.cmbOutputDir_SelectedIndexChanged);
            // 
            // btnChangeFolder
            // 
            resources.ApplyResources(this.btnChangeFolder, "btnChangeFolder");
            this.btnChangeFolder.ForeColor = System.Drawing.Color.Black;
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // btnOpenFolder
            // 
            resources.ApplyResources(this.btnOpenFolder, "btnOpenFolder");
            this.btnOpenFolder.ForeColor = System.Drawing.Color.Black;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // cmsFiles
            // 
            this.cmsFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.copyFullFilePathToolStripMenuItem});
            this.cmsFiles.Name = "cmsFiles";
            resources.ApplyResources(this.cmsFiles, "cmsFiles");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.flash;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.folder;
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            // 
            // copyFullFilePathToolStripMenuItem
            // 
            this.copyFullFilePathToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.copy;
            this.copyFullFilePathToolStripMenuItem.Name = "copyFullFilePathToolStripMenuItem";
            resources.ApplyResources(this.copyFullFilePathToolStripMenuItem, "copyFullFilePathToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebsiteToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.earth;
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Name = "visit4dotsSoftwareWebsiteToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebsiteToolStripMenuItem, "visit4dotsSoftwareWebsiteToolStripMenuItem");
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebsiteToolStripMenuItem_Click);
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.twitter_24;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionToolStripMenuItem, "checkForNewVersionToolStripMenuItem");
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // tsbExecute
            // 
            resources.ApplyResources(this.tsbExecute, "tsbExecute");
            this.tsbExecute.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbExecute.Image = global::VideoLooper.Properties.Resources.flash1;
            this.tsbExecute.Name = "tsbExecute";
            this.tsbExecute.Click += new System.EventHandler(this.tsbExecute_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExecute});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.downloadSoftwareToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.exit1;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whenFinishedToolStripMenuItem,
            this.toolStripMenuItem3,
            this.useFFMPEG64bitToolStripMenuItem,
            this.useFFMPEG32bitToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyEXIFInformationFromSourceVideoToolStripMenuItem,
            this.keepCreationDateFromSourceVideoToolStripMenuItem,
            this.keepLastModificationDateFromSourceVideoToolStripMenuItem,
            this.toolStripSeparator2,
            this.showMessageOnSuccessToolStripMenuItem,
            this.preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            resources.ApplyResources(this.optionsToolStripMenuItem1, "optionsToolStripMenuItem1");
            // 
            // whenFinishedToolStripMenuItem
            // 
            this.whenFinishedToolStripMenuItem.Name = "whenFinishedToolStripMenuItem";
            resources.ApplyResources(this.whenFinishedToolStripMenuItem, "whenFinishedToolStripMenuItem");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // useFFMPEG64bitToolStripMenuItem
            // 
            this.useFFMPEG64bitToolStripMenuItem.CheckOnClick = true;
            this.useFFMPEG64bitToolStripMenuItem.Name = "useFFMPEG64bitToolStripMenuItem";
            resources.ApplyResources(this.useFFMPEG64bitToolStripMenuItem, "useFFMPEG64bitToolStripMenuItem");
            this.useFFMPEG64bitToolStripMenuItem.Click += new System.EventHandler(this.useFFMPEG64bitToolStripMenuItem_Click);
            // 
            // useFFMPEG32bitToolStripMenuItem
            // 
            this.useFFMPEG32bitToolStripMenuItem.CheckOnClick = true;
            this.useFFMPEG32bitToolStripMenuItem.Name = "useFFMPEG32bitToolStripMenuItem";
            resources.ApplyResources(this.useFFMPEG32bitToolStripMenuItem, "useFFMPEG32bitToolStripMenuItem");
            this.useFFMPEG32bitToolStripMenuItem.Click += new System.EventHandler(this.useFFMPEG32bitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // copyEXIFInformationFromSourceVideoToolStripMenuItem
            // 
            this.copyEXIFInformationFromSourceVideoToolStripMenuItem.CheckOnClick = true;
            this.copyEXIFInformationFromSourceVideoToolStripMenuItem.Name = "copyEXIFInformationFromSourceVideoToolStripMenuItem";
            resources.ApplyResources(this.copyEXIFInformationFromSourceVideoToolStripMenuItem, "copyEXIFInformationFromSourceVideoToolStripMenuItem");
            this.copyEXIFInformationFromSourceVideoToolStripMenuItem.Click += new System.EventHandler(this.copyEXIFInformationFromSourceVideoToolStripMenuItem_Click);
            // 
            // keepCreationDateFromSourceVideoToolStripMenuItem
            // 
            this.keepCreationDateFromSourceVideoToolStripMenuItem.CheckOnClick = true;
            this.keepCreationDateFromSourceVideoToolStripMenuItem.Name = "keepCreationDateFromSourceVideoToolStripMenuItem";
            resources.ApplyResources(this.keepCreationDateFromSourceVideoToolStripMenuItem, "keepCreationDateFromSourceVideoToolStripMenuItem");
            this.keepCreationDateFromSourceVideoToolStripMenuItem.Click += new System.EventHandler(this.keepCreationDateFromSourceVideoToolStripMenuItem_Click);
            // 
            // keepLastModificationDateFromSourceVideoToolStripMenuItem
            // 
            this.keepLastModificationDateFromSourceVideoToolStripMenuItem.CheckOnClick = true;
            this.keepLastModificationDateFromSourceVideoToolStripMenuItem.Name = "keepLastModificationDateFromSourceVideoToolStripMenuItem";
            resources.ApplyResources(this.keepLastModificationDateFromSourceVideoToolStripMenuItem, "keepLastModificationDateFromSourceVideoToolStripMenuItem");
            this.keepLastModificationDateFromSourceVideoToolStripMenuItem.Click += new System.EventHandler(this.keepLastModificationDateFromSourceVideoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // showMessageOnSuccessToolStripMenuItem
            // 
            this.showMessageOnSuccessToolStripMenuItem.CheckOnClick = true;
            this.showMessageOnSuccessToolStripMenuItem.Name = "showMessageOnSuccessToolStripMenuItem";
            resources.ApplyResources(this.showMessageOnSuccessToolStripMenuItem, "showMessageOnSuccessToolStripMenuItem");
            this.showMessageOnSuccessToolStripMenuItem.Click += new System.EventHandler(this.showMessageOnSuccessToolStripMenuItem_Click);
            // 
            // preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem
            // 
            this.preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem.Name = "preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem";
            resources.ApplyResources(this.preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem, "preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem");
            this.preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem.Click += new System.EventHandler(this.preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractImagesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // extractImagesToolStripMenuItem
            // 
            this.extractImagesToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.flash;
            this.extractImagesToolStripMenuItem.Name = "extractImagesToolStripMenuItem";
            resources.ApplyResources(this.extractImagesToolStripMenuItem, "extractImagesToolStripMenuItem");
            this.extractImagesToolStripMenuItem.Click += new System.EventHandler(this.tsbExecute_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languages1ToolStripMenuItem,
            this.languages2ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // languages1ToolStripMenuItem
            // 
            this.languages1ToolStripMenuItem.Name = "languages1ToolStripMenuItem";
            resources.ApplyResources(this.languages1ToolStripMenuItem, "languages1ToolStripMenuItem");
            // 
            // languages2ToolStripMenuItem
            // 
            this.languages2ToolStripMenuItem.Name = "languages2ToolStripMenuItem";
            resources.ApplyResources(this.languages2ToolStripMenuItem, "languages2ToolStripMenuItem");
            // 
            // downloadSoftwareToolStripMenuItem
            // 
            this.downloadSoftwareToolStripMenuItem.Name = "downloadSoftwareToolStripMenuItem";
            resources.ApplyResources(this.downloadSoftwareToolStripMenuItem, "downloadSoftwareToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpGuideToolStripMenuItem,
            this.pleaseDonateToolStripMenuItem1,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.tiHelpFeedback,
            this.checkForNewVersionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.dotsSoftwareYoutubeChannelToolStripMenuItem,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebsiteToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpGuideToolStripMenuItem
            // 
            this.helpGuideToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.help2;
            this.helpGuideToolStripMenuItem.Name = "helpGuideToolStripMenuItem";
            resources.ApplyResources(this.helpGuideToolStripMenuItem, "helpGuideToolStripMenuItem");
            this.helpGuideToolStripMenuItem.Click += new System.EventHandler(this.helpGuideToolStripMenuItem_Click);
            // 
            // pleaseDonateToolStripMenuItem1
            // 
            this.pleaseDonateToolStripMenuItem1.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem1, "pleaseDonateToolStripMenuItem1");
            this.pleaseDonateToolStripMenuItem1.Name = "pleaseDonateToolStripMenuItem1";
            this.pleaseDonateToolStripMenuItem1.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem1_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // tiHelpFeedback
            // 
            this.tiHelpFeedback.Name = "tiHelpFeedback";
            resources.ApplyResources(this.tiHelpFeedback, "tiHelpFeedback");
            this.tiHelpFeedback.Click += new System.EventHandler(this.tiHelpFeedback_Click);
            // 
            // dotsSoftwareYoutubeChannelToolStripMenuItem
            // 
            this.dotsSoftwareYoutubeChannelToolStripMenuItem.Image = global::VideoLooper.Properties.Resources.youtube_32;
            this.dotsSoftwareYoutubeChannelToolStripMenuItem.Name = "dotsSoftwareYoutubeChannelToolStripMenuItem";
            resources.ApplyResources(this.dotsSoftwareYoutubeChannelToolStripMenuItem, "dotsSoftwareYoutubeChannelToolStripMenuItem");
            this.dotsSoftwareYoutubeChannelToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwareYoutubeChannelToolStripMenuItem_Click);
            // 
            // cmbVideoFile
            // 
            resources.ApplyResources(this.cmbVideoFile, "cmbVideoFile");
            this.cmbVideoFile.FormattingEnabled = true;
            this.cmbVideoFile.Name = "cmbVideoFile";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // cmbVideoVolume
            // 
            resources.ApplyResources(this.cmbVideoVolume, "cmbVideoVolume");
            this.cmbVideoVolume.FormattingEnabled = true;
            this.cmbVideoVolume.Name = "cmbVideoVolume";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // cmbBackgroundFile
            // 
            resources.ApplyResources(this.cmbBackgroundFile, "cmbBackgroundFile");
            this.cmbBackgroundFile.FormattingEnabled = true;
            this.cmbBackgroundFile.Name = "cmbBackgroundFile";
            // 
            // cmbBackgroundVolume
            // 
            resources.ApplyResources(this.cmbBackgroundVolume, "cmbBackgroundVolume");
            this.cmbBackgroundVolume.FormattingEnabled = true;
            this.cmbBackgroundVolume.Name = "cmbBackgroundVolume";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Name = "label6";
            // 
            // btnBrowseVideoFile
            // 
            resources.ApplyResources(this.btnBrowseVideoFile, "btnBrowseVideoFile");
            this.btnBrowseVideoFile.ForeColor = System.Drawing.Color.Black;
            this.btnBrowseVideoFile.Name = "btnBrowseVideoFile";
            this.btnBrowseVideoFile.UseVisualStyleBackColor = true;
            this.btnBrowseVideoFile.Click += new System.EventHandler(this.btnBrowseVideoFile_Click);
            // 
            // btnBrowseBackgroundFile
            // 
            resources.ApplyResources(this.btnBrowseBackgroundFile, "btnBrowseBackgroundFile");
            this.btnBrowseBackgroundFile.ForeColor = System.Drawing.Color.Black;
            this.btnBrowseBackgroundFile.Name = "btnBrowseBackgroundFile";
            this.btnBrowseBackgroundFile.UseVisualStyleBackColor = true;
            this.btnBrowseBackgroundFile.Click += new System.EventHandler(this.btnBrowseBackgroundFile_Click);
            // 
            // chkMute
            // 
            resources.ApplyResources(this.chkMute, "chkMute");
            this.chkMute.BackColor = System.Drawing.Color.Transparent;
            this.chkMute.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkMute.Name = "chkMute";
            this.chkMute.UseVisualStyleBackColor = false;
            this.chkMute.CheckedChanged += new System.EventHandler(this.chkMute_CheckedChanged);
            // 
            // tudDuration
            // 
            this.tudDuration.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tudDuration, "tudDuration");
            this.tudDuration.Name = "tudDuration";
            this.tudDuration.Time = System.TimeSpan.Parse("00:00:00");
            // 
            // rdTimeDuration
            // 
            resources.ApplyResources(this.rdTimeDuration, "rdTimeDuration");
            this.rdTimeDuration.BackColor = System.Drawing.Color.Transparent;
            this.rdTimeDuration.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdTimeDuration.Name = "rdTimeDuration";
            this.rdTimeDuration.TabStop = true;
            this.rdTimeDuration.UseVisualStyleBackColor = false;
            this.rdTimeDuration.CheckedChanged += new System.EventHandler(this.rdLoopFitBackgroundDuration_CheckedChanged);
            // 
            // rdLoopFitBackgroundDuration
            // 
            resources.ApplyResources(this.rdLoopFitBackgroundDuration, "rdLoopFitBackgroundDuration");
            this.rdLoopFitBackgroundDuration.BackColor = System.Drawing.Color.Transparent;
            this.rdLoopFitBackgroundDuration.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdLoopFitBackgroundDuration.Name = "rdLoopFitBackgroundDuration";
            this.rdLoopFitBackgroundDuration.TabStop = true;
            this.rdLoopFitBackgroundDuration.UseVisualStyleBackColor = false;
            this.rdLoopFitBackgroundDuration.CheckedChanged += new System.EventHandler(this.rdLoopFitBackgroundDuration_CheckedChanged);
            // 
            // rdLoopNumberOfTimes
            // 
            resources.ApplyResources(this.rdLoopNumberOfTimes, "rdLoopNumberOfTimes");
            this.rdLoopNumberOfTimes.BackColor = System.Drawing.Color.Transparent;
            this.rdLoopNumberOfTimes.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdLoopNumberOfTimes.Name = "rdLoopNumberOfTimes";
            this.rdLoopNumberOfTimes.TabStop = true;
            this.rdLoopNumberOfTimes.UseVisualStyleBackColor = false;
            this.rdLoopNumberOfTimes.CheckedChanged += new System.EventHandler(this.rdLoopFitBackgroundDuration_CheckedChanged);
            // 
            // nudLoopNumberOfTimes
            // 
            resources.ApplyResources(this.nudLoopNumberOfTimes, "nudLoopNumberOfTimes");
            this.nudLoopNumberOfTimes.Maximum = new decimal(new int[] {
            -1981284352,
            -1966660860,
            0,
            0});
            this.nudLoopNumberOfTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLoopNumberOfTimes.Name = "nudLoopNumberOfTimes";
            this.nudLoopNumberOfTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // txtFilenamePattern
            // 
            resources.ApplyResources(this.txtFilenamePattern, "txtFilenamePattern");
            this.txtFilenamePattern.Name = "txtFilenamePattern";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Name = "label3";
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilenamePattern);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudLoopNumberOfTimes);
            this.Controls.Add(this.rdLoopNumberOfTimes);
            this.Controls.Add(this.rdLoopFitBackgroundDuration);
            this.Controls.Add(this.rdTimeDuration);
            this.Controls.Add(this.tudDuration);
            this.Controls.Add(this.chkMute);
            this.Controls.Add(this.btnBrowseBackgroundFile);
            this.Controls.Add(this.btnBrowseVideoFile);
            this.Controls.Add(this.cmbBackgroundVolume);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbBackgroundFile);
            this.Controls.Add(this.cmbVideoVolume);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbVideoFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragOver);
            this.groupBox1.ResumeLayout(false);
            this.cmsFiles.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoopNumberOfTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox cmbOutputDir;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ContextMenuStrip cmsFiles;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFullFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbExecute;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languages1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languages2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiHelpFeedback;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVideoVolume;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBackgroundVolume;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowseVideoFile;
        private System.Windows.Forms.Button btnBrowseBackgroundFile;
        private System.Windows.Forms.CheckBox chkMute;
        private TimeUpDownControl tudDuration;
        public System.Windows.Forms.ComboBox cmbVideoFile;
        public System.Windows.Forms.ComboBox cmbBackgroundFile;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem whenFinishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem useFFMPEG64bitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useFFMPEG32bitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyEXIFInformationFromSourceVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepCreationDateFromSourceVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepLastModificationDateFromSourceVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwareYoutubeChannelToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdTimeDuration;
        private System.Windows.Forms.RadioButton rdLoopFitBackgroundDuration;
        private System.Windows.Forms.RadioButton rdLoopNumberOfTimes;
        private System.Windows.Forms.NumericUpDown nudLoopNumberOfTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilenamePattern;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem showMessageOnSuccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem;
        private com.softpcapps.download_software.DownloadSoftwareToolStripMenuItem downloadSoftwareToolStripMenuItem;
    }
}