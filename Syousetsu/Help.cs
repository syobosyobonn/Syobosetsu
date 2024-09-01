using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syobosetsu
{
    public partial class Help : Form
    {
        public Help()
        {
            Color Gray = Color.FromArgb(33, 33, 33);
            Color FontC = Color.FromArgb(245, 245, 245);

            InitializeComponent();

            if (Properties.Settings.Default.Dark)
            {
                BackColor = Color.Black;
                ForeColor = Color.White;

                richTextBox1.BackColor = Gray;
                richTextBox1.ForeColor = FontC;

                treeView1.BackColor = Gray;
                treeView1.ForeColor = FontC;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Text == "概要")
                {
                    richTextBox1.Text =
                        "このウィンドウは\"Syobosetsu\"のヘルプです。\n" +
                        "\n" +
                        "(copyright) 2024 Syobosyobonn\n" +
                        "\n";
                }
                else if (selectedNode.Text == "ショートカット")
                {
                    richTextBox1.Text =
                        "・Ctrl+O\t-ファイルを開く\n" +
                        "・Ctrl+R\t-ファイルをリロード\n" +
                        "・Ctrl+S\t-ファイルを上書き保存\n" + 
                        "\t-(開かれてない場合は名前を付けて保存)\n" +
                        "・Ctrl+M\t-メモウィンドウを開く\n" +
                        "・Ctrl+F\t-解析ウィンドウを開く\n" +
                        "\n";
                }
                else if (selectedNode.Text == "その他")
                {
                    richTextBox1.Text =
                        "このプログラムは、β版です。\n" +
                        "ご留意ください。\n";
                }
                else if (selectedNode.Text == "Copyright")
                {
                    richTextBox1.Text =
                        "■Azuki\n" +
                        "　作者様\t\tYAMAMOTO Suguru\n"+
                        "　ライセンス\tzlib License\n"+
                        "　Ver\t\t1.7.13";
                }
                else
                {
                    richTextBox1.Text = "";
                }
            }
        }
    }
}
