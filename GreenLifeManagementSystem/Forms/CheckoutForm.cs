using System;
using System.Data;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;
using GreenLifeManagementSystem.Models;

namespace GreenLifeManagementSystem.Forms
{
    public partial class CheckoutForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        decimal totalAmount = 0;

        public CheckoutForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            LoadCartData();
        }

        private void LoadCartData()
        {
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add("ProductName", "Product Details");
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns.Add("UnitPrice", "Unit Price");
            dgvCart.Columns.Add("SubTotal", "Sub-Total");

            totalAmount = 0;

            foreach (var item in CustomerStorefront.ShoppingCart)
            {
                Product p = item.Key;
                int qty = item.Value;
                decimal subTotal = p.UnitPrice * qty;
                totalAmount += subTotal;

                dgvCart.Rows.Add(p.ProductName, qty, "Rs." + p.UnitPrice.ToString("0.00"), "Rs." + subTotal.ToString("0.00"));
            }

            lblTotalAmount.Text = "Rs." + totalAmount.ToString("0.00");

            btnConfirmCheckout.Enabled = CustomerStorefront.ShoppingCart.Count > 0;
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            CustomerStorefront.ShoppingCart.Clear();
            LoadCartData();
            MessageBox.Show("Your cart has been cleared.", "Cart Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackToStore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId = 1;
                DataTable dtCust = db.GetDataTable("SELECT TOP 1 UserID FROM Users WHERE UserRole = 'Customer'");
                if (dtCust.Rows.Count > 0)
                {
                    customerId = Convert.ToInt32(dtCust.Rows[0]["UserID"]);
                }

                string orderQuery = $"INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, Status) VALUES ({customerId}, GETDATE(), {totalAmount}, 'Pending'); SELECT SCOPE_IDENTITY();";
                DataTable dtOrder = db.GetDataTable(orderQuery);
                int newOrderId = Convert.ToInt32(dtOrder.Rows[0][0]);

                foreach (var item in CustomerStorefront.ShoppingCart)
                {
                    Product p = item.Key;
                    int qty = item.Value;
                    decimal subTotal = p.UnitPrice * qty;

                    string detailQuery = $"INSERT INTO ORDER_DETAILS (OrderID, ProductID, Quantity, SubTotal) VALUES ({newOrderId}, {p.ProductID}, {qty}, {subTotal})";
                    db.ExecuteQuery(detailQuery);

                    string stockQuery = $"UPDATE Products SET StockQuantity = StockQuantity - {qty} WHERE ProductID = {p.ProductID}";
                    db.ExecuteQuery(stockQuery);
                }

                MessageBox.Show($"Checkout successful! Your Order ID is #{newOrderId}. The Admin will process it shortly.", "Order Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CustomerStorefront.ShoppingCart.Clear();
                this.DialogResult = DialogResult.OK; // Signals the Storefront to refresh
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during checkout: " + ex.Message, "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}