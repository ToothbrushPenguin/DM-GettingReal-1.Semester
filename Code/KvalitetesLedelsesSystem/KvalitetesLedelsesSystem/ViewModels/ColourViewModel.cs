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
        private string _selectedColour;

        public string SelectedColour
        {
            get => _selectedColour;
            set
            {
                _selectedColour = value;
                OnPropertyChanged(nameof(SelectedColour));
            }
        }

        public ColourViewModel(Colour color)
        {
            _selectedColour = color.selectedColour;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
