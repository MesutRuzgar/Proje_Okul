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
using System.Data.SqlClient;

namespace Proje_Okul
{
    public partial class frmSınavIslemleri : Form
    {
        public frmSınavIslemleri()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=RUZGAR\SQLEXPRESS;Initial Catalog=ProjeOkul;Integrated Security=True");

        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(tbxOgrenciId.Text));

        }

        private void frmSınavIslemleri_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbxDersler.DisplayMember = "DersAd";
            cbxDersler.ValueMember = "DersId";
            cbxDersler.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxSinavId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbxOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbxOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbxDersler.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbxSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            tbxSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            tbxSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            tbxProje.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            tbxOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            tbxDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int sinav1, sinav2, sinav3, proje;
            double ortalama;
            string durum;

            sinav1 = Convert.ToInt32(tbxSinav1.Text);
            sinav2 = Convert.ToInt32(tbxSinav2.Text);
            sinav3 = Convert.ToInt32(tbxSinav3.Text);
            proje = Convert.ToInt32(tbxProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            tbxOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                tbxDurum.Text = "Geçti";
            }
            else
            {
                tbxDurum.Text = "Kaldı";
            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            tbxSinavId.Text = "";
            tbxOgrenciId.Text = "";
            tbxOgrenciAd.Text = "";
            tbxOgrenciSoyad.Text = "";
            cbxDersler.Text = "";
            tbxSinav1.Text = "";
            tbxSinav2.Text = "";
            tbxSinav3.Text = "";
            tbxProje.Text = "";
            tbxDurum.Text = "";
        }
    }
}
