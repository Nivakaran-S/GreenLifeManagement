using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;

namespace GreenLifeManagementSystem.Forms
{
    public class OrderReceiptForm : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int orderId;
        private DataGridView dgvItems;
        private Label lblOrderId, lblDate, lblStatus, lblTotalLabel, lblTotalValue;
        private Button btnPrint, btnClose;
        private Panel pnlHeader, pnlFooter;

        public OrderReceiptForm(int orderId)
        {
            this.orderId = orderId;
            InitializeReceiptForm();
            LoadReceiptData();
        }

        private void InitializeReceiptForm()
        {
            this.Text = $"Receipt - Order #{orderId}";
            this.Size = new Size(550, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.FromArgb(34, 139, 34),
                Padding = new Padding(15)
            };

            Label lblTitle = new Label
            {
                Text = "GreenLife Organic",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 10)
            };

            lblOrderId = new Label
            {
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 45)
            };

            lblDate = new Label
            {
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.WhiteSmoke,
                AutoSize = true,
                Location = new Point(15, 70)
            };

            lblStatus = new Label
            {
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.LightYellow,
                AutoSize = true,
                Location = new Point(350, 45)
            };

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblOrderId);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblStatus);
            this.Controls.Add(pnlHeader);

            dgvItems = new DataGridView
            {
                Location = new Point(15, 125),
                Size = new Size(505, 230),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(34, 139, 34),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9)
                },
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false
            };
            this.Controls.Add(dgvItems);

            lblTotalLabel = new Label
            {
                Text = "Order Total:",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(250, 370),
                AutoSize = true
            };

            lblTotalValue = new Label
            {
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 139, 34),
                Location = new Point(400, 370),
                AutoSize = true
            };

            this.Controls.Add(lblTotalLabel);
            this.Controls.Add(lblTotalValue);

            btnPrint = new Button
            {
                Text = "Print Receipt",
                Size = new Size(120, 35),
                Location = new Point(270, 415),
                BackColor = Color.FromArgb(34, 139, 34),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10)
            };
            btnPrint.Click += BtnPrint_Click;

            btnClose = new Button
            {
                Text = "Close",
                Size = new Size(100, 35),
                Location = new Point(400, 415),
                Font = new Font("Segoe UI", 10)
            };
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(btnPrint);
            this.Controls.Add(btnClose);
        }

        private void LoadReceiptData()
        {
            try
            {
                string orderQuery = $@"
                    SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.Status, u.FullName
                    FROM Orders o
                    INNER JOIN Users u ON o.CustomerID = u.UserID
                    WHERE o.OrderID = {orderId}";

                DataTable dtOrder = db.GetDataTable(orderQuery);

                if (dtOrder.Rows.Count > 0)
                {
                    DataRow row = dtOrder.Rows[0];
                    lblOrderId.Text = $"Order #{orderId}  |  Customer: {row["FullName"]}";
                    lblDate.Text = $"Date: {Convert.ToDateTime(row["OrderDate"]):dd MMM yyyy, hh:mm tt}";
                    lblStatus.Text = $"Status: {row["Status"]}";
                    lblTotalValue.Text = "Rs." + Convert.ToDecimal(row["TotalAmount"]).ToString("0.00");
                }

                string detailsQuery = $@"
                    SELECT 
                        p.ProductName AS [Product],
                        od.Quantity AS [Qty],
                        CAST(od.SubTotal / od.Quantity AS DECIMAL(10,2)) AS [Unit Price],
                        od.SubTotal AS [Sub-Total]
                    FROM ORDER_DETAILS od
                    INNER JOIN Products p ON od.ProductID = p.ProductID
                    WHERE od.OrderID = {orderId}";

                DataTable dtDetails = db.GetDataTable(detailsQuery);
                dgvItems.DataSource = dtDetails;

                if (dgvItems.Columns["Unit Price"] != null)
                    dgvItems.Columns["Unit Price"].DefaultCellStyle.Format = "c2";
                if (dgvItems.Columns["Sub-Total"] != null)
                    dgvItems.Columns["Sub-Total"].DefaultCellStyle.Format = "c2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, pe) =>
            {
                Graphics g = pe.Graphics;
                Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
                Font headerFont = new Font("Segoe UI", 11, FontStyle.Bold);
                Font bodyFont = new Font("Segoe UI", 10);
                int y = 30;

                g.DrawString("GreenLife Organic - Receipt", titleFont, Brushes.DarkGreen, 50, y);
                y += 40;
                g.DrawLine(Pens.DarkGreen, 50, y, 550, y);
                y += 15;

                g.DrawString(lblOrderId.Text, headerFont, Brushes.Black, 50, y); y += 25;
                g.DrawString(lblDate.Text, bodyFont, Brushes.Black, 50, y); y += 25;
                g.DrawString(lblStatus.Text, bodyFont, Brushes.Black, 50, y); y += 30;
                g.DrawLine(Pens.Gray, 50, y, 550, y);
                y += 15;

                g.DrawString("Product", headerFont, Brushes.Black, 50, y);
                g.DrawString("Qty", headerFont, Brushes.Black, 300, y);
                g.DrawString("Price", headerFont, Brushes.Black, 370, y);
                g.DrawString("Sub-Total", headerFont, Brushes.Black, 460, y);
                y += 25;

                if (dgvItems.DataSource is DataTable dt)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        g.DrawString(row["Product"].ToString(), bodyFont, Brushes.Black, 50, y);
                        g.DrawString(row["Qty"].ToString(), bodyFont, Brushes.Black, 310, y);
                        g.DrawString(Convert.ToDecimal(row["Unit Price"]).ToString("c2"), bodyFont, Brushes.Black, 370, y);
                        g.DrawString(Convert.ToDecimal(row["Sub-Total"]).ToString("c2"), bodyFont, Brushes.Black, 460, y);
                        y += 22;
                    }
                }

                y += 10;
                g.DrawLine(Pens.DarkGreen, 50, y, 550, y);
                y += 15;
                g.DrawString("Total: " + lblTotalValue.Text, titleFont, Brushes.DarkGreen, 350, y);
            };

            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };
            preview.ShowDialog();
        }
    }
}