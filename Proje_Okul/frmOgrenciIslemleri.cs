using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Okul
{
    public partial class frmOgrenciIslemleri : Form
    {
        public frmOgrenciIslemleri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_OgrencilerTableAdapter ds = new DataSet1TableAdapters.Tbl_OgrencilerTableAdapter();
        void Liste()
        {
            dataGridView1.DataSource = ds.OgrenciListe();
        }
        void Temizle()
        {
            tbxOgrenciId.Text = "";
            tbxOgrenciAd.Text = "";
            tbxOgrenciSoyad.Text = "";
            tbxKulup.Text = "";
            cbxCinsiyet.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOgrenciIslemleri_Load(object sender, EventArgs e)
        {
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           tbxOgrenciId.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbxOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbxKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbxCinsiyet.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.OgrenciEkle(tbxOgrenciAd.Text, tbxOgrenciSoyad.Text, byte.Parse(tbxKulup.Text), cbxCinsiyet.Text);
            MessageBox.Show("Öğrenci başarıyla eklendi.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
            Temizle();
        }
    }
}
