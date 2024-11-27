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
           if(parameter is string ID && ID =="Default")  
           {
                if (MessageBox.Show(
                        messageBoxText: $"Are you sure you want to Restore default settings?",
                        caption: "Delete User?",
                        button: MessageBoxButton.YesNo,
                        icon: MessageBoxImage.Warning,
                        defaultResult: MessageBoxResult.No) == MessageBoxResult.Yes)
                {


                    {
                        // Rewrites the files where colors and images are stored.
                        using (StreamWriter writer = new StreamWriter("Colors.txt"))
                        {
                            writer.WriteLine("#3F3F3F");
                            writer.WriteLine("#FF1E1E1E");
                            writer.WriteLine("#FF373232");
                        }
                        using (StreamWriter writer = new StreamWriter("Images.txt"))
                        {
                            writer.WriteLine("/Views/Societate transparent.png");
                            writer.WriteLine("/Views/Societate transparent.png");
                            writer.WriteLine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Test.pdf"));
                        }

                        // updates The list where colors and images are stored, while program is running.
                        MainViewModel.colourVMs[0].SelectedColour = "#3F3F3F";
                        MainViewModel.colourVMs[1].SelectedColour = "#FF1E1E1E";
                        MainViewModel.colourVMs[2].SelectedColour = "#FF373232";

                        MainViewModel.imageVMs[0].SelectedImage = "/Views/Societate transparent.png";
                        MainViewModel.imageVMs[1].SelectedImage = "/Views/Societate transparent.png";
                        MainViewModel.imageVMs[2].SelectedImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Test.pdf");
                    }
                }

           }   
        }
    }
}
