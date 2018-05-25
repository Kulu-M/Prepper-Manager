using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.Annotations;
using Prepper_Manager.Model;

namespace Prepper_Manager.ViewModel
{
    public class PrepperViewModel : INotifyPropertyChanged
    {
        public string waterReservesHint { get; set; }

        public string foodReservesHint { get; set; }

        #region Constructor

        public PrepperViewModel()
        {

        }

        #endregion Constructor

        #region People

        public ObservableCollection<Person> personList = new ObservableCollection<Person>();

        #endregion People
        
        #region Tip of the Day

        private string _tipOfTheDay;

        public string tipOfTheDay
        {
            get { return _tipOfTheDay; }
            set { _tipOfTheDay = value; OnPropertyChanged("tipOfTheDay");}
        }

        #endregion Tip of the Day

        #region INotify

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotify
    }
}
