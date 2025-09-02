using Core_rights.Admin_All_Forms;
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
    public partial class Form_Home_Admin : Form
    {
        public Point mouseLocation;

        string ID;
        private const string ConnectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";
        public Form_Home_Admin(string ID)
        {
            InitializeComponent();
            this.ID = ID;

            LbL_Firm_ID.Text = "Admin ID :   " + ID;
            LbL_Informations.Text = "Admin Informations";
            Icn_Box_settings.IconChar = IconChar.Bars;

            PnL_services_back.BackColor = Color.DimGray;
            PnL_Case_back.BackColor = Color.DimGray;
            PnL_Lawyer_back.BackColor = Color.DimGray;

            CheckFirmName(ID);
            CheckFirmName2(ID);


            Form_Admin_Dashboard form_Admin_Dashboard = new Form_Admin_Dashboard(ID, this);
            ShowFormInPanel(form_Admin_Dashboard);
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
        private void CheckFirmName(string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT Name FROM [Admin] WHERE ID = @FirmID";

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

                    string query = "SELECT Name FROM [Admin] WHERE ID = @FirmID";

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
        private void Icn_pic_Exit_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LbL_services_MouseEnter(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Gray;
        }

        private void LbL_services_MouseLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.DimGray;
        }

        private void Icn_Pic_Services_MouseEnter(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.Gray;
        }

        private void Icn_Pic_Services_MouseLeave(object sender, EventArgs e)
        {
            PnL_services_back.BackColor = Color.DimGray;
        }

        private void LbL_services_Click(object sender, EventArgs e)
        {

            LbL_Informations.Text = "Law Firm Informations";
            PnL_services_back2.BackColor = Color.FromArgb(100, 25, 50);
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;


            Form_LawFirm_Info form_LawFirm_Info = new Form_LawFirm_Info(this);
            ShowFormInPanel(form_LawFirm_Info);
        }

        private void Icn_Pic_Services_Click(object sender, EventArgs e)
        {

            LbL_Informations.Text = "Law Firm Informations";

            PnL_services_back2.BackColor = Color.FromArgb(100, 25, 50);
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;


            Form_LawFirm_Info form_LawFirm_Info = new Form_LawFirm_Info(this);
            ShowFormInPanel(form_LawFirm_Info);
        }

        private void LbL_Lawyers_MouseEnter(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.Gray;
        }

        private void LbL_Lawyers_MouseLeave(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.DimGray;
        }

        private void Icn_Pic_Lawyer_MouseEnter(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.Gray;
        }

        private void Icn_Pic_Lawyer_MouseLeave(object sender, EventArgs e)
        {
            PnL_Lawyer_back.BackColor = Color.DimGray;
        }

        private void LbL_Lawyers_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Users Informations";

            PnL_Lawyer_back2.BackColor = Color.FromArgb(100, 25, 50);
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            Form_Admin_allUserInfo form_Admin_AllUserInfo = new Form_Admin_allUserInfo(this);
            ShowFormInPanel(form_Admin_AllUserInfo);
        }

        private void Icn_Pic_Lawyer_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Users Informations";

            PnL_Lawyer_back2.BackColor = Color.FromArgb(100, 25, 50);
            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

            Form_Admin_allUserInfo form_Admin_AllUserInfo = new Form_Admin_allUserInfo(this);
            ShowFormInPanel(form_Admin_AllUserInfo);
        }

        private void LbL_Cases_MouseEnter(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.Gray;
        }

        private void Icn_Pic_Case_MouseEnter(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.Gray;
        }

        private void LbL_Cases_MouseLeave(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.DimGray;
        }

        private void Icn_Pic_Case_MouseLeave(object sender, EventArgs e)
        {
            PnL_Case_back.BackColor = Color.DimGray;
        }

        private void LbL_Cases_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Lawyers Informations";

            PnL_Case_back2.BackColor = Color.FromArgb(100, 25, 50);
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;


            Form_All_LawyerInfo form_All_LawyerInfo = new Form_All_LawyerInfo(this); 
            ShowFormInPanel(form_All_LawyerInfo);
        }

        private void Icn_Pic_Case_Click(object sender, EventArgs e)
        {
            LbL_Informations.Text = "Lawyers Informations";


            PnL_Case_back2.BackColor = Color.FromArgb(100, 25, 50);
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

            PnL_services_back.BackColor = Color.DimGray;
            PnL_Case_back.BackColor = Color.DimGray;
            PnL_Lawyer_back.BackColor = Color.DimGray;

            PnL_Case_back2.BackColor = Color.DimGray;
            PnL_Lawyer_back2.BackColor = Color.DimGray;
            PnL_services_back2.BackColor = Color.DimGray;


            LbL_Informations.Text = "Admin Informations";

            Form_Admin_Dashboard form_Admin_Dashboard = new Form_Admin_Dashboard(ID, this);
            ShowFormInPanel(form_Admin_Dashboard);
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_Admin_Login form_Admin_Login = new Form_Admin_Login();
            this.Hide();
            form_Admin_Login.ShowDialog();
        }

        private void iconPictureBox9_Click(object sender, EventArgs e)
        {
            Form_Admin_Login form_Admin_Login = new Form_Admin_Login();
            this.Hide();
            form_Admin_Login.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form_Admin_Login form_Admin_Login = new Form_Admin_Login();
            this.Hide();
            form_Admin_Login.ShowDialog();
        }

        private void PnL_userback_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
