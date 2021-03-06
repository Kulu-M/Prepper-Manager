﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;
using Prepper_Manager.Controller.API;
using Prepper_Manager.Controller.Calculation;

namespace Prepper_Manager.View.Pages
{
    /// <summary>
    /// Interaction logic for FoodPage.xaml
    /// </summary>
    public partial class FoodPage : UserControl
    {
        APIRootObject temporaryFood = null;
        string temporaryNutritionValuesString = "";
        bool dontUpdate = false;

        public FoodPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lb_foodList.ItemsSource = App._vmData.foodList;

            lb_searchResults.ItemsSource = App._vmData.apiSearchResults;
        }

        private void b_addFoodDialogAccept_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_newFoodTextBox.Text))
            {
                lb_searchResults.ItemsSource = null;
                return;
            }

            var newFood = new Model.Food();
            newFood.name = tb_newFoodTextBox.Text;
            newFood.nutritionValuesString = temporaryNutritionValuesString;

            if (temporaryFood != null)
            {
                newFood.calories = APIRootObjectToNutritionValuesStringConverter.extractCaloriesFromAPIRootObject(temporaryFood);
            }
            else
            {
                newFood.calories = 0;
            }

            App._vmData.foodList.Add(newFood);

            temporaryNutritionValuesString = "";
            temporaryFood = null;

            FoodCalculation.calculateFood();
        }

        private void DialogHost_AddFood_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {
        }

        private void lb_foodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void b_addFood(object sender, RoutedEventArgs e)
        {
            //App._vmData.apiSearchResults = new List<string>();
            //lb_searchResults.ItemsSource = App._vmData.apiSearchResults;
            tb_newFoodTextBox.Text = "";
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

            FoodCalculation.calculateFood();

            //SnackBarMessage
            var messageQueue = sb_deletedFoodSnackBar.MessageQueue;
            var message = "Deleted " + foodToRemove.name + ".";
            if (!String.IsNullOrWhiteSpace(foodToRemove?.location))
            {
                message = "Deleted " + foodToRemove.name + " in Location " + foodToRemove.location + ".";
            }
            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }

        private void tb_newFoodTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dontUpdate || string.IsNullOrWhiteSpace(tb_newFoodTextBox.Text))
            {
                lb_searchResults.ItemsSource = null;
                return;
            }

            pb_AddFoodLoadingBar.Visibility = Visibility.Visible;
            try
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => { })).Wait();
            }
            catch (Exception)
            {
                // ignored
            }

            //Debug: don't query API
            //lb_searchResults.ItemsSource = new List<string>
            //{
            //    "bigmac",
            //    "pasta",
            //    "spareribs"
            //};

            //Release: query API
            //RequestFoodData.queryFoodByName(tb_newFoodTextBox.Text);
            if (App._vmData.apiSearchResults != null && App._vmData.apiSearchResults.Count > 0)
            {
                lb_searchResults.ItemsSource = App._vmData.apiSearchResults.Take(7);
            }

            pb_AddFoodLoadingBar.Visibility = Visibility.Hidden;
        }

        private void lb_searchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_searchResults.SelectedItem == null) return;
            dontUpdate = true;

            pb_AddFoodLoadingBar.Visibility = Visibility.Visible;
            exp_temporaryNutritionValuesExpander.Visibility = Visibility.Visible;
            tb_newFoodTextBox.Text = lb_searchResults.SelectedItem.ToString(); //check if this gets fired from here

            //Wait for UI Thread to display Loading Bar
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => { })).Wait();

            BackgroundWorker bw = new BackgroundWorker();
            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    BackgroundWorker b = o as BackgroundWorker;

                    //Set the result and do the API Request
                    args.Result = RequestFoodData.getNutritionValuesForSpecificFoodItemCommon(args.Argument as string);
                });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {
                temporaryFood = args.Result as APIRootObject;
                temporaryNutritionValuesString = APIRootObjectToNutritionValuesStringConverter.createStringFromAPIRootObject(temporaryFood);
                tb_temporaryNutritionValuesTextBox.Text = temporaryNutritionValuesString;
                pb_AddFoodLoadingBar.Visibility = Visibility.Hidden;
                dontUpdate = false;
            });
            var searchString = tb_newFoodTextBox.Text;
            bw.RunWorkerAsync(searchString);
        }

        private void b_warningExpiringFood_Click(object sender, RoutedEventArgs e)
        {
            //SnackBarMessage
            var messageQueue = sb_homeSnacker.MessageQueue;
            var message = "This item is expiring. You should consume and replace it!";
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }
    }
}
