using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CES_DAL.Models.UsersEntities
{
    public class Teacher : AppUser
    {

        public ICollection<Group> Groups { get; set; }
    }
}
