//using Prepper_Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            //DEBUG
            RequestFoodData.getNutritionValuesForSpecificFoodItemCommon("pasta");
            //Thread.Sleep(2000);
            //App._vmData.searchResultsExperimental4 = JsonConvert.DeserializeObject<APIRootObject>(App._vmData.searchResultsExperimental5);
            // object testList = JsonConvert.DeserializeObject(x.ToString());
            //~DEBUG

            var x = App._vmData.searchResultsExperimental5;
            var y = App._vmData.searchResultsExperimental4;

            //Load Saved Data from User
            Load.LoadFromJson();

            //Initial Calculations based on stored values
            FoodCalculation.calculateFood();
            WaterCalculation.calculateWater();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //Save on Exit
            Save.SaveToJson();
        }
    }
}
