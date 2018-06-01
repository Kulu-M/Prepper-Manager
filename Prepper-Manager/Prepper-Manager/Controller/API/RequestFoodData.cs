using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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
                    App._vmData.searchResults = JObject.Parse(r.Content)["common"].Select(p => p["food_name"].Value<string>()).ToList();
                }
            });
        }
    }
}
