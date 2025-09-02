using Core_rights.Individual_Lawyer_All_Forms;
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

namespace Core_rights.Individual_Lawyer_All_Forms
{
    public partial class Form_Individual_Lawyer_DashBoard_ShowInfo : Form
    {
        private string firmID;
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=\"Core Rights\";Integrated Security=True");
        Form parentform;
        public Form_Individual_Lawyer_DashBoard_ShowInfo(string ID, Form parentform)
        {
            this.firmID = ID;
            this.parentform = parentform;
            InitializeComponent();
            Form_IndividualLawyer_ShowInfo form_IndividualLawyer_ShowInfo = new Form_IndividualLawyer_ShowInfo(firmID,this);
            ShowFormInPanel(form_IndividualLawyer_ShowInfo);
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
            using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Individual Lawyer] WHERE [Lawyer ID ] = '" + firmID + "'", conn))
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Lawyer Deleted Successfully");

                    Form_Lawyer_Login form_Lawyer_Login = new Form_Lawyer_Login();
                    parentform.Hide();
                    form_Lawyer_Login.Show();
                }
                else
                {
                    MessageBox.Show("Lawyer Cannot be Deleted");
                }
            }
        }

        private void Icn_BtN_Add_Lawyer_Click(object sender, EventArgs e)
        {
            Form_IndividualLawyer_EditInfo form_IndividualLawyer_EditInfo = new Form_IndividualLawyer_EditInfo(firmID);
            ShowFormInPanel(form_IndividualLawyer_EditInfo);
        }
    }
}
