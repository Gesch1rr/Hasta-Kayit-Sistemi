using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class HastaPanel : Form
    {
        private readonly int _patientId;

        private readonly string cs =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public HastaPanel(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void HastaPanel_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            LoadPatientName();
            LoadRecentAppointments();
            LoadUpcomingAppointments();
        }

        private void LoadPatientName()
        {
            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
SELECT TOP 1 FirstName, LastName
FROM Hastalar
WHERE PatientID = @patientId;", con);

            cmd.Parameters.AddWithValue("@patientId", _patientId);

            con.Open();
            using var rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                string fullName = $"{rdr["FirstName"]} {rdr["LastName"]}";
                label1.Text = "Hoş Geldiniz, " + fullName;
            }
            else
            {
                label1.Text = "Hoş Geldiniz";
            }
        }

        private void LoadRecentAppointments()
        {
            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
SELECT TOP 10
    r.AppointmentDate AS AppointmentDate,
    CONVERT(varchar(5), r.AppointmentDate, 108) AS AppointmentTime,
    r.Status,
    r.Reason,
    r.Notes
FROM Randevular r
WHERE r.PatientID = @patientId
ORDER BY r.AppointmentDate DESC;", con);

            cmd.Parameters.AddWithValue("@patientId", _patientId);

            var dt = new DataTable();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            SetupGridCommon(dataGridView1);

            if (dataGridView1.Columns["AppointmentDate"] != null)
            {
                dataGridView1.Columns["AppointmentDate"].HeaderText = "Tarih";
                dataGridView1.Columns["AppointmentDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            if (dataGridView1.Columns["AppointmentTime"] != null)
                dataGridView1.Columns["AppointmentTime"].HeaderText = "Saat";

            if (dataGridView1.Columns["Status"] != null)
                dataGridView1.Columns["Status"].HeaderText = "Durum";

            if (dataGridView1.Columns["Reason"] != null)
                dataGridView1.Columns["Reason"].HeaderText = "Tür";

            if (dataGridView1.Columns["Notes"] != null)
                dataGridView1.Columns["Notes"].HeaderText = "Not";
        }

        private void LoadUpcomingAppointments()
        {
            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
SELECT TOP 10
    r.AppointmentDate AS AppointmentDate,
    CONVERT(varchar(5), r.AppointmentDate, 108) AS AppointmentTime,
    d.FirstName + ' ' + d.LastName AS DoctorName,
    d.Branch AS Branch,
    r.Status
FROM Randevular r
JOIN Doktorlar d ON d.DoctorID = r.DoctorID
WHERE 
    r.PatientID = @patientId
    AND r.AppointmentDate >= GETDATE()
    AND r.Status IN (N'Beklemede', N'Planlandı')
ORDER BY r.AppointmentDate ASC;", con);

            cmd.Parameters.AddWithValue("@patientId", _patientId);

            var dt = new DataTable();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView2.DataSource = dt;

            SetupGridCommon(dataGridView2);

            if (dataGridView2.Columns["AppointmentDate"] != null)
            {
                dataGridView2.Columns["AppointmentDate"].HeaderText = "Tarih";
                dataGridView2.Columns["AppointmentDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            if (dataGridView2.Columns["AppointmentTime"] != null)
                dataGridView2.Columns["AppointmentTime"].HeaderText = "Saat";

            if (dataGridView2.Columns["DoctorName"] != null)
                dataGridView2.Columns["DoctorName"].HeaderText = "Doktor";

            if (dataGridView2.Columns["Branch"] != null)
                dataGridView2.Columns["Branch"].HeaderText = "Branş";

            if (dataGridView2.Columns["Status"] != null)
                dataGridView2.Columns["Status"].HeaderText = "Durum";
        }

        private void SetupGridCommon(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new Message(_patientId);
            f.FormClosed += (s, args) => RefreshDashboard();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Form8();
            f.FormClosed += (s, args) => RefreshDashboard();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Form10(_patientId);
            f.FormClosed += (s, args) => RefreshDashboard();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form9(_patientId);
            f.FormClosed += (s, args) => RefreshDashboard();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f = new Form11(_patientId);
            f.FormClosed += (s, args) => RefreshDashboard();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
