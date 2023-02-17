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
    public partial class frmOgretmen : Form
    {
        public frmOgretmen()
        {
            InitializeComponent();
        }

           
        private void btnOgretmenler_Click(object sender, EventArgs e)
        {
            frmOgretmenler fr = new frmOgretmenler();
            fr.Show();
        }

        private void btnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            frmOgrenciIslemleri fr = new frmOgrenciIslemleri();
            {
                fr.Show();
            }
        }

        private void btnDersIslemleri_Click(object sender, EventArgs e)
        {
            frmDersIslemleri fr = new frmDersIslemleri();
            fr.Show();
        }
    }
}
