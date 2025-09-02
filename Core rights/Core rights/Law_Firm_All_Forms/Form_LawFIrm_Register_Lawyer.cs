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
    public partial class Form_LawFIrm_Register_Lawyer : Form
    {
        public bool pass_see = false;
        public bool cursor_on_pass_Box = false;
        string firmID;
        Form back_Panel;
        public Point mouseLocation;
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-368TJ83Q\SQLEXPRESS;Initial Catalog=""Core Rights"";Integrated Security=True");

        public Form_LawFIrm_Register_Lawyer(Form back_Panel,string firmID)
        {
            this.back_Panel = back_Panel;
            this.firmID = firmID;
            InitializeComponent();
            Icn_Box_settings.IconChar = IconChar.Bars;
            TxT_Box_Judicial_ID_No.Focus();
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void IcN_Btn_clear_Click(object sender, EventArgs e)
        {
            TxT_Box_Gmail.Text = "Enter your Gmail";
            TxT_Box_Gmail.ForeColor = Color.Silver;

            TxT_Box_Name.Text = "Enter your name";
            TxT_Box_Name.ForeColor = Color.Silver;

            TxT_Box_Judicial_ID_No.Text = "Enter your Judicial ID no";
            TxT_Box_Judicial_ID_No.ForeColor = Color.Silver;

            Cmbo_Box_District.Text = "Select District";
            Cmbo_Box_District.ForeColor = Color.Silver;

            Cmbo_Box_Division.Text = "Select Division";
            Cmbo_Box_Division.ForeColor = Color.Silver;

            Cmbo_Box_LawyerType.Text = "Select Type of lawyer";
            Cmbo_Box_LawyerType.ForeColor = Color.Silver;

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

        private void Cmbo_Box_District_MouseClick(object sender, MouseEventArgs e)
        {
            Cmbo_Box_District.Items.Clear();


            if (string.IsNullOrWhiteSpace(Cmbo_Box_Division.Text))
            {
                Cmbo_Box_District.Items.Add("Select Division first");
            }
            else if (Cmbo_Box_Division.Text == "Select Division")
            {
                Cmbo_Box_District.Items.Add("Select Division first");
            }
            else
            {
                if (Cmbo_Box_Division.Text == "Dhaka")
                {
                    string[] Dhaka_Districts =
                    {
                        "Dhaka", "Faridpur", "Gazipur", "Gopalganj", "Kishoreganj","Madaripur", "Manikganj","Munshiganj", "Narayanganj", "Narsingdi","Rajbari", "Shariatpur", "Tangail"
                    };

                    Cmbo_Box_District.Items.AddRange(Dhaka_Districts);
                }
                else if (Cmbo_Box_Division.Text == "Chattogram")
                {
                    string[] Chattogram_Districts =
                    {
                        "Brahmanbaria","Comilla","Chandpur","Lakshmipur","Noakhali","Feni","Khagrachhari","Rangamati","Bandarban","Chittagong","Cox's Bazar"
                    };
                    Cmbo_Box_District.Items.AddRange(Chattogram_Districts);
                }
                else if (Cmbo_Box_Division.Text == "Barishal")
                {
                    string[] Barishal_Districts =
                    {
                        "Barishal", "Patuakhali", "Bhola", "Pirojpur", "Barguna", "Jhalokati"
                    };
                    Cmbo_Box_District.Items.AddRange(Barishal_Districts);
                }
                else if (Cmbo_Box_Division.Text == "Khulna")
                {
                    string[] Khulna_Districts =
                    {
                        "Khulna", "Bagherhat", "Sathkhira", "Jessore", "Magura", "Jhenaidah", "Narail", "Kushtia", "Chuadanga", "Meherpur"
                    };
                    Cmbo_Box_District.Items.AddRange(Khulna_Districts);
                }
                else if (Cmbo_Box_Division.Text == "Rajshahi")
                {
                    string[] Rajshahi_Districts =
                    {
                        "Rajshahi", "Chapainawabganj", "Natore", "Naogaon", "Pabna", "Sirajganj", "Bogra", "Joypurhat"
                    };
                    Cmbo_Box_District.Items.AddRange(Rajshahi_Districts);
                }
                else if (Cmbo_Box_Division.Text == "Rangpur")
                {
                    string[] Rangpur_Districts =
                    {
                        "Rangpur", "Gaibandha", "Nilphamari", "Kurigram", "Lalmonirhat", "Dinajpur", "Thakurgaon", "Panchagarh"
                    };
                    Cmbo_Box_District.Items.AddRange(Rangpur_Districts);
                }
                else if (Cmbo_Box_Division.Text == "Mymensingh")
                {
                    string[] Mymensingh_Districts =
                    {
                        "Mymensingh", "Jamalpur", "Netrokona", "Sherpur"
                    };
                    Cmbo_Box_District.Items.AddRange(Mymensingh_Districts);
                }
                else if (Cmbo_Box_Division.Text == "Sylhet")
                {
                    string[] Sylhet_Districts =
                    {
                        "Habiganj", "Moulvibazar", "Sunamganj", "Sylhet"
                    };
                    Cmbo_Box_District.Items.AddRange(Sylhet_Districts);
                }
                else
                {
                    Cmbo_Box_District.Items.Add("Select Division correctly");
                }
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

        private void TxT_Box_Judicial_ID_No_Enter(object sender, EventArgs e)
        {

            if (TxT_Box_Judicial_ID_No.Text == "Enter your Judicial ID no")
            {
                TxT_Box_Judicial_ID_No.Text = "";
                TxT_Box_Judicial_ID_No.ForeColor = Color.Black;
            }
        }

        private void TxT_Box_Judicial_ID_No_Leave(object sender, EventArgs e)
        {
            if (TxT_Box_Judicial_ID_No.Text == "")
            {
                TxT_Box_Judicial_ID_No.Text = "Enter your Judicial ID no";
                TxT_Box_Judicial_ID_No.ForeColor = Color.Silver;
            }
        }

        private void Cmbo_Box_LawyerType_Enter(object sender, EventArgs e)
        {
            if (Cmbo_Box_LawyerType.Text == "Select Type of lawyer")
            {
                Cmbo_Box_LawyerType.Text = "";
                Cmbo_Box_LawyerType.ForeColor = Color.Black;
            }
        }

        private void Cmbo_Box_LawyerType_Leave(object sender, EventArgs e)
        {
            if (Cmbo_Box_LawyerType.Text == "")
            {
                Cmbo_Box_LawyerType.Text = "Select Type of lawyer";
                Cmbo_Box_LawyerType.ForeColor = Color.Silver;
            }
        }

        private void Cmbo_Box_District_Enter(object sender, EventArgs e)
        {
            if (Cmbo_Box_District.Text == "Select District")
            {
                Cmbo_Box_District.Text = "";
                Cmbo_Box_District.ForeColor = Color.Black;
            }
        }

        private void Cmbo_Box_District_Leave(object sender, EventArgs e)
        {
            if (Cmbo_Box_District.Text == "" || Cmbo_Box_District.Text == "Select Division first" || Cmbo_Box_District.Text == "Select Division correctly")
            {
                Cmbo_Box_District.Text = "Select District";
                Cmbo_Box_District.ForeColor = Color.Silver;
            }
        }

        private void Cmbo_Box_Division_Enter(object sender, EventArgs e)
        {
            if (Cmbo_Box_Division.Text == "Select Division")
            {
                Cmbo_Box_Division.Text = "";
                Cmbo_Box_Division.ForeColor = Color.Black;
            }
        }

        private void Cmbo_Box_Division_Leave(object sender, EventArgs e)
        {
            if (Cmbo_Box_Division.Text == "")
            {
                Cmbo_Box_Division.Text = "Select Division";
                Cmbo_Box_Division.ForeColor = Color.Silver;
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

        private void Icn_BtN_Register_Click(object sender, EventArgs e)
        {
            if (TxT_Box_Name.Text == "" || TxT_Box_Gmail.Text == ""  || TxT_Box_Judicial_ID_No.Text == "" || Cmbo_Box_District.Text == "" || Cmbo_Box_Division.Text == "" || TxT_Box_Password.Text == "" || TxT_Box_Name.Text == "Enter your name" || TxT_Box_Gmail.Text == "Enter your Gmail" || TxT_Box_Judicial_ID_No.Text == "Enter your Judicial ID no" || Cmbo_Box_District.Text == "Select District" || Cmbo_Box_Division.Text == "Select Division" || TxT_Box_Password.Text == "Enter your Password" || Cmbo_Box_LawyerType.Text == "" || Cmbo_Box_LawyerType.Text == "Select Type of lawyer")
            {
                MessageBox.Show(" Please enter all the datas");
            }
            else
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Lawyer Under Firm]
                    ([Lawyer Name],
                     [Gmail],
                     [Division],
                     [Judicial licence number ],
                     [District],
                     [Password],[Type of lawyer],[Firm ID])
                    VALUES      
                    ('" + TxT_Box_Name.Text + "','" + TxT_Box_Gmail.Text + "', '" + Cmbo_Box_Division.Text + "','" + TxT_Box_Judicial_ID_No.Text + "','" + Cmbo_Box_District.Text + "','" + TxT_Box_Password.Text + "','" + Cmbo_Box_LawyerType.Text + "','"+firmID+"')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registered Succesfully");

                TxT_Box_Name.Text = "Enter your name";
                TxT_Box_Name.ForeColor = Color.Silver;


                TxT_Box_Gmail.Text = "Enter your Gmail";
                TxT_Box_Gmail.ForeColor = Color.Silver;


                TxT_Box_Judicial_ID_No.Text = "Enter your Judicial ID no";
                TxT_Box_Judicial_ID_No.ForeColor = Color.Silver;

                Cmbo_Box_District.Text = "Select District";
                Cmbo_Box_District.ForeColor = Color.Silver;

                Cmbo_Box_Division.Text = "Select Division";
                Cmbo_Box_Division.ForeColor = Color.Silver;

                Cmbo_Box_LawyerType.Text = "Select Type of lawyer";
                Cmbo_Box_LawyerType.ForeColor = Color.Silver;

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
