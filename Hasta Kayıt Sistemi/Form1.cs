namespace Hasta_Kayıt_Sistemi
{
    using System;
    using Microsoft.Data.SqlClient;
    using System.Windows.Forms;
    public partial class secimPaneli : Form
    {
        public secimPaneli()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void doktorGiris_Click_1(object sender, EventArgs e)
        {
            var dg = new doktorGiris();
            dg.FormClosed += (s, args) => Application.Exit();
            dg.Show();
            this.Hide();
        }

        private void hastaGiris_Click_1(object sender, EventArgs e)
        {
            var hg = new hastaGiris();
            hg.FormClosed += (s, args) => this.Show();
            hg.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
