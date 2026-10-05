using System.Windows.Forms;

namespace WinFormsApp11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Boyu daxil edin!");
                return;
            }

            if (textBox2.Text == "")
            {
                errorProvider2.SetError(textBox2, "Ç?kini daxil edin!");
                return;
            }
            double boy;
            double ceki;

            if (!double.TryParse(textBox1.Text, out boy) ||
                !double.TryParse(textBox2.Text, out ceki))
            {
                MessageBox.Show("Boy v? ç?kini düzgün daxil edin!");
                return;
            }

            if (boy <= 0 || ceki <= 0)
            {
                MessageBox.Show("Boy v? ç?ki 0-dan böyük olmal?d?r!");
                return;
            }

            // Boyu santimetrd?n metr? çeviririk
            double boyMetr = boy / 100;

            // BK? düsturu
            double bki = ceki / (boyMetr * boyMetr);

            // ?vv?l bütün ??kill?ri gizl?dirik
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

            // N?tic?y? uy?un ??kil
            if (bki < 18.5)
            {
                pictureBox1.Visible = true;
                MessageBox.Show("BK?: " + bki.ToString("0.00") +
                                "\nN?tic?: ARIQ");
            }
            else if (bki >= 18.5 && bki < 25)
            {
                pictureBox4.Visible = true;
                MessageBox.Show("BK?: " + bki.ToString("0.00") +
                                "\nN?tic?: NORMAL");
            }
            else if (bki >= 25 && bki < 30)
            {
                pictureBox3.Visible = true;
                MessageBox.Show("BK?: " + bki.ToString("0.00") +
                                "\nN?tic?: ART?Q Ç?K?L?");
            }
            else
            {
                pictureBox2.Visible = true;
                MessageBox.Show("BK?: " + bki.ToString("0.00") +
                                "\nN?tic?: OBESITY");
            }
        }


    }
}

   


