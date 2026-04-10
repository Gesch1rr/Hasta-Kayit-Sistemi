using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Form11 : Form
    {
        private int _patientId;

        private readonly string cs =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public Form11()
        {
            InitializeComponent();
            this.Load += Form11_Load;
        }

        public Form11(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            this.Load += Form11_Load;
        }

        public void SetPatient(int patientId)
        {
            _patientId = patientId;
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            SetupGrid();

            if (_patientId <= 0)
            {
                MessageBox.Show("PatientID alınamadı. Form11'i new Form11(patientId) ile açmalısın.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadAppointments();
        }

        private void SetupGrid()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAppointments()
        {
            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
SELECT
    r.AppointmentID,
    r.AppointmentDate AS AppointmentDate,
    CONVERT(varchar(5), r.AppointmentDate, 108) AS AppointmentTime,
    d.FirstName + ' ' + d.LastName AS DoctorName,
    d.Branch AS Branch,
    r.Status,
    r.Reason,
    r.Notes,
    CASE WHEN r.AppointmentDate < GETDATE() THEN N'Geçmiş' ELSE N'Gelecek' END AS Period
FROM Randevular r
JOIN Doktorlar d ON d.DoctorID = r.DoctorID
WHERE r.PatientID = @patientId
ORDER BY r.AppointmentDate DESC;", con);

            cmd.Parameters.AddWithValue("@patientId", _patientId);

            var dt = new DataTable();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            ApplyHeaders();

            if (dataGridView1.Columns["AppointmentID"] != null)
                dataGridView1.Columns["AppointmentID"].Visible = false;
        }

        private void ApplyHeaders()
        {
            if (dataGridView1.Columns["AppointmentDate"] != null)
            {
                dataGridView1.Columns["AppointmentDate"].HeaderText = "Tarih";
                dataGridView1.Columns["AppointmentDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            if (dataGridView1.Columns["AppointmentTime"] != null)
                dataGridView1.Columns["AppointmentTime"].HeaderText = "Saat";

            if (dataGridView1.Columns["DoctorName"] != null)
                dataGridView1.Columns["DoctorName"].HeaderText = "Doktor";

            if (dataGridView1.Columns["Branch"] != null)
                dataGridView1.Columns["Branch"].HeaderText = "Branş";

            if (dataGridView1.Columns["Status"] != null)
                dataGridView1.Columns["Status"].HeaderText = "Durum";

            if (dataGridView1.Columns["Reason"] != null)
                dataGridView1.Columns["Reason"].HeaderText = "Tür";

            if (dataGridView1.Columns["Notes"] != null)
                dataGridView1.Columns["Notes"].HeaderText = "Not";

            if (dataGridView1.Columns["Period"] != null)
                dataGridView1.Columns["Period"].HeaderText = "Dönem";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            CancelSelectedAppointment();
        }

        private void CancelSelectedAppointment()
        {
            if (_patientId <= 0)
            {
                MessageBox.Show("PatientID alınamadı.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iptal etmek için bir randevu seçin.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            if (row.Cells["AppointmentID"]?.Value == null || row.Cells["AppointmentID"].Value == DBNull.Value)
            {
                MessageBox.Show("Seçili randevu bulunamadı.");
                return;
            }

            int appointmentId = Convert.ToInt32(row.Cells["AppointmentID"].Value);

            DateTime apptDate = DateTime.MinValue;
            if (row.Cells["AppointmentDate"]?.Value != null && row.Cells["AppointmentDate"].Value != DBNull.Value)
                apptDate = Convert.ToDateTime(row.Cells["AppointmentDate"].Value);

            if (apptDate < DateTime.Now)
            {
                MessageBox.Show("Geçmiş randevular iptal edilemez.");
                return;
            }

            string status = row.Cells["Status"]?.Value?.ToString() ?? "";
            if (status.Equals("İptal Edildi", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bu randevu zaten iptal edilmiş.");
                return;
            }

            var confirm = MessageBox.Show("Seçili randevuyu iptal etmek istiyor musunuz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
UPDATE Randevular
SET Status = N'İptal Edildi'
WHERE AppointmentID = @id AND PatientID = @patientId;", con);

            cmd.Parameters.AddWithValue("@id", appointmentId);
            cmd.Parameters.AddWithValue("@patientId", _patientId);

            con.Open();
            int affected = cmd.ExecuteNonQuery();

            if (affected > 0)
            {
                MessageBox.Show("Randevu iptal edildi ✔");
                LoadAppointments();
            }
            else
            {
                MessageBox.Show("Randevu iptal edilemedi.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
