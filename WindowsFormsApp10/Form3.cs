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
    public partial class kayit_formu : Form
    {
        public kayit_formu()
        {
            InitializeComponent();
        }


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





        private void pictureBox1_Click(object sender, EventArgs e)
        {
            giris_formu x = new giris_formu();
            x.Show();
            this.Hide();
        }
        private bool mouseDown;
        private Point lastLocation;

        private void kayit_formu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void kayit_formu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void kayit_formu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int flag_age = 0;
            int flag_city = 0;
            try
            {
                Convert.ToInt32(yas.Text);
                flag_age = 1;
            }
            catch
            {
                flag_age = 0;
            }
            try
            {
                Convert.ToInt32(sehir.Text);
                flag_city = 1;
            }
            catch
            {
                flag_city = 0;
            }
            if (flag_age == 0)
            {
                MessageBox.Show("Yaş, rakamlardan oluşmalıdır.");
            }
            else if (flag_city == 1)
            {
                MessageBox.Show("Şehir isminde rakam bulunamaz.");
            }
            else if ((String.IsNullOrEmpty(kull_adi.Text)) && (String.IsNullOrEmpty(sifre.Text)))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.");
            }
            else
            {
             
         

            if (mysql.State == ConnectionState.Closed)
            {
                 mysql.Open();
            }
       

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("select * from bx_users where kull_adi like '" + kull_adi.Text + "'", mysql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>=1)
            {
                MessageBox.Show("Üye zaten var");
            }
            else
            {

                sql("insert into bx_users (kull_adi,sifre,Location,Age) values ('"+kull_adi.Text + "','" + sifre.Text + "','" + sehir.Text + "','" + yas.Text+"'" +")");
                MessageBox.Show("Kayıt Tamamlandı");

                if (mysql.State == ConnectionState.Closed)
                {
                    mysql.Open();
                }

                MySqlDataReader dr;
                MySqlCommand kmt = new MySqlCommand("select * from bx_users where kull_adi like '" + kull_adi.Text + "' AND sifre='" + sifre.Text + "'", mysql);
                dr = kmt.ExecuteReader();
                string age = "Age";
                string location = "Location";
                string kullanici_adi = "kull_adi";
                string User_ID = "User_ID";
                while (dr.Read())
                {
                    giris_formu.glob_kull_adi = dr[kullanici_adi].ToString();
                    giris_formu.glob_location = dr[location].ToString();
                    giris_formu.glob_uye_id = dr[User_ID].ToString();
                    giris_formu.glob_yas = dr[age].ToString();
                }



                this.Hide();
                oylama_formu x = new oylama_formu();
                x.Show();
            }
            
           



            mysql.Close();

            }

        }

        private void kayit_formu_Load(object sender, EventArgs e)
        {

        }
    }
}
