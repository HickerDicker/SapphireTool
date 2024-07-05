using Guna.UI2.WinForms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Management;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using SapphireTool.User_Controls;
using WindowsFormsApplication2.User_Controls;
using WindowsFormsApplication2.Dialog_Boxes;
using WindowsFormsApplication2;

namespace SapphireTool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void guna2Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string manufacturer = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation"))
            {
                if (key != null)
                {
                    object value = key.GetValue("Manufacturer");
                    if (value is string stringValue)
                    {
                        manufacturer = stringValue;
                    }
                }
            }

            if (manufacturer != null && manufacturer.Equals("Hickensa", StringComparison.OrdinalIgnoreCase))
            {
            }
            else
            {
                this.Close();
            }
        }

    private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2Panel3.Controls.Add(downloads.Instance);
            downloads.Instance.Dock = DockStyle.Fill;
            downloads.Instance.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

                foreach (Control control in guna2Panel3.Controls.OfType<UserControl>().ToList())
                {
                    guna2Panel3.Controls.Remove(control);
                }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            using (about xForm = new about())
            {
                xForm.ShowDialog(this);
                GC.Collect();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Panel3.Controls.Add(tweaks.Instance);
            tweaks.Instance.Dock = DockStyle.Fill;
            tweaks.Instance.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel3.Controls.Add(info.Instance);
            info.Instance.Dock = DockStyle.Fill;
            info.Instance.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Panel3.Controls.Add(cleanup.Instance);
            cleanup.Instance.Dock = DockStyle.Fill;
            cleanup.Instance.BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2Panel3.Controls.Add(context.Instance);
            context.Instance.Dock = DockStyle.Fill;
            context.Instance.BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2Panel3.Controls.Add(gaming.Instance);
            gaming.Instance.Dock = DockStyle.Fill;
            gaming.Instance.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            guna2Panel3.Controls.Add(windowsapp.Instance);
            windowsapp.Instance.Dock = DockStyle.Fill;
            windowsapp.Instance.BringToFront();
        }


    }
}
