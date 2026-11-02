using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace WinFormsApp15
{
    public partial class Form1 : Form
    {
        PictureBox[] kutular;
        Image sualSekli;
        Image pisikSekli;
        Image bombaSekli;
        SoundPlayer ses;

        Random rnd = new Random();
        int bombaYeri;
        int xal;
        bool oyunBitib;

        public Form1()
        {
            InitializeComponent();
        }

    
        private string FaylTap(params string[] adlar)
        {
            var qovluqlar = new System.Collections.Generic.List<string>();

            
            DirectoryInfo d = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            while (d != null)
            {
                qovluqlar.Add(d.FullName);
                d = d.Parent;
            }

           
            string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            qovluqlar.Add(Path.Combine(user, "Downloads"));
            qovluqlar.Add(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            qovluqlar.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

            foreach (string q in qovluqlar)
            {
                foreach (string ad in adlar)
                {
                    string yol = Path.Combine(q, ad);
                    if (File.Exists(yol))
                        return yol;
                }
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kutular = new PictureBox[]
            {
                pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5, pictureBox6
            };

            string pisikYol = FaylTap("cat.png", "pişik.png");
            string bombaYol = FaylTap("bomba.png");
            string sesYol = FaylTap("explosion.wav");

            string yoxdur = "";
            if (pisikYol == null) yoxdur += "\n- cat.png (və ya pişik.png)";
            if (bombaYol == null) yoxdur += "\n- bomba.png";
            if (sesYol == null) yoxdur += "\n- explosion.wav";

            if (yoxdur != "")
            {
                MessageBox.Show(
                    "Bu fayllar tapılmadı:" + yoxdur +
                    "\n\nFaylları Downloads qovluğuna və ya Desktop-a at, sonra proqramı yenidən işə sal.",
                    "Fayl tapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return;
            }

            pisikSekli = Image.FromFile(pisikYol);
            bombaSekli = Image.FromFile(bombaYol);
            ses = new SoundPlayer(sesYol);
            sualSekli = SualIsaresiYarat();

            YeniOyun();
        }

      
        private Image SualIsaresiYarat()
        {
            Bitmap bmp = new Bitmap(160, 160);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Font f = new Font("Arial Black", 80, FontStyle.Bold, GraphicsUnit.Pixel))
            using (StringFormat sf = new StringFormat())
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString("?", f, Brushes.Black, new RectangleF(0, 0, 160, 160), sf);
            }
            return bmp;
        }

        private void YeniOyun()
        {
            xal = 0;
            label2.Text = "0";
            oyunBitib = false;

            // bomba yeri random seçilir (0-5)
            bombaYeri = rnd.Next(0, 6);

            for (int i = 0; i < kutular.Length; i++)
            {
                kutular[i].Image = sualSekli;
                kutular[i].Enabled = true;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (oyunBitib) return;

            PictureBox kutu = (PictureBox)sender;
            int index = Array.IndexOf(kutular, kutu);

            // artıq açılıb
            if (kutu.Image != sualSekli) return;

            if (index == bombaYeri)
            {
                // bomba tapıldı
                kutu.Image = bombaSekli;
                oyunBitib = true;
                ses.Play();

                // qalan xanaları göstər
                for (int i = 0; i < kutular.Length; i++)
                {
                    if (i != bombaYeri)
                        kutular[i].Image = pisikSekli;
                }

                MessageBox.Show("Oyun bitdi", "Bomba!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // pişik tapıldı
                kutu.Image = pisikSekli;
                xal++;
                label2.Text = xal.ToString();

                if (xal == 5)
                {
                    oyunBitib = true;
                    MessageBox.Show("Oyunu qazandınız, Yeni oyun üçün ok düyməsinə basın",
                                    "Təbriklər!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    YeniOyun();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeniOyun();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}