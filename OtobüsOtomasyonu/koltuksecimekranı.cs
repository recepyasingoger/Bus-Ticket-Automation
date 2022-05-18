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
using System.Collections;
namespace OtobüsOtomasyonu
{
    public partial class koltuksecimekranı : Form
    {

        Baglanti bgl = new Baglanti();
        public koltuksecimekranı()
        {
            InitializeComponent();
        }
       
       
        
        public string tarih = biletislemleri.SeferTarihi;
        public string tarih_saat = biletislemleri.Sefersaati;
        string adısoyadi = biletislemleri.ad + " " + biletislemleri.soyad;
        string Otür = biletislemleri.Otürü;
        int tutar;
        
         int fiyat = int.Parse(biletislemleri.arac_fiyat.ToString());
        
        string ucret;
        ArrayList koltuklar = new ArrayList();
        ArrayList iptalKoltuk = new ArrayList();
        int Otobusid = 0;
        int Seferid = 0;

        void koltukYazdir()
        {
            string koltuk = "";
           for (int i = 0; i < koltuklar.Count; i++)
            {
               koltuk += koltuklar[i].ToString() + ",";
            }
            if (koltuklar.Count >= 1)
           {
               koltuk = koltuk.Remove(koltuk.Length - 1, 1);


            }
            txtKoltukNo.Clear();
            txtKoltukNo.Text = koltuk;
        }

       string araGetir(string sql)
       {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
           SqlCommand cmd = new SqlCommand(sql, baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            oku.Read();
            string deger = oku[1].ToString();
            baglanti.Close();
           return deger;
        }

        void KayıtAl()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
           
            SqlCommand cmd = new SqlCommand("select * from Satıs where Otobusid='" + Otobusid + "'and Seferid='" + Seferid + "'and SeferTarihi='" + tarih + "'and SeferSaati='" + tarih_saat + "'", baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                string koltuk_No = oku[5].ToString();
                this.Controls.Find("btn" + koltuk_No, true)[0].BackColor = Color.Red;
            }
            baglanti.Close();
        }

        void biletAyir()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("Insert into musteri (ad,soyad,tckimlik,telefon,dogumtarihi,cinsiyet ) values ('"  + biletislemleri.ad + "','" + biletislemleri.soyad + "','" + biletislemleri.tckimlik + "','" + biletislemleri.telefon + "','" + biletislemleri.dogumtarihi + "','" + biletislemleri.cinsiyet + "')", baglanti);
            cmd2.ExecuteNonQuery();

            for (int i = 0; i < koltuklar.Count; i++)
            {   

                
                SqlCommand cmd = new SqlCommand("Insert into Satıs (Otobusid,Seferid,SeferSaati,SeferTarihi,KoltukNo,Fiyat,SatısAdı,SatısSoyadı,tckimlik,telefon,dogumtarihi,cinsiyet ) values ('"+Otobusid + "','"+ Seferid+ "','"  + tarih_saat + "','" +tarih + "','" + Convert.ToInt32(koltuklar[i]).ToString() + "','" + Fiyatt.Text + "','" + biletislemleri.ad + "','" + biletislemleri.soyad + "','" + biletislemleri.tckimlik + "','" + biletislemleri.telefon + "','" + biletislemleri.dogumtarihi + "','" + biletislemleri.cinsiyet + "')", baglanti);
                cmd.ExecuteNonQuery();
               this.Controls.Find("btn" + koltuklar[i].ToString(), true)[0].BackColor = Color.Red;
            }

            baglanti.Close();
        }
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (txtKoltukNo.Text != "")
            {

                biletAyir();
                MessageBox.Show(biletislemleri.ad + " " + biletislemleri.soyad + " bilgili kişinin " + txtKoltukNo.Text + " no'lu koltukları ayrılmıştır");
                this.Hide();

            }
            else
            {
                MessageBox.Show("Koltuk numarasını seçmediniz.", "Dikkat");
            }
           
            
        }

        private void btnKoltuk_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Chartreuse) // yeşil
            {
                ((Button)sender).BackColor = Color.Orange;
                if (!koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Add(((Button)sender).Text);
                }
                tutar = tutar + fiyat;
                ucret = tutar.ToString();
                Fiyatt.Text = ucret;
                koltukYazdir();

            }
            else if (((Button)sender).BackColor == Color.Orange) // turuncu
            {

                ((Button)sender).BackColor = Color.Chartreuse;
                if (koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Remove(((Button)sender).Text);
                    tutar = tutar - fiyat;
                    ucret = tutar.ToString();
                    Fiyatt.Text = ucret;
                    koltukYazdir();
                }

            }
           
        }
        private void koltuksecimekranı_Load(object sender, EventArgs e)
        {
            
          
           

            KayıtAl();
            adısoyadi = biletislemleri.ad;

        }
        private void BiletAraçTürü_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txtKoltukIptal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBilet_iptal_Click(object sender, EventArgs e)
        {

        }
    }
}
