using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dis_Klinigi
{
    public partial class PaswordChange : Form
    {
        public PaswordChange()
        {
            InitializeComponent();
        }

        private void PaswordChange_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mevcutSifre = txteski.Text;
            string yeniSifre = txtyeni.Text;
            string yeniSifreTekrar = txtrepyeni.Text;
            string kullaniciAdi = txtkulladi.Text; 

        
            if (string.IsNullOrWhiteSpace(mevcutSifre) || string.IsNullOrWhiteSpace(yeniSifre) || string.IsNullOrWhiteSpace(yeniSifreTekrar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (yeniSifre != yeniSifreTekrar)
            {
                MessageBox.Show("Yeni şifreler eşleşmiyor. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                try
                {
                    conn.Open();

                 
                    string query = "SELECT * FROM Users WHERE Name = @KullaniciAdi AND sifre = @MevcutSifre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@MevcutSifre", mevcutSifre);   

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);

                    
                    if (dt.Rows.Count > 0)
                    {
                    
                        string updateQuery = "UPDATE Users SET sifre = @YeniSifre WHERE Name = @KullaniciAdi";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@YeniSifre", yeniSifre);
                        updateCmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                   
                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Şifreniz başarıyla değiştirilmiştir.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Mevcut şifre yanlış. Lütfen tekrar kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();

        }
    }
}
