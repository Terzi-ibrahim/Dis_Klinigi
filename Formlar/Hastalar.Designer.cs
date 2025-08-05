namespace Dis_Klinigi.Formlar
{
    partial class Hastalar
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            datagrid = new DataGridView();
            label1 = new Label();
            txtfilter = new Guna.UI2.WinForms.Guna2TextBox();
            btnsorgu = new Button();
            btnsil = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datagrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(datagrid);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtfilter);
            panel1.Controls.Add(btnsorgu);
            panel1.Controls.Add(btnsil);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1251, 758);
            panel1.TabIndex = 1;
            // 
            // datagrid
            // 
            datagrid.AllowUserToAddRows = false;
            datagrid.AllowUserToDeleteRows = false;
            datagrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagrid.Location = new Point(0, 77);
            datagrid.Name = "datagrid";
            datagrid.ReadOnly = true;
            datagrid.Size = new Size(1251, 681);
            datagrid.TabIndex = 77;
            datagrid.CellContentClick += datagrid_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(88, 18);
            label1.TabIndex = 59;
            label1.Text = "Hasta Tc :";
            // 
            // txtfilter
            // 
            txtfilter.Anchor = AnchorStyles.Top;
            txtfilter.CustomizableEdges = customizableEdges1;
            txtfilter.DefaultText = "";
            txtfilter.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtfilter.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtfilter.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtfilter.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtfilter.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtfilter.Font = new Font("Segoe UI", 9F);
            txtfilter.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtfilter.Location = new Point(106, 26);
            txtfilter.MaxLength = 11;
            txtfilter.Name = "txtfilter";
            txtfilter.PasswordChar = '\0';
            txtfilter.PlaceholderText = "";
            txtfilter.SelectedText = "";
            txtfilter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtfilter.Size = new Size(819, 29);
            txtfilter.TabIndex = 56;
            // 
            // btnsorgu
            // 
            btnsorgu.Anchor = AnchorStyles.Top;
            btnsorgu.Location = new Point(967, 26);
            btnsorgu.Name = "btnsorgu";
            btnsorgu.Size = new Size(136, 29);
            btnsorgu.TabIndex = 4;
            btnsorgu.Text = "Ara";
            btnsorgu.UseVisualStyleBackColor = true;
            btnsorgu.Click += btnsorgu_Click;
            // 
            // btnsil
            // 
            btnsil.Anchor = AnchorStyles.Top;
            btnsil.Location = new Point(1109, 26);
            btnsil.Name = "btnsil";
            btnsil.Size = new Size(130, 29);
            btnsil.TabIndex = 1;
            btnsil.Text = "Sil";
            btnsil.UseVisualStyleBackColor = true;
            btnsil.Click += btnsil_Click;
            // 
            // Hastalar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1251, 758);
            Controls.Add(panel1);
            Name = "Hastalar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hastalar";
            Load += Hastalar_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)datagrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnsorgu;
        private Button btnsil;
        private Guna.UI2.WinForms.Guna2TextBox txtfilter;
        private Label label1;
        private DataGridView datagrid;
    }
}