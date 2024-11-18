﻿using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.ViewModels
{
    enum UserType
    {
        User,
        Admin,
        Contingency_Responsible
    }

    class UserRepository
    {

        private List<User> users = new List<User>();
        private List<Admin> admins = new List<Admin>();
        private List<Contingency_Responsible> cons = new List<Contingency_Responsible>();

        public User Get(string userName)
        {
            User result = null;

            foreach (User u in users)
            {
                if (u.UserName == userName)
                {
                    result = u;
                    break;
                }
            }

            return result;
        }

        public User Add(string userName, string name, string company, UserType userType = UserType.User, string password = "1234")
        {
            User result = null;

            if (!string.IsNullOrEmpty(userName) &&
                !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(company))
            {
                
                switch (userType)
                {
                    case UserType.User:
                        result = new User(userName,name,company);
                        break;
                    case UserType.Admin:
                        result = new Admin(userName, name, company, password);
                        break;
                    case UserType.Contingency_Responsible:
                        result = new Contingency_Responsible(userName, name, company, password);
                        break;
                }
                
                users.Add(result);
                
            }
            else
                throw (new ArgumentException("Not all arguments are valid"));

            return result;
        }

        public void Remove(string userName)
        {
            User foundPerson = this.Get(userName);

            if (foundPerson != null)
                users.Remove(foundPerson);
            else
                throw (new ArgumentException("Person with userName = " + userName + " not found"));
        }


        public List<User> GetAll()
        {
            return users;
        }
    }

    
}
