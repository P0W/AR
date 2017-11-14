
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;

namespace Innovation.AR.Droid
{
    [Activity(Label = "Innovation.AR", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Landscape,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        private static ARModel instance = null;

        private static int keyUpPresscounter = 0;
        private static int keyDownPresscounter = 0;

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

            instance = ARModel.GetInstance;
        }

        public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.VolumeDown)
            {

                keyUpPresscounter++;

                if (keyUpPresscounter == 4)
                {
                    instance.CasEnabled = !instance.CasEnabled;
                    keyUpPresscounter = 0;
                }

            }

            if (keyCode == Keycode.VolumeUp)
            {
                keyDownPresscounter++;

                if (keyDownPresscounter == 4)
                {
                    instance.UldEnabled = !instance.UldEnabled;
                    keyDownPresscounter = 0;
                }
            }
            return true; /*base.OnKeyUp(keyCode, e);*/
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.VolumeDown)
            {
                keyUpPresscounter++;
            }

            if (keyCode == Keycode.VolumeUp)
            {
                keyDownPresscounter++;
            }
            return true; /*base.OnKeyDown(keyCode, e);*/
        }
    }


}

