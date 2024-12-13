using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KvalitetesLedelsesSystem.ViewModels.Commands
{
    public class DeleteUserCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = true;

            if (parameter is Window window &&
                window.DataContext is MainViewModel mvm)
            {
                if (mvm.SelectedUserVM == null)
                {
                    result = false;
                }
            }
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is Window window &&
                window.DataContext is MainViewModel mvm)
            {
                string personName = mvm.SelectedUserVM.Name;
                string userName = mvm.SelectedUserVM.UserName;
                if (MessageBox.Show(
                        messageBoxText: $"Are you sure you want to delete {userName} : {personName}?",
                        caption: "Delete User?",
                        button: MessageBoxButton.YesNo,
                        icon: MessageBoxImage.Warning,
                        defaultResult: MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    mvm.RemoveUser();
                    window.Close();
                }
            }
        }
    }
}
