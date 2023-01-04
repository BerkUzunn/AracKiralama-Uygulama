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
    public partial class Müşteriler1 : Form
    {
        public Müşteriler1()
        {
            InitializeComponent();
        }
        Araçkiralama komut = new Araçkiralama();
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Listele()
        {
            dataGridView1.DataSource = komut.Müsteriler.ToList();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Müşteriler_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Müsteriler ekle = new Müsteriler();
            ekle.AdSoyad = textBox1.Text;
            ekle.Telefon = maskedTextBox1.Text;
            ekle.Yas = Convert.ToInt32(textBox2.Text);
            ekle.MüsteriBakiye = Convert.ToInt32(textBox3.Text);
            
            komut.Müsteriler.Add(ekle);
            komut.SaveChanges();
            Listele();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int müsterino = Convert.ToInt32(textBox1.Tag);
            var güncelle = komut.Müsteriler.Where(w => w.MüsteriNo==müsterino).FirstOrDefault();
            güncelle.AdSoyad = textBox1.Text;
            güncelle.Telefon = maskedTextBox1.Text;
            güncelle.Yas = Convert.ToInt32(textBox2.Text);
            güncelle.MüsteriBakiye = Convert.ToInt32(textBox3.Text);
          
            komut.SaveChanges();
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Tag = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           
      

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int musterino = Convert.ToInt32(textBox1.Tag);
            var sil = komut.Müsteriler.Where(w => w.MüsteriNo == musterino).FirstOrDefault() ;
            sil.AdSoyad = textBox1.Text;
            sil.Telefon = maskedTextBox1.Text;
            sil.Yas = Convert.ToInt32(textBox2.Text);
            sil.MüsteriBakiye = Convert.ToInt32(textBox3.Text);

            komut.Müsteriler.Remove(sil);
            komut.SaveChanges();
            Listele();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = komut.Müsteriler.Where(w => w.AdSoyad == textBox11.Text).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked=true)
            {
                var topmüsteri = komut.Müsteriler.Sum(p=> p.MüsteriBakiye);
                radioButton1.Text = "Topalam Müşteri Bakiyesi "+topmüsteri;
            }


            if (radioButton3.Checked = true)
            {
                var YaşOrt = komut.Müsteriler.Average(p => p.Yas);
                radioButton3.Text = "Müşterilerin Yaş Ortalaması: " + YaşOrt;
            }
           


        }
    }
}
