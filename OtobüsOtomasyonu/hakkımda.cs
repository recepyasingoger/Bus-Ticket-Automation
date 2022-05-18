using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobüsOtomasyonu
{
    public partial class hakkımda : Form
    {
        public hakkımda()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2CircleProgressBar1.Value = +30;
        }

        private void hakkımda_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void guna2ImageButton2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/recepyasingx");
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/recepyasingoger");
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/recepyasingoger/");

        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/recep-yasin-göger-465728214/");
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/recepyasingoger"); 
        }
    }
}
