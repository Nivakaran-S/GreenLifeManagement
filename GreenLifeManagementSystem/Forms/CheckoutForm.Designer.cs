namespace GreenLifeManagementSystem.Forms
{
    partial class CheckoutForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnBackToStore = new System.Windows.Forms.Button();
            this.btnConfirmCheckout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Review Your Cart";
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(20, 70);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 29;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(760, 250);
            this.dgvCart.TabIndex = 1;
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalText.Location = new System.Drawing.Point(540, 340);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(148, 28);
            this.lblTotalText.TabIndex = 2;
            this.lblTotalText.Text = "Total Amount:";
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalAmount.Location = new System.Drawing.Point(690, 335);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(90, 35);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "Rs.0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClearCart.Location = new System.Drawing.Point(20, 390);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(110, 40);
            this.btnClearCart.TabIndex = 4;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            this.btnConfirmCheckout.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmCheckout.Location = new System.Drawing.Point(610, 390);
            this.btnConfirmCheckout.Name = "btnConfirmCheckout";
            this.btnConfirmCheckout.Size = new System.Drawing.Size(170, 40);
            this.btnConfirmCheckout.TabIndex = 5;
            this.btnConfirmCheckout.Text = "Confirm Checkout";
            this.btnConfirmCheckout.UseVisualStyleBackColor = true;
            this.btnConfirmCheckout.Click += new System.EventHandler(this.btnConfirmCheckout_Click);
            this.btnBackToStore.Location = new System.Drawing.Point(150, 390);
            this.btnBackToStore.Name = "btnBackToStore";
            this.btnBackToStore.Size = new System.Drawing.Size(150, 40);
            this.btnBackToStore.TabIndex = 6;
            this.btnBackToStore.Text = "? Back to Store";
            this.btnBackToStore.UseVisualStyleBackColor = true;
            this.btnBackToStore.Click += new System.EventHandler(this.btnBackToStore_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBackToStore);
            this.Controls.Add(this.btnConfirmCheckout);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalText);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.lblTitle);
            this.Name = "CheckoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shopping Cart & Checkout";
            this.Load += new System.EventHandler(this.CheckoutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnBackToStore;
        private System.Windows.Forms.Button btnConfirmCheckout;
    }
}