namespace SuperShop.View.stock
{
    partial class inventoryStock
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.cmdBrand = new System.Windows.Forms.ComboBox();
            this.cmdCategory = new System.Windows.Forms.ComboBox();
            this.cmdsubcategory = new System.Windows.Forms.ComboBox();
            this.cmdexpdate = new System.Windows.Forms.ComboBox();
            this.cmd_rack = new System.Windows.Forms.ComboBox();
            this.cmd_product = new System.Windows.Forms.ComboBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.cmd_barcode = new System.Windows.Forms.ComboBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(4, 95);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 23);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Brand";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(4, 128);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(169, 23);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Category/Product Type";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(4, 163);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(111, 23);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Sub Category";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(4, 197);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(86, 23);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Exp-Date";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.Location = new System.Drawing.Point(4, 236);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(83, 23);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "Rack No";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // cmdBrand
            // 
            this.cmdBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmdBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmdBrand.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrand.FormattingEnabled = true;
            this.cmdBrand.Location = new System.Drawing.Point(176, 91);
            this.cmdBrand.Name = "cmdBrand";
            this.cmdBrand.Size = new System.Drawing.Size(152, 27);
            this.cmdBrand.TabIndex = 5;
            // 
            // cmdCategory
            // 
            this.cmdCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmdCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmdCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCategory.FormattingEnabled = true;
            this.cmdCategory.Location = new System.Drawing.Point(176, 124);
            this.cmdCategory.Name = "cmdCategory";
            this.cmdCategory.Size = new System.Drawing.Size(152, 27);
            this.cmdCategory.TabIndex = 6;
            this.cmdCategory.SelectedIndexChanged += new System.EventHandler(this.cmdCategory_SelectedIndexChanged);
            // 
            // cmdsubcategory
            // 
            this.cmdsubcategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmdsubcategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmdsubcategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsubcategory.FormattingEnabled = true;
            this.cmdsubcategory.Location = new System.Drawing.Point(176, 159);
            this.cmdsubcategory.Name = "cmdsubcategory";
            this.cmdsubcategory.Size = new System.Drawing.Size(152, 27);
            this.cmdsubcategory.TabIndex = 7;
            // 
            // cmdexpdate
            // 
            this.cmdexpdate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmdexpdate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmdexpdate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdexpdate.FormattingEnabled = true;
            this.cmdexpdate.Location = new System.Drawing.Point(176, 196);
            this.cmdexpdate.Name = "cmdexpdate";
            this.cmdexpdate.Size = new System.Drawing.Size(152, 27);
            this.cmdexpdate.TabIndex = 8;
            this.cmdexpdate.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // cmd_rack
            // 
            this.cmd_rack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmd_rack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmd_rack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_rack.FormattingEnabled = true;
            this.cmd_rack.Location = new System.Drawing.Point(176, 232);
            this.cmd_rack.Name = "cmd_rack";
            this.cmd_rack.Size = new System.Drawing.Size(148, 27);
            this.cmd_rack.TabIndex = 9;
            this.cmd_rack.SelectedIndexChanged += new System.EventHandler(this.cmd_rack_SelectedIndexChanged);
            // 
            // cmd_product
            // 
            this.cmd_product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmd_product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmd_product.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_product.FormattingEnabled = true;
            this.cmd_product.Location = new System.Drawing.Point(176, 270);
            this.cmd_product.Name = "cmd_product";
            this.cmd_product.Size = new System.Drawing.Size(152, 27);
            this.cmd_product.TabIndex = 11;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.Location = new System.Drawing.Point(4, 274);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(116, 23);
            this.radioButton6.TabIndex = 10;
            this.radioButton6.Text = "Product Name";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // cmd_barcode
            // 
            this.cmd_barcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmd_barcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmd_barcode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_barcode.FormattingEnabled = true;
            this.cmd_barcode.Location = new System.Drawing.Point(176, 306);
            this.cmd_barcode.Name = "cmd_barcode";
            this.cmd_barcode.Size = new System.Drawing.Size(152, 27);
            this.cmd_barcode.TabIndex = 13;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton7.Location = new System.Drawing.Point(4, 310);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(131, 23);
            this.radioButton7.TabIndex = 12;
            this.radioButton7.Text = "Product Barcode";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(179, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 35);
            this.button1.TabIndex = 14;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(249, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 15;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 71);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(96, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Record";
            // 
            // inventoryStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(336, 379);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmd_barcode);
            this.Controls.Add(this.radioButton7);
            this.Controls.Add(this.cmd_product);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.cmd_rack);
            this.Controls.Add(this.cmdexpdate);
            this.Controls.Add(this.cmdsubcategory);
            this.Controls.Add(this.cmdCategory);
            this.Controls.Add(this.cmdBrand);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "inventoryStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.inventoryStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.ComboBox cmdBrand;
        private System.Windows.Forms.ComboBox cmdCategory;
        private System.Windows.Forms.ComboBox cmdsubcategory;
        private System.Windows.Forms.ComboBox cmdexpdate;
        private System.Windows.Forms.ComboBox cmd_rack;
        private System.Windows.Forms.ComboBox cmd_product;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.ComboBox cmd_barcode;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

    }
}