using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
       
        SqlConnection bag = new SqlConnection("Data source=DESKTOP-8TO73FG\\SQLEXPRESS;Initial Catalog=pansıyon;Integrated security=true;");
        private void temizle() {
            txtid.Clear();
            txtad.Clear();
            txtsoyad.Clear();
            txtodano.Clear();
            txttelefon.Clear();
            txthesap.Clear();

        
        
        
        
        
        }
        private void verilerigöster()
        {
            bag.Open();
            listView1.Items.Clear();
          
            SqlCommand komut = new SqlCommand("Select * from müsteriler2", bag);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["odano"].ToString());
                ekle.SubItems.Add(oku["giriştarihi"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["Ctarih"].ToString());

                listView1.Items.Add(ekle);
              




            }
            bag.Close();
           
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();
           
            SqlCommand komut = new SqlCommand("insert into müsteriler2(id,ad,soyad,odano,giriştarihi,telefon,Hesap,Ctarih) values('" + txtid.Text.ToString() + "', '" + txtad.Text.ToString() + "','" + txtsoyad.Text.ToString() + "','" + txtodano.Text.ToString() + "','" + dategiriş.Text.ToString() + "','" + txttelefon.Text.ToString() + "','" + txthesap.Text.ToString() + "','" + dateçıkış.Text.ToString()+ "')", bag);

            komut.ExecuteNonQuery();
            bag.Close();
            verilerigöster();
            temizle();
            
        }
        int id = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand(" Delete From müsteriler2 where id=(" + id + ")", bag);
            komut.ExecuteNonQuery();
            bag.Close();
            verilerigöster();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text.ToString());
            txtid.Text = listView1.SelectedItems[0].SubItems[0].Text;



            txtad.Text = listView1.SelectedItems[0].SubItems[1].Text;

txtsoyad.Text     = listView1.SelectedItems[0].SubItems[2].Text;


txtodano.Text
  = listView1.SelectedItems[0].SubItems[3].Text;


dategiriş.Text

             = listView1.SelectedItems[0].SubItems[4].Text;
txttelefon.Text
 = listView1.SelectedItems[0].SubItems[5].Text;
            txthesap.Text

 = listView1.SelectedItems[0].SubItems[6].Text;

            
            dateçıkış.Text
            = listView1.SelectedItems[0].SubItems[7].Text;










        }

       
        private void button4_Click_1(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand(" update müsteriler2 set  id='" + txtid.Text.ToString() + "',ad='" + txtad.Text.ToString() + "',soyad='" + txtsoyad.Text.ToString() + "',odano='" + txtodano.Text.ToString() + "',giriştarihi='" + dategiriş.Text.ToString() + "',telefon='" + txttelefon.Text.ToString() + "',Hesap='" + txthesap.Text.ToString() + "',Ctarih='" + dateçıkış.Text.ToString() + "' where id=" + id + "", bag);
            komut.ExecuteNonQuery();
            bag.Close();
            verilerigöster();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand(" update müsteriler2 set  id='" + txtid.Text.ToString() + "',ad='" + txtad.Text.ToString() + "',soyad='" + txtsoyad.Text.ToString() + "',odano='" + txtodano.Text.ToString() + "',giriştarihi='" + dategiriş.Text.ToString() + "',telefon='" + txttelefon.Text.ToString() + "',Hesap='" + txthesap.Text.ToString() + "',Ctarih='" + dateçıkış.Text.ToString() + "' where id=" + id + "", bag);
            komut.ExecuteNonQuery();
            bag.Close();
            verilerigöster();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bag.Open();
            listView1.Items.Clear();

            SqlCommand komut = new SqlCommand("Select * from müsteriler2 where ad like'%"+textBox1.Text+ "%'"   , bag);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["odano"].ToString());
                ekle.SubItems.Add(oku["giriştarihi"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["Ctarih"].ToString());

                listView1.Items.Add(ekle);





            }
            bag.Close();
        }
    }
}
