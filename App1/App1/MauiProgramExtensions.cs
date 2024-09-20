using Esri.ArcGISRuntime.Maui;
using Esri.ArcGISRuntime.Toolkit.Maui;
using CommunityToolkit.Maui;

namespace App1;
public static class MauiProgramExtensions
{
    public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
    {
        builder.UseMauiApp<App>()
            .UseArcGISRuntime()
            .UseArcGISToolkit()
            .UseMauiCommunityToolkit();
        // TODO: Add the entry points to your Apps here.
        // See also: https://learn.microsoft.com/dotnet/maui/fundamentals/app-lifecycle
        //builder.Services.AddTransient<AppShell, AppShell>();
        return builder;
    }
}
