using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2.Dialog_Boxes;
using WindowsFormsApplication2.User_Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SapphireTool.User_Controls
{
    public partial class downloads : UserControl
    {
        WebClient dl;
        Stopwatch sw = new Stopwatch();
        private static downloads _instance;

        public static downloads Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new downloads();
                return _instance;
            }
        }
        public downloads()
        {
            InitializeComponent();
        }
        private void dl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                sw.Reset();
                lblSpeed.Text = "";
                lblDownload.Text = "";
                label2.Text = "Status: Idle...";
                guna2ProgressBar1.Value = 0;
                if (e.Error != null)
                    {
                        using (Error xForm = new Error())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                    else
                    {
                        using (custom xForm = new custom())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
            }));
        }
        private void dl_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lblSpeed.Text = string.Format("Download Speed: {0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
            lblDownload.Text = string.Format("{0} MB / {1} MB",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
            guna2ProgressBar1.Value = e.ProgressPercentage;
        }
        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Brave..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://brave-browser-downloads.s3.brave.com/latest/BraveBrowserSetup.exe"), "C:\\SapphireTool\\Downloads\\BraveBrowserSetup.exe");
        }
        private async void guna2Button23_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Daum Pot Player..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://t1.daumcdn.net/potplayer/PotPlayer/Version/Latest/PotPlayerSetup64.exe"), "C:\\SapphireTool\\Downloads\\PotPlayerSetup64.exe");
        }
        private async void guna2Button24_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Discord..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x64"), "C:\\SapphireTool\\Downloads\\DiscordSetup.exe");
        }
        private async void guna2Button25_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Gom Player..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://cdn.gomlab.com/gretech/player/GOMPLAYERGLOBALSETUP_CHROME.EXE"), "C:\\SapphireTool\\Downloads\\GOMPLAYERGLOBALSETUP_CHROME.EXE");
        }
        private async void guna2Button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Chrome..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("http://dl.google.com/chrome/install/chrome_installer.exe"), "C:\\SapphireTool\\Downloads\\chrome_installer.exe");
        }
        private async void guna2Button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Firefox..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://mzl.la/3o6YriV"), "C:\\SapphireTool\\Downloads\\Firefox Installer.exe");
        }
        private async void guna2Button16_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Waterfox..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://cdn1.waterfox.net/waterfox/releases/latest/windows"), "C:\\SapphireTool\\Downloads\\Waterfox Setup.exe");
        }
        private async void guna2Button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading OperaGX..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://net.geo.opera.com/opera_gx/stable/windows?utm_tryagain=yes&utm_source=google&utm_medium=ose&utm_campaign=(none)&http_referrer=https%3A%2F%2Fwww.google.com%2F&utm_site=opera_com&"), "C:\\SapphireTool\\Downloads\\Opera_GX_Installer.exe");
        }
        private async void guna2Button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Spotify..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://download.scdn.co/SpotifySetup.exe"), "C:\\SapphireTool\\Downloads\\SpotifySetup.exe");
        }
        private async void guna2Button19_Click(object sender, EventArgs e)
        {
			// Stolen from imribiy#0001
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "SmoothScrollWebViews", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "DWriteEnable", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "StartupMode", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "H264HWAccel", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "DPIScaling", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "GPUAccelWebViews", 0, RegistryValueKind.DWord);
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Steam..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://cdn.cloudflare.steamstatic.com/client/installer/SteamSetup.exe"), "C:\\SapphireTool\\Downloads\\SteamSetup.exe");
        }
        private async void guna2Button21_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Microsoft Edge..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://go.microsoft.com/fwlink/?linkid=2108834&Channel=Stable&language=en&brand=M100"), "C:\\SapphireTool\\Downloads\\MicrosoftEdgeSetup.exe");
        }
        private async void guna2Button20_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Microsoft Edge Webview..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://go.microsoft.com/fwlink/?linkid=2124701"), "C:\\SapphireTool\\Downloads\\MicrosoftEdgeWebView2RuntimeInstallerX64.exe");
        }
        private async void guna2Button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Vencord..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://github.com/Vencord/Installer/releases/latest/download/VencordInstaller.exe"), "C:\\SapphireTool\\Downloads\\VencordInstaller.exe");
        }
        private async void guna2Button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Free Download Manager..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://dn3.freedownloadmanager.org/6/latest/fdm_x64_setup.exe"), "C:\\SapphireTool\\Downloads\\fdm_x64_setup.exe");
        }
        private async void guna2Button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Lightshot..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://app.prntscr.com/build/setup-lightshot.exe"), "C:\\SapphireTool\\Downloads\\setup-lightshot.exe");
        }
        private async void guna2Button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Opera..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://net.geo.opera.com/opera/stable/windows?utm_tryagain=yes&utm_source=google&utm_medium=ose&utm_campaign=(none)&http_referrer=https%3A%2F%2Fwww.google.com%2F&utm_site=opera_com&&utm_lastpage=opera.com/"), "C:\\SapphireTool\\Downloads\\OperaSetup.exe");
        }
        private async void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Waterfox..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://cdn1.waterfox.net/waterfox/releases/latest/windows"), "C:\\SapphireTool\\Downloads\\Waterfox Setup.exe");
        }
        private async void guna2Button8_Click(object sender, EventArgs e)
        {
                this.Hide();
                guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
                dl = new WebClient();
                dl.DownloadProgressChanged += dl_DownloadProgressChanged;
                dl.DownloadFileCompleted += dl_DownloadFileCompleted;
                label2.Text = "Status: Downloading Epic Games Launcher..."; label2.Refresh();
                sw.Start();
                this.Show();
                await dl.DownloadFileTaskAsync(new Uri("https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi"), "C:\\SapphireTool\\Downloads\\EpicGamesLauncherInstaller.msi");
        }           
        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Daum PotPlayer..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://t1.daumcdn.net/potplayer/PotPlayer/Version/Latest/PotPlayerSetup64.exe"), "C:\\SapphireTool\\Downloads\\PotPlayerSetup64.exe");
        }
        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Discord..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x64"), "C:\\SapphireTool\\Downloads\\DiscordSetup.exe");
        }
        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Mozila Firefox..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://mzl.la/3o6YriV"), "C:\\SapphireTool\\Downloads\\Firefox Installer.exe");
        }
        private async void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Google Chrome..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("http://dl.google.com/chrome/install/chrome_installer.exe"), "C:\\SapphireTool\\Downloads\\chrome_installer.exe");
        }
        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading GOM Player..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://cdn.gomlab.com/gretech/player/GOMPLAYERGLOBALSETUP_CHROME.EXE"), "C:\\SapphireTool\\Downloads\\GOMPLAYERGLOBALSETUP_CHROME.EXE");
        }
        private async void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading SDIO..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://www.glenn.delahoy.com/downloads/sdio/SDIO_1.12.22.763.zip"), "C:\\SapphireTool\\Downloads\\SDIO_1.12.22.763.zip");
        }
        private void downloads_Load(object sender, EventArgs e)
        {

        }
        private async void guna2Button26_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Vesktop..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://vencord.dev/download/vesktop/amd64/windows"), "C:\\SapphireTool\\Downloads\\Vesktop-Setup.exe");
        }
        private async void guna2Button32_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status Downloading Visual Studio Code..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://code.visualstudio.com/sha/download?build=stable&os=win32-x64-user"), "C:\\SapphireTool\\Downloads\\VSCodeUserSetup.exe");
        }
        private async void guna2Button31_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Visual Studio 2022..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030:7fa892c8cc4444d8a24f4c8959dfff1d"), "C:\\SapphireTool\\Downloads\\VisualStudioSetup.exe");

        }
        private async void guna2Button29_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Bulk Crap Uninstaller..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://github.com/Klocman/Bulk-Crap-Uninstaller/releases/download/v5.7/BCUninstaller_5.7_setup.exe"), "C:\\SapphireTool\\Downloads\\BCUninstaller_5.7_setup.exe");
        }
        private async void guna2Button28_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Foobar2000..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://www.foobar2000.org/files/foobar2000-x64_v2.1.4.exe"), "C:\\SapphireTool\\Downloads\\foobar2000-x64_v2.1.4.exe");
        }
        private async void guna2Button27_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading VLC..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://mirrors.netix.net/vlc/vlc/3.0.21/win64/vlc-3.0.21-win64.exe"), "C:\\SapphireTool\\Downloads\\vlc-3.0.21-win64.exe");
        }

        private async void guna2Button30_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Classic Paint..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://files1.majorgeeks.com/10afebdbffcd4742c81a3cb0f6ce4092156b4375/microsoft/ClassicPaint.zip"), "C:\\SapphireTool\\Downloads\\ClassicPaint.zip");
        }

        private async void guna2Button33_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Mem Reduct..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://github.com/henrypp/memreduct/releases/download/v.3.4/memreduct-3.4-setup.exe"), "C:\\SapphireTool\\Downloads\\memreduct-3.4-setup.exe");
        }

        private async void guna2Button34_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading AnyDesk..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://download.anydesk.com/AnyDesk.exe"), "C:\\SapphireTool\\Downloads\\AnyDesk.exe");
        }

        private async void guna2Button35_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Thorium AVX2..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/thorium_AVX2_mini_installer.exe"), "C:\\SapphireTool\\Downloads\\thorium_AVX2_mini_installer.exe");
        }

        private async void guna2Button36_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading MPC-HC..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://github.com/mpc-hc/mpc-hc/releases/download/1.7.13/MPC-HC.1.7.13.x64.exe"), "C:\\SapphireTool\\Downloads\\MPC-HC.1.7.13.x64.exe");
        }

        private async void guna2Button37_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading AutoGpuAffinity..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://github.com/spddl/AutoGpuAffinity/releases/download/v1.0.3/AutoGpuAffinity.exe"), "C:\\SapphireTool\\Downloads\\AutoGpuAffinity.exe");
        }

        private async void guna2Button38_Click(object sender, EventArgs e)
        {
            this.Hide();
            guna2ProgressBar1.Style = ProgressBarStyle.Blocks;
            dl = new WebClient();
            dl.DownloadProgressChanged += dl_DownloadProgressChanged;
            dl.DownloadFileCompleted += dl_DownloadFileCompleted;
            label2.Text = "Status: Downloading Everything..."; label2.Refresh();
            sw.Start();
            this.Show();
            await dl.DownloadFileTaskAsync(new Uri("https://www.voidtools.com/Everything-1.4.1.1024.x86-Setup.exe"), "C:\\SapphireTool\\Downloads\\Everything-1.4.1.1024.x86-Setup.exe");
        }
    }
}
