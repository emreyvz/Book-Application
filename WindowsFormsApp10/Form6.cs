using MySql.Data.MySqlClient;
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

namespace WindowsFormsApp10
{
    public partial class kitap_sec_formu : Form
    {
        MySqlConnection mysql = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");
        int limit_alt = 0;


        public kitap_sec_formu()
        {
            InitializeComponent();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
            
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


        private void veri_cek()
        {
            try
            {
                mysql.Open();
                if (mysql.State != ConnectionState.Closed)
                {
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
                        MySqlCommand kmt = new MySqlCommand("select * from bx_books LIMIT " + limit_alt + "," + 10, mysql);
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
                    }
                    catch (Exception em)
                    {
                        mysql.Close();
                        MessageBox.Show(em.Message);
                    }


                }

                else
                {
                    MessageBox.Show("Maalesef Bağlantı Yapılamadı...!");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Hata! " + err.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBox15_Click(object sender, EventArgs e)
        {
            limit_alt += 10;
            veri_cek();
        }

        private void kitap_sec_formu_Load(object sender, EventArgs e)
        {
            veri_cek();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (limit_alt < 10)
            {
                MessageBox.Show("Daha Fazla Geri Gidilemiyor !");
            }
            else
            {
                limit_alt -= 10;
                veri_cek();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            okuma_formu x = new okuma_formu();
            x.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void pictureBox13_Click(object sender, EventArgs e)
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

        private void pictureBox12_Click(object sender, EventArgs e)
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

        private void pictureBox11_Click(object sender, EventArgs e)
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

        private void pictureBox10_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kitap_formu x = new kitap_formu();
            x.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            kitap_onerileri_formu x = new kitap_onerileri_formu();
            x.Show();
            this.Hide();
        }
    }
}
