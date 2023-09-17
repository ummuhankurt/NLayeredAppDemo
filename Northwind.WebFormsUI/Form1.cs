using Entities.Concrete;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependencyResolvers.Autofac;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.NHibernite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IProductService _productService = InstanceFactory.GetInstance<IProductService>();
        ICategoryService _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }
        private void LoadProducts()
        {
            dgwProdcut.DataSource = _productService.GetAll();

        }
        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategory2.DataSource = _categoryService.GetAll();
            cbxCategory2.DisplayMember = "CategoryName";
            cbxCategory2.ValueMember = "CategoryId";

            cbxUpdateCategoryId.DataSource = _categoryService.GetAll();
            cbxUpdateCategoryId.DisplayMember = "CategoryName";
            cbxUpdateCategoryId.ValueMember = "CategoryId";

        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProdcut.DataSource = _productService.GetProductsByCategoryId(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtProductName.Text))
            {
                dgwProdcut.DataSource = _productService.GetProductsByProductName(txtProductName.Text);
            }
            else
            {
                LoadProducts();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product()
                {
                    CategoryId = Convert.ToInt32(cbxCategory2.SelectedValue),
                    ProductName = txtPoductName2.Text,
                    QuantityPerUnit = txtQuantityPerUnit.Text,
                    UnitPrice = Convert.ToDecimal(txtUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(txtUnitsInStock.Text)
                };
                _productService.Add(product);
                MessageBox.Show("Ürün Eklendi !");
                LoadProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product()
                {
                    ProductId = Convert.ToInt32(dgwProdcut.CurrentRow.Cells[0].Value),
                    CategoryId = Convert.ToInt32(cbxUpdateCategoryId.SelectedValue),
                    ProductName = txtUpdateProductName.Text,
                    QuantityPerUnit = txtUpdateQuantityPerUnit.Text,
                    UnitPrice = Convert.ToDecimal(txtUpdateUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(txtUpdateUnitsInStock.Text)

                };
                _productService.Update(product);
                MessageBox.Show("Ürün Güncellendi !");
                LoadProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgwProdcut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxUpdateCategoryId.SelectedValue = dgwProdcut.CurrentRow.Cells[1].Value;
            txtUpdateProductName.Text = dgwProdcut.CurrentRow.Cells[2].Value.ToString();
            txtUpdateUnitPrice.Text = dgwProdcut.CurrentRow.Cells[3].Value.ToString();
            txtUpdateQuantityPerUnit.Text = dgwProdcut.CurrentRow.Cells[4].Value.ToString();
            txtUpdateUnitsInStock.Text = dgwProdcut.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object  sender, EventArgs e)
        {
            try
            {
                if (dgwProdcut.CurrentRow != null)
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProdcut.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("Ürün Silindi !");
                    LoadProducts();
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

        }

        
    }
}
