using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teyyare_taski
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SoundPlayer enis = new SoundPlayer("C:\\Users\\Tunis Idrisov\\Downloads\\inishazirliklari.wav");
        SoundPlayer tur = new SoundPlayer("C:\\Users\\Tunis Idrisov\\Downloads\\turbulans.wav");
        SoundPlayer kem = new SoundPlayer("C:\\Users\\Tunis Idrisov\\Downloads\\kemerler.wav");
        SoundPlayer tsk = new SoundPlayer("C:\\Users\\Tunis Idrisov\\Downloads\\tesekkurler.wav");
        SoundPlayer beep = new SoundPlayer("C:\\Users\\Tunis Idrisov\\Downloads\\beep.wav");
        SoundPlayer onof = new SoundPlayer("C:\\Users\\Tunis Idrisov\\Downloads\\isikacmakapamasesi.wav");

        bool Gas = false;

        private void button1_Click_1(object sender, EventArgs e)
        {
            enis.Play();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            tur.Play();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            kem.Play();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            tsk.Play();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            beep.Play();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Gas = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Gas == true && pictureBox1.Location.Y > 0)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 1);
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 1);
            }
            else
            {
                timer1.Stop();
                Gas = false;
                MessageBox.Show("Way end");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure game exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
                onof.Play();
            }
            else
            {
                pictureBox2.Visible = true;
                onof.Play();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}