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
    public partial class Form_Admin_allUserInfo : Form
    {
        Form back_Panel;
        public Form_Admin_allUserInfo(Form back_Panel)
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

                string firmQuery = "SELECT [Name], [NID] FROM [User]";

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


                this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
            }
        }

        private void DisplayLawyerInfo(DataRow row, int yOffset)
        {
            Label nameLabel = new Label();
            nameLabel.Text = row["Name"].ToString();
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.AutoSize = true;

            Label idLabel = new Label();
            idLabel.Text = "NID : " + row["NID"].ToString();
            idLabel.AutoSize = true;

            IconPictureBox pictureBox = new IconPictureBox();
            pictureBox.IconChar = IconChar.User;
            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            pictureBox.IconFont = IconFont.Solid;
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

        private void Icn_BtN_Delete_Account_Click(object sender, EventArgs e)
        {
            panel_lawyer_infoes.Controls.Clear();
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            int yOffset = 27;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string firmQuery = "SELECT [Name], [NID] FROM [User]";

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


                this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
            }
        }
        private void DisplayLawyerInfo2(DataRow row, int yOffset)
        {
            Label nameLabel = new Label();
            nameLabel.Text = row["Name"].ToString();
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.AutoSize = true;

            string NID = row["NID"].ToString();

            Label idLabel = new Label();
            idLabel.Text = "Judicial License Number: " + NID;
            idLabel.AutoSize = true;

            IconPictureBox pictureBox = new IconPictureBox();
            pictureBox.IconChar = IconChar.User;
            pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            pictureBox.IconFont = IconFont.Solid;
            pictureBox.IconSize = 35;

            IconPictureBox delete_Icon = new IconPictureBox();
            delete_Icon.IconChar = IconChar.Trash;
            delete_Icon.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
            delete_Icon.IconSize = 35;
            delete_Icon.Click += (s, EventArgs) => DeleteLawyer(NID);

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
        private void DeleteLawyer(string NID)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM [User] WHERE [NID] = @NID";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@NID", NID);
                    deleteCommand.ExecuteNonQuery();
                }

                MessageBox.Show("The User is");
                LoadLawyerInfo();
            }
        }

        private void Icn_BtN_Add_Lawyer_Click(object sender, EventArgs e)
        {
            Form_User_Registration form_User_Registration = new Form_User_Registration(this);
            form_User_Registration.Show();
        }
    }
}
