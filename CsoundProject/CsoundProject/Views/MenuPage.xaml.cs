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

namespace CsoundProject.Views
{
    /// <summary>
    /// Logique d'interaction pour MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void creationButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CSoundCreationPage());
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PlayerPage());
        }

        private void pianoButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PianoPage());
        }
    }
}
