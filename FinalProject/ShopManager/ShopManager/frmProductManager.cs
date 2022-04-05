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
    public partial class frmProductManager : Form
    {
        public frmProductManager()
        {
            InitializeComponent();
        }
        private void frmProductManager_Load(object sender, EventArgs e)
        {
            DesignDataGridView();
            LoadCategoryToCombobox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddNew frmAddNew = new frmAddNew();
            frmAddNew.ShowDialog();
            LoadToDatagridview();
        }

        private void LoadCategoryToCombobox()
        {
            PRN_ProjectContext context = new PRN_ProjectContext();
            List<ProductCategory> cate = (from c in context.ProductCategories select c).ToList();
            cate.Insert(0, new ProductCategory("Danh mục"));
            cbCate.DisplayMember = "Cname";
            cbCate.ValueMember = "Cid";
            cbCate.DataSource = cate;
        }

        private void DesignDataGridView()
        {
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.Columns.Add("Pid", "ID");
            dgvProduct.Columns["Pid"].DataPropertyName = "Pid";
            dgvProduct.Columns.Add("Pname", "Tên sản phẩm");
            dgvProduct.Columns["Pname"].DataPropertyName = "Pname";
            dgvProduct.Columns.Add("Price", "Giá");
            dgvProduct.Columns["Price"].DataPropertyName = "Price";
            dgvProduct.Columns.Add("Cname", "Danh mục");
            dgvProduct.Columns["Cname"].DataPropertyName = "Cname";
            DataGridViewButtonColumn editcol = new DataGridViewButtonColumn();
            editcol.HeaderText = "Sửa";
            editcol.Name = "editcol";
            editcol.Text = "Sửa";
            editcol.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn deletecol = new DataGridViewButtonColumn();
            deletecol.HeaderText = "Xóa";
            deletecol.Name = "detelecol";
            deletecol.Text = "Xóa";
            deletecol.UseColumnTextForButtonValue = true;
            dgvProduct.Columns.Add(editcol);
            dgvProduct.Columns.Add(deletecol);
        }

        private void LoadToDatagridview()
        {
            int cid = Convert.ToInt32(cbCate.SelectedValue);
            PRN_ProjectContext context = new PRN_ProjectContext();
            //var products;
            if (cid == 0)
            {
                var products = (from p in context.Products
                            join c in context.ProductCategories
                            on p.Cid equals c.Cid
                            select new
                            {
                                Cname = c.Cname,
                                Pname = p.Pname,
                                Price = p.Price,
                                Pid = p.Pid
                            }).ToList();
                dgvProduct.DataSource = products;
            }
            else
            {
                var products = (from p in context.Products
                                join c in context.ProductCategories
                                on p.Cid equals c.Cid
                                where p.Cid == cid
                            select new
                            {
                                Cname = c.Cname,
                                Pname = p.Pname,
                                Price = p.Price,
                                Pid = p.Pid
                            }).ToList();
                dgvProduct.DataSource = products;
            }
        }

        private void Search()
        {
            if(tbSearch.Text == "")
            {
                PRN_ProjectContext context = new PRN_ProjectContext();
                List<Product> products = (from p in context.Products select p).ToList();
                dgvProduct.DataSource=products;
            } else
            {
                PRN_ProjectContext context = new PRN_ProjectContext();
                List<Product> products = (from p in context.Products
                                          where p.Pname.ToUpper().Contains(tbSearch.Text.ToUpper())
                                          select p).ToList();
                dgvProduct.DataSource = products;
            }
        }

        private void cbCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadToDatagridview();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.Columns[e.ColumnIndex].Name.Equals("editcol"))
            {
                //(neu ko luu san thi co the unbox tu datasource ra) List<Student> students = (List<Student>)dataGridView1.DataSource;
                //int ProductId = (int)dgvProduct.Rows[e.RowIndex].Cells["Pid"].Value;
                //PRN_ProjectContext context = new PRN_ProjectContext();
                //Product CurProduct = (from p in context.Products
                //                      where p.Pid == ProductId
                //                      select p).First();
                //ProductCategory cate = (from c in context.ProductCategories
                //                        where c.Cid == CurProduct.Cid select c).First();
                //CurProduct.CidNavigation = cate;
                //frmAddNew editform = new frmAddNew(CurProduct);
                //editform.FormClosed += frmAddNew_Close;
                //editform.Show();
                //LoadToDatagridview();
            }
            else if (dgvProduct.Columns[e.ColumnIndex].Name.Equals("detelecol"))
            {
                //co the lay du lieu tu truc tiep tren DataGridView: String StudentName = dataGridView1.Rows[e.RowIndex].Cells["fullname"].Value.ToString();
                int ProductId = (int)dgvProduct.Rows[e.RowIndex].Cells["Pid"].Value;
                DialogResult result = MessageBox.Show($"Bạn có thực sự muốn xóa {dgvProduct.Rows[e.RowIndex].Cells["Pname"].Value}?",
                    "Xac nhan!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PRN_ProjectContext context = new PRN_ProjectContext();
                    Product DelPro = (from p in context.Products
                                  where p.Pid == ProductId
                                      select p).First();
                    context.Products.Remove(DelPro);
                    context.SaveChanges();
                    LoadToDatagridview();
                }
            }
        }

        private void quảnLýĐơnHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmOrderManager frmOrderManager = new frmOrderManager();
            this.Hide();
            frmOrderManager.ShowDialog();
            this.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAccountManager frmAccountManager = new frmAccountManager();
            this.Hide();
            frmAccountManager.ShowDialog();
            this.Show();
        }

    }
}
