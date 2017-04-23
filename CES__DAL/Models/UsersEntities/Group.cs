using System;
using System.Collections.Generic;
using System.Text;

namespace CES_DAL.Models.UsersEntities
{
    public class Group
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
