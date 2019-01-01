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
    public partial class oylama_formu : Form
    {
        bool secildi = false;
        int puan = 0;
        int oylanan = 0;
        private bool mouseDown;
        private Point lastLocation;

        public oylama_formu()
        {
            InitializeComponent();
        }
        MySqlConnection mysql = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");


        private void duzenle()
        {
            if (puan == 0)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 1)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 2)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";

            }

            if (puan == 3)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 4)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 5)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 6)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 7)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 8)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 9)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }

            if (puan == 10)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan<1)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else if (secildi == true && puan < 1)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            secildi = true;
            puan = 1;
            duzenle();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 1)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi==true && puan==2)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 2;
            duzenle();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan < 2)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 1;
            duzenle();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 3;
            duzenle();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan < 3)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 3)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 4;
            duzenle();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 4)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan < 4)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 5;
            duzenle();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan < 5)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 5)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
         
        }

        private void oylama_formu_Load(object sender, EventArgs e)
        {
            oylama_formu.CheckForIllegalCrossThreadCalls = false;
            kitaplar_bw.RunWorkerAsync();
       }

        private void oylama_formu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void oylama_formu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void oylama_formu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 6;
            duzenle();
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan < 6)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 6)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 7;
            duzenle();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 8;
            duzenle();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 9;
            duzenle();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            secildi = true;
            puan = 10;
            duzenle();
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan < 7)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan <7)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan < 8)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox11_MouseHover(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }

            if (secildi == true && puan < 8)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 9)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 9)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 10)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            if (secildi == false)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-gri.png";
            }
            else if (secildi == true && puan == 10)
            {
                pictureBox1.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox3.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox4.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox5.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox6.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox7.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox8.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox9.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox10.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
                pictureBox11.ImageLocation = Application.StartupPath + "/yildiz-sari.png";
            }
            else
            {
                duzenle();
            }
        }

        private void kitaplar_bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }

            using (MySqlDataAdapter adapter = new MySqlDataAdapter("select * from bx_books", mysql))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

            dataGridView1.Columns["Year_Of_Publication"].Visible = false;
            dataGridView1.Columns["Publisher"].Visible = false;
            dataGridView1.Columns["Image_URL_S"].Visible = false;
            dataGridView1.Columns["Image_URL_M"].Visible = false;
            dataGridView1.Columns["Image_URL_L"].Visible = false;
            dataGridView1.Columns["eklenme_tarihi"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            kitaplar_loading.Visible = false;
            mysql.Close();
            kitaplar_bw.CancelAsync();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1){
                MessageBox.Show("Oylamak İçin 1 Kitap Seçmelisiniz!");
            }
            else
            {

                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string secilen_isbn = Convert.ToString(selectedRow.Cells["ISBN"].Value);

                if (mysql.State == ConnectionState.Closed)
                {
                    mysql.Open();
                }
                try
                {
                    MySqlCommand kmt = new MySqlCommand("insert into bx_book_ratings (User_ID,ISBN,Book_Rating) values ('" + giris_formu.glob_uye_id + "','" + secilen_isbn + "','" + puan + "')", mysql);
                    kmt.ExecuteNonQuery();
                    puan = 0;
                    oylanan++;
                    duzenle();
                    mysql.Close();
                    if (oylanan >= 10)
                    {
                        kitap_formu x = new kitap_formu();
                        x.Show();
                        this.Hide();
                    }
                    else
                    {
                        label1.Text = "Kayıt Olmak İçin " + (10-oylanan) +  " Kitabı Oylayın";
                    }
                }
                catch
                {
                    mysql.Close();
                }

            }
        }
    }
}
