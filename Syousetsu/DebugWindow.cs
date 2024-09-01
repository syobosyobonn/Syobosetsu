using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Syobosetsu
{
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();

            string DebugWindowVer = "3.0";

            string AppVer = VerInfo.ver;

            this.BackColor = Color.Black;

            richTextBox1.BackColor = Color.Black;

            RBWhiteLine("□Debug window□");

            RBWhiteLine("");

            RBWhiteLine($"Application-Vertion:\t{AppVer}");
            RBWhiteLine($"DebugWIndow-Vertion:\t{DebugWindowVer}");

            RBWhiteLine("");

            RBWhite(">");

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();

            if (e.KeyCode == Keys.Back)
            {
                RBBack();
            }
            else if (e.KeyCode == Keys.Space)
            {
                RBWhite(" ");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int index = richTextBox1.Text.LastIndexOf('>');
                if (index != -1 && index < richTextBox1.Text.Length - 1)
                {
                    string commandText = richTextBox1.Text.Substring(index + 1);

                    RBWhiteLine("");

                    if (commandText == "CLS")
                    {
                        richTextBox1.Text = "";
                    }
                    else if (commandText == "RESET")
                    {
                        Properties.Settings.Default.Reset();

                        RBWhiteLine("Reseted all settings!");
                    }
                    else if (commandText == "SHOW S")
                    {
                        RBWhiteLine(PropertiesEpIp.GetSettingsFilePath());
                    }
                    else if (commandText == "HELP")
                    {

                        RBWhiteLine("CLS\t→Clear texts");
                        RBWhiteLine("───────────────────────");
                        RBWhiteLine("RESET\t→Reset \"All\" Settings");
                        RBWhiteLine("SHOW S\t→Show Syobosetsu's setting file path");
                        RBWhiteLine("───────────────────────");
                        RBWhiteLine("HELP\t→Show this text");
                        RBWhiteLine("───────────────────────");
                        RBWhiteLine("SHOW C\t\t→Show Syobosetsu's CustomizedID");
                        RBWhiteLine("\t\t　HKEY_CURRENT_USER\\Software\\Syobosyobonn\\Syobosetsu\\Customized-ID");
                        RBWhiteLine("\t\t　HKEY_CURRENT_USER\\Software\\Syobosyobonn\\Syobosetsu\\Customized-ID-Calc");
                        RBWhiteLine("SHOW I\t\t→Show Syobosetsu's Installed Path");
                        RBWhiteLine("\t\t　HKEY_CURRENT_USER\\Software\\Syobosyobonn\\Syobosetsu\\InstallPath");
                        RBWhiteLine("SHOW L\t\t→Show Syobosetsu's Appdata(Local)");
                        RBWhiteLine("SHOW R\t\t→Show Syobosetsu's Appdata(Roaming)");
                        RBWhiteLine("SHOW ALL REG\t→Show Syobosetsu's All regs");
                        RBWhiteLine("\t\t　HKEY_CURRENT_USER\\Software\\Syobosyobonn\\Syobosetsu\\");
                        RBWhiteLine("───────────────────────");
                    }
                    else if (commandText == "SHOW C")
                    {
                        RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Syobosyobonn\Syobosetsu");
                        string locationA = regKey.GetValue("Customized-ID").ToString();

                        RBWhiteLine("Customized-ID\t\t" + locationA);

                        try
                        {
                            string locationC = regKey.GetValue("Customized-ID-Calc").ToString();
                            RBWhiteLine("Customized-ID-Calc\t" + locationC);
                        }
                        catch 
                        {
                            RBWhiteLine("not setted \"Customized-ID-Calc\"");
                        }
                    }
                    else if (commandText == "SHOW L")
                    {
                        RBWhiteLine(PropertiesEpIp.GetLocalAppDirectory());
                    }
                    else if (commandText == "SHOW R")
                    {
                        RBWhiteLine(PropertiesEpIp.GetRoamingAppDataDirectory());
                    }
                    else if (commandText == "SHOW ALL REG")
                    {
                        RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Syobosyobonn\Syobosetsu");
                        string locationA = regKey.GetValue("Customized-ID").ToString();
                        string locationI = regKey.GetValue("Installed").ToString();
                        string locationP = (string)regKey.GetValue("InstallPath");

                        RBWhiteLine("Customized-ID\t\t" + locationA);
                        RBWhiteLine("Installed\t\t\t" + locationI);
                        RBWhiteLine("InstallPath\t\t" + locationP);

                        try
                        {
                            string locationC = regKey.GetValue("Customized-ID-Calc").ToString();
                            RBWhiteLine("Customized-ID-Calc\t" + locationC);
                        }
                        catch
                        {
                            RBWhiteLine("not setted \"Customized-ID-Calc\"");
                        }
                    }

                    RBWhite("\n>");
                }
                else
                {
                    RBWhite("\n>");
                }
                return;
            }
            else
            {
                RBWhite(e.KeyData.ToString());
            }
        }

        public void RBWhite(string s)
        {
            richTextBox1.Text += s;
        }
        public void RBWhiteLine(string s)
        {
            richTextBox1.Text += s + "\n";
        }
        public void RBBack()
        {
            string textTemp = richTextBox1.Text;
            if (textTemp[textTemp.Length - 1] != '>')
            {
                textTemp = textTemp.Substring(0, textTemp.Length - 1);
            }

            richTextBox1.Text = textTemp;
        }
    }
}
