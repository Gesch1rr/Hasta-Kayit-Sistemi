using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Form7 : Form
    {
        private readonly string cs =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private readonly int _doctorId;
        private int? _selectedPatientId = null;

        public Form7(int doctorId)
        {
            InitializeComponent();
            _doctorId = doctorId;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            lbPatients.SelectedIndexChanged += lbPatients_SelectedIndexChanged;
            btnSend.Click += btnSend_Click;

            LoadPatients();
            ClearChat();
        }

        private void LoadPatients()
        {
            lbPatients.Items.Clear();

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
SELECT DISTINCT
    h.PatientID,
    h.FirstName,
    h.LastName
FROM Randevular r
JOIN Hastalar h ON h.PatientID = r.PatientID
WHERE r.DoctorID = @doctorId
ORDER BY h.FirstName, h.LastName;", con);

            cmd.Parameters.AddWithValue("@doctorId", _doctorId);

            con.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int patientId = Convert.ToInt32(rdr["PatientID"]);
                string fullName = $"{rdr["FirstName"]} {rdr["LastName"]}";
                lbPatients.Items.Add(new PatientListItem(patientId, fullName));
            }
        }

        private void lbPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPatients.SelectedItem is not PatientListItem item)
                return;

            _selectedPatientId = item.PatientID;
            lblChatTitle.Text = item.FullName;

            LoadMessages(item.PatientID);
        }

        private void LoadMessages(int patientId)
        {
            txtChatHistory.Clear();

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
SELECT
    SenderType,
    Body,
    SentAt
FROM Mesajlar
WHERE
(
    SenderType='D' AND SenderID=@doctorId AND ReceiverType='P' AND ReceiverID=@patientId
)
OR
(
    SenderType='P' AND SenderID=@patientId AND ReceiverType='D' AND ReceiverID=@doctorId
)
ORDER BY SentAt ASC;", con);

            cmd.Parameters.AddWithValue("@doctorId", _doctorId);
            cmd.Parameters.AddWithValue("@patientId", patientId);

            con.Open();
            using var rdr = cmd.ExecuteReader();

            var sb = new StringBuilder();
            while (rdr.Read())
            {
                string senderType = Convert.ToString(rdr["SenderType"]) ?? "";
                string senderLabel = senderType == "D" ? "Doktor" : "Hasta";
                DateTime sentAt = Convert.ToDateTime(rdr["SentAt"]);
                string body = Convert.ToString(rdr["Body"]) ?? "";

                sb.Append('[').Append(sentAt.ToString("dd.MM.yyyy HH:mm")).Append("] ");
                sb.Append(senderLabel).Append(": ");
                sb.AppendLine(body);
                sb.AppendLine();
            }

            if (sb.Length == 0)
                sb.AppendLine("Henüz mesaj yok. İlk mesajı göndererek konuşmayı başlatabilirsiniz.");

            txtChatHistory.Text = sb.ToString();
            txtChatHistory.SelectionStart = txtChatHistory.TextLength;
            txtChatHistory.ScrollToCaret();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            if (_selectedPatientId == null)
            {
                MessageBox.Show("Lütfen soldan bir hasta seçin.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string body = (txtMessage.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(body))
                return;

            int patientId = _selectedPatientId.Value;

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
INSERT INTO Mesajlar (SenderType, SenderID, ReceiverType, ReceiverID, Body, SentAt, IsRead)
VALUES ('D', @doctorId, 'P', @patientId, @body, GETDATE(), 0);", con);

            cmd.Parameters.AddWithValue("@doctorId", _doctorId);
            cmd.Parameters.AddWithValue("@patientId", patientId);
            cmd.Parameters.AddWithValue("@body", body);

            con.Open();
            cmd.ExecuteNonQuery();

            txtMessage.Clear();
            LoadMessages(patientId);
        }

        private void ClearChat()
        {
            lblChatTitle.Text = "Bir hasta seçin";
            txtChatHistory.Clear();
            txtMessage.Clear();
        }

        private sealed class PatientListItem
        {
            public int PatientID { get; }
            public string FullName { get; }

            public PatientListItem(int patientId, string fullName)
            {
                PatientID = patientId;
                FullName = fullName;
            }

            public override string ToString() => FullName;
        }
    }
}
