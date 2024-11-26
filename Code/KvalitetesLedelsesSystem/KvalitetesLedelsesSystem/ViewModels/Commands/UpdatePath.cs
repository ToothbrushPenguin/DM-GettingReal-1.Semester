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

            // Commandparameters er en string hvor at, argumentet Logo tilgår MainViewModel.imageVMs[0].SelectedImage
            // Argumentet ContingencyDrawing tilgår MainViewModel.imageVMs[1].SelectedImage
            // Argumentet ContingencyPlan tilgår MainViewModel.imageVMs[2].SelectedImage
            string newpath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                if (parameter is string ID)
                {
                    if(ID == "Logo")
                    {
                        newpath = openFileDialog.FileName;
                        //newpath.Replace(@"\", "/"); 
                        MainViewModel.imageVMs[0].SelectedImage = newpath;
                    }
                    else if (ID =="ContingencyDrawing")
                    {
                      newpath = openFileDialog.FileName;
                      //newpath.Replace(@"\", "/"); 
                      MainViewModel.imageVMs[1].SelectedImage = newpath;
                    }
                    else if (ID =="ContingencyPlan")
                    {
                        newpath = openFileDialog.FileName;
                        string[] check = newpath.Split('.');
                        if (check[1] !="pdf")
                        {
                          MessageBox.Show("Please only select pdf files","Error: Wrong file type",MessageBoxButton.OK, MessageBoxImage.Error);  
                        }
                        else if(check[1] == "pdf") 
                        {
                            //newpath.Replace(@"\", "/"); 
                            MainViewModel.imageVMs[2].SelectedImage = newpath;
                        }
                    }
                    
                    using(StreamWriter writer = new StreamWriter("Images.txt",false))
                    {
                        writer.WriteLine(MainViewModel.imageVMs[0].SelectedImage);
                        writer.WriteLine(MainViewModel.imageVMs[1].SelectedImage);
                        writer.WriteLine(MainViewModel.imageVMs[2].SelectedImage);
                    }




                }
            }
                          
            
        }
    }
}
