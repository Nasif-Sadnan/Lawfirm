using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core_rights.Admin_All_Forms
{
    public partial class Form_LawFirm_Info : Form
    {
        Form back_Panel;
        public Form_LawFirm_Info(Form back_Panel)
        {
            this.back_Panel = back_Panel;
            InitializeComponent();
            LoadLawyerInfo();
        }
        private void LoadLawyerInfo()
        {
            panel_lawyer_infoes.Controls.Clear();
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            int yOffset = 27;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string firmQuery = "SELECT [Firm_Name], [Firm_ID],[Rating]  FROM [Law Firm]";
                using (SqlCommand firmCommand = new SqlCommand(firmQuery, connection))
                {
                    using (SqlDataAdapter firmAdapter = new SqlDataAdapter(firmCommand))
                    {
                        DataTable firmDataTable = new DataTable();
                        firmAdapter.Fill(firmDataTable);

                        Panel panel = new Panel();
                        panel.Size = new System.Drawing.Size(500, 2);
                        panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
                        panel.Location = new System.Drawing.Point(14, 0);

                        panel_lawyer_infoes.Controls.Add(panel);

                        foreach (DataRow row in firmDataTable.Rows)
                        {
                            DisplayLawyerInfo(row, yOffset);
                            yOffset += 143;
                        }
                    }
                }

                this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
            }
        }
        private void DisplayLawyerInfo(DataRow row, int yOffset)
        {
            Label nameLabel = new Label();
            nameLabel.Text = row["Firm_Name"].ToString();
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.AutoSize = true;

            Label idLabel = new Label();
            idLabel.Text = "Firm ID: " + row["Firm_ID"].ToString();
            idLabel.AutoSize = true;

            Label rateLbL = new Label();
            rateLbL.Text = "Rating : " + row["Rating"].ToString();
            rateLbL.AutoSize = true;

            IconPictureBox pictureBox = new IconPictureBox();
            pictureBox.IconChar = IconChar.ScaleBalanced;
            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            pictureBox.IconSize = 28;

            Panel panel1 = new Panel();
            panel1.Size = new System.Drawing.Size(500, 2);
            panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);


            nameLabel.Location = new System.Drawing.Point(59, yOffset);
            idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
            pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
            panel1.Location = new System.Drawing.Point(14, yOffset + 110);
            rateLbL.Location = new System.Drawing.Point(304, yOffset + 50);

            panel_lawyer_infoes.Controls.Add(nameLabel);
            panel_lawyer_infoes.Controls.Add(idLabel);
            panel_lawyer_infoes.Controls.Add(pictureBox);
            panel_lawyer_infoes.Controls.Add(panel1);
            panel_lawyer_infoes.Controls.Add(rateLbL);

        }

        private void Icn_BtN_Delete_Account_Click(object sender, EventArgs e)
        {
            panel_lawyer_infoes.Controls.Clear();
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            int yOffset = 27;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string firmQuery = "SELECT [Firm_Name], [Firm_ID] FROM [Law Firm]";

                using (SqlCommand firmCommand = new SqlCommand(firmQuery, connection))
                {
                    using (SqlDataAdapter firmAdapter = new SqlDataAdapter(firmCommand))
                    {
                        DataTable firmDataTable = new DataTable();
                        firmAdapter.Fill(firmDataTable);

                        Panel panel = new Panel();
                        panel.Size = new System.Drawing.Size(500, 2);
                        panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
                        panel.Location = new System.Drawing.Point(14, 0);

                        foreach (DataRow row in firmDataTable.Rows)
                        {

                            DisplayLawyerInfo2(row, yOffset);
                            yOffset += 143;
                        }
                    }
                }

            }
        }
        private void DisplayLawyerInfo2(DataRow row, int yOffset)
        {
            Label nameLabel = new Label();
            nameLabel.Text = row["Firm_Name"].ToString();
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.AutoSize = true;

            string FirmID = row["Firm_ID"].ToString();

            Label idLabel = new Label();
            idLabel.Text = "Law Firm ID : " + FirmID;
            idLabel.AutoSize = true;

            IconPictureBox pictureBox = new IconPictureBox();
            pictureBox.IconChar = IconChar.ScaleBalanced;
            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            pictureBox.IconSize = 35;

            IconPictureBox delete_Icon = new IconPictureBox();
            delete_Icon.IconChar = IconChar.Trash;
            delete_Icon.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            delete_Icon.IconSize = 35;
            delete_Icon.Click += (s, EventArgs) => DeleteLawyer(FirmID);

            Panel panel = new Panel();
            panel.Size = new System.Drawing.Size(450, 2);
            panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

            nameLabel.Location = new System.Drawing.Point(59, yOffset);
            idLabel.Location = new System.Drawing.Point(66, yOffset + 36);
            pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
            delete_Icon.Location = new System.Drawing.Point(440, yOffset + 11);
            panel.Location = new System.Drawing.Point(14, yOffset + 75);

            panel_lawyer_infoes.Controls.Add(nameLabel);
            panel_lawyer_infoes.Controls.Add(idLabel);
            panel_lawyer_infoes.Controls.Add(pictureBox);
            panel_lawyer_infoes.Controls.Add(delete_Icon);
            panel_lawyer_infoes.Controls.Add(panel);
        }
        private void DeleteLawyer(string firmID)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string deleteQuery2 = "DELETE FROM [Review] WHERE [Firm_ID] = @firmID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery2, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@firmID", firmID);
                        deleteCommand.ExecuteNonQuery();
                    }

                    string deleteQuery5 = "DELETE FROM [Payment] WHERE [Firm_ID] = @firmID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery5, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@firmID", firmID);
                        deleteCommand.ExecuteNonQuery();
                    }

                    string deleteQuery3 = "DELETE FROM [Case] WHERE [Firm_ID] = @firmID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery3, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@firmID", firmID);
                        deleteCommand.ExecuteNonQuery();
                    }

                    string deleteQuery4 = "DELETE FROM [Service] WHERE [Firm_ID] = @firmID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery4, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@firmID", firmID);
                        deleteCommand.ExecuteNonQuery();
                    }

                    string deleteQuery1 = "DELETE FROM [Lawyer Under Firm] WHERE [Firm ID] = @firmID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery1, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@firmID", firmID);
                        deleteCommand.ExecuteNonQuery();
                    }

                    string deleteQuery = "DELETE FROM [Law Firm] WHERE [Firm_ID] = @FirmID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@FirmID", firmID);

                        deleteCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("The law firm is deleted");
                    LoadLawyerInfo();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void Cmbo_Box_lawFirmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (Cmbo_Box_lawFirmType.Text == "Select Firm Type" || Cmbo_Box_lawFirmType.Text == "All")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Firm_Name], [Firm_ID],[Rating]  FROM [Law Firm]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

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
                                Label nameLabel = new Label();
                                nameLabel.Text = row["Firm_Name"].ToString();
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Firm ID: " + row["Firm_ID"].ToString();
                                idLabel.AutoSize = true;

                                Label rateLbL = new Label();
                                rateLbL.Text = "Rating : " + row["Rating"].ToString();
                                rateLbL.AutoSize = true;

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.ScaleBalanced;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 28;

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);


                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                rateLbL.Location = new System.Drawing.Point(304, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(rateLbL);

                                yOffset += 143;
                            }
                        }
                    }
                }

                else if (Cmbo_Box_lawFirmType.Text == "Criminal" || Cmbo_Box_lawFirmType.Text == "Land" || Cmbo_Box_lawFirmType.Text == "Tax")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Firm_Name], [Firm_ID], [Rating] FROM [Law Firm] WHERE [Firm_Type] = @FirmType";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirmType", Cmbo_Box_lawFirmType.Text);

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
                                Label nameLabel = new Label();
                                nameLabel.Text = row["Firm_Name"].ToString();
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Firm ID: " + row["Firm_ID"].ToString();
                                idLabel.AutoSize = true;

                                Label rateLbL = new Label();
                                rateLbL.Text = "Rating : " + row["Rating"].ToString();
                                rateLbL.AutoSize = true;

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.ScaleBalanced;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 28;

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);


                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                rateLbL.Location = new System.Drawing.Point(304, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(rateLbL);

                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else
                {

                }

            }
        }

        private void Icn_BtN_Add_Lawyer_Click(object sender, EventArgs e)
        {
            Form_LawFirm_Registration form_LawFirm_Registration = new Form_LawFirm_Registration(this);
            form_LawFirm_Registration.ShowDialog();
        }
    }
}
