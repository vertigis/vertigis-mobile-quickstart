namespace App1.Droid;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseSharedMauiApp()
            .UseStudioMobile();

        return builder.Build();
    }
}
