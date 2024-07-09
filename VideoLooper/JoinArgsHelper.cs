using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace VideoLooper
{
    public class FFMpegArgsCreator
    {
        public FFMpegArgsCreator()
        {

        }



        /*
        public JoinArgs GetJoinArgs(string filepath, OutputFormatResult res,  bool timeWasSet, string startTime, string endTime)
        {

            JoinArgs jargs = GetJoinArgs(filepath, res.extension,
            res.ffmpegParameters,
            res.firstPassArgs,
            res.secondPassArgs,
            res.videoBitRate,
            res.videoFrameRate,
            res.videoSize,
            res.videoAspectRatio,
            res.videoTwoPass,
            res.videoDeinterlace,
            res.audioBitRate,
            res.audioSampleRate,
            res.audioChannels,
            res.audioVolume,
            res.audioNormalize,
            res.audioMute,
            res.copyMetadata,
            timeWasSet, startTime, endTime);


            jargs.OutputFormatResult = res;

            return jargs;
        }        
        */



        /* REMOVE COMMENTS 16.11.2017
        public JoinArgs GetJoinArgs(OutputFormatResult res)
        {            
            return GetJoinArgsDifferentType(res);
            
        }
        */

        public string GetJoinFilePrefix(string filepath, string ext, string prefix)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (System.IO.File.Exists(jfp))
            {
                int k = 1;
                bool found = false;

                while (!found)
                {
                    jfp = System.IO.Path.Combine(outfolder,
                        prefix.Replace("[N]", k.ToString()) + joinfile + ext);

                    if (!System.IO.File.Exists(jfp))
                    {
                        return jfp;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            else
            {
                return jfp;
            }

            return "-1";
        }
        public string GetJoinFileSuffix(string filepath, string ext, string suffix)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (System.IO.File.Exists(jfp))
            {
                int k = 1;
                bool found = false;

                while (!found)
                {
                    jfp = System.IO.Path.Combine(outfolder,
                        joinfile + suffix.Replace("[N]", k.ToString()) + ext);

                    if (!System.IO.File.Exists(jfp))
                    {
                        return jfp;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            else
            {
                return jfp;
            }

            return "-1";
        }

        public string GetJoinFileSkip(string filepath, string ext)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (!System.IO.File.Exists(jfp))
            {
                return jfp;
            }
            else
            {
                return "-1";
            }

        }


    }


    public class JoinArgs
    {
        public string Args = "";

        //public List<string> CropOutputFilepaths = new List<string>();
        //public List<string> OverlayOutputFilepaths = new List<string>();

        public string CropOutputFilepath = "";
        public string OverlayCutOutputFilepath = "";
        public string OverlayOutputFilepath = "";

        public string NonZoomPartsFilepathStart = "";
        public string NonZoomPartsFilepathEnd = "";

        public string ArgsCrop = "";
        public string ArgsOverlayCut = "";
        public string ArgsOverlay = "";

        public string NonZoomPartsArgsStart = "";
        public string NonZoomPartsArgsEnd = "";

        public List<string> ResizeOutputFilepaths = new List<string>();
        public List<string> FadeOutputFilepaths = new List<string>();
        public List<string> ResizeFadeOutputArgs = new List<string>();



        public string AudioVolumeArgs = "";
        public string AudioVolumeArgsNoNormalize = "";
        public string AudioVolumeFile = "";



        public string DeinterlaceArgs = "";
        public string DeinterlaceFile = "";

        public int DurationMsecs = 0;
        public string JoinFile = "";

        

        public OutputFormatResult OutputFormatResult = null;
    }
}