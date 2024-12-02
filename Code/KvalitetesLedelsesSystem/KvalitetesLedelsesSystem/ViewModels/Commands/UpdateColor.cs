using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haley.Services;
using Haley.MVVM;
using Haley.WPF;
using System.Windows.Input;
using Haley.WPF.Controls;
using System.IO;


namespace KvalitetesLedelsesSystem.ViewModels.Commands
{
    class UpdateColor : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {

            // Commandparameters er en string hvor at, argumentet Background tilgår MainViewModel.colourVMs[0].SelectedImage
            // Argumentet Foreground  tilgår MainViewModel.coulourVMs[1].SelectedImage
            // Argumentet Accent tilgår MainViewModel.colourVMs[2].SelectedImage
            MainViewModel mainViewModel = new MainViewModel();
            if (parameter is string ID)
            {
                mainViewModel.UpdateColour(ID);
            }
            }
    }
}
