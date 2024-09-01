using System;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Security.Cryptography;

namespace Syobosetsu
{
    public partial class Memo : Form
    {
        #pragma warning disable CS0414 // フィールド 'Memo.selectedMemo' が割り当てられていますが、値は使用されていません
        public int selectedMemo = 0;
        #pragma warning restore CS0414 // フィールド 'Memo.selectedMemo' が割り当てられていますが、値は使用されていません


        public Memo()
        {
            InitializeComponent();

            this.Size = Properties.Settings.Default.MemoWindowSize;

            if (Properties.Settings.Default.Dark)
            {
                Color Gray = Color.FromArgb(33, 33, 33);
                Color FontC = Color.FromArgb(245, 245, 245);

                BackColor = Color.Black;
                ForeColor = Color.White;

                richTextBox1.BackColor = Gray;
                richTextBox1.ForeColor = Color.White;

                groupBox1.ForeColor = Color.White;

                menuStrip1.BackColor = Gray;
                menuStrip1.ForeColor = Color.White;

                QuitToolStripMenuItem.BackColor = Gray;
                QuitToolStripMenuItem.ForeColor= FontC;

                txtToolStripMenuItem.BackColor = Gray;
                txtToolStripMenuItem.ForeColor = FontC;

                comboBox1.BackColor = Gray;
                comboBox1.ForeColor = FontC;

                ChangeName.BackColor = Gray;
                ChangeName.ForeColor = FontC;
            }

            if (Properties.Settings.Default.Memos == null)
            {
                Properties.Settings.Default.Memos = new string[] { "", "", "", "", "", "", "", "", "", "", "" };
            }

            this.Size = Properties.Settings.Default.MemoWindowSize;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Memos[selectedMemo] = richTextBox1.Text;

            Properties.Settings.Default.Save();
        }

        private void ChangeMemo(object sender, EventArgs e)
        {
            selectedMemo = comboBox1.SelectedIndex;
            richTextBox1.Text = Properties.Settings.Default.Memos[selectedMemo];
        }

        private void Memo_Resize(object sender, EventArgs e)
        {
            Properties.Settings.Default.MemoWindowSize = this.Size;
            Properties.Settings.Default.Save();
        }

        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svfd = new SaveFileDialog();
            svfd.FileName = "*.txt";
            svfd.DefaultExt = "txt";
            svfd.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            svfd.Title = "保存する場所を選択してください";

            if (svfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //string[] lines = { "■Memo1\n" + Properties.Settings.Default.Memo1 + "\n\n\n■Memo2\n" + Properties.Settings.Default.Memo2 + "\n\n\n■Memo3\n" + Properties.Settings.Default.Memo3 };
                    string[] lines = new string[11];

                    for (int i = 0; i < Properties.Settings.Default.Memos.Length; i++)
                    {
                        lines[i] = $"{Properties.Settings.Default.MemosName[i]}\n" + Properties.Settings.Default.Memos[i] + "\n";
                    }

                    File.WriteAllLines(svfd.FileName, lines, Encoding.UTF8);
                    MessageBox.Show("正常に保存されました。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("内容は保存されませんでした。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("内容は保存されませんでした。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Memo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MemoWindowSize = this.Size;
            Properties.Settings.Default.Save();
        }

        private void Memo_Load(object sender, EventArgs e)
        {
            this.Size = Properties.Settings.Default.MemoWindowSize;
        }

        private void ChangeName_Click(object sender, EventArgs e)
        {
            ChangeMemoName changeMemoName = new ChangeMemoName(selectedMemo);
            changeMemoName.ShowDialog();

            Memo memo = new Memo();
            memo.Show();

            this.Close();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MemoWindowSize = this.Size;
            this.Close();
        }
    }
}
