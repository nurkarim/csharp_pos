using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperShop.Controller
{
    class clientController
    {
        private string _clientID;
        private string _name;
        private string _email;
        private string _phone;
        private string _type;
        private string _city;
        private string _gender;
        
        private string _address;
        public string Id { get { return _clientID; } set { _clientID = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Gender { get { return _gender; } set { _gender = value; } }
        public string Address { get { return _address; } set { _address = value; } }

    }
}
