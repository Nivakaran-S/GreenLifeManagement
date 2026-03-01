using System;
using System.Data;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;

namespace GreenLifeManagementSystem.Forms
{
    public partial class CustomerOrderHistoryForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public CustomerOrderHistoryForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void CustomerOrderHistoryForm_Load(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0; // Default filter to "All Orders"
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            try
            {
                int customerId = 1;
                DataTable dtCust = db.GetDataTable("SELECT TOP 1 UserID FROM Users WHERE UserRole = 'Customer'");
                if (dtCust.Rows.Count > 0)
                {
                    customerId = Convert.ToInt32(dtCust.Rows[0]["UserID"]);
                }

                string statusFilter = cmbFilterStatus.SelectedItem?.ToString() ?? "All Orders";

                string query = $@"
                    SELECT 
                        OrderID AS [Order ID], 
                        OrderDate AS [Date], 
                        TotalAmount AS [Total], 
                        Status 
                    FROM Orders 
                    WHERE CustomerID = {customerId}";

                if (statusFilter != "All Orders")
                {
                    query += $" AND Status = '{statusFilter}'";
                }

                query += " ORDER BY OrderDate DESC";

                DataTable dt = db.GetDataTable(query);
                dgvOrders.DataSource = dt;

                if (dgvOrders.Columns["ViewDetails"] == null)
                {
                    DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                    btnCol.Name = "ViewDetails";
                    btnCol.HeaderText = "Action";
                    btnCol.Text = "View Details";
                    btnCol.UseColumnTextForButtonValue = true;
                    dgvOrders.Columns.Add(btnCol);
                }

                if (dgvOrders.Columns["Total"] != null)
                {
                    dgvOrders.Columns["Total"].DefaultCellStyle.Format = "c2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order history: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.Columns[e.ColumnIndex].Name == "ViewDetails")
            {
                int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["Order ID"].Value);

                OrderReceiptForm receiptForm = new OrderReceiptForm(orderId);
                receiptForm.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Return to storefront
        }
    }
}