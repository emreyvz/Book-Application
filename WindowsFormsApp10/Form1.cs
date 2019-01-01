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
    public partial class kitap_formu : Form
    {
        public kitap_formu()
        {
            InitializeComponent();
        }
        MySqlConnection mysql = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void renk_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kitap_formu.CheckForIllegalCrossThreadCalls = false;
            label13.Text = "";
            label17.Text = "";
            label18.Text = "";
            populer_loading.Visible = true;
            en_iyi_loading.Visible = true;
            yeni_loading.Visible = true;
            uye_id.Text = giris_formu.glob_uye_id.ToString();
            label15.Text = giris_formu.glob_kull_adi.ToString();
            label14.Text = giris_formu.glob_location.ToString();
            label16.Text = giris_formu.glob_yas.ToString();
            en_iyi_10.RunWorkerAsync();
            populer_kitap.RunWorkerAsync();
            yeni_kitap.RunWorkerAsync();
        }


        public string KullaniciAdi { get; set; }
        public string Age { get; set; }
        public string uyeid { get; set; }
        public string location { get; set; }

        private bool mouseDown;
        private Point lastLocation;

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        public string veri_al(String sql, string kolon)
        {
            if (mysql.State == ConnectionState.Open)
            {
            }
            else
            {
                mysql.Open();
            }

            var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, mysql);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reader.Close();
                return ((Convert.ToString(reader[kolon])));
                
            }
            mysql.Close();
            return "1";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            giris_formu x = new giris_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (giris_formu.glob_kull_adi == "admin")
            {
                admin_formu x = new admin_formu();
                x.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bu alana girmek yönetici olmanız gerekmektedir.!");
            }


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void en_iyi_10_DoWork(object sender, DoWorkEventArgs e)
        {
            label13.Text = "";
            MySqlConnection en_iyi_ozel = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");
            if (en_iyi_ozel.State == ConnectionState.Closed)
            {
                en_iyi_ozel.Open();
            }

            
            MySqlDataAdapter da1 = new MySqlDataAdapter();
            MySqlCommand kmt = new MySqlCommand("SELECT ISBN, SUM(Book_Rating), COUNT(*) FROM bx_book_ratings GROUP BY ISBN", mysql);
            kmt.CommandTimeout = 200;
            da1.SelectCommand = kmt;
            DataTable dt1 = new DataTable();
            
            da1.Fill(dt1);
            List<String> kitap_isbn = new List<string>();
            List<double> ortalama = new List<double>();

          

            
            DataTable veriler = new DataTable();
            veriler.Columns.Add("ISBN");
            veriler.Columns.Add("puan");
            veriler.Columns.Add("oy_sayisi");
            veriler.Columns["puan"].DataType = typeof(double);

            for (int i =0;i<= dt1.Rows.Count - 1; i++)
            {
                if (Convert.IsDBNull(dt1.Rows[i][0]) || Convert.IsDBNull(dt1.Rows[i][1]) || Convert.IsDBNull(dt1.Rows[i][2])) {
                    Console.WriteLine("Null değeri atlandı");
                    continue;
                }
                DataRow satir = veriler.NewRow();
                satir["ISBN"] = dt1.Rows[i][0].ToString();
                satir["puan"] = Convert.ToDouble(dt1.Rows[i][1]) / Convert.ToDouble(dt1.Rows[i][2]);
                satir["oy_sayisi"] = dt1.Rows[i][2].ToString();
                veriler.Rows.Add(satir);
            }

            
            DataView view = veriler.DefaultView;
            view.Sort = "puan DESC,oy_sayisi DESC";
            DataTable sortedDate = view.ToTable();




            List<string> dondur = new List<string>();
            String veri = "";
            for(int j = 0; j < 10; j++)
            {
                veri = veri + Environment.NewLine + sortedDate.Rows[j]["puan"];
                dondur.Add(sortedDate.Rows[j]["ISBN"].ToString());
            }


            

            for (int i = 0; i < dondur.Count(); i++)
            {

                if (dondur[i].ToString().Contains("'") || dondur[i].ToString().Contains("\""))
                {
                    Console.WriteLine("Hatalı Tipteki Veri Atlandı.");
                    continue;
                }
                MySqlDataReader dr1;
                MySqlCommand kmt1 = new MySqlCommand("SELECT * FROM bx_books where ISBN='" + dondur[i].ToString() + "'", en_iyi_ozel);
                dr1 = kmt1.ExecuteReader();
                while (dr1.Read())
                {
                    label13.Text = label13.Text + dr1["Book_Title"].ToString() + Environment.NewLine;
                }

                dr1.Close();
                en_iyi_loading.Visible = false;
            }
            en_iyi_ozel.Close();
            en_iyi_10.CancelAsync();
        }

        private void populer_kitap_DoWork(object sender, DoWorkEventArgs e)
        {
            MySqlConnection populer_ozel = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");
            label17.Text = "";
            if (populer_ozel.State == ConnectionState.Closed)
            {
                populer_ozel.Open();
            }
            MySqlDataReader dr;
            MySqlCommand kmt = new MySqlCommand("SELECT ISBN, COUNT(*) FROM bx_book_ratings GROUP BY ISBN ORDER BY COUNT(*) DESC LIMIT 11;", populer_ozel);
            kmt.CommandTimeout = 200;
            dr = kmt.ExecuteReader();
            List<string> dondur = new List<string>();
            while (dr.Read())
            {
                dondur.Add(dr["ISBN"].ToString());
            }
            dr.Close();
            for (int i = 0; i < dondur.Count(); i++)
            {

                MySqlDataReader dr1;
                MySqlCommand kmt1 = new MySqlCommand("SELECT * FROM bx_books where ISBN='" + dondur[i].ToString() + "'", populer_ozel);
                dr1 = kmt1.ExecuteReader();
                while (dr1.Read())
                {
                    label17.Text = label17.Text + dr1["Book_Title"].ToString() + Environment.NewLine;
                }

                dr1.Close();
                populer_loading.Visible = false;
            }
            populer_ozel.Close();
            populer_kitap.CancelAsync();
        }

        private void yeni_kitap_DoWork(object sender, DoWorkEventArgs e)
        {
            MySqlConnection yeni_kitap_ozel = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");
            label18.Text = "";
            if (yeni_kitap_ozel.State == ConnectionState.Closed)
            {
                yeni_kitap_ozel.Open();
            }
            MySqlDataReader dr;
            MySqlCommand kmt = new MySqlCommand("SELECT ISBN FROM bx_books ORDER BY eklenme_tarihi DESC LIMIT 10;", yeni_kitap_ozel);
            dr = kmt.ExecuteReader();
            List<string> dondur = new List<string>();
            while (dr.Read())
            {
                dondur.Add(dr["ISBN"].ToString());
            }
            dr.Close();
            for (int i = 0; i < dondur.Count(); i++)
            {

                MySqlDataReader dr1;
                MySqlCommand kmt1 = new MySqlCommand("SELECT * FROM bx_books where ISBN='" + dondur[i].ToString() + "'", yeni_kitap_ozel);
                dr1 = kmt1.ExecuteReader();
                while (dr1.Read())
                {
                    label18.Text = label18.Text + dr1["Book_Title"].ToString() + Environment.NewLine;
                }

                dr1.Close();
                yeni_loading.Visible = false;
            }
            yeni_kitap_ozel.Close();
            yeni_kitap.CancelAsync();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (giris_formu.glob_kull_adi == "admin")
            {
                admin_formu x = new admin_formu();
                x.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bu alana girmek yönetici olmanız gerekmektedir.!");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (giris_formu.glob_kull_adi == "admin")
            {
                admin_formu x = new admin_formu();
                x.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bu alana girmek yönetici olmanız gerekmektedir.!");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (giris_formu.glob_kull_adi == "admin")
            {
                admin_formu x = new admin_formu();
                x.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bu alana girmek yönetici olmanız gerekmektedir.!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            kitap_sec_formu x = new kitap_sec_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (en_iyi_10.IsBusy == false)
            {
                en_iyi_loading.Visible = true;
                en_iyi_10.RunWorkerAsync();
            }

            if (populer_kitap.IsBusy == false)
            {
                populer_loading.Visible = true;
                populer_kitap.RunWorkerAsync();
            }

            if (yeni_kitap.IsBusy == false)
            {
                yeni_loading.Visible = true;
                yeni_kitap.RunWorkerAsync();              
            }
        }

    }
}
