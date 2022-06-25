using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.Request
{
    class ItemRequest
    {
        Controller.ItemController _item = new Controller.ItemController();
        public bool Itemvalidation()
        {
            bool check = false;
            if (_item.Name == "")
            {
                MessageBox.Show("Please Input Name");
               
            }
            else if (_item.Roll == "")
            {
                MessageBox.Show("Please Input Id");
              
            }
            return check;
        }


       
    }
}
