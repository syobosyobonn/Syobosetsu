using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();

            ToDarkTitleBarProsess.Run(this);
        }
    }

    internal class ToDarkTitleBarProsess
    {
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref int pvAttribute, uint cbAttribute);

        public static void Run(Form form)
        {
            int value = 1;
            DwmSetWindowAttribute(form.Handle, DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, ref value, (uint)Marshal.SizeOf(typeof(int)));
        }

        private enum DWMWINDOWATTRIBUTE
        {
            DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
            DWMWA_WINDOW_CORNER_PREFERENCE = 33,
            DWMWA_MICA_EFFECT = 1029,
            DWMWA_LAST
        }
    }
}
