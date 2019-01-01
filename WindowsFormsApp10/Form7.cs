using iTextSharp.text.pdf.parser;
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
    public partial class okuma_formu : Form
    {
        public okuma_formu()
        {
            InitializeComponent();
        }
        private bool mouseDown;
        private Point lastLocation;
        int sayfa_numarasi = 70;
        int kitap_no = 0;

        private void okuma_formu_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int rastgele = rnd.Next(1, 5);
            kitap_no = rastgele;
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(Application.StartupPath + "/pdf/" + kitap_no + ".pdf");
            richTextBox1.Text = PdfTextExtractor.GetTextFromPage(reader,sayfa_numarasi);
            richTextBox1.SelectionStart =1;
            richTextBox1.ScrollToCaret();
        }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            kitap_sec_formu X = new kitap_sec_formu();
            X.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(Application.StartupPath + "/pdf/" + kitap_no + ".pdf");
            sayfa_numarasi--;
            richTextBox1.Text = PdfTextExtractor.GetTextFromPage(reader, sayfa_numarasi);
            richTextBox1.SelectionStart = 1;
            richTextBox1.ScrollToCaret();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(Application.StartupPath + "/pdf/" + kitap_no + ".pdf");
            sayfa_numarasi++;
                richTextBox1.Text = PdfTextExtractor.GetTextFromPage(reader, sayfa_numarasi);
            richTextBox1.SelectionStart = 1;
            richTextBox1.ScrollToCaret();
        }
    }
}
