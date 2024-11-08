using MaterialColorUtilities.Maui;
using Microsoft.Extensions.Logging;
using Sigma.Android.Services.LLM;
using Sigma.Android.Services.Storage;

namespace Sigma.Android
{
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
                })
                .UseMaterialColors();

            builder.Services.AddMauiBlazorWebView();

            builder.Services
            .AddScoped<DynamicColorService>()
            .AddScoped<LLamaInterfaceService>()
            .AddScoped<LLamaLoaderService>()
            .AddScoped<ExternalStorageService>()
            .AddScoped<SettingsService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
