using CES_DAL.Models.UsersEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CES_BLL.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Rank { get; set; }

        public UserViewModel()
        {

        }
        public UserViewModel(AppUser user)
        {
            Id = user.Id;
            Name = user.Name;
            Login = user.UserName;
            Password = user.Password;
            Rank = user.Rank;
        }

    }

}
