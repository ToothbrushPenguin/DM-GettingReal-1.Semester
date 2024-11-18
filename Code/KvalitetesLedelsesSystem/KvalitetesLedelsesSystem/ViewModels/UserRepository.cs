using KvalitetesLedelsesSystem.Models;
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



        public void Update(string userName, string name, string company, UserType userType, string password)
        {
            // Find the person in the internal persons list with same userName as the 'userName'-parameter
            User foundUser = Get(userName);

            if (foundUser != null)
            {
                if (!string.IsNullOrEmpty(userName) &&
                    !string.IsNullOrEmpty(name) &&
                    !string.IsNullOrEmpty(company))
                {

                     
                    switch (foundUser)
                    {
                        case Admin:
                            if (userType == UserType.User)
                            {
                                User newUser = new User(userName, name, company);
                                Remove(userName);
                                users.Add(newUser);

                                foundUser = newUser;
                            }
                            else if(userType == UserType.Contingency_Responsible)
                            {
                                Contingency_Responsible newConingencyResponsible = new Contingency_Responsible(userName, name, company, password);
                                Remove(userName);
                                users.Add(newConingencyResponsible);

                                foundUser = newConingencyResponsible;

                            }
                            else
                            {

                            }

                            break;
                        case Contingency_Responsible:
                            if (userType == UserType.Admin)
                            {
                                Admin newAdmin = new Admin(userName, name, company, password);
                                Remove(userName);
                                users.Add(newAdmin);

                                foundUser = newAdmin;
                            }
                            else if (userType == UserType.User)
                            {
                                User newUser = new User(userName, name, company);
                                Remove(userName);
                                users.Add(newUser);

                                foundUser = newUser;

                            }
                            else
                            {
                                if(foundUser.UserName != userName)
                                {
                                    foundUser.UserName = userName;
                                }
                                if(foundUser.Name != name)
                                {
                                    foundUser.Name = name;
                                }
                                if(foundUser.Company != company)
                                {
                                    foundUser.Company = company;
                                }
                                Admin foundAdmin = foundUser;
                                if(foundUser.password
                            }
                            break;
                        default:
                            if (userType == UserType.Admin)
                            {
                                Admin newAdmin = new Admin(userName, name, company,password);
                                Remove(userName);
                                users.Add(newAdmin);

                                foundUser = newAdmin;
                            }
                            else if (userType == UserType.Contingency_Responsible)
                            {
                                Contingency_Responsible newConingencyResponsible = new Contingency_Responsible(userName, name, company, password);
                                Remove(userName);
                                users.Add(newConingencyResponsible);

                                foundUser = newConingencyResponsible;

                            }
                            else
                            {

                            }

                            break;
                    }

                    // Update only changed properties for this person
                    if (foundPerson.FirstName != firstName)
                        foundPerson.FirstName = firstName;
                    if (foundPerson.LastName != lastName)
                        foundPerson.LastName = lastName;
                    if (foundPerson.Age != age)
                        foundPerson.Age = age;
                    if (foundPerson.Phone != phone)
                        foundPerson.Phone = phone;
                }
                else
                {
                    throw (new ArgumentException("Not all arguments for user are valid"));
                }
                    
            }
            else
            {
                throw (new ArgumentException("Person with userName = " + userName + " not found"));
            }
                
        }



        public List<User> GetAll()
        {
            return users;
        }
    }

    
}
