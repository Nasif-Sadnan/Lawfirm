using Core_rights.Individual_Lawyer_All_Forms;
using Core_rights.Lawyer_Under_Firm_All_Forms;
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
    public partial class Form_Home_LawyerUnderFirm : Form
    {
        public Point mouseLocation;

        string ID;
        private const string ConnectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        public Form_Home_LawyerUnderFirm(string ID)
        {
            InitializeComponent();
            this.ID = ID;

            Icn_Box_settings.IconChar = IconChar.Bars;
            LbL_Firm_ID.Text = "Lawyer ID :   " + ID;
            SetPanelTransparent(PnL_services_back, 150);
            SetPanelTransparent(PnL_Case_back, 150);
            SetPanelTransparent(PnL_Lawyer_back, 150);

            LbL_Informations.Text = "Lawyer's Informations";

            CheckFirmName(ID);
            CheckFirmName2(ID);
            SetFirmType(ID);


            Form_Lawyer_Underfirm_dashboard form_Lawyer_Underfirm_Dashboard = new Form_Lawyer_Underfirm_dashboard(ID, this);
            ShowFormInPanel(form_Lawyer_Underfirm_Dashboard);
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
        private void SetPanelTransparent(Panel panel, int alpha)
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

                    string query = "SELECT [Lawyer Name] FROM [Lawyer Under Firm] WHERE [Judicial licence number ] = @FirmID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirmID", id);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            LbL_Firm_Name.Text = "Lawyer Name :  " + result.ToString();
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

                    string query = "SELECT [Lawyer Name] FROM [Lawyer Under Firm] WHERE [Judicial licence number ] = @FirmID";

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
        private void SetFirmType(string lawyerID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT [Type of lawyer] FROM [Lawyer Under Firm] WHERE [Judicial licence number ] = @lawyerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@lawyerID", ID);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            LbL_Sub_Title.Text = "Ready to assist you in resolving any " + result.ToString() + " related issues";
                        }
                        else
                        {
                            MessageBox.Show("Lawyer ID not found in the database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }




        private void Icn_pic_Exit_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LbL_services_MouseEnter(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_services_back, 150);
        }

        private void Icn_Pic_Services_MouseEnter(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_services_back, 150);
        }

        private void LbL_services_DragLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Transparent;
        }

        private void Icn_Pic_Services_MouseLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Transparent;
        }

        private void LbL_Lawyers_MouseEnter(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_Lawyer_back, 150);
        }

        private void LbL_Lawyers_MouseLeave(object sender, EventArgs e)
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

        private void LbL_Cases_MouseEnter(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_Case_back, 150);
        }

        private void Icn_Pic_Case_MouseEnter(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_Case_back, 150);
        }

        private void LbL_Cases_MouseLeave(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.DimGray;
        }

        private void Icn_Pic_Case_MouseLeave(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.DimGray;
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_Lawyer_Login form_Lawyer_Login = new Form_Lawyer_Login();
            this.Hide();
            form_Lawyer_Login.ShowDialog();
        }

        private void iconPictureBox9_Click(object sender, EventArgs e)
        {
            Form_Lawyer_Login form_Lawyer_Login = new Form_Lawyer_Login();
            this.Hide();
            form_Lawyer_Login.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form_Lawyer_Login form_Lawyer_Login = new Form_Lawyer_Login();
            this.Hide();
            form_Lawyer_Login.ShowDialog();
        }

        private void LbL_services_Click(object sender, EventArgs e)
        {
            PnL_services_back2.BackColor = Color.DarkSlateGray;
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
        }

        private void Icn_Pic_Services_Click(object sender, EventArgs e)
        {
            PnL_services_back2.BackColor = Color.DarkSlateGray;
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
        }

        private void LbL_Lawyers_Click(object sender, EventArgs e)
        {
            PnL_Lawyer_back2.BackColor = Color.DarkSlateGray;
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;
        }

        private void Icn_Pic_Lawyer_Click(object sender, EventArgs e)
        {
            PnL_Lawyer_back2.BackColor = Color.DarkSlateGray;
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;
        }

        private void LbL_Cases_Click(object sender, EventArgs e)
        {
            PnL_Case_back2.BackColor = Color.DarkSlateGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            Form_LawyerUnderFirm_CaseInfo form_LawyerUnderFirm_CaseInfo = new Form_LawyerUnderFirm_CaseInfo(ID);
            ShowFormInPanel(form_LawyerUnderFirm_CaseInfo);
        }

        private void Icn_Pic_Case_Click(object sender, EventArgs e)
        {
            PnL_Case_back2.BackColor = Color.DarkSlateGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            Form_LawyerUnderFirm_CaseInfo form_LawyerUnderFirm_CaseInfo = new Form_LawyerUnderFirm_CaseInfo(ID);
            ShowFormInPanel(form_LawyerUnderFirm_CaseInfo);
        }

        private void Icn_pic_Window_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Window format or extended format not available at this moment!!");
        }

        private void Icn_pic_minimize_Btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void LbL_services_MouseLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Transparent;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            LbL_Informations.Text = "Lawyer Informations";

            Form_Lawyer_Underfirm_dashboard form_Lawyer_Underfirm_Dashboard = new Form_Lawyer_Underfirm_dashboard(ID,this);
            ShowFormInPanel(form_Lawyer_Underfirm_Dashboard);
        }
    }
}
