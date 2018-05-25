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
            App._vmData.waterReservesHint = "You have 53 days of water.";
        }
    }
}
