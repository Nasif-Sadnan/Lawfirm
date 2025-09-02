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

namespace Core_rights.User_All_Forms
{
    public partial class Form_User_CaseInfo : Form
    {
        public string ID;
        bool has_Law_Firm;
        bool has_Lawyer;
        public Form_User_CaseInfo(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            LoadLawyerInfo(ID);
        }
        private void LoadLawyerInfo(string ID)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (Cmbo_Box_lawFirmType.Text == "Select Case Type" || Cmbo_Box_lawFirmType.Text == "All")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Case Name], [Case ID], [Firm_ID], [Lawyer ID],[Case Status],[paid_status],[review_status] FROM [Case] WHERE [NID] = @ID ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            int yOffset = 32;

                            Panel panel = new Panel();
                            panel.Size = new System.Drawing.Size(500, 2);
                            panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
                            panel.Location = new System.Drawing.Point(14, 0);

                            panel_lawyer_infoes.Controls.Add(panel);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                string paidStatus = row["paid_status"].ToString();
                                string reviewStatus = row["review_status"].ToString();

                                Label nameLabel = new Label();
                                nameLabel.Text = row["Case Name"].ToString() + "  Case";
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label caseStatus = new Label();
                                caseStatus.Text="Status : "+row["Case Status"].ToString();
                                caseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                caseStatus.AutoSize = true;

                                switch (row["Case Status"].ToString().ToLower())
                                {
                                    case "pending case":
                                        caseStatus.ForeColor = System.Drawing.Color.Red;
                                        break;
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        if (paidStatus == "not_paid")
                                        {
                                            Button pay = new Button();
                                            pay.Text = "Pay";
                                            pay.Tag = row["Case ID"];
                                            pay.Size = new System.Drawing.Size(130, 30);
                                            pay.Location = new System.Drawing.Point(390, yOffset);
                                            pay.Click += Pay_Clicked;
                                            panel_lawyer_infoes.Controls.Add(pay);
                                        }
                                        break;
                                    case "closed case":
                                        caseStatus.ForeColor = System.Drawing.Color.Yellow;
                                        if (reviewStatus == "not_reviewed")
                                        {
                                            Button review = new Button();
                                            review.Text = "Give Review";
                                            review.Tag = row["Case ID"];
                                            review.Size = new System.Drawing.Size(130, 30);
                                            review.Location = new System.Drawing.Point(390, yOffset);
                                            review.Click += Review_Clicked;
                                            panel_lawyer_infoes.Controls.Add(review);
                                        }
                                        break;
                                    default:
                                       
                                        break;

                                }

                                Label idLabel = new Label();
                                idLabel.Text = "Case ID: " + row["Case ID"].ToString();
                                idLabel.AutoSize = true;

                                Label firmIdLabel = new Label();
                                firmIdLabel.Text = "The case was submitted to the law Firm with ID: " + (row["Firm_ID"] == DBNull.Value ? "N/A" : row["Firm_ID"].ToString());
                                firmIdLabel.AutoSize = true;
                                firmIdLabel.Visible = (row["Firm_ID"] != DBNull.Value);

