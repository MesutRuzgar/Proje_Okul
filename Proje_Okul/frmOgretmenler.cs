using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Okul
{
    public partial class frmOgretmenler : Form
    {
        public frmOgretmenler()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=RUZGAR\SQLEXPRESS;Initial Catalog=ProjeOkul;Integrated Security=True");
        DataSet1TableAdapters.Tbl_OgretmenlerTableAdapter ds = new DataSet1TableAdapters.Tbl_OgretmenlerTableAdapter();

        void Liste()
        {
            dataGridView1.DataSource = ds.OgretmenListe();
        }
        void Temizle()
        {
            tbxOgrentmenId.Text = "";
            tbxOgretmenAdSoyad.Text = "";
            cbxBrans.Text = "";
        }

        private void frmOgretmenler_Load(object sender, EventArgs e)
        {
            Liste();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbxBrans.DisplayMember = "DersAd";
            cbxBrans.ValueMember = "DersId";
            cbxBrans.DataSource = dt;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxOgrentmenId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbxBrans.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbxOgretmenAdSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.OgretmenEkle(byte.Parse(cbxBrans.SelectedValue.ToString()), tbxOgretmenAdSoyad.Text);
            MessageBox.Show("Yeni öğretmen başarıyla kayıt edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
            Temizle();
        }
    }
}
