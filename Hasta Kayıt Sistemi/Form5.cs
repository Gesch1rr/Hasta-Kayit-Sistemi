using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Form5 : Form
    {
        private readonly int _doctorId;

        public Form5(int doctorId)
        {
            InitializeComponent();
            _doctorId = doctorId;

            DoktorAdiniGetir();
            HastalariYukle();
            SonRandevulariYukle();
        }
        private readonly string cs =
        "Data Source=SCHARTZMULL\\SQLEXPRESS;Initial Catalog=HastaneDB;Integrated Security=True;TrustServerCertificate=True;";

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void DoktorAdiniGetir()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                SELECT FirstName, LastName
                FROM Doktorlar
                WHERE DoctorID = @id";

                cmd.Parameters.AddWithValue("@id", _doctorId);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string ad = dr.GetString(0);
                        string soyad = dr.GetString(1);

                        label2.Text = $"Hoş geldiniz Dr. {ad} {soyad}";

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f6 = new Form6(_doctorId);
            f6.Show();
        }
        private void HastalariYukle(string arama = "")
        {
            using var conn = new SqlConnection(cs);

            using var cmd = new SqlCommand(@"
        SELECT DISTINCT
        h.PatientID,
        REPLICATE('*', LEN(h.TCKN) - 3) + RIGHT(h.TCKN, 3) AS TCKN,
        h.FirstName AS Ad,
        h.LastName  AS Soyad,
        h.Gender    AS Cinsiyet,
        h.DateOfBirth AS DogumTarihi
        FROM Randevular r
        INNER JOIN Hastalar h ON h.PatientID = r.PatientID
        WHERE r.DoctorID = @DoctorID
        AND (@q = '' 
        OR h.TCKN LIKE @qLike 
        OR (h.FirstName + ' ' + h.LastName) LIKE @qLike)
        ORDER BY h.LastName, h.FirstName;", conn);

            cmd.Parameters.AddWithValue("@DoctorID", _doctorId);
            cmd.Parameters.AddWithValue("@q", arama.Trim());
            cmd.Parameters.AddWithValue("@qLike", "%" + arama.Trim() + "%");

            var dt = new DataTable();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView2.DataSource = dt;

            dataGridView2.Columns["PatientID"].HeaderText = "Hasta ID";
            dataGridView2.Columns["TCKN"].HeaderText = "TCKN";
            dataGridView2.Columns["Ad"].HeaderText = "Ad";
            dataGridView2.Columns["Soyad"].HeaderText = "Soyad";
            dataGridView2.Columns["Cinsiyet"].HeaderText = "Cinsiyet";
            dataGridView2.Columns["DogumTarihi"].HeaderText = "Doğum Tarihi";

            dataGridView2.Columns["DogumTarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }
        private void SonRandevulariYukle()
        {
            using var conn = new SqlConnection(cs);

            using var cmd = new SqlCommand(@"
            SELECT TOP 5
            r.AppointmentDate AS Tarih,
            CONVERT(varchar(5), r.AppointmentDate, 108) AS Saat,
            h.FirstName + ' ' + h.LastName AS Hasta,
            REPLICATE('*', LEN(h.TCKN) - 3) + RIGHT(h.TCKN, 3) AS TCKN,
            r.Status AS Durum,
            r.Reason AS Sebep
            FROM Randevular r
            INNER JOIN Hastalar h ON h.PatientID = r.PatientID
            WHERE r.DoctorID = @DoctorID
            AND r.Status IN ('Tamamlandı', 'İptal Edildi')
            ORDER BY r.AppointmentDate DESC;", conn);

            cmd.Parameters.AddWithValue("@DoctorID", _doctorId);

            var dt = new DataTable();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f7 = new Form7(_doctorId);
            f7.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var f = new Form8())
            {
                f.ShowDialog();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
