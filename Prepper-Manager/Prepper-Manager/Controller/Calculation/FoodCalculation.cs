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
            decimal daysOfFoodSupplies = 0;
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
                daysOfFoodSupplies = Decimal.Round(totalCaloriesStored / dailyCalorieConsumption);
                if (daysOfFoodSupplies <= 1)
                {
                    App._vmData.foodReservesHint = "Your supplies won't last a day!";
                }
                else
                {
                    App._vmData.foodReservesHint = "You have " + daysOfFoodSupplies + " days of food.";
                }
            }
            catch (DivideByZeroException)
            {
                App._vmData.foodReservesHint = "You have no supplies at all.";
            }
        }
    }
}
