using Foundation;
using Microsoft.Maui.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VertiGIS.Mobile.Platform;

namespace App1.iOS;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseSharedMauiApp()
            .UseStudioMobile();

        var result =  builder.Build();

        var test = ListAssets(string.Empty);

        var better = test.Where(s => s.Contains("app"));

        return result;
    }

    public static IEnumerable<string> ListAssets(string subfolder)
    {
        NSBundle mainBundle = NSBundle.MainBundle;
        string resourcesPath = mainBundle.ResourcePath;
        string subfolderPath = Path.Combine(resourcesPath, subfolder);

        if (Directory.Exists(subfolderPath))
        {
            string[] files = Directory.GetFiles(subfolderPath);
            return files.Select(Path.GetFileName).ToList();
        }
        else
        {
            return new List<string>();
        }
    }
}
