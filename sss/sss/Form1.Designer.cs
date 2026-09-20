namespace sss
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            linkLabel1 = new LinkLabel();
            checkBox1 = new CheckBox();
            button1 = new Button();
            password = new TextBox();
            Username = new TextBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            checkBox2 = new CheckBox();
            button2 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.DarkGray;
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(password);
            groupBox1.Controls.Add(Username);
            groupBox1.Cursor = Cursors.Hand;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(325, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(251, 295);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Log in";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.Red;
            linkLabel1.Location = new Point(37, 174);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(117, 16);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Create an account ";
            linkLabel1.Visible = false;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(37, 151);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(135, 20);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Show me pasword";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(78, 231);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Sign in";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // password
            // 
            password.BackColor = Color.White;
            password.Location = new Point(37, 115);
            password.Name = "password";
            password.PlaceholderText = "Password";
            password.Size = new Size(182, 30);
            password.TabIndex = 2;
            password.UseSystemPasswordChar = true;
            password.TextChanged += password_TextChanged_1;
            // 
            // Username
            // 
            Username.BackColor = Color.White;
            Username.Location = new Point(37, 69);
            Username.Name = "Username";
            Username.PlaceholderText = "Username";
            Username.Size = new Size(182, 30);
            Username.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.DarkGray;
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(button2);
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(328, 64);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(248, 295);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sign up";
            groupBox2.Visible = false;
            groupBox2.Enter += groupBox2_Enter;
            // 
            // label1
            // 
            label1.BackColor = Color.DarkGray;
            label1.Font = new Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(38, 179);
            label1.Name = "label1";
            label1.Size = new Size(176, 36);
            label1.TabIndex = 9;
            label1.Text = "Xəta  ! Qeydiyatdan keçmək üçün aradan qaldır.";
            label1.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(38, 115);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = " Repeat Password";
            textBox3.Size = new Size(176, 30);
            textBox3.TabIndex = 8;
            textBox3.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(38, 38);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Username";
            textBox1.Size = new Size(176, 30);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(38, 79);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Password";
            textBox2.Size = new Size(176, 30);
            textBox2.TabIndex = 6;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Cursor = Cursors.Hand;
            checkBox2.Font = new Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox2.Location = new Point(38, 156);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(135, 20);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Show me pasword";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Location = new Point(79, 222);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox password;
        private TextBox Username;
        private CheckBox checkBox1;
        private Button button1;
        private LinkLabel linkLabel1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private CheckBox checkBox2;
        private TextBox textBox3;
        private Label label1;
    }
}
