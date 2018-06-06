using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Controller.API
{
    public class APIRootObjectToNutritionValuesStringConverter
    {
        public static string createStringFromAPIRootObject(APIRootObject apiRoot)
        {
            string s = "";
            try
            {
                s = "Calories: " + apiRoot.foods[0].nf_calories + Environment.NewLine + "Cholesterol: " + apiRoot.foods[0].nf_cholesterol + Environment.NewLine + "Protein: " + apiRoot.foods[0].nf_protein + Environment.NewLine + "Saturated fat: " + apiRoot.foods[0].nf_saturated_fat + Environment.NewLine + "Sugars: " + apiRoot.foods[0].nf_sugars + Environment.NewLine + "Sodium: " + apiRoot.foods[0].nf_sodium + Environment.NewLine + "Carbohydrates: " + apiRoot.foods[0].nf_total_carbohydrate + Environment.NewLine + "Total fat: " + apiRoot.foods[0].nf_total_fat;
            }
            catch (Exception)
            {
                
            }            
            return s;
        }

        public static int extractCaloriesFromAPIRootObject(APIRootObject apiRoot)
        {
            var value = 0;
            try
            {
                value = Convert.ToInt32(apiRoot.foods[0].nf_calories);
            }
            catch (Exception)
            {

            }
            return value;
        } 
    }
}
