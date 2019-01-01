using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class giris_formu : Form
    {
        public giris_formu()
        {
            InitializeComponent();
        }

        public static string glob_kull_adi = "";
        public static string glob_uye_id = "";
        public static string glob_yas = "";
        public static string glob_location = "";
        MySqlConnection mysql = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");



        public bool sql(String sql)
        {
            if (mysql.State == ConnectionState.Open)
            {
            }
            else
            {
                mysql.Open();
            }

            try
            {
                MySqlCommand kmt = new MySqlCommand(sql, mysql);
                kmt.ExecuteNonQuery();
                mysql.Close();
                return true;
            }
            catch (Exception e)
            {
                mysql.Close();
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void giris_formu_Load(object sender, EventArgs e)
        {

        }

        private bool mouseDown;
        private Point lastLocation;


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            kayit_formu x = new kayit_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (mysql.State == ConnectionState.Open)
            {
            }
            else
            {
                mysql.Open();
            }

            if (kull_adi.Text == "" || sifre.Text == "")
            {
                MessageBox.Show("Kullanıcı Ade veya Şifre Boş Olamaz !");
            }else{
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("select * from bx_users where kull_adi like '" + kull_adi.Text + "' AND sifre='" + sifre.Text + "'", mysql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MySqlDataReader dr;
                MySqlCommand kmt = new MySqlCommand("select * from bx_users where kull_adi like '" + kull_adi.Text + "' AND sifre='" + sifre.Text + "'", mysql);
                dr = kmt.ExecuteReader();
                string age = "Age";
                string location = "Location";
                string kullanici_adi = "kull_adi";
                string User_ID = "User_ID";
                while (dr.Read())
                {
                    glob_kull_adi= dr[kullanici_adi].ToString();
                    glob_location = dr[location].ToString();
                    glob_uye_id = dr[User_ID].ToString();
                    glob_yas = dr[age].ToString();
                }

                dr.Close();

                    int a_kitap_sayisi = 0;
                    MySqlDataReader dr1;
                    MySqlCommand kmt1 = new MySqlCommand("SELECT * from bx_book_ratings where User_ID='" + giris_formu.glob_uye_id.ToString() + "'", mysql);
                    dr1 = kmt1.ExecuteReader();
                    while (dr1.Read())
                    {
                        a_kitap_sayisi++;
                    }
                    dr1.Close();
                    mysql.Close();
                    if (a_kitap_sayisi < 7)
                    {
                        oylama_formu x = new oylama_formu();
                        x.Show();
                        this.Hide();
                    }
                    else
                    {
                        kitap_formu x = new kitap_formu();
                        x.Show();
                        this.Hide();
                    }

                   
                }
                else
                {
                    MessageBox.Show("Üye Bulunamadı !");
                }

            }

        }

        private void giris_formu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void giris_formu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void giris_formu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
