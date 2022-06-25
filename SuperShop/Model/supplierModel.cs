using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Model
{
    class supplierModel
    {
        Controller.supplierController _controller = new Controller.supplierController();
        DB.query _query = new DB.query();


        public bool save(Controller.supplierController _controller)
        {

            bool check = false;
            _query.Insert("supplyer_table", "name,phone,email,company_name,company_address,company_phone,billing_addresss,gender,cmail,created_by", "'" + _controller.Name + "','" + _controller.Phone + "','" + _controller.Email + "','" + _controller.CName + "','" + _controller.CAddress + "','" + _controller.CPhone + "','" + _controller.Address + "','" + _controller.Gender + "','" + _controller.CEmail + "','" + _controller.USER + "'");
            return check;
        }

        public bool update(Controller.supplierController _controller)
        {

            bool check = false;
            _query.Update("supplyer_table", "name='" + _controller.Name + "',phone='" + _controller.Phone + "',email='" + _controller.Email + "',company_name='" + _controller.CName + "',company_address='" + _controller.CAddress + "',company_phone='" + _controller.CPhone + "',billing_addresss='" + _controller.Address + "',gender='" + _controller.Gender + "',cmail='" + _controller.CEmail + "'", "id", "'" + _controller.ID + "'");
            return check;
        }
    }
}
