using KvalitetesLedelsesSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetesLedelsesSystem.Models
{
    public class User : INotifyPropertyChanged
    {
        

        
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        private bool checkInStatus;

        public bool CheckInStatus
        {
            get
            {
                return checkInStatus;
            }
            set
            {
                checkInStatus = value;
                OnPropertyChanged(nameof(CheckInStatus));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public User(string username, string name, string company)
        {

            UserName = username;
            Name = name;
            Company = company;
            CheckInStatus = false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual string ToString() 
        {
            return $"{UserName};{Name};{Company}";
        }

        
    }
}
