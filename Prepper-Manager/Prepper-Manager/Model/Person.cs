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

        private string _gender;
        public string gender
        {
            get => _gender;
            set
            {
                _gender = value;
                if (value == "Male")
                    calorieIntake = GlobalSettings.GlobalSettings.dailyCalorieIntakeMale;
                else if (value == "Female")
                {
                    calorieIntake = GlobalSettings.GlobalSettings.dailyCalorieIntakeFemale;
                }
            }
        }

        public int calorieIntake { get; set; }

        public Person()
        {
            
        }

        //TODO make gender IEnumerable
        public IEnumerable<string> Foods
        {
            get
            {
                yield return "Male";
                yield return "Female";
            }
        }
    }
}
