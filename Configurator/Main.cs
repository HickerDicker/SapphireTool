using Guna.UI2.WinForms;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Configurator.Classes;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Configurator
{
    public partial class Main : Form
    {

        public static RegistryKey Configurator = Registry.CurrentUser.CreateSubKey(@"Software\Configurator", RegistryKeyPermissionCheck.ReadWriteSubTree);
        private string DownloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

        //Registry Keys

        string dwmRegistryPath = @"SOFTWARE\Policies\Microsoft\Windows\DWM";
        string windowMetricsRegistryPath = @"Control Panel\Desktop\WindowMetrics";
        string explorerAdvancedRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        string visualEffectsRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects";
        string desktopRegistryPath = @"Control Panel\Desktop";
        string gameBarRegistryPath = @"Software\Microsoft\GameBar";
        string gameConfigStoreRegistryPath = @"System\GameConfigStore";
        string gameDVRRegistryPath = @"SOFTWARE\Policies\Microsoft\Windows\GameDVR";
        string currentVersionGameDVRRegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\GameDVR";
        string bcastDVRUserServiceRegistryPath = @"SYSTEM\CurrentControlSet\Services\BcastDVRUserService";
        string sessionManagerEnvironmentRegistryPath = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";

        public Main()
        {
            InitializeComponent();
            ReadSettings();
            GetOSInfo();
        }

        //Read Settings
        private void ReadSettings()
        {
            RegistryKey key = Configurator;

            Utils.CheckRegistryValueAndSetToggleSwitch(key, "AnimationsDisabled", tsDisableAnimation);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableBackgroundApps", tsDisableBackgroundApps);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableBluetooth", tsDisableBluetooth);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableClipboard", tsDisableClipboard);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableFSO", tsDisableFSO);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisablePrefetch", tsDisablePrefetch);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableHyperV", tsDisableHyperV);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableWorkstation", tsDisableWorkstation);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableNetworkDiscovery", tsDisableNetworkDiscovery);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableNotifications", tsDisableNotifcations);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisablePrinter", tsDisablePrintSpooler);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableVPN", tsDisableVPN);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "DisableWiFi", tsDisableClipboard);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "EnableHAGS", tsEnableHAGS);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "OldAltTab", tsOldAltTab);
            Utils.CheckRegistryValueAndSetToggleSwitch(key, "OldContextMenu", tsOldContextMenu);

            OSName.Text = Utils.GetOS();
            OSArch.Text = Utils.GetBitness();
            Welcome.Text = "Welcome " + Environment.UserName;

            //Show Tweak if the OS is Windows 11

            if (OSName.Text.Contains("Windows 11"))
            {
                label10.Visible = true;
                tsOldContextMenu.Visible = true;
            }
        }

        private void GetOSInfo()
        {
            if (SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.NoSystemBattery)
            {
                Platform.Text = ($"Desktop ({Environment.MachineName})");
            }
            else
            {
                Platform.Text = ($"Laptop ({Environment.MachineName})");
            }
        }

        //please wait
        private async void PleaseWait()
        {
            pleaseWait.Visible = true;
            await Task.Delay(1000);
            pleaseWait.Text = pleaseWait.Text + ".";
            await Task.Delay(1000);
            pleaseWait.Text = pleaseWait.Text + ".";
            await Task.Delay(1000);
            pleaseWait.Text = pleaseWait.Text + ".";
        }

        private void PleaseDontWait()
        {
            pleaseWait.Text = "Please Wait";
            pleaseWait.Visible = false;
        }
        //Workstation Services
        private void WorkstationEnable()
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\rdbss", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\KSecPkg", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\mrxsmb20", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\mrxsmb", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\srv2", "Start", 2, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanWorkstation", "Start", 2, RegistryValueKind.DWord);
            Utils.RunCommand("DISM", "/Online /Enable-Feature /FeatureName:SmbDirect /NoRestart");
        }
        private void WorkstationDiasble()
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\rdbss", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\KSecPkg", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\mrxsmb20", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\mrxsmb", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\srv2", "Start", 4, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\LanmanWorkstation", "Start", 4, RegistryValueKind.DWord);
            Utils.RunCommand("DISM", "/Online /Disable-Feature /FeatureName:SmbDirect /NoRestart");
        }

        //Checkboxes
        private void tsDisableAnimation_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableAnimation.Checked)
            {
                object aVal = Configurator.GetValue("AnimationsDisabled");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\" + dwmRegistryPath, "DisallowAnimations", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + windowMetricsRegistryPath, "MinAnimate", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + explorerAdvancedRegistryPath, "TaskbarAnimations", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + visualEffectsRegistryPath, "VisualFXSetting", 3, RegistryValueKind.DWord);

                    byte[] userPreferencesMaskData = { 0x90, 0x12, 0x03, 0x80, 0x10, 0x00, 0x00, 0x00 };
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + desktopRegistryPath, "UserPreferencesMask", userPreferencesMaskData, RegistryValueKind.Binary);

                    Configurator.SetValue("AnimationsDisabled", 1);
                }
            }
            else
            {
                try
                {
                    RegistryKey localMachineKey = Registry.LocalMachine.OpenSubKey(dwmRegistryPath, true);
                    if (localMachineKey != null)
                    {
                        localMachineKey.DeleteValue("DisallowAnimations", false);
                        localMachineKey.Close();
                    }

                    RegistryKey currentUserKey = Registry.CurrentUser.OpenSubKey(windowMetricsRegistryPath, true);
                    if (currentUserKey != null)
                    {
                        currentUserKey.DeleteValue("MinAnimate", false);
                        currentUserKey.Close();
                    }

                    Registry.SetValue(@"HKEY_CURRENT_USER\" + explorerAdvancedRegistryPath, "TaskbarAnimations", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + visualEffectsRegistryPath, "VisualFXSetting", 1, RegistryValueKind.DWord);

                    byte[] userPreferencesMaskData = { 0x9e, 0x3e, 0x07, 0x80, 0x12, 0x00, 0x00, 0x00 };
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + desktopRegistryPath, "UserPreferencesMask", userPreferencesMaskData, RegistryValueKind.Binary);
                }
                catch (Exception)
                { }
                Configurator.DeleteValue("AnimationsDisabled");
            }
        }

        private void tsDisableBackgroundApps_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableBackgroundApps.Checked)
            {
                object aVal = Configurator.GetValue("DisableBackgroundApps");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy", "LetAppsRunInBackground", 2, RegistryValueKind.DWord);
                    Registry.SetValue($@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", "GlobalUserDisabled", 1, RegistryValueKind.DWord);
                    Registry.SetValue($@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Search", "BackgroundAppGlobalToggle", 0, RegistryValueKind.DWord);
                    Configurator.SetValue("DisableBackgroundApps", 1);
                }
            }
            else
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\AppPrivacy", "LetAppsRunInBackground", 1, RegistryValueKind.DWord);
                Registry.SetValue($@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", "GlobalUserDisabled", 0, RegistryValueKind.DWord);
                Registry.SetValue($@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Search", "BackgroundAppGlobalToggle", 1, RegistryValueKind.DWord);
                Configurator.DeleteValue("DisableBackgroundApps");
            }
        }

        private void tsDisableBluetooth_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableBluetooth.Checked)
            {
                object aVal = Configurator.GetValue("DisableBluetooth");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthAvctpSvc", "Start", 4, RegistryValueKind.DWord);
                    Configurator.SetValue("DisableBluetooth", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\BthAvctpSvc", "Start", 3, RegistryValueKind.DWord);
                Configurator.DeleteValue("DisableBluetooth");
            }
        }

        private void tsDisableClipboard_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableClipboard.Checked)
            {
                object aVal = Configurator.GetValue("DisableClipboard");
                if (null != aVal)
                {
                }
                else
                {
                    using (RegistryKey servicesKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services", true))
                    {
                        if (servicesKey != null)
                        {
                            foreach (string subkeyName in servicesKey.GetSubKeyNames())
                            {
                                if (subkeyName.Contains("cbdhsvc"))
                                {
                                    using (RegistryKey subkey = servicesKey.OpenSubKey(subkeyName, true))
                                    {
                                        subkey?.SetValue("Start", 4, RegistryValueKind.DWord);
                                    }
                                }
                            }
                        }
                    }

                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Clipboard", "EnableClipboardHistory", 0, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\System", "AllowClipboardHistory", 0, RegistryValueKind.DWord);
                    Configurator.SetValue("DisableClipboard", 1);
                }
            }
            else
            {
                using (RegistryKey servicesKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services", true))
                {
                    if (servicesKey != null)
                    {
                        foreach (string subkeyName in servicesKey.GetSubKeyNames())
                        {
                            if (subkeyName.Contains("cbdhsvc"))
                            {
                                using (RegistryKey subkey = servicesKey.OpenSubKey(subkeyName, true))
                                {
                                    subkey?.SetValue("Start", 2, RegistryValueKind.DWord);
                                }
                            }
                        }
                    }
                }

                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Clipboard", "EnableClipboardHistory", 1, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\System", "AllowClipboardHistory", 1, RegistryValueKind.DWord);
                Configurator.DeleteValue("DisableClipboard");
            }
        }

        private void tsDisableFSO_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableFSO.Checked)
            {
                object aVal = Configurator.GetValue("DisableFSO");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameBarRegistryPath, "ShowStartupPanel", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameBarRegistryPath, "GamePanelStartupTipIndex", 3, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameBarRegistryPath, "AllowAutoGameMode", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameBarRegistryPath, "AutoGameModeEnabled", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameBarRegistryPath, "UseNexusForGameBarEnabled", 0, RegistryValueKind.DWord);

                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameConfigStoreRegistryPath, "GameDVR_Enabled", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameConfigStoreRegistryPath, "GameDVR_FSEBehaviorMode", 2, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameConfigStoreRegistryPath, "GameDVR_FSEBehavior", 2, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameConfigStoreRegistryPath, "GameDVR_HonorUserFSEBehaviorMode", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameConfigStoreRegistryPath, "GameDVR_DXGIHonorFSEWindowsCompatible", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameConfigStoreRegistryPath, "GameDVR_EFSEFeatureFlags", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\" + gameConfigStoreRegistryPath, "GameDVR_DSEBehavior", 2, RegistryValueKind.DWord);

                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\" + gameDVRRegistryPath, "AllowGameDVR", 0, RegistryValueKind.DWord);

                    Registry.SetValue(@"HKEY_CURRENT_USER\" + currentVersionGameDVRRegistryPath, "AppCaptureEnabled", 0, RegistryValueKind.DWord);

                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\" + bcastDVRUserServiceRegistryPath, "Start", 4, RegistryValueKind.DWord);

                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\" + sessionManagerEnvironmentRegistryPath, "__COMPAT_LAYER", "~ DISABLEDXMAXIMIZEDWINDOWEDMODE", RegistryValueKind.String);

                    Configurator.SetValue("DisableFSO", 1);
                }
            }
            else
            {
                RegistryKey currentUserKey = Registry.CurrentUser;

                currentUserKey.OpenSubKey(gameBarRegistryPath, true)?.DeleteValue("GamePanelStartupTipIndex", false);
                currentUserKey.OpenSubKey(gameBarRegistryPath, true)?.DeleteValue("AllowAutoGameMode", false);
                currentUserKey.OpenSubKey(gameBarRegistryPath, true)?.DeleteValue("AutoGameModeEnabled", false);
                currentUserKey.OpenSubKey(gameBarRegistryPath, true)?.SetValue("UseNexusForGameBarEnabled", 1, RegistryValueKind.DWord);
                currentUserKey.OpenSubKey(gameBarRegistryPath, true)?.SetValue("ShowStartupPanel", 1, RegistryValueKind.DWord);

                currentUserKey.OpenSubKey(gameConfigStoreRegistryPath, true)?.SetValue("GameDVR_Enabled", 1, RegistryValueKind.DWord);
                currentUserKey.OpenSubKey(gameConfigStoreRegistryPath, true)?.SetValue("GameDVR_FSEBehavior", 0, RegistryValueKind.DWord);
                currentUserKey.OpenSubKey(gameConfigStoreRegistryPath, true)?.SetValue("GameDVR_FSEBehaviorMode", 2, RegistryValueKind.DWord);
                currentUserKey.OpenSubKey(gameConfigStoreRegistryPath, true)?.SetValue("GameDVR_HonorUserFSEBehaviorMode", 0, RegistryValueKind.DWord);
                currentUserKey.OpenSubKey(gameConfigStoreRegistryPath, true)?.SetValue("GameDVR_DXGIHonorFSEWindowsCompatible", 0, RegistryValueKind.DWord);
                currentUserKey.OpenSubKey(gameConfigStoreRegistryPath, true)?.SetValue("GameDVR_EFSEFeatureFlags", 1, RegistryValueKind.DWord);
                currentUserKey.OpenSubKey(gameConfigStoreRegistryPath, true)?.DeleteValue("GameDVR_DSEBehavior", false);

                Registry.LocalMachine.OpenSubKey(gameDVRRegistryPath, true)?.DeleteValue("AllowGameDVR", false);

                currentUserKey.OpenSubKey(currentVersionGameDVRRegistryPath, true)?.SetValue("AppCaptureEnabled", 1, RegistryValueKind.DWord);

                Registry.LocalMachine.OpenSubKey(bcastDVRUserServiceRegistryPath, true)?.SetValue("Start", 3, RegistryValueKind.DWord);

                Registry.LocalMachine.OpenSubKey(sessionManagerEnvironmentRegistryPath, true)?.DeleteValue("__COMPAT_LAYER", false);

                Configurator.DeleteValue("DisableFSO");
            }
        }

        private void tsDisablePrefetch_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisablePrefetch.Checked)
            {
                object aVal = Configurator.GetValue("DisablePrefetch");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SysMain", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\FontCache", "Start", 4, RegistryValueKind.DWord);

                    Configurator.SetValue("DisablePrefetch", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\SysMain", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\FontCache", "Start", 2, RegistryValueKind.DWord);

                Configurator.DeleteValue("DisablePrefetch");
            }
        }

        private void tsDisableHyperV_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableHyperV.Checked)
            {
                object aVal = Configurator.GetValue("DisableHyperV");
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

                    Configurator.SetValue("DisableHyperV", 1);
                }
            }
            else
            {
                Utils.RunCommand("bcdedit", "/set hypervisorlaunchtype auto");
                Utils.RunCommand("bcdedit", "/deletevalue vm");
                Utils.RunCommand("bcdedit", "/deletevalue loadoptions");

                // Enable Hyper-V with DISM
                Utils.RunCommand("DISM", "/Online /Enable-Feature:Microsoft-Hyper-V-All /Quiet /NoRestart");

                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("EnableVirtualizationBasedSecurity", false);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("RequirePlatformSecurityFeatures", false);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("HypervisorEnforcedCodeIntegrity", false);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("HVCIMATRequired", false);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("LsaCfgFlags", false);
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DeviceGuard", true)?.DeleteValue("ConfigureSystemGuardLaunch", false);

                // Set registry values
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "RequireMicrosoftSignedBootChain", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "EnableVirtualizationBasedSecurity", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "RequirePlatformSecurityFeatures", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard", "Locked", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity", "Enabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity", "Locked", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity", "WasEnabledBy", 1, RegistryValueKind.DWord);

                Configurator.DeleteValue("DisableHyperV");
            }
        }

        private void tsDisableWorkstation_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableWorkstation.Checked)
            {
                object aVal = Configurator.GetValue("DisableWorkstation");
                if (null != aVal)
                {
                }
                else
                {
                    WorkstationDiasble();
                    Configurator.SetValue("DisableWorkstation", 1);
                }

            }
            else
            {
                WorkstationEnable();
                Configurator.DeleteValue("DisableWorkstation");
            }
        }

        private void tsDisableNetworkDiscovery_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableNetworkDiscovery.Checked)
            {
                object aVal = Configurator.GetValue("DisableNetworkDiscovery");
                if (null != aVal)
                {
                }
                else
                {
                    WorkstationDiasble();
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NlaSvc", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\lmhosts", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netman", "Start", 4, RegistryValueKind.DWord);
                    Configurator.SetValue("DisableNetworkDiscovery", 1);
                }
            }
            else
            {
                WorkstationEnable();
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NlaSvc", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\lmhosts", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netman", "Start", 2, RegistryValueKind.DWord);
                Configurator.DeleteValue("DisableNetworkDiscovery");
            }
        }

        private void tsDisableNotifcations_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableNotifcations.Checked)
            {
                object aVal = Configurator.GetValue("DisableNotifications");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WpnService", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\PushNotifications", "ToastEnabled", 0, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer", "DisableNotificationCenter", 1, RegistryValueKind.DWord);
                    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userNotificationListener", "Value", "Deny", RegistryValueKind.String);
                    Configurator.SetValue("DisableNotifications", 1);
                }

            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WpnService", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\PushNotifications", "ToastEnabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer", "DisableNotificationCenter", 0, RegistryValueKind.DWord);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userNotificationListener", "Value", "Allow", RegistryValueKind.String);
                Configurator.DeleteValue("DisableNotifications");
            }
        }

        private void tsDisablePrintSpooler_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisablePrintSpooler.Checked)
            {
                object aVal = Configurator.GetValue("DisablePrinter");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Spooler", "Start", 4, RegistryValueKind.DWord);
                    Configurator.SetValue("DisablePrinter", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Spooler", "Start", 2, RegistryValueKind.DWord);
                Configurator.DeleteValue("DisablePrinter");
            }
        }

        private void tsDisableVPN_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableVPN.Checked)
            {
                object aVal = Configurator.GetValue("DisableVPN");
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
                    Configurator.SetValue("DisableVPN", 1);
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
                Configurator.DeleteValue("DisableVPN");
            }
        }

        private void tsDisableWiFI_CheckedChanged(object sender, EventArgs e)
        {
            if (tsDisableWiFI.Checked)
            {
                object aVal = Configurator.GetValue("DisableWiFi");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WlanSvc", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\vwififlt", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 4, RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NlaSvc  ", "Start", 4, RegistryValueKind.DWord);
                    Configurator.SetValue("DisableWiFi", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\WlanSvc", "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\vwififlt", "Start", 1, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 3, RegistryValueKind.DWord);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\NlaSvc  ", "Start", 2, RegistryValueKind.DWord);
                Configurator.DeleteValue("DisableWiFi");
            }
                        if (OSName.Text.Contains("Windows 11"))
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\netprofm", "Start", 3, RegistryValueKind.DWord);
            }
 
    }
        }

        private void tsEnableHAGS_CheckedChanged(object sender, EventArgs e)
        {
            if (tsEnableHAGS.Checked)
            {
                object aVal = Configurator.GetValue("EnableHAGS");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", "HwSchMode", 1, RegistryValueKind.DWord);
                    Configurator.SetValue("EnableHAGS", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", "HwSchMode", 2, RegistryValueKind.DWord);
                Configurator.DeleteValue("EnableHAGS");
            }
        }

        private void tsOldAltTab_CheckedChanged(object sender, EventArgs e)
        {
            if (tsOldAltTab.Checked)
            {
                object aVal = Configurator.GetValue("OldAltTab");
                if (null != aVal)
                {
                }
                else
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AltTabSettings", 1, RegistryValueKind.DWord);
                    Configurator.SetValue("OldAltTab", 1);
                }
            }
            else
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AltTabSettings", 0, RegistryValueKind.DWord);
                Configurator.DeleteValue("OldAltTab");
            }
        }

        private void tsOldContextMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (tsOldContextMenu.Checked)
            {
                object aVal = Configurator.GetValue("OldContextMenu");
                if (null != aVal)
                {
                }
                else
                {
                    Process.Start("regedit.exe", "/s C:\\Windows\\Modules\\OldContextMenu.reg"); //Change According to your preference
                    Configurator.SetValue("OldContextMenu", 1);
                }
            }
            else
            {
                Process.Start("regedit.exe", "/s C:\\Windows\\Modules\\NewContextMenu.reg"); //Change According to your preference
                Configurator.DeleteValue("OldContextMenu");
            }
        }

        private void btnBrave_Click(object sender, EventArgs e)
        {
            PleaseWait();
            if (Utils.DownloadFile(
"https://brave-browser-downloads.s3.brave.com/latest/BraveBrowserSetup.exe",
DownloadsFolder + "\\BraveBrowserSetup.exe"
) == true)
            {
                PleaseDontWait();
                Process.Start(DownloadsFolder + "\\BraveBrowserSetup.exe");
            }
        }

        private void btnChrome_Click(object sender, EventArgs e)
        {
            PleaseWait();
            if (Utils.DownloadFile(
"http://dl.google.com/chrome/install/chrome_installer.exe",
DownloadsFolder + "\\chrome_installer.exe"
) == true)
            {
                PleaseDontWait();
                Process.Start(DownloadsFolder + "\\chrome_installer.exe");
            }
        }

        private void btnEdge_Click(object sender, EventArgs e)
        {
            PleaseWait();
            if (Utils.DownloadFile(
"https://cdn.discordapp.com/attachments/901077907043156009/1151491922444165120/MicrosoftEdgeSetup.exe",
DownloadsFolder + "\\MicrosoftEdgeSetup.exe"
) == true)
            {
                PleaseDontWait();
                Process.Start(DownloadsFolder + "\\MicrosoftEdgeSetup.exe");
            }
        }

        private void btnFirefox_Click(object sender, EventArgs e)
        {
            PleaseWait();
            if (Utils.DownloadFile(
"https://mzl.la/3o6YriV",
DownloadsFolder + "\\MozillaFirefoxSetup.exe"
) == true)
            {
                PleaseDontWait();
                Process.Start(DownloadsFolder + "\\MozillaFirefoxSetup.exe");
            }
        }

        private void btnOperaGX_Click(object sender, EventArgs e)
        {
            PleaseWait();
            if (Utils.DownloadFile(
"https://cdn.discordapp.com/attachments/905447438238773259/934389036800409660/OperaGXSetup.exe",
DownloadsFolder + "\\OperaGXSetup.exe"
) == true)
            {
                PleaseDontWait();
                Process.Start(DownloadsFolder + "\\OperaGXSetup.exe");
            }
        }

        private async void btnDriverBooster_Click(object sender, EventArgs e)
        {
            string url = "https://nexus-toolkit.epubg691.workers.dev/?file=/Toolkit/17th%20June/IObit%20Driver%20Booster%20Pro%2010.5.0.139%20Multilingual.7z";
            string filename = DownloadsFolder + "\\IObit Driver Booster Pro.7z";

            PleaseWait();

            bool downloadSuccess = await Utils.DownloadFileAsync(url, filename);

            PleaseDontWait();

            if (downloadSuccess)
            {
                Process.Start("explorer.exe", DownloadsFolder);
            }
            else
            {
                MessageDialog.Show(null, "", "Download Failed!", MessageDialogButtons.OK, MessageDialogIcon.Error, MessageDialogStyle.Dark);
            }
        }

        private async void btnSDIO_Click(object sender, EventArgs e)
        {

            string url = "https://cdn.discordapp.com/attachments/901077907043156009/1152589193869004873/SDI_R2309.zip";
            string filename = DownloadsFolder + "\\SDI_R2309.zip";

            PleaseWait();

            bool downloadSuccess = await Utils.DownloadFileAsync(url, filename);

            PleaseDontWait();

            if (downloadSuccess)
            {
                Process.Start("explorer.exe", DownloadsFolder);
            }
            else
            {
                MessageDialog.Show(null, "", "Download Failed!", MessageDialogButtons.OK, MessageDialogIcon.Error, MessageDialogStyle.Dark);
            }
        }

        private async void btnNVCleanstall_Click(object sender, EventArgs e)
        {
            string url = "https://cdn.discordapp.com/attachments/901077907043156009/1152589609218351104/NVCleanstall_1.16.0.exe";
            string filename = DownloadsFolder + "\\NVCleanstall_1.16.0.zip";
            
            PleaseWait();

            bool downloadSuccess = await Utils.DownloadFileAsync(url, filename);

            PleaseDontWait();

            if (downloadSuccess)
            {
                Process.Start("explorer.exe", DownloadsFolder);
            }
            else
            {
                MessageDialog.Show(null, "", "Download Failed!", MessageDialogButtons.OK, MessageDialogIcon.Error, MessageDialogStyle.Dark);
            }
        }

        private async void btnRSS_Click(object sender, EventArgs e)
        {
            string url = "https://cdn.discordapp.com/attachments/901077907043156009/1152589910532948049/RadeonSoftwareSlimmer_1.10.1_net48.zip";
            string filename = DownloadsFolder + "\\RadeonSoftwareSlimmer_1.10.1_net48.zip";

            PleaseWait();

            bool downloadSuccess = await Utils.DownloadFileAsync(url, filename);

            PleaseDontWait();

            if (downloadSuccess)
            {
                Process.Start("explorer.exe", DownloadsFolder);
            }
            else
            {
                MessageDialog.Show(null, "", "Download Failed!", MessageDialogButtons.OK, MessageDialogIcon.Error, MessageDialogStyle.Dark);
            }
        }

        private async void btnNVS_Click(object sender, EventArgs e)
        {
            string url = "https://cdn.discordapp.com/attachments/901077907043156009/1152590163717926922/Guru3D.com-NVSlimmer.zip";
            string filename = DownloadsFolder + "\\NVSlimmer.zip";

            PleaseWait();

            bool downloadSuccess = await Utils.DownloadFileAsync(url, filename);
            
            PleaseDontWait();

            if (downloadSuccess)
            {
                Process.Start("explorer.exe", DownloadsFolder);
            }
            else
            {
                MessageDialog.Show(null, "", "Download Failed!", MessageDialogButtons.OK, MessageDialogIcon.Error, MessageDialogStyle.Dark);
            }
        }
    }
}
