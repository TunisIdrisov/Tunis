
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int num;
        private int count;
        private readonly Random random = new Random();
        private bool gameStarted = false;

        public Form1()
        {
            InitializeComponent();

            // Proqram açılan zaman oyun başlamayıb
            textBox1.Enabled = false;
            button1.Enabled = false;

            richTextBox1.Text =
                "Oyuna başlamaq üçün\r\n" +
                "\"Yeni oyun\" düyməsinə basın.";
        }

        // Yeni oyun
        private void yenioyunbtn_Click(object sender, EventArgs e)
        {
            num = random.Next(0, 101);
            count = 0;
            gameStarted = true;

            textBox1.Clear();
            errorProvider1.Clear();

            textBox1.Enabled = true;
            button1.Enabled = true;

            richTextBox1.Text =
                "Yeni oyun başladı!\r\n" +
                "0-100 arasında bir ədəd tapın.\r\n" +
                "Cəhd sayı: 0";

            textBox1.Focus();
        }

        // Yoxla
        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (!gameStarted)
                return;

            // Xana boşdursa
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(
                    textBox1,
                    "Ədəd daxil edin!"
                );

                return;
            }

            int enteredNumber;

            // Yalnız tam ədəd qəbul edilir
            if (!int.TryParse(textBox1.Text, out enteredNumber))
            {
                errorProvider1.SetError(
                    textBox1,
                    "Düzgün tam ədəd daxil edin!"
                );

                return;
            }

            // Ədəd 0-100 arasında olmalıdır
            if (enteredNumber < 0 || enteredNumber > 100)
            {
                errorProvider1.SetError(
                    textBox1,
                    "0-100 arasında ədəd daxil edin!"
                );

                return;
            }

            // Hər düzgün daxil edilmiş təxmin bir cəhddir
            count++;

            // Ədəd tapılıb
            if (enteredNumber == num)
            {
                richTextBox1.Text =
                    "Oyunu qazandınız!\r\n" +
                    "Təbriklər, düzgün ədədi tapdınız.\r\n" +
                    "Cəhd sayı: " + count;

                gameStarted = false;
                button1.Enabled = false;
                textBox1.Enabled = false;

                return;
            }

            // Ədəd tapılmayıb
            richTextBox1.Text =
                "Daxil edilən ədəd yanlışdır!\r\n";

            if (enteredNumber < num)
            {
                richTextBox1.Text +=
                    "Təsadüfi ədəddən kiçikdir.\r\n";
            }
            else
            {
                richTextBox1.Text +=
                    "Təsadüfi ədəddən böyükdür.\r\n";
            }

            richTextBox1.Text +=
                "Cəhd sayı: " + count;

            textBox1.Clear();
            textBox1.Focus();
        }
    }
}