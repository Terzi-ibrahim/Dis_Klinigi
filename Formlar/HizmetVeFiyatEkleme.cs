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
    public partial class HizmetVeFiyatEkleme : Form
    {
       

        public HizmetVeFiyatEkleme()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable hizmetler = HizmetleriGetir();
            dataGridView1.DataSource = hizmetler;


        }
        public DataTable HizmetleriGetir()
        {
            using (SqlConnection connection = SqlKomutlari.SqlBaglanti())
            {
                string query = "SELECT * FROM Hizmetler"; 
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable hizmetlerTable = new DataTable();

                adapter.Fill(hizmetlerTable);
                return hizmetlerTable;
            }
        }

        private void HizmetVeFiyatEkleme_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void btnhizmet_Click(object sender, EventArgs e)
        {
       
            string hizmetAdi = txthizxek.Text;
            decimal fiyat;
            if (!decimal.TryParse(txthizfiyek.Text, out fiyat))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.");
                return;
            }


          
            HizmetEkle(hizmetAdi, fiyat);

          
            MessageBox.Show("Hizmet başarıyla eklendi.");
            TemizleForm();
            ListeyiGuncelle();
        }


        public void HizmetEkle(string hizmetAdi, decimal fiyat)
        {
            using (SqlConnection connection = SqlKomutlari.SqlBaglanti())
            {
                string query = "INSERT INTO Hizmetler (HizmetAdi, Fiyat ) VALUES (@HizmetAdi, @Fiyat)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HizmetAdi", hizmetAdi);
                command.Parameters.AddWithValue("@Fiyat", fiyat);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void FiyatGuncelle(int hizmetId, decimal yeniFiyat)
        {
            using (SqlConnection connection = SqlKomutlari.SqlBaglanti())
            {
                string query = "UPDATE Hizmetler SET Fiyat = @YeniFiyat WHERE Id = @HizmetId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@YeniFiyat", yeniFiyat);
                command.Parameters.AddWithValue("@HizmetId", hizmetId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void TemizleForm()
        {
            txthizxek.Clear();
            txthizfiyek.Clear();
            txtıdgun.Clear();
            txthizfiyatgün.Clear();
        }

        private void ListeyiGuncelle()
        {
            DataTable hizmetler = HizmetleriGetir();
            dataGridView1.DataSource = hizmetler;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            int hizmetId;
            if (!int.TryParse(txtıdgun.Text, out hizmetId))
            {
                MessageBox.Show("Lütfen geçerli bir Hizmet ID giriniz.");
                return;
            }
            decimal yeniFiyat;
            if (!decimal.TryParse(txthizfiyatgün.Text, out yeniFiyat))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.");
                return;
            }

           
            FiyatGuncelle(hizmetId, yeniFiyat);

          
            MessageBox.Show("Hizmet fiyatı başarıyla güncellendi.");
            TemizleForm();
            ListeyiGuncelle();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txthizıdsil.Text))
            {
                int hizmetId;
                if (int.TryParse(txthizıdsil.Text, out hizmetId))
                {
                    bool silindi = HizmetSil(hizmetId);
                    if (silindi)
                    {
                        MessageBox.Show("Hizmet başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Hizmet silinirken bir hata oluştu veya ID bulunamadı.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir ID girin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir ID girin.");
            }

            txthizıdsil.Clear();



        }
        public bool HizmetSil(int id)
        {
            using (SqlConnection connection = SqlKomutlari.SqlBaglanti())
            {
                string query = "DELETE FROM Hizmetler WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery(); 
                    return result > 0; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                    return false;
                }
            }


        }
    }
}

