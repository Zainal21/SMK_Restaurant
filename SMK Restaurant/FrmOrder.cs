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
    public partial class FrmOrder : Form
    {
        menuu selected;
        string kodeid;
        string idtype;
        List<menuu> list = new List<menuu>();
        private Form close;
        private Msemployee emp;
        public FrmOrder(Form close, Msemployee emp)
        {
            InitializeComponent();
            this.close = close;
            this.emp = emp;
        }

        private void FrmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            close.Show();
        }

        private void tbxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (int)e.KeyChar != (int)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (int)e.KeyChar != (int)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void tampildata()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                dg1.DataSource = db.Msmenus.Select(s => s);
                dg1.Columns["MenuID"].Visible = false;
                dg1.Columns["Photo"].Visible = false;
                dg1.Columns["Name"].HeaderText = "Menu";
                cbxMember.DataSource = db.Msmembers.Select(s => s.Name);
            }
        }
        private void bersih()
        {
            tbxName.Clear();
            tbxQty.Clear();
            tbxPrice.Clear();
            dg2.Rows.Clear();
            lblTotal.Text = "Total : 0";
            dg2.DataSource = null;
            pictureBox1.ImageLocation = null;
            pictureBox1.BackgroundImage = null;
        }
        private void awal()
        {
            tampildata();
            bersih();
            tbxName.Enabled = false;
            tbxPrice.Enabled = false;
            cbxMember.Enabled = true;
            dg2.Refresh();
        }
        private void refreshlabel()
        {
            int tot = 0;
            foreach (menuu i in list)
            {
                tot += i.Total;
                lblTotal.Text = "Total : " + tot.ToString();
            }
            if (list.Count == 0)
            {
                lblTotal.Text = "Total : 0";
            }
        }
        private void refreshdg()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = list;
            dg2.DataSource = bs;
            if (list.Count != null)
            {
                dg2.Columns["kodemenu"].Visible = false;
                dg2.Columns["namamember"].HeaderText = "Nama Member";
                dg2.Columns["namamenu"].HeaderText = "Menu";
            }
            else
            {
                dg2.DataSource = null;
            }
        }
        string c;
        private void autonumber()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Detailorder d = db.Detailorders.OrderByDescending(s => s.Detailid).FirstOrDefault();
                if (d != null)
                {
                    string a = d.Detailid.ToString().Substring(6, 4);
                    int n = Convert.ToInt32(a) + 1;
                    c = DateTime.Today.ToString("yyyyMM") + n.ToString("d4");
                }
                else
                {
                    c = DateTime.Today.ToString("yyyyMM") + "0001";
                }
            }
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void cbxMember_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxMember.Enabled = false;
        }

        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow r = dg1.Rows[e.RowIndex];
                kodeid = r.Cells["MenuID"].Value.ToString();
                tbxName.Text = r.Cells["Name"].Value.ToString();
                tbxPrice.Text = r.Cells["Price"].Value.ToString();
                pictureBox1.ImageLocation = r.Cells["Photo"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                if (tbxName.Text == "" || tbxPrice.Text == "" || tbxQty.Text == "" || cbxMember.SelectedItem == null)
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bersih();
                }
                else
                {
                    menuu m = list.Where(s => s.kodemenu == kodeid).FirstOrDefault();
                    if (m != null)
                    {
                        m.Qty += Convert.ToInt32(tbxQty.Text);
                    }
                    else
                    {
                        list.Add(new menuu
                        {
                            kodemenu = kodeid,
                            namamember = cbxMember.SelectedItem.ToString(),
                            namamenu = tbxName.Text,
                            Price = Convert.ToInt32(tbxPrice.Text),
                            Qty = Convert.ToInt32(tbxQty.Text)
                        });
                    }
                    refreshlabel();
                    refreshdg();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                MessageBox.Show("Please Select Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (selected.Qty > -1)
                {
                    selected.Qty--;
                }
                else
                {
                    list.Remove(selected);
                }
                refreshlabel();
                refreshdg();
            }
        }

        private void dg2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selected = new menuu();
                selected = list[e.RowIndex];
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    if (dg2.DataSource == null)
                    {
                        MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        awal();
                    }
                    else
                    {
                        Headerorder d = db.Headerorders.OrderByDescending(s => s.OrderID).FirstOrDefault();
                        if (d != null)
                        {
                            string auto = d.OrderID.ToString().Substring(6, 4);
                            int n = Convert.ToInt32(auto) + 1;
                            c = DateTime.Today.ToString("yyyyMM") + n.ToString("d4");
                        }
                        else
                        {
                            c = DateTime.Today.ToString("yyyyMM") + "0001";
                        }
                        int dd;
                        Detailorder ddd = db.Detailorders.OrderByDescending(s => s.Detailid).FirstOrDefault();
                        if (ddd != null)
                        {
                            string autonumber = ddd.Detailid.ToString();
                            int n = Convert.ToInt32(autonumber) + 1;
                            dd = Convert.ToInt32(n.ToString("d1"));
                        }
                        else
                        {
                            dd = 1;
                        }
                        var a = c;
                        List<Msmember> m = db.Msmembers.Select(s => s).ToList();
                        db.Headerorders.InsertOnSubmit(new Headerorder
                        {
                            OrderID = a,
                            Employeeid = emp.EmployeeID,
                            Date = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")),
                            Memberid = m[cbxMember.SelectedIndex].MemberID
                        });
                        db.SubmitChanges();
                        foreach (menuu i in list)
                        {
                            db.Detailorders.InsertOnSubmit(new Detailorder
                            {
                                Detailid = dd,
                                Orderid = a,
                                Menuid = Convert.ToInt32(i.kodemenu),
                                Qty = i.Qty,
                                Price = i.Price,
                                Status = "Pending"
                            });
                            db.SubmitChanges();
                        }
                        MessageBox.Show("Successfully Order Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        awal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try Again, Please Contact Admin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                awal();
            }
        }
    }
    class menuu
    {
        public string namamember { get; set; }
        public string namamenu { get; set; }
        public string kodemenu { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int Total { get { return Price * Qty; } }
    }
}
