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
            if (lb_foodList.SelectedItem == null)
            {
                MessageBox.Show("Please select a food supply from your List!");
                return;
            }

            var foodToRemove = lb_foodList.SelectedItem as Model.Food;
            App._vmData.foodList.Remove(foodToRemove);

            //SnackBarMessage
            var messageQueue = sb_deletedFoodSnackBar.MessageQueue;
            var message = "Deleted " + foodToRemove.foodName + ".";
            if (!String.IsNullOrWhiteSpace(foodToRemove?.location))
            {
                message = "Deleted " + foodToRemove.foodName + " in Location " + foodToRemove.location + ".";
            }
            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }

        private void tb_newFoodTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_newFoodTextBox.Text))
            {
                lb_searchResults.ItemsSource = null;
                return;
            }

            //Debug: don't query API
            //lb_searchResults.ItemsSource = new List<string>
            //{
            //    "bigmac",
            //    "pasta",
            //    "spareribs"
            //};

            //Release: query API
            RequestFoodData.queryFoodByName(tb_newFoodTextBox.Text);

            if (App._vmData.apiSearchResults != null && App._vmData.apiSearchResults.Count > 0)
            {
                lb_searchResults.ItemsSource = App._vmData.apiSearchResults.Take(7);
            }            
        }

        private void lb_searchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_newFoodTextBox.Text = lb_searchResults.SelectedItem.ToString();
            exp_temporaryNutritionValuesExpander.Visibility = Visibility.Visible;
            //exp_temporaryNutritionValuesExpander.IsEnabled = true;

            var temp = RequestFoodData.getNutritionValuesForSpecificFoodItemCommon(tb_newFoodTextBox.Text);

            //foreach (var nutr in temp)
            //{
                
            //}

            tb_temporaryNutritionValuesTextBox.Text = "Calories: " + temp.foods[0].nf_calories + Environment.NewLine + "Cholesterol: " + temp.foods[0].nf_cholesterol + Environment.NewLine + "Protein: " + temp.foods[0].nf_protein + Environment.NewLine + "Saturated fat: " + temp.foods[0].nf_saturated_fat + Environment.NewLine + "Sugars: " + temp.foods[0].nf_sugars + Environment.NewLine + "Sodium: " + temp.foods[0].nf_sodium + Environment.NewLine + "Carbohydrates: " + temp.foods[0].nf_total_carbohydrate + Environment.NewLine + "Total fat: " + temp.foods[0].nf_total_fat; 
        }

        //private void lb_searchResults_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    exp_temporaryNutritionValuesExpander.Visibility = Visibility.Visible;
        //}

        //private void lb_searchResults_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    exp_temporaryNutritionValuesExpander.Visibility = Visibility.Collapsed;
        //}
    }
}
