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

namespace WindowsFormsApplication2.User_Controls
{
    public partial class context : UserControl
    {
        private static context _instace;
        public static context Instance
        {
            get
            {
                if (_instace == null)
                    _instace = new context();
                return _instace;
            }
        }
        public context()
        {
            InitializeComponent();
        }

        private string REG_KILL_PATH = "DesktopBackground\\shell\\KillNotResponding";

        private void button19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/4aNYHSEHYw");
        }

        private string REG_BASE_PATH = "DesktopBackground\\Shell\\WindowsTools";
        private void button15_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCwLj1srRmurcaJ5TpEg_4iQ");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey("Directory\\Shell\\OpenElevatedCMD");
            if (val != null)
            {
                val.SetValue("", (object)"Open CMD As Administrator");
                val.SetValue("Icon", (object)"imageres.dll,-5324");
                RegistryKey val2 = val.CreateSubKey("Command");
                val2.SetValue("", (object)("Powershell.exe -windowstyle hidden -Command \"Start-Process cmd.exe -ArgumentList ‘/s,/k,pushd,%V’ -Verb RunAs\""));
                val2.Close();
                val.Close();
            }

            RegistryKey val1 = Registry.ClassesRoot.CreateSubKey("Drive\\Shell\\OpenElevatedCMD");
            if (val1 != null)
            {
                val1.SetValue("", (object)"Open CMD As Administrator");
                val1.SetValue("Icon", (object)"imageres.dll,-5324");
                RegistryKey val2 = val1.CreateSubKey("Command");
                val2.SetValue("", (object)("Powershell.exe -windowstyle hidden -Command \"Start-Process cmd.exe -ArgumentList ‘/s,/k,pushd,%V’ -Verb RunAs\""));
                val2.Close();
                val1.Close();
            }

            RegistryKey val3 = Registry.ClassesRoot.CreateSubKey("LibraryFolder\\background\\Shell\\OpenElevatedCMD");
            if (val3 != null)
            {
                val3.SetValue("", (object)"Open CMD As Administrator");
                val3.SetValue("Icon", (object)"imageres.dll,-5324");
                RegistryKey val2 = val3.CreateSubKey("Command");
                val2.SetValue("", (object)("Powershell.exe -windowstyle hidden -Command \"Start-Process cmd.exe -ArgumentList ‘/s,/k,pushd,%V’ -Verb RunAs\""));
                val2.Close();
                val3.Close();
            }

