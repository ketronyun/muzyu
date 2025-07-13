namespace muzyu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 122);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(62, 179);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(298, 27);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(62, 365);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(298, 27);
            textBox3.TabIndex = 2;
            textBox3.Visible = false;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(366, 122);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(128, 28);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDark;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(62, 99);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 4;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDark;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(62, 156);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 5;
            label2.Text = "Parola";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlDark;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(62, 342);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 6;
            label3.Text = "Parola Kontrol";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlDark;
            label4.ForeColor = Color.MediumBlue;
            label4.Location = new Point(62, 209);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 7;
            label4.Text = "Kayıt ol";
            label4.Click += label4_Click;
            label4.MouseLeave += label4_MouseLeave;
            label4.MouseMove += label4_MouseMove;
            // 
            // button1
            // 
            button1.Location = new Point(128, 453);
            button1.Name = "button1";
            button1.Size = new Size(260, 79);
            button1.TabIndex = 8;
            button1.Text = "Giriş yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(128, 453);
            button2.Name = "button2";
            button2.Size = new Size(260, 79);
            button2.TabIndex = 9;
            button2.Text = "Onayla";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = SystemColors.ControlDark;
            checkBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            checkBox1.Location = new Point(366, 182);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(106, 24);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDark;
            pictureBox1.Location = new Point(24, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(482, 465);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(504, 2);
            button3.Name = "button3";
            button3.Size = new Size(30, 29);
            button3.TabIndex = 12;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("New Rocker", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Indigo;
            label5.Location = new Point(190, 18);
            label5.Name = "label5";
            label5.Size = new Size(144, 45);
            label5.TabIndex = 13;
            label5.Text = "MuZyu";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(62, 252);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(298, 27);
            textBox4.TabIndex = 14;
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(62, 312);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(298, 27);
            textBox5.TabIndex = 15;
            textBox5.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlDark;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(62, 229);
            label6.Name = "label6";
            label6.Size = new Size(96, 20);
            label6.TabIndex = 16;
            label6.Text = "Kullanıcı Adı";
            label6.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ControlDark;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(62, 289);
            label7.Name = "label7";
            label7.Size = new Size(133, 20);
            label7.TabIndex = 17;
            label7.Text = "Telefon Numarası";
            label7.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlDark;
            label8.Location = new Point(65, 395);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 18;
            label8.Text = "Geri";
            label8.Visible = false;
            label8.Click += label8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(536, 560);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Muzyu";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private Button button3;
        private Label label5;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}
