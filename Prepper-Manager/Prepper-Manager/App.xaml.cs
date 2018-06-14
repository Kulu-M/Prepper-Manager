//using Prepper_Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Prepper_Manager.Controller.API;
using Prepper_Manager.Controller.Calculation;
using Prepper_Manager.Controller.Persistence;
using Prepper_Manager.Model;
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
            //Load Saved Data from User (ViewModel)
            Load.LoadFromJson();

            //Language
            if (_vmData.cultureInfo != null)
            {
                Thread.CurrentThread.CurrentUICulture = _vmData.cultureInfo;
            }
            else
            {
                _vmData.cultureInfo = Thread.CurrentThread.CurrentUICulture;
            }

            //Initial Calculations based on stored values
            FoodCalculation.calculateFood();
            WaterCalculation.calculateWater();
            PeopleCalculation.calculateNumberOfPeople();

            //DEBUG: Don't send email every time.
            //RequestEmail.postEmailRequestToEmailAPI(ExpirationCalculation.calculateExpiringFoodItem());
            //ExpirationCalculation.startExpirationEmailChecker();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //Save on Exit
            Save.SaveToJson();
        }
    }
}
