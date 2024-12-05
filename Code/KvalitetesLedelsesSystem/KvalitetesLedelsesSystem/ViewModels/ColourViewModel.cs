using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KvalitetesLedelsesSystem.Models;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public class ColourViewModel : INotifyPropertyChanged
    {

        public Colour colour { get; set; }

        private string _selectedColour;

     
        public string SelectedColour
        {
            get => _selectedColour;
            set
            {
                if (_selectedColour != value)
                {
                    _selectedColour = value;
                    OnPropertyChanged(nameof(SelectedColour));
                }
            }
        }

        public ColourViewModel(Colour colour)
        {
            this.colour = colour;
            _selectedColour = colour.selectedColour;
        }

        public static void Update(ColourRepository colourRepository,string ID , string newColor)
        {
            colourRepository.Update(ID, newColor);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public static void Default(ColourRepository colourRepository)
        {
            colourRepository.Default();
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
