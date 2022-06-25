namespace SuperShop.CrystalReport.customer
{
    partial class ReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txt_type = new System.Windows.Forms.Label();
            this.txt_global_data = new System.Windows.Forms.Label();
            this.txt_date = new System.Windows.Forms.Label();
            this.txt_date_b = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1065, 591);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // txt_type
            // 
            this.txt_type.AutoSize = true;
            this.txt_type.Location = new System.Drawing.Point(26, 44);
            this.txt_type.Name = "txt_type";
            this.txt_type.Size = new System.Drawing.Size(35, 13);
            this.txt_type.TabIndex = 1;
            this.txt_type.Text = "label1";
            this.txt_type.Visible = false;
            // 
            // txt_global_data
            // 
            this.txt_global_data.AutoSize = true;
            this.txt_global_data.Location = new System.Drawing.Point(67, 44);
            this.txt_global_data.Name = "txt_global_data";
            this.txt_global_data.Size = new System.Drawing.Size(35, 13);
            this.txt_global_data.TabIndex = 2;
            this.txt_global_data.Text = "label2";
            this.txt_global_data.Visible = false;
            // 
            // txt_date
            // 
            this.txt_date.AutoSize = true;
            this.txt_date.Location = new System.Drawing.Point(108, 44);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(35, 13);
            this.txt_date.TabIndex = 3;
            this.txt_date.Text = "label3";
            this.txt_date.Visible = false;
            // 
            // txt_date_b
            // 
            this.txt_date_b.AutoSize = true;
            this.txt_date_b.Location = new System.Drawing.Point(149, 44);
            this.txt_date_b.Name = "txt_date_b";
            this.txt_date_b.Size = new System.Drawing.Size(35, 13);
            this.txt_date_b.TabIndex = 4;
            this.txt_date_b.Text = "label1";
            this.txt_date_b.Visible = false;
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 591);
            this.Controls.Add(this.txt_date_b);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.txt_global_data);
            this.Controls.Add(this.txt_type);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "ReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label txt_type;
        private System.Windows.Forms.Label txt_global_data;
        private System.Windows.Forms.Label txt_date;
        private System.Windows.Forms.Label txt_date_b;
    }
}