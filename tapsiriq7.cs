
using System;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        decimal totalIncome = 0;

        public Form1()
        {
            InitializeComponent();

            label5.Text = "0.00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Bos xanalar yoxlanilir
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Butun xanalari doldurun!");
                return;
            }

            // Sayi yoxlayiriq
            int count;

            if (!int.TryParse(textBox2.Text, out count))
            {
                MessageBox.Show("Sayi duzgun daxil edin!");
                return;
            }

            if (count <= 0)
            {
                MessageBox.Show("Say sifirdan boyuk olmalidir!");
                return;
            }

            // Qiymeti yoxlayiriq
            decimal price;

            string priceText = textBox3.Text.Trim()
                .Replace(',', '.');

            if (!decimal.TryParse(
                priceText,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out price))
            {
                MessageBox.Show("Qiymeti duzgun daxil edin!");
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Qiymet sifirdan boyuk olmalidir!");
                return;
            }

            // Yekun qiymet
            decimal result = count * price;

            // Cedvele melumat elave edilir
            dataGridView1.Rows.Add(
                textBox1.Text.Trim(),
                count.ToString(),
                price.ToString("F2"),
                result.ToString("F2"));

            // Umumi gelir hesablanir
            totalIncome += result;
            label5.Text = totalIncome.ToString("F2");

            // Xanalar temizlenir
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show(
                "Cixis edilsinmi?",
                "Cixis",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cavab == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}