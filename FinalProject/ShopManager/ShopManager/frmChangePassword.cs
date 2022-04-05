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
    public partial class frmChangePassword : Form
    {
        public Account CurAccount { get; }

        public frmChangePassword()
        {
            InitializeComponent();
        }
        public frmChangePassword(Account account)
        {
            CurAccount = account;
            InitializeComponent();
        }
        private void frmEditProfile_Load(object sender, EventArgs e)
        {
            //tbName.Text = CurAccount.Name;
            //tbEmail.Text = CurAccount.Email;
            //tbPass.Text = CurAccount.Password;
            //tbPhone.Text = CurAccount.PhoneNumber;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            PRN_ProjectContext context = new PRN_ProjectContext();
            Account account = (from a in context.Accounts
                               where a.Aid == CurAccount.Aid
                               select a).First();
            if (account != null)
            {
                if (tbOldPass.Text == CurAccount.Password)
                {
                    if(tbNewPass.Text == tbRePass.Text && tbNewPass.Text != "")
                    {
                        account.Password = tbNewPass.Text;
                        context.SaveChanges();
                        MessageBox.Show("Đã đổi mật khẩu");
                        this.Close();
                    } else
                    {
                        MessageBox.Show("Mật khẩu nhập lại không đúng");
                    }
                } else
                {
                    MessageBox.Show("Mật khẩu sai");
                }
            }
        }

        private void Home_FormClosed(object? sender, FormClosedEventArgs e)
        {
            //PRN_ProjectContext context = new PRN_ProjectContext();
            //Account account = (from a in context.Accounts
            //                   where a.Aid == CurAccount.Aid
            //                   select a).First();
        }
    }
}
