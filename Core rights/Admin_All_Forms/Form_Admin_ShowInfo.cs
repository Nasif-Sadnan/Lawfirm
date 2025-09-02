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

namespace Core_rights.Admin_All_Forms
{
    public partial class Form_Admin_ShowInfo : Form
    {
        private string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        private string firmID;
        public Form_Admin_ShowInfo(string ID, Form previous_form)
        {
            InitializeComponent();
            this.firmID = ID;
            DisplayFirmInfo(firmID);
            if(previous_form is Form_Admin_EditInfo)
            {

                LbL_PassBack.Show();
                LbL_GmailBack.Show();

                LbL_PassBack.Visible = true;
                LbL_GmailBack.Visible = true;
            }
               
            
        }

        private void DisplayFirmInfo(string firmID)
        {
            string query = "SELECT Password, Gmail FROM [Admin] WHERE ID = @FirmID";

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
                                LbL_Gmail.Text = reader["Gmail"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No information found for the given Admin ID.");
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
