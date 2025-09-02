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
    public partial class Form_Lawyer_Infoes : Form
    {
        private string firmID;
        public Form_Lawyer_Infoes(string ID)
        {
            InitializeComponent();
            this.firmID = ID;
            LoadLawyerInfo();
        }
        private void LoadLawyerInfo()
        {
            panel_lawyer_infoes.Controls.Clear();
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=""Core Rights"";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT [Lawyer Name], [Judicial licence number ] FROM [Lawyer Under Firm] WHERE [Firm ID] = @FirmID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirmID", firmID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        int yOffset = 27;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            Label nameLabel = new Label();
                            nameLabel.Text = row["Lawyer Name"].ToString();
                            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            nameLabel.AutoSize = true;

                            Label idLabel = new Label();
                            idLabel.Text = "Judicial License Number: " + row["Judicial licence number "].ToString();
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

                            yOffset += 106;
                        }
                        this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                    }
                }
            }
        }

        private void Icn_BtN_Delete_Account_Click(object sender, EventArgs e)
        {
            panel_lawyer_infoes.Controls.Clear();
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=""Core Rights"";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT [Lawyer Name], [Judicial licence number ] FROM [Lawyer Under Firm] WHERE [Firm ID] = @FirmID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirmID", firmID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        int yOffset = 27;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            Label nameLabel = new Label();
                            nameLabel.Text = row["Lawyer Name"].ToString();
                            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            nameLabel.AutoSize = true;

                            Label idLabel = new Label();
                            idLabel.Text = "Judicial License Number: " + row["Judicial licence number "].ToString();
                            idLabel.AutoSize = true;

                            IconPictureBox pictureBox = new IconPictureBox();
                            pictureBox.IconChar = IconChar.UserTie;
                            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                            pictureBox.IconSize = 35;


                            string judicialLicenseNumber = row["Judicial licence number "].ToString(); 


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
                            panel_lawyer_infoes.Controls.Add(panel);
                            panel_lawyer_infoes.Controls.Add(delete_Icon);

                            yOffset += 106;
                        }
                        this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                    }
                }
            }
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

        private void Icn_BtN_Add_Lawyer_Click(object sender, EventArgs e)
        {
            Form_LawFIrm_Register_Lawyer form_LawFIrm_Register_Lawyer = new Form_LawFIrm_Register_Lawyer(this,firmID);
            form_LawFIrm_Register_Lawyer.Show();
        }
    }
}
