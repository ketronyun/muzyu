namespace muzyu
{
    partial class PlayerControl
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

        #region Bileşen Tasarım Kodu

        private void InitializeComponent()
        {
            mainLayout = new TableLayoutPanel();
            leftPanel = new Panel();
            picAlbumCover = new PictureBox();
            lblTitle = new Label();
            lblArtist = new Label();
            centerPanel = new Panel();
            centerLayout = new TableLayoutPanel();
            trackBarProgress = new TrackBar();
            buttonPanel = new TableLayoutPanel();
            btnPrevious = new Button();
            btnPlayPause = new Button();
            btnNext = new Button();
            rightPanel = new Panel();
            trackBarVolume = new TrackBar();
            mainLayout.SuspendLayout();
            leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAlbumCover).BeginInit();
            centerPanel.SuspendLayout();
            centerLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarProgress).BeginInit();
            buttonPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 3;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            mainLayout.Controls.Add(leftPanel, 0, 0);
            mainLayout.Controls.Add(centerPanel, 1, 0);
            mainLayout.Controls.Add(rightPanel, 2, 0);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 1;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(1000, 100);
            mainLayout.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.Transparent;
            leftPanel.Controls.Add(picAlbumCover);
            leftPanel.Controls.Add(lblTitle);
            leftPanel.Controls.Add(lblArtist);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(3, 3);
            leftPanel.Name = "leftPanel";
            leftPanel.Padding = new Padding(10);
            leftPanel.Size = new Size(294, 94);
            leftPanel.TabIndex = 0;
            // 
            // picAlbumCover
            // 
            picAlbumCover.Location = new Point(10, 10);
            picAlbumCover.Name = "picAlbumCover";
            picAlbumCover.Size = new Size(60, 60);
            picAlbumCover.SizeMode = PictureBoxSizeMode.StretchImage;
            picAlbumCover.TabIndex = 0;
            picAlbumCover.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(80, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(109, 23);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Şarkı Başlığı";
            // 
            // lblArtist
            // 
            lblArtist.AutoSize = true;
            lblArtist.Font = new Font("Segoe UI", 9F);
            lblArtist.Location = new Point(80, 35);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(57, 20);
            lblArtist.TabIndex = 2;
            lblArtist.Text = "Sanatçı";
            // 
            // centerPanel
            // 
            centerPanel.BackColor = Color.Transparent;
            centerPanel.Controls.Add(centerLayout);
            centerPanel.Dock = DockStyle.Fill;
            centerPanel.Location = new Point(303, 3);
            centerPanel.Name = "centerPanel";
            centerPanel.Size = new Size(394, 94);
            centerPanel.TabIndex = 1;
            // 
            // centerLayout
            // 
            centerLayout.BackColor = Color.Transparent;
            centerLayout.ColumnCount = 1;
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            centerLayout.Controls.Add(trackBarProgress, 0, 0);
            centerLayout.Controls.Add(buttonPanel, 0, 1);
            centerLayout.Dock = DockStyle.Fill;
            centerLayout.Location = new Point(0, 0);
            centerLayout.Name = "centerLayout";
            centerLayout.RowCount = 3;
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 6F));
            centerLayout.Size = new Size(394, 94);
            centerLayout.TabIndex = 0;
            // 
            // trackBarProgress
            // 
            trackBarProgress.Dock = DockStyle.Fill;
            trackBarProgress.Location = new Point(3, 3);
            trackBarProgress.Name = "trackBarProgress";
            trackBarProgress.Size = new Size(388, 14);
            trackBarProgress.TabIndex = 0;
            trackBarProgress.TickStyle = TickStyle.None;
            // 
            // buttonPanel
            // 
            buttonPanel.Anchor = AnchorStyles.None;
            buttonPanel.AutoSize = true;
            buttonPanel.BackColor = Color.Transparent;
            buttonPanel.ColumnCount = 3;
            buttonPanel.ColumnStyles.Add(new ColumnStyle());
            buttonPanel.ColumnStyles.Add(new ColumnStyle());
            buttonPanel.ColumnStyles.Add(new ColumnStyle());
            buttonPanel.Controls.Add(btnPrevious, 0, 0);
            buttonPanel.Controls.Add(btnPlayPause, 1, 0);
            buttonPanel.Controls.Add(btnNext, 2, 0);
            buttonPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            buttonPanel.Location = new Point(113, 38);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.RowCount = 1;
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            buttonPanel.Size = new Size(168, 20);
            buttonPanel.TabIndex = 1;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.Transparent;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Location = new Point(3, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(50, 50);
            btnPrevious.TabIndex = 0;
            btnPrevious.Text = "⏮";
            btnPrevious.UseVisualStyleBackColor = false;
            // 
            // btnPlayPause
            // 
            btnPlayPause.BackColor = Color.Transparent;
            btnPlayPause.FlatAppearance.BorderSize = 0;
            btnPlayPause.FlatStyle = FlatStyle.Flat;
            btnPlayPause.Location = new Point(59, 3);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(50, 50);
            btnPlayPause.TabIndex = 1;
            btnPlayPause.Text = "▶️";
            btnPlayPause.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Location = new Point(115, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(50, 50);
            btnNext.TabIndex = 2;
            btnNext.Text = "⏭";
            btnNext.UseVisualStyleBackColor = false;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.Transparent;
            rightPanel.Controls.Add(trackBarVolume);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(703, 3);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(10);
            rightPanel.Size = new Size(294, 94);
            rightPanel.TabIndex = 2;
            // 
            // trackBarVolume
            // 
            trackBarVolume.BackColor = Color.FromArgb(64, 64, 64);
            trackBarVolume.Dock = DockStyle.Right;
            trackBarVolume.Location = new Point(184, 10);
            trackBarVolume.Maximum = 100;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(100, 74);
            trackBarVolume.TabIndex = 0;
            trackBarVolume.TickStyle = TickStyle.None;
            trackBarVolume.Value = 50;
            // 
            // PlayerControl
            // 
            BackColor = Color.Transparent;
            Controls.Add(mainLayout);
            Name = "PlayerControl";
            Size = new Size(1000, 100);
            mainLayout.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAlbumCover).EndInit();
            centerPanel.ResumeLayout(false);
            centerLayout.ResumeLayout(false);
            centerLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarProgress).EndInit();
            buttonPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private Panel leftPanel;
        private Panel centerPanel;
        private Panel rightPanel;

        private PictureBox picAlbumCover;
        private Label lblTitle;
        private Label lblArtist;

        private Button btnPlayPause;
        private Button btnNext;
        private Button btnPrevious;

        private TrackBar trackBarProgress;
        private TrackBar trackBarVolume;
        private TableLayoutPanel centerLayout;
        private TableLayoutPanel buttonPanel;
    }
}
