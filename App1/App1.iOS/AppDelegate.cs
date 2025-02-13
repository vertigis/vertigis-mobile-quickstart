using Foundation;
using Microsoft.Maui.Hosting;
using System.Diagnostics;
using System;
using UIKit;
using VertiGIS.Mobile;
using VertiGIS.Mobile.Platforms;
using VertiGIS.Mobile.Toolkit.Utilities;
using VertiGIS.Mobile.Toolkit.Logging;

namespace App1.iOS;

// TODO: Platform specific bootstrapping code should be migrated from AppDelegate.cs.original to AppDelegate.cs or MauiProgram.cs.
// See iOS App Lifecycle: https://learn.microsoft.com/dotnet/maui/fundamentals/app-lifecycle#ios

[Register(nameof(AppDelegate))]
public class AppDelegate : VertiGISAppDelegate
{
    private bool _hasLoaded;

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    // This method is invoked when the application has loaded and is ready to run. In this
    // method you should instantiate the window, load the UI into it and then make the window
    // visible.
    //
    // You have 17 seconds to return from this method, or iOS will terminate your application.
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        var loadTimer = Stopwatch.StartNew();

        // Handle startup urls
        // See below comment in OpenUrl, then uncomment the code below
        //SetLaunchUrl(options);

        var returnValue = base.FinishedLaunching(app, options);

        void OnLoadHandler(object sender, EventArgs args)
        {
            Logger.Info($"App Loaded in {loadTimer.Elapsed.ToLogFormat()}.");
            _hasLoaded = true;
            loadTimer.Stop();
            loadTimer = null;
            AppManager.Instance.OnLoaded -= OnLoadHandler;

            if (AppManager.ActivationOptions != null)
            {
                AppManager.RaiseReadyForLaunchOptions(AppManager.ActivationOptions);
            }
        }

        var instance = AppManager.Instance;
        if (instance != null)
        {
            AppManager.Instance.OnLoaded += OnLoadHandler;
        }

        return returnValue;
    }

    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {
        // Handle startup urls
        // Add a URL type to Info.plist, then uncomment the code below
        //if (_hasLoaded)
        //{
        //    return HandleOpenUrl(url);
        //}
        //else
        //{
        //    return true;
        //}
        return false;
    }

#pragma warning disable CA1822 // Mark members as static.
    [Export("application:supportedInterfaceOrientationsForWindow:")]
    public UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
    {
        return GetSupportedOrientations();
    }
#pragma warning restore CA1822 // Mark members as as static.
}
