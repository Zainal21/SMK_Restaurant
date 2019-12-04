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
    public partial class FrmPayment : Form
    {
        private Form close;
        public FrmPayment(Form close)
        {
            InitializeComponent();
            this.close = close;
        }

        private void FrmPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            close.Show();
        }
        private void tampildata()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                dg1.DataSource = from u in db.Detailorders
                                 join s in db.Msmenus
                                 on u.Menuid equals s.MenuID
                                 where u.Orderid == cbxOrderid.SelectedItem.ToString()
                                 select new
                                 {
                                     Menu = s.Name,
                                     Qty = u.Qty,
                                     u.Detailid,
                                     u.Status,
                                     Price = u.Price,
                                     Action = u.Status,
                                     Total = u.Price * u.Qty
                                 };
                dg1.Columns["Action"].Visible = false;
                dg1.Columns["Detailid"].Visible = false;
                dg1.Columns["Status"].Visible = false;
                hitung();
            }
        }
        private void isicombo()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                //cbxOrderid.DataSource = db.Headerorders.Select(s => s.OrderID);
                cbxOrderid.DataSource = from u in db.Headerorders
                                        where u.Payment == null
                                        group u by u.OrderID into s
                                        select s.Key;
            }
        }
        private void hitung()
        {
            int total = 0;
            foreach (DataGridViewRow row in dg1.Rows)
            {
                total += Convert.ToInt32(row.Cells["Total"].Value.ToString());
                Class1.orderid = cbxOrderid.Text;
                Class1.total = total.ToString();
            }
            lblTotal.Text = "Total : " + total.ToString();
        }
        private void bersih()
        {
            lblTotal.Text = "Total : 0";
            dg1.Rows.Clear();
            cbxPayment.SelectedItem = null;
            tbxCard.Clear();
            cbxBank.SelectedItem = null;
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            isicombo();
        }

        private void cbxOrderid_SelectedValueChanged(object sender, EventArgs e)
        {
            tampildata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxPayment.SelectedItem == null || tbxCard.Text == "" || cbxBank.SelectedItem == null)
            {
                MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxPayment.SelectedItem = null;
                tbxCard.Clear();
                cbxBank.SelectedItem = null;
            }
            else
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    Headerorder h = db.Headerorders.Where(s => s.OrderID == cbxOrderid.SelectedItem.ToString()).FirstOrDefault();
                    h.Payment = cbxPayment.SelectedItem.ToString();
                    h.CardNumber = tbxCard.Text;
                    h.bank = cbxBank.SelectedItem.ToString();
                    h.Date = DateTime.Now;
                    db.SubmitChanges();
                    cbxPayment.SelectedItem = null;
                    tbxCard.Clear();
                    cbxBank.SelectedItem = null;
                    dg1.DataSource = null;
                    lblTotal.Text = "Total : 0";
                    this.Refresh();
                    MessageBox.Show("Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cbxType_SelectedValueChanged(object sender, EventArgs e)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                if (dg1.Rows.Count == 0)
                {
                    MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (cbxPayment.SelectedItem == "Cash")
                    {
                        (new FrmAmmountCash(this)).Show();
                        this.Enabled = false;
                    }
                }

            }
        }
    }
}
