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
    public partial class Form_User_See_Rivews : Form
    {
        int usernum = 0;
        string firmID;
        Form backform;
        string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        public Form_User_See_Rivews(string firmID,Form backform)
        {
            InitializeComponent();
            this.firmID = firmID;
            this.backform = backform;
            

            if (backform is Form_LawFirm_Infoes)
            {
                LoadLawfirmComment();
            }
            else
            {
                LoadLawYerComment();
            }
        }

        private void LoadLawfirmComment()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                connection.Open();

                string query= "SELECT [Rating], [Comment] FROM [Review] WHERE [Firm_ID] = @firmID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@firmID", firmID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            Label noRatingLabel = new Label();
                            noRatingLabel.Text = "No reviews available for this Law Firm.";
                            noRatingLabel.Font = new Font("Nikosh", 18, FontStyle.Bold);
                            noRatingLabel.AutoSize = true;
                            noRatingLabel.Location = new Point(19, 222);
                            PnL_Reviews.Controls.Add(noRatingLabel);
                        }

                        int yOffset = 30;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            usernum++;
                            Panel panelBack = new Panel();
                            panelBack.BackColor= Color.Transparent;
                            panelBack.BorderStyle = BorderStyle.FixedSingle;
                            panelBack.Size = new System.Drawing.Size(478, 101); ;
                            panelBack.Location = new System.Drawing.Point(23, yOffset);
                            PnL_Reviews.Controls.Add(panelBack);

                            IconPictureBox memberpic = new IconPictureBox();
                            memberpic.IconChar = IconChar.UserSecret;
                            memberpic.IconColor = System.Drawing.Color.FromArgb(51, 51, 51);
                            memberpic.IconSize = 55;
                            memberpic.Size = new System.Drawing.Size(55, 55);
                            memberpic.Location = new System.Drawing.Point(18,28);
                            panelBack.Controls.Add(memberpic);


                            Panel commentBox= new Panel();
                            commentBox.Size = new System.Drawing.Size(365, 67); ;
                            commentBox.BackColor = Color.BlanchedAlmond;
                            commentBox.Location = new System.Drawing.Point(89, 13);
                            panelBack.Controls.Add(commentBox);


                            Label nameLabel = new Label();
                            nameLabel.Text = "anonymous user "+usernum;
                            nameLabel.Font = new Font("Nikosh2", 12, FontStyle.Bold); 
                            nameLabel.AutoSize = true;
                            nameLabel.Location = new System.Drawing.Point(3, 2);
                            commentBox.Controls.Add(nameLabel);

                            Label rating = new Label();
                            rating.Text = "Rating : " + row["Rating"].ToString();
                            rating.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75f);
                            rating.AutoSize = true;
                            rating.Location = new System.Drawing.Point(290, 2);
                            commentBox.Controls.Add(rating);

                            Label comment = new Label();
                            comment.Text =  row["Comment"].ToString();
                            comment.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75f);
                            comment.AutoSize = true;
                            comment.Location = new System.Drawing.Point(5, 37);
                            commentBox.Controls.Add(comment);

                            yOffset += 130;
                        }
                    }
                }
            }
        }

        private void LoadLawYerComment()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT [Rating], [Comment] FROM [Review] WHERE [Lawyer ID ] = @firmID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@firmID", firmID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            Label noRatingLabel = new Label();
                            noRatingLabel.Text = "No reviews available for this Lawyer.";
                            noRatingLabel.Font = new Font("Nikosh", 18, FontStyle.Bold);
                            noRatingLabel.AutoSize = true;
                            noRatingLabel.Location = new Point(19, 222);
                            PnL_Reviews.Controls.Add(noRatingLabel);
                        }
                        int yOffset = 30;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            usernum++;
                            Panel panelBack = new Panel();
                            panelBack.BackColor = Color.Transparent;
                            panelBack.BorderStyle = BorderStyle.FixedSingle;
                            panelBack.Size = new System.Drawing.Size(478, 101); ;
                            panelBack.Location = new System.Drawing.Point(23, yOffset);
                            PnL_Reviews.Controls.Add(panelBack);

                            IconPictureBox memberpic = new IconPictureBox();
                            memberpic.IconChar = IconChar.UserSecret;
                            memberpic.IconColor = System.Drawing.Color.FromArgb(51, 51, 51);
                            memberpic.IconSize = 55;
                            memberpic.Size = new System.Drawing.Size(55, 55);
                            memberpic.Location = new System.Drawing.Point(18, 28);
                            panelBack.Controls.Add(memberpic);


                            Panel commentBox = new Panel();
                            commentBox.Size = new System.Drawing.Size(365, 67); ;
                            commentBox.BackColor = Color.BlanchedAlmond;
                            commentBox.Location = new System.Drawing.Point(89, 13);
                            panelBack.Controls.Add(commentBox);


                            Label nameLabel = new Label();
                            nameLabel.Text = "anonymous user " + usernum;
                            nameLabel.Font = new Font("Nikosh2", 12, FontStyle.Bold);
                            nameLabel.AutoSize = true;
                            nameLabel.Location = new System.Drawing.Point(3, 2);
                            commentBox.Controls.Add(nameLabel);

                            Label rating = new Label();
                            rating.Text = "Rating : " + row["Rating"].ToString();
                            rating.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75f);
                            rating.AutoSize = true;
                            rating.Location = new System.Drawing.Point(290, 2);
                            commentBox.Controls.Add(rating);

                            Label comment = new Label();
                            comment.Text = row["Comment"].ToString();
                            comment.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75f);
                            comment.AutoSize = true;
                            comment.Location = new System.Drawing.Point(5, 37);
                            commentBox.Controls.Add(comment);

                            yOffset += 130;
                        }
                    }
                }
            }
        }
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
