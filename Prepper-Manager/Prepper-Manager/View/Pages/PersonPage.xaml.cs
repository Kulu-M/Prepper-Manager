using System;
using System.Collections.Generic;
using System.IO;
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
using MaterialDesignThemes.Wpf;
using Prepper_Manager.Controller.Calculation;
using Prepper_Manager.Model;

namespace Prepper_Manager.View.Pages
{
    /// <summary>
    /// Interaction logic for PersonPage.xaml
    /// </summary>
    public partial class PersonPage : UserControl
    {
        public PersonPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ic_mainItemControl.ItemsSource = App._vmData.personList;
        }
        private void b_addPerson_Click(object sender, RoutedEventArgs e)
        {
            var p = new Person { firstName = "New Person" };
            App._vmData.personList.Add(p);
            FoodCalculation.calculateFood();
        }

        private void b_acceptDeletePerson_OnClick(object sender, RoutedEventArgs e)
        {
            App._vmData.personList.Remove(((((sender as Button).Parent as StackPanel).Parent as StackPanel).Parent as Card).DataContext as Person);
        }
    }
}
