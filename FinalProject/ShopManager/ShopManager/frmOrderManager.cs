using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManager
{
    public partial class frmOrderManager : Form
    {
        public frmOrderManager()
        {
            InitializeComponent();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductManager frmProductManager = new frmProductManager();
            this.Hide();
            frmProductManager.ShowDialog();
            this.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountManager frmAccountManager = new frmAccountManager();
            this.Hide();
            frmAccountManager.ShowDialog();
            this.Show();
        }
    }
}
