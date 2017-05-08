using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CES_DAL.Models.UsersEntities
{
    public class AppUser : IdentityUser
    {

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
