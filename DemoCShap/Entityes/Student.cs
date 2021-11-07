using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCShap.Entityes
{
    class Student
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Fullname {FullName}, Email {Email}, Phone {Phone}";
        }
    }
}
