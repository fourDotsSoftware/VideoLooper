using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace VideoLooper
{
    public class ShutdownHelper
    {
        public int WhenFinishedIndex = -1;
        public string OutputFile = "";

        public static void Hibernate()
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }

        public static void Sleep()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        
        public static void Shutdown()
        {
            Process.Start("shutdown","/s /t 0");
        }

        public static void Restart()
        {
            Process.Start("shutdown", "/r /t 0");
        }

        public static void Logoff()
        {
            ExitWindowsEx(0, 0);
  
        }

        public static void Lock()
        {
            LockWorkStation();
        }

        public void ProcessWhenFinished()
        {
            int ichecked = WhenFinishedIndex;

            if (ichecked == 0)
            {
                ShutdownHelper.Shutdown();
            }
            else if (ichecked == 1)
            {
                ShutdownHelper.Sleep();
            }
            else if (ichecked == 2)
            {
                ShutdownHelper.Hibernate();
            }
            else if (ichecked == 3)
            {
                ShutdownHelper.Logoff();
            }
            else if (ichecked == 4)
            {
                ShutdownHelper.Lock();
            }
            else if (ichecked == 5)
            {
                ShutdownHelper.Restart();
            }
            else if (ichecked == 6)
            {
                Application.Exit();
            }
            else if (ichecked == 7)
            {
                string args = string.Format("/e, /select, \"{0}\"",OutputFile);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.UseShellExecute = true;
                info.Arguments = args;
                Process.Start(info);
            }

        }
    }
}
