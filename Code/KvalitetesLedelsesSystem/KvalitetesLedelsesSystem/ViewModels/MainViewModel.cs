using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KvalitetesLedelsesSystem.Models;

namespace KvalitetesLedelsesSystem.ViewModels
{
    class MainViewModel
    {
        private UserRepository userRepository = new UserRepository();
        public ObservableCollection<UserViewModel> userVMs { get; set; } = new ObservableCollection<UserViewModel>();

        public MainViewModel() 
        {
            foreach (User user in userRepository.GetAll())
            {
                userVMs.Add(new UserViewModel(user));
            }
        }

    }
}
