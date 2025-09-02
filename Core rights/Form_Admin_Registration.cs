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
    public partial class Form_Admin_Registration : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=""Core Rights"";Integrated Security=True");

        public Point mouseLocation;
        public bool cursor_on_pass_Box = false;
        public bool pass_see = false;
        public Form_Admin_Registration()
        {
            InitializeComponent();
            Icn_Box_settings.IconChar = IconChar.Bars;
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

        private void TxT_Box_Name_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_Name.Text == "Enter your name")
            {
                TxT_Box_Name.Text = "";
                TxT_Box_Name.ForeColor = Color.Black;
            }
        }

        private void TxT_Box_Name_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_Name.Text == "")
            {
                TxT_Box_Name.Text = "Enter your name";
                TxT_Box_Name.ForeColor = Color.Silver;
            }
        }

        private void TxT_Box_Gmail_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_Gmail.Text == "Enter your Gmail")
            {
                TxT_Box_Gmail.Text = "";
                TxT_Box_Gmail.ForeColor = Color.Black;
            }
        }

        private void TxT_Box_Gmail_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_Gmail.Text == "")
            {
                TxT_Box_Gmail.Text = "Enter your Gmail";
                TxT_Box_Gmail.ForeColor = Color.Silver;
            }
        }

        private void TxT_Box_NID_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_NID.Text == "Enter your ID no")
            {
                TxT_Box_NID.Text = "";
                TxT_Box_NID.ForeColor = Color.Black;
            }
        }

        private void TxT_Box_NID_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_NID.Text == "")
            {
                TxT_Box_NID.Text = "Enter your ID no";
                TxT_Box_NID.ForeColor = Color.Silver;
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

        private void Icn_PicBox_Eye_Click(object sender, EventArgs e)
        {
            if (pass_see == false && cursor_on_pass_Box == false)
            {
                TxT_Box_Password.UseSystemPasswordChar = false;
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
            else if (pass_see == false && cursor_on_pass_Box == true)
            {
                TxT_Box_Password.UseSystemPasswordChar = false;
                Icn_PicBox_Eye.IconChar = IconChar.EyeSlash;
                LbL_pass_see.Text = "Hide password";
                pass_see = true;
            }
            else if (pass_see == true)
            {
                TxT_Box_Password.UseSystemPasswordChar = true;
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
        }

        private void LbL_pass_see_Click(object sender, EventArgs e)
        {
            if (pass_see == false && cursor_on_pass_Box == false)
            {
                TxT_Box_Password.UseSystemPasswordChar = false;
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
            else if (pass_see == false && cursor_on_pass_Box == true)
            {
                TxT_Box_Password.UseSystemPasswordChar = false;
                Icn_PicBox_Eye.IconChar = IconChar.EyeSlash;
                LbL_pass_see.Text = "Hide password";
                pass_see = true;
            }
            else if (pass_see == true)
            {
                TxT_Box_Password.UseSystemPasswordChar = true;
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
        }

        private void IcN_Btn_clear_Click(object sender, EventArgs e)
        {
            TxT_Box_NID.Text = "Enter your ID no";
            TxT_Box_NID.ForeColor = Color.Silver;

            TxT_Box_Gmail.Text = "Enter your Gmail";
            TxT_Box_Gmail.ForeColor = Color.Silver;

            TxT_Box_Name.Text = "Enter your name";
            TxT_Box_Name.ForeColor = Color.Silver;

            TxT_Box_Password.Text = "Enter your Password";
            TxT_Box_Password.UseSystemPasswordChar = false;
            TxT_Box_Password.ForeColor = Color.Silver;

            if (pass_see == true)
            {
                Icn_PicBox_Eye.IconChar = IconChar.Eye;
                LbL_pass_see.Text = "Show password";
                pass_see = false;
            }
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_Admin_Login form_Admin_Login = new Form_Admin_Login();
            this.Hide();
            form_Admin_Login.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form_Admin_Login form_Admin_Login = new Form_Admin_Login();
            this.Hide();
            form_Admin_Login.ShowDialog();
        }

        private void Icn_BtN_Register_Click(object sender, EventArgs e)
        {
            if (TxT_Box_Name.Text == "" || TxT_Box_Gmail.Text == "" ||  TxT_Box_NID.Text == "" || TxT_Box_Password.Text == "" || TxT_Box_Name.Text == "Enter your name" || TxT_Box_Gmail.Text == "Enter your Gmail"  || TxT_Box_NID.Text == "Enter your ID no" || TxT_Box_Password.Text == "Enter your Password")
            {
                MessageBox.Show(" Please enter all the datas");
            }
            else
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Admin]
                    ([ID],
                     [Name],
                     [Gmail],
                     [Password])
                    VALUES      
                    ('" + TxT_Box_NID.Text + "','" + TxT_Box_Name.Text + "','" + TxT_Box_Gmail.Text + "','" + TxT_Box_Password.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registered Succesfully");


                TxT_Box_NID.Text = "Enter your ID no";
                TxT_Box_NID.ForeColor = Color.Silver;

                TxT_Box_Gmail.Text = "Enter your Gmail";
                TxT_Box_Gmail.ForeColor = Color.Silver;

                TxT_Box_Name.Text = "Enter your name";
                TxT_Box_Name.ForeColor = Color.Silver;


                TxT_Box_Password.Text = "Enter your Password";
                TxT_Box_Password.UseSystemPasswordChar = false;
                TxT_Box_Password.ForeColor = Color.Silver;

                if (pass_see == true)
                {
                    Icn_PicBox_Eye.IconChar = IconChar.Eye;
                    LbL_pass_see.Text = "Show password";
                    pass_see = false;
                }
            }
        }
    }
}
