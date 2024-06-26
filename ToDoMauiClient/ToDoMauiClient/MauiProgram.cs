﻿using Microsoft.Extensions.Logging;
using ToDoMauiClient.DataSources;
using ToDoMauiClient.Pages;

namespace ToDoMauiClient
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IRestDataService, RestDataService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ManageToDoPage>();
            return builder.Build();
        }
    }
}
