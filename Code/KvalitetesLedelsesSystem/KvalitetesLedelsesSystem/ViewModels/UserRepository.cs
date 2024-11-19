using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
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


        //HUSK - implement constructor to load from file and methoth to save to file
        public UserRepository() 
        { 
            using(StreamReader reader = new StreamReader("Users.txt"))
            {
                string? line;
                //Line struktur  Password;Username;Name;Company
                string[] lineSplit;
                line = reader.ReadLine();
                while(line != null)
                {
                    lineSplit = line.Split(';');

                }
            }
        }

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

            if(Get(userName)==null)
            {
                if (!string.IsNullOrEmpty(userName) &&
                !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(company))
                {

                    switch (userType)
                    {
                        case UserType.User:
                            result = new User(userName, name, company);
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
                {
                    throw (new ArgumentException("Not all arguments are valid"));
                }
                    
            }
            else
            {
                throw (new ArgumentException("userName allready exists"));
            }
            

            return result;
        }

        public void Remove(string userName)
        {
            User foundPerson = Get(userName);

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
