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
    public partial class frmOgrenciNotlar : Form
    {
        public frmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=RUZGAR\SQLEXPRESS;Initial Catalog=ProjeOkul;Integrated Security=True");

        public string numara;
        public string adSoyad;

        private void frmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DersAd As 'Ders Adı',Sinav1 As '1. Sınav',Sinav2 As '2. Sınav',Sinav3 As '3. Sınav',Proje,Ortalama,Durum  From Tbl_Notlar inner join tbl_dersler on tbl_notlar.DersId=Tbl_Dersler.DersId Where OgrenciId=@p1", baglanti);

            komut.Parameters.AddWithValue("@p1", numara);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select OgrenciAd,OgrenciSoyad from Tbl_Ogrenciler where OgrenciId=@p1", baglanti);

            komut2.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0] + " " + dr[1];
            }
            baglanti.Close();

        }
    }
}
