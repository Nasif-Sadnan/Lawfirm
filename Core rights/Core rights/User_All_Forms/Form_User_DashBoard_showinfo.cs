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

namespace Core_rights.User_All_Forms
{
    public partial class Form_User_DashBoard_showinfo : Form
    {
        private string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        private string firmID;
        public Form_User_DashBoard_showinfo(string ID, Form previous_form)
        {
            InitializeComponent();
            this.firmID = ID;
            DisplayFirmInfo(firmID);
            if (previous_form is Law_Firm_All_Forms.Form_LawFIrm_DashBoard_editInfo)
            {
                LbL_DistrictBack.Show();
                LbL_DivisionBack.Show();
                LbL_PassBack.Show();
                LbL_GmailBack.Show();
                LbL_MobileNoBack.Show();
                LbL_DoBBack.Show();

                LbL_DistrictBack.Visible = true;
                LbL_DivisionBack.Visible = true;
                LbL_PassBack.Visible = true;
                LbL_GmailBack.Visible = true;
                LbL_MobileNoBack.Visible = true;
                LbL_DoBBack.Visible = true;
            }

        }
        private void DisplayFirmInfo(string firmID)
        {
            string query = "SELECT Password, Division, District, Gmail,Mobile_NUmber,DOB FROM [User] WHERE NID = @FirmID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirmID", firmID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LbL_Password.Text = reader["Password"].ToString();
                                LbL_Division.Text = reader["Division"].ToString();
                                LbL_district.Text = reader["District"].ToString();
                                LbL_Gmail.Text = reader["Gmail"].ToString();
                                LbL_MobileNo.Text = reader["Mobile_NUmber"].ToString();
                                LbL_Dob.Text = reader["DOB"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No information found for the given FirmID.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
