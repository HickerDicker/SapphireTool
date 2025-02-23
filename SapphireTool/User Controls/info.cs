using System;
using System.Windows.Forms;

namespace SapphireTool.UserControls
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
            label2.Text = "Operating System: " + OSName;
            label4.Text = OSArch;
            label7.Text = "Build: " + BuildNumber;
            label15.Text = "CPU: " + CPUName;
            label22.Text = "CPU Threads: " + CPUThreads + " Threads";
            label12.Text = "Ram Capacity: " + RAM;
            label13.Text = "Ram Manufacturer: " + RAMman;
            label11.Text = "Ram Clock: "+ RAMClock;
            label16.Text = "CPU Cores: " + CPUCores + " Cores";
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

