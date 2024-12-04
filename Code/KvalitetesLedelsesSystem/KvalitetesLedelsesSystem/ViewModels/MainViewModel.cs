using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using KvalitetesLedelsesSystem.Models;
using KvalitetesLedelsesSystem.ViewModels.Commands;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private static UserRepository userRepository = new UserRepository();
        public static ObservableCollection<UserViewModel> userVMs { get; set; } = new ObservableCollection<UserViewModel>();

        public ICommand AddUserCommand { get; } = new AddUserCommand();
        public ICommand DeleteUserCommand { get; } = new DeleteUserCommand();
        public ICommand UpdateUserCommand { get; } = new UpdateUserCommand();

        private UserViewModel _selectedUserVM;
        public UserViewModel SelectedUserVM
        {
            get => _selectedUserVM;
            set
            {
                _selectedUserVM = value;
                OnPropertyChanged(nameof(SelectedUserVM));
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

        public void UpdateUser()
        {
            if (SelectedUserVM != null)
            {
                // The Update method in UserViewModel now handles getting all the values
                // from its own properties
                SelectedUserVM.Update(userRepository);

                // Notify UI that the selected user might have changed
                OnPropertyChanged(nameof(SelectedUserVM));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}