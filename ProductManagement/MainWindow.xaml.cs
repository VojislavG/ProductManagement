using ProductManagement.ViewModels;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace ProductManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Clicked(object sender, RoutedEventArgs e)
        {
           
            DataContext = new SearchViewModel();
        }

        private void LagerButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new LagerViewModel();
        }
    }
}
