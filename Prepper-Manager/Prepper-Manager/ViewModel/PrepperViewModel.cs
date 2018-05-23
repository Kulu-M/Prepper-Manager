using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.Annotations;

namespace Prepper_Manager.ViewModel
{
    public class PrepperViewModel : INotifyPropertyChanged
    {
        private string _tipOfTheDay;

        public string tipOfTheDay
        {
            get { return _tipOfTheDay; }
            set { _tipOfTheDay = value; OnPropertyChanged("tipOfTheDay");}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
