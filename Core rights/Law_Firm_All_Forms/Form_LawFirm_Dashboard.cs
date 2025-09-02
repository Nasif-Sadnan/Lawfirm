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
    public partial class Form_LawFirm_Dashboard : Form
    {
        private string firmID;
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=\"Core Rights\";Integrated Security=True");
        Form parentform;
        public Form_LawFirm_Dashboard(string ID,Form parentform)
        {
            InitializeComponent();
            this.firmID = ID;
            this.parentform = parentform;
            Law_Firm_All_Forms.Form_LawFIrm_DashBoard_showInfo form_LawFIrm_DashBoard_ShowInfo= new Form_LawFIrm_DashBoard_showInfo(firmID,this);
            ShowFormInPanel(form_LawFIrm_DashBoard_ShowInfo);
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
            Law_Firm_All_Forms.Form_LawFIrm_DashBoard_editInfo form_LawFIrm_DashBoard_EditInfo = new Form_LawFIrm_DashBoard_editInfo(firmID);
            ShowFormInPanel(form_LawFIrm_DashBoard_EditInfo);
        }

        private void Icn_BtN_Delete_Account_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Law Firm] WHERE [Firm_ID] = '" + firmID + "'", conn))
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("LawFirm Deleted Successfully");

                    Form_lawfirm_Login form_Lawfirm_Login = new Form_lawfirm_Login();
                    parentform.Hide();
                    form_Lawfirm_Login.Show();
                }
                else
                {
                    MessageBox.Show("LawFirm Cannot be Deleted");
                }
            }
        }
    }
}
