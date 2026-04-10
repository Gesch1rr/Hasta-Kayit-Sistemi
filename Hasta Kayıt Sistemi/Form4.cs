using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Form4 : Form
    {
        private readonly string cs =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tckn = (textBox2.Text ?? "").Trim();
            string ad = (textBox3.Text ?? "").Trim();
            string soyad = (textBox6.Text ?? "").Trim();
            string telefon = (textBox1.Text ?? "").Trim();
            string eposta = (textBox4.Text ?? "").Trim();
            string adres = (textBox5.Text ?? "").Trim();
            DateTime dogumTarihi = dateTimePicker1.Value.Date;

            if (tckn.Length != 11 || !tckn.All(char.IsDigit))
            {
                MessageBox.Show("TCKN 11 haneli ve sadece rakamlardan oluşmalıdır.");
                return;
            }

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
            {
                MessageBox.Show("Ad ve Soyad boş olamaz.");
                return;
            }

            if (dogumTarihi > DateTime.Today)
            {
                MessageBox.Show("Doğum tarihi gelecekte olamaz.");
                return;
            }

            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBox1.SelectedItem?.ToString()))
            {
                MessageBox.Show("Lütfen cinsiyet seçiniz.");
                return;
            }

            string cinsiyetText = comboBox1.SelectedItem.ToString();
            string cinsiyet = (cinsiyetText == "Kadın") ? "K" :
                              (cinsiyetText == "Erkek") ? "E" :
                              cinsiyetText;

            if (!string.IsNullOrWhiteSpace(telefon))
            {
                string telDigits = new string(telefon.Where(char.IsDigit).ToArray());
                if (telDigits.Length < 10 || telDigits.Length > 15)
                {
                    MessageBox.Show("Telefon numarası geçersiz. (En az 10, en fazla 15 rakam)");
                    return;
                }
                telefon = telDigits;
            }

            if (!string.IsNullOrWhiteSpace(eposta))
            {
                bool emailOk = Regex.IsMatch(eposta, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!emailOk)
                {
                    MessageBox.Show("E-posta formatı geçersiz.");
                    return;
                }
            }

            try
            {
                using var conn = new SqlConnection(cs);
                using var cmd = new SqlCommand(@"
INSERT INTO Hastalar
(TCKN, FirstName, LastName, DateOfBirth, Gender, Phone, Email, Address, IsActive, CreatedAt)
VALUES
(@TCKN, @Ad, @Soyad, @DogumTarihi, @Cinsiyet,  @Telefon, @Eposta, @Adres, 1, GETDATE());", conn);

                cmd.Parameters.Add("@TCKN", System.Data.SqlDbType.VarChar, 11).Value = tckn;
                cmd.Parameters.Add("@Ad", System.Data.SqlDbType.NVarChar, 50).Value = ad;
                cmd.Parameters.Add("@Soyad", System.Data.SqlDbType.NVarChar, 50).Value = soyad;
                cmd.Parameters.Add("@DogumTarihi", System.Data.SqlDbType.Date).Value = dogumTarihi;
                cmd.Parameters.Add("@Cinsiyet", System.Data.SqlDbType.NVarChar, 1).Value = cinsiyet;
                cmd.Parameters.Add("@Telefon", System.Data.SqlDbType.NVarChar, 20).Value = (object)telefon ?? DBNull.Value;
                cmd.Parameters.Add("@Eposta", System.Data.SqlDbType.NVarChar, 100).Value = (object)eposta ?? DBNull.Value;
                cmd.Parameters.Add("@Adres", System.Data.SqlDbType.NVarChar, -1).Value = (object)adres ?? DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Hasta kaydı başarıyla oluşturuldu");
                FormuTemizle();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Bu TCKN ile zaten bir hasta kaydı mevcut.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Veritabanı hatası:\n" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void FormuTemizle()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();

            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
        }
    }
}
