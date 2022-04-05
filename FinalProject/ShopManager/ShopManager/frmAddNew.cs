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
    public partial class frmAddNew : Form
    {
        public frmAddNew()
        {
            InitializeComponent();
        }

        private void frmAddNew_Load(object sender, EventArgs e)
        {
            PRN_ProjectContext context = new PRN_ProjectContext();
            List<ProductCategory> cate = (from c in context.ProductCategories select c).ToList();
            cbCate.DisplayMember = "Cname";
            cbCate.ValueMember = "Cid";
            cbCate.DataSource = cate;
        }

        private void AddNewProduct()
        {
            Product product = new Product();
            PRN_ProjectContext context = new PRN_ProjectContext();
            if(tbProductName.Text=="" || nudPrice.Value==0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            } else
            {
                product.Pname = tbProductName.Text;
                product.Price = (double)nudPrice.Value;
                product.Cid = Convert.ToInt32(cbCate.SelectedValue);
                context.Products.Add(product);
                context.SaveChanges();
                MessageBox.Show("Đã thêm sản phẩm");
                this.Close();
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            AddNewProduct();
        }
    }
}
