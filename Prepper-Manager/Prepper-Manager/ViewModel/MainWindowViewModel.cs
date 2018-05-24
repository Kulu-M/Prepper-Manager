using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.View.Pages;
using Prepper_Manager.ViewModel.MainWindow;

namespace Prepper_Manager.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowPage[] MainWindowPages { get; }
        
        public MainWindowViewModel()
        {
            MainWindowPages = new[]
            {
                new MainWindowPage("Home", new Home()),
                new MainWindowPage("Test", new Test()),
                new MainWindowPage("Add Person", new AddPerson())
            };
        }
    }
}
