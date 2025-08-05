namespace Dis_Klinigi.Formlar
{
    partial class Takvim
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
            label9 = new Label();
            daterndv = new DateTimePicker();
            button9 = new Button();
            label8 = new Label();
            comboBoxDoktor = new ComboBox();
            label7 = new Label();
            comboBox2 = new ComboBox();
            label6 = new Label();
            label2 = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            cmbodk = new ComboBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            cmbIslem = new ComboBox();
            dataGridView1 = new DataGridView();
            txtTC = new TextBox();
            label1 = new Label();
            btnsil = new Button();
            btnAddAppointment = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label9);
            panel1.Controls.Add(daterndv);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(comboBoxDoktor);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateTimePickerEnd);
            panel1.Controls.Add(dateTimePickerStart);
            panel1.Controls.Add(cmbodk);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbIslem);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(txtTC);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnsil);
            panel1.Controls.Add(btnAddAppointment);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1251, 758);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Location = new Point(47, 103);
            label9.Name = "label9";
            label9.Size = new Size(91, 15);
            label9.TabIndex = 39;
            label9.Text = "Randevu Tarihi :";
            // 
            // daterndv
            // 
            daterndv.Anchor = AnchorStyles.Top;
            daterndv.Location = new Point(47, 125);
            daterndv.Name = "daterndv";
            daterndv.Size = new Size(181, 23);
            daterndv.TabIndex = 38;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top;
            button9.Location = new Point(633, 31);
            button9.Name = "button9";
            button9.Size = new Size(103, 39);
            button9.TabIndex = 37;
            button9.Text = "Sorgula";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(472, 19);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 36;
            label8.Text = "Doktor Seçiniz";
            // 
            // comboBoxDoktor
            // 
            comboBoxDoktor.Anchor = AnchorStyles.Top;
            comboBoxDoktor.FormattingEnabled = true;
            comboBoxDoktor.Location = new Point(472, 47);
            comboBoxDoktor.Name = "comboBoxDoktor";
            comboBoxDoktor.Size = new Size(143, 23);
            comboBoxDoktor.TabIndex = 35;
            comboBoxDoktor.SelectedIndexChanged += comboBoxDoktor_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(846, 103);
            label7.Name = "label7";
            label7.Size = new Size(82, 15);
            label7.TabIndex = 34;
            label7.Text = "Doktor Seçiniz";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(846, 125);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(119, 23);
            comboBox2.TabIndex = 33;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(267, 19);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 25;
            label6.Text = "Bitiş Tarihi :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(47, 19);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 24;
            label2.Text = "Başlangıç Tarihi :";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Anchor = AnchorStyles.Top;
            dateTimePickerEnd.Location = new Point(267, 47);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(187, 23);
            dateTimePickerEnd.TabIndex = 22;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Anchor = AnchorStyles.Top;
            dateTimePickerStart.Location = new Point(47, 47);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(181, 23);
            dateTimePickerStart.TabIndex = 21;
            // 
            // cmbodk
            // 
            cmbodk.Anchor = AnchorStyles.Top;
            cmbodk.FormattingEnabled = true;
            cmbodk.Location = new Point(704, 125);
            cmbodk.Name = "cmbodk";
            cmbodk.Size = new Size(124, 23);
            cmbodk.TabIndex = 19;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(704, 103);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 18;
            label5.Text = "Randevu Dakika";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(560, 125);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(124, 23);
            comboBox1.TabIndex = 17;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(392, 103);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 16;
            label4.Text = "Yapılacak İşlem";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(560, 103);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 15;
            label3.Text = "Randevu Saati";
            // 
            // cmbIslem
            // 
            cmbIslem.Anchor = AnchorStyles.Top;
            cmbIslem.FormattingEnabled = true;
            cmbIslem.Location = new Point(392, 125);
            cmbIslem.Name = "cmbIslem";
            cmbIslem.Size = new Size(143, 23);
            cmbIslem.TabIndex = 14;
            cmbIslem.SelectedIndexChanged += cmbIslem_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 169);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1251, 586);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            // 
            // txtTC
            // 
            txtTC.Anchor = AnchorStyles.Top;
            txtTC.Location = new Point(238, 125);
            txtTC.MaxLength = 11;
            txtTC.Name = "txtTC";
            txtTC.Size = new Size(133, 23);
            txtTC.TabIndex = 11;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(238, 103);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 9;
            label1.Text = "TC NO Giriniz :";
            // 
            // btnsil
            // 
            btnsil.Anchor = AnchorStyles.Top;
            btnsil.Location = new Point(1119, 120);
            btnsil.Name = "btnsil";
            btnsil.Size = new Size(114, 31);
            btnsil.TabIndex = 7;
            btnsil.Text = "Randevu Sil";
            btnsil.UseVisualStyleBackColor = true;
            btnsil.Click += btnsil_Click;
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.Anchor = AnchorStyles.Top;
            btnAddAppointment.Location = new Point(980, 120);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Size = new Size(114, 31);
            btnAddAppointment.TabIndex = 2;
            btnAddAppointment.Text = "Randevu Ekle";
            btnAddAppointment.UseVisualStyleBackColor = true;
            btnAddAppointment.Click += btnAddAppointment_Click;
            // 
            // Takvim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 758);
            Controls.Add(panel1);
            Name = "Takvim";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Takvim";
            Load += Takvim_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnAddAppointment;
        private Button btnsil;
        private Label label1;
        private TextBox txtTC;
        private DataGridView dataGridView1;
        private ComboBox cmbIslem;
        private ComboBox comboBox1;
        private Label label4;
        private Label label3;
        private ComboBox cmbodk;
        private Label label5;
        private Label label6;
        private Label label2;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private Label label7;
        private ComboBox comboBox2;
        private Button button9;
        private Label label8;
        private ComboBox comboBoxDoktor;
        private Label label9;
        private DateTimePicker daterndv;
    }
}