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

namespace Dis_Klinigi.Formlar
{
    public partial class HastaKayıt : Form
    {

        
        public HastaKayıt()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ad = txtad.Text;
            string soyad = txtsoyad.Text;
            string tc = txttc.Text;
            string cepTelefonu = msgtlf.Text;
            string cinsiyet = combocinsiyet.Text;
            string adres = richadres.Text;

           
            bool isFormValid = true;
            string errorMessage = "Lütfen gerekli alanları doldurun:\n";

          
            if (string.IsNullOrEmpty(ad))
            {
                isFormValid = false;
                errorMessage += "- Ad alanını doldurun\n";
            }

            if (string.IsNullOrEmpty(soyad))
            {
                isFormValid = false;
                errorMessage += "- Soyad alanını doldurun\n";
            }

            if (string.IsNullOrEmpty(tc))
            {
                isFormValid = false;
                errorMessage += "- TC alanını doldurun\n";
            }

            if (string.IsNullOrEmpty(cepTelefonu))
            {
                isFormValid = false;
                errorMessage += "- Cep Telefonu alanını doldurun\n";
            }

            if (string.IsNullOrEmpty(cinsiyet))
            {
                isFormValid = false;
                errorMessage += "- Cinsiyet alanını seçin\n";
            }

            if (string.IsNullOrEmpty(adres))
            {
                isFormValid = false;
                errorMessage += "- Adres alanını doldurun\n";
            }

            if (!isFormValid)
            {
                MessageBox.Show(errorMessage, "Eksik Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            string query = "INSERT INTO Hastalar (Ad, Soyad, TC, CepTelefonu, Cinsiyet, Adres) " +
                           "VALUES (@Ad, @Soyad, @TC, @CepTelefonu, @Cinsiyet, @Adres)";

            using (SqlConnection conn =SqlKomutlari.SqlBaglanti())
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                // Parametreler ekleniyor
                cmd.Parameters.AddWithValue("@Ad", ad);
                cmd.Parameters.AddWithValue("@Soyad", soyad);
                cmd.Parameters.AddWithValue("@TC", tc);
                cmd.Parameters.AddWithValue("@CepTelefonu", cepTelefonu);
                cmd.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
                cmd.Parameters.AddWithValue("@Adres", adres);

                try
                {
                    conn.Open();  
                    cmd.ExecuteNonQuery();  
                    MessageBox.Show("Kayıt başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttc_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void HastaKayıt_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
       

        private void richislem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngetir_Click(object sender, EventArgs e)
        {
            string tcKimlik = txtgetir.Text;  // TextBox'tan TC kimlik numarasını al

            if (string.IsNullOrEmpty(tcKimlik))
            {
                MessageBox.Show("Lütfen TC kimlik numarasını girin.");
                return;
            }

            LoadIslemler(tcKimlik);
        }
        private void LoadIslemler(string tcKimlik)
        {
              
            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())  
            {
                // SQL sorgusu
                string query = "SELECT IslemAd, IslemTarihi FROM Islemler WHERE TC = @TC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@TC", tcKimlik);  

                DataTable dt = new DataTable();  
                da.Fill(dt);  

                
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void msktarih_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            HastaBilgiGuncelle frmGuncelle = new HastaBilgiGuncelle();
            frmGuncelle.Owner = this; 
            frmGuncelle.Show();  
            this.Hide();




            Form openForm = GetOpenForm(typeof(HastaBilgiGuncelle));
            if (openForm == null)
            {
                HastaBilgiGuncelle frm = new HastaBilgiGuncelle();
                frm.Owner = this;
                frm.Show();
                this.Hide();
            }
            else
            {
                openForm.Show(); 
                this.Hide();
            }

        }



        private Form GetOpenForm(Type formType)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.GetType() == formType)
                {
                    return openForm;
                }
            }
            return null;
        }






    }
}
