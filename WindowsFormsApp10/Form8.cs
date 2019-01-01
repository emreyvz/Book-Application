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
    public partial class kitap_onerileri_formu : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        MySqlConnection mysql = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none;");

        public kitap_onerileri_formu()
        {
            InitializeComponent();
        }

        public bool double_mi(double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }

        private void kitap_onerileri_formu_Load(object sender, EventArgs e)
        {
            if (mysql.State != ConnectionState.Open)
            {
                mysql.Open();
            }
            kitaplar_loading.Visible = true;
            yukleniyor_yazisi.Visible = true;
            panel5.Visible = false;
            panel1.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel12.Visible = false;
            panel11.Visible = false;
            panel10.Visible = false;
            panel9.Visible = false;
            panel8.Visible = false;
            kitap_onerileri_formu.CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.RunWorkerAsync();
           

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
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

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kitap_sec_formu x = new kitap_sec_formu();
            x.Show();
            this.Hide();
        }
        int say = 0;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            List<int> puanlar = new List<int>();
            List<String> benzeyen_kisiler = new List<string>();

            int user1 = Convert.ToInt32(giris_formu.glob_uye_id);
            String lokasyon = giris_formu.glob_location.ToString();
            int lok_Say = lokasyon.Split(',').Length-1;
            String sql = "";
            if (lok_Say == 0)
            {
                sql = "(Location LIKE '%" + lokasyon.ToLower() + "%')";
            }
            if (lok_Say == 1)
            {
                if (string.IsNullOrEmpty(lokasyon.Split(',')[0]) || string.IsNullOrEmpty(lokasyon.Split(',')[1]))
                {
                    lokasyon.Split(',')[0] = "bilinmiyor";
                    lokasyon.Split(',')[1] = "bilinmiyor";
                }
                sql = "(Location LIKE '%" + lokasyon.Split(',')[0].ToLower() + "%' OR Location LIKE '%" + lokasyon.Split(',')[1].ToLower() + "%')";
            }
            if (lok_Say == 2)
            {
                if (string.IsNullOrEmpty(lokasyon.Split(',')[0]) || string.IsNullOrEmpty(lokasyon.Split(',')[1]) || string.IsNullOrEmpty(lokasyon.Split(',')[2]))
                {
                    lokasyon.Split(',')[0] = "bilinmiyor";
                    lokasyon.Split(',')[1] = "bilinmiyor";
                    lokasyon.Split(',')[2] = "bilinmiyor";
                }
                sql = "(Location LIKE '%" + lokasyon.Split(',')[0].ToLower() + "%' OR Location LIKE '%" + lokasyon.Split(',')[1].ToLower() + "%' OR Location LIKE '%"+ lokasyon.Split(',')[2].ToLower() + "%')";
            }
            String[] lokasyonlar = new String[10];
            MySqlDataAdapter da1 = new MySqlDataAdapter();       
            if (string.IsNullOrEmpty(giris_formu.glob_yas))
            {
                da1.SelectCommand = new MySqlCommand("SELECT * FROM bx_users where " + sql + " AND User_ID!='" + user1 + "'", mysql);
            }
            else
            {
                da1.SelectCommand = new MySqlCommand("SELECT * FROM bx_users where Age='" + giris_formu.glob_yas + "' AND " + sql + " AND User_ID!='" + user1 + "'", mysql);
            }

            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
 
            for (int j = 0; j <= dt1.Rows.Count - 1; j++)
            {
                say++;
                int user2 = Convert.ToInt32(dt1.Rows[j]["User_ID"].ToString());
                int a_kull = 0;
                int b_kull = 0;
                double a_kitap_sayisi = 0;
                double b_kitap_sayisi = 0;
                double a_ort = 0;
                double b_ort = 0;
                MySqlDataReader dr1;
                MySqlCommand kmt1 = new MySqlCommand("SELECT * from bx_book_ratings where User_ID='" + user1 + "'", mysql);
                dr1 = kmt1.ExecuteReader();
                while (dr1.Read())
                {
                    a_kull += Convert.ToInt32(dr1["Book_Rating"].ToString());
                    a_kitap_sayisi++;
                }

                dr1.Close();


                MySqlDataReader dr2;
                MySqlCommand kmt2 = new MySqlCommand("SELECT * from bx_book_ratings where User_ID='" + user2 + "'", mysql);
                dr2 = kmt2.ExecuteReader();
                while (dr2.Read())
                {
                    b_kull += Convert.ToInt32(dr2["Book_Rating"].ToString());
                    b_kitap_sayisi++;
                }

                dr2.Close();

               
                
                a_ort = a_kull / a_kitap_sayisi;
                b_ort = b_kull / b_kitap_sayisi;



                if (a_kitap_sayisi < 7 || b_kitap_sayisi < 7)
                {
                    Console.WriteLine("(" + user2 + ") Atlandı");
                    continue;
                }



                // İki kullanıcının da ortak olarak beğendiği kitapların listesi 

                MySqlDataAdapter da3 = new MySqlDataAdapter();
                da3.SelectCommand = new MySqlCommand("SELECT * FROM bx_book_ratings AS o WHERE (User_ID='" + user1 + "' OR User_ID='" + user2 + "') AND EXISTS (SELECT * FROM bx_book_ratings AS b WHERE (User_ID='" + user1 + "' OR User_ID='" + user2 + "') AND (o.ISBN=b.ISBN))", mysql);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);

                DataTable temiz = new DataTable();
                da3.Fill(temiz);
                temiz.Rows.Clear();

                for (int i = dt3.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt3.Rows[i]["User_ID"].ToString() == Convert.ToString(user1))
                    {
                        string str_isbn = dt3.Rows[i]["ISBN"].ToString();
                        bool kontrol = dt3.Select().ToList().Exists(row => row["ISBN"].ToString().ToUpper() == str_isbn && row["User_ID"].ToString().ToUpper() == Convert.ToString(user2));
                        if (kontrol != false)
                        {
                            var drFail = temiz.NewRow();
                            drFail["User_ID"] = dt3.Rows[i]["User_ID"];
                            drFail["ISBN"] = dt3.Rows[i]["ISBN"];
                            drFail["Book_Rating"] = dt3.Rows[i]["Book_Rating"];

                            temiz.Rows.Add(drFail);
                        }
                    }

                    if (dt3.Rows[i]["User_ID"].ToString() == Convert.ToString(user2))
                    {
                        string str_isbn = dt3.Rows[i]["ISBN"].ToString();
                        bool kontrol = dt3.Select().ToList().Exists(row => row["ISBN"].ToString().ToUpper() == str_isbn && row["User_ID"].ToString().ToUpper() == Convert.ToString(user1));
                        if (kontrol != false)
                        {
                            var drFail = temiz.NewRow();
                            drFail["User_ID"] = dt3.Rows[i]["User_ID"];
                            drFail["ISBN"] = dt3.Rows[i]["ISBN"];
                            drFail["Book_Rating"] = dt3.Rows[i]["Book_Rating"];

                            temiz.Rows.Add(drFail);
                        }
                    }
                }


                if (temiz.Rows.Count < 1)
                {
                    Console.WriteLine("(" + user2 + ") Atlandı");
                    continue;
                }



                double toplam = 0;
                double bolen_x_kare = 0;
                double bolen_y_kare = 0;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = new MySqlCommand("SELECT * FROM bx_book_ratings AS o  WHERE User_ID='" + user1 + "' AND  EXISTS (SELECT * FROM bx_book_ratings AS b WHERE User_ID='" + user2 + "' AND o.ISBN=b.ISBN)", mysql);
                DataTable dt = new DataTable();
                da.Fill(dt);
               

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {



                    MySqlDataReader dr4;
                    MySqlCommand kmt4 = new MySqlCommand(" SELECT * FROM bx_book_ratings where ISBN='" + dt.Rows[i]["ISBN"].ToString() + "' AND User_ID='" + user2 + "' LIMIT 1", mysql);
                    dr4 = kmt4.ExecuteReader();
                    while (dr4.Read())
                    {
                        toplam += (Convert.ToDouble(dr4["Book_Rating"].ToString()) - b_ort) * (Convert.ToDouble(dt.Rows[i]["Book_Rating"].ToString()) - a_ort);
                        bolen_x_kare += (Convert.ToDouble(dt.Rows[i]["Book_Rating"].ToString()) - a_ort) * (Convert.ToDouble(dt.Rows[i]["Book_Rating"].ToString()) - a_ort);
                        bolen_y_kare += (Convert.ToDouble(dr4["Book_Rating"].ToString()) - b_ort) * (Convert.ToDouble(dr4["Book_Rating"].ToString()) - b_ort);
                        //  Console.WriteLine((Convert.ToDouble(dr4["Book_Rating"].ToString()) - b_ort) + "*" + (Convert.ToDouble(dt.Rows[i]["Book_Rating"].ToString()) - a_ort));
                    }

                    dr4.Close();



                }

                double benzerlik = toplam / (Math.Sqrt(bolen_x_kare) * Math.Sqrt(bolen_y_kare));
                //Console.WriteLine("Bolum1= " + toplam + Environment.NewLine + "Bolen_x_kare = " + bolen_x_kare + Environment.NewLine + "Bolen_y_kare=" + bolen_y_kare);
                if (double_mi(benzerlik))
                {
                    puanlar.Add(Convert.ToInt32(benzerlik));
                    benzeyen_kisiler.Add(Convert.ToString(user2));
                    Console.WriteLine("(" + user2 + ") Benzerlik:  " + benzerlik);
                }
                else
                {
                    Console.WriteLine("(" + user2 + ") Atlandı"); 
                }
               

                //MessageBox.Show("Bölüm: " + bolum +"    Çarpan1_kare:"+ carpan1_kare +"   Çarpan2_kare:"+carpan2_kare + "    Ort2:"+ b_ort);
                //MessageBox.Show(bolum + "/ (√" + carpan1_kare + "*" + carpan2_kare + " )");

            }
            int benzer_userID= 278863;  // İhtimal bulunamazsa adminin beğendiklerini önerir.

            if (puanlar.Count > 0)
            {

            double en_yuksek_deger = Convert.ToDouble(puanlar[0].ToString());
            int en_yuksek_index = 0;
            
            for (int k = 0; k <= puanlar.Count - 1; k++)
            {
               if (Convert.ToDouble(puanlar[k].ToString())>= Convert.ToDouble(en_yuksek_deger))
                {
                    en_yuksek_deger = Convert.ToDouble(puanlar[k].ToString());
                    en_yuksek_index = k;
                }
            }

                benzer_userID=  Convert.ToInt32(benzeyen_kisiler[en_yuksek_index]);
            }

            bool kitap1 = false;
            bool kitap2 = false;
            bool kitap3 = false;
            bool kitap4 = false;
            bool kitap5 = false;
            bool kitap6 = false;
            bool kitap7 = false;
            bool kitap8 = false;
            bool kitap9 = false;
            bool kitap10 = false;

            try
            {
                MySqlDataReader dr;
                MySqlCommand kmt = new MySqlCommand("SELECT * FROM bx_books AS o  WHERE EXISTS (select * from bx_book_ratings as b where User_ID='"+benzer_userID+"' AND o.ISBN=b.ISBN)", mysql);
                dr = kmt.ExecuteReader();
                string kolon = "Book_Title";
                string kolon1 = "Image_URL_S";
                while (dr.Read())
                {

                    if (kitap1 == false)
                    {
                        kitap1 = true;
                        label1.Text = dr[kolon].ToString();
                        pictureBox3.Load(dr[kolon1].ToString());
                        continue;
                    }

                    if (kitap2 == false)
                    {
                        kitap2 = true;
                        label2.Text = dr[kolon].ToString();
                        pictureBox4.Load(dr[kolon1].ToString());
                        continue;
                    }


                    if (kitap3 == false)
                    {
                        kitap3 = true;
                        label7.Text = dr[kolon].ToString();
                        pictureBox5.Load(dr[kolon1].ToString());
                        continue;
                    }


                    if (kitap4 == false)
                    {
                        kitap4 = true;
                        label10.Text = dr[kolon].ToString();
                        pictureBox7.Load(dr[kolon1].ToString());
                        continue;
                    }


                    if (kitap5 == false)
                    {
                        kitap5 = true;
                        label13.Text = dr[kolon].ToString();
                        pictureBox8.Load(dr[kolon1].ToString());
                        continue;
                    }


                    if (kitap6 == false)
                    {
                        kitap6 = true;
                        label28.Text = dr[kolon].ToString();
                        pictureBox13.Load(dr[kolon1].ToString());
                        continue;
                    }


                    if (kitap7 == false)
                    {
                        kitap7 = true;
                        label25.Text = dr[kolon].ToString();
                        pictureBox12.Load(dr[kolon1].ToString());
                        continue;
                    }


                    if (kitap8 == false)
                    {
                        kitap8 = true;
                        label22.Text = dr[kolon].ToString();
                        pictureBox11.Load(dr[kolon1].ToString());
                        continue;
                    }


                    if (kitap9 == false)
                    {
                        kitap9 = true;
                        label19.Text = dr[kolon].ToString();
                        pictureBox10.Load(dr[kolon1].ToString());
                        continue;
                    }


                    if (kitap10 == false)
                    {
                        kitap10 = true;
                        label16.Text = dr[kolon].ToString();
                        pictureBox9.Load(dr[kolon1].ToString());
                        continue;
                    }


                }
                mysql.Close();
                kitaplar_loading.Visible = false;
                yukleniyor_yazisi.Visible = false;
                panel5.Visible = true;
                panel1.Visible = true;
                panel4.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel12.Visible = true;
                panel11.Visible = true;
                panel10.Visible = true;
                panel9.Visible = true;
                panel8.Visible = true;
            }
            catch (Exception em)
            {
                mysql.Close();
                MessageBox.Show(em.Message);
            }









             mysql.Close();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }
    }
}
