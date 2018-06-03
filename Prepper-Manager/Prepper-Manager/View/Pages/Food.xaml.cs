using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Food.xaml
    /// </summary>
    public partial class Food : UserControl
    {
        public Food()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dg_foodItems.ItemsSource = App._vmData.foodList;

            lb_searchResults.ItemsSource = App._vmData.apiSearchResults;
        }

        private void b_addFood(object sender, RoutedEventArgs e)
        {
            var f1 = new Model.Food {foodName = "New item"};
            App._vmData.foodList.Add(f1);
        }

        private void b_removeFood(object sender, RoutedEventArgs e)
        {
            if (dg_foodItems.SelectedItem != null) return;
            App._vmData.foodList.Remove(dg_foodItems.SelectedItem as Model.Food);
        }

        private void DialogHost_AddFood_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {
            
        }

        private void tb_newFoodTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_newFoodTextBox.Text)) return;
            
            RequestFoodData.queryFoodByName(tb_newFoodTextBox.Text);

            lb_searchResults.ItemsSource = App._vmData.apiSearchResults;
        }
    }
}
