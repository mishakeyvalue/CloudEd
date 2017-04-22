using System;
using System.Collections.Generic;
using System.Text;

namespace CES_DAL.Models.UsersEntities
{
     public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
