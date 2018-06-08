using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Controller.Calculation
{
    public class FoodCalculation
    {
        public static void calculateFood()
        {
            if (App._vmData.foodList == null || App._vmData.foodList.Count < 1 || App._vmData.personList == null ||
                App._vmData.personList.Count < 1) return;

            decimal totalCaloriesStored = 0;
            decimal dailyCalorieConsumption = 0;

            foreach (var food in App._vmData.foodList)
            {
                totalCaloriesStored += food.calories;
            }

            foreach (var person in App._vmData.personList)
            {
                dailyCalorieConsumption += person.calorieIntake;
            }

            try
            {
                var daysOfFoodSupplies = Decimal.Round(totalCaloriesStored / dailyCalorieConsumption);
                if (daysOfFoodSupplies <= 1)
                {
                    App._vmData.foodReservesHint = "Your supplies won't last a day!";
                }
                else
                {
                    App._vmData.foodReservesHint = "You have " + daysOfFoodSupplies + " days of food";
                }
            }
            catch (DivideByZeroException)
            {
                App._vmData.foodReservesHint = "You have no supplies at all.";
            }
            calculateFoodProgress();
        }

        /// <summary>
        /// Used to calculate how far the governmental recommended 2 weeks of water (and food) supplies are reached.
        /// </summary>
        public static void calculateFoodProgress()
        {
            var personCounter = 0;
            int totalCaloriesInSupplies = 0;
            int totalCaloriesNeededPerDay = 0;

            foreach (var person in App._vmData.personList)
            {
                personCounter += 1;
                totalCaloriesNeededPerDay += person.calorieIntake;
            }

            foreach (var food in App._vmData.foodList)
            {
                totalCaloriesInSupplies += food.calories;
            }

            try
            {
                double daysOfCalories = totalCaloriesInSupplies / totalCaloriesNeededPerDay;
                App._vmData.foodProgress = Convert.ToInt32((daysOfCalories / GlobalSettings.GlobalSettings.governmentalRecommendedSupplyPeriodInDays) * 100);
            }
            catch (Exception)
            {
                App._vmData.foodProgress = 0;
            }
        }
    }
}
