using Core_rights.Individual_Lawyer_All_Forms;
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

namespace Core_rights.Lawyer_Under_Firm_All_Forms
{
    public partial class Form_LawyerUnderFirm_Editinfo : Form
    {
        private string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        private string firmID;
        public Form_LawyerUnderFirm_Editinfo(string ID)
        {
            InitializeComponent();
            this.firmID = ID;
            Icn_Pic_Edit_Done.IconChar = IconChar.SquareCheck;
            DisplayFirmInfo(firmID);
        }

        private void DisplayFirmInfo(string firmID)
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
                                TxT_Box_Pass.Text = reader["Password"].ToString();
                                Cmbo_Box_Division.Text = reader["Division"].ToString();
                                Cmbo_Box_District.Text = reader["District"].ToString();
                                TxT_Box_Gmail.Text = reader["Gmail"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No information found for the given Lawyer ID.");
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
            string newDivision = Cmbo_Box_Division.Text;
            string newDistrict = Cmbo_Box_District.Text;
            string newGmail = TxT_Box_Gmail.Text;

            string updateQuery = "UPDATE [Lawyer Under Firm] SET Password = @Password, Division = @Division, District = @District, Gmail = @Gmail WHERE [Judicial licence number ] = @LawyerID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Division", newDivision);
                    command.Parameters.AddWithValue("@District", newDistrict);
                    command.Parameters.AddWithValue("@Gmail", newGmail);
                    command.Parameters.AddWithValue("@LawyerID", firmID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.");

                            Form_LawyerUnderFIrm_ShowInfo showInfoForm = new Form_LawyerUnderFIrm_ShowInfo(firmID, this);

                            this.Hide();

                            Form_Lawyer_Underfirm_dashboard parentForm = this.ParentForm as Form_Lawyer_Underfirm_dashboard;

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
                            MessageBox.Show("No datas were updated. Please check the Lawyer ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void Cmbo_Box_District_MouseClick(object sender, MouseEventArgs e)
        {
            if (Cmbo_Box_Division.Text == "Dhaka")
            {
                string[] Dhaka_Districts =
                {
                        "Dhaka", "Faridpur", "Gazipur", "Gopalganj", "Kishoreganj","Madaripur", "Manikganj","Munshiganj", "Narayanganj", "Narsingdi","Rajbari", "Shariatpur", "Tangail"
                };

                Cmbo_Box_District.Items.AddRange(Dhaka_Districts);
            }
            else if (Cmbo_Box_Division.Text == "Chattogram")
            {
                string[] Chattogram_Districts =
                {
                        "Brahmanbaria","Comilla","Chandpur","Lakshmipur","Noakhali","Feni","Khagrachhari","Rangamati","Bandarban","Chittagong","Cox's Bazar"
                };
                Cmbo_Box_District.Items.AddRange(Chattogram_Districts);
            }
            else if (Cmbo_Box_Division.Text == "Barishal")
            {
                string[] Barishal_Districts =
                {
                        "Barishal", "Patuakhali", "Bhola", "Pirojpur", "Barguna", "Jhalokati"
                };
                Cmbo_Box_District.Items.AddRange(Barishal_Districts);
            }
            else if (Cmbo_Box_Division.Text == "Khulna")
            {
                string[] Khulna_Districts =
                {
                        "Khulna", "Bagherhat", "Sathkhira", "Jessore", "Magura", "Jhenaidah", "Narail", "Kushtia", "Chuadanga", "Meherpur"
                };
                Cmbo_Box_District.Items.AddRange(Khulna_Districts);
            }
            else if (Cmbo_Box_Division.Text == "Rajshahi")
            {
                string[] Rajshahi_Districts =
                {
                        "Rajshahi", "Chapainawabganj", "Natore", "Naogaon", "Pabna", "Sirajganj", "Bogra", "Joypurhat"
                };
                Cmbo_Box_District.Items.AddRange(Rajshahi_Districts);
            }
            else if (Cmbo_Box_Division.Text == "Rangpur")
            {
                string[] Rangpur_Districts =
                {
                        "Rangpur", "Gaibandha", "Nilphamari", "Kurigram", "Lalmonirhat", "Dinajpur", "Thakurgaon", "Panchagarh"
                };
                Cmbo_Box_District.Items.AddRange(Rangpur_Districts);
            }
            else if (Cmbo_Box_Division.Text == "Mymensingh")
            {
                string[] Mymensingh_Districts =
                {
                        "Mymensingh", "Jamalpur", "Netrokona", "Sherpur"
                };
                Cmbo_Box_District.Items.AddRange(Mymensingh_Districts);
            }
            else if (Cmbo_Box_Division.Text == "Sylhet")
            {
                string[] Sylhet_Districts =
                {
                        "Habiganj", "Moulvibazar", "Sunamganj", "Sylhet"
                };
                Cmbo_Box_District.Items.AddRange(Sylhet_Districts);
            }
        }
    }
}
