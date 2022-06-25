using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class supplierController
    {
        private string _Id;
        private string _name;
        private string _email;
        private string _phone;
        private string _gender;
        private string _address;
        private string _cname;
        private string _cemail;
        private string _cphone;
        private string _cAddress;
        private string _user;

        public string USER { get { return _user; } set { _user = value; } }
        public string ID { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Gender { get { return _gender; } set { _gender = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string CName { get { return _cname; } set { _cname = value; } }
        public string CEmail { get { return _cemail; } set { _cemail = value; } }
        public string CPhone { get { return _cphone; } set { _cphone = value; } }
        public string CAddress { get { return _cAddress; } set { _cAddress = value; } }
    }
}
