using Newtonsoft.Json;
using Plugin.TextToSpeech;
using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


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


        private TcpSocketListener jsonTcpListener = null;
        private DataModel myModel = null;


        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = ARModel.GetInstance;

            // populate picker with available colors
            foreach (string colorName in colorDict.Keys)
            {
                settingsColorPicker.Items.Add(colorName);
            }
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

                            await UpdateUI();
                        }
                        catch
                        {

                        }
                        
                    }

                }
            };

            // bind to the listen port across all interfaces
            await jsonTcpListener.StartListeningAsync(speechListenPort);
        }

        private async Task UpdateUI()
        {
            ARModel.GetInstance.CasEnabled = myModel.casEnabled;
            ARModel.GetInstance.AirdropPhase = myModel.airdropLight;
            ARModel.GetInstance.UldEnabled = myModel.uldEnabled;
            ARModel.GetInstance.SituationAwarenessContext.TimeToDrop = myModel.timeToDrop;
            ARModel.GetInstance.SituationAwarenessContext.RadarAltitude = myModel.radarAltitude;

            await CrossTextToSpeech.Current.Speak(myModel.textToSpeech);
        }

        protected async override void OnAppearing()
        {
            await CreateJsonTcpListener();
        }
    }
}
