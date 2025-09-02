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
    public partial class Form_Welcome : Form
    {
        public Point mouseLocation;
        public Form_Welcome()
        {
            InitializeComponent();
            Pic_Box_Consultation.Location = new Point(710, 95);
            Icn_Box_Case.IconChar = IconChar.ScaleBalanced;
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

        private void PnL_Top_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void PnL_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void LbL_Bout_Us_Click(object sender, EventArgs e)
        {
            LbL_About.Focus();
            LbL_Us.Focus();
            Pic_Box_Team.Focus();
            LbL_FFour.Focus();
        }

        private void iconPictureBox5_Click(object sender, EventArgs e)
        {
            PnL_Top.Focus();
        }

        private void LbL_Contact_withus_Click(object sender, EventArgs e)
        {
            PnL_down.Focus();
        }

        private void LbL_Login_Click(object sender, EventArgs e)
        {
            Form_Login_Options f_Login_Options = new Form_Login_Options();
            this.Hide();
            f_Login_Options.ShowDialog();
            
        }

        private void Form_Welcome_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=\"Core Rights\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string lawFirmQuery = "SELECT COUNT(*) FROM [Law Firm]";

                    int lawFirmRowCount = GetRowCount(lawFirmQuery, connection);
                    UpdateLabelWithCount(LbL_LawFirm_Num, lawFirmRowCount);

                    string lawyerUnderFirmQuery = "SELECT COUNT(*) FROM [Lawyer Under Firm]";
                    int lawyerUnderFirmRowCount = GetRowCount(lawyerUnderFirmQuery, connection);

                    string individualLawyerQuery = "SELECT COUNT(*) FROM [Individual Lawyer]";
                    int individualLawyerRowCount = GetRowCount(individualLawyerQuery, connection);


                    int totalLawyerRowCount = lawyerUnderFirmRowCount + individualLawyerRowCount;
                    UpdateLabelWithCount(LbL_LawYear_Num, totalLawyerRowCount);

                    string userQuery = "SELECT COUNT(*) FROM [User]";
                    int userRowCount = GetRowCount(userQuery, connection);
                    UpdateLabelWithCount(LbL_User_Num, userRowCount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private int GetRowCount(string query, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                return (int)command.ExecuteScalar();
            }
        }

        private void UpdateLabelWithCount(Label label, int rowCount)
        {
            if (rowCount > 1)
            {
                int result = rowCount - 1;
                label.Text = result.ToString() + "+";
            }
            else
            {
                label.Text = rowCount.ToString();
            }
        }
    }
}
