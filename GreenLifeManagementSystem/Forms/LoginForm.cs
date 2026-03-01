using System;
using System.Data;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;

namespace GreenLifeManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public LoginForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbRole.SelectedItem == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem.ToString();

            try
            {
                string query = $"SELECT * FROM Users WHERE Username='{username}' AND Password='{password}' AND UserRole='{role}'";
                DataTable dt = db.GetDataTable(query);

                if (dt.Rows.Count > 0)
                {
                    this.Hide();

                    if (role == "Admin")
                    {
                        AdminDashboard adminForm = new AdminDashboard();
                        adminForm.ShowDialog();
                    }
                    else
                    {
                        CustomerStorefront customerForm = new CustomerStorefront();
                        customerForm.ShowDialog();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials, please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegFullName.Text) ||
                string.IsNullOrWhiteSpace(txtRegUsername.Text) ||
                string.IsNullOrWhiteSpace(txtRegPassword.Text) ||
                string.IsNullOrWhiteSpace(txtRegAddress.Text))
            {
                MessageBox.Show("All fields are required for registration.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = txtRegFullName.Text;
            string username = txtRegUsername.Text;
            string password = txtRegPassword.Text;
            string address = txtRegAddress.Text;

            try
            {
                string checkUserQuery = $"SELECT * FROM Users WHERE Username='{username}'";
                DataTable dtCheck = db.GetDataTable(checkUserQuery);

                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show("That username is already taken. Please choose another.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertQuery = $"INSERT INTO Users (Username, Password, UserRole, FullName, Address) " +
                                     $"VALUES ('{username}', '{password}', 'Customer', '{fullName}', '{address}')";

                db.ExecuteQuery(insertQuery);

                MessageBox.Show("Registration successful! You can now log in using the left panel.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtRegFullName.Clear();
                txtRegUsername.Clear();
                txtRegPassword.Clear();
                txtRegAddress.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}