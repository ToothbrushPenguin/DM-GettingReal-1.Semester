using KvalitetesLedelsesSystem.ViewModels;
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
using KvalitetesLedelsesSystem.Views;

namespace KvalitetesLedelsesSystem.Views
{
    /// <summary>
    /// Interaction logic for Plan.xaml
    /// </summary>
    public partial class Plan : Page
    {
        MainViewModel mvm = new MainViewModel();
        public Plan()
        {
            InitializeComponent();
            DataContext = mvm;
            pdfWebViewer.Navigate(new Uri("about:blank"));
            

            // Navigate to the PDF file
            pdfWebViewer.Navigate(MainViewModel.imageVMs[2].SelectedImage);

           
           
        }

        private void GoBack_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
