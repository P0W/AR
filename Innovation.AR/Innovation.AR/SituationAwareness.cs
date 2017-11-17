using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Innovation.AR
{
    public class SituationAwareness : INotifyPropertyChanged
    {

        #region Properties
        private string _radarAltitude;
        public string RadarAltitude
        {
            get
            {
                return _radarAltitude;
            }

            set
            {
                if (value != _radarAltitude)
                {
                    _radarAltitude = String.Format("{0:0.0#} ft", value);
                    PropertyChanged(this, new PropertyChangedEventArgs("RadarAltitude"));
                }
            }
        }

        public string MasterTime { get; set; }

        private string _timeToDrop;
        public string TimeToDrop
        {
            get
            {
                return _timeToDrop;
            }

            set
            {
                if (value != _timeToDrop)
                {
                    _timeToDrop = String.Format("{0:0.0#} sec", value);
                    PropertyChanged(this, new PropertyChangedEventArgs("TimeToDrop"));
                }
            }
        }


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
            _radarAltitude = "2400";
            _timeToDrop = "8.2";

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
