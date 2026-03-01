namespace GreenLifeManagementSystem.Forms
{
    partial class ReportsForm
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
            this.lblSelectReport = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblSummaryText = new System.Windows.Forms.Label();
            this.lblSummaryValue = new System.Windows.Forms.Label();
            this.btnExportPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "System Reports";
            this.lblSelectReport.AutoSize = true;
            this.lblSelectReport.Location = new System.Drawing.Point(20, 80);
            this.lblSelectReport.Name = "lblSelectReport";
            this.lblSelectReport.Size = new System.Drawing.Size(135, 20);
            this.lblSelectReport.TabIndex = 1;
            this.lblSelectReport.Text = "Select Report Type:";
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Sales Report (Delivered Orders)",
            "Stock Report (Current Inventory)",
            "Customer Order History"});
            this.cmbReportType.Location = new System.Drawing.Point(170, 75);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(300, 28);
            this.cmbReportType.TabIndex = 2;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerate.Location = new System.Drawing.Point(490, 70);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 35);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(20, 130);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 29;
            this.dgvReport.Size = new System.Drawing.Size(840, 380);
            this.dgvReport.TabIndex = 4;
            this.lblSummaryText.AutoSize = true;
            this.lblSummaryText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSummaryText.Location = new System.Drawing.Point(20, 530);
            this.lblSummaryText.Name = "lblSummaryText";
            this.lblSummaryText.Size = new System.Drawing.Size(180, 28);
            this.lblSummaryText.TabIndex = 5;
            this.lblSummaryText.Text = "Report Summary:";
            this.lblSummaryText.Visible = false;
            this.lblSummaryValue.AutoSize = true;
            this.lblSummaryValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSummaryValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSummaryValue.Location = new System.Drawing.Point(210, 530);
            this.lblSummaryValue.Name = "lblSummaryValue";
            this.lblSummaryValue.Size = new System.Drawing.Size(65, 28);
            this.lblSummaryValue.TabIndex = 6;
            this.lblSummaryValue.Text = "Rs.0.00";
            this.lblSummaryValue.Visible = false;
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportPdf.Location = new System.Drawing.Point(660, 70);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(150, 35);
            this.btnExportPdf.TabIndex = 7;
            this.btnExportPdf.Text = "Export to PDF";
            this.btnExportPdf.UseVisualStyleBackColor = true;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 600);
            this.Controls.Add(this.btnExportPdf);
            this.Controls.Add(this.lblSummaryValue);
            this.Controls.Add(this.lblSummaryText);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblSelectReport);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Reports (Admin)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectReport;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblSummaryText;
        private System.Windows.Forms.Label lblSummaryValue;
        private System.Windows.Forms.Button btnExportPdf;
    }
}