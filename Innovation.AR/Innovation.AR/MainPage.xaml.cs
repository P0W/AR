using Newtonsoft.Json;

using Plugin.TextToSpeech;
using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.SpeechRecognition;
using System.Diagnostics;

namespace Innovation.AR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        Dictionary<string, string> colorDict = new Dictionary<string, string>()
        {
            { "Default", "#000000" },       { "Amber", "#FFC107" },
            { "Black", "#212121" },         { "Blue", "#2196F3" },
            { "Blue Grey", "#607D8B" },     { "Brown", "#795548" },
            { "Cyan", "#00BCD4" },          { "Dark Orange", "#FF5722" },
            { "Dark Purple", "#673AB7" },   { "Green", "#4CAF50" },
            { "Grey", "#9E9E9E" },          { "Indigo", "#3F51B5" },
            { "Light Blue", "#02A8F3" },    { "Light Green", "#8AC249" },
            { "Lime", "#CDDC39" },          { "Orange", "#FF9800" },
            { "Pink", "#E91E63" },          { "Purple", "#94499D" },
            { "Red", "#D32F2F" },           { "Teal", "#009587" },
            { "White", "#FFFFFF" },         { "Yellow", "#FFEB3B" },

        };

        static private volatile string greetText = "";

        private TcpSocketListener jsonTcpListener = null;
        private DataModel myModel = new DataModel();
        private List<string> oldList = new List<string>();

        private ISpeechRecognizer speech;

        IObservable<string> listener = null;

        public MainPage()
        {


            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = ARModel.GetInstance;

            // populate picker with available colors
            //foreach (string colorName in colorDict.Keys)
            //{
            //    settingsColorPicker.Items.Add(colorName);
            //}

            InitializeComponent();

            // Ugly way to update UI, this is work-around to avoid update of ObservableCollection on Async Task
            // Device.StartTimer(TimeSpan.FromMilliseconds(500), UpdateView);

            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    speech = CrossSpeechRecognition.Current;
                    listener = speech.ListenUntilPause();
                    Device.StartTimer(TimeSpan.FromMilliseconds(10), ListenPhrase);


                    break;
                default:
                    break;
            }


        }


        private bool ListenPhrase()
        {

            try
            {
                listener.Subscribe(phrase =>
                {
                    Debug.WriteLine("Phrases Retuned :" + phrase);
                    var msg = phrase.Trim().ToLower();
                    if (msg.Contains("show cargos") || msg.Contains("show car goes") || msg.Contains("display cargos") || msg.Contains("display car goes"))
                    {
                        ARModel.GetInstance.UldEnabled = true;
                    }
                    else if (msg.Contains("clear cargos") || msg.Contains("clear car goes"))
                    {
                        ARModel.GetInstance.UldEnabled = false;
                    }

                    else if (msg.Contains("show messages") || msg.Contains("display messages"))
                    {
                        ARModel.GetInstance.CasEnabled = true;
                    }
                    else if (msg.Contains("clear messages"))
                    {
                        ARModel.GetInstance.CasEnabled = false;
                    }
                    else if (msg.Contains("show all") || msg.Contains("display all"))
                    {
                        ARModel.GetInstance.ShowAll = true;
                    }
                    else if (msg.Contains("clear all"))
                    {
                        ARModel.GetInstance.ShowAll = false;
                    }

                });
            }
            catch
            {
                Debug.WriteLine("Exception While Listening Phrase");
            }
            return true;
        }

        private bool UpdateView()
        {
            try
            {

                if (!Enumerable.SequenceEqual(oldList.OrderBy(t => t), myModel.casMsgList.OrderBy(t => t)))
                {
                    ARModel.GetInstance.CasList.Clear();
                    foreach (string msg in myModel.casMsgList)
                    {
                        ARModel.GetInstance.CasList.Add(new CasMessage(msg.Trim()));
                    }

                    oldList = myModel.casMsgList;
                }
            }

            catch
            {

            }

            return true;
        }

        private void TapColorPicker_Tapped(object sender, EventArgs e)
        {
            settingsColorPicker.Focus();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            ARModel.GetInstance.SituationAwarenessContext.ColorValue = colorDict[picker.Items[picker.SelectedIndex]];
        }

        private async Task CreateJsonTcpListener()
        {
            var speechListenPort = 12000;
            jsonTcpListener = new TcpSocketListener();


            jsonTcpListener.ConnectionReceived += async (sender, args) =>
            {
                var client = args.SocketClient;

                var bytesRead = -1;
                var buf = new byte[1024];

                while (bytesRead != 0)
                {
                    bytesRead = await args.SocketClient.ReadStream.ReadAsync(buf, 0, 1024);
                    if (bytesRead > 0)
                    {
                        var text = Encoding.UTF8.GetString(buf, 0, bytesRead);

                        // Ugly hack to avoid crash
                        try
                        {
                            myModel = JsonConvert.DeserializeObject<DataModel>(text);


                            Device.BeginInvokeOnMainThread(() =>
                            {
                                UpdateUI();
                                UpdateView();
                            });



                        }
                        catch
                        {
                            myModel.textToSpeech = "";
                        }


                    }

                }
            };

            // bind to the listen port across all interfaces
            await jsonTcpListener.StartListeningAsync(speechListenPort);
        }

        private void UpdateUI()
        {
            ARModel.GetInstance.CasEnabled = myModel.casEnabled;
            ARModel.GetInstance.AirdropPhase = myModel.airdropLight;
            ARModel.GetInstance.UldEnabled = myModel.uldEnabled;
            ARModel.GetInstance.SituationAwarenessContext.TimeToDrop = myModel.timeToDrop;
            ARModel.GetInstance.SituationAwarenessContext.RadarAltitude = myModel.radarAltitude;
            ARModel.GetInstance.ShowAll = !myModel.clearAll;

            greetText = myModel.textToSpeech.Trim();
            if (greetText != "")
            {
                CrossTextToSpeech.Current.Speak(greetText, pitch: 1.5f);
            }
        }

        protected async override void OnAppearing()
        {
            await CreateJsonTcpListener();
        }
    }
}
