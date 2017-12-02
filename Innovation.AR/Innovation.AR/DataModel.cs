using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Innovation.AR
{
    public class CasMessage
    {

        private static Dictionary<string, Tuple<Color, Color>> casDict = new Dictionary<string, Tuple<Color, Color>>
        {
            { "airdrop fail",    new Tuple<Color, Color>( Color.White, Color.Red ) },
            { "safe mode on",    new Tuple<Color, Color>( Color.LightCyan, Color.Black ) },
            { "device ctrl on",  new Tuple<Color, Color>( Color.LightCyan, Color.Black ) },
            { "chadcs fail",     new Tuple<Color, Color>( Color.Black, Color.Yellow ) },
            { "ccp fail",    new Tuple<Color, Color>( Color.Black, Color.DarkCyan ) },

        };


        public CasMessage(string msg)
        {
            CasMessageTextBgColor = CasMessageTextColor = Color.Black;
            if (msg != "")
            {
                CasMessageText = msg;

                try
                {
                    var d = casDict[msg.ToLower()];
                    CasMessageTextColor = d.Item1;
                    CasMessageTextBgColor = d.Item2;

                }
                catch (KeyNotFoundException)
                {
                    CasMessageText = "";
                }

            }
        }

        public string CasMessageText { get; set; }
        public Color CasMessageTextColor { get; set; }

        public Color CasMessageTextBgColor { get; set; }
    }

    public class DataModel
    {
        public DataModel()
        {

            uldEnabled = false;
            casEnabled = false;
            airdropLight = 0;
            radarAltitude = "0 ft";
            timeToDrop = "0.0 sec";
            textToSpeech = "";

            casMsgList = new List<string>();
        }

        public bool uldEnabled { get; set; }
        public bool casEnabled { get; set; }
        public int airdropLight { get; set; }

        //public string masterTime { get; set;  }
        public string radarAltitude { get; set; }

        public string timeToDrop { get; set; }

        public string textToSpeech { get; set; }

        public List<string> casMsgList { get; set; }
    }
}
