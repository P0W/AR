
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
                instance.AirdropPhase = 2;
                return true;
            }

            if (keyCode == Keycode.VolumeUp)
            {
                return true;
            }
            return true; /*base.OnKeyUp(keyCode, e);*/
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.VolumeDown)
            {
                return true;
            }

            if (keyCode == Keycode.VolumeUp)
            {
                return true;
            }
            return true; /*base.OnKeyDown(keyCode, e);*/
        }
    }


}

