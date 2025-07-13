using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;

namespace muzyu
{

    public partial class Anasayfa : Form
    {
        int click = 0;
        bool menuAcik = false; // Menü açık mı kapalı mı?
        string kullaniciAdi;
        public Anasayfa(string adi)
        {
            InitializeComponent();

            kullaniciAdi = adi;
            label1.Text = "Hoş geldin, " + kullaniciAdi;
            // Menü butonunun konumlandırılması
            btnMenu.Top = 0;
            btnMenu.Left = 5;
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            pnlMenu.Width = 0; // Başlangıçta menü dar halde
            timer1.Interval = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (menuAcik)
            {
                pnlMenu.Width -= 20; // Menü daralıyor
                if (pnlMenu.Width <= 0)
                {
                    timer1.Stop();
                    menuAcik = false;
                }
            }
            else
            {
                pnlMenu.Width += 20; // Menü genişliyor
                if (pnlMenu.Width >= 161)
                {
                    timer1.Stop();
                    menuAcik = true;
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            click++;

            if (click == 1)
            {
                timer1.Start(); // Menü aç/kapat animasyonunu başlat

                btnMenu.Top = 0;
                btnMenu.Left = 142;
            }
            else
            {
                timer1.Start(); // Menü aç/kapat animasyonunu başlat

                click = 0;
                btnMenu.Top = 0;
                btnMenu.Left = 5;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Oturumu sil
            string oturumDosyasi = "MuZyuOturum.txt";
            if (System.IO.File.Exists(oturumDosyasi))
                System.IO.File.Delete(oturumDosyasi);

            // Form1’e dön
            Form1 girisForm = new Form1();
            girisForm.Show();

            // AnaSayfa’yı kapat
            this.Close();
        }

    }
}
