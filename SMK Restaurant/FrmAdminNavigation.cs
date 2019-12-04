using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMK_Restaurant
{
    public partial class FrmAdminNavigation : Form
    {
        private Form close;
        private Msemployee emp;
        public FrmAdminNavigation(Form close, Msemployee emp)
        {
            InitializeComponent();
            this.close = close;
            this.emp = emp;
        }

        private void FrmAdminNavigation_FormClosing(object sender, FormClosingEventArgs e)
        {
            close.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Logout?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                close.Show();
                this.Hide();
            }
            else
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FrmManageEmployee(this)).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new FrmManageMenu(this)).Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new FrmManageMember(this)).Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new FrmChangePassword(this, emp)).Show();
            this.Hide();
        }

        private void FrmAdminNavigation_Load(object sender, EventArgs e)
        {
            lblName.Text = "Welcome , " + emp.Name;
        }
    }
}
