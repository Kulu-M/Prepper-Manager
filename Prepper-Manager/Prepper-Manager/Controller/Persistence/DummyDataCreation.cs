﻿using System;
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
        public static void createDummyPersons()
        {
            App._vmData.personList = new ObservableCollection<Person>();
            App._vmData.personList.Clear();

            var p1 = new Person
            {
                firstName = "Mohammed",
                lastName = "Yass",
                gender = "Male",
                imagePath = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImageFiles\yass.jpg"))
            };

            var p2 = new Person
            {
                firstName = "Babsi",
                lastName = "Sprick",
                gender = "Female",
                imagePath = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImageFiles\sprick.jpg"))
            };

            var p3 = new Person
            {
                firstName = "Gerd",
                lastName = "Möckel",
                gender = "Male",
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
