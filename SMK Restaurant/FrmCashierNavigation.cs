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
    public partial class FrmCashierNavigation : Form
    {
        private Form close;
        private Msemployee emp;
        public FrmCashierNavigation(Form close, Msemployee emp)
        {
            InitializeComponent();
            this.close = close;
            this.emp = emp;
        }

        private void FrmCashierNavigation_FormClosing(object sender, FormClosingEventArgs e)
        {
            close.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            (new FrmOrder(this, emp)).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FrmPayment(this)).Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new FrmChangePassword(this, emp)).Show();
            this.Hide();
        }

        private void FrmCashierNavigation_Load(object sender, EventArgs e)
        {
            lblName.Text = "Welcome , " + emp.Name;
        }
    }
}
