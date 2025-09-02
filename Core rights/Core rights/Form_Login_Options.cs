using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core_rights
{
    public partial class Form_Login_Options : Form
    {
        public Point mouseLocation;
        public Form_Login_Options()
        {
            InitializeComponent();
            Icn_Box_settings.IconChar = IconChar.Bars;
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            Form_Welcome f_Welcome = new Form_Welcome();
            this.Hide();
            f_Welcome.ShowDialog();
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

        private void PnL_user_Name_back_MouseEnter(object sender, EventArgs e)
        {
            PnL_user_Name_back.BackColor = Color.Silver;
            LbL_User.BackColor = Color.Silver;
            LbL_User2.BackColor = Color.Silver;
            PnL_User_Pic_Back.BackColor = Color.Silver;
            Icn_Pic_User.BackColor = Color.Silver;
            Icn_Pic_User.IconColor = SystemColors.ButtonHighlight;
        }

        private void PnL_user_Name_back_MouseLeave(object sender, EventArgs e)
        {
            PnL_user_Name_back.BackColor = SystemColors.ButtonHighlight;
            LbL_User.BackColor = SystemColors.ButtonHighlight;
            LbL_User2.BackColor = SystemColors.ButtonHighlight;
            PnL_User_Pic_Back.BackColor = SystemColors.ButtonHighlight;
            Icn_Pic_User.BackColor = SystemColors.ButtonHighlight;
            Icn_Pic_User.IconColor = SystemColors.ButtonShadow;
        }

        private void PnL_Law_FirmName_Back_MouseEnter(object sender, EventArgs e)
        {
            PnL_Law_FirmName_Back.BackColor = Color.Silver;
            LbL_Lawfirm.BackColor = Color.Silver;
            LbL_Lawfirm2.BackColor = Color.Silver;
            PnL_Lawfirm_Pic_Back.BackColor = Color.Silver;
            Icn_Pic_Law_Firm.BackColor = Color.Silver;
            Icn_Pic_Law_Firm.IconColor = SystemColors.ButtonHighlight;
        }

        private void PnL_Law_FirmName_Back_MouseLeave(object sender, EventArgs e)
        {
            PnL_Law_FirmName_Back.BackColor = SystemColors.ButtonHighlight;
            LbL_Lawfirm.BackColor = SystemColors.ButtonHighlight;
            LbL_Lawfirm2.BackColor = SystemColors.ButtonHighlight;
            PnL_Lawfirm_Pic_Back.BackColor = SystemColors.ButtonHighlight;
            Icn_Pic_Law_Firm.BackColor = SystemColors.ButtonHighlight;
            Icn_Pic_Law_Firm.IconColor = SystemColors.ButtonShadow;
        }

        private void PnL_Lawyer_Name_Back_MouseEnter(object sender, EventArgs e)
        {
            PnL_Lawyer_Name_Back.BackColor = Color.Silver;
            LbL_Lawyer.BackColor = Color.Silver;
            LbL_Lawyer2.BackColor = Color.Silver;
            PnL_Lawyer_Pic_Back.BackColor = Color.Silver;
            Icn_Pic_Lawyer.BackColor = Color.Silver;
            Icn_Pic_Lawyer.IconColor = SystemColors.ButtonHighlight;
        }

        private void PnL_Lawyer_Name_Back_MouseLeave(object sender, EventArgs e)
        {
            PnL_Lawyer_Name_Back.BackColor = SystemColors.ButtonHighlight;
            LbL_Lawyer.BackColor = SystemColors.ButtonHighlight;
            LbL_Lawyer2.BackColor = SystemColors.ButtonHighlight;
            PnL_Lawyer_Pic_Back.BackColor = SystemColors.ButtonHighlight;
            Icn_Pic_Lawyer.BackColor = SystemColors.ButtonHighlight;
            Icn_Pic_Lawyer.IconColor = SystemColors.ButtonShadow;
        }

        private void PnL_Admin_Name_Back_MouseEnter(object sender, EventArgs e)
        {
            PnL_Admin_Name_Back.BackColor = Color.Silver;
            LbL_Admin.BackColor = Color.Silver;
            LbL_Admin2.BackColor = Color.Silver;
            PnL_Admin_Pic_Back.BackColor = Color.Silver;
            Icn_Pic_Admin.BackColor = Color.Silver;
            Icn_Pic_Admin.IconColor = SystemColors.ButtonHighlight;
        }

        private void PnL_Admin_Name_Back_MouseLeave(object sender, EventArgs e)
        {
            PnL_Admin_Name_Back.BackColor = SystemColors.ButtonHighlight;
            LbL_Admin.BackColor = SystemColors.ButtonHighlight;
            LbL_Admin2.BackColor = SystemColors.ButtonHighlight;
            PnL_Admin_Pic_Back.BackColor = SystemColors.ButtonHighlight;
            Icn_Pic_Admin.BackColor = SystemColors.ButtonHighlight;
            Icn_Pic_Admin.IconColor = SystemColors.ButtonShadow;
        }

        private void PnL_user_Name_back_Click(object sender, EventArgs e)
        {
            Form_User_Login form_User_Login = new Form_User_Login();
            this.Hide();
            form_User_Login.ShowDialog();
        }

        private void PnL_Law_FirmName_Back_MouseClick(object sender, MouseEventArgs e)
        {
            Form_lawfirm_Login f_Lawfirm_Login = new Form_lawfirm_Login();
            this.Hide();
            f_Lawfirm_Login.ShowDialog();
        }

        private void PnL_Lawyer_Name_Back_MouseClick(object sender, MouseEventArgs e)
        {
            Form_Lawyer_Login f_Lawyer_Login = new Form_Lawyer_Login();
            this.Hide();
            f_Lawyer_Login.ShowDialog();
        }

        private void PnL_Admin_Name_Back_MouseClick(object sender, MouseEventArgs e)
        {
            Form_Admin_Login f_Admin_Login = new Form_Admin_Login();
            this.Hide();
            f_Admin_Login.ShowDialog();
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

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Window format or extended format not available at this moment!!");
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
