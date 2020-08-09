using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using maid;
namespace maid
{

    public partial class Form1 : Form
    {
        maid shit = new maid();
        #region startup
        public const int aa = 0xA1;
        public const int bb = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr iptr, int msg, int wparam, int iparam);

        [DllImportAttribute("user32.dll")]
        public static extern int ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, aa, bb, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            shit.moveFiles(textBox1.Text);
            MessageBox.Show("Done","Files Orginized",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
