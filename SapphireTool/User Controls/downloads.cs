using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Text;
using SapphireTool.DialogBoxes;
using SapphireTool.UserControls;

namespace SapphireTool.UserControls
{
    public partial class Downloads : UserControl
    {
        Stopwatch sw = new Stopwatch();

        string appNameTemp;
        int maxCount = 0;
        int count = 0;
        private bool cancelled = false;
        private WebClient _webClient;
        private Task _downloadTask;
        string downloadLog;
        private int downloadCount = 0;
        string fileExtension = ".exe";
        private string dl_location = @"C:\SapphireTool\Downloads";

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
        public class ApplicationInfo
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Version { get; set; }
            public string Type { get; set; }
            public string Size { get; set; }
        }

        private List<ListViewItem> allListViewItems;

        public Downloads()
        {
            InitializeComponent();
            GetList();
            name.Width = 307;
            version.Width = 275;
            type.Width = 155;
            size.Width = 148;
        }

        private async void GetList()
        {
            try
            {
                string jsonUrl = "https://hickos.hickdick.workers.dev/0:/Downloads.json";
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("Cache-Control", "no-cache");
                    webClient.Encoding = Encoding.UTF8;
                    status.Text = "Status: Getting List...";
                    string jsonString = await webClient.DownloadStringTaskAsync(jsonUrl);
                    List<ApplicationInfo> appList = JsonConvert.DeserializeObject<List<ApplicationInfo>>(jsonString);
                    listView1.Items.Clear();
                    foreach (var appInfo in appList)
                    {
                        ListViewItem item = new ListViewItem(appInfo.Title);
                        item.SubItems.Add(appInfo.Version);
                        item.SubItems.Add(appInfo.Type);
                        item.SubItems.Add(appInfo.Size);
                        item.Tag = appInfo;
                        listView1.Items.Add(item);
                    }

                    allListViewItems = listView1.Items.Cast<ListViewItem>().ToList();

                    status.Text = "Status: Idle";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading app list: {ex.Message}");
            }
        }

        //search box
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchBox.Text.ToLower();
            listView1.Items.Clear();

            foreach (var item in allListViewItems)
            {
                string itemName = item.SubItems[0].Text.ToLower();

                if (itemName.Contains(searchText))
                {
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Brush customBrush = new SolidBrush(Color.FromArgb(33, 33, 33)))
            {
                e.Graphics.FillRectangle(customBrush, e.Bounds);
            }
            e.DrawText();
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void Downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                status.Text = string.Format("({1}/{2}) - {0} ...", appNameTemp, count, maxCount);
                lblSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
                lblDownload.Text = string.Format("{0} MB / {1} MB",
                    (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                    (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
                ProgressBar1.Value = e.ProgressPercentage;
            }));
        }

        private void Downloader_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            downloadCount++;
            BeginInvoke((MethodInvoker)delegate
            {
                if (e.Cancelled)
                {
                    RenderAppDownloaderFree();
                    using (cancel xForm = new cancel())
                    {
                        xForm.ShowDialog(this);
                    }
                }

                if (downloadCount == maxCount)
                {
                    if (e.Error != null && !e.Cancelled)
                    {
                        RenderAppDownloaderFree();
                        using (Error xForm = new Error())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                    else if (!cancelled)
                    {
                        RenderAppDownloaderFree();
                        using (custom xForm = new custom())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                }
            });
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            sw.Start();
            count = 0;
            downloadCount = 0;
            cancelled = false;
            searchBox.Text = "";
            downloadLog = string.Empty;

            if (!Directory.Exists(dl_location))
            {
                Directory.CreateDirectory(dl_location);
            }

            foreach (ListViewItem selectedItem in listView1.CheckedItems)
            {
                ApplicationInfo selectedApp = (ApplicationInfo)selectedItem.Tag;

                if (selectedApp != null && !string.IsNullOrEmpty(selectedApp.Link))
                {
                    // Determine file extension based on link content
                    if (selectedApp.Link.Contains(".7z") || selectedApp.Link.Contains(".bin"))
                    {
                        fileExtension = ".7z";
                    }
                    else if (selectedApp.Link.Contains(".msi"))
                    {
                        fileExtension = ".msi";
                    }
                    else if (selectedApp.Link.Contains(".zip"))
                    {
                        fileExtension = ".zip";
                    }
                    else if (selectedApp.Link.Contains(".img"))
                    {
                        fileExtension = ".img";
                    }
                    else if (selectedApp.Link.Contains(".rar"))
                    {
                        fileExtension = ".rar";
                    }
                    else if (selectedApp.Link.Contains(".bat"))
                    {
                        fileExtension = ".bat";
                    }
                    else if (selectedApp.Link.Contains(".iso"))
                    {
                        fileExtension = ".iso";
                    }
                    else if (selectedApp.Link.Contains(".exe"))
                    {
                        fileExtension = ".exe";
                    }
                    else
                    {
                        fileExtension = ".exe";
                    }

                    string downloadLink = selectedApp.Link;
                    string version = selectedApp.Version.Replace("| Version : ", " ");
                    string filename = selectedApp.Title;

                    appNameTemp = selectedApp.Title;

                    count++;

                    if (!cancelled)
                    {
                        _webClient = new WebClient();
                        _webClient.DownloadFileCompleted += Downloader_DownloadFileCompleted;
                        _webClient.DownloadProgressChanged += Downloader_DownloadProgressChanged;
                        RenderDownloaderBusy();
                        _downloadTask = _webClient.DownloadFileTaskAsync(new Uri(downloadLink), dl_location + "\\" + filename + version + fileExtension);

                        try
                        {
                            await _downloadTask;
                            downloadLog += "• " + filename + ":" + Environment.NewLine + "Downloaded Successfully!" + Environment.NewLine + Environment.NewLine;
                        }
                        catch (Exception)
                        {
                            downloadLog += "• " + filename + ":" + Environment.NewLine + "Download Failed!" + Environment.NewLine + Environment.NewLine;
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelled = true;
            if (_webClient != null)
            {
                _webClient.CancelAsync();
            }
            RenderAppDownloaderFree();
        }

        private void RenderDownloaderBusy()
        {
            btnDownload.Enabled = false;
            searchBox.Enabled = false;
        }

        private void RenderAppDownloaderFree()
        {
            sw.Reset();
            ProgressBar1.Value = 0;
            lblSpeed.Text = ""; lblDownload.Refresh();
            lblDownload.Text = ""; lblDownload.Refresh();
            status.Text = "Status : Idle..."; status.Refresh();
            searchBox.Enabled = true;
            btnDownload.Enabled = true;

            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }
        }

        private void listView1_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = true;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            maxCount = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    maxCount++;
                }
                else if (item.Checked = false && maxCount > 0 && maxCount != 0)
                {
                    maxCount--;
                }
            }
        }
    }
}
