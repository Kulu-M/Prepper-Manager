using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.Controller.Persistence
{

    public class Load
    {
        public static void LoadFromJson()
        {
            try
            {
                //App._vm = JsonConvert.DeserializeObject<PrepperViewModel>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json")));
                //if (App._vm == null)
                //{
                //    App._vm = new PrepperViewModel();
                //}
            }
            catch (Exception e)
            {
                //TODO ?
                //File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json"), JsonConvert.SerializeObject(App._vm));
                //Console.WriteLine(e);
            }
        }
    }
}

