using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.View.Pages;
using Prepper_Manager.ViewModel.MainWindow;
using Prepper_Manager.Annotations;
using System.Runtime.CompilerServices;

namespace Prepper_Manager.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //Array of all Pages which are used in the App
        public MainWindowPage[] MainWindowPages { get; }

        //Handling the change of Pages, MainWindow.xaml is bound to this
        private MainWindowPage _SelectedItem;
        public MainWindowPage SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (value != _SelectedItem)
                {
                    _SelectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public MainWindowViewModel()
        {
            //Defines the order of the pages in the sidebar
            MainWindowPages = new[]
            {
                new MainWindowPage("Home", new Home()),
                new MainWindowPage("Test", new Test()),
                new MainWindowPage("Add Person", new AddPerson()),
                new MainWindowPage("Person", new PersonPage())
            };
            //Defines the starting page
            SelectedItem = MainWindowPages[0];
        }

        #region INotify

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotify
    }
}
