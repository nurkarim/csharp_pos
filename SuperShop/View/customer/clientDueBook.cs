using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.customer
{
    public partial class clientDueBook : Form
    {
        public clientDueBook()
        {
            InitializeComponent();
        }
        DB.config con = new DB.config();
        DB.query _query = new DB.query();


        void list()
        {

            dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_master_ladger_book.date as 'Last Date',customer_master_ladger_book.customer_id as 'ID', customer_master_ladger_book.customer_name as 'Customer Name',customer_master_ladger_book.debit_amount as 'Debit Blance',customer_master_ladger_book.credit_amount as 'Credit Blance',((customer_master_ladger_book.debit_amount)-(customer_master_ladger_book.credit_amount)) as 'Blance' from customer_master_ladger_book order by date desc ");
        }
        private void clientDueBook_Load(object sender, EventArgs e)
        {
            list();
        }
    }
}
