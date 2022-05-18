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
    public partial class kayıtislemleri : Form
    {
        Baglanti bgl = new Baglanti();
        SqlDataAdapter dataadapter;
        DataTable tbl = new DataTable();
        public kayıtislemleri()
        {
            InitializeComponent();
        }
        void Musteriler()
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            tbl.Clear();
            dataadapter = new SqlDataAdapter("SELECT *FROM musteri ", data);
            dataadapter.Fill(tbl);
            Müsteriler.DataSource = tbl;
            Müsteriler.Columns[0].HeaderText = "Müşteri No";
            Müsteriler.Columns[1].HeaderText = "Ad";
            Müsteriler.Columns[2].HeaderText = "Soyad";
            Müsteriler.Columns[3].HeaderText = "TC Kimlik";
            Müsteriler.Columns[4].HeaderText = "Telefon";
            Müsteriler.Columns[5].HeaderText = "Doğum Tarihi";
            Müsteriler.Columns[6].HeaderText = "Cinsiyet";

        }
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            data.Open();
            SqlCommand Ara = new SqlCommand("SELECT * from musteri where tckimlik like '%" + txtTc.Text + "%'", data);
            SqlDataReader dr = Ara.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            Müsteriler.DataSource = dt;
            data.Close();
        }

        private void kayıtislemleri_Load(object sender, EventArgs e)
        {
            Musteriler();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            txtTc.Text = "";
            
            data.Open();
            SqlCommand Ara = new SqlCommand("SELECT * from musteri where tckimlik like '%" + txtTc.Text + "%'", data);
            SqlDataReader dr = Ara.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            Müsteriler.DataSource = dt;
            data.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            try
            {

                data.Open();
                SqlCommand sil = new SqlCommand("DELETE FROM musteri WHERE id='" + Müsteriler.CurrentRow.Cells[0].Value.ToString() + "'", data);
                sil.ExecuteNonQuery();
                data.Close();
                tbl.Clear();
                Musteriler();

            }

            catch
            {
                MessageBox.Show("Herhangi bir kayıt seçmediniz.", "Hata");
            }
        }

        private void Müsteriler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
