using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Model
{
    public class Water
    {
        public string name { get; set; }
        public string description { get; set; }
        public double liter { get; set; }
        public string location { get; set; }
        public int count { get; set; }

        #region Constructor

        public Water()
        {
            count = 1;
        }

        #endregion Constructor

    }
}
