using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using VertiGIS.Mobile.Platforms.Platform;

namespace App1.UWP;

// See Windows App Lifecycle: https://learn.microsoft.com/dotnet/maui/fundamentals/app-lifecycle#windows

public partial class App : MauiWinUIApplication
{
    public App()
    {
        InitializeComponent();
        AppHandlers.HandleExceptions(this);
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs launchArgs)
    {
        base.OnLaunched(launchArgs);

        AppHandlers.HandleOnLaunched();
    }
}
