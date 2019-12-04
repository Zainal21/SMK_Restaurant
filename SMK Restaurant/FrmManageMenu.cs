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
    public partial class FrmManageMenu : Form
    {
        private Form close;
        public FrmManageMenu(Form close)
        {
            this.close = close;
            InitializeComponent();
        }

        private void FrmManageMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            close.Show();
        }

        private void tbxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (int)e.KeyChar != (int)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                tbxPhoto.Text = openFileDialog1.FileName;
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }
        private void bersih()
        {
            tbxName.Clear();
            tbxPrice.Clear();
            tbxPhoto.Clear();
            pictureBox1.ImageLocation = null;
            pictureBox1.BackgroundImage = null;
        }
        private void awal()
        {
            tampildata();
            bersih();
            autonumber();
            tbxID.Enabled = false;
            tbxPhoto.ReadOnly = true;
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
            pictureBox1.ImageLocation = null;
            pictureBox1.BackgroundImage = null;
            if (e.RowIndex > -1)
            {
                DataGridViewRow r = dg1.Rows[e.RowIndex];
                tbxID.Text = r.Cells["MenuID"].Value.ToString();
                tbxName.Text = r.Cells["Name"].Value.ToString();
                tbxPrice.Text = r.Cells["Price"].Value.ToString();
                tbxPhoto.Text = r.Cells["Photo"].Value.ToString();
                pictureBox1.ImageLocation = r.Cells["Photo"].Value.ToString();
            }
        }
        private void tampildata()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                dg1.DataSource = db.Msmenus.Select(s => s);
                dg1.Columns["MenuID"].HeaderText = "MenuId";
                dg1.Columns["Photo"].Visible = false;
            }
        }
        private void autonumber()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Msmenu m = db.Msmenus.OrderByDescending(s => s.MenuID).FirstOrDefault();
                if (m != null)
                {
                    string a = m.MenuID.ToString();
                    int n = Convert.ToInt32(a) + 1;
                    tbxID.Text = n.ToString("d1");
                }
                else
                {
                    tbxID.Text = "1";
                }
            }
        }

        private void FrmManageMenu_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                if (tbxID.Text == "" || tbxName.Text == "" || tbxPrice.Text == "" || tbxPhoto.Text == "")
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bersih();
                }
                else
                {
                    Msmenu m = db.Msmenus.Where(s => s.MenuID == Convert.ToInt32(tbxID.Text)).FirstOrDefault();
                    db.Msmenus.DeleteOnSubmit(m);
                    db.SubmitChanges();
                    awal();
                    MessageBox.Show("Successfully Deleted Data", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                if (tbxID.Text == "" || tbxName.Text == "" || tbxPrice.Text == "" || tbxPhoto.Text == "")
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bersih();
                }
                else
                {
                    Msmenu m = db.Msmenus.Where(s => s.MenuID == Convert.ToInt32(tbxID.Text)).FirstOrDefault();
                    m.MenuID = Convert.ToInt32(tbxID.Text);
                    m.Name = tbxName.Text;
                    m.Price = Convert.ToInt32(tbxPrice.Text);
                    m.Photo = tbxPhoto.Text;
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
                    if (tbxID.Text == "" || tbxName.Text == "" || tbxPrice.Text == "" || tbxPhoto.Text == "")
                    {
                        MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bersih();
                    }
                    else
                    {
                        db.Msmenus.InsertOnSubmit(new Msmenu()
                        {
                            MenuID = Convert.ToInt32(tbxID.Text),
                            Name = tbxName.Text,
                            Price = Convert.ToInt32(tbxPrice.Text),
                            Photo = tbxPhoto.Text,
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
