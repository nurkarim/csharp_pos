using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.Model
{
    class subCategoryModel
    {
        Controller.subCategoryController _controller = new Controller.subCategoryController();
        public void save(Controller.subCategoryController _controller)
        {
            DB.query query = new DB.query();
            
            if (_controller.categoryId == "")
            {
                MessageBox.Show("Please Input Category");
            }
            else if (_controller.Name == "")
            {
                MessageBox.Show("Please Input Name");
            }
            else
            {
                query.Insert("sub_category", "fk_category_id,name,created_at,fk_user_id", "'" + _controller.categoryId + "','" + _controller.Name + "','" + DateTime.Now.ToString("yyyy-MM-dd H:i:s") + "','"+_controller.user+"'");
            }
            return;
        }

        public void updateSuB(Controller.subCategoryController _controller)
        {
            DB.query query = new DB.query();
           
            if (_controller.categoryId == "")
            {
                MessageBox.Show("Please Input Category");
            }
            else if (_controller.Name == "")
            {
                MessageBox.Show("Please Input Name");
            }
            else
            {
                query.Update("sub_category", "fk_category_id='"+_controller.categoryId+"',name='"+_controller.Name+"'","id","'"+_controller.SubcategoryId+"'");
            }
            return;
        }
    }
}
