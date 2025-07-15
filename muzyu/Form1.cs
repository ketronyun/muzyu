using System;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace muzyu
{
    public partial class Form1 : Form
    {

        string k_adi, k_par, k_park, a, c, d, j, k;
        string b = "@hot";
        string b1 = "@gma";
        public Form1()
        {
            InitializeComponent();

            comboBox1.Text = "Seçiniz...";
            comboBox1.Items.Add("@hotmail.com");
            comboBox1.Items.Add("@gmail.com");


            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            //======================================================================
            //======================     Sql baglantı      =========================
            //======================================================================
            string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MessageBox.Show("Bağlantı başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            //======================================================================
            //======================================================================



        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("MuZyuOturum.txt"))
            {
                string email = File.ReadAllText("MuZyuOturum.txt");

                if (!string.IsNullOrWhiteSpace(email))
                {
                    using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=muzyu;port=3306;password=12345678;"))
                    {
                        conn.Open();
                        string query = "SELECT kad FROM kullanicilar WHERE email = @e";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@e", email);

                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string kullaniciAdi = reader["kad"].ToString();
                            Anasayfa anasayfa = new Anasayfa(kullaniciAdi);
                            anasayfa.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }


        //======================================================================
        //======================================================================
        //======================================================================
        //======================================================================



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label8.Visible = true;
            textBox3.Visible = true;
            label3.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            button2.Visible = true;
            button1.Visible = false;
            label4.Visible = false;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label6.Left = 62;
            label6.Top = 156;
            textBox4.Left = 62;
            textBox4.Top = 179;

            label7.Left = 62;
            label7.Top = 229;
            textBox5.Left = 62;
            textBox5.Top = 252;

            label2.Left = 62;
            label2.Top = 289;
            textBox2.Left = 62;
            textBox2.Top = 312;

            checkBox1.Left = 366;
            checkBox1.Top = 315;
            //checkBox1.Left = 220;
            //checkBox1.Top = 210;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //karakteri göster.
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TextChanged olayını geçici olarak devre dışı bırak
            textBox1.TextChanged -= textBox1_TextChanged;

            // @hotmail veya @gmail zaten eklenmişse, işlem yapma
            if (textBox1.Text.Contains("@hotmail") || textBox1.Text.Contains("@gmail"))
            {
                // TextChanged olayını yeniden etkinleştir
                textBox1.TextChanged += textBox1_TextChanged;
                return; // İşlem yapılmadan çık
            }

            if (textBox1.Text.Contains("@hot"))
            {
                // @hot kısmını bul ve tamamla
                textBox1.Text = textBox1.Text.Replace("@hot", "@hotmail.com");
                comboBox1.Visible = false;
                comboBox1.SelectedIndex = 0;
            }
            else if (textBox1.Text.Contains("@g"))
            {
                // @g kısmını bul ve tamamla
                textBox1.Text = textBox1.Text.Replace("@g", "@gmail.com");
                comboBox1.Visible = false;
                comboBox1.SelectedIndex = 1;
            }

            // TextChanged olayını yeniden etkinleştir
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TextChanged olayını geçici olarak devre dışı bırak
            textBox1.TextChanged -= textBox1_TextChanged;

            if (comboBox1.SelectedItem != null && !textBox1.Text.Contains("@"))
            {
                textBox1.Text += comboBox1.SelectedItem.ToString();
                comboBox1.Visible = false;
            }

            // TextChanged olayını yeniden bağla
            textBox1.TextChanged += textBox1_TextChanged;
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text)

            && !string.IsNullOrEmpty(textBox1.Text)
            && (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1))
            {
                button2.Enabled = true;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                button2.Enabled = false;
            }
        }
        private void kenaryumus(PictureBox picBox, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, picBox.Width, picBox.Height);
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            picBox.Region = new Region(path);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text)

            && !string.IsNullOrEmpty(textBox1.Text)
            && (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1))
            {
                button2.Enabled = true;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                button2.Enabled = false;
            }
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.MediumBlue;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT kad FROM kullanicilar WHERE email = @e AND sifre = @s";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@s", sifre);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string kullaniciAdi = reader["kad"].ToString();

                        MessageBox.Show("Giriş başarılı!");

                        // Oturumu dosyaya yaz 
                        System.IO.File.WriteAllText("MuZyuOturum.txt", email);

                        // Ana sayfaya kullanıcı adını gönder
                        Anasayfa anasayfa = new Anasayfa(kullaniciAdi);
                        anasayfa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("E-posta veya şifre hatalı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void SendVerificationCode(string toEmail, string code)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("muzyu.music@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "🎵 MuZyu'dan Doğrulama Kodu!";

                // HTML body ile resmi ve metni birlikte kullanıyoruz
                mail.IsBodyHtml = true;

                // Harici bir resim URL'si kullanarak örnek (Spotify logosu veya kendi logon)
                string logoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROzCKYLMLZAHLjsGa2Fy6cCd6Y0UfIRF53pA&s";

                mail.Body = $@"
<div style='font-family: Arial, sans-serif; color: #1DB954;'>
    <img src='{logoUrl}' alt='MuZyu Logo' style='width:250px; height:auto;' />
    <h2>MuZyu ailesine hoş geldin {textBox4.Text} ! 🎉</h2>
    <p>Hesabını oluşturman için gereken doğrulama kodun:</p>
    <h1 style='color:#191414;'>{code}</h1>
    <p>Bu kodu 10 dakika içinde kullanmayı unutma.</p>
    <p>Herhangi bir sorun yaşarsan bize ulaşabilirsin.</p>
    <p>İyi müzikler dileriz! 🎧<br />MuZyu Ekibi</p>
</div>";


                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("muzyu.music@gmail.com", "wnla gupb gpwn ibmi ");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                MessageBox.Show("Doğrulama kodu e-posta adresinize gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilemedi: " + ex.Message);
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();
            string sifreTekrar = textBox3.Text.Trim();
            string kad = textBox4.Text.Trim();
            string telefon = textBox5.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") ||
                string.IsNullOrWhiteSpace(kad) || string.IsNullOrWhiteSpace(telefon))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (!(email.EndsWith("@hotmail.com") || email.EndsWith("@gmail.com")))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta uzantısı girin.");
                return;
            }

            if (sifre.Length < 8 || sifreTekrar.Length < 8)
            {
                MessageBox.Show("Şifreniz en az 8 karakter olmalı!");
                return;
            }

            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Şifreler uyuşmuyor!");
                return;
            }

            string dogrulamaKodu = new Random().Next(100000, 999999).ToString();
            SendVerificationCode(email, dogrulamaKodu);

            VerificationForm verificationForm = new VerificationForm(email, dogrulamaKodu);
            var sonuc = verificationForm.ShowDialog();

            if (sonuc == DialogResult.OK)
            {
                string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();

                        string kontrolQuery = "SELECT * FROM kullanicilar WHERE email = @e";
                        MySqlCommand kontrolCmd = new MySqlCommand(kontrolQuery, conn);
                        kontrolCmd.Parameters.AddWithValue("@e", email);
                        var reader = kontrolCmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            MessageBox.Show("Bu e-posta zaten kayıtlı!");
                            return;
                        }
                        reader.Close();

                        string insertQuery = "INSERT INTO kullanicilar (email, sifre, kad, telefon) VALUES (@e, @s, @k, @t)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@e", email);
                        insertCmd.Parameters.AddWithValue("@s", sifre);
                        insertCmd.Parameters.AddWithValue("@k", kad);
                        insertCmd.Parameters.AddWithValue("@t", telefon);
                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarılı!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }

            // Temizle
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox3.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            button2.Visible = false;
            label2.Left = 62;
            label2.Top = 156;
            label4.Visible = true;

            textBox2.Left = 62;
            textBox2.Top = 179;
            checkBox1.Left = 366;
            checkBox1.Top = 182;
            button1.Visible = true;
            comboBox1.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox3.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            button2.Visible = false;
            label2.Left = 62;
            label2.Top = 156;

            textBox2.Left = 62;
            textBox2.Top = 179;
            checkBox1.Left = 366;
            checkBox1.Top = 182;

            button1.Visible = true;
            comboBox1.Visible = true;
            label4.Visible = true;
            label8.Visible = false;
        }
    }
}




