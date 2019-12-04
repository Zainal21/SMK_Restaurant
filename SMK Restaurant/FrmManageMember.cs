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
    public partial class FrmManageMember : Form
    {
        private Form close;
        public FrmManageMember(Form close)
        {
            InitializeComponent();
            this.close = close;
        }

        private void FrmManageMember_FormClosing(object sender, FormClosingEventArgs e)
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
        private void bersih()
        {
            tbxName.Clear();
            tbxEmail.Clear();
            tbxHandphone.Clear();
        }
        private void awal()
        {
            tampildata();
            autonumber();
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
                tbxID.Text = r.Cells["MemberID"].Value.ToString();
                tbxName.Text = r.Cells["Name"].Value.ToString();
                tbxEmail.Text = r.Cells["Email"].Value.ToString();
                tbxHandphone.Text = r.Cells["Handphone"].Value.ToString();
            }
        }
        private void tampildata()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                dg1.DataSource = db.Msmembers.Select(s => s);
                dg1.Columns["MemberID"].HeaderText = "MemberId";
            }
        }
        private void autonumber()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Msmember m = db.Msmembers.OrderByDescending(s => s.MemberID).FirstOrDefault();
                if (m != null)
                {
                    string a = m.MemberID.ToString();
                    int n = Convert.ToInt32(a) + 1;
                    tbxID.Text = n.ToString("d1");
                }
                else
                {
                    tbxID.Text = "1";
                }
            }
        }

        private void FrmManageMember_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                if (tbxID.Text == "" || tbxName.Text == "" || tbxEmail.Text == "" || tbxHandphone.Text == "")
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bersih();
                }
                else
                {
                    Msmember m  = db.Msmembers.Where(s => s.MemberID == tbxID.Text).FirstOrDefault();
                    db.Msmembers.DeleteOnSubmit(m);
                    db.SubmitChanges();
                    awal();
                    MessageBox.Show("Successfully Deleted Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                if (tbxID.Text == "" || tbxName.Text == "" || tbxEmail.Text == "" || tbxHandphone.Text == "")
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bersih();
                }
                else
                {
                    Msmember m = db.Msmembers.Where(s => s.MemberID == tbxID.Text).FirstOrDefault();
                    m.MemberID = tbxID.Text;
                    m.Name = tbxName.Text;
                    m.Email = tbxEmail.Text;
                    m.Handphone = tbxHandphone.Text;
                    m.JoinDate = DateTime.Now;
                    db.SubmitChanges();
                    awal();
                    MessageBox.Show("Successfully Saved Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    if (tbxID.Text == "" || tbxName.Text == "" || tbxEmail.Text == "" || tbxHandphone.Text == "")
                    {
                        MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bersih();
                    }
                    else
                    {
                        db.Msmembers.InsertOnSubmit(new Msmember()
                        {
                            MemberID = tbxID.Text,
                            Name = tbxName.Text,
                            Email = tbxEmail.Text,
                            Handphone = tbxHandphone.Text,
                            JoinDate = DateTime.Now
                        });
                        db.SubmitChanges();
                        awal();
                        MessageBox.Show("Successfully Added Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try Again, Please Contact Admin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
