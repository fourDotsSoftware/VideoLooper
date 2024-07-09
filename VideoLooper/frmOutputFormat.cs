using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace VideoLooper
{
    public partial class frmOutputFormat : VideoLooper.CustomForm
    {
        private List<SelectedCategoryProfile> SelectedCategoryProfileNames = new List<SelectedCategoryProfile>();

        public string Extension = "";
        public string FFMpegParameters = "";
        public OutputFormatResult OutputFormatResult = null;

        private bool ForBatchJoin = false;

        public frmOutputFormat(bool for_batch_join)
        {
            InitializeComponent();

            ForBatchJoin = for_batch_join;

            if (ForBatchJoin)
            {
                this.Text = TranslateHelper.Translate("Please specify Default Output Format to do Batch Rotate and Flip");
            }
        }

        public frmOutputFormat():this(false)
        {

        }

        public frmOutputFormat(OutputFormatResult res)
            : this(true)
        {
            OutputFormatResult = res;
        }
        private void btnNewProfile_Click(object sender, EventArgs e)
        {
            frmProfile f = new frmProfile(true);

            if (f.ShowDialog() == DialogResult.OK)
            {
                FillProfiles(f.txtProfileName.Text.Trim(), f.cmbCategory.Text.Trim());
            }
        }

        private void FillProfiles(string selected_profile,string selected_category)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNodeList nocats = doc.SelectNodes("//cat");

            List<string> lst = new List<string>();

            for (int k = 0; k < nocats.Count; k++)
            {
                string ncat = nocats[k].InnerText;

                if (lst.IndexOf(ncat) < 0)
                {
                    lst.Add(ncat);
                }
            }

            lst.Sort();

            lvCategory.Items.Clear();
            lvProfile.Items.Clear();

            lvCategory.Items.Add(TranslateHelper.Translate("Recent Profiles"));

            for (int k = 0; k < lst.Count; k++)
            {                
                    lvCategory.Items.Add(lst[k]);

                    if (selected_category != string.Empty && lst[k] == selected_category)
                    {
                        lvCategory.Items[lvCategory.Items.Count - 1].Selected = true;
                    }                                
            }

            for (int k = 0; k < lvCategory.Items.Count; k++)
            {
                if (lvCategory.Items[k].Text == TranslateHelper.Translate("Preview Join"))
                {
                    int m = 1;
                    string cattext = TranslateHelper.Translate("Preview Join");

                    lvCategory.Items.RemoveAt(k);
                    lvCategory.Items.Insert(m, cattext);

                    if (selected_category != string.Empty && cattext == selected_category)
                    {
                        lvCategory.Items[m].Selected = true;
                    }
                }
            }

            for (int k = 0; k < lvCategory.Items.Count; k++)
            {
                if (lvCategory.Items[k].Text == TranslateHelper.Translate("Ultrafast"))
                {
                    int m = 2;
                    string cattext = TranslateHelper.Translate("Ultrafast");

                    lvCategory.Items.RemoveAt(k);
                    lvCategory.Items.Insert(m, cattext);

                    if (selected_category != string.Empty && cattext == selected_category)
                    {
                        lvCategory.Items[m].Selected = true;
                    }
                }
            }

            for (int k = 0; k < lvCategory.Items.Count; k++)
            {
                if (lvCategory.Items[k].Text == TranslateHelper.Translate("Superfast"))
                {
                    int m = 3;
                    string cattext = TranslateHelper.Translate("Superfast");

                    lvCategory.Items.RemoveAt(k);
                    lvCategory.Items.Insert(m, cattext);

                    if (selected_category != string.Empty && cattext == selected_category)
                    {
                        lvCategory.Items[m].Selected = true;
                    }
                }
            }

            for (int k = 0; k < lvCategory.Items.Count; k++)
            {
                if (lvCategory.Items[k].Text == TranslateHelper.Translate("Veryfast"))
                {
                    int m = 4;
                    string cattext = TranslateHelper.Translate("Veryfast");

                    lvCategory.Items.RemoveAt(k);
                    lvCategory.Items.Insert(m, cattext);

                    if (selected_category != string.Empty && cattext == selected_category)
                    {
                        lvCategory.Items[m].Selected = true;
                    }
                }
            }

            if (lvCategory.Items.Count > 0 && selected_category == string.Empty)
            {
                lvCategory.Items[0].Selected = true;
                selected_category = lvCategory.Items[0].Text;
            }

            SelectCategory(selected_category, selected_profile);

            lvCategory.Columns[0].Width = lvCategory.Width - 7;
            lvProfile.Columns[0].Width = lvProfile.Width - 7;
        }

        public static void ProfilesToText()
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNodeList nolos = doc.SelectNodes("//Profile");

            string str = "<ul>\r\n";

            for (int k = 0; k < nolos.Count; k++)
            {
                string label = nolos[k].SelectSingleNode("label").InnerText;

                str += "<li>" + label + "</li>\r\n";
            }

            str += "</ul>";

            Clipboard.Clear();
            Clipboard.SetText(str);
        }

        private void SelectCategory(string category, string profile_name)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            SelectedCategoryProfileNames = new List<SelectedCategoryProfile>();

            if (lvCategory.SelectedIndices.Count>0 && lvCategory.SelectedIndices[0] == 0) // Recent Profiles
            {
                XmlNodeList noreces = doc.SelectNodes("//RecentProfile");

                for (int m = 0; m < noreces.Count; m++)
                {
                    XmlNode nod = doc.SelectSingleNode("//Profile[@name='" + noreces[m].InnerText + "']");

                    string label = nod.SelectSingleNode("label").InnerText;
                    
                    SelectedCategoryProfile profi = new SelectedCategoryProfile();
                    profi.Name = noreces[m].InnerText;
                    profi.Label = label;

                    SelectedCategoryProfileNames.Add(profi);
                }
            }
            else
            {
                XmlNodeList nocats = doc.SelectNodes("//cat");

                for (int k = 0; k < nocats.Count; k++)
                {
                    string ncat = nocats[k].InnerText;

                    if (ncat == category)
                    {
                        string label = nocats[k].ParentNode.SelectSingleNode("label").InnerText;
                        string name = nocats[k].ParentNode.Attributes.GetNamedItem("name").Value; ;

                        bool found = false;

                        for (int m = 0; m < SelectedCategoryProfileNames.Count; m++)
                        {
                            if (SelectedCategoryProfileNames[m].Name == name)
                            {
                                found = true;
                            }
                        }

                        if (!found)
                        {
                            SelectedCategoryProfile profi = new SelectedCategoryProfile();
                            profi.Name = nocats[k].ParentNode.Attributes.GetNamedItem("name").Value;
                            profi.Label = label;

                            SelectedCategoryProfileNames.Add(profi);
                        }
                    }
                }
            }

            SelectedCategoryProfileNames.Sort(new SelectedCategoryComparer());

            lvProfile.Items.Clear();

            for (int k = 0; k < SelectedCategoryProfileNames.Count; k++)
            {
                lvProfile.Items.Add(SelectedCategoryProfileNames[k].Label);

                if (profile_name!=string.Empty)
                {
                    if (SelectedCategoryProfileNames[k].Name == profile_name)
                    {
                        lvProfile.Items[lvProfile.Items.Count - 1].Selected = true;
                    }
                }
            }

            if (profile_name == string.Empty && lvProfile.Items.Count > 0)
            {
                lvProfile.Items[0].Selected = true;
            }
        }
        private void frmOutputFormat_Load(object sender, EventArgs e)
        {
            if (OutputFormatResult != null)
            {
                FillProfiles(OutputFormatResult.selectedProfile, OutputFormatResult.selectedProfileCategory);
            }
            else
            {
                FillProfiles(Properties.Settings.Default.SelectedProfile, Properties.Settings.Default.SelectedProfileCategory);
            }

            LoadVideoEncodingOptions();

            if (OutputFormatResult != null)
            {
                LoadOutputFormatResult();
            }
            else
            {
                LoadSettings();
            }            

            this.CancelButton = null;
            this.AcceptButton = null;
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCategory.SelectedIndices.Count > 0)
            {
                SelectCategory(lvCategory.SelectedItems[0].Text, "");
                btnEditProfile.Enabled = true;
            }
            else
            {
                btnEditProfile.Enabled = false;               
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvProfile.SelectedIndices.Count == 0)
            {
                Module.ShowMessage("Please select a Profile first !");
                return;
            }                        

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNode nod = doc.SelectSingleNode("//Profile[@name='" + SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name + "']");

            Extension = nod.SelectSingleNode("ext").InnerText;

            if (!Extension.StartsWith("."))
            {
                Extension = "." + Extension;
            }
            
            FFMpegParameters = nod.SelectSingleNode("ffmpeg_parameters").InnerText;            

            if (ForBatchJoin)
            {
                OutputFormatResult = new OutputFormatResult();

                OutputFormatResult.selectedProfile = SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name;
                OutputFormatResult.selectedProfileCategory = lvCategory.Items[lvCategory.SelectedIndices[0]].Text;
                OutputFormatResult.extension = Extension;
                OutputFormatResult.ffmpegParameters = FFMpegParameters;

                SaveOutputFormatResult();
            }
            else
            {

                Properties.Settings.Default.SelectedProfile = SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name;
                Properties.Settings.Default.SelectedProfileCategory = lvCategory.Items[lvCategory.SelectedIndices[0]].Text;

                SaveRecentProfiles(SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name);

                SaveSettings();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void SaveRecentProfiles(string profile_name)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNodeList norece = doc.SelectNodes("//RecentProfile");

            bool found = false;

            for (int k = 0; k < norece.Count; k++)
            {
                if (norece[k].InnerText == profile_name)
                {
                    found = true;

                    XmlNode nor = (XmlNode)doc.CreateElement("RecentProfile");
                    nor.InnerText = profile_name;

                    norece[k].ParentNode.PrependChild(nor);

                    norece[k].ParentNode.RemoveChild(norece[k]);
                }

                if ((k == 11 && !found) || k>11)
                {
                    norece[k].ParentNode.RemoveChild(norece[k]);
                }
            }

            if (!found)
            {
                XmlNode nor = (XmlNode)doc.CreateElement("RecentProfile");
                nor.InnerText = profile_name;

                XmlNode noreces = doc.SelectSingleNode("//RecentProfiles");

                noreces.PrependChild(nor);
            }

            doc.Save(Module.ProfilesFile);

        }

        private void LoadRecentProfiles()
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(Module.ProfilesFile);
            }
            catch
            {
                Module.ShowMessage("Error. Could not read valid Profiles File !");
                return;
            }

            XmlNodeList norece = doc.SelectNodes("//RecentProfile");
            
            for (int k = 0; k < norece.Count; k++)
            {

            }
        }
        private void LoadVideoEncodingOptions()
        {
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

            cmbVolume.Items.Add("");            

            for (int k = 0; k < novos.Count; k++)
            {
                cmbVolume.Items.Add(novos[k].InnerText);                
            }

            XmlNodeList nochan = doc.SelectNodes("//AudioChannel");

            cmbAudioChannels.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbAudioChannels.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//VideoSize");

            cmbVideoSize.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbVideoSize.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//AspectRatio");

            cmbVideoAspectRatio.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbVideoAspectRatio.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//VideoBitrate");

            cmbVideoBitrate.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbVideoBitrate.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//AudioBitrate");

            cmbAudioBitrate.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbAudioBitrate.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//AudioSampleRate");

            cmbSampleRate.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbSampleRate.Items.Add(nochan[k].InnerText);
            }

            nochan = doc.SelectNodes("//FrameRate");

            cmbVideoFrameRate.Items.Add("");

            for (int k = 0; k < nochan.Count; k++)
            {
                cmbVideoFrameRate.Items.Add(nochan[k].InnerText);
            }                        
        }

        private void LoadSettings()
        {
            cmbVideoBitrate.Text = Properties.Settings.Default.OFVideoBitrate;
            cmbVideoFrameRate.Text = Properties.Settings.Default.OFFrameRate;
            cmbVideoSize.Text = Properties.Settings.Default.OFVideoSize;
            cmbVolume.Text = Properties.Settings.Default.OFVolume;
            cmbAudioBitrate.Text = Properties.Settings.Default.OFAudioBitrate;
            cmbAudioChannels.Text = Properties.Settings.Default.OFAudioChannels;
            cmbSampleRate.Text = Properties.Settings.Default.OFSampleRate;
            cmbVideoAspectRatio.Text = Properties.Settings.Default.OFAspectRatio;

            chkTwoPass.Checked = Properties.Settings.Default.OFTwoPass;
            chkDeinterlace.Checked = Properties.Settings.Default.OFDeinterlace;

            txtFFMpeg1stPass.Text = Properties.Settings.Default.OF1stPassParameters;
            txtFFMpeg2ndPass.Text = Properties.Settings.Default.OF2ndPassParameters;
            txtFFMpegAddParameters.Text = Properties.Settings.Default.OFAdditionalParameters;

            chkNormalize.Checked = Properties.Settings.Default.OFAudioNormalize;

            chkMute.Checked = Properties.Settings.Default.OFMute;

            chkCopyMetadata.Checked = Properties.Settings.Default.OFKeepMetadata;            
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.OFVideoBitrate = cmbVideoBitrate.Text;
            Properties.Settings.Default.OFFrameRate = cmbVideoFrameRate.Text;
            Properties.Settings.Default.OFVideoSize = cmbVideoSize.Text;
            Properties.Settings.Default.OFVolume = cmbVolume.Text;
            Properties.Settings.Default.OFAudioBitrate = cmbAudioBitrate.Text;
            Properties.Settings.Default.OFAudioChannels = cmbAudioChannels.Text;
            Properties.Settings.Default.OFSampleRate = cmbSampleRate.Text;
            Properties.Settings.Default.OFAspectRatio = cmbVideoAspectRatio.Text;

            Properties.Settings.Default.OFTwoPass = chkTwoPass.Checked;
            Properties.Settings.Default.OFDeinterlace = chkDeinterlace.Checked;

            Properties.Settings.Default.OF1stPassParameters = txtFFMpeg1stPass.Text;
            Properties.Settings.Default.OF2ndPassParameters = txtFFMpeg2ndPass.Text;
            Properties.Settings.Default.OFAdditionalParameters = txtFFMpegAddParameters.Text;

            Properties.Settings.Default.OFAudioNormalize = chkNormalize.Checked;
            Properties.Settings.Default.OFMute = chkMute.Checked;

            Properties.Settings.Default.OFKeepMetadata = chkCopyMetadata.Checked;                       
        }

        private void SaveOutputFormatResult()
        {
            OutputFormatResult.videoBitRate = cmbVideoBitrate.Text;
            OutputFormatResult.videoFrameRate = cmbVideoFrameRate.Text;
            OutputFormatResult.videoSize = cmbVideoSize.Text;
            OutputFormatResult.audioVolume = cmbVolume.Text;
            OutputFormatResult.audioBitRate = cmbAudioBitrate.Text;
            OutputFormatResult.audioChannels = cmbAudioChannels.Text;
            OutputFormatResult.audioSampleRate = cmbSampleRate.Text;
            OutputFormatResult.videoAspectRatio = cmbVideoAspectRatio.Text;

            OutputFormatResult.videoTwoPass = chkTwoPass.Checked;
            OutputFormatResult.videoDeinterlace = chkDeinterlace.Checked;

            OutputFormatResult.firstPassArgs = txtFFMpeg1stPass.Text;
            OutputFormatResult.secondPassArgs = txtFFMpeg2ndPass.Text;
            OutputFormatResult.additionalArgs = txtFFMpegAddParameters.Text;

            OutputFormatResult.audioNormalize = chkNormalize.Checked;
            OutputFormatResult.audioMute = chkMute.Checked;

            OutputFormatResult.copyMetadata = chkCopyMetadata.Checked;           
            
        }

        private void LoadOutputFormatResult()
        {
            cmbVideoBitrate.Text = OutputFormatResult.videoBitRate;
            cmbVideoFrameRate.Text = OutputFormatResult.videoFrameRate;
            cmbVideoSize.Text = OutputFormatResult.videoSize;
            cmbVolume.Text = OutputFormatResult.audioVolume;
            cmbAudioBitrate.Text = OutputFormatResult.audioBitRate;
            cmbAudioChannels.Text = OutputFormatResult.audioChannels;
            cmbSampleRate.Text = OutputFormatResult.audioChannels;
            cmbVideoAspectRatio.Text = OutputFormatResult.videoAspectRatio;

            chkTwoPass.Checked = OutputFormatResult.videoTwoPass;
            chkDeinterlace.Checked = OutputFormatResult.videoDeinterlace;

            txtFFMpeg1stPass.Text = OutputFormatResult.firstPassArgs;
            txtFFMpeg2ndPass.Text = OutputFormatResult.secondPassArgs;
            txtFFMpegAddParameters.Text = OutputFormatResult.additionalArgs;

            chkNormalize.Checked = OutputFormatResult.audioNormalize;
            chkMute.Checked = OutputFormatResult.audioMute;

            chkCopyMetadata.Checked = OutputFormatResult.copyMetadata;           

        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (lvProfile.SelectedIndices.Count == 0)
            {
                Module.ShowMessage("Please select a Profile first !");
                return;
            }

            frmProfile f = new frmProfile(SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name);

            if (f.ShowDialog() == DialogResult.OK)
            {
                FillProfiles(f.txtProfileName.Text.Trim().Replace("'",""), f.cmbCategory.Text.Trim().Replace("'",""));
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
                        
        }

        private void chkReplaceAudio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkMixAudio_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnDrawTextFontColor_Click(object sender, EventArgs e)
        {
        }

        private void btnDrawTextShadowColor_Click(object sender, EventArgs e)
        {
        }

        private void btnDrawTextFontBrowse_Click(object sender, EventArgs e)
        {
        }

        private void btnBrowseOverlay_Click(object sender, EventArgs e)
        {
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (lvProfile.SelectedIndices.Count == 0)
            {
                Module.ShowMessage("Please select a Profile first !");
                return;
            }

            if (Module.ShowQuestionDialog("Are you sure that you want to Delete this Profile ?", TranslateHelper.Translate("Delete Profile ?"))
                == DialogResult.Yes)
            {                
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(Module.ProfilesFile);
                }
                catch
                {
                    Module.ShowMessage("Error. Could not read valid Profiles File !");
                    return;
                }

                XmlNode nod = doc.SelectSingleNode("//Profile[@name='" + SelectedCategoryProfileNames[lvProfile.SelectedIndices[0]].Name + "']");

                nod.ParentNode.RemoveChild(nod);

                doc.Save(Module.ProfilesFile);

                lvCategory_SelectedIndexChanged(null, null);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbAudioBitrate.Text = "";
            cmbAudioChannels.Text = "";
            cmbSampleRate.Text = "";
            cmbVideoAspectRatio.Text = "";
            cmbVideoBitrate.Text = "";
            cmbVideoFrameRate.Text = "";
            cmbVideoSize.Text = "";
            cmbVolume.Text = "";

            chkCopyMetadata.Checked = true;
            chkDeinterlace.Checked = false;
            chkMute.Checked = false;
            chkNormalize.Checked = false;
            chkTwoPass.Checked = false;

            txtFFMpeg1stPass.Text = "";
            txtFFMpeg2ndPass.Text = "";
            txtFFMpegAddParameters.Text = "";

        }

        private void btnFillInputValues_Click(object sender, EventArgs e)
        {
            FFMPEGInfo finfo = new FFMPEGInfo(frmMain.Instance.cmbVideoFile.Text);

            cmbVideoBitrate.Text = finfo.VideoBitRate.Replace(" kb/s", "k");
            cmbVideoFrameRate.Text = finfo.VideoFrameRate.Replace(" fps", "");

            tabControl1.TabPages[1].Show();

            cmbAudioBitrate.Text = finfo.AudioBitRate.Replace(" kb/s", "k");
            cmbSampleRate.Text = finfo.AudioSamplingRate;

            tabControl1.TabPages[0].Show();
        }
    }

    public class OutputFormatResult
    {
        public string outputext;
        public string outputparams;
        public string firstPassArgs;
        public string secondPassArgs;
        public string additionalArgs;
        public string videoBitRate;
        public string videoFrameRate;
        public string videoSize;
        public string videoAspectRatio;
        public bool videoTwoPass;
        public bool videoDeinterlace;
        public string audioBitRate;
        public string audioSampleRate;
        public string audioChannels;
        public string audioVolume;
        public bool audioNormalize;
        public bool audioMute;
        public bool copyMetadata;       
        
        public string mixVolume = "";        

        public string selectedProfile;
        public string selectedProfileCategory;

        public string extension;
        public string ffmpegParameters;

        public OutputFormatResult()
        {

        }
    }

    public class SelectedCategoryProfile
    {
        public string Label="";
        public string Name="";

        public SelectedCategoryProfile()
        {

        }
    }

    public class SelectedCategoryComparer : IComparer<SelectedCategoryProfile>
    {
        public int Compare(SelectedCategoryProfile x, SelectedCategoryProfile y)
        {
            int icompareLabel = x.Label.CompareTo(y.Label);

            return icompareLabel;
        }
    }    
}
