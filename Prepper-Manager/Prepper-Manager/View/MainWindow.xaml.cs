using Prepper_Manager.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prepper_Manager.Controller.API;
using Prepper_Manager.Controller.TipOfTheDay;
using Prepper_Manager.ViewModel;
using Prepper_Manager.Controller.Persistence;

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
            DataContext = App._vmView;
            TipOfTheDay.startTipOfTheDayChanger();

            loadLanguages();
            cb_langBox.SelectionChanged += cb_langBox_SelectionChanged;
        }

        /// <summary>
        /// Load all languages which are present on the pc and add them to the sidebar cb
        /// </summary>
        private void loadLanguages()
        {
            foreach (var ci in CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(ci => ci.Calendar is GregorianCalendar)
                .OrderBy(ci => ci.Name))
            {
                cb_langBox.Items.Add(ci.Name);
            }
            cb_langBox.SelectedItem = App._vmData.cultureInfo.Name;
        }

        private void cb_langBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = cb_langBox.SelectedItem as String;
            if (string.IsNullOrWhiteSpace(selectedItem)) return;

            if (selectedItem == "en-US")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                App._vmData.cultureInfo = new CultureInfo("en-US");
            }
            else if (selectedItem == "de-DE")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                App._vmData.cultureInfo = new CultureInfo("de-DE");
            }
           
            //Safe, Wait a bit, then restart the application to change the language in the UI Thread
            Save.SaveToJson();
            Task.Delay(200);
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            MenuToggleButton.IsChecked = false;
        }

        private void b_restoreSampleData_Click(object sender, RoutedEventArgs e)
        {
            DummyDataCreation.createAllSampleData();

            //SnackBarMessage
            var messageQueue = sb_deletedFoodSnackBar.MessageQueue;
            var message = "Restored sample data.";            
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }

        private void b_sendHtmlEmail_Click(object sender, RoutedEventArgs e)
        {
            RequestEmail.postEmailRequestToEmailAPIWithHTMLBody();
        }

        private void b_debug_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(App._vmData.anyExpiringFoodItemsPresent);
        }
    }
}
