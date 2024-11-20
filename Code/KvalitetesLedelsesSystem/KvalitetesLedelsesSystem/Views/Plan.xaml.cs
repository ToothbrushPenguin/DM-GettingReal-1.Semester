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

namespace KvalitetesLedelsesSystem.Views
{
    /// <summary>
    /// Interaction logic for Plan.xaml
    /// </summary>
    public partial class Plan : Page
    {
        public Plan()
        {
            InitializeComponent();
            pdfWebViewer.Navigate(new Uri("about:blank"));
        

            string relativePath = @"Test.pdf"; // Adjust this to the location relative to your output folder
            string absolutePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            // Navigate to the PDF file
            pdfWebViewer.Navigate(absolutePath);
        }

        private void GoBack_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckinUd_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();  
            
        }
    }
}
