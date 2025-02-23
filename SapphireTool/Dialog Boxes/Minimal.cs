using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SapphireTool.Classes;

namespace SapphireTool.DialogBoxes
{
    public partial class Minimal : Form
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
        public Minimal()
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
            Process.Start(@"C:\PostInstall\Services\exes.bat");
            Utils.RunCommand("C:\\PostInstall\\Tweaks\\Nsudo.exe", "-U:S -P:E cmd /c C:\\PostInstall\\Services\\Minimal-services.reg");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
            this.Dispose();
        }
    }
}
