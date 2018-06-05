using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prepper_Manager.Annotations;
using Prepper_Manager.Controller.Calculation;

namespace Prepper_Manager.Model
{
    public class Water : INotifyPropertyChanged
    {
        public string name { get; set; }
        public string description { get; set; }

        private double _liter;
        public double liter
        {
            get
            {
                return _liter;
            }
            set
            {
                _liter = value;
                WaterCalculation.calculateWater();
            }
        }
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
