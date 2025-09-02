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
    public partial class Form_LawyerUnderFirm_CaseInfo : Form
    {
        public string ID;
        public Form_LawyerUnderFirm_CaseInfo(String ID)
        {
            InitializeComponent();
            this.ID= ID;
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

                    string query = "SELECT [paid_status],[Case Name], [Case ID], [Judicial licence number],[Case Status],[paid_status],[review_status],[NID] FROM [Case] WHERE [Judicial licence number] = @ID ";
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
                                string paid_status = row["paid_status"].ToString();

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
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        if (paid_status == "paid")
                                        {
                                            Button close_case = new Button();
                                            close_case.Text = "close case";
                                            close_case.Tag = row["Case ID"];
                                            close_case.Size = new System.Drawing.Size(130, 30);
                                            close_case.Location = new System.Drawing.Point(390, yOffset);
                                            close_case.Click += Close_Clicked;
                                            panel_lawyer_infoes.Controls.Add(close_case);
                                        }
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
                else if (Cmbo_Box_lawFirmType.Text == "running case" || Cmbo_Box_lawFirmType.Text == "closed case")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [paid_status],[Case Name], [Case ID],[Judicial licence number], [Case Status],[paid_status],[NID] FROM [Case] WHERE [Judicial licence number] = @ID AND [Case Status] = @Case_Status";

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
                                string paid_status = row["paid_status"].ToString();

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
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        if (paid_status == "paid")
                                        {
                                            Button close_case = new Button();
                                            close_case.Text = "close case";
                                            close_case.Tag = row["Case ID"];
                                            close_case.Size = new System.Drawing.Size(130, 30);
                                            close_case.Location = new System.Drawing.Point(390, yOffset);
                                            close_case.Click += Close_Clicked;
                                            panel_lawyer_infoes.Controls.Add(close_case);
                                        }
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
        private void Close_Clicked(object sender, EventArgs e)
        {
            int Case_ID = Convert.ToInt32(((Button)sender).Tag.ToString());

            try
            {

                if (Case_ID > 0)
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
                    {
                        connection.Open();

                        string updateQuery = "UPDATE [Case] SET [Case Status] = 'closed case',[review_status]='not_reviewed' WHERE [Case ID] = @CaseID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@CaseID", Case_ID);

                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Closed");
                }
                else
                {
                    MessageBox.Show("Invalid Case ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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

                    string query = "SELECT [paid_status],[Case Name], [Case ID], [Judicial licence number],[Case Status],[paid_status],[review_status],[NID] FROM [Case] WHERE [Judicial licence number] = @ID ";
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
                                string paid_status = row["paid_status"].ToString();

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
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        if (paid_status == "paid")
                                        {
                                            Button close_case = new Button();
                                            close_case.Text = "close case";
                                            close_case.Tag = row["Case ID"];
                                            close_case.Size = new System.Drawing.Size(130, 30);
                                            close_case.Location = new System.Drawing.Point(390, yOffset);
                                            close_case.Click += Close_Clicked;
                                            panel_lawyer_infoes.Controls.Add(close_case);
                                        }
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
                else if (Cmbo_Box_lawFirmType.Text == "running case" || Cmbo_Box_lawFirmType.Text == "closed case")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [paid_status],[Case Name], [Case ID],[Judicial licence number], [Case Status],[paid_status],[NID] FROM [Case] WHERE [Judicial licence number] = @ID AND [Case Status] = @Case_Status";

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
                                string paid_status = row["paid_status"].ToString();

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
                                    case "running case":
                                        caseStatus.ForeColor = System.Drawing.Color.Blue;
                                        if (paid_status == "paid")
                                        {
                                            Button close_case = new Button();
                                            close_case.Text = "close case";
                                            close_case.Tag = row["Case ID"];
                                            close_case.Size = new System.Drawing.Size(130, 30);
                                            close_case.Location = new System.Drawing.Point(390, yOffset);
                                            close_case.Click += Close_Clicked;
                                            panel_lawyer_infoes.Controls.Add(close_case);
                                        }
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
