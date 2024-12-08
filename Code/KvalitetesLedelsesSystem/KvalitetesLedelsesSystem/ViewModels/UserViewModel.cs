using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private User user;
        private string userName;
        private string name;
        private string company;
        private string password;
        private UserType userType;

        public string UserName
        {
            get => userName;
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Company
        {
            get => company;
            set
            {
                if (company != value)
                {
                    company = value;
                    OnPropertyChanged(nameof(Company));
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public UserType UserType
        {
            get => userType;
            set
            {
                if (userType != value)
                {
                    userType = value;
                    OnPropertyChanged(nameof(UserType));
                    OnPropertyChanged(nameof(IsPasswordEnabled));
                }
            }
        }

        public bool IsPasswordEnabled => UserType != UserType.User;

        public UserViewModel(User user)
        {
            this.user = user;
            UserName = user.UserName;
            Name = user.Name;
            Company = user.Company;

            if (user is Admin)
            {
                Password = ((Admin)user).Password;
                UserType = UserType.Admin;
            }
            else if (user is Contingency_Responsible)
            {
                Password = ((Contingency_Responsible)user).Password;
                UserType = UserType.Contingency_Responsible;
            }
            else
            {
                Password = "";
                UserType = UserType.User;
            }
        }

        public void Delete(UserRepository userRepository)
        {
            userRepository.Remove(user.UserName);
        }

        public void Update(UserRepository userRepository)
        {
            user = userRepository.Update(user.UserName, Name, UserName, Company, Password, UserType);

            // Update local properties to reflect the changes
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



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ChangeCheck(UserRepository userRepository, string username)
        {
            userRepository.ChangeCheck(username);
            userRepository.UpdateLog(username);
            userRepository.CheckedInUsers(username);
        }



    }
}