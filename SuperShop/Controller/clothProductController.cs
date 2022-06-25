using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class clothProductController
    {
        private string _pdt_id;
        private string _pdt_code;
        private string _brand;
        private string _category;
        private string _sub_category;
        private string _pdt_type;
        private string _purchase_price;
        private string _sale_price;
        private string _quentity;
        private string _serial_no;
        private string _rack_no;
        private string _check_value;

        public string Pdt_Code { get { return _pdt_code; } set { _pdt_code = value; } }
        public string Pdt_id { get { return _pdt_id; } set { _pdt_id = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }
        public string Category { get { return _category; } set { _category = value; } }
        public string SubCategory { get { return _sub_category; } set { _sub_category = value; } }
        public string PdtType { get { return _pdt_type; } set { _pdt_type = value; } }
        public string PurchasePrice { get { return _purchase_price; } set { _purchase_price = value; } }
        public string SalePrice { get { return _sale_price; } set { _sale_price = value; } }
        public string Quentity { get { return _quentity; } set { _quentity = value; } }
        public string RackNo { get { return _rack_no; } set { _rack_no = value; } }
        public string CheckValue { get { return _check_value; } set { _check_value = value; } }
        public string SerialNo { get { return _serial_no; } set { _serial_no = value; } }



    }
}