            RegistryKey val4 = Registry.ClassesRoot.CreateSubKey("Directory\\Background\\Shell\\OpenElevatedCMD");
            if (val4 != null)
            {
                val4.SetValue("", (object)"Open CMD As Administrator");
                val4.SetValue("Icon", (object)"imageres.dll,-5324");
                RegistryKey val2 = val4.CreateSubKey("Command");
                val2.SetValue("", (object)("Powershell.exe -windowstyle hidden -Command \"Start-Process cmd.exe -ArgumentList ‘/s,/k,pushd,%V’ -Verb RunAs\""));
                val2.Close();
                val4.Close();
            }
            Utils.RestartExplorer();
            //Message box displays
            using (added xForm = new added())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (var key1 = clrt.OpenSubKey(@"Directory\\Background\\Shell\\OpenElevatedCmd"))
            {
                if (key1 == null)
                {
                }
                else
                {
                    string keyName = @"Directory\Background\Shell\";
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true))
                    {
                        key.DeleteSubKeyTree("OpenElevatedCmd", true);

                    }
                    Utils.RestartExplorer();
                    //Message box displays
                    using (removed xForm = new removed())
                    {
                        xForm.ShowDialog(this);
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey("Directory\\Shell\\OpenElevatedPS");
            if (val != null)
            {
                val.SetValue("", (object)"Open Powershell As Administrator");
                val.SetValue("Icon", (object)"powershell.exe");
                RegistryKey val2 = val.CreateSubKey("Command");
                val2.SetValue("", (object)("Powershell.exe -windowstyle hidden -Command \"Start-Process cmd.exe -ArgumentList '/s,/c,pushd %V && powershell' -Verb RunAs\""));
                val2.Close();
                val.Close();
            }

            RegistryKey val1 = Registry.ClassesRoot.CreateSubKey("Drive\\Shell\\OpenElevatedPS");
            if (val1 != null)
            {
                val1.SetValue("", (object)"Open Powershell As Administrator");
                val1.SetValue("Icon", (object)"powershell.exe"); ;
                RegistryKey val2 = val1.CreateSubKey("Command");
                val2.SetValue("", (object)("Powershell.exe -windowstyle hidden -Command \"Start-Process cmd.exe -ArgumentList '/s,/c,pushd %V && powershell' -Verb RunAs\""));
                val2.Close();
                val1.Close();
            }

            RegistryKey val3 = Registry.ClassesRoot.CreateSubKey("LibraryFolder\\background\\Shell\\OpenElevatedPS");
            if (val3 != null)
            {
                val3.SetValue("", (object)"Open Powershell As Administrator");
                val3.SetValue("Icon", (object)"powershell.exe");
                RegistryKey val2 = val3.CreateSubKey("Command");
                val2.SetValue("", (object)("Powershell.exe -windowstyle hidden -Command \"Start-Process cmd.exe -ArgumentList '/s,/c,pushd %V && powershell' -Verb RunAs\""));
                val2.Close();
                val3.Close();
            }

            RegistryKey val4 = Registry.ClassesRoot.CreateSubKey("Directory\\Background\\Shell\\OpenElevatedPS");
            if (val4 != null)
            {
                val4.SetValue("", (object)"Open Powershell As Administrator");
                val4.SetValue("Icon", (object)"powershell.exe");
                RegistryKey val2 = val4.CreateSubKey("Command");
                val2.SetValue("", (object)("Powershell.exe -windowstyle hidden -Command \"Start-Process cmd.exe -ArgumentList '/s,/c,pushd %V && powershell' -Verb RunAs\""));
                val2.Close();
                val4.Close();
            }
            Utils.RestartExplorer();
            //Message box displays
            using (added xForm = new added())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (var key1 = clrt.OpenSubKey(@"Directory\\Background\\Shell\\OpenElevatedPS"))
            {
                if (key1 == null)
                {
                }
                else
                {
                    string keyName = @"Directory\Background\Shell\";
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true))
                    {
                        key.DeleteSubKeyTree("OpenElevatedPS", true);

                    }
                    Utils.RestartExplorer();
                    //Message box displays
                    using (removed xForm = new removed())
                    {
                        xForm.ShowDialog(this);
                    }
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey("*\\shell\\TakeOwnership");
            if (val != null)
            {
                val.SetValue("", (object)"Take Ownership", (RegistryValueKind)1);
                val.SetValue("HasLUAShield", (object)"", (RegistryValueKind)1);
                val.SetValue("NoWorkingDirectory", (object)"", (RegistryValueKind)1);
                val.SetValue("NeverDefault", (object)"", (RegistryValueKind)1);
                val.Close();
                val = Registry.ClassesRoot.CreateSubKey("*\\shell\\TakeOwnership\\command");
                val.SetValue("", (object)"powershell.exe -windowstyle hidden -command \"Start-Process cmd -ArgumentList '/c takeown /f \\\"%1\\\" && icacls \\\"%1\\\" /grant *S-1-3-4:F /c /l & pause' -Verb runAs\"");
                val.SetValue("IsolatedCommand", (object)"powershell.exe -windowstyle hidden -command \"Start-Process cmd -ArgumentList '/c takeown /f \\\"%1\\\" && icacls \\\"%1\\\" /grant *S-1-3-4:F /c /l & pause' -Verb runAs\"");
                val.Close();
            }
            val = Registry.ClassesRoot.CreateSubKey("Directory\\shell\\TakeOwnership");
            if (val != null)
            {
                val.SetValue("", (object)"Take Ownership", (RegistryValueKind)1);
                val.SetValue("HasLUAShield", (object)"", (RegistryValueKind)1);
                val.SetValue("NoWorkingDirectory", (object)"", (RegistryValueKind)1);
                val.SetValue("NeverDefault", (object)"", (RegistryValueKind)1);
                val.SetValue("AppliesTo", (object)"NOT (System.ItemPathDisplay:=\"C:\\Users\" OR System.ItemPathDisplay:=\"C:\\ProgramData\" OR System.ItemPathDisplay:=\"C:\\Windows\" OR System.ItemPathDisplay:=\"C:\\Windows\\System32\" OR System.ItemPathDisplay:=\"C:\\Program Files\" OR System.ItemPathDisplay:=\"C:\\Program Files (x86)\")", (RegistryValueKind)1);
                val.Close();
                val = Registry.ClassesRoot.CreateSubKey("Directory\\shell\\TakeOwnership\\command");
                val.SetValue("", (object)"powershell.exe -windowstyle hidden -command \"Start-Process cmd -ArgumentList '/c takeown /f \\\"%1\\\"  /r /d y /skipsl && icacls \\\"%1\\\" /grant *S-1-3-4:F /t /c /l & pause' -Verb runAs\"");
                val.SetValue("IsolatedCommand", (object)"powershell.exe -windowstyle hidden -command \"Start-Process cmd -ArgumentList '/c takeown /f \\\"%1\\\" /r /d y /skipsl && icacls \\\"%1\\\" /grant *S-1-3-4:F /t /c /l & pause' -Verb runAs\"");
                val.Close();
                Utils.RestartExplorer();
                //Message box displays
                using (added xForm = new added())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (var key1 = clrt.OpenSubKey(@"*\shell\TakeOwnership"))
            {
                if (key1 == null)
                {
                }
                else
                {
                    string keyName = @"*\shell\";
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true))
                    {
                        key.DeleteSubKeyTree("TakeOwnership", true);

                    }

                    string keyName1 = @"Directory\shell";
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName1, true))
                    {
                        key.DeleteSubKeyTree("TakeOwnership", true);

                    }
                    Utils.RestartExplorer();
                    //Message box displays
                    using (removed xForm = new removed())
                    {
                        xForm.ShowDialog(this);
                    }
                }
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey("DesktopBackground\\shell\\ControlPanel");
            if (val != null)
            {
                val.SetValue("MUIVerb", (object)"@shell32.dll,-4161");
                val.SetValue("Icon", (object)"imageres.dll,-27");
                val.SetValue("Position", (object)"Bottom");
                val.SetValue("SubCommands", (object)"");
                RegistryKey val2 = val.CreateSubKey("shell\\1ControlPanelCmd");
                val2.SetValue("MUIVerb", (object)"@shell32.dll,-31061");
                val2.SetValue("Icon", (object)"imageres.dll,-27");
                RegistryKey val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"explorer.exe shell:::{26EE0668-A00A-44D7-9371-BEB064C98683}");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\2ControlPanelCmd");
                val2.SetValue("MUIVerb", (object)"@shell32.dll,-31062");
                val2.SetValue("Icon", (object)"imageres.dll,-27");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"explorer.exe shell:::{21EC2020-3AEA-1069-A2DD-08002B30309D}");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\3ControlPanelCmd");
                val2.SetValue("MUIVerb", (object)"@shell32.dll,-32537");
                val2.SetValue("Icon", (object)"imageres.dll,-27");
                val2.SetValue("CommandFlags", (object)32, (RegistryValueKind)4);
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"explorer.exe shell:::{ED7BA470-8E54-465E-825C-99712043E01C}");
                val3.Close();
                val2.Close();
                val.Close();
                Utils.RestartExplorer();
                //Message box displays
                using (added xForm = new added())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (var key1 = clrt.OpenSubKey(@"DesktopBackground\\shell\\ControlPanel"))
            {
                if (key1 == null)
                {
                }
                else
                {
                    string keyName = @"DesktopBackground\shell\";
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true))
                    {
                        key.DeleteSubKeyTree("ControlPanel", true);

                    }
                    Utils.RestartExplorer();
                    //Message box displays
                    using (removed xForm = new removed())
                    {
                        xForm.ShowDialog(this);
                    }
                }
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey("*\\shell\\Hash");
            if (val != null)
            {
                val.SetValue("MUIVerb", (object)"Hash");
                val.SetValue("SubCommands", (object)"");
                RegistryKey val2 = val.CreateSubKey("shell\\01Menu");
                val2.SetValue("MUIVerb", (object)"SHA1");
                RegistryKey val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"powershell - noexit get - filehash - literalpath '%1' - algorithm SHA1 | format - list");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\02Menu");
                val2.SetValue("MUIVerb", (object)"SHA256");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"powershell -noexit get-filehash -literalpath '%1' -algorithm SHA256 | format-list");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\03Menu");
                val2.SetValue("MUIVerb", (object)"SHA384");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"powershell -noexit get-filehash -literalpath '%1' -algorithm SHA384 | format-list");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\04Menu");
                val2.SetValue("MUIVerb", (object)"SHA512");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"powershell -noexit get-filehash -literalpath '%1' -algorithm SHA512 | format-list");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\05Menu");
                val2.SetValue("MUIVerb", (object)"MACTripleDES");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"powershell -noexit get-filehash -literalpath '%1' -algorithm MACTripleDES | format-list");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\06Menu");
                val2.SetValue("MUIVerb", (object)"MD5");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"powershell -noexit get-filehash -literalpath '%1' -algorithm MD5 | format-list");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\07Menu");
                val2.SetValue("MUIVerb", (object)"RIPEMD160");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"powershell -noexit get-filehash -literalpath '%1' -algorithm RIPEMD160 | format-list");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\08Menu");
                val2.SetValue("MUIVerb", (object)"Show all");
                Registry.SetValue("HKEY_CLASSES_ROOT\\*\\shell\\hash\\shell\\08menu", "CommandFlags", 00000032, RegistryValueKind.DWord);
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"powershell -noexit get-filehash -literalpath '%1' -algorithm SHA1 | format-list;get-filehash -literalpath '%1' -algorithm SHA256 | format-list;get-filehash -literalpath '%1' -algorithm SHA384 | format-list;get-filehash -literalpath '%1' -algorithm SHA512 | format-list;get-filehash -literalpath '%1' -algorithm MACTripleDES | format-list;get-filehash -literalpath '%1' -algorithm MD5 | format-list;get-filehash -literalpath '%1' -algorithm RIPEMD160 | format-list");
                val3.Close();
                val2.Close();
                val.Close();
                Utils.RestartExplorer();
                //Message box displays
                using (added xForm = new added())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (var key1 = clrt.OpenSubKey(@"*\shell\Hash"))
            {
                if (key1 == null)
                {
                }
                else
                {
                    string keyName = @"*\shell\";
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true))
                    {
                        key.DeleteSubKeyTree("Hash", true);

                    }
                    Utils.RestartExplorer();
                    //Message box displays
                    using (removed xForm = new removed())
                    {
                        xForm.ShowDialog(this);
                    }
                }
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey(REG_KILL_PATH);
            if (val != null)
            {
                val.SetValue("MUIVerb", (object)"Kill not responding tasks");
                val.SetValue("Icon", (object)"%SystemRoot%\\\\System32\\\\imageres.dll,-98");
                val.SetValue("Position", (object)"Top");
                RegistryKey val2 = val.CreateSubKey("Command");
                val2.SetValue("", (object)"cmd.exe /K taskkill.exe /F /FI \"status eq NOT RESPONDING\"");
                val2.Close();
                val.Close();
            }
            Utils.RestartExplorer();
            //Message box displays
            using (added xForm = new added())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var key1 = hklm.OpenSubKey(@"SOFTWARE\Classes\DesktopBackground\Shell\KillNotResponding"))
            {
                if (key1 == null)
                {
                }
                else
                {
                    string keyName = @"SOFTWARE\Classes\DesktopBackground\Shell";
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
                    {
                        key.DeleteSubKeyTree("KillNotResponding", true);

                    }
                    Utils.RestartExplorer();
                    //Message box displays
                    using (removed xForm = new removed())
                    {
                        xForm.ShowDialog(this);
                    }
                }
            }
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey(REG_BASE_PATH);
            if (val != null)
            {
                val.SetValue("MUIVerb", (object)"Windows Tools");
                val.SetValue("Icon", (object)"imageres.dll,-114");
                val.SetValue("Position", (object)"Bottom");
                RegistryKey val2 = val.CreateSubKey("command");
                val2.SetValue("", (object)"explorer.exe shell:::{D20EA4E1-3957-11d2-A40B-0C5020524153}");
                val2.Close();
                val.Close();
            }
            Utils.RestartExplorer();
            //Message box displays
            using (added xForm = new added())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (var key1 = clrt.OpenSubKey(@"DesktopBackground\\Shell\\WindowsTools"))
            {
                if (key1 == null)
                {
                }
                else
                {
                    string keyName = @"DesktopBackground\Shell";
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true))
                    {
                        key.DeleteSubKeyTree("WindowsTools", true);

                    }
                    Utils.RestartExplorer();
                    //Message box displays
                    using (removed xForm = new removed())
                    {
                        xForm.ShowDialog(this);
                    }
                }
            }
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey("DesktopBackground\\shell\\ShutDown");
            if (val != null)
            {
                val.SetValue("MUIVerb", (object)"Shut Down");
                val.SetValue("Icon", (object)"shell32.dll,-28");
                val.SetValue("Position", (object)"Bottom");
                val.SetValue("SubCommands", (object)"");
                RegistryKey val2 = val.CreateSubKey("shell\\001ShutdownInstantly");
                val2.SetValue("MUIVerb", (object)"Shut down instantly");
                val2.SetValue("Icon", (object)"shell32.dll,-28");
                RegistryKey val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"shutdown -s -f -t 0");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\002ShutdownWarning");
                val2.SetValue("MUIVerb", (object)"Shut down with warning");
                val2.SetValue("Icon", (object)"shell32.dll,-28");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"shutdown -s");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\003RestartInstantly");
                val2.SetValue("MUIVerb", (object)"Restart instantly");
                val2.SetValue("Icon", (object)"shell32.dll,-16739");
                val2.SetValue("CommandFlags", (object)32, (RegistryValueKind)4);
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"shutdown -r -f -t 0");
                val3.Close();
                val2.Close();
                val2 = val.CreateSubKey("shell\\004RestartWarning");
                val2.SetValue("MUIVerb", (object)"Restart with warning");
                val2.SetValue("Icon", (object)"shell32.dll,-16739");
                val3 = val2.CreateSubKey("Command");
                val3.SetValue("", (object)"shutdown -r");
                val3.Close();
                val2.Close();
                val.Close();
            }
            Utils.RestartExplorer();
            //Message box displays
            using (added xForm = new added())
            {
                xForm.ShowDialog(this);
            }
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            using (var key1 = clrt.OpenSubKey(@"DesktopBackground\\shell\\ShutDown"))
            {
                if (key1 == null)
                {
                }
                else
                {
                    string keyName = @"DesktopBackground\shell";
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true))
                    {
                        key.DeleteSubKeyTree("ShutDown", true);

                    }
                    Utils.RestartExplorer();
                    //Message box displays
                    using (removed xForm = new removed())
                    {
                        xForm.ShowDialog(this);
                    }
                }
            }
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            RegistryKey val = Registry.ClassesRoot.CreateSubKey(".pow");
            if (val != null)
            {
                RegistryKey val2 = Registry.ClassesRoot.CreateSubKey(".pow\\DefaultIcon");
                if (val2 != null)
                {
                    val2.SetValue("", @"%SystemRoot%\System32\powercfg.cpl,-202");
                }
                RegistryKey val3 = val.CreateSubKey("Shell\\open\\command");
                if (val3 != null)
                {
                    val3.SetValue("", "powercfg /import %1");
                    val3.Close();
                }

                val.Close();
                Utils.RestartExplorer();
                //Message box displays
                using (added xForm = new added())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            {
                using (var key1 = clrt.OpenSubKey(".pow"))
                {
                    if (key1 == null)
                    {                    }
                    else
                    {
                        clrt.DeleteSubKeyTree(".pow", true);
                        // Restart explorer
                        Utils.RestartExplorer();
                        // Display message box
                        using (removed xForm = new removed())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                }
            }
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"exefile\shell\Priority");
            if (key != null)
            {
                key.SetValue("MUIVerb", "Run with priority");
                key.SetValue("SubCommands", "");

                RegistryKey priorityKey;

                priorityKey = key.CreateSubKey(@"shell\001flyout");
                if (priorityKey != null)
                {
                    priorityKey.SetValue("", "Realtime");

                    RegistryKey commandKey = priorityKey.CreateSubKey("command");
                    if (commandKey != null)
                    {
                        commandKey.SetValue("", @"cmd /c start """" /Realtime ""%1""");
                        commandKey.Close();
                    }
                    priorityKey.Close();
                }

                priorityKey = key.CreateSubKey(@"shell\002flyout");
                if (priorityKey != null)
                {
                    priorityKey.SetValue("", "High");

                    RegistryKey commandKey = priorityKey.CreateSubKey("command");
                    if (commandKey != null)
                    {
                        commandKey.SetValue("", @"cmd /c start """" /High ""%1""");
                        commandKey.Close();
                    }
                    priorityKey.Close();
                }
                key.Close();
                Utils.RestartExplorer();
                //Message box displays
                using (added xForm = new added())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            {
                using (var key1 = clrt.OpenSubKey(@"exefile\shell\Priority"))
                {
                    if (key1 == null)
                    {
                    }
                    else
                    {
                        clrt.DeleteSubKeyTree(@"exefile\shell\Priority", true);
                        Utils.RestartExplorer();
                        // Display message box
                        using (removed xForm = new removed())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                }
            }
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"Directory\background\shell\Change Res");
            if (key != null)
            {
                key.SetValue("MUIVerb", "Change Resolution");

                RegistryKey commandKey = key.CreateSubKey("command");
                if (commandKey != null)
                {
                    commandKey.SetValue("", @"C:\Windows\System32\rundll32.exe display.dll,ShowAdapterSettings 0");
                    commandKey.Close();
                }

                key.Close();
                Utils.RestartExplorer();
                using (added xForm = new added())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            {
                using (var key1 = clrt.OpenSubKey(@"Directory\background\shell\Change Res"))
                {
                    if (key1 == null)
                    {
                    }
                    else
                    {
                        clrt.DeleteSubKeyTree(@"Directory\background\shell\Change Res", true);
                        Utils.RestartExplorer();
                        // Display message box
                        using (removed xForm = new removed())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                }
            }
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"Directory\background\shell\reboot to fw");
            if (key != null)
            {
                key.SetValue("MUIVerb", "Reboot To BIOS");

                RegistryKey commandKey = key.CreateSubKey("command");
                if (commandKey != null)
                {
                    commandKey.SetValue("", @"shutdown /r /fw /t 0");
                    commandKey.Close();
                }

                key.Close();
                Utils.RestartExplorer();
                using (added xForm = new added())
                {
                    xForm.ShowDialog(this);
                }
            }
        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            using (var clrt = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64))
            {
                using (var key1 = clrt.OpenSubKey(@"Directory\background\shell\reboot to fw"))
                {
                    if (key1 == null)
                    {
                    }
                    else
                    {
                        clrt.DeleteSubKeyTree(@"Directory\background\shell\reboot to fw", true);
                        Utils.RestartExplorer();
                        // Display message box
                        using (removed xForm = new removed())
                        {
                            xForm.ShowDialog(this);
                        }
                    }
                }
            }
        }
    }
}

