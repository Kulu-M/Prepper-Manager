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
using Prepper_Manager.Controller.Calculation;

namespace Prepper_Manager.View.Pages
{
    /// <summary>
    /// Interaction logic for WaterPage.xaml
    /// </summary>
    public partial class WaterPage : UserControl
    {
        public WaterPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dg_waterItems.ItemsSource = App._vmData.waterList;
        }

        private void DialogHost_AddWater_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {
            if (String.IsNullOrWhiteSpace(tb_newWaterTextBox.Text)) return;
            var w1 = new Model.Water { name = tb_newWaterTextBox.Text };
            App._vmData.waterList.Add(w1);
            tb_newWaterTextBox.Text = "";
            WaterCalculation.calculateWater();
        }

        private void b_addWater(object sender, RoutedEventArgs e)
        {
            
        }

        private void b_removeWater(object sender, RoutedEventArgs e)
        {
            if (dg_waterItems.SelectedItem == null)
            {
                MessageBox.Show("Select an item from you water supplies.");
                return;
            }

            var waterToRemove = dg_waterItems.SelectedItem as Model.Water;

            App._vmData.waterList.Remove(waterToRemove);

            WaterCalculation.calculateWater();

            //SnackBarMessage
            var messageQueue = sb_deletedWaterSnackBar.MessageQueue;
            var message = "Deleted " + waterToRemove.name + ".";
            if (!String.IsNullOrWhiteSpace(waterToRemove?.location))
            {
                message = "Deleted " + waterToRemove.name + " in Location " + waterToRemove.location + ".";
            }
            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }

        private void dg_waterItems_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            WaterCalculation.calculateWater();
        }
    }
}
