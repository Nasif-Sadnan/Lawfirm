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

namespace Core_rights.Law_Firm_All_Forms
{
    public partial class Form_LawFirm_caseInfo : Form
    {
        public string ID;
        public Form_LawFirm_caseInfo(String ID)
        {
            InitializeComponent();
            this.ID = ID;
            LoadCaseINFO(ID);
        }
        private void LoadCaseINFO(string ID)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (Cmbo_Box_lawFirmType.Text == "Select Case Type" || Cmbo_Box_lawFirmType.Text == "All")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Case Name], [Case ID], [Firm_ID],[Case Status],[paid_status],[review_status],[NID] FROM [Case] WHERE [Firm_ID] = @ID ";
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
                                string casestatus = row["Case Status"].ToString();

                                Label nameLabel = new Label();
                                nameLabel.Text = row["Case Name"].ToString() + "  Case";
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label caseStatus = new Label();
                                caseStatus.Text = "Status : " + row["Case Status"].ToString();
                                caseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                Label userLbL = new Label();
                                userLbL.Text = "The case was submitted by User with ID: " + row["NID"].ToString();
                                userLbL.AutoSize = true;

                                caseStatus.AutoSize = true;

                                switch (row["Case Status"].ToString().ToLower())
                                {
                                    case "pending case":
                                        caseStatus.ForeColor = System.Drawing.Color.Red;


                                        Button accept_case = new Button();
                                        accept_case.Text = "Accept";
                                        accept_case.Tag = row["Case ID"];
                                        accept_case.Size = new System.Drawing.Size(130, 30);
                                        accept_case.Location = new System.Drawing.Point(390, yOffset);
                                        accept_case.Click += Accept_Clicked;
                                        panel_lawyer_infoes.Controls.Add(accept_case);

                                        Button reject_Case = new Button();
                                        reject_Case.Text = "Reject";
                                        reject_Case.Tag = row["Case ID"];
                                        reject_Case.Size = new System.Drawing.Size(130, 30);
                                        reject_Case.Location = new System.Drawing.Point(390, yOffset+50);
                                        reject_Case.Click += reject_Clicked;
                                        panel_lawyer_infoes.Controls.Add(reject_Case);

                                        break;
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        break;
                                    case "closed case":
                                        caseStatus.ForeColor = System.Drawing.Color.Yellow;
                                        break;
                                    default:

                                        break;

                                }

                                Label idLabel = new Label();
                                idLabel.Text = "Case ID: " + row["Case ID"].ToString();
                                idLabel.AutoSize = true;

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
                                caseStatus.Location = new System.Drawing.Point(230, yOffset);
                                userLbL.Location = new System.Drawing.Point(150, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(caseStatus);
                                panel_lawyer_infoes.Controls.Add(userLbL);


                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else if (Cmbo_Box_lawFirmType.Text == "pending case" || Cmbo_Box_lawFirmType.Text == "running case" || Cmbo_Box_lawFirmType.Text == "closed case")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Case Name], [Case ID], [Firm_ID], [Case Status],[paid_status],[NID] FROM [Case] WHERE WHERE [Firm_ID] = @ID AND [Case Status] = @Case_Status";

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
                                string casestatus = row["Case Status"].ToString();

                                Label nameLabel = new Label();
                                nameLabel.Text = row["Case Name"].ToString() + "  Case";
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Case ID: " + row["Case ID"].ToString();
                                idLabel.AutoSize = true;

                                Label userLbL = new Label();
                                userLbL.Text = "The case was submitted by User with ID: " + row["NID"].ToString();
                                userLbL.AutoSize = true;

                                Label caseStatus = new Label();
                                caseStatus.Text = "Status : " + row["Case Status"].ToString();
                                caseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                caseStatus.AutoSize = true;

