using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.Annotations;

namespace Prepper_Manager.Model
{
    public class Water : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
