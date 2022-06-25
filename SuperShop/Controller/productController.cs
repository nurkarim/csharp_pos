using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class productController
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
        private string _sellPrice;
        private string _netPrice;
        private string _qty;
        private string _weight;
        private string _rackNo;
        private string _weightType;
        public string Subcategory { get { return _Subcategory; } set { _Subcategory = value; } }
        public string weightType { get { return _weightType; } set { _weightType = value; } }
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
            get {return  _brand; }
            set { _brand = value; }
        }
        public string productserialcode { get { return _productserialCode; } set { _productserialCode = value; } }
        public string purchasePrice { get { return _purchasePrice; } set { _purchasePrice = value; } }
        public string Barcode { get { return _barcode; } set { _barcode = value; } }
        public string SelPrice { get { return _sellPrice; } set { _sellPrice = value; } }
        public string NetPrice { get { return _netPrice; } set { _netPrice = value; } }
        public string Qty { get { return _qty; } set { _qty = value; } }
        public string Weight { get { return _weight; } set { _weight = value; } }
        public string RackNo { get { return _rackNo; } set { _rackNo = value; } }
    }
}
