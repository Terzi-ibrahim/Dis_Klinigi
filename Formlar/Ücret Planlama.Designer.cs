namespace Dis_Klinigi.Formlar
{
    partial class Ücret_Planlama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btntemiz = new Button();
            lbltop = new Label();
            label1 = new Label();
            btnhesapla = new Button();
            cmbDoktorlar = new ComboBox();
            dataGridView1 = new DataGridView();
            combohizmet = new ComboBox();
            label11 = new Label();
            label8 = new Label();
            label10 = new Label();
            cmbHizmetTurleri = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btntemiz);
            panel1.Controls.Add(lbltop);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnhesapla);
            panel1.Controls.Add(cmbDoktorlar);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(combohizmet);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cmbHizmetTurleri);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1235, 719);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btntemiz
            // 
            btntemiz.Anchor = AnchorStyles.Top;
            btntemiz.Font = new Font("Arial Rounded MT Bold", 9.75F);
            btntemiz.Location = new Point(504, 297);
            btntemiz.Name = "btntemiz";
            btntemiz.Size = new Size(184, 34);
            btntemiz.TabIndex = 59;
            btntemiz.Text = "Listeyi Temizle";
            btntemiz.UseVisualStyleBackColor = true;
            btntemiz.Click += btntemiz_Click;
            // 
            // lbltop
            // 
            lbltop.Anchor = AnchorStyles.Top;
            lbltop.AutoSize = true;
            lbltop.Font = new Font("Arial Rounded MT Bold", 12F);
            lbltop.Location = new Point(419, 387);
            lbltop.Name = "lbltop";
            lbltop.Size = new Size(0, 18);
            lbltop.TabIndex = 58;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(262, 146);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 56;
            label1.Text = "Doktor Seçiniz";
            // 
            // btnhesapla
            // 
            btnhesapla.Anchor = AnchorStyles.Top;
            btnhesapla.Font = new Font("Arial Rounded MT Bold", 9.75F);
            btnhesapla.Location = new Point(709, 297);
            btnhesapla.Name = "btnhesapla";
            btnhesapla.Size = new Size(184, 34);
            btnhesapla.TabIndex = 55;
            btnhesapla.Text = "Hizmet Ekle";
            btnhesapla.UseVisualStyleBackColor = true;
            btnhesapla.Click += btnhesapla_Click;
            // 
            // cmbDoktorlar
            // 
            cmbDoktorlar.Anchor = AnchorStyles.Top;
            cmbDoktorlar.FormattingEnabled = true;
            cmbDoktorlar.Location = new Point(262, 172);
            cmbDoktorlar.Name = "cmbDoktorlar";
            cmbDoktorlar.Size = new Size(157, 23);
            cmbDoktorlar.TabIndex = 49;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(262, 201);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(631, 90);
            dataGridView1.TabIndex = 54;
            dataGridView1.CellContentClick += dataGridView2_CellContentClick;
            // 
            // combohizmet
            // 
            combohizmet.Anchor = AnchorStyles.Top;
            combohizmet.FormattingEnabled = true;
            combohizmet.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            combohizmet.Location = new Point(688, 172);
            combohizmet.Name = "combohizmet";
            combohizmet.Size = new Size(205, 23);
            combohizmet.TabIndex = 53;
            combohizmet.SelectedIndexChanged += combohizmet_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Font = new Font("Arial Rounded MT Bold", 9.75F);
            label11.Location = new Point(688, 144);
            label11.Name = "label11";
            label11.Size = new Size(94, 15);
            label11.TabIndex = 52;
            label11.Text = "Hizmet Adeti:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(236, 104);
            label8.Name = "label8";
            label8.Size = new Size(116, 18);
            label8.TabIndex = 48;
            label8.Text = "Fiyatlandırma";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 9.75F);
            label10.Location = new Point(439, 146);
            label10.Name = "label10";
            label10.Size = new Size(144, 15);
            label10.TabIndex = 51;
            label10.Text = "Hizmet Türü Seçiniz :";
            // 
            // cmbHizmetTurleri
            // 
            cmbHizmetTurleri.Anchor = AnchorStyles.Top;
            cmbHizmetTurleri.FormattingEnabled = true;
            cmbHizmetTurleri.Location = new Point(438, 172);
            cmbHizmetTurleri.Name = "cmbHizmetTurleri";
            cmbHizmetTurleri.Size = new Size(220, 23);
            cmbHizmetTurleri.TabIndex = 50;
            // 
            // Ücret_Planlama
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 719);
            Controls.Add(panel1);
            Name = "Ücret_Planlama";
            Text = "Ücret_Planlama";
            Load += Ücret_Planlama_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnhesapla;
        private ComboBox cmbDoktorlar;
        private DataGridView dataGridView1;
        private ComboBox combohizmet;
        private Label label11;
        private Label label8;
        private Label label10;
        private ComboBox cmbHizmetTurleri;
        private Label label1;
        private Label lbltop;
        private Button btntemiz;
    }
}