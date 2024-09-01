using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syobosetsu
{
    public partial class FlashScreen : Form
    {

        public FlashScreen()
        {
            InitializeComponent();
        }

        private async void FlashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void pictureBox1_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Thread.Sleep(1000);
        }
    }
}
