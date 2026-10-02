using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public class Form1 : Form
    {
        private TextBox adSoyad;
        private TextBox muddet;

        private Button[] otaqlar = new Button[4];
        private TextBox[] vaxtlar = new TextBox[4];

        private bool[] rezervOlunub = new bool[4];
        private int[] qalanSaniye = new int[4];

        private System.Windows.Forms.Timer timer;

        public Form1()
        {
            // FORM
            this.Text = "Otaq Rezervasiya Sistemi";
            this.ClientSize = new Size(520, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Teal;

            // =========================
            // AD SOYAD
            // =========================

            Label adLabel = new Label();

            adLabel.Text = "Ad Soyad:";
            adLabel.Location = new Point(50, 25);
            adLabel.AutoSize = true;
            adLabel.ForeColor = Color.White;

            this.Controls.Add(adLabel);

            adSoyad = new TextBox();

            adSoyad.Location = new Point(50, 50);
            adSoyad.Size = new Size(300, 25);

            this.Controls.Add(adSoyad);

            // =========================
            // MÜDDƏT
            // =========================

            Label muddetLabel = new Label();

            muddetLabel.Text = "Müddət (dəqiqə):";
            muddetLabel.Location = new Point(50, 85);
            muddetLabel.AutoSize = true;
            muddetLabel.ForeColor = Color.White;

            this.Controls.Add(muddetLabel);

            muddet = new TextBox();

            muddet.Location = new Point(50, 110);
            muddet.Size = new Size(300, 25);

            this.Controls.Add(muddet);

            // =========================
            // 4 OTAQ
            // =========================

            for (int i = 0; i < 4; i++)
            {
                int index = i;

                int x;
                int y;

                if (i == 0)
                {
                    x = 50;
                    y = 190;
                }
                else if (i == 1)
                {
                    x = 280;
                    y = 190;
                }
                else if (i == 2)
                {
                    x = 50;
                    y = 360;
                }
                else
                {
                    x = 280;
                    y = 360;
                }

                // VAQT TEXTBOX
                vaxtlar[i] = new TextBox();

                vaxtlar[i].Location =
                    new Point(x + 25, y - 30);

                vaxtlar[i].Size =
                    new Size(150, 25);

                vaxtlar[i].Text = "Boş";
                vaxtlar[i].ReadOnly = true;
                vaxtlar[i].TextAlign =
                    HorizontalAlignment.Center;

                this.Controls.Add(vaxtlar[i]);

                // OTAQ BUTTON
                otaqlar[i] = new Button();

                otaqlar[i].Text =
                    "Otaq " + (i + 1);

                otaqlar[i].Location =
                    new Point(x, y);

                otaqlar[i].Size =
                    new Size(200, 120);

                otaqlar[i].BackColor =
                    Color.LightGray;

                otaqlar[i].ForeColor =
                    Color.Black;

                otaqlar[i].Font =
                    new Font(
                        "Arial",
                        11,
                        FontStyle.Bold
                    );

                otaqlar[i].Click +=
                    delegate
                    {
                        OtaqRezervEt(index);
                    };

                this.Controls.Add(otaqlar[i]);
            }

            // =========================
            // TIMER
            // =========================

            timer =
                new System.Windows.Forms.Timer();

            timer.Interval = 1000;

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        // ==========================================
        // OTAQ REZERV ET
        // ==========================================

        private void OtaqRezervEt(int index)
        {
            // AD SOYAD
            if (string.IsNullOrWhiteSpace(adSoyad.Text))
            {
                MessageBox.Show(
                    "Zəhmət olmasa Ad Soyad daxil edin!",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                adSoyad.Focus();

                return;
            }

            // MÜDDƏT
            int deqiqe;

            if (!int.TryParse(
                muddet.Text,
                out deqiqe))
            {
                MessageBox.Show(
                    "Müddəti düzgün daxil edin!",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                muddet.Focus();

                return;
            }

            // MÜDDƏT 0 OLA BİLMƏZ
            if (deqiqe <= 0)
            {
                MessageBox.Show(
                    "Müddət 0-dan böyük olmalıdır!",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // OTAQ REZERV OLUNUB?
            if (rezervOlunub[index])
            {
                MessageBox.Show(
                    "Bu otaq rezerv olunub!",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            // REZERV ET
            rezervOlunub[index] = true;

            qalanSaniye[index] =
                deqiqe * 60;

            // OTAĞI QIRMIZI ET
            otaqlar[index].ForeColor =
                Color.Red;

            // OTAĞIN ADI VƏ MÜŞTƏRİ
            otaqlar[index].Text =
                "Otaq " +
                (index + 1) +
                Environment.NewLine +
                adSoyad.Text;

            // VAXTI GÖSTƏR
            VaxtiGoster(index);

            MessageBox.Show(
                "Otaq rezerv olundu!",
                "Məlumat",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ==========================================
        // TIMER
        // ==========================================

        private void Timer_Tick(
            object sender,
            EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (!rezervOlunub[i])
                {
                    continue;
                }

                qalanSaniye[i]--;

                // VAXT BİTDİ
                if (qalanSaniye[i] <= 0)
                {
                    rezervOlunub[i] = false;

                    qalanSaniye[i] = 0;

                    otaqlar[i].Text =
                        "Otaq " + (i + 1);

                    otaqlar[i].ForeColor =
                        Color.Black;

                    vaxtlar[i].Text =
                        "Boş";

                    MessageBox.Show(
                        "Otaq " +
                        (i + 1) +
                        " üçün rezervasiya müddəti bitdi.",
                        "Məlumat",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    VaxtiGoster(i);
                }
            }
        }

        // ==========================================
        // VAXTI GÖSTƏR
        // ==========================================

        private void VaxtiGoster(int index)
        {
            int deqiqe =
                qalanSaniye[index] / 60;

            int saniye =
                qalanSaniye[index] % 60;

            vaxtlar[index].Text =
                deqiqe.ToString("00") +
                ":" +
                saniye.ToString("00");
        }
    }
}
