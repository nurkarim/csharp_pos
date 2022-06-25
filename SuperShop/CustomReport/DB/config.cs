using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace SuperShop.DB
{
    class config
    {
        MySqlConnection conDatabase;
        public MySqlConnection connection()
        {

            try
            {
                //192.168.0.1 sbit 123456
                conDatabase = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=inventory_management;UID=root;PASSWORD=;");
            }
            catch (Exception)
            {

            }

            return conDatabase;
        }
    }
}
