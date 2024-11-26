using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KvalitetesLedelsesSystem.Models;
using KvalitetesLedelsesSystem.ViewModels.Commands;

namespace KvalitetesLedelsesSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private UserRepository userRepository = new UserRepository();
        public ObservableCollection<UserViewModel> userVMs { get; set; } = new ObservableCollection<UserViewModel>();

        public static ObservableCollection<ColourViewModel> colourVMs { get; set; } = new ObservableCollection<ColourViewModel>();
        public static ObservableCollection<ImageViewModel> imageVMs { get; set; } = new ObservableCollection<ImageViewModel>();
       


        public ICommand AddUserCommand {  get; } = new AddUserCommand();
        public ICommand DeleteUserCommand { get; } = new DeleteUserCommand();
        public ICommand UpdatePath { get; } = new UpdatePath();
        public ICommand UpdateColor {  get; } = new UpdateColor();


        private UserViewModel _selectedUserVM;
        public UserViewModel SelectedUserVM
        {
            get => _selectedUserVM;
            set
            {
                _selectedUserVM = value; 
               // OnPropertyChanged(nameof(SelectedUserVM));
            }
        }


        public MainViewModel() 
        {
            
            foreach (User user in userRepository.GetAll())
            {
                userVMs.Add(new UserViewModel(user));
            }

            //First add is Background Color
            //Second add is Foreground Color
            //Thrid add is Accent Color
            colourVMs.Add(new ColourViewModel(new Colour("#3F3F3F")));
            colourVMs.Add(new ColourViewModel(new Colour("#FFFFFFFF")));
            colourVMs.Add(new ColourViewModel(new Colour("#FF373232")));


            //First add is LogoDrawing
            //Second add is ContingencyDrawing
            //Third add is ContingencyPlan
            imageVMs.Add(new ImageViewModel(new ImageTod("/Views/Societate transparent.png")));
            imageVMs.Add(new ImageViewModel(new ImageTod("/Views/Societate transparent.png")));
            imageVMs.Add(new ImageViewModel(new ImageTod(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Test.pdf"//combiner path til bin med relative path
            ))));      // Adding Colours and Images
        }

        public void AddUser()
        {
            User user = userRepository.Add("User", "", "", UserType.User, "");
            UserViewModel vm = new UserViewModel(user);
            userVMs.Add(vm);
            SelectedUserVM = vm;

        }

        public void RemoveUser() 
        {
            if (SelectedUserVM != null)
            {
                SelectedUserVM.Delete(userRepository);
                userVMs.Remove(SelectedUserVM);
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
