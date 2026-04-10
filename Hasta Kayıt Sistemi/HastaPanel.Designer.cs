namespace Hasta_Kayıt_Sistemi
{
    partial class HastaPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HastaPanel));
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(185, 31);
            label1.Name = "label1";
            label1.Size = new Size(160, 32);
            label1.TabIndex = 0;
            label1.Text = "Hoş Geldiniz, ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(185, 79);
            label2.Name = "label2";
            label2.Size = new Size(176, 25);
            label2.TabIndex = 1;
            label2.Text = "Hasta Yönetim Paneli";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources.Hasta_Logo;
            pictureBox1.Image = Properties.Resources.Hasta_Logo;
            pictureBox1.InitialImage = Properties.Resources.Hasta_Logo;
            pictureBox1.Location = new Point(46, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(116, 106);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.ForeColor = Color.FromArgb(44, 62, 80);
            button1.Location = new Point(46, 284);
            button1.Name = "button1";
            button1.Size = new Size(168, 51);
            button1.TabIndex = 3;
            button1.Text = "Doktor Bilgi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.FromArgb(44, 62, 80);
            button2.Location = new Point(46, 398);
            button2.Name = "button2";
            button2.Size = new Size(168, 51);
            button2.TabIndex = 4;
            button2.Text = "Duyuru";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.ForeColor = Color.FromArgb(44, 62, 80);
            button3.Location = new Point(46, 152);
            button3.Name = "button3";
            button3.Size = new Size(168, 60);
            button3.TabIndex = 5;
            button3.Text = "Randevu Oluşturma";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.ForeColor = Color.FromArgb(44, 62, 80);
            button4.Location = new Point(46, 341);
            button4.Name = "button4";
            button4.Size = new Size(168, 51);
            button4.TabIndex = 10;
            button4.Text = "Mesajlar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(44, 62, 80);
            label3.Location = new Point(246, 137);
            label3.Name = "label3";
            label3.Size = new Size(136, 25);
            label3.TabIndex = 11;
            label3.Text = "Son Randevular";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(246, 174);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(660, 185);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(44, 62, 80);
            label4.Location = new Point(246, 370);
            label4.Name = "label4";
            label4.Size = new Size(171, 25);
            label4.TabIndex = 13;
            label4.Text = "Yaklaşan Randevular";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(246, 398);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(660, 178);
            dataGridView2.TabIndex = 14;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // button5
            // 
            button5.ForeColor = Color.FromArgb(44, 62, 80);
            button5.Location = new Point(46, 218);
            button5.Name = "button5";
            button5.Size = new Size(168, 60);
            button5.TabIndex = 15;
            button5.Text = "Randevu ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // HastaPanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 249);
            ClientSize = new Size(1006, 643);
            Controls.Add(button5);
            Controls.Add(dataGridView2);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HastaPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hasta Takip & Randevu Sistemi";
            Load += HastaPanel_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label3;
        private DataGridView dataGridView1;
        private Label label4;
        private DataGridView dataGridView2;
        private Button button5;
    }
}