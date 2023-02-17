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
    public partial class frmDersIslemleri : Form
    {
        public frmDersIslemleri()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();

        void Liste()
        {
            dataGridView1.DataSource = ds.DersListesi();
        }
        void Temizle()
        {
            tbxDersId.Text = "";
            tbxDersAd.Text = "";
        }

        private void frmDersIslemleri_Load(object sender, EventArgs e)
        {
            Liste();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(tbxDersAd.Text);
            MessageBox.Show("Ders başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(tbxDersId.Text));
            MessageBox.Show("Ders başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
            Temizle();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxDersId.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
         
            ds.DersGuncelle(tbxDersAd.Text,byte.Parse(tbxDersId.Text));
            MessageBox.Show("Ders başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
            Temizle();
        }
    }
}
