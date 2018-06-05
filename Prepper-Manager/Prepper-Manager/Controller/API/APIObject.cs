using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Controller.API
{
    //Common food from API:
    // brand_name,item_name,brand_id,item_id,upc,item_type,item_description,nf_ingredient_statement,nf_calories,nf_calories_from_fat,nf_total_fat,nf_saturated_fat,nf_trans_fatty_acid,nf_polyunsaturated_fat,nf_monounsaturated_fat,nf_cholesterol,nf_sodium,nf_total_carbohydrate,nf_dietary_fiber,nf_sugars,nf_protein,nf_vitamin_a_dv,nf_vitamin_c_dv,nf_calcium_dv,nf_iron_dv,nf_servings_per_container,nf_serving_size_qty,nf_serving_size_unit,nf_serving_weight_grams,updated_at

    //Grocery food from API:
    // brand_name,item_name,brand_id,item_id,upc,item_type,item_description,nf_ingredient_statement,nf_calories,nf_calories_from_fat,nf_total_fat,nf_saturated_fat,nf_trans_fatty_acid,nf_polyunsaturated_fat,nf_monounsaturated_fat,nf_cholesterol,nf_sodium,nf_total_carbohydrate,nf_dietary_fiber,nf_sugars,nf_protein,nf_vitamin_a_dv,nf_vitamin_c_dv,nf_calcium_dv,nf_iron_dv,nf_potassium,nf_servings_per_container,nf_serving_size_qty,nf_serving_size_unit,nf_serving_weight_grams,metric_qty,metric_uom,images_front_full_url,updated_at,section_ids

    public class APIRootObject
    {
        public List<Food> foods { get; set; }
    }
    
    public class APIObject
    {
        public int attr_id { get; set; }
        public double value { get; set; }
    }

    public class Metadata
    {
        public bool is_raw_food { get; set; }
    }

    public class Tags
    {
        public string item { get; set; }
        public object measure { get; set; }
        public string quantity { get; set; }
        public int food_group { get; set; }
        public int tag_id { get; set; }
    }

    public class AltMeasure
    {
        public double serving_weight { get; set; }
        public string measure { get; set; }
        public int? seq { get; set; }
        public int qty { get; set; }
    }

    public class Photo
    {
        public string thumb { get; set; }
        public string highres { get; set; }
        public bool is_user_uploaded { get; set; }
    }

    public class Food
    {
        public string food_name { get; set; }
        public object brand_name { get; set; }
        public double serving_qty { get; set; }
        public string serving_unit { get; set; }
        public double serving_weight_grams { get; set; }
        public double nf_calories { get; set; }
        public double nf_total_fat { get; set; }
        public double nf_saturated_fat { get; set; }
        public double nf_cholesterol { get; set; }
        public double nf_sodium { get; set; }
        public double nf_total_carbohydrate { get; set; }
        public double nf_dietary_fiber { get; set; }
        public double nf_sugars { get; set; }
        public double nf_protein { get; set; }
        public double nf_potassium { get; set; }
        public double nf_p { get; set; }
        public List<APIObject> full_nutrients { get; set; }
        public object nix_brand_name { get; set; }
        public object nix_brand_id { get; set; }
        public object nix_item_name { get; set; }
        public object nix_item_id { get; set; }
        public object upc { get; set; }
        public DateTime consumed_at { get; set; }
        public Metadata metadata { get; set; }
        public int source { get; set; }
        public int ndb_no { get; set; }
        public Tags tags { get; set; }
        public List<AltMeasure> alt_measures { get; set; }
        public object lat { get; set; }
        public object lng { get; set; }
        public int meal_type { get; set; }
        public Photo photo { get; set; }
        public object sub_recipe { get; set; }
    }

   
}

