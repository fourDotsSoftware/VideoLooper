using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace VideoLooper
{
    public partial class frmOptions : VideoLooper.CustomForm
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void btnInsertN_Click(object sender, EventArgs e)
        {
            txtFilename.Text += "[N]";
        }

        private void btnInsertDocFilename_Click(object sender, EventArgs e)
        {
            txtFilename.Text += "[DOC]";
        }

        private void btnInsertDate_Click(object sender, EventArgs e)
        {
            txtFilename.Text += "[DATE]";
        }

        private void btnInsertDateTime_Click(object sender, EventArgs e)
        {
            txtFilename.Text += "[DATETIME]";
        }

        private void frmOutputFilenamePattern_Load(object sender, EventArgs e)
        {
            txtFilename.Text = Properties.Settings.Default.FilenamePattern;

            chkOverwrite.Checked = Properties.Settings.Default.OverwriteExisting;

            rdPNG.Checked = Properties.Settings.Default.SaveImageFormat == 0;
            rdJPG.Checked = Properties.Settings.Default.SaveImageFormat == 1;
            rdGIF.Checked = Properties.Settings.Default.SaveImageFormat == 2;
            rdBMP.Checked = Properties.Settings.Default.SaveImageFormat == 3;

            nudJpegQuality.Value = Properties.Settings.Default.SaveJPEGQuality;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FilenamePattern = txtFilename.Text;

            Properties.Settings.Default.OverwriteExisting = chkOverwrite.Checked;

            Properties.Settings.Default.SaveImageFormat = rdPNG.Checked ? 0 : rdJPG.Checked ? 1 : rdGIF.Checked ? 2 : rdBMP.Checked ? 3 : 0;

            Properties.Settings.Default.SaveJPEGQuality = (int)nudJpegQuality.Value;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public static string GetSaveFilepath(string docfilepath,string outdir,int slidenr)
        {
            string fp = Properties.Settings.Default.FilenamePattern + GetImageExtension();

            System.IO.FileInfo fi = new System.IO.FileInfo(docfilepath);

            string sDate = fi.LastWriteTime.Year.ToString("D4") + fi.LastWriteTime.Month.ToString("D2") + fi.LastWriteTime.Day.ToString("D2");

            string sDateTime = fi.LastWriteTime.Year.ToString("D4") + fi.LastWriteTime.Month.ToString("D2") + fi.LastWriteTime.Day.ToString("D2")
                + "_" + fi.LastWriteTime.Hour.ToString("D4") + fi.LastWriteTime.Minute.ToString("D2") + fi.LastWriteTime.Second.ToString("D2");

            fp = fp.Replace("[DATE]", sDate).Replace("[DATETIME]", sDateTime).Replace("[DOC]", System.IO.Path.GetFileName(docfilepath));

            fp = fp.Replace("[N]", slidenr.ToString());

            string outfp = System.IO.Path.Combine(outdir, fp);            

            int k = 1;            
            
            if (Properties.Settings.Default.OverwriteExisting || !System.IO.File.Exists(outfp))
            {
                return outfp;
            }
            else
            {
                while (true)
                {
                    k++;

                    string outfp2 = System.IO.Path.Combine(outdir, System.IO.Path.GetFileNameWithoutExtension(fp) + " - " + k.ToString() + System.IO.Path.GetExtension(fp));

                    if (!System.IO.File.Exists(outfp2))
                    {
                        return outfp2;
                    }
                }
            }                     
        }

        private void nudJpegQuality_ValueChanged(object sender, EventArgs e)
        {
            tbJpegQuality.Value = (int)nudJpegQuality.Value;
        }

        private void tbJpegQuality_ValueChanged(object sender, EventArgs e)
        {
            nudJpegQuality.Value = tbJpegQuality.Value;
        }

        public static bool SaveImage(string filepath,Bitmap bmp)
        {
            if (Properties.Settings.Default.SaveImageFormat == 0)
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (Properties.Settings.Default.SaveImageFormat == 1)
            {
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.
                // An EncoderParameters object has an array of EncoderParameter
                // objects. In this case, there is only one
                // EncoderParameter object in the array.
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)Properties.Settings.Default.SaveJPEGQuality);
                    
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp.Save(filepath, jgpEncoder, myEncoderParameters);                
            }
            else if (Properties.Settings.Default.SaveImageFormat == 2)
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Gif);
            }
            else if (Properties.Settings.Default.SaveImageFormat == 3)
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Bmp);
            }

            return true;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static string GetImageExtension()
        {
            if (Properties.Settings.Default.SaveImageFormat == 0)
            {
                return ".png";
            }
            else if (Properties.Settings.Default.SaveImageFormat == 1)
            {
                return ".jpg";
            }
            else if (Properties.Settings.Default.SaveImageFormat == 2)
            {
                return ".gif";
            }
            else if (Properties.Settings.Default.SaveImageFormat == 3)
            {
                return ".bmp";
            }
            else
            {
                return ".bmp";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFilename.Text += "[SLIDENR]";
        }
    }
}
