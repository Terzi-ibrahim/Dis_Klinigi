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
    public partial class DoktorListesi : Form
    {  private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        public DoktorListesi()
        {
            InitializeComponent();
        }

        private void DoktorListesi_Load(object sender, EventArgs e)
        {
            DoktorlariGetir();
            AyarlariUygula();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        // DataGridView ayarları
        private void AyarlariUygula()
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
        }

        // Doktorları veritabanından çek ve datagridview'e bağla
        private void DoktorlariGetir()
        {
            string query = "SELECT DoktorID, DoktorAdi, DoktorSoyadi FROM Doktorlar";

            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        // Yeni doktor ekleme butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string doktorAdi = txtDoktorAdi.Text.Trim();
            string doktorSoyadi = txtDoktorSoyadi.Text.Trim();

            if (string.IsNullOrEmpty(doktorAdi) || string.IsNullOrEmpty(doktorSoyadi))
            {
                MessageBox.Show("Doktor adı ve soyadı boş olamaz.");
                return;
            }

            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                string query = "INSERT INTO Doktorlar (DoktorAdi, DoktorSoyadi) VALUES (@DoktorAdi, @DoktorSoyadi)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoktorAdi", doktorAdi);
                    cmd.Parameters.AddWithValue("@DoktorSoyadi", doktorSoyadi);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Doktor başarıyla eklendi." : "Ekleme başarısız.");
                        if (rows > 0) DoktorlariGetir();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                    }
                }
            }
        }

        // Doktor güncelleme butonu
        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtgunıd.Text.Trim(), out int doktorId))
            {
                MessageBox.Show("Lütfen geçerli bir doktor ID'si giriniz.");
                return;
            }

            string doktorAdi = txtdokgun.Text.Trim();
            string doktorSoyadi = txtgundoksoy.Text.Trim();

            if (string.IsNullOrEmpty(doktorAdi) || string.IsNullOrEmpty(doktorSoyadi))
            {
                MessageBox.Show("Doktor adı ve soyadı boş olamaz.");
                return;
            }

            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                string query = "UPDATE Doktorlar SET DoktorAdi = @DoktorAdi, DoktorSoyadi = @DoktorSoyadi WHERE DoktorID = @DoktorID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoktorAdi", doktorAdi);
                    cmd.Parameters.AddWithValue("@DoktorSoyadi", doktorSoyadi);
                    cmd.Parameters.AddWithValue("@DoktorID", doktorId);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Doktor başarıyla güncellendi." : "Güncelleme başarısız.");
                        if (rows > 0) DoktorlariGetir();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                    }
                }
            }
        }

        // Doktor silme butonu
        private void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtsilid.Text.Trim(), out int doktorID))
            {
                MessageBox.Show("Lütfen geçerli bir Doktor ID girin!");
                return;
            }

            DialogResult result = MessageBox.Show($"Doktor ID {doktorID} silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            DoktorSil(doktorID);
        }

        // Doktor silme işlemi
        private void DoktorSil(int doktorID)
        {
            using (SqlConnection conn = SqlKomutlari.SqlBaglanti())
            {
                string query = "DELETE FROM Doktorlar WHERE DoktorID = @DoktorID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoktorID", doktorID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Doktor başarıyla silindi." : "Belirtilen ID ile eşleşen doktor bulunamadı.");
                        if (rows > 0) DoktorlariGetir();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                    }
                }
            }
        }

        // DataGridView satırına çift tıklayınca silme onayı
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count)
                return;

            if (dataGridView1.Rows[rowIndex].Cells["DoktorID"].Value == null)
                return;

            int doktorID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["DoktorID"].Value);

            DialogResult result = MessageBox.Show($"Doktor ID {doktorID} silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DoktorSil(doktorID);
            }
        }

        // Yenile butonu (doktorları tekrar yükler)
        private void button2_Click(object sender, EventArgs e)
        {
            DoktorlariGetir();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
