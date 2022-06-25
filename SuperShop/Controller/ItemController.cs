using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class ItemController
    {
        private string _name;
        private string _roll;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Roll
        {
            get { return _roll; }
            set { _roll = value; }
        }
    }
}
