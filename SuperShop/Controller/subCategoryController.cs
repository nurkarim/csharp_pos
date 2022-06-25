using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class subCategoryController
    {
        private string _fk_category_id;
        private string _subCategoryName;
        private string user_id;
        private string _SubcategoryId;
        public string categoryId
        {
            get { return _fk_category_id; }
            set { _fk_category_id = value; }

        }
        public string SubcategoryId
        {
            get { return _SubcategoryId; }
            set { _SubcategoryId = value; }

        }
        public string Name
        {
            get { return _subCategoryName; }
            set { _subCategoryName = value; }
        }
        public string user
        {
            get { return user_id; }
            set { user_id = value; }
        
        }
    }
}
