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
    public partial class admin_formu : Form
    {
        public admin_formu()
        {
            InitializeComponent();
        }
        private bool mouseDown;
        private Point lastLocation;
        MySqlConnection veritabani = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            kitap_formu x = new kitap_formu();
            x.Show();
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

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            if (textBox9.Text == "")
            {
                MessageBox.Show("ISBN Boş Olamaz.");
            }
            else
            {

                if (veritabani.State == ConnectionState.Closed)
                {
                    veritabani.Open();
                }
                try
                {
                    MySqlCommand kmt = new MySqlCommand("DELETE FROM bx_users where User_ID='" + textBox9.Text + "'", veritabani);
                    kmt.ExecuteNonQuery();
                    veritabani.Close();
                    uyeler_loading.Visible = true;
                    dataGridView1.DataSource = null;
                    uye_bw.RunWorkerAsync();
                }
                catch
                {
                    veritabani.Close();
                }
            }
        }

        private void admin_formu_Load(object sender, EventArgs e)
        {
            admin_formu.CheckForIllegalCrossThreadCalls = false;
            uye_bw.RunWorkerAsync();
            kitap_bw.RunWorkerAsync();
        }

        private void uye_bw_DoWork(object sender, DoWorkEventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            MySqlConnection mysql = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("select * from bx_users", mysql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mysql.Close();
            uyeler_loading.Visible = false;
            uye_bw.CancelAsync();
        }

        private void kitap_bw_DoWork(object sender, DoWorkEventArgs e)
        {
            MySqlConnection mysql = new MySqlConnection("Server=localhost;Database=yazlab1;Uid=root;Pwd='';Encrypt=false;AllowUserVariables=True;UseCompression=True;SslMode=none");
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = new MySqlCommand("select * from bx_books", mysql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            mysql.Close();
            kitaplar_loading.Visible = false;
            kitap_bw.CancelAsync();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string al_user_id = Convert.ToString(selectedRow.Cells["User_ID"].Value);
                textBox9.Text = al_user_id;
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count>0)
            { 
            int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
            string al_isbn = Convert.ToString(selectedRow.Cells["ISBN"].Value);
            textBox6.Text = al_isbn;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                MessageBox.Show("ISBN Boş Olamaz.");
            }
            else {

            if (veritabani.State == ConnectionState.Closed)
            {
                veritabani.Open();
            }
            try
            {
                MySqlCommand kmt = new MySqlCommand("DELETE FROM bx_books where ISBN='" +textBox6.Text +"'", veritabani);
                kmt.ExecuteNonQuery();
                veritabani.Close();
                kitaplar_loading.Visible = true;
                dataGridView2.DataSource = null;
                kitap_bw.RunWorkerAsync();
            }
            catch(Exception hata)
            {
                    MessageBox.Show(hata.Message);
                veritabani.Close();
            }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            if ((String.IsNullOrEmpty(kitap_isbn.Text)) || (String.IsNullOrEmpty(textBox1.Text)) || (String.IsNullOrEmpty(textBox2.Text)) || (String.IsNullOrEmpty(textBox3.Text)) || (String.IsNullOrEmpty(textBox4.Text)) || (String.IsNullOrEmpty(textBox5.Text)) || (String.IsNullOrEmpty(textBox6.Text)) || (String.IsNullOrEmpty(textBox7.Text)) || (String.IsNullOrEmpty(textBox8.Text)))
            {
                MessageBox.Show("Eklenecek kitabın özelliklerinden herhangi biri boş olamaz.");
            }
            else { 
                if (veritabani.State == ConnectionState.Closed)
                {
                    veritabani.Open();
                }




                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = new MySqlCommand("select * from bx_books where ISBN like '" + kitap_isbn.Text + "'", veritabani);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Bu ISBN'ye sahip bir kitap zaten var");
                }
                else
                {
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    sql("insert into bx_books (ISBN,Book_Title,Book_Author,Year_Of_Publication,Publisher,Image_URL_S,Image_URL_M,Image_URL_L,eklenme_tarihi) values ('" + kitap_isbn.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + unixTimestamp + "'" + ")");
                    kitap_isbn.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    kitaplar_loading.Visible = true;
                    dataGridView2.DataSource = null;
                    kitap_bw.RunWorkerAsync();
                }



                veritabani.Close();

            }

        }


        public bool sql(String sql)
        {
            if (veritabani.State == ConnectionState.Closed)
            {
                 veritabani.Open();
            }  
            try
            {
                MySqlCommand kmt = new MySqlCommand(sql, veritabani);
                kmt.ExecuteNonQuery();
                veritabani.Close();
                return true;
            }
            catch (Exception e)
            {
                veritabani.Close();
                MessageBox.Show(e.Message);
                return false;
            }
        }

    }
}
