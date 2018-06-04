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
            App._vmData.peopleCountHint = App._vmData.personList.Count + " people in your household";
        }
    }
}
