namespace muzyu
{
    partial class Anasayfa
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            pnlMenu = new Panel();
            btnMenu = new Button();
            btnCikis = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = SystemColors.ActiveCaption;
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(193, 450);
            pnlMenu.TabIndex = 0;
            // 
            // btnMenu
            // 
            btnMenu.Location = new Point(756, 54);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(32, 29);
            btnMenu.TabIndex = 1;
            btnMenu.Text = "button1";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnCikis
            // 
            btnCikis.Location = new Point(694, 409);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(94, 29);
            btnCikis.TabIndex = 2;
            btnCikis.Text = "button1";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(199, 9);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkMagenta;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(193, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(607, 48);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Anasayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnMenu);
            Controls.Add(btnCikis);
            Controls.Add(pictureBox1);
            Controls.Add(pnlMenu);
            Name = "Anasayfa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anasayfa";
            Load += Anasayfa_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Panel pnlMenu;
        private Button btnMenu;
        private Button btnCikis;
        private Label label1;
        private PictureBox pictureBox1;
    }
}