using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Model
{
    class clientModel
    {
        Controller.clientController _controller = new Controller.clientController();
        DB.query _query = new DB.query();
        public bool save(Controller.clientController _controller)
        {
            bool check = false;
            _query.Insert("customer_info", "type,customer_name,phone,email,gender,city,address", "'"+_controller.Type+"','"+_controller.Name+"','"+_controller.Phone+"','"+_controller.Email+"','"+_controller.Gender+"','"+_controller.City+"','"+_controller.Address+"'");
            return check;
        }

        public bool update(Controller.clientController _controller)
        {
            bool check = false;
            _query.Update("customer_info", "type='" + _controller.Type + "',customer_name='" + _controller.Name + "',phone='" + _controller.Phone + "',email='" + _controller.Email + "',gender='" + _controller.Gender + "',city='" + _controller.City + "',address='" + _controller.Address + "'", "id","'"+_controller.Id+"'");
            return check;
        }
    }
}
