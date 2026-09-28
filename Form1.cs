using System.Runtime.ConstrainedExecution;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int count = 0;






        public Form1()
        {
            InitializeComponent();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            count += 1;

            biletler.Items.Add(count.ToString() + ") " + comboBox1.Text + " " + comboBox2.Text + " " + maskedTextBox1.Text + " " + maskedTextBox2.Text + " " + maskedTextBox3.Text + " " + textBox2.Text + " " + textBox3.Text);

            comboBox1.Text = "";
            comboBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox6.Text = "";
            maskedTextBox5.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show(
    "Çıxmaq istəyirsiniz?",
    "Bildiriş",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);

            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (biletler.Items.Count > 0)
            {
                biletler.Items.RemoveAt(0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = comboBox1.Text;
            string b = comboBox2.Text;

            comboBox1.Text = b;
            comboBox2.Text = a;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
       
    
   
