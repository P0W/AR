
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

using PCL = Innovation.AR;
namespace Innovation.AR.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {

        Gestures ges = null;
        public MainPage()
        {
            this.InitializeComponent();
            //ges = new Gestures();

            //ges.Register();
            this.LoadApplication(new PCL.App());
        }
    }
}
