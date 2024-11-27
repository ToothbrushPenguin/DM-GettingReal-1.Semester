using System;
using System.Collections.Generic;
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
        public ObservableCollection<UserViewModel> userVMs { get; set; } = new ObservableCollection<UserViewModel>();

        public static ObservableCollection<ColourViewModel> colourVMs { get; set; } = new ObservableCollection<ColourViewModel>();
        public static ObservableCollection<ImageViewModel> imageVMs { get; set; } = new ObservableCollection<ImageViewModel>();
       


        public ICommand AddUserCommand {  get; } = new AddUserCommand();
        public ICommand DeleteUserCommand { get; } = new DeleteUserCommand();
        public ICommand AdminCrudCommand { get; } = new AdminCRUDCommand();
        public ICommand AdminLogInCommand {  get; } = new AdminLogInCommand();
        public ICommand AdminMenuCommand { get; } = new AdminMenuCommand();
        public ICommand CheckCommand { get; } = new CheckCommand();
        public ICommand CreateGuestCommand { get; } = new CreateGuestCommand();
        public ICommand PersonListCommand { get; } = new PersonListCommand();
        public ICommand PlanCommand { get; } = new PlanCommand();
        public ICommand UpdatePath { get; } = new UpdatePath();
        public ICommand UpdateColor {  get; } = new UpdateColor();

        public ICommand DefautSettingsCommand { get; }  = new DefaultSettingsCommand();

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


            if (!File.Exists("Colors.txt")|| !File.Exists("Images.txt"))
            {
                if(!File.Exists("Colors.txt"))
                {
                    //File.Create("Colors.txt");
                    using(StreamWriter writer = new StreamWriter("Colors.txt"))
                    {
                        //First add is Background Color
                        //Second add is Foreground Color
                        //Thrid add is Accent Color
                        writer.WriteLine("#3F3F3F");
                        writer.WriteLine("#FF1E1E1E");
                        writer.WriteLine("#FF373232");
                    }
                }
                if(!File.Exists("Images.txt"))
                {
                    //File.Create("Images.txt");
                    using (StreamWriter writer = new StreamWriter("Images.txt"))
                    {
                        //First add is LogoDrawing
                        //Second add is ContingencyDrawing
                        //Third add is ContingencyPlan
                        writer.WriteLine("/Views/Societate transparent.png");
                        writer.WriteLine("/Views/Societate transparent.png");
                        writer.WriteLine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Test.pdf"));
                    }
                }

            }
            if(File.Exists("Colors.txt") && File.Exists("Images.txt"))
            {
                string line;
                int i = 0;

                using (StreamReader reader = new StreamReader("Images.txt"))
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        imageVMs.Add(new ImageViewModel(new ImageTod(line)));
                        i++;
                        line = reader.ReadLine();
                    }
                   
                }
                i = 0; // reset index for new txt file
                using (StreamReader reader = new StreamReader("Colors.txt"))
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        colourVMs.Add(new ColourViewModel(new Colour(line)));
                        i++;
                        line = reader.ReadLine();
                    }
                }

            }

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
