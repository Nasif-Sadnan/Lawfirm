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

namespace Core_rights
{
    public partial class Form_LawFirm_Change_Password : Form
    {
        public bool pass_see = false;
        public bool cursor_on_pass_Box = false;
        public bool cursor_on_Con_pass_Box = false;

        public Point mouseLocation;
        string Firm_ID;
        public Form_LawFirm_Change_Password(String Firm_ID)
        {
            InitializeComponent();
            this.Firm_ID = Firm_ID;
            Icn_Box_settings.IconChar = IconChar.Bars;
            LbL_ID.Text = "NID no : " + Firm_ID;
        }

        private void Icn_PicBox_Eye_Click(object sender, EventArgs e)
        {
            if (pass_see == false && cursor_on_pass_Box == false && cursor_on_Con_pass_Box == false)
            {
                TxT_Box_Password.UseSystemPasswordChar = false;
                TxT_Box_Con_password.UseSystemPasswordChar = false;
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
            else if (pass_see == false && cursor_on_pass_Box == true && cursor_on_Con_pass_Box == true)
            {
                TxT_Box_Password.UseSystemPasswordChar = false;
                TxT_Box_Con_password.UseSystemPasswordChar = false;
                Icn_PicBox_Eye.IconChar = IconChar.EyeSlash;
                LbL_pass_see.Text = "Hide password";
                pass_see = true;
            }
            else if (pass_see == true)
            {
                TxT_Box_Password.UseSystemPasswordChar = true;
                TxT_Box_Con_password.UseSystemPasswordChar = true;
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
        }

        private void LbL_pass_see_Click(object sender, EventArgs e)
        {
            if (pass_see == false && cursor_on_pass_Box == false && cursor_on_Con_pass_Box == false)
            {
                TxT_Box_Password.UseSystemPasswordChar = false;
                TxT_Box_Con_password.UseSystemPasswordChar = false;
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
            else if (pass_see == false && cursor_on_pass_Box == true && cursor_on_Con_pass_Box == true)
            {
                TxT_Box_Password.UseSystemPasswordChar = false;
                TxT_Box_Con_password.UseSystemPasswordChar = false;
                Icn_PicBox_Eye.IconChar = IconChar.EyeSlash;
                LbL_pass_see.Text = "Hide password";
                pass_see = true;
            }
            else if (pass_see == true)
            {
                TxT_Box_Password.UseSystemPasswordChar = true;
                TxT_Box_Con_password.UseSystemPasswordChar = true;
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
        }

        private void Icn_pic_Exit_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Icn_pic_Window_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Window format or extended format not available at this moment!!");
        }

        private void Icn_pic_minimize_Btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PnL_chng_Pos_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void PnL_chng_Pos_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void TxT_Box_Password_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_Password.Text == "Enter your Password")
            {
                TxT_Box_Password.Text = "";

                TxT_Box_Password.UseSystemPasswordChar = true;
                TxT_Box_Password.ForeColor = Color.Black;
                cursor_on_pass_Box = true;
            }
        }

        private void TxT_Box_Password_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_Password.Text == "")
            {
                TxT_Box_Password.Text = "Enter your Password";

                TxT_Box_Password.UseSystemPasswordChar = false;
                TxT_Box_Password.ForeColor = Color.Silver;
                cursor_on_pass_Box = false;
            }
        }

        private void TxT_Box_Con_password_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_Con_password.Text == "Rewrite your Password")
            {
                TxT_Box_Con_password.Text = "";

                TxT_Box_Con_password.UseSystemPasswordChar = true;
                TxT_Box_Con_password.ForeColor = Color.Black;
                cursor_on_Con_pass_Box = true;
            }
        }

        private void TxT_Box_Con_password_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_Con_password.Text == "")
            {
                TxT_Box_Con_password.Text = "Rewrite your Password";

                TxT_Box_Con_password.UseSystemPasswordChar = false;
                TxT_Box_Con_password.ForeColor = Color.Silver;
                cursor_on_Con_pass_Box = false;
            }
        }

        private void IcN_Btn_clear_Click(object sender, EventArgs e)
        {
            TxT_Box_Password.Text = "Enter your Password";
            TxT_Box_Password.UseSystemPasswordChar = false;
            TxT_Box_Password.ForeColor = Color.Silver;


            TxT_Box_Con_password.Text = "Rewrite your Password";
            TxT_Box_Con_password.UseSystemPasswordChar = false;
            TxT_Box_Con_password.ForeColor = Color.Silver;

            if (pass_see == true)
            {
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_LawFirm_SendMail_ForPassCHnage form_LawFirm_SendMail_ForPassCHnage = new Form_LawFirm_SendMail_ForPassCHnage(Firm_ID);
            this.Hide();
            form_LawFirm_SendMail_ForPassCHnage.Show();
        }

        private void LbL_Go_To_LogIN_Menu_Click(object sender, EventArgs e)
        {
            Form_lawfirm_Login form_Lawfirm_Login = new Form_lawfirm_Login();
            this.Hide();
            form_Lawfirm_Login.Show();
        }

        private void Icn_BtN_Update_Password_Click(object sender, EventArgs e)
        {
            if (TxT_Box_Password.Text == "" || TxT_Box_Con_password.Text == "" || TxT_Box_Password.Text == "Enter your Password" || TxT_Box_Con_password.Text == "Rewrite your Password")
            {
                MessageBox.Show("Please write the new password and also rewrite it correctly");
            }
            else
            {
                string previousPassword = GetPreviousPasswordFromDatabase(Firm_ID); 

                if (TxT_Box_Password.Text == previousPassword)
                {
                    MessageBox.Show("Please enter a new password. It should be different from the previous one.");
                }
                else if (TxT_Box_Password.Text != TxT_Box_Con_password.Text)
                {
                    MessageBox.Show("Password and Confirm Password do not match. Please rewrite the password correctly.");
                }
                else
                {
                    UpdatePasswordInDatabase(Firm_ID, TxT_Box_Password.Text); 

                    MessageBox.Show("Password updated successfully.");

                    TxT_Box_Password.Text = "Enter your Password";
                    TxT_Box_Password.UseSystemPasswordChar = false;
                    TxT_Box_Password.ForeColor = Color.Silver;


                    TxT_Box_Con_password.Text = "Rewrite your Password";
                    TxT_Box_Con_password.UseSystemPasswordChar = false;
                    TxT_Box_Con_password.ForeColor = Color.Silver;

                    if (pass_see == true)
                    {
                        Icn_PicBox_Eye.IconChar = IconChar.Eye;
                        LbL_pass_see.Text = "Show password";
                        pass_see = false;
                    }
                }
            }
        }
        private string GetPreviousPasswordFromDatabase(string firmID)
        {
            string previousPassword = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=""Core Rights"";Integrated Security=True"))
                {
                    connection.Open();

                    string query = "SELECT Password FROM [Law Firm] WHERE Firm_ID = @Firm_ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Firm_ID", firmID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                previousPassword = reader["Password"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving previous password: " + ex.Message);
            }

            return previousPassword;
        }

        private void UpdatePasswordInDatabase(string firmID, string newPassword)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=""Core Rights"";Integrated Security=True"))
                {
                    connection.Open();

                    string query = "UPDATE [Law Firm] SET Password = @NewPassword WHERE Firm_ID = @Firm_ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@Firm_ID", firmID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message);
            }
        }

    }
}
