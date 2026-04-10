namespace Hasta_Kayıt_Sistemi
{
    partial class Form8
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            label1 = new Label();
            dgvDuyurular = new DataGridView();
            AnnoucementID = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            txtIcerik = new TextBox();
            lblDetailTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDuyurular).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.FromArgb(44, 62, 80);
            label1.Location = new Point(21, 20);
            label1.Name = "label1";
            label1.Size = new Size(119, 32);
            label1.TabIndex = 0;
            label1.Text = "Duyurular";
            // 
            // dgvDuyurular
            // 
            dgvDuyurular.AllowUserToAddRows = false;
            dgvDuyurular.AllowUserToDeleteRows = false;
            dgvDuyurular.AllowUserToResizeColumns = false;
            dgvDuyurular.AllowUserToResizeRows = false;
            dgvDuyurular.BackgroundColor = Color.White;
            dgvDuyurular.BorderStyle = BorderStyle.None;
            dgvDuyurular.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDuyurular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDuyurular.Columns.AddRange(new DataGridViewColumn[] { AnnoucementID });
            dgvDuyurular.EnableHeadersVisualStyles = false;
            dgvDuyurular.Location = new Point(21, 73);
            dgvDuyurular.MultiSelect = false;
            dgvDuyurular.Name = "dgvDuyurular";
            dgvDuyurular.ReadOnly = true;
            dgvDuyurular.RowHeadersVisible = false;
            dgvDuyurular.RowHeadersWidth = 62;
            dgvDuyurular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDuyurular.Size = new Size(977, 145);
            dgvDuyurular.TabIndex = 1;
            // 
            // AnnoucementID
            // 
            AnnoucementID.HeaderText = "Column1";
            AnnoucementID.MinimumWidth = 8;
            AnnoucementID.Name = "AnnoucementID";
            AnnoucementID.ReadOnly = true;
            AnnoucementID.Visible = false;
            AnnoucementID.Width = 150;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtIcerik);
            panel1.Controls.Add(lblDetailTitle);
            panel1.Controls.Add(dgvDuyurular);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1016, 608);
            panel1.TabIndex = 2;
            // 
            // txtIcerik
            // 
            txtIcerik.BackColor = Color.White;
            txtIcerik.BorderStyle = BorderStyle.None;
            txtIcerik.ForeColor = Color.FromArgb(44, 62, 80);
            txtIcerik.Location = new Point(21, 288);
            txtIcerik.Multiline = true;
            txtIcerik.Name = "txtIcerik";
            txtIcerik.ReadOnly = true;
            txtIcerik.ScrollBars = ScrollBars.Vertical;
            txtIcerik.ShortcutsEnabled = false;
            txtIcerik.Size = new Size(977, 297);
            txtIcerik.TabIndex = 4;
            txtIcerik.TabStop = false;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 12F);
            lblDetailTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblDetailTitle.Location = new Point(21, 253);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(77, 32);
            lblDetailTitle.TabIndex = 3;
            lblDetailTitle.Text = "Mesaj";
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 249);
            ClientSize = new Size(1015, 600);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form8";
            Padding = new Padding(16);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hasta Takip & Randevu Sistemi";
            Load += Form8_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDuyurular).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView dgvDuyurular;
        private Panel panel1;
        private Label lblDetailTitle;
        private TextBox txtIcerik;
        private DataGridViewTextBoxColumn AnnoucementID;
    }
}