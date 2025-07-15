using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NAudio.Wave;
using TagLib;

namespace muzyu
{
    public partial class Anasayfa : Form
    {
        private PlayerControl playerControl1;
        private System.Windows.Forms.Timer progressTimer;
        private List<string> playlist = new();
        private int currentIndex = -1;
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private string kullaniciAdi;
        private bool isPlaying = false;
        private bool menuAcik = false;
        private int click = 0;

        public Anasayfa(string adi)
        {
            InitializeComponent();
            btnMenu.Top = 0;
            btnMenu.Left = 0;
            pnlMenu.Width = 70;
            pnlMenu.Width = 0;
            timer1.Interval = 1;
            kullaniciAdi = adi;
            label1.Text = "Hoş geldin, " + kullaniciAdi;

            // PlayerControl yükle
            playerControl1 = new PlayerControl();
            playerControl1.Dock = DockStyle.Bottom;
            this.Controls.Add(playerControl1);

            // Eventler
            playerControl1.PlayClicked += (s, e) => Resume();
            playerControl1.PauseClicked += (s, e) => Pause();
            playerControl1.NextClicked += (s, e) => NextSong();
            playerControl1.PreviousClicked += (s, e) => PreviousSong();
            playerControl1.VolumeChanged += (s, vol) => SetVolume(vol);
            playerControl1.ProgressBarSeekRequested += PlayerControl1_ProgressBarSeekRequested;

            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 500;
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();

            ListeleMuzikler();
        }

        private void PlayerControl1_ProgressBarSeekRequested(object sender, double percentage)
        {
            if (audioFile != null)
            {
                double newPosition = audioFile.TotalTime.TotalSeconds * percentage;
                audioFile.CurrentTime = TimeSpan.FromSeconds(newPosition);
            }
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (audioFile != null && outputDevice != null && isPlaying)
            {
                double pos = audioFile.CurrentTime.TotalSeconds;
                double dur = audioFile.TotalTime.TotalSeconds;
                playerControl1.UpdateProgress(pos, dur);
            }
        }

        private void PlaySongByIndex(int index)
        {
            if (index < 0 || index >= playlist.Count) return;

            string filePath = playlist[index];

            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("Dosya bulunamadı.");
                return;
            }

            StopPlayback();

            try
            {
                audioFile = new AudioFileReader(filePath);

                // BURADA ses seviyesini ayarlıyoruz
                float volume = Math.Clamp(playerControl1.CurrentVolume / 100f, 0f, 1f);
                audioFile.Volume = volume;

                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
                isPlaying = true;

                var tagFile = TagLib.File.Create(filePath);
                string title = tagFile.Tag.Title;
                string artist = string.Join(", ", tagFile.Tag.Performers);
                Image albumCover = null;

                if (tagFile.Tag.Pictures.Length > 0)
                {
                    byte[] bin = tagFile.Tag.Pictures[0].Data.Data;
                    using MemoryStream ms = new(bin);
                    albumCover = Image.FromStream(ms);
                }

                playerControl1.SetSong(title, artist, albumCover);
                playerControl1.SetPlayState(true); // ← Burada çalma durumu kontrolüne göre ayarlanıyor

            }
            catch (Exception ex)
            {
                MessageBox.Show("Şarkı çalınırken hata oluştu: " + ex.Message);
            }
        }


        private void Resume()
        {
            if (outputDevice != null && audioFile != null)
            {
                outputDevice.Play();
                isPlaying = true;
                playerControl1.SetPlayState(true); // devam ettiğinde görsel güncelle
            }
        }

        private void Pause()
        {
            if (outputDevice != null)
            {
                outputDevice.Pause();
                isPlaying = false;
                playerControl1.SetPlayState(false);

            }
        }

