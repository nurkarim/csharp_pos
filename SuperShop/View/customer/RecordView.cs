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
    public partial class RecordView : Form
    {
        public RecordView()
        {
            InitializeComponent();
        }
        public string Type { get { return txt_type.Text; } set { txt_type.Text = value; } }
        public string GlobalData { get { return txt_global_data.Text; } set { txt_global_data.Text = value; } }
        public string DateA { get { return txt_date.Text; } set { txt_date.Text = value; } }
        public string DateB { get { return txt_date_b.Text; } set { txt_date_b.Text = value; } }
        DB.config connect = new DB.config();
        
        DB.query _query = new DB.query();
        private void RecordView_Load(object sender, EventArgs e)
        {
            if (txt_type.Text == "allCustomer")
            {
                dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_name as 'Name',phone as 'Phone',email as 'E-mail',gender as 'Gender',city as 'City',address as 'Address',if(customer_info.`status`=1,'Active','Inactive') from customer_info");
            }
            else if (txt_type.Text == "custLadger")
            {
                dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_ladger_book.date as 'Date',customer_ladger_book.voucher_id as 'Voucher', customer_info.customer_name as 'Name',customer_ladger_book.phone,customer_ladger_book.discription as 'Discription',customer_ladger_book.debit_amount as 'Debit',customer_ladger_book.credit_amount as 'Credit',customer_ladger_book.blance as 'Balance',if(customer_info.`status`=1,'Active','Inactive') as 'Status' from customer_ladger_book inner join customer_info on customer_ladger_book.customer_id=customer_info.id;");
            }

            else if (txt_type.Text == "custDue")
            {
                dataGridView1.DataSource = _query.SelectFullTable("select customermasterduebook.`Last Date`,customermasterduebook.`Customer Name`,customermasterduebook.`Debit Blance`,customermasterduebook.`Credit Blance`,customermasterduebook.Blance,IF(customermasterduebook.Blance>=customermasterduebook.`Credit Blance`,'Debit','Credit')as 'Type' from  customermasterduebook");
            }


            else if (txt_type.Text == "custAccordingrDue")
            {
                dataGridView1.DataSource = _query.SelectFullTable("select customermasterduebook.`Last Date`,customermasterduebook.`Customer Name`,customermasterduebook.`Debit Blance`,customermasterduebook.`Credit Blance`,customermasterduebook.Blance,IF(customermasterduebook.Blance>=customermasterduebook.`Credit Blance`,'Debit','Credit')as 'Type' from  customermasterduebook where customermasterduebook.ID='"+txt_global_data.Text+"'");
            }
            else if (txt_type.Text == "custAccordingLadger")
            {
                dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_ladger_book.date as 'Date',customer_ladger_book.voucher_id as 'Voucher', customer_info.customer_name as 'Name',customer_ladger_book.phone,customer_ladger_book.discription as 'Discription',customer_ladger_book.debit_amount as 'Debit',customer_ladger_book.credit_amount as 'Credit',customer_ladger_book.blance as 'Balance',if(customer_info.`status`=1,'Active','Inactive') as 'Status' from customer_ladger_book inner join customer_info on customer_ladger_book.customer_id=customer_info.id where customer_id='"+txt_global_data.Text+"'");
            }

            else if (txt_type.Text == "dailyLadger")
            {
                dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_ladger_book.date as 'Date',customer_ladger_book.voucher_id as 'Voucher', customer_info.customer_name as 'Name',customer_ladger_book.phone,customer_ladger_book.discription as 'Discription',customer_ladger_book.debit_amount as 'Debit',customer_ladger_book.credit_amount as 'Credit',customer_ladger_book.blance as 'Balance',if(customer_info.`status`=1,'Active','Inactive') as 'Status' from customer_ladger_book inner join customer_info on customer_ladger_book.customer_id=customer_info.id where customer_ladger_book.date='"+txt_date.Text+"'");
            }
            else if (txt_type.Text == "monthlyLadger")
            {
                dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_ladger_book.date as 'Date',customer_ladger_book.voucher_id as 'Voucher', customer_info.customer_name as 'Name',customer_ladger_book.phone,customer_ladger_book.discription as 'Discription',customer_ladger_book.debit_amount as 'Debit',customer_ladger_book.credit_amount as 'Credit',customer_ladger_book.blance as 'Balance',if(customer_info.`status`=1,'Active','Inactive') as 'Status' from customer_ladger_book inner join customer_info on customer_ladger_book.customer_id=customer_info.id where right(customer_ladger_book.date,8)='" + txt_date.Text + "'");
            }
            else if (txt_type.Text == "yearly")
            {
                dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_ladger_book.date as 'Date',customer_ladger_book.voucher_id as 'Voucher', customer_info.customer_name as 'Name',customer_ladger_book.phone,customer_ladger_book.discription as 'Discription',customer_ladger_book.debit_amount as 'Debit',customer_ladger_book.credit_amount as 'Credit',customer_ladger_book.blance as 'Balance',if(customer_info.`status`=1,'Active','Inactive') as 'Status' from customer_ladger_book inner join customer_info on customer_ladger_book.customer_id=customer_info.id where right(customer_ladger_book.date,4)='" + txt_date.Text + "'");
            }
            else if (txt_type.Text == "weekly")
            {
                dataGridView1.DataSource = _query.SelectFullTable("SELECT customer_ladger_book.date as 'Date',customer_ladger_book.voucher_id as 'Voucher', customer_info.customer_name as 'Name',customer_ladger_book.phone,customer_ladger_book.discription as 'Discription',customer_ladger_book.debit_amount as 'Debit',customer_ladger_book.credit_amount as 'Credit',customer_ladger_book.blance as 'Balance',if(customer_info.`status`=1,'Active','Inactive') as 'Status' from customer_ladger_book inner join customer_info on customer_ladger_book.customer_id=customer_info.id where customer_ladger_book.date between '" + txt_date.Text + "' and '"+txt_date_b.Text+"'");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pvDialog.Document = printDocument1;

            pvDialog.PrintPreviewControl.Zoom = 1;

            pvDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap dataGridViewImage = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(dataGridViewImage, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(dataGridViewImage, 0, 0);
        }
    }
}
