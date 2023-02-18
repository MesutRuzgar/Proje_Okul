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
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        void Liste()
        {
            dataGridView1.DataSource = ds.OgrenciListe();
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
    }
}
