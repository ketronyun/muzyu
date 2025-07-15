namespace muzyu
{
    partial class Anasayfa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            pnlMenu = new Panel();
            button2 = new Button();
            btnCikis = new Button();
            label1 = new Label();
            panel1 = new Panel();
            flowPanelMuzikler = new FlowLayoutPanel();
            panelOrta = new Panel();
            panelArama = new Panel();
            txtArama = new TextBox();
            btnAra = new Button();
            btnMenu = new Button();
            pnlMenu.SuspendLayout();
            panelArama.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.Gray;
            pnlMenu.Controls.Add(button2);
            pnlMenu.Controls.Add(btnCikis);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(187, 562);
            pnlMenu.TabIndex = 0;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Bottom;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.Location = new Point(0, 475);
            button2.Name = "button2";
            button2.Size = new Size(187, 46);
            button2.TabIndex = 3;
            button2.Text = "Şarkı ekle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnCikis
            // 
            btnCikis.Dock = DockStyle.Bottom;
            btnCikis.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCikis.Location = new Point(0, 521);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(187, 41);
            btnCikis.TabIndex = 2;
            btnCikis.Text = "Çıkış Yap";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LawnGreen;
            label1.Location = new Point(61, 15);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(187, 502);
            panel1.Name = "panel1";
            panel1.Size = new Size(1294, 60);
            panel1.TabIndex = 6;
            // 
            // flowPanelMuzikler
            // 
            flowPanelMuzikler.AutoScroll = true;
            flowPanelMuzikler.Dock = DockStyle.Right;
            flowPanelMuzikler.FlowDirection = FlowDirection.TopDown;
            flowPanelMuzikler.Location = new Point(1187, 0);
            flowPanelMuzikler.Name = "flowPanelMuzikler";
            flowPanelMuzikler.Size = new Size(294, 502);
            flowPanelMuzikler.TabIndex = 8;
            flowPanelMuzikler.WrapContents = false;
            // 
            // panelOrta
            // 
            panelOrta.BackColor = Color.White;
            panelOrta.Dock = DockStyle.Fill;
            panelOrta.Location = new Point(187, 56);
            panelOrta.Name = "panelOrta";
            panelOrta.Size = new Size(1000, 446);
            panelOrta.TabIndex = 11;
            // 
            // panelArama
            // 
            panelArama.BackColor = Color.LawnGreen;
            panelArama.Controls.Add(label1);
            panelArama.Controls.Add(txtArama);
            panelArama.Controls.Add(btnAra);
            panelArama.Dock = DockStyle.Top;
            panelArama.Location = new Point(187, 0);
            panelArama.Name = "panelArama";
            panelArama.Size = new Size(1000, 56);
            panelArama.TabIndex = 0;
            // 
            // txtArama
            // 
            txtArama.Anchor = AnchorStyles.None;
            txtArama.Location = new Point(246, 12);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(388, 27);
            txtArama.TabIndex = 9;
            txtArama.TextChanged += txtArama_TextChanged;
            // 
            // btnAra
            // 
            btnAra.Anchor = AnchorStyles.None;
            btnAra.Location = new Point(640, 12);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(94, 27);
            btnAra.TabIndex = 10;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // btnMenu
            // 
            btnMenu.Location = new Point(218, 92);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(60, 60);
            btnMenu.TabIndex = 77;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // Anasayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1481, 562);
            Controls.Add(panelOrta);
            Controls.Add(btnMenu);
            Controls.Add(panelArama);
            Controls.Add(flowPanelMuzikler);
            Controls.Add(panel1);
            Controls.Add(pnlMenu);
            ForeColor = SystemColors.ControlText;
            Name = "Anasayfa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anasayfa";
            WindowState = FormWindowState.Maximized;
            Load += Anasayfa_Load;
            pnlMenu.ResumeLayout(false);
            panelArama.ResumeLayout(false);
            panelArama.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Panel pnlMenu;
        private Button btnCikis;
        private Label label1;
        private Panel panel1;
        private Button button2;
        private FlowLayoutPanel flowPanelMuzikler;
        private Panel panelOrta;
        private TextBox txtArama;
        private Button btnAra;
        private PictureBox pictureBox1;
        private Panel panelArama;
        private Button btnMenu;
        // 🔥 btnMenu tamamen kaldırıldı.
    }
}
