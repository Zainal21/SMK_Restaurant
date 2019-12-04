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
    public partial class FrmManageEmployee : Form
    {
        private Form close;
        public FrmManageEmployee(Form close)
        {
            InitializeComponent();
            this.close = close;
        }

        private void FrmManageEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            close.Show();
        }

        private void tbxHandphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (int)e.KeyChar != (int)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void FrmManageEmployee_Load(object sender, EventArgs e)
        {
            awal();
        }
        private void bersih()
        {
            tbxName.Clear();
            tbxEmail.Clear();
            tbxHandphone.Clear();
            cbxPosition.SelectedItem = null;
        }
        private void awal()
        {
            autonumber();
            tampildata();
            bersih();
            tbxID.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            awal();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }

        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow r = dg1.Rows[e.RowIndex];
                tbxID.Text = r.Cells["EmployeeID"].Value.ToString();
                tbxName.Text = r.Cells["Name"].Value.ToString();
                tbxEmail.Text = r.Cells["Email"].Value.ToString();
                tbxHandphone.Text = r.Cells["Handphone"].Value.ToString();
                cbxPosition.SelectedItem = r.Cells["Position"].Value.ToString();
            }
        }
        private void tampildata()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                dg1.DataSource = db.Msemployees.Select(s => s);
            }
            dg1.Columns["Password"].Visible = false;
            dg1.Columns["EmployeeID"].HeaderText = "EmployeeId";
        }
        private void autonumber()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Msemployee emp = db.Msemployees.OrderByDescending(s => s.EmployeeID).FirstOrDefault();
                if (emp != null)
                {
                    string a = emp.EmployeeID.ToString();
                    int n = Convert.ToInt32(a) + 1;
                    tbxID.Text = n.ToString("d1");
                }
                else
                {
                    tbxID.Text = "1";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                if (tbxID.Text == "" || tbxName.Text == "" || tbxEmail.Text == "" || tbxHandphone.Text == "" || cbxPosition.SelectedItem == null)
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bersih();
                }
                else
                {
                    Msemployee emp = db.Msemployees.Where(s => s.EmployeeID == tbxID.Text).FirstOrDefault();
                    db.Msemployees.DeleteOnSubmit(emp);
                    db.SubmitChanges();
                    awal();
                    MessageBox.Show("Successfully Deleted Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private static Random random = new Random();
        public static string RandomPass(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    if (tbxID.Text == "" || tbxName.Text == "" || tbxEmail.Text == "" || tbxHandphone.Text == "" || cbxPosition.SelectedItem == null)
                    {
                        MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bersih();
                    }
                    else
                    {
                        string pass = RandomPass(8);
                        db.Msemployees.InsertOnSubmit(new Msemployee()
                        {
                            EmployeeID = tbxID.Text,
                            Name = tbxName.Text,
                            Email = tbxEmail.Text,
                            Handphone = tbxHandphone.Text,
                            Password = pass,
                            Position = cbxPosition.SelectedItem.ToString()
                        });
                        db.SubmitChanges();
                        awal();
                        MessageBox.Show("Successfully Added Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Password : " + pass, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try Again, Please Contact Admin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                if (tbxID.Text == "" || tbxName.Text == "" || tbxEmail.Text == "" || tbxHandphone.Text == "" || cbxPosition.SelectedItem == null)
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bersih();
                }
                else
                {
                    Msemployee emp = db.Msemployees.Where(s => s.EmployeeID == tbxID.Text).FirstOrDefault();
                    emp.EmployeeID = tbxID.Text;
                    emp.Name = tbxName.Text;
                    emp.Email = tbxEmail.Text;
                    emp.Handphone = tbxHandphone.Text;
                    emp.Position = cbxPosition.SelectedItem.ToString();
                    db.SubmitChanges();
                    awal();
                    MessageBox.Show("Successfully Saved Data", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
    }
}
