using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Innovation.AR
{
    public class ARModel : INotifyPropertyChanged
    {

        #region Constructors

        private static volatile object lockObject = new object();
        private static ARModel instance;

        public AirdropLights AirdropLightsContext { get; private set; }
        public SituationAwareness SituationAwarenessContext { get; private set; }

        private ARModel()
        {
            _airdropPhase = 0;
            _uldEnabled = true;
            _casEnabled = true;
            Initialise();
        }

        private void Initialise()
        {
            SituationAwarenessContext = new SituationAwareness();
            AirdropLightsContext = new AirdropLights();
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #region Properties
        private int _airdropPhase;
        public int AirdropPhase
        {
            get
            {
                return _airdropPhase;
            }

            set
            {
                if (value != _airdropPhase)
                {
                    _airdropPhase = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _casEnabled;
        public bool CasEnabled
        {
            get
            {
                return _casEnabled;
            }

            set
            {
                if (value != _casEnabled)
                {
                    _casEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _uldEnabled;
        public bool UldEnabled
        {
            get
            {
                return _uldEnabled;
            }

            set
            {
                if (value != _uldEnabled)
                {
                    _uldEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public static ARModel GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new ARModel();
                        }
                    }
                }
                return instance;
            }
        }



    }
}
