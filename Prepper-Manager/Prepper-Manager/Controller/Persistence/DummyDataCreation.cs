using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        public static void createAllSampleData()
        {
            createDummyPersons();
            createSampleFoodList();
            createSampleWaterList();

            FoodCalculation.calculateFood();
            WaterCalculation.calculateWater();
            PeopleCalculation.calculateNumberOfPeople();
        }

        public static void createDummyPersons()
        {
            App._vmData.personList = new ObservableCollection<Person>();
            App._vmData.personList.Clear();

            var p1 = new Person
            {
                firstName = "Mohammed",
                lastName = "Yass",
                calorieIntake = 2000,
                imagePath = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImageFiles\yass.jpg"))
            };

            var p2 = new Person
            {
                firstName = "Barbara",
                lastName = "Sprick",
                calorieIntake = 1500,
                imagePath = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImageFiles\sprick.jpg"))
            };

            var p3 = new Person
            {
                firstName = "Gerd",
                lastName = "Möckel",
                calorieIntake = 3000,
                imagePath = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImageFiles\moeckel.jpg"))
            };

            App._vmData.personList.Add(p1);
            App._vmData.personList.Add(p2);
            App._vmData.personList.Add(p3);

            FoodCalculation.calculateFood();
        }

        public static void createSampleFoodList()
        {
            App._vmData.foodList = new ObservableCollection<Food>();
            App._vmData.foodList.Clear();

            var f1 = new Food
            {
                name = "Spaghetti",
                calories = 500,
                location = "Basement",
                expirationDate = DateTime.Now + TimeSpan.FromDays(300)
            };

            var f2 = new Food
            {
                name = "Rice",
                calories = 200,
                location = "Kitchen",
                expirationDate = DateTime.Now + TimeSpan.FromDays(3000)
            };

            var f3 = new Food
            {
                name = "Burnt Popcorn",
                calories = 13337,
                location = "Kitchen",
                expirationDate = DateTime.Now + TimeSpan.FromDays(30)
            };

            var f4 = new Food
            {
                name = "Can of Tuna",
                calories = 100,
                location = "Basement",
                expirationDate = DateTime.Now + TimeSpan.FromDays(2)
            };

            var f5 = new Food
            {
                name = "Korean Cup Noodles Soup Shin Ramyun",
                calories = 5,
                location = "Kitchen",
                expirationDate = DateTime.Now + TimeSpan.FromDays(130)
            };

            App._vmData.foodList.Add(f1);
            App._vmData.foodList.Add(f2);
            App._vmData.foodList.Add(f3);
            App._vmData.foodList.Add(f4);
            App._vmData.foodList.Add(f5);

            FoodCalculation.calculateFood();
        }

        public static void createSampleWaterList()
        {
            App._vmData.waterList = new ObservableCollection<Water>();
            App._vmData.waterList.Clear();

            var w1 = new Water
            {
                name = "Water bottles Bonaqua",
                description = "Sparkling water.",
                liter = 1.5,
                count = 6,
                location = "Basement"
            };

            var w2 = new Water
            {
                name = "Water Keg",
                description = "Big water keg. Bought at Metro Supermarket.",
                liter = 25,
                location = "Basement",
                count = 1
            };

            var w3 = new Water
            {
                name = "JA! Wasser",
                description = "Mehrere Sixpacks und ein paar einzelne Flaschen.",
                liter = 1,
                count = 30,
                location = "Kitchen, behind drawer",

            };

            var w4 = new Water
            {
                name = "Water/Apple Juice Mixed drink",
                description = "Don't give them to the children!",
                liter = 5,
                location = "Under Peter's bed"
            };

            App._vmData.waterList.Add(w1);
            App._vmData.waterList.Add(w2);
            App._vmData.waterList.Add(w3);
            App._vmData.waterList.Add(w4);
        }


    }
}
