using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySqlQuery;
using System.Windows.Forms;
namespace SuperShop.Model
{
    class BrandModel
    {
        DB.query query = new DB.query();
        Controller.BrandController _controller = new Controller.BrandController();
        public void saveBrand(Controller.BrandController _controller)
        {
            
            
            if (_controller.BrandName == "")
            {
                MessageBox.Show("Please Input Name");
            }
            else if (_controller.BrandId == "")
            {
                MessageBox.Show("Please Input Id");
            }
            else
            {
                query.Insert("brand_table", "Brand_id,Brand_name,year,create_at,create_by", "'" + _controller.BrandId + "','" + _controller.BrandName + "','" + _controller.Year + "','" + DateTime.Now + "','1'");
            }
            return;
        }


    }
}
