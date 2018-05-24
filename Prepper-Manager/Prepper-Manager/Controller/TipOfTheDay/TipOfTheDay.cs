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
        public static ObservableCollection<string> tipsOfTheDay = new ObservableCollection<string>
        {
            "Tip of the Day: Lore preppus maximus dolor sit prepparatum amet.",
            "Tip of the Day: Never burn down your house.",
            "Tip of the Day: Go insde when it rains or you will get wet about 76% of times."
        };

        public static int counterList = 0;



        public static void startTipOfTheDayChanger()
        {
            Thread.CurrentThread.IsBackground = true;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            App._vm.tipOfTheDay = getNextTipOfTheDay();
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
