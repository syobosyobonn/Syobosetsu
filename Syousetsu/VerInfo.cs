using System;
using System.Drawing;
using System.Windows.Forms;

namespace Syobosetsu
{
    public partial class VerInfo : Form
    {
        public static string ver = "0.16.0";

        public VerInfo()
        {
            InitializeComponent();

            label1.Text = $"Ver:(β).{ver}";
        }

        private void VerInfo_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Dark)
            {
                Color Gray = Color.FromArgb(33, 33, 33);
                Color FontC = Color.FromArgb(245, 245, 245);

                this.BackColor = Gray;
                this.ForeColor = FontC;
            }
        }

        private void VerInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Control == true)
            {
                DebugWindow debugWindow = new();
                debugWindow.Show();
            }
        }
    }
}
