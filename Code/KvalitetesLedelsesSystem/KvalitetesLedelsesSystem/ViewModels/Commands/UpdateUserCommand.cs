using System;
using System.Windows;
using System.Windows.Input;

namespace KvalitetesLedelsesSystem.ViewModels.Commands
{
    public class UpdateUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;

            if (parameter is Window window &&
                window.DataContext is MainViewModel mvm)
            {
                if (mvm.SelectedUserVM == null ||
                    string.IsNullOrWhiteSpace(mvm.SelectedUserVM.UserName) ||
                    string.IsNullOrWhiteSpace(mvm.SelectedUserVM.Name) ||
                    string.IsNullOrWhiteSpace(mvm.SelectedUserVM.Company))
                {
                    result = false;
                }
            }

            return result;
        }

        public void Execute(object parameter)
        {
            if (parameter is Window window &&
                window.DataContext is MainViewModel mvm)
            {
                try
                {
                    mvm.UpdateUser();
                    MessageBox.Show("User updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    window.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}