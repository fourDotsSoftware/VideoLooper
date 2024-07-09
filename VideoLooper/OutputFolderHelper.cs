﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VideoLooper
{
    class OutputFolderHelper
    {
        public static void SaveOutputFolder(string folder)
        {
            if (folder == TranslateHelper.Translate("Subfolder of Video")
                || folder == TranslateHelper.Translate("Overwrite Video")
                || folder == TranslateHelper.Translate("Same Folder of Video")
                || folder == Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString()
                || folder.StartsWith("---------------------")
                || folder.Trim() == string.Empty
                )
            {
                return;
            }
            else if (!folder.StartsWith(TranslateHelper.Translate("Subfolder") + " : ")
                && !System.IO.Directory.Exists(folder))
            {
                return;
            }
            /*
            {                    
                try 
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(folder);
                }
                catch
                {
                    return;
                }
            }
            */

            List<string> lst = new List<string>();
            
            
            if (Properties.Settings.Default.OutputFolder1 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder1);
            }

            if (Properties.Settings.Default.OutputFolder2 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder2);
            }

            if (Properties.Settings.Default.OutputFolder3 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder3);
            }

            if (Properties.Settings.Default.OutputFolder4 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder4);
            }

            if (Properties.Settings.Default.OutputFolder5 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder5);
            }
            

            int lsi = lst.IndexOf(folder);

            if (lsi < 0)
            {
                lst.Insert(0, folder);
            }
            else
            {
                lst.RemoveAt(lsi);
                lst.Insert(0, folder);
            }

            int cmbc=frmMain.Instance.cmbOutputDir.Items.Count;
            for (int k = 5; k < cmbc; k++)
            {
                frmMain.Instance.cmbOutputDir.Items.RemoveAt(4);
            }

            for (int k = 0; k < 5 && k<lst.Count; k++)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(4 + k, lst[k]);
                                
                if (k == 0)
                {
                    Properties.Settings.Default.OutputFolder1 = lst[k];
                }
                else if (k == 1)
                {
                    Properties.Settings.Default.OutputFolder2 = lst[k];
                }
                if (k == 2)
                {
                    Properties.Settings.Default.OutputFolder3 = lst[k];
                }
                if (k == 3)
                {
                    Properties.Settings.Default.OutputFolder4 = lst[k];
                }
                if (k == 4)
                {
                    Properties.Settings.Default.OutputFolder5 = lst[k];
                }                               
            }

            frmMain.Instance.cmbOutputDir.SelectedIndex = 4;
        }

        public static void LoadOutputFolders()
        {
            int k = 4;

            if (Properties.Settings.Default.OutputFolder1 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++,Properties.Settings.Default.OutputFolder1);
            }

            if (Properties.Settings.Default.OutputFolder2 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++, Properties.Settings.Default.OutputFolder2);
            }

            if (Properties.Settings.Default.OutputFolder3 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++, Properties.Settings.Default.OutputFolder3);
            }

            if (Properties.Settings.Default.OutputFolder4 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++, Properties.Settings.Default.OutputFolder4);
            }

            if (Properties.Settings.Default.OutputFolder5 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++, Properties.Settings.Default.OutputFolder5);
            }
        }

        public static string CalculateOutputFile(string filepath, string outputext, string outputfolder,string filenamePattern)
        {            
            string outfp = "";

            string outfn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            outfn = filenamePattern.Replace("[FILENAME]", outfn) + outputext;

            if (outputfolder.Trim() == TranslateHelper.Translate("Same Folder of Video"))
            {
                outfp = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath), outfn);
            }
            else if (outputfolder.StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
            {
                int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                string subfolder = outputfolder.Substring(subfolderspos);

                outfp = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder, outfn);
            }
            else
            {
                outfp = System.IO.Path.Combine(outputfolder, outfn);

            }

            return outfp;
        }

    }
}
