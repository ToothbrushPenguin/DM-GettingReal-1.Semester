using KvalitetesLedelsesSystem.ViewModels;
using KvalitetesLedelsesSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for Check.xaml
    /// </summary>
    public partial class Check : Page
    {
        private MainViewModel mvm = new MainViewModel();
        public Check()
        {
            InitializeComponent();
            DataContext = mvm;
            UserNameBox.Text = mvm.UserName;

        }

        private void ContingencyPlan(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.NavigateTo_Plan();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.NavigateTo_PersonList();

        }

        private void UserNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "UserName")
            {
                textBox.Text = string.Empty; 
                textBox.Foreground = Brushes.Black; 
            }
        }

        private void UserNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "UserName";
                textBox.Foreground = Brushes.Gray; 
            }
        }
    }
}
