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

namespace OtobüsOtomasyonu
{
    public partial class OtobüsOtomasyonu : Form
    {
        Baglanti bgl = new Baglanti();
        SqlDataAdapter dataadapter;
        DataTable tbl = new DataTable();

        public OtobüsOtomasyonu()
        {
            InitializeComponent();

        }

        string Kullanici = girispaneli.KullaniciAdSoyad;
        string kullanıcı;
        void GuncelTablo()
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            tbl.Clear();
            dataadapter = new SqlDataAdapter("SELECT *FROM SeferTanım", data);
            dataadapter.Fill(tbl);
            TanımlıSeferler.DataSource = tbl;
            //TanımlıSeferler.Columns[0].Visible = false; //KOLON GİZLEME
            TanımlıSeferler.Columns[1].Visible = false; //KOLON GİZLEME
            TanımlıSeferler.Columns["Seferid"].HeaderText = "Sefer No";
            TanımlıSeferler.Columns["Otürü"].HeaderText = "Otobüs Türü";
            TanımlıSeferler.Columns["SeferSaati"].HeaderText = "Sefer Saati";
            TanımlıSeferler.Columns["SeferTarihi"].HeaderText = "Sefer Tarihi";

        }

        
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2GradientButton8.Checked = false;
            guna2GradientButton7.Checked = false;
            guna2GradientButton6.Checked = false;
            guna2GradientButton1.Checked = false;
            guna2GradientButton2.Checked = false;
            guna2GradientButton3.Checked = false;
            guna2GradientButton4.Checked = false;
            biletislemleri bi2 = new biletislemleri();
            
