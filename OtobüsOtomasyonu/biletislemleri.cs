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
    public partial class biletislemleri : Form
    {
       
        
        

        
        public biletislemleri()
        {
            InitializeComponent();

        }
        Baglanti bgl = new Baglanti();
        
        SqlDataAdapter dataadapter;
        DataTable tbl = new DataTable();
        
        

        public static string tckimlik = "";
        public static string Plaka = "";
        public static string ad = "";
        public static string soyad = "";
        public static string dogumtarihi = "";
        public static string telefon = "";
        public static string cinsiyet = "";
        public static string Nereden = "";
        public static string Nereye = "";
        public static string Sefersaati = "";
        public static string SeferTarihi = "";
        public static string Otürü = "";
        public static string Fiyat = "";
        public static string Seferid = "";
        public static string biletnum = "";
        public static string arac_fiyat = "";



       

        void GuncelTablo()
        {

            SqlConnection data = new SqlConnection(bgl.Adres);
            dataadapter = new SqlDataAdapter("SELECT *FROM SeferTanım", data);
            dataadapter.Fill(tbl);
            TanımlıSeferler.DataSource = tbl;
            TanımlıSeferler.Columns[1].Visible = false; //KOLON GİZLEME
            TanımlıSeferler.Columns[0].HeaderText = "Sefer No";
            TanımlıSeferler.Columns["Otürü"].HeaderText = "Otobüs Türü";
            TanımlıSeferler.Columns[6].HeaderText = "Sefer Tarihi";
            TanımlıSeferler.Columns[7].HeaderText = "Sefer Saati";

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            biletiptal bi = new biletiptal();
            bi.BringToFront();
            bi.ShowDialog();
        }
        

       
        
        private void KoltukButton_Click(object sender, EventArgs e)
        {
            tckimlik = BiletTC.Text;
            Sefersaati = BiletSaat.Text;
            ad = BiletAd.Text;
            soyad = BiletSoyad.Text;
            dogumtarihi = BiletDT.Text;
            cinsiyet = BiletCinsiyet.Text;
            telefon = BiletTel.Text;
            Nereden = BiletNereden.Text;
            Nereye = BiletNereye.Text;
            SeferTarihi = BiletTarih.Text;
            Otürü = BiletAraçTürü.Text;
            
            if (tckimlik != "")
            {
                if (tckimlik.Length == 11)
                {
                    char[] rakamlar = tckimlik.ToCharArray();
                    int kural1 = 0, hane11 = rakamlar[10], hane10 = rakamlar[9];
                    //kural1: ilk 10 rakamın toplamının birler basamağı, 11. rakamı vermektedir.
                    for (int i = 0; i < 10; i++)
                    {
                        kural1 += Convert.ToInt32(rakamlar[i].ToString());
                    }
                    char[] birlerbasamagikural1 = kural1.ToString().ToCharArray();

                    int kural2tek = 0, kural2cift = 0;
                    //kural2:  1, 3, 5, 7 ve 9. rakamın toplamının 7 katı ile 2, 4, 6 ve 8. rakamın toplamının 9 katının toplamının birler basamağı 10. rakamı vermektedir.
                    for (int i = 0; i < 10; i += 2)
                    {
                        kural2tek += Convert.ToInt32(rakamlar[i].ToString());
                    }
                    for (int i = 1; i < 9; i += 2)
                    {
                        kural2cift += Convert.ToInt32(rakamlar[i].ToString());
                    }
                    char[] birlerbasamagikural2 = ((7 * kural2tek) + (9 * kural2cift)).ToString().ToCharArray();

                    int kural3 = 0;
                    //1, 3, 5, 7 ve 9. rakamın toplamının 8 katının birler basamağı 11. rakamı vermektedir.
                    for (int i = 0; i < 10; i += 2)
                    {
                        kural3 += Convert.ToInt32(rakamlar[i].ToString());
                    }
                    char[] birlerbasamagikural3 = (8 * kural3).ToString().ToCharArray();

                    if ((birlerbasamagikural1[birlerbasamagikural1.Length - 1] == hane11) && (birlerbasamagikural2[birlerbasamagikural2.Length - 1] == hane10) && (birlerbasamagikural3[birlerbasamagikural3.Length - 1] == hane11 ) && tckimlik!="00000000000" )
                    {

                        koltuksecimekranı kse = new koltuksecimekranı();
                        kse.BringToFront();
                        kse.ShowDialog();
                    }
                    
                    else
                    {

                        MessageBox.Show("TC Kimlik Numarası Geçerli Değildir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    BiletTC.Clear();
                    BiletTC.Focus();
                }
                else
                {
                    MessageBox.Show(" TC Kimlik Numaranızı Eksik Girdiniz Lütfen Kontrol Ediniz!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {

                MessageBox.Show(" TC Kimlik Numarası Giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            SqlConnection data = new SqlConnection(bgl.Adres);
            data.Open();
            SqlCommand komut = new SqlCommand("select * from SeferTanım where SeferSaati = '" + Sefersaati + "'and SeferTarihi = '" + SeferTarihi + "'and Nereden = '" + Nereden + "'and Nereye = '" + Nereye + "'and Otürü='" + Otürü + "'", data);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Seferid = oku[1].ToString();
            
            }
            else
            {

                MessageBox.Show("Böyle bir sefer bulunmamaktadır  !");

            }

            data.Close();


        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void Plakaa_TextChanged(object sender, EventArgs e)
        {
            
           

        }
        private void biletislemleri_Load(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            GuncelTablo();

            //data.Open();
            //SqlCommand komutt = new SqlCommand("Select * from Otobus", data);
            //SqlDataReader oku2 = komutt.ExecuteReader();
            //while (oku2.Read())
            //{

            //    BiletAraçTürü.Items.Add(oku2["Otürü"].ToString());
            //}
            //data.Close();
           
        }
       
        private void BiletAraçTürü_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void TanımlıSeferler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BiletAd_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BiletSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void BiletAd_TextChanged_1(object sender, EventArgs e)
        {
            if (BiletAd.Text == "")
            {

                BiletSoyad.Clear();
                BiletTC.Clear();
                BiletTel.Clear();
                BiletDT.Clear();

                BiletCinsiyet.SelectedIndex = -1;


            }
        }

        private void BiletTC_TextChanged(object sender, EventArgs e)
        {

        }

        private void Plakaa_TextChanged_1(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            data.Open();
            SqlCommand komut5 = new SqlCommand("select * from SeferTanım where Plaka like'%" + Plakaa.Text + "%'", data);
            SqlDataReader read = komut5.ExecuteReader();
            while (read.Read())
            {
                BiletNereden.Text = read["Nereden"].ToString();
                BiletNereye.Text = read["Nereye"].ToString();
                BiletSaat.Text = read["SeferSaati"].ToString();
                BiletTarih.Text = read["SeferTarihi"].ToString();
                BiletAraçTürü.Text = read["Otürü"].ToString();

            }
            data.Close();
            data.Open();
            SqlCommand komutt = new SqlCommand("Select * from Otobus where Otürü='" + BiletAraçTürü.Text + "'", data);
            SqlDataReader oku3 = komutt.ExecuteReader();
            while (oku3.Read())
            {



                arac_fiyat = oku3["Fiyat"].ToString();




            }
            data.Close();

            if (Plakaa.Text == "")
            {

                BiletNereden.Clear();
                BiletNereye.Clear();
                BiletTarih.Clear();
                BiletSaat.Clear();

                BiletTarih.Clear();
                BiletAraçTürü.Clear();

            }
        }
    }
}


