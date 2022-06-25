using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Model
{
    class StockModel
    {
        Controller.StockController _stockController = new Controller.StockController();
        DB.query _query = new DB.query();
        public bool save(Controller.StockController _stockController)
        {
            bool chec = false;

            _query.Insert("stock", "fk_brand_id,fk_category,fk_sub_category_id,fk_product_id,fk_panding_stock_id,barcode_id,net_price,purchase_price,sale_price,vat,qty,date,fk_user_id,rack_no,exp_date", "'" + _stockController.Brand + "','" + _stockController.Category + "','" + _stockController.Subcategory + "','" + _stockController.productId + "','" + _stockController.pendingStockId + "','" + _stockController.barcode + "','" + _stockController.NetPrice + "','" + _stockController.purchasePrice + "','" + _stockController.salePrice + "','"+_stockController.Tax+"','" + _stockController.quentity + "','" + DateTime.Now.ToString("dd-MMM-yyyy") + "','" + _stockController.userId + "','" + _stockController.ReackNo + "','" + _stockController.ExpDate + "'");
            return chec;
        }

        public bool delete(Controller.StockController _stockController)
        {
            bool check = true;
            _query.Delete("panding_stock","id", "'"+_stockController.pendingStockId+"'");
            return check;
        }

        public bool update(Controller.StockController _stockController)
        {
            bool check = true;
            _query.Update("stock", "purchase_price='" + _stockController.purchasePrice + "',sale_price='" + _stockController.salePrice + "',vat='" + _stockController.Tax + "',qty=qty+'" + _stockController.quentity + "'", "fk_product_id", "'" + _stockController.productId + "'");
            return check;
        }
    }
}
