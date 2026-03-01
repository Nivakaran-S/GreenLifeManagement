namespace GreenLifeManagementSystem.Forms
{
    partial class CustomerStorefront
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            btnLogout = new Button();
            lblTitle = new Label();
            btnCart = new Button();
            btnMyOrders = new Button();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            flpProducts = new FlowLayoutPanel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnCart);
            panelHeader.Controls.Add(btnMyOrders);
            panelHeader.Controls.Add(cmbCategory);
            panelHeader.Controls.Add(lblCategory);
            panelHeader.Controls.Add(txtSearch);
            panelHeader.Controls.Add(lblSearch);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 100);
            panelHeader.TabIndex = 0;
            btnLogout.Location = new Point(20, 55);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(125, 31);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Storefront";
            btnCart.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnCart.Location = new Point(820, 45);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(150, 40);
            btnCart.TabIndex = 4;
            btnCart.Text = "Cart Items: 0";
            btnCart.UseVisualStyleBackColor = true;
            btnCart.Click += btnCart_Click;
            btnMyOrders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMyOrders.Location = new Point(820, 10);
            btnMyOrders.Name = "btnMyOrders";
            btnMyOrders.Size = new Size(150, 30);
            btnMyOrders.TabIndex = 7;
            btnMyOrders.Text = "My Orders";
            btnMyOrders.UseVisualStyleBackColor = true;
            btnMyOrders.Click += btnMyOrders_Click;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "All", "Vegetables", "Fruits", "Dairy", "Pantry", "Beverages" });
            cmbCategory.Location = new Point(620, 45);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(170, 28);
            cmbCategory.TabIndex = 3;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(540, 50);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            txtSearch.Location = new Point(260, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search products...";
            txtSearch.Size = new Size(260, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(190, 50);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            flpProducts.AutoScroll = true;
            flpProducts.Dock = DockStyle.Fill;
            flpProducts.Location = new Point(0, 100);
            flpProducts.Name = "flpProducts";
            flpProducts.Padding = new Padding(20);
            flpProducts.Size = new Size(1000, 600);
            flpProducts.TabIndex = 1;
            flpProducts.Paint += flpProducts_Paint;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 700);
            Controls.Add(flpProducts);
            Controls.Add(panelHeader);
            Name = "CustomerStorefront";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GreenLife Organic - Store";
            Load += CustomerStorefront_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnMyOrders;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
    }
}