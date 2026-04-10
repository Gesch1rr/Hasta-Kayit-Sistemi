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
    public partial class doktorGiris : Form
    {
        public doktorGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SCHARTZMULL\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        private void doktorGiris_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.");
                return;
            }

            string cs = "Data Source=SCHARTZMULL\\SQLEXPRESS;Initial Catalog=HastaneDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

            using (SqlConnection conn = new SqlConnection(cs))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT TOP 1 DoctorID
            FROM Doktorlar
            WHERE Username = @u AND Password = @p AND IsActive = 1";

                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int doctorId = Convert.ToInt32(result);

                    var f5 = new Form5(doctorId);
                    f5.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                }
            }

        }
    }
}
