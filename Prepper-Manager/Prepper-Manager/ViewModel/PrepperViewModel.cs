using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prepper_Manager.Annotations;
using Prepper_Manager.Controller.API;
using Prepper_Manager.Controller.Calculation;
using Prepper_Manager.Model;
using RestSharp;
using Food = Prepper_Manager.Model.Food;

namespace Prepper_Manager.ViewModel
{
    public class PrepperViewModel : INotifyPropertyChanged
    {
        #region Constructor / Destructor

        public PrepperViewModel()
        {
            apiSearchResults = new List<string>();
            foodList.CollectionChanged += FoodListOnCollectionChanged;
        }

        private void FoodListOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Food item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Food item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }

        private void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FoodCalculation.calculateFood();
        }

        ~PrepperViewModel()
        {

        }

        #endregion Constructor

        #region Lists - Water, Food, People

        public ObservableCollection<Food> foodList = new ObservableCollection<Food>();

        public ObservableCollection<Water> waterList = new ObservableCollection<Water>();

        public ObservableCollection<Person> personList = new ObservableCollection<Person>();

        #endregion Lists - Water, Food, People

        #region Main Page Status Messages

        private Visibility _anyExpiringFoodItemsPresent;
        public Visibility anyExpiringFoodItemsPresent
        {
            get
            {
                var expiringFoods = App._vmData.foodList.Where(food => food.expiring == Visibility.Visible);
                if (expiringFoods.Any())
                {
                    _anyExpiringFoodItemsPresent = Visibility.Visible;
                    //OnPropertyChanged();
                    return _anyExpiringFoodItemsPresent;
                }
                _anyExpiringFoodItemsPresent = Visibility.Collapsed;
                //OnPropertyChanged();
                return _anyExpiringFoodItemsPresent;
            }
            set
            {
                _anyExpiringFoodItemsPresent = value;
                OnPropertyChanged();
            }
        }

        public string totalCalorieConsumption
        {
            get
            {
                return "Your household needs " + PeopleCalculation.calculateTotalDailyCalorieConsumption() +
                       " calories per Day.";
            }
        }

        private string _waterReservesHint;
        public string waterReservesHint
        {
            get
            {
                return _waterReservesHint;
            }
            set
            {
                _waterReservesHint = value;
                OnPropertyChanged();
            }
        }
        public int waterProgress { get; set; }

        private string _foodReservesHint;
        public string foodReservesHint
        {
            get
            {
                return _foodReservesHint;
            }
            set
            {
                _foodReservesHint= value;
                OnPropertyChanged();
            }
        }
        public int foodProgress { get; set; }

        private string _peopleCountHint;
        public string peopleCountHint
        {
            get
            {
                return _peopleCountHint;
            }
            set
            {
                _peopleCountHint = value;
                OnPropertyChanged();
            }
        }

        #endregion Main Page Status Messages

        #region Testing API Stuff
        //Random TODO cleanup

        //public List<JToken> searchResultsExperimental;

        //public List<Food> searchResultsExperimental2;

        //public object searchResultsExperimental3;

        //public APIRootObject searchResultsExperimental4;

        //public string searchResultsExperimental5;
        //Random ~
        #endregion Testing API Stuff

        [JsonIgnore]
        public List<string> apiSearchResults { get; set; }

        #region Tip of the Day

        private string _tipOfTheDay;

        public string tipOfTheDay
        {
            get { return _tipOfTheDay; }
            set { _tipOfTheDay = value; OnPropertyChanged("tipOfTheDay"); }
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

