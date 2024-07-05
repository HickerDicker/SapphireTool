using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WindowsFormsApplication2.Dialog_Boxes;
using System.Security.Cryptography;

namespace WindowsFormsApplication2
{
    public partial class cleanup : UserControl
    {
        private static cleanup _instace;

        public static cleanup Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new cleanup();
                return _instace;
            }
        }
        public cleanup()
        {
            InitializeComponent();
        }

        private void cleanup_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }
        private void button24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCwLj1srRmurcaJ5TpEg_4iQ");
        }
        private void button21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/4aNYHSEHYw");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cleanmgr.exe";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
            //msgbox
            using (cleared xForm = new cleared())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C ipconfig /flushdns";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
            //msgbox
            using (cleared xForm = new cleared())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C cmd.exe /c Cleanmgr /sageset:65535 & Cleanmgr /sagerun:65535";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("cmd.exe", "/c del /f /q \"%userprofile%\\Cookies\\*.*\"");
            //msgbox
            using (cleared xForm = new cleared())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("cmd.exe", "/c del /f /q \"%userprofile%\\AppData\\Local\\Microsoft\\Windows\\Temporary Internet Files\\*.*");
            //msgbox
            using (cleared xForm = new cleared())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/c del /s /q \"%temp%\"");
            using (cleared xForm = new cleared())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C Dism.exe /online /Cleanup-Image /StartComponentCleanup";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C Dism.exe /online /Cleanup-Image /StartComponentCleanup /ResetBase";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
