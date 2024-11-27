using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KvalitetesLedelsesSystem.Models;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public class ImageViewModel : INotifyPropertyChanged
    {
        


         public ImageViewModel(ImageTod image)
         {
            
             _selectedImage = image.selectedPath;
         }
      
        private string _selectedImage;

        public string SelectedImage
        {
            get => _selectedImage;
            set
            {
                _selectedImage = value;
                OnPropertyChanged(nameof(SelectedImage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
