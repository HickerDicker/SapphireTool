using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApplication2.Dialog_Boxes
{
    public partial class Timer : Form
    {
        private Point mouseOffset;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect,     // x-coordinate of upper-left corner
    int nTopRect,      // y-coordinate of upper-left corner
    int nRightRect,    // x-coordinate of lower-right corner
    int nBottomRect,   // y-coordinate of lower-right corner
    int nWidthEllipse, // width of ellipse
    int nHeightEllipse // height of ellipse
);
        public Timer()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            button1.Click += button1_Click;
        }
        public static RegistryKey SapphireTool = Registry.CurrentUser.CreateSubKey(@"Software\SapphireTool", RegistryKeyPermissionCheck.ReadWriteSubTree);

        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        WebClient dl = new WebClient();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_Paint(object sender, MouseEventArgs e)
        {

        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Windows\\SysWoW64\\lv-LV\\TimerResolution"))
            {
                Utils.RunCommand("bcdedit", "/set testsigning on");
                Utils.RunCommand("sc", "create Timer binPath=\"C:\\\\Windows\\\\SysWoW64\\\\lv-LV\\\\TimerResolution\\\\timer.sys\" type=kernel");
                await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/SetTimerResolution.exe.lnk"), "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\SetTimerResolution.lnk");
                Utils.RunCommand("shutdown", "-r -t -c \"Timer Resolution has been enabled!\" \"10");
            }
            else
            {
                dl = new WebClient();
                Directory.CreateDirectory("C:\\Windows\\SysWoW64\\lv-LV\\TimerResolution");
                await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/timer.cat"), "C:\\Windows\\SysWoW64\\lv-LV\\TimerResolution\\timer.cat");
                await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/timer.sys"), "C:\\Windows\\SysWoW64\\lv-LV\\TimerResolution\\timer.sys");
                await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/timer.inf"), "C:\\Windows\\SysWoW64\\lv-LV\\TimerResolution\\timer.inf");
                await dl.DownloadFileTaskAsync(new Uri("https://github.com/valleyofdoom/TimerResolution/releases/download/SetTimerResolution-v1.0.0/SetTimerResolution.exe"), "C:\\Windows\\SysWoW64\\lv-LV\\TimerResolution\\SetTimerResolution.exe");
                await dl.DownloadFileTaskAsync(new Uri("https://hickos.hickdick.workers.dev/0:/SetTimerResolution.exe.lnk"), "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\SetTimerResolution.lnk");
            }
            Utils.RunCommand("bcdedit", "/set testsigning on");
            Utils.RunCommand("sc", "create Timer binPath=\"C:\\Windows\\SysWoW64\\lv-LV\\TimerResolution\\timer.sys\" type=kernel start= auto error= normal");
            Utils.RunCommand("sc", "Timer start=Boot");
            Utils.RunCommand("shutdown", "-r -t 10");
            SapphireTool.SetValue("EnableTimerResW10", 1);
            this.Dispose();
        }
    }
}
