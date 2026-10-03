using System;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Visible = false; // 1 manat
            pictureBox2.Visible = false; // 5 manat
            pictureBox3.Visible = false; // 10 manat
            pictureBox4.Visible = false; // 20 manat
            pictureBox5.Visible = false; // 50 manat
            pictureBox6.Visible = false; // 100 manat
            pictureBox7.Visible = false; // 200 manat
            pictureBox8.Visible = false; // 500 manat

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                errorProvider1.SetError(textBox1, "Məbləğ daxil edin");
                return;
            }

            errorProvider1.Clear();

            int mebleg = Convert.ToInt32(textBox1.Text);

            if (mebleg <= 0)
            {
                MessageBox.Show(
                    "Mənfi və ya sıfır məbləğ xırdalanmaz",
                    "Diqqət",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            int say500 = mebleg / 500;
            mebleg %= 500;

            int say200 = mebleg / 200;
            mebleg %= 200;

            int say100 = mebleg / 100;
            mebleg %= 100;

            int say50 = mebleg / 50;
            mebleg %= 50;

            int say20 = mebleg / 20;
            mebleg %= 20;

            int say10 = mebleg / 10;
            mebleg %= 10;

            int say5 = mebleg / 5;
            mebleg %= 5;

            int say1 = mebleg;

            if (say500 > 0)
            {
                pictureBox8.Visible = true;
                label9.Visible = true;
                label9.Text = say500.ToString();
            }

            if (say200 > 0)
            {
                pictureBox7.Visible = true;
                label8.Visible = true;
                label8.Text = say200.ToString();
            }

            if (say100 > 0)
            {
                pictureBox6.Visible = true;
                label7.Visible = true;
                label7.Text = say100.ToString();
            }

            if (say50 > 0)
            {
                pictureBox5.Visible = true;
                label6.Visible = true;
                label6.Text = say50.ToString();
            }

            if (say20 > 0)
            {
                pictureBox4.Visible = true;
                label5.Visible = true;
                label5.Text = say20.ToString();
            }

            if (say10 > 0)
            {
                pictureBox3.Visible = true;
                label4.Visible = true;
                label4.Text = say10.ToString();
            }

            if (say5 > 0)
            {
                pictureBox2.Visible = true;
                label3.Visible = true;
                label3.Text = say5.ToString();
            }

            if (say1 > 0)
            {
                pictureBox1.Visible = true;
                label2.Visible = true;
                label2.Text = say1.ToString();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                errorProvider1.Clear();
            }
        }
    }
}