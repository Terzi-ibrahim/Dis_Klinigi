namespace Dis_Klinigi
{
    partial class HastaBilgiGuncelle
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            combocinsiyet = new ComboBox();
            msgtlf = new MaskedTextBox();
            richadres = new RichTextBox();
            txttc = new Guna.UI2.WinForms.Guna2TextBox();
            txtsoyad = new Guna.UI2.WinForms.Guna2TextBox();
            txtad = new Guna.UI2.WinForms.Guna2TextBox();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            btngeri = new Button();
            uyeliste = new DataGridView();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)uyeliste).BeginInit();
            SuspendLayout();
            // 
            // combocinsiyet
            // 
            combocinsiyet.FormattingEnabled = true;
            combocinsiyet.Items.AddRange(new object[] { "Kadın", "Erkek" });
            combocinsiyet.Location = new Point(520, 50);
            combocinsiyet.Name = "combocinsiyet";
            combocinsiyet.Size = new Size(212, 23);
            combocinsiyet.TabIndex = 84;
            // 
            // msgtlf
            // 
            msgtlf.Location = new Point(280, 111);
            msgtlf.Mask = "(999) 000-0000";
            msgtlf.Name = "msgtlf";
            msgtlf.Size = new Size(197, 23);
            msgtlf.TabIndex = 83;
            // 
            // richadres
            // 
            richadres.Location = new Point(21, 160);
            richadres.Name = "richadres";
            richadres.Size = new Size(711, 53);
            richadres.TabIndex = 82;
            richadres.Text = "";
            richadres.TextChanged += richadres_TextChanged;
            // 
            // txttc
            // 
            txttc.CustomizableEdges = customizableEdges7;
            txttc.DefaultText = "";
            txttc.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txttc.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txttc.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txttc.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txttc.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txttc.Font = new Font("Segoe UI", 9F);
            txttc.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txttc.Location = new Point(21, 111);
            txttc.MaxLength = 11;
            txttc.Name = "txttc";
            txttc.PasswordChar = '\0';
            txttc.PlaceholderText = "";
            txttc.SelectedText = "";
            txttc.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txttc.Size = new Size(182, 29);
            txttc.TabIndex = 81;
            // 
            // txtsoyad
            // 
            txtsoyad.CustomizableEdges = customizableEdges9;
            txtsoyad.DefaultText = "";
            txtsoyad.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtsoyad.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtsoyad.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtsoyad.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtsoyad.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsoyad.Font = new Font("Segoe UI", 9F);
            txtsoyad.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtsoyad.Location = new Point(280, 44);
            txtsoyad.Name = "txtsoyad";
            txtsoyad.PasswordChar = '\0';
            txtsoyad.PlaceholderText = "";
            txtsoyad.SelectedText = "";
            txtsoyad.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtsoyad.Size = new Size(182, 29);
            txtsoyad.TabIndex = 80;
            // 
            // txtad
            // 
            txtad.CustomizableEdges = customizableEdges11;
            txtad.DefaultText = "";
            txtad.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtad.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtad.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtad.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtad.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtad.Font = new Font("Segoe UI", 9F);
            txtad.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtad.Location = new Point(21, 44);
            txtad.Name = "txtad";
            txtad.PasswordChar = '\0';
            txtad.PlaceholderText = "";
            txtad.SelectedText = "";
            txtad.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtad.Size = new Size(182, 29);
            txtad.TabIndex = 79;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 142);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 78;
            label7.Text = "Adres";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(280, 93);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 77;
            label6.Text = "Cep Telefonu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(516, 31);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 76;
            label4.Text = "Cinsiyet";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(280, 26);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 75;
            label3.Text = "Soyadı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 26);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 74;
            label2.Text = "Adı";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 93);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 73;
            label1.Text = "Hasta Tc:";
            // 
            // button1
            // 
            button1.Location = new Point(21, 459);
            button1.Name = "button1";
            button1.Size = new Size(711, 40);
            button1.TabIndex = 85;
            button1.Text = "Bilgileri Güncelle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btngeri
            // 
            btngeri.Location = new Point(21, 505);
            btngeri.Name = "btngeri";
            btngeri.Size = new Size(711, 40);
            btngeri.TabIndex = 86;
            btngeri.Text = "Geri";
            btngeri.UseVisualStyleBackColor = true;
            btngeri.Click += btngeri_Click;
            // 
            // uyeliste
            // 
            uyeliste.AllowUserToAddRows = false;
            uyeliste.AllowUserToDeleteRows = false;
            uyeliste.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uyeliste.Location = new Point(21, 228);
            uyeliste.Name = "uyeliste";
            uyeliste.ReadOnly = true;
            uyeliste.Size = new Size(711, 176);
            uyeliste.TabIndex = 87;
            uyeliste.CellContentClick += uyeliste_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(21, 413);
            button2.Name = "button2";
            button2.Size = new Size(711, 40);
            button2.TabIndex = 88;
            button2.Text = "Üyeleri Listele";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // HastaBilgiGuncelle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 557);
            Controls.Add(button2);
            Controls.Add(uyeliste);
            Controls.Add(btngeri);
            Controls.Add(button1);
            Controls.Add(combocinsiyet);
            Controls.Add(msgtlf);
            Controls.Add(richadres);
            Controls.Add(txttc);
            Controls.Add(txtsoyad);
            Controls.Add(txtad);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "HastaBilgiGuncelle";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += HastaBilgiGuncelle_FormClosed;
            Load += HastaBilgiGuncelle_Load_1;
            ((System.ComponentModel.ISupportInitialize)uyeliste).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox combocinsiyet;
        private MaskedTextBox msgtlf;
        private RichTextBox richadres;
        private Guna.UI2.WinForms.Guna2TextBox txttc;
        private Guna.UI2.WinForms.Guna2TextBox txtsoyad;
        private Guna.UI2.WinForms.Guna2TextBox txtad;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private Button btngeri;
        private DataGridView uyeliste;
        private Button button2;
    }
}