using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class BrandController
    {
        private string _brandId;
        private string _brandName;
      
        private string _year;
        public string BrandId
        {
            get { return _brandId; }
            set { _brandId = value; }
        }
        public string BrandName 
        {
            get { return _brandName; }
            set { _brandName = value; }
        }
        
        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }
    }
}
