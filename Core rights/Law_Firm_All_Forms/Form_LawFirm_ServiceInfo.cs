using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core_rights.Law_Firm_All_Forms
{
    public partial class Form_LawFirm_ServiceInfo : Form
    {
        public string ID;
        public Form_LawFirm_ServiceInfo(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }
    }
}
