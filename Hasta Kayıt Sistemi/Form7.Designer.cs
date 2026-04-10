namespace Hasta_Kayıt_Sistemi
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            pLeft = new Panel();
            lbPatients = new ListBox();
            lblPatients = new Label();
            pRight = new Panel();
            panel1 = new Panel();
            btnSend = new Button();
            txtMessage = new TextBox();
            txtChatHistory = new TextBox();
            lblChatTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pLeft.SuspendLayout();
            pRight.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(103, 32);
            label1.TabIndex = 0;
            label1.Text = "Mesajlar";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 54);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pLeft);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pRight);
            splitContainer1.Size = new Size(961, 576);
            splitContainer1.SplitterDistance = 260;
            splitContainer1.TabIndex = 1;
            // 
            // pLeft
            // 
            pLeft.Controls.Add(lbPatients);
            pLeft.Controls.Add(lblPatients);
            pLeft.Dock = DockStyle.Fill;
            pLeft.Location = new Point(0, 0);
            pLeft.Name = "pLeft";
            pLeft.Size = new Size(260, 576);
            pLeft.TabIndex = 0;
            // 
            // lbPatients
            // 
            lbPatients.BorderStyle = BorderStyle.None;
            lbPatients.ForeColor = Color.FromArgb(44, 62, 80);
            lbPatients.FormattingEnabled = true;
            lbPatients.Location = new Point(3, 39);
            lbPatients.Name = "lbPatients";
            lbPatients.Size = new Size(254, 525);
            lbPatients.TabIndex = 1;
            // 
            // lblPatients
            // 
            lblPatients.AutoSize = true;
            lblPatients.ForeColor = Color.FromArgb(44, 62, 80);
            lblPatients.Location = new Point(0, 11);
            lblPatients.Name = "lblPatients";
            lblPatients.Size = new Size(76, 25);
            lblPatients.TabIndex = 0;
            lblPatients.Text = "Hastalar";
            // 
            // pRight
            // 
            pRight.BackColor = Color.FromArgb(244, 245, 249);
            pRight.Controls.Add(panel1);
            pRight.Controls.Add(txtChatHistory);
            pRight.Controls.Add(lblChatTitle);
            pRight.Dock = DockStyle.Fill;
            pRight.Location = new Point(0, 0);
            pRight.Name = "pRight";
            pRight.Size = new Size(697, 576);
            pRight.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(txtMessage);
            panel1.Location = new Point(3, 495);
            panel1.Name = "panel1";
            panel1.Size = new Size(691, 81);
            panel1.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(31, 111, 235);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(598, 9);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(90, 60);
            btnSend.TabIndex = 1;
            btnSend.Text = "Gönder";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // txtMessage
            // 
            txtMessage.ForeColor = Color.FromArgb(44, 62, 80);
            txtMessage.Location = new Point(3, 9);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(589, 60);
            txtMessage.TabIndex = 0;
            // 
            // txtChatHistory
            // 
            txtChatHistory.BackColor = Color.White;
            txtChatHistory.BorderStyle = BorderStyle.None;
            txtChatHistory.ForeColor = Color.FromArgb(44, 62, 80);
            txtChatHistory.Location = new Point(3, 39);
            txtChatHistory.Multiline = true;
            txtChatHistory.Name = "txtChatHistory";
            txtChatHistory.ReadOnly = true;
            txtChatHistory.ScrollBars = ScrollBars.Vertical;
            txtChatHistory.Size = new Size(691, 448);
            txtChatHistory.TabIndex = 1;
            // 
            // lblChatTitle
            // 
            lblChatTitle.AutoSize = true;
            lblChatTitle.Font = new Font("Segoe UI", 12F);
            lblChatTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblChatTitle.Location = new Point(3, 5);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(115, 32);
            lblChatTitle.TabIndex = 0;
            lblChatTitle.Text = "Hasta Adı";
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 249);
            ClientSize = new Size(985, 642);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form7";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hasta Takip & Randevu Sistemi";
            Load += Form7_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pLeft.ResumeLayout(false);
            pLeft.PerformLayout();
            pRight.ResumeLayout(false);
            pRight.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private SplitContainer splitContainer1;
        private Panel pLeft;
        private ListBox lbPatients;
        private Label lblPatients;
        private Panel pRight;
        private Label lblChatTitle;
        private Panel panel1;
        private Button btnSend;
        private TextBox txtMessage;
        private TextBox txtChatHistory;
    }
}