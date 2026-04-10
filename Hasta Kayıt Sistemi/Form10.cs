using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Form10 : Form
    {
        private readonly int _patientId;
          
        private readonly string connectionString =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public Form10(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";

            comboBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox2.Enabled = false;

            comboBranch.SelectedIndexChanged += comboBranch_SelectedIndexChanged;

            FillTimeSlots();
            LoadBranches();
            ResetDoctorCombo();
        }

        private void LoadBranches()
        {
            comboBranch.Items.Clear();
            comboBranch.Items.Add("Seçiniz");

            using var con = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(@"
SELECT DISTINCT Branch
FROM Doktorlar
WHERE Branch IS NOT NULL AND LTRIM(RTRIM(Branch)) <> ''
ORDER BY Branch;", con);

            con.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                comboBranch.Items.Add(Convert.ToString(rdr["Branch"]));
            }

            comboBranch.SelectedIndex = 0;
        }

        private void FillTimeSlots()
        {
            comboBox1.Items.Clear();

            for (int h = 9; h <= 17; h++)
            {
                comboBox1.Items.Add($"{h:00}:00");
                if (h != 17) comboBox1.Items.Add($"{h:00}:30");
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void ResetDoctorCombo()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Önce branş seçin");
            comboBox2.SelectedIndex = 0;
            comboBox2.Enabled = false;
        }

        private void comboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBranch.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(comboBranch.SelectedItem?.ToString()))
            {
                ResetDoctorCombo();
                return;
            }

            string branch = comboBranch.SelectedItem.ToString();
            LoadDoctorsForBranch(branch);
        }

        private void LoadDoctorsForBranch(string branch)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Seçiniz");
            comboBox2.SelectedIndex = 0;

            using var con = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(@"
SELECT DoctorID, FirstName, LastName
FROM Doktorlar
WHERE Branch = @branch
ORDER BY FirstName, LastName;", con);

            cmd.Parameters.AddWithValue("@branch", branch);

            con.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int doctorId = Convert.ToInt32(rdr["DoctorID"]);
                string name = $"{rdr["FirstName"]} {rdr["LastName"]}";
                comboBox2.Items.Add(new DoctorItem(doctorId, name));
            }

            comboBox2.Enabled = comboBox2.Items.Count > 1;
            if (!comboBox2.Enabled)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Doktor bulunamadı");
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateAppointment();
        }

        private void CreateAppointment()
        {
            if (comboBranch.SelectedIndex <= 0 || string.IsNullOrWhiteSpace(comboBranch.SelectedItem?.ToString()))
            {
                MessageBox.Show("Lütfen bir branş seçin.");
                return;
            }

            if (!comboBox2.Enabled || comboBox2.SelectedIndex <= 0 || comboBox2.SelectedItem is not DoctorItem)
            {
                MessageBox.Show("Lütfen branşa ait bir doktor seçin.");
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir saat seçin.");
                return;
            }

            DateTime date = dateTimePicker1.Value.Date;
            if (date < DateTime.Today)
            {
                MessageBox.Show("Geçmiş bir tarih seçemezsiniz.");
                return;
            }

            string timeText = comboBox1.SelectedItem.ToString();
            if (!TryParseTime(timeText, out TimeSpan time))
            {
                MessageBox.Show("Saat formatı geçersiz. Örnek: 09:30");
                return;
            }

            DateTime appointmentDateTime = date.Add(time);
            if (appointmentDateTime <= DateTime.Now)
            {
                MessageBox.Show("Geçmiş bir saat seçemezsiniz.");
                return;
            }

            int doctorId = ((DoctorItem)comboBox2.SelectedItem).DoctorID;
            string doctorName = ((DoctorItem)comboBox2.SelectedItem).FullName;

            string note = (textBox1.Text ?? "").Trim();

            using var con = new SqlConnection(connectionString);
            con.Open();

            if (AppointmentExists(con, doctorId, appointmentDateTime))
            {
                MessageBox.Show("Seçtiğiniz doktor için bu tarih/saat dolu. Lütfen farklı bir saat seçin.");
                return;
            }

            using var cmdInsert = new SqlCommand(@"
INSERT INTO Randevular
(
    DoctorID,
    PatientID,
    AppointmentDate,
    Status,
    Reason,
    Notes,
    CreatedByUserID
)
VALUES
(
    @doctorId,
    @patientId,
    @dt,
    N'Beklemede',
    N'Hasta Randevusu',
    @notes,
    @createdBy
);", con);

            cmdInsert.Parameters.AddWithValue("@doctorId", doctorId);
            cmdInsert.Parameters.AddWithValue("@patientId", _patientId);
            cmdInsert.Parameters.AddWithValue("@dt", appointmentDateTime);
            cmdInsert.Parameters.AddWithValue("@notes", note);
            cmdInsert.Parameters.AddWithValue("@createdBy", _patientId);

            cmdInsert.ExecuteNonQuery();

            MessageBox.Show(
                $"Randevu oluşturuldu ✔\n\nDoktor: {doctorName}\nTarih: {appointmentDateTime:dd.MM.yyyy}\nSaat: {appointmentDateTime:HH:mm}",
                "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            comboBranch.SelectedIndex = 0;
            ResetDoctorCombo();
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Today;
        }

        private bool AppointmentExists(SqlConnection con, int doctorId, DateTime appointmentDateTime)
        {
            using var cmd = new SqlCommand(@"
SELECT COUNT(1)
FROM Randevular
WHERE DoctorID = @doctorId AND AppointmentDate = @dt;", con);

            cmd.Parameters.AddWithValue("@doctorId", doctorId);
            cmd.Parameters.AddWithValue("@dt", appointmentDateTime);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private bool TryParseTime(string input, out TimeSpan time)
        {
            time = default;
            if (string.IsNullOrWhiteSpace(input)) return false;

            input = input.Replace('.', ':');

            return TimeSpan.TryParseExact(input, @"h\:m", CultureInfo.InvariantCulture, out time)
                || TimeSpan.TryParseExact(input, @"hh\:mm", CultureInfo.InvariantCulture, out time)
                || TimeSpan.TryParseExact(input, @"h\:mm", CultureInfo.InvariantCulture, out time);
        }

        private sealed class DoctorItem
        {
            public int DoctorID { get; }
            public string FullName { get; }

            public DoctorItem(int doctorId, string fullName)
            {
                DoctorID = doctorId;
                FullName = fullName;
            }

            public override string ToString() => FullName;
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
