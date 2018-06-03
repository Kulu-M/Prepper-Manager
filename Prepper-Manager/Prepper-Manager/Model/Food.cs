using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Model
{
    //Common food from API:
    // brand_name,item_name,brand_id,item_id,upc,item_type,item_description,nf_ingredient_statement,nf_calories,nf_calories_from_fat,nf_total_fat,nf_saturated_fat,nf_trans_fatty_acid,nf_polyunsaturated_fat,nf_monounsaturated_fat,nf_cholesterol,nf_sodium,nf_total_carbohydrate,nf_dietary_fiber,nf_sugars,nf_protein,nf_vitamin_a_dv,nf_vitamin_c_dv,nf_calcium_dv,nf_iron_dv,nf_servings_per_container,nf_serving_size_qty,nf_serving_size_unit,nf_serving_weight_grams,updated_at

    //Grocery food from API:
    // brand_name,item_name,brand_id,item_id,upc,item_type,item_description,nf_ingredient_statement,nf_calories,nf_calories_from_fat,nf_total_fat,nf_saturated_fat,nf_trans_fatty_acid,nf_polyunsaturated_fat,nf_monounsaturated_fat,nf_cholesterol,nf_sodium,nf_total_carbohydrate,nf_dietary_fiber,nf_sugars,nf_protein,nf_vitamin_a_dv,nf_vitamin_c_dv,nf_calcium_dv,nf_iron_dv,nf_potassium,nf_servings_per_container,nf_serving_size_qty,nf_serving_size_unit,nf_serving_weight_grams,metric_qty,metric_uom,images_front_full_url,updated_at,section_ids


    public class Food
    {
        public string foodName { get; set; }
        public string servingUnit { get; set; }
        public string itemName { get; set; }
        public string brandName { get; set; }
        public int calories { get; set; }
        public string location { get; set; }
    }
}
