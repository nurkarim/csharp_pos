using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlQuery;
namespace SuperShop.Model
{
    class ItemModel
    {
             
              Controller.ItemController _controller = new Controller.ItemController();
              DB.query _query;
              DBQuery _dat = new DBQuery();
              Request.ItemRequest _itemrequest = new Request.ItemRequest();
         public bool save(Controller.ItemController _controller)
        {
            bool check = false;
            try
            {
               
                if (_controller.Name == "")
                {
                    MessageBox.Show("Please Input Name");

                }
                else if (_controller.Roll == "")
                {
                    MessageBox.Show("Please Input Id");

                }

                else
                {
                _dat.Insert("item", "name,cusId", "'" + _controller.Name + "','" + _controller.Roll + "'");
                //MessageBox.Show("Save Success");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;
        }
        public void deleteItem(Controller.ItemController _controller)
        {
            try
            {
                if (_controller.Roll == "")
                {
                    MessageBox.Show("Please Input Roll");
                }
                else
                {
                    _query = new DB.query();
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
