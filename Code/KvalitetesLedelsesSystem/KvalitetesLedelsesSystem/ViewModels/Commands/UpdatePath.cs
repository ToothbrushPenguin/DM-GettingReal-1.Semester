using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KvalitetesLedelsesSystem.ViewModels.Commands
{
    public class UpdatePath : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MainViewModel mvm = new MainViewModel();
            if (parameter is string ID)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    if(ID == "ContingencyPlan")
                    {
                        string newPath = openFileDialog.FileName;
                        string filetype = newPath.Substring(newPath.Length - 3);
                        if (filetype != "pdf")
                        {
                            MessageBox.Show("Please only select pdf files", "Error: Wrong file type", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        if (filetype == "pdf")
                        {
                            mvm.UpdateImage(ID, openFileDialog.FileName);
                        }
                    }
                    else
                    {
                        mvm.UpdateImage(ID, openFileDialog.FileName);
                    }
                    

                }
            }
        }
    }
}
