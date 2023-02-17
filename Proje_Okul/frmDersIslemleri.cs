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
            MessageBox.Show("Ders başarıyla eklendi.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
        }
    }
}
