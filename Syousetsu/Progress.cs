using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syobosetsu
{
    public partial class Progress : Form
    {
        public ProgressBar ProgressBarAccsess { get; }

        public int IconID;

        public Progress(int i)
        {
            InitializeComponent();

            IconID = i;

            // ProgressBarの初期化
            ProgressBarAccsess = new  ProgressBar();
            ProgressBarAccsess.Minimum = 0;
            ProgressBarAccsess.Maximum = 100;
            ProgressBarAccsess.Value = 0;
            
            Thread.Sleep(500);
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            if (IconID == 0)
            {

            }
            if (IconID == 1)
            {
                label1.Text = "Saving file....";
            }
            if (IconID == 2)
            {
                label1.Text = "Making Analysys....";
            }
        }

        public void UpdateProgressBar(int value)
        {
            Thread.Sleep(1);
            ProgressBarAccsess.Value = value;
            progressBar1.Value = ProgressBarAccsess.Value;

            if (IconID == 0)
            {

            }
            if (IconID == 1)
            {
                label1.Text = "Saving file....";
            }
            if (IconID == 2)
            {
                label1.Text = "Making Analysys....";
            }
        }
    }
}
