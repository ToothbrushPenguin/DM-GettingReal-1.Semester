using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private User user;
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Password { get; set; }

        public UserViewModel(User user) 
        {
            this.user = user;
            UserName = user.UserName;
            Name = user.Name;
            Company = user.Company;



            if (user is Admin a)
            {
                Password = a.Password;
            }
            else if (user is Contingency_Responsible c)
            {
                Password = c.Password;
            }
            else
            {
                Password = "";
            }
        }

        public void Delete(UserRepository userRepository)
        {
            userRepository.Remove(user.UserName);
        }

        public void ChangeCheck(UserRepository userRepository, string username)
        {
            userRepository.ChangeCheck(username);
        }



    }
}
