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
    public partial class frmProfile : VideoLooper.CustomForm
    {
        private bool is_for_new = false;

        private string profileName = "";

        public frmProfile(string profile_name)
        {
            InitializeComponent();

            FillCategories();

            LoadProfile(profile_name);

            profileName = profile_name;
        }

        public frmProfile(bool for_new)            
        {
            InitializeComponent();

            FillCategories();

            is_for_new = for_new;
        }

        private void FillCategories()
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

            for (int k = 0; k < lst.Count; k++)
            {
                cmbCategory.Items.Add(lst[k]);
            }
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadProfile(string profile_name)
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

            XmlNode nod = doc.SelectSingleNode("//Profile[@name='" + profile_name + "']");

            if (nod == null)
            {
                Module.ShowMessage("Error. Could not find the settings of the selected Profile !");
                return;
            }

            txtFFMpegParameters.Text = nod.SelectSingleNode("ffmpeg_parameters").InnerText;
            txtLabel.Text = nod.SelectSingleNode("label").InnerText;
            txtProfileName.Text = nod.Attributes.GetNamedItem("name").Value;
            cmbCategory.Text = nod.SelectSingleNode("cat").InnerText;
            txtExtension.Text = nod.SelectSingleNode("ext").InnerText;

        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (txtProfileName.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a Profile Name !");
                return;
            }            
            
            bool is_alphanum = true;

            /*
            string profnam=txtProfileName.Text.Trim();
            for (int k=0;k<profnam.Length;k++)
            {
                if (profnam[k]!='-' && profnam[k]!='_' && !char.IsLetterOrDigit(profnam[k]))
                {
                    is_alphanum = false;
                    break;
                }
            }

            if (!is_alphanum)
            {
                Module.ShowMessage("Please enter only Letters and Numbers for the Profile Name !");
                return;
            }
            */

            string profile_name = txtProfileName.Text.Trim().Replace("'","");

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


            if (is_for_new)
            {
                XmlNode nopn=doc.SelectSingleNode("//Profile[@name='" + profile_name + "']");

                if (nopn != null)
                {
                    Module.ShowMessage("Another Profile already exists with the same Name !");
                    return;
                }
            }
            
            if (txtLabel.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a Profile Label !");
                return;
            }
                        
            if (txtExtension.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify an Output File Extension !");
                return;
            }

            bool is_alphanum_cat = true;
            
            string catnam = cmbCategory.Text.Trim().Replace("'","");

            if (catnam == string.Empty)
            {
                Module.ShowMessage("Please specify a Profile Category !");
                return;

            }
            /*
            for (int k = 0; k < catnam.Length; k++)
            {
                if (!char.IsLetterOrDigit(catnam[k]))
                {
                    is_alphanum_cat = false;
                    break;
                }
            }

            if (!is_alphanum_cat)
            {
                Module.ShowMessage("Please enter only Letters and Numbers for the Profile Category !");
                return;
            }
            */

            string exte = txtExtension.Text.Trim();

            if (exte.StartsWith(".") && exte.Length>1)
            {
                exte = exte.Substring(1);
            }
            
            if (!is_for_new)
            {
                XmlNode nopn = doc.SelectSingleNode("//Profile[@name='" + profileName + "']");
                nopn.SelectSingleNode("label").InnerText = txtLabel.Text;
                nopn.SelectSingleNode("ffmpeg_parameters").InnerText = txtFFMpegParameters.Text;
                nopn.SelectSingleNode("ext").InnerText = exte;
                nopn.SelectSingleNode("cat").InnerText = cmbCategory.Text;
                nopn.Attributes.GetNamedItem("name").Value = profile_name;
            }
            else
            {
                XmlNode nopn = (XmlNode)doc.CreateElement("Profile");
                XmlNode nod1 = (XmlNode)doc.CreateElement("label");
                XmlNode nod2 = (XmlNode)doc.CreateElement("cat");
                XmlNode nod3 = (XmlNode)doc.CreateElement("ext");
                XmlNode nod4 = (XmlNode)doc.CreateElement("ffmpeg_parameters");

                nod1.InnerText = txtLabel.Text.Trim();
                nod2.InnerText = cmbCategory.Text.Trim();
                nod3.InnerText = exte;
                nod4.InnerText = txtFFMpegParameters.Text;

                nopn.AppendChild(nod1);
                nopn.AppendChild(nod2);
                nopn.AppendChild(nod3);
                nopn.AppendChild(nod4);

                XmlAttribute noat = doc.CreateAttribute("name");
                noat.Value = txtProfileName.Text.Trim();

                nopn.Attributes.Append(noat);

                XmlNode noprofi = doc.SelectSingleNode("//Profiles");

                noprofi.AppendChild(nopn);
            }

            try
            {
                doc.Save(Module.ProfilesFile);

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                Module.ShowMessage("Error. Could not Save Profiles Settings File !");
                return;
            }            
        }
    }
}
