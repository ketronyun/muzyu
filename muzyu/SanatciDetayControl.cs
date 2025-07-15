using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace muzyu
{
    public partial class SanatciDetayControl : UserControl
    {
        public string SanatciAdi { get; private set; }

        public event EventHandler<MuzikItemControl> MuzikSecildi;
        public event EventHandler<string> AlbumSecildi;
        public SanatciDetayControl()
        {
            InitializeComponent();
        }

        public void SetSanatci(string sanatciAdi, Image arkaPlanGorsel = null)
        {
            SanatciAdi = sanatciAdi;
            lblSanatciAdi.Text = sanatciAdi;
            tableSarkiListesi.Controls.Clear();
            tableSarkiListesi.RowCount = 0;
            tableSarkiListesi.RowStyles.Clear();

            string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
            using var conn = new MySqlConnection(connStr);
            conn.Open();

            var cmd = new MySqlCommand("SELECT DISTINCT album, album_resmi FROM muzikler WHERE sanatci = @sanatci AND album IS NOT NULL", conn);
            cmd.Parameters.AddWithValue("@sanatci", sanatciAdi);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string albumAdi = reader["album"]?.ToString();
                string base64Resim = reader["album_resmi"]?.ToString();

                var albumControl = new AlbumItemControl();
                albumControl.SetAlbum(albumAdi, base64Resim);

                albumControl.AlbumTiklandi += (s, e) =>
                {
                    AlbumSecildi?.Invoke(this, albumAdi);
                };

                tableSarkiListesi.RowCount++;
                tableSarkiListesi.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableSarkiListesi.Controls.Add(albumControl, 0, tableSarkiListesi.RowCount - 1);
            }

            // Otomatik yükseklik ayarı
            tableSarkiListesi.Height = tableSarkiListesi.Controls.Count * (100 + 10); // her albüm 100px varsayımı
            sarkiListesiWrapper.Height = tableSarkiListesi.Height;
        }






        private void OnAlbumClicked(string albumAdi)
        {
            AlbumSecildi?.Invoke(this, albumAdi);
        }

        private void MuzikItem_MuzikTiklandi(object sender, EventArgs e)
        {
            var muzik = sender as MuzikItemControl;
            MuzikSecildi?.Invoke(this, muzik);
        }
    }
}
