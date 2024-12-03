using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
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


        private static string LogPath = Path.GetFullPath(@"Log.txt");

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

        public User Add(string userName, string name, string company, UserType userType, bool checkInStatus, string password)
        {
            
            User result = null;

            if(Get(userName)==null)
            {
                if (userName != null && name != null && company != null)
                {

                    switch (userType)
                    {
                        case UserType.User:
                            result = new User(userName, name, company, checkInStatus);
                            break;
                        case UserType.Admin:
                            result = new Admin(userName, name, company, checkInStatus, password);
                            break;
                        case UserType.Contingency_Responsible:
                            result = new Contingency_Responsible(userName, name, company, checkInStatus, password);
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

        public void ChangeCheck(string username)
        {
            User FoundPerson = Get(username);
            FoundPerson.CheckInStatus = !FoundPerson.CheckInStatus;
        }

        public void UpdateLog(string userName)
        {
            User foundPerson = Get(userName);

            if (foundPerson != null)
            {
                using (StreamWriter SR = new StreamWriter(LogPath))
                {
                    SR.WriteLine(foundPerson);
                }
            }
            else
            {
                throw (new ArgumentException("No person with this username was found"));
            }
            
        }
    }

    
}
