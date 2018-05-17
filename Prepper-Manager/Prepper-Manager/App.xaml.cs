using Prepper_Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Prepper_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        PrepperViewModel _vm = new PrepperViewModel();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Load VM
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //SAVE VM
        }
    }
}
