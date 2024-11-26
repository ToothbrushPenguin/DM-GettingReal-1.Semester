﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KvalitetesLedelsesSystem.Models;
using KvalitetesLedelsesSystem.ViewModels.Commands;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private UserRepository userRepository = new UserRepository();
        public ObservableCollection<UserViewModel> userVMs { get; set; } = new ObservableCollection<UserViewModel>();



        public ICommand AddUserCommand {  get; } = new AddUserCommand();
        public ICommand DeleteUserCommand { get; } = new DeleteUserCommand();

        public ICommand CheckInOutCommand { get; } = new CheckInOutCommand();

        private static string username = "Username";
        public string UserName { 
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }



        private UserViewModel _selectedUserVM;
        public UserViewModel SelectedUserVM
        {
            get => _selectedUserVM;
            set
            {
                _selectedUserVM = value; 
                //OnPropertyChanged(nameof(SelectedUserVM));
            }
        }


        public MainViewModel() 
        {
            
            foreach (User user in userRepository.GetAll())
            {
                userVMs.Add(new UserViewModel(user));
            }
        }

        public void AddUser()
        {
            User user = userRepository.Add("User", "", "", UserType.User, "");
            UserViewModel vm = new UserViewModel(user);
            userVMs.Add(vm);
            SelectedUserVM = vm;

        }

        public void RemoveUser() 
        {
            if (SelectedUserVM != null)
            {
                SelectedUserVM.Delete(userRepository);
                userVMs.Remove(SelectedUserVM);
            }
        }

        public void Check()
        {
           

            foreach (UserViewModel uvm in userVMs)
            {
                if (uvm.UserName == UserName)
                {
                    uvm.ChangeCheck(userRepository, uvm.UserName);
                }
            }
           
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
