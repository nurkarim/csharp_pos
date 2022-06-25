using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class SaleController
    {
        private string _saleID;
        private string _date;
        private string _customer_id;
        private string _customerName;
        private string _Customer_phone;
        private string _custom_voucher_id;
        private string _subtotal_amount;
        private string _vat;
        private string _discount;
        private string _total_amount;
        private string _paid;
        private string _due;
        private string _type;
        private string _paid_type;
        private string _paid_type_check_number;
        private string _note;
        private string _user_id;
        private string _boothNo;
        private string _currency;

        public string Currency { get { return _currency; } set { _currency = value; } }

        public string Booth { get { return _boothNo; } set { _boothNo = value; } }
        public string SaleID { get { return _saleID; } set { _saleID = value; } }
        public string Date { get { return _date; } set { _date = value; } }
        public string CustomerId { get { return _customer_id; } set { _customer_id = value; } }
        public string CustomerName { get { return _customerName; } set { _customerName = value; } }
        public string CustomerPhone { get { return _Customer_phone; } set { _Customer_phone = value; } }
        public string VoucherId { get { return _custom_voucher_id; } set { _custom_voucher_id = value; } }
        public string SubTotal { get { return _subtotal_amount; } set { _subtotal_amount = value; } }
        public string Vat { get { return _vat; } set { _vat = value; } }
        public string Discount { get { return _discount; } set { _discount = value; } }
        public string TotalAmount { get { return _total_amount; } set { _total_amount = value; } }
        public string Paid { get { return _paid; } set { _paid = value; } }
        public string Due { get { return _due; } set { _due = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string PaidType { get { return _paid_type; } set { _paid_type = value; } }
        public string CheckNumber { get { return _paid_type_check_number; } set { _paid_type_check_number = value; } }
        public string Note { get { return _note; } set { _note = value; } }
        public string UserName { get { return _user_id; } set { _user_id = value; } }

    

    }
}
