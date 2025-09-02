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
    public partial class Form_User_Payforcasecs : Form
    {
        Form backform;
        int Case_ID;
        string NID;
        int n;
        private const string ConnectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        public Form_User_Payforcasecs(Form backform,string NID,int caseID,int amount)
        {
            InitializeComponent();
            this.Case_ID = caseID;

            this.NID = NID;
            this.n = amount;
            this.backform = backform;
            PnL_Paymentoption.Visible = false;
            Txt_Box_Mobileno.Visible = false;
            Txt_Box_Password.Visible = false;

            Radio_Btn_Rocket.Checked = false;
            Radio_Btn_Nagad.Checked = false;
            Radio_Btn_Bkash.Checked = false;

            loadInfo();
        }
        private void loadInfo()
        {
            string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            if (backform is Form_User_CaseInfo)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string casePaymentQuery = "SELECT Payment FROM [Case] WHERE [Case ID] = @Case_ID";

                    using (SqlCommand command = new SqlCommand(casePaymentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Case_ID", Case_ID);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            /*int payment = Convert.ToInt32(result);
                            int totalPayment = payment * n;*/

                            Btn_Pay.Text = "Pay for $ " + result.ToString();
                        }
                        else
                        {
                            Btn_Pay.Text = "Payment: N/A";
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string servicePaymentQuery = "SELECT Payment FROM [Service] WHERE [Service ID] = @Service_ID";

                    using (SqlCommand command = new SqlCommand(servicePaymentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Service_ID", Case_ID);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int payment = Convert.ToInt32(result);
                            int totalPayment = payment * n;

                            Btn_Pay.Text = "Pay for $ " + totalPayment.ToString();
                        }
                        else
                        {
                            Btn_Pay.Text = "Payment: N/A";
                        }
                    }
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PnL_Paymentoption.Visible=true;
            PnL_Paymentoption.Location = new System.Drawing.Point(650, 81);
            Txt_Box_Mobileno.Visible = true;
            Txt_Box_Password.Visible = true;
            Txt_Box_Mobileno.Text = null;
            LbL_Payment_Option.Text = "Via Bkash";
            Radio_Btn_Bkash.Checked = true;
            Radio_Btn_Nagad.Checked = false;
            Radio_Btn_Rocket.Checked = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PnL_Paymentoption.Visible = true;
            PnL_Paymentoption.Location = new System.Drawing.Point(813, 81);
            Txt_Box_Mobileno.Visible = true;
            Txt_Box_Password.Visible = true;
            Txt_Box_Mobileno.Text = null;
            LbL_Payment_Option.Text = "Via nagad";
            Radio_Btn_Nagad.Checked = true;
            Radio_Btn_Rocket.Checked = false;
            Radio_Btn_Bkash.Checked = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PnL_Paymentoption.Visible = true;
            PnL_Paymentoption.Location = new System.Drawing.Point(974, 81);
            Txt_Box_Mobileno.Visible = true;
            Txt_Box_Password.Visible = true;
            Txt_Box_Mobileno.Text = null;
            LbL_Payment_Option.Text = "Via Rocket";
            Radio_Btn_Rocket.Checked = true;
            Radio_Btn_Nagad.Checked = false;
            Radio_Btn_Bkash.Checked = false;
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Radio_Btn_Bkash_CheckedChanged(object sender, EventArgs e)
        {
            PnL_Paymentoption.Visible = true;
            PnL_Paymentoption.Location = new System.Drawing.Point(650, 81);
            Txt_Box_Mobileno.Visible = true;
            Txt_Box_Password.Visible = true;
            Txt_Box_Mobileno.Text = null;
            LbL_Payment_Option.Text = "Via Bkash";
            Radio_Btn_Bkash.Checked = true;
            Radio_Btn_Nagad.Checked = false;
            Radio_Btn_Rocket.Checked = false;
        }

        private void Radio_Btn_Nagad_CheckedChanged(object sender, EventArgs e)
        {
            PnL_Paymentoption.Visible = true;
            PnL_Paymentoption.Location = new System.Drawing.Point(813, 81);
            Txt_Box_Mobileno.Visible = true;
            Txt_Box_Password.Visible = true;
            Txt_Box_Mobileno.Text = null;
            LbL_Payment_Option.Text = "Via nagad";
            Radio_Btn_Nagad.Checked = true;
            Radio_Btn_Rocket.Checked = false;
            Radio_Btn_Bkash.Checked = false;
        }

        private void Radio_Btn_Rocket_CheckedChanged(object sender, EventArgs e)
        {
            PnL_Paymentoption.Visible = true;
            PnL_Paymentoption.Location = new System.Drawing.Point(974, 81);
            Txt_Box_Mobileno.Visible = true;
            Txt_Box_Password.Visible = true;
            Txt_Box_Mobileno.Text = null;
            LbL_Payment_Option.Text = "Via Rocket";
            Radio_Btn_Rocket.Checked = true;
            Radio_Btn_Nagad.Checked = false;
            Radio_Btn_Bkash.Checked = false;
        }

        private void Btn_Pay_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    connection.Open();

                    if (backform is Form_User_CaseInfo)
                    {

                        UpdateCase(connection);
                        MessageBox.Show("Payment successfull!!");
                        this.Hide();

                        //InsertPayment_ForCase(connection, GetFirmID(connection), GetLawyerID(connection));
                    }
                    else
                    {

                        MessageBox.Show("Payment successfull!!");
                        this.Hide();
                        //InsertPayment(connection, GetFirmID_Service(connection), GetLawyerID_Services(connection));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void UpdateCase(SqlConnection connection)
        {
            string updateCaseQuery = "UPDATE [Case] SET paid_status = 'paid' WHERE [Case ID] = @CaseID";

            using (SqlCommand updateCaseCommand = new SqlCommand(updateCaseQuery, connection))
            {
                updateCaseCommand.Parameters.AddWithValue("@CaseID", Case_ID);
                

                updateCaseCommand.ExecuteNonQuery();

                
            }
        }


        private void InsertPayment_ForCase(SqlConnection connection, string firmID, string lawyerID)
        {           
            SqlCommand cmd = new SqlCommand(@" INSERT INTO [dbo].[Payment]
                                            ([Payment_Type],[Account_No],[NID],[Firm_ID],[Case ID],[amount],[Lawyer ID])
                                             VALUES ('" + LbL_Payment_Option.Text + "','"+ Txt_Box_Mobileno.Text + "','"+ NID + "','"+ firmID + "','"+Case_ID+"','"+n+"','"+ lawyerID + "')", connection);
            
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Payment Successfull!!");
            this.Hide();
        }

        private void InsertPayment(SqlConnection connection, string firmID, string lawyerID)
        {
            SqlCommand cmd = new SqlCommand(@" INSERT INTO [dbo].[Payment]
                                            ([Payment_Type],[Account_No],[NID],[Firm_ID],[Service ID],[amount],[Lawyer ID])
                                             VALUES ('" + LbL_Payment_Option.Text + "','" + Txt_Box_Mobileno.Text + "','" + NID + "','" + firmID + "','" + Case_ID + "','" + n + "','"+ lawyerID + "')", connection);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Payment Successfull!!");
            this.Hide();
        }
        private string GetFirmID(SqlConnection connection)
        {
            string firmIDQuery = "SELECT Firm_ID FROM [Case] WHERE [Case ID] IN (@CaseIDs)";

            using (SqlCommand command = new SqlCommand(firmIDQuery, connection))
            {
                command.Parameters.AddWithValue("@CaseIDs", Case_ID);
                object result = command.ExecuteScalar();

                return result.ToString();
            }
        }

        private string GetLawyerID(SqlConnection connection)
        {
            string lawyerIDQuery = "SELECT [Lawyer ID] FROM [Case] WHERE [Case ID] IN (@CaseIDs)";

            using (SqlCommand command = new SqlCommand(lawyerIDQuery, connection))
            {
                command.Parameters.AddWithValue("@CaseIDs", Case_ID);
                object result = command.ExecuteScalar();

                return result.ToString();
            }
        }

        private string GetFirmID_Service(SqlConnection connection)
        {
            string firmIDQuery = "SELECT Firm_ID FROM Service WHERE [Service ID] IN (@CaseIDs)";

            using (SqlCommand command = new SqlCommand(firmIDQuery, connection))
            {
                command.Parameters.AddWithValue("@CaseIDs", Case_ID);
                object result = command.ExecuteScalar();

                return result.ToString();
            }
        }

        private string GetLawyerID_Services(SqlConnection connection)
        {
            string lawyerIDQuery = "SELECT [Lawyer ID ] FROM Service WHERE [Service ID] IN (@CaseIDs)";

            using (SqlCommand command = new SqlCommand(lawyerIDQuery, connection))
            {
                command.Parameters.AddWithValue("@CaseIDs", Case_ID);
                object result = command.ExecuteScalar();

                return result.ToString();
            }
        }
    }
}
