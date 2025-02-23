using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace SapphireTool.UserControls
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
            ReadSettings();
            if (OSName.Contains("Windows 11") || BuildNumber.Contains("26100") || BuildNumber.Contains("20348"))
            {
                tsTimer.Hide();
                label33.Hide();
                label34.Show();
            }
            else
            {
                label34.Hide();
            }
        }

        string OSName = Utils.GetOS();
        string OSArch = Utils.GetBitness();
        string BuildNumber = Utils.GetBuildNumber();
        private void button24_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCwLj1srRmurcaJ5TpEg_4iQ");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/4aNYHSEHYw");
        }

        public static RegistryKey SapphireTool = Registry.CurrentUser.CreateSubKey(@"Software\SapphireTool", RegistryKeyPermissionCheck.ReadWriteSubTree);
        private void ReadSettings()
        {
            RegistryKey key = SapphireTool;

            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableBluetooth", tsDisableBluetooth);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableFSO", tsDisableFSO);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisablePrefetch", tsDisablePrefetch);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableHyperV", tsDisableHyperV);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisablePrinter", tsDisablePrintSpooler);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableVPN", tsDisableVPN);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableWiFi", tsDisableWiFI);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableHAGS", tsEnableHAGS);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "ActionCenter", tsDisableActionCenter);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableUAC", tsEnableUAC);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableClipboardSvc", tsEnableClipboardSvc);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableAdminUAC", tsEnableAdminUAC);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableMPO", tsDisableMPO);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableTSX", tsTSX);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableNX", tsDisableNX);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableClassicAltTab", tsAltTab);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "BootMenuPolicy", tsBoot);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableNTFSEncryption", tsEncryption);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableNotifications", tsNotifications);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableCDROM", tsCDROMSvc);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "NoLazyMode", tsNoLazy); // Always develop no lazy men )))
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableVR", tsVR);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableLargeSystemCache", tsLSC);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableStartmenu", tsStartmenu);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableLockScreen", tsLockScreen);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "WallpaperQuality", tsWallpaper);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "TransparencyEffects", tsTransparency);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableDCOM", tsDCOM);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableSerializeTimerExpiration", tsSTEX);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableTimerResW10", tsTimer);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableAnimations", tsAnimations);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "SystemProfile", tsSysProfile);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "NVMETweaks", tsNVMETweaks);
        }
        private void tsLSC_CheckedChanged(object sender, EventArgs e)
        {
            if (tsLSC.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableLargeSystemCache");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", "LargeSystemCache", 1, RegistryValueKind.DWord);
                    SapphireTool.SetValue("EnableLargeSystemCache", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", "LargeSystemCache", 0, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("EnableLargeSystemCache");
            }
        }
        private void tsDisableWiFI_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableWiFI.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableWiFi");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WlanSvc", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\vwififlt", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NlaSvc  ", "Start", 4, RegistryValueKind.DWord);
                    if (OSName.Contains("Windows 11"))
                    {
                        Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 3, RegistryValueKind.DWord);
                    }
                    SapphireTool.SetValue("DisableWiFi", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WlanSvc", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\vwififlt", "Start", 1, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NlaSvc  ", "Start", 2, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("DisableWiFi");
            }
        }

        private void tsDisableBluetooth_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableBluetooth.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableBluetooth");
                if (null != aVal)
                {
                }
                else
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
                    SapphireTool.SetValue("DisableBluetooth", 1);
                }
            }
            else
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
                SapphireTool.DeleteValue("DisableBluetooth");
            }
        }

        private void tsEnableHAGS_CheckedChanged(object sender, EventArgs e)
        {
            if (tsEnableHAGS.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableHAGS");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", "HwSchMode", 2, RegistryValueKind.DWord);
                    SapphireTool.SetValue("EnableHAGS", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", "HwSchMode", 1, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("EnableHAGS");
            }
        }

        private void tsEnableClipboardSvc_CheckedChanged(object sender, EventArgs e)
        {
            if (tsEnableClipboardSvc.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableClipboardSvc");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\cbdhsvc", "Start", 2, RegistryValueKind.DWord);
                    SapphireTool.SetValue("EnableClipboardSvc", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\cbdhsvc", "Start", 4, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("EnableClipboardSvc");
            }
        }

        private void tsDisableVPN_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableVPN.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableVPN");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\IKEEXT", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinHttpAutoProxySvc", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\RasMan", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SstpSvc", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\iphlpsvc", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NdisVirtualBus", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Eaphost", "Start", 4, RegistryValueKind.DWord);
                    SapphireTool.SetValue("DisableVPN", 1);
                }

            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\IKEEXT", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BFE", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WinHttpAutoProxySvc", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\RasMan", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SstpSvc", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\iphlpsvc", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NdisVirtualBus", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Eaphost", "Start", 3, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("DisableVPN");
            }
        }

        private void tsDisablePrefetch_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisablePrefetch.Checked)
            {
                object aVal = SapphireTool.GetValue("DisablePrefetch");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SysMain", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\FontCache", "Start", 4, RegistryValueKind.DWord);

                    SapphireTool.SetValue("DisablePrefetch", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SysMain", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\FontCache", "Start", 2, RegistryValueKind.DWord);

                SapphireTool.DeleteValue("DisablePrefetch");
            }
        }

        private void tsDisablePrintSpooler_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisablePrintSpooler.Checked)
            {
                object aVal = SapphireTool.GetValue("DisablePrinter");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Spooler", "Start", 4, RegistryValueKind.DWord);
                    SapphireTool.SetValue("DisablePrinter", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Spooler", "Start", 2, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("DisablePrinter");
            }
        }

        private void tsDisableHyperV_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableHyperV.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableHyperV");
                if (null != aVal)
                {
                }
                else
                {
                    Utils.RunCommand("bcdedit", "/set hypervisorlaunchtype off");
                    Utils.RunCommand("bcdedit", "/set vm no");
                    Utils.RunCommand("bcdedit", "/set vsmlaunchtype Off");
                    Utils.RunCommand("bcdedit", "/set loadoptions DISABLE-LSA-ISO,DISABLE-VBS");
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
                    SapphireTool.SetValue("DisableHyperV", 1);
                }
            }
            else
            {
                Utils.RunCommand("bcdedit", "/set hypervisorlaunchtype auto");
                Utils.RunCommand("bcdedit", "/deletevalue vm");
                Utils.RunCommand("bcdedit", "/deletevalue loadoptions");
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
                SapphireTool.DeleteValue("DisableHyperV");
            }
        }


        private void tsDisableMPO_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableMPO.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableMPO");
                if (null != aVal)
                {
                }
                else
                {
                    Process.Start("C:\\PostInstall\\GPU\\Nvidia\\mpo disable.bat");
                    SapphireTool.SetValue("DisableMPO", 1);
                }
            }
            else
            {
                Process.Start("C:\\PostInstall\\GPU\\Nvidia\\mpo enable.bat");
                SapphireTool.DeleteValue("DisableMPO");
            }
        }

        private void tsDisableNX_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableNX.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableNX");
                if (null != aVal)
                {
                }
                else
                {
                    Utils.RunCommand("bcdedit", "/set NX AlwaysOff");
                    SapphireTool.SetValue("DisableNX", 1);
                }
            }
            else
            {
                Utils.RunCommand("bcdedit", "/set NX OptIn");
                SapphireTool.DeleteValue("DisableNX");
            }
        }

        private void tsDisableFSO_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableFSO.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableFSO");
                if (null != aVal)
                {
                }
                else
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
                    SapphireTool.SetValue("DisableFSO", 1);
                }
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehaviorMode", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_FSEBehavior", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_HonorUserFSEBehaviorMode", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_DXGIHonorFSEWindowsCompatible", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_EFSEFeatureFlags", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_DSEBehavior", 0, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("DisableFSO");
            }
        }

        private void tsNoLazy_CheckedChanged(object sender, EventArgs e)
        {
            if (tsNoLazy.Checked)
            {
                object aVal = SapphireTool.GetValue("NoLazyMode");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "NoLazyMode", 1, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "AlwaysOn", 1, RegistryValueKind.DWord);
                    SapphireTool.SetValue("NoLazyMode", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "NoLazyMode", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "AlwaysOn", 0, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("NoLazyMode");
            }
        }

        private void tsDisableActionCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableActionCenter.Checked)
            {
                object aVal = SapphireTool.GetValue("ActionCenter");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\Explorer", "DisableNotificationCenter", 1, RegistryValueKind.DWord);
                    Utils.RestartExplorer();
                    SapphireTool.SetValue("ActionCenter", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Policies\\Microsoft\\Windows\\Explorer", "DisableNotificationCenter", 0, RegistryValueKind.DWord);
                Utils.RestartExplorer();
                SapphireTool.DeleteValue("ActionCenter");
            }
        }

        private void tsBoot_CheckedChanged(object sender, EventArgs e)
        {
            if (tsBoot.Checked)
            {
                object aVal = SapphireTool.GetValue("BootMenuPolicy");
                if (null != aVal)
                {
                }
                else
                {
                    Utils.RunCommand("bcdedit.exe", "/set bootmenupolicy Standard");
                    SapphireTool.SetValue("BootMenuPolicy", 1);
                }
            }
            else
            {
                Utils.RunCommand("bcdedit.exe", "/set bootmenupolicy legacy");
                SapphireTool.DeleteValue("BootMenuPolicy");
            }
        }

        private void tsEncryption_CheckedChanged(object sender, EventArgs e)
        {
            if (tsEncryption.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableNTFSEncryption");
                if (null != aVal)
                {
                }
                else
                {
                    Utils.RunCommand("fsutil", "behavior set disableencryption 1");
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Policies", "NtfsDisableEncryption", 1, RegistryValueKind.DWord);
                    SapphireTool.SetValue("DisableNTFSEncryption", 1);
                }
            }
            else
            {
                Utils.RunCommand("fsutil", "behavior set disableencryption 0");
                Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Policies", true)?.DeleteValue("NtfsDisableEncryption", false);
                SapphireTool.DeleteValue("DisableNTFSEncryption");
            }
        }

        private void tsEnableUAC_CheckedChanged(object sender, EventArgs e)
        {
            if (tsEnableUAC.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableUAC");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\AppInfo", "Start", 2, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", 1, RegistryValueKind.DWord);
                    SapphireTool.SetValue("EnableUAC", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\AppInfo", "Start", 4, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "EnableLUA", 0, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("EnableUAC");
            }
        }

        private void tsEnableAdminUAC_CheckedChanged(object sender, EventArgs e)
        {
            if (tsEnableAdminUAC.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableAdminUAC");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\AppInfo", "Start", 2, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ValidateAdminCodeSignatures", 1, RegistryValueKind.DWord);
                    SapphireTool.SetValue("EnableAdminUAC", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\AppInfo", "Start", 4, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ValidateAdminCodeSignatures", 0, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("EnableAdminUAC");
            }
        }

        private void tsVR_CheckedChanged(object sender, EventArgs e)
        {
            if (tsVR.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableVR");
                if (null != aVal)
                {
                }
                else
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
                    SapphireTool.SetValue("EnableVR", 1);
                }
            }
            else
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
                SapphireTool.DeleteValue("EnableVR");
            }
        }

        private void tsCDROMSvc_CheckedChanged(object sender, EventArgs e)
        {
            if (tsCDROMSvc.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableCDROM");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\cdrom", "Start", 3, RegistryValueKind.DWord);
                    SapphireTool.SetValue("EnableCDROM", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\cdrom", "Start", 4, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("EnableCDROM");
            }
        }

        private void tsTSX_CheckedChanged(object sender, EventArgs e)
        {
            if (tsTSX.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableTSX");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Control\\Session Manager\\kernel", "DisableTsx", 0, RegistryValueKind.DWord);
                    SapphireTool.SetValue("EnableTSX", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Control\\Session Manager\\kernel", "DisableTsx", 1, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("EnableTSX");
            }
        }

        private void tsSTEX_CheckedChanged(object sender, EventArgs e)
        {
            if (tsSTEX.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableSerializeTimerExpiration");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", "SerializeTimerExpiration", 2, RegistryValueKind.DWord);
                    SapphireTool.SetValue("DisableSerializeTimerExpiration", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\kernel", "SerializeTimerExpiration", 1, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("DisableSerializeTimerExpiration");
            }
        }

        private void tsAltTab_CheckedChanged(object sender, EventArgs e)
        {
            if (tsAltTab.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableClassicAltTab");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AltTabSettings", 1, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "HoverSelectDesktops", 0, RegistryValueKind.DWord);
                    SapphireTool.SetValue("EnableClassicAltTab", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AltTabSettings", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "HoverSelectDesktops", 1, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("EnableClassicAltTab");
            }
        }

        private void tsNotifications_CheckedChanged(object sender, EventArgs e)
        {
            if (tsNotifications.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableNotifications");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WpnService", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", "NOC_GLOBAL_SETTING_ALLOW_NOTIFICATION_SOUND", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener", "Value", "Deny", RegistryValueKind.String);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", "ToastEnabled", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", "NoCloudApplicationNotification", 1, RegistryValueKind.DWord);
                    SapphireTool.SetValue("DisableNotifications", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WpnService", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings", "NOC_GLOBAL_SETTING_ALLOW_NOTIFICATION_SOUND", 1, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener", "Value", "Allow", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PushNotifications", true)?.DeleteValue("ToastEnabled", false);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications", true)?.DeleteValue("NoCloudApplicationNotification", false);
                SapphireTool.DeleteValue("DisableNotifications");
            }
        }

        private void tsStartmenu_CheckedChanged(object sender, EventArgs e)
        {
            if (tsStartmenu.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableStartmenu");
                if (null != aVal)
                {
                }
                else
                {
                    if (OSName.Contains("Windows 11"))
                    {
                        Process.Start(@"C:\PostInstall\Others\Startmenu\disable startmenu 11.bat");
                    }
                    else
                    {
                        Process.Start(@"C:\PostInstall\Others\Startmenu\disable startmenu 10 and server.bat");
                    }
                    SapphireTool.SetValue("DisableStartmenu", 1);
                }
            }
            else
            {
                if (OSName.Contains("Windows 11"))
                {
                    Process.Start(@"C:\PostInstall\Others\Startmenu\enable startmenu 11.bat");
                }
                else
                {
                    Process.Start(@"C:\PostInstall\Others\Startmenu\enable startmenu.bat");
                }
                SapphireTool.DeleteValue("DisableStartmenu");
            }
        }

        private void tsLockScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (tsLockScreen.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableLockScreen");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\Personalization", "NoLockScreen", 1, RegistryValueKind.DWord);
                    SapphireTool.SetValue("DisableLockScreen", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\Personalization", "NoLockScreen", 0, RegistryValueKind.DWord);
                SapphireTool.DeleteValue("DisableLockScreen");
            }
        }

        private void tsWallpaper_CheckedChanged(object sender, EventArgs e)
        {
            if (tsWallpaper.Checked)
            {
                object aVal = SapphireTool.GetValue("WallpaperQuality");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "JPEGImportQuality", 100, RegistryValueKind.DWord);
                    SapphireTool.SetValue("WallpaperQuality", 1);
                }
            }
            else
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                currentUserKey.OpenSubKey(@"Control Panel\Desktop", true)?.DeleteValue("JPEGImportQuality", false);
                SapphireTool.DeleteValue("WallpaperQuality");
            }
        }

        private void tsTransparency_CheckedChanged(object sender, EventArgs e)
        {
            if (tsTransparency.Checked)
            {
                 object aVal = SapphireTool.GetValue("TransparencyEffects");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "EnableTransparency", 1, RegistryValueKind.DWord);
                    Utils.RestartExplorer();
                    SapphireTool.SetValue("TransparencyEffects", 1);
                }
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "EnableTransparency", 0, RegistryValueKind.DWord);
                Utils.RestartExplorer();
                SapphireTool.DeleteValue("TransparencyEffects");
            }
        }

        private void tsDCOM_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDCOM.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableDCOM");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Ole", "EnableDCOM", "N", RegistryValueKind.String);
                    SapphireTool.SetValue("DisableDCOM", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Ole", "EnableDCOM", "Y", RegistryValueKind.String);
                SapphireTool.DeleteValue("DisableDCOM");
            }
        }

        private void tsTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (tsTimer.Checked)
            {
                object aVal = SapphireTool.GetValue("EnableTimerResW10");
                if (null != aVal)
                {
                }
                else
                {
                    using (SapphireTool.DialogBoxes.Timer xForm = new SapphireTool.DialogBoxes.Timer())
                    {
                        xForm.ShowDialog(this);
                        GC.Collect();
                    }
                }
            }
            else
            {
                Utils.RunCommand("bcdedit", "/set testsigning off");
                Utils.RunCommand("sc", "delete Timer");
                Utils.RunCommand("shutdown", "-r -t -c \"Timer Resolution has been disabled!\" \"10");
                File.Delete("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\SetTimerResolution.lnk");
                SapphireTool.DeleteValue("EnableTimerResW10");
            }
        }

        private void tsAnimations_CheckedChanged(object sender, EventArgs e)
        {
            if (tsAnimations.Checked)
            {
                object aVal = SapphireTool.GetValue("DisableAnimations");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", "DisallowAnimations", 1, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\DWM", "EnableAeroPeek", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\DWM", "AlwaysHibernateThumbnails", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop\\WindowMetrics", "MinAnimate", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarAnimations", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "IconsOnly", 1, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ListviewAlphaSelect", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ListviewShadow", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects", "VisualFXSetting", 3, RegistryValueKind.DWord);
                    byte[] userPreferencesMaskData = new byte[8] { 144, 18, 3, 128, 16, 0, 0, 0 };
                    Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "UserPreferencesMask", userPreferencesMaskData, RegistryValueKind.Binary);
                    SapphireTool.SetValue("DisableAnimations", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", "EnableAeroPeek", 1, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", "AlwaysHibernateThumbnails", 1, RegistryValueKind.DWord);
                RegistryKey localMachineKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DWM", writable: true);
                if (localMachineKey != null)
                {
                    localMachineKey.DeleteValue("DisallowAnimations", throwOnMissingValue: false);
                    localMachineKey.Close();
                }
                RegistryKey currentUserKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop\\WindowMetrics", writable: true);
                if (currentUserKey != null)
                {
                    currentUserKey.DeleteValue("MinAnimate", throwOnMissingValue: false);
                    currentUserKey.Close();
                }
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarAnimations", 1, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "IconsOnly", 0, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ListviewAlphaSelect", 1, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "ListviewShadow", 1, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects", "VisualFXSetting", 1, RegistryValueKind.DWord);
                byte[] userPreferencesMaskData = new byte[8] { 158, 62, 7, 128, 18, 0, 0, 0 };
                Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "UserPreferencesMask", userPreferencesMaskData, RegistryValueKind.Binary);
                SapphireTool.DeleteValue("DisableAnimations");
            }
        }

        private void tsSysProfile_CheckedChanged(object sender, EventArgs e)
        {
            if (tsSysProfile.Checked)
            {
                object aVal = SapphireTool.GetValue("SystemProfile");
                if (null != aVal)
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "Affinity", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "Background Only", "False", RegistryValueKind.String);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "Clock Rate", 2710, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "GPU Priority", 8, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "Priority", 8, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "SFIO Priority", "High", RegistryValueKind.String);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Pro Audio", "Priority", 8, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Pro Audio", "Scheduling Category", "Medium", RegistryValueKind.String);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Audio", "Priority", 8, RegistryValueKind.DWord);
                }
                else
                {
                    SapphireTool.SetValue("SystemProfile", 1);
                }
            }
            else
            {
                RegistryKey LocalMachineKey = Registry.LocalMachine;
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", true)?.DeleteValue("Affinity", false);
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", true)?.DeleteValue("Background Only", false);
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", true)?.DeleteValue("Clock Rate", false);
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", true)?.DeleteValue("GPU Priority", false);
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", true)?.DeleteValue("Priority", false);
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Games", true)?.DeleteValue("SFIO Priority", false);
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Pro Audio", true)?.DeleteValue("Priority", false);
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Pro Audio", true)?.DeleteValue("Scheduling Category", false);
                LocalMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks\Audio", true)?.DeleteValue("Priority", false);
                SapphireTool.DeleteValue("SystemProfile");
            }
        }

        private void tsNVMETweaks_CheckedChanged(object sender, EventArgs e)
        {
            if (tsNVMETweaks.Checked)
            {
                object aVal = SapphireTool.GetValue("NVMETweaks");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\stornvme\\Parameters\\Device", "ContiguousMemoryFromAnyNode", 1, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\stornvme\\Parameters\\Device", "LogSize", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\stornvme\\Parameters\\Device", "IdlePowerMode", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\stornvme\\Parameters\\Device", "DiagnosticFlags", 0, RegistryValueKind.DWord);
                    SapphireTool.SetValue("NVMETweaks", 1);
                }
            }
            else
            {
                RegistryKey LocalMachineKey = Registry.LocalMachine;
                LocalMachineKey.OpenSubKey(@"SYSTEM\ControlSet001\Services\stornvme\Parameters\Device", true)?.DeleteValue("ContiguousMemoryFromAnyNode", false);
                LocalMachineKey.OpenSubKey(@"SYSTEM\ControlSet001\Services\stornvme\Parameters\Device", true)?.DeleteValue("LogSize", false);
                LocalMachineKey.OpenSubKey(@"SYSTEM\ControlSet001\Services\stornvme\Parameters\Device", true)?.DeleteValue("IdlePowerMode", false);
                LocalMachineKey.OpenSubKey(@"SYSTEM\ControlSet001\Services\stornvme\Parameters\Device", true)?.DeleteValue("DiagnosticFlags", false);
                SapphireTool.DeleteValue("NVMETweaks");
            }
        }
    }
}