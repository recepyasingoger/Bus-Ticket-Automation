using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace OtobüsOtomasyonu
{
    public partial class otobüsislemleri : Form
    {
        Baglanti bgl = new Baglanti();
        SqlCommand cmd = new SqlCommand();
        public otobüsislemleri()
        {
            InitializeComponent();
           
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            bool Check = true;
            SqlCommand cmd2 = new SqlCommand();
            SqlDataReader dr;


            data.Open();
            cmd2.Connection = data;
            cmd2.CommandText = "SELECT * FROM Otobus where OPlaka='" + OPlaka.Text + "'";
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



            if (OPlaka.Text != ""  )
            {
                if (Check == false)
                {
                    
                    data.Open();
                    cmd.Connection = data;
                    cmd.CommandText = "Insert Into Otobus(OPlaka, OTürü, Wifi, Ekran, Fiyat) values (@OPlaka, @OTürü, @Wifi, @Ekran, @Fiyat)";
                    cmd.Parameters.AddWithValue("@OPlaka", OPlaka.Text);
                    cmd.Parameters.AddWithValue("@OTürü", OTürü.Text);
                    cmd.Parameters.AddWithValue("@Wifi", OWifi.Text);
                    cmd.Parameters.AddWithValue("@Ekran", OEkran.Text);
                    cmd.Parameters.AddWithValue("@Fiyat", Fiyat.Text);
                    
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    MessageBox.Show("Tanımlama Başarılı!", "İşlem Gerçekleştirildi");
                    data.Close();
                }

                else
                {
                    MessageBox.Show("Bu plakaya sahip araç zaten filoda mevcut.", "Plaka Hatası");
                }

                Check = true;
            }
            else
            {
                MessageBox.Show("Bilgileri Eksiksiz Doldurunuz!", "Hata");
            }
        }

        

       

       
        int count = -1;
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {   
            if(count<3)
            {
                count++;
            }
            
            if (count == 0)
            {
                guna2PictureBox1.Visible = true;
                guna2PictureBox2.Visible = false;
                guna2PictureBox3.Visible = false;
                guna2RadioButton1.Visible = true;
                guna2RadioButton2.Visible = false;
                guna2RadioButton3.Visible = false;
            }
            else if (count == 1)
            {
                guna2PictureBox2.Visible = true;
                guna2PictureBox1.Visible = false;
                guna2PictureBox3.Visible = false;
                guna2RadioButton1.Visible = false;
                guna2RadioButton3.Visible = false;
                guna2RadioButton2.Visible = true;
            }
            else if (count == 2)
            {
                guna2PictureBox3.Visible = true;
                guna2PictureBox2.Visible = false;
                guna2PictureBox1.Visible = false;
                guna2RadioButton1.Visible = false;
                guna2RadioButton3.Visible = true;
                guna2RadioButton2.Visible = false;
            }
            if(count == 2)
            {
                guna2CircleButton1.Enabled = false;
                guna2CircleButton2.Enabled = true;
            }
            if (count == 1)
            {
                guna2CircleButton2.Enabled = true;
                guna2CircleButton1.Enabled = true;
            }
            if (count == 0)
            {
                guna2CircleButton2.Enabled = true;
                guna2CircleButton1.Enabled = true;
            }
        }
        
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (count >0)
            {
                count--;
            }
            
            if (count == 0)
            {
                guna2PictureBox1.Visible = true;
                guna2PictureBox2.Visible = false;
                guna2PictureBox3.Visible = false;
                guna2RadioButton1.Visible = true;
                guna2RadioButton2.Visible = false;
                guna2RadioButton3.Visible = false;
            }
            else if (count == 1)
            {
                guna2PictureBox2.Visible = true;
                guna2PictureBox1.Visible = false;
                guna2PictureBox3.Visible = false;
                guna2RadioButton1.Visible = false;
                guna2RadioButton3.Visible = false;
                guna2RadioButton2.Visible = true;
            }
            else if (count == 2)
            {
                guna2PictureBox3.Visible = true;
                guna2PictureBox2.Visible = false;
                guna2PictureBox1.Visible = false;
                guna2RadioButton1.Visible = false;
                guna2RadioButton3.Visible = true;
                guna2RadioButton2.Visible =false;
            }
            if (count == 0 )
            {
                guna2CircleButton2.Enabled = false;
                guna2CircleButton1.Enabled = true;

            }
            if(count==1)
            {
                guna2CircleButton2.Enabled = true;
                guna2CircleButton1.Enabled = true;
            }
            if (count == 2)
            {
                guna2CircleButton2.Enabled = true;
                guna2CircleButton1.Enabled = true;
            }
        }
        private void otobüsislemleri_Load(object sender, EventArgs e)
        {
            //if (guna2PictureBox2.Image == ımageList1.Images[0])
            //{
            //    guna2RadioButton1.Visible = false;
            //    guna2RadioButton2.Visible = false;
            //    guna2RadioButton3.Visible = false;
            //}
           
        }

        

       

        private void guna2ImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2ImageCheckBox1.Checked == true)
            {
                OWifi.Text="Var";
            }
            else if(guna2ImageCheckBox1.Checked ==false)
            {
                OWifi.Text = "Yok";
            }
        }

        private void guna2ImageCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ImageCheckBox2.Checked == true)
            {
                OEkran.Text = "Var";
            }
            else if (guna2ImageCheckBox2.Checked == false)
            {
                OEkran.Text = "Yok";
            }
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked == true)
            {
                
                OTürü.Text = "VIP";
            }
        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2RadioButton2.Checked == true)
            {
                OTürü.Text = "Business";
            }
        }

        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2RadioButton3.Checked == true)
            {
                OTürü.Text = "Economy";
            }
        }

       

        private void OWifi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void OTürü_TextChanged(object sender, EventArgs e)
        {
            SqlConnection data = new SqlConnection(bgl.Adres);
            data.Open();
            SqlCommand komut = new SqlCommand("select * from Otobus where Otürü like'" + OTürü.Text + "'", data);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Fiyat.Text = read["Fiyat"].ToString();

            }
            data.Close();
        }

        private void OPlaka_TextChanged(object sender, EventArgs e)
        {
            if (OPlaka.Text == "")
            {

                OTürü.Clear();
                OWifi.Clear();
                OEkran.Clear();
                Fiyat.Clear();

                


            }
        }
    }
    }

