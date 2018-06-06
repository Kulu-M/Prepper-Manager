using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.ViewModel;

namespace Prepper_Manager.Controller.Persistence
{

    public class Load
    {
        public static void LoadFromJson()
        {
            try
            {
                App._vmData = JsonConvert.DeserializeObject<PrepperViewModel>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json")));
                if (App._vmData == null)
                {
                    App._vmData = new PrepperViewModel();
                }
            }
            catch (Exception e)
            {
                App._vmData = new PrepperViewModel();
                DummyDataCreation.createAllSampleData();
            }
        }
    }
}

