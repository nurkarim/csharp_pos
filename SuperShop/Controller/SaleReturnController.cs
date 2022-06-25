using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class SaleReturnController
    {
        private string _id;
        private string _return_id;
        private string _recipt_no;
        private string _customer_id;
        private string _customer_name;
        private string _phone;
        private string _sub_total;
        private string _discount;
        private string _total;
        private string _paid;
        private string _due;
        private string _type;
        private string _note;
        private string _date;
        private string _booth;
        private string _user;

        public string ID { get { return _id; } set { _id = value; } }
        public string VoucherNo { get { return _return_id; } set { _return_id = value; } }
        public string ReciptNo { get { return _recipt_no; } set { _recipt_no = value; } }
        public string CustomerId { get { return _customer_id; } set { _customer_id = value; } }
        public string CustomerName { get { return _customer_name; } set { _customer_name = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string SubTotal { get { return _sub_total; } set { _sub_total = value; } }
        public string Discount { get { return _discount; } set { _discount = value; } }
        public string Total { get { return _total; } set { _total = value; } }
        public string Paid { get { return _paid; } set { _paid = value; } }
        public string Due { get { return _due; } set { _due = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Note { get { return _note; } set { _note = value; } }
        public string Date { get { return _date; } set { _date = value; } }
        public string UserID { get { return _user; } set { _user = value; } }
        public string Booth { get { return _booth; } set { _booth = value; } }



    }
}
