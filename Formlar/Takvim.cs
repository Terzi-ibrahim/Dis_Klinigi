using Guna.UI2.WinForms.Suite;
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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Dis_Klinigi.Formlar
{
    public partial class Takvim : Form
    {


       
        public Takvim()
        {
            InitializeComponent();

        }


        private void lstAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public class Doctor
        {
            public int DoktorID { get; set; }
            public string DoktorAdiSoyadi { get; set; }

            public override string ToString()
            {
                return DoktorAdiSoyadi;
            }
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {

        
            if (comboBox1.SelectedIndex == -1 || cmbodk.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            DateTime randevuTarihi = daterndv.Value; 

       
            int saat = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            int dakika = Convert.ToInt32(cmbodk.SelectedItem.ToString());

            
            DateTime randevuTarihiOnly = randevuTarihi.Date;

        
            TimeSpan randevuSaati = new TimeSpan(saat, dakika, 0);

   
            Doctor selectedDoctor = (Doctor)comboBox2.SelectedItem;

       
            if (selectedDoctor == null)
            {
                MessageBox.Show("Lütfen bir doktor seçin.");
                return;
            }


            string hastaTC = txtTC.Text.Trim();

         
            if (!IsHastaValid(hastaTC))
            {
                MessageBox.Show("Geçersiz Hasta TC numarası.");
                return;
            }

          
            if (IsRandevuOccupiedForPatient(randevuTarihiOnly, randevuSaati, hastaTC))
            {
                MessageBox.Show("Bu tarihte ve saatte bu hastaya ait bir randevu zaten mevcut.");
                return;
            }

      
            if (IsRandevuOccupiedForDoctor(randevuTarihiOnly, randevuSaati, selectedDoctor.DoktorID))
            {
                MessageBox.Show("Bu tarihte ve saatte bu doktora ait bir randevu zaten mevcut.");
                return;
            }

        
            string aciklama = cmbIslem.Text.Trim(); 

           
            RandevuEkle(hastaTC, randevuTarihiOnly, randevuSaati, selectedDoctor.DoktorID, aciklama);
            DateTime today = DateTime.Today;


            LoadDoktorRandevular(today);


        }

        private void RandevuEkle(string hastaTC, DateTime randevuTarihi, TimeSpan randevuSaati, int doktorID, string aciklama)
        {
            
            string query = "INSERT INTO Randevular (HastaTC, RandevuTarihi, RandevuSaati, DoktorID, Aciklama) " +
                           "VALUES (@HastaTC, @RandevuTarihi, @RandevuSaati, @DoktorID, @Aciklama)";

            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                      
                        cmd.Parameters.AddWithValue("@HastaTC", hastaTC);
                        cmd.Parameters.AddWithValue("@RandevuTarihi", randevuTarihi); 
                        cmd.Parameters.AddWithValue("@RandevuSaati", randevuSaati); 

                        cmd.Parameters.AddWithValue("@DoktorID", doktorID);

                        
                        if (string.IsNullOrWhiteSpace(aciklama))
                        {
                            cmd.Parameters.AddWithValue("@Aciklama", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Aciklama", aciklama);
                        }

                     
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Randevu başarıyla eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Randevu eklenirken bir hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

     
        private bool IsRandevuOccupiedForPatient(DateTime randevuTarihi, TimeSpan randevuSaati, string hastaTC)
        {
            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Randevular 
            WHERE HastaTC = @HastaTC 
            AND CONVERT(DATE, RandevuTarihi) = @RandevuTarihiDate 
            AND RandevuSaati = @RandevuSaati";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HastaTC", hastaTC);
                cmd.Parameters.AddWithValue("@RandevuTarihiDate", randevuTarihi.Date); 
                cmd.Parameters.AddWithValue("@RandevuSaati", randevuSaati); 

                conn.Open();
                int randevuCount = (int)cmd.ExecuteScalar();

                return randevuCount > 0; 
            }
        }


        private bool IsRandevuOccupiedForDoctor(DateTime randevuTarihi, TimeSpan randevuSaati, int doktorID)
        {
            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Randevular 
            WHERE DoktorID = @DoktorID 
            AND CONVERT(DATE, RandevuTarihi) = @RandevuTarihiDate 
            AND RandevuSaati = @RandevuSaati";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoktorID", doktorID);
                cmd.Parameters.AddWithValue("@RandevuTarihiDate", randevuTarihi.Date); 
                cmd.Parameters.AddWithValue("@RandevuSaati", randevuSaati);

                conn.Open();
                int randevuCount = (int)cmd.ExecuteScalar();

                return randevuCount > 0;
            }
        }


        private bool IsHastaValid(string hastaTC)
        {
            string query = "SELECT COUNT(*) FROM [dbo].[Hastalar] WHERE TC = @HastaTC";

            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HastaTC", hastaTC);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0; 
            }
        }

        private void LoadRandevular(DateTime? filterDate = null)
        {
            string query = @"
        SELECT TOP (1000)
            R.HastaTC,
            R.RandevuTarihi,
            R.Aciklama,
            R.RandevuSaati,
            D.DoktorAdi + ' ' + D.DoktorSoyadi AS DoktorAdSoyad
        FROM [dbo].[Randevular] R
        JOIN [dbo].[Doktorlar] D ON R.DoktorID = D.DoktorID";

            
            if (filterDate.HasValue)
            {
                query += " WHERE CAST(R.[RandevuTarihi] AS DATE) = @FilterDate";
            }
            Console.WriteLine(query);
            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

           
                if (filterDate.HasValue)
                {
                    da.SelectCommand.Parameters.AddWithValue("@FilterDate", filterDate.Value.Date);
                }

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void txtAppointment_TextChanged(object sender, EventArgs e)
        {

        }

        private void Takvim_Load(object sender, EventArgs e)
        {

           
            for (int i = 0; i < 24; i++)
            {
                comboBox1.Items.Add(i.ToString("D2"));  
            }

            for (int i = 0; i < 60; i += 5)
            {
                cmbodk.Items.Add(i.ToString("D2")); 
            }

            comboBox1.SelectedIndex = 0;
            cmbodk.SelectedIndex = 0;




            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;


            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellContentDoubleClick);
          
            DateTime today = DateTime.Today;

          
            LoadDoktorRandevular(today);

            LoadDoktorlar(comboBoxDoktor);

            LoadDoktorlarComboBox(comboBox2);
            HizmetleriGetirVeDoldur(cmbIslem);

        }
        private void LoadDoktorRandevular(DateTime date)
        {
            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                string query = @"
    SELECT TOP (1000) 
        R.RandevuID AS 'RandevuID',
        R.HastaTC AS 'HastaTC',
        H.Ad AS 'HastaAdi',
        H.Soyad AS 'HastaSoyadi',
        R.Aciklama AS 'Aciklama',
        R.RandevuTarihi AS 'RandevuTarihi',
        R.RandevuSaati AS 'RandevuSaati',
        D.DoktorAdi + ' ' + D.DoktorSoyadi AS 'DoktorAdSoyad'
    FROM Randevular R
    INNER JOIN Doktorlar D ON R.DoktorID = D.DoktorID
    INNER JOIN Hastalar H ON R.HastaTC = H.TC
    WHERE CAST(R.RandevuTarihi AS DATE) = @Date";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                var dataList = new List<object>();

                while (reader.Read())
                {
                    dataList.Add(new
                    {
                        RandevuID = reader["RandevuID"].ToString(),
                        HastaTC = reader["HastaTC"].ToString(),
                        HastaAdi = reader["HastaAdi"].ToString(),
                        HastaSoyadi = reader["HastaSoyadi"].ToString(),
                        Aciklama = reader["Aciklama"].ToString(),
                        RandevuTarihi = Convert.ToDateTime(reader["RandevuTarihi"]).ToString("yyyy-MM-dd"),
                        RandevuSaati = reader["RandevuSaati"].ToString(),
                        DoktorAdSoyad = reader["DoktorAdSoyad"].ToString(),
                    });
                }

                dataGridView1.DataSource = dataList;

                if (dataGridView1.Columns.Count > 0)
                {
                    if (dataGridView1.Columns["RandevuID"] != null)
                        dataGridView1.Columns["RandevuID"].HeaderText = "Randevu ID";

                    if (dataGridView1.Columns["HastaTC"] != null)
                        dataGridView1.Columns["HastaTC"].HeaderText = "Hasta TC";

                    if (dataGridView1.Columns["HastaAdi"] != null)
                        dataGridView1.Columns["HastaAdi"].HeaderText = "Hasta Adı";

                    if (dataGridView1.Columns["HastaSoyadi"] != null)
                        dataGridView1.Columns["HastaSoyadi"].HeaderText = "Hasta Soyadı";

                    if (dataGridView1.Columns["Aciklama"] != null)
                        dataGridView1.Columns["Aciklama"].HeaderText = "Açıklama";

                    if (dataGridView1.Columns["RandevuSaati"] != null)
                        dataGridView1.Columns["RandevuSaati"].HeaderText = "Randevu Saati";

                    if (dataGridView1.Columns["RandevuTarihi"] != null)
                        dataGridView1.Columns["RandevuTarihi"].HeaderText = "Randevu Tarihi";

                    if (dataGridView1.Columns["DoktorAdSoyad"] != null)
                        dataGridView1.Columns["DoktorAdSoyad"].HeaderText = "Doktor Adı Soyadı";
                }
            }



        }
        private void LoadDoktorlarComboBox(System.Windows.Forms.ComboBox comboBoxDoktor)
        {
            string query = "SELECT DoktorID, DoktorAdi, DoktorSoyadi FROM Doktorlar";
            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                comboBox2.Items.Clear(); 
                while (reader.Read())
                {
                  
                    Doctor doctor = new Doctor
                    {
                        DoktorID = Convert.ToInt32(reader["DoktorID"]),
                        DoktorAdiSoyadi = reader["DoktorAdi"].ToString() + " " + reader["DoktorSoyadi"].ToString()
                    };
                    comboBox2.Items.Add(doctor);  
                }
                reader.Close();
            }
        }
        private void LoadDoktorlar(System.Windows.Forms.ComboBox comboBoxDoktor)
        {
            string query = "SELECT DoktorID, DoktorAdi, DoktorSoyadi FROM Doktorlar";
            using (SqlConnection conn = SqlKomutlari.SqlBaglanti( ))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                comboBoxDoktor.Items.Clear();  
                while (reader.Read())
                {
                    
                    Doctor doctor = new Doctor
                    {
                        DoktorID = Convert.ToInt32(reader["DoktorID"]),
                        DoktorAdiSoyadi = reader["DoktorAdi"].ToString() + " " + reader["DoktorSoyadi"].ToString()
                    };
                    comboBoxDoktor.Items.Add(doctor); 
                }
                reader.Close();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuları seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Seçilen randevuları silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            List<int> selectedRandevuIDs = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
               
                if (row.Cells["RandevuID"].Value != null)
                {
                    selectedRandevuIDs.Add(Convert.ToInt32(row.Cells["RandevuID"].Value));
                }
            }

            if (selectedRandevuIDs.Count == 0)
            {
                MessageBox.Show("Silinecek geçerli randevular bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                conn.Open();

                string deleteQuery = "DELETE FROM Randevular WHERE RandevuID = @RandevuID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    int rowsAffected = 0;

                    foreach (var randevuID in selectedRandevuIDs)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@RandevuID", randevuID);
                        rowsAffected += cmd.ExecuteNonQuery();
                    }

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Seçilen randevular başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRandevular();
                    }
                    else
                    {
                        MessageBox.Show("Randevular silinirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            DateTime today = DateTime.Today;
            LoadDoktorRandevular(today);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns.Contains("RandevuID"))
            {
                if (e.ColumnIndex == dataGridView1.Columns["RandevuID"].Index)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    if (selectedRow.Cells["RandevuID"].Value != null)
                    {
                        int randevuID = Convert.ToInt32(selectedRow.Cells["RandevuID"].Value);

                        DialogResult dialogResult = MessageBox.Show("Seçilen randevuyu silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                        using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM Randevular WHERE RandevuID = @RandevuID";
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@RandevuID", randevuID);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Seçilen randevu başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    DateTime today = DateTime.Today;
                                
                                    LoadDoktorRandevular(today);
                                }
                                else
                                {
                                    MessageBox.Show("Randevu silinirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Randevu ID'si bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("RandevuID kolonu bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void button9_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            if (comboBoxDoktor.SelectedItem == null)
            {
                MessageBox.Show("Lütfen doktor seçin.");
                return;
            }

            string selectedDoctor = comboBoxDoktor.SelectedItem.ToString();

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                string query = @"
        SELECT TOP (1000) 
            R.RandevuID, -- Randevu ID alanını ekliyoruz
            R.HastaTC,
            R.RandevuTarihi,
            R.Aciklama,
            R.RandevuSaati,
            D.DoktorAdi + ' ' + D.DoktorSoyadi AS DoktorAdSoyad,
            H.Ad AS HastaAdi,
            H.Soyad AS HastaSoyadi
        FROM Randevular R
        INNER JOIN Doktorlar D ON R.DoktorID = D.DoktorID
        INNER JOIN Hastalar H ON R.HastaTC = H.TC
        WHERE R.RandevuTarihi BETWEEN @StartDate AND @EndDate
          AND (D.DoktorAdi + ' ' + D.DoktorSoyadi) = @DoktorAdiSoyadi";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@DoktorAdiSoyadi", selectedDoctor);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                var dataList = new List<object>();

                while (reader.Read())
                {
                    dataList.Add(new
                    {
                        RandevuID = reader["RandevuID"].ToString(), 
                        HastaTC = reader["HastaTC"].ToString(),
                        HastaAdi = reader["HastaAdi"].ToString(),
                        HastaSoyadi = reader["HastaSoyadi"].ToString(),
                        Aciklama = reader["Aciklama"].ToString(),
                        RandevuSaati = reader["RandevuSaati"].ToString(),
                        RandevuTarihi = Convert.ToDateTime(reader["RandevuTarihi"]).ToString("yyyy-MM-dd"),
                    });
                }

                dataGridView1.DataSource = dataList;

                
                if (dataGridView1.Columns.Contains("RandevuID"))
                    dataGridView1.Columns["RandevuID"].HeaderText = "Randevu ID"; 

                if (dataGridView1.Columns.Contains("HastaTC"))
                    dataGridView1.Columns["HastaTC"].HeaderText = "Hasta TC";

                if (dataGridView1.Columns.Contains("HastaAdi"))
                    dataGridView1.Columns["HastaAdi"].HeaderText = "Hasta Adı";

                if (dataGridView1.Columns.Contains("HastaSoyadi"))
                    dataGridView1.Columns["HastaSoyadi"].HeaderText = "Hasta Soyadı";

                if (dataGridView1.Columns.Contains("Aciklama"))
                    dataGridView1.Columns["Aciklama"].HeaderText = "Açıklama";

                if (dataGridView1.Columns.Contains("RandevuSaati"))
                    dataGridView1.Columns["RandevuSaati"].HeaderText = "Randevu Saati";

                if (dataGridView1.Columns.Contains("RandevuTarihi"))
                    dataGridView1.Columns["RandevuTarihi"].HeaderText = "Randevu Tarihi";
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbIslem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void HizmetleriGetirVeDoldur(System.Windows.Forms.ComboBox comboBox)
        {
            using (SqlConnection connection = SqlKomutlari.SqlBaglanti())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT HizmetAdi FROM Hizmetler"; 
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                      
                        comboBox.Items.Add(reader["HizmetAdi"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }
    }
}
