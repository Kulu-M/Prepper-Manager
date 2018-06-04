using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Controller.API
{
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
        public int serving_qty { get; set; }
        public string serving_unit { get; set; }
        public int serving_weight_grams { get; set; }
        public double nf_calories { get; set; }
        public double nf_total_fat { get; set; }
        public double nf_saturated_fat { get; set; }
        public int nf_cholesterol { get; set; }
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

