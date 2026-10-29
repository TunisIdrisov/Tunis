using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FaylMeneceri
{
    public partial class Form1 : Form
    {
        private string cariQovluq = "";

        public Form1()
        {
            InitializeComponent();
            lstFayllar.Items.Clear();
            txtMetn.Clear();
            lblMelumat.Text = "Fayl seçilməyib";
            lblStatus.Text = "Hazırdır  |  Fayl sayı: 0";
        }

      
        private void btnQovluq_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                cariQovluq = dlg.SelectedPath;
                txtYol.Text = cariQovluq;
                FayllariYenile();
            }
        }

        private void FayllariYenile()
        {
            lstFayllar.Items.Clear();
            txtMetn.Clear();
            lblMelumat.Text = "Fayl seçilməyib";

            if (!Directory.Exists(cariQovluq)) return;

            var fayllar = Directory.GetFiles(cariQovluq, "*.txt")
                                   .Select(Path.GetFileName)
                                   .OrderBy(f => f);

            foreach (var f in fayllar)
                lstFayllar.Items.Add(f);

            lblStatus.Text = $"Hazırdır  |  Fayl sayı: {lstFayllar.Items.Count}";
        }

        private string SecilmisYol()
        {
            if (lstFayllar.SelectedItem == null) return null;
            return Path.Combine(cariQovluq, lstFayllar.SelectedItem.ToString());
        }

       
        private void lstFayllar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yol = SecilmisYol();
            if (yol == null || !File.Exists(yol)) return;

            var info = new FileInfo(yol);
            lblMelumat.Text = $"Ad: {info.Name}     Ölçü: {info.Length / 1024.0:0.0} KB     " +
                              $"Yaranma tarixi: {info.CreationTime:dd.MM.yyyy}";
        }

       
        private void btnAc_Click(object sender, EventArgs e)
        {
            string yol = SecilmisYol();
            if (yol == null)
            {
                MessageBox.Show("Zəhmət olmasa siyahıdan fayl seçin.", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                txtMetn.Text = File.ReadAllText(yol);
                lblStatus.Text = $"Açıldı: {Path.GetFileName(yol)}  |  Fayl sayı: {lstFayllar.Items.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fayl açılmadı: " + ex.Message, "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnSaxla_Click(object sender, EventArgs e)
        {
            string yol = SecilmisYol();
            if (yol == null)
            {
                MessageBox.Show("Zəhmət olmasa siyahıdan fayl seçin.", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                File.WriteAllText(yol, txtMetn.Text);
                lblStatus.Text = $"Yadda saxlandı: {Path.GetFileName(yol)}  |  Fayl sayı: {lstFayllar.Items.Count}";
                lstFayllar_SelectedIndexChanged(null, null); // ölçünü yenilə
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yadda saxlanmadı: " + ex.Message, "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnSil_Click(object sender, EventArgs e)
        {
            string yol = SecilmisYol();
            if (yol == null)
            {
                MessageBox.Show("Zəhmət olmasa siyahıdan fayl seçin.", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cavab = MessageBox.Show(
                $"'{Path.GetFileName(yol)}' faylı silinsin?", "Təsdiq",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cavab != DialogResult.Yes) return;

            try
            {
                File.Delete(yol);
                FayllariYenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinmədi: " + ex.Message, "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
