using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Gerekli kütüphaneleri ekleyelim.
using System.Data.Sql;
using System.Data.SqlClient;

namespace login_islemleri
{
    public partial class Form1 : Form
    {
        // Tanımlamalarımızı yapalım.
        SqlConnection baglanti;
        SqlDataReader okuyucu;
        SqlCommand komut;

        public Form1()
        {

            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gerekli yerlerin Sql ile olan bağlantısını gerçekleştirme işlemleri:
            string user = textBox1.Text;
            string password = textBox1.Text;
            baglanti = new SqlConnection("Data Source=DESKTOP-ME3MUPN;Initial Catalog=Ornek;Integrated Security=True");
            komut = new SqlCommand();
            baglanti.Open();

            // Yukarıda tanımlanan Sql bağlantısını alıp bu bağlantıyı komut satırının bağlantısına ekliyoruz.
            komut.Connection = baglanti;
            komut.CommandText = "Select * from KullaniciBilgi where kullanici_adi='" + textBox1.Text + "' And sifre='" + textBox2.Text + "'";

            // DataReader olarak tanımladığımız okuyucudan ExecuteReader ile yazmış olduğumuz bu sorguyu çalıştırıyoruz.
            okuyucu = komut.ExecuteReader();

            if (okuyucu.Read())
            {
                MessageBox.Show("Tebrikler Giriş Başarılı");

                // Giriş başarılı ise Form2'ye geçiş işlemi yapıyoruz.
                Form2 gecis = new Form2();
                gecis.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }

            baglanti.Close();
        }
    }
}
