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
    public partial class kullanıcıislemleri : Form
    {
        Baglanti bgl = new Baglanti();
        
        DataSet dset = new DataSet();
        public kullanıcıislemleri()
        {
            InitializeComponent();
           
        }

        public void doldur()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            dset.Clear();

            SqlDataAdapter adtr2 = new SqlDataAdapter("select * From  yönetimpanel ORDER BY id DESC", baglanti);

            adtr2.Fill(dset, "kullanici");

            kullanıcıdata.DataSource = dset.Tables["kullanici"];

            adtr2.Dispose();

           
           
            kullanıcıdata.MultiSelect = false;
            kullanıcıdata.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            kullanıcıdata.Columns[0].HeaderText = "Kullanıcı No";
            kullanıcıdata.Columns[1].HeaderText = "Kullanıcı Adı";
            kullanıcıdata.Columns[2].HeaderText = "Kullanıcı Şifre";


            baglanti.Close();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();

            SqlCommand ekle = new SqlCommand("insert into yönetimpanel(kullaniciadi,sifre) values('" + katext1.Text + "','" + katext2.Text + "')", baglanti);
            ekle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Ekleme İşlemi Başarılı");
            doldur();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("delete from yönetimpanel where id='" + kullanıcıdata.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşleme Başarıyla Tamamlandı");
                baglanti.Close();
                doldur();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message); ;
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();

            SqlCommand guncelle = new SqlCommand("UPDATE yönetimpanel set kullaniciadi='" + katext1.Text + "',sifre='" + katext2.Text + "' where id ='" + kullanıcıdata.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
            guncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            doldur();
        }

        private void kullanıcıdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void kullanıcıislemleri_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void kullanıcıdata_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void kullanıcıdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            katext1.Text = kullanıcıdata.CurrentRow.Cells["kullaniciadi"].Value.ToString();
            katext2.Text = kullanıcıdata.CurrentRow.Cells["sifre"].Value.ToString();
        }
    }
}
