using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.ViewModels
{
    class UserViewModel
    {
        private User user;
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public UserViewModel(User user) 
        {
            this.user = user;
            UserName = user.UserName;
            Name = user.Name;
            Company = user.Company;
        }

        public void Delete(UserRepository userRepository)
        {
            userRepository.Remove(user.UserName);
        }


    }
}
