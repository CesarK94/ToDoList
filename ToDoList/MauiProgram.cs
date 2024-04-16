using Microsoft.Extensions.Logging;
using ToDoList.Pages;
using ToDoList.Services;
using ToDoList.ViewModel;
using CommunityToolkit.Maui;

namespace ToDoList
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
          
            #if DEBUG
            //builder.Services.AddSingleton<IDataService, FakeTaskService>();
            //builder.Services.AddSingleton<IDataService, FirebaseDataService>();
            builder.Services.AddSingleton<IDataService>(new FirebaseDataService());
            #endif
            builder.Services.AddTransient<RegistroTareaPage>();
            builder.Services.AddTransient<RegistroTareaViewModel>();
            builder.Services.AddTransient<ToDoPage>();
            builder.Services.AddTransient<TodoViewModel>();

            builder.Services.AddTransient<RegistroEncuesta>();
            builder.Services.AddTransient<RegistroEncuestaViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddTransient<RegistroPage>();
            builder.Services.AddTransient<RegistroViewModel>();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    // Add Material Design Icons font
                    fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
