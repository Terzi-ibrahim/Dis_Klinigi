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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Dis_Klinigi.Formlar
{
    public partial class Hastalar : Form
    {
        

        public Hastalar()
        {
            InitializeComponent();
        }

        private void VerileriGoster()
        {
            using (SqlConnection baglanti = SqlKomutlari.SqlBaglanti())
            {
                string sorgu = "SELECT TOP (1000) [ID], [Ad], [Soyad], [TC], [CepTelefonu], [Cinsiyet], [Adres] FROM [dbo].[Hastalar]";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagrid.DataSource = dt;
            }
        }
        private void Hastalar_Load(object sender, EventArgs e)
        {
            datagrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            datagrid.AllowUserToResizeColumns = true;
            datagrid.AllowUserToResizeRows = false;
            VerileriGoster();



        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();
        }

        private void btnsorgu_Click(object sender, EventArgs e)
        {
        
            string tc = txtfilter.Text.Trim();

            try
            {
                using (SqlConnection con = SqlKomutlari.SqlBaglanti())
                {
                    con.Open();


                    string query;
                    if (string.IsNullOrEmpty(tc))
                    {
                        query = "select Ad,Soyad ,TC,CepTelefonu,Cinsiyet,Adres  from Hastalar";
                    }
                    else
                    {
                        query = "SELECT * FROM Hastalar WHERE TC = @TC";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        if (!string.IsNullOrEmpty(tc))
                        {
                            cmd.Parameters.AddWithValue("@TC", tc);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);


                            datagrid.DataSource = dt;


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndzn_Click(object sender, EventArgs e)
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

        private void btnsil_Click(object sender, EventArgs e)
        {
            string tc = txtfilter.Text.Trim();

           
            if (string.IsNullOrEmpty(tc) && datagrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek hastanın TC kimlik numarasını girin veya bir hasta seçin.",
                                "Hata",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

     
            if (datagrid.SelectedRows.Count > 0)
            {
                var selectedCellValue = datagrid.SelectedRows[0].Cells["TC"].Value;
                if (selectedCellValue == null || string.IsNullOrEmpty(selectedCellValue.ToString()))
                {
                    MessageBox.Show("Seçili satırda TC bilgisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tc = selectedCellValue.ToString().Trim();
            }

            try
            {
               
                using (SqlConnection con = SqlKomutlari.SqlBaglanti())
                {
                    con.Open();

                   
                    string checkRandevularQuery = "SELECT COUNT(*) FROM Randevular WHERE HastaTC = @TC";
                    int randevuCount = 0;

                    using (SqlCommand checkCmd = new SqlCommand(checkRandevularQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@TC", tc);
                        randevuCount = (int)checkCmd.ExecuteScalar(); // Randevu sayısını al
                    }

                    
                    if (randevuCount > 0)
                    {
                        DialogResult randevuSilOnay = MessageBox.Show(
                            $"Bu hastanın {randevuCount} randevusu bulunmaktadır. Randevular da iptal edilecek. Onaylıyor musunuz?",
                            "Randevular İptal Edilecek",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (randevuSilOnay != DialogResult.Yes)
                        {
                           
                            MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    
                    DialogResult hastaSilOnay = MessageBox.Show("Bu hastayı silmek istediğinizden emin misiniz?",
                                                                "Silme Onayı",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Warning);

                    if (hastaSilOnay != DialogResult.Yes)
                    {
                        MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    
                    string deleteRandevularQuery = "DELETE FROM Randevular WHERE HastaTC = @TC";
                    using (SqlCommand cmdRandevular = new SqlCommand(deleteRandevularQuery, con))
                    {
                        cmdRandevular.Parameters.AddWithValue("@TC", tc);
                        cmdRandevular.ExecuteNonQuery();
                    }

                   
                    string deleteIslemlerQuery = "DELETE FROM Islemler WHERE TC = @TC";
                    using (SqlCommand cmdIslemler = new SqlCommand(deleteIslemlerQuery, con))
                    {
                        cmdIslemler.Parameters.AddWithValue("@TC", tc);
                        cmdIslemler.ExecuteNonQuery();
                    }

             
                    string deleteHastalarQuery = "DELETE FROM Hastalar WHERE TC = @TC";
                    using (SqlCommand cmdHastalar = new SqlCommand(deleteHastalarQuery, con))
                    {
                        cmdHastalar.Parameters.AddWithValue("@TC", tc);
                        int rowsAffected = cmdHastalar.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Hasta ve ilişkili randevuları başarıyla silindi.",
                                            "Başarılı",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Silinecek hasta bulunamadı.",
                                            "Hata",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL hatası oluştu: " + sqlEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        
            txtfilter.Clear();
            btnsorgu_Click(sender, e);


        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
