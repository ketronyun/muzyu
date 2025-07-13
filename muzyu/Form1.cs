using System;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
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

            comboBox1.Text = "Se�iniz...";
            comboBox1.Items.Add("@hotmail.com");
            comboBox1.Items.Add("@gmail.com");


            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            //======================================================================
            //======================     Sql baglant�      =========================
            //======================================================================
            string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MessageBox.Show("Ba�lant� ba�ar�l�!");
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
                //karakteri g�ster.
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            //de�ilse karakterlerin yerine * koy.
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TextChanged olay�n� ge�ici olarak devre d��� b�rak
            textBox1.TextChanged -= textBox1_TextChanged;

            // @hotmail veya @gmail zaten eklenmi�se, i�lem yapma
            if (textBox1.Text.Contains("@hotmail") || textBox1.Text.Contains("@gmail"))
            {
                // TextChanged olay�n� yeniden etkinle�tir
                textBox1.TextChanged += textBox1_TextChanged;
                return; // ��lem yap�lmadan ��k
            }

            if (textBox1.Text.Contains("@hot"))
            {
                // @hot k�sm�n� bul ve tamamla
                textBox1.Text = textBox1.Text.Replace("@hot", "@hotmail.com");
                comboBox1.Visible = false;
                comboBox1.SelectedIndex = 0;
            }
            else if (textBox1.Text.Contains("@g"))
            {
                // @g k�sm�n� bul ve tamamla
                textBox1.Text = textBox1.Text.Replace("@g", "@gmail.com");
                comboBox1.Visible = false;
                comboBox1.SelectedIndex = 1;
            }

            // TextChanged olay�n� yeniden etkinle�tir
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TextChanged olay�n� ge�ici olarak devre d��� b�rak
            textBox1.TextChanged -= textBox1_TextChanged;

            if (comboBox1.SelectedItem != null && !textBox1.Text.Contains("@"))
            {
                textBox1.Text += comboBox1.SelectedItem.ToString();
                comboBox1.Visible = false;
            }

            // TextChanged olay�n� yeniden ba�la
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
                MessageBox.Show("L�tfen t�m alanlar� doldurun.");
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

                        MessageBox.Show("Giri� ba�ar�l�!");

                        // Oturumu dosyaya yaz 
                        System.IO.File.WriteAllText("MuZyuOturum.txt", email);

                        // Ana sayfaya kullan�c� ad�n� g�nder
                        Anasayfa anasayfa = new Anasayfa(kullaniciAdi);
                        anasayfa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("E-posta veya �ifre hatal�.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();
            string sifreTekrar = textBox3.Text.Trim();
            string kad = textBox4.Text.Trim();       // Kullan�c� ad�
            string telefon = textBox5.Text.Trim();   // Telefon numaras�

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") ||
                string.IsNullOrWhiteSpace(kad) || string.IsNullOrWhiteSpace(telefon))
            {
                MessageBox.Show("L�tfen t�m alanlar� doldurun.");
                return;
            }

            if (!(email.EndsWith("@hotmail.com") || email.EndsWith("@gmail.com")))
            {
                MessageBox.Show("L�tfen ge�erli bir e-posta uzant�s� girin.");
                return;
            }

            if (sifre.Length < 8 || sifreTekrar.Length < 8)
            {
                MessageBox.Show("�ifreniz en az 8 karakter olmal�!");
                return;
            }

            if (sifre != sifreTekrar)
            {
                MessageBox.Show("�ifreler uyu�muyor!");
                return;
            }

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
                        MessageBox.Show("Bu e-posta zaten kay�tl�!");
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

                    MessageBox.Show("Kay�t ba�ar�l�!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
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




