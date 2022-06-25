using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class DailyIncomeController
    {
        private string _id;
        private string _title;
        private string _amount;
        private string _date;
        private string _type;
        private string _note;
        private string _user;
        public string USER { get { return _user; } set { _user = value; } }
        public string ID { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Amount { get { return _amount; } set { _amount = value; } }
        public string Date { get { return _date; } set { _date = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Note { get { return _note; } set { _note = value; } }
    }
}
