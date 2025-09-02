using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Core_rights
{
    public partial class Form_Admin_SendMail_ForPassCHnage : Form
    {
        private string randomCode;
        public Point mouseLocation;
        public string ID;

        public Form_Admin_SendMail_ForPassCHnage(string ID)
        {
            InitializeComponent();
            Icn_Box_settings.IconChar = IconChar.Bars;
            this.ID = ID;
            LbL_ID.Text = "NID no : " + ID;
        }

        private void Icn_pic_Exit_Btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IcN_Btn_clear_Click(object sender, EventArgs e)
        {
            TxT_Box_Gmail.Text = "Enter your Gmail";
            TxT_Box_Gmail.ForeColor = Color.Silver;

            TxT_Box_random_code.Text = "Enter your code";
            TxT_Box_random_code.ForeColor = Color.Silver;
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

        private void Icn_BtN_Send_Mail_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            randomCode = rand.Next(100000, 999999).ToString();

            string from = "corerightsproject@gmail.com";
            string password = "nbkn tvdt parz eybl";
            string messageBody = $"Your Reset code is {randomCode}";

            MailMessage message = new MailMessage();
            message.To.Add(TxT_Box_Gmail.Text);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password reset code";

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, password);

                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Code successfully sent");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
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

        private void TxT_Box_random_code_Enter(object sender, EventArgs e)
        {
            if (TxT_Box_random_code.Text == "Enter your code")
            {
                TxT_Box_random_code.Text = "";
                TxT_Box_random_code.ForeColor = Color.Black;
            }
        }

        private void TxT_Box_random_code_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_random_code.Text == "")
            {
                TxT_Box_random_code.Text = "Enter your code";
                TxT_Box_random_code.ForeColor = Color.Silver;
            }
        }

        private void Icn_BtN_CHange_Pass_Click(object sender, EventArgs e)
        {
            if (randomCode == TxT_Box_random_code.Text)
            {
                Form_Admin_Change_Password form_Admin_Change_Password = new Form_Admin_Change_Password(ID);
                this.Hide();
                form_Admin_Change_Password.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong code");
            }
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_Admin_Login form_Admin_Login = new Form_Admin_Login();
            this.Hide();
            form_Admin_Login.ShowDialog();
        }
    }
}
