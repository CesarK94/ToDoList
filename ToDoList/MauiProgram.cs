using Microsoft.Extensions.Logging;
using ToDoList.Pages;
using ToDoList.Services;
using ToDoList.ViewModel;

namespace ToDoList
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
          
            #if DEBUG
            builder.Services.AddSingleton<IDataService, FakeTaskService>();
            builder.Services.AddSingleton<IDataService, IFirebaseDataService>();
            #endif
            builder.Services.AddTransient<RegistroTareaPage>();
            builder.Services.AddTransient<RegistroTareaViewModel>();
            builder.Services.AddTransient<ToDoPage>();
            builder.Services.AddTransient<TodoViewModel>();

            builder
                .UseMauiApp<App>()
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
