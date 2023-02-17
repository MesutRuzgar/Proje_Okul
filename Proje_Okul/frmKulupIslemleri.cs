using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Okul
{
    public partial class frmKulupIslemleri : Form
    {
        public frmKulupIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=RUZGAR\SQLEXPRESS;Initial Catalog=ProjeOkul;Integrated Security=True");

        void Liste() {
            SqlDataAdapter da = new SqlDataAdapter("Select KulupId as 'Kulüp No',KulupAd as 'Kulüp Adı' from tbl_kulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKulupIslemleri_Load(object sender, EventArgs e)
        {
            Liste();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_kulupler (KulupAd) values (@p1)",baglanti);
            komut.Parameters.AddWithValue("@p1",tbxKulupAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekleme işlemi başarılı.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Liste();
           
        }
    }
}
