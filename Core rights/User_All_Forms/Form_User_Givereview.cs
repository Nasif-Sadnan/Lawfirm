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
    public partial class Form_User_Givereview : Form
    {
        double rating=0;
        string NID;
        int Case_ID;

        string Firm_ID;
        string Lawyer_ID;

        private const string ConnectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        public Form_User_Givereview(string NID,int Case_ID)
        {
            InitializeComponent();
            this. NID = NID;
            this. Case_ID = Case_ID;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Icon_Pic_Minus_Click(object sender, EventArgs e)
        {
            if (rating <= 0)
            {
                rating = 0;
                LbL_Rateing.Text = rating.ToString();
            }
            else
            {
                rating -= 1;
                LbL_Rateing.Text = rating.ToString();
            }
        }

        private void Icon_Pic_Plus_Click(object sender, EventArgs e)
        {
            if (rating >=5)
            {
                rating = 5;
                LbL_Rateing.Text = rating.ToString();
            }
            else
            {
                rating += 1;
                LbL_Rateing.Text = rating.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    if (GetFirmID_Service(connection))
                    {
                        addreviewTo_LawFirm(connection);
                    }
                    else if (GetLawyerID_Services(connection))
                    {
                        //addreviewTo_Lawyer(connection);

                        MessageBox.Show("Review updated!!");
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void addreviewTo_LawFirm(SqlConnection connection)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[Review]
              ([Comment],[Firm_ID],[NID],[Case ID],[Rating])
              VALUES (@Comment, @FirmID,  @NID, @CaseID, @Rating)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Comment", Txt_Box_Message.Text);
                    cmd.Parameters.AddWithValue("@FirmID", Firm_ID);
                    cmd.Parameters.AddWithValue("@NID", NID);
                    cmd.Parameters.AddWithValue("@CaseID", Case_ID);
                    cmd.Parameters.AddWithValue("@Rating", rating);


                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Review updated!!");
                UpdateCaseStatus(connection, Case_ID);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void addreviewTo_Lawyer(SqlConnection connection)
        {
            try
            {

                string query = @"INSERT INTO [dbo].[Review]
              ([Comment],[Lawyer ID ],[NID],[Case ID],[Rating])
              VALUES (@Comment, @lawyerID,  @NID, @CaseID, @Rating)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Comment", Txt_Box_Message.Text);
                    cmd.Parameters.AddWithValue("@lawyerID", Lawyer_ID);
                    cmd.Parameters.AddWithValue("@NID", NID);
                    cmd.Parameters.AddWithValue("@CaseID", Case_ID);
                    cmd.Parameters.AddWithValue("@Rating", rating);
;

                    cmd.ExecuteNonQuery();
                }

                UpdateCaseStatus(connection, Case_ID);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private bool GetFirmID_Service(SqlConnection connection)
        {
            string firmIDQuery = "SELECT Firm_ID FROM [Case] WHERE [Case ID] = @CaseID";

            using (SqlCommand command = new SqlCommand(firmIDQuery, connection))
            {
                command.Parameters.AddWithValue("@CaseID", Case_ID);

                object result = command.ExecuteScalar();
                Firm_ID = result != null ? result.ToString() : null;

                return Firm_ID != null;
            }
        }

        private bool GetLawyerID_Services(SqlConnection connection)
        {
            string lawyerIDQuery = "SELECT [Lawyer ID] FROM [Case] WHERE [Case ID] = @CaseID";

            using (SqlCommand command = new SqlCommand(lawyerIDQuery, connection))
            {
                command.Parameters.AddWithValue("@CaseID", Case_ID);

                object result = command.ExecuteScalar();
                Lawyer_ID = result != null ? result.ToString() : null;

                return Lawyer_ID != null;
            }
        }

        private void UpdateCaseStatus(SqlConnection connection, int caseID)
        {
            string updateStatusQuery = "UPDATE [Case] SET [review_status] = 'Reviewed' WHERE [Case ID] = @CaseID";

            using (SqlCommand command = new SqlCommand(updateStatusQuery, connection))
            {
                command.Parameters.AddWithValue("@CaseID", caseID);
                command.ExecuteNonQuery();
            }
        }
    }
}
