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
    public partial class Araclar1 : Form
    {
        public Araclar1()
        {
            InitializeComponent();
        }
        Araçkiralama komut = new Araçkiralama();
        private void Araçlar_Load(object sender, EventArgs e)
        {
        }
        public void Listele()
        {
            dataGridView1.DataSource = komut.Araclars.ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Listele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Araclar ekle = new Araclar();
            ekle.AracNo = Convert.ToInt32(textBox1.Tag);
            ekle.AracMarka = textBox1.Text;
            ekle.AracModel = textBox2.Text;
            ekle.AracYıl = Convert.ToInt32(textBox3.Text);
            ekle.AracMotor = Convert.ToInt32(textBox4.Text);
            ekle.AracAdet = Convert.ToInt32(textBox5.Text);
            ekle.AracPaket = textBox6.Text;
            ekle.AracRenk = textBox7.Text;
            ekle.AracFİyat = Convert.ToInt32(textBox8.Text);
            ekle.SubeNo = Convert.ToInt32(textBox10.Text);
            komut.Araclars.Add(ekle);
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
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int aracno = Convert.ToInt32(textBox1.Tag);
            var güncelle = komut.Araclars.Where(w => w.AracNo == aracno).FirstOrDefault();
            güncelle.AracMarka = textBox1.Text;
            güncelle.AracModel = textBox2.Text;
            güncelle.AracYıl = Convert.ToInt32(textBox3.Text);
            güncelle.AracMotor = Convert.ToInt32(textBox4.Text);
            güncelle.AracAdet = Convert.ToInt32(textBox5.Text);
            güncelle.AracPaket = textBox6.Text;
            güncelle.AracFİyat = Convert.ToInt32(textBox8.Text);
            güncelle.SubeNo = Convert.ToInt32(textBox10.Text);
            komut.SaveChanges();
            Listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int aracno = Convert.ToInt32(textBox1.Tag);
            var sil = komut.Araclars.Where(w=> w.AracNo==aracno).FirstOrDefault();
            sil.AracMarka = textBox1.Text;
            sil.AracModel = textBox2.Text;
            sil.AracYıl = Convert.ToInt32(textBox3.Text);
            sil.AracMotor = Convert.ToInt32(textBox4.Text);
            sil.AracAdet = Convert.ToInt32(textBox5.Text);
            sil.AracPaket = textBox6.Text;
            sil.AracFİyat = Convert.ToInt32(textBox8.Text);
            sil.SubeNo = Convert.ToInt32(textBox10.Text);
            komut.Araclars.Remove(sil);
            komut.SaveChanges();
            Listele();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = komut.Araclars.Where(w => w.AracMarka == textBox11.Text).ToList();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked=true)
            {
                List<Araclar> liste1 = komut.Araclars.OrderByDescending(p => p.AracMarka).ToList();
                dataGridView1.DataSource = liste1;

            }
            if (radioButton2.Checked=true)
            {
                List<Araclar> liste2 = komut.Araclars.OrderBy(p => p.AracFİyat).ToList();
                dataGridView1.DataSource = liste2;
            }

            if (radioButton3.Checked=true)
            {
                List<Araclar> liste3 = komut.Araclars.Where(p => p.AracRenk=="siyah" ).ToList();
                dataGridView1.DataSource = liste3;

            }

            if (radioButton4.Checked = true)
            {
                List<Araclar> liste4 = komut.Araclars.Where(p => p.AracAdet>3).ToList();
                dataGridView1.DataSource = liste4;

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
