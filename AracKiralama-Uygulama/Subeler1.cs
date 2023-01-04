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
    public partial class Subeler1 : Form
    {
        public Subeler1()
        {
            InitializeComponent();
        }
        Araçkiralama komut = new Araçkiralama();

        public void Listele()
        {
            dataGridView1.DataSource = komut.Subelers.ToList();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subeler ekle = new Subeler();
            ekle.SubeAdi = textBox1.Text;
            ekle.SubeSehir = textBox2.Text;
            ekle.SubeCiro = Convert.ToInt32(textBox3.Text);
            ekle.MusteriNo = Convert.ToInt32(textBox4.Text);
            komut.Subelers.Add(ekle);
            komut.SaveChanges();
            Listele();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Tag = dataGridView1.CurrentRow.Cells[0].Value;
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int subeno = Convert.ToInt32(textBox1.Tag);
            var güncelle = komut.Subelers.Where(w=> w.SubeNo==subeno).FirstOrDefault();
            güncelle.SubeAdi = textBox1.Text;
            güncelle.SubeSehir = textBox2.Text;
            güncelle.SubeCiro = Convert.ToInt32(textBox3.Text);
            güncelle.MusteriNo = Convert.ToInt32(textBox4.Text);
           
            komut.SaveChanges();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int subeno = Convert.ToInt32(textBox1.Tag);
            var sil = komut.Subelers.Where(w=> w.SubeNo==subeno).FirstOrDefault();
            sil.SubeAdi = textBox1.Text;
            sil.SubeSehir = textBox2.Text;
            sil.SubeCiro = Convert.ToInt32(textBox3.Text);
            sil.MusteriNo = Convert.ToInt32(textBox4.Text);
            komut.Subelers.Remove(sil);
            komut.SaveChanges();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = komut.Subelers.Where(w=> w.SubeSehir==textBox5.Text).ToList();
            dataGridView1.DataSource = komut.Subelers.Where(w=> w.SubeAdi==textBox6.Text).ToList();

        }

        private void Şubeler_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked = true)
            {
                var Ciro = komut.Subelers.Average(p => p.SubeCiro);
                //radioButton3.Text = "Şubelerin Cİro Ortalaması: " + Ciro;
                dataGridView1.DataSource = Ciro;
            }
             if (radioButton1.Checked = true)
            {
                List<Subeler> liste1 = komut.Subelers.Where(p => p.SubeSehir=="istanbul").ToList();
                dataGridView1.DataSource = liste1;
            }
        }
    }
}
