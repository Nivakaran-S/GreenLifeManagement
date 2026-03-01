using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;
using GreenLifeManagementSystem.Models;

namespace GreenLifeManagementSystem.Forms
{
    public partial class CustomerStorefront : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        List<Product> allProducts = new List<Product>();

        public static Dictionary<Product, int> ShoppingCart = new Dictionary<Product, int>();

        public CustomerStorefront()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void CustomerStorefront_Load(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0; // Set to "All" by default
            LoadProductsFromDatabase();
            UpdateCartButton();
        }

        private void LoadProductsFromDatabase()
        {
            try
            {
                allProducts.Clear();
                string query = "SELECT ProductID, ProductName, Category, UnitPrice, StockQuantity FROM Products WHERE StockQuantity > 0";
                DataTable dt = db.GetDataTable(query);

                foreach (DataRow row in dt.Rows)
                {
                    Product p = new Product
                    {
                        ProductID = Convert.ToInt32(row["ProductID"]),
                        ProductName = row["ProductName"].ToString(),
                        Category = row["Category"].ToString(),
                        UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                        StockQuantity = Convert.ToInt32(row["StockQuantity"])
                    };
                    allProducts.Add(p);
                }

                DisplayProducts(allProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformLinearSearch()
        {
            string keyword = txtSearch.Text.ToLower().Trim();
            string selectedCategory = cmbCategory.SelectedItem?.ToString() ?? "All";

            List<Product> searchResults = new List<Product>();

            foreach (Product p in allProducts)
            {
                bool matchesKeyword = string.IsNullOrEmpty(keyword) || p.ProductName.ToLower().Contains(keyword);
                bool matchesCategory = selectedCategory == "All" || p.Category == selectedCategory;

                if (matchesKeyword && matchesCategory)
                {
                    searchResults.Add(p);
                }
            }

            DisplayProducts(searchResults);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PerformLinearSearch();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformLinearSearch();
        }

        private void DisplayProducts(List<Product> productsToDisplay)
        {
            flpProducts.Controls.Clear();

            if (productsToDisplay.Count == 0)
            {
                Label lblNoResults = new Label
                {
                    Text = "No products found matching your search.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Margin = new Padding(20)
                };
                flpProducts.Controls.Add(lblNoResults);
                return;
            }

            foreach (Product p in productsToDisplay)
            {
                Panel card = new Panel
                {
                    Width = 220,
                    Height = 260,
                    Margin = new Padding(12),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.None
                };

                card.Paint += (s, pe) =>
                {
                    using (Pen pen = new Pen(Color.FromArgb(200, 230, 201), 2))
                    {
                        pe.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                    }
                };

                card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(245, 255, 245);
                card.MouseLeave += (s, e) => card.BackColor = Color.White;

                PictureBox picBox = new PictureBox
                {
                    Width = 200,
                    Height = 100,
                    Location = new Point(10, 10),
                    BackColor = Color.FromArgb(232, 245, 233),
                    SizeMode = PictureBoxSizeMode.CenterImage
                };

                picBox.Paint += (s, pe) => {
                    pe.Graphics.DrawString("??", new Font("Segoe UI Emoji", 24), Brushes.Green, new PointF(78, 25));
                };

                Label lblName = new Label
                {
                    Text = p.ProductName,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(33, 33, 33),
                    Location = new Point(12, 120),
                    AutoSize = true,
                    MaximumSize = new Size(196, 0)
                };

                Label lblCategory = new Label
                {
                    Text = p.Category,
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.FromArgb(46, 125, 50),
                    BackColor = Color.FromArgb(232, 245, 233),
                    Location = new Point(12, 150),
                    AutoSize = true,
                    Padding = new Padding(4, 2, 4, 2)
                };

                Label lblPrice = new Label
                {
                    Text = "Rs." + p.UnitPrice.ToString("0.00"),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Location = new Point(130, 178),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(27, 94, 32)
                };

                Label lblStock = new Label
                {
                    Text = "Stock: " + p.StockQuantity,
                    Font = new Font("Segoe UI", 8),
                    Location = new Point(12, 182),
                    AutoSize = true,
                    ForeColor = p.StockQuantity < 10 ? Color.FromArgb(211, 47, 47) : Color.FromArgb(117, 117, 117)
                };

                Button btnAddToCart = new Button
                {
                    Text = "Add to Cart",
                    Location = new Point(100, 210),
                    Width = 110,
                    Height = 35,
                    Tag = p,
                    BackColor = Color.FromArgb(46, 125, 50),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnAddToCart.FlatAppearance.BorderSize = 0;
                btnAddToCart.Click += BtnAddToCart_Click;

                btnAddToCart.MouseEnter += (s, e) => btnAddToCart.BackColor = Color.FromArgb(27, 94, 32);
                btnAddToCart.MouseLeave += (s, e) => btnAddToCart.BackColor = Color.FromArgb(46, 125, 50);

                card.Controls.Add(picBox);
                card.Controls.Add(lblName);
                card.Controls.Add(lblCategory);
                card.Controls.Add(lblPrice);
                card.Controls.Add(lblStock);
                card.Controls.Add(btnAddToCart);

                flpProducts.Controls.Add(card);
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            Product selectedProduct = clickedBtn.Tag as Product;

            if (selectedProduct != null)
            {
                bool exists = false;
                foreach (var item in ShoppingCart.Keys)
                {
                    if (item.ProductID == selectedProduct.ProductID)
                    {
                        if (ShoppingCart[item] < selectedProduct.StockQuantity)
                        {
                            ShoppingCart[item]++;
                            MessageBox.Show($"{selectedProduct.ProductName} added to cart!", "Cart Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Cannot add more than available stock.", "Stock Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    ShoppingCart.Add(selectedProduct, 1);
                    MessageBox.Show($"{selectedProduct.ProductName} added to cart!", "Cart Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                UpdateCartButton();
            }
        }

        private void UpdateCartButton()
        {
            int totalItems = 0;
            foreach (int qty in ShoppingCart.Values)
            {
                totalItems += qty;
            }
            btnCart.Text = $"Cart Items: {totalItems}";
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add products before checking out.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CheckoutForm checkout = new CheckoutForm();
            if (checkout.ShowDialog() == DialogResult.OK)
            {
                LoadProductsFromDatabase();
                UpdateCartButton();
            }
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            CustomerOrderHistoryForm historyForm = new CustomerOrderHistoryForm();
            historyForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShoppingCart.Clear(); // Clear cart on logout
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void flpProducts_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}