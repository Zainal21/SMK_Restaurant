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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Do You Want To Exit This Application?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
            else
            {
                Application.Restart();
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bersih();
                }
                else
                {
                    using (DataClassesDataContext db = new DataClassesDataContext())
                    {
                        Msemployee emp = db.Msemployees.Where(s => s.Email == textBox1.Text && s.Password == textBox2.Text).FirstOrDefault();
                        if (emp != null)
                        {
                            if (emp.Position == "Admin")
                            {
                                (new FrmAdminNavigation(this, emp)).Show();
                                this.Hide();
                                bersih();
                            }
                            else if (emp.Position == "Chef")
                            {
                                (new FrmChefNavigation(this, emp)).Show();
                                this.Hide();
                                bersih();
                            }
                            else if (emp.Position == "Cashier")
                            {
                                (new FrmCashierNavigation(this, emp)).Show();
                                this.Hide();
                                bersih();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Such User", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bersih();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try Again, Please Contact Admin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void bersih()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }
    }
}
