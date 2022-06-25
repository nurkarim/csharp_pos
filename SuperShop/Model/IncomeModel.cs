using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Model
{
    class IncomeModel
    {
        Controller.DailyIncomeController _incomeController = new Controller.DailyIncomeController();
        DB.query _query = new DB.query();

        public bool save(Controller.DailyIncomeController _incomeController)
        {
            bool check = true;

            _query.InsertA("income", "date,income_sourch,amount,recived_type,created_by,note", "'" + _incomeController.Date + "','" + _incomeController.Title + "','" + _incomeController.Amount + "','" + _incomeController.Type + "','" + _incomeController.USER + "','" + _incomeController.Note + "'");

            _query.Insert("income_expense_table", "date,voucher_id,income_sourch,income_amount,type,note","'"+_incomeController.Date+"','"+_query.LastId+"','"+_incomeController.Title+"','"+_incomeController.Amount+"','INC','"+_incomeController.Note+"'");
            return check;
        
        }
    }
}
