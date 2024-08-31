using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Guna.UI2;
using Guna.UI2.WinForms;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace SapphireTool.User_Controls
{
    partial class Downloads
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDownloadApps = new Guna.UI2.WinForms.Guna2Button();
            this.button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lblDownload = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.Guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label266 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter Medium", 25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 41);
            this.label1.TabIndex = 93;
            this.label1.Text = "Downloads";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 551);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(679, 23);
            this.progressBar1.TabIndex = 342;
            this.progressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter Medium", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 589);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 19);
            this.label2.TabIndex = 339;
            this.label2.Text = "Status : Idle....";
            // 
            // btnDownloadApps
            // 
            this.btnDownloadApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.btnDownloadApps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadApps.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.btnDownloadApps.Font = new System.Drawing.Font("Inter Medium", 11.25F);
            this.btnDownloadApps.ForeColor = System.Drawing.Color.White;
            this.btnDownloadApps.Location = new System.Drawing.Point(700, 546);
            this.btnDownloadApps.Margin = new System.Windows.Forms.Padding(1);
            this.btnDownloadApps.Name = "btnDownloadApps";
            this.btnDownloadApps.Size = new System.Drawing.Size(101, 35);
            this.btnDownloadApps.TabIndex = 338;
            this.btnDownloadApps.Text = "Download";
            this.btnDownloadApps.Click += new System.EventHandler(this.btnDownloadApps_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.button1.Font = new System.Drawing.Font("Inter Medium", 11.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(803, 546);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 343;
            this.button1.Text = "Cancel";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDownload.ForeColor = System.Drawing.Color.White;
            this.lblDownload.Location = new System.Drawing.Point(731, 586);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(0, 21);
            this.lblDownload.TabIndex = 340;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSpeed.ForeColor = System.Drawing.Color.White;
            this.lblSpeed.Location = new System.Drawing.Point(389, 587);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(0, 21);
            this.lblSpeed.TabIndex = 341;
            // 
            // Guna2VScrollBar1
            // 
            this.Guna2VScrollBar1.BindingContainer = this.panel1;
            this.Guna2VScrollBar1.BorderRadius = 8;
            this.Guna2VScrollBar1.FillColor = System.Drawing.Color.Transparent;
            this.Guna2VScrollBar1.InUpdate = false;
            this.Guna2VScrollBar1.LargeChange = 10;
            this.Guna2VScrollBar1.Location = new System.Drawing.Point(897, 71);
            this.Guna2VScrollBar1.Name = "Guna2VScrollBar1";
            this.Guna2VScrollBar1.ScrollbarSize = 18;
            this.Guna2VScrollBar1.Size = new System.Drawing.Size(18, 470);
            this.Guna2VScrollBar1.TabIndex = 337;
            this.Guna2VScrollBar1.ThumbColor = System.Drawing.Color.Gray;
            this.Guna2VScrollBar1.ThumbSize = 80F;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(18, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 470);
            this.panel1.TabIndex = 95;
            // 
            // label266
            // 
            this.label266.AutoSize = true;
            this.label266.Font = new System.Drawing.Font("Inter Medium", 9F);
            this.label266.ForeColor = System.Drawing.Color.Silver;
            this.label266.Location = new System.Drawing.Point(23, 53);
            this.label266.Name = "label266";
            this.label266.Size = new System.Drawing.Size(213, 15);
            this.label266.TabIndex = 94;
            this.label266.Text = "Download some essential freewares";
            // 
            // Downloads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.Guna2VScrollBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDownloadApps);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label266);
            this.Name = "Downloads";
            this.Size = new System.Drawing.Size(918, 619);
            this.Load += new System.EventHandler(this.downloads_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private string appNameTemp = string.Empty;
        private int maxCount = 0;
        private int count = 0;
        private bool cancelled = false;
        private WebClient _webClient;
        private Task _downloadTask;
        private string downloadLog = string.Empty;
        private static int a = 25;
        private static int b = 10;
        private double result = (double)a / (double)b;
        private readonly string _feedLink = "https://hickos.hickdick.workers.dev/0:/Downloads.json";
        public List<FeedApp> AppsFromFeed = new List<FeedApp>();
        private int downloadCount = 0;
        private string fileExtension = ".exe";
        private List<Guna2CheckBox> checkBoxes = new List<Guna2CheckBox>();
        private int DPI_PREFERENCE;
        private string dl_location;
        private Stopwatch sw = new Stopwatch();
        private static Downloads _instance;
        private UserPreferenceChangedEventHandler UserPreferenceChanged;
        private System.Windows.Forms.Label label266;
        private System.Windows.Forms.Label label1;
        private Guna2VScrollBar Guna2VScrollBar1;
        private Guna2ProgressBar progressBar1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Label label2;
        private Guna2Button btnDownloadApps;
        private Guna2Button button1;
        private Panel panel1;
    }
    #endregion
}
