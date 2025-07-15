using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TagLib;

namespace muzyu
{
    public partial class eklemüzik : Form
    {
        public eklemüzik()
        {
            InitializeComponent();

            cmbKategori.Items.AddRange(new[] { "Pop", "Rock", "Jazz", "Blues", "Klasik", "Hip‑Hop" });
            cmbKategori.SelectedIndex = 0;

            this.AllowDrop = true;
            this.DragEnter += Form_DragEnter;
            this.DragDrop += Form_DragDrop;
        }

        private void btnGözat_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "MP3 Dosyaları (*.mp3)|*.mp3",
                Title = "Müzik Seç"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDosyaYolu.Text = ofd.FileName;

                try
                {
                    var tfile = TagLib.File.Create(ofd.FileName);
                    txtBaslik.Text = tfile.Tag.Title ?? Path.GetFileNameWithoutExtension(ofd.FileName);
                    txtSanatci.Text = tfile.Tag.FirstPerformer ?? "Bilinmeyen";
                    txtSure.Text = tfile.Properties.Duration.ToString(@"hh\:mm\:ss");

                    if (txtAlbum != null)
                        txtAlbum.Text = tfile.Tag.Album ?? "Bilinmeyen Albüm";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MP3 bilgileri okunamadı: " + ex.Message);
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBaslik.Text) ||
                string.IsNullOrWhiteSpace(txtDosyaYolu.Text) ||
                !System.IO.File.Exists(txtDosyaYolu.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun!", "Eksik Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TimeSpan.TryParse(txtSure.Text, out TimeSpan sure))
            {
                MessageBox.Show("Süre formatı hh:mm:ss olmalıdır.",
                                "Hatalı Süre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var tagFile = TagLib.File.Create(txtDosyaYolu.Text);

                string album = txtAlbum?.Text ?? tagFile.Tag.Album ?? "Tekli";
                string albumResimBase64 = null;

                if (tagFile.Tag.Pictures.Length > 0)
                {
                    byte[] bin = tagFile.Tag.Pictures[0].Data.Data;
                    albumResimBase64 = Convert.ToBase64String(bin);
                }

                const string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                const string sql = @"INSERT INTO muzikler
                (baslik, dosya_yolu, kategori, sanatci, sure, album, album_resmi)
                VALUES (@baslik, @dosya, @kategori, @sanatci, @sure, @album, @albumResim)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@baslik", txtBaslik.Text);
                cmd.Parameters.AddWithValue("@dosya", txtDosyaYolu.Text);
                cmd.Parameters.AddWithValue("@kategori", cmbKategori.Text);
                cmd.Parameters.AddWithValue("@sanatci", txtSanatci.Text);
                cmd.Parameters.AddWithValue("@sure", sure);
                cmd.Parameters.AddWithValue("@album", album);
                cmd.Parameters.AddWithValue("@albumResim", albumResimBase64 ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Müzik başarıyla eklendi!", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message,
                    "Veri Tabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string ext = Path.GetExtension(files[0]).ToLower();

                if (ext == ".mp3" || ext == ".zip" || ext == ".rar")
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0) return;

            foreach (string path in files)
            {
                if (path.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    string extractPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                    ZipFile.ExtractToDirectory(path, extractPath);

                    foreach (string mp3File in Directory.GetFiles(extractPath, "*.mp3", SearchOption.AllDirectories))
                        Mp3DosyasiKaydet(mp3File);

                    MessageBox.Show("ZIP içindeki müzikler başarıyla eklendi.");
                }
                else if (path.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
                {
                    Mp3DosyasiKaydet(path);
                    MessageBox.Show("MP3 başarıyla eklendi.");
                }
            }
        }

        private void Mp3DosyasiKaydet(string mp3Path)
        {
            try
            {
                var tagFile = TagLib.File.Create(mp3Path);

                string baslik = tagFile.Tag.Title ?? Path.GetFileNameWithoutExtension(mp3Path);
                string sanatci = tagFile.Tag.FirstPerformer ?? "Bilinmeyen";
                string album = tagFile.Tag.Album ?? "Tekli";
                TimeSpan sure = tagFile.Properties.Duration;

                string albumResimBase64 = null;
                if (tagFile.Tag.Pictures.Length > 0)
                {
                    byte[] bin = tagFile.Tag.Pictures[0].Data.Data;
                    albumResimBase64 = Convert.ToBase64String(bin);
                }

                const string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                const string sql = @"INSERT INTO muzikler
                (baslik, dosya_yolu, kategori, sanatci, sure, album, album_resmi)
                VALUES (@baslik, @dosya, @kategori, @sanatci, @sure, @album, @albumResim)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@baslik", baslik);
                cmd.Parameters.AddWithValue("@dosya", mp3Path);
                cmd.Parameters.AddWithValue("@kategori", "Bilinmeyen");
                cmd.Parameters.AddWithValue("@sanatci", sanatci);
                cmd.Parameters.AddWithValue("@sure", sure);
                cmd.Parameters.AddWithValue("@album", album);
                cmd.Parameters.AddWithValue("@albumResim", albumResimBase64 ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MP3 ekleme hatası: " + ex.Message);
            }
        }

        private void Temizle()
        {
            txtBaslik.Clear();
            txtDosyaYolu.Clear();
            txtSanatci.Clear();
            txtSure.Clear();
            if (txtAlbum != null) txtAlbum.Clear();
            cmbKategori.SelectedIndex = 0;
        }
    }
}
