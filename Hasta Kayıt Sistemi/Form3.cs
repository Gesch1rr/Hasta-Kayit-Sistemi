using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class hastaGiris : Form
    {
        private readonly string cs =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public hastaGiris()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tckn = (textBox1.Text ?? "").Trim();
            string sifre = (textBox2.Text ?? "").Trim();

            if (tckn.Length != 11 || !IsAllDigits(tckn))
            {
                MessageBox.Show("TCKN 11 haneli ve sadece rakamlardan oluşmalıdır.");
                return;
            }

            if (string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Şifre boş olamaz.");
                return;
            }

            try
            {
                using var con = new SqlConnection(cs);
                using var cmd = new SqlCommand(@"
SELECT TOP 1 PatientID, FirstName, LastName, IsActive
FROM Hastalar
WHERE TCKN = @tckn AND Password = @pwd;", con);

                cmd.Parameters.AddWithValue("@tckn", tckn);
                cmd.Parameters.AddWithValue("@pwd", sifre);

                con.Open();
                using var rdr = cmd.ExecuteReader();

                if (!rdr.Read())
                {
                    MessageBox.Show("TCKN veya şifre hatalı.");
                    return;
                }

                bool isActive = true;
                if (!rdr.IsDBNull(rdr.GetOrdinal("IsActive")))
                    isActive = rdr.GetBoolean(rdr.GetOrdinal("IsActive"));

                if (!isActive)
                {
                    MessageBox.Show("Bu hasta hesabı pasif durumda.");
                    return;
                }

                int patientId = rdr.GetInt32(rdr.GetOrdinal("PatientID"));

                var panel = new HastaPanel(patientId);
                panel.FormClosed += (s, args) => this.Show();
                panel.Show();
                this.Hide();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası:\n" + ex.Message);
            }
        }

        private static bool IsAllDigits(string s)
        {
            foreach (char c in s)
                if (c < '0' || c > '9') return false;
            return true;
        }
    }
}
