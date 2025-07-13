using System;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace muzyu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string email = null;
            if (File.Exists("MuZyuOturum.txt"))
            {
                email = File.ReadAllText("MuZyuOturum.txt").Trim();
            }

            if (!string.IsNullOrEmpty(email))
            {
                string kullaniciAdi = null;
                string connStr = "server=localhost;user=root;database=muzyu;port=3306;password=12345678;";

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "SELECT kad FROM kullanicilar WHERE email = @e";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@e", email);

                        var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            kullaniciAdi = reader["kad"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Baðlantý hatasý: " + ex.Message);
                }

                if (!string.IsNullOrEmpty(kullaniciAdi))
                {
                    Application.Run(new Anasayfa(kullaniciAdi));
                    return; // Oturum açýldý, uygulama Anasayfa ile baþlasýn
                }
            }

            // Oturum yoksa login formunu aç
            Application.Run(new Form1());
        }
    }
}
