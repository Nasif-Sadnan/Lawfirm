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
    public partial class Form_All_LawyerInfo : Form
    {
        Form back_Panel;
        public Form_All_LawyerInfo(Form back_Panel)
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

                string firmQuery = "SELECT [Lawyer Name], [Judicial licence number] FROM [Lawyer Under Firm]";

                using (SqlCommand firmCommand = new SqlCommand(firmQuery, connection))
                {
                    using (SqlDataAdapter firmAdapter = new SqlDataAdapter(firmCommand))
                    {
                        DataTable firmDataTable = new DataTable();
                        firmAdapter.Fill(firmDataTable);

                        foreach (DataRow row in firmDataTable.Rows)
                        {
                            DisplayLawyerInfo(row, yOffset);
                            yOffset += 106;
                        }
                    }
                }

                string individualQuery = "SELECT [Lawyer Name], [Judicial licence number] FROM [Individual Lawyer]";

                using (SqlCommand individualCommand = new SqlCommand(individualQuery, connection))
                {
                    using (SqlDataAdapter individualAdapter = new SqlDataAdapter(individualCommand))
                    {
                        DataTable individualDataTable = new DataTable();
                        individualAdapter.Fill(individualDataTable);

                        foreach (DataRow row in individualDataTable.Rows)
                        {
                            DisplayLawyerInfo(row, yOffset);
                            yOffset += 106;
                        }
                    }
                }

                this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
            }
        }

        private void DisplayLawyerInfo(DataRow row, int yOffset)
        {
            Label nameLabel = new Label();
            nameLabel.Text = row["Lawyer Name"].ToString();
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.AutoSize = true;

            Label idLabel = new Label();
            idLabel.Text = "Judicial License Number: " + row["Judicial licence number"].ToString();
            idLabel.AutoSize = true;

            IconPictureBox pictureBox = new IconPictureBox();
            pictureBox.IconChar = IconChar.UserTie;
            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            pictureBox.IconSize = 35;

            Panel panel = new Panel();
            panel.Size = new System.Drawing.Size(450, 2);
            panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

            nameLabel.Location = new System.Drawing.Point(59, yOffset);
            idLabel.Location = new System.Drawing.Point(66, yOffset + 36);
            pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
            panel.Location = new System.Drawing.Point(14, yOffset + 75);

            panel_lawyer_infoes.Controls.Add(nameLabel);
            panel_lawyer_infoes.Controls.Add(idLabel);
            panel_lawyer_infoes.Controls.Add(pictureBox);
            panel_lawyer_infoes.Controls.Add(panel);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_lawyer_infoes.Controls.Clear();
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            int yOffset = 27;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if(CmboBox_LawyerType.Text== "Select Lawyer type" || CmboBox_LawyerType.Text == "All")
                {
                    LoadLawyerInfo();
                }
                else if(CmboBox_LawyerType.Text == "Lawyer Under Firm")
                {
                    string firmQuery = "SELECT [Lawyer Name], [Judicial licence number] FROM [Lawyer Under Firm]";

                    using (SqlCommand firmCommand = new SqlCommand(firmQuery, connection))
                    {
                        using (SqlDataAdapter firmAdapter = new SqlDataAdapter(firmCommand))
                        {
                            DataTable firmDataTable = new DataTable();
                            firmAdapter.Fill(firmDataTable);

                            foreach (DataRow row in firmDataTable.Rows)
                            {
                                DisplayLawyerInfo(row, yOffset);
                                yOffset += 106;
                            }
                        }
                    }
                }
                else if(CmboBox_LawyerType.Text == "Individual Lawyer")
                {
                    string individualQuery = "SELECT [Lawyer Name], [Judicial licence number] FROM [Individual Lawyer]";

                    using (SqlCommand individualCommand = new SqlCommand(individualQuery, connection))
                    {
                        using (SqlDataAdapter individualAdapter = new SqlDataAdapter(individualCommand))
                        {
                            DataTable individualDataTable = new DataTable();
                            individualAdapter.Fill(individualDataTable);

                            foreach (DataRow row in individualDataTable.Rows)
                            {
                                DisplayLawyerInfo(row, yOffset);
                                yOffset += 106;
                            }
                        }
                        
                    }
                }
                else
                {
                    CmboBox_LawyerType.Text = "Select Lawyer type";
                }
                this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
            }
        }

        private void Icn_BtN_Delete_Account_Click(object sender, EventArgs e)
        {
            panel_lawyer_infoes.Controls.Clear();
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            int yOffset = 27;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string firmQuery = "SELECT [Lawyer Name], [Judicial licence number] FROM [Lawyer Under Firm]";

                using (SqlCommand firmCommand = new SqlCommand(firmQuery, connection))
                {
                    using (SqlDataAdapter firmAdapter = new SqlDataAdapter(firmCommand))
                    {
                        DataTable firmDataTable = new DataTable();
                        firmAdapter.Fill(firmDataTable);

                        foreach (DataRow row in firmDataTable.Rows)
                        {
                            DisplayLawyerInfo2(row, yOffset);
                            yOffset += 106;
                        }
                    }
                }

                string individualQuery = "SELECT [Lawyer Name], [Judicial licence number] FROM [Individual Lawyer]";

                using (SqlCommand individualCommand = new SqlCommand(individualQuery, connection))
                {
                    using (SqlDataAdapter individualAdapter = new SqlDataAdapter(individualCommand))
                    {
                        DataTable individualDataTable = new DataTable();
                        individualAdapter.Fill(individualDataTable);

                        foreach (DataRow row in individualDataTable.Rows)
                        {
                            DisplayLawyerInfo3(row, yOffset);
                            yOffset += 106;
                        }
                    }
                }

                this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
            }
        }

        private void DisplayLawyerInfo2(DataRow row, int yOffset)
        {
            Label nameLabel = new Label();
            nameLabel.Text = row["Lawyer Name"].ToString();
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.AutoSize = true;

            string judicialLicenseNumber = row["Judicial licence number"].ToString();

            Label idLabel = new Label();
            idLabel.Text = "Judicial License Number: " + judicialLicenseNumber;
            idLabel.AutoSize = true;

            IconPictureBox pictureBox = new IconPictureBox();
            pictureBox.IconChar = IconChar.UserTie;
            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            pictureBox.IconSize = 35;

            IconPictureBox delete_Icon = new IconPictureBox();
            delete_Icon.IconChar = IconChar.Trash;
            delete_Icon.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            delete_Icon.IconSize = 35;
            delete_Icon.Click += (s, EventArgs) => DeleteLawyer(judicialLicenseNumber);

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
        private void DeleteLawyer(string judicialLicenseNumber)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM [Lawyer Under Firm] WHERE [Judicial licence number ] = @JudicialLicenseNumber";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@JudicialLicenseNumber", judicialLicenseNumber);
                    deleteCommand.ExecuteNonQuery();
                }

                MessageBox.Show("The lawyer is deleted from the law firm");
                LoadLawyerInfo();
            }
        }
        private void DisplayLawyerInfo3(DataRow row, int yOffset)
        {
            Label nameLabel = new Label();
            nameLabel.Text = row["Lawyer Name"].ToString();
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.AutoSize = true;

            string judicialLicenseNumber = row["Judicial licence number"].ToString();

            Label idLabel = new Label();
            idLabel.Text = "Judicial License Number: " + judicialLicenseNumber;
            idLabel.AutoSize = true;

            IconPictureBox pictureBox = new IconPictureBox();
            pictureBox.IconChar = IconChar.UserTie;
            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            pictureBox.IconSize = 35;

            IconPictureBox delete_Icon = new IconPictureBox();
            delete_Icon.IconChar = IconChar.Trash;
            delete_Icon.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            delete_Icon.IconSize = 35;
            delete_Icon.Click += (s, EventArgs) => DeleteLawyer2(judicialLicenseNumber);

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
        private void DeleteLawyer2(string judicialLicenseNumber)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM [Individual Lawyer] WHERE [Lawyer ID  ] = @JudicialLicenseNumber";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@JudicialLicenseNumber", judicialLicenseNumber);
                    deleteCommand.ExecuteNonQuery();
                }

                MessageBox.Show("The lawyer is deleted from the law firm");
                LoadLawyerInfo();
            }
        }

        private void Icn_BtN_Add_Lawyer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can only register for Individual Lawyers!!");
            Form_Individual_Lawyer_registration form_Individual_Lawyer_Registration = new Form_Individual_Lawyer_registration(back_Panel);
            form_Individual_Lawyer_Registration.ShowDialog();
        }
    }
}
