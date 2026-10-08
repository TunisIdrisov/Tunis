
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

                                        
                                          




            
design hissesi



namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            groupBox1 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            button2 = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);

            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            // Form
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DarkRed;
            ClientSize = new System.Drawing.Size(1055, 513);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Random number";

            // groupBox1
            groupBox1.Location = new System.Drawing.Point(20, 45);
            groupBox1.Size = new System.Drawing.Size(525, 400);
            groupBox1.Text = "Ədəd axtarışı";
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            groupBox1.TabStop = false;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);

            // label1
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(70, 65);
            label1.Text = "Axtarılan ədəd";
            label1.ForeColor = System.Drawing.Color.White;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F);

            // textBox1
            textBox1.Location = new System.Drawing.Point(68, 115);
            textBox1.Size = new System.Drawing.Size(375, 41);
            textBox1.Font = new System.Drawing.Font("Segoe UI", 15F);
            textBox1.Enabled = false;
            textBox1.TabIndex = 0;

            // button1
            button1.Location = new System.Drawing.Point(68, 220);
            button1.Size = new System.Drawing.Size(375, 63);
            button1.Text = "Yoxla";
            button1.Font = new System.Drawing.Font("Segoe UI", 14F);
            button1.Enabled = false;
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // richTextBox1
            richTextBox1.Location = new System.Drawing.Point(615, 48);
            richTextBox1.Size = new System.Drawing.Size(405, 300);
            richTextBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            richTextBox1.BackColor = System.Drawing.Color.White;
            richTextBox1.ReadOnly = true;
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";

            // button2
            button2.Location = new System.Drawing.Point(615, 370);
            button2.Size = new System.Drawing.Size(405, 63);
            button2.Text = "Yeni oyun";
            button2.Font = new System.Drawing.Font("Segoe UI", 14F);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = true;
            button2.Click += yenioyunbtn_Click;

            // errorProvider1
            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkStyle =
                System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

            // Controls
            Controls.Add(groupBox1);
            Controls.Add(richTextBox1);
            Controls.Add(button2);

            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }
    }
}
