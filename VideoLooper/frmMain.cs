using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace VideoLooper
{
    public partial class frmMain : CustomForm
    {
        public static frmMain Instance = null;       

        public bool SilentAdd = false;
        public string SilentAddErr = "";                

        private string sOutputDir = "";
        private bool bKeepBackup = false;

        public string DurationStr = "";
        public int DurationMsecs = 0;                                              

        public frmMain()
        {
            InitializeComponent();

            Instance = this;            
        }                

        #region Share

        private void tsiFacebook_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void tsiTwitter_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void tsiGooglePlus_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void tsiLinkedIn_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void tsiEmail_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
        }

        #endregion
                
        private void SetupOutputFolders()
        {
            if (cmbOutputDir.Items.Count > 0) return;

            cmbOutputDir.Items.Add(TranslateHelper.Translate("Same Folder of Video"));
            //cmbOutputDir.Items.Add(TranslateHelper.Translate("Overwrite Document"));
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Subfolder of Video"));
            cmbOutputDir.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString());
            cmbOutputDir.Items.Add("---------------------------------------------------------------------------------------");

            OutputFolderHelper.LoadOutputFolders();
            cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;            

            //4keepBackupOfChangedDocumentsToolStripMenuItem.Checked = Properties.Settings.Default.KeepBackup;

        }

        bool FreeForPersonalUse = false;
        bool FreeForPersonalAndCommercialUse = true;

        private void SetTitle()
        {
            string str = "";

            if (!FreeForPersonalUse && !FreeForPersonalAndCommercialUse)
            {
                if (frmAbout.LDT == string.Empty)
                {
                    str += " - " + TranslateHelper.Translate("Trial Version - Unlicensed - Please Buy !");
                }
                else
                {
                    str += " - " + TranslateHelper.Translate("Licensed Version");
                }
            }
            else if (FreeForPersonalUse)
            {
                str += " - " + TranslateHelper.Translate("Free for Personal Use Only - Please Donate !");
            }
            else if (FreeForPersonalAndCommercialUse)
            {
                str += " - " + TranslateHelper.Translate("Free for Personal and Commercial Use - Please Donate !");
            }

            this.Text = Module.ApplicationTitle + str.ToUpper();
        }
        private void SetupOnLoad()
        {            
            //3this.Icon = Properties.Resources.pdf_compress_48;

            this.Text = Module.ApplicationTitle;

            SetTitle();
            
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            //this.Left = 0;
            AddLanguageMenuItems();
                        
            AdjustSizeLocation();

            SetupOutputFolders();

            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Shutdown"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Sleep"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Hibernate"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Logoff"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Lock Workstation"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Restart"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Exit Application"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Explore Output Video"));
            whenFinishedToolStripMenuItem.DropDownItems.Add(TranslateHelper.Translate("Do Nothing"));

            foreach (ToolStripMenuItem ti in whenFinishedToolStripMenuItem.DropDownItems)
            {
                ti.Click += tiWhenFinished_Click;
            }

            if (Properties.Settings.Default.WhenFinishedIndex != -1)
            {
                ToolStripMenuItem ti = (ToolStripMenuItem)whenFinishedToolStripMenuItem.DropDownItems[Properties.Settings.Default.WhenFinishedIndex];
                ti.Checked = true;
            }
            
            /*
            buyToolStripMenuItem.Visible = frmPurchase.RenMove;

            if (Properties.Settings.Default.Price != string.Empty && !buyApplicationToolStripMenuItem.Text.EndsWith(Properties.Settings.Default.Price))
            {
                buyApplicationToolStripMenuItem.Text = buyApplicationToolStripMenuItem.Text + " " + Properties.Settings.Default.Price;
            }
            */            

            RecentFilesHelper.FillBackgroundFiles();
            RecentFilesHelper.FillVideoFiles();

            cmbVideoFile.Text = Properties.Settings.Default.CurrentVideoFile;
            cmbBackgroundFile.Text = Properties.Settings.Default.CurrentBackgroundFile;
            

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Module.VideoOptionsFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not load Video Encoding Options File !");
                return;
            }

            XmlNodeList novos = doc.SelectNodes("//Volume");

            cmbVideoVolume.Items.Add("");

            for (int k = 0; k < novos.Count; k++)
            {
                cmbVideoVolume.Items.Add(novos[k].InnerText);
                cmbBackgroundVolume.Items.Add(novos[k].InnerText);
            }

            if (Properties.Settings.Default.FFMPEG64Bit == 0)
            {
                if (Module.IsWindows64Bit)
                {
                    useFFMPEG64bitToolStripMenuItem_Click(null, null);
                }
                else
                {
                    useFFMPEG32bitToolStripMenuItem_Click(null, null);
                }
            }
            else if (Properties.Settings.Default.FFMPEG64Bit == 1)
            {
                useFFMPEG64bitToolStripMenuItem_Click(null, null);
            }
            else if (Properties.Settings.Default.FFMPEG64Bit == 2)
            {
                useFFMPEG32bitToolStripMenuItem_Click(null, null);
            }

            copyEXIFInformationFromSourceVideoToolStripMenuItem.Checked = Properties.Settings.Default.CopyEXIF;

            tudDuration.Text = Properties.Settings.Default.LoopDuration;

            //3

            /*            
            enterLicenseKeyToolStripMenuItem.Visible = frmPurchase.RenMove;

            buyToolStripMenuItem.Visible = frmPurchase.RenMove;

            if (Properties.Settings.Default.Price != string.Empty && !buyApplicationToolStripMenuItem.Text.EndsWith(Properties.Settings.Default.Price))
            {
                buyApplicationToolStripMenuItem.Text = buyApplicationToolStripMenuItem.Text + " " + Properties.Settings.Default.Price;
            }
            */

            chkMute.Checked = Properties.Settings.Default.OFMute;

            cmbVideoVolume.Text = Properties.Settings.Default.OFVolume;

            cmbBackgroundVolume.Text = Properties.Settings.Default.BackgroundVolume;

            nudLoopNumberOfTimes.Value = Properties.Settings.Default.LoopNumberOfTimes;

            if (Properties.Settings.Default.LoopType == 0)
            {
                rdTimeDuration.Checked = true;
            }
            else if (Properties.Settings.Default.LoopType == 1)
            {
                rdLoopFitBackgroundDuration.Checked = true;
            }
            else if (Properties.Settings.Default.LoopType == 2)
            {
                rdLoopNumberOfTimes.Checked = true;
            }

            txtFilenamePattern.Text = Properties.Settings.Default.OutputFilenamePattern;

            checkForNewVersionEachWeekToolStripMenuItem.Checked = Properties.Settings.Default.CheckWeek;

            preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem.Checked = Properties.Settings.Default.PreventSleep;

            if (Properties.Settings.Default.PreventSleep)
            {
                SleepPreventer.PreventSleep();
            }

        }

        private void AdjustSizeLocation()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width == -1)
                {
                    this.CenterToScreen();
                    return;
                }
                else
                {
                    this.Width = Properties.Settings.Default.Width;
                }
                if (Properties.Settings.Default.Height != 0)
                {
                    this.Height = Properties.Settings.Default.Height;
                }

                if (Properties.Settings.Default.Left != -1)
                {
                    this.Left = Properties.Settings.Default.Left;
                }

                if (Properties.Settings.Default.Top != -1)
                {
                    this.Top = Properties.Settings.Default.Top;
                }

                if (this.Width < 300)
                {
                    this.Width = 300;
                }

                if (this.Height < 300)
                {
                    this.Height = 300;
                }

                if (this.Left < 0)
                {
                    this.Left = 0;
                }

                if (this.Top < 0)
                {
                    this.Top = 0;
                }
            }

        }

        private void SaveSizeLocation()
        {
            Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Save();

        }

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Properties.Settings.Default.Language == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);

                if (k < 25)
                {
                    languages1ToolStripMenuItem.DropDownItems.Add(ti);
                }
                else
                {
                    languages2ToolStripMenuItem.DropDownItems.Add(ti);
                }

                //languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            //for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            for (int k = 0; k < languages1ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages1ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }

            for (int k = 0; k < languages2ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages2ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }

        private bool InChangeLanguage = false;

        private void ChangeLanguage(string language_code)
        {
            try
            {
                InChangeLanguage = true;

                Properties.Settings.Default.Language = language_code;
                frmLanguage.SetLanguage();

                Properties.Settings.Default.Save();
                Module.ShowMessage("Please restart the application !");
                Application.Exit();
                return;

                /*
                RegistryKey key = Registry.CurrentUser;
                RegistryKey key2 = Registry.CurrentUser;

                try
                {
                    key = key.OpenSubKey("Software\\softpcapps Software", true);

                    if (key == null)
                    {
                        key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\softpcapps Software");
                    }

                    key2 = key.OpenSubKey(frmLanguage.RegKeyName, true);

                    if (key2 == null)
                    {
                        key2 = key.CreateSubKey(frmLanguage.RegKeyName);
                    }

                    key = key2;

                    //key.SetValue("Language", language_code);
                    key.SetValue("Menu Item Caption", TranslateHelper.Translate("Change PDF Properties"));
                }
                catch (Exception ex)
                {
                    Module.ShowError(ex);
                    return;
                }
                finally
                {
                    key.Close();
                    key2.Close();
                }
                */
                //1SaveSizeLocation();

                //3SavePositionSize();
                
            }
            finally
            {
                InChangeLanguage = false;
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }

        private void EnableDisableForm(bool enable)
        {
            foreach (Control co in this.Controls)
            {
                co.Enabled = enable;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetupOnLoad();

            if (Properties.Settings.Default.CheckWeek)
            {
                UpdateHelper.InitializeCheckVersionWeek();
            }

            //3

           // this.Text += " - " + TranslateHelper.Translate("Free for personal and commercial use") + " - " + TranslateHelper.Translate("Please donate !");

            
        }        

        #region Help

        private void helpGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.StartupPath + "\\Video Cutter Joiner Expert - User's Manual.chm");
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private void pleaseDonateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/donate.php");
        }

        private void dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://softpcapps.com/downloads/4dots-Software-PRODUCT-CATALOG.pdf");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void tiHelpFeedback_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://softpcapps.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.twitter.com/4dotsSoftware");
        }

        private void visit4dotsSoftwareWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://softpcapps.com");
        }

        private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateHelper.CheckVersion(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch { }
        }

        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {            
            Properties.Settings.Default.CurrentVideoFile = cmbVideoFile.Text;

            Properties.Settings.Default.CurrentBackgroundFile = cmbBackgroundFile.Text;

            Properties.Settings.Default.OFMute = chkMute.Checked;

            Properties.Settings.Default.OFVolume = cmbVideoVolume.Text;

            Properties.Settings.Default.BackgroundVolume = cmbBackgroundVolume.Text;

            Properties.Settings.Default.LoopDuration = tudDuration.Text;

            Properties.Settings.Default.OutputFolder = cmbOutputDir.Text;

            Properties.Settings.Default.OutputFolderIndex = cmbOutputDir.SelectedIndex;

            Properties.Settings.Default.LoopNumberOfTimes = (int)nudLoopNumberOfTimes.Value;

            if (rdTimeDuration.Checked)
            {
                Properties.Settings.Default.LoopType = 0;
            }
            else if (rdLoopFitBackgroundDuration.Checked)
            {
                Properties.Settings.Default.LoopType = 1;
            }
            else if (rdLoopNumberOfTimes.Checked)
            {
                Properties.Settings.Default.LoopType = 2;
            }

            Properties.Settings.Default.OutputFilenamePattern = txtFilenamePattern.Text;

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;

            Properties.Settings.Default.PreventSleep = preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();

            SaveSizeLocation();
        }

        public FFMpegExecuter FFMpegExecuter = null;

        private FFMpegArgs ffmpegArgs = null;

        public void tsbExecute_Click(object sender, EventArgs e)
        {
            if (FFMpegExecuter!=null && FFMpegExecuter.ConversionStarted)
            {
                FFMpegExecuter.PauseExecution();
            }
            else if (FFMpegExecuter != null && FFMpegExecuter.ConversionPaused)
            {
                FFMpegExecuter.ResumeExecution();
            }
            else
            {
                try
                {
                    if (cmbVideoFile.Text == string.Empty || !System.IO.File.Exists(cmbVideoFile.Text))
                    {
                        Module.ShowMessage("Please specify a valid Input Video File first !");
                        return;
                    }

                    if (cmbBackgroundFile.Text.Trim() == string.Empty && rdLoopFitBackgroundDuration.Checked)
                    {
                        Module.ShowMessage("Please specify a valid Background Audio File first !");
                        return;
                    }

                    if (cmbBackgroundFile.Text != string.Empty && !System.IO.File.Exists(cmbBackgroundFile.Text))
                    {
                        Module.ShowMessage("Please specify a valid Background Audio File first !");
                        return;
                    }

                    if (cmbOutputDir.SelectedIndex > 3)
                    {
                        try
                        {
                            if (!System.IO.Directory.Exists(cmbOutputDir.Text))
                            {
                                System.IO.Directory.CreateDirectory(cmbOutputDir.Text);
                            }
                        }
                        catch
                        {

                        }
                    }

                    OutputFolderHelper.SaveOutputFolder(cmbOutputDir.Text);

                    ffmpegArgs = new FFMpegArgs();

                    if (!ffmpegArgs.GetOutputFormat()) return;                    

                    Properties.Settings.Default.CurrentVideoFile = cmbVideoFile.Text;

                    Properties.Settings.Default.CurrentBackgroundFile = cmbBackgroundFile.Text;

                    Properties.Settings.Default.OFMute = chkMute.Checked;

                    Properties.Settings.Default.OFVolume = cmbVideoVolume.Text;

                    Properties.Settings.Default.BackgroundVolume = cmbBackgroundVolume.Text;

                    Properties.Settings.Default.LoopDuration = tudDuration.Text;

                    Properties.Settings.Default.OutputFolder = cmbOutputDir.Text;

                    Properties.Settings.Default.OutputFolderIndex = cmbOutputDir.SelectedIndex;

                    Properties.Settings.Default.OutputFilenamePattern = txtFilenamePattern.Text;

                    Properties.Settings.Default.LoopNumberOfTimes = (int)nudLoopNumberOfTimes.Value;

                    if (rdTimeDuration.Checked)
                    {
                        Properties.Settings.Default.LoopType = 0;
                    }
                    else if (rdLoopFitBackgroundDuration.Checked)
                    {
                        Properties.Settings.Default.LoopType = 1;
                    }
                    else if (rdLoopNumberOfTimes.Checked)
                    {
                        Properties.Settings.Default.LoopType = 2;
                    }                    

                    bool video_has_audio = false;

                    try
                    {
                        FFMPEGInfo finfo = new FFMPEGInfo(cmbVideoFile.Text);

                        ffmpegArgs.DurationMsecs = finfo.DurationMsecs;

                        if (finfo.AudioEncoder != string.Empty)
                        {
                            video_has_audio = true;
                        }

                        if (cmbBackgroundFile.Text.Trim() != string.Empty)
                        {
                            FFMPEGInfo finfo2 = new FFMPEGInfo(cmbBackgroundFile.Text);
                            ffmpegArgs.BackgroundAudioDurationMsecs = finfo2.DurationMsecs;
                        }
                    }
                    catch (Exception ex)
                    {
                        Module.ShowError("Error could not get Video or Audio Duration !", ex);                    
                    }


                    ffmpegArgs.VideoFile = Properties.Settings.Default.CurrentVideoFile;
                    ffmpegArgs.BackgroundFile = Properties.Settings.Default.CurrentBackgroundFile;
                    ffmpegArgs.firstPassArgs = Properties.Settings.Default.OF1stPassParameters;
                    ffmpegArgs.secondPassArgs = Properties.Settings.Default.OF2ndPassParameters;
                    ffmpegArgs.videoBitRate = Properties.Settings.Default.OFVideoBitrate;
                    ffmpegArgs.videoFrameRate = Properties.Settings.Default.OFFrameRate;
                    ffmpegArgs.videoSize = Properties.Settings.Default.OFVideoSize;
                    ffmpegArgs.videoAspectRatio = Properties.Settings.Default.OFAspectRatio;
                    ffmpegArgs.videoTwoPass = Properties.Settings.Default.OFTwoPass;
                    ffmpegArgs.videoDeinterlace = Properties.Settings.Default.OFDeinterlace;
                    ffmpegArgs.audioBitRate = Properties.Settings.Default.OFAudioBitrate;
                    ffmpegArgs.audioSampleRate = Properties.Settings.Default.OFSampleRate;
                    ffmpegArgs.audioChannels = Properties.Settings.Default.OFAudioChannels;
                    ffmpegArgs.audioVolume = Properties.Settings.Default.OFVolume;
                    ffmpegArgs.audioNormalize = Properties.Settings.Default.OFAudioNormalize;
                    ffmpegArgs.audioMute = Properties.Settings.Default.OFMute;
                    ffmpegArgs.copyMetadata = Properties.Settings.Default.OFKeepMetadata;
                    ffmpegArgs.VideoHasAudio = video_has_audio;                    

                    ffmpegArgs.backgroundAudioVolume = Properties.Settings.Default.BackgroundVolume;

                    ffmpegArgs.OutputFolder = Properties.Settings.Default.OutputFolder;

                    ffmpegArgs.LoopDurationMsecs = tudDuration.MSecsValue;

                    ffmpegArgs.LoopType = Properties.Settings.Default.LoopType;

                    ffmpegArgs.LoopNumberOfTimes = Properties.Settings.Default.LoopNumberOfTimes;

                    this.Cursor = Cursors.WaitCursor;
                    //this.Enabled = false;

                    EnableDisableForm(false);

                    BackgroundWorker bwArgs = new BackgroundWorker();
                    bwArgs.DoWork += bwArgs_DoWork;
                    bwArgs.RunWorkerCompleted += bwArgs_RunWorkerCompleted;

                    frmProgress fp = new frmProgress();
                    fp.Show(this);

                    bwArgs.RunWorkerAsync(ffmpegArgs);

                    while (bwArgs.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    fp.Close();

                    this.Cursor = null;

                    if (ffmpegArgs == null) return;

                    if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(ffmpegArgs.FirstOutputFile)))
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(ffmpegArgs.FirstOutputFile));
                        }
                        catch
                        {
                            EnableDisableForm(true);

                            Module.ShowMessage("Error could not create Output Directory !");

                            //this.Enabled = true;

                            return;
                        }
                    }

                    FFMpegExecuter = new VideoLooper.FFMpegExecuter(ffmpegArgs, this, Properties.Settings.Default.WhenFinishedIndex);

                    FFMpegExecuter.Execute();                                       

                }
                catch (Exception ex)
                {
                    EnableDisableForm(true);

                    Module.ShowError("Error !", ex);

                    //this.Enabled = true;
                }
                finally
                {
                    EnableDisableForm(true);
                }
            }
        }

        void bwArgs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ffmpegArgs = (FFMpegArgs)e.Result;
        }

        void bwArgs_DoWork(object sender, DoWorkEventArgs e)
        {
            FFMpegArgs ffmpegArgs1 = (FFMpegArgs)e.Argument;
            
            ffmpegArgs1 = ffmpegArgs1.InitializeFFMpegArgs();

            e.Result = ffmpegArgs;
        }        

        #region Options

        void tiWhenFinished_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem ti2 in whenFinishedToolStripMenuItem.DropDownItems)
            {
                ti2.Checked = false;
            }

            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            ti.Checked = true;

            Properties.Settings.Default.WhenFinishedIndex = whenFinishedToolStripMenuItem.DropDownItems.IndexOf(ti);
        }

        #endregion                                

        private bool IsFileTheSame(string filepath, string existingfp)
        {
            if (!System.IO.File.Exists(existingfp)) return false;

            FileInfo fi = new FileInfo(filepath);
            FileInfo fi2 = new FileInfo(existingfp);

            if (fi.Length != fi2.Length)
            {
                return false;
            }
            else
            {
                using (FileStream fs = File.OpenRead(filepath))
                {
                    using (FileStream fs2 = File.OpenRead(existingfp))
                    {
                        try
                        {
                            byte[] bytes = new byte[1024];
                            byte[] bytes2 = new byte[1024];

                            while (fs.Read(bytes, 0, bytes.Length) > 0)
                            {
                                if (fs2.Read(bytes2, 0, bytes2.Length) > 0)
                                {
                                    for (int m = 0; m < bytes.Length; m++)
                                    {
                                        if (bytes[m] != bytes2[m])
                                        {
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void bwExtractImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }                

        private void cmbOutputDir_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cmbOutputDir.SelectedIndex == 3)
            {
                Module.ShowMessage("Please specify another option as the Output Folder !");
                cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;
            }
            else if (cmbOutputDir.SelectedIndex == 1)
            {
                frmOutputSubFolder fob = new frmOutputSubFolder();

                if (fob.ShowDialog() == DialogResult.OK)
                {
                    OutputFolderHelper.SaveOutputFolder(TranslateHelper.Translate("Subfolder") + " : " + fob.txtSubfolder.Text);
                }
                else
                {
                    return;
                }
            }            
        }        

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {     
                        
            if (cmbVideoFile.Text.Trim()==string.Empty)
            {
                Module.ShowMessage("Please specify an Input Video first !");

            }
            else
            {
                string dirpath = "";
                string filepath = "";
                string outfilepath = "";

                filepath = cmbVideoFile.Text;

                if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Same Folder of Video"))
                {
                    dirpath = System.IO.Path.GetDirectoryName(filepath);                    
                }
                else if (frmMain.Instance.cmbOutputDir.Text.ToString().StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                {
                    int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                    string subfolder = frmMain.Instance.cmbOutputDir.Text.ToString().Substring(subfolderspos);

                    dirpath= System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder;
                }
                /*
                else if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Overwrite Document"))
                {
                    outfilepath = filepath;
                }*/
                else
                {
                    dirpath = cmbOutputDir.Text;                    
                }                

                string args = string.Format("/e, /select, \"{0}\"", dirpath);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.UseShellExecute = true;
                info.Arguments = args;
                Process.Start(info);
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbr = new FolderBrowserDialog();

            if (cmbOutputDir.Text != string.Empty && System.IO.Directory.Exists(cmbOutputDir.Text))
            {
                fbr.SelectedPath = cmbOutputDir.Text;
            }
            if (fbr.ShowDialog() == DialogResult.OK)
            {
                OutputFolderHelper.SaveOutputFolder(fbr.SelectedPath);
            }

        }

        #region Drag and Drop

        private void dgFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgFiles_DragOver(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void AddFile(string filepath)
        {
            cmbVideoFile.Text = filepath;

            RecentFilesHelper.AddRecentVideoFile(filepath);
        }

        private void dgFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        if (System.IO.File.Exists(filez[k]))
                        {
                            AddFile(filez[k]);
                        }                        
                    }
                    finally
                    {
                        this.Cursor = null;
                    }
                }
            }
        }

        #endregion

        private void btnBrowseVideoFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = cmbVideoFile.Text;
            ofd.Filter = Module.OpenVideoFilter;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cmbVideoFile.Text = ofd.FileName;

                RecentFilesHelper.AddRecentVideoFile(ofd.FileName);
            }            
        }

        private void btnBrowseBackgroundFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = cmbBackgroundFile.Text;
            ofd.Filter = Module.OpenAudioFilesFilter;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cmbBackgroundFile.Text = ofd.FileName;

                RecentFilesHelper.AddRecentBackgroundFile(ofd.FileName);
            }
        }

        private void chkSetDurationBackground_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void useFFMPEG64bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useFFMPEG64bitToolStripMenuItem.Checked = true;
            useFFMPEG32bitToolStripMenuItem.Checked = false;

            Properties.Settings.Default.FFMPEG64Bit = 1;
        }

        private void useFFMPEG32bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useFFMPEG64bitToolStripMenuItem.Checked = false;
            useFFMPEG32bitToolStripMenuItem.Checked = true;

            Properties.Settings.Default.FFMPEG64Bit = 2;
        }

        private void copyEXIFInformationFromSourceVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CopyEXIF = copyEXIFInformationFromSourceVideoToolStripMenuItem.Checked;            
        }

        private void keepCreationDateFromSourceVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeepCreationDate = keepCreationDateFromSourceVideoToolStripMenuItem.Checked;
        }

        private void keepLastModificationDateFromSourceVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeepLastModDate = keepLastModificationDateFromSourceVideoToolStripMenuItem.Checked;
        }

        private void buyApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.BuyURL);
        }

        private void enterLicenseKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dotsSoftwareYoutubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCovA-lld9Q79l08K-V1QEng");
        }

        private void chkMute_CheckedChanged(object sender, EventArgs e)
        {
            cmbVideoVolume.Enabled = !chkMute.Checked;
        }

        private void rdLoopFitBackgroundDuration_CheckedChanged(object sender, EventArgs e)
        {
            tudDuration.Enabled = rdTimeDuration.Checked;

            nudLoopNumberOfTimes.Enabled = rdLoopNumberOfTimes.Checked;
        }

        private void showMessageOnSuccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowMsgOnSuccess = showMessageOnSuccessToolStripMenuItem.Checked;
        }

        private void preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PreventSleep = !Properties.Settings.Default.PreventSleep;
            preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem.Checked = !preventSystemSleepBecauseOfPowerSettingsToolStripMenuItem.Checked;
        }
    }
}
