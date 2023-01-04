using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama_Uygulama
{
    public partial class KulanıcıGiriş1 : Form
    {
        public KulanıcıGiriş1()
        {
            InitializeComponent();
        }
        Araçkiralama komut = new Araçkiralama();


        private void button2_Click(object sender, EventArgs e)
        {
            Kullanicilar ekle = new Kullanicilar();
            ekle.KullaniciAdi = textBox4.Text;
            ekle.Sifre = textBox3.Text;
            komut.Kullanicilars.Add(ekle);
            komut.SaveChanges();
       
            
            
        }
    }
}
