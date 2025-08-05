using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Dis_Klinigi.Formlar;

namespace Dis_Klinigi

{
    public partial class Anasayfa : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public Anasayfa()
        {
            InitializeComponent();

            this.Resize += Form1_Resize_1;
            this.Resize += Form1_MinimumSizeChanged;


            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;



        }


        private struct RGBColors()
        {
            public static Color color1 = Color.MediumBlue;



        }
        private void ActiveButton(object senderBtn, Color color)
        {


            if (senderBtn != null)
            {
                DisableButton();



                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.Gainsboro;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //left border 
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                // icon current chilt 
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;




            }


        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {

                currentBtn.BackColor = Color.DimGray;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;



            }
        }

        private void OpenChildForm(Form childForm)
        {

            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlDesk.Controls.Add(childForm);
            pnlDesk.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildFrom.Text = childForm.Text;


        }


        private void btnhastakyt_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);

            OpenChildForm(new Formlar.HastaKayýt());
        }




        private void btnhastalar_Click(object sender, EventArgs e)
        {

            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new Formlar.Hastalar());
        }

        private void btntkvm_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new Formlar.Takvim());

        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumBlue;
            lblTitleChildFrom.Text = "Anasayfa";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }




        private void pnlDesk_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void iconCurrentChildForm_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            int minFormWidth = 1419;
            int minFormHeight = 910;


            int minPanelWidth = 1267;
            int minPanelHeight = 797;

            if (this.ClientSize.Width < minFormWidth && this.ClientSize.Height < minFormHeight)
                return;


            pnlDesk.Size = new Size(
                Math.Max(minPanelWidth, this.ClientSize.Width / 2),
                Math.Max(minPanelHeight, this.ClientSize.Height / 2)
            );
        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {

            int minWidth = 1419;
            int minHeight = 910;

            if (this.Width < minWidth)
                this.Width = minWidth;

            if (this.Height < minHeight)
                this.Height = minHeight;
        }

        private void ýconButton1_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            Giris grs = new Giris();
            grs.Show();
            this.Hide();

        }

        private void ýconButton2_Click(object sender, EventArgs e)
        {

            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new Formlar.DoktorListesi());
        }

        private void ýconButton3_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new Formlar.HizmetVeFiyatEkleme());
        }

        private void ýconButton4_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new Formlar.Ücret_Planlama());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            string saat = DateTime.Now.ToString("HH:mm:ss");
            string tarih = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            lblsaat.Text = $"{tarih}  {saat}";

        }

        private void ýconPictureBox1_Click(object sender, EventArgs e)
        {

            PaswordChange sifredegis = new PaswordChange();
            sifredegis.Owner = this;
            sifredegis.Show();
         



               Form openForm = GetOpenForm(typeof(PaswordChange));
            if (openForm == null)
            {
                PaswordChange frm = new PaswordChange();
                frm.Owner = this;
                frm.Show();
                
            }
            else
            {
                openForm.Show();
               
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





    }


}
