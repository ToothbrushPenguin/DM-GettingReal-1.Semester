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
using System.Windows.Shapes;

namespace KvalitetesLedelsesSystem.Views
{
    /// <summary>
    /// Interaction logic for AdminDeleteUser.xaml
    /// </summary>
    public partial class AdminDeleteUser : Window
    {
        public AdminDeleteUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string personName = "temp"; // neeeds to be replased
            string userName = "temp"; // neeeds to be replased
            if (MessageBox.Show(
                    messageBoxText: $"Are you shure you want to delete {userName} : {personName}?",
                    caption: "Delete User?",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Warning,
                    defaultResult: MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                // Do something here
            }
        }
    }
}
