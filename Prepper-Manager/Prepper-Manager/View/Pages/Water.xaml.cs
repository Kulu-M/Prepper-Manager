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

namespace Prepper_Manager.View.Pages
{
    /// <summary>
    /// Interaction logic for Water.xaml
    /// </summary>
    public partial class Water : UserControl
    {
        public Water()
        {
            InitializeComponent();
        }

        private void B_acceptDeletePerson_OnClick_acceptDeleteWater_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(lb_waterList.SelectedItem is Water)) return;
            var waterToRemove = lb_waterList.SelectedItem as Model.Water;
            App._vmData.waterList.Remove(lb_waterList.SelectedItem as Model.Water);

            var messageQueue = sb_deletedWaterSnackBar.MessageQueue;

            var message = "Deleted " + waterToRemove.name + ".";
            if (!String.IsNullOrWhiteSpace(waterToRemove?.location))
            {
                message = "Deleted " + waterToRemove.name + " in Location " + waterToRemove.location + ".";
            }

            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }

        private void lb_waterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {
            var w = new Model.Water
            {
                name = tb_newNameTextBox.Text.Trim()
            };
            App._vmData.waterList.Add(w);
            var selected = App._vmData.waterList.Where(x => x.name == w.name);
            lb_waterList.SelectedItem = selected;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lb_waterList.ItemsSource = App._vmData.waterList;
        }
    }
}
