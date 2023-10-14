﻿using Budget_App.Data;
using Microsoft.Extensions.Logging;
using IgniteUI.Blazor.Controls;

namespace Budget_App
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<BudgetRepository>();
            builder.Services.AddIgniteUIBlazor(typeof(IgbCircularProgressModule));
            builder.Services.AddIgniteUIBlazor(typeof(IgbLinearGaugeModule));
            builder.Services.AddIgniteUIBlazor(typeof(IgbRadialGaugeModule));

            return builder.Build();
        }
    }
}