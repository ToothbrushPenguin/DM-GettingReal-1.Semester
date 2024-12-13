using KvalitetesLedelsesSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KvalitetesLedelsesSystem.ViewModels.Commands
{
    public class AdminCRUDCommand : ICommand
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
                AdminCRUD dialog = new AdminCRUD() { DataContext = mvm };
                dialog.ShowDialog();

            }
        }

    }
}
