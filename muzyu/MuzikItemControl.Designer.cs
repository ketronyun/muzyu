namespace muzyu
{
    partial class MuzikItemControl
    {
        private PictureBox pictureBoxKapak;
        private Label lblBaslik;
        private Label lblSanatci;

        private void InitializeComponent()
        {
            this.pictureBoxKapak = new PictureBox();
            this.lblBaslik = new Label();
            this.lblSanatci = new Label();

            // ---- MuzikItemControl Ayarları ----
            this.Size = new Size(400, 80); // ✅ Sabit boyut ver
            this.BackColor = Color.Red;
            this.Margin = new Padding(0);
            this.Padding = new Padding(5);

            // ---- pictureBoxKapak ----
            this.pictureBoxKapak.Location = new Point(10, 10);
            this.pictureBoxKapak.Size = new Size(60, 60);
            this.pictureBoxKapak.SizeMode = PictureBoxSizeMode.Zoom;

            // ---- lblBaslik ----
            this.lblBaslik.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.White;
            this.lblBaslik.Location = new Point(80, 10);
            this.lblBaslik.AutoSize = true;

            // ---- lblSanatci ----
            this.lblSanatci.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblSanatci.ForeColor = Color.White;
            this.lblSanatci.Location = new Point(80, 35);
            this.lblSanatci.AutoSize = true;

            // ---- Controls Ekle ----
            this.Controls.Add(this.pictureBoxKapak);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.lblSanatci);
        }
    }
}
