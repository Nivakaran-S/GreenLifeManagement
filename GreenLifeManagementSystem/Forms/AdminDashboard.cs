using System;
using System.Data;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;

namespace GreenLifeManagementSystem.Forms
{
    public partial class AdminDashboard : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public AdminDashboard()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                string productQuery = "SELECT COUNT(*) FROM Products";
                DataTable dtProducts = db.GetDataTable(productQuery);
                if (dtProducts.Rows.Count > 0)
                {
                    lblTotalProducts.Text = dtProducts.Rows[0][0].ToString();
                }

                string orderQuery = "SELECT COUNT(*) FROM Orders WHERE Status = 'Pending'";
                DataTable dtOrders = db.GetDataTable(orderQuery);
                if (dtOrders.Rows.Count > 0)
                {
                    lblPendingOrders.Text = dtOrders.Rows[0][0].ToString();
                }

                string lowStockQuery = "SELECT COUNT(*) FROM Products WHERE StockQuantity < 10";
                DataTable dtLowStock = db.GetDataTable(lowStockQuery);
                if (dtLowStock.Rows.Count > 0)
                {
                    lblLowStock.Text = dtLowStock.Rows[0][0].ToString();
                }

                LoadRecentOrders();
                LoadLowStockProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Could not load all dashboard metrics. If you haven't created the Orders table yet, some data will be missing.\n\nDetails: " + ex.Message,
                                "Dashboard Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadRecentOrders()
        {
            try
            {
                string query = @"
                    SELECT TOP 10
                        o.OrderID AS [Order],
                        u.FullName AS [Customer],
                        o.TotalAmount AS [Total],
                        o.Status
                    FROM Orders o
                    INNER JOIN Users u ON o.CustomerID = u.UserID
                    ORDER BY o.OrderDate DESC";

                DataTable dt = db.GetDataTable(query);
                dgvRecentOrders.DataSource = dt;

                if (dgvRecentOrders.Columns["Total"] != null)
                    dgvRecentOrders.Columns["Total"].DefaultCellStyle.Format = "c2";
            }
            catch (Exception)
            {
            }
        }

        private void LoadLowStockProducts()
        {
            try
            {
                string query = @"
                    SELECT 
                        ProductName AS [Product],
                        Category,
                        StockQuantity AS [Stock]
                    FROM Products
                    WHERE StockQuantity < 10
                    ORDER BY StockQuantity ASC";

                DataTable dt = db.GetDataTable(query);
                dgvLowStockProducts.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            ProductManagementForm productForm = new ProductManagementForm();
            productForm.ShowDialog();

            LoadDashboardData();
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            OrderManagementForm orderForm = new OrderManagementForm();
            orderForm.ShowDialog();

            LoadDashboardData();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            CustomerManagementForm customerForm = new CustomerManagementForm();
            customerForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}