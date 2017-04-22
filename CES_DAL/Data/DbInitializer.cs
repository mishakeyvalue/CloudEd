using CES_DAL.Models.UsersEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CES_DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Teachers.Any()) {
                Teacher Mum = new Teacher() { Name = "Ирина Владимировна", Login = "kilua", Password = "cesadmin144" };
                context.Teachers.Add(Mum);
                context.SaveChanges();
            }
        }
    }
}
