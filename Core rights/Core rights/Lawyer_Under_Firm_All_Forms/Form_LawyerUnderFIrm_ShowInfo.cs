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

namespace Core_rights.Lawyer_Under_Firm_All_Forms
{
    public partial class Form_LawyerUnderFIrm_ShowInfo : Form
    {
        private string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        private string firmID;
        public Form_LawyerUnderFIrm_ShowInfo(string ID, Form previous_form)
        {
            InitializeComponent();
            InitializeComponent();
            this.firmID = ID;
            DisplayUserInfo(firmID);
        }

        private void DisplayUserInfo(string firmID)
        {
            string query = "SELECT Password, Division, District, Gmail FROM [Lawyer Under Firm] WHERE [Judicial licence number ] = @FirmID";

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
                            }
                            else
                            {
                                MessageBox.Show("No information found for the given lawyer ID.");
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
