using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Model
{
    class ExpenseModel
    {
        Controller.ExpenseController _controller = new Controller.ExpenseController();
        DB.query _model = new DB.query();

        public bool save(Controller.ExpenseController _controller)
        {
            bool check = false;
            _model.InsertA("expense", "date,expense_sourche,amount,recived_type,note,recived_by", "'"+_controller.Date+"','"+_controller.Title+"','"+_controller.Amount+"','"+_controller.Type+"','"+_controller.Note+"','"+_controller.USER+"'");
            return check;
        
        }

        public bool Update(Controller.ExpenseController _controller)
        {
            bool check = false;
            _model.Update("expense", "date='" + _controller.Date + "',expense_sourche='" + _controller.Title + "',amount='" + _controller.Amount + "',recived_type='" + _controller.Type + "',note='" + _controller.Note + "',recived_by='" + _controller.USER + "'","id","'"+_controller.ID+"'");
            return check;

        }
    }
}
