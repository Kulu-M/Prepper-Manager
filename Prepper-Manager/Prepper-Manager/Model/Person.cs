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

        private string _gender;
        public string gender
        {
            get => _gender;
            set
            {
                _gender = value;
                if (value == "Male")
                    calorieIntake = GlobalSettings.GlobalSettings.dailyCalorieIntakeMaleDefault;
                else if (value == "Female")
                {
                    calorieIntake = GlobalSettings.GlobalSettings.dailyCalorieIntakeFemaleDefault;
                }
            }
        }

        public int calorieIntake { get; set; }

        public string imagePath { get; set; }

        public Person()
        {
            imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImageFiles\default.png");
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
