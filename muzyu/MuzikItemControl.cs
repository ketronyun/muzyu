using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TagLib;

namespace muzyu
{
    public partial class MuzikItemControl : UserControl
    {
        public string Baslik => lblBaslik.Text;
        public string Sanatci => lblSanatci.Text;
        public string DosyaYolu => dosyaYolu;

        private string dosyaYolu;

        // Olaylar
        public event EventHandler MuzikTiklandi;
        public event EventHandler<string> SanatciTiklandi;

        public MuzikItemControl()
        {
            InitializeComponent();

            // Sanatçı adına özel tıklama
            lblSanatci.Click += lblSanatci_Click;

            // Diğer tüm kontroller için genel tıklama
            RegisterClickEvent(this);
        }

        private void RegisterClickEvent(Control parent)
        {
            if (parent != lblSanatci) // Sanatçıya özel handler olduğu için bu genel handler'a dahil etme
                parent.Click += OnClick;

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl != lblSanatci) // yine sanatçıyı hariç tut
                    RegisterClickEvent(ctrl);
            }
        }

        private void lblSanatci_Click(object sender, EventArgs e)
        {
            SanatciTiklandi?.Invoke(this, lblSanatci.Text);
        }

        private void OnClick(object sender, EventArgs e)
        {
            MuzikTiklandi?.Invoke(this, EventArgs.Empty);
        }

        public void SetData(string baslik, string sanatci, string dosyaYolu)
        {
            lblBaslik.Text = baslik;
            lblSanatci.Text = sanatci;
            this.dosyaYolu = dosyaYolu;

            try
            {
                var tfile = TagLib.File.Create(dosyaYolu);
                if (tfile.Tag.Pictures.Length > 0)
                {
                    byte[] bin = tfile.Tag.Pictures[0].Data.Data;
                    using var ms = new MemoryStream(bin);
                    pictureBoxKapak.Image = Image.FromStream(ms);
                }
                else
                {
                    pictureBoxKapak.Image = null; // Albüm kapak yoksa
                }
            }
            catch
            {
                pictureBoxKapak.Image = null; // Hata varsa temizle
            }
        }
    }
}
