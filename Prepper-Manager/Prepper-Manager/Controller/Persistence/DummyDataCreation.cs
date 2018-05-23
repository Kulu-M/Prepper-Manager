using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.ViewModel;

namespace Prepper_Manager.Controller.Persistence
{
    public class DummyDataCreation
    {
        public static PrepperViewModel createDummyViewModel()
        {
            PrepperViewModel _vm = new PrepperViewModel();
            _vm.tipOfTheDay = "Tip of the Day: Lore preppus maximus dolor sit prepparatum amet.";

            return _vm;
        }
    }
}
