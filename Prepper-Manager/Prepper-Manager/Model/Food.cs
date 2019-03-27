using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prepper_Manager.Annotations;
using Prepper_Manager.Controller.Calculation;

namespace Prepper_Manager.Model
{
    public class Food : INotifyPropertyChanged
    {
        public string name { get; set; }
        public string servingUnit { get; set; }
        public string itemName { get; set; }
        public string brandName { get; set; }
        public int count { get; set; }

        private int _calories;
        public int calories
        {
            get
            {
                return _calories;
            }
            set
            {
                FoodCalculation.calculateFood();
                _calories = value;
            }
        }

        public string location { get; set; }

        private DateTime _expirationDate;
        public DateTime expirationDate
        {
            get
            {
                return _expirationDate;
            }
            set
            {
                var time = value - DateTime.Now;
                if (time < TimeSpan.FromDays(7))
                {
                    expiring = Visibility.Visible;
                }
                else
                {
                    expiring = Visibility.Collapsed;
                }
                _expirationDate = value;
                if (ExpirationCalculation.calculateExpiringFoodItem().Any())
                {
                    App._vmData.anyExpiringFoodItemsPresent = Visibility.Visible;
                }
                else
                {
                    App._vmData.anyExpiringFoodItemsPresent = Visibility.Collapsed;
                }
                OnPropertyChanged();
            }
        }

        private Visibility _expiring;
        public Visibility expiring
        {
            get
            {
                return _expiring;
            }
            set
            {
                _expiring = value;
                OnPropertyChanged();
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
