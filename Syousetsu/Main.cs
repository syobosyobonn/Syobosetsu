using Sgry.Azuki.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syobosetsu
{
    public partial class Main : Form
    {
        public FlashScreen flash = new();

        string fText = "";

        string backText = "";
        string OpenedPath = "";

        bool CheckTextsOn = false;

        public static Color Gray = Color.FromArgb(33, 33, 33);
        public static Color DarkGray = Color.FromArgb(27, 27, 27);

        public static Color FontC = Color.FromArgb(245, 245, 245);
        public static Color DarkWhite = Color.FromArgb(235, 235, 235); 

        public static Sgry.Azuki.WinForms.AzukiControl StaticMainTextBox { get; private set; }

        public Main(string[] option)
        {
            flash.Show();

            InitializeComponent();

            Properties.Settings.Default.Ver = VerInfo.ver;

            Properties.Settings.Default.Save();

            if (IsAdministrator())
            {
                this.Text += " (Adminstator)";
            }

            StaticMainTextBox = MainTextBox;

            FileNamePanel.Region = new Region(PanelRegion(FileNamePanel));

            MoziPanel.Region = new Region(PanelRegion(MoziPanel));

            MainTextBox.ColorScheme.CleanedLineBar = Color.FromArgb(0,0,0,0);

            if (Properties.Settings.Default.Dark)
            {
                ToDark();
            }
            if (!(Properties.Settings.Default.Dark))
            {
                FileNameLabel.BackColor = DarkWhite;
                FileNamePanel.BackColor = DarkWhite;

                MoziLabel.BackColor = DarkWhite;
                MoziPanel.BackColor = DarkWhite;
            }

            if (!(option == null) && !(option.Length == 0))
            {
                try
                {
                    string extension = Path.GetExtension(option[0]);

                    if (extension != null && extension == ".txt") 
                    {
                        OpenedPath = option[0];

                        CheckTextsOn = true;
                        MainTextBox.Text = File.ReadAllText(OpenedPath);
                        CheckTextsOn = false;

                        FileNameLabel.Text = OpenedPath;
                        fText = MainTextBox.Text;
                    }
                    else
                    {
                        Msgs.MsgDialog(35);
                    }
                }
                catch
                {
                    Msgs.MsgDialog(20);
                }
            }

            if (Properties.Settings.Default.Font == null)
            {
                Properties.Settings.Default.Font = new Font("MS UI Gothic", 9);
            }
            MainTextBox.Font = Properties.Settings.Default.Font;

            CloseFlash();
        }

        public void ToDark()
        {
            BackColor = Color.Black;
            ForeColor = Color.White;

            /*
            MainTextBox.BackColor = Gray;
            MainTextBox.ForeColor = Color.White;
            */

            MainTextBox.ColorScheme.LineNumberBack = DarkGray;
            MainTextBox.ColorScheme.LineNumberFore = FontC;
            MainTextBox.ColorScheme.MatchedBracketFore = Color.Black;
            MainTextBox.BackColor = Gray;
            MainTextBox.ForeColor = FontC;

            menuStrip1.BackColor = Gray;
            menuStrip1.ForeColor = Color.White;

            NewWindowToolStripMenuItem.BackColor = Gray;
            NewWindowToolStripMenuItem.ForeColor = FontC;

            NewFileToolStripMenuItem.BackColor = Gray;
            NewFileToolStripMenuItem.ForeColor = FontC;

            OpenToolStripMenuItem.BackColor = Gray;
            OpenToolStripMenuItem.ForeColor = FontC;

            ReReadToolStripMenuItem.BackColor = Gray;
            ReReadToolStripMenuItem.ForeColor = FontC;

            OverWriteToolStripMenuItem.BackColor = Gray;
            OverWriteToolStripMenuItem.ForeColor = FontC;

            SaveAsToolStripMenuItem.BackColor = Gray;
            SaveAsToolStripMenuItem.ForeColor = FontC;

            SaveToMNFPToolStripMenuItem.BackColor = Gray;
            SaveToMNFPToolStripMenuItem.ForeColor = FontC;

            QuitToolStripMenuItem.BackColor = Gray;
            QuitToolStripMenuItem.ForeColor = FontC;

            MemoToolStripMenuItem.BackColor = Gray;
            MemoToolStripMenuItem.ForeColor = FontC;

            AnalysisToolStripMenuItem.BackColor = Gray;
            AnalysisToolStripMenuItem.ForeColor = FontC;

            SettingsToolStripMenuItem.BackColor = Gray;
            SettingsToolStripMenuItem.ForeColor = FontC;

            AllSettingsEandIToolStripMenuItem.BackColor = Gray;
            AllSettingsEandIToolStripMenuItem.ForeColor = FontC;

            ExpSettingsToolStripMenuItem.BackColor = Gray;
            ExpSettingsToolStripMenuItem.ForeColor = FontC;

            InpSettingsToolStripMenuItem.BackColor = Gray;
            InpSettingsToolStripMenuItem.ForeColor = FontC;

            HelpToolStripMenuItem.BackColor = Gray;
            HelpToolStripMenuItem.ForeColor = FontC;

            HelpToolStripMenuItem1.BackColor = Gray;
            HelpToolStripMenuItem1.ForeColor = FontC;

            VerInfoToolStripMenuItem.BackColor = Gray;
            VerInfoToolStripMenuItem.ForeColor = FontC;

            FileNameLabel.BackColor = DarkGray;
            FileNameLabel.ForeColor = FontC;

            MoziLabel.BackColor = DarkGray;
            MoziLabel.ForeColor = FontC;

            FileNamePanel.BackColor = DarkGray;
            FileNamePanel.ForeColor = FontC;

            MoziPanel.BackColor = DarkGray;
            MoziPanel.ForeColor = FontC;
        }

        public void CheckTexts()
        {
            string moziTemp = MainTextBox.Text;
            string mozi = moziTemp.Replace("\n", "");

            string[] lines = moziTemp.Split(new[] { "\n" }, StringSplitOptions.None);

            if (Properties.Settings.Default.SaidaiMoziOn)
            {
                if (mozi.Length > Properties.Settings.Default.SaidaiMozi)
                {
                    Msgs.MsgDialog(32);
                    Properties.Settings.Default.SaidaiMoziOn = false;
                }
            }

            if (Properties.Settings.Default.SaidaiRetsuOn)
            {
                foreach (string line in lines)
                {
                    int lineLength = line.Length;
                    if (lineLength > Properties.Settings.Default.SaidaiRetsu)
                    {
                        Msgs.MsgDialog(33);
                        Properties.Settings.Default.SaidaiRetsuOn = false;
                    }
                }
            }

            if (Properties.Settings.Default.SaidaiGyouOn)
            {
                if (lines.Length > Properties.Settings.Default.SaidaiGyou)
                {
                    Msgs.MsgDialog(34);
                    Properties.Settings.Default.SaidaiGyouOn = false;
                }
            }
        }

        public static System.Drawing.Drawing2D.GraphicsPath PanelRegion(Panel panel)
        {
            int radius = 1;
            int diameter = radius * 2;
            System.Drawing.Drawing2D.GraphicsPath gp = new();

            // 左上
            gp.AddPie(0, 0, diameter, diameter, 180, 90);
            // 右上
            gp.AddPie(panel.Width - diameter, 0, diameter, diameter, 270, 90);
            // 左下
            gp.AddPie(0, panel.Width - diameter, diameter, diameter, 90, 90);
            // 右下
            gp.AddPie(panel.Width - diameter, panel.Height - diameter, diameter, diameter, 0, 90);
            // 中央
            gp.AddRectangle(new Rectangle(radius, 0, panel.Width - diameter, panel.Height));
            // 左
            gp.AddRectangle(new Rectangle(0, radius, radius, panel.Height - diameter));
            // 右
            gp.AddRectangle(new Rectangle(panel.Width - radius, radius, radius, panel.Height - diameter));

            return gp;
        } 

        public Task CloseFlash()
        {
            Task.Delay(5000);
            flash.Close();
            return null;
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new();
            settings.ShowDialog();
        }

        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
            string moziTemp = MainTextBox.Text;
            string mozi = moziTemp.Replace("\n", "");
            MoziLabel.Text = mozi.Length.ToString() + "文字";

            if (CheckTextsOn)
            {
                CheckTexts();
            }

            if (Properties.Settings.Default.SaidaiMoziOn)
            {
                if (mozi.Length > Properties.Settings.Default.SaidaiMozi)
                {
                    Msgs.MsgDialog(21);
                    MainTextBox.Text = backText;
                }
            }

            if (Properties.Settings.Default.SaidaiRetsuOn)
            {
                // 現在のテキストを取得
                string text = MainTextBox.Text;

                // 行ごとに分割
                string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);

                foreach (string line in lines)
                {
                    int lineLength = line.Length;
                    if (lineLength > Properties.Settings.Default.SaidaiRetsu)
                    {
                        Msgs.MsgDialog(22);
                        MainTextBox.Text = backText; // 元のテキストを復元
                    }
                }
            }

            if (Properties.Settings.Default.SaidaiGyouOn)
            {
                // 現在のテキストを取得
                string text = MainTextBox.Text;

                // 行ごとに分割
                string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);

                if (lines.Length > Properties.Settings.Default.SaidaiGyou)
                {
                    Msgs.MsgDialog(23);
                    MainTextBox.Text = backText; // 元のテキストを復元
                }
            }

            backText = MainTextBox.Text;
        }

        private void KeyDowning(object sender, KeyEventArgs e)
        {
            StaticMainTextBox = MainTextBox;

            string Ctrl1 = Properties.Settings.Default.Ctrl1;
            string Ctrl2 = Properties.Settings.Default.Ctrl2;
            string Ctrl3 = Properties.Settings.Default.Ctrl3;
            string Ctrl4 = Properties.Settings.Default.Ctrl4;
            string Ctrl5 = Properties.Settings.Default.Ctrl5;

            if (e.KeyCode == (Keys.D1) && e.Control == true)
            {
                if (Properties.Settings.Default.Ctrl1On)
                {
                    // 現在のIMEモードを保存
                    bool _isImeEnabled = IsImeEnabled();

                    // IMEモードを無効化
                    SetImeStatus(false);

                    SendKeys.Send(Ctrl1);
                    // 元のIMEモードに復元
                    SetImeStatus(_isImeEnabled);
                }
            }

            if (e.KeyCode == (Keys.D2) && e.Control == true)
            {
                if (Properties.Settings.Default.Ctrl2On)
                {
                    // 現在のIMEモードを保存
                    bool _isImeEnabled = IsImeEnabled();

                    // IMEモードを無効化
                    SetImeStatus(false);

                    SendKeys.Send(Ctrl2);

                    // 元のIMEモードに復元
                    SetImeStatus(_isImeEnabled);
                }
            }

            if (e.KeyCode == (Keys.D3) && e.Control == true)
            {
                if (Properties.Settings.Default.Ctrl3On)
                {
                    // 現在のIMEモードを保存
                    bool _isImeEnabled = IsImeEnabled();

                    // IMEモードを無効化
                    SetImeStatus(false);

                    SendKeys.Send(Ctrl3);

                    // 元のIMEモードに復元
                    SetImeStatus(_isImeEnabled);
                }
            }

            if (e.KeyCode == (Keys.D4) && e.Control == true)
            {
                if (Properties.Settings.Default.Ctrl4On)
                {
                    // 現在のIMEモードを保存
                    bool _isImeEnabled = IsImeEnabled();

                    // IMEモードを無効化
                    SetImeStatus(false);

                    SendKeys.Send(Ctrl4);

                    // 元のIMEモードに復元
                    SetImeStatus(_isImeEnabled);
                }
            }

            if (e.KeyCode == (Keys.D5) && e.Control == true)
            {
                if (Properties.Settings.Default.Ctrl5On)
                {
                    // 現在のIMEモードを保存
                    bool _isImeEnabled = IsImeEnabled();

                    // IMEモードを無効化
                    SetImeStatus(false);

                    SendKeys.Send(Ctrl5);

                    // 元のIMEモードに復元
                    SetImeStatus(_isImeEnabled);
                }
            }
            
            if (e.KeyCode == Keys.M && e.Control == true)
            {
                Memo memo = new();
                memo.Show();
            }

            if (e.KeyCode == Keys.S && e.Control == true)
            {
                OverWriteSave();
            }
            
            if (e.KeyCode == Keys.O && e.Control == true)
            {
                Open();
            }

            if (e.KeyCode == Keys.R && e.Control == true)
            {
                ReRead();
            }

            if (e.KeyCode == Keys.F && e.Control == true)
            {
                Analysis a = new();
                a.Show();
            }

            if (e.KeyCode == Keys.N && e.Control == true)
            {
                新規作成ToolStripMenuItem_Click(null,null);
            }
        }

        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("imm32.dll")]
        private static extern bool ImmSetOpenStatus(IntPtr hIMC, bool fOpen);

        private static bool IsImeEnabled()
        {
            var hIMC = ImmGetContext(IntPtr.Zero);
            return ImmSetOpenStatus(hIMC, true);
        }

        private static void SetImeStatus(bool isEnabled)
        {
            var hIMC = ImmGetContext(IntPtr.Zero);
            ImmSetOpenStatus(hIMC, isEnabled);
        }

        public bool CheckSaving()
        {
            /* How to use?
            bool Canselflag = CheckSaving();
            if (Canselflag)
            {
                return;
            } 
            */

            if (!(fText == MainTextBox.Text))
            {
                DialogResult result = MessageBox.Show("現在の作業内容を保存しますか?", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    OverWriteSave();
                }
                else if (result == DialogResult.Cancel)
                {
                    //canselされた場合、trueを返す。
                    return true;
                }

                if (MainTextBox.Text.Length < 0)
                {
                    if (!(OpenedPath == ""))
                    {
                        OverWriteSave();
                    }
                    else
                    {
                        SaveAs();
                    }
                }
            }
            return false;
        }

        public async void SaveAs()
        {

            SaveFileDialog svfd = new();
            svfd.FileName = "*.txt";
            svfd.DefaultExt = "txt";
            svfd.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            svfd.Title = "保存する場所を選択してください";

            if (svfd.ShowDialog() == DialogResult.OK)
            {             
                try
                {

                    MainWindowProgressBar.Visible = true;

                    string Texts = MainTextBox.Text;

                    string[] lines = Texts.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                    int totalLines = lines.Length;
                    double rate = 100.0 / totalLines; // 各行ごとの進捗率

                    try
                    {
                        File.Delete(svfd.FileName);
                    }
                    catch { }
                    for (int i = 0; i < lines.Length; i++)
                    {
                        // ファイルに行を追加
                        File.AppendAllText(svfd.FileName, lines[i] + Environment.NewLine, Encoding.UTF8);

                        double progressValue = (i + 1) * rate; // 進捗率の計算

                        MainWindowProgressBar.Value = (int)progressValue;
                    }

                    OpenedPath = svfd.FileName;
                }
                catch
                {
                    Msgs.MsgDialog(30);
                    return;
                }
                DateTime currentTime = DateTime.Now;
                string timeString = currentTime.ToString("hh:mm:ss");
                FileNameLabel.Text = OpenedPath + "  (laset save is " + timeString + ")";

                MainTextBox.Document.IsDirty = false;
            }
            else
            {
                Msgs.MsgDialog(30);
                return;
            }
            
            fText = MainTextBox.Text;

            await Task.Delay(1000);

            MainWindowProgressBar.Visible = false;
        }

        private async void OverWriteSave()
        {   
            if (OpenedPath == "")
            {
                SaveAs();
            }
            else
            {
                try
                {

                    MainWindowProgressBar.Visible = true;

                    string Texts = MainTextBox.Text;

                    string[] lines = Texts.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                    int totalLines = lines.Length;
                    double rate = 100.0 / totalLines; // 各行ごとの進捗率

                    try
                    {
                        File.Delete(OpenedPath);
                    }
                    catch { }
                    for (int i = 0; i < lines.Length; i++)
                    {
                        // ファイルに行を追加
                        File.AppendAllText(OpenedPath, lines[i] + Environment.NewLine, Encoding.UTF8);

                        double progressValue = (i + 1) * rate; // 進捗率の計算

                        MainWindowProgressBar.Value = (int)progressValue;
                    }
                }
                catch
                {
                    Msgs.MsgDialog(30);

                    return ;
                }
                DateTime currentTime = DateTime.Now;
                string timeString = currentTime.ToString("hh:mm:ss");
                FileNameLabel.Text = OpenedPath + "  (laset save is " + timeString + ")";

                MainTextBox.Document.IsDirty = false;
            }

            fText = MainTextBox.Text;

            await Task.Delay(1000);

            MainWindowProgressBar.Visible = false;
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }
        public void Open()
        {
            bool Canselflag = CheckSaving();
            if (Canselflag)
            {
                return;
            }

            OpenFileDialog ofd = new();
            ofd.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            ofd.Title = "開くファイルを選択してください";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenedPath = "None";
                OpenedPath = ofd.FileName;
                CheckTextsOn = true;
                MainTextBox.Text = File.ReadAllText(OpenedPath);
                CheckTextsOn = false;
                FileNameLabel.Text = ofd.FileName;
                fText = MainTextBox.Text;

                MainTextBox.Document.IsDirty = false;
            }
            else
            {

            }
        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OverWriteSave();
        }

        private void 名前をつけて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Canselflag = CheckSaving();
            if (Canselflag)
            {
                return;
            }

            MainTextBox.Text = "";
            FileNameLabel.Text = "None";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool Canselflag = CheckSaving();
            if (Canselflag)
            {
                // クローズをキャンセルする
                e.Cancel = true;
            } 
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReRead_Click(object sender, EventArgs e)
        {
            ReRead();
        }
        public void ReRead()
        {
            bool Canselflag = CheckSaving();
            if (Canselflag)
            {
                return;
            }

            if (!(OpenedPath == ""))
            {
                MainTextBox.Text = File.ReadAllText(OpenedPath);
                FileNameLabel.Text = OpenedPath;
                fText = MainTextBox.Text;
            }
            else
            {
                Open();
            }

            MainTextBox.Document.IsDirty = false;
        }

        private void ヘルプToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help help = new();
            help.Show();
        }

        private void SaveToMNFPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MNFP.SaveToMNFP();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerInfo verInfo = new();
            verInfo.Show();
        }

        private void MemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Memo memo = new();
            memo.Show();
        }

        public void AnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analysis a = new();
            a.Show();
        }

        public string GetTextBoxValuePipe()
        {
            return MainTextBox.Text;
        }

        private void NewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly myAssembly = Assembly.GetEntryAssembly();
            string path = myAssembly.Location;

            Process.Start(path);
        }

        private void ExpSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesEpIp EpIp = new();
            EpIp.Export();
        }

        private void InpSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesEpIp EpIp = new();
            EpIp.Import();
        }

        public bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void RunAsAdministrator()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = Application.ExecutablePath,
                Verb = "runas", // 管理者権限で再起動するための設定
                UseShellExecute = true
            };

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