            bi2.Dock = DockStyle.Fill;
            bi2.TopLevel = false;
            bi2.FormBorderStyle = FormBorderStyle.None;
            guna2Panel3.Controls.Add(bi2);
            bi2.Show();
            bi2.BringToFront();
        }

        

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Hide();
            girispaneli f1 = new girispaneli();
            f1.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            guna2GradientButton8.Checked = false;
            guna2GradientButton7.Checked = false;
            guna2GradientButton6.Checked = false;
            guna2GradientButton1.Checked = true;
            guna2GradientButton2.Checked = false;
            guna2GradientButton3.Checked = false;
            guna2GradientButton4.Checked = false;
            biletislemleri bi2 = new biletislemleri();

            bi2.Dock = DockStyle.Fill;
            bi2.TopLevel = false;
            bi2.FormBorderStyle = FormBorderStyle.None;
            guna2Panel3.Controls.Add(bi2);
            bi2.Show();
            bi2.BringToFront();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            guna2GradientButton8.Checked = false;
            guna2GradientButton7.Checked = false;
            guna2GradientButton6.Checked = false;
            guna2GradientButton2.Checked = true;
            guna2GradientButton1.Checked = false;
            guna2GradientButton3.Checked = false;
            guna2GradientButton4.Checked = false;
            seferislemleri si2 = new seferislemleri();

            si2.Dock = DockStyle.Fill;
            si2.TopLevel = false;
            si2.FormBorderStyle = FormBorderStyle.None;
            guna2Panel3.Controls.Add(si2);
            si2.Show();
            si2.BringToFront();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            guna2GradientButton8.Checked = false;
            guna2GradientButton7.Checked = false;
            guna2GradientButton6.Checked = false;
            guna2GradientButton2.Checked = true;
            guna2GradientButton1.Checked = false;
            guna2GradientButton3.Checked = false;
            guna2GradientButton4.Checked = false;
            Hide();
            girispaneli f1 = new girispaneli();
            f1.Show();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            guna2GradientButton7.Checked = true;
            guna2GradientButton8.Checked = false;
            guna2GradientButton6.Checked = false;
            guna2GradientButton1.Checked = false;
            guna2GradientButton3.Checked = false;
            guna2GradientButton2.Checked = false;
            guna2GradientButton4.Checked = false;

            GuncelTablo();
            guna2Panel4.BringToFront();
            guna2Panel4.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            saat.Text = DateTime.Now.ToLongTimeString();
           tarih.Text= DateTime.Now.ToShortDateString();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            guna2GradientButton8.Checked = false;
            guna2GradientButton7.Checked = false;
            guna2GradientButton6.Checked = true;
            guna2GradientButton3.Checked = false;
            guna2GradientButton1.Checked = false;
            guna2GradientButton2.Checked = false;
            guna2GradientButton4.Checked = false;
            kayıtislemleri ki2 = new kayıtislemleri();

            ki2.Dock = DockStyle.Fill;
            ki2.TopLevel = false;
            ki2.FormBorderStyle = FormBorderStyle.None;
            guna2Panel3.Controls.Add(ki2);
            ki2.Show();
            ki2.BringToFront();

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            guna2GradientButton8.Checked = false;
            guna2GradientButton7.Checked = false;
            guna2GradientButton3.Checked = true;
            guna2GradientButton4.Checked = false;
            guna2GradientButton6.Checked = false;
            guna2GradientButton1.Checked = false;
            guna2GradientButton2.Checked = false;
            otobüsislemleri oi2 = new otobüsislemleri();

            oi2.Dock = DockStyle.Fill;
            oi2.TopLevel = false;
            oi2.FormBorderStyle = FormBorderStyle.None;
            guna2Panel3.Controls.Add(oi2);
            oi2.Show();
            oi2.BringToFront();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            guna2GradientButton8.Checked = false;
            guna2GradientButton4.Checked = true;
            guna2GradientButton7.Checked = false;
            guna2GradientButton6.Checked = false;
            guna2GradientButton1.Checked = false;
            guna2GradientButton2.Checked = false;
            guna2GradientButton3.Checked = false;
            kullanıcıislemleri kis2 = new kullanıcıislemleri();

            kis2.Dock = DockStyle.Fill;
            kis2.TopLevel = false;
            kis2.FormBorderStyle = FormBorderStyle.None;
            guna2Panel3.Controls.Add(kis2);
            kis2.Show();
            kis2.BringToFront();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OtobüsOtomasyonu_Load(object sender, EventArgs e)
        {
            GuncelTablo();
           
           
            girispaneli gp = new girispaneli();
            label2.Text = Kullanici;
           kullanıcı = label2.Text;
            label2.Text = kullanıcı.ToUpper();
        }

        private void SeferAra_Click(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            data.Open();
            SqlCommand Ara = new SqlCommand("SELECT * from SeferTanım where Hepsi like '%" + SeferNeredenAna.Text + " - " + SeferNereyeAna.Text + "%'", data);
            SqlDataReader dr = Ara.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            TanımlıSeferler.DataSource = dt;
            data.Close();
        }

       

       
        private void guna2GradientButton11_Click(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            if (MessageBox.Show("Bu kaydı silmek istiyor musunuz ?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                data.Open();
                SqlCommand komut = new SqlCommand("Delete From SeferTanım Where Plaka=@Plaka", data);
                komut.Parameters.AddWithValue("@Plaka", TanımlıSeferler.CurrentRow.Cells["Plaka"].Value.ToString());
                komut.ExecuteNonQuery();
                data.Close();
                
            }

            GuncelTablo();
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            SeferNeredenAna.SelectedIndex = -1;
            SeferNereyeAna.SelectedIndex = -1;
            
        }

        private void TarihAna_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            hakkımda hk = new hakkımda();
            guna2GradientButton8.Checked = true;
            guna2GradientButton7.Checked = false;
            guna2GradientButton6.Checked = false;
            guna2GradientButton2.Checked = false;
            guna2GradientButton1.Checked = false;
            guna2GradientButton3.Checked = false;

            hk.Dock = DockStyle.Fill;
            hk.TopLevel = false;
            hk.FormBorderStyle = FormBorderStyle.None;
            guna2Panel3.Controls.Add(hk);
            hk.Show();
            hk.BringToFront();
            
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void saat_Click(object sender, EventArgs e)
        {

        }

        private void tarih_Click(object sender, EventArgs e)
        {

        }

        private void TanımlıSeferler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SeferNeredenAna_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
