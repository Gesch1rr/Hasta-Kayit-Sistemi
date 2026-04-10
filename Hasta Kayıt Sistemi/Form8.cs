using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Hasta_Kayıt_Sistemi
{
    public partial class Form8 : Form
    {
        private readonly string cs =
            "Data Source=SCHARTZMULL\\SQLEXPRESS;" +
            "Initial Catalog=HastaneDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public Form8()
        {
            InitializeComponent();
        }
       
            private readonly int _patientId;

            public Form8(int patientId)
            {
                InitializeComponent();
                _patientId = patientId;
            }
        

        private void Form8_Load(object sender, EventArgs e)
        {
            dgvDuyurular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDuyurular.MultiSelect = false;
            dgvDuyurular.ReadOnly = true;
            dgvDuyurular.AllowUserToAddRows = false;
            dgvDuyurular.AllowUserToDeleteRows = false;
            dgvDuyurular.RowHeadersVisible = false;
            dgvDuyurular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtIcerik.ReadOnly = true;
            txtIcerik.Multiline = true;
            txtIcerik.ScrollBars = ScrollBars.Vertical;

            LoadAnnouncements();

            dgvDuyurular.SelectionChanged += dgvDuyurular_SelectionChanged;
        }

        private void LoadAnnouncements()
        {
            using var con = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
SELECT
    AnnouncementID,
    Title,
    PublishedBy,
    PublishedAt,
    Content
FROM Duyurular
ORDER BY PublishedAt DESC;", con);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            dgvDuyurular.DataSource = dt;

            if (dgvDuyurular.Columns.Contains("AnnouncementID"))
                dgvDuyurular.Columns["AnnouncementID"].Visible = false;

            if (dgvDuyurular.Columns.Contains("Content"))
                dgvDuyurular.Columns["Content"].Visible = false;

            if (dgvDuyurular.Columns.Contains("Title"))
                dgvDuyurular.Columns["Title"].HeaderText = "Başlık";

            if (dgvDuyurular.Columns.Contains("PublishedBy"))
                dgvDuyurular.Columns["PublishedBy"].HeaderText = "Yayınlayan";

            if (dgvDuyurular.Columns.Contains("PublishedAt"))
            {
                dgvDuyurular.Columns["PublishedAt"].HeaderText = "Tarih";
                dgvDuyurular.Columns["PublishedAt"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            if (dgvDuyurular.Rows.Count > 0)
            {
                dgvDuyurular.ClearSelection();
                dgvDuyurular.Rows[0].Selected = true;

                if (dgvDuyurular.Columns.Contains("Title"))
                    dgvDuyurular.CurrentCell = dgvDuyurular.Rows[0].Cells["Title"];
                else
                    dgvDuyurular.CurrentCell = dgvDuyurular.Rows[0].Cells[0];

                FillTextBoxFromCurrentRow();
            }
            else
            {
                txtIcerik.Clear();
            }
        }

        private void dgvDuyurular_SelectionChanged(object sender, EventArgs e)
        {
            FillTextBoxFromCurrentRow();
        }

        private void FillTextBoxFromCurrentRow()
        {
            if (dgvDuyurular.CurrentRow == null)
                return;

            if (dgvDuyurular.Columns.Contains("Content"))
                txtIcerik.Text = dgvDuyurular.CurrentRow.Cells["Content"].Value?.ToString() ?? "";
            else
                txtIcerik.Clear();
        }
    }
}