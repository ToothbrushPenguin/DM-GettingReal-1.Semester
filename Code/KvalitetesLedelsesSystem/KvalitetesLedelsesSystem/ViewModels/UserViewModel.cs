using KvalitetesLedelsesSystem.Models;
using System;
using System.Collections.Generic;
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
        private string pendingUserName;
        private string name;
        private string company;
        private string password;
        private UserType userType;
        private string asString;

        public string AsString
        {
            get => asString;
            private set
            {
                if (asString != value)
                {
                    asString = value;
                    OnPropertyChanged(nameof(AsString));
                }
            }
        }

        private void UpdateDisplayString()
        {
            AsString = $"{UserName} - {Name} - {Company} - {UserType}";
        }

        public string UserName
        {
            get => userName;
            private set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged(nameof(UserName));
                    UpdateDisplayString();
                }
            }
        }

        public string PendingUserName
        {
            get => pendingUserName;
            set
            {
                if (pendingUserName != value)
                {
                    pendingUserName = value;
                    OnPropertyChanged(nameof(PendingUserName));
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
                    UpdateDisplayString();
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
                    UpdateDisplayString();
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
                    OnPropertyChanged(nameof(IsUserType));
                    OnPropertyChanged(nameof(IsAdminType));
                    OnPropertyChanged(nameof(IsContingencyType));
                    UpdateDisplayString();
                }
            }
        }

        public bool IsUserType
        {
            get => UserType == UserType.User;
            set
            {
                if (value)
                {
                    UserType = UserType.User;
                }
            }
        }

        public bool IsAdminType
        {
            get => UserType == UserType.Admin;
            set
            {
                if (value)
                {
                    UserType = UserType.Admin;
                }
            }
        }

        public bool IsContingencyType
        {
            get => UserType == UserType.Contingency_Responsible;
            set
            {
                if (value)
                {
                    UserType = UserType.Contingency_Responsible;
                }
            }
        }

        public bool IsPasswordEnabled => UserType != UserType.User;

        public UserViewModel(User user)
        {
            this.user = user;
            UserName = user.UserName;
            PendingUserName = user.UserName;
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

            UpdateDisplayString();
        }

        public void Delete(UserRepository userRepository)
        {
            userRepository.Remove(user.UserName);
        }

        public bool Update(UserRepository userRepository)
        {
            User newUser = userRepository.Update(user.UserName, Name, PendingUserName, Company, Password, UserType);
            if (newUser != user)
            {
                user = newUser;

                UserName = user.UserName;
                PendingUserName = user.UserName;
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChangeCheck(UserRepository userRepository, string username)
        {
            userRepository.ChangeCheck(username);
            userRepository.UpdateLog(username);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}