using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Syobosetsu
{
    public partial class Analysis : Form
    {
        public string[] AnalisysNames;

        Color Gray = Color.FromArgb(33, 33, 33);
        Color FontC = Color.FromArgb(245, 245, 245);

        public Analysis()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Dark)
            {
                BackColor = Color.Black;
                ForeColor = Color.White;

                chart1.BackColor = Gray;
                chart1.ForeColor = FontC;

                button1.BackColor = Gray;
                button1.ForeColor = FontC;

                button2.BackColor = Gray;
                button2.ForeColor = FontC;

                button3.BackColor = Gray;
                button3.ForeColor = FontC;

                groupBox1.ForeColor = FontC;
                groupBox2.ForeColor = FontC;

                textBox1.BackColor = Gray;
                textBox1.ForeColor = FontC;

                listBox1.BackColor = Gray;
                listBox1.ForeColor = FontC;
            }
        }

        public void ResetGraph()
        {
            Progress progress = new Progress(2);
            progress.Show();

            progress.UpdateProgressBar(0);

            if (Properties.Settings.Default.AnalNames == null)
            {
                Properties.Settings.Default.AnalNames = new string[] { };
                Properties.Settings.Default.Save();
            }
            AnalisysNames = Properties.Settings.Default.AnalNames;

            listBox1.Items.Clear();
            for (int i = 0;i < AnalisysNames.Length; i++)
            {
                listBox1.Items.Add(AnalisysNames[i]);
            }

            // clear
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();

            if (AnalisysNames.Length == 0)
            {
                string[] newArray = new string[AnalisysNames.Length + 1];
                // 元の配列を新しい配列にコピー
                Array.Copy(AnalisysNames, newArray, AnalisysNames.Length);
                // 新しい要素を追加
                newArray[newArray.Length - 1] = "登録した後、これを削除してください。";
                // プロパティに新しい配列を設定
                AnalisysNames = newArray;

                Properties.Settings.Default.AnalNames = AnalisysNames;
                Properties.Settings.Default.Save();

                MessageBox.Show("\"登録した後、これを削除してください。\"が表示されていない場合は\nReloadボタンを押してください。", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            chart1.ChartAreas.Add(new ChartArea());
            chart1.Legends.Add(new Legend());

            Series series = new Series("出現数")
            {
                ChartType = SeriesChartType.Bar
            };

            string text = Main.StaticMainTextBox.Text;

            int rate = 100 / AnalisysNames.Length;
            int Progress = 0;

            for (int i = 0; i < AnalisysNames.Length; i++)
            {
                string searchString = AnalisysNames[i];
                int index = -1;
                int count = 0;
                try
                {
                    while ((index = text.IndexOf(searchString, index + 1)) != -1)
                    {
                        count++;
                    }
                    Progress = Progress + rate;
                    progress.UpdateProgressBar(Progress);
                }
                catch { }

                series.Points.AddXY(AnalisysNames[i], count); // ここではX軸をインデックス、Y軸を配列の値として設定

                if (rate == 100)
                {
                    progress.UpdateProgressBar(rate);
                }
            }


            chart1.Series.Add(series);

            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 10;

            if (Properties.Settings.Default.Dark)
            {
                chart1.BackColor = Gray;
                chart1.ForeColor = FontC;
                chart1.BorderlineColor = FontC;

                series.LabelBackColor = Gray;
                series.LabelForeColor = FontC;

                chart1.ChartAreas["ChartArea1"].BorderWidth = 2; // 枠の幅を設定
                chart1.ChartAreas["ChartArea1"].BackColor = Gray;
                chart1.ChartAreas["ChartArea1"].BorderColor = FontC;
                chart1.ChartAreas["ChartArea1"].BorderDashStyle = ChartDashStyle.Solid; // 枠のスタイルを設定
                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash; // X軸の主グリッドのスタイルを設定
                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot; // X軸の副グリッドのスタイルを設定
                chart1.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = FontC;
                chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = FontC;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash; // Y軸の主グリッドのスタイルを設定
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot; // Y軸の副グリッドのスタイルを設定
                chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = FontC;
                chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = FontC;

                chart1.Legends["Legend1"].BackColor = Gray;
                chart1.Legends["Legend1"].ForeColor = FontC;
                chart1.Legends["Legend1"].BorderColor = FontC;
            }

            progress.Close();
        }

        private void Analysis_Load(object sender, EventArgs e)
        {
            ResetGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == ""))
            {
                string[] newArray = new string[AnalisysNames.Length + 1];
                // 元の配列を新しい配列にコピー
                Array.Copy(AnalisysNames, newArray, AnalisysNames.Length);
                // 新しい要素を追加
                newArray[newArray.Length - 1] = this.textBox1.Text;
                // プロパティに新しい配列を設定
                AnalisysNames = newArray;

                Properties.Settings.Default.AnalNames = AnalisysNames;
                Properties.Settings.Default.Save();

                ResetGraph();
            }
            else
            {
                MessageBox.Show("テキストボックスにテキストを入力してください。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0 && index < AnalisysNames.Length)
            {
                try
                {
                    // 新しい配列を作成し、削除したい要素を除外
                    string[] newArray = AnalisysNames.Where((val, idx) => idx != index).ToArray();
                    // プロパティに新しい配列を設定
                    AnalisysNames = newArray;

                    Properties.Settings.Default.AnalNames = AnalisysNames;
                    Properties.Settings.Default.Save();

                    ResetGraph();
                }
                catch 
                {
                    MessageBox.Show("エラーが発生しました。アイテムが選択されているかなどを確認してください。","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Analysis analysis = new Analysis();
            analysis.Show();
            this.Close();
        }
    }
}
