namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = maskedTextBox6.Text.Trim();
            string nomre = "0";

            int sdf1, sdf2, ff, seminar, final;

            if (ad == "")
            {
                MessageBox.Show("Ad soyad daxil edin!");
                return;
            }

            if (!int.TryParse(maskedTextBox1.Text, out sdf1) ||
                !int.TryParse(maskedTextBox2.Text, out sdf2) ||
                !int.TryParse(maskedTextBox3.Text, out ff) ||
                !int.TryParse(maskedTextBox4.Text, out seminar) ||
                !int.TryParse(maskedTextBox5.Text, out final))
            {
                MessageBox.Show("Ballari duzgun daxil edin!");
                return;
            }

            if (sdf1 < 0 || sdf1 > 10 ||
                sdf2 < 0 || sdf2 > 10 ||
                ff < 0 || ff > 10 ||
                seminar < 0 || seminar > 10 ||
                final < 0 || final > 50)
            {
                MessageBox.Show("Bal limitlerini duzgun daxil edin!");
                return;
            }

            int netice = sdf1 + sdf2 + ff + seminar + final;

            string kateqoriya;

            if (netice >= 81)
                kateqoriya = "A";
            else if (netice >= 72)
                kateqoriya = "B";
            else if (netice >= 63)
                kateqoriya = "C";
            else if (netice >= 54)
                kateqoriya = "D";
            else if (netice >= 45)
                kateqoriya = "E";
            else
                kateqoriya = "F";
            dataGridView1.Rows.Add(ad, nomre, netice, kateqoriya);
            MessageBox.Show(
                "Telebe: " + ad +
                "\nNetice: " + netice +
                "\nKateqoriya: " + kateqoriya
            );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox5.Clear();
            maskedTextBox6.Clear();

            maskedTextBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show(
        "Proqramdan cixmaq isteyirsiniz?",
        "Cixis",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (cavab == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

