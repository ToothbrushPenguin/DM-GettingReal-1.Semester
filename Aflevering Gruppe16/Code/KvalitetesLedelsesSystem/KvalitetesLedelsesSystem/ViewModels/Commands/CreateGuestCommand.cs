using KvalitetesLedelsesSystem.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace KvalitetesLedelsesSystem.ViewModels.Commands
{
    public class CreateGuestCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                // Add new user and auto-number will happen in UserRepository
                mvm.AddUser();

                // Set as guest (normal user)
                mvm.SelectedUserVM.UserType = UserType.User;

                // Show dialog
                CreateGuest dialog = new CreateGuest() { DataContext = mvm };
                dialog.ShowDialog();
            }
        }
    }
}