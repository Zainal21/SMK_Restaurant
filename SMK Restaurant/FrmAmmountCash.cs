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
    public partial class FrmAmmountCash : Form
    {
        private Form close;
        public FrmAmmountCash(Form close)
        {
            InitializeComponent();
            this.close = close;
        }

        private void FrmAmmountCash_Load(object sender, EventArgs e)
        {
            close.Show();
            lblTotal.Text = "Your Payment : " + Class1.total.ToString();
        }

        private void FrmAmmountCash_FormClosing(object sender, FormClosingEventArgs e)
        {
            close.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(Class1.total);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Data Cant Be Empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
            }
            else if (a < b)
            {
                MessageBox.Show("Your Money Is Not Enough", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox1.Focus();
            }
            else
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    Headerorder h = db.Headerorders.Where(s => s.OrderID == Class1.orderid).FirstOrDefault();
                    h.Payment = "Cash";
                    db.SubmitChanges();
                    MessageBox.Show("Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    close.Enabled = true;
                    this.Close();
                }
            }
        }
    }
}
