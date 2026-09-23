using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace comandTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0"; textBox2.Text = "0"; comboBox1.SelectedIndex = -1; label4.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(textBox1.Text);
                double num2 = Convert.ToDouble(textBox2.Text);
                if (comboBox1.SelectedItem == null)
                { label4.Text = "Error"; }
                string command = comboBox1.SelectedItem.ToString();
                double result = 0;


                switch (command)
                {
                    case "add":
                        result = num1 + num2;
                        break;
                    case "subtraction":
                        result = num1 - num2;
                        break;
                    case "multiplication":
                        result = num1 * num2;
                        break;
                    case "division":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                        {
                            label4.Text = "Error: Div by zero";
                            return;
                        }
                        break;
                }

                label4.Text = result.ToString();
            }
            catch (Exception ex)
            {
                label4.Text = "Error";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
