using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2.Dialog_Boxes;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Drawing2D;
using System.Management;

namespace WindowsFormsApplication2.User_Controls
{
    public partial class info : UserControl
    {
        private static info _instace;
        string OSName = Utils.GetOS();
        string OSArch = Utils.GetBitness();
        string BuildNumber = Utils.GetBuildNumber();
        string CPUName = Utils.GetCPU();
        string CPUThreads = Utils.GetThreads();
        string RAM = Utils.GetRAM();
        string RAMman = Utils.GetRAMManufacturer();
        string RAMClock = Utils.GetRAMClock();
        string CPUCores = Utils.GetCPUCores();
        public static info Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new info();
                return _instace;
            }
        }
        public info()
        {
            InitializeComponent();
            label3.Text = OSName;
            label4.Text = OSArch;
            label8.Text = BuildNumber;
            label17.Text = CPUName;
            label18.Text = CPUThreads + " Threads";
            label19.Text = RAM;
            label20.Text = RAMman;
            label21.Text = RAMClock;
            label23.Text = CPUCores + " Cores";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCwLj1srRmurcaJ5TpEg_4iQ");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/4aNYHSEHYw");
        }
    }
}

