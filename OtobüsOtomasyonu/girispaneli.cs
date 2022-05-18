using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace OtobüsOtomasyonu
{
    
    public partial class girispaneli : Form
    {
       
        Baglanti bgl = new Baglanti();

        public girispaneli()
        {

            InitializeComponent();
            
        }
        public static string KullaniciAdSoyad = "";

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            string kadi = guna2TextBox1.Text;
            string parola = guna2TextBox2.Text;
            baglanti.Open();
            string sql = "select * from yönetimpanel where kullaniciadi = @kullaniciadi and sifre = @sifre";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(new SqlParameter("@kullaniciadi", kadi));
            komut.Parameters.Add(new SqlParameter("@sifre", parola));
            
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                KullaniciAdSoyad = reader[1].ToString();
                OtobüsOtomasyonu oo = new OtobüsOtomasyonu();
                oo.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
            }

            baglanti.Close();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/recepyasingx");
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/recepyasingoger"); 
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/recep-yasin-göger-465728214/");  
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/recepyasingoger/");  
        }

        
        private void girispaneli_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2GradientButton1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void guna2GradientButton1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2GradientButton1.PerformClick();

            }
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2GradientButton1.PerformClick();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
