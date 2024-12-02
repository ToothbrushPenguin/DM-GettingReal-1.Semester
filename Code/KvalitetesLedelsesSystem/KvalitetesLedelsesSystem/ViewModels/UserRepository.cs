using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public enum UserType
    {
        User,
        Admin,
        Contingency_Responsible
    }

    public class UserRepository
    {

        private List<User> users = new List<User>();


        //HUSK - implement constructor to load from file and methoth to save to file
        public UserRepository() 
        { 
            //using(StreamReader reader = new StreamReader("Users.txt"))
            //{
                
            //    string? line;
            //    //Line struktur  Password;Username;Name;Company
            //    string[] lineSplit;
            //    line = reader.ReadLine();
            //    while(line == null)
            //    {
            //        lineSplit = line.Split(';');
            //        if (lineSplit[0] == null)
            //        {
            //            users.Add(new User(lineSplit[1], lineSplit[2], lineSplit[3]));
            //        }
            //        else if (lineSplit[0] != null)
            //        {
            //            users.Add(new Admin(lineSplit[0], lineSplit[1], lineSplit[2], lineSplit[3]));
            //        }    

                    
            //    }
            //}
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

        public User Add(string userName, string name, string company, UserType userType, string password)
        {
            
            User result = null;

            if(Get(userName)==null)
            {
                if (userName != null && name != null && company != null)
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

        public User Update(string oldUserName, string newName, string newUserName, string newCompany, string newPassword, UserType userType)
        {
            User foundPerson = Get(oldUserName);
            User updatedUser = null;

            if (foundPerson != null)
            {
                users.Remove(foundPerson);

                switch (userType)
                {
                    case UserType.Admin:
                        updatedUser = new Admin(newUserName, newName, newCompany, newPassword);
                        break;
                    case UserType.Contingency_Responsible:
                        updatedUser = new Contingency_Responsible(newUserName, newName, newCompany, newPassword);
                        break;
                    case UserType.User:
                        updatedUser = new User(newUserName, newName, newCompany);
                        break;
                }

                users.Add(updatedUser);
            }
            else
            {
                throw new ArgumentException($"User with username {oldUserName} not found");
            }

            return updatedUser;
        }

        private User ConvertUserType(User user, UserType userType)
        {
            User output = user;
            switch (userType)
            {
                case UserType.Admin:
                    if (!(user is Admin))
                    {
                        output = new Admin(user.Name,user.UserName,user.Company,"1234");
                        
                    }
                    
                    break;
                case UserType.Contingency_Responsible:
                    break;
                case UserType.User:
                    break;
                default:
                    break;
            }
            return output;
        }

        public List<User> GetAll()
        {
            return users;
        }
    }

    
}
