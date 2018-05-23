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
using Prepper_Manager.View.Food;

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
            gr_mainGrid.DataContext = App._vm;
        }

        private void b_waterOverview_Click(object sender, RoutedEventArgs e)
        {
            
            var win = new Water_Overview();

            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }

        private void b_foodOverview_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.DemoItemsListBox.SelectedItem = "";
            var win = new Food_Overview();
            
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }

        
    }
}
