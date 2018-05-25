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
            App._vmData.foodReservesHint = "You have 12 days of food.";
        }
    }
}
