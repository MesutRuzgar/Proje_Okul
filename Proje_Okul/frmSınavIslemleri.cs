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
    }
}
