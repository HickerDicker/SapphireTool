using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using WindowsFormsApplication2.Classes;
using System.Diagnostics;
using System.Xml.Linq;

namespace WindowsFormsApplication2.User_Controls
{
    public partial class tweaks : UserControl
    {
        private static tweaks _instace;
        public static tweaks Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new tweaks();
                return _instace;
            }
        }
        public tweaks()
        {
            InitializeComponent();
        }

        string OSName = Utils.GetOS();
        string OSArch = Utils.GetBitness();

        private void button24_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCwLj1srRmurcaJ5TpEg_4iQ");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/4aNYHSEHYw");
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WlanSvc", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\vwififlt", "Start", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NlaSvc  ", "Start", 2, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\Explorer", "DisableNotificationCenter", 0, RegistryValueKind.DWord);
            Utils.RestartExplorer();
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\cbdhsvc", "Start", 2, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", "HwSchMode", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button16_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthA3dp", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthEnum", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthHFEnum", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthLEEnum", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BTHMODEM", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Microsoft_Bluetooth_AvrcpTransport", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BluetoothUserService", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthAvctpSvc", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\RFCOMM", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\bthserv", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BTAGService", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BTHUSB", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BTHPORT", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthMini", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\HidBth", "Start", 3, RegistryValueKind.DWord);
            Utils.RunCommand("C:\\PostInstall\\Tweaks\\DevManView.exe", "/enable \"Microsoft Radio Device Enumeration Bus");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button14_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\IKEEXT", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BFE", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinHttpAutoProxySvc", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\RasMan", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SstpSvc", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\iphlpsvc", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NdisVirtualBus", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Eaphost", "Start", 3, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button12_Click(object sender, EventArgs e)
        {

            RegistryKey currentUserKey = Registry.CurrentUser;
            currentUserKey.OpenSubKey(@"Software\Microsoft\GameBar", true)?.DeleteValue("GamePanelStartupTipIndex", false);
            currentUserKey.OpenSubKey(@"Software\Microsoft\GameBar", true)?.DeleteValue("AllowAutoGameMode", false);
            currentUserKey.OpenSubKey(@"Software\Microsoft\GameBar", true)?.DeleteValue("AutoGameModeEnabled", false);
            currentUserKey.OpenSubKey(@"Software\Microsoft\GameBar", true)?.SetValue("UseNexusForGameBarEnabled", 1, RegistryValueKind.DWord);
            currentUserKey.OpenSubKey(@"Software\Microsoft\GameBar", true)?.SetValue("ShowStartupPanel", 1, RegistryValueKind.DWord);
            currentUserKey.OpenSubKey(@"System\GameConfigStore", true)?.SetValue("GameDVR_Enabled", 1, RegistryValueKind.DWord);
            currentUserKey.OpenSubKey(@"System\GameConfigStore", true)?.SetValue("GameDVR_FSEBehavior", 0, RegistryValueKind.DWord);
            currentUserKey.OpenSubKey(@"System\GameConfigStore", true)?.SetValue("GameDVR_FSEBehaviorMode", 2, RegistryValueKind.DWord);
            currentUserKey.OpenSubKey(@"System\GameConfigStore", true)?.SetValue("GameDVR_HonorUserFSEBehaviorMode", 0, RegistryValueKind.DWord);
            currentUserKey.OpenSubKey(@"System\GameConfigStore", true)?.SetValue("GameDVR_DXGIHonorFSEWindowsCompatible", 0, RegistryValueKind.DWord);
            currentUserKey.OpenSubKey(@"System\GameConfigStore", true)?.SetValue("GameDVR_EFSEFeatureFlags", 1, RegistryValueKind.DWord);
            currentUserKey.OpenSubKey(@"System\GameConfigStore", true)?.DeleteValue("GameDVR_DSEBehavior", false);
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\GameDVR", true)?.DeleteValue("AllowGameDVR", false);
            currentUserKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR", true)?.SetValue("AppCaptureEnabled", 1, RegistryValueKind.DWord);
            Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\BcastDVRUserService", true)?.SetValue("Start", 3, RegistryValueKind.DWord);
            Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", true)?.DeleteValue("__COMPAT_LAYER", false);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SysMain", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\FontCache", "Start", 2, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button32_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Spooler", "Start", 2, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button30_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\AppInfo", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ValidateAdminCodeSignatures", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button28_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\AppInfo", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button26_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("bcdedit.exe", "/set hypervisorlaunchtype auto");
            Utils.RunCommand("bcdedit.exe", "/deletevalue vm");
            Utils.RunCommand("bcdedit.exe", "/deletevalue loadoptions");
            Utils.RunCommand("DISM", "/Online /Enable-Feature:Microsoft-Hyper-V-All /Quiet /NoRestart");
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("EnableVirtualizationBasedSecurity", false);
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("RequirePlatformSecurityFeatures", false);
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("HypervisorEnforcedCodeIntegrity", false);
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("HVCIMATRequired", false);
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("LsaCfgFlags", false);
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("ConfigureSystemGuardLaunch", false);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "RequireMicrosoftSignedBootChain", 1, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "EnableVirtualizationBasedSecurity", 1, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "RequirePlatformSecurityFeatures", 1, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "Locked", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity", "Enabled", 1, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity", "Locked", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity", "WasEnabledBy", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button24_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\GPU\\Nvidia\\mpo enable.bat");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button20_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("bcdedit.exe", "/set NX OptIn");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button18_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", "SerializeTimerExpiration", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button42_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AltTabSettings", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "HoverSelectDesktops", 0, RegistryValueKind.DWord);
            Utils.RestartExplorer();
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button40_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("bcdedit.exe", "/set bootmenupolicy legacy");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button38_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("fsutil", "behavior set disableencryption 0");
            Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Policies", true)?.DeleteValue("NtfsDisableEncryption", false);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button36_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WpnService", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", "NOC_GLOBAL_SETTING_ALLOW_NOTIFICATION_SOUND", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener", "Value", "Allow", RegistryValueKind.String);
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PushNotifications", true)?.DeleteValue("ToastEnabled", false);
            Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications", true)?.DeleteValue("NoCloudApplicationNotification", false);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button34_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\cdrom", "Start", 3, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WlanSvc", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\vwififlt", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NlaSvc  ", "Start", 4, RegistryValueKind.DWord);
            if (OSName.Contains("Windows 11"))
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 3, RegistryValueKind.DWord);
            }
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\Explorer", "DisableNotificationCenter", 1, RegistryValueKind.DWord);
            Utils.RestartExplorer();
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\cbdhsvc", "Start", 4, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", "HwSchMode", 2, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button15_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthA4dp", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthEnum", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthHFEnum", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthLEEnum", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BTHMODEM", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Microsoft_Bluetooth_AvrcpTransport", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BluetoothUserService", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthAvctpSvc", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\RFCOMM", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\bthserv", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BTAGService", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BTHUSB", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BTHPORT", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthMini", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\HidBth", "Start", 4, RegistryValueKind.DWord);
            Utils.RunCommand("C:\\PostInstall\\Tweaks\\DevManView.exe", "/disable \"Microsoft Radio Device Enumeration Bus");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button13_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\IKEEXT", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinHttpAutoProxySvc", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\RasMan", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SstpSvc", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\iphlpsvc", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NdisVirtualBus", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Eaphost", "Start", 4, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "ShowStartupPanel", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "GamePanelStartupTipIndex", 3, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "AllowAutoGameMode", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "AutoGameModeEnabled", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\GameBar", "UseNexusForGameBarEnabled", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehaviorMode", 2, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehavior", 2, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_HonorUserFSEBehaviorMode", 1, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_DXGIHonorFSEWindowsCompatible", 1, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_EFSEFeatureFlags", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_DSEBehavior", 2, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\GameDVR", "AllowGameDVR", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR", "AppCaptureEnabled", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\BcastDVRUserService", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "__COMPAT_LAYER", "~ DISABLEDXMAXIMIZEDWINDOWEDMODE", RegistryValueKind.String);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SysMain", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\FontCache", "Start", 2, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button31_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Spooler", "Start", 4, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button29_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\AppInfo", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ValidateAdminCodeSignatures", 0, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button27_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\AppInfo", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", 0, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button25_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("bcdedit.exe", "/set hypervisorlaunchtype off");
            Utils.RunCommand("bcdedit.exe", "/set vm no");
            Utils.RunCommand("bcdedit.exe", "/set vsmlaunchtype Off");
            Utils.RunCommand("bcdedit.exe", "/set loadoptions DISABLE-LSA-ISO,DISABLE-VBS");
            Utils.RunCommand("DISM", "/Online /Disable-Feature:Microsoft-Hyper-V-All /Quiet /NoRestart");
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", "EnableVirtualizationBasedSecurity", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", "RequirePlatformSecurityFeatures", 1, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", "HypervisorEnforcedCodeIntegrity", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", "HVCIMATRequired", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", "LsaCfgFlags", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", "ConfigureSystemGuardLaunch", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "RequireMicrosoftSignedBootChain", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity", "WasEnabledBy", 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity", "Enabled", 0, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button23_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\PostInstall\\GPU\\Nvidia\\mpo disable.bat");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button19_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("bcdedit.exe", "/set NX AlwaysOff");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button17_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", "SerializeTimerExpiration", 2, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button41_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AltTabSettings", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "HoverSelectDesktops", 1, RegistryValueKind.DWord);
            Utils.RestartExplorer();
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button39_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("bcdedit.exe", "/set bootmenupolicy standard");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button37_Click(object sender, EventArgs e)
        {
            Utils.RunCommand("fsutil", "behavior set disableencryption 1");
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Policies", "NtfsDisableEncryption", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button35_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WpnService", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", "NOC_GLOBAL_SETTING_ALLOW_NOTIFICATION_SOUND", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener", "Value", "Deny", RegistryValueKind.String);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", "ToastEnabled", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", "NoCloudApplicationNotification", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button33_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\cdrom", "Start", 4, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button44_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "NoLazyMode", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "AlwaysOn", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button43_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "NoLazyMode", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "AlwaysOn", 0, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button46_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\KSecPkg", "Start", 0, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\LanmanWorkstation", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\mrxsmb", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\mrxsmb20", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\rdbss", "Start", 1, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\srv2", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\QwaveDrv", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\Qwave", "Start", 3, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\FontCache", "Start", 2, RegistryValueKind.DWord);
            Utils.RunCommand("cmd", "/c DISM /Online /Enable-Feature /FeatureName:SmbDirect /NoRestart");
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button45_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\KSecPkg", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\LanmanWorkstation", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\mrxsmb", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\mrxsmb20", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\rdbss", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\srv2", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\QwaveDrv", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\Qwave", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\FontCache", "Start", 4, RegistryValueKind.DWord);
            Utils.RunCommand("cmd", "/c DISM /Online /Disable-Feature /FeatureName:SmbDirect /NoRestart");
            if (OSName.Contains("Windows 11"))
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\KSecPkg", "Start", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\srv2", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\mrxsmb20", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\LanmanWorkstation", "Start", 2, RegistryValueKind.DWord);
            }
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
        private void guna2Button22_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Control\\Session Manager\\kernel", "DisableTsx", 0, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Control\\Session Manager\\kernel", "DisableTsx", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button48_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", "LargeSystemCache", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button47_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", "LargeSystemCache", 0, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button50_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", "ThreadDpcEnable", 1, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button49_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", "ThreadDpcEnable", 0, RegistryValueKind.DWord);
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button52_Click(object sender, EventArgs e)
        {
            if (OSName.Contains("Windows 11"))
            {
                Process.Start(@"C:\PostInstall\Others\Startmenu\enable startmenu 11.bat");
            }
            else
            {
                Process.Start(@"C:\PostInstall\Others\Startmenu\enable startmenu.bat");
            }
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button51_Click(object sender, EventArgs e)
        {
            if (OSName.Contains("Windows 11"))
            {
                Process.Start(@"C:\PostInstall\Others\Startmenu\disable startmenu 11.bat");
            }
            else
            {
                Process.Start(@"C:\PostInstall\Others\Startmenu\disable startmenu 10 and server.bat");
            }
            //Message box displays
            using (applied xForm = new applied())
            {
                xForm.ShowDialog(this);
            }
        }
    }
}