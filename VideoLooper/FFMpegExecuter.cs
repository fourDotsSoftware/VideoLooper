using System;
using System.Collections.Generic;

using System.Text;

using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace VideoLooper
{
    public class FFMpegExecuter
    {
        private FFMpegArgs FFMpegArgs = null;
        private string FirstOutputFile = "";

        public string OutputFile = "";
        private string Err = "";

        private bool OperationStopped = false;
        private bool OperationPaused = false;

        
        private BackgroundWorker bwConvert = new BackgroundWorker();

        public Process psFFMpeg = null;
        public frmProgress frmProgress = null;

        public frmMain frmMain = null;

        private ShutdownHelper ShutdownHelper = null;

        public bool ConversionStopped = false;
        public bool ConversionStarted = false;
        public bool ConversionPaused = false;
        public int ConversionProgressTime = 0;

        public int CompletedSecs = -1;

        private string LastFFMpegOutput = "";

        private int beforeCompletedSecs = 0;

        private bool time_str_found = false;

        private string last_line = "";

        public FFMpegExecuter(FFMpegArgs ffmpegArgs,frmMain frmmain,int whenFinishedIndex)
        {
            FFMpegArgs = ffmpegArgs;

            bwConvert.DoWork += bwConvert_DoWork;
            bwConvert.RunWorkerCompleted += bwConvert_RunWorkerCompleted;
            bwConvert.ProgressChanged += bwConvert_ProgressChanged;
            bwConvert.WorkerReportsProgress = true;
            bwConvert.WorkerSupportsCancellation = true;            

            frmMain = frmmain;

            frmProgress = new frmProgress(this);

            ShutdownHelper = new ShutdownHelper();
            ShutdownHelper.WhenFinishedIndex = whenFinishedIndex;
            ShutdownHelper.OutputFile = ffmpegArgs.FirstOutputFile;

        }

        public void Execute()
        {
            try
            {
                frmProgress.Show(frmMain);
                frmProgress.timTime.Enabled = true;
                frmMain.Enabled = false;

                ConversionStopped = false;
                ConversionStarted = true;
                Err = "";
                FirstOutputFile = "";

                CompletedSecs = 0;
                beforeCompletedSecs = 0;

                frmProgress.progressBar1.Maximum = FFMpegArgs.TotalDurationMsecs;
                frmProgress.progressBar1.Value = 0;
                frmProgress.lblOutputFile.Text = System.IO.Path.GetFileName(FFMpegArgs.FirstOutputFile);

                for (int k = 0; k < FFMpegArgs.Args.Count; k++)
                {
                    if (ConversionStopped) return;

                    while (ConversionPaused)
                    {
                        if (ConversionStopped) return;

                        Application.DoEvents();
                    }

                    CreateFFMpegProcess();

                    psFFMpeg.StartInfo.Arguments = FFMpegArgs.Args[k];

                    bwConvert.RunWorkerAsync();

                    while (bwConvert.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    beforeCompletedSecs = CompletedSecs;
                }

                if (FFMpegArgs.NormalizeArgs1 != string.Empty)
                {
                    while (ConversionPaused)
                    {
                        if (ConversionStopped) return;

                        Application.DoEvents();
                    }

                    Module.MoveFile(OutputFile, FFMpegArgs.NormalizeFile);

                    CreateFFMpegProcess();

                    psFFMpeg.StartInfo.Arguments = FFMpegArgs.NormalizeArgs1;

                    bwConvert.RunWorkerAsync();

                    while (bwConvert.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    FFMpegArgs.NormalizeArgs2 = FFMpegArgs.GetNormalizeArgs(FFMpegArgs.NormalizeArgs2, LastFFMpegOutput);

                    if (FFMpegArgs.NormalizeArgs2 != string.Empty)
                    {
                        while (ConversionPaused)
                        {
                            if (ConversionStopped) return;

                            Application.DoEvents();
                        }

                        if (ConversionStopped) return;

                        CreateFFMpegProcess();

                        psFFMpeg.StartInfo.Arguments = FFMpegArgs.NormalizeArgs2 + " \"" + OutputFile + "\"";

                        bwConvert.RunWorkerAsync();

                        while (bwConvert.IsBusy)
                        {
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        // no need to normalize use the joinnofilter file and the proper args

                        //res.AudioVolumeArgs = res.AudioVolumeArgsNoNormalize;

                        while (ConversionPaused)
                        {
                            if (ConversionStopped) return;

                            Application.DoEvents();
                        }

                        if (ConversionStopped) return;

                        Module.MoveFile(FFMpegArgs.NormalizeFile, OutputFile);

                        FFMpegArgs.NormalizeFile = "";
                    }
                }

                if (FFMpegArgs.JoinFileWithNoFilter != string.Empty)
                {
                    while (ConversionPaused)
                    {
                        if (ConversionStopped) return;

                        Application.DoEvents();
                    }

                    if (ConversionStopped) return;

                    Module.MoveFile(FFMpegArgs.FirstOutputFile, FFMpegArgs.JoinFileWithNoFilter);

                    CreateFFMpegProcess();

                    psFFMpeg.StartInfo.Arguments = FFMpegArgs.JoinArgsWithNoFilter + " \"" + OutputFile + "\"";

                    bwConvert.RunWorkerAsync();

                    while (bwConvert.IsBusy)
                    {
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                Err += ex.Message;
            }
            finally
            {
                Finish();
            }
        }

        private void Finish()
        {            
            try
            {
                ExifCopier.ApplyVideoExifAndDates(FFMpegArgs.VideoFile, FirstOutputFile);

                //System.Threading.Thread.Sleep(1500);

                for (int k = 0; k < Module.FilesToDelete.Count; k++)
                {
                    try
                    {
                        if (System.IO.File.Exists(Module.FilesToDelete[k]))
                        {
                            try
                            {
                                //System.Threading.Thread.Sleep(1500);
                                //System.Threading.Thread.Sleep(300);

                                File.SetAttributes(Module.FilesToDelete[k], FileAttributes.Normal);

                                System.IO.File.Delete(Module.FilesToDelete[k]);

                            }
                            catch { }
                        }
                    }
                    catch { }
                }

                Module.FilesToDelete.Clear();

                //timJoinVideos.Enabled = false;
                this.ConversionProgressTime = 0;
                this.ConversionStarted = false;
                //8OutputFileActionRepeat = false;                    

                if (frmProgress != null && frmProgress.Visible)
                {
                    frmProgress.Close();
                }

                frmMain.Enabled = true;

                if (!ConversionStopped)
                {
                    if (Err == string.Empty)
                    {
                        ShutdownHelper.ProcessWhenFinished();
                    }

                    if (Err != String.Empty)
                    {
                        if (System.IO.File.Exists(FirstOutputFile))
                        {
                            frmError fer = new frmError(TranslateHelper.Translate("Output Video was produced but operation was completed with Errors !"), Err);
                            fer.ShowDialog(frmMain);
                        }
                        else
                        {
                            frmError fer = new frmError(TranslateHelper.Translate("Operation completed with Errors !"), Err);
                            fer.ShowDialog(frmMain);
                        }
                        //Module.ShowMessage(TranslateHelper.Translate("Operation completed with Errors !") + "\n\n" + errstr);
                    }
                    else
                    {
                        if (Properties.Settings.Default.ShowMsgOnSuccess)
                        {
                            Module.ShowMessage("Operation completed successfully !");
                        }
                    }
                }
                else
                {
                    Module.ShowMessage("Operation stopped !");
                }

                if (FFMpegArgs.NormalizeFile != string.Empty)
                {
                    try
                    {
                        if (System.IO.File.Exists(FFMpegArgs.NormalizeFile))
                        {
                            System.IO.File.Delete(FFMpegArgs.NormalizeFile);
                        }
                    }
                    catch
                    {
                        Err += TranslateHelper.Translate("Error. Could not Delete File") + " : " + FFMpegArgs.NormalizeFile + "\n\n";
                    }
                }

                if (FFMpegArgs.JoinFileWithNoFilter != string.Empty)
                {
                    try
                    {
                        if (System.IO.File.Exists(FFMpegArgs.JoinFileWithNoFilter))
                        {
                            System.IO.File.Delete(FFMpegArgs.JoinFileWithNoFilter);
                        }
                    }
                    catch
                    {
                        Err += TranslateHelper.Translate("Error. Could not Delete File") + " : " + FFMpegArgs.JoinFileWithNoFilter + "\n\n";
                    }
                }

                /*
                    if (Properties.Settings.Default.OFTwoPass)
                    {
                        CreateFFMpegProcess();

                        psFFMpeg.StartInfo.Arguments = lstArgs[m] + " -pass 1 " + Properties.Settings.Default.OF1stPassParameters + " NUL ";

                        bwConvert.RunWorkerAsync();

                        while (bwConvert.IsBusy)
                        {
                            Application.DoEvents();
                        }

                        if (ConversionStopped) return;

                        CreateFFMpegProcess();

                        psFFMpeg.StartInfo.Arguments = lstArgs[m] + " -pass 2 " + Properties.Settings.Default.OF2ndPassParameters + " \"" + joinFile + "\"";

                        bwConvert.RunWorkerAsync();

                        while (bwConvert.IsBusy)
                        {
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        if (ConversionStopped) return;

                        CreateFFMpegProcess();

                        //Clipboard.Clear();
                        //Clipboard.SetText(res.Args + " \"" + res.JoinFile + "\"");

                        psFFMpeg.StartInfo.Arguments = lstArgs[m] + " \"" + joinFile + "\"";

                        bwConvert.RunWorkerAsync();

                        while (bwConvert.IsBusy)
                        {
                            Application.DoEvents();
                        }
                    }

                    if (ConversionStopped) return;
                }
                */
            }
            catch (Exception ex)
            {
                Module.ShowError("Error", ex);
            }
        }

        public void PauseExecution()
        {
            if (!psFFMpeg.HasExited)
            {
                SuspendResumeThread.SuspendProcess(psFFMpeg.Id);
                ConversionPaused = true;
                ConversionStarted = false;
                //timJoinVideos.Enabled = false;

                if (frmProgress != null)
                {
                    frmProgress.btnPause.Image = Properties.Resources.flash1;
                    frmProgress.btnPause.Text = TranslateHelper.Translate("Resume");
                    frmProgress.timTime.Enabled = false;
                }
            }
        }

        public void ResumeExecution()
        {
            ConversionStarted = true;
            ConversionPaused = true;
            //timJoinVideos.Enabled = true;
            SuspendResumeThread.ResumeProcess(psFFMpeg.Id);

            if (frmProgress != null)
            {
                frmProgress.btnPause.Image = Properties.Resources.media_pause;
                frmProgress.btnPause.Text = TranslateHelper.Translate("Pause");
                frmProgress.timTime.Enabled = true;
            }
        }

        private void CreateFFMpegProcess()
        {
            System.Threading.Thread.Sleep(300);

            try
            {
                if (psFFMpeg != null) // && psFFMpeg.SynchronizingObject!=null &&  !psFFMpeg.HasExited)
                {
                    // psFFMpeg.Kill();
                }
            }
            catch { }

            System.Threading.Thread.Sleep(300);

            psFFMpeg = new Process();

            //psFFMpeg.StartInfo.FileName = "ffmpeg ";
            if (Properties.Settings.Default.FFMPEG64Bit == 1)
            {
                psFFMpeg.StartInfo.FileName = "ffmpeg64 ";
            }
            else
            {
                psFFMpeg.StartInfo.FileName = "ffmpeg32 ";
            }

            psFFMpeg.StartInfo.CreateNoWindow = true;
            psFFMpeg.StartInfo.UseShellExecute = false;
            psFFMpeg.StartInfo.RedirectStandardError = true;
            psFFMpeg.StartInfo.RedirectStandardOutput = true;

            psFFMpeg.OutputDataReceived += psFFMpeg_OutputDataReceived;
            psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;

            psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //System.Threading.Thread.Sleep(500);            
        }

        void psFFMpeg_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string line = e.Data;

            Console.WriteLine(line);

            if (line != null)
            {
                last_line = line;
            }

            LastFFMpegOutput += line + "\r\n";

            Application.DoEvents();

            if (line != null && line.Contains("time="))
            {
                time_str_found = true;

                try
                {
                    int spos = line.LastIndexOf("time=") + "time=".Length;
                    int epos = line.IndexOf(" ", spos);

                    string time = line.Substring(spos, epos - spos + 1);

                    //0sw.WriteLine("time=" + time);

                    TimeSpan ts = new TimeSpan(int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(3, 2)),
                        int.Parse(time.Substring(6, 2)));

                    int completed_secs = (int)ts.TotalSeconds;
                    int msecs = int.Parse(time.Substring(9, 1));

                    //0sw.WriteLine("parsed time="+ts.ToString() + "." + msecs.ToString());

                    //0sw.WriteLine("before completed secs=" + CompletedSecs.ToString());

                    CompletedSecs = beforeCompletedSecs + (completed_secs * 10 + msecs);                    

                    //0sw.WriteLine("completed secs="+CompletedSecs.ToString());

                    //int totalsex = LastCutArgs.TotalDuration / 10;

                    //1int progress = (int)((decimal)CompletedSecs * 100 / (decimal)(LastCutArgs.TotalDuration));

                    //1bwConvert.ReportProgress(progress);
                    bwConvert.ReportProgress(0, CompletedSecs);
                }
                catch { }

            }
            else if (line != null && line.ToLower().StartsWith("error"))
            {
                if (!time_str_found)
                {
                    Err += line;
                }
            }
        }

        void psFFMpeg_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Console.WriteLine("OUTPUT:"+e.Data);
        }

        void bwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if no time= string was found this means that an error occured
            if (!time_str_found)
            {
                Err += last_line;
            }
        }

        void bwConvert_DoWork(object sender, DoWorkEventArgs e)
        {
            //0sw.WriteLine("ARGS=");
            //0sw.WriteLine(psFFMpeg.StartInfo.Arguments);

            LastFFMpegOutput = "";

            beforeCompletedSecs = CompletedSecs;

            time_str_found = false;

            last_line = "";

            Console.WriteLine("ARGS=" + psFFMpeg.StartInfo.Arguments);

            psFFMpeg.Start();

            psFFMpeg.BeginErrorReadLine();
            psFFMpeg.BeginOutputReadLine();

            psFFMpeg.WaitForExit();

            psFFMpeg.Close();

            psFFMpeg.Dispose();

            psFFMpeg = null;

            /*
            if (!time_str_found)
            {
                errstr += last_line;
            }*/

        }

        void bwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int pg = (int)e.UserState;

            /*1
            if (pg >= 0 && pg <= pbarCut.Maximum)
            {
                pbarCut.Value = pg;
            }
            */

            if (frmProgress != null && frmProgress.Visible)
            {
                if (pg >= 0 && pg <= frmProgress.progressBar1.Maximum)
                {
                    frmProgress.progressBar1.Value = pg;

                    decimal d1 = (decimal)frmProgress.progressBar1.Value;
                    decimal d2 = (decimal)frmProgress.progressBar1.Maximum;

                    decimal dprog = (d1 / d2) * 100;

                    int iprog = (int)dprog;

                    frmProgress.progressBar1.lblText = iprog.ToString() + "%";

                    int totalprog = frmProgress.PreviousTotalProgress + pg;

                    if (totalprog >= 0 && totalprog <= frmProgress.pbarTotal.Maximum)
                    {
                        frmProgress.pbarTotal.Value = totalprog;

                        decimal dt1 = (decimal)frmProgress.pbarTotal.Value;
                        decimal dt2 = (decimal)frmProgress.pbarTotal.Maximum;

                        decimal dtprog = (dt1 / dt2) * 100;

                        int itprog = (int)dtprog;

                        frmProgress.pbarTotal.lblText = itprog.ToString() + "%";
                    }
                }
            }
        }
    }

    public class FFMpegArgs
    {
        public List<string> Args = new List<string>();

        public string VideoFile = "";
        public string BackgroundFile = "";
        public string outputext = "";
        public string outputparams = "";
        public string firstPassArgs = "";
        public string secondPassArgs = "";
        public string videoBitRate = "";
        public string videoFrameRate = "";
        public string videoSize = "";
        public string videoAspectRatio = "";
        public bool videoTwoPass = false;
        public bool videoDeinterlace = false;
        public string audioBitRate = "";
        public string audioSampleRate = "";
        public string audioChannels = "";
        public string audioVolume = "";
        public bool audioNormalize = false;
        public bool audioMute = false;
        public bool copyMetadata = true;
        public string totalDuration = "";
        public int durationMsecs = 0;
        public string AdditionalParameters = "";
        public string OutputFolder = "";        

        public string backgroundAudioVolume = "";

        public int LoopType = 0;

        public int LoopNumberOfTimes = 0;

        public int WhenFinishedIndex = -1;

        public string FirstOutputFile = "";

        public string NormalizeArgs1 = "";
        public string NormalizeArgs2 = "";
        public string NormalizeFile = "";

        public string JoinArgsWithNoFilter = "";
        public string JoinFileWithNoFilter = "";

        public List<string> InputVideoFiles = new List<string>();

        public int DurationMsecs = 0;
        public int BackgroundAudioDurationMsecs = 0;
        public int TotalDurationMsecs = 0;
        public int LoopDurationMsecs = 0;

        public bool VideoHasAudio = true;

        public FFMpegArgs()
        {
        }


        public string GetSampleRate(string sample_rate)
        {
            try
            {
                return sample_rate.ToLower().Replace("khz", "").Replace("hz", "");
            }
            catch
            {
                return "";
            }
        }

        public string GetFrameRate(string frame_rate)
        {
            try
            {
                int spos = frame_rate.IndexOf("(");

                if (spos >= 0)
                {
                    int epos = frame_rate.IndexOf(")", spos);

                    frame_rate = frame_rate.Substring(0, spos) + frame_rate.Substring(epos + 1);
                }

                frame_rate = frame_rate.Replace("fps", "").Trim();

                return frame_rate;
            }
            catch
            {
                return "";
            }
        }

        public string GetVideoSize(string video_size)
        {
            try
            {
                if (video_size.IndexOf("(") >= 0)
                {
                    int spos = video_size.IndexOf("(");
                    int epos = video_size.IndexOf(")", spos);

                    video_size = video_size.Substring(spos + 1, epos - spos - 1);
                }

                return video_size.Replace("*", "x");
            }
            catch
            {
                return "";
            }
        }

        public bool GetOutputFormat()
        {
            frmOutputFormat fo = new frmOutputFormat();

            if (fo.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            this.outputext = fo.Extension;
            this.outputparams = fo.FFMpegParameters + " " + Properties.Settings.Default.OFAdditionalParameters;

            return true;
        }

        public FFMpegArgs InitializeFFMpegArgs()
        {
            try
            {                                
                FFMpegArgs ffmpegArgs = this;

                if (ffmpegArgs.videoBitRate != string.Empty) ffmpegArgs.outputparams += " -b:v " + ffmpegArgs.videoBitRate;
                if (ffmpegArgs.videoFrameRate != string.Empty) ffmpegArgs.outputparams += " -r " + GetFrameRate(ffmpegArgs.videoFrameRate);
                if (ffmpegArgs.videoSize != string.Empty) ffmpegArgs.outputparams += " -s " + GetVideoSize(ffmpegArgs.videoSize);
                if (ffmpegArgs.videoAspectRatio != string.Empty) ffmpegArgs.outputparams += " -aspect " + ffmpegArgs.videoAspectRatio;
                if (ffmpegArgs.audioBitRate != string.Empty) ffmpegArgs.outputparams += " -b:a " + ffmpegArgs.audioBitRate;
                if (ffmpegArgs.audioSampleRate != string.Empty) ffmpegArgs.outputparams += " -ar " + GetSampleRate(ffmpegArgs.audioSampleRate);
                if (ffmpegArgs.audioChannels != string.Empty) ffmpegArgs.outputparams += " -ac " + ffmpegArgs.audioChannels;
                //3if (ffmpegArgs.audioMute) ffmpegArgs.outputparams += " -an ";

                string metadata_args = "";

                if (ffmpegArgs.outputext == ".gif")
                {
                    ffmpegArgs.BackgroundFile = "";
                    ffmpegArgs.audioMute = true;
                }

                if (ffmpegArgs.copyMetadata) metadata_args = " -map_metadata 0 ";

                string outputparams_original = ffmpegArgs.outputparams;

                bool has_filter_params = HasParameter("-vf", ffmpegArgs.outputparams);

                ffmpegArgs.outputparams = RemoveVideoAudioFilterArgsFromArgs(ffmpegArgs.outputparams);

                string fv = GetVideoFilterArgs(outputparams_original);

                string fa = GetAudioFilterArgs(outputparams_original);

                //3string fargs = " -vf \"";

                string audioVolumeParams = "";

                if (ffmpegArgs.audioVolume != string.Empty)
                {
                    if (ffmpegArgs.audioVolume.IndexOf("%") > 0)
                    {
                        ffmpegArgs.audioVolume = ffmpegArgs.audioVolume.Replace("%", "");

                        decimal decVol1 = decimal.Parse(ffmpegArgs.audioVolume);
                        decimal decVol2 = (decimal)100;
                        decimal decVol = decVol1 / decVol2;

                        audioVolumeParams += "volume=" + decVol.ToString() + "";
                    }
                    else
                    {
                        audioVolumeParams += "volume=" + ffmpegArgs.audioVolume + "";
                    }
                }
                else
                {
                    audioVolumeParams += "volume=1";
                }

                if (ffmpegArgs.audioMute)
                {
                    audioVolumeParams = "volume=0";
                }

                string audioVolumeParamsBack = "";

                if (ffmpegArgs.backgroundAudioVolume != string.Empty)
                {
                    if (ffmpegArgs.backgroundAudioVolume.IndexOf("%") > 0)
                    {
                        ffmpegArgs.backgroundAudioVolume = ffmpegArgs.backgroundAudioVolume.Replace("%", "");

                        decimal decVol1 = decimal.Parse(ffmpegArgs.backgroundAudioVolume);
                        decimal decVol2 = (decimal)100;
                        decimal decVol = decVol1 / decVol2;

                        audioVolumeParamsBack += "volume=" + decVol.ToString() + "";
                    }
                    else
                    {
                        audioVolumeParamsBack += "volume=" + ffmpegArgs.backgroundAudioVolume + "";
                    }
                }
                else
                {
                    audioVolumeParamsBack += "volume=1";
                }

                string deinterlaceParams = "";

                if (ffmpegArgs.videoDeinterlace)
                {
                    deinterlaceParams = ",yadif";
                }

                audioVolumeParams += deinterlaceParams;
                                                                

                //3string args = " -ss " + startTime + " -t " + duration + " -i \"" + filepath + "\" ";
                /*
                string fn = "";
                string joinfile = "";
                string outfolder = System.IO.Path.GetDirectoryName(ffmpegArgs.VideoFile);

                outfolder = ffmpegArgs.OutputFolder;

                fn = System.IO.Path.GetFileNameWithoutExtension(ffmpegArgs.VideoFile);

                joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

                ffmpegArgs.FirstOutputFile = System.IO.Path.Combine(outfolder, joinfile + ffmpegArgs.outputext);
                */

                ffmpegArgs.FirstOutputFile = OutputFolderHelper.CalculateOutputFile(
                    ffmpegArgs.VideoFile, ffmpegArgs.outputext, Properties.Settings.Default.OutputFolder,
                    Properties.Settings.Default.OutputFilenamePattern);

                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(ffmpegArgs.FirstOutputFile)))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(ffmpegArgs.FirstOutputFile));
                    }
                    catch
                    {
                        Module.ShowMessage("Error could not create Output Folder !");

                        return null;
                    }

                }

                int numloop = 0;
                string additionalSecs = "";
                int addmsecs = 0;

                int numloopback = 0;
                string additionalSecsBack = "";
                int addmsecsback = 0;

                ffmpegArgs.TotalDurationMsecs = 0;

                if (ffmpegArgs.LoopType == 2)
                {
                    ffmpegArgs.LoopDurationMsecs = ffmpegArgs.LoopNumberOfTimes * ffmpegArgs.DurationMsecs;

                    ffmpegArgs.LoopType = 0;
                }

                if (ffmpegArgs.LoopType==1)
                {
                    if (ffmpegArgs.DurationMsecs >= ffmpegArgs.BackgroundAudioDurationMsecs)
                    {
                        numloop = 0;

                        additionalSecs = TimeUpDownControl.MsecsToSecsString(ffmpegArgs.BackgroundAudioDurationMsecs);

                        addmsecs = ffmpegArgs.BackgroundAudioDurationMsecs;
                    }
                    else
                    {
                        numloop = ffmpegArgs.BackgroundAudioDurationMsecs / ffmpegArgs.DurationMsecs;

                        addmsecs = ffmpegArgs.BackgroundAudioDurationMsecs % ffmpegArgs.DurationMsecs;

                        additionalSecs = TimeUpDownControl.MsecsToSecsString(addmsecs);
                    }
                }
                else
                {
                    if (ffmpegArgs.LoopDurationMsecs < ffmpegArgs.DurationMsecs)
                    {
                        numloop = 0;

                        additionalSecs = TimeUpDownControl.MsecsToSecsString(ffmpegArgs.LoopDurationMsecs);

                        addmsecs += ffmpegArgs.LoopDurationMsecs;
                    }
                    else
                    {
                        numloop = ffmpegArgs.LoopDurationMsecs / ffmpegArgs.DurationMsecs;

                        addmsecs = ffmpegArgs.LoopDurationMsecs % ffmpegArgs.DurationMsecs;

                        additionalSecs = TimeUpDownControl.MsecsToSecsString(addmsecs);
                    }

                    if (ffmpegArgs.BackgroundAudioDurationMsecs > 0)
                    {
                        if (ffmpegArgs.LoopDurationMsecs < ffmpegArgs.BackgroundAudioDurationMsecs)
                        {
                            numloopback = 0;

                            additionalSecsBack = TimeUpDownControl.MsecsToSecsString(ffmpegArgs.LoopDurationMsecs);

                            addmsecsback = ffmpegArgs.LoopDurationMsecs;
                        }
                        else
                        {
                            numloopback = ffmpegArgs.LoopDurationMsecs / ffmpegArgs.BackgroundAudioDurationMsecs;

                            addmsecsback = ffmpegArgs.LoopDurationMsecs % ffmpegArgs.BackgroundAudioDurationMsecs;

                            additionalSecsBack = TimeUpDownControl.MsecsToSecsString(addmsecsback);
                        }
                    }

                }

                string addfile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + outputext);

                string addfileBack = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

                string safile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + outputext);

                if (additionalSecs != string.Empty && addmsecs > 500)
                {
                    if ((ffmpegArgs.BackgroundFile != string.Empty) || (numloop != 0))
                    {
                        //string sa = " -t " + additionalSecs + " -i \"" + ffmpegArgs.VideoFile + "\" " + ffmpegArgs.outputparams + metadata_args + " \"" + addfile + "\"";

                        string sa = " -t " + additionalSecs + " -i \"" + ffmpegArgs.VideoFile + "\" " + outputparams_original + metadata_args + " \"" + addfile + "\"";

                        Module.FilesToDelete.Add(addfile);

                        ffmpegArgs.Args.Add(sa);

                        ffmpegArgs.TotalDurationMsecs += addmsecs;
                    }
                    else
                    {
                        //string sa = " -t " + additionalSecs + " -i \"" + ffmpegArgs.VideoFile + "\" " + ffmpegArgs.outputparams + metadata_args + " \"" + ffmpegArgs.FirstOutputFile + "\"";

                        string sa = " -t " + additionalSecs + " -i \"" + ffmpegArgs.VideoFile + "\" " + outputparams_original + metadata_args + " \"" + ffmpegArgs.FirstOutputFile + "\"";

                        ffmpegArgs.Args.Add(sa);

                        ffmpegArgs.TotalDurationMsecs += addmsecs;
                    }
                }

                if (additionalSecsBack != string.Empty && addmsecsback > 500)
                {
                    string sa = " -t " + additionalSecsBack + " -i \"" + ffmpegArgs.BackgroundFile + "\" \"" + addfileBack + "\"";

                    Module.FilesToDelete.Add(addfileBack);

                    ffmpegArgs.Args.Add(sa);

                    ffmpegArgs.TotalDurationMsecs += addmsecsback;
                }

                if (numloop != 0)
                {
                    string sa = "";

                    for (int k = 0; k < numloop; k++)
                    {
                        string vfile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + System.IO.Path.GetExtension(ffmpegArgs.VideoFile));

                        System.IO.File.Copy(ffmpegArgs.VideoFile, vfile);

                        Module.FilesToDelete.Add(vfile);

                        sa += " -i \"" + vfile + "\" ";

                        ffmpegArgs.TotalDurationMsecs += ffmpegArgs.DurationMsecs;
                    }

                    if (additionalSecs != string.Empty && addmsecs > 500)
                    {
                        sa += " -i \"" + addfile + "\" ";

                        Module.FilesToDelete.Add(addfile);

                        ffmpegArgs.TotalDurationMsecs += addmsecs;
                    }

                    sa += " -filter_complex \"";

                    if (additionalSecs != string.Empty && addmsecs > 500)
                    {
                        numloop += 1;
                    }

                    if (ffmpegArgs.VideoHasAudio && !ffmpegArgs.audioMute)
                    {
                        for (int k = 0; k < numloop; k++)
                        {
                            sa += "[" + k.ToString() + ":v:0]"+(fv==string.Empty?"copy":fv)+"[v"+k.ToString()+"];[" + k.ToString() + ":a:0]"+(fa==string.Empty?"acopy":fa)+"[a"+k.ToString()+"];";
                        }

                        for (int k = 0; k < numloop; k++)
                        {
                            sa+="[v" + k.ToString() + "][a" + k.ToString() + "]";
                        }
                        /*
                        for (int k = 0; k < numloop; k++)
                        {
                            sa += "[" + k.ToString() + ":v:0][" + k.ToString() + ":a:0]";
                        }
                        */

                        if (ffmpegArgs.BackgroundFile != string.Empty)
                        {
                            sa += "concat=n=" + (numloop).ToString() + ":v=1:a=1[v][a]\" -map \"[v]\" -map \"[a]\" -y " +
                                 ffmpegArgs.outputparams + metadata_args + " \"" + safile + "\"";

                            ffmpegArgs.Args.Add(sa);

                            Module.FilesToDelete.Add(safile);
                        }
                        else
                        {
                            sa += "concat=n=" + (numloop).ToString() + ":v=1:a=1[v][a]\" -map \"[v]\" -map \"[a]\" -y " +
                                 ffmpegArgs.outputparams + metadata_args + " \"" + ffmpegArgs.FirstOutputFile + "\"";

                            ffmpegArgs.Args.Add(sa);
                        }
                    }
                    else
                    {
                        /*
                        for (int k = 0; k < numloop; k++)
                        {
                            sa += "[" + k.ToString() + ":v:0]";
                        }
                        */

                        for (int k = 0; k < numloop; k++)
                        {
                            sa += "[" + k.ToString() + ":v:0]" + (fv == string.Empty ? "copy" : fv) + "[v" + k.ToString() + "];";
                        }

                        for (int k = 0; k < numloop; k++)
                        {
                            sa += "[v" + k.ToString() + "]";
                        }

                        if (ffmpegArgs.BackgroundFile != string.Empty)
                        {
                            sa += "concat=n=" + (numloop).ToString() + ":v=1:a=0[v]\" -map \"[v]\" -y " +
                                 ffmpegArgs.outputparams + metadata_args + " \"" + safile + "\"";

                            ffmpegArgs.Args.Add(sa);

                            Module.FilesToDelete.Add(safile);
                        }
                        else
                        {
                            sa += "concat=n=" + (numloop).ToString() + ":v=1:a=0[v]\" -map \"[v]\" -y " +
                                 ffmpegArgs.outputparams + metadata_args + " \"" + ffmpegArgs.FirstOutputFile + "\"";

                            ffmpegArgs.Args.Add(sa);
                        }
                    }
                }

                string safileback = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

                if (ffmpegArgs.BackgroundFile != string.Empty)
                {
                    if (ffmpegArgs.LoopType==1)
                    {
                        safileback = ffmpegArgs.BackgroundFile;
                    }
                    else if (numloopback != 0)
                    {
                        string sa = "";

                        for (int k = 0; k < numloopback; k++)
                        {
                            string vfile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

                            System.IO.File.Copy(ffmpegArgs.BackgroundFile, vfile);

                            Module.FilesToDelete.Add(vfile);

                            sa += " -i \"" + vfile + "\" ";

                            ffmpegArgs.TotalDurationMsecs += ffmpegArgs.BackgroundAudioDurationMsecs;
                        }

                        if (additionalSecsBack != string.Empty && addmsecsback > 500)
                        {
                            sa += " -i \"" + addfileBack + "\" ";

                            ffmpegArgs.TotalDurationMsecs += addmsecsback;

                            Module.FilesToDelete.Add(addfileBack);
                        }

                        sa += " -filter_complex \"";

                        if (additionalSecsBack != string.Empty && addmsecsback > 500)
                        {
                            numloopback++;
                        }

                        for (int k = 0; k < numloopback; k++)
                        {
                            sa += "[" + k.ToString() + ":a:0]";
                        }

                        sa += "concat=n=" + (numloopback).ToString() + ":v=0:a=1[a]\" -map \"[a]\" -y " +
                              " \"" + safileback + "\"";

                        ffmpegArgs.Args.Add(sa);

                        Module.FilesToDelete.Add(safileback);
                    }
                    else
                    {
                        safileback = addfileBack;
                    }

                    if (ffmpegArgs.VideoHasAudio && !ffmpegArgs.audioMute)
                    {
                        string sajoin = " -i \"" + safile + "\" -i \"" + safileback + "\" -filter_complex \"[0:a:0]" +((fa!=string.Empty)?(fa+","):"")+ audioVolumeParams + "[a1];[1:a:0]"+((fa!=string.Empty)?(fa+","):"")+ audioVolumeParamsBack + "[a2];[a1][a2]amix=inputs=2" +
                        "\" -y " + ffmpegArgs.outputparams + metadata_args + " \"" + ffmpegArgs.FirstOutputFile + "\"";

                        ffmpegArgs.Args.Add(sajoin);
                    }
                    else
                    {
                        string sajoin = " -i \"" + safile + "\" -i \"" + safileback + "\" -filter_complex \"[1:a:0]" + ((fa != string.Empty) ? (fa + ",") : "") + audioVolumeParamsBack + "[a2];[a2]amix=inputs=1" +
                        "\" -y " + ffmpegArgs.outputparams + metadata_args + " \"" + ffmpegArgs.FirstOutputFile + "\"";

                        ffmpegArgs.Args.Add(sajoin);
                    }

                    if (ffmpegArgs.LoopType==1)
                    {
                        ffmpegArgs.TotalDurationMsecs += ffmpegArgs.BackgroundAudioDurationMsecs;
                    }
                    else
                    {
                        ffmpegArgs.TotalDurationMsecs += ffmpegArgs.LoopDurationMsecs;
                    }


                }

                ffmpegArgs.DurationMsecs += 0;

                if (ffmpegArgs.audioNormalize)
                {
                    ffmpegArgs.NormalizeFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + outputext);

                    ffmpegArgs.NormalizeArgs1 = " -i \"" + ffmpegArgs.NormalizeFile + "\" -af \"volumedetect\" -f null NUL ";

                    ffmpegArgs.NormalizeArgs2 = " -y -i \"" + ffmpegArgs.NormalizeFile + "\" -filter_complex \"[0:v:0]"+((fv!=string.Empty)?fv:"copy")+"[v1];[0:a:0]"+((fa!=string.Empty)?fa:"acopy")+",volume=" + "[REPLACE_MAXVOL]" + "dB[a1];"+
                        "[v1][a1]concat=n=1:v=1:a=1[v][a]\" -map \"[v]\" -map \"[a]\" "+ffmpegArgs.outputparams + metadata_args +" -y ";

                    Module.FilesToDelete.Add(ffmpegArgs.NormalizeFile);

                    if (ffmpegArgs.LoopType==1)
                    {
                        ffmpegArgs.TotalDurationMsecs += 2 * ffmpegArgs.BackgroundAudioDurationMsecs;
                    }
                    else
                    {
                        ffmpegArgs.TotalDurationMsecs += 2 * ffmpegArgs.LoopDurationMsecs;
                    }
                }

                //joinargs.Args = args + " " + outputparams + metadata_args + " -y ";

                /*
                if (has_filter_params)
                {
                    ffmpegArgs.JoinFileWithNoFilter = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + outputext);

                    ffmpegArgs.JoinArgsWithNoFilter = " -i \"" + ffmpegArgs.JoinFileWithNoFilter + "\" " + outputparams_original + metadata_args + " -y \"" + ffmpegArgs.FirstOutputFile + "\" ";

                    Module.FilesToDelete.Add(ffmpegArgs.JoinFileWithNoFilter);

                    if (ffmpegArgs.LoopType==1)
                    {
                        ffmpegArgs.TotalDurationMsecs += ffmpegArgs.BackgroundAudioDurationMsecs;
                    }
                    else
                    {
                        ffmpegArgs.TotalDurationMsecs += ffmpegArgs.LoopDurationMsecs;
                    }
                }                
                */

                ffmpegArgs.TotalDurationMsecs = ffmpegArgs.TotalDurationMsecs / 100;

                ffmpegArgs.InputVideoFiles.Add(ffmpegArgs.VideoFile);

                return ffmpegArgs;                
            }
            finally
            {
                
            }
        }

        private bool HasParameter(string parameter, string args)
        {
            return ((args.IndexOf(" " + parameter + " ") > 0) || args.StartsWith(parameter+" "));
        }

        private string RemoveVideoAudioFilterArgsFromArgs(string args)
        {
            string str = RemoveParameterFromArgs("-vf", args);

            str = RemoveParameterFromArgs("-af", str);

            return str;
        }

        private string GetVideoFilterArgs(string args)
        {
            string fa = "";

            int spos = args.IndexOf("-vf");

            if (spos >= 0)
            {
                spos = args.IndexOf("-vf \"");

                if (spos >= 0)
                {
                    spos += "-vf \"".Length;

                    int epos = args.IndexOf("\"", spos + "-vf \"".Length);

                    fa +=args.Substring(spos, epos - spos);
                }
                else
                {
                    spos = args.IndexOf("-vf ");

                    if (spos >= 0)
                    {
                        spos += "-vf ".Length;

                        int epos = args.IndexOf(" ", spos + "-vf ".Length);

                        fa += args.Substring(spos, epos - spos);
                    }

                }
            }            

            return fa;
        }

        private string GetAudioFilterArgs(string args)
        {
            string fa = "";            

            int spos = args.IndexOf("-af");

            if (spos >= 0)
            {
                spos = args.IndexOf("-af \"");

                if (spos >= 0)
                {
                    spos += "-af \"".Length;

                    int epos = args.IndexOf("\"", spos + "-af \"".Length);

                    fa += args.Substring(spos, epos - spos);
                }
                else
                {
                    spos = args.IndexOf("-af ");

                    if (spos >= 0)
                    {
                        spos += "-af ".Length;

                        int epos = args.IndexOf(" ", spos + "-af ".Length);

                        fa += args.Substring(spos, epos - spos);
                    }

                }
            }

            return fa;
        }

        private string RemoveParameterFromArgs(string parameter, string args)
        {
            if (args.IndexOf(" " + parameter + " ") > 0)
            {
                string param = " " + parameter + " ";

                int spos1 = args.IndexOf(param);

                int spos = args.IndexOf(param) + param.Length;

                if (args.Substring(spos, 1) == "\"")
                {
                    int epos = args.IndexOf("\"", spos + 1);

                    return " " + args.Substring(0, spos1) + args.Substring(epos + 1);
                }
                else if (args.Substring(spos, 1) == "'")
                {
                    int epos = args.IndexOf("'", spos + 1);

                    return " " + args.Substring(0, spos1) + args.Substring(epos + 1);
                }
                else
                {
                    int epos = args.IndexOf(" ", spos);

                    if (epos < 0)
                    {
                        epos = args.Length - 1;

                        return " " + args.Substring(0, spos1);
                    }
                    else
                    {
                        return " " + args.Substring(0, spos1) + args.Substring(epos);
                    }
                }
            }
            else if (args.StartsWith(parameter + " "))
            {
                string param = parameter + " ";

                int spos1 = args.IndexOf(param);

                int spos = args.IndexOf(param) + param.Length;

                if (args.Substring(spos, 1) == "\"")
                {
                    int epos = args.IndexOf("\"", spos + 1);

                    return " " + args.Substring(0, spos1) + args.Substring(epos + 1);
                }
                else if (args.Substring(spos, 1) == "'")
                {
                    int epos = args.IndexOf("'", spos + 1);

                    return " " + args.Substring(0, spos1) + args.Substring(epos + 1);
                }
                else
                {
                    int epos = args.IndexOf(" ", spos);

                    if (epos < 0)
                    {
                        epos = args.Length - 1;

                        return " " + args.Substring(0, spos1);
                    }
                    else
                    {
                        return " " + args.Substring(0, spos1) + args.Substring(epos);
                    }
                }
            }
            else
            {
                return args;
            }
        }

        public static string GetNormalizeArgs(string initial_args, string ffmpeg_output)
        {
            string maxvol = "";

            using (System.IO.StringReader sr = new System.IO.StringReader(ffmpeg_output))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {

                    if (line.Contains(" max_volume: "))
                    {
                        int spos = line.IndexOf(" max_volume: ") + " max_volume: ".Length;
                        int epos = line.IndexOf(" ", spos);

                        maxvol = line.Substring(spos, epos - spos);
                    }
                }

                if (maxvol != "0.0") // if it is not normalized
                {
                    if (maxvol.StartsWith("-"))
                    {
                        maxvol = maxvol.Substring(1);
                    }

                    return initial_args.Replace("[REPLACE_MAXVOL]", maxvol);
                }
                else
                {
                    return "";
                }
            }
        }
    }
}