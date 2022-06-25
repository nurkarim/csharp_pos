using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class purchaseController
    {
        private string _purchaseId;
        private string _product_id;
        private string _netPrice;
        private string _purchasePrice;
        private string _qty;
        private string _qty_type;
        private string _subAmount;
        private string _voucher_no;
        private string _billNo;
        private string _date;
        private string _vat;
        private string _discount;
        private string _subotalal;
        private string _supliyerName;
        private string _phoneNumber;
        private string _total_sub_amount;
        private string _total_vat;
        private string _total_discount;
        private string _total_purchase_amount;
        private string _paid_amount;
        private string _due_amount;
        private string _paid_type;
        private string _note;
        private string _user;
        private string _booth;
        private string _checkvalue;
       
        public string CheckValu { get { return _checkvalue; } set { _checkvalue = value; } }

        public string User { get { return _user; } set { _user = value; } }
        public string Booth { get { return _booth; } set { _booth = value; } }

        public string Date { get { return _date; } set { _date = value; } }
        public string PurchaseId { get { return _purchaseId; } set { _purchaseId = value; } }
        public string ProductId { get { return _product_id; } set { _product_id = value; } }
        public string NetPrice { get { return _netPrice; } set { _netPrice = value; } }
        public string PurchasePrice { get { return _purchasePrice; } set { _purchasePrice = value; } }
        public string Qty { get { return _qty; } set { _qty = value; } }
        public string qt_type { get { return _qty_type; } set { _qty_type = value; } }
        public string SubAmount { get { return _subAmount; } set { _subAmount = value; } }
        public string VoucherNo { get { return _voucher_no; } set { _voucher_no = value; } }
        public string BillNo { get { return _billNo; } set { _billNo = value; } }
        public string SubVat { get { return _vat; } set { _vat = value; } }
        public string SubDiscount { get { return _discount; } set { _discount = value; } }
        public string SubTotal { get { return _subotalal; } set { _subotalal = value; } }
        public string Suplyer { get { return _supliyerName; } set { _supliyerName = value; } }
        public string phone { get { return _phoneNumber; } set { _phoneNumber = value; } }
        public string TotalSubAmount { get { return _total_sub_amount; } set { _total_sub_amount = value; } }
        public string Total_Vat { get { return _total_vat; } set { _total_vat = value; } }
        public string Total_Discount { get { return _total_discount; } set { _total_discount = value; } }
        public string TotalPurchaseAmount { get { return _total_purchase_amount; } set { _total_purchase_amount = value; } }
        public string Paid_amount { get { return _paid_amount; } set { _paid_amount = value; } }
        public string Due { get { return _due_amount; } set { _due_amount = value; } }
        public string PaidType { get { return _paid_type; } set { _paid_type = value; } }

        public string Note { get { return _note; } set { _note = value; } }
            


    }
}
