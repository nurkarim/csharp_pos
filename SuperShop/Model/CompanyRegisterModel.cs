using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace SuperShop.Model
{
    class CompanyRegisterModel
    {
        DB.config connect = new DB.config();
        DB.query _dat = new DB.query();
        
        public bool save(Controller.CompanyRegisterController _controller)
        {
            bool check = false;
            try
            {

                if (_controller.Name == "")
                {
                    MessageBox.Show("Please Get Input Name");

                }
                else if (_controller.Phone == "")
                {
                    MessageBox.Show("Please Get Input Phone");

                }
                else if (_controller.UserName == "")
                {
                    MessageBox.Show("Please Get Input User Name");

                }
                else if (_controller.Password == "")
                {
                    MessageBox.Show("Please Get Input Password");

                }
                else if (_controller.SoftwareType == "")
                {
                    MessageBox.Show("Please Select Software");

                }
                else
                {
                   
                    _dat.Insert("company_register", "id,name,email,phone,fax,country,city,address,logo,created_at,user_name,password", "'cm-101','" + _controller.Name + "','" + _controller.Email + "','" + _controller.Phone + "','" + _controller.FaxNo + "','" + _controller.Country + "','" + _controller.City + "','" + _controller.Address + "','"+ _controller.Image + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','"+_controller.UserName+"','"+_controller.Password+"'");
                    _dat.InsertA("check_run_software", "software_type,company_name,company_id", "'" + _controller.SoftwareType + "','" + _controller.Name + "','cm-101'");
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
