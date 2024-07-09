using System;
using System.Collections.Generic;

using System.Text;

using System.Windows.Forms;
using System.Diagnostics;

namespace VideoLooper
{
    public class ExifCopier
    {
        public static void ApplyVideoExifAndDates(string inputFilepath, string outputFilepath)
        {
            if (System.IO.File.Exists(outputFilepath))
            {                
                if (Properties.Settings.Default.CopyEXIF)
                {
                    System.Diagnostics.Process pr = new Process();
                    pr.StartInfo.FileName = "\"" + System.IO.Path.Combine(Application.StartupPath, "exiftool.exe") + "\"";
                    pr.StartInfo.Arguments = "-tagsfromfile \"" + inputFilepath + "\" -exif \"" + outputFilepath + "\"";

                    pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pr.StartInfo.UseShellExecute = true;
                    pr.Start();

                    while (!pr.HasExited)
                    {
                        Application.DoEvents();
                    }

                    if (System.IO.File.Exists(outputFilepath + "_original"))
                    {
                        try
                        {
                            System.IO.File.Delete(outputFilepath + "_original");
                        }
                        catch
                        {

                        }
                    }
                }

                if (Properties.Settings.Default.KeepCreationDate)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(inputFilepath);

                    System.IO.FileInfo fi2 = new System.IO.FileInfo(outputFilepath);

                    fi2.CreationTime = fi.CreationTime;

                    fi2.CreationTimeUtc = fi.CreationTimeUtc;
                }

                if (Properties.Settings.Default.KeepLastModDate)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(inputFilepath);

                    System.IO.FileInfo fi2 = new System.IO.FileInfo(outputFilepath);

                    fi2.LastWriteTime = fi.LastWriteTime;

                    fi2.LastWriteTimeUtc = fi.LastWriteTimeUtc;
                }
            }
        }
    }
}
