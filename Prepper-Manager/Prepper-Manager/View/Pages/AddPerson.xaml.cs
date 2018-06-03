using Prepper_Manager.Model;
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
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPerson : UserControl
    {
        public AddPerson()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lb_personList.ItemsSource = App._vmData.personList;
        }
      
        private void lb_personList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region Add, Delete Persons
        
        private void B_acceptDeletePerson_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(lb_personList.SelectedItem is Person)) return;
            var personToRemove = lb_personList.SelectedItem as Person;
            App._vmData.personList.Remove(lb_personList.SelectedItem as Person);

            var messageQueue = sb_delelteSnack.MessageQueue;
            var message = "Deleted " + personToRemove.firstName + " " + personToRemove.lastName + ".";

            //the message queue can be called from any thread
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }

        private void DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {
            var p = new Person();
            p.firstName = tb_newNameTextBox.Text.Trim();
            App._vmData.personList.Add(p);
            var selected = App._vmData.personList.Where(x => x.firstName == p.firstName);
            lb_personList.SelectedItem = selected;
        }

        #endregion Add, Delete Persons       
    }
}
