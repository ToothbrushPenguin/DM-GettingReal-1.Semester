using System;
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
    class MainViewModel : BaseViewModel
    {
        private UserRepository userRepository = new UserRepository();
        public ObservableCollection<UserViewModel> userVMs { get; set; } = new ObservableCollection<UserViewModel>();

        public ICommand AddUserCommand {  get; } = new AddUserCommand();

        private UserViewModel _selectedUserVM;
        public UserViewModel SelectedUserVM { get; set; }


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

       
      
        

    }
}
