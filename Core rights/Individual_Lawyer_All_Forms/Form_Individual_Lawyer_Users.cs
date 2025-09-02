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

namespace Core_rights.Individual_Lawyer_All_Forms
{
    public partial class Form_Individual_Lawyer_Users : Form
    {
        string LawyerID;
        public Form_Individual_Lawyer_Users(string LawyerID)
        {
            InitializeComponent();
            this.LawyerID = LawyerID;
            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            panel_lawyer_infoes.Controls.Clear();
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Modify the query to join the [User] and [Individual Lawyer] tables
                string userQuery = "SELECT u.[Name], u.[NID] FROM [User] u JOIN [Individual Lawyer] il ON u.[NID] = il.[NID] WHERE il.[Lawyer ID] = @LawyerID";

                using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                {
                    userCommand.Parameters.AddWithValue("@LawyerID", LawyerID);

                    using (SqlDataAdapter userAdapter = new SqlDataAdapter(userCommand))
                    {
                        DataTable userDataTable = new DataTable();
                        userAdapter.Fill(userDataTable);

                        if (userDataTable.Rows.Count > 0)
                        {
                            DataRow row = userDataTable.Rows[0];
                            DisplayLawyerInfo(row);
                        }
                    }
                }
            }
        }

        private void DisplayLawyerInfo(DataRow row)
        {
            Label nameLabel = new Label();
            nameLabel.Text = "Name: " + row["Name"].ToString();
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.AutoSize = true;

            Label nidLabel = new Label();
            nidLabel.Text = "NID: " + row["NID"].ToString();
            nidLabel.AutoSize = true;

            IconPictureBox pictureBox = new IconPictureBox();
            pictureBox.IconChar = IconChar.UserTie;
            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            pictureBox.IconSize = 35;

            Panel panel = new Panel();
            panel.Size = new System.Drawing.Size(450, 2);
            panel.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

            nameLabel.Location = new System.Drawing.Point(59, 27);
            nidLabel.Location = new System.Drawing.Point(66, 63);
            pictureBox.Location = new System.Drawing.Point(18, 38);
            panel.Location = new System.Drawing.Point(14, 100);

            panel_lawyer_infoes.Controls.Add(nameLabel);
            panel_lawyer_infoes.Controls.Add(nidLabel);
            panel_lawyer_infoes.Controls.Add(pictureBox);
            panel_lawyer_infoes.Controls.Add(panel);
        }
    }
}
