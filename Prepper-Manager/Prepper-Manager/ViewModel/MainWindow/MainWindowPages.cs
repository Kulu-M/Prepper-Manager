using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepper_Manager.ViewModel.MainWindow
{
    public class MainWindowPage
    {
        public string name;
        public object content;


        public MainWindowPage(string inputName, object inputContent)
        {
            name = inputName;
            content = inputContent;
        }

        public string Name
        {
            get => name;
            set { }
        }
    }
}
