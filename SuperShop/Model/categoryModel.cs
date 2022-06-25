using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySqlQuery;
using System.Data;
using System.Windows.Forms;
namespace SuperShop.Model
{
    class categoryModel
    {
     
        DB.config connect = new DB.config();
        DB.query _dat = new DB.query();
        MySqlConnection conDatabase;
        MySqlCommand cmd;
        internal List<string> dataRead()
        {
            List<string> items = new List<string>();
            conDatabase = connect.connection();
            conDatabase.Open();
            cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "SELECT id,name FROM item";
            MySqlDataReader dread = cmd.ExecuteReader();
            string data = "";
            
            while (dread.Read())
            {
                //data = dread["name"].ToString() + "," + dread["id"].ToString();
                data = dread["name"].ToString();
               items.Add(data); 
            }
            dread.Close();
            return items;
        }
        public bool save(Controller.categoryController _controller)
        {
            bool check = false;
            try
            {

                if (_controller.categoryName == "")
                {
                    MessageBox.Show("Please Input Name");

                }
              
                else
                {
                    _dat.Insert("category", "name,created_at", "'" + _controller.categoryName + "','" + DateTime.Today + "'");
                    //MessageBox.Show("Save Success");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;
        }
        public bool update(Controller.categoryController _controller)
        {
            bool check = false;
            try
            {

                if (_controller.categoryName == "")
                {
                    MessageBox.Show("Please Input Name");

                }

                else
                {
                    _dat.Update("category", "name='" + _controller.categoryName + "'", "id", "'" + _controller.ID + "'");
                    //MessageBox.Show("Save Success");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;
        }
    }
}
