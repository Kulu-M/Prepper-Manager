using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.Controller.Calculation;
using Prepper_Manager.Model;
using Prepper_Manager.ViewModel;

namespace Prepper_Manager.Controller.Persistence
{
    public class DummyDataCreation
    {
        public static void createDummyPersons()
        {
            App._vmData.personList = new ObservableCollection<Person>();
            App._vmData.personList.Clear();

            var p1 = new Person
            {
                firstName = "Mohammed",
                lastName = "Yass",
                gender = "Male"
            };
           

            var p2 = new Person();
            p2.firstName = "Babsi";
            p2.lastName = "Sprick";
            p2.gender = "Female";

            var p3 = new Person();
            p3.firstName = "Gerd";
            p3.lastName = "Möckel";
            p3.gender = "Male";

            App._vmData.personList.Add(p1);
            App._vmData.personList.Add(p2);
            App._vmData.personList.Add(p3);

            FoodCalculation.calculateFood();
        }

        public static void createSampleFoodList()
        {
            App._vmData.foodList = new ObservableCollection<Food>();
            App._vmData.foodList.Clear();

            var f1 = new Food();
            f1.foodName = "Spaghetti";
            f1.calories = 500;
            f1.location = "Basement";

            var f2 = new Food();
            f2.foodName = "Rice";
            f2.calories = 200;
            f2.location = "Kitchen";
            
            App._vmData.foodList.Add(f1);
            App._vmData.foodList.Add(f2);

            FoodCalculation.calculateFood();
        }
    }
}
