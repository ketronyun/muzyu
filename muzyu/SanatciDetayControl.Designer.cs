namespace muzyu
{
    partial class SanatciDetayControl
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private PictureBox pictureBoxArka;
        private Label lblSanatciAdi;
        private Panel panelSarkilar;
        private TableLayoutPanel sarkiListesiWrapper;
        private TableLayoutPanel tableSarkiListesi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.mainLayout = new TableLayoutPanel();
            this.pictureBoxArka = new PictureBox();
            this.lblSanatciAdi = new Label();
            this.panelSarkilar = new Panel();
            this.sarkiListesiWrapper = new TableLayoutPanel();
            this.tableSarkiListesi = new TableLayoutPanel();

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.pictureBoxArka, 0, 0);
            this.mainLayout.Controls.Add(this.lblSanatciAdi, 0, 1);
            this.mainLayout.Controls.Add(this.panelSarkilar, 0, 2);
            this.mainLayout.BackColor = Color.White;
            this.mainLayout.Padding = new Padding(0);
            this.mainLayout.Margin = new Padding(0);

            // pictureBoxArka
            this.pictureBoxArka.Dock = DockStyle.Fill;
            this.pictureBoxArka.SizeMode = PictureBoxSizeMode.Zoom;

            // lblSanatciAdi
            this.lblSanatciAdi.Dock = DockStyle.Fill;
            this.lblSanatciAdi.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSanatciAdi.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblSanatciAdi.Text = "Sanatçı Adı";

            // panelSarkilar
            this.panelSarkilar.Dock = DockStyle.Fill;
            this.panelSarkilar.AutoScroll = true;
            this.panelSarkilar.Padding = new Padding(0);
            this.panelSarkilar.Margin = new Padding(0);
            this.panelSarkilar.Controls.Add(this.sarkiListesiWrapper);

            // sarkiListesiWrapper
            this.sarkiListesiWrapper.Dock = DockStyle.Top;
            this.sarkiListesiWrapper.AutoSize = true;
            this.sarkiListesiWrapper.Margin = new Padding(0);
            this.sarkiListesiWrapper.Padding = new Padding(0);
            this.sarkiListesiWrapper.ColumnCount = 3;
            this.sarkiListesiWrapper.ColumnStyles.Clear();
            this.sarkiListesiWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.sarkiListesiWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.sarkiListesiWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.sarkiListesiWrapper.Controls.Add(this.tableSarkiListesi, 1, 0);

            // tableSarkiListesi
            this.tableSarkiListesi.AutoSize = true;
            this.tableSarkiListesi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tableSarkiListesi.Dock = DockStyle.Top;
            this.tableSarkiListesi.Margin = new Padding(0);
            this.tableSarkiListesi.Padding = new Padding(0);
            this.tableSarkiListesi.ColumnCount = 1;
            this.tableSarkiListesi.ColumnStyles.Clear();
            this.tableSarkiListesi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableSarkiListesi.RowCount = 0;

            // UserControl
            this.Controls.Add(this.mainLayout);
            this.Name = "SanatciDetayControl";
            this.Size = new Size(600, 600);
        }


    }
}
