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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            PRN_ProjectContext context = new PRN_ProjectContext();
            string email = tbEmail.Text;
            string password = tbPass.Text;
            if(Login(email, password))
            {
                Account CurAcc = (from a in context.Accounts
                                  where a.Email.Equals(email) && a.Password.Equals(password)
                                  select a).First();
                frmHome frmHome = new frmHome(CurAcc);
                this.Hide();
                frmHome.ShowDialog();
                this.Show();
            } else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
            
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát?", "Thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private bool Login(string email, string password)
        {
            PRN_ProjectContext context = new PRN_ProjectContext();
            var login = (from a in context.Accounts
                         where a.Email.Equals(email) && a.Password.Equals(password)
                         select a).FirstOrDefault();
            if (login != null) return true; 
            else return false;
        }
    }
}
