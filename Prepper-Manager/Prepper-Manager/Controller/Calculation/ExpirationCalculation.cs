using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Prepper_Manager.Controller.API;
using Food = Prepper_Manager.Model.Food;

namespace Prepper_Manager.Controller.Calculation
{
    public static class ExpirationCalculation
    {
        public static List<Food> calculateExpiringFoodItem()
        {
            var expiringFoodsList = new List<Food>();

            foreach (var food in App._vmData.foodList)
            {
                var time = food.expirationDate - DateTime.Now;
                if (time < TimeSpan.FromDays(7))
                {
                    expiringFoodsList.Add(food);
                }
            }
            return expiringFoodsList;
        }

        public static void startExpirationEmailChecker()
        {
            Thread.CurrentThread.IsBackground = true;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromDays(1) };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            if (calculateExpiringFoodItem().Count >= 1)
            {
                RequestEmail.postEmailRequestToEmailAPI(calculateExpiringFoodItem());
            }
        }
    }
}
