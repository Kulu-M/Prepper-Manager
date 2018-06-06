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
using Prepper_Manager.Controller.Persistence;

namespace Prepper_Manager.View.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            gr_mainGrid.DataContext = App._vmData;
        }

        private void b_waterOverview_Click(object sender, RoutedEventArgs e)
        {
            App._vmView.SelectedItem = App._vmView.MainWindowPages[1];
        }

        private void b_foodOverview_Click(object sender, RoutedEventArgs e)
        {
            App._vmView.SelectedItem = App._vmView.MainWindowPages[2];
        }

        private void b_peopleOverview_Click(object sender, RoutedEventArgs e)
        {
            App._vmView.SelectedItem = App._vmView.MainWindowPages[3];
        }        

        private void crd_water_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App._vmView.SelectedItem = App._vmView.MainWindowPages[1];
        }

        private void crd_food_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App._vmView.SelectedItem = App._vmView.MainWindowPages[2];
        }

        private void crd_household_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App._vmView.SelectedItem = App._vmView.MainWindowPages[3];
        }
    }
}
