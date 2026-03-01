using System;
using System.Data;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;

namespace GreenLifeManagementSystem.Forms
{
    public partial class ProductManagementForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        int selectedProductId = 0; // Keeps track of which product the admin clicked on in the grid

        public ProductManagementForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                string query = "SELECT ProductID, ProductName, Category, UnitPrice, StockQuantity FROM Products";
                DataTable dt = db.GetDataTable(query);
                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    string name = txtProductName.Text;
                    string category = cmbCategory.SelectedItem?.ToString() ?? "";
                    decimal price = Convert.ToDecimal(txtPrice.Text);
                    int stock = Convert.ToInt32(txtStock.Text);

                    string query = $"INSERT INTO Products (ProductName, Category, UnitPrice, StockQuantity) VALUES ('{name}', '{category}', {price}, {stock})";
                    db.ExecuteQuery(query);

                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadProducts();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Price or Stock format. Please enter numeric values.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProductId > 0 && ValidateInputs())
            {
                try
                {
                    string name = txtProductName.Text;
                    string category = cmbCategory.SelectedItem?.ToString() ?? "";
                    decimal price = Convert.ToDecimal(txtPrice.Text);
                    int stock = Convert.ToInt32(txtStock.Text);

                    string query = $"UPDATE Products SET ProductName='{name}', Category='{category}', UnitPrice={price}, StockQuantity={stock} WHERE ProductID={selectedProductId}";
                    db.ExecuteQuery(query);

                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadProducts();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Price or Stock format. Please enter numeric values.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product from the list below to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = $"DELETE FROM Products WHERE ProductID={selectedProductId}";
                        db.ExecuteQuery(query);

                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product from the list below to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);

                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                cmbCategory.Text = row.Cells["Category"].Value.ToString();
                txtPrice.Text = row.Cells["UnitPrice"].Value.ToString();
                txtStock.Text = row.Cells["StockQuantity"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            selectedProductId = 0;
            txtProductName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            cmbCategory.SelectedIndex = -1;
        }
    }
}