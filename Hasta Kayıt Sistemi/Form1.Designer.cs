namespace Hasta_Kayıt_Sistemi
{
    partial class secimPaneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(secimPaneli));
            doktorGiris = new Button();
            hastaGiris = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // doktorGiris
            // 
            doktorGiris.BackColor = Color.White;
            doktorGiris.ForeColor = Color.FromArgb(44, 62, 80);
            doktorGiris.Location = new Point(12, 141);
            doktorGiris.Name = "doktorGiris";
            doktorGiris.Size = new Size(238, 60);
            doktorGiris.TabIndex = 1;
            doktorGiris.Text = "Doktor Girişi";
            doktorGiris.UseVisualStyleBackColor = false;
            doktorGiris.Click += doktorGiris_Click_1;
            // 
            // hastaGiris
            // 
            hastaGiris.BackColor = Color.White;
            hastaGiris.ForeColor = Color.FromArgb(44, 62, 80);
            hastaGiris.Location = new Point(352, 141);
            hastaGiris.Name = "hastaGiris";
            hastaGiris.Size = new Size(238, 60);
            hastaGiris.TabIndex = 2;
            hastaGiris.Text = "Hasta Girişi";
            hastaGiris.UseVisualStyleBackColor = false;
            hastaGiris.Click += hastaGiris_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(244, 245, 249);
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(125, 36);
            label1.Name = "label1";
            label1.Size = new Size(350, 32);
            label1.TabIndex = 0;
            label1.Text = "Hasta Takip ve Randevu Sistemi";
            label1.Click += label1_Click;
            // 
            // secimPaneli
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 249);
            ClientSize = new Size(611, 387);
            Controls.Add(label1);
            Controls.Add(hastaGiris);
            Controls.Add(doktorGiris);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "secimPaneli";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hasta Takip & Randevu Sistemi";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button doktorGiris;
        private Button hastaGiris;
        private Label label1;
    }
}