                                switch (row["Case Status"].ToString().ToLower())
                                {
                                    case "pending case":
                                        caseStatus.ForeColor = System.Drawing.Color.Red;


                                        Button accept_case = new Button();
                                        accept_case.Text = "Accept";
                                        accept_case.Tag = row["Case ID"];
                                        accept_case.Size = new System.Drawing.Size(130, 30);
                                        accept_case.Location = new System.Drawing.Point(390, yOffset);
                                        accept_case.Click += Accept_Clicked;
                                        panel_lawyer_infoes.Controls.Add(accept_case);

                                        Button reject_Case = new Button();
                                        reject_Case.Text = "Reject";
                                        reject_Case.Tag = row["Case ID"];
                                        reject_Case.Size = new System.Drawing.Size(130, 30);
                                        reject_Case.Location = new System.Drawing.Point(390, yOffset + 50);
                                        reject_Case.Click += reject_Clicked;
                                        panel_lawyer_infoes.Controls.Add(reject_Case);

                                        break;
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        break;
                                    case "closed case":
                                        caseStatus.ForeColor = System.Drawing.Color.Yellow;
                                        break;
                                    default:

                                        break;

                                }

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.FileInvoice;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 32;


                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                caseStatus.Location = new System.Drawing.Point(230, yOffset);
                                userLbL.Location = new System.Drawing.Point(150, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(caseStatus);
                                panel_lawyer_infoes.Controls.Add(userLbL);

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

        private void Accept_Clicked(object sender, EventArgs e)
        {
            int Case_ID = Convert.ToInt32(((Button)sender).Tag.ToString());

            Form_LawFirm_Lawyer_Addcase form_LawFirm_Lawyer_Addcase = new Form_LawFirm_Lawyer_Addcase(ID,Case_ID);
            this.Hide();
            form_LawFirm_Lawyer_Addcase.ShowDialog();
        }
        private void reject_Clicked(object sender, EventArgs e)
        {
            int Case_ID = Convert.ToInt32(((Button)sender).Tag.ToString());

            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM [dbo].[Case] WHERE [Case ID] = @CaseID";
                
                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@CaseID", Case_ID);
                    MessageBox.Show("2nd");
                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("3rd");
                    MessageBox.Show("The case was rejected");
                }
                connection.Close();
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

                    string query = "SELECT [Case Name], [Case ID], [Firm_ID],[Case Status],[paid_status],[review_status],[NID] FROM [Case] WHERE [Firm_ID] = @ID ";
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
                                string casestatus = row["Case Status"].ToString();

                                Label nameLabel = new Label();
                                nameLabel.Text = row["Case Name"].ToString() + "  Case";
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label caseStatus = new Label();
                                caseStatus.Text = "Status : " + row["Case Status"].ToString();
                                caseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                                Label userLbL = new Label();
                                userLbL.Text = "The case was submitted by User with ID: " + row["NID"].ToString();
                                userLbL.AutoSize = true;

                                caseStatus.AutoSize = true;

                                switch (row["Case Status"].ToString().ToLower())
                                {
                                    case "pending case":
                                        caseStatus.ForeColor = System.Drawing.Color.Red;


                                        Button accept_case = new Button();
                                        accept_case.Text = "Accept";
                                        accept_case.Tag = row["Case ID"];
                                        accept_case.Size = new System.Drawing.Size(130, 30);
                                        accept_case.Location = new System.Drawing.Point(390, yOffset);
                                        accept_case.Click += Accept_Clicked;
                                        panel_lawyer_infoes.Controls.Add(accept_case);

                                        Button reject_Case = new Button();
                                        reject_Case.Text = "Reject";
                                        reject_Case.Tag = row["Case ID"];
                                        reject_Case.Size = new System.Drawing.Size(130, 30);
                                        reject_Case.Location = new System.Drawing.Point(390, yOffset + 50);
                                        reject_Case.Click += reject_Clicked;
                                        panel_lawyer_infoes.Controls.Add(reject_Case);

                                        break;
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        break;
                                    case "closed case":
                                        caseStatus.ForeColor = System.Drawing.Color.Yellow;
                                        break;
                                    default:

                                        break;

                                }

                                Label idLabel = new Label();
                                idLabel.Text = "Case ID: " + row["Case ID"].ToString();
                                idLabel.AutoSize = true;

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
                                caseStatus.Location = new System.Drawing.Point(230, yOffset);
                                userLbL.Location = new System.Drawing.Point(150, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(caseStatus);
                                panel_lawyer_infoes.Controls.Add(userLbL);


                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else if (Cmbo_Box_lawFirmType.Text == "pending case" || Cmbo_Box_lawFirmType.Text == "running case" || Cmbo_Box_lawFirmType.Text == "closed case")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Case Name], [Case ID], [Firm_ID], [Case Status],[paid_status],[NID] FROM [Case] WHERE [Firm_ID] = @ID AND [Case Status] = @Case_Status";

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
                                string casestatus = row["Case Status"].ToString();

                                Label nameLabel = new Label();
                                nameLabel.Text = row["Case Name"].ToString() + "  Case";
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Case ID: " + row["Case ID"].ToString();
                                idLabel.AutoSize = true;

                                Label userLbL = new Label();
                                userLbL.Text = "The case was submitted by User with ID: " + row["NID"].ToString();
                                userLbL.AutoSize = true;

                                Label caseStatus = new Label();
                                caseStatus.Text = "Status : " + row["Case Status"].ToString();
                                caseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                caseStatus.AutoSize = true;

                                switch (row["Case Status"].ToString().ToLower())
                                {
                                    case "pending case":
                                        caseStatus.ForeColor = System.Drawing.Color.Red;


                                        Button accept_case = new Button();
                                        accept_case.Text = "Accept";
                                        accept_case.Tag = row["Case ID"];
                                        accept_case.Size = new System.Drawing.Size(130, 30);
                                        accept_case.Location = new System.Drawing.Point(390, yOffset);
                                        accept_case.Click += Accept_Clicked;
                                        panel_lawyer_infoes.Controls.Add(accept_case);

                                        Button reject_Case = new Button();
                                        reject_Case.Text = "Reject";
                                        reject_Case.Tag = row["Case ID"];
                                        reject_Case.Size = new System.Drawing.Size(130, 30);
                                        reject_Case.Location = new System.Drawing.Point(390, yOffset + 50);
                                        reject_Case.Click += reject_Clicked;
                                        panel_lawyer_infoes.Controls.Add(reject_Case);

                                        break;
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        break;
                                    case "closed case":
                                        caseStatus.ForeColor = System.Drawing.Color.Yellow;
                                        break;
                                    default:

                                        break;

                                }

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.FileInvoice;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 32;


                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                caseStatus.Location = new System.Drawing.Point(230, yOffset);
                                userLbL.Location = new System.Drawing.Point(150, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(caseStatus);
                                panel_lawyer_infoes.Controls.Add(userLbL);

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
    }
}
