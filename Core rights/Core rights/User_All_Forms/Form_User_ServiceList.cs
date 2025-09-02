using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core_rights.User_All_Forms
{
    public partial class Form_User_ServiceList : Form
    {
        string FirmID;
        string UserID;
        Form backform;

        int price_Of_FIlecheck;
        int price_Of_Consult;

        int file_payment;
        int consultPayment;

        int service_ID;

        int num_Of_FIlecheck=1;
        int num_Of_Consult=1;

        
        public Form_User_ServiceList(string UserID, string FirmID, Form backform)
        {
            InitializeComponent();
            this.FirmID = FirmID;
            this.UserID = UserID;
            this.backform = backform;

            PlusIcon_file_Num.IconChar = FontAwesome.Sharp.IconChar.Plus;
            PlusIcon_hourconsult.IconChar = FontAwesome.Sharp.IconChar.Plus;

            PnL_File_Check.Visible = false;
            PnL_File_Check.Visible = false;

            if (backform is Form_LawFirm_Infoes)
            {
                Service_taken_FromLawFirm();
            }
            else
            {
                Service_taken_Lawyer();
            }

            Servicelistcheck();
        }
        private void Service_taken_FromLawFirm()
        {

            Lbl_serviceholder.Text = "Law Firm   : ";
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
                        LbL_ServiceProvider.Text = result.ToString();
                    }
                    else
                    {
                        LbL_ServiceProvider.Text = "Law Firm not found!";
                    }
                }

                connection.Close();
            }
        }

        private void Service_taken_Lawyer()
        {
            Lbl_serviceholder.Text = "Lawyer   : ";
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
                        LbL_ServiceProvider.Text = result.ToString();
                    }
                    else
                    {
                        LbL_ServiceProvider.Text = "Lawyer not found!";
                    }
                }

                connection.Close();
            }
        }
        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


       


        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void Servicelistcheck()
        {
            if (backform is Form_LawFirm_Infoes)
            {
                if (CheckServiceExists("Taking consultation"))
                {
                    PnL_consult.Visible = true;
                    Get_PriceOf_LawFirm_services_Consult("Taking consultation");
                }
                else
                {
                    PnL_consult.Visible = false;
                }

                if (CheckServiceExists("File checking"))
                {
                    PnL_File_Check.Visible = true;
                    Get_PriceOf_LawFirm_services_Filecheck("File checking");
                }
                else
                {
                    PnL_File_Check.Visible = false;
                }
            }
            else
            {
                if (CheckServiceExists_Inlawyer("Taking consultation"))
                {
                    PnL_consult.Visible = true;
                    Get_PriceOf_PriceOf_Lawyer_services_Consult("Taking consultation");
                }
                else
                {
                    PnL_consult.Visible = false;
                }

                if (CheckServiceExists_Inlawyer("File checking"))
                {
                    PnL_File_Check.Visible = true;
                    Get_PriceOf_Lawyer_services_Filecheck("File checking");
                }
                else
                {
                    PnL_File_Check.Visible = false;
                }
            }
        }


        private bool CheckServiceExists(string serviceName)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                int count;
                connection.Open();

                string query = "SELECT COUNT(*) FROM Service WHERE [Service Name] = @ServiceName AND Firm_ID = @FirmID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceName", serviceName);
                    command.Parameters.AddWithValue("@FirmID", FirmID);

                    count = (int)command.ExecuteScalar();

                }
                connection.Close();
                return count > 0;

            }
        }
        private bool CheckServiceExists_Inlawyer(string serviceName)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                int count;
                connection.Open();

                string query = "SELECT COUNT(*) FROM Service WHERE [Service Name] = @ServiceName AND [Lawyer ID] = @FirmID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceName", serviceName);
                    command.Parameters.AddWithValue("@FirmID", FirmID);

                    count = (int)command.ExecuteScalar();

                }
                connection.Close();
                return count > 0;
            }
        }
        private int Get_PriceOf_LawFirm_services_Filecheck(string servicename)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT Payment FROM Service WHERE [Service Name] = @ServiceName AND [Firm_ID] = @FirmID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceName", servicename);
                    command.Parameters.AddWithValue("@FirmID", FirmID);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        price_Of_FIlecheck = Convert.ToInt32(result);
                        file_payment = Convert.ToInt32(result);
                        LbL_PriceOf_File_Check.Text = result.ToString()+" Taka";
                    }

                }
                connection.Close();
                return 0;
            }
        }
        private int Get_PriceOf_LawFirm_services_Consult(string servicename)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT Payment FROM Service WHERE [Service Name] = @ServiceName AND [Firm_ID] = @FirmID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceName", servicename);
                    command.Parameters.AddWithValue("@FirmID", FirmID);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        consultPayment = Convert.ToInt32(result);
                        price_Of_Consult = Convert.ToInt32(result);
                        LbL_PriceOf_Consulting.Text = result.ToString() + " Taka";
                    }

                    
                }
                connection.Close();
                return 0;
            }
        }

        private int Get_PriceOf_Lawyer_services_Filecheck(string servicename)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT Payment FROM Service WHERE [Service Name] = @ServiceName AND [Lawyer ID] = @FirmID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceName", servicename);
                    command.Parameters.AddWithValue("@FirmID", FirmID);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        file_payment = Convert.ToInt32(result);
                        price_Of_FIlecheck = Convert.ToInt32(result);
                        LbL_PriceOf_File_Check.Text = result.ToString() + " Taka";
                    }

                    
                }
                connection.Close();
                return 0;
            }
        }
        private int Get_PriceOf_PriceOf_Lawyer_services_Consult(string servicename)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT Payment FROM Service WHERE [Service Name] = @ServiceName AND [Lawyer ID] = @FirmID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceName", servicename);
                    command.Parameters.AddWithValue("@FirmID", FirmID);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        consultPayment = Convert.ToInt32(result);
                        price_Of_Consult = Convert.ToInt32(result);
                        LbL_PriceOf_Consulting.Text = result.ToString() + " Taka";
                    }

                    
                }
                connection.Close();
                return 0;
            }
        }

        private void PlusIcon_file_Num_Click(object sender, EventArgs e)
        {
            num_Of_FIlecheck++;
            file_payment= file_payment + price_Of_FIlecheck;
            LbL_Num_OfFIle.Text = num_Of_FIlecheck.ToString();
            LbL_PriceOf_File_Check.Text= file_payment.ToString()+" Taka";
        }

        private void PlusIcon_hourconsult_Click(object sender, EventArgs e)
        {
            num_Of_Consult++;
            consultPayment =consultPayment+ price_Of_Consult;
            LbL_HourOf_Consult.Text = num_Of_Consult.ToString();
            LbL_PriceOf_Consulting.Text = consultPayment.ToString() + " Taka";
        }

        private void MinusIcon_FileCheck_Click(object sender, EventArgs e)
        {
            if(num_Of_FIlecheck <= 1)
            {
                LbL_Num_OfFIle.Text = "1";
            }
            else
            {
                num_Of_FIlecheck--;
                file_payment = file_payment-price_Of_FIlecheck;
                LbL_Num_OfFIle.Text = num_Of_FIlecheck.ToString();
                LbL_PriceOf_File_Check.Text = file_payment.ToString() + " Taka";
            }
        }

        private void MinusIcon_TakeConsult_Click(object sender, EventArgs e)
        {
            if (num_Of_Consult <= 1)
            {
                LbL_HourOf_Consult.Text = "1";
            }
            else
            {
                num_Of_Consult--;
                consultPayment = consultPayment - price_Of_Consult;
                LbL_HourOf_Consult.Text = num_Of_Consult.ToString();
                LbL_PriceOf_Consulting.Text = consultPayment.ToString() + " Taka";
            }
        }

        private void Button_Payfor_consulting_Click(object sender, EventArgs e)
        {
            addtoservicetable("Taking consultation");
            Form_User_Payforcasecs form_User_Payforcasecs = new Form_User_Payforcasecs(this, UserID, service_ID, num_Of_Consult);
            this.Hide();
            form_User_Payforcasecs.ShowDialog();
        }
        private void Button_Payfor_Filecheck_Click(object sender, EventArgs e)
        {
            addtoservicetable("File checking"); 
            Form_User_Payforcasecs form_User_Payforcasecs = new Form_User_Payforcasecs(this, UserID, service_ID, num_Of_FIlecheck);
            this.Hide();
            form_User_Payforcasecs.ShowDialog();
        }

        private void addtoservicetable(string servicename)
        {
            if(backform is Form_LawFirm_Infoes)
            {
                AddToLawFirm(servicename);
            }
            else
            {
                AddToIndividualLawyer(servicename);
            }
        }
        private void AddToLawFirm(string serviceName)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();

                string selectQuery = "SELECT [Service ID], Payment FROM Service WHERE [Service Name] = @ServiceName AND [Firm_ID] = @FirmID";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@ServiceName", serviceName);
                    selectCommand.Parameters.AddWithValue("@FirmID", FirmID);

                    MessageBox.Show("added successfully");

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            service_ID = reader.GetInt32(reader.GetOrdinal("Service ID"));
                        }
                    }
                }

                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();

                string updateQuery = "UPDATE Service SET NID = @NID WHERE [Service ID] = @ServiceID";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@NID", UserID);
                    updateCommand.Parameters.AddWithValue("@ServiceID", service_ID);

                    updateCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


        private void AddToIndividualLawyer(string serviceName)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();

                string selectQuery = "SELECT [Service ID], Payment FROM Service WHERE [Service Name] = @ServiceName AND [Lawyer ID] = @FirmID";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@ServiceName", serviceName);
                    selectCommand.Parameters.AddWithValue("@FirmID", FirmID);

                    MessageBox.Show("added successfully");

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            service_ID = reader.GetInt32(reader.GetOrdinal("Service ID"));
                        }
                    }
                }

                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();

                string updateQuery = "UPDATE Service SET NID = @NID WHERE [Service ID] = @ServiceID";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@NID", UserID);
                    updateCommand.Parameters.AddWithValue("@ServiceID", service_ID);

                    updateCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

    }
}

