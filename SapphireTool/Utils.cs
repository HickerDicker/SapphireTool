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
using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Linq;

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

        public static void CheckRegistryValueAndSetToggleSwitch(RegistryKey key, string valueName, Guna2ToggleSwitch toggleSwitch)
        {
            object val = key.GetValue(valueName);
            if (val != null)
            {
                toggleSwitch.Checked = true;
            }
        }
        public class ButtonToggleManager
        {
            private List<Guna2Button> buttons = new List<Guna2Button>();
            private Guna2Button lastClickedButton = null;
            private Color defaultColor = Color.FromArgb(28, 26, 38);
            private Color selectedColor = Color.FromArgb(38, 36, 48);
            private Color borderColor = Color.BlueViolet;
            private Padding borderThickness = new Padding(0, 0, 0, 2);
            private Guna2Button excludedButton;
            public ButtonToggleManager(Guna2Panel panel, Guna2Button defaultButton, Guna2Button excludeButton = null)
            {
                excludedButton = excludeButton;
                FindButtonsInPanel(panel);
                foreach (var button in buttons)
                {
                    button.Click += Button_Click;
                }
                if (defaultButton != null)
                {
                    SetButtonSelected(defaultButton);
                    lastClickedButton = defaultButton;
                }
            }
            private void FindButtonsInPanel(Guna2Panel panel)
            {
                foreach (var control in panel.Controls)
                {
                    if (control is Guna2Button gunaButton && gunaButton != excludedButton)
                    {
                        buttons.Add(gunaButton);
                    }
                    else if (control is Guna2Panel subPanel)
                    {
                        FindButtonsInPanel(subPanel);
                    }
                }
            }
            private void Button_Click(object sender, EventArgs e)
            {
                var clickedButton = (Guna2Button)sender;
                if (lastClickedButton != null && lastClickedButton != clickedButton)
                {
                    SetButtonDefault(lastClickedButton);
                }
                SetButtonSelected(clickedButton);
                lastClickedButton = clickedButton;
            }
            private void SetButtonDefault(Guna2Button button)
            {
                button.FillColor = defaultColor;
                button.CustomBorderColor = Color.Empty;
                button.CustomBorderThickness = new Padding(0);
                button.CheckedState.BorderColor = Color.Empty;
                button.CheckedState.CustomBorderColor = Color.Empty;
            }
            private void SetButtonSelected(Guna2Button button)
            {
                button.FillColor = selectedColor;
                button.CustomBorderColor = borderColor;
                button.CustomBorderThickness = borderThickness;
                button.CheckedState.BorderColor = borderColor;
                button.CheckedState.CustomBorderColor = borderColor;
            }
            public void Reset()
            {
                if (lastClickedButton != null)
                {
                    SetButtonDefault(lastClickedButton);
                    lastClickedButton = null;
                }
            }
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
        public class Updater
        {
            private static readonly string VersionFileUrl = "https://hickos.hickdick.workers.dev/0:/version.txt";
            private static readonly string CurrentVersion = "v1.1";
            private static readonly string TempVersionFilePath = Path.Combine(Path.GetTempPath(), "version.txt");

            public async Task<bool> CheckForUpdatesAsync()
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        await client.DownloadFileTaskAsync(new Uri(VersionFileUrl), TempVersionFilePath);
                        string latestVersion;
                        using (FileStream stream = new FileStream(TempVersionFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            latestVersion = await reader.ReadToEndAsync();
                        }
                        latestVersion = latestVersion.Trim();
                        File.Delete(TempVersionFilePath);
                        return latestVersion != CurrentVersion;
                    }
                }
                catch
                {
                    MessageDialog.Show(null, "You Probably Do Not Have Internet Cannot Check For Updates", "Warning", MessageDialogButtons.OK, MessageDialogIcon.Warning, MessageDialogStyle.Dark);
                    return false;
                }
            }
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
        public class TreeData<T> : IEnumerable<TreeData<T>>, IEnumerable
        {
            public T Data { get; set; }
            public TreeData<T> Parent { get; set; }
            public ICollection<TreeData<T>> Children { get; set; }
            public string Tag { get; set; }
            public string Name { get; set; }
            public bool Root
            {
                get
                {
                    return this.Parent == null;
                }
            }
            public bool HasChildren
            {
                get
                {
                    return this.Children.Count > 0;
                }
            }
            public int Level
            {
                get
                {
                    return this.Root ? 0 : this.Parent.Level + 1;
                }
            }
            private ICollection<TreeData<T>> ItemCollection { get; set; }
            public TreeData(T data)
            {
                this.Data = data;
                this.Children = new LinkedList<TreeData<T>>();
                this.ItemCollection = new LinkedList<TreeData<T>>();
                this.ItemCollection.Add(this);
            }
            public TreeData<T> AddChild(T childItem)
            {
                TreeData<T> childNode = new TreeData<T>(childItem);
                childNode.Parent = this;
                this.Children.Add(childNode);
                this.AddToSearch(childNode);
                return childNode;
            }
            private void AddToSearch(TreeData<T> item)
            {
                bool flag;
                flag = this.Parent != null;
                this.Parent.AddToSearch(item);
                this.ItemCollection.Add(item);
            }
            public TreeData<T> FindTreeItem(Func<TreeData<T>, bool> predicate)
            {
                TreeData<T> treeData;
                treeData = this.ItemCollection.FirstOrDefault(predicate);
                return treeData;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                IEnumerator enumerator;
                enumerator = this.GetEnumerator();
                return enumerator;
            }
            public IEnumerator<TreeData<T>> GetEnumerator()
            {
                return new Enumerator(this);
            }

            private class Enumerator : IEnumerator<TreeData<T>>
            {
                private readonly TreeData<T> _root;
                private Stack<IEnumerator<TreeData<T>>> _stack;
                private TreeData<T> _current;

                public Enumerator(TreeData<T> root)
                {
                    _root = root;
                    _stack = new Stack<IEnumerator<TreeData<T>>>();
                    _stack.Push(((IEnumerable<TreeData<T>>)new[] { _root }).GetEnumerator());
                }

                public TreeData<T> Current => _current;

                object IEnumerator.Current => Current;

                public bool MoveNext()
                {
                    while (_stack.Count > 0)
                    {
                        if (_stack.Peek().MoveNext())
                        {
                            _current = _stack.Peek().Current;
                            _stack.Push(_current.Children.GetEnumerator());
                            return true;
                        }
                        else
                        {
                            _stack.Pop();
                        }
                    }
                    return false;
                }
                public void Reset()
                {
                    _stack.Clear();
                    _stack.Push(((IEnumerable<TreeData<T>>)new[] { _root }).GetEnumerator());
                }
                public void Dispose()
                {
                }
            }
        }
    }
}
