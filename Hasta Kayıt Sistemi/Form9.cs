using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Form9 : Form
    {
        private readonly int _patientId;

        private readonly string cs =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public Form9(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            LoadDoctorsForPatient();
        }

        private void LoadDoctorsForPatient()
        {
            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
SELECT DISTINCT TOP 4
    d.FirstName + ' ' + d.LastName AS DoctorName,
    ISNULL(NULLIF(LTRIM(RTRIM(d.Branch)), ''), '-') AS DoctorBranch
FROM Randevular r
JOIN Doktorlar d ON d.DoctorID = r.DoctorID
WHERE r.PatientID = @patientId
ORDER BY DoctorName;", con);

            cmd.Parameters.AddWithValue("@patientId", _patientId);

            var dt = new DataTable();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            lblDoctorName.Text = dt.Rows.Count >= 1 ? (Convert.ToString(dt.Rows[0]["DoctorName"]) ?? "-") : "-";
            lblBranch.Text = dt.Rows.Count >= 1 ? (Convert.ToString(dt.Rows[0]["DoctorBranch"]) ?? "-") : "-";

            lblDoctorName2.Text = dt.Rows.Count >= 2 ? (Convert.ToString(dt.Rows[1]["DoctorName"]) ?? "-") : "-";
            lblBranch2.Text = dt.Rows.Count >= 2 ? (Convert.ToString(dt.Rows[1]["DoctorBranch"]) ?? "-") : "-";

            label3.Text = dt.Rows.Count >= 3 ? (Convert.ToString(dt.Rows[2]["DoctorName"]) ?? "-") : "-";
            label2.Text = dt.Rows.Count >= 3 ? (Convert.ToString(dt.Rows[2]["DoctorBranch"]) ?? "-") : "-";

            label5.Text = dt.Rows.Count >= 4 ? (Convert.ToString(dt.Rows[3]["DoctorName"]) ?? "-") : "-";
            label4.Text = dt.Rows.Count >= 4 ? (Convert.ToString(dt.Rows[3]["DoctorBranch"]) ?? "-") : "-";

            if (string.IsNullOrWhiteSpace(lblBranch.Text)) lblBranch.Text = "-";
            if (string.IsNullOrWhiteSpace(lblBranch2.Text)) lblBranch2.Text = "-";
            if (string.IsNullOrWhiteSpace(label2.Text)) label2.Text = "-";
            if (string.IsNullOrWhiteSpace(label4.Text)) label4.Text = "-";
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}
