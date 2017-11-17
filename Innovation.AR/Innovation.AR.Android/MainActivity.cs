
using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Speech;
using System.Collections.Generic;
using Plugin.TextToSpeech;
using Android.Content;
using Android.Speech.Tts;
using static Android.App.Application;
using Android.Text;
using Android.Media;
using System.Text;
using SkiaSharp.Views.Forms;
using SkiaSharp;
using Xamarin.Forms;


namespace Innovation.AR.Droid
{
    [Activity(Label = "Innovation.AR", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Landscape,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public TapGestureRecognizer tg;
        private readonly int VOICE = 10;
        public string textInput;
        private SpeechRecognizer sr;
        public RecognitionService rs;
        public IRecognitionListener listener;
        public static ARModel GetInstance = null;
        public static int ButtonCount;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);


            // Hide top & bottom bar https://stackoverflow.com/a/42088471/1870232
            //====================================
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            //====================================


            LoadApplication(new App());

            ARModel.GetInstance.CasEnabled = false;
            ARModel.GetInstance.UldEnabled = false;
            CrossTextToSpeech.Current.Speak(" HI LoadMaster");
            CrossTextToSpeech.Current.Speak(" Welcome to Cargo Handling Control System");
        }
      public void ProcessText(string text)
        {
            var textLower = text.ToLower();
            Toast.MakeText(this, textLower, ToastLength.Long).Show();
            if (textLower.Contains("open bundle"))
            {            
                SetContentView(Resource.Layout.layout1);
            }
            if (textLower.Contains("go back"))
            {
               
                StartActivity(typeof(MainActivity));
                var intent = new Intent(this, typeof(MainActivity))
                   .SetFlags(ActivityFlags.ReorderToFront);
                StartActivity(intent);

            }

            if ((textLower.Contains("set Air drop light")) || (textLower.Contains("set Air drop lights")) || (textLower.Contains("set lights")))
            {
                
                ARModel.GetInstance.AirdropPhase = 1;
                ARModel.GetInstance.AirdropPhase = 2;
                ARModel.GetInstance.AirdropPhase = 3;
            }
            var prjct = new List<string>() { "show cas","display crew alerting system message","display crew alerting system messages" ,"show crew alerting system message","show crew alerting system messages",
                                             "set Air drop light", "set Air drop lights","show Air drop light" ,"show Air drop lights",
                                             "show unit load device","show unit load devices","dispaly unit load device","dispaly unit load devices",};
                       
            if ((textLower.Contains("show crew alerting system message"))|| textLower.Contains("show crew alerting system messages") || textLower.Contains("dispaly crew alerting system messages") || textLower.Contains("dispaly crew alerting system message"))
            {
                ARModel.GetInstance.CasEnabled = true;
            }
            if ((textLower.Contains("show ulds")) || (textLower.Contains("dispaly load")) || (textLower.Contains("dispalay loads")) || (textLower.Contains("dispaly uld")) || (textLower.Contains("show unit load device")) || (textLower.Contains("show loads")))
            {                
                ARModel.GetInstance.UldEnabled = true;
                               
            }
        }
           
     public override bool OnKeyLongPress(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Headsethook)
            {
                Toast.MakeText(this, "HeadSet Button Clicked", ToastLength.Long).Show();
                ARModel.GetInstance.UldEnabled = false;
                ARModel.GetInstance.CasEnabled = false;              
            }

            return true;// base.OnKeyLongPress(keyCode, e);
        }           
        public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Headsethook)
            {
                
                if (ButtonCount < 1)
                {
                    TimeSpan tt = new TimeSpan(0, 0, 1);
                    Device.StartTimer(tt, TestHandleFunc);
                    
                }
                ButtonCount++;
                bool TestHandleFunc()
                {
                    if (ButtonCount > 1 && ButtonCount != 3 && ButtonCount != 4)
                    {
                       // Toast.MakeText(this, "Two Clicks", ToastLength.Long).Show();
                        ARModel.GetInstance.CasEnabled = true;


                    }
                    if (ButtonCount == 3)
                    {
                        //action for Tripel button Click here
                        CrossTextToSpeech.Current.Speak("SAFE MODE ON");
                        CrossTextToSpeech.Current.Speak("AIRDROP FAIL");
                        CrossTextToSpeech.Current.Speak("CHADCS FAIL");
                        CrossTextToSpeech.Current.Speak("LVAD FAIL");
                    }
                    if (ButtonCount == 4)
                    {
                        //action for Reset                
                        ARModel.GetInstance.UldEnabled = false;
                        ARModel.GetInstance.CasEnabled = false;
                    }
                    else
                    {
                        if (ButtonCount == 1)
                        {
                            // action for Single Click here
                            ARModel.GetInstance.UldEnabled = true;
                        }
                    }
                    ButtonCount = 0;

                    return false;
                }

            }

            if (keyCode == Keycode.VolumeDown)
            {
                sr = SpeechRecognizer.CreateSpeechRecognizer(this);
                Intent intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
                intent.PutExtra(RecognizerIntent.ExtraCallingPackage, "this package");
                intent.PutExtra(RecognizerIntent.ExtraMaxResults, 5);
                sr.StartListening(intent);
                //sr.SetRecognitionListener(RecognitionListener);
                StartActivityForResult(intent, VOICE);             
            }
            
            if (keyCode == Keycode.VolumeUp)
            {
              
                sr = SpeechRecognizer.CreateSpeechRecognizer(this);
                sr.SetRecognitionListener(listener);

                Intent intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                intent.PutExtra(RecognizerIntent.ExtraLanguage, "en-US");
                intent.PutExtra(RecognizerIntent.ExtraPreferOffline, true);
                intent.PutExtra(RecognizerIntent.ExtraPrompt, "CHADCS Is Listening");
                intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
                intent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.English);
                intent.PutExtra(RecognizerIntent.ExtraCallingPackage, "this package");
                intent.PutExtra(RecognizerIntent.ExtraMaxResults, 5);
                sr.StartListening(intent);
                StartActivityForResult(intent, VOICE);
            }

            return base.OnKeyUp(keyCode, e);
        }

    }


}

