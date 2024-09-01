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
    public partial class ChangeMemoName : Form
    {
        int selectedMemoI = 0;

        public ChangeMemoName(int i)
        {
            InitializeComponent();
            selectedMemoI = i;

            if (Properties.Settings.Default.Dark)
            {
                BackColor = Color.Black;
                ForeColor = Color.White;

                textBox1.BackColor = Color.FromArgb(33, 33, 33);
                textBox1.ForeColor = Color.FromArgb(245, 245, 245);

                OK.BackColor = Color.FromArgb(33, 33, 33);
                OK.ForeColor = Color.FromArgb(245, 245, 245);

                Cansel.BackColor = Color.FromArgb(33, 33, 33);
                Cansel.ForeColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MemosName[selectedMemoI] = textBox1.Text;
            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
