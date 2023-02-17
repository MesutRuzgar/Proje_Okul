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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmOgrenciNotlar fr = new frmOgrenciNotlar();
            fr.numara=tbxNumara.Text;
            fr.Show();
        }

        private void tbxNumara_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmOgretmen fr = new frmOgretmen();
            fr.Show();
        }
    }
}
