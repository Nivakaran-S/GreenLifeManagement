using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using GreenLifeManagementSystem.Data;

namespace GreenLifeManagementSystem.Forms
{
    public partial class ReportsForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        private int printRowIndex = 0;

        public ReportsForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Please generate a report first before exporting.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printRowIndex = 0;

            printDoc.PrintPage += (s, pe) =>
            {
                Graphics g = pe.Graphics;
                float y = 40;
                float leftMargin = 40;
                float pageWidth = pe.PageBounds.Width - 80;

                string reportTitle = "GreenLife Organic — " + (cmbReportType.SelectedItem?.ToString() ?? "Report");
                Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
                g.DrawString(reportTitle, titleFont, Brushes.Black, leftMargin, y);
                y += 40;

                Font smallFont = new Font("Segoe UI", 9);
                g.DrawString("Generated: " + DateTime.Now.ToString("dd MMM yyyy, hh:mm tt"), smallFont, Brushes.Gray, leftMargin, y);
                y += 30;

                g.DrawLine(new Pen(Color.FromArgb(46, 125, 50), 2), leftMargin, y, leftMargin + pageWidth, y);
                y += 15;

                Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
                Font cellFont = new Font("Segoe UI", 9);
                int colCount = dgvReport.Columns.Count;
                float colWidth = pageWidth / colCount;

                g.FillRectangle(new SolidBrush(Color.FromArgb(46, 125, 50)), leftMargin, y, pageWidth, 25);
                for (int c = 0; c < colCount; c++)
                {
                    g.DrawString(dgvReport.Columns[c].HeaderText, headerFont, Brushes.White, leftMargin + c * colWidth + 5, y + 3);
                }
                y += 28;

                bool alternate = false;
                while (printRowIndex < dgvReport.Rows.Count)
                {
                    if (y > pe.PageBounds.Height - 80)
                    {
                        pe.HasMorePages = true;
                        return;
                    }

                    DataGridViewRow row = dgvReport.Rows[printRowIndex];

                    if (alternate)
                        g.FillRectangle(new SolidBrush(Color.FromArgb(232, 245, 233)), leftMargin, y, pageWidth, 22);

                    for (int c = 0; c < colCount; c++)
                    {
                        string val = row.Cells[c].Value?.ToString() ?? "";
                        g.DrawString(val, cellFont, Brushes.Black, leftMargin + c * colWidth + 5, y + 2);
                    }

                    y += 22;
                    g.DrawLine(Pens.LightGray, leftMargin, y, leftMargin + pageWidth, y);
                    alternate = !alternate;
                    printRowIndex++;
                }

                if (lblSummaryText.Visible)
                {
                    y += 20;
                    g.DrawLine(new Pen(Color.FromArgb(46, 125, 50), 2), leftMargin, y, leftMargin + pageWidth, y);
                    y += 10;
                    Font summaryFont = new Font("Segoe UI", 11, FontStyle.Bold);
                    g.DrawString(lblSummaryText.Text + "  " + lblSummaryValue.Text, summaryFont, new SolidBrush(Color.FromArgb(27, 94, 32)), leftMargin, y);
                }

                pe.HasMorePages = false;
            };

            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 900,
                Height = 700
            };

            preview.ShowDialog();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString();

            lblSummaryText.Visible = false;
            lblSummaryValue.Visible = false;

            try
            {
                string query = "";

                switch (reportType)
                {
                    case "Sales Report (Delivered Orders)":
                        query = @"
                            SELECT 
                                o.OrderID, 
                                u.FullName AS Customer, 
                                o.OrderDate AS Date, 
                                o.TotalAmount 
                            FROM Orders o
                            JOIN Users u ON o.CustomerID = u.UserID
                            WHERE o.Status = 'Delivered'
                            ORDER BY o.OrderDate DESC";

                        DataTable dtSales = db.GetDataTable(query);
                        dgvReport.DataSource = dtSales;

                        if (dgvReport.Columns["TotalAmount"] != null)
                            dgvReport.Columns["TotalAmount"].DefaultCellStyle.Format = "c2";

                        decimal totalRevenue = 0;
                        foreach (DataRow row in dtSales.Rows)
                        {
                            totalRevenue += Convert.ToDecimal(row["TotalAmount"]);
                        }

                        lblSummaryText.Text = "Total Sales Revenue:";
                        lblSummaryValue.Text = "Rs." + totalRevenue.ToString("0.00");
                        lblSummaryText.Visible = true;
                        lblSummaryValue.Visible = true;
                        break;

                    case "Stock Report (Current Inventory)":
                        query = @"
                            SELECT 
                                ProductID, 
                                ProductName, 
                                Category, 
                                StockQuantity 
                            FROM Products 
                            ORDER BY StockQuantity ASC"; // Shows lowest stock first

                        DataTable dtStock = db.GetDataTable(query);
                        dgvReport.DataSource = dtStock;

                        int lowStockCount = 0;
                        foreach (DataRow row in dtStock.Rows)
                        {
                            if (Convert.ToInt32(row["StockQuantity"]) < 10)
                                lowStockCount++;
                        }

                        lblSummaryText.Text = "Items Below Threshold (<10):";
                        lblSummaryValue.Text = lowStockCount.ToString();
                        lblSummaryText.Visible = true;
                        lblSummaryValue.Visible = true;
                        break;

                    case "Customer Order History":
                        query = @"
                            SELECT 
                                u.FullName AS Customer,
                                o.OrderID,  
                                o.OrderDate AS Date, 
                                o.TotalAmount,
                                o.Status 
                            FROM Orders o
                            JOIN Users u ON o.CustomerID = u.UserID
                            ORDER BY u.FullName, o.OrderDate DESC";

                        dgvReport.DataSource = db.GetDataTable(query);

                        if (dgvReport.Columns["TotalAmount"] != null)
                            dgvReport.Columns["TotalAmount"].DefaultCellStyle.Format = "c2";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}