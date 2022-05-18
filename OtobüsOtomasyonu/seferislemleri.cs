using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;


namespace OtobüsOtomasyonu
{
    public partial class seferislemleri : Form
    {
        Baglanti bgl = new Baglanti();
        SqlCommand cmd = new SqlCommand();
        public seferislemleri()
        {
            InitializeComponent();
        }
        void Otobusler()
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            SeferPlaka.Items.Clear();
            SqlDataAdapter adapter;
            DataSet DSet = new DataSet();

            adapter = new SqlDataAdapter("SELECT *From Otobus", data);
            adapter.Fill(DSet);

            foreach (DataRow Drow in DSet.Tables[0].Rows)
            {
                SeferPlaka.Items.Add(Drow[1]);
            }

        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            bool Check = true;
            SqlCommand cmd2 = new SqlCommand();
            SqlDataReader dr;


            data.Open();
            cmd2.Connection = data;
            cmd2.CommandText = "SELECT * FROM SeferTanım where Plaka='" + SeferPlaka.Text + "'";
            dr = cmd2.ExecuteReader();

            if (dr.Read())
            {
                Check = true;
            }

            else
            {
                Check = false;
            }

            data.Close();



            if (SeferNereden.SelectedIndex != -1 && SeferPlaka.SelectedIndex != -1 && SeferSaati.SelectedIndex != -1 && SeferNereye.SelectedIndex != -1)
            {

               
                if (Check == false)
                {
                    
                    data.Open();
                    cmd.Connection = data;
                    cmd.CommandText = "Insert Into SeferTanım(Otürü,Plaka, Nereden, Nereye, SeferSaati, SeferTarihi, Hepsi) values (@Otürü,@Plaka, @Nereden, @Nereye, @SeferSaati, @SeferTarihi, @Hepsi)";
                    cmd.Parameters.AddWithValue("@Otürü", OTürü.Text);
                    cmd.Parameters.AddWithValue("@Plaka", SeferPlaka.Text);
                    cmd.Parameters.AddWithValue("@Nereden", SeferNereden.Text);
                    cmd.Parameters.AddWithValue("@Nereye", SeferNereye.Text);
                    cmd.Parameters.AddWithValue("@SeferSaati", SeferSaati.Text);
                    cmd.Parameters.AddWithValue("@SeferTarihi", SeferTarihi.Text);
                    cmd.Parameters.AddWithValue("@Hepsi",SeferNereden.Text + " - " + SeferNereye.Text + " - " + SeferTarihi.Text + " - " + SeferSaati.Text + " - " + SeferPlaka.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    
                    data.Close();
                    guna2TextBox1.Text = SeferNereden.Text + " - " + SeferNereye.Text + " - " + SeferTarihi.Text + " - " + SeferSaati.Text + " - " + SeferPlaka.Text;
                    
                   
                    guna2PictureBox4.Enabled = true;
                    label5.Visible = true;
                    
                }

                else
                {

                    DialogResult EvetHayir = new DialogResult();
                    EvetHayir = MessageBox.Show("Seçtiğiniz otobüs için zaten bir sefer tanımlıdır. Seferi Düzenlemek İster Misiniz?", "Araç Zaten Seferde", MessageBoxButtons.YesNo);

                    if (EvetHayir == DialogResult.Yes)
                    {
                       OtobüsOtomasyonu Ac = new OtobüsOtomasyonu();
                       Ac.ShowDialog();
                   }
                }
            }
            else
            {
                MessageBox.Show("Bilgileri Eksiksiz Doldurunuz!", "Hata");
            }
        }
        
        private void seferislemleri_Load(object sender, EventArgs e)
        {

            Otobusler();
            SeferTarihi.MinDate = DateTime.Now;
            SeferTarihi.Format = DateTimePickerFormat.Custom;
            SeferTarihi.CustomFormat = "d/MM/yyyy";




        }

       
        private void OTürü_TextChanged(object sender, EventArgs e)
        {
            if (OTürü.Text == "VIP")
            {
                guna2PictureBox1.Visible = true;
                guna2PictureBox3.Visible = false;
                guna2PictureBox2.Visible = false;
            }
            if (OTürü.Text == "Business")
            {
                guna2PictureBox1.Visible = false;
                guna2PictureBox3.Visible = false;
                guna2PictureBox2.Visible = true; 
            }
            if (OTürü.Text == "Economy")
            {
                guna2PictureBox1.Visible = false;
                guna2PictureBox2.Visible = false;
                guna2PictureBox3.Visible = true;
            }
        }

        private void SeferSaati_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SeferTarihi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SeferPlaka_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            data.Open();
            SqlCommand komut = new SqlCommand("select * from Otobus where OPlaka like'" + SeferPlaka.Text + "'", data);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                OTürü.Text = read["Otürü"].ToString();

            }
            data.Close();
        }

        private void SeferTarihi_ValueChanged_1(object sender, EventArgs e)
        {


        }
    }
}
