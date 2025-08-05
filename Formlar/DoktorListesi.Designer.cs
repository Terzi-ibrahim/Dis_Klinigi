namespace Dis_Klinigi.Formlar
{
    partial class DoktorListesi
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
            panel2 = new Panel();
            label6 = new Label();
            label5 = new Label();
            button2 = new Button();
            txtdokgun = new TextBox();
            txtgunıd = new TextBox();
            txtgundoksoy = new TextBox();
            label4 = new Label();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            label9 = new Label();
            label3 = new Label();
            txtsilid = new TextBox();
            label1 = new Label();
            txtDoktorSoyadi = new TextBox();
            label2 = new Label();
            button4 = new Button();
            txtDoktorAdi = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Controls.Add(button1);
            panel2.Controls.Add(txtDoktorAdi);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtDoktorSoyadi);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtsilid);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtgundoksoy);
            panel2.Controls.Add(txtgunıd);
            panel2.Controls.Add(txtdokgun);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(358, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(488, 635);
            panel2.TabIndex = 25;
            panel2.Paint += panel2_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(62, 406);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 13;
            label6.Text = "Doktor Adı :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(250, 406);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 14;
            label5.Text = "Doktor Soyadı :";
            // 
            // button2
            // 
            button2.Location = new Point(60, 349);
            button2.Name = "button2";
            button2.Size = new Size(352, 25);
            button2.TabIndex = 12;
            button2.Text = "Doktor Liste Güncelle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtdokgun
            // 
            txtdokgun.Location = new Point(62, 440);
            txtdokgun.Name = "txtdokgun";
            txtdokgun.Size = new Size(160, 23);
            txtdokgun.TabIndex = 15;
            txtdokgun.TextChanged += textBox5_TextChanged;
            // 
            // txtgunıd
            // 
            txtgunıd.Location = new Point(62, 499);
            txtgunıd.Name = "txtgunıd";
            txtgunıd.Size = new Size(160, 23);
            txtgunıd.TabIndex = 11;
            // 
            // txtgundoksoy
            // 
            txtgundoksoy.Location = new Point(254, 440);
            txtgundoksoy.Name = "txtgundoksoy";
            txtgundoksoy.Size = new Size(158, 23);
            txtgundoksoy.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 208);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 9;
            label4.Text = "Doktorlar Liste";
            // 
            // button3
            // 
            button3.Location = new Point(252, 491);
            button3.Name = "button3";
            button3.Size = new Size(160, 31);
            button3.TabIndex = 17;
            button3.Text = "Güncelle";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(60, 239);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(352, 104);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(70, 563);
            label9.Name = "label9";
            label9.Size = new Size(62, 15);
            label9.TabIndex = 18;
            label9.Text = "Doktor Id :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 475);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 7;
            label3.Text = "Doktor Id :";
            // 
            // txtsilid
            // 
            txtsilid.Location = new Point(62, 581);
            txtsilid.Name = "txtsilid";
            txtsilid.Size = new Size(160, 23);
            txtsilid.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 5);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 1;
            label1.Text = "Doktor Adı :";
            // 
            // txtDoktorSoyadi
            // 
            txtDoktorSoyadi.Location = new Point(60, 114);
            txtDoktorSoyadi.Name = "txtDoktorSoyadi";
            txtDoktorSoyadi.Size = new Size(218, 23);
            txtDoktorSoyadi.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 84);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 2;
            label2.Text = "Doktor Soyadı :";
            // 
            // button4
            // 
            button4.Location = new Point(254, 576);
            button4.Name = "button4";
            button4.Size = new Size(158, 31);
            button4.TabIndex = 24;
            button4.Text = "Sil";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // txtDoktorAdi
            // 
            txtDoktorAdi.Location = new Point(60, 36);
            txtDoktorAdi.Name = "txtDoktorAdi";
            txtDoktorAdi.Size = new Size(216, 23);
            txtDoktorAdi.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(62, 164);
            button1.Name = "button1";
            button1.Size = new Size(216, 31);
            button1.TabIndex = 5;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(358, 758);
            panel1.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(845, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(406, 758);
            panel3.TabIndex = 27;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(358, 655);
            panel4.Name = "panel4";
            panel4.Size = new Size(487, 103);
            panel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(358, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(487, 41);
            panel5.TabIndex = 28;
            // 
            // DoktorListesi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1251, 758);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "DoktorListesi";
            Text = "DoktorListesi";
            Load += DoktorListesi_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button button1;
        private TextBox txtDoktorAdi;
        private Button button4;
        private Label label2;
        private TextBox txtDoktorSoyadi;
        private Label label1;
        private TextBox txtsilid;
        private Label label3;
        private Label label9;
        private DataGridView dataGridView1;
        private Button button3;
        private Label label4;
        private TextBox txtgundoksoy;
        private TextBox txtgunıd;
        private TextBox txtdokgun;
        private Button button2;
        private Label label5;
        private Label label6;
        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}