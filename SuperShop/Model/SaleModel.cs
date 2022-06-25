using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Model
{
    class SaleModel
    {
        Controller.SaleController _saleController = new Controller.SaleController();
        DB.query _query = new DB.query();


        public bool save( Controller.SaleController _saleController)
        {
            bool check = true;
            _query.InsertA("voucher", "date,customer_id,customer_name,phone,custom_voucher_id,subtotal_amount,vat,discount,total_amount,paid,due,type,paid_type,paid_type_check_number,note,user_id,booth_no", "'" + _saleController.Date + "','" + _saleController.CustomerId + "','" + _saleController.CustomerName + "','" + _saleController.CustomerPhone + "','" + _saleController.VoucherId + "','" + _saleController.SubTotal + "','" + _saleController.Vat + "','" + _saleController.Discount + "','" + _saleController.TotalAmount + "','" + _saleController.Paid + "','" + _saleController.Due + "','" + _saleController.Type + "','" + _saleController.PaidType + "','" + _saleController.CheckNumber + "','" + _saleController.Note + "','" + _saleController.UserName + "','"+_saleController.Booth+"'");
            return check;
        
        }
    }
}
