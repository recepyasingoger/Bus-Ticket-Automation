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
    public partial class biletiptal : Form
    {
        Baglanti bgl = new Baglanti();
        
        DataSet dset = new DataSet();
        public biletiptal()
        {
            InitializeComponent();
        }

        public void doldur()
        {
           
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            dset.Clear();

            SqlDataAdapter adtr2 = new SqlDataAdapter("select * From  Satıs ORDER BY id DESC", baglanti);

            adtr2.Fill(dset, "kullanici");

            Biletler.DataSource = dset.Tables["kullanici"];

            adtr2.Dispose();
            Biletler.RowHeadersVisible = false; 
            
            Biletler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Biletler.Columns[1].Visible = false; //KOLON GİZLEME
            Biletler.Columns[2].Visible = false; //KOLON GİZLEME
            baglanti.Close();
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Hide();
        }

       

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void İptal_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();

                SqlCommand komut = new SqlCommand("delete from Satıs where id='" + Biletler.CurrentRow.Cells["id"].Value.ToString() + "'", baglanti);
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

        private void biletiptal_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void Biletler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
