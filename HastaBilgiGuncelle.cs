using Dis_Klinigi.Formlar;
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
using System.Windows.Controls;
using System.Windows.Forms;

namespace Dis_Klinigi
{
    public partial class HastaBilgiGuncelle : Form
    {

       
        public HastaBilgiGuncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string tc = txttc.Text;

            if (string.IsNullOrEmpty(tc))
            {
                MessageBox.Show("Lütfen TC kimlik numarasını girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection con = SqlKomutlari.SqlBaglanti())
                {
                    con.Open();

                    string query = @"
                        UPDATE Hastalar 
                        SET 
                            Ad = @Ad,
                            Soyad = @Soyad,
                            CepTelefonu = @CepTelefonu,
                            Cinsiyet = @Cinsiyet,
                            Adres = @Adres
                        WHERE TC = @TC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Ad", txtad.Text);
                        cmd.Parameters.AddWithValue("@Soyad", txtsoyad.Text);
                        cmd.Parameters.AddWithValue("@CepTelefonu", msgtlf.Text);
                        cmd.Parameters.AddWithValue("@Cinsiyet", combocinsiyet.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Adres", richadres.Text);
                        cmd.Parameters.AddWithValue("@TC", tc);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Hasta bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("TC kimlik numarasına ait bir hasta bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }

        public void gridDoldur()
        {
            using (SqlConnection con = SqlKomutlari.SqlBaglanti()) 
            {
                con.Open(); 

                string query = "SELECT TOP (1000) [Ad], [Soyad], [TC], [CepTelefonu], [Cinsiyet], [Adres] FROM [dbo].[Hastalar]";

               
                using (SqlCommand kmt = new SqlCommand(query, con))
                using (SqlDataAdapter adap = new SqlDataAdapter(kmt))
                {
                    DataTable dt = new DataTable();
                    adap.Fill(dt); 
                    uyeliste.DataSource = dt; 
                }
            }


        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();

        }

        private void richadres_TextChanged(object sender, EventArgs e)
        {

        }

        private void HastaBilgiGuncelle_Load(object sender, EventArgs e)
        {

            this.MaximizeBox = false;

        }

        private void HastaBilgiGuncelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        private void HastaBilgiGuncelle_Resize(object sender, EventArgs e)
        {

        }

        private void HastaBilgiGuncelle_Load_1(object sender, EventArgs e)
        {
            uyeliste.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            uyeliste.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            uyeliste.AllowUserToResizeColumns = true;
            uyeliste.AllowUserToResizeRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gridDoldur();
        }

        private void uyeliste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txttc.Text = uyeliste.CurrentRow.Cells["TC"].Value.ToString();
            txtad.Text = uyeliste.CurrentRow.Cells["AD"].Value.ToString();
            txtsoyad.Text = uyeliste.CurrentRow.Cells["Soyad"].Value.ToString();
            combocinsiyet.Text = uyeliste.CurrentRow.Cells["Cinsiyet"].Value.ToString();
            msgtlf.Text = uyeliste.CurrentRow.Cells["CepTelefonu"].Value.ToString();
            richadres.Text = uyeliste.CurrentRow.Cells["Adres"].Value.ToString();

        }
    }
}
