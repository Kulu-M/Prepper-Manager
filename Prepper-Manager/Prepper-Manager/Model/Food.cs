using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prepper_Manager.Annotations;

namespace Prepper_Manager.Model
{
    public class Food : INotifyPropertyChanged
    {
        public string name { get; set; }
        public string servingUnit { get; set; }
        public string itemName { get; set; }
        public string brandName { get; set; }
        public int calories { get; set; }
        public string location { get; set; }
        public DateTime expirationDate { get; set; }

        public Visibility expiring
        {
            get
            {
                var time = expirationDate - DateTime.Now;
                if (time < TimeSpan.FromDays(7))
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }

        public string nutritionValuesString { get; set; }

        #region Constructor
        public Food()
        {
            expirationDate = DateTime.Now;
            location = "";
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
