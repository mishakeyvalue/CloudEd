using System;
using System.Collections.Generic;
using System.Text;

namespace CES_DAL.Models.UsersEntities
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Group> Groups { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
