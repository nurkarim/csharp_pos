namespace SuperShop.View.customer
{
    partial class RecordView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_type = new System.Windows.Forms.Label();
            this.txt_global_data = new System.Windows.Forms.Label();
            this.txt_date = new System.Windows.Forms.Label();
            this.txt_date_b = new System.Windows.Forms.Label();
            this.pvDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(964, 604);
            this.dataGridView1.TabIndex = 0;
            // 
            // txt_type
            // 
            this.txt_type.AutoSize = true;
            this.txt_type.Location = new System.Drawing.Point(41, 1);
            this.txt_type.Name = "txt_type";
            this.txt_type.Size = new System.Drawing.Size(35, 13);
            this.txt_type.TabIndex = 1;
            this.txt_type.Text = "label1";
            this.txt_type.Visible = false;
            // 
            // txt_global_data
            // 
            this.txt_global_data.AutoSize = true;
            this.txt_global_data.Location = new System.Drawing.Point(87, 1);
            this.txt_global_data.Name = "txt_global_data";
            this.txt_global_data.Size = new System.Drawing.Size(35, 13);
            this.txt_global_data.TabIndex = 2;
            this.txt_global_data.Text = "label1";
            this.txt_global_data.Visible = false;
            // 
            // txt_date
            // 
            this.txt_date.AutoSize = true;
            this.txt_date.Location = new System.Drawing.Point(135, 2);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(35, 13);
            this.txt_date.TabIndex = 3;
            this.txt_date.Text = "label1";
            this.txt_date.Visible = false;
            // 
            // txt_date_b
            // 
            this.txt_date_b.AutoSize = true;
            this.txt_date_b.Location = new System.Drawing.Point(189, 0);
            this.txt_date_b.Name = "txt_date_b";
            this.txt_date_b.Size = new System.Drawing.Size(35, 13);
            this.txt_date_b.TabIndex = 4;
            this.txt_date_b.Text = "label1";
            this.txt_date_b.Visible = false;
            // 
            // pvDialog
            // 
            this.pvDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.pvDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.pvDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.pvDialog.Enabled = true;
            this.pvDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("pvDialog.Icon")));
            this.pvDialog.Name = "pvDialog";
            this.pvDialog.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 612);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 650);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_date_b);
            this.Controls.Add(this.txt_date);
            this.Controls.Add(this.txt_global_data);
            this.Controls.Add(this.txt_type);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "RecordView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecordView";
            this.Load += new System.EventHandler(this.RecordView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label txt_type;
        private System.Windows.Forms.Label txt_global_data;
        private System.Windows.Forms.Label txt_date;
        private System.Windows.Forms.Label txt_date_b;
        private System.Windows.Forms.PrintPreviewDialog pvDialog;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button1;
    }
}