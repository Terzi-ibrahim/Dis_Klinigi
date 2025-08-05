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
    public partial class Ücret_Planlama : Form
    {
      

        public Ücret_Planlama()
        {
            InitializeComponent();
        }

        private void Ücret_Planlama_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
            DoktorlariYukle();
            HizmetTurleriniYukle();
            DataGridViewHazirla();
        }
        private void DataGridViewHazirla()
        {
            dataGridView1.Columns.Add("DoktorAdi", "Doktor");
            dataGridView1.Columns.Add("HizmetAdi", "Hizmet");
            dataGridView1.Columns.Add("HizmetAdedi", "Adet");
            dataGridView1.Columns.Add("Fiyat", "Birim Fiyat");
            dataGridView1.Columns.Add("ToplamFiyat", "Toplam Fiyat");
        }
        private void DoktorlariYukle()
        {
            using (SqlConnection connection = SqlKomutlari.SqlBaglanti())
            {
                string query = "SELECT  DoktorAdi FROM Doktorlar";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable doktorTable = new DataTable();

                adapter.Fill(doktorTable);
                cmbDoktorlar.DataSource = doktorTable;
                cmbDoktorlar.DisplayMember = "DoktorAdi";

            }
        }

        private void HizmetTurleriniYukle()
        {
            using (SqlConnection connection = SqlKomutlari.SqlBaglanti())
            {
                string query = "SELECT  HizmetAdi, Fiyat FROM Hizmetler";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable hizmetTable = new DataTable();

                adapter.Fill(hizmetTable);
                cmbHizmetTurleri.DataSource = hizmetTable;
                cmbHizmetTurleri.DisplayMember = "HizmetAdi";

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnhesapla_Click(object sender, EventArgs e)
        {
            
            if (cmbDoktorlar.SelectedValue != null && cmbHizmetTurleri.SelectedValue != null &&
                !string.IsNullOrWhiteSpace(combohizmet.Text) &&
                int.TryParse(combohizmet.Text, out int hizmetAdedi)) 
            {
                try
                {
                  
                    DataRowView selectedHizmet = (DataRowView)cmbHizmetTurleri.SelectedItem;
                    decimal fiyat = Convert.ToDecimal(selectedHizmet["Fiyat"]); 
                    string hizmetAdi = selectedHizmet["HizmetAdi"].ToString();

            
                    decimal toplamFiyat = fiyat * hizmetAdedi;

               
                    dataGridView1.Rows.Add(
                        cmbDoktorlar.Text, 
                        hizmetAdi,         
                        hizmetAdedi,     
                        fiyat,             
                        toplamFiyat      
                    );

              
                    GenelToplamGuncelle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hesaplama sırasında bir hata oluştu: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doğru doldurun ve hizmet adedini seçin.");
            }
        }
        private void GenelToplamGuncelle()
        {
            decimal genelToplam = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                genelToplam += Convert.ToDecimal(row.Cells["ToplamFiyat"].Value);
            }

            lbltop.Text = $"Toplam Fiyat: {genelToplam:C}";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void combohizmet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btntemiz_Click(object sender, EventArgs e)
        {
           
            dataGridView1.Rows.Clear();


            lbltop.Text = "Toplam Fiyat : 0 TL";
        }
    }
}
