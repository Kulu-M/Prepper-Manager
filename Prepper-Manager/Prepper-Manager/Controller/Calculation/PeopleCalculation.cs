using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Controller.Calculation
{
    public static class PeopleCalculation
    {
        public static void calculateNumberOfPeople()
        {
            if (App._vmData.personList == null || App._vmData.personList.Count < 1) return;

            App._vmData.peopleCountHint = App._vmData.personList.Count + " people in your household";
        }

        public static int calculateTotalDailyCalorieConsumption()
        {
            if (App._vmData.personList == null || App._vmData.personList.Count < 1) return 0;
            
            var consumption = 0;
            foreach (var p in App._vmData.personList)
            {
                consumption += p.calorieIntake;
            }
            return consumption;
        }
    }
}
