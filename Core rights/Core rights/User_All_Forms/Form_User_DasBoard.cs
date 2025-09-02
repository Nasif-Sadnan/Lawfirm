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
    public partial class Form_User_DasBoard : Form
    {
        private string firmID;
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=\"Core Rights\";Integrated Security=True");
        Form parentform;
        public Form_User_DasBoard(string ID, Form parentform)
        {
            InitializeComponent();

            this.firmID = ID;
            this.parentform = parentform;
            User_All_Forms.Form_User_DashBoard_showinfo form_User_DashBoard_Showinfo = new Form_User_DashBoard_showinfo(firmID,this);
            ShowFormInPanel(form_User_DashBoard_Showinfo);
        }
        private void ShowFormInPanel(Form form)
        {
            panel_lawyer_infoes.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel_lawyer_infoes.Controls.Add(form);

            form.Show();
        }

        private void Icn_BtN_Add_Lawyer_Click(object sender, EventArgs e)
        {
            User_All_Forms.Form_User_Dashboard_editInfo form_User_Dashboard_EditInfo = new Form_User_Dashboard_editInfo(firmID);
            ShowFormInPanel(form_User_Dashboard_EditInfo);
        }

        private void Icn_BtN_Delete_Account_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[User] WHERE [NID] = '" + firmID + "'", conn))
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User Deleted Successfully");

                    Form_lawfirm_Login form_Lawfirm_Login = new Form_lawfirm_Login();
                    parentform.Hide();
                    form_Lawfirm_Login.Show();
                }
                else
                {
                    MessageBox.Show("User Cannot be Deleted");
                }
            }
        }
    }
}
