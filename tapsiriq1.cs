using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace sss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string u = Username.Text;
            string p = password.Text;
            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
            {
                MessageBox.Show("Xana boş olmaz!", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                if (Username.Text == "Tunis Idrisov" && password.Text == "tunis2007")
                {
                    MessageBox.Show("Sistemə daxil oldunuz!", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Username.Clear();
                    password.Clear();
                }
                else
                {
                    linkLabel1.Visible = true;
                    MessageBox.Show("İstifadəçi adı və ya şifrisi yanlışdır!", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = !checkBox1.Checked;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox2.Checked;
            textBox3.UseSystemPasswordChar = !checkBox2.Checked;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            string z = textBox2.Text;
            string k = textBox3.Text;
            if (textBox2.Text != textBox3.Text || string.IsNullOrEmpty(t) || string.IsNullOrEmpty(z) || string.IsNullOrEmpty(k))
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

                MessageBox.Show("Sistemdə qeydiyatdan keçdiniz", "Bildiriş", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
