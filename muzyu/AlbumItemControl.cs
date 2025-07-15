using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace muzyu
{
    public partial class AlbumItemControl : UserControl
    {
        public event EventHandler AlbumTiklandi;
        public string AlbumAdi { get; private set; }

        public AlbumItemControl()
        {
            InitializeComponent();

            // Her yere tıklanınca albüm olayını tetikle
            this.Click += AlbumItemControl_Click;
            foreach (Control ctrl in this.Controls)
                ctrl.Click += AlbumItemControl_Click;
        }

        private void AlbumItemControl_Click(object sender, EventArgs e)
        {
            AlbumTiklandi?.Invoke(this, EventArgs.Empty);
        }

        public void SetAlbum(string albumAdi, string base64Resim)
        {
            AlbumAdi = albumAdi;
            lblAlbumAdi.Text = albumAdi;

            if (!string.IsNullOrEmpty(base64Resim))
            {
                try
                {
                    byte[] imageBytes = Convert.FromBase64String(base64Resim);
                    using MemoryStream ms = new(imageBytes);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                catch
                {
                    pictureBox1.Image = null; // Bozuk resim varsa temizle
                }
            }
            else
            {
                pictureBox1.Image = null; // Hiç resim yoksa boş bırak
            }
        }
    }
}
