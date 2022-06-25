namespace SuperShop.View.stock
{
    partial class StockList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_quentity = new System.Windows.Forms.Label();
            this.txt_net_price = new System.Windows.Forms.Label();
            this.txt_purchase = new System.Windows.Forms.Label();
            this.txt_sale = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.txt_brand = new System.Windows.Forms.Label();
            this.txt_category = new System.Windows.Forms.Label();
            this.txt_sub_category = new System.Windows.Forms.Label();
            this.txt_dynamic_date = new System.Windows.Forms.Label();
            this.txt_rack = new System.Windows.Forms.Label();
            this.txt_expdate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 87);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.txt_quentity);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(37, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 71);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.txt_net_price);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(268, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 71);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.txt_purchase);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(498, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 71);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.txt_sale);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(728, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 71);
            this.panel5.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(974, 482);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(835, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quentity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Net Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Purchase Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sale Price";
            // 
            // txt_quentity
            // 
            this.txt_quentity.AutoSize = true;
            this.txt_quentity.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_quentity.Location = new System.Drawing.Point(56, 17);
            this.txt_quentity.Name = "txt_quentity";
            this.txt_quentity.Size = new System.Drawing.Size(59, 24);
            this.txt_quentity.TabIndex = 1;
            this.txt_quentity.Text = "00.00";
            // 
            // txt_net_price
            // 
            this.txt_net_price.AutoSize = true;
            this.txt_net_price.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_net_price.Location = new System.Drawing.Point(16, 17);
            this.txt_net_price.Name = "txt_net_price";
            this.txt_net_price.Size = new System.Drawing.Size(59, 24);
            this.txt_net_price.TabIndex = 2;
            this.txt_net_price.Text = "00.00";
            // 
            // txt_purchase
            // 
            this.txt_purchase.AutoSize = true;
            this.txt_purchase.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_purchase.Location = new System.Drawing.Point(13, 17);
            this.txt_purchase.Name = "txt_purchase";
            this.txt_purchase.Size = new System.Drawing.Size(59, 24);
            this.txt_purchase.TabIndex = 3;
            this.txt_purchase.Text = "00.00";
            // 
            // txt_sale
            // 
            this.txt_sale.AutoSize = true;
            this.txt_sale.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sale.Location = new System.Drawing.Point(13, 17);
            this.txt_sale.Name = "txt_sale";
            this.txt_sale.Size = new System.Drawing.Size(59, 24);
            this.txt_sale.TabIndex = 3;
            this.txt_sale.Text = "00.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(773, 599);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "pdtId";
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Location = new System.Drawing.Point(48, 599);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(27, 13);
            this.type.TabIndex = 4;
            this.type.Text = "type";
            this.type.Visible = false;
            // 
            // txt_brand
            // 
            this.txt_brand.AutoSize = true;
            this.txt_brand.Location = new System.Drawing.Point(112, 599);
            this.txt_brand.Name = "txt_brand";
            this.txt_brand.Size = new System.Drawing.Size(34, 13);
            this.txt_brand.TabIndex = 5;
            this.txt_brand.Text = "brand";
            this.txt_brand.Visible = false;
            // 
            // txt_category
            // 
            this.txt_category.AutoSize = true;
            this.txt_category.Location = new System.Drawing.Point(177, 599);
            this.txt_category.Name = "txt_category";
            this.txt_category.Size = new System.Drawing.Size(41, 13);
            this.txt_category.TabIndex = 6;
            this.txt_category.Text = "label10";
            this.txt_category.Visible = false;
            // 
            // txt_sub_category
            // 
            this.txt_sub_category.AutoSize = true;
            this.txt_sub_category.Location = new System.Drawing.Point(247, 598);
            this.txt_sub_category.Name = "txt_sub_category";
            this.txt_sub_category.Size = new System.Drawing.Size(41, 13);
            this.txt_sub_category.TabIndex = 7;
            this.txt_sub_category.Text = "label10";
            this.txt_sub_category.Visible = false;
            // 
            // txt_dynamic_date
            // 
            this.txt_dynamic_date.AutoSize = true;
            this.txt_dynamic_date.Location = new System.Drawing.Point(318, 599);
            this.txt_dynamic_date.Name = "txt_dynamic_date";
            this.txt_dynamic_date.Size = new System.Drawing.Size(41, 13);
            this.txt_dynamic_date.TabIndex = 8;
            this.txt_dynamic_date.Text = "label10";
            this.txt_dynamic_date.Visible = false;
            this.txt_dynamic_date.Click += new System.EventHandler(this.txt_pdt_name_Click);
            // 
            // txt_rack
            // 
            this.txt_rack.AutoSize = true;
            this.txt_rack.Location = new System.Drawing.Point(372, 598);
            this.txt_rack.Name = "txt_rack";
            this.txt_rack.Size = new System.Drawing.Size(35, 13);
            this.txt_rack.TabIndex = 9;
            this.txt_rack.Text = "label5";
            this.txt_rack.Visible = false;
            // 
            // txt_expdate
            // 
            this.txt_expdate.AutoSize = true;
            this.txt_expdate.Location = new System.Drawing.Point(417, 598);
            this.txt_expdate.Name = "txt_expdate";
            this.txt_expdate.Size = new System.Drawing.Size(68, 13);
            this.txt_expdate.TabIndex = 10;
            this.txt_expdate.Text = "11-Sep-2016";
            this.txt_expdate.Visible = false;
            // 
            // StockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(980, 621);
            this.Controls.Add(this.txt_expdate);
            this.Controls.Add(this.txt_rack);
            this.Controls.Add(this.txt_dynamic_date);
            this.Controls.Add(this.txt_sub_category);
            this.Controls.Add(this.txt_category);
            this.Controls.Add(this.txt_brand);
            this.Controls.Add(this.type);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "StockList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockList";
            this.Load += new System.EventHandler(this.StockList_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_sale;
        private System.Windows.Forms.Label txt_purchase;
        private System.Windows.Forms.Label txt_net_price;
        private System.Windows.Forms.Label txt_quentity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label type;
        private System.Windows.Forms.Label txt_brand;
        private System.Windows.Forms.Label txt_category;
        private System.Windows.Forms.Label txt_sub_category;
        private System.Windows.Forms.Label txt_dynamic_date;
        private System.Windows.Forms.Label txt_rack;
        private System.Windows.Forms.Label txt_expdate;
    }
}