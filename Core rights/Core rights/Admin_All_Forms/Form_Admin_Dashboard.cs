using Core_rights.User_All_Forms;
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

namespace Core_rights.Admin_All_Forms
{
    public partial class Form_Admin_Dashboard : Form
    {
        private string firmID;
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=\"Core Rights\";Integrated Security=True");
        Form parentform;
        public Form_Admin_Dashboard(string ID,Form parentform)
        {
            InitializeComponent();

            this.firmID = ID;
            this.parentform = parentform;
            Form_Admin_ShowInfo form_Admin_ShowInfo = new Form_Admin_ShowInfo(firmID, this);
            ShowFormInPanel(form_Admin_ShowInfo);
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

        private void Icn_BtN_Delete_Account_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Admin] WHERE [ID] = '" + firmID + "'", conn))
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Admin Deleted Successfully");

                    Form_lawfirm_Login form_Lawfirm_Login = new Form_lawfirm_Login();
                    parentform.Hide();
                    form_Lawfirm_Login.Show();
                }
                else
                {
                    MessageBox.Show("Admin Cannot be Deleted");
                }
            }
        }

        private void Icn_BtN_Add_Lawyer_Click(object sender, EventArgs e)
        {
            Form_Admin_EditInfo form_Admin_EditInfo = new Form_Admin_EditInfo(firmID);
            ShowFormInPanel(form_Admin_EditInfo);
        }
    }
}
