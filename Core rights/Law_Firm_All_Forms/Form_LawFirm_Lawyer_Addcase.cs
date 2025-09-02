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
    public partial class Form_LawFirm_Lawyer_Addcase : Form
    {
        private string firmID;
        public int caseID;
        public Form_LawFirm_Lawyer_Addcase(string ID,int caseID)
        {
            InitializeComponent();
            this.firmID = ID;
            this.caseID = caseID;

            LbL_CaseID.Text= "Case ID : "+caseID;
            LoadLawyerInfo();
;       }
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

                            Button accept_case = new Button();
                            accept_case.Text = "Add lawyer";
                            accept_case.Tag = row["Judicial licence number "];
                            accept_case.Size = new System.Drawing.Size(130, 30);
                            accept_case.Location = new System.Drawing.Point(390, yOffset);
                            accept_case.Click += addLawyer;
                            panel_lawyer_infoes.Controls.Add(accept_case);

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
                    }
                }
            }
        }

        private void addLawyer(object sender, EventArgs e)
        {
            try
            {
                string lawyerID = ((Button)sender).Tag.ToString();

                if (caseID > 0)
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True"))
                    {
                        connection.Open();

                        string updateQuery = "UPDATE [Case] SET [Judicial licence number] = @LawyerID, [Case Status] = 'running case',[paid_status]='not_paid' WHERE [Case ID] = @CaseID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@LawyerID", lawyerID);
                            updateCommand.Parameters.AddWithValue("@CaseID", caseID);

                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Lawyer added to the case successfully.");
                    this.Hide();
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
        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
