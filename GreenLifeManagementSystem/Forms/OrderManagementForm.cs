using System;
using System.Data;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;

namespace GreenLifeManagementSystem.Forms
{
    public partial class OrderManagementForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public OrderManagementForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders(string filter = "")
        {
            try
            {
                string query = @"
                    SELECT 
                        o.OrderID, 
                        u.FullName AS CustomerName, 
                        o.OrderDate AS Date, 
                        o.TotalAmount, 
                        o.Status 
                    FROM Orders o
                    INNER JOIN Users u ON o.CustomerID = u.UserID";

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    query += $" WHERE u.FullName LIKE '%{filter}%' OR o.Status LIKE '%{filter}%'";
                }

                DataTable dt = db.GetDataTable(query);
                dgvOrders.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrders(txtSearch.Text);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                if (cmbUpdateStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please select a new status from the dropdown menu.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newStatus = cmbUpdateStatus.SelectedItem.ToString();

                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

                try
                {
                    string query = $"UPDATE Orders SET Status = '{newStatus}' WHERE OrderID = {orderId}";
                    db.ExecuteQuery(query);

                    MessageBox.Show($"Order #{orderId} successfully updated to {newStatus}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadOrders(txtSearch.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an order from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}