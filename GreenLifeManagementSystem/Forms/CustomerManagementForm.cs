using System;
using System.Data;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;

namespace GreenLifeManagementSystem.Forms
{
    public partial class CustomerManagementForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        int selectedUserId = 0;

        public CustomerManagementForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                string query = "SELECT UserID, FullName, Username, Address FROM Users WHERE UserRole = 'Customer'";
                DataTable dt = db.GetDataTable(query);
                dgvCustomers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId > 0)
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Full Name and Address are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string query = $"UPDATE Users SET FullName='{txtFullName.Text}', Address='{txtAddress.Text}' WHERE UserID={selectedUserId}";
                    db.ExecuteQuery(query);

                    MessageBox.Show("Customer details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer from the grid to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer account? This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = $"DELETE FROM Users WHERE UserID={selectedUserId}";
                        db.ExecuteQuery(query);

                        MessageBox.Show("Customer account deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting customer (they may have existing orders tied to their account): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer from the grid to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedUserId = 0;
            txtFullName.Clear();
            txtUsername.Clear();
            txtAddress.Clear();
        }
    }
}