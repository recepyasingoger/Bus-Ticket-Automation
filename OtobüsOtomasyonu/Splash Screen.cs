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
    public partial class Splash_Screen : Form
    {
      
        public Splash_Screen()
        {
            InitializeComponent();
           
           
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width +=4;
            if(panel1.Width >= 900)
            {
                timer1.Stop();
                girispaneli grp = new girispaneli();
                grp.Show();
                this.Hide();
            }
            
        }

     
    }
}
