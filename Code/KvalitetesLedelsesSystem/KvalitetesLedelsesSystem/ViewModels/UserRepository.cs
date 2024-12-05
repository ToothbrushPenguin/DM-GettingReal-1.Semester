
﻿using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        private bool CheckStatus = false;
        private static string LogPath = Path.GetFullPath(@"Log.txt");


        //HUSK - implement constructor to load from file and methoth to save to file
        public UserRepository() 
        { 
            LoadUsersToList();
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
                    SaveUsersFromList();

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
            {
                users.Remove(foundPerson);
                SaveUsersFromList();
            }   
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
                SaveUsersFromList();


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

        private void LoadUsersToList()
        {
            
            if (File.Exists("Users.txt"))
            {
                users.Clear(); // Clear existing users before loading

                using (StreamReader reader = new StreamReader("Users.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] parts = line.Split(';');

                            // Check number of parts to determine user type
                            // If 4 parts, it's an Admin or Contingency_Responsible (has password)
                            // If 3 parts, it's a regular User
                            if (parts.Length == 4)
                            {
                                // Determine if it's an Admin or Contingency_Responsible based on the username prefix
                                if (parts[0].StartsWith("admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    users.Add(new Admin(parts[0], parts[1], parts[2], parts[3]));
                                }
                                else
                                {
                                    users.Add(new Contingency_Responsible(parts[0], parts[1], parts[2], parts[3]));
                                }
                            }
                            else if (parts.Length == 3)
                            {
                                users.Add(new User(parts[0], parts[1], parts[2]));
                            }
                        }
                    }
                }
            }
        }

        private void SaveUsersFromList()
        {
            using (TextWriter tw = new StreamWriter("Users.txt"))
            {
                foreach (User user in users) 
                {
                    tw.WriteLine(user.ToString());
                }
            }
        }

        // public void ChangeCheck(string username)
        //{
        //    CheckStatus = !CheckStatus;
        //}

        //public void UpdateLog(string userName)
        //{
        //    User foundPerson = Get(userName);

        //    if (foundPerson != null)
        //    {
        //        using (StreamWriter SR = new StreamWriter(LogPath))
        //        {
        //            SR.WriteLine(foundPerson);
        //        }
        //    }
        //    else
        //    {
        //        throw (new ArgumentException("No person with this username was found"));
        //    }

        //}
        public void ChangeCheck(string username)
        {
            User FoundPerson = Get(username);
            FoundPerson.CheckInStatus = !FoundPerson.CheckInStatus;
        }

        public void UpdateLog(string userName)
        {
            User foundPerson = Get(userName);
            DateTime logTime = DateTime.Now;
            string checkMessage = null;

            if (foundPerson != null)
            {

                if (foundPerson.CheckInStatus == true)
                {
                    MessageBox.Show("You have been checked in!");
                    checkMessage = "Checked In";
                }
                else if (foundPerson.CheckInStatus == false)
                {
                    MessageBox.Show("You have been checked out!");
                    checkMessage = "Checked Out";
                }
                using (StreamWriter SR = new StreamWriter(LogPath, true))
                {
                    SR.WriteLine($"{foundPerson.ToString()} {checkMessage} {logTime}");
                }

            }
            else
            {
                throw (new ArgumentException("No person with this username was found"));
            }

        }
    }

    
}
