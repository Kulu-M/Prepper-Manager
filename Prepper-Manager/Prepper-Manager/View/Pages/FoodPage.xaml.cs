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
using MaterialDesignThemes.Wpf;
using Prepper_Manager.Controller.API;

namespace Prepper_Manager.View.Pages
{
    /// <summary>
    /// Interaction logic for FoodPage.xaml
    /// </summary>
    public partial class FoodPage : UserControl
    {
        public FoodPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lb_foodList.ItemsSource = App._vmData.foodList;

            lb_searchResults.ItemsSource = App._vmData.apiSearchResults;
        }

        private void DialogHost_AddFood_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {
            
        }

        private void lb_foodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void B_acceptDeleteFood_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {
            
        }

        private void b_addFood(object sender, RoutedEventArgs e)
        {
            
        }

        private void b_removeFood(object sender, RoutedEventArgs e)
        {
            
        }

        private void tb_newFoodTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_newFoodTextBox.Text))
            {
                lb_searchResults.ItemsSource = null;
                return;
            }

            RequestFoodData.queryFoodByName(tb_newFoodTextBox.Text);

            lb_searchResults.ItemsSource = App._vmData.apiSearchResults;
        }
    }
}
