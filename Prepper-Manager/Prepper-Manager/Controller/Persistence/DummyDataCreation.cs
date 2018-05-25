using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.Model;
using Prepper_Manager.ViewModel;

namespace Prepper_Manager.Controller.Persistence
{
    public class DummyDataCreation
    {
        public static void createDummyPersons()
        {
            App._vmData.personList.Clear();
            App._vmData.personList = new System.Collections.ObjectModel.ObservableCollection<Person>();

            var p1 = new Person();
            p1.firstName = "Mohammed";
            p1.lastName = "Yass";

            var p2 = new Person();
            p2.firstName = "Babsi";
            p2.lastName = "Sprick";

            var p3 = new Person();
            p3.firstName = "Gerd";
            p3.lastName = "Möckel";

            App._vmData.personList.Add(p1);
            App._vmData.personList.Add(p2);
            App._vmData.personList.Add(p3);
        }
    }
}
