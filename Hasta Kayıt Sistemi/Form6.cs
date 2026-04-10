using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Form6 : Form
    {
        private readonly int _doctorId;

        private readonly string connectionString =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private DataTable _dt;

        public Form6(int doctorId)
        {
            InitializeComponent();
            _doctorId = doctorId;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            RandevulariYukle(_doctorId);
            dataGridView1.DataSource = _dt.DefaultView;

            GridBasliklari();
            SetupPatientCombo();
            SetupDatePickers();

            button1.Click += button1_Click;
        }

        private void RandevulariYukle(int doctorId)
        {
            using var conn = new SqlConnection(connectionString);

            using var cmd = new SqlCommand(@"
SELECT
    r.AppointmentDate AS AppointmentDate,
    CONVERT(varchar(5), r.AppointmentDate, 108) AS AppointmentTime,
    h.FirstName + ' ' + h.LastName AS Hasta,
    REPLICATE('*', LEN(h.TCKN) - 3) + RIGHT(h.TCKN, 3) AS TCKN,
    r.Status,
    r.Reason,
    r.Notes
FROM Randevular r
INNER JOIN Hastalar h ON h.PatientID = r.PatientID
WHERE r.DoctorID = @DoctorID
ORDER BY r.AppointmentDate DESC;", conn);

            cmd.Parameters.AddWithValue("@DoctorID", doctorId);

            _dt = new DataTable();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(_dt);
        }

        private void GridBasliklari()
        {
            dataGridView1.Columns["AppointmentDate"].HeaderText = "Tarih";
            dataGridView1.Columns["AppointmentTime"].HeaderText = "Saat";
            dataGridView1.Columns["Hasta"].HeaderText = "Hasta";
            dataGridView1.Columns["TCKN"].HeaderText = "T.C. Kimlik No";
            dataGridView1.Columns["Status"].HeaderText = "Durum";
            dataGridView1.Columns["Reason"].HeaderText = "Randevu Türü";
            dataGridView1.Columns["Notes"].HeaderText = "Notlar";
            dataGridView1.Columns["AppointmentDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void SetupPatientCombo()
        {
            comboBox1.Items.Clear();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.Items.Add("Tümü");

            if (_dt != null && _dt.Columns.Contains("Hasta"))
            {
                var unique = _dt.DefaultView.ToTable(true, "Hasta");
                foreach (DataRow row in unique.Rows)
                {
                    var name = Convert.ToString(row["Hasta"]);
                    if (!string.IsNullOrWhiteSpace(name))
                        comboBox1.Items.Add(name);
                }
            }

            comboBox1.SelectedIndex = 0;
        }

        private void SetupDatePickers()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;

            if (_dt == null || _dt.Rows.Count == 0)
                return;

            DateTime min = DateTime.MaxValue;
            DateTime max = DateTime.MinValue;

            foreach (DataRow r in _dt.Rows)
            {
                if (r["AppointmentDate"] == DBNull.Value) continue;
                var d = Convert.ToDateTime(r["AppointmentDate"]).Date;
                if (d < min) min = d;
                if (d > max) max = d;
            }

            if (min == DateTime.MaxValue) return;

            dateTimePicker1.Value = min;
            dateTimePicker2.Value = max;
        }

        private void ApplyFilters()
        {
            if (_dt == null) return;

            DateTime start = dateTimePicker1.Value.Date;
            DateTime endExclusive = dateTimePicker2.Value.Date.AddDays(1);

            string startStr = start.ToString("yyyy-MM-dd");
            string endStr = endExclusive.ToString("yyyy-MM-dd");

            string filter = $"AppointmentDate >= #{startStr}# AND AppointmentDate < #{endStr}#";

            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Tümü")
            {
                string hasta = comboBox1.SelectedItem.ToString().Replace("'", "''");
                filter += $" AND Hasta = '{hasta}'";
            }

            _dt.DefaultView.RowFilter = filter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Başlangıç tarihi, bitiş tarihinden büyük olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplyFilters();
        }
    }
}
