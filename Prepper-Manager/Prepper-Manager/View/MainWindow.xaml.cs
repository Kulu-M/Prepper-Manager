using Prepper_Manager.View;
using Prepper_Manager.View.Food;
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

namespace Prepper_Manager
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gr_mainGrid.DataContext = App._vm;
        }

        private void b_waterOverview_Click(object sender, RoutedEventArgs e)
        {
            var win = new Water_Overview();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }

        private void b_foodOverview_Click(object sender, RoutedEventArgs e)
        {
            var win = new Food_Overview();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }

    }
}
