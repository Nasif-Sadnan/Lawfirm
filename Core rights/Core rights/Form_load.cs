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
    public partial class Form_load : Form
    {
        public Form_load()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PnL_Load_Bar.Width += 3;
            if (PnL_Load_Bar.Width >= 465)
            {
                timer1.Stop();
                Form_Welcome f2_Welcome = new Form_Welcome();
                this.Hide();
                f2_Welcome.Show();
            }
        }
    }
}
