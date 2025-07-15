namespace muzyu
{
    partial class eklemüzik
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblBaslik = new Label();
            txtBaslik = new TextBox();
            btnGözat = new Button();
            cmbKategori = new ComboBox();
            lblDosya = new Label();
            txtDosyaYolu = new TextBox();
            lblKategori = new Label();
            txtSanatci = new TextBox();
            lblSanatci = new Label();
            lblSure = new Label();
            txtSure = new TextBox();
            btnEkle = new Button();
            txtAlbum = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Location = new Point(94, 67);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(47, 20);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Başlık";
            // 
            // txtBaslik
            // 
            txtBaslik.Location = new Point(94, 90);
            txtBaslik.Name = "txtBaslik";
            txtBaslik.Size = new Size(125, 27);
            txtBaslik.TabIndex = 1;
            // 
            // btnGözat
            // 
            btnGözat.Location = new Point(94, 176);
            btnGözat.Name = "btnGözat";
            btnGözat.Size = new Size(94, 29);
            btnGözat.TabIndex = 2;
            btnGözat.Text = "Göz At";
            btnGözat.UseVisualStyleBackColor = true;
            btnGözat.Click += btnGözat_Click;
            // 
            // cmbKategori
            // 
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(94, 231);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(151, 28);
            cmbKategori.TabIndex = 3;
            // 
            // lblDosya
            // 
            lblDosya.AutoSize = true;
            lblDosya.Location = new Point(94, 120);
            lblDosya.Name = "lblDosya";
            lblDosya.Size = new Size(82, 20);
            lblDosya.TabIndex = 4;
            lblDosya.Text = "Dosya yolu";
            // 
            // txtDosyaYolu
            // 
            txtDosyaYolu.AllowDrop = true;
            txtDosyaYolu.Location = new Point(94, 143);
            txtDosyaYolu.Name = "txtDosyaYolu";
            txtDosyaYolu.Size = new Size(125, 27);
            txtDosyaYolu.TabIndex = 5;
            // 
            // lblKategori
            // 
            lblKategori.AutoSize = true;
            lblKategori.Location = new Point(94, 208);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(66, 20);
            lblKategori.TabIndex = 6;
            lblKategori.Text = "Kategori";
            // 
            // txtSanatci
            // 
            txtSanatci.Location = new Point(94, 285);
            txtSanatci.Name = "txtSanatci";
            txtSanatci.Size = new Size(125, 27);
            txtSanatci.TabIndex = 7;
            // 
            // lblSanatci
            // 
            lblSanatci.AutoSize = true;
            lblSanatci.Location = new Point(94, 262);
            lblSanatci.Name = "lblSanatci";
            lblSanatci.Size = new Size(55, 20);
            lblSanatci.TabIndex = 8;
            lblSanatci.Text = "sanatçı";
            // 
            // lblSure
            // 
            lblSure.AutoSize = true;
            lblSure.Location = new Point(94, 315);
            lblSure.Name = "lblSure";
            lblSure.Size = new Size(36, 20);
            lblSure.TabIndex = 9;
            lblSure.Text = "süre";
            // 
            // txtSure
            // 
            txtSure.Location = new Point(94, 338);
            txtSure.Name = "txtSure";
            txtSure.Size = new Size(125, 27);
            txtSure.TabIndex = 10;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(94, 371);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 29);
            btnEkle.TabIndex = 11;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // txtAlbum
            // 
            txtAlbum.Location = new Point(94, 37);
            txtAlbum.Name = "txtAlbum";
            txtAlbum.Size = new Size(125, 27);
            txtAlbum.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 16);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 13;
            label1.Text = "album adı";
            // 
            // eklemüzik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 576);
            Controls.Add(label1);
            Controls.Add(txtAlbum);
            Controls.Add(btnEkle);
            Controls.Add(txtSure);
            Controls.Add(lblSure);
            Controls.Add(lblSanatci);
            Controls.Add(txtSanatci);
            Controls.Add(lblKategori);
            Controls.Add(txtDosyaYolu);
            Controls.Add(lblDosya);
            Controls.Add(cmbKategori);
            Controls.Add(btnGözat);
            Controls.Add(txtBaslik);
            Controls.Add(lblBaslik);
            Name = "eklemüzik";
            Text = "eklemüzik";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBaslik;
        private TextBox txtBaslik;
        private Button btnGözat;
        private ComboBox cmbKategori;
        private Label lblDosya;
        private TextBox txtDosyaYolu;
        private Label lblKategori;
        private TextBox txtSanatci;
        private Label lblSanatci;
        private Label lblSure;
        private TextBox txtSure;
        private Button btnEkle;
        private TextBox txtAlbum;
        private Label label1;
    }
}