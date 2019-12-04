using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SMK_Restaurant
{
    public partial class FrmChangePassword : Form
    {
        private Form close;
        private Msemployee emp;
        public FrmChangePassword(Form close, Msemployee emp)
        {
            InitializeComponent();
            this.close = close;
            this.emp = emp;
            emp = new Msemployee();
        }

        private void FrmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            close.Show();
        }
        private void awal()
        {
            tbxConfirm.Enabled = false;
            tbxNew.Enabled = false;
            tbxNew.Clear();
            tbxOld.Clear();
            tbxConfirm.Clear();
            tbxOld.Focus();
            this.Refresh();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Msemployee employee = db.Msemployees.Where(s => s.EmployeeID == emp.EmployeeID).FirstOrDefault();
                if (tbxOld.Text == "" || tbxNew.Text == "" || tbxConfirm.Text == "")
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    awal();
                }
                else
                {
                    employee.Password = tbxConfirm.Text;
                    db.SubmitChanges();
                    MessageBox.Show("Successfully Change Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    awal();

                }
            }
        }

        private void tbxOld_TextChanged(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Msemployee employee = db.Msemployees.Where(s => s.EmployeeID == emp.EmployeeID).FirstOrDefault();
                if (tbxOld.Text == employee.Password)
                {
                    tbxNew.Enabled = true;
                }
                else
                {
                    tbxNew.Enabled = false;
                }
            }
        }

        private void tbxNew_TextChanged(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Regex reg = new Regex("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{5,20}$");
                if (reg.IsMatch(tbxNew.Text))
                {
                    tbxConfirm.Enabled = true;
                }
                else
                {
                    tbxConfirm.Enabled = false;
                }
            }
        }
    }
}
