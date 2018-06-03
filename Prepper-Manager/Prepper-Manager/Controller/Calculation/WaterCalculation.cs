using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Controller.Calculation
{
    public class WaterCalculation
    {
        public static void calculateWater()
        {
            var personCounter = 0;
            double totalWaterCount = 0;
            double totalWaterLastingDays = 0;

            foreach (var person in App._vmData.personList)
            {
                personCounter += 1;
            }

            foreach (var water in App._vmData.waterList)
            {
                totalWaterCount += water.liter * water.count;
            }
            
            totalWaterLastingDays = Math.Round(totalWaterCount / (personCounter *
                                    GlobalSettings.GlobalSettings.waterConsumptionPerDayPerPersonInLiter));


            App._vmData.waterReservesHint = "You have " + totalWaterLastingDays + " days of water.";
        }
    }
}
