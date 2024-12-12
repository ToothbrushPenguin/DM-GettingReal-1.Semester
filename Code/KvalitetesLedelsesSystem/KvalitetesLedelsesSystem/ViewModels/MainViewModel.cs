using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
        private ColourRepository colourRepository = new ColourRepository();



        private ImageRepository imageRepository = new ImageRepository();//Repositories
        public ObservableCollection<UserViewModel> userVMs { get; set; } = new ObservableCollection<UserViewModel>();

        public static ObservableCollection<ColourViewModel> colourVMs { get; set; } = new ObservableCollection<ColourViewModel>();
        public static ObservableCollection<ImageViewModel> imageVMs { get; set; } = new ObservableCollection<ImageViewModel>();// Observablecollections



        public ICommand AddUserCommand { get; } = new AddUserCommand();
        public ICommand DeleteUserCommand { get; } = new DeleteUserCommand();
        public ICommand AdminCRUDCommand { get; } = new AdminCRUDCommand();
        public ICommand AdminLogInCommand {  get; } = new AdminLogInCommand();
        public ICommand AdminCrudCommand { get; } = new AdminCRUDCommand();
        public ICommand AdminMenuCommand { get; } = new AdminMenuCommand();
        public ICommand CheckCommand { get; } = new CheckCommand();
        public ICommand CreateGuestCommand { get; } = new CreateGuestCommand();
        public ICommand PersonListCommand { get; } = new PersonListCommand();
        public ICommand PlanCommand { get; } = new PlanCommand();
        public ICommand UpdatePath { get; } = new UpdatePath();
        public ICommand UpdateColor { get; } = new UpdateColor();

        public ICommand CheckInOutCommand { get; } = new CheckInOutCommand();

        public ICommand DefautSettingsCommand { get; } = new DefaultSettingsCommand();// Commands
        private static string username = "Username";
        public string UserName {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public ICommand UpdateUserCommand { get; } = new UpdateUserCommand();

        private UserViewModel _selectedUserVM;
        public UserViewModel SelectedUserVM
        {
            get => _selectedUserVM;
            set
            {
                _selectedUserVM = value;
                //OnPropertyChanged(nameof(SelectedUserVM));
            }
        }


        public MainViewModel()
        {
            foreach (User user in userRepository.GetAll())
            {
                userVMs.Add(new UserViewModel(user));
            }
            AddColours();
            AddImages();
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

        public void Check()
        {


            foreach (UserViewModel uvm in userVMs)
            {
                if (uvm.UserName == UserName)
                {
                    uvm.ChangeCheck(userRepository, uvm.UserName);
                }
            }

        }

        public void AddColours() //add all colours to Colour VM's
        {
            colourVMs.Clear();
            foreach (Colour colour in colourRepository.GetAll())
            {
                colourVMs.Add(new ColourViewModel(colour));
            }
        }


        public void UpdateColour(string ID, string newColor)
        {
            ColourViewModel.Update(colourRepository, ID, newColor);
            AddColours();
        }

        public void AddImages()//adds all images
        {
            imageVMs.Clear();
            foreach (ImageTod image in imageRepository.GetAll())
            {
                imageVMs.Add(new ImageViewModel(image));
            }
            
            
        }

        public void Default()
        {
            ImageViewModel.Default(imageRepository);
            ColourViewModel.Default(colourRepository); 
        }
        public void UpdateImage(string ID, string newPath )
        {
            imageRepository.UpdateImage(ID, newPath);
            AddImages();
        }
        public bool UpdateUser()
        {
            if (SelectedUserVM != null)
            {
                // The Update method in UserViewModel now handles getting all the values
                // from its own properties
                bool output = SelectedUserVM.Update(userRepository);

                // Notify UI that the selected user might have changed
                //OnPropertyChanged(nameof(SelectedUserVM));

                return output;
            }
            return false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}