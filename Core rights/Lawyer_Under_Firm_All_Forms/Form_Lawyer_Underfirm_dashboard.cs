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

namespace Core_rights.Lawyer_Under_Firm_All_Forms
{
    public partial class Form_Lawyer_Underfirm_dashboard : Form
    {

        private string firmID;
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-368TJ83Q\\SQLEXPRESS;Initial Catalog=\"Core Rights\";Integrated Security=True");
        Form parentform;
        public Form_Lawyer_Underfirm_dashboard(string ID, Form parentform)
        {
            InitializeComponent();

            this.firmID = ID;
            this.parentform = parentform;

            Form_LawyerUnderFIrm_ShowInfo form_LawyerUnderFIrm_ShowInfo = new Form_LawyerUnderFIrm_ShowInfo(firmID,this);
            ShowFormInPanel(form_LawyerUnderFIrm_ShowInfo);
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
            Form_LawyerUnderFirm_Editinfo form_LawyerUnderFirm_Editinfo = new Form_LawyerUnderFirm_Editinfo(firmID);
            ShowFormInPanel(form_LawyerUnderFirm_Editinfo);
        }
    }
}
