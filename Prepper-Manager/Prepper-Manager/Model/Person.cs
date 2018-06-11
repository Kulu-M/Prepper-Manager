using Prepper_Manager.Controller.Calculation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Prepper_Manager.Model
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }        

        private int _calorieIntake;
        public int calorieIntake
        {
            get
            {
                return _calorieIntake;
            }
            set
            {
                _calorieIntake = value;
                FoodCalculation.calculateFood();
                //Just to force an updaten on VM
                App._vmData.totalCalorieConsumption = "";
            }
        }

        public string imagePath { get; set; }

        public Person()
        {
            imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImageFiles\default.png");
            calorieIntake = 2000;
        }        
    }
}
