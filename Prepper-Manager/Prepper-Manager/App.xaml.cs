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
            //RequestFoodData.getNutritionValuesForSpecificFoodItemCommon("pasta");

            //DEBUG
            //Thread.Sleep(2000);
            //var x = App._vmData.searchResultsExperimental;
            //object testList = JsonConvert.DeserializeObject(x.ToString());

            //var y = App._vmData.searchResultsExperimental3;

           // JObjectToObjectMapper.mapJObjectToFood(null);

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
