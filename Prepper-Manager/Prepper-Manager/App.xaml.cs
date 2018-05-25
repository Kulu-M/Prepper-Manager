//using Prepper_Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prepper_Manager.Controller.Calculation;
using Prepper_Manager.Controller.Persistence;
using Prepper_Manager.ViewModel;

namespace Prepper_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PrepperViewModel _vmData = new PrepperViewModel();
        public static MainWindowViewModel _vmView = new MainWindowViewModel();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Load.LoadFromJson();
            //_vmData = DummyDataCreation.createDummyViewModel();

            FoodCalculation.calculateFood();
            WaterCalculation.calculateWater();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Save.SaveToJson();
        }
    }
}
