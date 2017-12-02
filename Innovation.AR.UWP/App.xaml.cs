using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


using System.Collections.Generic;
using System.Reflection;

using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using Windows.Media.SpeechRecognition;
using System.Diagnostics;
using Windows.UI.Core;
using System.Text;

namespace Innovation.AR.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {

        SpeechRecognizer rec;
        CoreDispatcher dispatcher;
        SpeechRecognitionCompilationResult grammar = null;
        string originalEditorText;
        StringBuilder dictatedText = null;
        DispatcherTimer t1;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;


           
            //rec = new SpeechRecognizer();
            
            //rec.ContinuousRecognitionSession.Completed += OnRecognitionSessionCompleted;
            //rec.ContinuousRecognitionSession.ResultGenerated += OnRecognitionSessionResultGenerated;
            //rec.HypothesisGenerated += OnRecognationHypothesisGenerated;
            //rec.UIOptions.ShowConfirmation = true;

            //rec.StateChanged += RecOnStateChanged;

            //t1 = new DispatcherTimer();

            //t1.Interval = new TimeSpan(0, 0, 1);

            //t1.Tick += T1_Tick;

            //t1.Start();


        }

        private async void T1_Tick(object sender, object e)
        {
            if (rec.State == SpeechRecognizerState.Idle)
            {
                if (grammar == null)
                    grammar = await rec.CompileConstraintsAsync();

                if (dictatedText == null)
                    dictatedText = new StringBuilder();
                else
                    dictatedText.Clear();

                originalEditorText = "Hello World";

                await rec.ContinuousRecognitionSession.StartAsync();

               // t1.Stop();
            }
            else if (rec.State == SpeechRecognizerState.Processing)
            {
              //  t1.Start();
            }
            else
            {
                await rec.ContinuousRecognitionSession.CancelAsync();
            }
        }

        private void RecOnStateChanged(SpeechRecognizer sender, SpeechRecognizerStateChangedEventArgs args)
        {
            Debug.WriteLine("Speech recognition state = {0}", args.State.ToString());
        }

        private async void OnRecognationHypothesisGenerated(SpeechRecognizer sender, SpeechRecognitionHypothesisGeneratedEventArgs args)
        {
            Debug.WriteLine("Hypotheses generated = " + args.Hypothesis.Text);

            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Debug.WriteLine(originalEditorText + dictatedText.ToString() + args.Hypothesis.Text + "...");
            });
        }

        private async void OnRecognitionSessionResultGenerated(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionResultGeneratedEventArgs args)
        {
            Debug.WriteLine("OnRecognitionSessionResultGenerated condifence = {0} Text = {1}",
                args.Result.Confidence.ToString(), args.Result.Text);

            dictatedText.Append(args.Result.Text);

            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Debug.WriteLine(" OnRecognitionSessionResultGenerated Result = " + originalEditorText + dictatedText.ToString());
            });
        }

        private async void OnRecognitionSessionCompleted(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionCompletedEventArgs args)
        {
            Debug.WriteLine("OnRecognitionSessionCompleted status = {0}" , args.Status.ToString());

            if (args.Status == SpeechRecognitionResultStatus.UserCanceled)
            {
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Debug.WriteLine(" OnRecognitionSessionCompleted Result = " + originalEditorText + dictatedText.ToString());
                });
            }
        }



        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                List<Assembly> assembliesToInclude = new List<Assembly>();

                //Now, add in all the assemblies your app uses
                assembliesToInclude.Add(typeof(ITextToSpeech).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(TextToSpeech).GetTypeInfo().Assembly);

                Xamarin.Forms.Forms.Init(e, assembliesToInclude);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }

            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;

                if (titleBar != null)
                {
                    titleBar.BackgroundColor = Colors.Transparent;
                }
            }


            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        }



        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