        private void StopPlayback()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            audioFile?.Dispose();
            outputDevice = null;
            audioFile = null;
            isPlaying = false;
        }

        private void SetVolume(int volume)
        {
            if (audioFile != null)
            {
                audioFile.Volume = Math.Clamp(volume / 100f, 0f, 1f);
            }
        }


        private void NextSong()
        {
            if (playlist.Count == 0) return;
            currentIndex = (currentIndex + 1) % playlist.Count;
            PlaySongByIndex(currentIndex);
        }

        private void PreviousSong()
        {
            if (playlist.Count == 0) return;
            currentIndex = (currentIndex - 1 + playlist.Count) % playlist.Count;
            PlaySongByIndex(currentIndex);
        }

        private void ListeleMuzikler()
        {
            flowPanelMuzikler.Controls.Clear();
            playlist.Clear();

            string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "SELECT baslik, sanatci, dosya_yolu FROM muzikler ORDER BY sanatci, baslik";
            using var cmd = new MySqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string baslik = reader["baslik"].ToString();
                string sanatci = reader["sanatci"].ToString();
                string dosyaYolu = reader["dosya_yolu"].ToString();

                playlist.Add(dosyaYolu);

                var muzikItem = new MuzikItemControl();
                muzikItem.SetData(baslik, sanatci, dosyaYolu);
                muzikItem.MuzikTiklandi += MuzikItem_MuzikTiklandi;
                muzikItem.SanatciTiklandi += (s, sanatciAdi) => GosterSanatciDetay(sanatciAdi);

                flowPanelMuzikler.Controls.Add(muzikItem);
            }
        }



        private void MuzikleriYukle(string albumAdi)
        {
            flowPanelMuzikler.Controls.Clear();

            string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "SELECT * FROM muzikler WHERE album = @album";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@album", albumAdi);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string baslik = reader["baslik"].ToString();
                string sanatci = reader["sanatci"].ToString();
                string dosyaYolu = reader["dosya_yolu"].ToString();

                var muzikItem = new MuzikItemControl();
                muzikItem.SetData(baslik, sanatci, dosyaYolu);
                muzikItem.MuzikTiklandi += MuzikItem_MuzikTiklandi;

                flowPanelMuzikler.Controls.Add(muzikItem);
            }
        }

        private void MuzikItem_MuzikTiklandi(object sender, EventArgs e)
        {
            if (sender is MuzikItemControl muzikItem)
            {
                string path = muzikItem.DosyaYolu;
                currentIndex = playlist.IndexOf(path);
                PlaySongByIndex(currentIndex);
            }
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            pnlMenu.Width = 0;
            timer1.Interval = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (menuAcik)
            {
                pnlMenu.Width -= 20;
                if (pnlMenu.Width <= 0)
                {
                    pnlMenu.Width = 0;
                    timer1.Stop();
                    menuAcik = false;
                    button2.Visible = false;
                    btnCikis.Visible = false;
                }
            }
            else
            {
                pnlMenu.Width += 20;
                if (pnlMenu.Width >= 250)
                {
                    pnlMenu.Width = 250;
                    timer1.Stop();
                    menuAcik = true;
                    button2.Visible = true;
                    btnCikis.Visible = true;
                }
            }

            // 🔄 Butonu hep önde tut
            btnMenu.BringToFront();
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            click++;
            timer1.Start();

            btnMenu.Left = menuAcik ? 0 : 190;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oturumDosyasi = "MuZyuOturum.txt";
            if (System.IO.File.Exists(oturumDosyasi))
                System.IO.File.Delete(oturumDosyasi);

            new Form1().Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new eklemüzik().ShowDialog();
        }

        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPlayback();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aranan = txtArama.Text.Trim().ToLower();

            flowPanelMuzikler.Controls.Clear();
            playlist.Clear();

            if (string.IsNullOrEmpty(aranan))
            {
                ListeleMuzikler(); // Tüm şarkılar
                panelOrta.Controls.Clear(); // Sanatçı detay temizle
                return;
            }

            string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            string sql = "SELECT baslik, sanatci, dosya_yolu FROM muzikler WHERE LOWER(baslik) LIKE @aranan OR LOWER(sanatci) LIKE @aranan";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@aranan", $"%{aranan}%");
            using var reader = cmd.ExecuteReader();

            HashSet<string> sanatciSet = new(); // aranan sanatçıyı algılamak için
            while (reader.Read())
            {
                string baslik = reader["baslik"].ToString();
                string sanatci = reader["sanatci"].ToString();
                string dosyaYolu = reader["dosya_yolu"].ToString();

                sanatciSet.Add(sanatci);

                var muzikItem = new MuzikItemControl();
                muzikItem.SetData(baslik, sanatci, dosyaYolu);
                muzikItem.MuzikTiklandi += MuzikItem_MuzikTiklandi;
                muzikItem.SanatciTiklandi += (s, sanatciAdi) => GosterSanatciDetay(sanatciAdi);

                flowPanelMuzikler.Controls.Add(muzikItem);
            }

            // Eğer sadece tek bir sanatçı varsa onun detayını göster
            if (sanatciSet.Count == 1)
            {
                string tekSanatci = sanatciSet.First();
                GosterSanatciDetay(tekSanatci);
            }
            else
            {
                panelOrta.Controls.Clear(); // birden fazla varsa detay gösterme
            }
        }




        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArama.Text))
            {
                ListeleMuzikler();
                panelOrta.Controls.Clear(); // Sanatçi detayını kaldır
            }
        }
        private void GosterSanatciDetay(string sanatciAdi)
        {
            panelOrta.Controls.Clear();

            var detay = new SanatciDetayControl();
            detay.Dock = DockStyle.Fill;
            detay.SetSanatci(sanatciAdi);

            // Şarkı tıklanınca çalma
            detay.MuzikSecildi += (s, muzikControl) =>
            {
                string filePath = muzikControl.DosyaYolu;

                if (!System.IO.File.Exists(filePath))
                {
                    MessageBox.Show("Dosya bulunamadı.");
                    return;
                }

                var tagFile = TagLib.File.Create(filePath);
                string title = tagFile.Tag.Title;
                string artist = string.Join(", ", tagFile.Tag.Performers);
                Image albumCover = null;

                if (tagFile.Tag.Pictures.Length > 0)
                {
                    byte[] bin = tagFile.Tag.Pictures[0].Data.Data;
                    using MemoryStream ms = new(bin);
                    albumCover = Image.FromStream(ms);
                }

                playerControl1.SetSong(title, artist, albumCover);

                StopPlayback();
                audioFile = new AudioFileReader(filePath);
                float volume = Math.Clamp(playerControl1.CurrentVolume / 100f, 0f, 1f);
                audioFile.Volume = volume;
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
                isPlaying = true;
                playerControl1.SetPlayState(true);
            };

            // Albüm tıklanınca sadece o albümün şarkılarını göster
            detay.AlbumSecildi += (s, albumAdi) =>
            {
                MuzikleriYukle(albumAdi); // flowPanelMuzikler'de sadece o albüm şarkıları
            };

            panelOrta.Controls.Add(detay);
        }



    }
}
