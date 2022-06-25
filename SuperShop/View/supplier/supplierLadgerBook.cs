using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.supplier
{
    public partial class supplierLadgerBook : Form
    {
        public supplierLadgerBook()
        {
            InitializeComponent();
        }
        DB.query _query = new DB.query();
        private void supplierLadgerBook_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=_query.SelectFullTable("SELECT supplier_master_ladger_book.date as Date, supplier_master_ladger_book.supplier_id as Supplier_ID,supplier_master_ladger_book.supplier_name as Name,supplier_master_ladger_book.debit_amount as Debit_Amount,supplier_master_ladger_book.credit_amount as Credit_Amount FROM supplier_master_ladger_book");
        }
    }
}
