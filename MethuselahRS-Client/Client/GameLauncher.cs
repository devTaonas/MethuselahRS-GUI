using MethuselahRS_Client.Controller.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

        public RS3Client LaunchProcess()
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

            RS3Client rS3Client = new RS3Client
            {
                GameClient = process,
                MainModule = process.MainModule
            };

            rS3Client.RSBaseAddress = rS3Client.MainModule.BaseAddress;
            rS3Client.RSExeFile = rS3Client.MainModule.FileName;
            rS3Client.RSExeSize = rS3Client.MainModule.ModuleMemorySize;
            rS3Client.RSHash = FindMD5(rS3Client.RSExeFile);
            rS3Client.RSHashString = CalculateMD5(rS3Client.RSExeFile);

            return rS3Client;
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

        internal static byte[] FindMD5(string RSExeFile)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(RSExeFile))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }
        static string CalculateMD5(string RSExeFile)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(RSExeFile))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
