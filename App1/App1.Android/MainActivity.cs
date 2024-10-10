using Android.App;
using Android.Content.PM;
using Android.OS;
using Java.Lang;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using VertiGIS.Mobile.Platforms;
using static Java.Lang.Thread;

namespace App1.Droid;

// See Android App Lifecycle: https://learn.microsoft.com/dotnet/maui/fundamentals/app-lifecycle#android
// See MainActivity: https://learn.microsoft.com/dotnet/maui/android/manifest#activity-name

[Activity(Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    Name = "app1.mainactivity",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
public class MainActivity : VertiGISMobileActivity, IUncaughtExceptionHandler
{
    protected override void OnCreate(Bundle bundle)
    {
        DefaultUncaughtExceptionHandler = this;
        HandleExceptions();

        // The app was launched with the splash screen theme, so change it to the main theme now
        base.SetTheme(Android.Resource.Style.MainTheme);

        base.OnCreate(bundle);

        // Handle startup urls
        HandleOnCreateIntent(); // Startup urls
        HandleFullyDrawn(); // Android diagnostics
        HandleAppPermissions(); // Location, bluetooth, etc.
    }

    public void UncaughtException(Thread t, Throwable e)
    {
        //throw new System.NotImplementedException();
    }
}
