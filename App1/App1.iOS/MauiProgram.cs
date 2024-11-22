using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;
using VertiGIS.Mobile.Platform;

namespace App1.iOS;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseStudioMobile()
            .UseSharedMauiApp();

        return builder.Build();
    }
}
