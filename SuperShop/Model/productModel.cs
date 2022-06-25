using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Model
{
   class productModel
    {
     
       Controller.productController pdtController = new Controller.productController();
       DB.query query = new DB.query();
      
       public bool save(Controller.productController pdtController)
       {
           bool check = false;

           query.InsertA("product", "fk_brand_id,fk_category_id,fk_sub_category_id,product_name,net_weight,weight_type,product_serial_number,set_price,rack_no", "'" + pdtController.Brand + "','" + pdtController.Category + "','" + pdtController.Subcategory + "','" + pdtController.productName + "','" + pdtController.Weight + "','" + pdtController.weightType + "','" + pdtController.productserialcode + "','" + pdtController.NetPrice + "','"+pdtController.RackNo+"'");
         
           if (pdtController.CheckValu == "In Stock")
          {
              query.Insert("panding_stock", "fk_product_id,fk_category_id,fk_brand_id,fk_subcategory_id,net_price,purchase_price,net_weight,weigth_type,stock", "'" + Convert.ToString(query.LastId) + "','" + pdtController.Category + "','" + pdtController.Brand + "','" + pdtController.Subcategory + "','" + pdtController.NetPrice + "','" + pdtController.purchasePrice + "','" + pdtController.Weight + "','" + pdtController.weightType + "','" + pdtController.Qty + "'");
          }
           return check;
       }
       public bool updateProduct(Controller.productController pdtController)
       {
           bool check = false;

           query.Update("product", "fk_brand_id='" + pdtController.Brand + "',fk_category_id='" + pdtController.Category + "',fk_sub_category_id='" + pdtController.Subcategory + "',product_name='" + pdtController.productName + "',net_weight='" + pdtController.Weight + "'", "id","'"+_pdtController.productId+"'");

           
           return check;
       }
       public bool saveCloth(Controller.clothProductController pdtController)
       {
           bool check = false;

           query.InsertA("product", "fk_brand_id,fk_category_id,fk_sub_category_id,pdt_code,product_name,product_serial_number,rack_no", "'" + pdtController.Brand + "','" + pdtController.Category + "','" + pdtController.SubCategory + "','" + pdtController.Pdt_Code + "','" + pdtController.PdtType + "','" + pdtController.SerialNo + "','" + pdtController.RackNo + "'");

           if (pdtController.CheckValue == "In Stock")
           {
               query.Insert("panding_stock", "fk_product_id,fk_category_id,fk_brand_id,fk_subcategory_id,purchase_price,stock", "'" + Convert.ToString(query.LastId) + "','" + pdtController.Category + "','" + pdtController.Brand + "','" + pdtController.SubCategory + "','" + pdtController.PurchasePrice + "','" + pdtController.Quentity + "'");
           }
           return check;
       }

       public bool updateCloth(Controller.clothProductController pdtController)
       {
           bool check = false;
           query.Update("product", "fk_brand_id='" + pdtController.Brand + "',fk_category_id='" + pdtController.Category + "',fk_sub_category_id='" + pdtController.SubCategory + "',pdt_code='" + pdtController.Pdt_Code + "',product_name='" + pdtController.PdtType + "',rack_no='" + pdtController.RackNo + "'", "id", "'" + pdtController.Pdt_id + "'");
           return check;
       
       }
       Controller.ElectronicProductController _pdtController = new Controller.ElectronicProductController();

       public bool saveElectronic(Controller.ElectronicProductController pdtController)
       {
           bool check = false;

           query.InsertA("product", "fk_brand_id,fk_category_id,fk_sub_category_id,pdt_code,product_name,product_serial_number,color,warrenty,set_price,rack_no,created_by", "'" + pdtController.Brand + "','" + pdtController.Category + "','" + pdtController.Subcategory + "','" + pdtController.code + "','" + pdtController.productName + "','" + pdtController.productserialcode + "','" + pdtController.Color + "','" + pdtController.warentiy + "','"+pdtController.purchasePrice+"','" + pdtController.RackNo + "','" + _pdtController.User + "'");

           if (pdtController.CheckValu == "In Stock")
           {
               query.Insert("panding_stock", "fk_product_id,fk_category_id,fk_brand_id,fk_subcategory_id,purchase_price,stock", "'" + Convert.ToString(query.LastId) + "','" + pdtController.Category + "','" + pdtController.Brand + "','" + pdtController.Subcategory + "','" + pdtController.purchasePrice + "','" + pdtController.Qty + "'");
           }
           return check;
       }

       public bool updateElectronics(Controller.ElectronicProductController pdtController)
       {
           bool check = false;
           query.Update("product", "fk_brand_id='" + pdtController.Brand + "',fk_category_id='" + pdtController.Category + "',fk_sub_category_id='" + pdtController.Subcategory + "',pdt_code='" + pdtController.code + "',product_name='" + pdtController.productName + "',color='" + pdtController.Color + "',warrenty='" + pdtController.warentiy + "',rack_no='" + pdtController.RackNo + "',set_price='" + pdtController.purchasePrice + "'", "id", "'" + pdtController.productId + "'");
           return check;

       }

    }
}
