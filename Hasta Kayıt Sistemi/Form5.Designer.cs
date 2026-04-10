namespace Hasta_Kayıt_Sistemi
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            label1 = new Label();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(185, 79);
            label1.Name = "label1";
            label1.Size = new Size(187, 25);
            label1.TabIndex = 0;
            label1.Text = "Doktor Yönetim Paneli";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(185, 31);
            label2.Name = "label2";
            label2.Size = new Size(183, 32);
            label2.TabIndex = 1;
            label2.Text = "Hoş geldiniz Dr.";
            label2.Click += label2_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(button5, 0, 3);
            tableLayoutPanel1.Controls.Add(button4, 0, 2);
            tableLayoutPanel1.Controls.Add(button3, 0, 1);
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Location = new Point(43, 145);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.09375F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.90625F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 302F));
            tableLayoutPanel1.Size = new Size(174, 489);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // button5
            // 
            button5.ForeColor = Color.FromArgb(44, 62, 80);
            button5.Location = new Point(3, 189);
            button5.Name = "button5";
            button5.Size = new Size(168, 58);
            button5.TabIndex = 3;
            button5.Text = "Duyurular";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.ForeColor = Color.FromArgb(44, 62, 80);
            button4.Location = new Point(3, 126);
            button4.Name = "button4";
            button4.Size = new Size(168, 57);
            button4.TabIndex = 2;
            button4.Text = "Mesajlar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.ForeColor = Color.FromArgb(44, 62, 80);
            button3.Location = new Point(3, 60);
            button3.Name = "button3";
            button3.Size = new Size(168, 58);
            button3.TabIndex = 1;
            button3.Text = "Randevu Listeleme";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.FromArgb(44, 62, 80);
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(168, 51);
            button2.TabIndex = 0;
            button2.Text = "Yeni Hasta Kayıt";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = Color.FromArgb(44, 62, 80);
            label3.Location = new Point(246, 137);
            label3.Name = "label3";
            label3.Size = new Size(109, 25);
            label3.TabIndex = 5;
            label3.Text = "Hasta Listesi";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.ForeColor = Color.FromArgb(44, 62, 80);
            label4.Location = new Point(246, 405);
            label4.Name = "label4";
            label4.Size = new Size(136, 25);
            label4.TabIndex = 6;
            label4.Text = "Son Randevular";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(246, 433);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(785, 201);
            dataGridView1.TabIndex = 7;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(246, 165);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(785, 227);
            dataGridView2.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources.Doktor_Logo;
            pictureBox1.ImageLocation = "\"C:\\Users\\Geschirr\\Pictures\\Resimler\\Doktor Logo.jpg\"";
            pictureBox1.InitialImage = Properties.Resources.Doktor_Logo;
            pictureBox1.Location = new Point(46, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(116, 106);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 249);
            ClientSize = new Size(1085, 705);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hasta Takip & Randevu Sistemi";
            Load += Form5_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button2;
        private Button button4;
        private Button button3;
        private Button button5;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private PictureBox pictureBox1;
    }
}