                                Label lawyerIdLabel = new Label();
                                lawyerIdLabel.Text = "The case was submitted to the Lawyer with ID: " + (row["Lawyer ID"] == DBNull.Value ? "N/A" : row["Lawyer ID"].ToString());
                                lawyerIdLabel.AutoSize = true;
                                lawyerIdLabel.Visible = (row["Lawyer ID"] != DBNull.Value);

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.FileInvoice;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 32;

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                firmIdLabel.Location = new System.Drawing.Point(230, yOffset + 50);
                                lawyerIdLabel.Location = new System.Drawing.Point(230, yOffset + 50 );
                                caseStatus.Location = new System.Drawing.Point(230, yOffset);


                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(firmIdLabel);
                                panel_lawyer_infoes.Controls.Add(lawyerIdLabel);
                                panel_lawyer_infoes.Controls.Add(caseStatus);


                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else if (Cmbo_Box_lawFirmType.Text == "pending case" || Cmbo_Box_lawFirmType.Text == "running case" || Cmbo_Box_lawFirmType.Text == "closed case")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Case Name], [Case ID], [Firm_ID], [Lawyer ID],[Case Status],[review_status],[paid_status] FROM [Case] WHERE [NID] = @ID AND [Case Status] = @Case_Status";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Case_Status", Cmbo_Box_lawFirmType.Text);
                        command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            int yOffset = 32;

                            Panel panel = new Panel();
                            panel.Size = new System.Drawing.Size(500, 2);
                            panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
                            panel.Location = new System.Drawing.Point(14, 0);

                            panel_lawyer_infoes.Controls.Add(panel);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                string paidStatus = row["paid_status"].ToString();
                                string reviewStatus = row["review_status"].ToString();

                                Label nameLabel = new Label();
                                nameLabel.Text = row["Case Name"].ToString() + "  Case";
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Case ID: " + row["Case ID"].ToString();
                                idLabel.AutoSize = true;

                                Label firmIdLabel = new Label();
                                firmIdLabel.Text = "The case was submitted to the Law Firm with ID: " + (row["Firm_ID"] == DBNull.Value ? "N/A" : row["Firm_ID"].ToString());
                                firmIdLabel.AutoSize = true;
                                firmIdLabel.Visible = (row["Firm_ID"] != DBNull.Value);

                                Label caseStatus = new Label();
                                caseStatus.Text = "Status : " + row["Case Status"].ToString();
                                caseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                caseStatus.AutoSize = true;

                                switch (row["Case Status"].ToString().ToLower())
                                {
                                    case "pending case":
                                        caseStatus.ForeColor = System.Drawing.Color.Red;
                                        break;
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        if (paidStatus == "not_paid")
                                        {
                                            Button pay = new Button();
                                            pay.Text = "Pay";
                                            pay.Tag = row["Case ID"];
                                            pay.Size = new System.Drawing.Size(130, 30);
                                            pay.Location = new System.Drawing.Point(390, yOffset);
                                            pay.Click += Pay_Clicked;
                                            panel_lawyer_infoes.Controls.Add(pay);
                                        }
                                        break;
                                    case "closed case":
                                        caseStatus.ForeColor = System.Drawing.Color.Yellow;
                                        if (reviewStatus == "not_reviewed")
                                        {
                                            Button review = new Button();
                                            review.Text = "Give Review";
                                            review.Tag = row["Case ID"];
                                            review.Size = new System.Drawing.Size(130, 30);
                                            review.Location = new System.Drawing.Point(390, yOffset);
                                            review.Click += Review_Clicked;
                                            panel_lawyer_infoes.Controls.Add(review);
                                        }
                                        break;
                                    default:

                                        break;

                                }

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.FileInvoice;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 32;

                                Label lawyerIdLabel = new Label();
                                lawyerIdLabel.Text = "The case was submitted to the Lawyer with ID: " + (row["Lawyer ID"] == DBNull.Value ? "N/A" : row["Lawyer ID"].ToString());
                                lawyerIdLabel.AutoSize = true;
                                lawyerIdLabel.Visible = (row["Lawyer ID"] != DBNull.Value);

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                firmIdLabel.Location = new System.Drawing.Point(230, yOffset + 50);
                                lawyerIdLabel.Location = new System.Drawing.Point(230, yOffset + 50);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                caseStatus.Location = new System.Drawing.Point(230, yOffset);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(firmIdLabel);
                                panel_lawyer_infoes.Controls.Add(lawyerIdLabel);
                                panel_lawyer_infoes.Controls.Add(caseStatus);

                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else
                {
                    Label caselbl = new Label();
                    caselbl.Text = "no cases available!!!!";
                    caselbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    caselbl.AutoSize = true;
                    caselbl.ForeColor = System.Drawing.Color.Green;
                    caselbl.Location = new System.Drawing.Point(80, 32);
                    panel_lawyer_infoes.Controls.Add(caselbl);
                }
            }
        }

        private void Cmbo_Box_lawFirmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (Cmbo_Box_lawFirmType.Text == "Select Case Type" || Cmbo_Box_lawFirmType.Text == "All")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Case Name], [Case ID], [Firm_ID], [Lawyer ID],[Case Status],[review_status],[paid_status] FROM [Case] WHERE [NID] = @ID ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            int yOffset = 32;

                            Panel panel = new Panel();
                            panel.Size = new System.Drawing.Size(500, 2);
                            panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
                            panel.Location = new System.Drawing.Point(14, 0);

                            panel_lawyer_infoes.Controls.Add(panel);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                string paidStatus = row["paid_status"].ToString();
                                string reviewStatus = row["review_status"].ToString();

                                Label nameLabel = new Label();
                                nameLabel.Text = row["Case Name"].ToString() + "  Case";
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label caseStatus = new Label();
                                caseStatus.Text = "Status : " + row["Case Status"].ToString();
                                caseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                caseStatus.AutoSize = true;

                                switch (row["Case Status"].ToString().ToLower())
                                {
                                    case "pending case":
                                        caseStatus.ForeColor = System.Drawing.Color.Red;
                                        break;
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        if (paidStatus == "not_paid")
                                        {
                                            Button pay = new Button();
                                            pay.Text = "Pay";
                                            pay.Tag = row["Case ID"];
                                            pay.Size = new System.Drawing.Size(130, 30);
                                            pay.Location = new System.Drawing.Point(390, yOffset);
                                            pay.Click += Pay_Clicked;
                                            panel_lawyer_infoes.Controls.Add(pay);
                                        }
                                        break;
                                    case "closed case":
                                        caseStatus.ForeColor = System.Drawing.Color.Yellow;
                                        if (reviewStatus == "not_reviewed")
                                        {
                                            Button review = new Button();
                                            review.Text = "Give Review";
                                            review.Tag = row["Case ID"];
                                            review.Size = new System.Drawing.Size(130, 30);
                                            review.Location = new System.Drawing.Point(390, yOffset);
                                            review.Click += Review_Clicked;
                                            panel_lawyer_infoes.Controls.Add(review);
                                        }
                                        break;
                                    default:

                                        break;

                                }

                                Label idLabel = new Label();
                                idLabel.Text = "Case ID: " + row["Case ID"].ToString();
                                idLabel.AutoSize = true;

                                Label firmIdLabel = new Label();
                                firmIdLabel.Text = "The case was submitted to the Law Firm with ID: " + (row["Firm_ID"] == DBNull.Value ? "N/A" : row["Firm_ID"].ToString());
                                firmIdLabel.AutoSize = true;
                                firmIdLabel.Visible = (row["Firm_ID"] != DBNull.Value);

                                Label lawyerIdLabel = new Label();
                                lawyerIdLabel.Text = "The case was submitted to the Lawyer with ID: " + (row["Lawyer ID"] == DBNull.Value ? "N/A" : row["Lawyer ID"].ToString());
                                lawyerIdLabel.AutoSize = true;
                                lawyerIdLabel.Visible = (row["Lawyer ID"] != DBNull.Value);

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.FileInvoice;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 32;

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                firmIdLabel.Location = new System.Drawing.Point(230, yOffset + 50);
                                lawyerIdLabel.Location = new System.Drawing.Point(230, yOffset + 50);
                                caseStatus.Location = new System.Drawing.Point(230, yOffset);


                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(firmIdLabel);
                                panel_lawyer_infoes.Controls.Add(lawyerIdLabel);
                                panel_lawyer_infoes.Controls.Add(caseStatus);


                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else if (Cmbo_Box_lawFirmType.Text == "pending case" || Cmbo_Box_lawFirmType.Text == "running case" || Cmbo_Box_lawFirmType.Text == "closed case")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Case Name], [Case ID], [Firm_ID], [Lawyer ID],[Case Status], [review_status],[paid_status] FROM [Case] WHERE [NID] = @ID AND [Case Status] = @Case_Status";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Case_Status", Cmbo_Box_lawFirmType.Text);
                        command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            int yOffset = 32;

                            Panel panel = new Panel();
                            panel.Size = new System.Drawing.Size(500, 2);
                            panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
                            panel.Location = new System.Drawing.Point(14, 0);

                            panel_lawyer_infoes.Controls.Add(panel);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                string paidStatus = row["paid_status"].ToString();
                                string reviewStatus = row["review_status"].ToString();

                                Label nameLabel = new Label();
                                nameLabel.Text = row["Case Name"].ToString() + "  Case";
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Case ID: " + row["Case ID"].ToString();
                                idLabel.AutoSize = true;

                                Label firmIdLabel = new Label();
                                firmIdLabel.Text = "The case was submitted to the Law Firm with ID: " + (row["Firm_ID"] == DBNull.Value ? "N/A" : row["Firm_ID"].ToString());
                                firmIdLabel.AutoSize = true;
                                firmIdLabel.Visible = (row["Firm_ID"] != DBNull.Value);

                                Label caseStatus = new Label();
                                caseStatus.Text = "Status : " + row["Case Status"].ToString();
                                caseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                caseStatus.AutoSize = true;

                                switch (row["Case Status"].ToString().ToLower())
                                {
                                    case "pending case":
                                        caseStatus.ForeColor = System.Drawing.Color.Red;
                                        break;
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        if (paidStatus == "not_paid")
                                        {
                                            Button pay = new Button();
                                            pay.Text = "Pay";
                                            pay.Tag = row["Case ID"];
                                            pay.Size = new System.Drawing.Size(130, 30);
                                            pay.Location = new System.Drawing.Point(390, yOffset);
                                            pay.Click += Pay_Clicked;
                                            panel_lawyer_infoes.Controls.Add(pay);
                                        }

                                        break;
                                    case "closed case":
                                        caseStatus.ForeColor = System.Drawing.Color.Yellow;
                                        if (reviewStatus == "not_reviewed")
                                        {
                                            Button review = new Button();
                                            review.Text = "Give Review";
                                            review.Tag = row["Case ID"];
                                            review.Size = new System.Drawing.Size(130, 30);
                                            review.Location = new System.Drawing.Point(390, yOffset);
                                            review.Click += Review_Clicked;
                                            panel_lawyer_infoes.Controls.Add(review);
                                        }
                                        break;
                                    default:

                                        break;

                                }

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.FileInvoice;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 32;

                                Label lawyerIdLabel = new Label();
                                lawyerIdLabel.Text = "The case was submitted to the Lawyer with ID: " + (row["Lawyer ID"] == DBNull.Value ? "N/A" : row["Lawyer ID"].ToString());
                                lawyerIdLabel.AutoSize = true;
                                lawyerIdLabel.Visible = (row["Lawyer ID"] != DBNull.Value);

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                firmIdLabel.Location = new System.Drawing.Point(230, yOffset + 50);
                                lawyerIdLabel.Location = new System.Drawing.Point(230, yOffset + 50);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                caseStatus.Location = new System.Drawing.Point(230, yOffset);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(firmIdLabel);
                                panel_lawyer_infoes.Controls.Add(lawyerIdLabel);
                                panel_lawyer_infoes.Controls.Add(caseStatus);

                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else
                {
                    Label caselbl = new Label();
                    caselbl.Text = "no cases available!!!!";
                    caselbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    caselbl.AutoSize = true;
                    caselbl.ForeColor = System.Drawing.Color.Green;
                    caselbl.Location = new System.Drawing.Point(80, 32);
                    panel_lawyer_infoes.Controls.Add(caselbl);
                }
            }
        }

        private void Pay_Clicked(object sender, EventArgs e)
        {
            int Case_ID = Convert.ToInt32(((Button)sender).Tag.ToString());

            int n = 1;

            Form_User_Payforcasecs form_User_Payforcasecs = new Form_User_Payforcasecs(this,ID, Case_ID,n);
            form_User_Payforcasecs.ShowDialog();
        }
        private void Review_Clicked(object sender, EventArgs e)
        {
            int Case_ID = Convert.ToInt32(((Button)sender).Tag.ToString());

            Form_User_Givereview form_User_Givereview = new Form_User_Givereview(ID,Case_ID);
            form_User_Givereview.ShowDialog();
        }

        
    }
}
