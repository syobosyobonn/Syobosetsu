using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Syobosetsu
{
    public partial class Settings : Form
    {
        Main main = new(null);

        public Settings()
        {
            InitializeComponent();

            //プロパティ→画面の同期
            if (Properties.Settings.Default.Ctrl1On)
            {
                checkBox1.Checked = true;
            }
            else
            {
                textBox1.Enabled = false;
            }

            if (Properties.Settings.Default.Ctrl2On)
            {
                checkBox2.Checked = true;
            }
            else
            {
                textBox2.Enabled = false;
            }

            if (Properties.Settings.Default.Ctrl3On)
            {
                checkBox3.Checked = true;
            }
            else
            {
                textBox3.Enabled = false;
            }

            if (Properties.Settings.Default.Ctrl4On)
            {
                checkBox4.Checked = true;
            }
            else
            {
                textBox4.Enabled = false;
            }

            if (Properties.Settings.Default.Ctrl5On)
            {
                checkBox5.Checked = true;
            }
            else
            {
                textBox5.Enabled = false;
            }

            if (Properties.Settings.Default.PathIsAdded)
            {
                button2.Enabled = false;
                button3.Enabled = true;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = false;
            }

            textBox1.Text = Properties.Settings.Default.Ctrl1;
            textBox2.Text = Properties.Settings.Default.Ctrl2;
            textBox3.Text = Properties.Settings.Default.Ctrl3;
            textBox4.Text = Properties.Settings.Default.Ctrl4;
            textBox5.Text = Properties.Settings.Default.Ctrl5;

            numericUpDown1.Enabled = Properties.Settings.Default.SaidaiMoziOn;
            numericUpDown2.Enabled = Properties.Settings.Default.SaidaiRetsuOn;
            numericUpDown3.Enabled = Properties.Settings.Default.SaidaiGyouOn;

            checkBox12.Checked = Properties.Settings.Default.SaidaiMoziOn;
            checkBox13.Checked = Properties.Settings.Default.SaidaiRetsuOn;
            checkBox14.Checked = Properties.Settings.Default.SaidaiGyouOn;

            numericUpDown1.Value = Properties.Settings.Default.SaidaiMozi;
            numericUpDown2.Value = Properties.Settings.Default.SaidaiRetsu;
            numericUpDown3.Value = Properties.Settings.Default.SaidaiGyou;

            checkBox6.Checked = Properties.Settings.Default.Dark;
            if (Properties.Settings.Default.Dark)
            {
                this.BackColor = Color.FromArgb(33, 33, 33);
                this.ForeColor = Color.White;
                button1.BackColor = Color.FromArgb(33, 33, 33);
                button1.ForeColor = Color.White;

                button2.BackColor = Color.FromArgb(33, 33, 33);
                button2.ForeColor = Color.White;

                button3.BackColor = Color.FromArgb(33, 33, 33);
                button3.ForeColor = Color.White;

                button4.BackColor = Color.FromArgb(33, 33, 33);
                button4.ForeColor = Color.White;

                Font.BackColor = Color.FromArgb(33, 33, 33);
                Font.ForeColor = Color.White;

                groupBox1.ForeColor = Color.White;
                groupBox2.ForeColor = Color.White;
                groupBox3.ForeColor = Color.White;
                groupBox4.ForeColor = Color.White;
                groupBox5.ForeColor = Color.White;
                groupBox6.ForeColor = Color.White;
                EnvBox.ForeColor = Color.White;
            }

            

            if (main.IsAdministrator())
            {
                button4.Visible = false;
            }
        }

        //ショートカット類の有効化または無効化設定変更時の処理
        //(内容→プロパティ)
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
                Properties.Settings.Default.Ctrl1On = true;
            }
            else
            {
                textBox1.Enabled = false;
                Properties.Settings.Default.Ctrl1On = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
                Properties.Settings.Default.Ctrl2On = true;
            }
            else
            {
                textBox2.Enabled = false;
                Properties.Settings.Default.Ctrl2On = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            {
                textBox3.Enabled = true;
                Properties.Settings.Default.Ctrl3On = true;
            }
            else
            {
                textBox3.Enabled= false;
                Properties.Settings.Default.Ctrl3On = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox4.Enabled = true;
                Properties.Settings.Default.Ctrl4On = true;
            }
            else
            {
                textBox4.Enabled = false;
                Properties.Settings.Default.Ctrl4On = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox5.Enabled = true;
                Properties.Settings.Default.Ctrl5On = true;
            }
            else
            {
                textBox5.Enabled= false;
                Properties.Settings.Default.Ctrl5On = false;
            }
        }

        //定型文の設定変更時の処理
        //(内容→プロパティ)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Ctrl1 = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Ctrl2 = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Ctrl3 = textBox3.Text;
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Ctrl4 = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Ctrl5 = textBox5.Text;
        }

        //最大文字数云々の有効化または無効化設定変更時の処理
        //(内容→プロパティ)
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaidaiMoziOn = checkBox12.Checked;
            numericUpDown1.Enabled = checkBox12.Checked;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaidaiRetsuOn = checkBox13.Checked;
            numericUpDown2.Enabled = checkBox13.Checked;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaidaiGyouOn = checkBox14.Checked;
            numericUpDown3.Enabled = checkBox14.Checked;
        }

        //最大文字数云々の設定変更時の処理
        //(内容→プロパティ)
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaidaiMozi = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaidaiRetsu = (int)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaidaiGyou = (int)numericUpDown3.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //アプリ終了後も引き継がれるように終了
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Dark = checkBox6.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (main.IsAdministrator())
            {
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string newPath = appDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);

                if (!currentPath.Split(';').Contains(newPath))
                {
                    string updatedPath = currentPath + ";" + newPath;

                    Environment.SetEnvironmentVariable("PATH", updatedPath, EnvironmentVariableTarget.Machine);
                }
                else
                {
                }

                button2.Enabled = false;
                button3.Enabled = true;

                Properties.Settings.Default.PathIsAdded = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Msgs.MsgDialog(24);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (main.IsAdministrator())
            {
                // アプリケーションの実行ディレクトリを取得
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // 削除するパスを指定
                string pathToRemove = appDirectory;

                // 現在のPATH環境変数を取得
                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);

                // 現在のPATHから指定されたパスを削除
                string updatedPath = string.Join(";", currentPath.Split(';').Where(p => !p.Equals(pathToRemove, StringComparison.OrdinalIgnoreCase)));

                // 更新したPATHを設定
                Environment.SetEnvironmentVariable("PATH", updatedPath, EnvironmentVariableTarget.Machine);


                button2.Enabled = true;
                button3.Enabled = false;

                Properties.Settings.Default.PathIsAdded = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Msgs.MsgDialog(24);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            main.RunAsAdministrator();
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Reload();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            button4.Text = "🛡️Run-Adminstator";
        }

        private void Font_Click(object sender, EventArgs e)
        {
            //FontDialogクラスのインスタンスを作成
            FontDialog fd = new();

            if (Properties.Settings.Default.Font == null)
            {
                Properties.Settings.Default.Font = new Font("MS UI Gothic", 9);
            }

            fd.Font = Properties.Settings.Default.Font;

            //ユーザーが選択できるポイントサイズの最大値を設定する
            fd.MaxSize = 15;
            fd.MinSize = 10;
            //存在しないフォントやスタイルをユーザーが選択すると
            //エラーメッセージを表示する
            fd.FontMustExist = true;
            //横書きフォントだけを表示する
            fd.AllowVerticalFonts = false;
            //取り消し線、下線、テキストの色などのオプションを指定可能にする
            //デフォルトがTrueのため必要はない
            fd.ShowEffects = false;
            //固定ピッチフォント以外も表示する
            //デフォルトがFalseのため必要はない
            fd.FixedPitchOnly = false;
            //ベクタ フォントを選択できるようにする
            //デフォルトがTrueのため必要はない
            fd.AllowVectorFonts = true;

            //ダイアログを表示する
            if (fd.ShowDialog() != DialogResult.Cancel)
            {
                //TextBox1のフォントと色を変える
                Properties.Settings.Default.Font = fd.Font;
            }
        }
    }
}
