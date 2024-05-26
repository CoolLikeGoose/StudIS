using Microsoft.Extensions.Logging;
using StudIS.APP.ViewModels.Student;
using StudIS.APP.Views.Student;
using StudIS.BL;
using StudIS.DAL;
using StudIS.DAL.Migrator;
using StudIS.DAL.Options;

namespace StudIS.APP;

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

        // Services
        builder.Services
            .AddDalServices(new DALOptions()
            {
                DatabaseDirectory = FileSystem.AppDataDirectory,
                DatabaseName = "StudIS.db",
                RecreateDatabaseOnStartup = true,
                SeedDemoData = true
            })
            .AddAppServices()
            .AddBlServices();
        
        var app = builder.Build();
        
        // Migration
        app.Services.GetRequiredService<IDbMigrator>().Migrate();
        
        // Routing
        Routing.RegisterRoute("//students/detail", typeof(StudentDetailView));
        Routing.RegisterRoute("//students/edit", typeof(StudentEditView));
        
        return app;
    }
}