using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using SapphireTool.DialogBoxes;
using System.IO;
using Login_HWID.DialogBoxes;
using System.IO.Compression;

namespace SapphireTool.UserControls
{
    public partial class windowsapp : UserControl
    {
        WebClient dl;
        Stopwatch sw = new Stopwatch();
        private static windowsapp _instace;
        public static windowsapp Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new windowsapp();
                return _instace;
            }
        }
        public windowsapp()
        {
            InitializeComponent();
        }
        private void dl_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lblSpeed.Text = string.Format("Download Speed: {0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
            lblDownload.Text = string.Format("{0} MB / {1} MB",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
            guna2ProgressBar1.Value = e.ProgressPercentage;
        }
        private void dl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            guna2ProgressBar1.Value = 0;
            lblSpeed.Text = ""; lblDownload.Refresh();
            lblDownload.Text = ""; lblDownload.Refresh();
            label2.Text = "Status : Idle..."; label2.Refresh();
            if (e.Error != null)
            {
                using (Error xForm = new Error())
                {
                    xForm.ShowDialog(this);
                }
            }
            else
            {
                using (AppX xForm = new AppX())
                {
                    xForm.ShowDialog(this);
                }
            }
        }
        private void dl_DownloadAppxCompleted(object sender, AsyncCompletedEventArgs e)
        {

            guna2ProgressBar1.Value = 0;
            label2.Text = $"Status : Still Downloading..."; label2.Refresh();
            if (e.Error != null)
            {
                using (Error xForm = new Error())
                {
                    xForm.ShowDialog(this);
                }
            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/@hickensa");
        }
        private void button21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/4aNYHSEHYw");
        }
        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic");
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadAppxCompleted;
            label2.Text = "Status: Downloading Groove Music..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Groove/Installer.bat"), "C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic\\Installer.bat");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Groove/Microsoft.UI.Xaml.2.3_2.32002.13001.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic\\Microsoft.UI.Xaml.2.3_2.32002.13001.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Groove/Microsoft.UI.Xaml.2.3_2.32002.13001.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic\\Microsoft.UI.Xaml.2.3_2.32002.13001.0_x86__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Groove/Microsoft.VCLibs.140.00_14.0.27810.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic\\Microsoft.VCLibs.140.00_14.0.27810.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Groove/Microsoft.VCLibs.140.00_14.0.27810.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic\\Microsoft.VCLibs.140.00_14.0.27810.0_x86__8wekyb3d8bbwe.Appx");
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Groove/Microsoft.ZuneMusic_2019.20032.12611.0_neutral_~_8wekyb3d8bbwe.AppxBundle"), "C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic\\Microsoft.ZuneMusic_2019.20032.12611.0_neutral_~_8wekyb3d8bbwe.AppxBundle");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic\\Installer.bat"))
            {
                Utils.RunCommand("cmd.exe", "/c cd C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic && C:\\SapphireTool\\Downloads\\Appx\\GrooveMusic\\Installer.bat");
            }
            else
            {
                using (_404notfound xForm = new _404notfound())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\SapphireTool\\Downloads\\Appx\\Calculator");
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadAppxCompleted;
            label2.Text = "Status: Downloading Calculator..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Groove/Installer.bat"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Installer.bat");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.UI.Xaml.2.2_2.21909.17002.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.UI.Xaml.2.2_2.21909.17002.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.UI.Xaml.2.2_2.21909.17002.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.UI.Xaml.2.2_2.21909.17002.0_x86__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.UI.Xaml.2.3_2.32002.13001.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.UI.Xaml.2.3_2.32002.13001.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.UI.Xaml.2.3_2.32002.13001.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.UI.Xaml.2.3_2.32002.13001.0_x86__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.UI.Xaml.2.4_2.42007.9001.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.UI.Xaml.2.4_2.42007.9001.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.UI.Xaml.2.4_2.42007.9001.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.UI.Xaml.2.4_2.42007.9001.0_x86__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.VCLibs.140.00_14.0.29231.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.VCLibs.140.00_14.0.29231.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.VCLibs.140.00_14.0.29231.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.VCLibs.140.00_14.0.29231.0_x86__8wekyb3d8bbwe.Appx");
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Calculator/Microsoft.WindowsCalculator_2020.2103.8.0_neutral_~_8wekyb3d8bbwe.AppxBundle"), "C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Microsoft.WindowsCalculator_2020.2103.8.0_neutral_~_8wekyb3d8bbwe.AppxBundle");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Installer.bat"))
            {
                Utils.RunCommand("cmd.exe", "/c cd C:\\SapphireTool\\Downloads\\Appx\\Calculator && C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Installer.bat");
            }
            else
            {
                using (_404notfound xForm = new _404notfound())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private async void guna2Button8_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\SapphireTool\\Downloads\\Appx\\Photos");
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadAppxCompleted;
            label2.Text = "Status: Downloading Photos..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Groove/Installer.bat"), "C:\\SapphireTool\\Downloads\\Appx\\Photos\\Installer.bat");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Photos/Microsoft.NET.Native.Framework.2.2_2.2.29512.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Photos\\Microsoft.NET.Native.Framework.2.2_2.2.29512.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Photos/Microsoft.NET.Native.Framework.2.2_2.2.29512.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Photos\\Microsoft.NET.Native.Framework.2.2_2.2.29512.0_x86__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Photos/Microsoft.UI.Xaml.2.4_2.42007.9001.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Photos\\Microsoft.UI.Xaml.2.4_2.42007.9001.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Photos/Microsoft.UI.Xaml.2.4_2.42007.9001.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Photos\\Microsoft.UI.Xaml.2.4_2.42007.9001.0_x86__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Photos/Microsoft.VCLibs.140.00_14.0.27810.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Photos\\Microsoft.VCLibs.140.00_14.0.27810.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Photos/Microsoft.VCLibs.140.00_14.0.27810.0_x86__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Photos\\Microsoft.VCLibs.140.00_14.0.27810.0_x86__8wekyb3d8bbwe.Appx");
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Photos/microsoft.windows.photos_8wekyb3d8bbwe.appxbundle"), "C:\\SapphireTool\\Downloads\\Appx\\Photos\\microsoft.windows.photos_8wekyb3d8bbwe.appxbundle");
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\SapphireTool\\Downloads\\Appx\\Calculator\\Installer.bat"))
            {
                Utils.RunCommand("cmd.exe", "/c cd C:\\SapphireTool\\Downloads\\Appx\\Photos && C:\\SapphireTool\\Downloads\\Appx\\Photos\\Installer.bat");
            }
            else
            {
                using (_404notfound xForm = new _404notfound())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Microsoft Store..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/Install_Microsoft_Libs_and_Store.zip"), "C:\\SapphireTool\\Downloads\\Appx\\Install_Microsoft_Libs_and_Store.zip");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            var zipPath = @"C:\SapphireTool\Downloads\Appx\Install_Microsoft_Libs_and_Store.zip";
            var extractPath = @"C:\SapphireTool\Downloads\Appx\Install_Microsoft_Libs_and_Store";
            Directory.CreateDirectory(extractPath);
            if (File.Exists("C:\\SapphireTool\\Downloads\\Appx\\Install_Microsoft_Libs_and_Store\\Install_Microsoft_Libs_and_Store.bat"))
            {
            }
            else
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
            if (File.Exists("C:\\SapphireTool\\Downloads\\Appx\\Install_Microsoft_Libs_and_Store\\Install_Microsoft_Libs_and_Store.bat"))
            {
                Process.Start("C:\\SapphireTool\\Downloads\\Appx\\Install_Microsoft_Libs_and_Store\\Install_Microsoft_Libs_and_Store.bat");
            }
            else
            {
                using (_404notfound xForm = new _404notfound())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private async void guna2Button12_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\SapphireTool\\Downloads\\Appx\\Terminal");
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadAppxCompleted;
            label2.Text = "Status: Downloading Windows Terminal..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Terminal/Microsoft.VCLibs.140.00.UWPDesktop_14.0.30704.0_x64__8wekyb3d8bbwe.appx"), "C:\\SapphireTool\\Downloads\\Appx\\Terminal\\Microsoft.VCLibs.140.00.UWPDesktop_14.0.30704.0_x64__8wekyb3d8bbwe.appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Terminal/Installer.bat"), "C:\\SapphireTool\\Downloads\\Appx\\Terminal\\Installer.bat");
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Terminal/Microsoft.WindowsTerminal_3001.16.10261.0_neutral_~_8wekyb3d8bbwe.Msixbundle"), "C:\\SapphireTool\\Downloads\\Appx\\Terminal\\Microsoft.WindowsTerminal_3001.16.10261.0_neutral_~_8wekyb3d8bbwe.Msixbundle");
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\SapphireTool\\Downloads\\Appx\\Terminal\\Installer.bat"))
            {
                Utils.RunCommand("cmd.exe", "/c cd C:\\SapphireTool\\Downloads\\Appx\\Terminal && C:\\SapphireTool\\Downloads\\Appx\\Terminal\\Installer.bat");
            }
            else
            {
                using (_404notfound xForm = new _404notfound())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private async void guna2Button10_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\SapphireTool\\Downloads\\Appx\\Xbox");
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadAppxCompleted;
            label2.Text = "Status: Downloading Xbox Game Bar..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Xbox/Installer.bat"), "C:\\SapphireTool\\Downloads\\Appx\\Xbox\\Installer.bat");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Xbox/Microsoft.UI.Xaml.2.7_7.2208.15002.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Xbox\\Microsoft.UI.Xaml.2.7_7.2208.15002.0_x64__8wekyb3d8bbwe.Appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Xbox/Microsoft.VCLibs.140.00.UWPDesktop_14.0.30704.0_x64__8wekyb3d8bbwe.appx"), "C:\\SapphireTool\\Downloads\\Appx\\Xbox\\Microsoft.VCLibs.140.00.UWPDesktop_14.0.30704.0_x64__8wekyb3d8bbwe.appx");
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Xbox/Microsoft.VCLibs.140.00_14.0.30704.0_x64__8wekyb3d8bbwe.Appx"), "C:\\SapphireTool\\Downloads\\Appx\\Xbox\\Microsoft.VCLibs.140.00_14.0.30704.0_x64__8wekyb3d8bbwe.Appx");
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/appxs/Xbox/Microsoft.XboxGamingOverlay_5.822.9161.0_neutral___8wekyb3d8bbwe.AppxBundle"), "C:\\SapphireTool\\Downloads\\Appx\\Xbox\\Microsoft.XboxGamingOverlay_5.822.9161.0_neutral___8wekyb3d8bbwe.AppxBundle");
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\SapphireTool\\Downloads\\Appx\\Xbox\\Installer.bat"))
            {
                Utils.RunCommand("cmd.exe", "/c cd C:\\SapphireTool\\Downloads\\Appx\\Xbox && C:\\SapphireTool\\Downloads\\Appx\\Xbox\\Installer.bat");
            }
            else
            {
                using (_404notfound xForm = new _404notfound())
                {
                    xForm.ShowDialog(this);
                }
            }
        }
    }
}
