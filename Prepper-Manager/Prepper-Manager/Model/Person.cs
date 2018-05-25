using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Model
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int calorieIntake { get; set; }

        public Person()
        {
            //Set calorie intake depending on gender
        }
    }
}
