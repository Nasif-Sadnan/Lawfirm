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
    public partial class Form_Admin_Login : Form
    {
        public bool pass_see = false;
        public bool cursor_on_pass_Box = false;
        public bool cursor_on_Con_pass_Box = false;

        private const string conn = "Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=Core Rights;Integrated Security=True";

        public Point mouseLocation;
        public Form_Admin_Login()
        {
            InitializeComponent();
            Icn_Box_settings.IconChar = IconChar.Bars;
            TxT_Box_ID.Focus();
        }

        private void Icn_pic_Exit_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Icn_pic_minimize_Btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Icn_pic_Window_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Window format or extended format not available at this moment!!");
        }

        private void IcN_Btn_clear_Click(object sender, EventArgs e)
        {
            TxT_Box_ID.Text = "Enter your Admin ID";
            TxT_Box_ID.ForeColor = Color.Silver;


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

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_Login_Options f_Login_Options = new Form_Login_Options();
            this.Hide();
            f_Login_Options.ShowDialog();
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

        private void TxT_Box_ID_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_ID.Text == "Enter your Admin ID")
            {
                TxT_Box_ID.Text = "";

                TxT_Box_ID.ForeColor = Color.Black;
            }
        }

        private void TxT_Box_ID_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_ID.Text == "")
            {
                TxT_Box_ID.Text = "Enter your Admin ID";

                TxT_Box_ID.ForeColor = Color.Silver;
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

        private void LbL_Reg_option_Click(object sender, EventArgs e)
        {
            Form_Admin_Registration form_Admin_Registration = new Form_Admin_Registration();
            this.Hide();
            form_Admin_Registration.ShowDialog();
        }

        private void LbL_Reset_Pass_Click(object sender, EventArgs e)
        {
            if (TxT_Box_ID.Text == "Enter your Admin ID" || TxT_Box_ID.Text == "")
            {
                MessageBox.Show("Please enter your ID");
            }
            else
            {
                string userID = TxT_Box_ID.Text;

                if (CheckIfUserIDExists(userID))
                {
                    Form_User_SendMail_ForPassCHnage f_User_SendMail_ForPassCHnage = new Form_User_SendMail_ForPassCHnage(userID);
                    this.Hide();
                    f_User_SendMail_ForPassCHnage.ShowDialog();
                }
                else
                {
                    MessageBox.Show("The entered NID is not available, please enter a registered NID");
                }
            }
        }
        private bool CheckIfUserIDExists(string userID)
        {
            bool userIDExists = false;

            using (SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=""Core Rights"";Integrated Security=True"))
            {
                connection.Open();

                string query = $"SELECT COUNT(*) FROM [Admin] WHERE ID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    int count = (int)command.ExecuteScalar();
                    userIDExists = count > 0;
                }
            }

            return userIDExists;
        }

        private void Icn_BtN_Register_Click(object sender, EventArgs e)
        {
            string userID = TxT_Box_ID.Text;
            string password = TxT_Box_Password.Text;
            string confirmPassword = TxT_Box_Con_password.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }
            else
            {
                try
                {
                    string query = "SELECT * FROM [Admin] WHERE ID ='" + TxT_Box_ID.Text + "' AND Password='" + TxT_Box_Password.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        userID = TxT_Box_ID.Text;
                        password = TxT_Box_Password.Text;

                        Form_Home_Admin form_Home_Admin = new Form_Home_Admin(userID);

                        this.Hide();
                        form_Home_Admin.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(" Invalid details \n Reenter ID and Password", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Clone();
                }
            }
        }
    }
}
