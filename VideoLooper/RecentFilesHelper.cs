using System;
using System.Collections.Generic;
using System.Text;

namespace VideoLooper
{
    class RecentFilesHelper
    {        
        public static void FillVideoFiles()
        {
            string[] str = Properties.Settings.Default.VideoFiles.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmMain.Instance.cmbVideoFile.Items.Add(str[k]);
            }
        }

        public static void FillBackgroundFiles()
        {
            string[] str = Properties.Settings.Default.BackgroundFiles.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmMain.Instance.cmbBackgroundFile.Items.Add(str[k]);
            }
        }                

        public static void AddRecentVideoFile(string filepath)
        {
            string[] str = Properties.Settings.Default.VideoFiles.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }

            strl.Insert(0, filepath);

            frmMain.Instance.cmbVideoFile.Items.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k <= 12; k++)
            {
                frmMain.Instance.cmbVideoFile.Items.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.VideoFiles = newrec;
        }

        public static void AddRecentBackgroundFile(string filepath)
        {
            string[] str = Properties.Settings.Default.BackgroundFiles.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }

            strl.Insert(0, filepath);

            frmMain.Instance.cmbBackgroundFile.Items.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k <= 12; k++)
            {
                frmMain.Instance.cmbBackgroundFile.Items.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.BackgroundFiles = newrec;
        } 

        public static List<string> ArrayToListString(string[] str)
        {
            List<string> strl = new List<string>();

            for (int k = 0; k < str.Length; k++)
            {
                strl.Add(str[k]);
            }

            return strl;
        }
    }
}
