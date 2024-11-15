using KvalitetesLedelsesSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.Models
{
    class User
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }

        public User(string username, string name, string company)
        {
            UserName = name;
            Name = name;
            Company = company;
        }

        public static User CreateUser(UserType type, string username, string name, string company, string password = null)
        {
            switch (type)
            {
                case UserType.Admin:
                    return new Admin(username, name, company, password);
                case UserType.Contingency_Responsible:
                    return new Contingency_Responsible(username, name, company, password);
                default:
                    return new User(username, name, company);
            }
        }
    }
}
