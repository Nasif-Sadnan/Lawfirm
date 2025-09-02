using Core_rights.Law_Firm_All_Forms;
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
    public partial class Form_Home_LawFirm : Form
    {
        public Point mouseLocation;

        string ID;

        private const string ConnectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";
        public Form_Home_LawFirm(string ID)
        {
            InitializeComponent();
            this.ID= ID;

            LbL_Firm_ID.Text = "Firm ID :   " +ID;
            Icn_Box_settings.IconChar = IconChar.Bars;
            SetPanelTransparent(PnL_services_back, 150);
            SetPanelTransparent(PnL_Case_back, 150);
            SetPanelTransparent(PnL_Lawyer_back, 150);

            LbL_Informations.Text = "Law Firm Informations";

            CheckFirmName(ID);
            CheckFirmName2(ID);
            SetFirmType(ID);

            Law_Firm_All_Forms.Form_LawFirm_Dashboard form_LawFirm_Dashboard = new Form_LawFirm_Dashboard(ID, this);
            ShowFormInPanel(form_LawFirm_Dashboard);
        }

        private void CheckFirmName(string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Firm_Name FROM [Law Firm] WHERE Firm_ID = @FirmID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirmID", id);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            LbL_Firm_Name.Text = "Firm Name :  " + result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Firm not found for the given ID.");
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

                    string query = "SELECT Firm_Name FROM [Law Firm] WHERE Firm_ID = @FirmID";

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
                            MessageBox.Show("Firm not found for the given ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void SetFirmType(string firmID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Firm_Type FROM [Law Firm] WHERE Firm_ID = @FirmID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirmID", firmID);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            LbL_Sub_Title.Text = "A comprehensive organisation for solving " + result.ToString() + " cases";
                        }
                        else
                        {
                            MessageBox.Show("Firm ID not found in the database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void SetPanelTransparent(Panel panel, int alpha)
        {
            alpha = Math.Max(0, Math.Min(30, alpha));

            panel.BackColor = Color.FromArgb(alpha, panel.BackColor);
        }

        private void LbL_services_MouseEnter(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_services_back, 150);
        }

        private void LbL_services_MouseLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Transparent;
        }

        private void LbL_services_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Service Informations";

            PnL_services_back2.BackColor = Color.DarkSlateGray;
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;

            Form_LawFirm_ServiceInfo form_LawFirm_ServiceInfo = new Form_LawFirm_ServiceInfo(ID);
            ShowFormInPanel(form_LawFirm_ServiceInfo);
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

        private void LbL_Lawyers_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Lawyers Informations";

            PnL_Lawyer_back2.BackColor = Color.DarkSlateGray;
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            Law_Firm_All_Forms.Form_Lawyer_Infoes form_Lawyer_Infoes = new Law_Firm_All_Forms.Form_Lawyer_Infoes(ID);
            ShowFormInPanel(form_Lawyer_Infoes);
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

        private void LbL_Cases_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Case Informations";

            PnL_Case_back2.BackColor = Color.DarkSlateGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            Form_LawFirm_caseInfo form_LawFirm_CaseInfo = new Form_LawFirm_caseInfo(ID);
            ShowFormInPanel(form_LawFirm_CaseInfo);
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

        private void Icn_pic_Exit_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Icn_pic_Window_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Window format or extended format not available at this moment!!");
        }

        private void Icn_pic_minimize_Btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PnL_chng_Pos_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void PnL_chng_Pos_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void Icn_Pic_Services_MouseEnter(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Black;
            SetPanelTransparent(PnL_services_back, 150);
        }

        private void Icn_Pic_Services_MouseLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Transparent;
        }

        private void Icn_Pic_Services_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Service Informations";

            PnL_services_back2.BackColor = Color.DarkSlateGray;
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;

            Form_LawFirm_ServiceInfo form_LawFirm_ServiceInfo = new Form_LawFirm_ServiceInfo(ID);
            ShowFormInPanel(form_LawFirm_ServiceInfo);
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

        private void Icn_Pic_Lawyer_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Lawyers Informations";

            PnL_Lawyer_back2.BackColor = Color.DarkSlateGray;
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            Law_Firm_All_Forms.Form_Lawyer_Infoes form_Lawyer_Infoes = new Law_Firm_All_Forms.Form_Lawyer_Infoes(ID);
            ShowFormInPanel(form_Lawyer_Infoes);
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

        private void Icn_Pic_Case_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Case Informations";

            PnL_Case_back2.BackColor = Color.DarkSlateGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            Form_LawFirm_caseInfo form_LawFirm_CaseInfo = new Form_LawFirm_caseInfo(ID);
            ShowFormInPanel(form_LawFirm_CaseInfo);
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            LbL_Informations.Text = "Law Firm Informations";

            Law_Firm_All_Forms.Form_LawFirm_Dashboard form_LawFirm_Dashboard = new Form_LawFirm_Dashboard(ID,this);
            ShowFormInPanel(form_LawFirm_Dashboard);
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_lawfirm_Login form_Lawfirm_Login = new Form_lawfirm_Login();
            this.Hide();
            form_Lawfirm_Login.ShowDialog();
        }

        private void iconPictureBox9_Click(object sender, EventArgs e)
        {
            Form_lawfirm_Login form_Lawfirm_Login = new Form_lawfirm_Login();
            this.Hide();
            form_Lawfirm_Login.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form_lawfirm_Login form_Lawfirm_Login = new Form_lawfirm_Login();
            this.Hide();
            form_Lawfirm_Login.ShowDialog();
        }
    }
}
