namespace Hasta_Kayıt_Sistemi
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            label2 = new Label();
            button3 = new Button();
            lblDoctor = new Label();
            button2 = new Button();
            comboBranch = new ComboBox();
            label4 = new Label();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label5 = new Label();
            comboBox2 = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(392, 45);
            label1.Name = "label1";
            label1.Size = new Size(192, 32);
            label1.TabIndex = 1;
            label1.Text = "Randevu Oluştur";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(990, 655);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(lblDoctor);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(comboBranch);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(128, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(720, 395);
            panel2.TabIndex = 11;
            // 
            // comboBox1
            // 
            comboBox1.ForeColor = Color.FromArgb(44, 62, 80);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(416, 196);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.FromArgb(44, 62, 80);
            label2.Location = new Point(410, 157);
            label2.Name = "label2";
            label2.Size = new Size(46, 25);
            label2.TabIndex = 13;
            label2.Text = "Saat";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(31, 111, 235);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(581, 351);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 11;
            button3.Text = "Onayla";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.BackColor = Color.White;
            lblDoctor.Font = new Font("Segoe UI", 9F);
            lblDoctor.ForeColor = Color.FromArgb(44, 62, 80);
            lblDoctor.Location = new Point(0, 29);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(101, 25);
            lblDoctor.TabIndex = 3;
            lblDoctor.Text = "Branş Seçin";
            // 
            // button2
            // 
            button2.ForeColor = Color.FromArgb(44, 62, 80);
            button2.Location = new Point(416, 351);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 10;
            button2.Text = "İptal Et";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBranch
            // 
            comboBranch.ForeColor = Color.FromArgb(44, 62, 80);
            comboBranch.FormattingEnabled = true;
            comboBranch.Location = new Point(0, 57);
            comboBranch.Name = "comboBranch";
            comboBranch.Size = new Size(182, 33);
            comboBranch.TabIndex = 4;
            comboBranch.SelectedIndexChanged += comboBranch_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 9F);
            label4.ForeColor = Color.FromArgb(44, 62, 80);
            label4.Location = new Point(416, 29);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 8;
            label4.Text = "Tarih";
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.FromArgb(44, 62, 80);
            textBox1.Location = new Point(3, 232);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(317, 153);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.AllowDrop = true;
            dateTimePicker1.CalendarForeColor = Color.FromArgb(44, 62, 80);
            dateTimePicker1.CalendarTitleForeColor = Color.FromArgb(44, 62, 80);
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(416, 59);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(277, 31);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2026, 1, 7, 22, 6, 4, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = Color.FromArgb(44, 62, 80);
            label3.Location = new Point(0, 204);
            label3.Name = "label3";
            label3.Size = new Size(42, 25);
            label3.TabIndex = 6;
            label3.Text = "Not";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 9F);
            label5.ForeColor = Color.FromArgb(44, 62, 80);
            label5.Location = new Point(0, 109);
            label5.Name = "label5";
            label5.Size = new Size(114, 25);
            label5.TabIndex = 15;
            label5.Text = "Doktor Seçin";
            // 
            // comboBox2
            // 
            comboBox2.ForeColor = Color.FromArgb(44, 62, 80);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(0, 149);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 16;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // Form10
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 249);
            ClientSize = new Size(990, 655);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form10";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hasta Takip & Randevu Sistemi";
            Load += Form10_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label lblDoctor;
        private Button button2;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBranch;
        private Panel panel2;
        private Button button3;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Label label5;
    }
}