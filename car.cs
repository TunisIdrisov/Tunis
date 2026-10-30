
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace MasinIdareetme
{
    public partial class Form1 : Form
    {
        // Masin
        private Panel car;

        // Timerler
        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.Timer clockTimer;

        // Suret
        private int speed = 6;

        // Hereket istiqameti
        private int moveX = 0;
        private int moveY = 0;

        // Proqramin veziyyeti
        private bool isStarted = false;
        private bool isMoving = false;

        // Vaxt
        private int elapsedSeconds = 0;

        public Form1()
        {
            InitializeComponent();

            CreateCar();
            CreateTimers();

            speed = 6;
        }

        // MASININ YARADILMASI
        private void CreateCar()
        {
            car = new Panel();

            car.Size = new Size(48, 120);
            car.Location = new Point(214, 500);
            car.BackColor = Color.Transparent;

            car.Paint += DrawCar;

            road.Controls.Add(car);
            car.BringToFront();
        }

        // MASININ SEKLININ CEKILMESI
        private void DrawCar(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Masin govdesi
            g.FillRoundedRectangle(
                Brushes.Red, 8, 5, 32, 110, 12);

            // On ve arxa hisseler
            g.FillEllipse(Brushes.Red, 7, 3, 34, 30);
            g.FillEllipse(Brushes.Red, 7, 88, 34, 30);

            // Kabin
            g.FillRectangle(
                Brushes.Firebrick, 10, 30, 28, 60);

            // Suseler
            g.FillEllipse(Brushes.Black, 10, 32, 28, 28);
            g.FillEllipse(Brushes.Black, 10, 69, 28, 25);

            // Faralar
            g.FillRectangle(Brushes.White, 11, 5, 7, 4);
            g.FillRectangle(Brushes.White, 30, 5, 7, 4);

            // Arxa faralar
            g.FillRectangle(Brushes.DarkRed, 11, 112, 7, 4);
            g.FillRectangle(Brushes.DarkRed, 30, 112, 7, 4);

            // Tekərlər
            g.FillRectangle(Brushes.Black, 2, 22, 7, 20);
            g.FillRectangle(Brushes.Black, 39, 22, 7, 20);
            g.FillRectangle(Brushes.Black, 2, 78, 7, 20);
            g.FillRectangle(Brushes.Black, 39, 78, 7, 20);

            // Kontur
            g.DrawRectangle(Pens.DarkRed, 8, 5, 32, 110);
        }

        // TIMERLERIN YARADILMASI
        private void CreateTimers()
        {
            moveTimer = new System.Windows.Forms.Timer();

            moveTimer.Interval = 30;
            moveTimer.Tick += MoveTimer_Tick;

            clockTimer = new System.Windows.Forms.Timer();

            clockTimer.Interval = 1000;
            clockTimer.Tick += ClockTimer_Tick;
        }

        // YOL XETLERI
        private void Road_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.White, 9))
            {
                p.DashStyle =
                    System.Drawing.Drawing2D.DashStyle.Dash;

                e.Graphics.DrawLine(
                    p, 143, 20, 143, 628);
            }
        }

        // START
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                isStarted = true;

                PlayEngineSound();

                clockTimer.Start();
            }

            isMoving = true;
            moveTimer.Start();
        }

        // BREAK
        private void BtnBreak_Click(object sender, EventArgs e)
        {
            isMoving = false;

            moveX = 0;
            moveY = 0;

            moveTimer.Stop();
        }

        // EXIT
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ISTIQAMET
        private void MoveCar(int x, int y)
        {
            if (!isStarted)
            {
                MessageBox.Show(
                    "Evvelce START duymesine basin!",
                    "Melumat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            moveX = x;
            moveY = y;

            isMoving = true;
            moveTimer.Start();
        }

        // MASININ HEREKETI
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (!isStarted || !isMoving)
                return;

            int newX = car.Left + moveX * speed;
            int newY = car.Top + moveY * speed;

            // Yolun serhedleri
            if (newX < 0)
                newX = 0;

            if (newX > road.Width - car.Width)
                newX = road.Width - car.Width;

            if (newY < 0)
                newY = 0;

            if (newY > road.Height - car.Height)
                newY = road.Height - car.Height;

            car.Location = new Point(newX, newY);
        }

        // COMBOBOX SURET
        private void CmbSpeed_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            switch (cmbSpeed.SelectedItem.ToString())
            {
                case "30":
                    speed = 3;
                    break;

                case "60":
                    speed = 6;
                    break;

                case "90":
                    speed = 9;
                    break;

                case "120":
                    speed = 12;
                    break;
            }
        }

        // VAXTIN HESABLANMASI
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;

            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;

            lblTime.Text =
                minutes.ToString("00") + ":" +
                seconds.ToString("00");
        }

        // MUHERRIK SESI
        private void PlayEngineSound()
        {
            try
            {
                SystemSounds.Beep.Play();
                SystemSounds.Asterisk.Play();
            }
            catch
            {
                SystemSounds.Beep.Play();
            }
        }

        // FORM BAGLANANDA
        protected override void OnFormClosing(
            FormClosingEventArgs e)
        {
            if (moveTimer != null)
            {
                moveTimer.Stop();
                moveTimer.Dispose();
            }

            if (clockTimer != null)
            {
                clockTimer.Stop();
                clockTimer.Dispose();
            }

            base.OnFormClosing(e);
        }
    }

    // MASININ YUMRU GOVDESI
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            int x, int y,
            int width, int height,
            int radius)
        {
            using (
                System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(x, y, radius, radius, 180, 90);

                path.AddArc(
                    x + width - radius, y,
                    radius, radius, 270, 90);

                path.AddArc(
                    x + width - radius,
                    y + height - radius,
                    radius, radius, 0, 90);

                path.AddArc(
                    x, y + height - radius,
                    radius, radius, 90, 90);

                path.CloseFigure();

                graphics.FillPath(brush, path);
            }
        }
    }
}
