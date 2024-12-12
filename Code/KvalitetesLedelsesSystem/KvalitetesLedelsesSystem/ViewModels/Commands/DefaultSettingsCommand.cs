using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KvalitetesLedelsesSystem.ViewModels.Commands
{
    class DefaultSettingsCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MainViewModel mvm = new MainViewModel();


            mvm.Default();
               
            
        }
    }
}
