using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MethuselahRS_Client.Client
{
    internal class GameLauncher
    {
        private const int TimeoutMilliseconds = 30000; // 30 seconds

        public GameLauncher()
        {
        }

        public Process LaunchAndBindProcessAsync()
        {
            var processStartInfo = new ProcessStartInfo
            {
                //FileName = "C:\\Program Files (x86)\\Jagex Launcher\\Games\\RuneScape",
                FileName = "C:\\ProgramData\\Jagex\\launcher\\rs2client.exe",
                Arguments = "https://world1.runescape.com/jav_config.ws?binaryType=2",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = Process.Start(processStartInfo);
            process.WaitForInputIdle();

            if (process != null)
            {


                bool isBound = WaitForProcessAndBind(process);
                if (!isBound)
                {
                    MessageBox.Show("No client with the specified Main Window Title was detected.",
                                    "Client Detection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            return process;
        }

        public static Panel Main;
        private bool WaitForProcessAndBind(Process process)
        {
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < TimeoutMilliseconds)
            {
                process.Refresh(); // Refresh the process information
                if (!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.MainWindowTitle.Equals("NxtApp", StringComparison.OrdinalIgnoreCase))
                    {

                        return true;
                    }
                }
                Thread.Sleep(500);
            }
            return false;
        }
    }
}
