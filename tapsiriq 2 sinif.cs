namespace WinFormsApp3
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "0";

            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.Click += Button_Click;
            }
        }
        private double firstNumber = 0;
        private string operation = "";

        private void Button_Click(object sender, EventArgs e)
        {
            
           
            Button btn = (Button)sender;
            string value = btn.Text;
         


            if (char.IsDigit(value[0]))
            {
                if (richTextBox1.Text == "0")
                    richTextBox1.Text = "";

                richTextBox1.Text += value;
            }

            else if (value == ".")
            {
                if (!richTextBox1.Text.Contains("."))
                    richTextBox1.Text += ".";
            }

            
            else if (value == "C")
            {
                richTextBox1.Text = "0";
                firstNumber = 0;
                operation = "";
            }

            
            else if (value == "+" || value == "-" || value == "x" || value == "/")
            {
                firstNumber = Convert.ToDouble(richTextBox1.Text);
                operation = value;
                richTextBox1.Text = "";
            }

            
            else if (value == "=")
            {
                double secondNumber = Convert.ToDouble(richTextBox1.Text);

                if (operation == "+")
                    richTextBox1.Text = (firstNumber + secondNumber).ToString();

                else if (operation == "-")
                    richTextBox1.Text = (firstNumber - secondNumber).ToString();

                else if (operation == "x")
                    richTextBox1.Text = (firstNumber * secondNumber).ToString();

                else if (operation == "/")
                {
                    if (secondNumber == 0)
                        richTextBox1.Text = "Error";
                    else
                        richTextBox1.Text = (firstNumber / secondNumber).ToString();
                }
            }

            
            else if (value == "Sqrt")
            {
                double number = Convert.ToDouble(richTextBox1.Text);
                richTextBox1.Text = Math.Sqrt(number).ToString();
            }

            
            else if (value == "%")
            {
                double number = Convert.ToDouble(richTextBox1.Text);
                richTextBox1.Text = (number / 100).ToString();
            }

            
            else if (value == "<--")
            {
                if (richTextBox1.Text.Length > 1)
                    richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
                else
                    richTextBox1.Text = "0";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
