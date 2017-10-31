using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Innovation.AR
{
    public class SituationAwareness : INotifyPropertyChanged
    {

        #region Properties
        public string RadarAltitude { get; set; }
        public string MasterTime { get; set; }

        public string TimeToDrop { get; set; }


        private string _colorValue;
        public string ColorValue
        {
            get
            {
                return _colorValue;
            }

            set
            {
                _colorValue = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ColorValue"));
            }
        }
        #endregion

        #region Constructors
        public SituationAwareness()
        {
            RadarAltitude = "2400.0 ft";
            TimeToDrop = "8.0 sec";

            Device.StartTimer(TimeSpan.FromMilliseconds(1000), OnTimerTick);

            MasterTime = "00:00:00";

            _colorValue = "#000000";
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        private bool OnTimerTick()
        {
            DateTime now = DateTime.Now.ToLocalTime();
            MasterTime = now.ToString("HH:mm:ss");


            PropertyChanged(this, new PropertyChangedEventArgs("MasterTime"));

            return true;
        }

        #endregion
    }
}
