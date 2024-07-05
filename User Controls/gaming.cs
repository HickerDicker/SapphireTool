using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using WindowsFormsApplication2.Classes;
using WindowsFormsApplication2.Dialog_Boxes;

namespace WindowsFormsApplication2.User_Controls
{
    public partial class gaming : UserControl
    {
        private static gaming _instace;

        public static gaming Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new gaming();
                return _instace;
            }
        }
        public gaming()
        {
            InitializeComponent();
        }
        private void button24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCwLj1srRmurcaJ5TpEg_4iQ");
        }
        private void button21_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/4aNYHSEHYw");
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers\\Scheduler", "EnablePreemption", 0, RegistryValueKind.DWord);            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RMHdcpKeyglobZero", 0, RegistryValueKind.DWord);
            //msgbox
            using (reverted xForm = new reverted())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Others\\Network\\Run this if you had to install a network driver.bat");
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers\\Scheduler", "EnablePreemption", 1, RegistryValueKind.DWord);            //msgbox
            using (reverted xForm = new reverted())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RMHdcpKeyglobZero", 1, RegistryValueKind.DWord);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "SvcHostSplitThresholdInKB", (object)68764420, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "SvcHostSplitThresholdInKB", (object)103355478, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "SvcHostSplitThresholdInKB", (object)137922056, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "SvcHostSplitThresholdInKB", (object)307767570, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "SvcHostSplitThresholdInKB", (object)376926742, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button12_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "SvcHostSplitThresholdInKB", (object)861226034, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button13_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "SvcHostSplitThresholdInKB", (object)380000, (RegistryValueKind)4);
            //msgbox
            using (reverted xForm = new reverted())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)26, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button14_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)20, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button16_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)21, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button17_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)22, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button18_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)24, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button19_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)25, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button15_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)42, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button20_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)36, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button21_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)37, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button22_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)38, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button23_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)40, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button24_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl", "Win32PrioritySeparation", (object)41, (RegistryValueKind)4);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button26_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("C:\\PostInstall\\GPU\\Nvidia\\NIP\\nvidiaProfileInspector.exe", "/s C:\\PostInstall\\GPU\\Nvidia\\NIP\\Settings.nip");
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button27_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "DisableDynamicPstate", 1, RegistryValueKind.DWord);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button28_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\GPU\\Nvidia\\!No ECC.bat");
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button29_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm\\Global\\Startup", "SendTelemetryData", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\NVIDIA Corporation\\NvControlPanel2\\Client", "OptInOrOutPreference", 0, RegistryValueKind.DWord);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button30_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\GPU\\Nvidia\\!Unrestricted Clock Policy by Cancerogeno.bat");
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button31_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\GPU\\Nvidia\\NVCleanstall_1.16.0.exe");
        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\GPU\\AMD\\AMD Dwords by imribiy.bat");
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button33_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\GPU\\AMD\\radeon software slimmer\\RadeonSoftwareSlimmer.exe");
        }

        private void guna2Button34_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.amd.com/en/support/download/drivers.html");
        }
        private void guna2Button35_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\GPU\\AMD\\disable_dx11navi.exe");
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button36_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4d36e968-e325-11ce-bfc1-08002be10318}\0000\UMD", "ShaderCache", new byte[] { 0x32, 0x00 }, RegistryValueKind.Binary);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button49_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\Autoruns.exe");
        }
        private void guna2Button47_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\DevManView.exe");
        }
        private void guna2Button46_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\serviwin.exe");
        }
        private void guna2Button45_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Mitigations\\InSpectre.exe");
        }
        private void guna2Button44_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\Mouse Polling Test\\MouseTester.exe");
        }
        private void guna2Button43_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\NSudo.exe");
        }
        private void guna2Button48_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\CRU\\CRU.exe");
        }
        private void guna2Button42_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\Auto DSCP & FSE.bat");
        }
        private void guna2Button41_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\MSI Mode Utility.exe");
        }
        private void guna2Button40_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\Administrator\\Desktop\\Dism++10.1.1002.1B\\Dism++x64.exe");
        }
        private void guna2Button39_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\DeviceCleanup.exe");
        }
        private void guna2Button38_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\Interrupt Affinity Policy Tool.exe");
        }
        private void guna2Button50_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\hidusbf\\DRIVER\\Setup.exe");
        }
        private void guna2Button51_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\MeasureSleep.exe");
        }
        private void guna2Button52_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\Process explorer\\Process Explorer.exe");
        }
        private void guna2Button53_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Tweaks\\ReservedCpuSets.exe");
        }
        private void guna2Button57_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\Others\\Network\\Revert Network Tweaks.bat");
            //msgbox
            using (reverted xForm = new reverted())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button54_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\PostInstall\Services\exes enable.bat");
            Utils.RunCommand("C:\\PostInstall\\Tweaks\\Nsudo.exe", "-U:S -P:E cmd /c C:\\PostInstall\\Services\\SapphireOS-Default-services.reg");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\PostInstall\Services\exes enable.bat");
            Utils.RunCommand("C:\\PostInstall\\Tweaks\\Nsudo.exe", "-U:S -P:E cmd /c C:\\PostInstall\\Services\\Windows-Default-services.reg");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button55_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\PostInstall\Services\exes.bat");
            Utils.RunCommand("C:\\PostInstall\\Tweaks\\Nsudo.exe", "-U:S -P:E cmd /c C:\\PostInstall\\Services\\Minimal-services.reg");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button37_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class\{4d36e968-e325-11ce-bfc1-08002be10318}\0000\UMD", "ShaderCache", new byte[] { 0x31, 0x00 }, RegistryValueKind.Binary);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button56_Click(object sender, EventArgs e)
        {
            // I better not see anyone complain about not enough NVIDIA tweaks cause here you go 36 placebo dwords :3 happy?
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RmDisableHwFaultBuffer", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "EnableRuntimePowerManagement", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "DisableOverlay", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "D3PCLatency", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "F1TransitionLatency", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "Node3DLowLatency", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "PciLatencyTimerControl", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RMDeepL1EntryLatencyUsec", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RmGspcMaxFtuS", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RmGspcMinFtuS", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RmGspcPerioduS", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RMLpwrEiIdleThresholdUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RMLpwrGrIdleThresholdUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RMLpwrGrRgIdleThresholdUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RMLpwrMsIdleThresholdUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "VRDirectFlipDPCDelayUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "VRDirectFlipTimingMarginUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "VRDirectJITFlipMsHybridFlipDelayUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "vrrCursorMarginUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "vrrDeflickerMarginUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "vrrDeflickerMaxUs", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "PreferSystemMemoryContiguous", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "TCCSupported", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "RmCacheLoc", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000", "TrackResetEngine", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\NVIDIA Corporation\\Global\\NVTweak\\Devices\\509901423-0\\Color", "NvCplUseColorCorrection", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm\\FTS", "EnableRID61684", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm", "DisplayPowerSaving", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm", "RmGpsPsEnablePerCpuCoreDpc", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm", "DisableWriteCombining", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm", "DisablePreemption", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm", "DisableCudaContextPreemption", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm", "EnableCEPreemption", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm", "DisablePreemptionOnS3S4", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Services\\nvlddmkm", "ComputePreemption", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\GraphicsDrivers", "PlatformSupportMiracast", 0, RegistryValueKind.DWord);
            //msgbox
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
    }
}
