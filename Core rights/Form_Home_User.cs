using Core_rights.Law_Firm_All_Forms;
using Core_rights.User_All_Forms;
using FontAwesome.Sharp;
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

namespace Core_rights
{
    public partial class Form_Home_User : Form
    {
        public Point mouseLocation;

        string ID;
        private const string ConnectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";
        public Form_Home_User(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            LbL_Firm_ID.Text = "NID :   " + ID;
            Icn_Box_settings.IconChar = IconChar.Bars;

            SetPanelTransparent(PnL_services_back, 150);
            SetPanelTransparent(PnL_Case_back, 150);
            SetPanelTransparent(PnL_Lawyer_back, 150);

            LbL_Informations.Text = "User Informations";

            CheckFirmName(ID);

            CheckFirmName(ID);
            CheckFirmName2(ID);

            PnL_Menu1_Back.Size = new System.Drawing.Size(168, 151);
            PnL_Menu2_Back.Size = new System.Drawing.Size(168, 151);
            PnL_Menu3_Back.Size = new System.Drawing.Size(168, 151);

            User_All_Forms.Form_User_DasBoard form_User_DasBoard = new User_All_Forms.Form_User_DasBoard(ID,this);
            ShowFormInPanel(form_User_DasBoard);
        }
        private void ShowFormInPanel(Form form)
        {
            PnL_SUbform_Back.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            PnL_SUbform_Back.Controls.Add(form);

            form.Show();
        }
        public void SetPanelTransparent(Panel panel, int alpha)
        {
            alpha = Math.Max(0, Math.Min(30, alpha));

            panel.BackColor = Color.FromArgb(alpha, panel.BackColor);
        }

        private void CheckFirmName(string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Name FROM [User] WHERE NID = @FirmID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirmID", id);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            LbL_Firm_Name.Text = "User Name :  " + result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found for the given ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void CheckFirmName2(string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Name FROM [User] WHERE NID = @FirmID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirmID", id);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            LbL_LawFirm_Main.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found for the given ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LbL_LawFirms_MouseEnter(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_services_back, 150);
        }

        private void LbL_LawFirms_MouseLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Transparent;
        }

        private void iconPictureBox9_MouseEnter(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_services_back, 150);
        }

        private void iconPictureBox9_MouseLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Transparent;
        }

        private void LbL_LawFirms_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Law Firm's Informations";

            PnL_services_back2.BackColor = Color.FromArgb(51, 51, 51);
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;


            User_All_Forms.Form_LawFirm_Infoes form_LawFirm_Infoes = new User_All_Forms.Form_LawFirm_Infoes(ID);
            ShowFormInPanel(form_LawFirm_Infoes);
        }

        private void LbL_IndividualLawyers_MouseEnter(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_Lawyer_back, 150);
        }

        private void LbL_IndividualLawyers_MouseLeave(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.DimGray;
        }

        private void Icn_Pic_Lawyer_MouseEnter(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_Lawyer_back, 150);
        }

        private void Icn_Pic_Lawyer_MouseLeave(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.DimGray;
        }

        private void LbL_IndividualLawyers_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Lawyers Informations";

            PnL_Lawyer_back2.BackColor = Color.FromArgb(51, 51, 51);
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;


            User_All_Forms.Form_Individual_Lawyer_Info form_Individual_Lawyer_Info = new User_All_Forms.Form_Individual_Lawyer_Info(ID);
            ShowFormInPanel(form_Individual_Lawyer_Info);
        }

        private void iconPictureBox9_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Law Firm's Informations";

            PnL_services_back2.BackColor = Color.FromArgb(51, 51, 51);
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;


            User_All_Forms.Form_LawFirm_Infoes form_LawFirm_Infoes = new User_All_Forms.Form_LawFirm_Infoes(ID);
            ShowFormInPanel(form_LawFirm_Infoes);
        }

        private void Icn_Pic_Lawyer_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Lawyers Informations";

            PnL_Lawyer_back2.BackColor = Color.FromArgb(51, 51, 51);
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;


            User_All_Forms.Form_Individual_Lawyer_Info form_Individual_Lawyer_Info = new User_All_Forms.Form_Individual_Lawyer_Info(ID);
            ShowFormInPanel(form_Individual_Lawyer_Info);
        }

        private void LbL_Cases_MouseEnter(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_Case_back, 150);
        }

        private void LbL_Cases_MouseLeave(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.DimGray;
        }

        private void Icn_Pic_Case_MouseEnter(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_Case_back, 150);
        }

        private void Icn_Pic_Case_MouseLeave(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.DimGray;
        }

        private void LbL_Cases_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Case Informations";

            PnL_Case_back2.BackColor = Color.FromArgb(51, 51, 51);
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;


            User_All_Forms.Form_User_CaseInfo form_User_CaseInfo = new User_All_Forms.Form_User_CaseInfo(ID);
            ShowFormInPanel(form_User_CaseInfo);
        }

        private void Icn_Pic_Case_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Case Informations";

            PnL_Case_back2.BackColor = Color.FromArgb(51, 51, 51);
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;


            User_All_Forms.Form_User_CaseInfo form_User_CaseInfo = new User_All_Forms.Form_User_CaseInfo(ID);
            ShowFormInPanel(form_User_CaseInfo);
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_User_Login form_User_Login = new Form_User_Login();
            this.Hide();
            form_User_Login.ShowDialog();
        }

        private void Icn_pic_Exit_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Icn_pic_minimize_Btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Icn_pic_Window_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Window format or extended format not available at this moment!!");
        }

        private void PnL_chng_Pos_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void PnL_chng_Pos_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = System.Windows.Forms.Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;


            LbL_Informations.Text = "Law Firm Informations";

            User_All_Forms.Form_User_DasBoard form_User_DasBoard = new User_All_Forms.Form_User_DasBoard(ID, this);
            ShowFormInPanel(form_User_DasBoard);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form_User_Login form_User_Login = new Form_User_Login();
            this.Hide();
            form_User_Login.ShowDialog();
        }

        private void iconPictureBox10_Click(object sender, EventArgs e)
        {
            Form_User_Login form_User_Login = new Form_User_Login();
            this.Hide();
            form_User_Login.ShowDialog();
        }
    }
}
