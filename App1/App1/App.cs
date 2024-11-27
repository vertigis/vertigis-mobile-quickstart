using VertiGIS.Mobile;
using VertiGIS.Mobile.Infrastructure.Configuration;

namespace App1
{
    public class App : Application
    {
        public App() : base()
        {
            AppManager.Initialize(this);

            // Uncomment the following to add the styles from this page to the application.
            // Overrides default styles provided by VertiGIS.Mobile.
            //var res = new Styles().Resources;
            //Resources.MergedDictionaries.Add(res);

            MainPage = new ContentPage()
            {
                Content = GetContent()
            };

            // Register additional assemblies to search for configured assembly attributes.
            AppManager.Instance.AssemblyManager.RegisterAssemblies(this.GetType().Assembly);
        }

        protected override async void OnStart()
        {
            await AppManager.Instance.InitializeAsync();
            var appPage = await AppManager.Instance.Bootstrapper.LoadAppAsync(new Uri("resource://app.json"));
            await AppManager.Instance.Bootstrapper.DisplayAppAsync(appPage.Page);
        }

        /*
        OnSleep() and OnResume() don't seem to get called by Xamarin so we're providing the same functionality explicitly for iOS, Android.
        */

        // <inheritdoc/>
        protected override void OnSleep()
        {
            AppManager.Instance.OnBackgrounded();

            base.OnSleep();
        }

        // <inheritdoc/>
        protected override void OnResume()
        {
            // OnResume will get called when background processing begins.
            // UWP activated events are raised in UWP App.xaml.cs.
            if (DeviceInfo.Platform != DevicePlatform.WinUI)
            {
                AppManager.Instance.OnActivated();
            }

            base.OnResume();
        }

        private View GetContent()
        {
            // Stack
            var stack = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 15
            };

            // Spinner
            var spinner = new ActivityIndicator()
            {
                IsRunning = true
            };
            spinner.WidthRequest = 75;
            spinner.HeightRequest = 75;
            stack.Children.Add(spinner);

            // Label
            var label = new Label()
            {
                TextColor = Colors.Black
            };
            stack.Children.Add(label);

            void ShowStatus(object sender, LoadingEventArgs e)
            {
                if (GlobalConfiguration.Instance.StartupLoadStatus)
                {
                    label.Text = e.LoadAction;
                }
                else
                {
                    AppManager.LoadingAction -= ShowStatus;
                }
            }

            AppManager.LoadingAction += ShowStatus;

            return stack;
        }
    }
}
