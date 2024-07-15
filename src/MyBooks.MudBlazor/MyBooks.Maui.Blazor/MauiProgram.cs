using MyBooks.Maui.Blazor.Services;
using MyBooks.Shared.Blazor;
using MyBooks.Shared.Blazor.Services;

namespace MyBooks.Maui.Blazor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddBlazorServices("https://localhost:44330/");
        builder.Services.AddSingleton<IStorageService, MauiStorageService>();
        
        return builder.Build();
    }
}
