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

namespace Core_rights.Admin_All_Forms
{
    public partial class Form_Admin_EditInfo : Form
    {
        private string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        private string firmID;
        public Form_Admin_EditInfo(string ID)
        {
            InitializeComponent();
            this.firmID = ID;
            Icn_Pic_Edit_Done.IconChar = IconChar.SquareCheck;
            DisplayFirmInfo(firmID);
        }

        private void DisplayFirmInfo(string firmID)
        {
            string query = "SELECT Password,Gmail FROM [Admin] WHERE ID = @FirmID";

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
                                TxT_Box_Pass.Text = reader["Password"].ToString();
                                TxT_Box_Gmail.Text = reader["Gmail"].ToString();
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

        private void Icn_Pic_Edit_Done_Click(object sender, EventArgs e)
        {
            string newPassword = TxT_Box_Pass.Text;
            string newGmail = TxT_Box_Gmail.Text;


            string updateQuery = "UPDATE [Admin] SET Password = @Password, Gmail = @Gmail WHERE ID = @FirmID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Gmail", newGmail);
                    command.Parameters.AddWithValue("@FirmID", firmID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.");

                            Form_Admin_ShowInfo showInfoForm = new Form_Admin_ShowInfo(firmID, this);

                            this.Hide();

                            Form_Admin_Dashboard parentForm = this.ParentForm as Form_Admin_Dashboard;

                            if (parentForm != null)
                            {
                                showInfoForm.TopLevel = false;
                                showInfoForm.FormBorderStyle = FormBorderStyle.None;
                                showInfoForm.Dock = DockStyle.Fill;

                                parentForm.panel_lawyer_infoes.Controls.Clear();

                                parentForm.panel_lawyer_infoes.Controls.Add(showInfoForm);

                                showInfoForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No datas were updated. Please check the Firm ID.");
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
