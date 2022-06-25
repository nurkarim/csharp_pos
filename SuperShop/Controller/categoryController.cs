using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class categoryController
    {

        private string _catName;
        private string _id;

    
        public string categoryName
        {
            get { return _catName; }
            set { _catName = value; }
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
