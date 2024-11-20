using KvalitetesLedelsesSystem.ViewModels;
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

        

        
        private MainViewModel mvm = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;

            _check = new Check();
            _plan = new Plan();
            _adminLogin = new AdminLogin();
            _personList = new PersonList();
            

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
        public void NavigateTo_AdminCRUD() 
        {
            AdminCRUD _adminCRUD = new AdminCRUD(mvm);
            _adminCRUD.ShowDialog();
        }

    }
}