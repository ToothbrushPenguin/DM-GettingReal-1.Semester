using KvalitetesLedelsesSystem.ViewModels;
using KvalitetesLedelsesSystem.ViewModels.Commands;
using KvalitetesLedelsesSystem.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KvalitetesLedelsesSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Check _check;

        private Plan _plan;

        private AdminLogin _adminLogin;

        private PersonList _personList;

        private AdminMenu _adminMenu;

        private AdminCRUD _adminCRUD;

        private CreateGuest _createGuest;

        

        
        private MainViewModel mvm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;

            _check = new Check();
            _plan = new Plan();
            _adminLogin = new AdminLogin();
            _personList = new PersonList();
            _adminMenu = new AdminMenu();
            _adminCRUD = new AdminCRUD();
            _createGuest = new CreateGuest();
            

            MainFrame.NavigationService.Navigate(_check);
        }

        public void NavigateTo_Admin()
        {
            MainFrame.Navigate(_adminLogin);
        }

        public void NavigateTo_Plan()
        {
            MainFrame.Navigate(_plan);
        }

        public void NavigateTo_Check()
        {
            MainFrame.Navigate(_check);
        }

        public void NavigateTo_PersonList()
        {
            MainFrame.Navigate(_personList);
        }

        public void NavigateTo_AdminMenu()
        {
            MainFrame.Navigate(_adminMenu);
        }

        public void NavigateTo_AdminCRUD()
        {
            MainFrame.Navigate(_adminCRUD);
        }

        public void NavigateTo_CreateGuest()
        {
            MainFrame.Navigate(_createGuest);
        }

    }
}