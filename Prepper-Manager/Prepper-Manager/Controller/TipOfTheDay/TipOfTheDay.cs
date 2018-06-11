using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Prepper_Manager.Annotations;

namespace Prepper_Manager.Controller.TipOfTheDay
{
    public class TipOfTheDay : INotifyPropertyChanged
    {
        //TODO extract tips from other source
        public static ObservableCollection<string> tipsOfTheDay = new ObservableCollection<string>
        {
            "Tip of the Day: Store batteries inside a feeze - that way they last longer.",
            "Tip of the Day: Keep your supplies in a dry and cool spot.",
            "Tip of the Day: Seal your supplies to prevent pests from getting the hold of them.",
            "Tip of the Day: In case of an emergency you can fill up your bathtub with water.",
            "Tip of the Day: Many governments recommend having supplies for bad times.",
            "Tip of the Day: Never overcharge oder overdischarge your Li-Ion devices.",
            "Tip of the Day: An average human can survive 3 days without water.",
            "Tip of the Day: An average human can survive 30 days without food.",
        };

        public static int counterList;
        
        public static void startTipOfTheDayChanger()
        {
            Thread.CurrentThread.IsBackground = true;
            var timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(10)};
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            App._vmData.tipOfTheDay = getNextTipOfTheDay();
        }

        private static string getNextTipOfTheDay()
        {
            if (counterList < tipsOfTheDay.Count - 1)
            {
                counterList++;
            }
            else
            {
                counterList = 0;
            }
            return tipsOfTheDay[counterList];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

