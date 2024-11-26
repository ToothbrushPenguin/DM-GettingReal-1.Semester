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
            string newColor;
            var colorPicker = new ColorPickerDialog();


            if (colorPicker.ShowDialog() == true)
            {
                newColor = colorPicker.SelectedColor.ToString();
                if (parameter is string ID)
                {
                    if (ID == "Background")
                    {
                        MainViewModel.colourVMs[0].SelectedColour = newColor;
                    }
                    else if (ID == "Foreround")
                    {
                        MainViewModel.colourVMs[1].SelectedColour = newColor;
                    }
                    else if (ID == "Accent")
                    {
                        MainViewModel.colourVMs[2].SelectedColour = newColor;
                    }
                }
            }
            using(StreamWriter writer = new StreamWriter("Colors.txt",false))
            {
                writer.WriteLine(MainViewModel.colourVMs[0].SelectedColour);
                writer.WriteLine(MainViewModel.colourVMs[1].SelectedColour);
                writer.WriteLine(MainViewModel.colourVMs[2].SelectedColour);
            }
        }
    }
}
