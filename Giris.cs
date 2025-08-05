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
using System.Windows.Controls;
using Dis_Klinigi.Formlar;


namespace Dis_Klinigi
{
    public partial class Giris : Form
    {


        

        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {

        }

        private void ıconButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            DoktorKayıt  dkt= new DoktorKayıt ();
            dkt.Show();
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text) || string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                MessageBox.Show("Lütfen gerekli alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                try
                {
                    conn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.CommandText = "SELECT * FROM Users WHERE Name = @Name AND sifre = @Sifre";
                    komut.Connection = conn;

                   
                    komut.Parameters.AddWithValue("@Name", guna2TextBox1.Text);
                    komut.Parameters.AddWithValue("@Sifre", guna2TextBox2.Text);

                    SqlDataAdapter adap = new SqlDataAdapter();
                    adap.SelectCommand = komut;
                    DataTable dt = new DataTable();
                    adap.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Anasayfa git_AnaSayfa = new Anasayfa();
                        git_AnaSayfa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adınız ve Şifreniz yanlıştır.");
                        guna2TextBox1.Clear();
                        guna2TextBox2.Clear();
                        guna2TextBox1.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
                }
            }

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public static implicit operator Giris(Anasayfa v)
        {
            throw new NotImplementedException();
        }
    }
}
