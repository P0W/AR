
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp.Views.Forms;
using SkiaSharp;

namespace Innovation.AR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AirdropLights : ContentView
    {
        public AirdropLights()
        {
            InitializeComponent();
        }


        private static SKColor IDLE_COLOR = SKColors.DarkGray;

        private SKColor GetRedState()
        {
            return AirdropPhase == 1 ? SKColors.Red : IDLE_COLOR;
        }

        private SKColor GetYellowState()
        {
            return AirdropPhase == 2 ? SKColors.Yellow : IDLE_COLOR;
        }

        private SKColor GetGreenState()
        {
            return AirdropPhase == 3 ? SKColors.Green : IDLE_COLOR;
        }

        private void onPaintsurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            using (SKPaint paint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.WhiteSmoke,
                IsAntialias = true
            })
            {
                canvas.Clear();

                var redState = GetRedState();
                var yellowState = GetYellowState();
                var greenState = GetGreenState();

                paint.Color = redState;
                paint.Style = redState != IDLE_COLOR ? SKPaintStyle.StrokeAndFill : SKPaintStyle.Stroke;

                using (SKPath path = new SKPath())
                {

                    path.MoveTo(0, 200);
                    path.LineTo(100, 0);
                    path.LineTo(200, 200);
                    path.LineTo(0, 200);
                    path.Close();
                    canvas.DrawPath(path, paint);

                }

                SKRect middleRect = new SKRect(0, 225, 200, 325);
                paint.Color = yellowState;
                paint.Style = yellowState != IDLE_COLOR ? SKPaintStyle.StrokeAndFill : SKPaintStyle.Stroke;
                canvas.DrawRect(middleRect, paint);

                paint.Color = greenState;
                paint.Style = greenState != IDLE_COLOR ? SKPaintStyle.StrokeAndFill : SKPaintStyle.Stroke;
                canvas.DrawCircle(100.0f, 450.0f, 100.0f, paint);


            }
        }

        public static readonly BindableProperty AirdropPhaseProperty =
   BindableProperty.Create(nameof(AirdropPhase), typeof(int), typeof(AirdropLights), 0,
       BindingMode.TwoWay,
       propertyChanged: (bindable, oldvalue, newvalue) =>
       {
           ((AirdropLights)bindable).AirdropPhase = (int)newvalue;
       });

        public int AirdropPhase
        {
            get { return (int)GetValue(AirdropPhaseProperty); }
            set
            {
                SetValue(AirdropPhaseProperty, value);
                AirdropSurface.InvalidateSurface();
            }
        }

        private void ChangeAirdropPhase(object sender, SKTouchEventArgs e)
        {
            AirdropPhase = (AirdropPhase + 1) % 4;
        }
    }
}