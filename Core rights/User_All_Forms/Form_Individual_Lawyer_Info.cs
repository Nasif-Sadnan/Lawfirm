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
    public partial class Form_Individual_Lawyer_Info : Form
    {
        string ID;
        public Form_Individual_Lawyer_Info(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            LoadLawyerInfo();
        }
        private void LoadLawyerInfo()
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (Cmbo_Box_lawFirmType.Text == "Select Lawyer Type" || Cmbo_Box_lawFirmType.Text == "All")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Lawyer Name], [Lawyer ID ], [Rating] FROM [Individual Lawyer]";

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
                                nameLabel.Text = row["Lawyer Name"].ToString();
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Lawyer ID: " + row["Lawyer ID "].ToString();
                                idLabel.AutoSize = true;

                                Label rateLbL = new Label();
                                rateLbL.Text = "Rating : " + row["Rating"].ToString();
                                rateLbL.AutoSize = true;

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.UserTie;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 35;

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                Button btnAddCase = new Button();
                                btnAddCase.Text = "Add Case";
                                btnAddCase.Tag = row["Lawyer ID "];
                                btnAddCase.Click += BtnAddCase_Click;
                                btnAddCase.Size = new System.Drawing.Size(130, 30);

                                Button reviews = new Button();
                                reviews.Text = "Show reviews";
                                reviews.AutoSize = true;
                                reviews.Tag = row["Lawyer ID "];
                                reviews.Click += Reviews_Click;
                                reviews.Size = new System.Drawing.Size(130, 30);

                                Button btnTakeServices = new Button();
                                btnTakeServices.Text = "Take Services";
                                btnTakeServices.Tag = row["Lawyer ID "];
                                btnTakeServices.Click += BtnTakeServices_Click;
                                btnTakeServices.Size = new System.Drawing.Size(130, 30);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                btnAddCase.Location = new System.Drawing.Point(383, yOffset);
                                btnTakeServices.Location = new System.Drawing.Point(383, yOffset + 50);
                                rateLbL.Location = new System.Drawing.Point(304, yOffset);
                                reviews.Location = new System.Drawing.Point(250, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(btnAddCase);
                                panel_lawyer_infoes.Controls.Add(btnTakeServices);
                                panel_lawyer_infoes.Controls.Add(rateLbL);
                                panel_lawyer_infoes.Controls.Add(reviews);


                                yOffset += 143;
                            }
                        }
                    }
                }

                else if (Cmbo_Box_lawFirmType.Text == "Criminal" || Cmbo_Box_lawFirmType.Text == "Land" || Cmbo_Box_lawFirmType.Text == "Tax")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Lawyer Name], [Lawyer ID ], [Rating] FROM [Individual Lawyer] WHERE [Type of lawyer] = @FirmType";

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
                                nameLabel.Text = row["Lawyer Name"].ToString();
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Lawyer ID: " + row["Lawyer ID "].ToString();
                                idLabel.AutoSize = true;

                                Label rateLbL = new Label();
                                rateLbL.Text = "Rating : " + row["Rating"].ToString();
                                rateLbL.AutoSize = true;

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.UserTie;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 35;

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                Button btnAddCase = new Button();
                                btnAddCase.Text = "Add Case";
                                btnAddCase.Tag = row["Lawyer ID "];
                                btnAddCase.Click += BtnAddCase_Click;
                                btnAddCase.Size = new System.Drawing.Size(130, 30);

                                Button reviews = new Button();
                                reviews.Text = "Show reviews";
                                reviews.AutoSize = true;
                                reviews.Tag = row["Lawyer ID "];
                                reviews.Click += Reviews_Click;
                                reviews.Size = new System.Drawing.Size(130, 30);

                                Button btnTakeServices = new Button();
                                btnTakeServices.Text = "Take Services";
                                btnTakeServices.Tag = row["Lawyer ID "];
                                btnTakeServices.Click += BtnTakeServices_Click;
                                btnTakeServices.Size = new System.Drawing.Size(130, 30);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                btnAddCase.Location = new System.Drawing.Point(383, yOffset);
                                btnTakeServices.Location = new System.Drawing.Point(383, yOffset + 50);
                                rateLbL.Location = new System.Drawing.Point(304, yOffset); 
                                reviews.Location = new System.Drawing.Point(250, yOffset + 50);


                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(btnAddCase);
                                panel_lawyer_infoes.Controls.Add(btnTakeServices);
                                panel_lawyer_infoes.Controls.Add(rateLbL);
                                panel_lawyer_infoes.Controls.Add(reviews);


                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else
                {
                    Label caselbl = new Label();
                    caselbl.Text = "no lawyer available!!!!";
                    caselbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    caselbl.AutoSize = true;
                    caselbl.ForeColor = System.Drawing.Color.Green;
                    caselbl.Location = new System.Drawing.Point(80, 32);
                    panel_lawyer_infoes.Controls.Add(caselbl);
                }

            }
        }

        private void BtnAddCase_Click(object sender, EventArgs e)
        {
            string firmID = ((Button)sender).Tag.ToString();

            Form_User_Submitcase form_User_Submitcase = new Form_User_Submitcase(ID,firmID,this);
            form_User_Submitcase.ShowDialog();

        }

        private void BtnTakeServices_Click(object sender, EventArgs e)
        {
            string firmID = ((Button)sender).Tag.ToString();

            Form_User_ServiceList form_User_ServiceList = new Form_User_ServiceList(ID, firmID, this);
            form_User_ServiceList.ShowDialog();
        }

        private void Cmbo_Box_lawFirmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (Cmbo_Box_lawFirmType.Text == "Select Lawyer Type" || Cmbo_Box_lawFirmType.Text == "All")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Lawyer Name], [Lawyer ID ], [Rating] FROM [Individual Lawyer]";

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
                                nameLabel.Text = row["Lawyer Name"].ToString();
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Lawyer ID: " + row["Lawyer ID "].ToString();
                                idLabel.AutoSize = true;

                                Label rateLbL = new Label();
                                rateLbL.Text = "Rating : " + row["Rating"].ToString();
                                rateLbL.AutoSize = true;

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.UserTie;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 35;

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                Button btnAddCase = new Button();
                                btnAddCase.Text = "Add Case";
                                btnAddCase.Tag = row["Lawyer ID "];
                                btnAddCase.Click += BtnAddCase_Click;
                                btnAddCase.Size = new System.Drawing.Size(130, 30);

                                Button btnTakeServices = new Button();
                                btnTakeServices.Text = "Take Services";
                                btnTakeServices.Tag = row["Lawyer ID "];
                                btnTakeServices.Click += BtnTakeServices_Click;
                                btnTakeServices.Size = new System.Drawing.Size(130, 30);

                                Button reviews = new Button();
                                reviews.Text = "Show reviews";
                                reviews.AutoSize = true;
                                reviews.Tag = row["Lawyer ID "];
                                reviews.Click += Reviews_Click;
                                reviews.Size = new System.Drawing.Size(130, 30);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                btnAddCase.Location = new System.Drawing.Point(383, yOffset);
                                btnTakeServices.Location = new System.Drawing.Point(383, yOffset + 50);
                                rateLbL.Location = new System.Drawing.Point(304, yOffset);
                                reviews.Location = new System.Drawing.Point(250, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(btnAddCase);
                                panel_lawyer_infoes.Controls.Add(btnTakeServices);
                                panel_lawyer_infoes.Controls.Add(rateLbL);
                                panel_lawyer_infoes.Controls.Add(reviews);

                                yOffset += 143;
                            }
                        }
                    }
                }

                else if (Cmbo_Box_lawFirmType.Text == "Criminal" || Cmbo_Box_lawFirmType.Text == "Land" || Cmbo_Box_lawFirmType.Text == "Tax")
                {
                    panel_lawyer_infoes.Controls.Clear();

                    string query = "SELECT [Lawyer Name], [Lawyer ID ], [Rating] FROM [Individual Lawyer] WHERE [Type of lawyer] = @FirmType";

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
                                nameLabel.Text = row["Lawyer Name"].ToString();
                                nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                nameLabel.AutoSize = true;

                                Label idLabel = new Label();
                                idLabel.Text = "Lawyer ID: " + row["Lawyer ID "].ToString();
                                idLabel.AutoSize = true;

                                Label rateLbL = new Label();
                                rateLbL.Text = "Rating : " + row["Rating"].ToString();
                                rateLbL.AutoSize = true;

                                IconPictureBox pictureBox = new IconPictureBox();
                                pictureBox.IconChar = IconChar.UserTie;
                                pictureBox.IconColor = System.Drawing.Color.FromArgb(61, 61, 61);
                                pictureBox.IconSize = 35;

                                Panel panel1 = new Panel();
                                panel1.Size = new System.Drawing.Size(500, 2);
                                panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);

                                Button btnAddCase = new Button();
                                btnAddCase.Text = "Add Case";
                                btnAddCase.Tag = row["Lawyer ID "];
                                btnAddCase.Click += BtnAddCase_Click;
                                btnAddCase.Size = new System.Drawing.Size(130, 30);

                                Button reviews = new Button();
                                reviews.Text = "Show reviews";
                                reviews.AutoSize = true;
                                reviews.Tag = row["Lawyer ID "];
                                reviews.Click += Reviews_Click;
                                reviews.Size = new System.Drawing.Size(130, 30);

                                Button btnTakeServices = new Button();
                                btnTakeServices.Text = "Take Services";
                                btnTakeServices.Tag = row["Lawyer ID "];
                                btnTakeServices.Click += BtnTakeServices_Click;
                                btnTakeServices.Size = new System.Drawing.Size(130, 30);

                                nameLabel.Location = new System.Drawing.Point(59, yOffset);
                                idLabel.Location = new System.Drawing.Point(66, yOffset + 50);
                                pictureBox.Location = new System.Drawing.Point(18, yOffset + 11);
                                panel1.Location = new System.Drawing.Point(14, yOffset + 110);
                                btnAddCase.Location = new System.Drawing.Point(383, yOffset);
                                btnTakeServices.Location = new System.Drawing.Point(383, yOffset + 50);
                                rateLbL.Location = new System.Drawing.Point(304, yOffset);
                                reviews.Location = new System.Drawing.Point(250, yOffset + 50);

                                panel_lawyer_infoes.Controls.Add(nameLabel);
                                panel_lawyer_infoes.Controls.Add(idLabel);
                                panel_lawyer_infoes.Controls.Add(pictureBox);
                                panel_lawyer_infoes.Controls.Add(panel1);
                                panel_lawyer_infoes.Controls.Add(btnAddCase);
                                panel_lawyer_infoes.Controls.Add(btnTakeServices);
                                panel_lawyer_infoes.Controls.Add(rateLbL);
                                panel_lawyer_infoes.Controls.Add(reviews);


                                yOffset += 143;
                            }
                            this.ClientSize = new System.Drawing.Size(409, yOffset + 10);
                        }
                    }
                }
                else
                {
                    Label caselbl = new Label();
                    caselbl.Text = "no lawyer available!!!!";
                    caselbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    caselbl.AutoSize = true;
                    caselbl.ForeColor = System.Drawing.Color.Green;
                    caselbl.Location = new System.Drawing.Point(80, 32);
                    panel_lawyer_infoes.Controls.Add(caselbl);
                }

            }
        }

        private void Reviews_Click(object sender, EventArgs e)
        {
            string firmID = ((Button)sender).Tag.ToString();

            Form_User_See_Rivews form_User_See_Rivews = new Form_User_See_Rivews(firmID, this);
            form_User_See_Rivews.ShowDialog();

        }
    }
}
