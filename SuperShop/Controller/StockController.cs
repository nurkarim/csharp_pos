using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class StockController
    {
        private string _productId;
        private string _pending_stock_id;
        private string _category_id;
        private string _subCategory_id;
        private string _net_price;
        private string _purchase_price;
        private string _sel_price;
        private string _barcodeId;
        private string _quentity;
        private string _barand;
        private string _user_id;
        private string _rack_No;
        private string _exp_Date;
        private string _tax;
        public string Tax { get { return _tax; } set { _tax = value; } }
        public string ExpDate { get { return _exp_Date; } set { _exp_Date = value; } }

        public string ReackNo { get { return _rack_No; } set { _rack_No = value; } }
        public string productId { get { return _productId; } set { _productId = value; } }
        public string pendingStockId { get { return _pending_stock_id; } set { _pending_stock_id = value; } }
        public string Category { get { return _category_id; } set { _category_id = value; } }
        public string Subcategory { get { return _subCategory_id; } set { _subCategory_id = value; } }
        public string barcode { get { return _barcodeId; } set { _barcodeId = value; } }
        public string NetPrice { get { return _net_price; } set { _net_price = value; } }
        public string purchasePrice { get { return _purchase_price; } set { _purchase_price = value; } }
        public string quentity { get { return _quentity; } set { _quentity = value; } }
        public string Brand { get { return _barand; } set { _barand = value; } }
        public string salePrice { get { return _sel_price; } set { _sel_price = value; } }
        public string userId { get { return _user_id; } set { _user_id = value; } }
    }
}