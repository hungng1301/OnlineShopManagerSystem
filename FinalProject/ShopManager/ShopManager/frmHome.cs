using ShopManager.Models;
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
    public partial class frmHome : Form
    {
        public Account CurAccount { get;}
        public Account AccountUpdate { get; set; }

        public frmHome(Account account)
        {
            CurAccount = account;
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            tbEmail.Text = CurAccount.Email;
            tbName.Text = CurAccount.Name;
            tbPass.Text = CurAccount.Password;
            tbPhone.Text = CurAccount.PhoneNumber;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            PRN_ProjectContext context = new PRN_ProjectContext();
            AccountUpdate = (from a in context.Accounts
                             where a.Aid == CurAccount.Aid
                             select a).First();
            if (AccountUpdate != null)
            {
                if (tbName.Text != "")
                {
                    AccountUpdate.Name = tbName.Text;
                    if (tbPhone.Text.Count() == 10 && System.Text.RegularExpressions.Regex.IsMatch(tbPhone.Text, "^[0-9]+$"))
                    {
                        AccountUpdate.PhoneNumber = tbPhone.Text;
                        context.SaveChanges();
                        MessageBox.Show("Đã thay đổi thông tin", "Thành công");
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại sai");
                    }                   
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên");
                }              
            }
        }

        private void btChangePass_Click(object sender, EventArgs e)
        {
            frmChangePassword frmEdit = new frmChangePassword(CurAccount);
            //this.Hide();
            frmEdit.FormClosed += FrmEdit_FormClosed;
            frmEdit.ShowDialog();
            //this.Close();
        }

        private void FrmEdit_FormClosed(object? sender, FormClosedEventArgs e)
        {
            PRN_ProjectContext context = new PRN_ProjectContext();
            AccountUpdate = (from a in context.Accounts
                             where a.Aid == CurAccount.Aid
                             select a).First();
            tbEmail.Text = AccountUpdate.Email;
            tbName.Text = AccountUpdate.Name;
            tbPass.Text = AccountUpdate.Password;
            tbPhone.Text = AccountUpdate.PhoneNumber;
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductManager frmProductManager = new frmProductManager();
            this.Hide();
            frmProductManager.ShowDialog();
            this.Show();
        }

        private void quảnLýĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderManager frmOrderManager = new frmOrderManager();
            this.Hide();
            frmOrderManager.ShowDialog();
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
