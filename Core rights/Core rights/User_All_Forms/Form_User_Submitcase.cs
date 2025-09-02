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
    public partial class Form_User_Submitcase : Form
    {
        string FirmID;
        string UserID;
        Form backform;
        public Form_User_Submitcase(string UserID, string FirmID,Form backform)
        {
            InitializeComponent();
            this.FirmID = FirmID;
            this.UserID = UserID;
            this.backform = backform;
            if(backform is Form_LawFirm_Infoes)
            {
                SetSubmittedTo_Law_Firm();
            }
            else
            {
                SetSubmittedTo_Individual_Lawyer();
            }

            SetSubmitterName();
        }

        private void SetSubmitterName()
        {
            string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            string userNameQuery = "SELECT Name FROM [User] WHERE NID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(userNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        LbL_Submittername.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("User not found!");
                    }
                }

                connection.Close();
            }
        }

        private void SetSubmittedTo_Law_Firm()
        {

            LbL_Submitted_To_Institute.Text = "(Submitted to law firm)";
            string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            string userNameQuery = "SELECT Firm_Name FROM [Law Firm] WHERE Firm_ID = @FirmID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(userNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirmID", FirmID);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        LbL_Submittername.Text = result.ToString();
                    }
                    else
                    {
                        LbL_Submittername.Text = "Firm not found!";
                    }
                }

                connection.Close();
            }
        }

        private void SetSubmittedTo_Individual_Lawyer()
        {
            LbL_Submitted_To_Institute.Text = "(Submitted to lawyer)";
            string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            string userNameQuery = "SELECT [Lawyer Name] FROM [Individual Lawyer] WHERE [Lawyer ID ] = @FirmID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(userNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirmID", FirmID);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        LbL_Submittername.Text = result.ToString();
                    }
                    else
                    {
                        LbL_Submittername.Text = "Lawyer not found!";
                    }
                }

                connection.Close();
            }
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TxT_Box_Case_Name_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_Case_Name.Text == "Enter your case name")
            {
                TxT_Box_Case_Name.Text = "";

                TxT_Box_Case_Name.ForeColor = SystemColors.Control;
            }
        }

        private void TxT_Box_Case_Name_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_Case_Name.Text == "")
            {
                TxT_Box_Case_Name.Text = "Enter your case name";

                TxT_Box_Case_Name.ForeColor =  SystemColors.ControlDarkDark;
            }
        }

        private void TxT_Box_VictimName_Enter(object sender, EventArgs e)
        {
            if(TxT_Box_VictimName.Text== "Enter Victim name")
            {
                TxT_Box_VictimName.Text = "";

                TxT_Box_VictimName.ForeColor = SystemColors.Control;
            }
        }

        private void TxT_Box_VictimName_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_VictimName.Text == "")
            {
                TxT_Box_VictimName.Text = "Enter Victim name";

                TxT_Box_VictimName.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void TxT_Box_OpponentName_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_OpponentName.Text == "Enter opponent name")
            {
                TxT_Box_OpponentName.Text = "";

                TxT_Box_OpponentName.ForeColor = SystemColors.Control;
            }
        }

        private void TxT_Box_OpponentName_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_OpponentName.Text == "")
            {
                TxT_Box_OpponentName.Text = "Enter opponent name";

                TxT_Box_OpponentName.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void Cmbo_Box_Division_Enter(object sender, EventArgs e)
        {
            if (Cmbo_Box_Division.Text == "Select Division")
            {
                Cmbo_Box_Division.Text = "";
                Cmbo_Box_Division.ForeColor = SystemColors.Control;
            }
        }

        private void Cmbo_Box_Division_Leave(object sender, EventArgs e)
        {
            if (Cmbo_Box_Division.Text == "")
            {
                Cmbo_Box_Division.Text = "Select Division";
                Cmbo_Box_Division.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void Cmbo_Box_District_Enter(object sender, EventArgs e)
        {
            if (Cmbo_Box_District.Text == "Select District")
            {
                Cmbo_Box_District.Text = "";
                Cmbo_Box_District.ForeColor = SystemColors.Control;
            }
        }

        private void Cmbo_Box_District_Leave(object sender, EventArgs e)
        {
            if (Cmbo_Box_District.Text == "" || Cmbo_Box_District.Text == "Select Division first" || Cmbo_Box_District.Text == "Select Division correctly")
            {
                Cmbo_Box_District.Text = "Select District";
                Cmbo_Box_District.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void Cmbo_Box_District_MouseClick(object sender, MouseEventArgs e)
        {
            Cmbo_Box_District.Items.Clear();


            if (string.IsNullOrWhiteSpace(Cmbo_Box_Division.Text))
            {
                Cmbo_Box_District.Items.Add("Select Division first");
            }
            else
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
                else
                {
                    Cmbo_Box_District.Items.Add("Select Division correctly");
                }
            }
        }

        private void Icn_BtN_SUbmit_Case_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string caseName = TxT_Box_Case_Name.Text;
                DateTime caseTime = Date_Time_Case.Value;
                string victimName = TxT_Box_VictimName.Text;
                string opponentName = TxT_Box_OpponentName.Text;
                string division = Cmbo_Box_Division.Text;
                string district = Cmbo_Box_District.Text;

                string userID = UserID;
                string firmID = FirmID;

                if (backform is Form_LawFirm_Infoes)
                {
                    string insertQuery = "INSERT INTO [Case] ([Case Name], [Case Time], [Victim], [Opponent], [Case Place_Division], [Case Place_District], [NID], [Firm_ID]) " +
                                         "VALUES (@CaseName, @CaseTime, @Victim, @Opponent, @Division, @District, @UserID, @FirmID)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CaseName", caseName);
                        command.Parameters.AddWithValue("@CaseTime", caseTime);
                        command.Parameters.AddWithValue("@Victim", victimName);
                        command.Parameters.AddWithValue("@Opponent", opponentName);
                        command.Parameters.AddWithValue("@Division", division);
                        command.Parameters.AddWithValue("@District", district);
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@FirmID", firmID);

                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertQuery = "INSERT INTO [Case] ([Case Name], [Case Time], [Victim], [Opponent], [Case Place_Division], [Case Place_District], [NID], [Lawyer ID]) " +
                                         "VALUES (@CaseName, @CaseTime, @Victim, @Opponent, @Division, @District, @UserID, @FirmID)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CaseName", caseName);
                        command.Parameters.AddWithValue("@CaseTime", caseTime);
                        command.Parameters.AddWithValue("@Victim", victimName);
                        command.Parameters.AddWithValue("@Opponent", opponentName);
                        command.Parameters.AddWithValue("@Division", division);
                        command.Parameters.AddWithValue("@District", district);
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@FirmID", firmID);

                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
                MessageBox.Show("Case submitted successfully!");
                this.Hide();
            }
        }
    }
}
