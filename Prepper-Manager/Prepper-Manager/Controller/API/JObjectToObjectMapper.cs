using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Prepper_Manager.Model;

namespace Prepper_Manager.Controller.API
{
    public class JObjectToObjectMapper
    {
        public static Food mapJObjectToFood(object obj)
        {
            //var propList = App._vmData.searchResultsExperimental3.GetType().GetProperties();

            var rand = App._vmData.searchResultsExperimental[0];

            var f1 = new Food();
            //f1.

            return null;
        }
    }
}
