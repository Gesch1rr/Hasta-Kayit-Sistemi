using Microsoft.Data.SqlClient;
using System;
using System.Text;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Message : Form
    {
        private readonly string cs =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private readonly int _patientId;
        private int? _selectedPatientId = null;

        public Message(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void Message_Load(object sender, EventArgs e)
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
    d.DoctorID,
    d.FirstName,
    d.LastName
FROM Randevular r
JOIN Doktorlar d ON d.DoctorID = r.DoctorID
WHERE r.PatientID = @patientId
ORDER BY d.FirstName, d.LastName;", con);

            cmd.Parameters.AddWithValue("@patientId", _patientId);

            con.Open();
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int doctorId = Convert.ToInt32(rdr["DoctorID"]);
                string fullName = $"{rdr["FirstName"]} {rdr["LastName"]}";
                lbPatients.Items.Add(new PatientListItem(doctorId, fullName));
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

        private void LoadMessages(int doctorId)
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
    SenderType='P' AND SenderID=@patientId AND ReceiverType='D' AND ReceiverID=@doctorId
)
OR
(
    SenderType='D' AND SenderID=@doctorId AND ReceiverType='P' AND ReceiverID=@patientId
)
ORDER BY SentAt ASC;", con);

            cmd.Parameters.AddWithValue("@patientId", _patientId);
            cmd.Parameters.AddWithValue("@doctorId", doctorId);

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
                MessageBox.Show("Lütfen soldan bir doktor seçin.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string body = (txtMessage.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(body))
                return;

            int doctorId = _selectedPatientId.Value;

            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
INSERT INTO Mesajlar (SenderType, SenderID, ReceiverType, ReceiverID, Body, SentAt, IsRead)
VALUES ('P', @patientId, 'D', @doctorId, @body, GETDATE(), 0);", con);

            cmd.Parameters.AddWithValue("@patientId", _patientId);
            cmd.Parameters.AddWithValue("@doctorId", doctorId);
            cmd.Parameters.AddWithValue("@body", body);

            con.Open();
            cmd.ExecuteNonQuery();

            txtMessage.Clear();
            LoadMessages(doctorId);
        }

        private void ClearChat()
        {
            lblChatTitle.Text = "Bir doktor seçin";
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
