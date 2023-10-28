using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    internal class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Person(string name, string email, string phone)
        {
            Name = name;
            this.Email = email;
            Phone = phone;
        }

        public Person()
        {
        }
    }
}
