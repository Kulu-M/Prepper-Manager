using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prepper_Manager.Model;
using RestSharp;

namespace Prepper_Manager.Controller.API
{
    public class RequestFoodData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchItem"></param> 
        /// Search item Name
        /// <param name="searchForBrandItems"></param>
        /// Set this to true to search for Brand items instead of just food items
        /// For example: Barilla instead of Spaghetti
        /// 
        public static void queryFoodByName(string searchItem, bool searchForBrandItems = false)
        {
            var client = new RestClient("https://www.nutritionix.com");

            var request = new RestRequest("/track-api/v2/search/instant?branded=false&common=true&query={id}&self=false", Method.GET);
            request.AddUrlSegment("id", searchItem);

            if (searchForBrandItems)
            {
                request.AddUrlSegment("branded=false", "branded=true");
            }

            var asyncHandler = client.ExecuteAsync<List<object>>(request, r =>
            {
                if (r.ResponseStatus == ResponseStatus.Completed)
                {
                    App._vmData.apiSearchResults = JObject.Parse(r.Content)["common"].Select(p => p["food_name"].Value<string>()).ToList();
                }
            });
        }

        public static APIRootObject getNutritionValuesForSpecificFoodItemCommon(string searchItem)
        {
            var client = new RestClient("https://trackapi.nutritionix.com");

            var request = new RestRequest("/v2/natural/nutrients", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-app-id", NutritionixAPIKey.ApplicationID);
            request.AddHeader("x-app-key", NutritionixAPIKey.ApplicationKey);
            request.AddHeader("x-remote-user-id", "0");

            request.RequestFormat = DataFormat.Json;
            
            //Add the JSON Body
            request.AddJsonBody(new {query = searchItem});

            //var response = client.Execute(request);

            //App._vmData.searchResultsExperimental = JObject.Parse(response.Content)["foods"].ToList();

            //request.AddBody(new { query = searchItem});
            //var x = client.Execute(request);

            //Working:
            //App._vmData.searchResultsExperimental5 = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<APIRootObject>(client.Execute(request).Content);

            //var asyncHandler = client.ExecuteAsync<List<object>>(request, r =>
            //{
            //    if (r.ResponseStatus == ResponseStatus.Completed)
            //    {
            //        App._vmData.searchResultsExperimental5 = r.Content;
            //        App._vmData.searchResultsExperimental = JObject.Parse(r.Content)["foods"].ToList();

            //        //var y = r.Content;

            //        App._vmData.searchResultsExperimental3 = JsonConvert.DeserializeObject<object>(r.Content);

            //        //foreach (var jObject in JsonConvert.DeserializeObject(r.Content))
            //        //{
            //        //    App._vmData.searchResultsExperimental2.Add(JObjectToObjectMapper.mapJObjectToFood(jObject));
            //        //}
            //        App._vmData.searchResultsExperimental4 = JsonConvert.DeserializeObject<APIRootObject>(r.Content);
            //    }
            //});


        }
    }
}
