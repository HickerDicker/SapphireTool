using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Management;

namespace WindowsFormsApplication2
{
    class Utils
    {
        public static bool DownloadFile(string url, string filename)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(url), filename);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> DownloadFileAsync(string url, string filename)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(new Uri(url), filename);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        static string productName = string.Empty;
        static string buildNumber = string.Empty;
        internal enum WindowsVersion
        {
            Unsupported = 0,
            Windows7 = 7,
            Windows8 = 8,
            Windows10 = 10,
            Windows11 = 11
        }

        internal static WindowsVersion CurrentWindowsVersion = WindowsVersion.Unsupported;

        //Run Command
        //Run Command
        public static void RunCommand(string command, string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = false
            };

            Process process = new Process { StartInfo = startInfo };

            process.Start();
            process.WaitForExit();
        }

        //get OS Name

        internal static string GetOS()
        {
            productName = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", "");

            if (productName.Contains("Windows 7"))
            {
                CurrentWindowsVersion = WindowsVersion.Windows7;
            }
            if (productName.Contains("Windows 8") || productName.Contains("Windows 8.1"))
            {
                CurrentWindowsVersion = WindowsVersion.Windows8;
            }
            if (productName.Contains("Windows 10"))
            {
                buildNumber = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentBuild", "");

                if (Convert.ToInt32(buildNumber) >= 22000)
                {
                    productName = productName.Replace("Windows 10", "Windows 11");
                    CurrentWindowsVersion = WindowsVersion.Windows11;
                }
                else
                {
                    CurrentWindowsVersion = WindowsVersion.Windows10;
                }
            }
            return productName;
        }
        // Get Build Number
        internal static string GetBuildNumber()
        {
            return (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CurrentBuild", "");
        }
        // Get CPU Name
        internal static string GetCPU()
        {
            return (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0", "ProcessorNameString", "");
        }
        // Get CPU Threads
        internal static string GetThreads()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor"))
            {
                if (key != null)
                {
                    return key.SubKeyCount.ToString();
                }
            }
            return "-1";
        }
        // Ram amount
        internal static string GetRAM()
        {
            string RAM = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem");

            foreach (ManagementObject mo in searcher.Get())
            {
                ulong totalMemory = (ulong)mo["TotalPhysicalMemory"];
                double totalMemoryGB = totalMemory / (1024.0 * 1024.0 * 1024.0);
                RAM = totalMemoryGB.ToString("N2") + " GB";
                break;
            }
            return RAM;
        }
        // Ram Manufacturer
        internal static string GetRAMManufacturer()
        {
            string ramManufacturer = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_PhysicalMemory");

                foreach (ManagementObject mo in searcher.Get())
                {
                    ramManufacturer = mo["Manufacturer"].ToString();
                    break;
                }
            }
            catch
            {
                ramManufacturer = "Mismatched";
            }

            return ramManufacturer;
        }
        // Ram Clock
        internal static string GetRAMClock()
        {
            string ramClock = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ConfiguredClockSpeed FROM Win32_PhysicalMemory");

                foreach (ManagementObject mo in searcher.Get())
                {
                    uint configuredClock = (uint)mo["ConfiguredClockSpeed"];
                    ramClock = configuredClock.ToString() + " MHz";
                    break;
                }

                return ramClock;
            }
            catch
            {
                return null;
            }
        }
        // Get CPU cores
        internal static string GetCPUCores()
        {
            int coreCount = 0;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT NumberOfCores FROM Win32_Processor");

            foreach (ManagementObject mo in searcher.Get())
            {
                coreCount += Convert.ToInt32(mo["NumberOfCores"]);
            }

            return coreCount.ToString();
        }
        // Restart explorer (this one is actually used more than once unlike the cpu checks and stuff)
        public static void RestartExplorer()
        {
            foreach (var process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }
            Process.Start("explorer.exe");
        }

        // Get Operating System arch
        internal static string GetBitness()
        {
            string bitness;

            if (Environment.Is64BitOperatingSystem)
            {
                bitness = "Operating System Architecture: 64-bit";
            }
            else
            {
                bitness = "Operating System Architecture: 32-bit";
            }

            return bitness;
        }
    }
}
