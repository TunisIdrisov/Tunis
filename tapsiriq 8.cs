
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string photoPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Profil şəkli seç";
                dialog.Filter = "Şəkillər|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    photoPath = dialog.FileName;

                    using (Image image = Image.FromFile(photoPath))
                    {
                        pictureBoxProfile.Image = new Bitmap(image);
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show(
                    "Zəhmət olmasa, bütün xanaları doldurun.",
                    "Xəbərdarlıq",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!textBoxEmail.Text.Contains("@") ||
                !textBoxEmail.Text.Contains("."))
            {
                MessageBox.Show(
                    "Düzgün e-poçt ünvanı daxil edin.",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            buttonSave.Enabled = false;
            buttonAddPhoto.Enabled = false;

            progressBarLoading.Value = 0;
            labelStatus.Text = "Məlumatlar yadda saxlanılır...";

            timerLoading.Start();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            if (progressBarLoading.Value < 100)
            {
                progressBarLoading.Value =
                    Math.Min(progressBarLoading.Value + 5, 100);
            }
            else
            {
                timerLoading.Stop();

                try
                {
                    string folder = Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments);

                    string filePath = Path.Combine(folder, "ProfileData.txt");

                    string data =
                        "Ad və soyad: " + textBoxName.Text + Environment.NewLine +
                        "E-poçt: " + textBoxEmail.Text + Environment.NewLine +
                        "Telefon: " + textBoxPhone.Text + Environment.NewLine +
                        "Tarix: " + dateTimePicker1.Value.ToShortDateString() +
                        Environment.NewLine +
                        "Şəkil: " + photoPath;

                    File.WriteAllText(filePath, data);

                    labelStatus.Text = "Məlumatlar yadda saxlanıldı!";

                    MessageBox.Show(
                        "Məlumatlar uğurla yadda saxlanıldı.\n\nFayl: " + filePath,
                        "Uğurlu əməliyyat",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    labelStatus.Text = "Yadda saxlamaq mümkün olmadı.";

                    MessageBox.Show(
                        "Xəta: " + ex.Message,
                        "Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    buttonSave.Enabled = true;
                    buttonAddPhoto.Enabled = true;
                }
            }
        }
    }
}