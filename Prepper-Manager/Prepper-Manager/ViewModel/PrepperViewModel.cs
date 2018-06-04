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
            foodList.CollectionChanged += FoodListOnCollectionChanged;
        }

        // https://msdn.microsoft.com/en-us/library/ms653375.aspx?f=255&MSPPError=-2147217396
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

        public ObservableCollection<Food> foodList = new ObservableCollection<Food>();

        public ObservableCollection<Water> waterList = new ObservableCollection<Water>();

        public string waterReservesHint { get; set; }

        public string foodReservesHint { get; set; }

        //Random TODO cleanup

        public List<JToken> searchResultsExperimental;

        public List<Food> searchResultsExperimental2;

        public object searchResultsExperimental3;

        public APIRootObject searchResultsExperimental4;

        public string searchResultsExperimental5;
        //Random ~

        [JsonIgnore]
        public List<string> apiSearchResults { get; set; }

       

        #region People

        public ObservableCollection<Person> personList = new ObservableCollection<Person>();

        #endregion People

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

