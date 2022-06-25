using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class CompanyRegisterController
    {
        private string _name;
        private string _email;
        private string _phone;
        private string _faxNo;
        private string _country;
        private string _city;
        private string _address;
        private string _userName;
        private string _password;
        private string _softwareType;
        private string _image;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string FaxNo
        {
            get { return _faxNo; }
            set { _faxNo = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string SoftwareType
        {
            get { return _softwareType; }
            set { _softwareType = value; }
        }
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
