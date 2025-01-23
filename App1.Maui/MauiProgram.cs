using Microsoft.Extensions.Logging;
using VertiGIS.Mobile.Platform;
using Esri.ArcGISRuntime.Maui;
using Esri.ArcGISRuntime.Toolkit.Maui;
using CommunityToolkit.Maui;

namespace App1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseStudioMobile()
                .UseArcGISRuntime()
                .UseArcGISToolkit()
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
