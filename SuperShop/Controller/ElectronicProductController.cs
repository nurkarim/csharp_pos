using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class ElectronicProductController
    {
        private string _checkvalue;
        private string _productId;
        private string _productName;
        private string _productType;
        private string _category;
        private string _Subcategory;
        private string _brand;
        private string _productserialCode;
        private string _barcode;
        private string _purchasePrice;
        private string _warentiy;
        private string _pdt_code;

        private string _qty;
        private string _color;
        
        private string _rackNo;
        private string _user;
        public string Subcategory { get { return _Subcategory; } set { _Subcategory = value; } }
        public string code { get { return _pdt_code; } set { _pdt_code = value; } }
        public string User { get { return _user; } set { _user = value; } }
        public string CheckValu { get { return _checkvalue; } set { _checkvalue = value; } }
        public string productId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public string productType
        {
            get { return _productType; }
            set { _productType = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public string productserialcode { get { return _productserialCode; } set { _productserialCode = value; } }
        public string purchasePrice { get { return _purchasePrice; } set { _purchasePrice = value; } }
        public string Barcode { get { return _barcode; } set { _barcode = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public string warentiy { get { return _warentiy; } set { _warentiy = value; } }
        public string Qty { get { return _qty; } set { _qty = value; } }
      
        public string RackNo { get { return _rackNo; } set { _rackNo = value; } }
    }
}
