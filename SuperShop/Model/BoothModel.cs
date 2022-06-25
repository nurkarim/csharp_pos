using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace SuperShop.Model
{
    class BoothModel
    {
        DB.query _query = new DB.query();
        DB.config cn = new DB.config();      
        Controller.bothController _booth = new Controller.bothController();
        public void saveBooth(Controller.bothController _controller)
        {
            _query.Insert("booth_setup", "date,pc_id,booth_name","'"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+_controller.PcId_No+"','"+_controller.BoothName+"'");
            return;
        }
    }
}
