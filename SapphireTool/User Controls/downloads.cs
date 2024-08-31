using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;
using WindowsFormsApplication2.Dialog_Boxes;
using WindowsFormsApplication2.User_Controls;
using System.Diagnostics;
using static System.Windows.Forms.AxHost;
using System.Runtime.CompilerServices;
using Login_HWID.Dialog_Boxes;
using static SapphireTool.User_Controls.Downloads;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace SapphireTool.User_Controls
{
    public partial class Downloads : UserControl
    {
        private static Downloads _instace;

        public static Downloads Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new Downloads();
                return _instace;
            }
        }
        public Downloads()
        {
            this.InitializeComponent();
        }
        private List<FeedApp> feedApps;
        public sealed class FeedApp
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Tag { get; set; }
            public string version { get; set; }
            public string type { get; set; }
            public string size { get; set; }
        }
        private void downloads_Load(object sender, EventArgs e)
        {

            base.BeginInvoke(new MethodInvoker(delegate
            {
                this.GetFeed();
            }));

            this.DPI_PREFERENCE = Convert.ToInt32(Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ThemeManager", "LastLoadedDPI", "96"));
        }
        public async void GetFeed()
        {
            try
            {
                WebClient webClient = new WebClient
                {
                    Headers = { { "Cache-Control", "no-cache" } },
                    Encoding = Encoding.UTF8
                };
                label2.Text = "Status: Loading The Downloads";
                string value = await webClient.DownloadStringTaskAsync(_feedLink);
                webClient.DownloadProgressChanged += dl_DownloadProgressChanged;
                AppsFromFeed = JsonConvert.DeserializeObject<List<FeedApp>>(value);
                panel1.Controls.Clear();
                for (int i = 0; i < AppsFromFeed.Count; i++)
                {
                    FeedApp feedApp = AppsFromFeed[i];
                    DlAppCard dlAppCard = new DlAppCard
                    {
                        AutoSize = true,
                        Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right),
                        appTitle =
                         {
                             Text = feedApp.Title,
                             Name = feedApp.Tag
                         },
                                        version =
                         {
                             Text = feedApp.version
                         },
                                        type =
                         {
                             Text = feedApp.type
                         },
                                        size =
                         {
                             Text = feedApp.size
                         }
                    };
                    dlAppCard.Top = i * dlAppCard.Height;
                    dlAppCard.Left = 0;
                    dlAppCard.Width = panel1.ClientSize.Width;
                    panel1.Controls.Add(dlAppCard);
                    this.panel1.AutoScroll = false;
                    Guna2VScrollBar1.Visible = false;
                    await Task.Delay(10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.panel1.AutoScroll = true;
            Guna2VScrollBar1.Visible = true;
            label2.Text = "Status: Idle";
        }
        private void RenderAppDownloaderBusy()
        {
            IEnumerator<DlAppCard> enumerator = panel1.Controls.OfType<DlAppCard>().GetEnumerator();
            btnDownloadApps.Enabled = false;
            try
            {
                while (enumerator.MoveNext())
                {
                    DlAppCard current = enumerator.Current;
                    foreach (Guna2CheckBox item in current.Controls.OfType<Guna2CheckBox>())
                    {
                        item.Enabled = false;
                    }
                    foreach (Label item2 in current.Controls.OfType<Label>())
                    {
                        item2.ForeColor = Color.LightGray;
                    }
                }
            }
            finally
            {
                enumerator?.Dispose();
            }
        }
        private async void btnDownloadApps_Click(object sender, EventArgs e)
        {
            RenderAppDownloaderBusy();
            maxCount = 0;
            downloadCount = 0;
            count = 0;
            downloadLog = string.Empty;
            foreach (DlAppCard item in panel1.Controls.OfType<DlAppCard>())
            {
                Guna2CheckBox guna2CheckBox = item.Controls.OfType<Guna2CheckBox>().FirstOrDefault();
                if (guna2CheckBox != null && guna2CheckBox.Checked)
                {
                    maxCount++;
                }
            }
            foreach (FeedApp x in AppsFromFeed)
            {
                if (string.IsNullOrEmpty(x.Tag))
                {
                    continue;
                }
                DlAppCard dlAppCard = panel1.Controls.OfType<DlAppCard>().FirstOrDefault((DlAppCard c) => c.appTitle.Name == x.Tag);
                if (dlAppCard == null)
                {
                    continue;
                }
                Guna2CheckBox guna2CheckBox2 = dlAppCard.Controls.OfType<Guna2CheckBox>().FirstOrDefault();
                if (guna2CheckBox2 != null && guna2CheckBox2.Checked)
                {
                    appNameTemp = x.Title;
                    count++;
                    if (!string.IsNullOrEmpty(x.Link))
                    {
                        await DownloadApp(x);
                    }
                }
            }
            foreach (DlAppCard item2 in panel1.Controls.OfType<DlAppCard>())
            {
                Guna2CheckBox guna2CheckBox3 = item2.Controls.OfType<Guna2CheckBox>().FirstOrDefault();
                if (guna2CheckBox3 != null)
                {
                    guna2CheckBox3.Checked = false;
                }
            }
            RenderAppDownloaderFree();
        }
        private async Task DownloadApp(FeedApp app)
        {
            if (app.Tag.Contains ("Stm"))
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "SmoothScrollWebViews", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "DWriteEnable", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "StartupMode", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "H264HWAccel", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "DPIScaling", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "GPUAccelWebViews", 0, RegistryValueKind.DWord);
            }
            try
            {
                using (_webClient = new WebClient())
                {
                    _webClient.Headers.Add("User-Agent: Other");
                    _webClient.Encoding = Encoding.UTF8;
                    _webClient.DownloadProgressChanged += dl_DownloadProgressChanged;
                    _webClient.DownloadFileCompleted += Downloader_DownloadFileCompleted;

                    string downloadFolder = @"C:\SapphireTool\Downloads";
                    string fileExtension = ExtractExtensionFromUrl(app.Link);

                    if (string.IsNullOrEmpty(fileExtension))
                    {
                        fileExtension = ".exe";
                    }

                    sw.Start();
                    await _webClient.DownloadFileTaskAsync(new Uri(app.Link), Path.Combine(downloadFolder, app.Title + fileExtension));
                    sw.Stop();
                }
            }
            catch (Exception)
            {
                string downloadFolder = @"C:\SapphireTool\Downloads";
                string fileExtension = ExtractExtensionFromUrl(app.Link);

                if (string.IsNullOrEmpty(fileExtension))
                {
                    fileExtension = ".exe";
                }

                try { File.Delete(Path.Combine(downloadFolder, app.Title + fileExtension)); } catch { }
            }
            finally
            {
                sw.Reset();
            }
        }

        private string ExtractExtensionFromUrl(string url)
        {
            var knownExtensions = new[] { ".msi", ".exe", ".zip", ".7z", ".iso" };
            return knownExtensions.FirstOrDefault(ext => url.EndsWith(ext, StringComparison.OrdinalIgnoreCase)) ?? string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._webClient != null && this._webClient.IsBusy)
            {
                this._webClient.CancelAsync();
            }
            this.cancelled = true;
        }


        private void RenderAppDownloaderFree()
        {
            this.progressBar1.Value = 0;
            this.lblDownload.Text = "";
            this.label2.Refresh();
            IEnumerator<DlAppCard> enumerator = this.panel1.Controls.OfType<DlAppCard>().GetEnumerator();
            this.btnDownloadApps.Enabled = true;
            this.label2.Text = "Status : Idle...";
            this.lblDownload.Refresh();
            this.lblSpeed.Text = "";
            this.sw.Reset();

            try
            {
                while (enumerator.MoveNext())
                {
                    DlAppCard dlAppCard = enumerator.Current;
                    foreach (Guna2CheckBox Guna2CheckBox in dlAppCard.Controls.OfType<Guna2CheckBox>())
                    {
                        Guna2CheckBox.Enabled = true;
                        Guna2CheckBox.Checked = false;
                    }
                    foreach (Label label in dlAppCard.Controls.OfType<Label>())
                    {
                        label.ForeColor = Color.White;
                    }
                }
            }
            finally
            {
                if (enumerator != null)
                {
                    enumerator.Dispose();
                }
            }
        }
        private async Task<List<FeedApp>> FetchFeedAppsAsync()
        {
            await Task.Delay(1000);
            return new List<FeedApp>();
        }
        public void Downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            base.BeginInvoke(new MethodInvoker(delegate
            {
                try
                {
                    if (e.Cancelled)
                    {
                        RenderAppDownloaderFree();
                        using (cancel xForm = new cancel())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                    else if (e.Error != null)
                    {
                        RenderAppDownloaderFree();
                        using (Error xForm = new Error())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                    else
                    {
                        downloadCount++;
                        if (downloadCount == maxCount)
                        {
                            RenderAppDownloaderFree();
                            using (custom xForm = new custom())
                            {
                                xForm.ShowDialog(this);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception in DownloadFileCompleted: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }
        private void dl_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var locals = new
            {
                thisReference = this,
                eReference = e
            };

            this.BeginInvoke(new Action(delegate
            {
                locals.thisReference.label2.Text = string.Format("({1}/{2}) - {0} ...",
                    locals.thisReference.appNameTemp,
                    locals.thisReference.count,
                    locals.thisReference.maxCount);

                locals.thisReference.lblSpeed.Text = string.Format("{0} kb/s",
                    ((double)locals.eReference.BytesReceived / 1024.0 / locals.thisReference.sw.Elapsed.TotalSeconds).ToString("0.00"));

                locals.thisReference.lblDownload.Text = string.Format("{0} MB / {1} MB",
                    ((double)locals.eReference.BytesReceived / 1024.0 / 1024.0).ToString("0.00"),
                    ((double)locals.eReference.TotalBytesToReceive / 1024.0 / 1024.0).ToString("0.00"));

                locals.thisReference.progressBar1.Value = locals.eReference.ProgressPercentage;
            }));
        }
    }
}